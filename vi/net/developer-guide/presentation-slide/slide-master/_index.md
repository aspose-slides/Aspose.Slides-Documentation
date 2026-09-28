---
title: "Quản lý Slide Master của Bài thuyết trình trong .NET"
linktitle: "Slide Master"
type: docs
weight: 80
url: /vi/net/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- nhiều slide master
- so sánh slide master
- nền
- placeholder
- sao chép slide master
- sao chép slide master
- nhân bản slide master
- slide master không dùng
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho .NET: truy cập, chỉnh sửa, sao chép, so sánh và xóa slide master trong các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** định nghĩa các thiết lập thiết kế chung cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, thiết lập chủ đề và thiết lập chân trang. Trong PowerPoint, việc chỉnh sửa một slide master là cách thường dùng để duy trì sự nhất quán của bản trình bày mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for .NET hỗ trợ cùng mô hình này. Một bản trình bày có thể chứa một hoặc nhiều master slide, và mỗi master slide có thể chứa một số layout slide. Các slide thường không tham chiếu trực tiếp tới master slide. Thay vào đó, một slide thường sử dụng một layout slide, và layout slide đó thuộc về một master slide.

Cấu trúc phân cấp như sau:

1. **Slide master** – định nghĩa thiết kế và chủ đề chung.
1. **Layout slide** – định nghĩa cách sắp xếp các placeholder và định dạng ở mức layout.
1. **Normal slide** – chứa nội dung thực tế của bản trình bày và sử dụng một layout slide.

![Cấu trúc phân cấp của master slide, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được biểu diễn bằng giao diện [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/). Tất cả các master slide trong một bản trình bày có thể truy cập qua collection [Presentation.Masters](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/masters/), collection này thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Khi cùng một thuộc tính được định nghĩa ở nhiều cấp độ, cấp độ cụ thể hơn sẽ thắng. Ví dụ, nếu một master slide và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm về layout slide, xem [Apply or Change Slide Layouts](/slides/vi/net/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng collection `Masters` để truy cập các master slide:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Bạn cũng có thể lấy master slide được một slide thường sử dụng thông qua layout của nó:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Nội dung của một Slide Master**

Một master slide là một đối tượng giống slide. Nó thực thi [IBaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như slide thường và layout. Các thành viên riêng của master được liệt kê trên trang API [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/).

Các thành viên master slide thường dùng bao gồm:

| Member | Purpose |
| --- | --- |
| `Background` | Đặt nền slide ở mức master. |
| `Shapes` | Lưu trữ các hình dạng được đặt trên master, chẳng hạn như logo, khung ảnh và văn bản chung. |
| `LayoutSlides` | Lưu trữ các layout slide thuộc về master. |
| `ThemeManager` | Cung cấp truy cập vào các API chủ đề của master. |
| `HeaderFooterManager` | Kiểm soát tiêu đề, chân trang, ngày tháng và số slide cho master và các layout con của nó. |
| `GetDependingSlides` | Trả về các slide thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một master slide, nó sẽ hiển thị trên các slide sử dụng layout từ master đó. Tính năng này hữu ích cho logo, dấu nước, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào master slide đầu tiên:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Để biết thêm về khung ảnh, xem [Picture Frame](/slides/vi/net/picture-frame/).

## **Kiểm soát hiển thị đồ họa của Master**

Sử dụng [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/showmastershapes/) để ẩn các đồ họa kế thừa từ master, chẳng hạn như logo hoặc hình dạng trang trí, mà không xóa chúng khỏi master. Đặt [Slide.ShowMasterShapes](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/showmastershapes/) thành `false` trên slide muốn bỏ các đồ họa đó và giữ `true` trên các slide muốn hiển thị chúng.

Ví dụ tự chứa dưới đây tạo một dải trang trí màu xanh trên master và hai slide sử dụng cùng một layout trống. Dải này hiển thị trên slide đầu tiên và ẩn trên slide thứ hai. Không cần bản trình bày hoặc hình ảnh đầu vào.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Ví dụ sử dụng layout **Blank** được cung cấp trong một bản trình bày mới và loại bỏ các placeholder riêng của slide đầu tiên.

### **Chọn phạm vi thiết lập**

Một slide thường sử dụng master thông qua [ISlide.LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/layoutslide/) và [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ilayoutslide/masterslide/). Đặt thuộc tính trên một slide riêng chỉ ảnh hưởng đến slide đó. Đặt [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutslide/showmastershapes/) thành `false` sẽ ẩn đồ họa master cho tất cả các slide dùng cùng layout, ngay cả khi thiết lập riêng của chúng là `true`. Để ẩn đồ họa chỉ trên một slide, thay đổi thuộc tính của slide và giữ layout chung không đổi.

Thiết lập này không được hỗ trợ làm điều khiển hiển thị trên chính master slide. Trên master luôn trả về `false`, và gán `true` sẽ ném `NotSupportedException`. Áp dụng nó cho slide thường hoặc layout thay vì master.

### **Phân biệt đồ họa và nền**

| Operation | Effect |
| --- | --- |
| Hide master graphics | Kiểm soát việc ẩn các shape kế thừa từ master mà không xóa chúng hoặc thay đổi các shape riêng của slide. |
| Change the slide background fill | Thay đổi màu, gradient hoặc hình ảnh nền. Đồ họa master là các shape riêng biệt và có thể vẫn hiển thị trên nền mới. Xem [Presentation Background](/slides/vi/net/presentation-background/). |
| Delete a shape from the master | Loại bỏ shape nguồn chung, vì vậy nó sẽ không còn khả dụng cho bất kỳ slide nào dùng master đó. |

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Master slide cung cấp kiểu và chủ đề chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào có sẵn và chúng được đặt ở đâu.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ Slide Master.

![Lệnh Insert Placeholder trong chế độ Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên master slide. Ví dụ dưới đây tìm placeholder tiêu đề và áp dụng màu gradient tuyến tính:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Placeholder tiêu đề đã định dạng kế thừa bởi các slide thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/slides/vi/net/manage-placeholder/) và [Text Formatting](/slides/vi/net/text-formatting/).

## **Thay đổi nền Slide Master**

Nền master được kế thừa bởi các layout và slide không ghi đè nó. Ví dụ sau đặt màu nền đặc cho master slide đầu tiên:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Đối với các chủ đề liên quan, xem [Presentation Background](/slides/vi/net/presentation-background/) và [Presentation Theme](/slides/vi/net/presentation-theme/).

## **Sao chép Slide Master sang bản trình bày khác**

Sử dụng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/) để sao chép một master slide vào bản trình bày khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản đích.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Nếu bạn cần sao chép cả các slide thường cùng với master của chúng, xem [Clone Slides](/slides/vi/net/clone-slides/).

## **Thêm nhiều Slide Master**

Một bản trình bày có thể chứa nhiều master slide. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc thiết lập chủ đề riêng.

![Các lệnh PowerPoint để chèn và quản lý master slide](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép và thêm một slide mới dựa trên layout đó:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **So sánh Slide Masters**

Các master slide có thể được so sánh bằng phương thức `Equals` kế thừa từ [IBaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/). So sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn như shape, văn bản, định dạng, hoạt ảnh và các thiết lập slide khác. Nó không so sánh các định danh duy nhất như ID slide, hay các giá trị placeholder động như ngày hiện tại.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Để biết thêm, xem [Compare Presentation Slides](/slides/vi/net/compare-slides/).

## **Đặt chế độ Slide Master làm chế độ mặc định**

Sử dụng thuộc tính `LastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/) để điều khiển chế độ mà PowerPoint mở đầu tiên. Ví dụ dưới mở bản trình bày ở chế độ Slide Master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Để biết thêm các thiết lập chế độ xem, xem [Save Presentation](/slides/vi/net/save-presentation/).

## **Xóa các Master Slide không dùng**

Đôi khi bản trình bày chứa các master slide không còn được bất kỳ slide thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hoá việc bảo trì mẫu.

Sử dụng [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/vi/net/aspose.slides/masterslidecollection/removeunused/) để xóa các master không dùng khỏi collection `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Bạn cũng có thể dùng phương thức low-code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Sự khác nhau giữa slide master và layout slide là gì?**

Slide master định nghĩa các thiết lập thiết kế chung như chủ đề, nền, hình dạng chung và kiểu chữ. Layout slide thuộc về một master slide và định nghĩa cách sắp xếp cụ thể của các placeholder. Slide thường sử dụng một layout slide, vì vậy nó kế thừa từ cả layout và master.

**Một bản trình bày có thể chứa nhiều slide master không?**

Có. Một bản trình bày có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc thương hiệu riêng.

**Nên thêm placeholder vào master slide hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh và định dạng chung trên master slide, sau đó đặt các placeholder nội dung trên layout mà các slide thường sẽ sử dụng.

**Tôi có thể xóa một master slide đang được dùng không?**

Không. Master slide có slide phụ thuộc không thể bị xóa trực tiếp một cách an toàn. Đầu tiên hãy di chuyển các slide đó sang layout dưới master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng chỉ xóa các master không được sử dụng.