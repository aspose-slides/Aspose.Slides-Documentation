---
title: Quản lý Placeholder trong Bài thuyết trình với Python
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/python-net/manage-placeholder/
keywords:
- trình giữ chỗ
- placeholder văn bản
- placeholder hình ảnh
- placeholder biểu đồ
- văn bản nhắc
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Quản lý placeholder trong Aspose.Slides cho Python qua .NET một cách dễ dàng: thay thế văn bản, tùy chỉnh nhắc & đặt độ trong suốt hình ảnh trong PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các placeholder của bài thuyết trình một cách lập trình. Bài viết này giải thích cách tìm placeholder trên các slide và thay đổi văn bản của chúng, đặt văn bản nhắc tùy chỉnh cho các layout placeholder, và điều chỉnh độ trong suốt của hình ảnh được sử dụng làm nền placeholder. Nó cũng bao gồm một phần FAQ ngắn giải thích sự khác nhau giữa base placeholder và local shape, mô tả cách áp dụng thay đổi placeholder thông qua layouts hoặc masters, và chỉ đến việc quản lý placeholder header và footer.

## **Thay đổi văn bản trong Placeholder**

Sử dụng Aspose.Slides cho Python, bạn có thể tìm và sửa đổi các placeholder trên các slide trong một bài thuyết trình. Aspose.Slides cho phép bạn sửa đổi văn bản trong một placeholder.

**Yêu cầu trước:** Bạn cần một bài thuyết trình có chứa placeholder. Bạn có thể tạo một bài thuyết trình như vậy trong Microsoft PowerPoint.

Đây là cách sử dụng Aspose.Slides để thay thế văn bản trong một placeholder:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và truyền bài thuyết trình làm đối số.
1. Lấy tham chiếu tới slide bằng chỉ mục của nó.
1. Duyệt qua các shape để tìm placeholder.
1. Thay đổi văn bản bằng cách sử dụng [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) liên kết với [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).
1. Lưu bài thuyết trình đã sửa đổi.

Đoạn mã Python này cho thấy cách thay đổi văn bản trong một placeholder:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Duyệt qua các shape để tìm placeholder.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Thay đổi văn bản trong mỗi placeholder.
            shape.text_frame.text = "This is Placeholder"

    # Lưu bài thuyết trình vào ổ đĩa.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt văn bản nhắc cho Placeholder**

Các layout tiêu chuẩn và được dựng sẵn bao gồm văn bản nhắc placeholder như **Click to add a title** hoặc **Click to add a subtitle**. Với Aspose.Slides, bạn có thể thay thế các nhắc này bằng văn bản riêng của mình trong các layout placeholder.

Ví dụ Python sau đây cho thấy cách đặt văn bản nhắc cho một placeholder:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Duyệt qua các shape để tìm placeholder.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt độ trong suốt hình ảnh trong Placeholder**

Aspose.Slides cho phép bạn đặt độ trong suốt của hình ảnh nền trong một placeholder văn bản. Bằng cách điều chỉnh độ trong suốt của ảnh trong khung đó, bạn có thể làm nổi bật văn bản hoặc hình ảnh, tùy thuộc vào màu sắc của chúng.

Ví dụ Python sau đây cho thấy cách đặt độ trong suốt cho nền hình ảnh bên trong một shape:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **Câu hỏi thường gặp**

**Base placeholder là gì và nó khác gì so với local shape trên slide?**

Base placeholder là shape gốc trên layout hoặc master mà shape của slide kế thừa—kiểu, vị trí và một số định dạng đến từ nó. Local shape là độc lập; nếu không có base placeholder, việc kế thừa sẽ không áp dụng.

**Làm sao để cập nhật tất cả tiêu đề hoặc chú thích trên toàn bộ bài thuyết trình mà không phải duyệt qua từng slide?**

Chỉnh sửa placeholder tương ứng trên layout hoặc master. Các slide dựa trên những layout/master đó sẽ tự động kế thừa thay đổi.

**Làm sao tôi kiểm soát các placeholder tiêu chuẩn cho header/footer—ngày & giờ, số slide và văn bản footer?**

Sử dụng các trình quản lý HeaderFooter ở phạm vi phù hợp (slide thường, layouts, master, notes/handouts) để bật hoặc tắt các placeholder đó và đặt nội dung của chúng.