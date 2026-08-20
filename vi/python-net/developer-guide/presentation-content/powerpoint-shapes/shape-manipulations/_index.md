---
title: Quản lý các hình dạng trên bản trình chiếu bằng Python
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/python-net/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xoá hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- hình dạng thành SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách xác định, sao chép, xoá, ẩn, sắp lại thứ tự, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python via .NET biểu diễn các hình dạng trên một slide dưới dạng một [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Nó đầu tiên giải thích cách xác định một hình dạng một cách đáng tin cậy, sau đó chỉ ra cách sao chép, xóa, ẩn và sắp lại thứ tự các hình dạng. Các phần cuối cùng đề cập đến định dạng ở mức bố cục, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình công việc của bạn yêu cầu.

## **Xác định và Tìm kiếm Hình dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp lại thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Chọn một định danh dựa trên cách bản trình bày được tạo và duy trì:

- [Shape.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/name/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [Shape.alternative_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/alternative_text/) hữu dụng khi mô tả trợ năng hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được địa phương hoá hoặc viết lại cho trợ năng, và không được đảm bảo là duy nhất. Đừng yên lặng tái sử dụng văn bản trợ năng có ý nghĩa làm khóa cơ sở dữ liệu.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/office_interop_shape_id/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và sẽ nhận ID riêng của nó.

Thuộc tính liên quan [Shape.unique_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/unique_id/) có phạm vi toàn bộ bản trình bày, nhưng nó được thiết kế cho các add-in và có thể được gán lại. Không nên coi nó như một khóa bên ngoài vĩnh viễn. Nếu nhận dạng lâu dài là quan trọng, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Ví dụ dưới đây tìm kiếm theo `name` với so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Khi một thao tác cụ thể cho một loại hình dạng, kiểm tra kiểu trước khi sử dụng các thành viên đặc thù kiểu. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ nếu đối tượng có tên là một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Sửa đổi Bộ sưu tập Hình dạng**

Các phương thức thêm, sao chép, xóa và sắp lại hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác làm thay đổi số lượng hoặc thứ tự của các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước thao tác đó.

### **Sao chép một Hình dạng**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_clone/) tạo một bản sao độc lập và thêm vào cuối bộ sưu tập đích. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/insert_clone/) cũng tạo một bản sao nhưng đặt nó tại một chỉ mục z‑order xác định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao có thể thay đổi kích thước đồng thời.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi một trong các bản sao không làm thay đổi hình nguồn.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Sao chép bao gồm nội dung và định dạng của hình, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được trình chiếu xử lý, nhưng một bản sao vẫn là mục mới trong bộ sưu tập với định danh hình dạng mới.

### **Xóa Hình dạng**

[ShapeCollection.remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/remove/) xoá một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả phù hợp trong quá trình lặp có chỉ mục, duyệt từ cuối lên để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc `slide.shapes[index]`, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng một cách không cần thiết.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình sau thay đổi. Tham chiếu tới các hình không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần cân nhắc các connector, hoạt ảnh và các tính năng trình chiếu khác có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi nhiều hơn chỉ vẻ ngoài của slide.

### **Ẩn một Hình dạng**

Đặt [Shape.hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/hidden/) thành `True` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong chế độ trình chiếu thông thường. Chỉ mục, định dạng và nội dung của nó vẫn sẵn sàng cho mã, vì vậy ẩn phù hợp cho các yếu tố tùy chọn có thể được khôi phục sau này.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã khám phá và hiển thị lại, và nó vẫn là một phần của tệp trình chiếu.

### **Thay đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [ShapeCollection.reorder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/reorder/) di chuyển một hình dạng đã tồn tại tới một chỉ mục đích mà không sao chép. Chỉ mục `0` là phía sau; `len(slide.shapes) - 1` là phía trước.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Hình chữ nhật được tạo trước và ban đầu nằm phía sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đặt nó lên phía trước. Hoàn thiện thứ tự z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó thêm hoặc chèn mục mới vào bộ sưu tập và có thể làm thay đổi ngăn xếp đã dự định.

## **Kiểm tra Hình dạng trên Slide Bố cục**

Slide thường, slide bố cục và slide master có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng ở vị trí tương tự trên slide thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do bố cục cung cấp.

Ví dụ dưới đây đọc [Shape.fill_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/fill_format/) và [Shape.line_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/line_format/) của mỗi hình dạng bố cục mà không giả định mọi hình dạng đều là `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Việc chỉnh sửa một bố cục có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố cục, xác định xem slide thường có kế thừa đối tượng này hay chứa một ghi đè cục bộ, và thử nghiệm mọi slide sử dụng bố cục đó.

## **Xuất Hình dạng ra SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/write_as_svg/) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chứa hình dạng, không phải toàn bộ nền slide hoặc các hình dạng lân cận.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Giữ trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải đóng nó.

## **Căn chỉnh Hình dạng**

Các overload của [SlideUtil.align_shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/align_shapes/) căn chỉnh toàn bộ hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân bố. Đặt `align_to_slide` thành `True` để sử dụng các cạnh slide; đặt thành `False` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các chỉ mục hiện tại của chúng được tính ngay trước khi căn chỉnh.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Căn chỉnh thay đổi vị trí, không thay đổi z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân bố ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `flip_h` và `flip_v` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/python-net/aspose.slides/nullablebool/): `TRUE` bật lật, `FALSE` tắt lật, và `NOT_DEFINED` giữ trạng thái chưa xác định hoặc mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình dạng chưa bị lật.

![Hình dạng trước khi lật](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì gán một [Shape.frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/frame/) mới sẽ thay thế toàn bộ khung.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Hình dạng đã lưu được lật ngược chiều ngang và chiều dọc trong khi vẫn giữ vị trí, kích thước và góc quay.

![Hình dạng sau khi lật](flipped_shape.png)

## **FAQ**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng trong các xử lý ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên một quy ước `name` hoặc `alternative_text` đã được xác thực cho các mẫu do người viết, hoặc `office_interop_shape_id` cho công việc interop có phạm vi slide.

**Việc ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn ở trong bộ sưu tập với cùng chỉ mục. Nó có thể được tìm, sắp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng sao chép lại xuất hiện phía trước một hình dạng khác?**

`add_clone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước trong z‑order. Sử dụng `insert_clone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi đã thêm tất cả các hình dạng.