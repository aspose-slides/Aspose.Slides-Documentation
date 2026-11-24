---
title: Quản lý Theme Bản Trình Chiếu trong Python qua Java
linktitle: Theme Bản Trình Chiếu
type: docs
weight: 10
url: /vi/python-java/presentation-theme/
keywords:
- theme PowerPoint
- theme bản trình chiếu
- theme slide
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
- Java
- Aspose.Slides
description: "Quản lý theme bản trình chiếu trong Aspose.Slides cho Python qua Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản trình chiếu (presentation theme) xác định một tập hợp phối hợp gồm các màu sắc, phông chữ, kiểu nền, tô màu, đường nét và hiệu ứng. Các đối tượng nhận thức theme tham chiếu đến các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi theme có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, theme ở mức bản trình chiếu có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme). Một bản trình chiếu cũng có thể chứa các ghi đè theme ở mức thấp hơn. Một master có thể ghi đè theme của bản trình chiếu qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè theme được kế thừa qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). Thực tế, theme hiệu quả cho một slide được giải quyết qua chuỗi kế thừa này: theme của bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với theme phổ biến nhất: kiểm tra một theme, đổi màu và phông chữ, sao chép hoặc áp dụng một theme, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Theme**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) cung cấp các sơ đồ màu, phông chữ và định dạng của theme qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme). Kiểm tra những bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chính của theme và báo cáo số lượng kiểu nền, tô, đường nét và hiệu ứng được lưu trong theme:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()

    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

Nếu tệp sử dụng nhiều master, đừng cho rằng mọi slide đều có cùng theme hiệu quả. Kiểm tra master liên kết với slide, và sử dụng quy trình theme‑hiệu‑quả được mô tả sau trong bài viết khi có thể có ghi đè ở layout hoặc slide.

## **Thay đổi Màu Theme**

Các tô, đường và văn bản nhận thức theme có thể tham chiếu đến một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu theme đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu theme.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, đổi màu `Accent4` của theme thành màu đỏ, lưu bản trình chiếu, mở lại và in ra màu tô hiệu quả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)

    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ chuyển sang đỏ sau khi theme được đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới tô đó.

### **Sử dụng Màu từ Bảng Màu Bổ Sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu theme bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Các màu theme chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo ra từ các màu theme chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các biến thể này vẫn dựa trên màu theme. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các Khe `ColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) cung cấp cùng các khe theme dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các khe theme; chúng không phải là giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Theme**

Một sơ đồ phông chữ theme chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) và [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) cung cấp các bộ này.

Các định danh phông chữ theme tương thích PowerPoint có thể được dùng trong định dạng văn bản:

* `+mn-lt` - Phông chữ Body Latin (Phông chữ Latin phụ)
* `+mj-lt` - Phông chữ Heading Latin (Phông chữ Latin chính)
* `+mn-ea` - Phông chữ Body East Asian (Phông chữ East Asian phụ)
* `+mj-ea` - Phông chữ Heading East Asian (Phông chữ East Asian chính)
* `+mn-cs` - Phông chữ Body Complex Script (Phông chữ Complex Script phụ)
* `+mj-cs` - Phông chữ Heading Complex Script (Phông chữ Complex Script chính)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó đổi các phông chữ theme và lưu kết quả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ rõ ràng thay vì định danh theme sẽ không tự động chuyển khi sơ đồ phông chữ theme thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}

Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/python-java/powerpoint-fonts/).

{{% /alert %}}

### **Giải quyết Tham chiếu Phông chữ Theme**

Khi kiểm tra văn bản, [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) có thể trả về một tham chiếu theme như `+mn-lt` thay vì tên họ phông chữ. Gọi [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) với dữ liệu theme hiệu quả phù hợp để giải quyết tham chiếu đó. Các tiền tố `+mj` và `+mn` chọn bộ phông chữ chính và phụ; các hậu tố `-lt`, `-ea` và `-cs` chọn các phông chữ Latin, East Asian và Complex Script tương ứng.

Lấy theme hiệu quả qua [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) trên trình quản lý theme của đối tượng mà theme áp dụng cho văn bản được kiểm tra. Đối với văn bản thông thường trên một slide, sử dụng trình quản lý theme của slide để ngữ cảnh bao gồm theme kế thừa của slide và các ghi đè địa phương. Khi kiểm tra một layout hoặc master, sử dụng theme hiệu quả của chính nó. Đừng cho rằng theme của master đầu tiên áp dụng cho mọi slide.

Ví dụ sau tạo một đoạn văn bản tham chiếu rõ ràng tới phông chữ Latin phụ. Nó khởi tạo sơ đồ phông chữ slide qua [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) và đặt họ phông chữ Latin chính và phụ thành `Arial` và `Calibri`, giúp kết quả có thể tái tạo mà không cần tệp đầu vào.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

Kết quả là `+mn-lt -> Calibri` tiếp theo là `Verdana -> Verdana`. Tham chiếu đã lưu vẫn không thay đổi, trong khi một họ phông chữ rõ ràng được trả về nguyên trạng. Nếu đoạn văn bản dùng `+mj-lt`, nó sẽ giải quyết thành `Arial` trong theme này.

Giải quyết một tham chiếu theme xác định họ phông chữ do theme chỉ định. Nó không kiểm tra khả năng có sẵn của phông chữ hay xác định tệp phông chữ thực tế được dùng sau khi thay thế hoặc fallback glyph trong quá trình render. Xem [Font Selection Sequence](/slides/vi/python-java/font-selection-sequence/) và [Font Substitution](/slides/vi/python-java/font-substitution/) để biết các bước riêng biệt này.

## **Sao chép hoặc Áp dụng một Theme**

Các quy trình dưới đây giải quyết các vấn đề liên quan đến theme khác nhau.

### **Áp dụng Theme Ngoài vào Các Slide Phụ Thuộc Master**

Sử dụng [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) khi bạn có tệp theme PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters), đại diện bởi [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/), và truyền đường dẫn tệp theme vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng theme ngoài vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) mới được tạo.

Ví dụ sau áp dụng theme ngoài vào các slide phụ thuộc vào master đầu tiên và lưu bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")
    print("Created master:", themed_master.getName())

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Một theme không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/). Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý lỗi truy cập hệ thống tệp, và chỉ lưu bản trình chiếu sau khi theme đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với master khác giữ nguyên master và theme hiện tại. Các màu, phông chữ, tô, đường, nền và hiệu ứng nhận thức theme sẽ được giải quyết dựa trên theme ngoài. Các định dạng màu, phông chữ, tô và các định dạng rõ ràng khác có thể không thay đổi. Các ghi đè ở mức layout và slide cũng có thể có ưu tiên hơn các giá trị kế thừa từ master mới.

Theme có thể tham chiếu đến các phông chữ không có trong môi trường runtime. Để đảm bảo render và xuất đồng nhất, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/python-java/custom-font/), hoặc cấu hình [font substitution](/slides/vi/python-java/font-substitution/).

Đây là quy trình cấp độ master trực tiếp: phương thức nhận một đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè theme ở mức slide hoặc layout.

### **Áp dụng Các Theme Ngoài Khác Nhau trong Bản Trình Chiếu Đa‑Master**

Khi master liên quan chưa được biết trước, lấy nó từ một slide đại diện qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) và [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide). Lưu lại các tham chiếu master gốc trước khi áp dụng bất kỳ theme nào vì mỗi lần gọi sẽ tạo thêm một master mới trong bản trình chiếu.

Ví dụ sau sử dụng slide từ hai phần để xác định master và áp dụng một theme ngoài khác nhau cho mỗi nhóm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lần gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `first_group_master`, còn lần gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `second_group_master`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu.

### **Bảo tồn Theme Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và giữ nguyên thiết kế gốc, hãy sao chép master nguồn vào bản trình chiếu đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone), sau đó sao chép slide bằng [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) và master đã sao chép. Điều này mang master, các layout và theme liên quan cùng nhau.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)

        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung vào một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên theme.

### **Áp dụng Giá trị Theme cho Slide hiện có**

Nếu slide đích phải ở lại master và layout hiện tại, khởi tạo một ghi đè cấp slide từ theme nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) sao chép ba thành phần chính của theme vào ghi đè.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Điều này thay đổi theme được slide sử dụng mà không thay đổi theme mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear).

### **Áp dụng Ghi đè Theme cho Layout**

Một ghi đè cấp layout áp dụng cho các slide dùng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

Sử dụng theme cấp master hoặc bản trình chiếu khi nhiều layout và slide cần chia sẻ cùng một thiết kế nền, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và chỉ dùng ghi đè slide cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi theme toàn cục sau này khó dự đoán.

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Một ghi đè layout áp dụng cho các slide sử dụng layout đó trừ khi một slide có ghi đè riêng hơn. Các giá trị dựa trên theme tuân theo sơ đồ đã giải quyết; các đối tượng được định dạng rõ ràng có thể giữ ngoại hình cục bộ của chúng. Giữ ghi đè hẹp đúng mức ngoại lệ thiết kế dự định.*
<!-- visual-explanation:presentation-theme:end -->

## **Cập nhật Kiểu Nền Theme**

Các tô nền của theme được lưu trong [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn so với số lượng định nghĩa tô thực tế trong bộ sưu tập này vì giao diện người dùng có thể kết hợp các tô theme với màu theme và các tham chiếu kiểu khác.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex) hiện tại. Một chỉ mục kiểu `0` có nghĩa là không có tô theme; các giá trị dương là các tham chiếu kiểu nền theme. Điều này khác với việc chỉ mục trực tiếp bộ sưu tập, trong đó `get_Item(0)` là mục đầu tiên được lưu. Đừng cho rằng mọi bản trình chiếu đều chứa cùng số lượng kiểu tô nền.

Ví dụ sau báo cáo số lượng tô nền khả dụng, gán một tham chiếu nền theme cho master đầu tiên, và lưu bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)

        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả hiển thị phụ thuộc vào mục theme mà master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, chỉ thay đổi nền master có thể không ảnh hưởng tới slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) khi bạn cần biết nền cuối cùng sau khi kế thừa đã được áp dụng.

{{% alert color="warning" title="Warning" %}}

Đừng xem chỉ mục kiểu như một chỉ mục bộ sưu tập dựa trên chỉ số 0. Cũng tránh việc hard‑code một số kiểu từ một tệp và cho rằng nó sẽ có cùng diện mạo trong tệp khác; các định nghĩa kiểu theme là đặc thù cho từng bản trình chiếu.

{{% /alert %}}

{{% alert color="success" title="Tip" %}}

Đối với việc định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/python-java/presentation-background/).

{{% /alert %}}

## **Cập nhật Hiệu Ứng Theme**

Một sơ đồ định dạng theme chứa các bộ sưu tập riêng biệt cho tô, đường và hiệu ứng được mở ra qua [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) và [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles). Các theme Office thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, vừa và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định một số lượng cố định.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Python qua Java, chỉ mục bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/). Thay đổi một style theme ảnh hưởng tới các hình dạng tham chiếu style đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục style cần thiết, thay đổi style đường thứ nhất, thay đổi style tô thứ ba, bật bóng đổ ngoài trong style hiệu ứng thứ ba, và lưu kết quả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)

        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đối với các hình dạng tham chiếu các khe này, style đường theme đầu tiên sẽ chuyển sang màu đỏ, style tô theme thứ ba sẽ thành màu xanh rừng đặc, và style hiệu ứng thứ ba sẽ có bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào mỗi hình dạng tham chiếu khe nào và liệu định dạng trực tiếp có ghi đè theme hay không.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Chọn Kiểu Tô và Đường cho Một Shape**

Một shape có thể chọn tô và viền một cách độc lập qua [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) và [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex). Đối với cả hai phương thức, chỉ mục `1` chọn mục đầu tiên trong bộ sưu tập theme tương ứng (`get_Item(0)`), và chỉ mục `2` chọn mục thứ hai (`get_Item(1)`).

Ví dụ sau thiết lập hai kiểu tô (vàng và xanh da trời) và hai kiểu đường (xanh đậm 6 pt và đỏ đậm 12 pt) trong theme mặc định của một bản trình chiếu mới. Nó lưu slide ở ba giai đoạn để bạn có thể so sánh kết quả trong PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Kiểu ban đầu | Thay đổi viền bên phải | Chỉnh sửa lớp tô theme đầu tiên |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Chọn một kiểu đường khác chỉ thay đổi viền của hình chữ nhật bên phải. Chỉnh sửa lớp tô theme đầu tiên cập nhật mọi shape sử dụng nó. Ở đây, chỉ hình chữ nhật bên trái chuyển sang màu xanh lá.

Trên một shape đã tồn tại, màu tô cục bộ, màu đường hoặc độ dày đường có thể ghi đè phần đó của style theme. Nếu việc thay đổi chỉ mục style không có hiệu ứng trực quan, hãy kiểm tra [direct formatting](/slides/vi/python-java/shape-formatting/).

## **Xác định Liệu Một Fill Rắn Hiệu Quả Có Sử Dụng Màu Theme Hay Không**

Một fill có thể được lưu trực tiếp trên đối tượng hoặc kế thừa từ đoạn văn, layout, master, style theme hoặc một mức định dạng khác. Gọi [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) để giải quyết chuỗi phân cấp này thành dữ liệu fill hiệu quả bất biến. Đầu tiên kiểm tra `getFillType` trên đối tượng dữ liệu hiệu quả. Chỉ khi nó là `FillType.Solid` mới đọc các thuộc tính fill rắn.

Đối với một fill rắn, `getSolidFillColor` trả về giá trị RGB cuối cùng sau khi kế thừa, tra cứu theme và áp dụng các biến đổi màu. `getSolidFillSchemeColor` trả về khe logic [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor.NotDefined` có nghĩa là fill rắn hiệu quả không dựa trên màu scheme. Trong một quy trình mà các fill chỉ là màu theme hoặc màu RGB trực tiếp, giá trị này xác định một fill RGB trực tiếp.

Đừng chỉ dựa vào giá trị địa phương [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) để phân loại một fill. Ví dụ, một đoạn văn bản có thể không có màu scheme được định nghĩa cục bộ, vì vậy giá trị địa phương là `NotDefined`, trong khi fill hiệu quả của nó kế thừa một màu theme và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho biết khe theme logic đã tạo ra màu hiệu quả, nhưng không cho biết khe đó đến từ đối tượng, đoạn văn, layout, master hay mức định dạng nào.

Ví dụ sau tải một bản trình chiếu, kiểm tra cả fill của shape và fill của đoạn văn bản, in ra mỗi giá trị RGB cuối cùng và scheme color liên quan, và đánh dấu các fill rắn sẽ không theo dõi thay đổi màu theme:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

Nhánh `NotDefined` cung cấp danh sách audit các fill rắn sẽ không phản hồi với các thay đổi trong các khe màu theme. Xem xét các đối tượng này khi bản trình chiếu phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo vẫn hiển thị ngoại hình hiện tại, trong khi giá trị scheme giải thích liệu ngoại hình đó có được kết nối với theme hay không.

Các đối tượng định dạng‑hiệu‑quả là ảnh chụp. Sau khi thay đổi theme bản trình chiếu, một ghi đè theme hoặc bất kỳ định dạng kế thừa nào, gọi lại `getEffective` và đọc đối tượng dữ liệu fill hiệu quả mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá Trị Theme Hiệu Quả**

Các đối tượng theme thô cho bạn biết những gì được định nghĩa ở mức nhất định. Các giá trị hiệu quả cho bạn biết slide hoặc shape thực sự sử dụng gì sau khi kế thừa và ghi đè địa phương được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Đối với nền, dùng [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective), và đối với fill, dùng [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective).

Ví dụ sau đọc theme hiệu quả, nền và fill của shape đầu tiên từ một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

Sử dụng dữ liệu hiệu quả cho chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme), bạn có thể bỏ lỡ một master, layout, slide hoặc shape có ghi đè thay đổi ngoại hình cuối cùng.

## **Câu Hỏi Thường Gặp**

**Áp dụng theme ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide dùng các master khác giữ theme hiện có.

**Tôi có thể áp dụng một theme cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) của slide và khởi tạo theme ghi đè của nó. Thay đổi sẽ chỉ tồn tại cục bộ trên slide đó; các slide khác vẫn kế thừa theme hiện tại.

**Cách an toàn nhất để mang theme từ một bản trình chiếu sang bản khác là gì?**

Khi di chuyển một slide và giữ nguyên ngoại hình nguồn, sao chép master nguồn vào đích và sao chép slide với master đó bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) và [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone). Điều này giữ nguyên master, layout và theme cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) cho một slide hoặc layout theme và các phương thức dữ liệu‑hiệu‑quả tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) và [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective). Các API này trả về các giá trị đã giải quyết sau khi kế thừa và ghi đè được áp dụng.