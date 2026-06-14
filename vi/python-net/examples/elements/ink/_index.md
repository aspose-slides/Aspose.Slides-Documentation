---
title: Mực
type: docs
weight: 180
url: /vi/python-net/examples/elements/ink/
keywords:
- mực
- truy cập mực
- xoá mực
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Xử lý mực kỹ thuật số trên các slide trong Python với Aspose.Slides: thêm nét bút, chỉnh sửa đường dẫn, đặt màu và độ rộng, và xuất kết quả cho PowerPoint và OpenDocument."
---
Cung cấp các ví dụ về việc truy cập các hình mực hiện có và xoá chúng bằng **Aspose.Slides for Python via .NET**.

> ❗ **Note:** Các hình mực đại diện cho đầu vào của người dùng từ các thiết bị chuyên dụng. Aspose.Slides không thể tạo các nét mực mới bằng chương trình, nhưng bạn có thể đọc và chỉnh sửa các nét mực hiện có.

## **Truy cập Mực**

Lấy hình mực đầu tiên từ một slide.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Xóa Mực**

Xoá một hình mực khỏi slide.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình đầu tiên là đối tượng Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```