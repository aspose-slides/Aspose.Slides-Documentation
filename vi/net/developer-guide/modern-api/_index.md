---
title: Nâng cao Xử lý Hình ảnh với API Hiện đại
linktitle: API Hiện đại
type: docs
weight: 237
url: /vi/net/modern-api/
keywords:
- System.Drawing
- API hiện đại
- vẽ
- hình thu nhỏ slide
- slide sang ảnh
- hình thu nhỏ shape
- shape sang ảnh
- hình thu nhỏ bản trình bày
- bản trình bày sang ảnh
- thêm ảnh
- thêm hình
- .NET
- C#
- Aspose.Slides
description: "Hiện đại hóa việc xử lý hình ảnh slide bằng cách thay thế các API hình ảnh đã lỗi thời bằng .NET Modern API để tự động hoá PowerPoint và OpenDocument một cách liền mạch."
---
## **Giới thiệu**

Lịch sử, Aspose Slides phụ thuộc vào System.Drawing và trong API công cộng có các lớp sau từ đó:
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

Kể từ phiên bản 24.4, API công cộng này được khai báo là đã lỗi thời.

Vì hỗ trợ System.Drawing trong các phiên bản .NET6 trở lên đã bị loại bỏ cho các nền tảng không phải Windows ([thay đổi đáng chú ý](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides đã triển khai cách tiếp cận hai gói:
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – hỗ trợ .NET6+ cho Windows, .NETStandard cho Windows/Linux/MacOS, .NETFramework 2+ (Windows).  
  - có phụ thuộc vào [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – phiên bản Windows/Linux/MacOS không có phụ thuộc.

Nhược điểm của [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) là nó thực hiện một phiên bản riêng của System.Drawing trong cùng namespace (để hỗ trợ tương thích ngược với API công cộng). Do đó, khi Aspose.Slides.NET6.CrossPlatform và System.Drawing từ .NET Framework hoặc gói System.Drawing.Common được dùng đồng thời, sẽ xảy ra xung đột tên nếu không sử dụng alias.

Để loại bỏ phụ thuộc vào System.Drawing trong gói Aspose.Slides.NET chính, chúng tôi đã thêm cái gọi là “Modern API” – tức là API nên được dùng thay cho API đã lỗi thời, các chữ ký của nó chứa các kiểu sau từ System.Drawing: [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) và [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) và [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) được khai báo là đã lỗi thời và hỗ trợ của chúng đã bị loại bỏ khỏi API công cộng của Slides.

Trong các phiên bản hiện tại, hãy xem API công cộng phụ thuộc vào System.Drawing như là di sản/đã lỗi thời. Sử dụng Modern API cho mã mới và khi di chuyển các quy trình xử lý ảnh hiện có.

## **API hiện đại**

Đã thêm các lớp và enum sau vào API công cộng:

- [Aspose.Slides.IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) – đại diện cho ảnh raster hoặc vector.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/) – đại diện cho định dạng tệp của ảnh.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/vi/net/aspose.slides/images/) – các phương thức để tạo và làm việc với giao diện [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/).

Lưu ý rằng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) là disposable (nó triển khai giao diện [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) và việc sử dụng nên được bao trong using hoặc giải phóng theo cách thuận tiện khác).

Sử dụng `GetImage` để render một slide hoặc shape duy nhất. Sử dụng `GetImages` để render nhiều slide của bản trình bày. Dùng các phương thức của [Images](https://reference.aspose.com/slides/vi/net/aspose.slides/images/) để tải ảnh, `AddImage` với [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) để thêm chúng vào bản trình bày, và `ReplaceImage` với [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) để cập nhật ảnh đã có trong bản trình bày.

Một kịch bản điển hình khi sử dụng API mới có thể trông như sau:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // khởi tạo một đối tượng IImage có thể giải phóng từ tệp trên đĩa.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // tạo một ảnh PowerPoint bằng cách thêm một đối tượng IImage vào bộ sưu tập ảnh của bản trình bày.
        ppImage = pres.Images.AddImage(image);
    }

    // thêm một hình ảnh dạng shape trên slide #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // lấy một đối tượng IImage đại diện cho slide #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // lưu ảnh vào đĩa.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## **Thay thế mã cũ bằng Modern API**

Để dễ chuyển đổi, giao diện của [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) mới lặp lại các chữ ký riêng của các lớp [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) và [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). Nói chung, bạn chỉ cần thay thế lời gọi tới phương thức cũ sử dụng System.Drawing bằng lời gọi mới.

### **Lấy hình thu nhỏ của Slide**

API di sản/đã lỗi thời:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Lấy hình thu nhỏ của Shape**

API di sản/đã lỗi thời:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Lấy hình thu nhỏ của Presentation**

API di sản/đã lỗi thời:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### **Thêm ảnh vào Presentation**

API di sản/đã lỗi thời:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

Modern API:

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

## **Phương thức/Tài sản đã lỗi thời và thay thế trong Modern API**

### **Presentation**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Không có thay thế Modern API |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Không có thay thế Modern API |
| public void Print() | Không có thay thế Modern API |
| public void Print(PrinterSettings printerSettings) | Không có thay thế Modern API |
| public void Print(string printerName) | Không có thay thế Modern API |
| public void Print(PrinterSettings printerSettings, string presName) | Không có thay thế Modern API |

### **Shape**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Không có thay thế Modern API |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Không có thay thế Modern API |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Không có thay thế Modern API |

### **Output**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/vi/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/vi/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/vi/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Chữ ký phương thức/tài sản | Chữ ký phương thức thay thế |
|----------------------------|-----------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/vi/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/vi/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/vi/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/vi/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Chữ ký phương thức | Chữ ký phương thức thay thế |
|--------------------|-----------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/vi/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Hỗ trợ API cho Graphics và PrinterSettings**

Lớp [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) không được hỗ trợ cho các phiên bản .NET6 trở lên đa nền tảng. Trong Aspose Slides, hãy dùng các phương thức render ảnh của Modern API thay vì API render tới [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics):
[ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/rendertographics/#rendertographics_5)

Ngoài ra, API liên quan tới việc in qua [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) không có thay thế Modern API trực tiếp:

[IPresentation](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/print/#print_2)

## **Câu hỏi thường gặp**

**Tại sao [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) bị loại bỏ?**

Hỗ trợ cho [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) đã bị lỗi thời trong API công cộng để thống nhất công việc render và ảnh, loại bỏ các phụ thuộc vào nền tảng cụ thể, và chuyển sang cách tiếp cận đa nền tảng với [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/). Hãy dùng `GetImage` hoặc `GetImages` thay vì render tới [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

**Lợi ích thực tế của [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) so với [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) là gì?**

[IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) thống nhất việc làm việc với cả ảnh raster và vector, đơn giản hoá việc lưu ở nhiều định dạng qua [ImageFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/), giảm phụ thuộc vào `System.Drawing`, và làm cho mã dễ di chuyển giữa các môi trường.

**Modern API có ảnh hưởng đến hiệu suất tạo thumbnail không?**

Việc chuyển từ `GetThumbnail` sang `GetImage` không làm giảm hiệu suất trong các kịch bản: các phương thức mới cung cấp cùng khả năng tạo ảnh với các tùy chọn và kích thước, đồng thời vẫn hỗ trợ các tùy chọn render. Lợi ích hoặc giảm hiệu suất cụ thể tùy thuộc vào tình huống, nhưng về chức năng các thay thế là tương đương.