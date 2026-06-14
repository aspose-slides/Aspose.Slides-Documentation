---
title: Quản lý Hộp Văn Bản trong Bản Trình Bày bằng Python
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/python-net/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Aspose.Slides cho Python qua .NET giúp bạn dễ dàng tạo, chỉnh sửa và sao chép hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bản trình bày của bạn."
---
## **Giới thiệu**

Văn bản trên các slide thường tồn tại trong các hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản vào trong hộp văn bản đó. Aspose.Slides cho Python cung cấp lớp [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) cho phép bạn thêm một hình dạng chứa một số văn bản.

{{% alert title="Info" color="info" %}}
Aspose.Slides cũng cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/). Tuy nhiên, không phải tất cả các hình dạng đều có thể chứa văn bản.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Do đó, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua lớp [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/). Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/), là một thuộc tính của [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/). Xem phần [Update Text](/slides/vi/python-net/manage-textbox/#update-text) trên trang này.
{{% /alert %}}

## **Tạo Hộp Văn Bản trên Slides**

Để tạo một hộp văn bản trên slide:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide đầu tiên.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) với `ShapeType.RECTANGLE` tại vị trí mong muốn trên slide.
4. Đặt văn bản trong [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng.
5. Lưu bản trình bày dưới dạng tệp PPTX.

Đoạn mã Python sau thực hiện các bước này:

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên trong bản trình bày.
    slide = presentation.slides[0]

    # Thêm một AutoShape loại RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Lưu bản trình bày vào đĩa.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm Tra Hình Dạng Có Phải Là Hộp Văn Bản Không**

Aspose.Slides cung cấp thuộc tính [is_text_box](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/is_text_box/) trên lớp [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/), cho phép bạn xác định một hình dạng có phải là hộp văn bản không.

![Hộp văn bản và hình dạng](istextbox.png)

Đoạn mã Python này cho thấy cách kiểm tra xem một hình dạng có được tạo thành hộp văn bản không:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Lưu ý rằng nếu bạn thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) bằng cách sử dụng lớp [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/), thuộc tính `is_text_box` của hình dạng sẽ trả về `False`. Tuy nhiên, sau khi bạn thêm văn bản — hoặc bằng phương thức `add_text_frame` hoặc bằng cách đặt thuộc tính `text` — `is_text_box` sẽ trả về `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box là false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box là true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box là false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box là true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box là false
    shape3.add_text_frame("")
    # shape3.is_text_box là false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box là false
    shape4.text_frame.text = ""
    # shape4.is_text_box là false
```

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các thuộc tính [column_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_count/) và [column_spacing](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_spacing/) trên lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) để thêm cột vào hộp văn bản. Bạn có thể chỉ định số lượng cột và đặt khoảng cách (tính bằng điểm) giữa các cột.

Mã Python sau minh họa thao tác này:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Lấy slide đầu tiên trong bản trình bày.
	slide = presentation.slides[0]

	# Thêm một AutoShape loại RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Thêm một TextFrame vào hình chữ nhật.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Lấy định dạng văn bản của TextFrame.
	format = shape.text_frame.text_frame_format

	# Xác định số lượng cột trong TextFrame.
	format.column_count = 3

	# Xác định khoảng cách giữa các cột.
	format.column_spacing = 10

	# Lưu bản trình bày.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập Nhật Văn Bản**

Aspose.Slides cho phép bạn cập nhật văn bản trong một hộp văn bản duy nhất hoặc trên toàn bộ bản trình bày.

Đoạn mã Python sau minh họa cách cập nhật toàn bộ văn bản trong một bản trình bày:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Lưu bản trình bày đã sửa đổi.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hộp Văn Bản với Siêu Liên Kết**

Bạn có thể chèn một liên kết vào hộp văn bản. Khi hộp văn bản được nhấp, liên kết sẽ mở.

Để thêm một hộp văn bản chứa siêu liên kết, làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide đầu tiên.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) với `ShapeType.RECTANGLE` tại vị trí mong muốn trên slide.
4. Đặt văn bản trong [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
5. Lấy tham chiếu tới [HyperlinkManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkmanager/).
6. Sử dụng thuộc tính `hyperlink_manager` để đặt một siêu liên kết click bên ngoài.
7. Lưu bản trình bày dưới dạng tệp PPTX.

Đoạn mã Python này cho thấy cách thêm một hộp văn bản có siêu liên kết vào slide:

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên trong bản trình bày.
    slide = presentation.slides[0]

    # Thêm một AutoShape loại RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Thêm văn bản vào khung.
    text_portion.text = "Aspose.Slides"

    # Đặt siêu liên kết cho phần văn bản.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa hộp văn bản và trình giữ chỗ văn bản khi làm việc với slide mẫu là gì?**

Một [placeholder](/slides/vi/python-net/manage-placeholder/) kế thừa kiểu dáng/vị trí từ [master](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/) và có thể bị ghi đè trên [layouts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/), trong khi đó, một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi bố cục.

**Làm thế nào để thực hiện thay thế văn bản hàng loạt trên toàn bộ bản trình bày mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế việc lặp lại của bạn chỉ đối với các auto-shape có khung văn bản và loại trừ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/)) bằng cách duyệt các collection của chúng riêng biệt hoặc bỏ qua các loại đối tượng đó.