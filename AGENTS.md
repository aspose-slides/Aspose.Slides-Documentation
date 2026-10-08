# AGENTS.md

This is a Hugo content repository. The site build lives elsewhere; work here is limited to article
content, front matter, links, resources, and the platform-specific sample validators under `tools/`.

- For article editing, review, translation, or validation, use `$slides-docs-editor` from
  `.agents/skills/slides-docs-editor/` and load only the references it routes to.
- Keep changes to the requested article files and their minimum validation artifacts; do not
  reformat unrelated content or bulk-rewrite languages.
- Keep all files under `tools/` local and ignored. Never force-add, commit, or push them.
- Check external links in every changed article using a temporary Python 3 script outside the
  repository and direct HTTP GET requests. Follow the link-checking instructions in `slides-docs-editor`.
  If sandbox networking blocks requests, retry with approved network access; do not treat network
  failures as broken links or report incomplete checks as passed. Do not use the Ruby validator.

Do not add build tooling, linters, or CI unless the user explicitly requests it.
