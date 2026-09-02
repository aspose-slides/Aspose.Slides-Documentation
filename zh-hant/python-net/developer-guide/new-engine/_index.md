---
title: 在版本 26.8 中遷移至新的 Python 到 .NET 引擎
linktitle: 遷移至新引擎
type: docs
weight: 290
url: /zh-hant/python-net/migrate-to-new-engine/
keywords:
- 新引擎
- 遷移
- aspose.pydrawing
- 繪圖基元
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "將您的 Python 程式碼遷移至版本 26.8 的新 Aspose.Slides 引擎：將繪圖基元重新定位至 aspose.slides，並自動修正匯入。"
---
## **簡介**

版本 26.8 取代了連接 Python 與 .NET 的引擎。繪圖基元已移至 `aspose.slides` 模組。

如果升級後遇到問題，請直接跳至 [我有錯誤](#i-have-an-error)。

### **繪圖基元已移至 aspose.slides**

七種型別已移動。它們保留原名稱、參數與行為：

|型別|26.8 之前|26.8 及之後|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/color/)|

這七種型別構成了 `aspose.pydrawing` 中剩餘的全部內容。重新指向它們後，程式碼中不再需要引用 `aspose.pydrawing`，所有的匯入都可以移除。這也使得結果易於檢查——請參閱 [驗證遷移](#verify-the-migration)。

**舊版程式碼:**

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

**版本 26.8:**

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

`from` 匯入形式會以相同方式變更：

```python
# 舊版程式碼
from aspose.pydrawing import Color, Point

# 版本 26.8
from aspose.slides import Color, Point
```

## **修復匯入錯誤**

在第一欄中找到您的回溯。

|錯誤|原因|修復|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|套件為 26.8，但程式碼仍指向舊模組|[更新程式碼](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|相同原因，`from` 匯入形式|[更新程式碼](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|模組及其所有七個型別已移至 `aspose.slides`|[更新程式碼](#update-your-code)，然後刪除 `aspose.pydrawing` 匯入|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|程式碼已遷移，但已安裝的套件為 26.7 或更舊版本|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|從 `aspose.pydrawing` 建立的值被傳遞給新 API|同樣從 `aspose.slides` 建立值|

## **更新程式碼**

因為 `aspose.pydrawing` 除了這七個已移動的型別外沒有其他內容，遷移只需重新命名模組。所有匯入形式皆受此單一重新命名涵蓋，包括別名：

```python
# 舊版程式碼
import aspose.pydrawing as drawing
color = drawing.Color.red

# 版本 26.8 - 別名仍然有效
import aspose.slides as drawing
color = drawing.Color.red
```

這在任何範圍內皆有效，包括函式內部，因為別名會保持在原先綁定的位置。唯一的缺點是名稱可能產生誤導，因此建議明確說明其意圖：

```python
import aspose.slides as slides
color = slides.Color.red
```

選擇與程式碼基礎規模相符的方法。

### **手動取代**

對於少數檔案，可搜尋 `aspose.pydrawing` 並替換為 `aspose.slides`，然後移除不再需要的任何匯入。

### **使用 Shell 指令取代**

這是純文字取代，會同時影響字串與註解內的出現。兩個指令皆會為每個被變更的檔案寫入 `.bak` 複本。

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

在 macOS 上，使用 `sed -i ''` 取代 `sed -i.bak`，或安裝 GNU sed 並以 `gsed` 使用。

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

在 Linux 或 macOS 上回退：

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

在 Windows 上回退：

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **使用 Python 腳本取代**

相同的重新命名，可在 Linux、macOS 與 Windows 上通用。腳本以路徑做為參數，除非傳入 `--write`，否則僅預覽變更。加入 `--backup` 可為每個變更的檔案保留 `.bak` 複本。以任意名稱儲存──執行時會自動偵測檔名。

```python
"""將 aspose.pydrawing 重新命名為 aspose.slides。純文字取代。

    python <this script> src/                     # 預覽
    python <this script> src/ --write             # 套用
    python <this script> src/ --write --backup    # 套用，保留 .bak 複本
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

典型執行結果如下：

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

路徑可以是目錄（會遞迴遍歷），也可以是單一 `.py` 檔案。

### **使用基於 AST 的腳本取代**

建議用於較大的程式碼基礎。此腳本執行相同的重新命名，但會先解析每個檔案，因而不會觸及字串、註解或文件字串中的出現。

因為它會直接在原地重新命名模組且保留別名，所有匯入形式皆可在不需特別處理的情況下處理：`import aspose.pydrawing`、`import aspose.pydrawing as X`、`from aspose.pydrawing import Color`、`from aspose.pydrawing import Color as C`、多行括號匯入、函式內的匯入，以及將模組作為值傳遞。它接受相同的 `--write` 與 `--backup` 旗標。

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
        # 匯入 aspose.pydrawing [as X]  /  從 aspose.pydrawing 匯入 ...
        # 模組名稱直接重新命名，因此任何別名仍保持原本的綁定。
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # 任何引用該模組的表達式，包括裸露的 `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # 由後往前處理可保持位移仍然有效
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

兩個腳本都是冪等的：在已遷移的程式碼上再次執行不會有任何變化。

## **驗證遷移**

文字搜尋可顯示是否仍有遺留：

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

此方法快速，但會同時匹配字串與註解內的出現，因此即使是乾淨的程式碼仍可能命中。若需確切答案，請使用以下檢查。它只會回報真實程式碼的引用，且若仍有遺留會以非零狀態結束，使其可作為建置關卡。

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

在遷移前後執行：

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

最後，執行測試以驗證已搬移的型別：

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

## **建議遷移順序**

**儲存基線。** 在目前版本上執行測試並保留參考渲染。這可讓您稍後將遷移錯誤與渲染差異分開。

**預覽遷移。** 使用其中一個腳本且不加 `--write`，檢查其將會變更的檔案清單。

**套用並驗證。** 加上 `--write --backup` 執行，然後執行驗證腳本與測試。

**使用容差比較渲染。** 移轉至 .NET 6 建置可能會在文字與特效上產生細微差異。請使用基於門檻的比較，而非逐位元檢查。

**移除備份。** 確認結果後，刪除 `.bak` 檔案：在 Linux 與 macOS 上使用 `find . -name '*.py.bak' -delete`，或在 Windows 上使用 `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item`。

## **在單一程式碼基礎中支援兩個版本**

如果需要從同一來源同時執行 26.7 與 26.8：

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 及之後
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 及之前
```

## **未變更的內容**

- 已搬移基元的名稱、參數與行為。
- `aspose.slides` API 其餘部分。
- 授權方式與授權檔的套用方式。
- 檔案格式及儲存與載入行為。
- Windows 與 macOS 的系統需求。
- 不需單獨的 .NET 安裝——執行環境仍然內建。