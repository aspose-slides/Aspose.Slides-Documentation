---
title: Chuyển Đổi Các Slide Bản Trình Bày Sang Hình Ảnh trong .NET
linktitle: Slide sang Hình Ảnh
type: docs
weight: 41
url: /vi/net/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang hình ảnh
- lưu slide dưới dạng hình ảnh
- slide sang EMF
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các slide từ các bản trình bày PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng hình ảnh khác trong C# với Aspose.Slides cho .NET."
---
## **Giới thiệu**

Aspose.Slides for .NET có thể tạo hình ảnh các slide riêng lẻ từ các bản trình bày PowerPoint và OpenDocument dưới dạng PNG, JPEG, GIF, TIFF và các định dạng hình ảnh khác.

Để chuyển đổi một slide thành hình ảnh, hãy thực hiện các bước sau:

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Chọn slide mà bạn muốn render.
3. Nếu cần, cấu hình việc render bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/renderingoptions/) hoặc lớp [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/) .
4. Gọi phương thức [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/) . Phương thức này trả về một đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) .
5. Gọi phương thức [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/save/) và chỉ định định dạng đầu ra bằng giá trị [ImageFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/) .

## **Chuyển đổi một Slide sang Ảnh PNG**

Cách chuyển đổi đơn giản nhất sử dụng cài đặt render mặc định. Đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) kết quả có thể được xử lý trong bộ nhớ hoặc lưu vào tệp.

Ví dụ C# sau render slide đầu tiên và lưu nó dưới dạng ảnh PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Chuyển đổi các Slide sang Hình ảnh với Kích thước Tùy chỉnh**

Sử dụng phương thức overload của [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/) nhận một giá trị [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) để render slide với kích thước pixel chính xác.

Ví dụ sau tạo một ảnh JPEG kích thước 1820 × 1040:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Chuyển đổi các Slide có Ghi chú và Bình luận sang Hình ảnh**

Mặc định, hình ảnh slide không bao gồm ghi chú hoặc bình luận. Gán một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/) vào thuộc tính [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) để kiểm soát vị trí xuất hiện của ghi chú và bình luận.

Ví dụ dưới đây đặt ghi chú bị cắt ngắn ở dưới slide và bình luận ở phía bên phải:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Đối với việc chuyển đổi slide sang hình ảnh, không đặt thuộc tính [NotesPosition](https://reference.aspose.com/slides/vi/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) thành [BottomFull](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notespositions/). Ghi chú có thể chứa nhiều văn bản hơn kích thước hình ảnh cố định có thể chứa. Hãy sử dụng [BottomTruncated](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notespositions/) thay thế.
{{% /alert %}}

## **Chuyển đổi Slide sang Hình ảnh bằng Tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của ảnh TIFF được render.

Ví dụ sau render slide đầu tiên dưới dạng ảnh TIFF kích thước 2160 × 2880 với độ phân giải 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Chuyển đổi Tất cả các Slide sang Hình ảnh**

Duyệt qua collection slide để chuyển đổi toàn bộ bản trình bày thành một loạt hình ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách rõ ràng.

Ví dụ dưới đây render mọi slide thành ảnh JPEG với hệ số tỷ lệ ngang và dọc là 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Tạo Đầu ra Metafile Nâng cao**

Enhanced Metafile (EMF) hữu ích khi đồ họa dựa trên vector cần được trao đổi với Microsoft Office hoặc các ứng dụng Windows khác hỗ trợ metafile Windows. Khác với hình ảnh dựa trên pixel, EMF có thể giữ lại các thao tác vẽ vector mà khi phóng to không mất độ sắc nét. Tuy nhiên, EMF chủ yếu là một định dạng tương thích cho các ứng dụng có hỗ trợ metafile Windows, không phải là định dạng trao đổi chung. Ngoài ra, nội dung slide phức tạp, chẳng hạn như hình ảnh bitmap và một số hiệu ứng, có thể được lưu dưới dạng các phần tử rasterized bên trong container metafile vector.

### **Xuất một Slide sang EMF**

Phương thức [ISlide.WriteAsEmf](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/writeasemf/) ghi một [ISlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/) vào một stream đích ở định dạng EMF. Ví dụ sau tải một bản trình bày, chọn slide đầu tiên và ghi nó vào một stream file EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

Người gọi sở hữu stream được truyền vào [ISlide.WriteAsEmf](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/writeasemf/) và phải đóng hoặc giải phóng nó. Aspose.Slides ghi tại vị trí hiện tại của stream và để stream mở.

### **Chuyển đổi Hình ảnh SVG sang EMF và Thêm vào Bản trình bày**

Sử dụng [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/writeasemf/) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bản trình bày thông qua [IImageCollection.AddImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection/addimage/) và đặt lên slide bằng [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addpictureframe/).

Ví dụ dưới đây tạo một [SvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/svgimage/) từ markup SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile vào slide đầu tiên và lưu bản trình bày:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/writeasemf/) không lấy quyền sở hữu stream đích. Sau khi ghi, vị trí của stream nằm ở cuối dữ liệu đã tạo. Đặt lại `Position` về đầu trước khi truyền cùng một stream có thể seek được cho bộ đọc, như đã chỉ ra ở trên. Giữ stream mở cho đến khi người tiêu dùng hoàn thành việc đọc, và sau đó giải phóng nó. Ngoài ra, gọi `ToArray` và truyền mảng byte trả về cho [IImageCollection.AddImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection/addimage/) ; `ToArray` trả về toàn bộ bộ đệm bất kể vị trí hiện tại của stream.

Việc tạo EMF khả dụng trên các hệ điều hành được hỗ trợ bởi bản build Aspose.Slides for .NET đã chọn, nhưng quá trình render có thể khác nhau giữa các nền tảng khi thiếu phông chữ hoặc các phụ thuộc đồ họa gốc. Cài đặt các phông chữ được sử dụng trong nội dung nguồn hoặc cấu hình các thay thế phù hợp, tuân theo [platform requirements](/slides/vi/net/system-requirements/) cho gói Aspose.Slides của bạn, và xác minh kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng Linux và macOS thường có hỗ trợ hạn chế hoặc không đồng nhất trong việc hiển thị và chỉnh sửa metafile Windows.

## **Render Emoji Màu**

{{% alert title="Note" color="info" %}}
Để render emoji màu đúng cách khi chuyển đổi slide của bản trình bày sang hình ảnh, các phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện việc chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** và phông chữ này thiếu, emoji có thể hiển thị dưới dạng đơn sắc trong các hình ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide với hoạt ảnh không?**

Không. Phương thức [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/) render một hình ảnh tĩnh của slide và không xuất hoạt ảnh.

**Có thể xuất các slide ẩn dưới dạng hình ảnh không?**

Có. Các slide ẩn có thể được render như các slide thường. Bao gồm chúng trong vòng xử lý, như đã minh họa trong ví dụ ở trên.

**Các bóng và các hiệu ứng khác có được bảo tồn trong hình ảnh slide không?**

Có. Aspose.Slides render các bóng, độ trong suốt và các hiệu ứng đồ họa hỗ trợ khác trong hình ảnh slide.