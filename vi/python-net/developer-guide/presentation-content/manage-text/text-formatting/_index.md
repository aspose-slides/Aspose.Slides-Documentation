---
title: Định dạng Văn bản Bản trình chiếu trong Python
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
- họ phông
- xoay văn bản
- góc xoay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự động vừa
- neo khung văn bản
- đánh tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn thế nữa."
---
## **Tổng quan**

Bài viết này mô tả cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides for Python via .NET. Nó bao gồm các màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, vị trí tab và cài đặt ngôn ngữ.

Trừ khi được ghi rõ khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều tính từ 0. Các ví dụ chọn phần in đậm sử dụng định dạng có hiệu lực, bao gồm cả định dạng in đậm kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên literal hoặc các khớp biểu thức chính quy, xem mục [Search and Replace Text](/slides/vi/python-net/search-and-replace-text/).

## **Đặt Màu Nền cho Văn Bản**

Sử dụng [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) để thiết lập màu nền mặc định cho một đoạn văn, hoặc sử dụng [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu nền xám nhạt làm màu mặc định cho đoạn văn đầu tiên. Màu nền được chỉ định rõ ràng cho các phần riêng lẻ sẽ có ưu tiên hơn giá trị mặc định này:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt màu làm nổi bật cho toàn bộ đoạn văn.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Đoạn văn xám](gray_paragraph.png)

Ví dụ mã dưới đây cho thấy cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Đặt màu làm nổi bật cho phần văn bản.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các phần văn bản xám](gray_text_portions.png)

## **Căn Lề Đoạn Văn Bản**

Sử dụng [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) để đặt căn lề đoạn văn trong một khung văn bản. Giá trị có thể là centered, left-aligned, right-aligned, justified, v.v.

Ví dụ mã sau cho thấy cách căn đoạn văn **ở giữa**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt căn chỉnh của đoạn văn thành giữa.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Căn Phông Chữ Trong Một Dòng**

Sử dụng [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) để căn dọc các phần văn bản có kích thước phông chữ khác nhau trong một dòng. Cài đặt này áp dụng cho toàn bộ đoạn và kiểm soát việc căn chỉnh trong mỗi dòng của nó.

Ví dụ tự chứa dưới đây tạo bốn hộp văn bản có nhãn trên một slide. Mỗi đoạn chứa cùng một văn bản với kích thước 18, 36 và 54 điểm, với một kiểu căn phông khác nhau. Nó dùng Arial, tắt tính năng tự động vừa và gập đoạn, và giữ khung văn bản đủ lớn cho một dòng duy nhất.

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

![So sánh căn Baseline, Top, Center và Bottom với kích thước phông hỗn hợp](font_alignment.png)

Căn phông sử dụng các số liệu phông, vì vậy các cạnh nhìn thấy của các ký tự riêng lẻ không nhất thiết phải thẳng hàng hoàn toàn. Ví dụ bao gồm một chữ hoa và một ký tự có phần xuống để minh họa sự khác nhau giữa căn baseline và bottom. Tính sẵn có của phông, việc thay thế phông, các ký tự được dùng và sự khác nhau về kích thước phông đều ảnh hưởng đến kết quả. Kích thước khung, lề, khoảng cách dòng, gập đoạn và tự động vừa cũng ảnh hưởng đến bố cục; hãy dùng cùng một phông và cùng cài đặt bố trí khi so sánh các chế độ.

Cài đặt này khác với [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), điều khiển căn lề ngang của đoạn, và [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), vị trí khối văn bản theo chiều dọc trong hình dạng. Định dạng superscript và subscript qua [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) dịch chuyển các phần riêng lẻ so với baseline thay vì thiết lập căn phông cho các dòng của đoạn.

## **Đặt Độ Trong Suốt cho Văn Bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị alpha ARGB trên thang 0–255, không phải là phần trăm trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn văn**:

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

![Đoạn văn trong suốt](transparent_paragraph.png)

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

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự cho Văn Bản**

Sử dụng [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ thu hẹp văn bản.

Đoạn mã Python sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn văn**:

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

![Khoảng cách ký tự trong đoạn văn](character_spacing_in_paragraph.png)

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

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Tắt Kerning cho Các Phông Cụ Thể Cụ Thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để đưa kết quả render gần hơn với PowerPoint trong những trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông bị ảnh hưởng. Đặt [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) thành giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu tệp "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông hiệu lực, bao gồm các phông kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này tắt kerning cho các phần khớp có kích thước phông dưới 100 điểm:

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

Đối với các văn bản khớp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp kết quả render của Aspose.Slides gần hơn với đầu ra trực quan của PowerPoint đối với các phông bị ảnh hưởng bởi hành vi riêng của PowerPoint này.

## **Quản Lý Thuộc Tính Phông Chữ của Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) hoặc ở mức phần riêng lẻ thông qua [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Ví dụ sau đặt phông mặc định cho đoạn văn đầu tiên là Times New Roman 12 điểm với in đậm, in nghiêng và gạch chân chấm. Định dạng riêng cho các phần sẽ có ưu tiên hơn các mặc định này.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt thuộc tính phông cho đoạn văn.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Thuộc tính phông cho đoạn văn](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, in nghiêng và gạch chân chấm cho các phần có định dạng hiệu lực là in đậm:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Đặt thuộc tính phông cho phần văn bản.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Thuộc tính phông cho các phần văn bản](font_properties_for_text_portions.png)

## **Kiểm Soát Chuẩn Hóa Chiều Cao Văn Bản**

Sử dụng [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) khi tái tạo kiểu chữ mẫu hoặc điều tra sự khác biệt về chiều cao ký tự. Trong PowerPoint, bật chuẩn hóa kéo giãn hoặc nén các ký tự riêng lẻ theo chiều dọc để chúng có chiều cao nhìn thấy đồng nhất trong phần văn bản. Nó không đảm bảo các đoạn văn có chiều cao văn bản bằng nhau giữa các phông khác nhau.

Đặt thuộc tính thành [NullableBool.TRUE hoặc FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) để bật hoặc tắt chuẩn hóa một cách rõ ràng. `NullableBool.NOT_DEFINED` để lại cài đặt cục bộ không được đặt, do đó phần sẽ kế thừa giá trị từ đoạn, ví dụ, từ [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/). Nó không đồng nghĩa với `False`. Sử dụng [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) và đọc [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) để lấy giá trị Boolean đã được giải quyết.

Ví dụ tự chứa dưới đây yêu cầu **Arial** được cài đặt. Nó tạo hai khối văn bản chứa cùng các chữ hoa, chữ thường, ký tự có phần xuống và ký tự có dấu ở kích thước 54 điểm. Cả hai đoạn đều bật chuẩn hóa theo mặc định. Phần trên tắt chuẩn hóa một cách rõ ràng; phần dưới kế thừa. Kích thước khung, lề và khoảng cách đoạn đều giống nhau, với gập đoạn và tự động vừa tắt để duy trì so sánh nhất quán. Ví dụ in ra `FALSE: False` và `NOT_DEFINED: True`, sau đó lưu "text_height_normalization.pptx".

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

So sánh dưới đây được xuất từ bản trình chiếu đã lưu. Hàng trên có chuẩn hóa tắt (`FALSE`); hàng dưới kế thừa cài đặt bật (`NOT_DEFINED` → `True`). Giữ Arial được cài đặt để tái tạo hình ảnh này.

![Văn bản Arial 54 điểm với chuẩn hóa tắt ở trên và chuẩn hóa kế thừa ở dưới](text_height_normalization.png)

Chuẩn hóa thay đổi chiều cao ký tự mà không thay đổi giá trị [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) đã gán, giá trị này xác định kích thước phông tính bằng điểm. [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) của đoạn điều khiển khoảng cách dòng, trong khi [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) của khung văn bản điều khiển cách văn bản hoặc khung của nó điều chỉnh để vừa. Các cài đặt này phục vụ các mục đích khác nhau và có thể ảnh hưởng độc lập đến bố cục tổng thể. Để biết thêm về định dạng đoạn và kế thừa, xem mục [Manage Paragraph](/slides/vi/python-net/manage-paragraph/).

## **Áp Dụng và Xóa Gạch Đè**

Sử dụng [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) trên một phần văn bản để hiển thị các sửa chữa, thuật ngữ đã hủy hoặc giá cũ mà không xóa văn bản gốc. Đặt nó thành [TextStrikethroughType.SINGLE hoặc DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) để có một hoặc hai đường kẻ qua văn bản.

Để xóa gạch đè, gán `TextStrikethroughType.NONE`. Điều này tắt hiệu ứng một cách rõ ràng, ngay cả khi định dạng xung quanh chỉ định gạch đè. Ngược lại, `TextStrikethroughType.NOT_DEFINED` để lại cài đặt cục bộ không được xác định, cho phép phần kế thừa định dạng, ví dụ, từ đoạn. Nó không đảm bảo gạch đè bị xóa. Sử dụng [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) để đọc định dạng sau khi áp dụng, bao gồm các giá trị kế thừa.

Ví dụ tự chứa dưới đây tạo ba so sánh giá. Mỗi đoạn có các phần riêng cho nhãn, giá cũ và giá hiện tại, vì vậy chỉ giá cũ bị ảnh hưởng. Hàng đầu áp dụng và sau đó xóa gạch đè; các hàng còn lại giữ gạch đè đơn và đôi. Thay đổi thuộc tính này giữ nguyên văn bản và các định dạng khác, bao gồm giá cũ in đậm.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Áp dụng gạch ngang, sau đó xóa rõ ràng nó khỏi giá trước đầu tiên.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả, từ trên xuống: không có gạch đè, gạch đè đơn, và gạch đè đôi.

![Giá trước không có gạch, có gạch đơn và gạch đôi](strikethrough.png)

## **Đặt Xoay Văn Bản**

Sử dụng [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) để đặt hướng văn bản được xác định trước bên trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), quay văn bản **90 độ ngược chiều kim đồng hồ**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Hiển Thị Hai Chữ Số Bên Nhau trong Văn Bản Dọc**

Để giữ một số hai chữ số cùng nhau trong một nhãn tiếng Nhật theo chiều dọc, đặt cả hai chữ số trong một phần văn bản và đặt [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) cho phần đó. Ví dụ tạo hai nhãn trong một bản trình chiếu mới sử dụng [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) và MS Gothic 40 điểm. Chỉ giá trị [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) được gán cho phần số thay đổi.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

Trong PowerPoint, nhãn bên trái (`TRUE`) hiển thị các chữ số thẳng đứng và bên nhau giữa 和 và 年. Trong nhãn bên phải (`FALSE`), cặp chữ số được quay 90 độ theo chiều kim đồng hồ. Các ký tự tiếng Nhật bao quanh vẫn thẳng đứng trong cả hai nhãn.

![So sánh nhãn ngày dọc trong PowerPoint với các chữ số thẳng đứng bên trái và các chữ số quay bên phải.](vertical_date.png)

## **Đặt Xoay Tùy Chỉnh cho Khung Văn Bản**

Sử dụng [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Ví dụ mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng cho Các Đoạn Văn**

Aspose.Slides cung cấp [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) và [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng tính bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn đầu tiên là 200% chiều cao dòng (gấp đôi):

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

![Khoảng cách dòng trong đoạn văn](line_spacing.png)

## **Kiểm Soát Ngắt Dòng**

Các quy tắc ngắt dòng của đoạn hữu ích trong các khối văn bản hẹp và các bản trình chiếu pha trộn văn bản Latin và Đông Á. Các thuộc tính sau thuộc về [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), vì vậy chúng áp dụng cho toàn bộ đoạn:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, thay đổi nó cũng có thể thay đổi vị trí gập đoạn của văn bản và dấu câu Đông Á liền kề.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), chức năng tự động gập đoạn trong khung văn bản. Chúng ảnh hưởng tới bố cục khi gập đoạn xảy ra; chúng không chèn ký tự ngắt dòng. Một ký tự ngắt dòng rõ ràng buộc một dòng mới trong đoạn bất kể độ rộng khả dụng.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai thuộc tính ngắt dòng một cách rõ ràng và lưu "line_breaking.pptx". Để thử nghiệm mỗi quy tắc, thay đổi giá trị của thuộc tính đó trong khi giữ các cài đặt còn lại cố định. Ví dụ sử dụng Arial 24 điểm và SimSun với độ rộng khung 160 điểm và lề ngang khung văn bản bằng 0. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) được đặt thành [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) để kích thước văn bản và khung giữ cố định.

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

## **Kiểm Soát Dấu Câu Treo**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) cho phép các dấu câu đủ điều kiện mở rộng ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu "hanging_punctuation.pptx". Với Arial 24 điểm và lề ngang khung bằng 0, dấu chấm cuối cùng ở sau “sentence” và mở rộng ra ngoài cạnh phải của văn bản. Đặt thuộc tính thành [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm chiếm một dòng riêng. Gập đoạn được bật và tự động vừa tắt để giữ độ rộng khả dụng cố định.

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

Không phải mọi dấu câu đều có thể treo. Kết quả hiển thị phụ thuộc vào [các điều kiện phông và bố cục](#control-line-breaking): thay đổi phông, độ rộng khả dụng, lề hoặc cài đặt tự động vừa có thể loại bỏ sự khác biệt nhìn thấy.

## **Đặt Kiểu Tự Động Vừa cho Khung Văn Bản**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát liệu văn bản co lại, tràn ra ngoài, hay tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để thay đổi kích thước phù hợp với văn bản và lưu kết quả vào "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Để đếm số dòng sau khi gập đoạn tự động và xem cách chiều rộng văn bản hoặc hình dạng thay đổi kết quả, xem [Count Rendered Lines](/slides/vi/python-net/manage-paragraph/). Số dòng một mình không cho biết văn bản có tràn ra ngoài vùng chứa hay không.

## **Đặt Neo cho Khung Văn Bản**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ, ở trên, giữa hoặc dưới. Ví dụ sau neo văn bản vào phía dưới của hình dạng đầu tiên và lưu kết quả vào "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Tab cho Văn Bản**

Sử dụng [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) và [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) để cấu hình các vị trí tab trong một đoạn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn lề trái tại 30 điểm. Các cài đặt này ảnh hưởng đến văn bản có ký tự tab.

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

![Các tab của đoạn văn](paragraph_tabs.png)

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được dùng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng "1。", đặt phông SimSun và gán ngôn ngữ kiểm tra Simplified Chinese (`zh-CN`). Sau đó lưu kết quả vào "proofing_language.pptx":

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

    # Đặt ngôn ngữ kiểm tra chính tả thành Tiếng Trung giản thể.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Sao Chép Siêu Dữ Liệu Ngôn Ngữ**

Khi sao chép văn bản đa ngôn ngữ từ mẫu, hãy bảo tồn cả [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) và [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Ví dụ tự chứa dưới đây tạo một phần nguồn với tiếng Anh Mỹ làm ngôn ngữ và tiếng Pháp làm ngôn ngữ thay thế, sau đó sao chép văn bản và các định danh vào một phần trong bản trình chiếu mới.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Nếu nguồn không có ngôn ngữ thay thế, None sẽ xóa giá trị của đích.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Để thử nguồn không có ngôn ngữ thay thế, bỏ qua việc gán `"fr-FR"`. Khi đó định danh thay thế sẽ là `None`, và câu lệnh sao chép giữ nguyên sự vắng mặt này mà không đưa vào giá trị mặc định, ngay cả khi đích trước đó đã có ngôn ngữ thay thế được gán.

Các định danh này lưu siêu dữ liệu ngôn ngữ. Bảo tồn chúng không quyết định PowerPoint sẽ chọn từ điển nào cho kiểm tra chính tả hoặc ngữ pháp.

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo bản trình chiếu. Ví dụ sau tạo một bản trình chiếu với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Thêm một hình chữ nhật mới với văn bản.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Kiểm tra ngôn ngữ của phần đầu tiên.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Ví dụ sau đặt phông in đậm 14 điểm làm mặc định cho các đoạn văn cấp cao nhất trong một bản trình chiếu mới và lưu nó vào "default_text_style.pptx". Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè chúng.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lấy định dạng đoạn văn cấp độ cao nhất.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Trích Xuất Văn Bản với Hiệu Ứng In Hoa**

Trong PowerPoint, áp dụng hiệu ứng font **All Caps** làm cho văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện trả về văn bản chính xác như đã nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `ALL`.

Ví dụ này yêu cầu "sample2.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps được áp dụng, như hình dưới.

![Hiệu ứng All Caps](all_caps_effect.png)

Ví dụ mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** được áp dụng:

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

**Làm sao tôi có thể sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô qua [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) và định dạng đoạn qua [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Làm sao tôi áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Đặt [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) thành [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) và cấu hình các điểm gradient, hướng và độ trong suốt.

Tính năng liên quan: [Format text within slides](/slides/vi/features/text-formatting/).