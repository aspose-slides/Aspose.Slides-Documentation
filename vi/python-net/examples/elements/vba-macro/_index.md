---
title: Macro VBA
type: docs
weight: 150
url: /vi/python-net/examples/elements/vba-macro/
keywords:
- macro VBA
- thêm macro VBA
- truy cập macro VBA
- xoá macro VBA
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Làm việc với macro VBA trong Python bằng Aspose.Slides: thêm hoặc chỉnh sửa dự án và mô-đun, ký hoặc xoá macro, và lưu bản trình chiếu ở định dạng PPT, PPTX và ODP."
---
Minh họa cách thêm, truy cập và xoá macro VBA bằng cách sử dụng **Aspose.Slides for Python via .NET**.

## **Thêm macro VBA**

Tạo một bản trình chiếu có dự án VBA và một mô-đun macro đơn giản.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # Khởi tạo một dự án VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # Thêm một mô-đun trống có tên "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Truy cập macro VBA**

Lấy mô-đun đầu tiên từ dự án VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **Xoá macro VBA**

Xoá một mô-đun khỏi dự án VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # Giả sử bản trình chiếu chứa một dự án VBA và ít nhất một mô-đun.
        module = presentation.vba_project.modules[0]

        # Xoá mô-đun khỏi dự án.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```