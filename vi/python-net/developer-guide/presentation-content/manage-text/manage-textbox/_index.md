---
title: Quản lý Hộp Văn Bản trong Bản Trình Chiếu bằng Python
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
- bản trình chiếu
- Python
- Aspose.Slides
description: "Aspose.Slides for Python qua .NET giúp dễ dàng tạo, chỉnh sửa và sao chép hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hóa bản trình chiếu của bạn."
---
## **Giới thiệu**

Văn bản trên các slide thường nằm trong các hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản vào trong hộp đó. Aspose.Slides for Python cung cấp lớp [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) cho phép bạn thêm một hình dạng chứa một số văn bản.

{{% alert title="Info" color="info" %}}
Aspose.Slides cũng cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/). Tuy nhiên, không phải tất cả các hình dạng đều có thể chứa văn bản.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Do đó, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua lớp [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/). Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/), đây là một thuộc tính của [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/). Xem phần [Update Text](/slides/vi/python-net/manage-textbox/#update-text) trên trang này.
{{% /alert %}}

## **Tạo Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản trên slide:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide đầu tiên.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) với `ShapeType.RECTANGLE` tại vị trí mong muốn trên slide.
4. Đặt văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng.
5. Lưu bản trình chiếu dưới dạng tệp PPTX.

Ví dụ Python sau thực hiện các bước này:

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên trong bản trình chiếu.
    slide = presentation.slides[0]

    # Thêm một AutoShape loại RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm Tra Hình Dạng Có Phải Là Hộp Văn Bản Không**

Aspose.Slides cung cấp thuộc tính [is_text_box](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/is_text_box/) trên lớp [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) , cho phép bạn xác định một hình dạng có phải là hộp văn bản hay không.

![Text box and shape](istextbox.png)

Ví dụ Python này cho thấy cách kiểm tra một hình dạng có được tạo dưới dạng hộp văn bản hay không:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Lưu ý rằng nếu bạn thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) bằng cách sử dụng lớp [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/) , thuộc tính `is_text_box` của hình dạng sẽ trả về `False`. Tuy nhiên, sau khi bạn thêm văn bản—bằng phương thức `add_text_frame` hoặc bằng cách đặt thuộc tính `text`—`is_text_box` sẽ trả về `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box là sai
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box là đúng

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box là sai
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box là đúng

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box là sai
    shape3.add_text_frame("")
    # shape3.is_text_box là sai

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box là sai
    shape4.text_frame.text = ""
    # shape4.is_text_box là sai
```

## **Tìm Hình Dạng Sở Hữu Text Frame**

Trong mã xử lý văn bản chung, bạn có thể nhận được một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) mà chưa biết đối tượng bản trình chiếu nào chứa nó. Sử dụng thuộc tính [TextFrame.parent_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_shape/) để điều hướng trở lại [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) sở hữu.

Đối với một text frame thuộc về một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hoặc một hình dạng khác chứa văn bản, [TextFrame.parent_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_shape/) được đặt và [TextFrame.parent_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_cell/) có giá trị `None`. Cả hai thuộc tính đều là thuộc tính điều hướng chỉ đọc, vì vậy việc đọc chúng không thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về có phải là `None` trước khi truy cập vào hình dạng.

Để xem một ví dụ đầy đủ xác định chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên quan đến nút SmartArt, hãy xem mục [Search and Replace Text](/slides/vi/python-net/search-and-replace-text/).

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các thuộc tính [column_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_count/) và [column_spacing](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_spacing/) trên lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) để thêm cột vào hộp văn bản. Bạn có thể chỉ định số lượng cột và đặt khoảng cách (theo điểm) giữa các cột.

Đoạn mã Python sau minh họa thao tác này:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Lấy slide đầu tiên trong bản trình chiếu.
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

	# Xác định số cột trong TextFrame.
	format.column_count = 3

	# Xác định khoảng cách giữa các cột.
	format.column_spacing = 10

	# Lưu bản trình chiếu.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Cập Nhật Văn Bản**

Aspose.Slides cho phép bạn cập nhật văn bản trong một hộp văn bản duy nhất hoặc trên toàn bộ bản trình chiếu.

Ví dụ Python sau minh họa cách cập nhật tất cả văn bản trong một bản trình chiếu:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Lưu bản trình chiếu đã chỉnh sửa.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hộp Văn Bản với Siêu Liên Kết** 

Bạn có thể chèn một liên kết vào hộp văn bản. Khi hộp văn bản được nhấp, liên kết sẽ mở.

Để thêm một hộp văn bản chứa siêu liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide đầu tiên.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) với `ShapeType.RECTANGLE` tại vị trí mong muốn trên slide.
4. Đặt văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
5. Lấy tham chiếu tới [HyperlinkManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkmanager/).
6. Sử dụng thuộc tính `hyperlink_manager` để thiết lập một siêu liên kết nhấp bên ngoài.
7. Lưu bản trình chiếu dưới dạng tệp PPTX.

Ví dụ Python này cho thấy cách thêm một hộp văn bản có siêu liên kết vào slide:

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên trong bản trình chiếu.
    slide = presentation.slides[0]

    # Thêm một AutoShape loại RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Thêm văn bản vào khung.
    text_portion.text = "Aspose.Slides"

    # Đặt siêu liên kết cho văn bản đoạn.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Sự khác nhau giữa hộp văn bản và placeholder văn bản khi làm việc với các slide master là gì?**

Một [placeholder](/slides/vi/python-net/manage-placeholder/) kế thừa kiểu dáng/vị trí từ [master](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/) và có thể được ghi đè trên [layouts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/), trong khi một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi các layout.

**Làm thế nào để thực hiện thay thế văn bản hàng loạt trên toàn bộ bản trình chiếu mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế vòng lặp của bạn chỉ ở các auto-shape có text frame và loại trừ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua những loại đối tượng đó.