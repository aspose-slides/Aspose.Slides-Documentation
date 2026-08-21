---
name: slides-docs-editor
description: Edit, review, translate, or validate Aspose.Slides Hugo documentation articles in this repository, including front matter, shortcodes, links, headings, and platform code samples. Do not use for unrelated tooling or application code.
---

# Slides documentation editor

1. Always read [article-format.md](references/article-format.md) before changing or reviewing an article.
2. For a non-English article, also read [translations.md](references/translations.md).
3. If code samples or public API descriptions are changed or technically reviewed, also read
   [code-samples.md](references/code-samples.md).
4. If a code sample changed, also read [validation.md](references/validation.md) and use only the
   policy and checker for the article's platform.
5. Run `ruby tools/docs-check.rb --links <article...>` for every changed article; add `--external`
   when HTTP(S) links are present. When code changed, follow the platform policy in
   [validation.md](references/validation.md).
6. Report only changed files, checks performed, and unresolved issues; do not paste full files,
   diffs, or successful command logs.
