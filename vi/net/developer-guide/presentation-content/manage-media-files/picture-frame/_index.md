---
title: Quản lý Khung Hình trong Bản Trình Chiếu bằng .NET
linktitle: Khung Hình
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
- tỷ lệ khía cạnh
- độ trong suốt hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thêm khung hình vào các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET. Tinh giản quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa một hình ảnh — giống như một bức tranh trong khung.

Bạn có thể thêm hình ảnh vào một slide thông qua khung hình. Bằng cách này, bạn định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert title="Mẹo" color="primary" %}} 
Aspose cung cấp các bộ chuyển đổi miễn phí — [JPEG sang PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG sang PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt) — cho phép người dùng tạo nhanh các bản trình chiếu từ hình ảnh. 
{{% /alert %}} 

## **Tạo Khung Hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
4. Xác định độ rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe) dựa trên độ rộng và chiều cao của hình ảnh thông qua phương thức `AddPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm một khung hình (chứa hình ảnh) vào slide.
7. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```c#
 // Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX
 using (Presentation pres = new Presentation())
 {
     // Lấy slide đầu tiên
     ISlide slide = pres.Slides[0];

     // Tải một hình ảnh và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = pres.Images.AddImage(image);
     image.Dispose();

     // Thêm một khung hình với chiều cao và chiều rộng bằng nhau
     IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

     // Áp dụng một số định dạng cho khung hình
     pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
     pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
     pictureFrame.LineFormat.Width = 20;
     pictureFrame.Rotation = 45;

     // Ghi bản trình chiếu ra tệp PPTX
     pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
 }
```

{{% alert color="warning" %}} 
Khung hình cho phép bạn nhanh chóng tạo các slide trình chiếu dựa trên hình ảnh. Khi kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể điều khiển các thao tác nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể muốn xem các trang này: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/net/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/net/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/net/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/net/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/net/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Tạo Khung Hình với Tỷ Lệ Tương Đối**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
5. Xác định độ rộng và chiều cao tương đối của hình ảnh trong khung hình.
6. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```c#
 // Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX
 using (Presentation presentation = new Presentation())
 {
     // Tải một hình ảnh và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     // Thêm một khung hình vào slide
     IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

     // Đặt tỷ lệ tương đối cho chiều rộng và chiều cao
     pictureFrame.RelativeScaleHeight = 0.8f;
     pictureFrame.RelativeScaleWidth = 1.35f;

     // Lưu bản trình chiếu
     presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
 }
```

## **Trích Xuất Hình Ảnh Raster từ Khung Hình**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu "sample.pptx" và lưu nó ở định dạng PNG.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Trích Xuất Hình Ảnh SVG từ Khung Hình**

Khi một bản trình chiếu chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/), Aspose.Slides cho .NET cho phép bạn lấy lại các hình ảnh vector gốc với độ chính xác đầy đủ. Bằng việc duyệt bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) nền có chứa nội dung SVG hay không, sau đó lưu hình ảnh đó vào đĩa hoặc stream ở định dạng SVG gốc.

Ví dụ mã sau minh họa cách trích xuất một hình ảnh SVG từ một khung hình:

```cs
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

## **Lấy Độ Trong Suất của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Đoạn mã C# này minh họa thao tác:

```c#
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

## **Lấy Độ Sáng và Độ Tương Phản của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng độ sáng và độ tương phản được áp dụng cho một hình ảnh. Giao diện [ILuminance](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/iluminance/) đại diện cho hiệu ứng biến đổi này của hình ảnh.

Đoạn mã C# này minh họa cách lấy cài đặt độ sáng và độ tương phản từ một khung hình:

```csharp
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

{{% alert color="primary" %}} 
Tất cả các hiệu ứng được áp dụng cho hình ảnh có thể tìm thấy trong [Aspose.Slides.Effects](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/). 
{{% /alert %}}

## **Định Dạng Khung Hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Sử dụng các tùy chọn này, bạn có thể thay đổi khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) . 
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm một hình ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
4. Xác định độ rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên độ rộng và chiều cao của hình ảnh thông qua phương thức [AddPictureFrame](http://www.aspose.com/api/net/slides/vi/aspose.slides/ishapecollection/methods/addpictureframe) được cung cấp bởi đối tượng [IShapes](http://www.aspose.com/api/net/slides/vi/aspose.slides/ishapecollection) liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Đặt màu viền của khung hình.
8. Đặt độ rộng viền của khung hình.
9. Xoay khung hình bằng cách đưa cho nó một giá trị dương hoặc âm.
   * Giá trị dương sẽ xoay hình ảnh theo chiều kim đồng hồ. 
   * Giá trị âm sẽ xoay hình ảnh ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa hình ảnh) vào slide.
11. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```c#
// Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide slide = presentation.Slides[0];

    // Tải một hình ảnh và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu
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

    // Ghi bản trình chiếu ra tệp PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 
Aspose gần đây đã phát triển một công cụ [Collage Maker miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [ghép JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, [tạo lưới ảnh từ các bức ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 
{{% /alert %}}

## **Thêm Hình Ảnh dưới Dạng Liên Kết**

Để tránh kích thước bản trình chiếu quá lớn, bạn có thể thêm hình ảnh (hoặc video) thông qua các liên kết thay vì nhúng tệp trực tiếp vào bản trình chiếu. Đoạn mã C# này cho thấy cách thêm một hình ảnh và video vào một placeholder:

```c#
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

## **Cắt Hình Ảnh**

Đoạn mã C# này cho thấy cách cắt một hình ảnh hiện có trên một slide:

```c#
using (Presentation presentation = new Presentation())
{
    // Tạo một đối tượng hình ảnh mới
    IImage image = Images.FromFile(imagePath);
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

## **Xóa Các Vùng Đã Cắt của Hình Ảnh**

Nếu bạn muốn xóa các vùng đã cắt của một hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu không cần cắt.

```c#
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

{{% alert title="LƯU Ý" color="warning" %}} 
Phương thức [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) sẽ thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của bản trình chiếu. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) đã xử lý, thiết lập này có thể giảm kích thước bản trình chiếu. Ngược lại, số lượng hình ảnh trong bản trình chiếu sẽ tăng.

Phương thức này chuyển đổi các metafile WMF/EMF sang hình ảnh PNG raster trong quá trình cắt. 
{{% /alert %}}

## **Nén Hình Ảnh**

Bạn có thể nén một hình ảnh trong bản trình chiếu bằng cách sử dụng phương thức [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/compressimage/). Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format → Compress Pictures → Resolution** của PowerPoint.

Các ví dụ C# sau đây minh họa cách nén một hình ảnh trong bản trình chiếu bằng cách chỉ định độ phân giải mục tiêu và tùy chọn loại bỏ các vùng đã cắt:

```csharp
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

Hoặc sử dụng trực tiếp một giá trị DPI tùy chỉnh:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Nén hình ảnh thành 150 DPI (độ phân giải web), loại bỏ các vùng đã cắt.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="LƯU Ý" color="warning" %}} 
Phương thức chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI đã cung cấp. Các khu vực đã cắt cũng có thể được xóa để tối ưu hóa kích thước tệp.  
Nếu hình ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ tùy theo độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao. 
{{% /alert %}}

## **Khóa Tỷ Lệ Khung Hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ tỷ lệ khung hình ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng thuộc tính [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframelock/aspectratiolocked/) để đặt cài đặt *Lock Aspect Ratio*.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Đặt hình dạng để bảo toàn tỷ lệ khung hình khi thay đổi kích thước
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="LƯU Ý" color="warning" %}} 
Cài đặt *Lock Aspect Ratio* này chỉ bảo tồn tỷ lệ khung hình chứ không phải hình ảnh bên trong. 
{{% /alert %}}

## **Sử Dụng Thuộc Tính StretchOffset**

Sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetright) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat), bạn có thể chỉ định một hình chữ nhật lấp đầy.

Khi xác định việc kéo giãn cho một hình ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để khớp với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được định nghĩa bằng một phần trăm offset so với cạnh tương ứng của hộp bao quanh hình dạng. Một phần trăm dương chỉ ra việc thu hẹp, trong khi một phần trăm âm chỉ ra việc mở rộng.

1. Tạo một thể hiện của [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) . 
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh. 
5. Đặt loại lấp đầy cho hình dạng. 
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng. 
7. Thêm một hình ảnh đã đặt để lấp đầy hình dạng. 
8. Chỉ định offset của hình ảnh từ cạnh tương ứng của hộp bao quanh hình dạng 
9. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX. 

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Đặt hình ảnh kéo giãn từ mỗi phía trong phần thân hình dạng
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **Câu Hỏi Thường Gặp**

**Làm sao tôi có thể biết những định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của công cụ chuyển đổi slide và hình ảnh.

**Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?**

Nhúng hình ảnh lớn làm tăng kích thước tệp và sử dụng bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản trình chiếu nhưng yêu cầu các tệp bên ngoài vẫn phải truy cập được. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao tôi có thể khóa một đối tượng hình ảnh tránh việc di chuyển/đổi kích thước ngoài ý muốn?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/pictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) (ví dụ, vô hiệu hóa di chuyển hoặc thay đổi kích thước). Cơ chế khóa được mô tả cho các hình dạng trong một [bài viết bảo vệ](/slides/vi/net/applying-protection-to-presentation/) riêng và được hỗ trợ cho nhiều loại hình dạng, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/).

**Độ chính xác vector SVG có được bảo lưu khi xuất bản trình chiếu sang PDF/hình ảnh không?**

Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame] như vector gốc. Khi [xuất sang PDF](/slides/vi/net/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/net/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy vào cài đặt xuất; thực tế SVG gốc được lưu dưới dạng vector được xác nhận qua hành vi trích xuất.