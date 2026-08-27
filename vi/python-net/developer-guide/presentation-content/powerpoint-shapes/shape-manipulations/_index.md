---
title: Quản lý các hình dạng trong bản thuyết trình bằng Python
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/python-net/shape-manipulations/
keywords:
- Hình PowerPoint
- Hình trong bản thuyết trình
- Hình trên slide
- Tìm hình
- Sao chép hình
- Xóa hình
- Ẩn hình
- Thay đổi thứ tự hình
- Lấy ID hình interop
- Văn bản thay thế của hình
- Điểm điều chỉnh hình
- Điều chỉnh hình preset
- Hình học hình
- Định dạng bố cục hình
- Hình dưới dạng SVG
- Chuyển hình sang SVG
- Căn chỉnh hình
- Lật hình
- PowerPoint
- bản thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình trong bản thuyết trình bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python via .NET biểu diễn các hình dạng trên một slide dưới dạng một [ShapeCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/) có thứ tự. Bộ sưu tập này vừa là nơi bạn tìm và sửa đổi các hình dạng vừa là nguồn gốc của thứ tự xếp chồng: chỉ mục `0` là hình ở phía sau nhất, trong khi chỉ mục cuối cùng là hình ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình một cách đáng tin cậy và chỉnh sửa các điểm điều chỉnh hình dạng đã được thiết lập sẵn, sau đó cho thấy cách sao chép, xóa, ẩn và sắp lại thứ tự các hình. Các phần cuối cùng đề cập đến định dạng ở mức layout, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ đều độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác cần thiết cho quy trình của mình.

## **Xác định và Tìm Kiếm Hình Dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp lại một hình có thể thay đổi chỉ mục của nó. Chọn một định danh phù hợp với cách bài thuyết trình được tạo và duy trì:

- [Shape.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/name/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy nên thiết lập quy tắc đặt tên nếu mã phụ thuộc vào chúng.
- [Shape.alternative_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/alternative_text/) hữu ích khi mô tả khả năng truy cập hoặc thẻ do tác giả cung cấp đã xác định rõ hình. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho khả năng truy cập, và không được đảm bảo là duy nhất. Đừng tự ý dùng lại văn bản khả năng truy cập có ý nghĩa làm khóa cơ sở dữ liệu.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/office_interop_shape_id/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình. Một hình được sao chép hoặc tạo lại là một hình khác và nhận ID riêng của nó.

Thuộc tính [Shape.unique_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/unique_id/) có phạm vi toàn bộ bài thuyết trình, nhưng nó dành cho add‑in và có thể được gán lại. Không nên coi nó là khóa bên ngoài vĩnh viễn. Nếu cần nhận dạng lâu dài, hãy lưu bản đồ trong dữ liệu ứng dụng và xác thực rằng hình mong đợi vẫn tồn tại.

Ví dụ sau tìm kiếm bằng `name` với so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác đặc thù cho một loại hình, hãy kiểm tra loại trước khi sử dụng các thành viên đặc thù. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).

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

## **Xác Định và Chỉnh Sửa Các Điều Chỉnh Hình Dạng Đặt Sẵn**

Các hình dạng hình học đặt sẵn có thể hiển thị các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng thông qua bộ sưu tập chỉ đọc [GeometryShape.adjustments](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/adjustments/). Bộ sưu tập này được cung cấp bởi hình dạng, nhưng mỗi [AdjustValue](https://reference.aspose.com/slides/vi/python-net/aspose.slides/adjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục cố định. Duyệt qua các điều chỉnh và kiểm tra thuộc tính chỉ đọc [AdjustValue.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/adjustvalue/type/), giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapeadjustmenttype/) mô tả điều chỉnh kiểm soát gì. Thuộc tính chỉ đọc [AdjustValue.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/adjustvalue/name/) cung cấp thêm thông tin nhận dạng và đặc biệt hữu ích khi một preset chứa nhiều hơn một điều chỉnh có cùng loại ngữ nghĩa.

Sử dụng thuộc tính giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CORNER_SIZE` | Kích thước góc bo tròn | [raw_value](https://reference.aspose.com/slides/vi/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Độ dày phần đuôi mũi tên | `raw_value` |
| `ARROWHEAD_LENGTH` | Độ dài đầu mũi tên | `raw_value` |
| `ARROWHEAD_WIDTH` | Độ rộng đầu mũi tên | `raw_value` |
| `START_ANGLE` | Góc bắt đầu của vòng tròn hoặc cung | [angle_value](https://reference.aspose.com/slides/vi/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Góc kết thúc của vòng tròn hoặc cung | `angle_value` |

`type` và `name` không thể gán. `raw_value` là một số nguyên đọc/ghi theo đơn vị hình học gốc của preset, trong khi `angle_value` là góc đọc/ghi tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào [GeometryShape.shape_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/geometryshape/shape_type/). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho preset khác.

Khi `type` là `ShapeAdjustmentType.CUSTOM`, API không nhận ra ý nghĩa ngữ nghĩa tiêu chuẩn. Kiểm tra `name`, loại preset và giá trị hiện có, và giữ nguyên điều chỉnh trừ khi bạn biết ý nghĩa và phạm vi mong muốn. Ngay cả với các loại đã được công nhận, cũng cần kiểm tra xem cùng một loại có xuất hiện nhiều hơn một lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/python-net/connector/) minh họa trường hợp này với các điều chỉnh gập nối.

Ví dụ đầy đủ sau tạo các phiên bản mặc định và đã chỉnh sửa của ba hình preset. Nó duyệt qua mọi điều chỉnh, báo cáo `name` và `type`, thay đổi các giá trị liên quan đến kích thước qua `raw_value`, thay đổi góc qua `angle_value`, và lưu kết quả. Cột trái giữ hình học mặc định; cột phải hiển thị hình chữ nhật bo tròn, mũi tên bốn chiều và hình bánh pie đã được điều chỉnh.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Thêm tiêu đề cho các cột hình dạng mặc định và đã điều chỉnh.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Kiểm tra loại ngữ nghĩa trước khi thay đổi giá trị giúp mã rõ ràng về mục đích và tránh giả định rằng một chỉ mục bộ sưu tập cụ thể có cùng ý nghĩa giữa các hình preset khác nhau.

## **Chỉnh Sửa Bộ Sưu Tập Hình Dạng**

Các phương thức thêm, sao chép, xóa và sắp lại hoạt động ngay trên bộ sưu tập. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước thao tác đó.

### **Sao Chép Một Hình Dạng**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_clone/) tạo một bản sao độc lập và thêm vào cuối bộ sưu tập đích. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/insert_clone/) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn một bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không ảnh hưởng đến hình nguồn.

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

Sao chép bao gồm nội dung và định dạng của hình, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên được sử dụng bởi các hình phức tạp do bản thuyết trình quản lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình mới.

### **Xóa Hình Dạng**

[ShapeCollection.remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/remove/) xóa một đối tượng hình cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều mục khớp trong khi duyệt theo chỉ mục, hãy duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình có tên được chỉ định. Nó đọc `slide.shapes[index]`, không phải một mục bộ sưu tập cố định, và không ép kiểu hình không cần thiết.

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

Sau khi xóa, số lượng hình và chỉ mục của các hình phía sau sẽ thay đổi. Tham chiếu đến các hình không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần cân nhắc các connector, hoạt ảnh và các tính năng khác của bản thuyết trình có thể tham chiếu đến đối tượng đã xóa; việc xóa một hình hiển thị có thể thay đổi hơn cả diện mạo của slide.

### **Ẩn Một Hình Dạng**

Đặt [Shape.hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/hidden/) thành `True` giữ hình trong bộ sưu tập nhưng ngăn nó xuất hiện trong chế độ chiếu slide bình thường. Chỉ mục, định dạng và nội dung của nó vẫn có sẵn cho mã, vì vậy ẩn là phù hợp cho các thành phần tùy chọn có thể được khôi phục sau.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã khám phá và hiển thị lại, và nó vẫn là một phần của tệp bản thuyết trình.

### **Thay Đổi Z‑Order**

Các hình chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [ShapeCollection.reorder](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/reorder/) di chuyển một hình đã tồn tại đến một chỉ mục mục tiêu mà không sao chép nó. Chỉ mục `0` là phía sau; `len(slide.shapes) - 1` là phía trước.

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

Hình chữ nhật được tạo đầu tiên và ban đầu ở sau hình ellipse. Di chuyển nó đến chỉ mục cuối cùng sẽ đặt nó lên phía trước. Hoàn thiện z‑order sau khi đã thêm hoặc sao chép tất cả các hình liên quan, vì các thao tác đó sẽ thêm hoặc chèn mục mới vào bộ sưu tập và có thể làm thay đổi ngăn xếp mong muốn.

## **Kiểm Tra Các Hình Dạng Trên Slide Layout**

Slide thường, slide layout và master slide có các bộ sưu tập hình độc lập. Một hình trong bộ sưu tập layout không phải là cùng một đối tượng với một hình có vị trí tương tự trên slide thường. Kiểm tra các hình trên layout khi bạn cần hiểu hoặc thay đổi định dạng do layout cung cấp.

Ví dụ sau đọc mỗi [Shape.fill_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/fill_format/) và [Shape.line_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/line_format/) của layout mà không giả định rằng mọi hình đều là `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Chỉnh sửa một layout có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình layout, xác định xem một slide thường có kế thừa đối tượng này hay có ghi đè cục bộ, và thử nghiệm trên mọi slide dùng layout đó.

## **Xuất Hình Dạng Ra SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/write_as_svg/) ghi nội dung đã render của một hình vào một stream. Kết quả chỉ chứa hình, không phải toàn bộ nền slide hoặc các hình lân cận.

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

Giữ bản thuyết trình mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình riêng lẻ. Người gọi sở hữu stream và phải đóng nó.

## **Căn Chỉnh Hình Dạng**

Các overload [SlideUtil.align_shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/align_shapes/) cho phép căn chỉnh tất cả các hình hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapesalignmenttype/) chỉ định cạnh, đường trung tâm hoặc chế độ phân bố. Đặt `align_to_slide` thành `True` để căn theo các cạnh slide; đặt `False` để căn các hình đã chọn tương quan với nhau.

Ví dụ này căn ba hình với cạnh trên cùng của slide. Các chỉ mục hiện tại của chúng được xác định ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không thay đổi z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình, trong khi phân bố ngang hoặc dọc cần đủ hình để xác định khoảng cách. Tính lại chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapeframe/) lưu vị trí, kích thước, cài đặt lật ngang và dọc, và góc xoay. Các giá trị `flip_h` và `flip_v` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/python-net/aspose.slides/nullablebool/): `TRUE` bật lật, `FALSE` tắt, và `NOT_DEFINED` giữ trạng thái chưa xác định hoặc mặc định.

Bản thuyết trình đầu vào dưới đây chứa một hình chưa được lật.

![Hình trước khi lật](shape_to_be_flipped.png)

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

Hình đã lưu được lật ngang và dọc trong khi vẫn giữ vị trí, kích thước và góc xoay.

![Hình sau khi lật](flipped_shape.png)

## **FAQ**

**Có nên dùng chỉ mục bộ sưu tập làm định danh cho hình không?**

Chỉ nên dùng trong quá trình ngắn hạn khi bộ sưu tập không thay đổi trước khi chỉ mục được dùng. Ưu tiên quy tắc `name` hoặc `alternative_text` đã được xác thực cho các mẫu được tạo, hoặc `office_interop_shape_id` cho công việc interop có phạm vi slide.

**Ẩn một hình có làm nó bị loại khỏi z‑order không?**

Không. Một hình ẩn vẫn còn trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm, sắp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình đã sao chép lại xuất hiện trước một hình khác?**

`add_clone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước trong z‑order. Dùng `insert_clone` để chọn chỉ mục khởi tạo hoặc `reorder` sau khi đã thêm tất cả các hình.

**Có thể dùng chỉ mục cố định để xác định một điều chỉnh hình preset không?**

Chỉ được sau khi đã xác thực preset và bố trí bộ sưu tập chính xác. Ưu tiên duyệt qua `GeometryShape.adjustments` và kiểm tra `AdjustValue.type`; dùng `AdjustValue.name` như thông tin bổ sung khi cùng một loại ngữ nghĩa xuất hiện nhiều lần.