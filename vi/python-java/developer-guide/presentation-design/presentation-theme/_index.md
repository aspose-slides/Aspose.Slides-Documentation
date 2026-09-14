---
title: Quản lý Chủ đề Bản trình chiếu trong Python qua Java
linktitle: Chủ đề Bản trình chiếu
type: docs
weight: 10
url: /vi/python-java/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề trình chiếu
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
- Java
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong Aspose.Slides cho Python qua Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu thống nhất."
---
## **Giới thiệu**

Một chủ đề trình chiếu định nghĩa một tập hợp phối hợp các màu, phông chữ, kiểu nền, màu nền, đường và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu tới các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, chủ đề ở mức trình chiếu có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasterTheme). Một bản trình chiếu cũng có thể chứa các ghi đè chủ đề ở các mức thấp hơn. Một master có thể ghi đè chủ đề trình chiếu qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterthememanager/#getOverrideTheme), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề kế thừa của nó qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme). Thực tế, chủ đề hiệu lực cho một slide được xác định thông qua chuỗi kế thừa này: chủ đề trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây cho thấy các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mastertheme/) cung cấp lược đồ màu, lược đồ phông chữ và lược đồ định dạng của chủ đề thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mastertheme/#getFontScheme) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/mastertheme/#getFormatScheme). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, màu nền, đường và hiệu ứng được lưu trong chủ đề:

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

Nếu tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng chủ đề hiệu lực. Kiểm tra master liên kết với slide, và dùng quy trình làm việc chủ đề hiệu lực được mô tả sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các màu nền, đường và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/colorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ end-to-end sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản trình chiếu, mở lại và in ra màu nền hiệu lực:

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

Vì hình chữ nhật vẫn liên kết tới `Accent4`, màu hiển thị của nó trở thành màu đỏ sau khi thay đổi chủ đề. Nếu bạn thay thế màu lược đồ bằng một màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới màu nền đó.

### **Sử dụng Màu từ Bảng màu Bổ sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này qua enum [ColorTransformOperation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu sáng hơn, tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.  
**2** - Các biến thể sáng hơn và tối hơn được tạo từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị 'SchemeColor' tới Các vị trí 'ColorScheme'**

Enum [SchemeColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/colorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bản đồ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một lược đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontscheme/#getMajor) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontscheme/#getMinor) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ thân văn bản Latin (Phông chữ Latin phụ)
* `+mj-lt` - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* `+mn-ea` - Phông chữ thân văn bản Đông Á (Phông chữ Đông Á phụ)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính của chủ đề và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ chủ đề và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và văn bản thân tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi lược đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa ánh xạ phông chữ cho các hệ thống viết riêng, chẳng hạn Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/python-java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình dưới đây giải quyết các vấn đề liên quan đến chủ đề khác nhau.

### **Áp dụng Chủ đề Ngoài vào Các Slide Phụ Thuộc vào Master**

Sử dụng [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasters), được biểu diễn bởi [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/), và truyền đường dẫn tệp chủ đề cho phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề ngoài vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về [MasterSlide] mới được tạo.

Ví dụ sau áp dụng một chủ đề ngoài vào các slide phụ thuộc vào master đầu tiên và lưu bản trình chiếu:

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

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxreadexception/). Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và lưu bản trình chiếu chỉ sau khi chủ đề đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác vẫn giữ master và chủ đề hiện tại. Các màu, phông chữ, màu nền, đường và hiệu ứng nhận thức chủ đề được giải quyết dựa trên chủ đề ngoài. Các màu, phông chữ, màu nền và các định dạng rõ ràng được gán trực tiếp có thể không thay đổi. Các ghi đè ở mức layout và slide cũng có thể ưu tiên hơn các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu tới các phông chữ không có sẵn trong môi trường chạy. Để đảm bảo hiển thị và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/python-java/custom-font/), hoặc cấu hình [font substitution](/slides/vi/python-java/font-substitution/).

Đây là một quy trình làm việc ở mức master trực tiếp: phương thức nhận một đường dẫn tệp `.thmx` và không yêu cầu tạo tay các ghi đè chủ đề ở mức slide hoặc layout.

### **Áp dụng Các Chủ đề Ngoài Khác Nhau trong Bản Trình Chiếu Nhiều Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getLayoutSlide) và [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getMasterSlide). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong bản trình chiếu.

Ví dụ sau sử dụng các slide từ hai phần để xác định master của chúng và áp dụng một chủ đề ngoài khác nhau cho mỗi nhóm:

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

Lệnh gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `first_group_master`, và lệnh gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `second_group_master`. Các slide thuộc bất kỳ master nào khác sẽ không được thay đổi kiểu.

### **Bảo lưu Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và giữ nguyên thiết kế gốc, sao chép master nguồn vào bản đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/#addClone), sau đó sao chép slide bằng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể thay đổi các màu, phông chữ, nền và hiệu ứng được điều khiển bởi chủ đề.

### **Áp dụng Giá trị Chủ đề vào Slide hiện có**

Nếu slide đích phải giữ master và layout hiện tại, khởi tạo một ghi đè ở mức slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) sao chép ba thành phần chủ đề chính vào ghi đè.

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

Điều này thay đổi chủ đề được slide sử dụng mà không thay đổi chủ đề được các slide khác kế thừa. Để loại bỏ ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/overridetheme/#clear).

### **Áp dụng Ghi đè Chủ đề vào Layout**

Một ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslidethememanager/):

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

Sử dụng chủ đề ở mức master hoặc trình chiếu khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ sở, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và chỉ ghi đè slide cho các ngoại lệ thực sự. Quá nhiều ghi đè ở mức slide làm cho việc thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các màu nền của chủ đề được lưu trong [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số định nghĩa màu nền vật lý được lưu trong bộ sưu tập này vì giao diện có thể kết hợp màu nền chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/background/#getStyleIndex) hiện tại. Chỉ số kiểu `0` có nghĩa là không có màu nền chủ đề; các giá trị dương là tham chiếu kiểu nền chủ đề. Điều này khác với việc lấy chỉ mục bộ sưu tập trực tiếp, trong đó `get_Item(0)` chỉ mục mục đầu tiên được lưu. Đừng giả định rằng mọi bản trình chiếu đều có cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu bản trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề được master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không thay đổi slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/background/#getEffective) khi bạn cần biết nền cuối cùng sau khi áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Không nên coi chỉ số kiểu là chỉ số bộ sưu tập bắt đầu từ 0. Ngoài ra, tránh mã hoá cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là đặc thù của từng bản trình chiếu.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
Đối với việc định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/python-java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một lược đồ định dạng chủ đề chứa các bộ sưu tập màu nền, đường và hiệu ứng riêng biệt được mở ra qua [FormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/python-java/aspose.slides/formatscheme/#getLineStyles) và [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/python-java/aspose.slides/formatscheme/#getEffectStyles). Các chủ đề Office điển hình thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng code nên kiểm tra từng bộ sưu tập thay vì giả định một số lượng cố định.

![Hiệu ứng chủ đề nhẹ, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi bạn truy cập các bộ sưu tập này trong Python qua Java, chỉ mục bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu được lưu đầu tiên và `get_Item(2)` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình là một khái niệm riêng, được mở ra qua [ShapeStyle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapestyle/). Việc sửa đổi một kiểu chủ đề ảnh hưởng tới các hình tham chiếu kiểu đó; các hình có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu yêu cầu, thay đổi kiểu đường đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ ngoại vi trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình tham chiếu các vị trí này, kiểu đường chủ đề đầu tiên trở thành màu đỏ, kiểu màu nền thứ ba trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba nhận bóng đổ ngoại vi với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào vị trí kiểu mỗi hình tham chiếu và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường, màu nền và thiết lập bóng đổ](presentation-design_11.png)

## **Xác định liệu một Đổ Đặc hiệu lực có sử dụng Màu Chủ đề hay không**

Một màu đổ có thể được lưu trực tiếp trên một đối tượng hoặc được kế thừa từ đoạn văn, layout, master, kiểu chủ đề hoặc một mức định dạng khác. Gọi [FillFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getEffective) để giải quyết chuỗi phân cấp này thành dữ liệu đổ hiệu lực không thay đổi. Đầu tiên kiểm tra `getFillType` trên đối tượng dữ liệu hiệu lực. Chỉ khi nó là `FillType.Solid` bạn mới nên đọc các thuộc tính đổ đặc.

Đối với một đổ đặc, `getSolidFillColor` trả về giá trị RGB cuối cùng sau khi áp dụng kế thừa, tra cứu chủ đề và biến đổi màu. `getSolidFillSchemeColor` trả về vị trí logical [SchemeColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor.NotDefined` nghĩa là đổ đặc hiệu lực không dựa trên màu lược đồ. Trong một quy trình mà các đổ chỉ là màu chủ đề hoặc màu RGB trực tiếp, giá trị này xác định một đổ RGB trực tiếp.

Không nên chỉ dùng giá trị địa phương của [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/colorformat/#getSchemeColor) để phân loại một đổ. Ví dụ, một đoạn văn bản có thể không có màu lược đồ định nghĩa cục bộ, vì vậy giá trị cục bộ là `NotDefined`, trong khi đổ hiệu lực của nó kế thừa một màu chủ đề và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho bạn biết vị trí logical chủ đề nào tạo ra màu hiệu lực, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay mức định dạng nào.

Ví dụ sau tải một bản trình chiếu, kiểm tra cả các đổ hình dạng và đổ đoạn văn bản, in mỗi giá trị RGB cuối cùng và màu lược đồ liên quan, và đánh dấu các đổ đặc sẽ không theo dõi các thay đổi màu chủ đề:

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

Nhánh `NotDefined` cung cấp danh sách kiểm tra các đổ đặc sẽ không phản hồi khi thay đổi các vị trí màu chủ đề. Xem lại các đối tượng này khi bản trình chiếu phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo vẫn hiển thị ngoại hình hiện tại, trong khi giá trị lược đồ giải thích liệu ngoại hình đó có liên kết đến chủ đề hay không.

Các đối tượng định dạng hiệu lực là ảnh chụp nhanh. Sau khi thay đổi chủ đề bản trình chiếu, một ghi đè chủ đề, hoặc bất kỳ định dạng kế thừa nào, gọi lại `getEffective` và đọc một đối tượng dữ liệu đổ hiệu lực mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Giá trị Chủ đề Hiệu lực**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở một mức cụ thể. Các giá trị hiệu lực cho bạn biết slide hoặc hình dạng thực tế sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/background/#getEffective), và đối với đổ, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getEffective).

Ví dụ sau đọc chủ đề hiệu lực, nền và đổ hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu lực cho việc chuẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getMasterTheme), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng thay đổi ngoại hình cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác vẫn giữ nguyên chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager] của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để mang một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

Khi di chuyển một slide và giữ nguyên ngoại hình nguồn, sao chép master nguồn vào bản đích và sao chép slide với master đó bằng [MasterSlideCollection.addClone] và [SlideCollection.addClone]. Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective] cho một slide hoặc layout và các phương thức dữ liệu hiệu lực tương ứng cho các đối tượng định dạng như [Background.getEffective] và [FillFormat.getEffective]. Các API này trả về các giá trị đã giải quyết sau khi áp dụng kế thừa và ghi đè.