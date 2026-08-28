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
- đặt theme
- thay đổi theme
- quản lý theme
- theme bên ngoài
- THMX
- màu theme
- bảng màu bổ sung
- phông theme
- kiểu theme
- hiệu ứng theme
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các theme bản trình chiếu trong Aspose.Slides cho Python thông qua .NET để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một theme bản thuyết trình định nghĩa một bộ màu, phông chữ, kiểu nền, màu nền, đường viền và hiệu ứng được phối hợp. Các đối tượng nhận thức theme tham chiếu đến các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi theme có thể cập nhật đồng thời nhiều đối tượng.

Trong Aspose.Slides, theme ở cấp độ bản thuyết trình có thể truy cập qua thuộc tính [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/). Một bản thuyết trình cũng có thể chứa các ghi đè theme ở các cấp độ thấp hơn. Một master có thể ghi đè theme bản thuyết trình bằng [MasterThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/masterthememanager/override_theme/), một layout có thể ghi đè theme kế thừa của nó bằng [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), và một slide riêng lẻ cũng có thể làm tương tự. Thực tế, theme hiệu quả cho một slide được xác định qua chuỗi kế thừa này: theme bản thuyết trình, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của theme: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần phía dưới trình bày các quy trình làm việc với theme thường gặp nhất: kiểm tra theme, thay đổi màu và phông chữ, sao chép hoặc áp dụng theme, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Theme**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/) cung cấp các thuộc tính [color_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/font_scheme/) và [format_scheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/mastertheme/format_scheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản thuyết trình đến từ nguồn bên ngoài vì số lượng và nội dung của các mục style có thể khác nhau.

Ví dụ dưới đây đọc các thuộc tính theme chính và báo cáo số lượng style nền, fill, line và effect được lưu trong theme:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một theme hiệu quả. Kiểm tra master liên kết với slide, và sử dụng quy trình làm việc theme‑hiệu‑quả được mô tả sau trong bài viết khi có thể có các ghi đè layout hoặc slide.

## **Thay đổi Màu Theme**

Các fill, line và văn bản nhận thức theme có thể tham chiếu đến một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) của theme, mọi đối tượng vẫn tham chiếu tới màu theme đó sẽ được giải quyết lại dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi việc cập nhật màu theme.

Ví dụ toàn diện dưới đây tạo một shape sử dụng `ACCENT4`, thay đổi màu `accent4` của theme thành màu đỏ, lưu bản thuyết trình, mở lại và in màu fill hiệu quả:

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

Vì hình chữ nhật vẫn liên kết với `ACCENT4`, màu hiển thị của nó sẽ trở thành đỏ sau khi theme được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên shape, các thay đổi sau này đối với `accent4` sẽ không còn ảnh hưởng đến fill đó.

### **Sử dụng màu từ Bảng màu Bổ sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu theme bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/colortransformoperation/).

![Màu theme chính và các màu sáng hơn, tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu theme chính.  
**2** - Các biến thể sáng hơn và tối hơn được tạo từ màu theme chính.

Ví dụ dưới đây tạo sáu hình chữ nhật dựa trên `ACCENT4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu theme. Nếu `accent4` thay đổi sau này, các màu đã được biến đổi sẽ được tính lại dựa trên giá trị `accent4` mới.

### **Ánh xạ giá trị `SchemeColor` tới các khe `ColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/) sử dụng `TEXT1`, `BACKGROUND1`, `TEXT2` và `BACKGROUND2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/colorscheme/) cung cấp cùng các khe theme dưới dạng `dark1`, `light1`, `dark2` và `light2`. Ánh xạ này cố định:

* `TEXT1` = `dark1`  
* `BACKGROUND1` = `light1`  
* `TEXT2` = `dark2`  
* `BACKGROUND2` = `light2`

Đây là các tên thay thế cho cùng một khe theme; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Theme**

Một scheme phông chữ theme chứa một tập phông chữ chính cho tiêu đề và một tập phụ cho nội dung. Các thuộc tính [FontScheme.major](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/major/) và [FontScheme.minor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/fontscheme/minor/) cung cấp các tập này.

Các định danh phông chữ theme tương thích PowerPoint có thể được sử dụng trong việc định dạng văn bản:

* `+mn‑lt` - Phông chữ thân văn bản Latin (Minor Latin Font)  
* `+mj‑lt` - Phông chữ tiêu đề Latin (Major Latin Font)  
* `+mn‑ea` - Phông chữ thân văn bản Đông Á (Minor East Asian Font)  
* `+mj‑ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ dưới đây tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ theme và lưu kết quả:

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

Tiêu đề sẽ theo phông chữ chính và nội dung sẽ theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh theme sẽ không tự động thay đổi khi scheme phông chữ theme thay đổi.

Các bộ sưu tập phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, hãy xem [Script‑Specific Theme Fonts](/slides/vi/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Để biết thêm thông tin về phông chữ trong bản thuyết trình, xem [PowerPoint Fonts](/slides/vi/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Sao chép hoặc Áp dụng một Theme**

Các quy trình dưới đây giải quyết các vấn đề liên quan đến theme khác nhau.

### **Áp dụng Theme bên ngoài cho các Slide phụ thuộc vào Master**

Sử dụng [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) khi bạn có một tệp theme PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.masters](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/masters/), bộ sưu tập này thực thi [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/), và truyền đường dẫn tệp theme vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.  
1. Áp dụng theme bên ngoài cho master mới.  
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.  
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/) mới tạo.

Ví dụ dưới đây áp dụng theme bên ngoài cho các slide phụ thuộc vào master đầu tiên và lưu bản thuyết trình:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Một theme không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxexception/) hoặc một trong các lớp con liên quan tới định dạng. Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tập tin, và chỉ lưu bản thuyết trình sau khi theme đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác vẫn giữ nguyên master và theme hiện có. Các màu, phông chữ, fill, line, nền và hiệu ứng nhận thức theme sẽ được giải quyết dựa trên theme bên ngoài. Các định dạng trực tiếp (màu, phông, fill…) có thể vẫn không đổi. Các ghi đè ở cấp layout và slide cũng có thể ưu tiên so với các giá trị kế thừa từ master mới.

Theme có thể tham chiếu tới các phông chữ không có trong môi trường runtime. Để đảm bảo việc render và xuất ra nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/python-net/custom-font/), hoặc cấu hình [font substitution](/slides/vi/python-net/font-substitution/).

Đây là quy trình làm việc trực tiếp ở cấp master: phương thức nhận một đường dẫn tới tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè theme ở cấp slide hay layout.

### **Áp dụng các Theme Bên ngoài Khác nhau trong Bản Thuyết Trình Nhiều Master**

Khi master liên quan chưa được xác định từ trước, hãy lấy nó từ một slide đại diện qua [Slide.layout_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/layout_slide/) và [LayoutSlide.master_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/master_slide/). Lưu lại các tham chiếu master gốc trước khi áp dụng bất kỳ theme nào vì mỗi lần gọi sẽ tạo thêm một master mới trong bản thuyết trình.

Ví dụ dưới đây sử dụng slide từ hai phần để xác định master của chúng và áp dụng một theme bên ngoài khác nhau cho mỗi nhóm:

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

Lần gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `first_group_master`, và lần gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `second_group_master`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu.

### **Bảo lưu Theme Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản thuyết trình khác và giữ nguyên thiết kế gốc, hãy sao chép master nguồn vào bản thuyết trình đích bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/), sau đó sao chép slide bằng [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/) và master đã sao chép. Việc này sẽ mang theo master, các layout và theme liên quan.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung vào một master đích không liên quan có thể thay đổi màu, phông, nền và hiệu ứng dựa trên theme.

### **Áp dụng Giá trị Theme cho Slide Đã Tồn tại**

Nếu slide đích phải ở lại master và layout hiện tại, hãy khởi tạo một ghi đè cấp slide từ theme nguồn. Các phương thức [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) và [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) sao chép ba thành phần chính của theme vào ghi đè.

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

Điều này thay đổi theme được dùng bởi slide đó mà không thay đổi theme mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng Ghi đè Theme cho Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được dùng thông qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/layoutslidethememanager/) của layout:

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

Hãy dùng theme cấp master hoặc bản thuyết trình khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, dùng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và dùng ghi đè slide chỉ cho những ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ khiến các thay đổi theme toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Theme**

Các màu nền của theme được lưu trong [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint có thể hiển thị nhiều tùy chọn nền hơn so với số lượng định nghĩa fill thực tế trong bộ sưu tập này vì giao diện người dùng có thể kết hợp các fill theme với màu theme và các tham chiếu style khác.

![Bộ sưu tập kiểu nền PowerPoint cho một theme bản thuyết trình](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và thuộc tính [Background.style_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/style_index/) hiện tại. `style_index` dùng giá trị `0` cho không có fill theme; các giá trị dương là tham chiếu tới kiểu nền của theme. Điều này khác với việc đánh chỉ mục một bộ sưu tập Python trực tiếp, nơi `[0]` nghĩa là mục đầu tiên. Đừng giả định mọi bản thuyết trình đều chứa cùng số lượng style nền.

Ví dụ dưới đây báo cáo số lượng fill nền có sẵn, gán một tham chiếu nền theme cho master đầu tiên và lưu bản thuyết trình:

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

Kết quả hiển thị phụ thuộc vào mục theme mà master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide có nền riêng, việc chỉ thay đổi nền của master có thể không ảnh hưởng tới slide đó. Hãy dùng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}

Đừng coi `style_index` như một chỉ mục bộ sưu tập bắt đầu từ 0. Cũng tránh việc hard‑code một số style từ một tệp và giả định nó sẽ có cùng giao diện trong tệp khác; các định nghĩa style theme là riêng cho mỗi bản thuyết trình.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Đối với việc định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/python-net/presentation-background/).

{{% /alert %}}

## **Cập nhật Hiệu Ứng Theme**

Một scheme định dạng theme chứa các bộ sưu tập riêng biệt [FormatScheme.fill_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/line_styles/) và [FormatScheme.effect_styles](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/formatscheme/effect_styles/). Các theme Office thường có ba mục style chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng theme nhẹ, trung bình và mạnh được áp dụng cho cùng một shape](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Python, chỉ mục bộ sưu tập bắt đầu từ 0: `[0]` là style đầu tiên, `[2]` là style thứ ba. Các chỉ mục tham chiếu style của shape là một khái niệm riêng, được mở ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapestyle/). Việc thay đổi một style theme sẽ ảnh hưởng tới các shape tham chiếu style đó; các shape có định dạng trực tiếp có thể không thay đổi.

Ví dụ dưới đây kiểm tra sự tồn tại của các mục style cần thiết, thay đổi style line đầu tiên, thay đổi style fill thứ ba, bật bóng đổ ngoài trong style effect thứ ba và lưu kết quả:

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

Đối với các shape tham chiếu các khe này, style line theme đầu tiên sẽ trở thành màu đỏ, style fill theme thứ ba sẽ thành màu xanh rừng đặc, và style effect thứ ba sẽ thêm một bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào các shape tham chiếu các khe nào và liệu định dạng trực tiếp có ghi đè theme hay không.

![Các style hiệu ứng theme sau khi thay đổi line, fill và thiết lập shadow](presentation-design_11.png)

## **Xác định Liệu Fill Rắn Đặc Hiệu Quả có Sử dụng Màu Theme hay Không**

Một fill có thể được lưu trực tiếp trên đối tượng hoặc kế thừa từ đoạn văn, layout, master, style theme hoặc cấp định dạng khác. Gọi [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/) để giải quyết chuỗi kế thừa này thành một đối tượng bất biến [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifillformateffectivedata/). Đầu tiên, kiểm tra [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Chỉ khi giá trị là `FillType.SOLID` mới đọc các thuộc tính fill rắn.

Đối với fill rắn, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) trả về giá trị RGB cuối cùng sau khi đã áp dụng kế thừa, tra cứu theme và các biến đổi màu. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) trả về khe logic [SchemeColor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/schemecolor/) tương ứng, chẳng hạn `TEXT1` hoặc `ACCENT6`. Giá trị `SchemeColor.NOT_DEFINED` có nghĩa là fill rắn không dựa trên màu scheme. Trong một quy trình mà fill chỉ có thể là màu theme hoặc màu RGB trực tiếp, giá trị này xác định một fill RGB trực tiếp.

Đừng chỉ dựa vào giá trị địa phương [IColorFormat.scheme_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/icolorformat/scheme_color/) để phân loại một fill. Ví dụ, một phần văn bản có thể không có màu scheme được định nghĩa cục bộ, do đó giá trị địa phương là `NOT_DEFINED`, trong khi fill hiệu quả lại kế thừa một màu theme và giải quyết thành `TEXT1` hoặc `ACCENT6`. Ngược lại, `solid_fill_scheme_color` cho bạn biết khe theme nào tạo nên màu hiệu quả, nhưng không cho biết khe này đến từ đối tượng, đoạn văn, layout, master hay cấp định dạng nào.

Ví dụ dưới đây tải một bản thuyết trình, kiểm tra cả fill của shape và fill của đoạn văn bản, in ra mỗi giá trị RGB cuối cùng và scheme color tương ứng, và đánh dấu các fill rắn sẽ không theo dõi thay đổi màu theme:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

Nhánh `NOT_DEFINED` cung cấp danh sách audit các fill rắn sẽ không phản hồi với các thay đổi trong các khe màu theme. Kiểm tra những đối tượng này khi bản thuyết trình phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo cáo vẫn hiển thị giao diện hiện tại, trong khi giá trị scheme giải thích liệu giao diện đó có gắn liền với theme hay không.

Các đối tượng format‑hiệu‑quả là ảnh chụp nhanh. Sau khi thay đổi theme bản thuyết trình, một ghi đè theme, hoặc bất kỳ định dạng kế thừa nào, hãy gọi lại `get_effective` và đọc một đối tượng `IFillFormatEffectiveData` mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá Trị Theme Hiệu Quả**

Các đối tượng theme thô cho bạn biết những gì được định nghĩa ở một cấp độ cụ thể. Các giá trị hiệu quả cho bạn biết slide hoặc shape thực tế sử dụng gì sau khi kế thừa và ghi đè đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Đối với nền, dùng [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/), và đối với fill, dùng [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/).

Ví dụ dưới đây đọc theme hiệu quả, nền, và fill của shape đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu quả để chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.master_theme](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/master_theme/), bạn có thể bỏ qua một master, layout, slide hoặc shape có ghi đè làm thay đổi giao diện cuối cùng.

## **FAQ**

**Áp dụng theme bên ngoài có ảnh hưởng tới mọi slide trong bản thuyết trình không?**

Không. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác vẫn giữ theme hiện có.

**Tôi có thể áp dụng một theme cho một slide đơn lẻ mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/slidethememanager/) của slide và khởi tạo ghi đè theme cho nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa theme hiện có.

**Cách an toàn nhất để chuyển theme từ bản thuyết trình này sang bản thuyết trình khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên giao diện nguồn, sao chép master nguồn vào bản thuyết trình đích và sao chép slide với master đó bằng [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/masterslidecollection/add_clone/) và [SlideCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_clone/). Điều này giữ lại master, các layout và theme cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) cho một slide hoặc layout theme và các phương thức dữ liệu‑hiệu‑quả tương ứng cho các đối tượng định dạng như [Background.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/background/get_effective/) và [FillFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fillformat/get_effective/). Các API này trả về các giá trị đã được giải quyết sau khi đã áp dụng kế thừa và ghi đè.