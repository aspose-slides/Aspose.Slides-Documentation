# Node.js via Java and Node.js via .NET

- In samples with explicit cleanup, call `dispose` directly in `finally` when the object was created
  before `try`. If construction inside `try` can fail before assignment, initialize the variable to
  `null` first and check that it holds an object before disposing it.
