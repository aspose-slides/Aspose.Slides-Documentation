---
title: ActiveX
type: docs
weight: 200
url: /vi/python-java/examples/elements/activex/
keywords:
- ví dụ mã
- ActiveX
- điều khiển ActiveX
- thuộc tính ActiveX
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Sử dụng Aspose.Slides for Python via Java để thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong các bản trình chiếu PowerPoint với các ví dụ mã thực tế."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong một bản trình chiếu bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Cài đặt](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy. Các ví dụ truy cập và xóa sử dụng `add_activex.pptm`, được tạo bởi ví dụ đầu tiên.

## **Thêm một điều khiển ActiveX**

Chèn một điều khiển Windows Media Player vào slide đầu tiên và lưu bản trình chiếu dưới dạng tệp PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm một điều khiển Windows Media Player.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Truy cập một điều khiển ActiveX**

Đọc tên và cài đặt phát lại tự động của điều khiển ActiveX đầu tiên trên slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Truy cập điều khiển ActiveX đầu tiên.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Xóa một điều khiển ActiveX**

Xóa điều khiển ActiveX đầu tiên khỏi slide và lưu bản trình chiếu đã chỉnh sửa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # Xóa điều khiển ActiveX đầu tiên.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Đặt thuộc tính ActiveX**

Thêm một điều khiển Windows Media Player, tắt phát lại tự động và ẩn các điều khiển phát lại của nó. Sử dụng [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/vi/python-java/aspose.slides/controlpropertiescollection/#set_Item) để gán giá trị thuộc tính dưới dạng chuỗi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm một điều khiển Windows Media Player và cấu hình các thuộc tính của nó.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```