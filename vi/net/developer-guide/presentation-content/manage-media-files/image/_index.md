---
title: Tối ưu hoá Quản lý Hình ảnh trong Bản trình bày trên .NET
linktitle: Quản lý Hình ảnh
type: docs
weight: 10
url: /vi/net/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thêm bitmap
- thay thế hình ảnh
- thay thế ảnh
- từ web
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- tài nguyên SVG bên ngoài
- bộ giải quyết SVG
- hình SVG liên kết
- phông chữ SVG
- thêm EMF
- thêm WMF
- thêm TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tối ưu hoá quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho .NET, nâng cao hiệu suất và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bản trình bày trở nên hấp dẫn và thu hút hơn. Trong Microsoft PowerPoint, bạn có thể chèn hình ảnh vào các slide từ tệp, internet hoặc các nguồn khác. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide của bản trình bày theo nhiều cách.

{{% alert  title="Tip" color="info" %}} 
Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép bạn nhanh chóng tạo bản trình bày từ hình ảnh. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Nếu bạn muốn thêm một hình ảnh dưới dạng khung ảnh—đặc biệt nếu bạn dự định thay đổi kích thước, áp dụng hiệu ứng hoặc sử dụng các tùy chọn định dạng chuẩn khác—xem [Picture Frame](/slides/vi/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/vi/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/vi/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/vi/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/vi/net/conversion/png-to-svg/), và [SVG to PNG](https://products.aspose.com/slides/vi/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides hỗ trợ các hình ảnh ở các định dạng phổ biến như JPEG, PNG, BMP, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Được Lưu Trữ Cục Bộ Vào Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh được lưu trên máy tính của mình vào một slide trong bản trình bày. Đoạn mã mẫu C# sau cho thấy cách thêm hình ảnh vào slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Thêm Hình Ảnh Từ Web Vào Slide**

Nếu hình ảnh bạn muốn thêm vào slide không được lưu trên máy tính, bạn có thể thêm trực tiếp từ web. 

Đoạn mã mẫu C# sau cho thấy cách thêm hình ảnh từ web vào slide:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master lưu trữ và kiểm soát thông tin như giao diện và bố cục cho các slide sử dụng nó. Khi bạn thêm hình ảnh vào slide master, hình ảnh sẽ xuất hiện trên mọi slide dựa trên master đó. 

Đoạn mã mẫu C# sau cho thấy cách thêm hình ảnh vào slide master:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Thêm Hình Ảnh Là Nền Cho Slide**

Bạn có thể sử dụng một hình ảnh làm nền cho một hoặc nhiều slide. Để biết chi tiết, xem *[Setting Images as Backgrounds for Slides](/slides/vi/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bản Trình Bày**

Nội dung SVG có thể được thêm vào bản trình bày bằng lớp [SvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/svgimage/). Đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) được tạo ra sau đó có thể được thêm vào bộ sưu tập hình ảnh của bản trình bày và dùng để tạo khung ảnh. 

Ví dụ C# sau nhập một chuỗi SVG tự chứa. Tất cả hình ảnh, kiểu dáng và các tài nguyên khác được SVG sử dụng đều được nhúng trực tiếp trong nội dung SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Nhập Nội Dung SVG Với Các Tài Nguyên Bên Ngoài**

Các tệp SVG xuất ra từ công cụ thiết kế, trình chỉnh sửa sơ đồ, hệ thống biểu tượng và quy trình web có thể tham chiếu đến các tài nguyên được lưu bên ngoài tài liệu SVG. Ví dụ, một SVG có thể chứa liên kết hình ảnh như `images/photo.png`, một giá trị CSS `url(...)`, hoặc một URL font. 

Để nhập nội dung SVG như vậy, tạo một triển khai [IExternalResourceResolver](https://reference.aspose.com/slides/vi/net/aspose.slides.import/iexternalresourceresolver/) và truyền nó cùng với một base URI cho một hàm khởi tạo `SvgImage` thích hợp. Base URI xác định vị trí của tài liệu SVG và được dùng để giải quyết các liên kết tương đối. 

Giao diện [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) cung cấp quyền truy cập thông tin về SVG đã nhập:

- `SvgContent` trả về markup SVG dưới dạng chuỗi.  
- `SvgData` trả về nội dung SVG dưới dạng mảng byte.  
- `BaseUri` trả về base URI được dùng cho các liên kết tương đối.  
- `ExternalResourceResolver` trả về bộ giải quyết được gán cho hình ảnh SVG.  

### **Thực Hiện Bộ Giải Quyết Tài Nguyên Bên Ngoài**

Bộ giải quyết có hai phương thức:

- `[ResolveUri](https://reference.aspose.com/slides/vi/net/aspose.slides.import/iexternalresourceresolver/resolveuri/)` kết hợp base URI và một liên kết tài nguyên tương đối và trả về URI tuyệt đối. Trả về `null` khi không thể giải quyết liên kết hoặc không được phép.  
- `[GetEntity](https://reference.aspose.com/slides/vi/net/aspose.slides.import/iexternalresourceresolver/getentity/)` trả về một stream có thể đọc được cho một URI tài nguyên tuyệt đối. Trả về `null` khi tài nguyên bị thiếu, bị chặn hoặc không khả dụng. Một stream dự phòng cũng có thể được trả về khi thích hợp.  

Bộ giải quyết sau chỉ tải các tài nguyên liên kết từ thư mục cục bộ được phép. Các tài nguyên mạng và đường dẫn ngoài thư mục cho phép sẽ bị chặn. Một hình ảnh dự phòng tùy chọn sẽ được trả về cho các liên kết hình ảnh không thể giải quyết.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Bộ giải quyết này cố ý chỉ cho phép các tệp cục bộ.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Chỉ sử dụng dự phòng cho tài nguyên hình ảnh. Trả về một luồng hình ảnh
        // đối với phông chữ hoặc stylesheet bị thiếu sẽ không hợp lệ.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Giải Quyết Các Tài Nguyên Liên Kết Khi Nhập SVG**

Giả sử `assets/diagram.svg` chứa một tham chiếu tương đối như:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ví dụ C# sau truyền URI của tệp SVG làm base URI và cung cấp một bộ giải quyết tùy chỉnh. Bộ giải quyết chuyển đổi liên kết hình ảnh tương đối thành URI tuyệt đối và trả về một stream chứa tài nguyên liên kết trong khi Aspose.Slides xử lý SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// URI cơ sở đại diện cho vị trí của tài liệu SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage cung cấp nội dung nguồn, dữ liệu nhị phân, URI cơ sở và bộ giải quyết.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

Lớp `SvgImage` cũng cung cấp các overload cho phép nhận dữ liệu SVG dưới dạng mảng byte hoặc stream, cùng với một bộ giải quyết tài nguyên bên ngoài và một base URI.

{{% alert title="Important" color="warning" %}}
Bộ giải quyết tài nguyên làm cho các tài nguyên bên ngoài có sẵn trong khi Aspose.Slides xử lý và hiển thị SVG. Nó không thay đổi markup SVG gốc hoặc tự động nhúng các tài nguyên đã giải quyết vào đó.  

Khi một `ISvgImage` được thêm vào bộ sưu tập hình ảnh của bản trình bày, tệp PPTX có thể chứa cả biểu diễn SVG gốc và một hình raster dự phòng. Một tài nguyên liên kết có thể xuất hiện trong hình dự phòng được tạo ra trong khi một liên kết tương đối như `images/photo.png` vẫn giữ nguyên trong SVG đã lưu. Do đó, ứng dụng hiển thị biểu diễn SVG gốc có thể bỏ qua nội dung liên kết khi tài nguyên bên ngoài gốc không khả dụng.  
{{% /alert %}}

### **Tạo Hình Ảnh SVG Có Thể Mang Theo**

Để tạo một hình ảnh SVG không phụ thuộc vào các tệp bên ngoài, làm cho SVG tự chứa trước khi tạo `SvgImage`. Ví dụ, thay thế các URL hình ảnh liên kết bằng URI `data:` chứa dữ liệu hình ảnh:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Sau khi tất cả các tài nguyên cần thiết đã được nhúng vào nội dung SVG, tạo `SvgImage`, thêm nó vào bộ sưu tập hình ảnh của bản trình bày và chèn vào khung ảnh như trong ví dụ trước.  

### **Xử Lý Các Tài Nguyên Thiếu Hoặc Bị Chặn**

Trả về `null` từ `ResolveUri` khi URI tài nguyên không hợp lệ, bị cấm hoặc không thể giải quyết. Trả về `null` từ `GetEntity` khi tài nguyên không thể đọc được. Aspose.Slides tiếp tục xử lý SVG mà không có tài nguyên đó khi có thể.  

Một stream dự phòng có thể được trả về cho tài nguyên thiếu, nhưng nội dung của nó phải tương thích với loại tài nguyên yêu cầu. Ví dụ, chỉ trả về stream hình ảnh cho hình ảnh bị thiếu, không phải cho font hoặc stylesheet.  

{{% alert title="Security" color="warning" %}}
Không giải quyết các đường dẫn tệp tùy ý hoặc URL mạng không giới hạn từ các tệp SVG không đáng tin cậy. Hạn chế các scheme, thư mục và host được phép. Đối với tài nguyên mạng, cũng cần áp dụng timeout kết nối, giới hạn kích thước phản hồi và kiểm tra nội dung.  
{{% /alert %}}

## **Chuyển Đổi SVG Thành Một Tập Hình Dạng**
Aspose.Slides có thể chuyển đổi SVG thành một tập các hình dạng, tương tự như chức năng tương ứng trong PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một overload của phương thức [AddGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/addgroupshape/methods/1) của giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection) nhận đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage) làm đối số đầu tiên.  

Đoạn mã mẫu C# sau cho thấy cách sử dụng phương thức này để chuyển đổi tệp SVG thành một tập các hình dạng:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Tên tệp SVG nguồn
string svgFileName = "sample.svg";

// Tên tệp bản trình bày đầu ra
string outPptxPath = "presentation.pptx";

// Tạo một bản trình bày mới
using (IPresentation presentation = new Presentation())
{
    // Đọc nội dung tệp SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Tạo một đối tượng SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Lấy kích thước slide
    SizeF slideSize = presentation.SlideSize.Size;

    // Chuyển đổi hình ảnh SVG thành một nhóm các hình dạng và co giãn tới kích thước slide
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Lưu bản trình bày ở định dạng PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**
Aspose.Slides cho .NET cho phép bạn tạo hình ảnh EMF từ các trang tính Excel bằng Aspose.Cells và thêm chúng vào các slide của bản trình bày.

Đoạn mã mẫu C# sau cho thấy cách thực hiện điều này:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Lưu workbook vào một luồng
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**
Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của bản trình bày, bao gồm các hình ảnh được các hình dạng slide sử dụng. Phần này mô tả một số cách để cập nhật hình ảnh trong bộ sưu tập. Bạn có thể thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải tệp bản trình bày chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).  
2. Tải một hình ảnh mới từ tệp vào một mảng byte.  
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.  
4. Trong cách thứ hai, tải hình ảnh vào đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/), và thay thế hình ảnh mục tiêu bằng đối tượng này.  
5. Trong cách thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bản trình bày.  
6. Ghi bản trình bày đã sửa đổi thành tệp PPTX.  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo một đối tượng Presentation đại diện cho tệp bản trình bày.
using Presentation presentation = new Presentation("sample.pptx");

// Cách đầu tiên.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Cách thứ hai.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Cách thứ ba.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Lưu bản trình bày vào tệp.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
Với trình chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt ảnh cho văn bản và tạo GIF từ văn bản. 
{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Độ phân giải gốc của hình ảnh có được giữ nguyên sau khi chèn không?**  
Có. Các pixel gốc được bảo lưu, nhưng kết quả cuối cùng phụ thuộc vào cách [picture](/slides/vi/net/picture-frame/) được phóng to/thu nhỏ trên slide và bất kỳ quá trình nén nào được áp dụng khi lưu.  

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng lúc là gì?**  
Đặt logo trên slide master hoặc layout và thay thế nó trong bộ sưu tập hình ảnh của bản trình bày—các cập nhật sẽ lan truyền tới mọi thành phần sử dụng tài nguyên đó.  

**Một SVG đã chèn có thể được chuyển đổi thành các hình dạng có thể chỉnh sửa không?**  
Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó các phần riêng lẻ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn.  

**Làm sao để đặt một hình ảnh làm nền cho nhiều slide cùng lúc?**  
[Gán hình ảnh làm nền](/slides/vi/net/presentation-background/) trên slide master hoặc layout tương ứng—bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.  

**Làm sao để ngăn một bản trình bày trở nên quá lớn vì có quá nhiều hình ảnh?**  
Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi cần.