---
title: SmartArt
type: docs
weight: 140
url: /vi/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- thêm SmartArt
- truy cập SmartArt
- xóa SmartArt
- bố cục SmartArt
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Xây dựng và chỉnh sửa SmartArt trong Python với Aspose.Slides: thêm nút, thay đổi bố cục và kiểu, chuyển đổi thành hình dạng một cách chính xác, và xuất ra cho PPT, PPTX và ODP."
---
Hiển thị cách thêm đồ họa SmartArt, truy cập chúng, xóa chúng và thay đổi bố cục bằng **Aspose.Slides for Python via .NET**.

## **Thêm SmartArt**

Chèn một đồ họa SmartArt bằng một trong các bố cục tích hợp.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập SmartArt**

Lấy đối tượng SmartArt đầu tiên trên một slide.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Truy cập hình dạng SmartArt đầu tiên.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Xóa SmartArt**

Xóa một hình dạng SmartArt khỏi slide.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một đối tượng SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay đổi Bố cục SmartArt**

Cập nhật loại bố cục của một đồ họa SmartArt hiện có.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Giả sử hình dạng đầu tiên là một đối tượng SmartArt.
        smart_art = slide.shapes[0]

        # Thay đổi bố cục SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```