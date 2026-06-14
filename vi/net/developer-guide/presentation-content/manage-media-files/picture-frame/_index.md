---
title: Quản lý khung hình trong bản trình bày bằng .NET
linktitle: Khung hình
type: docs
weight: 10
url: /vi/net/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- thêm ảnh
- tạo ảnh
- trích xuất ảnh
- ảnh raster
- ảnh vector
- cắt ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- trong suốt ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Thêm khung hình vào các bản trình bày PowerPoint và OpenDocument với Aspose.Slides cho .NET. Tinh giản quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa ảnh—giống như một bức tranh trong khung.  

Bạn có thể thêm ảnh vào một slide thông qua khung hình. Bằng cách này, bạn có thể định dạng ảnh bằng cách định dạng khung hình.

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bản trình bày nhanh chóng từ ảnh. 

{{% /alert %}} 

## **Tạo Khung Hình**

1. Tạo một thể hiện của lớp [Presentation ](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation)class. 
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) được liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng. 
4. Xác định chiều rộng và chiều cao của ảnh. 
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe) dựa trên chiều rộng và chiều cao của ảnh thông qua phương thức `AddPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu. 
6. Thêm khung hình (chứa hình ảnh) vào slide. 
7. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX. 

Đoạn mã C# này cho bạn thấy cách tạo một khung hình:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation pres = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide slide = pres.Slides[0];

    // Tải ảnh và thêm nó vào bộ sưu tập ảnh của bản trình bày
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

    // Ghi bản trình bày ra tệp PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Khung hình cho phép bạn nhanh chóng tạo các slide trình bày dựa trên ảnh. Khi kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các hoạt động nhập/xuất để chuyển đổi ảnh từ định dạng này sang định dạng khác. Bạn có thể muốn xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/net/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/net/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/net/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/net/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/net/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Tạo Khung Hình với Tỷ Lệ Tương Đối**

Bằng cách thay đổi tỷ lệ tương đối của ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation). 
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một ảnh vào bộ sưu tập ảnh của presentation. 
4. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) được liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng. 
5. Xác định chiều rộng và chiều cao tương đối của ảnh trong khung hình. 
6. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX. 

Đoạn mã C# này cho bạn thấy cách tạo một khung hình với tỷ lệ tương đối:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Tải ảnh và thêm nó vào bộ sưu tập ảnh của bản trình bày
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Thêm một khung hình vào slide
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Đặt tỷ lệ chiều rộng và chiều cao tương đối
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Lưu bản trình bày
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Trích Xuất Hình Raster Từ Khung Hình**

Bạn có thể trích xuất các hình raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe) và lưu chúng ở định dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một ảnh từ tài liệu “sample.pptx” và lưu nó dưới dạng PNG.

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

## **Trích Xuất Hình SVG Từ Khung Hình**

Khi một bản trình bày chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/), Aspose.Slides for .NET cho phép bạn lấy lại các hình ảnh vector gốc với độ trung thực đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/), kiểm tra xem [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) nền có chứa nội dung SVG hay không, và sau đó lưu ảnh đó ra đĩa hoặc stream ở định dạng SVG gốc.

Đoạn mã sau minh họa cách trích xuất một ảnh SVG từ một khung hình:

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

## **Lấy Độ Trong Suốt Của Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một ảnh. Đoạn mã C# dưới đây thể hiện thao tác này:

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

{{% alert color="primary" %}} 
Tất cả các hiệu ứng được áp dụng cho ảnh có thể được tìm thấy trong [Aspose.Slides.Effects](https://reference.aspose.com/slides/vi/net/aspose.slides.effects/). 
{{% /alert %}}

## **Định Dạng Khung Hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Bằng các tùy chọn này, bạn có thể thay đổi khung hình để phù hợp với các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) . 
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage) bằng cách thêm ảnh vào [IImagescollection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection) được liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng. 
4. Xác định chiều rộng và chiều cao của ảnh. 
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của ảnh thông qua phương thức [AddPictureFrame](http://www.aspose.com/api/net/slides/vi/aspose.slides/ishapecollection/methods/addpictureframe) được cung cấp bởi đối tượng [IShapes](http://www.aspose.com/api/net/slides/vi/aspose.slides/ishapecollection) liên kết với slide đã tham chiếu. 
6. Thêm khung hình (chứa hình ảnh) vào slide. 
7. Đặt màu đường viền cho khung hình. 
8. Đặt độ rộng đường viền cho khung hình. 
9. Xoay khung hình bằng cách cung cấp giá trị dương hoặc âm. 
   * Giá trị dương sẽ xoay ảnh theo chiều kim đồng hồ. 
   * Giá trị âm sẽ xoay ảnh ngược chiều kim đồng hồ. 
10. Thêm khung hình (chứa hình ảnh) vào slide. 
11. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX. 

Đoạn mã C# này minh họa quá trình định dạng khung hình:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide slide = presentation.Slides[0];

    // Tải ảnh và thêm nó vào bộ sưu tập ảnh của bản trình bày
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Thêm một khung hình với chiều cao và chiều rộng tương đương của ảnh
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Áp dụng một số định dạng cho khung hình
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Ghi bản trình bày ra tệp PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose gần đây đã phát triển một công cụ [free Collage Maker](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [gộp JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, hoặc [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 

{{% /alert %}}

## **Thêm Ảnh Dưới Dạng Liên Kết**

Để tránh kích thước bản trình bày quá lớn, bạn có thể thêm ảnh (hoặc video) qua liên kết thay vì nhúng tệp trực tiếp vào bản trình bày. Đoạn mã C# này cho bạn thấy cách thêm ảnh và video vào một placeholder:

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

## **Cắt Ảnh**

Đoạn mã C# này cho bạn thấy cách cắt một ảnh hiện có trên slide:

```c#
using (Presentation presentation = new Presentation())
{
    // Tạo một đối tượng ảnh mới
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Thêm một PictureFrame vào Slide
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Cắt ảnh (giá trị phần trăm)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Lưu kết quả
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Xóa Các Vùng Đã Cắt Của Ảnh**

Nếu bạn muốn xóa các vùng đã cắt của ảnh chứa trong khung, bạn có thể sử dụng phương thức [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Phương thức này trả về ảnh đã cắt hoặc ảnh gốc nếu không cần cắt.

Đoạn mã C# này minh họa thao tác:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Lấy PictureFrame từ slide đầu tiên
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Xóa các vùng đã cắt của ảnh PictureFrame và trả về ảnh đã cắt
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Lưu kết quả
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) thêm ảnh đã cắt vào bộ sưu tập ảnh của presentation. Nếu ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) đã xử lý, thiết lập này có thể giảm kích thước bản trình bày. Ngược lại, số lượng ảnh trong bản trình bày kết quả sẽ tăng.

Phương thức này chuyển đổi các tệp metafile WMF/EMF sang ảnh raster PNG trong quá trình cắt. 

{{% /alert %}}

## **Nén Ảnh**

Bạn có thể nén một ảnh trong bản trình bày bằng cách sử dụng phương thức [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/compressimage/). Phương thức này nén ảnh bằng cách giảm kích thước dựa trên kích thước của shape và độ phân giải được chỉ định, với tùy chọn xóa các vùng đã cắt. 

Nó điều chỉnh kích thước và độ phân giải của ảnh tương tự như tính năng **Picture Format → Compress Pictures → Resolution** của PowerPoint.

Các ví dụ C# sau đây minh họa cách nén một ảnh trong bản trình bày bằng cách chỉ định độ phân giải mục tiêu và tùy chọn loại bỏ các vùng đã cắt:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Nén ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải web) và xóa các vùng đã cắt.
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

    // Nén ảnh tới 150 DPI (độ phân giải web), loại bỏ các vùng đã cắt.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức chuyển đổi ảnh sang độ phân giải thấp hơn dựa trên kích thước của shape và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu hóa kích thước tệp.  
Nếu ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ tùy theo độ phân giải, tương tự như cách PowerPoint xử lý các JPEG có độ phân giải cao. 

{{% /alert %}}

## **Khóa Tỷ Lệ Khung Hình**

Nếu bạn muốn một shape chứa ảnh giữ nguyên tỷ lệ khung hình ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng thuộc tính [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframelock/aspectratiolocked/) để đặt cài đặt *Lock Aspect Ratio*. 

Đoạn mã C# này cho bạn thấy cách khóa tỷ lệ khung hình của shape:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Đặt shape để giữ tỷ lệ khung hình khi thay đổi kích thước
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Cài đặt *Lock Aspect Ratio* này chỉ bảo lưu tỷ lệ của shape mà không ảnh hưởng đến ảnh bên trong. 

{{% /alert %}}

## **Sử Dụng Thuộc Tính StretchOff**

Bằng cách sử dụng các thuộc tính [StretchOffsetLeft](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetright) và [StretchOffsetBottom](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) từ giao diện [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/picturefillformat), bạn có thể chỉ định một hình chữ nhật lấp đầy. 

Khi kéo dài được chỉ định cho một ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được định nghĩa bằng một phần trăm offset so với cạnh tương ứng của hộp bao của shape. Phần trăm dương biểu thị inset trong khi phần trăm âm biểu thị outset. 

1. Tạo một thể hiện của [Presentation](http://www.aspose.com/api/net/slides/vi/aspose.slides/) class. 
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một ảnh. 
5. Đặt loại lấp đầy cho shape. 
6. Đặt chế độ lấp đầy ảnh cho shape. 
7. Thêm ảnh đã đặt để lấp đầy shape. 
8. Xác định offset ảnh từ cạnh tương ứng của hộp bao của shape 
9. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX. 

Đoạn mã C# này minh họa quy trình sử dụng thuộc tính StretchOff:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Đặt ảnh kéo dãn từ mỗi phía trong thân shape
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **Câu Hỏi Thường Gặp**

**Làm thế nào để biết các định dạng ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và ảnh vector (ví dụ: SVG) thông qua đối tượng ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng với khả năng của động cơ chuyển đổi slide và ảnh.

**Việc thêm hàng chục ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?**

Nhúng ảnh lớn làm tăng kích thước tệp và sử dụng bộ nhớ; liên kết ảnh giúp giữ kích thước bản trình bày nhỏ hơn nhưng yêu cầu các tệp bên ngoài phải luôn có sẵn. Aspose.Slides cung cấp khả năng thêm ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao để khóa một đối tượng ảnh tránh việc di chuyển/đổi kích thước vô tình?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/pictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá di chuyển hoặc đổi kích thước). Cơ chế khóa được mô tả cho các shape trong một [bài viết bảo vệ](/slides/vi/net/applying-protection-to-presentation/) riêng và được hỗ trợ cho nhiều loại shape, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/).

**Độ trung thực của vector SVG có được giữ khi xuất bản trình bày ra PDF/ảnh không?**

Aspose.Slides cho phép trích xuất một SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất ra PDF](/slides/vi/net/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/net/convert-powerpoint-to-png/), kết quả có thể bị raster hoá tùy thuộc vào cài đặt xuất; việc SVG gốc được lưu dưới dạng vector được xác nhận qua hành vi trích xuất.