---
title: Slide
type: docs
weight: 10
url: /vi/python-net/examples/elements/slide/
keywords:
- slide
- thêm slide
- truy cập slide
- chỉ mục slide
- sao chép slide
- sắp xếp lại slide
- xóa slide
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý slide trong Python với Aspose.Slides: tạo, sao chép, sắp xếp lại, ẩn, đặt nền và kích thước, áp dụng chuyển đổi, và xuất ra cho PowerPoint và OpenDocument."
---
Bài viết này cung cấp một loạt các ví dụ minh họa cách làm việc với slide bằng **Aspose.Slides for Python via .NET**. Bạn sẽ học cách thêm, truy cập, sao chép, sắp xếp lại và xóa slide bằng lớp `Presentation`.

Mỗi ví dụ dưới đây bao gồm một phần giải thích ngắn gọn và sau đó là đoạn mã Python.

## **Thêm một slide**

Để thêm một slide mới, trước tiên bạn phải chọn một bố cục. Trong ví dụ này, chúng tôi sử dụng bố cục `Blank` và thêm một slide trống vào bản trình chiếu.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Mỗi slide dựa trên một bố cục, mà bản thân nó dựa trên một master slide.
        # Sử dụng bố cục Blank để tạo một slide mới.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Thêm một slide trống mới bằng cách sử dụng bố cục đã chọn.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Mẹo:** Mỗi bố cục slide được tạo ra từ một master slide, định nghĩa thiết kế tổng thể và cấu trúc placeholder. Hình ảnh bên dưới minh họa cách các master slide và các bố cục liên quan được tổ chức trong PowerPoint.

![Mối quan hệ giữa Master và Layout](master-layout-slide.png)

## **Truy cập slide theo chỉ mục**

Bạn có thể truy cập slide bằng chỉ mục của chúng. Điều này hữu ích khi lặp qua hoặc sửa đổi các slide cụ thể.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Truy cập một slide theo chỉ mục.
        first_slide = presentation.slides[0]
```

## **Sao chép một slide**

Ví dụ này trình bày cách sao chép một slide hiện có. Slide đã sao chép sẽ tự động được thêm vào cuối bộ sưu tập slide.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Sao chép slide; nó sẽ được thêm vào cuối bản trình chiếu.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Sắp xếp lại các slide**

Bạn có thể thay đổi thứ tự các slide bằng cách di chuyển một slide tới chỉ mục mới. Trong trường hợp này, chúng ta di chuyển một slide lên vị trí đầu tiên.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Di chuyển slide tới vị trí đầu tiên (các slide khác sẽ dịch xuống).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa một slide**

Để xóa một slide, chỉ cần tham chiếu tới nó và gọi `remove`. Ví dụ này xóa slide đầu tiên.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Xóa slide.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```