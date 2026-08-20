---
name: slides-docs-editor
description: Edit, review, translate, or validate Aspose.Slides Hugo documentation articles in this repository, including front matter, shortcodes, links, headings, and platform code samples. Do not use for unrelated tooling or application code.
---

# Slides documentation editor

Work only on the requested article files and the minimum validation artifacts needed for them.

1. Always read [article-format.md](references/article-format.md) before changing or reviewing an article.
2. If code samples or public API descriptions are changed or technically reviewed, also read
   [code-samples.md](references/code-samples.md). Read [validation.md](references/validation.md) only
   for the article's platform.
3. For any non-English article, also read [translations.md](references/translations.md).
4. Edit English first. Preserve existing front-matter `url:` values and unrelated formatting.
5. Run `ruby tools/docs-check.rb --links <article...>` for every changed article. Add `--external`
   when HTTP(S) links are present. Run the routed platform sample validator when code changed; the
   Android via Java validator is compile-only as specified in [validation.md](references/validation.md).
6. Report only changed files, checks performed, and unresolved issues; do not paste full files,
   diffs, or successful command logs.
