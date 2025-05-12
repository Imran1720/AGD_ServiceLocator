# 🎯 Understanding Design Patterns: Singleton, Service Locator & Dependency Injection

This was a premade Unity project used as a foundation to explore and understand three core design patterns: Singleton, Service Locator, and Dependency Injection.
Through hands-on implementation, I learned:
<ul>
  <li>What each pattern does.</li>
  <li>Their real-world pros and cons.</li>
  <li>When and why to use them in game development.</li>
</ul>

The focus was purely on grasping design principles, not building the project from scratch.

## Singleton
Singleton is a design pattern that ensures a class has only one instance and provides a global access point to it.

<b>User Case:</b> Can be used when <b>Prototyping</b>.
<b>Pros:</b> <ul>
  <li>Makes the communication between the classes easier.</li>
  <li>Ensure that there is only single instance for the class</li>
  <li>Simple to implement</li>
</ul>

<b>Cons:</b> <ul>
<li>Makes the class highly dependend on other or makes classes highly coupled.</li>
<li>Hides the dependencies.</li>
<li>Fails in unit testing.</li>
<li>Difficult to debug.</li>
</ul>

## Service Locator
Service Locator is a design pattern that provides a centralized system to access the services from a single point or class.

<b>User Case:</b> Can be used when building a <b>Mid-Scale project</b> as it is considered as a balanced solution.
<b>Pros:</b> <ul>
<li>Centralized instance/service management.</li>
<li>Simplifies access to the servies</li>
<li>Improves Bug fixing.</li>
</ul>

<b>Cons:</b> <ul>
<li>Has the same disadvantages as singleton but on reduced scale.</li>
<li>Fails at unit test.</li>
<li>still hides the dependencies</li>
</ul>

## Dependency Injection (DI)
Dependency Injection is a programming principle that lets you create classes that are losely coupled.

<b>User Case:</b> Can be used when building a <b>Large-Scale project</b> as it is considered as a balanced solution.
<b>Types Used:</b> <ul>
<li><b>Constructor Injection:</b> Dependencies are passed through a class’s constructor.</li>
<li><b>Method Injection:</b> Dependencies are passed directly into methods.</li>
</ul>
<b>Pros:</b> 
<ul>
  <li>Improves unit testing.</li>
  <li>Helps in creating loosely coupled classes.</li>
  
</ul>
<b>Cons:</b> 
<ul>
  <li>Increases complexity in code structure.</li>
</ul>

<b>📚 Goal:</b> The main goal here was to learn how to manage dependencies properly in Unity/C# using different patterns — and understand their real-world trade-offs.
