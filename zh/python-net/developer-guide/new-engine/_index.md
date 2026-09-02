---
title: 在版本 26.8 中将 Python 迁移到新的 Python 到 .NET 引擎
linktitle: 迁移到新引擎
type: docs
weight: 290
url: /zh/python-net/migrate-to-new-engine/
keywords:
- 新引擎
- 迁移
- aspose.pydrawing
- 绘图基元
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "将您的 Python 代码迁移到版本 26.8 中的新 Aspose.Slides 引擎：将绘图基元迁移到 aspose.slides，并自动修复导入。"
---
## **介绍**

版本 26.8 替换了用于将 Python 连接到 .NET 的引擎。绘图基元已移动到 `aspose.slides` 模块中。

如果升级后出现问题，请直接跳转到 [I Have an Error](#i-have-an-error)。

### **绘图基元已移动到 aspose.slides**

七种类型已移动。它们保持名称、参数和行为不变：

| 类型 | 26.8 之前 | 26.8 及以后 |
| :- | :- | :- |
| Point | `aspose.pydrawing.Point` | [aspose.slides.Point](https://reference.aspose.com/slides/zh/python-net/aspose.slides/point/) |
| PointF | `aspose.pydrawing.PointF` | [aspose.slides.PointF](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pointf/) |
| Size | `aspose.pydrawing.Size` | [aspose.slides.Size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/size/) |
| SizeF | `aspose.pydrawing.SizeF` | [aspose.slides.SizeF](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sizef/) |
| Rectangle | `aspose.pydrawing.Rectangle` | [aspose.slides.Rectangle](https://reference.aspose.com/slides/zh/python-net/aspose.slides/rectangle/) |
| RectangleF | `aspose.pydrawing.RectangleF` | [aspose.slides.RectangleF](https://reference.aspose.com/slides/zh/python-net/aspose.slides/rectanglef/) |
| Color | `aspose.pydrawing.Color` | [aspose.slides.Color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/color/) |

这七种类型构成了 `aspose.pydrawing` 的全部剩余内容。重新指向它们后，代码中不再需要引用 `aspose.pydrawing`，所有对它的导入都可以删除。这也使得结果易于检查——参见 [Verify the Migration](#verify-the-migration)。

**旧代码：**

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

**版本 26.8：**

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

`from` 导入形式同样会改变：

```python
# 旧代码
from aspose.pydrawing import Color, Point

# 版本 26.8
from aspose.slides import Color, Point
```

## **修复导入错误**

在第一列找到您的回溯信息。

| 错误 | 原因 | 解决方案 |
| :- | :- | :- |
| `AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on) | 包版本为 26.8，代码仍指向旧模块 | [Update your code](#update-your-code) |
| `ImportError: cannot import name 'Color' from 'aspose.pydrawing'` | 同样的原因，`from` 导入形式 | [Update your code](#update-your-code) |
| `ModuleNotFoundError: No module named 'aspose.pydrawing'` | 模块及其七个类型已移动到 `aspose.slides` | [Update your code](#update-your-code)，然后删除 `aspose.pydrawing` 的导入 |
| `ImportError: cannot import name 'Color' from 'aspose.slides'` | 代码已迁移，但已安装的包是 26.7 或更旧版本 | `pip install --upgrade aspose.slides` |
| `TypeError` on a color, point, or size argument | 从 `aspose.pydrawing` 创建的值传递给了新的 API | 同样使用 `aspose.slides` 创建该值 |

## **更新代码**

因为 `aspose.pydrawing` 除了这七个已移动的类型外不含其他内容，迁移只需重新命名模块。所有导入形式都由这个单一的重命名覆盖，包括别名：

```python
# 旧代码
import aspose.pydrawing as drawing
color = drawing.Color.red

# 版本 26.8 - 别名仍然有效
import aspose.slides as drawing
color = drawing.Color.red
```

这在任何作用域均有效，包括函数体内部，因为别名仍绑定在原来的位置。唯一的缺点是名称可能产生误导，因此可以考虑显式说明意图：

```python
import aspose.slides as slides
color = slides.Color.red
```

根据代码库规模选择合适的方法。

### **手动替换**

对于少量文件，搜索 `aspose.pydrawing` 并替换为 `aspose.slides`，然后删除不再需要的任何导入。

### **使用 Shell 命令替换**

这是一种纯文本替换，因此也会影响字符串和注释中的出现。两个命令都会为每个被修改的文件写入一个 `.bak` 副本。

**Linux：**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

在 macOS 上，使用 `sed -i ''` 替代 `sed -i.bak`，或者将 GNU sed 安装为 `gsed`。

**Windows PowerShell：**

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

在 Linux 或 macOS 上回滚：

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

在 Windows 上回滚：

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **使用 Python 脚本替换**

同样的重命名，可在 Linux、macOS 和 Windows 上移植。脚本接受路径作为参数，除非传入 `--write`，否则仅预览更改。添加 `--backup` 可为每个更改的文件保留 `.bak` 副本。使用任意文件名保存——运行时使用信息会自动获取文件名。

```python
"""将 aspose.pydrawing 重命名为 aspose.slides。纯文本替换。

    python <this script> src/                     # 预览
    python <this script> src/ --write             # 应用
    python <this script> src/ --write --backup    # 应用，并保留 .bak 副本
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

典型的运行如下：

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

路径可以是目录（递归遍历），也可以是单个 `.py` 文件。

### **使用基于 AST 的脚本替换**

推荐用于规模较大的代码库。该脚本执行相同的重命名，但在此之前先解析每个文件，因此不会触及字符串、注释或文档字符串中的出现。

由于它在原位重命名模块并保持别名不变，所有导入形式都能无需特殊处理地完成：`import aspose.pydrawing`、`import aspose.pydrawing as X`、`from aspose.pydrawing import Color`、`from aspose.pydrawing import Color as C`、多行括号导入、函数内部导入以及将模块作为值传递。它接受相同的 `--write` 和 `--backup` 标志。

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
        # 导入 aspose.pydrawing [as X]  /  从 aspose.pydrawing import ...
        # 模块名称在原地重命名，任何别名仍保持之前的绑定。
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # 任何引用该模块的表达式，包括裸露的 `fn(aspose.pydrawing)`.
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # back to front keeps offsets valid
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

两个脚本都是幂等的：在已迁移的代码上再次运行不会产生任何更改。

## **验证迁移**

文本搜索可以显示是否还有残留：

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

这很快速，但也会匹配字符串和注释中的出现，因此即使代码已清理仍可能出现匹配。要得到明确答案，请使用以下检查。它仅报告真实的代码引用，如果仍有残留则以非零状态退出，从而可用作构建闸门。

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

在迁移前后运行它：

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

最后，运行一个使用已迁移类型的冒烟测试：

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

## **推荐迁移顺序**

1. **保存基准。** 在当前版本上运行测试并保留参考渲染。这使您以后能够将迁移错误与渲染差异区分开来。
2. **预览迁移。** 在不加 `--write` 的情况下运行其中一个脚本，审查它将更改的文件列表。
3. **应用并验证。** 使用 `--write --backup` 运行，然后执行验证脚本和冒烟测试。
4. **在容差范围内比较渲染。** 转向 .NET 6 构建可能导致文本和效果出现细微差异。使用基于阈值的比较，而非逐字节检查。
5. **删除备份。** 确认结果后，删除 `.bak` 文件：在 Linux 和 macOS 上使用 `find . -name '*.py.bak' -delete`，在 Windows 上使用 `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item`。

## **在单一代码库中支持两个版本**

如果需要在同一源码中同时针对 26.7 和 26.8 运行：

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 及以后
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 及更早
```

## **未变更的内容**

- 已移动基元的名称、参数和行为保持不变。
- `aspose.slides` 其余 API 表面保持不变。
- 授权方式及授权文件的使用方式保持不变。
- 文件格式以及保存和加载行为保持不变。
- Windows 和 macOS 上的系统要求保持不变。
- 仍然没有单独的 .NET 安装——运行时仍然捆绑在一起。