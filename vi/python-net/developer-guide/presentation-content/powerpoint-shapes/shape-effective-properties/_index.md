---
title: Lấy Thuộc tính Hiệu quả của Hình dạng từ Bản trình chiếu bằng Python
linktitle: Thuộc tính Hiệu quả
type: docs
weight: 50
url: /vi/python-net/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính máy ảnh
- bộ ánh sáng
- độ nghiêng hình dạng
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng tô
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Python thông qua .NET tính toán và áp dụng các thuộc tính hình dạng hiệu quả để hiển thị PowerPoint một cách chính xác."
---
## **Tổng quan**

Chủ đề này giải thích sự khác biệt giữa các thuộc tính **cục bộ** và **hiệu quả**. Giá trị cục bộ là các giá trị được đặt trực tiếp tại một mức định dạng cụ thể, chẳng hạn:

1. Thuộc tính phần trong một slide.  
2. Kiểu văn bản hình dạng nguyên mẫu trên bố cục hoặc slide mẫu, khi hình dạng khung văn bản của phần có một kiểu.  
3. Cài đặt văn bản toàn cục trong một bản trình chiếu.

Giá trị cục bộ có thể được định nghĩa hoặc không ở bất kỳ mức nào. Khi Aspose.Slides cần định dạng cuối cùng “được hiển thị”, nó giải quyết chuỗi kế thừa và trả về các giá trị **hiệu quả**. Bạn có thể lấy chúng bằng cách gọi phương thức `get_effective` trên đối tượng định dạng cục bộ.

Ví dụ sau cho thấy cách lấy giá trị hiệu quả. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) có khung văn bản và ít nhất một phần.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Dữ liệu định dạng hiệu quả đại diện cho định dạng hiện tại đã được tính toán sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu hiệu quả, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iportionformateffectivedata/), có thể được lưu trong bộ nhớ đệm nội bộ. Gọi lại `get_effective` sau khi thay đổi định dạng cha hoặc kế thừa có thể làm mới dữ liệu đã được lưu, và một đối tượng đã lấy trước đó có thể không còn đại diện cho trạng thái ban đầu. Nếu bạn cần bảo tồn các giá trị hiệu quả để sử dụng lại sau này, hãy sao chép các thuộc tính cần thiết, chẳng hạn như chiều cao phông chữ, màu nền, kiểu phông hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy Thuộc tính Hiệu quả của Máy ảnh**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu quả của máy ảnh. Kiểu [ICameraEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/icameraeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính máy ảnh hiệu quả. Một thể hiện của [ICameraEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/icameraeffectivedata/) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị hiệu quả cho [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/).

Mẫu mã sau cho thấy cách lấy các thuộc tính hiệu quả cho máy ảnh. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Lấy Thuộc tính Hiệu quả của Bộ ánh sáng**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu quả của bộ ánh sáng. Kiểu [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ilightrigeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính bộ ánh sáng hiệu quả. Một thể hiện của [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ilightrigeffectivedata/) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị hiệu quả cho [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/).

Mẫu mã sau cho thấy cách lấy các thuộc tính hiệu quả cho bộ ánh sáng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Lấy Thuộc tính Hiệu quả của Độ nghiêng Hình dạng**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu quả của độ nghiêng hình dạng. Kiểu [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapebeveleffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính relief mặt cho một hình dạng. Một thể hiện của [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapebeveleffectivedata/) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị hiệu quả cho [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/).

Mẫu mã sau cho thấy cách lấy các thuộc tính hiệu quả cho cạnh nghiêng trên của một hình dạng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Lấy Thuộc tính Hiệu quả của Khung Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu quả của một khung văn bản. Kiểu [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/itextframeformateffectivedata/) chứa các thuộc tính định dạng khung văn bản hiệu quả.

Mẫu mã sau cho thấy cách lấy các thuộc tính định dạng khung văn bản hiệu quả. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) có khung văn bản.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Lấy Thuộc tính Hiệu quả của Kiểu Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu quả của một kiểu văn bản. Kiểu [ITextStyleEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/itextstyleeffectivedata/) chứa các thuộc tính kiểu văn bản hiệu quả.

Mẫu mã sau cho thấy cách lấy các thuộc tính kiểu văn bản hiệu quả. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) có khung văn bản.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Lấy Giá trị Chiều cao Phông chữ Hiệu quả**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ hiệu quả. Đoạn mã sau minh họa cách chiều cao phông chữ hiệu quả của một phần thay đổi sau khi các giá trị chiều cao phông chữ cục bộ được đặt ở các mức cấu trúc bản trình chiếu khác nhau.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy Định dạng Điền Hiệu quả cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng điền hiệu quả cho các phần khác nhau của bảng. Kiểu [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifillformateffectivedata/) chứa các thuộc tính định dạng điền hiệu quả. Định dạng ô có ưu tiên cao hơn định dạng hàng, định dạng hàng có ưu tiên cao hơn định dạng cột, và định dạng cột có ưu tiên cao hơn định dạng toàn bảng.

Do đó, các thuộc tính của [ICellFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/icellformateffectivedata/) được sử dụng để vẽ ô bảng. Mẫu mã sau cho thấy cách lấy định dạng điền hiệu quả cho các phần khác nhau của bảng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **Câu hỏi thường gặp**

**`get_effective` có trả về một ảnh chụp nhanh không?**

Không phải lúc nào cũng vậy. Dữ liệu hiệu quả đại diện cho định dạng đã được tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu hiệu quả có thể được lưu trong bộ nhớ đệm nội bộ. Một cuộc gọi `get_effective` tiếp theo có thể tính lại định dạng và làm mới dữ liệu đã lưu, vì vậy một đối tượng đã lấy trước đó không nên được coi là một ảnh chụp cố định.

**Khi nào tôi nên đọc lại các thuộc tính hiệu quả?**

Gọi lại `get_effective` sau khi thay đổi định dạng cục bộ, kiểu cha, định dạng bố cục, định dạng mẫu hoặc các mặc định ở mức bản trình chiếu. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả hiệu quả hiện tại.

**Việc thay đổi hoặc xoá một slide bố cục/mẫu có ảnh hưởng đến các thuộc tính hiệu quả đã được lấy không?**

Có, nhưng thay đổi sẽ được phản ánh ở lần gọi `get_effective` tiếp theo. Nếu nguồn định dạng cha bị thay đổi hoặc xoá, dữ liệu hiệu quả đã lấy trước có thể trở nên lỗi thời. Khi `get_effective` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc các giá trị khác có thể thay đổi.

**Tôi có thể sửa đổi giá trị thông qua các đối tượng dữ liệu hiệu quả không?**

Không. Các đối tượng dữ liệu hiệu quả chỉ cung cấp các giá trị đã tính toán. Thực hiện thay đổi trong các đối tượng định dạng cục bộ, sau đó lấy lại các giá trị hiệu quả.

**Nếu một thuộc tính không được đặt ở cấp hình dạng, cũng không ở bố cục/mẫu, cũng không ở cài đặt toàn cục thì sao?**

Giá trị hiệu quả được xác định bởi cơ chế mặc định, bao gồm các mặc định của PowerPoint và Aspose.Slides. Giá trị đã được giải quyết này sẽ trở thành một phần của dữ liệu hiệu quả hiện tại.

**Từ một giá trị phông chữ hiệu quả, tôi có thể biết được cấp độ nào đã cung cấp kích thước hoặc kiểu chữ không?**

Không trực tiếp. Dữ liệu hiệu quả chỉ trả về giá trị cuối cùng. Để tìm nguồn, hãy kiểm tra các giá trị cục bộ ở mức phần, đoạn, khung văn bản và các kiểu văn bản ở mức bố cục, mẫu và bản trình chiếu để xem nơi xuất hiện định nghĩa rõ ràng đầu tiên.

**Tại sao các giá trị hiệu quả đôi khi trông giống hệt với giá trị cục bộ?**

Bởi vì giá trị cục bộ đã trở thành giá trị cuối cùng (không cần kế thừa ở mức cao hơn). Trong những trường hợp đó, giá trị hiệu quả trùng khớp với giá trị cục bộ.

**Khi nào tôi nên sử dụng thuộc tính hiệu quả, và khi nào chỉ làm việc với các thuộc tính cục bộ?**

Sử dụng dữ liệu hiệu quả khi bạn cần kết quả “được hiển thị” sau khi tất cả các kế thừa đã được áp dụng, chẳng hạn để đồng bộ màu sắc, thụt lề hoặc kích thước. Nếu bạn cần bảo tồn các giá trị này bất kể những thay đổi định dạng sau này, hãy sao chép các thuộc tính cần thiết vào đối tượng riêng của bạn. Nếu bạn muốn thay đổi định dạng ở một mức cụ thể, hãy sửa các thuộc tính cục bộ và sau đó, nếu cần, đọc lại dữ liệu hiệu quả để xác minh kết quả.