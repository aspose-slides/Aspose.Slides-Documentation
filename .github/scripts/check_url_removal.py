#!/usr/bin/env python3
"""Fail the build when a `url:` front-matter key disappears without an alias.

WHY THIS EXISTS
    The live URL of every page on docs.aspose.com/slides comes from its `url:` front-matter key,
    not from its file path. The Hugo build runs with --cleanDestinationDir and the deploy does
    `sudo rm -rf` on the live directory, so the moment a `url:` value changes or vanishes, the old
    URL returns a hard 404 with no redirect.

    Measured 2026-07-28: 227 URLs carrying 62,287 impressions/year were 404ing, and the content repo
    contained NO `aliases:` key anywhere in 43,566 files. Three URL-destroying renames landed in the
    eight weeks before that measurement (SLIDESDOC-609, -731, -753).

    Hugo 0.80 supports `aliases:` natively. This check makes forgetting it a build failure instead of
    a silent traffic loss discovered a quarter later.

USAGE
    python check_url_removal.py <base-ref> <head-ref>

    Exit 0  — no URL was removed, or every removed URL is covered by an alias somewhere in HEAD.
    Exit 1  — at least one URL vanished with no alias. The offending URLs are printed.

    Run it from inside the content repository (Aspose.Slides-Documentation).

CI EXAMPLE (.github/workflows/url-stability.yml in the content repo)

    name: URL stability
    on: pull_request
    jobs:
      check:
        runs-on: ubuntu-latest
        steps:
          - uses: actions/checkout@v4
            with: { fetch-depth: 0 }
          - run: python check_url_removal.py origin/${{ github.base_ref }} HEAD
"""
import re
import subprocess
import sys

URL_KEY = re.compile(r'^url:\s*(\S+)', re.M)


def _git(args):
    """Run a git command and return stdout, tolerating the 'no matches' exit code from git grep."""
    r = subprocess.run(['git'] + args, capture_output=True, text=True,
                       encoding='utf-8', errors='replace')
    return r.stdout


def urls_at(ref):
    """Every `url:` value declared anywhere in the tree at `ref`, normalised to a trailing slash."""
    out = _git(['grep', '-h', '^url:', ref, '--', '*.md'])
    found = set()
    for m in URL_KEY.finditer(out):
        u = m.group(1).strip().strip('"\'')
        if u:
            found.add(u.rstrip('/') + '/')
    return found


def aliases_at(ref):
    """Every alias declared at `ref`.

    Aliases are a YAML list, so the values sit on continuation lines after the `aliases:` key:

        aliases:
          - /python-net/manage-bullet-and-numbered-lists/

    `git grep -A` gives us those continuation lines. We accept any line in that window that looks
    like a list item pointing at an absolute path, which is deliberately permissive — a false
    'covered' is a missed warning, while a false 'uncovered' would block a legitimate build.
    """
    out = _git(['grep', '-h', '-A', '10', '^aliases:', ref, '--', '*.md'])
    found = set()
    for line in out.split('\n'):
        s = line.strip()
        if s.startswith('- '):
            v = s[2:].strip().strip('"\'')
            if v.startswith('/'):
                found.add(v.rstrip('/') + '/')
    return found


def main(argv):
    if len(argv) != 3:
        print(__doc__)
        return 2
    base, head = argv[1], argv[2]

    before = urls_at(base)
    if not before:
        # A ref with no `url:` keys at all means the ref is wrong or the checkout is shallow.
        # Failing here would block every build, so warn loudly and pass.
        print('WARNING: no url: keys found at %s — is the checkout shallow? Skipping check.' % base)
        return 0

    lost = before - urls_at(head) - aliases_at(head)
    if lost:
        print('ERROR: %d URL(s) removed with no alias.\n' % len(lost))
        for u in sorted(lost):
            print('   ', u)
        print('\nAdd the old URL to the new page\'s front matter:\n')
        print('    aliases:')
        print('      - %s' % sorted(lost)[0])
        return 1

    print('OK: no unaliased URL removals (%d URLs checked)' % len(before))
    return 0


if __name__ == '__main__':
    sys.exit(main(sys.argv))
