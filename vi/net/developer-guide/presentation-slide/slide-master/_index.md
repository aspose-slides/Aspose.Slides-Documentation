---
title: Quản lý Slide Master của Bản trình bày trong .NET
linktitle: Slide Master
type: docs
weight: 80
url: /vi/net/slide-master/
keywords:
- slide master
- slide master
- slide master PPT
- nhiều slide master
- so sánh slide master
- nền
- trình giữ chỗ
- sao chép slide master
- chép slide master
- nhân bản slide master
- slide master không dùng
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho .NET: truy cập, chỉnh sửa, sao chép, so sánh và xóa slide master trong các bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** định nghĩa các cài đặt thiết kế chung cho một nhóm slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, cài đặt giao diện và cài đặt chân trang. Trong PowerPoint, chỉnh sửa slide master là cách thường dùng để giữ cho bản trình bày nhất quán mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for .NET hỗ trợ cùng mô hình này. Một bản trình bày có thể chứa một hoặc nhiều slide master, và mỗi slide master có thể chứa một số slide layout. Các slide thường không tham chiếu trực tiếp tới slide master. Thay vào đó, một slide thường sử dụng một slide layout, và slide layout đó thuộc về một slide master.

Cấu trúc phân cấp như sau:

1. **Slide master** – định nghĩa thiết kế và giao diện chung.
1. **Layout slide** – định nghĩa sắp xếp cụ thể của các placeholder và định dạng mức layout.
1. **Normal slide** – chứa nội dung thực tế của bản trình bày và sử dụng một layout slide.

![Cấu trúc phân cấp của slide master, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, slide master được biểu diễn bằng giao diện [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/). Tất cả các slide master trong một bản trình bày có thể truy cập qua bộ sưu tập [Presentation.Masters](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/masters/), bộ sưu tập này thực hiện [IMasterSlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Khi cùng một thuộc tính được định nghĩa ở nhiều mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một slide master và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Apply or Change Slide Layouts](/slides/vi/net/slide-layout/).

{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ Slide Master bằng **View** > **Slide Master**.

![Lệnh Slide Master trên thẻ View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `Masters` để truy cập các slide master:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Bạn cũng có thể lấy slide master được sử dụng bởi một slide thường thông qua layout của nó:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Nội dung của một Slide Master**

Slide master là một đối tượng giống slide. Nó thực hiện [IBaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như các slide thường và layout. Các thành viên đặc thù của master được liệt kê trên trang API [IMasterSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslide/).

Các thành viên master thường được sử dụng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `Background` | Đặt nền ở mức master. |
| `Shapes` | Lưu các hình dạng đặt trên master, như logo, khung ảnh và văn bản chia sẻ. |
| `LayoutSlides` | Lưu các layout slide thuộc về master. |
| `ThemeManager` | Cung cấp truy cập tới các API giao diện của master. |
| `HeaderFooterManager` | Điều khiển tiêu đề, chân trang, ngày tháng và số slide cho master và các layout con của nó. |
| `GetDependingSlides` | Trả về các slide thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm Hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào slide master, hình ảnh sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào slide master đầu tiên:

```csharp
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

Để biết thêm thông tin về khung ảnh, xem [Picture Frame](/slides/vi/net/picture-frame/).

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Slide master cung cấp kiểu dáng và giao diện chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào có sẵn và vị trí của chúng.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ Slide Master view.

![Lệnh Insert Placeholder trong chế độ Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```csharp
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

Bạn cũng có thể định dạng các placeholder đã tồn tại trên slide master. Ví dụ sau tìm placeholder tiêu đề và áp dụng tô đầy gradient tuyến tính:

```csharp
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

![Placeholder tiêu đề đã định dạng được kế thừa bởi slide thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/slides/vi/net/manage-placeholder/) và [Text Formatting](/slides/vi/net/text-formatting/).

## **Thay đổi Nền của Slide Master**

Nền master được kế thừa bởi các layout và slide không ghi đè nó. Ví dụ sau đặt màu nền đặc cho slide master đầu tiên:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Đối với các chủ đề liên quan, xem [Presentation Background](/slides/vi/net/presentation-background/) và [Presentation Theme](/slides/vi/net/presentation-theme/).

## **Sao chép Slide Master sang Bản Trình Bày Khác**

Sử dụng [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/vi/net/aspose.slides/imasterslidecollection/addclone/) để sao chép một slide master vào bản trình bày khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản trình bày đích.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Nếu bạn cần sao chép cả slide thường cùng với master của chúng, xem [Clone Slides](/slides/vi/net/clone-slides/).

## **Thêm Nhiều Slide Master**

Một bản trình bày có thể chứa nhiều slide master. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt giao diện riêng.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép và thêm một slide mới dựa trên layout đó:

```csharp
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

Slide master có thể được so sánh bằng phương thức `Equals` kế thừa từ [IBaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/). Việc so sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn như hình dạng, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất như ID slide, hay các giá trị placeholder động như ngày hiện tại.

```csharp
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

Để biết thêm chi tiết, xem [Compare Presentation Slides](/slides/vi/net/compare-slides/).

## **Đặt Slide Master View làm View Mặc định**

Sử dụng thuộc tính `LastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/) để điều khiển view mà PowerPoint mở đầu tiên. Ví dụ sau mở bản trình bày trong chế độ Slide Master view:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Đối với các cài đặt view khác, xem [Save Presentation](/slides/vi/net/save-presentation/).

## **Xóa Các Slide Master Không dùng**

Đôi khi bản trình bày chứa các slide master không còn được bất kỳ slide thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hoá việc bảo trì mẫu.

Sử dụng [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/vi/net/aspose.slides/masterslidecollection/removeunused/) để xóa các master không dùng khỏi bộ sưu tập `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Bạn cũng có thể dùng phương thức low-code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Sự khác nhau giữa slide master và layout slide là gì?**

Slide master định nghĩa các cài đặt thiết kế chung như giao diện, nền, các hình dạng và kiểu văn bản chung. Layout slide thuộc về một slide master và định nghĩa sắp xếp cụ thể của các placeholder. Slide thường sử dụng một layout slide, vì vậy nó kế thừa cả từ layout và master.

**Một bản trình bày có thể chứa nhiều slide master không?**

Có. Một bản trình bày có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc thương hiệu riêng.

**Nên thêm placeholder vào slide master hay layout slide?**

Trong hầu hết các trường hợp, hãy thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh và định dạng chung trên slide master, sau đó đặt các placeholder nội dung trên các layout mà slide thường sẽ sử dụng.

**Tôi có thể xóa một slide master còn đang được sử dụng không?**

Không. Slide master có các slide phụ thuộc không thể bị xóa trực tiếp một cách an toàn. Đầu tiên di chuyển các slide đó sang layout thuộc master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng để chỉ xóa các master không có slide phụ thuộc.