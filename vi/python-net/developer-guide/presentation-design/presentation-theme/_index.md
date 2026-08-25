---
title: Quản lý Theme Bản trình chiếu PowerPoint trong Python
linktitle: Theme Bản trình chiếu
type: docs
weight: 10
url: /vi/python-net/presentation-theme/
keywords:
- Theme PowerPoint
- Theme bản trình chiếu
- Theme slide
- Đặt theme
- Thay đổi theme
- Quản lý theme
- Màu theme
- Bảng màu bổ sung
- Phông theme
- Kiểu theme
- Hiệu ứng theme
- PowerPoint
- OpenDocument
- Bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các theme bản trình chiếu trong Aspose.Slides cho Python qua .NET để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một theme của bản trình chiếu xác định một tập hợp đồng bộ các màu sắc, phông chữ, kiểu nền, màu nền, đường viền và hiệu ứng. Các đối tượng nhận thức theme tham chiếu đến các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan như một giá trị cố định, do đó việc thay đổi theme có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, theme ở mức bản trình chiếu có thể truy cập thông qua thuộc tính [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/). Một bản trình chiếu cũng có thể chứa các ghi đè theme ở các cấp thấp hơn. Một master có thể ghi đè theme của bản trình chiếu thông qua [MasterThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/masterthememanager/override_theme/), một layout có thể ghi đè theme kế thừa của nó thông qua [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), và một slide riêng lẻ cũng có thể làm tương tự. Trong thực tế, theme thực tế cho một slide được xác định qua chuỗi kế thừa này: theme của bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của Theme: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với theme phổ biến nhất: kiểm tra một theme, thay đổi màu và phông chữ, sao chép hoặc áp dụng theme, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra Theme**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/) cung cấp các thuộc tính [color_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/font_scheme/), và [format_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/format_scheme/) của theme. Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính theme chính và báo cáo số lượng style nền, màu nền, đường viền và hiệu ứng được lưu trong theme:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Nếu một tệp sử dụng nhiều master, không nên giả định mọi slide có cùng theme thực tế. Kiểm tra master liên kết với slide, và sử dụng quy trình theme thực tế được mô tả sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi màu Theme**

Các màu nền, đường viền và văn bản nhận thức theme có thể tham chiếu tới một màu logic từ liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) của theme, tất cả các đối tượng vẫn tham chiếu đến màu theme đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi khi cập nhật màu theme.

Ví dụ toàn diện sau tạo một shape sử dụng `ACCENT4`, thay đổi màu `accent4` của theme thành màu đỏ, lưu bản trình chiếu, mở lại và in màu nền thực tế:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Vì hình chữ nhật vẫn được liên kết tới `ACCENT4`, màu hiển thị của nó sẽ trở thành đỏ sau khi theme được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên shape, các thay đổi sau này của `accent4` sẽ không còn ảnh hưởng đến màu nền đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo ra các biến thể nhẹ hơn và tối hơn từ một màu theme bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này qua liệt kê [ColorTransformOperation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/colortransformoperation/).

![Màu theme chính và các màu nhẹ hơn, tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu theme chính.  
**2** - Các biến thể nhẹ hơn và tối hơn được tạo từ màu theme chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `ACCENT4`, áp dụng các biến đổi độ sáng cho năm hình, và lưu kết quả:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Các biến thể này vẫn dựa trên màu theme. Nếu `accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `accent4` mới.

### **Ánh xạ các giá trị `SchemeColor` tới các vị trí `ColorScheme`**

Liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/) sử dụng `TEXT1`, `BACKGROUND1`, `TEXT2` và `BACKGROUND2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) mở ra các vị trí theme tương ứng là `dark1`, `light1`, `dark2` và `light2`. Ánh xạ cố định:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Đây là các tên thay thế cho cùng một vị trí theme; chúng không phải là giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ Theme**

Một scheme phông chữ theme chứa bộ phông chính cho tiêu đề và bộ phông phụ cho nội dung. Các thuộc tính [FontScheme.major](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/major/) và [FontScheme.minor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/minor/) đưa ra các bộ này.

Các định danh phông chữ theme tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ thân văn bản Latin (Phông chữ Latin phụ)
* `+mj-lt` - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* `+mn-ea` - Phông chữ thân văn bản Đông Á (Phông chữ Đông Á phụ)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Ví dụ sau tạo một tiêu đề sử dụng phông Latin chính và một dòng nội dung sử dụng phông Latin phụ. Sau đó thay đổi các phông chữ theme và lưu kết quả:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Tiêu đề tuân theo phông chính và nội dung tuân theo phông phụ. Văn bản có tên phông chữ rõ ràng thay vì định danh theme sẽ không tự động chuyển khi scheme phông chữ theme thay đổi.

Các bộ phông chính và phụ cũng có thể chứa ánh xạ phông cho các hệ thống viết riêng lẻ, như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem mục [Script-Specific Theme Fonts](/slides/vi/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [Phông chữ PowerPoint](/slides/vi/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng Theme**

Có hai quy trình làm việc phổ biến, và chúng giải quyết các vấn đề khác nhau.

### **Bảo toàn Theme nguồn khi di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và bảo toàn thiết kế gốc, sao chép master nguồn vào bản đích bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/), rồi sao chép slide bằng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) và master đã sao chép. Điều này mang theo master, các layout và theme liên quan.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Đây là quy trình ưu tiên khi slide nguồn cần trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên theme.

### **Áp dụng giá trị Theme cho Slide hiện có**

Nếu slide đích phải giữ nguyên master và layout hiện tại, khởi tạo một ghi đè ở mức slide từ theme nguồn. Các phương thức [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), và [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) sao chép ba thành phần chính của theme vào ghi đè.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Điều này thay đổi theme được slide này sử dụng mà không ảnh hưởng đến theme được các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng ghi đè Theme cho Layout**

Ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/layoutslidethememanager/):

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Sử dụng theme ở mức master hoặc bản trình chiếu khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, ghi đè layout khi một nhóm layout cần kiểu dáng khác, và ghi đè slide chỉ cho những ngoại lệ thực sự. Quá nhiều ghi đè ở mức slide khiến các thay đổi theme toàn cục sau này khó dự đoán.

## **Cập nhật kiểu nền Theme**

Các màu nền của theme được lưu trong [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn so với số định nghĩa màu nền thực tế trong bộ sưu tập này vì UI có thể kết hợp màu nền theme với màu theme và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho theme bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và thuộc tính [Background.style_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/style_index/). `style_index` dùng `0` cho không có màu nền theme; các giá trị dương là tham chiếu kiểu nền theme. Điều này khác với việc đánh chỉ mục một bộ sưu tập Python trực tiếp, nơi `[0]` nghĩa là mục đầu tiên được lưu. Không nên giả định mọi bản trình chiếu có cùng số lượng style nền.

Ví dụ dưới đây báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền theme cho master đầu tiên, và lưu bản trình chiếu:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả hiển thị phụ thuộc vào mục theme mà master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng tới slide đó. Sử dụng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) khi bạn cần biết nền cuối cùng sau khi kế thừa đã được áp dụng.

{{% alert color="warning" title="Warning" %}}
Không coi `style_index` như một chỉ mục bộ sưu tập dựa trên chỉ số 0. Cũng tránh mã cứng một số style từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa style theme là riêng cho từng bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem mục [Presentation Background](/slides/vi/python-net/presentation-background/).
{{% /alert %}}

## **Cập nhật hiệu ứng Theme**

Một scheme định dạng theme chứa các bộ sưu tập riêng biệt [FormatScheme.fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/line_styles/), và [FormatScheme.effect_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/effect_styles/). Các theme Office điển hình thường chứa ba mục style chính tương ứng với định dạng nhẹ, vừa và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng Theme nhẹ, vừa và mạnh được áp dụng lên cùng một hình](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Python, chỉ mục bộ sưu tập bắt đầu từ 0: `[0]` là style đầu tiên được lưu và `[2]` là style thứ ba. Các chỉ mục tham chiếu style của shape là một khái niệm riêng, được mở ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapestyle/). Việc sửa đổi một style theme ảnh hưởng tới các shape tham chiếu style đó; các shape có định dạng trực tiếp có thể không thay đổi.

Ví dụ dưới đây kiểm tra sự tồn tại của các mục style yêu cầu, thay đổi style đường viền đầu tiên, thay đổi style màu nền thứ ba, bật bóng ngoài trong style hiệu ứng thứ ba, và lưu kết quả:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Đối với các shape tham chiếu các vị trí này, style đường viền theme đầu tiên sẽ trở thành đỏ, style màu nền theme thứ ba sẽ trở thành màu xanh rừng đặc, và style hiệu ứng thứ ba sẽ có bóng ngoài với khoảng cách 10 điểm. Kết quả hình ảnh vẫn phụ thuộc vào mỗi shape tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè theme hay không.

![Kiểu hiệu ứng Theme sau khi thay đổi cài đặt đường viền, màu nền và bóng](presentation-design_11.png)

## **Đọc giá trị Theme thực tế**

Các đối tượng theme thô cho bạn biết những gì được định nghĩa ở mức cụ thể. Các giá trị thực tế cho bạn biết slide hoặc shape thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Đối với nền, sử dụng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/), và đối với màu nền, sử dụng [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/).

Ví dụ dưới đây đọc theme thực tế, nền và màu nền shape đầu tiên từ một slide:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Sử dụng dữ liệu thực tế cho việc chẩn đoán, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/), có thể bỏ lỡ một master, layout, slide hoặc ghi đè shape thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Có thể áp dụng theme cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/slidethememanager/) của slide và khởi tạo theme ghi đè của nó. Thay đổi sẽ chỉ áp dụng cho slide đó; các slide khác vẫn kế thừa theme hiện có.

**Cách an toàn nhất để chuyển theme từ bản trình chiếu này sang bản khác là gì?**

Khi di chuyển một slide và bảo toàn thiết kế nguồn, sao chép master nguồn vào bản đích và sao chép slide với master đó bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/) và [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/). Điều này giữ lại master, các layout và theme cùng nhau.

**Làm sao để xem các giá trị thực tế sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) cho theme của slide hoặc layout và các phương thức dữ liệu thực tế tương ứng cho các đối tượng định dạng như [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) và [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/). Các API này trả về các giá trị đã được giải quyết sau khi kế thừa và ghi đè được áp dụng.