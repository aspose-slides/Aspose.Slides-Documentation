# AGENTS.md

Guidance for automated agents and new contributors editing this repository.

This is a Hugo **content** repository. There is no application here, no build to run and no test
suite. The site is built and deployed elsewhere, from a separate theme and configuration, so the
only things you can get right or wrong here are content correctness, front matter integrity and
link safety.

Read the two rules under [Things that break the whole site](#things-that-break-the-whole-site)
before your first edit. Both have taken the site down.

## Layout

Language first, then product platform, then the page's own path:

```
en/net/developer-guide/manage-presentation/create-presentation/_index.md
ru/java/getting-started/installation/_index.md
```

Language folders: `ar cs de el en es fa fr hi hu id it ja ko nl pl pt ru sv th tr vi zh zh-hant`.

English is the source of truth. The other 23 are translations of it, so a change that only makes
sense in one language usually indicates the edit belongs in English first.

**Almost every content file is `_index.md`** — 43,565 of 43,566. These are Hugo *branch bundles*.
A file named `page.md` instead of `_index.md` renders as nothing. If you are creating a page, create
`<its-path>/_index.md`.

## Things that break the whole site

Both of these fail the build for **every** language and every product family sharing the deploy, not
just the page that contains them. Neither is caught before merge.

### 1. Front matter must be valid YAML

```yaml
---
title: Add a Watermark to a Presentation
keywords:
- watermark
- add watermark to PPTX
url: /net/watermark/
---
```

A real failure from this repository — one keyword split across three lines by a bad translation:

```yaml
keywords:
- odstranit vodoznak z PPT
- odstran            # <- the list item was broken in half
                     # <- and a blank line inserted
itvodoznak z PPTX
```

That single file stopped all 24 languages from building.

### 2. Shortcodes must be balanced

Every `{{% alert %}}` needs exactly one `{{% /alert %}}`. An opener with no closer, or a closer with
no opener, aborts the build. Both have occurred here — an unclosed `alert` in Hungarian and an
orphan closing tag left at the end of a Hindi page.

## Front matter

| Key | Required | Notes |
|---|---|---|
| `title` | yes | Also the `<h1>` and the search-result title |
| `description` | strongly | Used for the meta description, the page's summary block, and structured data. 191 English pages lack one; do not add to that number |
| `url` | **yes** | See below — this is the dangerous one |
| `type` | yes | `docs` on documentation pages |
| `weight` | no | Sidebar **ordering**, not importance |
| `keywords` | no | A YAML list |

### `url:` is the page's address. The file path is not.

**This is the single most dangerous key in the repository.** The published address of a page comes
from its `url:` front-matter value, never from where the file sits. 100% of pages carry one, and
**86% do not match their folder path**:

```
file:  en/net/developer-guide/manage-presentation/create-presentation/_index.md
url:   /net/create-presentation/
live:  https://docs.aspose.com/slides/net/create-presentation/
```

Consequences you must design around:

- **Renaming or moving a folder does not change the URL.** It is safe for the address, but it will
  confuse the next reader. Prefer leaving paths alone.
- **Changing `url:` silently breaks a live address.** There is no reverse mapping and no redirect is
  created for you. If a URL genuinely must change, add the old one to `aliases:`.
- **Never "tidy" a `url:` to match its folder.** It will look like an improvement and will be a
  regression.

## Callouts

Use the `alert` shortcode, and choose the colour by meaning:

| Purpose | Write | Use when |
|---|---|---|
| Note | `{{%/* alert color="info" title="Note" */%}}` | Context a reader can skip and still succeed |
| Warning | `{{%/* alert color="warning" title="Warning" */%}}` | Something that costs time or produces wrong output |
| Danger | `{{%/* alert color="danger" title="Important" */%}}` | Data loss, licence violation, unrecoverable state |
| Tip | `{{%/* alert color="success" title="Tip" */%}}` | A faster or better alternative |

Two rules:

- **Always pass `title=`.** An untitled box makes the reader work out why it is there.
- **Do not use `color="primary"`.** It is the shortcode's default and carries no meaning. Existing
  pages use it heavily; that is history, not a pattern to copy.

## Code samples

Every code sample must compile and run before it is committed. Samples here are the main reason
readers arrive, and a sample that does not build costs more trust than the page earns.

- Include the `using` / `import` lines. A snippet that assumes them is not runnable.
- Say how to install the library, or link to the page that does.
- Fence with the language: ` ```csharp `, ` ```java `, ` ```python `.
- Keep each code statement on one physical line. Do not split method calls, member-access chains,
  conditions, declarations or expression-bodied members across lines. If a statement becomes too
  long, simplify it with well-named intermediate variables instead of wrapping it.
- In article prose, link every mentioned public API class, interface, method, property and
  enumeration to the API Reference for that article's platform. Link directly to the specific
  member page when one exists, and verify that the target URL resolves. Do not add links inside
  code blocks.

## Editing translations

- Change English first, then the translations.
- Keep the shortcode and heading structure identical to the English page. If English has one
  `alert`, the translation has one `alert` in the same place — structural drift is how the two
  build failures above happened.
- Translate prose. **Do not translate** code, API names, `url:` values, or shortcode parameters.
- Never leave translation-tool commentary in the file. A page here once shipped the model's own
  notes to itself.

## Checklist before committing

- [ ] Front matter parses as YAML and keeps `url:` exactly as it was
- [ ] Every shortcode that opens is closed
- [ ] Code fences are balanced and labelled with a language
- [ ] Code samples were actually run
- [ ] `description` is present
- [ ] Structure matches the English page, if this is a translation

## What not to do

- Do not add build tooling, linters or CI without asking — the build lives in another repository.
- Do not reformat files you are not otherwise changing. It buries the real edit and makes
  translation drift impossible to review.
- Do not bulk-rewrite across languages in one commit. One language per commit stays reviewable.
