# Java and Android via Java

- Put import declarations at the beginning of every code block and reference imported types by their
  short names. Do not use fully qualified class names in sample bodies.
- In samples with explicit cleanup, call `dispose` directly in `finally` when the object was created
  before `try`. If construction inside `try` can fail before assignment, initialize the variable to
  `null` first and check that it holds an object before disposing it.
