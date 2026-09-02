---
title: Quản lý các chủ đề bản trình chiếu PowerPoint trong Python
linktitle: Chủ đề Bản trình chiếu
type: docs
weight: 10
url: /vi/python-net/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề bản trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- chủ đề bên ngoài
- THMX
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong Aspose.Slides cho Python qua .NET để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bài thuyết trình định nghĩa một bộ phối hợp các màu sắc, phông chữ, kiểu nền, màu nền, đường kẻ và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu đến các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề ở mức trình bày có thể truy cập qua thuộc tính [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/). Một trình bày cũng có thể chứa các ghi đè chủ đề ở các mức thấp hơn. Một master có thể ghi đè chủ đề trình bày thông qua [MasterThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/masterthememanager/override_theme/), một layout có thể ghi đè chủ đề được kế thừa thông qua [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), và một slide riêng lẻ cũng có thể làm điều tương tự. Thực tế, chủ đề thực tế cho một slide được giải quyết thông qua chuỗi kế thừa này: chủ đề trình bày, ghi đè master, ghi đè layout và ghi đè slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Các phần bên dưới trình bày các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/) cung cấp các thuộc tính [color_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/font_scheme/), và [format_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/format_scheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một trình bày đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, màu nền, đường kẻ và hiệu ứng được lưu trữ trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, không nên giả định rằng mỗi slide đều có cùng một chủ đề thực tế. Kiểm tra master liên quan đến slide, và sử dụng quy trình làm việc với chủ đề thực tế được mô tả sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi màu Chủ đề**

Các màu, đường kẻ và văn bản nhận thức chủ đề có thể tham chiếu đến một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) của chủ đề, tất cả các đối tượng vẫn tham chiếu màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ cuối‑cùng sau tạo một hình dạng sử dụng `ACCENT4`, thay đổi màu `accent4` của chủ đề thành màu đỏ, lưu trình bày, mở lại và in màu nền thực tế:

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

Vì hình chữ nhật vẫn được liên kết với `ACCENT4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `accent4` sẽ không còn ảnh hưởng đến màu nền đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này qua enum [ColorTransformOperation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Các màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo ra từ các màu chủ đề chính.

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

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `accent4` mới.

### **Ánh xạ giá trị `SchemeColor` tới các vị trí `ColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/) sử dụng `TEXT1`, `BACKGROUND1`, `TEXT2` và `BACKGROUND2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `dark1`, `light1`, `dark2` và `light2`. Ánh xạ này cố định:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ Chủ đề**

Một scheme phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các thuộc tính [FontScheme.major](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/major/) và [FontScheme.minor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/minor/) công khai các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ thân văn bản Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ thân văn bản Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ chủ đề và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động thay đổi khi scheme phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa ánh xạ phông chữ cho các hệ thống viết riêng lẻ, như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong trình bày, xem [PowerPoint Fonts](/slides/vi/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình làm việc dưới đây giải quyết các vấn đề khác nhau liên quan đến chủ đề.

### **Áp dụng Chủ đề bên ngoài cho các Slide phụ thuộc vào Master**

Sử dụng [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.masters](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/masters/) (thực thi [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/)) và truyền đường dẫn tệp chủ đề cho phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề bên ngoài cho master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/) mới được tạo.

Ví dụ sau áp dụng một chủ đề bên ngoài cho các slide phụ thuộc vào master đầu tiên và lưu trình bày:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxexception/) hoặc một trong các lớp con liên quan tới định dạng. Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và chỉ lưu trình bày sau khi chủ đề đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác vẫn giữ master và chủ đề hiện tại. Các màu, phông chữ, màu nền, đường kẻ và hiệu ứng nhận thức chủ đề sẽ được giải quyết dựa trên chủ đề bên ngoài. Các màu, phông chữ, màu nền và các định dạng tường minh khác có thể vẫn không thay đổi. Các ghi đè ở mức layout và slide cũng có thể có ưu tiên hơn các giá trị được kế thừa từ master mới.

Chủ đề có thể tham chiếu đến các phông chữ không có sẵn trong môi trường chạy. Để đảm bảo việc hiển thị và xuất ra nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/python-net/custom-font/), hoặc cấu hình [font substitution](/slides/vi/python-net/font-substitution/).

Đây là quy trình làm việc trực tiếp ở mức master: phương thức nhận đường dẫn tới tệp `.thmx` và không yêu cầu tạo ghi đè chủ đề ở mức slide hay layout một cách thủ công.

### **Áp dụng Các Chủ đề Bên ngoài Khác nhau trong Một Trình Bày Đa‑Master**

Khi master liên quan không được biết trước, hãy lấy nó từ một slide đại diện thông qua [Slide.layout_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/layout_slide/) và [LayoutSlide.master_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/master_slide/). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong trình bày.

Ví dụ sau sử dụng slide từ hai phần để xác định master của chúng và áp dụng một chủ đề bên ngoài khác nhau cho mỗi nhóm:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Lời gọi đầu tiên chỉ ảnh hưởng đến các slide phụ thuộc vào `first_group_master`, và lời gọi thứ hai chỉ ảnh hưởng đến các slide phụ thuộc vào `second_group_master`. Các slide thuộc bất kỳ master nào khác sẽ không được thay đổi kiểu dáng.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slide**

Nếu bạn muốn di chuyển một slide sang một trình bày khác và giữ nguyên thiết kế gốc, hãy sao chép master nguồn vào trình bày đích bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/), sau đó sao chép slide bằng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) và master đã sao chép. Điều này sẽ mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình được khuyến nghị khi slide nguồn phải trông giống hệt trong đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Một Slide Đã Tồn tại**

Nếu slide đích phải giữ master và layout hiện tại, hãy khởi tạo một ghi đè ở mức slide từ chủ đề nguồn. Các phương thức [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) và [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) sao chép ba thành phần chủ đề chính vào ghi đè.

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

Thao tác này thay đổi chủ đề mà slide đó sử dụng mà không ảnh hưởng đến chủ đề mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay trở lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng Ghi đè Chủ đề cho Một Layout**

Ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/layoutslidethememanager/) của layout:

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

Sử dụng chủ đề ở mức master hoặc trình bày khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ sở, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và sử dụng ghi đè slide chỉ cho những ngoại lệ thực sự. Quá nhiều ghi đè ở mức slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các màu nền của chủ đề được lưu trong [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì UI có thể kết hợp màu nền chủ đề với các màu chủ đề và các tham chiếu kiểu khác.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và thuộc tính [Background.style_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/style_index/) hiện tại. `style_index` dùng `0` để biểu thị không có màu nền có chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc chỉ mục một bộ sưu tập Python trực tiếp, trong đó `[0]` nghĩa là mục đầu tiên được lưu. Đừng giả định rằng mỗi trình bày chứa cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền có chủ đề cho master đầu tiên, và lưu trình bày:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề được master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide có nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng đến slide đó. Sử dụng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) khi bạn cần biết nền cuối cùng sau khi kế thừa đã được áp dụng.

{{% alert color="warning" title="Warning" %}}
Đừng xử lý `style_index` như một chỉ mục bộ sưu tập dựa trên số 0. Cũng tránh mã hóa cứng một số kiểu từ một tệp và giả định nó sẽ có cùng diện mạo trong tệp khác; các định nghĩa kiểu chủ đề là riêng biệt cho từng trình bày.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/python-net/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một scheme định dạng chủ đề chứa các bộ sưu tập riêng biệt [FormatScheme.fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/line_styles/) và [FormatScheme.effect_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/effect_styles/). Các chủ đề Office thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Python, chỉ mục bộ sưu tập là dựa trên 0: `[0]` là kiểu đầu tiên được lưu và `[2]` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của một hình dạng là một khái niệm riêng, được lộ ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapestyle/). Thay đổi một kiểu chủ đề sẽ ảnh hưởng đến các hình dạng tham chiếu kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường kẻ đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường kẻ chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu màu nền chủ đề thứ ba sẽ trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có một bóng đổ ngoài với khoảng cách 10 điểm. Kết quả trực quan cuối cùng vẫn phụ thuộc vào vị trí kiểu mà mỗi hình dạng tham chiếu và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Đọc Giá trị Chủ đề Thực tế**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở mức cụ thể. Giá trị thực tế cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Đối với nền, dùng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/), và đối với màu nền, dùng [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/).

Ví dụ sau đọc chủ đề thực tế, nền và màu nền của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu thực tế cho việc chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/), bạn có thể bỏ lỡ một ghi đè ở mức master, layout, slide hoặc hình dạng làm thay đổi ngoại hình cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề bên ngoài có ảnh hưởng đến mọi slide trong trình bày không?**

Không. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) chỉ gán lại những slide phụ thuộc vào master đã chọn. Các slide dùng các master khác vẫn giữ nguyên chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/slidethememanager/) của slide và khởi tạo ghi đè chủ đề. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác tiếp tục kế thừa chủ đề hiện tại.

**Cách an toàn nhất để chuyển một chủ đề từ một trình bày sang trình bày khác là gì?**

Khi di chuyển slide và muốn giữ nguyên giao diện nguồn, sao chép master nguồn vào đích bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/) và sao chép slide với master đã sao chép bằng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/). Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị thực tế sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) cho một slide hoặc layout và các phương thức dữ liệu thực tế tương ứng cho các đối tượng định dạng như [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) và [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/). Các API này trả về các giá trị đã được giải quyết sau khi kế thừa và ghi đè được áp dụng.