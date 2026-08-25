---
title: Quản lý giao diện bản trình chiếu trong .NET
linktitle: Giao diện bản trình chiếu
type: docs
weight: 10
url: /vi/net/presentation-theme/
keywords:
- giao diện PowerPoint
- giao diện bản trình chiếu
- giao diện slide
- đặt giao diện
- thay đổi giao diện
- quản lý giao diện
- màu giao diện
- bảng màu bổ sung
- phông chữ giao diện
- kiểu giao diện
- hiệu ứng giao diện
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý các giao diện bản trình chiếu chính trong Aspose.Slides cho .NET để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu đồng nhất."
---
## **Giới thiệu**

Một giao diện bản trình chiếu xác định một bộ màu, phông chữ, kiểu nền, màu nền, đường viền và hiệu ứng được phối hợp. Các đối tượng nhận thức giao diện tham chiếu các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy một thay đổi giao diện có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, giao diện cấp trình chiếu có sẵn thông qua thuộc tính [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/). Một bản trình chiếu cũng có thể chứa các ghi đè giao diện ở các cấp thấp hơn. Một master có thể ghi đè giao diện trình chiếu qua [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/masterthememanager/overridetheme/), một bố cục có thể ghi đè giao diện kế thừa của nó qua [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), và một slide riêng lẻ cũng có thể làm tương tự. Trong thực tế, giao diện thực tế cho một slide được xác định thông qua chuỗi kế thừa này: giao diện trình chiếu, ghi đè master, ghi đè bố cục và ghi đè slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Các phần bên dưới cho thấy các quy trình làm việc giao diện thường gặp nhất: kiểm tra giao diện, thay đổi màu và phông chữ, sao chép hoặc áp dụng giao diện, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Giao diện**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/) cung cấp [ColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/fontscheme/) và [FormatScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/mastertheme/formatscheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng rất hữu ích khi một bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính giao diện chính và báo cáo có bao nhiêu kiểu nền, màu nền, đường viền và hiệu ứng được lưu trong giao diện:

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

Nếu một tệp sử dụng nhiều master, đừng cho rằng mọi slide đều có cùng giao diện thực tế. Kiểm tra master gắn với slide, và sử dụng quy trình làm việc giao diện‑thực tế được mô tả sau trong bài viết khi có thể có ghi đè ở mức bố cục hoặc slide.

## **Thay đổi Màu Giao diện**

Các màu nền, đường viền và văn bản nhận thức giao diện có thể tham chiếu một màu logic từ liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/icolorscheme/) của giao diện, mọi đối tượng vẫn tham chiếu màu giao diện đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu giao diện.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của giao diện thành màu đỏ, lưu bản trình chiếu, mở lại và in màu nền thực tế:

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

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ thành màu đỏ sau khi giao diện được thay đổi. Nếu bạn thay thế màu lược đồ bằng một màu trực tiếp trên hình, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng đến màu nền đó.

### **Sử dụng Màu từ Bảng Màu Bổ Sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu giao diện bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua [ColorTransformOperation](https://reference.aspose.com/slides/vi/net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Các màu giao diện chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo ra từ các màu giao diện chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu giao diện. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các Khe `IColorScheme`**

Liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/net/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/icolorscheme/) cung cấp cùng các khe giao diện dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ này cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các khe giao diện; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng kia.

## **Thay đổi Phông chữ Giao diện**

Một lược đồ phông chữ giao diện chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các thuộc tính [FontScheme.Major](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/major/) và [FontScheme.Minor](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/fontscheme/minor/) cung cấp các bộ này.

Các định danh phông chữ giao diện tương thích PowerPoint có thể được dùng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ giao diện và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và văn bản nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh giao diện sẽ không tự động chuyển khi lược đồ phông chữ giao diện thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa ánh xạ phông chữ cho các hệ viết riêng lẻ, chẳng hạn Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc loại bỏ các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/net/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Giao diện**

Có hai quy trình làm việc phổ biến, và chúng giải quyết các vấn đề khác nhau.

### **Bảo tồn Giao diện Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và bảo tồn thiết kế gốc, sao chép master nguồn vào bản trình chiếu đích bằng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/), sau đó sao chép slide bằng [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/) và master đã sao chép. Thao tác này mang theo master, các bố cục và giao diện liên quan.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Việc chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi màu, phông chữ, nền và hiệu ứng dựa trên giao diện.

### **Áp dụng Giá trị Giao diện cho Slide hiện có**

Nếu slide đích phải ở trên master và bố cục hiện tại, khởi tạo một ghi đè cấp slide từ giao diện nguồn. Các phương thức [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initfontschemefrom/) và [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/initformatschemefrom/) sao chép ba thành phần chính của giao diện vào ghi đè.

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

Điều này thay đổi giao diện được slide đó sử dụng mà không ảnh hưởng đến giao diện được các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.Clear](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng Ghi đè Giao diện cho Layout**

Ghi đè cấp bố cục áp dụng cho các slide sử dụng bố cục đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể dùng thông qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/layoutslidethememanager/):

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

Sử dụng giao diện master hoặc trình chiếu khi nhiều bố cục và slide nên chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè bố cục khi một nhóm bố cục cần kiểu dáng khác nhau, và chỉ ghi đè slide cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide làm cho việc thay đổi giao diện toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Giao diện**

Các màu nền của giao diện được lưu trong [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì giao diện người dùng có thể kết hợp màu nền giao diện với màu giao diện và các tham chiếu kiểu khác.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và [Background.StyleIndex](https://reference.aspose.com/slides/vi/net/aspose.slides/background/styleindex/) hiện tại. `StyleIndex` dùng `0` cho không có màu nền giao diện; các giá trị dương là tham chiếu kiểu nền giao diện. Điều này khác với việc lập chỉ mục bộ sưu tập .NET trực tiếp, trong đó `[0]` nghĩa là mục đầu tiên được lưu. Đừng cho rằng mọi bản trình chiếu đều chứa cùng số kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền giao diện cho master đầu tiên, và lưu bản trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục giao diện được master tham chiếu và bất kỳ ghi đè nền nào ở mức bố cục hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng đến slide đó. Sử dụng [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng coi `StyleIndex` như một chỉ mục bộ sưu tập bắt đầu từ 0. Ngoài ra, tránh mã cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng ngoại hình trong tệp khác; các định nghĩa kiểu giao diện là đặc thù cho mỗi bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/net/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Giao diện**

Một lược đồ định dạng giao diện chứa các bộ sưu tập riêng biệt [FillStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/linestyles/) và [EffectStyles](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/formatscheme/effectstyles/). Các giao diện Office thường chứa ba mục kiểu chính tương ứng với định dạng tinh tế, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định một số lượng cố định.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong C#, chỉ mục bộ sưu tập bắt đầu từ 0: `[0]` là kiểu đầu tiên được lưu và `[2]` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được hiển thị qua [IShapeStyle](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapestyle/). Sửa đổi một kiểu giao diện sẽ ảnh hưởng đến các hình dạng tham chiếu kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra các mục kiểu cần thiết tồn tại, thay đổi kiểu đường đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ phía ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các khe này, kiểu đường giao diện đầu tiên trở nên màu đỏ, kiểu màu nền giao diện thứ ba trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba có một bóng đổ phía ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cụ thể vẫn phụ thuộc vào việc mỗi hình dạng tham chiếu khe kiểu nào và liệu định dạng trực tiếp có ghi đè giao diện hay không.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Đọc Giá trị Giao diện Thực tế**

Các đối tượng giao diện thô cho bạn biết gì được định nghĩa ở mức cụ thể. Giá trị thực tế cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ được giải quyết. Đối với slide, gọi [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Đối với nền, dùng [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/), và đối với màu nền, dùng [FillFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/geteffective/).

Ví dụ sau đọc giao diện thực tế, nền và màu nền của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu thực tế cho việc chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.MasterTheme](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/mastertheme/), bạn có thể bỏ lỡ một master, bố cục, slide hoặc ghi đè hình dạng thay đổi giao diện cuối cùng.

## **FAQ**

**Tôi có thể áp dụng một giao diện cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/slidethememanager/) của slide và khởi tạo giao diện ghi đè của nó. Thay đổi sẽ chỉ ảnh hưởng cục bộ tới slide đó; các slide khác tiếp tục kế thừa giao diện hiện có.

**Cách an toàn nhất để chuyển giao diện từ một bản trình chiếu sang bản khác là gì?**

Khi di chuyển một slide và bảo tồn giao diện nguồn, sao chép master nguồn vào bản đích và sao chép slide cùng master đó bằng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/) và [ISlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection/addclone/). Điều này giữ nguyên master, các bố cục và giao diện cùng nhau.

**Làm sao tôi có thể xem các giá trị thực tế sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/vi/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) cho một slide hoặc giao diện bố cục và các phương thức dữ liệu‑thực tế tương ứng cho các đối tượng định dạng như [Background.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/background/geteffective/) và [FillFormat.GetEffective](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/geteffective/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.