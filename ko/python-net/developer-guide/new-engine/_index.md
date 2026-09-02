---
title: 버전 26.8에서 새로운 Python-to-.NET 엔진으로 마이그레이션
linktitle: 새 엔진으로 마이그레이션
type: docs
weight: 290
url: /ko/python-net/migrate-to-new-engine/
keywords:
- 새 엔진
- 마이그레이션
- aspose.pydrawing
- 그리기 원시형
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- 파이썬
- Aspose.Slides
description: "버전 26.8에서 새로운 Aspose.Slides 엔진으로 Python 코드를 이동하십시오: 그리기 원시형을 aspose.slides로 재배치하고, import를 자동으로 수정합니다."
---
## **소개**

Version 26.8은 Python을 .NET에 연결하는 엔진을 교체합니다. 그리기 원시형이 `aspose.slides` 모듈로 이동했습니다.

업그레이드 후 문제가 있으면 바로 [I Have an Error](#i-have-an-error)로 이동하세요.

### **그리기 원시형이 aspose.slides로 이동**

7개의 유형이 이동했습니다. 이름, 매개변수 및 동작은 그대로 유지됩니다:

|형식|26.8 이전|26.8 이후|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/ko/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/ko/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/ko/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/ko/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/ko/python-net/aspose.slides/color/)|

이 7개의 유형은 `aspose.pydrawing`의 남은 전체 내용이었습니다. 이를 모두 재지정하면 코드에서 `aspose.pydrawing`을 참조할 필요가 없으며, 모든 import를 제거할 수 있습니다. 또한 결과를 쉽게 확인할 수 있습니다 - [Verify the Migration](#verify-the-migration) 를 보세요.

**Legacy code:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.red

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

**Version 26.8:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    with slide.get_image(slides.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

`from` import 형식도 동일하게 변경됩니다:

```python
# 레거시 코드
from aspose.pydrawing import Color, Point

# 버전 26.8
from aspose.slides import Color, Point
```

## **Import 오류 수정**

첫 번째 열에서 트레이스백을 찾으세요.

|오류|원인|해결|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|패키지는 26.8이지만 코드가 여전히 이전 모듈을 가리키고 있습니다|[코드 업데이트](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|같은 원인, `from` import 형식|[코드 업데이트](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|모듈과 그 일곱 유형이 모두 `aspose.slides`로 이동했습니다|[코드 업데이트](#update-your-code), then delete the `aspose.pydrawing` import|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|코드는 마이그레이션되었지만 설치된 패키지가 26.7 이하입니다|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|`aspose.pydrawing`에서 만든 값이 새로운 API에 전달되었습니다|`aspose.slides`에서 값을 생성하세요|

## **코드 업데이트**

`aspose.pydrawing`에는 이동된 7개 유형 외에 내용이 없으므로 마이그레이션은 모듈 이름을 바꾸는 것입니다. 모든 import 형식은 이 단일 이름 변경으로 처리되며, 별칭도 포함됩니다:

```python
# 레거시 코드
import aspose.pydrawing as drawing
color = drawing.Color.red

# 버전 26.8 - 별칭은 계속 작동합니다
import aspose.slides as drawing
color = drawing.Color.red
```

이는 함수 본문을 포함한 모든 범위에서 유효합니다. 별칭은 이전과 정확히 같은 위치에 바인딩되기 때문입니다. 유일한 단점은 오해를 일으킬 수 있는 이름이므로, 의도를 명시적으로 표현하는 것을 고려하세요:

```python
import aspose.slides as slides
color = slides.Color.red
```

코드베이스 규모에 맞는 접근 방식을 선택하세요.

### **수동 교체**

몇 개 파일에 대해 `aspose.pydrawing`을 검색하여 `aspose.slides`로 교체하고, 더 이상 필요 없는 import를 제거하세요.

### **셸 명령으로 교체**

이는 일반 텍스트 교체이므로 문자열 및 주석 내부의 발생도 영향을 받습니다. 두 명령 모두 변경된 모든 파일에 `.bak` 복사본을 작성합니다.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

macOS에서는 `sed -i ''`를 `sed -i.bak` 대신 사용하거나 GNU sed를 `gsed`로 설치하세요.

**Windows PowerShell:**

```
Get-ChildItem -Recurse -Filter *.py | ForEach-Object {
  $t = Get-Content $_ -Raw
  $new = $t -replace 'aspose\.pydrawing', 'aspose.slides'
  if ($new -ne $t) {
    Copy-Item $_.FullName "$($_.FullName).bak"
    Set-Content $_.FullName $new -NoNewline
    $_.FullName
  }
}
```

Linux 또는 macOS에서 되돌리려면:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Windows에서 되돌리려면:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Python 스크립트로 교체**

같은 이름 변경을 Linux, macOS, Windows에서 모두 사용할 수 있습니다. 스크립트는 경로를 인수로 받아 `--write`가 지정되지 않은 경우 변경 사항을 미리 보여줍니다. `--backup`을 추가하면 모든 변경 파일에 `.bak` 복사본을 유지합니다. 원하는 이름으로 저장하면 실행 시 사용법 메시지가 파일명을 자동으로 표시합니다.

```python
"""Rename aspose.pydrawing to aspose.slides. Plain text replacement.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import sys
from pathlib import Path

W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0

for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    n = s.replace("aspose.pydrawing", "aspose.slides")
    if n == s:
        continue
    changed += 1
    print(("wrote " if W else "would change ") + str(p))
    if W:
        if B:
            p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
        p.write_text(n, encoding="utf-8")

print(f"{changed} file(s) {'changed' if W else 'to change'}"
      + ("" if W or not changed else "; rerun with --write to apply"))
```

전형적인 실행 예시:

```console
$ python migrate.py src/
would change src/render.py
would change src/export/slides.py
2 file(s) to change; rerun with --write to apply

$ python migrate.py src/ --write --backup
wrote src/render.py
wrote src/export/slides.py
2 file(s) changed
```

경로는 재귀적으로 탐색되는 디렉터리이거나 단일 `.py` 파일일 수 있습니다.

### **AST 기반 스크립트로 교체**

대규모 코드베이스에 권장됩니다. 이 스크립트는 같은 이름 변경을 수행하지만 먼저 파일을 파싱하므로 문자열, 주석, docstring 내부의 발생을 건드리지 않습니다.

모듈을 제자리에서 이름 변경하고 별칭은 그대로 두기 때문에 `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, 여러 줄 괄호 안 import, 함수 내부 import, 값으로 전달된 모듈 등 모든 import 형식을 특수 케이스 없이 처리합니다. 동일한 `--write`와 `--backup` 플래그를 지원합니다.

```python
"""Rename aspose.pydrawing to aspose.slides, skipping strings and comments.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import ast, sys
from pathlib import Path

MOD, DST = "aspose.pydrawing", "aspose.slides"
W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def fix(src):
    tree = ast.parse(src)
    off, o = [], 0
    for l in src.encode().splitlines(keepends=True):
        off.append(o)
        o += len(l)
    off.append(o)
    edits = []

    for n in ast.walk(tree):
        # import aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # 모듈 이름이 제자리에서 변경되므로 별칭은 이전과 동일하게 바인딩됩니다.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # 모듈을 참조하는 모든 식, 예를 들어 `fn(aspose.pydrawing)`와 같은 경우도 포함합니다.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # 역순으로 처리하면 오프셋이 올바르게 유지됩니다.
        b = b[:s] + r.encode() + b[e:]
    return b.decode()


for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    try:
        n = fix(s)
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    if n != s:
        print(("wrote " if W else "would change ") + str(p))
        if W:
            if B:
                p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
            p.write_text(n, encoding="utf-8")
```

두 스크립트 모두 멱등합니다: 마이그레이션된 코드를 다시 실행해도 변경 사항이 없습니다.

## **마이그레이션 확인**

텍스트 검색을 통해 남아 있는 것이 있는지 확인합니다:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

빠르지만 문자열과 주석 내부까지 매치되므로 깨끗한 코드에서도 히트가 발생할 수 있습니다. 확실한 결과를 원한다면 아래 검사를 사용하세요. 실제 코드 참조만 보고 남은 것이 있으면 비정상 종료 코드로 종료하므로 빌드 게이트로 활용할 수 있습니다.

```python
import ast, sys
from pathlib import Path

MOD = "aspose.pydrawing"
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), ".")


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def scan(tree):
    for n in ast.walk(tree):
        if isinstance(n, ast.Import) and any(a.name == MOD for a in n.names):
            yield n.lineno, f"import {MOD}"
        elif isinstance(n, ast.ImportFrom) and n.module == MOD:
            names = ", ".join(a.name for a in n.names)
            yield n.lineno, f"from {MOD} import {names}"
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            yield n.lineno, f"reference to {MOD}"


hits = 0
for p in sorted(Path(ROOT).rglob("*.py")):
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    try:
        tree = ast.parse(p.read_text(encoding="utf-8"))
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    for lineno, what in sorted(scan(tree)):
        print(f"{p}:{lineno}: {what}")
        hits += 1

print("migration complete" if not hits else f"{hits} reference(s) left")
sys.exit(1 if hits else 0)
```

마이그레이션 전후에 실행하세요:

```console
$ python verify.py src/
src/render.py:4: from aspose.pydrawing import Color, Point
src/render.py:11: import aspose.pydrawing
src/render.py:12: reference to aspose.pydrawing
3 reference(s) left

$ python migrate.py src/ --write
wrote src/render.py

$ python verify.py src/
migration complete
```

마지막으로 이동된 유형을 활용하는 스모크 테스트를 실행하세요:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("smoke.pptx", slides.export.SaveFormat.PPTX)
    print("OK")
```

## **권장 마이그레이션 순서**

1. **기준을 저장합니다.** 현재 버전에서 테스트를 실행하고 레퍼런스 렌더링을 보관합니다. 이렇게 하면 나중에 마이그레이션 오류와 렌더링 차이를 구분할 수 있습니다.
2. **마이그레이션을 미리 확인합니다.** `--write` 없이 스크립트를 실행하고 변경될 파일 목록을 검토합니다.
3. **적용하고 검증합니다.** `--write --backup` 옵션으로 실행한 뒤 검증 스크립트와 스모크 테스트를 수행합니다.
4. **허용 오차로 렌더링을 비교합니다.** .NET 6 빌드로 이동하면 텍스트와 효과에 작은 차이가 발생할 수 있습니다. 바이트 단위 비교 대신 임계값 기반 비교를 사용합니다.
5. **백업을 제거합니다.** 결과가 확인되면 `.bak` 파일을 삭제합니다: Linux와 macOS에서는 `find . -name '*.py.bak' -delete`, Windows에서는 `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item`.

## **단일 코드베이스에서 두 버전 모두 지원**

동일 소스에서 26.7과 26.8을 모두 실행해야 하는 경우:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 및 이후
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 및 이전
```

## **변경되지 않은 사항**

- 이동된 원시형의 이름, 매개변수 및 동작.
- `aspose.slides` API의 나머지 부분.
- 라이선스 및 라이선스 파일 적용 방식.
- 파일 형식 및 저장·로드 동작.
- Windows와 macOS의 시스템 요구사항.
- 별도의 .NET 설치가 없으며 런타임이 여전히 번들되어 있음.