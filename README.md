# Design patterns



### 1. The SOLID Design Principles

### 2. Builder

When piecewise object construction is complicated, provide an API for doing it succinctly.

**<u>Motivation</u>**

- some objects are simple and can be created in a single constructor call;
- other objects require a lot of ceremony to create;
- having an object with 10 constructor arguments is not productive;
- instead, opt for piecewise construction;
- builder provides an API for constructing an object step-by-step;

**<u>Summary</u>**

-  a builder is a separate component for building an object;
-  can either give builder a constructor or return it via static function;
-  to make builder fluent, return ***this***;
-  different facets of an object can be built with different builders working in tandem via a base class;

## 3. Factories

A component responsible solely for the wholesale (not piecewise) creation of objects.

**<u>Motivation</u>**

- object creation logic becomes too convoluted;
- constructor is not descriptive:
  - name mandated by name of containing type;
  - cannot overload with same sets of arguments with different names;
  - can turn into "optional parameter hell";
- object creation (non piecewise, unlike Builder) can be outsourced to
  - a separate function (Factory Method);
  - that may exist in a separate class (Factory);
  - can create hierarchy of factories with Abstract Factory; 


**<u>Summary</u>**

- a factory method is a static method that creates objects;
- a factory can take care of object creation;
- a factory can be external or reside inside the object as an inner class;
- hierarchies of factories can be used to create related objects;