---
title: ActiveX
type: docs
weight: 200
url: /vi/python-net/examples/elements/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- thêm ActiveX
- truy cập ActiveX
- xóa ActiveX
- thuộc tính ActiveX
- ví dụ mã
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách tìm, chỉnh sửa và xóa các điều khiển ActiveX trong Python với Aspose.Slides, bao gồm việc cập nhật thuộc tính cho các bản trình chiếu PowerPoint."
---
Trình bày cách thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong một bản trình chiếu bằng **Aspose.Slides for Python via .NET**.

## **Thêm một điều khiển ActiveX**

Chèn một điều khiển ActiveX mới.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm một điều khiển ActiveX mới (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Truy cập một điều khiển ActiveX**

Đọc thông tin từ điều khiển ActiveX đầu tiên trên slide.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Truy cập điều khiển ActiveX đầu tiên.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # In tên điều khiển.
            print(f"Control Name: {control.name}")
```

## **Xóa một điều khiển ActiveX**

Xóa một điều khiển ActiveX hiện có khỏi slide.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Xóa điều khiển ActiveX đầu tiên.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Cài đặt các thuộc tính ActiveX**

Cấu hình một số thuộc tính ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Giả sử bộ sưu tập Control chứa ít nhất một Control.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```