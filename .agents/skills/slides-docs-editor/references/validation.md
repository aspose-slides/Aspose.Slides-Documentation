# Code sample validation

Use only the checker for the article's platform. Read its `README.md` when present. Except for Android
via Java, a successful exit code is insufficient: run behavior checks and inspect generated output
when the article promises a saved artifact.

Android via Java validation is compile-only. Compile every Java snippet with the Android checker, but
do not start an emulator, connect a device, install an APK, or execute the snippets at runtime.

For checkers that accept an article path:

```powershell
powershell -ExecutionPolicy Bypass -File tools\net\snippet-check\check-snippets.ps1 -Article <article>
powershell -ExecutionPolicy Bypass -File tools\java\snippet-check\check-snippets.ps1 -Article <article>
powershell -ExecutionPolicy Bypass -File tools\cpp\snippet-check\check-snippets.ps1 -Article <article>
powershell -ExecutionPolicy Bypass -File tools\androidjava\snippet-check\check-snippets.ps1 -Article <article>
powershell -ExecutionPolicy Bypass -File tools\nodejs-java\snippet-check\check-snippets.ps1 -Article <article>
```

For Python platforms, follow `tools/python-net/snippet-check/README.md` or
`tools/python-java/snippet-check/README.md` and use the supplied launcher. For other platforms, inspect
`tools/<platform>/snippet-check/` and reuse its dependencies and runtime.
