---
title: Quản lý Chủ đề Bản trình chiếu trong .NET
linktitle: Chủ đề Bản trình chiếu
type: docs
weight: 10
url: /vi/net/presentation-theme/
keywords:
- Chủ đề PowerPoint
- Chủ đề bản trình chiếu
- Chủ đề slide
- Thiết lập chủ đề
- Thay đổi chủ đề
- Quản lý chủ đề
- Chủ đề bên ngoài
- THMX
- Màu chủ đề
- Bảng màu bổ sung
- Phông chữ chủ đề
- Kiểu chủ đề
- Hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Kiểm soát các chủ đề bản trình chiếu trong Aspose.Slides cho .NET để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu thống nhất."
---
## **Giới thiệu**

Một chủ đề bản trình chiếu xác định một tập hợp phối hợp các màu sắc, phông chữ, kiểu nền, màu nền, đường nét và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu các định nghĩa chia sẻ này thay vì lưu trữ mỗi thuộc tính hình ảnh dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, chủ đề cấp trình bày có sẵn thông qua thuộc tính [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/). Một bản trình chiếu cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề trình bày thông qua [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/masterthememanager/overridetheme/), một layout có thể ghi đè chủ đề kế thừa của nó thông qua [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), và một slide riêng lẻ cũng có thể làm tương tự. Trong thực tế, chủ đề hiệu quả cho một slide được giải quyết qua chuỗi kế thừa này: chủ đề trình bày, ghi đè master, ghi đè layout và ghi đè slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi đã giải quyết kế thừa và ghi đè.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/) cung cấp truy cập tới [ColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/fontscheme/) và [FormatScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/formatscheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể thay đổi.

Ví dụ dưới đây đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, màu nền, đường nét và hiệu ứng được lưu trong chủ đề:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một chủ đề hiệu quả. Kiểm tra master liên kết với slide và sử dụng quy trình làm việc chủ đề‑hiệu quả được mô tả sau trong bài viết khi có khả năng có các ghi đè layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các màu đầy, đường nét và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/icolorscheme/) của chủ đề, tất cả các đối tượng vẫn tham chiếu màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện dưới đây tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản trình chiếu, mở lại và in màu đầy hiệu quả:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Vì hình chữ nhật vẫn được liên kết tới `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu scheme bằng một màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới màu đầy đó nữa.

### **Sử dụng Màu từ Bảng Màu Bổ Sung**

PowerPoint tạo ra các biến thể nhẹ hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua [ColorTransformOperation](https://reference.aspose.com/slides/vi/net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Các màu chủ đề chính.  
**2** - Các biến thể nhẹ hơn và tối hơn được tạo ra từ các màu chủ đề chính.

Ví dụ dưới đây tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng và lưu kết quả:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại dựa trên giá trị `Accent4` mới.

### **Ánh Xạ Giá Trị `SchemeColor` tới Các Vị Trí `IColorScheme`**

Liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/icolorscheme/) khai báo cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ này cố định:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng kia.

## **Thay đổi Phông chữ Chủ đề**

Một scheme phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các thuộc tính [FontScheme.Major](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/major/) và [FontScheme.Minor](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/minor/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được dùng trong định dạng văn bản:

* `+mn-lt` - Phông chữ Thân văn Latin (Minor Latin Font)  
* `+mj-lt` - Phông chữ Tiêu đề Latin (Major Latin Font)  
* `+mn-ea` - Phông chữ Thân văn Đông Á (Minor East Asian Font)  
* `+mj-ea` - Phông chữ Tiêu đề Đông Á (Major East Asian Font)

Ví dụ dưới đây tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ chủ đề và lưu kết quả:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi scheme phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa ánh xạ phông cho các hệ thống viết riêng lẻ, chẳng hạn Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/net/script-specific-font-mappings/).

{{% alert color="info" title="Mẹo" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/net/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng Một Chủ đề**

Các quy trình dưới đây giải quyết các vấn đề khác nhau liên quan đến chủ đề.

### **Áp dụng Chủ đề Bên ngoài cho Các Slide Phụ Thuộc của Master**

Sử dụng [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) khi bạn có tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.Masters](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/masters/) (thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/)) và truyền đường dẫn tệp chủ đề cho phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.  
1. Áp dụng chủ đề bên ngoài cho master mới.  
1. Gán master mới cho tất cả slide trước đây phụ thuộc vào master đã chọn.  
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/) mới tạo.

Ví dụ dưới đây áp dụng một chủ đề bên ngoài cho các slide phụ thuộc vào master thứ nhất, lưu bản trình chiếu và mở lại kết quả:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxexception/) hoặc một trong các lớp con liên quan đến định dạng. Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp và chỉ lưu bản trình chiếu sau khi chủ đề đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và chủ đề hiện tại. Các màu, phông chữ, màu nền, đường nét và hiệu ứng nhận thức chủ đề sẽ được giải quyết dựa trên chủ đề bên ngoài. Các định dạng màu, phông chữ, màu nền và các thuộc tính định dạng rõ ràng khác có thể không thay đổi. Các ghi đè ở cấp layout và slide cũng có thể ưu tiên so với các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu tới các phông chữ không có trong môi trường runtime. Để hiển thị và xuất nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [nguồn phông chữ tùy chỉnh](/slides/vi/net/custom-font/), hoặc cấu hình [thay thế phông chữ](/slides/vi/net/font-substitution/).

Đây là quy trình làm việc cấp master trực tiếp: phương thức chỉ nhận đường dẫn tới tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở cấp slide hay layout.

### **Áp dụng Các Chủ đề Bên ngoài Khác nhau trong Bản Trình chiếu Nhiều‑Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện qua [ISlide.LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/layoutslide/) và [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/masterslide/). Lưu lại các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong bản trình chiếu.

Ví dụ dưới đây sử dụng slide từ hai phần để xác định master của chúng và áp dụng một chủ đề bên ngoài khác nhau cho mỗi nhóm:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Lệnh gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, lệnh gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không được thay đổi kiểu dáng.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và giữ nguyên thiết kế gốc, hãy sao chép master nguồn vào bản trình chiếu đích bằng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/), sau đó sao chép slide bằng [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) và master đã sao chép. Điều này sẽ mang cả master, các layout và chủ đề liên quan cùng nhau.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Đây là quy trình làm việc được khuyến nghị khi slide nguồn cần hiển thị giống hệt trong bản đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide hiện có**

Nếu slide đích phải giữ master và layout hiện tại, hãy khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initfontschemefrom/) và [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initformatschemefrom/) sao chép ba thành phần chính của chủ đề vào ghi đè.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Điều này thay đổi chủ đề được slide sử dụng mà không ảnh hưởng tới chủ đề kế thừa của các slide khác. Để xóa ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được dùng thông qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/layoutslidethememanager/) của layout:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Hãy dùng một chủ đề cấp master hoặc presentation khi nhiều layout và slide cần chia sẻ cùng một thiết kế nền, dùng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và dùng ghi đè slide chỉ cho các ngoại lệ thực sự. Quá nhiều ghi đè slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các màu nền chủ đề được lưu trong [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì giao diện có thể kết hợp màu nền chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và thuộc tính [Background.StyleIndex](https://reference.aspose.com/slides/vi/net/aspose.slides/background/styleindex/) hiện tại. `StyleIndex` dùng giá trị `0` cho không có màu nền chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc chỉ mục bộ sưu tập .NET trực tiếp, trong đó `[0]` nghĩa là mục đầu tiên được lưu. Đừng giả định rằng mọi bản trình chiếu đều có cùng số lượng kiểu nền.

Ví dụ dưới đây báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên và lưu bản trình chiếu:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề được master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không làm thay đổi slide đó. Hãy dùng [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Cảnh báo" %}}
Đừng xem `StyleIndex` như một chỉ mục bộ sưu tập bắt đầu từ 0. Cũng tránh việc mã hóa cứng một số kiểu từ một tệp và giả định nó sẽ có cùng diện mạo trong tệp khác; các định nghĩa kiểu chủ đề là riêng cho mỗi bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Mẹo" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/net/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một scheme định dạng chủ đề chứa các bộ sưu tập riêng biệt [FillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/linestyles/) và [EffectStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/effectstyles/). Các chủ đề Office thường có ba mục kiểu chính tương ứng với kiểu nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong C#, chỉ mục bộ sưu tập bắt đầu từ 0: `[0]` là kiểu đầu tiên lưu và `[2]` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được biểu thị qua [IShapeStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapestyle/). Thay đổi một kiểu chủ đề sẽ ảnh hưởng tới các hình dạng tham chiếu kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ dưới đây kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường nét đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ bên ngoài trong kiểu hiệu ứng thứ ba và lưu kết quả:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường nét chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu màu nền chủ đề thứ ba sẽ trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có một bóng đổ bên ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào mỗi hình dạng tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè lên chủ đề hay không.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Xác định liệu Màu Đầy Đặc Ràng hiệu quả có sử dụng Màu Chủ đề hay không**

Màu đầy có thể được lưu trực tiếp trên đối tượng hoặc kế thừa từ đoạn văn, layout, master, kiểu chủ đề hoặc một cấp định dạng khác. Gọi [IFillFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformat/geteffective/) để giải quyết chuỗi này thành một đối tượng bất biến [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformateffectivedata/). Đầu tiên kiểm tra [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformateffectivedata/filltype/). Chỉ khi giá trị là `FillType.Solid` thì mới đọc các thuộc tính màu đầy đặc.

Đối với màu đầy đặc, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) trả về giá trị RGB cuối cùng sau khi đã áp dụng kế thừa, tra cứu chủ đề và các phép biến đổi màu. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) trả về vị trí logic [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor.NotDefined` có nghĩa là màu đầy đặc hiệu quả không dựa trên màu scheme. Trong quy trình làm việc mà màu đầy chỉ là màu chủ đề hoặc màu RGB trực tiếp, giá trị này xác định màu RGB trực tiếp.

Đừng chỉ dựa vào giá trị địa phương [IColorFormat.SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/icolorformat/schemecolor/) để phân loại màu đầy. Ví dụ, một đoạn văn bản có thể không có màu scheme được định nghĩa cục bộ, vì vậy giá trị địa phương là `NotDefined`, trong khi màu đầy hiệu quả kế thừa từ chủ đề và trả về `Text1` hoặc `Accent6`. Ngược lại, `SolidFillSchemeColor` cho biết vị trí logic nào của chủ đề đã tạo ra màu cuối cùng, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay cấp khác.

Ví dụ dưới đây tải một bản trình chiếu, kiểm tra cả màu đầy của hình dạng và của các đoạn văn bản, in mỗi giá trị RGB cuối cùng và scheme color liên quan, đồng thời đánh dấu các màu đầy đặc sẽ không theo dõi sự thay đổi màu chủ đề:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

Nhánh `NotDefined` cung cấp danh sách kiểm tra các màu đầy đặc sẽ không phản hồi khi thay đổi vị trí màu chủ đề. Hãy xem xét các đối tượng này khi bản trình chiếu phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo cáo vẫn hiển thị diện mạo hiện tại, trong khi giá trị scheme giải thích liệu diện mạo đó có liên kết với chủ đề hay không.

Các đối tượng định dạng hiệu quả là ảnh chụp nhanh. Sau khi thay đổi chủ đề bản trình chiếu, ghi đè chủ đề hoặc bất kỳ định dạng kế thừa nào, hãy gọi lại `GetEffective` và đọc một đối tượng `IFillFormatEffectiveData` mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá trị Chủ đề Hiệu quả**

Các đối tượng chủ đề thô cho bạn biết gì đã được định nghĩa ở một cấp nhất định. Các giá trị hiệu quả cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi đã giải quyết kế thừa và ghi đè cục bộ. Đối với một slide, gọi [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Đối với nền, dùng [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/), và đối với màu đầy, dùng [FillFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/geteffective/).

Ví dụ dưới đây đọc chủ đề hiệu quả, nền và màu đầy của hình dạng đầu tiên từ một slide:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Sử dụng dữ liệu hiệu quả cho chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/), bạn có thể bỏ qua các ghi đè của master, layout, slide hoặc hình dạng thay đổi diện mạo cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề bên ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng master khác giữ nguyên các chủ đề hiện có.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/slidethememanager/) của slide và khởi tạo ghi đè chủ đề cho nó. Thay đổi sẽ chỉ áp dụng cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để chuyển một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên diện mạo nguồn, sao chép master nguồn vào đích và sao chép slide cùng master đó bằng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/) và [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/). Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) cho một slide hoặc layout và các phương thức dữ liệu‑hiệu quả tương ứng cho các đối tượng định dạng như [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/) và [FillFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/geteffective/). Những API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.