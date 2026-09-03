---
title: Quản lý các hộp văn bản trong bản trình chiếu bằng Python
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
description: "Tạo, nhận dạng, định dạng và cập nhật các hộp văn bản trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET."
---
## **Giới thiệu**

Trong Aspose.Slides for Python via .NET, văn bản trên slide được lưu trong các khung văn bản (text frames) thuộc về các hình dạng (shapes). Lớp [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) đại diện cho hình dạng chứa văn bản phổ biến nhất và cung cấp văn bản của nó thông qua thuộc tính [AutoShape.text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Note" %}}
Mỗi auto shape kế thừa từ [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/), nhưng không phải mọi shape đều là auto shape hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình chiếu hiện có, hãy sử dụng `isinstance(shape, slides.AutoShape)` để kiểm tra loại shape trước khi truy cập văn bản của nó.
{{% /alert %}}

## **Tạo một Text Box trên Slide**

Để tạo một text box, hãy thêm một auto shape vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình chiếu. Ví dụ sau tạo một text box hình chữ nhật:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Các tọa độ và kích thước truyền cho [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_auto_shape/) được đo bằng điểm. [AutoShape.add_text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/add_text_frame/) khởi tạo khung văn bản với văn bản đã cung cấp.

## **Kiểm tra xem một Shape có phải là Text Box không**

Sử dụng thuộc tính [AutoShape.is_text_box](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/is_text_box/) để xác định một auto shape có được coi là text box hay không. Điều này hữu ích khi một bản trình chiếu chứa cả các auto shape có văn bản và các auto shape chỉ là đồ họa.

![A text box and a shape](istextbox.png)

Ví dụ sau kiểm tra mọi auto shape trong một bản trình chiếu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Một auto shape được thêm mới sẽ không được coi là text box cho đến khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó thông qua [AutoShape.add_text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/add_text_frame/) hoặc [TextFrame.text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/text/). Thêm hoặc gán một chuỗi rỗng sẽ khiến [is_text_box](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/is_text_box/) luôn là `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Hai lời gọi đầu tiên in ra `True`; hai lời gọi cuối in ra `False`.

## **Tìm Shape sở hữu một Text Frame**

Mã xử lý văn bản chung có thể nhận được một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) mà không biết đối tượng bản trình chiếu nào chứa nó. Hãy sử dụng thuộc tính chỉ đọc [TextFrame.parent_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_shape/) để quay lại shape sở hữu nó.

Đối với một text frame thuộc về một auto shape hoặc một shape chứa văn bản khác, [parent_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_shape/) chứa chủ sở hữu và [TextFrame.parent_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_cell/) là `None`. Hãy kiểm tra giá trị trả về trước khi truy cập. Để xác định cả chủ sở hữu shape và ô bảng, bao gồm các shape liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/python-net/search-and-replace-text/).

## **Thêm Cột vào Text Box**

Thuộc tính [TextFrameFormat.column_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_count/) chia khung văn bản thành các cột, trong khi [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_spacing/) đặt khoảng cách giữa các cột tính bằng điểm. Cả hai thiết lập đều thuộc về [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/) và có thể được thay đổi thông qua khung văn bản của một text box hiện có. Văn bản được luồng lại giữa các cột trong cùng một shape; nó không tiếp tục sang shape khác.

Ví dụ sau tạo một text box ba cột với khoảng cách 10 điểm giữa các cột, lưu bản trình chiếu và đọc lại các thiết lập từ tệp đầu ra:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Trích xuất Văn bản từ Các Cột Riêng lẻ**

Sử dụng [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/split_text_by_columns/) để lấy văn bản được gán cho mỗi cột trực quan trong một text frame hiện có. Phương thức trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Một text frame một cột sẽ trả về danh sách có một phần tử, và một cột rỗng được biểu diễn bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng cấp phần không được bảo lưu.

Điều này hữu ích khi bạn cần:

- Trích xuất văn bản đồng thời giữ nguyên thứ tự đọc dựa trên cột.
- Đánh chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường cơ sở dữ liệu, hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thay đổi [TextFrameFormat.column_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/column_spacing/), phông chữ, hoặc kích thước khung văn bản.

Phương thức báo cáo văn bản được phân phối trong [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) hiện tại; nó không tự động luồng văn bản giữa các shape hoặc text box riêng biệt. Phân phối cột có thể phụ thuộc vào phông chữ khả dụng và các thiết lập bố cục văn bản khác, vì vậy hãy chắc chắn các phông chữ cần thiết có sẵn khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình chiếu, tìm auto shape đa cột đầu tiên có text frame, đọc số cột đã cấu hình và ghi văn bản từ mỗi cột ra một tệp riêng. Các shape không cung cấp text frame sẽ bị bỏ qua.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Cập nhật Văn bản**

Để cập nhật văn bản trong toàn bộ bản trình chiếu, hãy lặp qua các slide và shape, chọn các auto shape, rồi chỉnh sửa các phần văn bản của chúng. Làm việc ở cấp phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

Ví dụ sau thay thế mọi lần xuất hiện của `years` bằng `months` trong văn bản auto shape và làm cho mỗi phần bị ảnh hưởng trở nên in đậm:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Quá trình duyệt này chỉ cập nhật văn bản trong các auto shape. Văn bản lưu trong bảng, biểu đồ, SmartArt hoặc shape nhóm yêu cầu duyệt các bộ sưu tập riêng của các đối tượng đó.

## **Thêm Text Box có Siêu liên kết**

Một siêu liên kết có thể được gán cho một phần văn bản cụ thể, vì vậy chỉ phần văn bản đó sẽ hoạt động như một liên kết có thể nhấp. Sử dụng [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/vi/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) để liên kết phần đó với một URL bên ngoài.

Ví dụ sau tạo văn bản có liên kết và lưu nó vào bản trình chiếu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Sự khác nhau giữa text box và placeholder văn bản trên slide master hoặc layout là gì?**

Một [placeholder](/slides/vi/python-net/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [master slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslide/) hoặc [layout slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/). Một text box thông thường là một shape độc lập trên slide mà nó được tạo và không nhận hành vi placeholder khi layout thay đổi.

**Làm sao thay thế văn bản mà không ảnh hưởng tới văn bản trong biểu đồ, bảng hoặc SmartArt?**

Giới hạn việc duyệt chỉ ở các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) như trong ví dụ Cập nhật Văn bản. Biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng, vì vậy chúng sẽ không bị thay đổi bởi vòng lặp đó.