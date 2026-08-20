# AGENTS.md

This is a Hugo content repository. The site build lives elsewhere; work here is limited to article
content, front matter, links, resources, and the platform-specific sample validators under `tools/`.

## Article work

- For editing, reviewing, translating, or validating documentation articles, use the repository
  skill `$slides-docs-editor` in `.agents/skills/slides-docs-editor/`. Load only the references it
  routes to for the current task.
- Keep changes scoped to the requested files. Do not reformat unrelated content or bulk-rewrite
  languages. English is the source; update it before translations. Keep one language per commit.
- New pages must be branch bundles named `<page-path>/_index.md`.

## Site-wide invariants

- Front matter must parse as YAML and contain `title`, `description`, `url`, and `type: docs`.
- Preserve an existing `url:` exactly. If an intentional URL change is explicitly requested, add
  the old URL to `aliases:`.
- Balance every Hugo shortcode, especially `{{% alert %}}` / `{{% /alert %}}`, and every code fence.
  A single malformed article can stop the build for every language and product family.

## Verification

- Run `ruby tools/docs-check.rb --links <article...>` on every changed article. Add `--external`
  when the article contains HTTP(S) links; the checker prints only a pass line or actionable errors.
- Verify every link in a changed article reaches the intended page or resource, not merely a
  successful but unrelated redirect.
- If an Android via Java code example changes, use `tools/androidjava/snippet-check/` to compile all
  snippets. This platform's documentation check is compile-only: do not start an emulator or run the
  snippets on a device.
- For other platforms, use the existing validator under `tools/<platform>/`; compile and run the
  example, verify relevant in-memory state, and reopen generated output to confirm the described
  result. Do not create ad hoc validation projects or install another product copy.

Do not add build tooling, linters, or CI unless the user explicitly requests it.
