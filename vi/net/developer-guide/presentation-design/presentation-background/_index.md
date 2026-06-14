---
title: Quản lý Nền Bài Trình Chiếu trong .NET
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/net/presentation-background/
keywords:
- nền bài trình chiếu
- nền slide
- màu nền đơn
- màu gradient
- nền hình ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bài trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách đặt nền động trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho .NET, kèm các mẹo mã để nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Màu nền đơn, gradient và hình ảnh thường được sử dụng làm nền cho slide. Bạn có thể đặt nền cho một **slide thường** (một slide duy nhất) hoặc một **slide chủ** (áp dụng cho nhiều slide cùng lúc).

![PowerPoint background](powerpoint-background.png)

## **Đặt Nền Màu Đơn cho Slide Thường**

Aspose.Slides cho phép bạn đặt màu nền đơn làm nền cho một slide cụ thể trong bản trình chiếu — ngay cả khi bản trình chiếu sử dụng slide chủ. Thay đổi chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng thuộc tính [SolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/solidfillcolor/) trên [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/) để chỉ định màu nền đơn.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C# sau đây minh họa cách đặt màu nền xanh lam dạng đơn cho một slide thường:

```cs
// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Đặt màu nền của slide thành màu xanh lam.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Lưu bản trình chiếu vào đĩa.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Đặt Nền Màu Đơn cho Slide Chủ**

Aspose.Slides cho phép bạn đặt màu nền đơn làm nền cho slide chủ trong bản trình chiếu. Slide chủ hoạt động như một mẫu, kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn màu nền đơn cho nền của slide chủ, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide chủ (qua `masters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide chủ thành `Solid`.
4. Sử dụng [SolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/solidfillcolor/) để chỉ định màu nền đơn.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C# sau đây minh họa cách đặt màu nền dạng đơn (xanh rừng) cho một slide chủ:

```cs
// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Đặt màu nền cho slide Master thành màu Xanh Rừng.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Lưu bản trình chiếu vào đĩa.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Đặt Nền Gradient cho Slide**

Gradient là một hiệu ứng đồ họa tạo ra bằng cách thay đổi màu dần dần. Khi được sử dụng làm nền cho slide, gradient có thể làm cho bản trình chiếu trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng thuộc tính [GradientFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/gradientformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C# sau đây minh họa cách đặt màu gradient làm nền cho một slide:

```cs
// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Áp dụng hiệu ứng gradient cho nền.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Lưu bản trình chiếu vào đĩa.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Đặt Hình Ảnh làm Nền cho Slide**

Ngoài các nền đơn và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền cho slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn dùng làm nền cho slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
6. Sử dụng thuộc tính [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/picturefillformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bản trình chiếu đã sửa đổi.

Ví dụ C# sau đây minh họa cách đặt hình ảnh làm nền cho một slide:

```c#
 // Tạo một thể hiện của lớp Presentation.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];
 
     // Đặt các thuộc tính hình ảnh nền.
     slide.Background.Type = BackgroundType.OwnBackground;
     slide.Background.FillFormat.FillType = FillType.Picture;
     slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
 
     // Tải hình ảnh.
     IImage image = Images.FromFile("Tulips.jpg");
     // Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();
 
     slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;
 
     // Lưu bản trình chiếu vào đĩa.
     presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
 }
```

Mẫu mã sau đây minh họa cách đặt kiểu tô nền thành hình ảnh lặp và chỉnh sửa các thuộc tính lặp:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Đặt hình ảnh được sử dụng cho việc tô nền.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Đặt chế độ tô hình ảnh thành Lát và điều chỉnh các thuộc tính lát.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Đọc thêm: [**Tile Picture As Texture**](/slides/vi/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay Đổi Độ Trong Suất Hình Ảnh Nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình ảnh nền slide để làm nổi bật nội dung slide. Đoạn mã C# sau đây chỉ cho bạn cách thay đổi độ trong suốt cho hình ảnh nền slide:

```cs
var transparencyValue = 30; // Ví dụ.

// Lấy tập hợp các thao tác biến đổi hình ảnh.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Tìm hiệu ứng trong suốt tỉ lệ cố định hiện có.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Đặt giá trị trong suốt mới.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **Lấy Giá Trị Nền của Slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ibackgroundeffectivedata/) để lấy các giá trị nền thực tế của một slide. Giao diện này cung cấp [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibackgroundeffectivedata/fillformat/) và [EffectFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibackgroundeffectivedata/effectformat/) thực tế.

Sử dụng thuộc tính `background` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslide/), bạn có thể lấy nền thực tế cho một slide.

Ví dụ C# sau đây minh họa cách lấy giá trị nền thực tế của một slide:

```cs
// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Lấy nền thực tế, có tính đến master, layout và theme.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt lại nền tùy chỉnh và khôi phục lại nền của chủ đề/bố cục không?**

Có. Loại bỏ việc tô tùy chỉnh của slide, và nền sẽ lại được kế thừa từ slide [layout](/slides/vi/net/slide-layout/)/[master](/slides/vi/net/slide-master/) tương ứng (tức là [theme background](/slides/vi/net/presentation-theme/)).

**Điều gì sẽ xảy ra với nền nếu tôi thay đổi chủ đề của bản trình chiếu sau này?**

Nếu một slide có màu tô riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/net/slide-layout/)/[master](/slides/vi/net/slide-master/), nó sẽ được cập nhật để khớp với [new theme](/slides/vi/net/presentation-theme/).