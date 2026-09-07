---
title: Macro VBA
type: docs
weight: 150
url: /vi/python-java/examples/elements/vba-macro/
keywords:
- ví dụ mã
- VBA
- macro
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Thêm, truy cập và xóa macro VBA trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho Python qua Java với các ví dụ mã rõ ràng và thực tiễn."
---
Bài viết này trình bày cách thêm, truy cập và xóa macro VBA bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm macro VBA**

Tạo một bản trình chiếu có dự án VBA và một mô-đun macro đơn giản.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **Truy cập macro VBA**

Lấy mô-đun đầu tiên từ dự án VBA.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **Xóa macro VBA**

Xóa một mô-đun khỏi dự án VBA.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```