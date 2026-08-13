---
title: Quản lý nền bài thuyết trình trong .NET
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/net/presentation-background/
keywords:
- nền bài thuyết trình
- nền slide
- màu đồng nhất
- màu gradient
- nền ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách đặt nền động trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho .NET, kèm các mẹo mã để nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Màu nền đơn, gradient và ảnh thường được sử dụng cho nền slide. Bạn có thể đặt nền cho một **slide thường** (một slide duy nhất) hoặc một **slide mẫu** (áp dụng cho nhiều slide cùng lúc).

![PowerPoint background](powerpoint-background.png)

## **Đặt nền màu đồng nhất cho một Slide Thường**

Aspose.Slides cho phép bạn đặt màu đồng nhất làm nền cho một slide cụ thể trong bài thuyết trình — ngay cả khi bài thuyết trình sử dụng slide mẫu. Thay đổi chỉ áp dụng cho slide được chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng thuộc tính [SolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/solidfillcolor/) trên [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/) để chỉ định màu nền đồng nhất.
5. Lưu bài thuyết trình đã sửa đổi.

Ví dụ C# sau cho thấy cách đặt màu xanh đồng nhất làm nền cho một slide thường:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Đặt màu nền của slide thành màu xanh.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Lưu bài thuyết trình vào đĩa.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Đặt nền màu đồng nhất cho một Slide Mẫu**

Aspose.Slides cho phép bạn đặt màu đồng nhất làm nền cho slide mẫu trong một bài thuyết trình. Slide mẫu hoạt động như một mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn màu đồng nhất cho nền của slide mẫu, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide mẫu (qua `masters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide mẫu thành `Solid`.
4. Sử dụng [SolidFillColor](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/solidfillcolor/) để chỉ định màu nền đồng nhất.
5. Lưu bài thuyết trình đã sửa đổi.

Ví dụ C# sau cho thấy cách đặt màu xanh rừng đồng nhất làm nền cho một slide mẫu:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Đặt màu nền cho slide Master thành màu Xanh Rừng.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Lưu bài thuyết trình vào đĩa.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Đặt nền Gradient cho một Slide**

Gradient là hiệu ứng đồ họa được tạo ra bằng sự thay đổi dần dần về màu sắc. Khi được sử dụng làm nền slide, gradient có thể làm cho bài thuyết trình trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng thuộc tính [GradientFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/gradientformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bài thuyết trình đã sửa đổi.

Ví dụ C# sau cho thấy cách đặt màu gradient làm nền cho một slide:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Áp dụng hiệu ứng gradient cho nền.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Lưu bài thuyết trình vào đĩa.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Đặt ảnh làm Nền Slide**

Ngoài việc sử dụng màu đồng nhất và gradient, Aspose.Slides còn cho phép bạn dùng ảnh làm nền slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/net/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/net/aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải ảnh mà bạn muốn dùng làm nền slide.
5. Thêm ảnh vào bộ sưu tập ảnh của bài thuyết trình.
6. Sử dụng thuộc tính [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/picturefillformat/) trên [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/fillformat/) để gán ảnh làm nền.
7. Lưu bài thuyết trình đã sửa đổi.

Ví dụ C# sau cho thấy cách đặt ảnh làm nền cho một slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
    // Thêm hình ảnh vào bộ sưu tập ảnh của bài thuyết trình.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Lưu bài thuyết trình vào đĩa.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Mẫu mã sau cho thấy cách đặt kiểu fill nền thành ảnh lặp và chỉnh sửa các thuộc tính lặp:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Đặt hình ảnh được sử dụng cho việc lấp nền.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Đặt chế độ lấp ảnh thành Lát và điều chỉnh các thuộc tính lát.
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

{{% alert color="info" %}}

Đọc thêm: [**Tile Picture As Texture**](/slides/vi/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Thay đổi Độ trong suốt của Ảnh Nền**

Bạn có thể muốn điều chỉnh độ trong suốt của ảnh nền slide để nội dung slide nổi bật hơn. Đoạn mã C# sau cho thấy cách thay đổi độ trong suốt cho ảnh nền slide:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Ví dụ.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy tập hợp các phép biến đổi hình ảnh.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Tìm hiệu ứng trong suốt cố định theo tỷ lệ đã tồn tại.
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

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Lấy Giá Trị Nền Slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/net/aspose.slides/ibackgroundeffectivedata/) để truy xuất các giá trị nền thực tế của một slide. Giao diện này cung cấp [FillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibackgroundeffectivedata/fillformat/) và [EffectFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibackgroundeffectivedata/effectformat/) thực tế.

Sử dụng thuộc tính `background` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslide/), bạn có thể lấy nền thực tế của một slide.

Ví dụ C# sau cho thấy cách lấy giá trị nền thực tế của một slide:

```cs
using Aspose.Slides;

// Tạo một thể hiện của lớp Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Lấy nền hiệu quả, tính đến master, layout và theme.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **Câu hỏi thường gặp**

### Tôi có thể đặt lại nền tùy chỉnh và khôi phục nền theo theme/bố cục không?

Có. Xóa fill tùy chỉnh của slide, và nền sẽ được kế thừa lại từ slide [layout](/slides/vi/net/slide-layout/)/[master](/slides/vi/net/slide-master/) tương ứng (tức là [theme background](/slides/vi/net/presentation-theme/)).

### Điều gì sẽ xảy ra với nền nếu tôi thay đổi theme của bài thuyết trình sau này?

Nếu một slide có fill riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/net/slide-layout/)/[master](/slides/vi/net/slide-master/), nó sẽ cập nhật để phù hợp với [new theme](/slides/vi/net/presentation-theme/).