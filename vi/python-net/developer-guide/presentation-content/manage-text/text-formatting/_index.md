---
title: Định dạng Văn bản Trình chiếu trong Python
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/python-net/text-formatting/
keywords:
- đánh dấu văn bản
- biểu thức chính quy
- căn chỉnh đoạn
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
description: "Định dạng và tạo kiểu cho văn bản trong các bản trình chiếu PowerPoint và OpenDocument sử dụng Aspose.Slides cho Python qua .NET. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn nữa."
---
## **Tổng quan**

Bài viết này chỉ ra cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET. Nó bao gồm việc đánh dấu, màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn văn, hành vi tự động điều chỉnh, neo văn bản, tab stop và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng tôi sẽ sử dụng một tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Đánh dấu Văn bản**

Sử dụng phương thức [TextFrame.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_text/) khi bạn cần đánh dấu văn bản khớp với một mẫu cụ thể trong một khung văn bản. Phương thức này áp dụng màu đánh dấu cho các đoạn văn bản khớp và có thể được sử dụng cùng với [TextSearchOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/) để kiểm soát cách tìm kiếm được thực hiện, ví dụ, để chỉ khớp toàn bộ từ.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Lấy hình dạng đầu tiên từ slide đầu tiên.
    shape = presentation.slides[0].shapes[0]

    # Đánh dấu từ "try" trong hình dạng.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # Đánh dấu từ "to" trong hình dạng.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Văn bản đã được đánh dấu](highlighted_text.png)

## **Đánh dấu Văn bản bằng Biểu thức Chính quy**

Phương thức [TextFrame.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_regex/) đánh dấu các kết quả khớp văn bản được tìm bằng biểu thức chính quy. Trong Python, API này được mở ra trên [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).

Ví dụ mã dưới đây đánh dấu tất cả các từ chứa **bảy ký tự trở lên**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Đánh dấu tất cả các từ có bảy ký tự trở lên.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Văn bản đã được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đặt Màu Nền cho Văn bản**

Sử dụng [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/default_portion_format/) để đặt màu đánh dấu mặc định cho một đoạn, hoặc sử dụng [PortionFormat.highlight_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/highlight_color/) cho các phần văn bản riêng lẻ.

Ví dụ mã sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt màu đánh dấu cho toàn bộ đoạn.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Đoạn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ đậm**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Đặt màu đánh dấu cho phần văn bản.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh Đoạn Văn bản**

Sử dụng [ParagraphFormat.alignment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/alignment/) để đặt cách căn đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn về **giữa**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt căn chỉnh của đoạn về trung tâm.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Đoạn đã căn](aligned_paragraph.png)

## **Đặt Độ Trong Suốt cho Văn bản**

Độ trong suốt của văn bản được điều khiển thông qua thành phần alpha của màu được gán cho [PortionFormat.fill_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/fill_format/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0-255, không phải phần trăm trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt màu nền của văn bản thành màu trong suốt.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Đoạn trong suốt](transparent_paragraph.png)

Ví dụ mã sau đây cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ đậm**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **Đặt Khoảng Cách Ký Tự cho Văn bản**

Sử dụng [BasePortionFormat.spacing](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Mã Python sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ghi chú: Sử dụng giá trị âm để nén khoảng cách ký tự.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ đậm**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ghi chú: Sử dụng giá trị âm để nén khoảng cách ký tự.
            portion.portion_format.spacing = 3  # Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Tắt Kerning cho Các Phông Chữ Cụ Thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho đầu ra render gần hơn với PowerPoint trong các trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) thành giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ việc render của Aspose.Slides với đầu ra hình ảnh của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint này.

## **Quản lý Thuộc tính Phông chữ Văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/default_portion_format/) hoặc trên các phần riêng lẻ thông qua [PortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/).

Mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: nó áp dụng kích thước phông, in đậm, nghiêng, gạch chân chấm, và phông Times New Roman cho tất cả các phần trong đoạn.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Đặt các thuộc tính phông chữ cho đoạn.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Thuộc tính phông chữ cho đoạn](font_properties_for_paragraph.png)

Ví dụ mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông chữ đậm**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt Xoay Văn bản**

Sử dụng [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/text_vertical_type/) để đặt hướng văn bản định sẵn trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành `VERTICAL270`, quay văn bản **90 độ ngược chiều kim đồng hồ**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt Xoay Tùy chỉnh cho Khung Văn bản**

Sử dụng [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/rotation_angle/) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).

Ví dụ mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng cho Các Đoạn**

Aspose.Slides cung cấp [ParagraphFormat.space_after](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/space_before/), và [ParagraphFormat.space_within](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/space_within/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ mã sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Đặt Loại Tự động Phù hợp cho Khung Văn bản**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/autofit_type/) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát liệu văn bản co lại, tràn ra, hoặc tự động thay đổi kích thước hình dạng.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Neo cho Khung Văn bản**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/anchoring_type/) xác định cách văn bản được đặt theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Tab cho Văn bản**

Sử dụng [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/default_tab_size/) và [ParagraphFormat.tabs](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/tabs/) để cấu hình các vị trí tab trong một đoạn.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các tab của đoạn](paragraph_tabs.png)

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp [PortionFormat.language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/language_id/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được sử dụng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ mã sau cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Đặt Id của ngôn ngữ kiểm tra chính tả.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Ngôn ngữ Mặc định**

Sử dụng [LoadOptions.default_text_language](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/default_text_language/) để định nghĩa ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Thêm một hình chữ nhật mới có văn bản.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Kiểm tra ngôn ngữ của phần đầu tiên.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Đặt Kiểu Văn bản Mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [Presentation.default_text_style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/default_text_style/).

Ví dụ mã sau cho thấy cách đặt phông chữ đậm mặc định với kích thước 14 pt cho tất cả văn bản trên các slide trong một bản trình chiếu mới.

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

## **Trích xuất Văn bản với Hiệu ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông chữ **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản chính xác như đã nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `ALL`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng All Caps](all_caps_effect.png)

Ví dụ mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Kết quả đầu ra:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu hỏi thường gặp**

**Làm thế nào để chỉnh sửa văn bản trong bảng trên một slide?**

Để chỉnh sửa văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/). Duyệt các ô và cập nhật mỗi ô thông qua [Cell.text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/text_frame/) và định dạng đoạn qua [Paragraph.paragraph_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/paragraph_format/).

**Làm thế nào để áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [PortionFormat.fill_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/fill_format/). Đặt [FillFormat.fill_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/fill_type/) thành [FillType.GRADIENT](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.