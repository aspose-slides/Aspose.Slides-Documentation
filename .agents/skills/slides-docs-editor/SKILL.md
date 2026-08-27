---
name: slides-docs-editor
description: Edit, review, translate, or validate Aspose.Slides Hugo documentation articles in this repository, including front matter, shortcodes, links, headings, and platform code samples. Do not use for unrelated tooling or application code.
---

# Slides documentation editor

1. Always read [article-format.md](references/article-format.md) before changing or reviewing an article.
2. For a non-English article, also read [translations.md](references/translations.md).
3. If code samples or public API descriptions are edited or technically reviewed, also read
   [code-samples.md](references/code-samples.md).
4. For any edit involving code samples, read [validation.md](references/validation.md) and treat it
   as the single source of truth for validation scope, platform checks, completion criteria, and
   final reporting.
5. Run `ruby tools/docs-check.rb --links <article...>` for every changed article; add `--external`
   when HTTP(S) links are present.
6. Report only changed files, checks performed, and unresolved issues; do not paste full files,
   diffs, or successful command logs. Follow [validation.md](references/validation.md) for required
   code-validation reporting.
