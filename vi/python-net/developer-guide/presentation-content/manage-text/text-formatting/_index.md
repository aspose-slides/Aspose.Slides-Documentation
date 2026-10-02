---
title: Định dạng Văn bản Bài thuyết trình trong Python
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/python-net/text-formatting/
keywords:
- căn đoạn
- kiểu văn bản
- nền văn bản
- độ trong suốt văn bản
- khoảng cách ký tự
- thuộc tính phông chữ
- họ phông chữ
- xoay văn bản
- góc xoay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự động điều chỉnh
- neo khung văn bản
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn nữa."
---
## **Tổng quan**

Bài viết này trình bày cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET. Nó bao phủ các màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động điều chỉnh kích thước, neo văn bản, tab stop và cài đặt ngôn ngữ.

Trừ khi được nêu khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Đối tượng dạng (shape) đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và shape đều bắt đầu từ 0. Các ví dụ chọn các phần in đậm sử dụng định dạng hiệu quả, bao gồm cả định dạng in đậm được kế thừa:

![Sample text](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên mẫu hoặc các kết quả khớp biểu thức chính quy, xem [Tìm và Thay Thế Văn Bản](/slides/vi/python-net/search-and-replace-text/).

## **Đặt màu nền cho văn bản**

Sử dụng [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) để đặt màu nổi bật mặc định cho một đoạn, hoặc sử dụng [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu nổi bật xám nhạt làm mặc định cho đoạn đầu tiên. Màu nổi bật rõ ràng trên các phần riêng lẻ sẽ có độ ưu tiên cao hơn mặc định này:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt màu nổi bật cho toàn bộ đoạn.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The gray paragraph](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Đặt màu nổi bật cho phần văn bản.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The gray text portions](gray_text_portions.png)

## **Căn chỉnh các đoạn văn bản**

Sử dụng [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) để đặt căn chỉnh đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn lề trái, căn lề phải, căn đều, v.v.

Ví dụ mã dưới đây cho thấy cách căn đoạn về **giữa**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt căn chỉnh của đoạn văn về trung tâm.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The aligned paragraph](aligned_paragraph.png)

## **Căn chỉnh phông chữ trong một dòng**

Sử dụng [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) để căn dọc các phần văn bản có kích thước phông chữ khác nhau trong một dòng. Cài đặt này áp dụng cho toàn bộ đoạn và kiểm soát căn chỉnh trong từng dòng của nó.

Ví dụ tự chứa dưới đây tạo bốn hộp văn bản có nhãn trên một slide. Mỗi đoạn chứa cùng một văn bản với kích thước 18, 36 và 54 điểm, với căn chỉnh phông chữ khác nhau. Nó sử dụng Arial, tắt tự động điều chỉnh kích thước và ngắt dòng, và giữ khung văn bản đủ lớn cho một dòng duy nhất.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Căn chỉnh phông chữ dựa trên số liệu phông, vì vậy các cạnh hiển thị của các ký tự riêng lẻ không nhất thiết phải thẳng hàng hoàn hảo. Ví dụ bao gồm một ký tự in hoa và một ký tự có phần đáy để giúp hiển thị sự khác biệt giữa căn chỉnh baseline và bottom. Khả năng sẵn có và thay thế phông, các ký tự được dùng, và sự khác nhau về kích thước phông ảnh hưởng đến kết quả. Kích thước khung, lề, khoảng cách dòng, ngắt dòng và tự động điều chỉnh kích thước cũng ảnh hưởng tới bố cục; hãy sử dụng cùng phông và cùng cài đặt bố cục khi so sánh các chế độ.

Cài đặt này khác với [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), kiểm soát căn chỉnh đoạn ngang, và [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), định vị khối văn bản dọc trong shape. Định dạng chỉ số trên [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) dịch chuyển các phần riêng lẻ so với baseline thay vì đặt căn chỉnh phông cho các dòng của đoạn.

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị alpha ARGB trên thang 0–255, không phải phần trăm độ trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt màu đen bán trong suốt cho văn bản.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The transparent paragraph](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Đặt độ trong suốt cho phần văn bản.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The transparent text portions](transparent_text_portions.png)

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm làm văn bản gọn lại.

Mã Python dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ in đậm**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
            portion.portion_format.spacing = 3  # Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Tắt kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần giống PowerPoint hơn trong các trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) thành giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu "presentation.pptx" với một hộp văn bản là shape đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông hiệu quả, bao gồm cả phông kế thừa, và đặt ngưỡng 100 điểm cho các phần dùng Roboto. Điều này sẽ tắt kerning cho các phần khớp có kích thước phông dưới 100 điểm:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Đối với văn bản khớp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp đồng bộ việc render của Aspose.Slides với kết quả hiển thị của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint.

## **Quản lý thuộc tính phông chữ của văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) hoặc trên các phần riêng lẻ qua [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Ví dụ sau đặt phông mặc định cho đoạn đầu tiên là Times New Roman 12 điểm với in đậm, in nghiêng và gạch dưới chấm. Định dạng rõ ràng trên các phần riêng lẻ sẽ ưu tiên hơn các mặc định này.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt các thuộc tính phông chữ cho đoạn.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, in nghiêng và gạch dưới chấm cho các phần có định dạng hiệu quả là in đậm:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Đặt các thuộc tính phông chữ cho phần văn bản.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Đặt xoay văn bản**

Sử dụng [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) để đặt hướng văn bản định sẵn trong một shape.

Mã dưới đây đặt hướng văn bản trong shape thành [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), làm quay văn bản **90 độ ngược chiều kim đồng hồ**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The text rotation](text_rotation.png)

## **Đặt xoay tùy chỉnh cho khung văn bản**

Sử dụng [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong shape:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The custom text rotation](custom_text_rotation.png)

## **Đặt khoảng cách dòng của các đoạn**

Aspose.Slides cung cấp [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), và [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ dưới đây đặt khoảng cách bên trong đoạn đầu tiên thành 200% chiều cao dòng (khoảng cách gấp đôi):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The line spacing within the paragraph](line_spacing.png)

## **Kiểm soát ngắt dòng**

Quy tắc ngắt dòng của đoạn hữu ích cho các khối văn bản hẹp và các bản trình chiếu hỗn hợp giữa văn bản Latin và Đông Á. Các thuộc tính sau thuộc về [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), do đó chúng áp dụng cho toàn bộ đoạn:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, việc thay đổi nó cũng có thể thay đổi nơi văn bản và dấu câu Đông Á liền kề được ngắt.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), tính năng tự động ngắt dòng trong một khung văn bản. Chúng ảnh hưởng đến bố cục khi ngắt dòng xảy ra; chúng không chèn ký tự ngắt dòng. Một ký tự ngắt dòng rõ ràng buộc một dòng mới trong đoạn bất kể độ rộng hiện có.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai thuộc tính ngắt dòng một cách rõ ràng và lưu "line_breaking.pptx". Để thử nghiệm một trong hai quy tắc, thay đổi giá trị của thuộc tính đó trong khi giữ cài đặt còn lại cố định. Ví dụ sử dụng Arial 24 điểm và SimSun với chiều rộng khung 160 điểm và lề ngang khung văn bản bằng 0. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) được đặt thành [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) để kích thước văn bản và kích thước khung giữ cố định.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm soát dấu câu treo**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) cho phép các dấu câu đủ điều kiện mở rộng ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu "hanging_punctuation.pptx". Với Arial 24 điểm và lề ngang khung bằng 0, dấu chấm cuối cùng vẫn ở sau "sentence" và mở rộng ra ngoài cạnh phải. Đặt thuộc tính thành [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm chiếm một dòng riêng. Ngắt dòng được bật và tự động điều chỉnh kích thước bị tắt để giữ độ rộng sẵn có cố định.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Không phải mọi dấu câu đều có thể treo. Kết quả hiển thị phụ thuộc vào [điều kiện phông và bố cục](#control-line-breaking): thay đổi phông, độ rộng có sẵn, lề, hoặc cài đặt tự động điều chỉnh kích thước có thể làm mất sự khác biệt hiển thị.

## **Đặt kiểu tự động điều chỉnh kích thước cho khung văn bản**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát việc văn bản co lại, tràn, hoặc tự động thay đổi kích thước shape. Ví dụ dưới đây cấu hình shape để thay đổi kích thước phù hợp với văn bản và lưu kết quả vào "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Để đếm số dòng sau khi tự động ngắt và xem cách thay đổi chiều rộng văn bản hoặc shape ảnh hưởng đến kết quả, xem [Count Rendered Lines](/slides/vi/python-net/manage-paragraph/). Số dòng chỉ không cho biết liệu văn bản có tràn khỏi vùng chứa hay không.

## **Đặt neo cho khung văn bản**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) xác định cách văn bản được định vị dọc bên trong một shape, ví dụ ở trên, giữa hoặc dưới. Ví dụ dưới đây neo văn bản vào đáy của shape đầu tiên và lưu kết quả vào "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt tab cho văn bản**

Sử dụng [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) và [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) để cấu hình các vị trí tab trong một đoạn. Ví dụ dưới đây đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn lề trái tại 30 điểm. Các cài đặt này ảnh hưởng tới văn bản chứa ký tự tab.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The paragraph tabs](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra xác định ngôn ngữ được dùng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ dưới đây yêu cầu "presentation.pptx" với một hộp văn bản là shape đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng "1。", đặt SimSun làm phông và gán ngôn ngữ kiểm tra Simplified Chinese (`zh-CN`). Sau đó lưu kết quả vào "proofing_language.pptx":

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Đặt ngôn ngữ kiểm tra chính tả thành tiếng Trung giản thể.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) để định nghĩa ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu. Ví dụ dưới đây tạo một bản trình chiếu với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in ra `en-US` cho phần văn bản đầu tiên của nó.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Thêm một shape hình chữ nhật mới với văn bản.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Kiểm tra ngôn ngữ của phần đầu tiên.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Ví dụ dưới đây đặt phông chữ đậm 14 điểm làm mặc định cho các đoạn cấp cao nhất trong một bản trình chiếu mới và lưu nó vào "default_text_style.pptx". Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lấy định dạng đoạn cấp cao nhất.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Trích xuất văn bản với hiệu ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi ban đầu được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `ALL`.

Ví dụ này yêu cầu "sample2.pptx" với một hộp văn bản là shape đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps được áp dụng, như hình dưới.

![The All Caps effect](all_caps_effect.png)

Mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** được áp dụng:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Làm thế nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô thông qua [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) và định dạng đoạn qua [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Làm thế nào để áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Đặt [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) thành [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.