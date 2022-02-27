﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
	public class HtmlElement
	{
		public string Name, Text;
		public List<HtmlElement> Elements = new List<HtmlElement>();

		private const int indentSize = 2;

		public HtmlElement()
		{

		}

		public HtmlElement(string name, string text)
		{
			if (name == null)
			{
				throw new ArgumentNullException(paramName: "Name");
			}
			if (text == null)
			{
				throw new ArgumentNullException(paramName: "Name");
			}
			Name = name;
			Text = text;
		}

		private string ToStringImpl(int indent)
		{
			var sb = new StringBuilder();
			var i = new string(' ', indentSize * indent);
			sb.AppendLine(string.Format("{0}<{1}>", i, Name));

			if (!string.IsNullOrWhiteSpace(Text))
			{
				sb.Append(new string(' ', indentSize * (indent + 1)));
				sb.AppendLine(Text);
			}

			foreach (var e in Elements)
			{
				sb.Append(e.ToStringImpl(indent + 1));
			}

			sb.AppendLine(string.Format("{0}</{1}>", i, Name));

			return sb.ToString();
		}

		public override string ToString()
		{
			return ToStringImpl(0);
		}
	}

	public class HtmlBuilder
	{
		private readonly string rootName;
		HtmlElement root = new HtmlElement();

		public HtmlBuilder(string rootName)
		{
			this.rootName = rootName;
			root.Name = rootName;
		}

		public HtmlBuilder AddChild(string childName, string childText)
		{
			var e = new HtmlElement(childName, childText);
			root.Elements.Add(e);

			return this;
		}

		public override string ToString()
		{
			return root.ToString();
		}

		public void Clear()
		{
			root = new HtmlElement { Name = rootName };
		}
	}

	public class Demo
	{
		static void Main(string[] args)
		{
			var hello = "hello";
			var sb = new StringBuilder();
			sb.Append("<p>"); 
			sb.Append(hello);
			sb.Append("</p>");
			Console.WriteLine(sb);

			var words = new[] { "hello", "world" };
			sb.Clear();
			sb.Append("<ul>");
			foreach (var word in words)
			{
				sb.AppendFormat("<li>{0}</li>", word);
			}
			sb.Append("</li>");
			Console.WriteLine(sb);

			// with Builder design pattern:
			var builder = new HtmlBuilder("ul");
			builder
				.AddChild("li", "hello")
				.AddChild("li", "world");
			Console.WriteLine(builder.ToString());
		}
	}
}
