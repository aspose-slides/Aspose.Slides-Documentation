# C#

- Use modern using declarations such as `using var presentation = new Presentation();`.
- Use `var` where the type is inferred; retain explicit types where C# requires them.
- In samples with explicit cleanup, call `Dispose` directly in `finally` when the object was created
  before `try`. If construction inside `try` can fail before assignment, initialize the variable to
  `null` first and check that it holds an object before disposing it.
