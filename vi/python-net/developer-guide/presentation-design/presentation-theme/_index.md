---
title: Quản lý giao diện bản trình bày PowerPoint trong Python
linktitle: Giao diện Bản trình bày
type: docs
weight: 10
url: /vi/python-net/presentation-theme/
keywords:
- giao diện PowerPoint
- giao diện bản trình bày
- giao diện slide
- cài đặt giao diện
- thay đổi giao diện
- quản lý giao diện
- màu giao diện
- bảng màu bổ sung
- phông chữ giao diện
- kiểu giao diện
- hiệu ứng giao diện
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý giao diện bản trình bày trong Aspose.Slides cho Python thông qua .NET để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một giao diện bài thuyết trình xác định một tập hợp phối hợp các màu sắc, phông chữ, kiểu nền, màu nền, đường và hiệu ứng. Các đối tượng nhận thức giao diện tham chiếu tới các định nghĩa chia sẻ này thay vì lưu trữ mỗi thuộc tính hiển thị dưới dạng giá trị cố định, do đó việc thay đổi giao diện có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, giao diện ở mức trình bày có sẵn thông qua thuộc tính [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/) . Một bản trình bày cũng có thể chứa các ghi đè giao diện ở các mức thấp hơn. Một master có thể ghi đè giao diện trình bày qua [MasterThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/masterthememanager/override_theme/), một layout có thể ghi đè giao diện kế thừa của nó qua [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), và một slide riêng lẻ cũng có thể làm tương tự. Trên thực tế, giao diện hiệu quả cho một slide được xác định qua chuỗi kế thừa này: giao diện trình bày, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của giao diện: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình giao diện phổ biến nhất: kiểm tra một giao diện, thay đổi màu sắc và phông chữ, sao chép hoặc áp dụng một giao diện, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra giao diện**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/) hiển thị các thuộc tính [color_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/font_scheme/) và [format_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/format_scheme/) của giao diện. Việc kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình bày đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể thay đổi.

Ví dụ sau đọc các thuộc tính chính của giao diện và báo cáo có bao nhiêu kiểu nền, màu nền, đường và hiệu ứng được lưu trong giao diện:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng giao diện hiệu quả. Kiểm tra master liên quan tới slide, và sử dụng quy trình làm việc giao diện hiệu quả được trình bày sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi màu sắc giao diện**

Các màu nền, đường và văn bản nhận thức giao diện có thể tham chiếu tới một màu logic từ danh sách [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) của giao diện, tất cả các đối tượng vẫn tham chiếu tới màu giao diện đó sẽ được áp dụng giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu giao diện.

Ví dụ end-to-end sau tạo một hình dạng sử dụng `ACCENT4`, thay đổi màu `accent4` của giao diện thành màu đỏ, lưu bản trình bày, mở lại và in màu nền hiệu quả:

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

Vì hình chữ nhật vẫn được liên kết với `ACCENT4`, màu hiển thị của nó sẽ trở thành đỏ sau khi giao diện được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `accent4` sẽ không còn ảnh hưởng tới màu nền đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu giao diện bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này thông qua danh sách [ColorTransformOperation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/colortransformoperation/) .

![Các màu giao diện chính và các màu sáng/tối được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** – Các màu giao diện chính.  
**2** – Các biến thể sáng hơn và tối hơn được tạo từ các màu giao diện chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `ACCENT4`, áp dụng các biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu giao diện. Nếu `accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `accent4` mới.

### **Ánh xạ giá trị `SchemeColor` tới các ô `ColorScheme`**

Danh sách [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/) sử dụng `TEXT1`, `BACKGROUND1`, `TEXT2` và `BACKGROUND2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) cung cấp cùng các ô giao diện dưới dạng `dark1`, `light1`, `dark2` và `light2`. Ánh xạ này cố định:

* `TEXT1` = `dark1`  
* `BACKGROUND1` = `light1`  
* `TEXT2` = `dark2`  
* `BACKGROUND2` = `light2`

Đây là các tên thay thế cho cùng các ô giao diện; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ giao diện**

Một bộ phông chữ giao diện chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các thuộc tính [FontScheme.major](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/major/) và [FontScheme.minor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/minor/) hiển thị các bộ này.

Các định danh phông chữ giao diện tương thích với PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` – Phông chữ nội dung Latin (Minor Latin Font)  
* `+mj-lt` – Phông chữ tiêu đề Latin (Major Latin Font)  
* `+mn-ea` – Phông chữ nội dung Đông Á (Minor East Asian Font)  
* `+mj-ea` – Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi các phông chữ giao diện và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và văn bản nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ rõ ràng thay vì định danh giao diện sẽ không tự động chuyển khi bộ phông chữ giao diện thay đổi.

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình bày, xem [PowerPoint Fonts](/slides/vi/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc áp dụng một giao diện**

Có hai quy trình thường gặp, và chúng giải quyết các vấn đề khác nhau.

### **Bảo tồn giao diện nguồn khi di chuyển slide**

Nếu muốn di chuyển một slide sang bản trình bày khác và giữ nguyên thiết kế gốc, sao chép master nguồn vào bản trình bày đích bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/), sau đó sao chép slide bằng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) và master đã sao chép. Điều này mang theo master, các layout và giao diện liên quan.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên giao diện.

### **Áp dụng giá trị giao diện cho một slide hiện có**

Nếu slide đích phải ở trên master và layout hiện tại, khởi tạo một ghi đè cấp slide từ giao diện nguồn. Các phương thức [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), và [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) sao chép ba thành phần chính của giao diện vào ghi đè.

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

Điều này thay đổi giao diện được slide đó sử dụng mà không làm thay đổi giao diện kế thừa bởi các slide khác. Để xóa ghi đè cục bộ và trở lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/clear/) .

### **Áp dụng ghi đè giao diện cho một layout**

Ghi đè cấp layout áp dụng cho các slide dùng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/layoutslidethememanager/) của layout:

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

Sử dụng giao diện cấp master hoặc trình bày khi nhiều layout và slide nên chia sẻ cùng một thiết kế nền, ghi đè layout khi một nhóm layout cần kiểu dáng khác nhau, và ghi đè slide chỉ cho các trường hợp ngoại lệ thực sự. Việc lạm dụng ghi đè cấp slide khiến các thay đổi giao diện toàn cục sau này khó dự đoán.

## **Cập nhật kiểu nền giao diện**

Các màu nền của giao diện được lưu trong [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì UI có thể kết hợp màu nền giao diện với màu giao diện và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một giao diện trình bày](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và thuộc tính [Background.style_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/style_index/) hiện tại. `style_index` dùng `0` cho không có màu nền giao diện; các giá trị dương là tham chiếu tới kiểu nền giao diện. Điều này khác với việc đánh chỉ mục một bộ sưu tập Python trực tiếp, nơi `[0]` nghĩa là mục đầu tiên được lưu. Đừng giả định rằng mọi bản trình bày đều có cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền giao diện cho master đầu tiên, và lưu bản trình bày:

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

Kết quả hiển thị phụ thuộc vào mục giao diện được master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide có nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng đến slide đó. Sử dụng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng coi `style_index` là một chỉ mục bộ sưu tập bắt đầu từ 0. Cũng tránh mã cứng một số kiểu từ một tệp và giả định nó sẽ có cùng ngoại hình trong tệp khác; các định nghĩa kiểu giao diện là đặc thù cho mỗi bản trình bày.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/python-net/presentation-background/) .
{{% /alert %}}

## **Cập nhật hiệu ứng giao diện**

Một bộ format giao diện chứa các bộ sưu tập riêng biệt [FormatScheme.fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/line_styles/), và [FormatScheme.effect_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/effect_styles/) . Các giao diện Office điển hình thường có ba mục kiểu chính tương ứng với định dạng tinh tế, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng giao diện tinh tế, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Python, chỉ mục bộ sưu tập bắt đầu từ 0: `[0]` là kiểu đầu tiên được lưu và `[2]` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở rộng thông qua [IShapeStyle](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapestyle/). Việc sửa đổi một kiểu giao diện ảnh hưởng tới các hình dạng tham chiếu tới kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu bắt buộc, thay đổi kiểu đường đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các ô này, kiểu đường đầu tiên của giao diện sẽ trở thành màu đỏ, kiểu màu nền thứ ba sẽ thành xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào mỗi hình dạng tham chiếu ô nào và liệu định dạng trực tiếp có ghi đè giao diện hay không.

![Các kiểu hiệu ứng giao diện sau khi thay đổi đường, màu nền và cài đặt bóng đổ](presentation-design_11.png)

## **Đọc các giá trị giao diện hiệu quả**

Các đối tượng giao diện thô cho bạn biết những gì được định nghĩa ở mức cụ thể. Các giá trị hiệu quả cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Đối với nền, sử dụng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/), và đối với màu nền, sử dụng [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/) .

Ví dụ sau đọc giao diện hiệu quả, nền và màu nền của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu quả để chẩn đoán hiển thị, xác thực và so sánh. Nếu chỉ kiểm tra [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/), bạn có thể bỏ qua một master, layout, slide hoặc ghi đè hình dạng thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một giao diện cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/slidethememanager/) của slide và khởi tạo ghi đè giao diện của nó. Thay đổi sẽ chỉ giới hạn ở slide đó; các slide khác vẫn kế thừa giao diện hiện tại.

**Cách an toàn nhất để chuyển giao diện từ bản trình bày này sang bản trình bày khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên giao diện nguồn, sao chép master nguồn vào bản đích và sao chép slide với master đó bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/) và [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) . Điều này giữ nguyên master, các layout và giao diện cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) cho một slide hoặc giao diện layout và các phương thức dữ liệu hiệu quả tương ứng cho các đối tượng định dạng như [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) và [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/) . Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.