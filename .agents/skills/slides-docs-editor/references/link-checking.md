# External link checking

Create and run a temporary Python 3 script outside the repository for the selected articles.
Delete that temporary script after checking. Do not add a checker to Git or force-add files from `tools/`.
Use the bundled Python executable returned by `load_workspace_dependencies` when available;
do not assume `python` on PATH is Python 3. Use only the standard library.

Have the script extract HTTP(S) URLs outside fenced code, deduplicate them, send direct GET
requests with timeouts, follow redirects, and print status, final URL, and HTML title.
Review the final destinations and titles against the links' purpose. Open ambiguous results
to inspect their content: HTTP 200 alone does not prove that a page is the intended destination.
Check external fragments against the destination when present. Non-HTML resources have no title.

If DNS, connection, or permission errors indicate sandbox network restrictions, rerun the same
command with approved network access. Retry remaining transient failures once. Never disable TLS
verification. Do not substitute search results or cached web-tool pages for direct HTTP checks.

`BROKEN` means HTTP 404 or 410. Other HTTP errors, DNS failures, timeouts, and TLS errors mean
`UNVERIFIED`, not a proven broken link. Use exit code 0 when every request succeeds, 1 for broken
links, and 2 for unverified results or invalid input. An unexpected redirect,
error page returning 200, or unrelated destination still requires correction or an unresolved report.

Report unique links checked, broken or unverified links, and unexpected redirects. Do not declare
the check complete while any destination remains unverified. If approved network access is unavailable,
state the limitation. The checker does not validate YAML, Hugo shortcodes, local resources, or anchors;
continue checking those under `article-format.md`. Ruby is not part of this workflow.
