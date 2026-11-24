# PHP via Java

- Put `use` imports at the beginning of every code block and reference imported types by their short
  names. Do not use fully qualified class names in sample bodies.
- In prose, FAQ text, and link labels, separate a PHP class from its method with `::`, as in
  `Presentation::save`; never write a class-qualified PHP method as `Presentation.save`.
- In samples with explicit cleanup, call `dispose` directly in `finally` when the object was created
  before `try`. If construction inside `try` can fail before assignment, initialize the variable to
  `null` first and check that it holds an object before disposing it.
