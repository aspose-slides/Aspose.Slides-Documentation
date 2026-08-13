---
title: Quản lý khung hình trong các bài thuyết trình trên .NET
linktitle: Khung hình
type: docs
weight: 10
url: /vi/net/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- thêm hình ảnh
- tạo hình ảnh
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- độ trong suốt của hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Thêm khung hình vào các bài thuyết trình PowerPoint và OpenDocument với Aspose.Slides cho .NET. Tinh giản quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa một hình ảnh—giống như một bức tranh trong khung.

Bạn có thể thêm hình ảnh vào một slide thông qua khung hình. Bằng cách này, bạn có thể định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert  title="Tip" color="info" %}} 

Aspose cung cấp các bộ chuyển đổi miễn phí—[JPEG sang PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG sang PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp người dùng tạo bài thuyết trình nhanh chóng từ hình ảnh. 

{{% /alert %}} 

## **Tạo khung hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) gắn với đối tượng presentation sẽ được dùng để lấp đầy hình dạng. 
4. Xác định chiều rộng và chiều cao của hình ảnh. 
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `AddPictureFrame` được cung cấp bởi đối tượng shape gắn với slide đã tham chiếu. 
6. Thêm một khung hình (chứa hình ảnh) vào slide. 
7. Ghi bản trình bày đã sửa đổi thành tệp PPTX. 

Mã C# này cho bạn thấy cách tạo khung hình:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide slide = pres.Slides[0];

    // Tải một hình ảnh và thêm nó vào bộ sưu tập hình ảnh của bản trình bày
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Thêm một khung hình với cùng chiều cao và chiều rộng
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Áp dụng một số định dạng cho khung hình
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Ghi bản trình bày vào tệp PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Khung hình cho phép bạn nhanh chóng tạo các slide thuyết trình dựa trên hình ảnh. Khi bạn kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể tham khảo các trang sau: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/net/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/net/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/net/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/net/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/net/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Tạo khung hình với tỷ lệ tương đối**

Bằng cách thay đổi tỷ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation. 
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) gắn với đối tượng presentation sẽ được dùng để lấp đầy hình dạng. 
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình. 
6. Ghi bản trình bày đã sửa đổi thành tệp PPTX. 

Mã C# này cho bạn thấy cách tạo khung hình với tỷ lệ tương đối:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Tải một hình ảnh và thêm nó vào bộ sưu tập hình ảnh của bản trình bày
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Thêm một khung hình vào slide
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Đặt chiều rộng và chiều cao tỷ lệ tương đối
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Lưu bản trình bày
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Trích xuất hình ảnh raster từ khung hình**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe) và lưu chúng ở định dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu “sample.pptx” và lưu nó ở định dạng PNG.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Trích xuất hình ảnh SVG từ khung hình**

Khi một bản thuyết trình chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/), Aspose.Slides cho .NET cho phép bạn lấy lại các hình ảnh vector gốc với độ trung thực đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) dưới lớp có chứa nội dung SVG hay không, sau đó lưu hình ảnh đó vào đĩa hoặc luồng ở định dạng SVG gốc.

Mã dưới đây minh họa cách trích xuất một hình ảnh SVG từ khung hình:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Lấy độ trong suốt của hình ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Mã C# này minh họa thao tác:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Lấy độ sáng và độ tương phản của hình ảnh**

Aspose.Slides cho phép bạn lấy độ sáng và độ tương phản được áp dụng cho một hình ảnh. Giao diện [ILuminance](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iluminance/) đại diện cho hiệu ứng biến đổi hình ảnh này.

Mã C# này minh họa cách lấy cài đặt độ sáng và độ tương phản từ một khung hình:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
Tất cả các hiệu ứng được áp dụng cho hình ảnh có thể được tìm thấy trong [Aspose.Slides.Effects](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/). 
{{% /alert %}}

## **Định dạng khung hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Bằng cách sử dụng các tùy chọn này, bạn có thể điều chỉnh khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) . 
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) gắn với đối tượng presentation sẽ được dùng để lấp đầy hình dạng. 
4. Xác định chiều rộng và chiều cao của hình ảnh. 
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [AddPictureFrame](http://www.aspose.com/api/net/slides/vi/aspose.slides/ishapecollection/methods/addpictureframe) được cung cấp bởi đối tượng [IShapes](http://www.aspose.com/api/net/slides/vi/aspose.slides/ishapecollection) gắn với slide đã tham chiếu. 
6. Thêm khung hình (chứa hình ảnh) vào slide. 
7. Đặt màu đường viền của khung hình. 
8. Đặt độ rộng đường viền của khung hình. 
9. Xoay khung hình bằng cách cung cấp giá trị dương hoặc âm. 
   * Giá trị dương quay hình ảnh theo chiều kim đồng hồ. 
   * Giá trị âm quay hình ảnh ngược chiều kim đồng hồ. 
10. Thêm khung hình (chứa hình ảnh) vào slide. 
11. Ghi bản trình bày đã sửa đổi thành tệp PPTX. 

Mã C# này minh họa quá trình định dạng khung hình:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide slide = presentation.Slides[0];

    // Tải một hình ảnh và thêm nó vào bộ sưu tập hình ảnh của bản trình bày
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Thêm một khung hình với chiều cao và chiều rộng tương đương của hình ảnh
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Áp dụng một số định dạng cho khung hình
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Ghi bản trình bày vào tệp PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose gần đây đã phát triển một công cụ [Collage Maker miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [gộp các ảnh JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 

{{% /alert %}}

## **Thêm hình ảnh dưới dạng liên kết**

Để tránh kích thước bản thuyết trình quá lớn, bạn có thể thêm hình ảnh (hoặc video) qua liên kết thay vì nhúng tệp trực tiếp vào bản thuyết trình. Mã C# này cho bạn thấy cách thêm một hình ảnh và video vào một placeholder:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Cắt hình ảnh**

Mã C# này cho bạn thấy cách cắt một hình ảnh đã tồn tại trên slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Tạo một đối tượng hình ảnh mới
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Thêm một PictureFrame vào Slide
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Cắt hình ảnh (giá trị phần trăm)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Lưu kết quả
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Xóa các khu vực đã cắt của hình ảnh**

Nếu bạn muốn xóa các khu vực đã cắt của hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu không cần cắt.

Mã C# này minh họa thao tác:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy PictureFrame từ slide đầu tiên
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Xóa các vùng đã cắt của hình ảnh PictureFrame và trả về hình ảnh đã cắt
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Lưu kết quả
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của presentation. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) đã xử lý, thiết lập này có thể giảm kích thước bản thuyết trình. Ngược lại, số lượng hình ảnh trong bản thuyết trình kết quả sẽ tăng.

Phương thức này chuyển đổi các tệp metafile WMF/EMF sang hình ảnh raster PNG trong quá trình cắt. 

{{% /alert %}}

## **Nén hình ảnh**

Bạn có thể nén một hình ảnh trong bản thuyết trình bằng phương thức [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/compressimage/). Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các khu vực đã cắt. 

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format → Compress Pictures → Resolution** của PowerPoint.

Các ví dụ C# sau đây minh họa cách nén hình ảnh trong bản thuyết trình bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các khu vực đã cắt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và loại bỏ các vùng đã cắt.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Kiểm tra kết quả của quá trình nén.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Hoặc sử dụng giá trị DPI tùy chỉnh trực tiếp:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Nén hình ảnh đến 150 DPI (độ phân giải web), loại bỏ các vùng đã cắt.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.  
Nếu hình ảnh là một metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý các JPEG độ phân giải cao. 

{{% /alert %}}

## **Khóa tỷ lệ khung hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ tỷ lệ khung ngay cả khi thay đổi kích thước hình ảnh, bạn có thể sử dụng thuộc tính [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframelock/aspectratiolocked/) để đặt cài đặt *Lock Aspect Ratio*. 

Mã C# này cho bạn thấy cách khóa tỷ lệ khung của hình dạng:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Đặt hình dạng để giữ tỷ lệ khung khi thay đổi kích thước
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Cài đặt *Lock Aspect Ratio* này chỉ bảo toàn tỷ lệ của hình dạng chứ không phải của hình ảnh bên trong. 

{{% /alert %}}

## **Sử dụng thuộc tính StretchOff**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetright) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat), bạn có thể chỉ định một hình chữ nhật lấp đầy. 

Khi kéo dài được chỉ định cho một hình ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được xác định bằng phần trăm offset so với cạnh tương ứng của hộp bao quanh của hình dạng. Phần trăm dương chỉ ra việc nội lõm trong khi phần trăm âm chỉ ra việc mở rộng ra ngoài.

1. Tạo một thể hiện của [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) . 
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh. 
5. Đặt kiểu lấp đầy cho hình dạng. 
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng. 
7. Thêm một tập hình ảnh để lấp đầy hình dạng. 
8. Xác định offset của hình ảnh từ cạnh tương ứng của hộp bao quanh của hình dạng 
9. Ghi bản trình bày đã sửa đổi thành tệp PPTX. 

Mã C# này minh họa quy trình sử dụng thuộc tính StretchOff:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Đặt hình ảnh kéo dãn từ mỗi phía trong thân hình dạng
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

### Làm thế nào tôi có thể biết định dạng hình ảnh nào được hỗ trợ cho PictureFrame?

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của động cơ chuyển đổi slide và hình ảnh.

### Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào tới kích thước và hiệu năng của PPTX?

Nhúng hình ảnh lớn làm tăng kích thước tệp và mức sử dụng bộ nhớ; liên kết hình ảnh giúp giữ kích thước bản thuyết trình nhỏ hơn nhưng đòi hỏi các tệp bên ngoài phải luôn khả dụng. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

### Làm sao tôi có thể khóa đối tượng hình ảnh khỏi việc di chuyển/đổi kích thước không mong muốn?

Sử dụng [khóa hình dạng](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/pictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá di chuyển hoặc thay đổi kích thước). Cơ chế khóa được mô tả cho các hình dạng trong một [bài viết bảo mật](/slides/vi/net/applying-protection-to-presentation/) riêng và được hỗ trợ cho nhiều loại hình dạng, bao gồm cả [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/).

### Độ trung thực vector SVG có được bảo toàn khi xuất bản thuyết trình sang PDF/hình ảnh không?

Aspose.Slides cho phép trích xuất một SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) như một vector gốc. Khi [xuất sang PDF](/slides/vi/net/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/net/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; việc SVG gốc được lưu dưới dạng vector được xác nhận qua hành vi trích xuất.