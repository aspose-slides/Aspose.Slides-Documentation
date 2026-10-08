---
name: slides-docs-editor
description: Edit, review, translate, or validate Aspose.Slides Hugo documentation articles in this repository, including front matter, shortcodes, links, headings, and platform code samples. Do not use for unrelated tooling or application code.
---

# Slides documentation editor

1. Always read [article-format.md](references/article-format.md) before changing or reviewing an article.
2. For a non-English article, also read [translations.md](references/translations.md).
3. If code samples or public API descriptions are edited or technically reviewed, also read
   [code-samples.md](references/code-samples.md).
4. When adding or changing code fences, or validating samples, read
   [validation.md](references/validation.md). Load only the platform references routed by these files.
5. Check article structure and local links according to `article-format.md`. For HTTP(S) links,
   read [link-checking.md](references/link-checking.md) and run the Python checker for every
   changed article. Do not use the Ruby validator.
6. Report only changed files, checks performed, and unresolved issues; do not paste full files,
   diffs, or successful command logs. For changed code, follow the validation reporting rules;
   otherwise state `code unchanged`.
