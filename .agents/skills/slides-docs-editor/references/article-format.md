# Article format

## Repository layout

Content paths are `<language>/<platform>/<article-path>/_index.md`. Supported language folders are
`ar cs de el en es fa fr hi hu id it ja ko nl pl pt ru sv th tr vi zh zh-hant`. English is the
source of truth. Front-matter `url:` omits the product prefix; published links use `/slides<url>`.
For example, `/java/slide-section/` becomes `/slides/java/slide-section/`.

- Create new pages as branch bundles named `<page-path>/_index.md`.
- Keep code fences and Hugo shortcodes balanced. A malformed article can stop the site build for
  every language and product family.

## English language review

For every platform, when creating, adapting, editing, or reviewing an English article, check and
correct grammar, spelling, punctuation, and clearly unnatural phrasing within the requested article.
Preserve the original meaning, technical claims, and structure. Do not add new information,
recommendations, or examples as part of language correction. An instruction such as "do not add
anything of your own" does not prohibit these language corrections; an explicit request to preserve
wording verbatim does.

## Front matter

- Keep valid YAML between balanced `---` delimiters.
- Require `title`, `description`, `url`, and `type: docs`; `weight` controls sidebar order and
  `keywords` is a YAML list when present.
- Never tidy or derive `url:` from the folder. Preserve it exactly. For an explicitly requested URL
  change, add the old value to `aliases:`.

## Headings and FAQ

- Bold all article section headings below the page title: `## **Overview**`, `### **Task**`, and so on.
- Every new article must include a `## **FAQ**` section with concise, article-specific questions and
  answers. Do not add placeholder or generic questions solely to satisfy this requirement.
- Format each FAQ question as a standalone bold line, not a Markdown heading.

## Alerts

Every alert requires a matching closing shortcode and an explicit title.

| Meaning | Shortcode attributes |
|---|---|
| Note | `color="info" title="Note"` |
| Warning | `color="warning" title="Warning"` |
| Important/danger | `color="danger" title="Important"` |
| Tip | `color="success" title="Tip"` |

Do not introduce `color="primary"`.

## Links

- Verify every link in a changed article. Cross-article documentation links must use the root-relative
  published `/slides<front-matter-url>` form; never use an absolute `https://docs.aspose.com/...`
  URL. Fragments must match a heading or explicit anchor, and relative resources must exist.
- External links must reach the intended page, not an error, generic home page, or unrelated redirect.
- Use plain Markdown labels: `[Presentation](url)`, never ``[`Presentation`](url)``.
- Do not add links inside code blocks.
