---
title: Quản lý Chủ đề Bản trình chiếu trong .NET
linktitle: Chủ đề Bản trình chiếu
type: docs
weight: 10
url: /vi/net/presentation-theme/
keywords:
- Chủ đề PowerPoint
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
- .NET
- C#
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong Aspose.Slides cho .NET để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản trình chiếu định nghĩa một tập hợp phối hợp các màu, phông chữ, kiểu nền, màu nền, đường kẻ và hiệu ứng. Các đối tượng nhận thức về chủ đề tham chiếu các định nghĩa chung này thay vì lưu mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, chủ đề ở mức độ bản trình chiếu có sẵn qua thuộc tính [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/). Một bản trình chiếu cũng có thể chứa các ghi đè chủ đề ở các mức thấp hơn. Một master có thể ghi đè chủ đề bản trình chiếu thông qua [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/masterthememanager/overridetheme/), một layout có thể ghi đè chủ đề kế thừa thông qua [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), và một slide riêng lẻ cũng có thể làm tương tự. Trong thực tế, chủ đề thực tế cho một slide được giải quyết qua chuỗi kế thừa này: chủ đề bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Thành phần của chủ đề: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày những quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/) cung cấp [ColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/fontscheme/) và [FormatScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/formatscheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chính của chủ đề và báo cáo có bao nhiêu kiểu nền, màu nền, đường kẻ và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, không nên cho rằng mọi slide đều có cùng một chủ đề thực tế. Kiểm tra master liên quan đến slide, và sử dụng quy trình làm việc với chủ đề thực tế được mô tả sau trong bài khi có thể có ghi đè ở layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các màu nền, đường kẻ và văn bản nhận thức về chủ đề có thể tham chiếu một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/icolorscheme/) của chủ đề, tất cả các đối tượng vẫn tham chiếu màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản trình chiếu, mở lại và in màu nền thực tế:

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

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành màu đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu lược đồ bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới màu nền đó.

### **Sử dụng Màu từ Bảng màu Bổ sung**

PowerPoint tạo ra các biến thể nhạt hơn và đậm hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các biến đổi này qua [ColorTransformOperation](https://reference.aspose.com/slides/vi/net/aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu nhạt hơn, đậm hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.

**2** - Các biến thể nhạt hơn và đậm hơn được tạo từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm hình và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các vị trí `IColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/icolorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ này cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ một dạng sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một lược đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các thuộc tính [FontScheme.Major](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/major/) và [FontScheme.Minor](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/minor/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ Thân văn bản Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ Tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ Thân văn bản Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ Tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi các phông chữ chủ đề và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi lược đồ phông chữ chủ đề thay đổi.

Bộ sưu tập phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/net/script-specific-font-mappings/).

{{% alert color="info" title="Mẹo" %}}

Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/net/powerpoint-fonts/).

{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình làm việc dưới đây giải quyết các vấn đề liên quan đến chủ đề khác nhau.

### **Áp dụng Chủ đề Bên ngoài cho Các Slide Phụ thuộc vào Master**

Sử dụng [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) khi bạn có tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.Masters](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/masters/), bộ sưu tập này triển khai [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các bước sau:

1. Tạo một slide master mới dựa trên master đã chọn.
1. Áp dụng chủ đề bên ngoài cho master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/) mới được tạo.

Ví dụ sau áp dụng một chủ đề bên ngoài cho các slide phụ thuộc vào master đầu tiên, lưu bản trình chiếu và mở lại kết quả:

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

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxexception/) hoặc một trong các lớp con liên quan tới định dạng. Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tập tin, và chỉ lưu bản trình chiếu sau khi chủ đề đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và chủ đề hiện tại. Các màu, phông chữ, màu nền, đường kẻ và hiệu ứng nhận thức về chủ đề sẽ được giải quyết dựa trên chủ đề bên ngoài. Các định dạng màu, phông chữ, màu nền và các định dạng rõ ràng khác có thể không thay đổi. Các ghi đè ở mức layout và slide cũng có thể có ưu tiên hơn các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu đến các phông chữ không có sẵn trong môi trường runtime. Để đảm bảo việc hiển thị và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [nguồn phông chữ tùy chỉnh](/slides/vi/net/custom-font/), hoặc cấu hình [thay thế phông chữ](/slides/vi/net/font-substitution/).

Đây là một quy trình làm việc trực tiếp ở mức master: phương thức nhận một đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở mức slide hay layout.

### **Áp dụng Các Chủ đề Bên ngoài Khác nhau trong Bản Trình chiếu Nhiều Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện thông qua [ISlide.LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/layoutslide/) và [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/masterslide/). Lưu trữ các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo thêm một master mới trong bản trình chiếu.

Ví dụ sau sử dụng các slide từ hai phần để xác định master của chúng và áp dụng một chủ đề bên ngoài khác nhau cho mỗi nhóm:

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

Lần gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, và lần gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu dáng.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và bảo tồn thiết kế gốc, hãy sao chép master nguồn vào bản trình chiếu đích bằng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/), sau đó sao chép slide bằng [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) và master đã sao chép. Điều này sẽ mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình làm việc được ưu tiên khi slide nguồn phải trông giống hệt ở nơi đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể thay đổi màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Một Slide hiện có**

Nếu slide đích phải ở lại master và layout hiện tại, khởi tạo một ghi đè ở mức slide từ chủ đề nguồn. Các phương thức [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initfontschemefrom/) và [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initformatschemefrom/) sao chép ba thành phần chính của chủ đề vào ghi đè.

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

Điều này thay đổi chủ đề được sử dụng bởi slide đó mà không ảnh hưởng tới chủ đề kế thừa của các slide khác. Để xóa ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng Ghi đè Chủ đề cho Một Layout**

Một ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/layoutslidethememanager/) của layout:

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

Sử dụng một chủ đề ở mức master hoặc bản trình chiếu khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và sử dụng ghi đè slide chỉ cho các trường hợp ngoại lệ thực sự. Việc ghi đè quá nhiều ở mức slide làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu nền Chủ đề**

Các màu nền của chủ đề được lưu trong [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì UI có thể kết hợp màu nền chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và thuộc tính [Background.StyleIndex](https://reference.aspose.com/slides/vi/net/aspose.slides/background/styleindex/) hiện tại. `StyleIndex` dùng `0` để biểu thị không có màu nền chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ mục bộ sưu tập .NET trực tiếp, trong đó `[0]` có nghĩa là mục đầu tiên. Đừng giả định rằng mọi bản trình chiếu đều chứa cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu bản trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục chủ đề được master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng tới slide đó. Hãy dùng [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Cảnh báo" %}}

Đừng xem `StyleIndex` như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh việc mã cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng biệt cho mỗi bản trình chiếu.

{{% /alert %}}

{{% alert color="info" title="Mẹo" %}}

Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/net/presentation-background/).

{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một lược đồ định dạng chủ đề chứa các bộ sưu tập riêng biệt [FillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/linestyles/) và [EffectStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/effectstyles/). Các chủ đề Office điển hình thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng chủ đề nhẹ, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong C#, chỉ mục bộ sưu tập bắt đầu từ 0: `[0]` là kiểu đầu tiên được lưu và `[2]` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở rộng qua [IShapeStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapestyle/). Thay đổi một kiểu chủ đề sẽ ảnh hưởng tới các hình dạng tham chiếu kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường kẻ đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ ngoài cho kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường kẻ chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu màu nền chủ đề thứ ba sẽ trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào việc mỗi hình dạng tham chiếu vị trí kiểu nào và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường kẻ, màu nền và cài đặt bóng đổ](presentation-design_11.png)

## **Đọc Các Giá trị Chủ đề Thực tế**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở mức độ cụ thể. Các giá trị thực tế cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Đối với nền, dùng [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/), và đối với màu nền, dùng [FillFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/geteffective/).

Ví dụ sau đọc chủ đề thực tế, nền và màu nền của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu thực tế cho chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/), bạn có thể bỏ lỡ một ghi đè ở master, layout, slide hoặc hình dạng thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Việc áp dụng một chủ đề bên ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) chỉ gán lại những slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác vẫn giữ nguyên chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Dùng [SlideThemeManager](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện có.

**Cách an toàn nhất để chuyển một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

Khi di chuyển một slide và muốn bảo tồn giao diện nguồn, sao chép master nguồn vào bản trình chiếu đích bằng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/) và sao chép slide cùng master đã sao chép bằng [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/). Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị thực tế sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) cho một slide hoặc layout và các phương thức dữ liệu thực tế tương ứng cho các đối tượng định dạng như [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/) và [FillFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/geteffective/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.