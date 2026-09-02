# Code sample validation

Every new or changed code fence must pass the platform's compilation check before the edit is
considered complete. Apply this rule only to fences added or modified in the current diff; do not
compile or run unchanged examples from the same article or platform. A parser or syntax-only check
does not count as compilation. For an interpreted platform that has no applicable compilation step,
run the strongest platform-equivalent validation that loads the real Aspose.Slides API and report it
explicitly as non-compilation validation. Do not claim that a sample was compiled when only syntax
parsing or runtime execution was performed.

Identify the applicable code fences from the diff, then use the existing checker for the article's
platform and read its `README.md` when present. If the checker cannot select individual fences and
would process the entire article, give it a temporary Markdown input containing only the changed
fences. Use the source article directly only when every code fence in it changed. Keep temporary
inputs within the existing checker, remove them after validation, and do not modify the source article
for the sake of validation. Do not create an ad hoc project or install another product copy.

Platform policies:

- **.NET:** Use `tools/net/` to compile and run only the applicable examples. Verify the relevant in-memory
  state. When an example saves output, reopen it and confirm the described objects, properties, or
  content. Extend the existing validator with only the minimum temporary invocation or assertions
  needed.
- **Android via Java:** Use `tools/androidjava/snippet-check/` to compile only the applicable examples.
  Do not start an emulator, connect a device, install an APK, or execute snippets at runtime.
- **Node.js via Java:** JavaScript has no applicable compile step in this repository. A successful
  `node --check` result is syntax-only and is insufficient by itself. Run the checker with `-Docker`
  so it performs both the syntax check and execution of only the applicable examples against the real
  `aspose.slides.via.java` package. Report `compilation: not applicable`, followed by the syntax and
  API runtime results separately.
- **All other platforms:** Use `tools/<platform>/` to compile only the applicable examples. Their
  documentation checks are compile-only; do not execute the examples or require runtime-result
  verification.

For checkers that accept a Markdown input path, pass either the source article when allowed above or
the targeted temporary input as `<validation-input>`:

```powershell
powershell -ExecutionPolicy Bypass -File tools\net\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\java\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\cpp\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\androidjava\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\nodejs-java\snippet-check\check-snippets.ps1 -Article <validation-input> -Docker
```

For Python platforms, follow `tools/python-net/snippet-check/README.md` or
`tools/python-java/snippet-check/README.md` and use the supplied launcher. For other platforms, inspect
`tools/<platform>/snippet-check/` and reuse its dependencies and runtime.

In the final report, state for every article covered by this rule whether its applicable code examples were compiled.
Use one of `compilation: passed`, `compilation: failed`, or `compilation: not applicable`. For
`not applicable`, name each required platform-equivalent check and its result. If a required check was
not run or failed, report that as an unresolved issue instead of presenting the edit as complete. When
no code fence changed, state `code unchanged`.

For every .NET article with changed code examples, also report the result of behavioral verification.
Use `runtime behavior: passed — the examples perform the operations described in the article` only
after running every applicable example and verifying its required state, saved output, and described
effects. Compilation alone is not evidence of correct behavior. If an applicable .NET example fails
behavioral verification or was not run, use `runtime behavior: failed` and describe the unresolved
issue instead of claiming that the examples work as required.

Do not report behavioral verification for non-.NET articles. Their final reports are limited to the
compilation status or, when compilation is not applicable, the platform-equivalent checks explicitly
required above.
