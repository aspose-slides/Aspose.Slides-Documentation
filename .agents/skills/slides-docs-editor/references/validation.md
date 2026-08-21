# Code sample validation

Validate only code fences whose contents changed in the current edit. Do not compile or run unchanged
examples from the same article or platform.

Identify the changed code fences from the diff, then use the existing checker for the article's
platform and read its `README.md` when present. If the checker cannot select individual fences and
would process the entire article, give it a temporary Markdown input containing only the changed
fences. Use the source article directly only when every code fence in it changed. Keep temporary
inputs within the existing checker, remove them after validation, and do not modify the source article
for the sake of validation. Do not create an ad hoc project or install another product copy.

Platform policies:

- **.NET:** Use `tools/net/` to compile and run only the changed examples. Verify the relevant in-memory
  state. When an example saves output, reopen it and confirm the described objects, properties, or
  content. Extend the existing validator with only the minimum temporary invocation or assertions
  needed.
- **Android via Java:** Use `tools/androidjava/snippet-check/` to compile only the changed examples.
  Do not start an emulator, connect a device, install an APK, or execute snippets at runtime.
- **All other platforms:** Use `tools/<platform>/` to compile only the changed examples. Their
  documentation checks are compile-only; do not execute the examples or require runtime-result
  verification.

For checkers that accept a Markdown input path, pass either the source article when allowed above or
the targeted temporary input as `<validation-input>`:

```powershell
powershell -ExecutionPolicy Bypass -File tools\net\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\java\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\cpp\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\androidjava\snippet-check\check-snippets.ps1 -Article <validation-input>
powershell -ExecutionPolicy Bypass -File tools\nodejs-java\snippet-check\check-snippets.ps1 -Article <validation-input>
```

For Python platforms, follow `tools/python-net/snippet-check/README.md` or
`tools/python-java/snippet-check/README.md` and use the supplied launcher. For other platforms, inspect
`tools/<platform>/snippet-check/` and reuse its dependencies and runtime.

In the final report, state for every changed article whether its changed code examples were compiled.
Include the result when compilation was performed; when no code fence changed, state `code unchanged`.
