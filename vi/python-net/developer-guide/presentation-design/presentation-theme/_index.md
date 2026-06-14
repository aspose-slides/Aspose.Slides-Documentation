---
title: Quản lý Chủ đề Bản trình chiếu PowerPoint trong Python
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/python-net/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các chủ đề trình chiếu trong Aspose.Slides cho Python thông qua .NET để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu xác định các thuộc tính của các yếu tố thiết kế. Khi bạn chọn một chủ đề, bạn đang lựa chọn một bộ các yếu tố hình ảnh và thuộc tính của chúng được phối hợp đồng bộ.

Trong PowerPoint, một chủ đề bao gồm màu sắc, [phông chữ](/slides/vi/python-net/powerpoint-fonts/), [kiểu nền](/slides/vi/python-net/presentation-background/), và hiệu ứng.

![các thành phần của chủ đề](theme-constituents.png)

## **Thay đổi màu chủ đề**

Một chủ đề PowerPoint sử dụng một tập hợp màu cụ thể cho các yếu tố khác nhau trên một slide. Nếu bạn không thích các mặc định, bạn có thể thay đổi chúng bằng cách áp dụng màu chủ đề mới. Để cho phép bạn chọn màu chủ đề mới, Aspose.Slides cung cấp các giá trị trong enumeration [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/).

Đoạn mã Python này cho thấy cách thay đổi màu nhấn của chủ đề:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Bạn có thể xác định giá trị thực tế của màu kết quả như sau:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Đầu ra ví dụ:
#
# ff8064a2 (Màu [A=255, R=128, G=100, B=162])
```

Để minh họa thêm việc thay đổi màu, chúng tôi tạo một yếu tố khác, gán cho nó màu nhấn từ bước đầu tiên, sau đó cập nhật màu chủ đề.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Màu mới được áp dụng tự động cho cả hai yếu tố.

### **Đặt màu chủ đề từ bảng màu bổ sung**

Khi bạn áp dụng các phép biến đổi độ sáng cho màu chủ đề chính (1), các màu từ bảng màu bổ sung (2) được tạo ra. Bạn có thể đặt và lấy các màu chủ đề đó.

![additional-palette-colors](additional-palette-colors.png)

**1** — Màu chủ đề chính

**2** — Màu từ bảng màu bổ sung

Đoạn mã Python này minh họa cách các màu từ bảng màu bổ sung được suy ra từ màu chủ đề chính và sau đó được sử dụng trong các hình dạng:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Màu phụ trợ 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Màu phụ trợ 4, Nhẹ hơn 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Màu phụ trợ 4, Nhẹ hơn 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Màu phụ trợ 4, Nhẹ hơn 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Màu phụ trợ 4, Đậm hơn 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Màu phụ trợ 4, Đậm hơn 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Ánh xạ `SchemeColor` tới các màu `ColorScheme`**

Khi bạn làm việc với [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/), bạn có thể nhận thấy nó chứa các giá trị màu chủ đề sau:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, và `TEXT2`.

Tuy nhiên, `Presentation.master_theme.color_scheme` trả về [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/), mà cung cấp các màu tương ứng dưới dạng:

`dark1`, `dark2`, `light1`, và `light2`.

Sự khác nhau này chỉ ở cách đặt tên. Các giá trị này đề cập đến cùng các vị trí màu chủ đề và ánh xạ là cố định:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Không có chuyển đổi động nào giữa `TEXT`/`BACKGROUND` và `dark`/`light`. Chúng chỉ là các tên thay thế cho cùng các màu chủ đề.

Sự khác biệt trong cách đặt tên này xuất phát từ thuật ngữ của Microsoft Office. Các phiên bản Office cũ sử dụng `Dark 1`, `Light 1`, `Dark 2`, và `Light 2`, trong khi các phiên bản giao diện người dùng mới hiển thị cùng các vị trí dưới dạng `Text 1`, `Background 1`, `Text 2`, và `Background 2`.

## **Thay đổi phông chữ chủ đề**

Để cho phép bạn chọn phông chữ cho các chủ đề và các mục đích khác, Aspose.Slides sử dụng các định danh đặc biệt này (tương tự như trong PowerPoint):

- **+mn‑lt** — Phông chữ thân Latin (Phông chữ Latin phụ)
- **+mj‑lt** — Phông chữ tiêu đề Latin (Phông chữ Latin chính)
- **+mn‑ea** — Phông chữ thân Đông Á (Phông chữ Đông Á phụ)
- **+mj‑ea** — Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Đoạn mã Python này cho thấy cách gán phông chữ Latin cho một yếu tố chủ đề:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Đoạn ví dụ Python này cho thấy cách thay đổi phông chữ chủ đề của bản trình chiếu:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Tất cả các hộp văn bản sẽ được cập nhật sang phông chữ mới.

{{% alert color="primary" title="TIP" %}}
Để biết thêm thông tin, xem [Phông chữ PowerPoint chính trong Python](/slides/vi/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Thay đổi kiểu nền chủ đề**

Mặc định, PowerPoint cung cấp 12 nền được định nghĩa trước, nhưng một bản trình chiếu điển hình chỉ lưu trữ 3 trong số chúng.

![todo:image_alt_text](presentation-design_8.png)

Ví dụ, sau khi bạn lưu một bản trình chiếu trong PowerPoint, bạn có thể chạy đoạn mã Python sau để xác định có bao nhiêu nền được định nghĩa trước trong nó:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Sử dụng thuộc tính `background_fill_styles` từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/) bạn có thể thêm hoặc truy cập các kiểu nền trong một chủ đề PowerPoint.
{{% /alert %}}

Đoạn ví dụ Python này cho thấy cách đặt nền cho bản trình chiếu:

```python
presentation.masters[0].background.style_index = 2  # 0 biểu thị không có màu nền; chỉ mục bắt đầu từ 1.
```

{{% alert color="primary" title="TIP" %}}
Để biết thêm thông tin, xem [Quản lý nền bản trình chiếu trong Python](/slides/vi/python-net/presentation-background/).
{{% /alert %}}

## **Thay đổi hiệu ứng chủ đề**

Một chủ đề PowerPoint thường bao gồm ba giá trị trong mỗi mảng kiểu. Các mảng này kết hợp thành ba cấp độ hiệu ứng: nhẹ, vừa và mạnh. Ví dụ, đây là kết quả khi các hiệu ứng đó được áp dụng cho một hình dạng cụ thể:

![todo:image_alt_text](presentation-design_10.png)

Sử dụng ba thuộc tính—`FillStyles`, `LineStyles`, và `EffectStyles`—từ lớp [FormatScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/) bạn có thể chỉnh sửa các yếu tố chủ đề (thậm chí linh hoạt hơn so với PowerPoint).

Đoạn mã Python này cho thấy cách thay đổi hiệu ứng chủ đề bằng cách thay đổi các phần của những yếu tố đó:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Các thay đổi kết quả bao gồm cập nhật màu nền, loại nền, hiệu ứng bóng đổ và các thuộc tính khác:

![todo:image_alt_text](presentation-design_11.png)

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một chủ đề cho một slide riêng lẻ mà không thay đổi master không?**

Có. Aspose.Slides hỗ trợ ghi đè chủ đề ở mức slide, vì vậy bạn có thể áp dụng một chủ đề cục bộ chỉ cho slide đó trong khi giữ nguyên chủ đề master (thông qua [SlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/slidethememanager/)).

**Cách an toàn nhất để chuyển một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

[Clone slides](/slides/vi/python-net/clone-slides/) cùng với master của chúng vào bản trình chiếu đích. Điều này giữ nguyên master, bố cục và chủ đề liên quan nên giao diện vẫn nhất quán.

**Làm thế nào để tôi xem các giá trị "effective" sau tất cả việc kế thừa và ghi đè?**

Sử dụng các “effective” view của API [/slides/vi/python-net/shape-effective-properties/] cho theme/color/font/effect. Các view này trả về các thuộc tính đã được giải quyết, cuối cùng sau khi áp dụng master cộng với bất kỳ ghi đè cục bộ nào.