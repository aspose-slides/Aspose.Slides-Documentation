---
title: Di chuyển sang Động cơ Python‑to‑.NET mới trong Phiên bản 26.8
linktitle: Di chuyển sang Động cơ mới
type: docs
weight: 290
url: /vi/python-net/migrate-to-new-engine/
keywords:
- động cơ mới
- di chuyển
- aspose.pydrawing
- các primitive vẽ
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "Di chuyển mã Python của bạn sang động cơ Aspose.Slides mới trong phiên bản 26.8: chuyển các primitive vẽ sang aspose.slides và tự động sửa các import."
---
## **Giới thiệu**

Phiên bản 26.8 thay thế động cơ kết nối Python với .NET. Các primitive vẽ đã được di chuyển vào mô-đun `aspose.slides`.

Nhảy thẳng tới [Tôi có lỗi](#i-have-an-error) nếu bạn gặp vấn đề sau khi nâng cấp.

### **Các primitive vẽ được di chuyển tới aspose.slides**

Bảy kiểu đã được di chuyển. Chúng giữ nguyên tên, đối số và hành vi:

|Kiểu|Trước 26.8|26.8 và Sau|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/vi/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/vi/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/vi/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/color/)|

Bảy kiểu này là toàn bộ nội dung còn lại của `aspose.pydrawing`. Khi bạn đã chuyển lại chúng, không có gì trong mã của bạn cần tham chiếu tới `aspose.pydrawing` nữa, và mọi import của nó có thể được xóa. Điều này cũng giúp việc kiểm tra kết quả trở nên dễ dàng - xem [Xác minh việc di chuyển](#verify-the-migration).

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

Cú pháp import `from` thay đổi theo cách tương tự:

```python
# Mã legacy
from aspose.pydrawing import Color, Point

# Phiên bản 26.8
from aspose.slides import Color, Point
```

## **Sửa lỗi Import**

Tìm traceback của bạn ở cột đầu tiên.

|Lỗi|Nguyên nhân|Cách sửa|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (hoặc `Point`, `Rectangle`, v.v.)|Gói là 26.8, mã vẫn chỉ tới mô-đun cũ|[Cập nhật mã của bạn](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|Gói là 26.8, mã vẫn chỉ tới mô-đun cũ|[Cập nhật mã của bạn](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|Mô-đun và bảy kiểu của nó đã được di chuyển vào `aspose.slides`|[Cập nhật mã của bạn](#update-your-code), sau đó xóa import `aspose.pydrawing`|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|Mã đã được di chuyển, nhưng gói đã cài là 26.7 hoặc cũ hơn|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|Giá trị tạo từ `aspose.pydrawing` được truyền vào API mới|Tạo giá trị từ `aspose.slides` cũng vậy|

## **Cập nhật mã của bạn**

Vì `aspose.pydrawing` không còn nội dung nào ngoài bảy kiểu đã di chuyển, việc di chuyển chỉ là đổi tên mô-đun. Mọi dạng import đều được bao phủ bởi việc đổi tên duy nhất này, bao gồm các bí danh:

```python
# Mã legacy
import aspose.pydrawing as drawing
color = drawing.Color.red

# Phiên bản 26.8 - bí danh vẫn hoạt động
import aspose.slides as drawing
color = drawing.Color.red
```

Điều này hợp lệ trong bất kỳ phạm vi nào, kể cả bên trong thân hàm, vì bí danh vẫn được gắn ở cùng vị trí như trước. Nhược điểm duy nhất là tên gây nhầm lẫn, vì vậy hãy cân nhắc làm rõ ý định:

```python
import aspose.slides as slides
color = slides.Color.red
```

Chọn cách tiếp cận phù hợp với kích thước cơ sở mã của bạn.

### **Thay thế thủ công**

Đối với một vài tệp, tìm `aspose.pydrawing` và thay thế bằng `aspose.slides`, sau đó xóa bất kỳ import nào không còn cần thiết.

### **Thay thế bằng lệnh Shell**

Việc này là thay thế văn bản thuần, vì vậy nó cũng ảnh hưởng tới các xuất hiện trong chuỗi và chú thích. Cả hai lệnh đều ghi một bản sao `.bak` của mọi tệp chúng thay đổi.

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

Trên macOS, dùng `sed -i ''` thay vì `sed -i.bak`, hoặc cài GNU sed dưới tên `gsed`.

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

Để quay lại trên Linux hoặc macOS:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Để quay lại trên Windows:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Thay thế bằng script Python**

Việc đổi tên tương tự, có thể chạy trên Linux, macOS và Windows. Script nhận đường dẫn làm đối số và hiển thị trước các thay đổi trừ khi truyền `--write`. Thêm `--backup` để giữ bản sao `.bak` của mọi tệp đã thay đổi. Lưu nó dưới bất kỳ tên nào - thông báo sử dụng sẽ lấy tên tại thời gian chạy.

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

Một lần chạy điển hình trông như sau:

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

Đường dẫn có thể là một thư mục, được duyệt đệ quy, hoặc một tệp `.py` duy nhất.

### **Thay thế bằng script dựa trên AST**

Được khuyến nghị cho các cơ sở mã lớn. Script này thực hiện cùng một việc đổi tên, nhưng phân tích mỗi tệp trước, vì vậy không bao giờ chạm tới các xuất hiện trong chuỗi, chú thích hoặc docstring.

Vì nó đổi tên mô-đun tại chỗ và để lại các bí danh, mọi dạng import đều được xử lý mà không cần trường hợp đặc biệt: `import aspose.pydrawing`, `import aspose.pydrawing as X`, `from aspose.pydrawing import Color`, `from aspose.pydrawing import Color as C`, import dạng đa dòng trong ngoặc, import trong hàm, và mô-đun được truyền dưới dạng giá trị. Nó chấp nhận các cờ `--write` và `--backup` giống nhau.

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
        # Tên mô-đun được đổi tên tại chỗ, vì vậy bất kỳ bí danh nào vẫn được gắn như trước.
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # Any expression referring to the module, including bare `fn(aspose.pydrawing)`.
        # Bất kỳ biểu thức nào tham chiếu đến mô-đun, bao gồm cả `fn(aspose.pydrawing)` không có gì.
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

Cả hai script đều idempotent: chạy lại trên mã đã di chuyển không thay đổi gì.

## **Xác minh việc di chuyển**

Tìm kiếm văn bản cho biết còn gì còn lại hay không:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

Cách này nhanh, nhưng cũng khớp trong chuỗi và chú thích, nên mã sạch vẫn có thể tạo ra kết quả. Để có câu trả lời chắc chắn, sử dụng kiểm tra dưới đây. Nó chỉ báo các tham chiếu mã thực tế và thoát với mã không 0 nếu còn lại, giúp dùng như một cổng kiểm tra build.

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

Chạy nó trước và sau khi di chuyển:

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

Cuối cùng, chạy một bài kiểm tra khói để kiểm tra các kiểu đã di chuyển:

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

## **Thứ tự di chuyển được đề xuất**

1. **Lưu trạng thái gốc.** Chạy các bài kiểm tra trên phiên bản hiện tại và giữ các bản render tham chiếu. Điều này cho phép bạn tách lỗi di chuyển khỏi sự khác biệt render sau này.
2. **Xem trước quá trình di chuyển.** Chạy một trong các script mà không có `--write` và xem danh sách tệp sẽ bị thay đổi.
3. **Áp dụng và xác minh.** Chạy với `--write --backup`, sau đó script xác minh và bài kiểm tra khói.
4. **So sánh các render với dung sai.** Việc chuyển sang bản dựng .NET 6 có thể tạo ra một số khác biệt nhỏ về văn bản và hiệu ứng. Sử dụng so sánh dựa trên ngưỡng thay vì kiểm tra từng byte.
5. **Xóa các bản sao lưu.** Khi kết quả đã được xác nhận, xóa các tệp `.bak`: `find . -name '*.py.bak' -delete` trên Linux và macOS, hoặc `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item` trên Windows.

## **Hỗ trợ cả hai phiên bản trong một cơ sở mã**

Nếu bạn cần chạy chống lại 26.7 và 26.8 từ cùng một nguồn:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 và sau
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 và trước
```

## **Những gì không thay đổi**

- Tên, đối số và hành vi của các primitive đã di chuyển.
- Các phần còn lại của API `aspose.slides`.
- Cách cấp phép và cách áp dụng tệp giấy phép.
- Định dạng tệp và hành vi lưu/ tải.
- Yêu cầu hệ thống trên Windows và macOS.
- Việc không có cài đặt .NET riêng - runtime vẫn được đóng gói.