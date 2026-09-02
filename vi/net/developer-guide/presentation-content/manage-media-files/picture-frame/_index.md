---
title: Quản lý khung ảnh trong các bản trình bày bằng .NET
linktitle: Khung ảnh
type: docs
weight: 10
url: /vi/net/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- hình ảnh nhúng
- hình ảnh liên kết
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh SVG
- cắt hình ảnh
- xóa các khu vực đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình bày với Aspose.Slides cho .NET."
---
## **Tổng quan**

Khung ảnh là một hình dạng trên slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh nhúng thông qua bộ sưu tập [Images](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/images/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) kiểm soát vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các cài đặt cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị hơn một lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/), và sử dụng tài nguyên hình ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa hình ảnh raster như PNG hoặc JPEG và hình ảnh vector SVG. Chúng cũng có thể tham chiếu tới hình ảnh liên kết thay vì lưu trữ byte hình ảnh trong bản trình bày. Lựa chọn này ảnh hưởng đến tính di động, kích thước tệp, khả năng trích xuất và hành vi xuất, vì vậy việc quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu là cần thiết.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình bày và tạo khung ảnh bằng [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addpictureframe/). Hình ảnh trở thành một phần của gói bản trình bày, vì vậy bản trình bày vẫn tự chứa khi di chuyển sang máy tính khác.

Ví dụ sau thêm một hình JPEG, tạo khung ở kích thước gốc của hình và áp dụng định dạng đường viền và xoay:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Khung ảnh kiểm soát hình học hiển thị; thay đổi kích thước khung không làm thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) cung cấp khả năng tỷ lệ chiều rộng và chiều cao tương đối cho khung. Giá trị `1.0` tương ứng với 100 % kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần duy trì mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không thực hiện việc lấy mẫu lại hoặc nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Một hình ảnh nhúng lưu dữ liệu hình ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho tính di động và việc hiển thị dự đoán được. Một hình ảnh liên kết lưu đường dẫn vị trí ngoài thông qua liên kết [ISlidesPicture](https://reference.aspose.com/slides/vi/net/aspose.slides/islidespicture/) thay vì nhúng dữ liệu ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được bởi ứng dụng mở hoặc hiển thị bản trình bày. Nếu đường dẫn thay đổi, tệp bị di chuyển hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình bày phải được gửi email, lưu trữ hoặc hiển thị trong môi trường cách ly, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm hình ảnh Liên kết**

Ví dụ sau tạo một khung ảnh và trỏ tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; liên kết video là một quy trình phương tiện riêng và được cố ý không trộn vào ví dụ này.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Không sử dụng chúng chỉ để thay thế nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường ít hữu ích hơn một bản trình bày lớn tự chứa.

## **Trích xuất Hình ảnh từ Khung ảnh**

Trước khi trích xuất hình ảnh từ bản trình bày hiện có, hãy kiểm tra xem hình dạng thực sự là một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) và nó có chứa hình ảnh nhúng hay không. Các khung ảnh liên kết có thể không chứa byte hình ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình ảnh Raster**

API hình ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) trực tiếp và không yêu cầu wrapper ảnh hệ thống cũ. Ví dụ sau tìm hình raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Lưu qua [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra đã yêu cầu. Nếu bạn cần byte đã mã hoá được lưu trong bản trình bày thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh thay thế.

### **Trích xuất Hình ảnh SVG**

Đối với ảnh SVG, [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Giữ nội dung SVG dưới dạng SVG bảo lưu nguồn vector trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất không nên được xem là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) nhúng khi cần tài nguyên vector gốc.

## **Cắt Hình ảnh**

Cắt thay đổi phần của hình ảnh hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung ảnh một cách an toàn và áp dụng các giá trị cắt:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Vì dữ liệu ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả thi việc hoàn tác, các vùng đã cắt có thể được loại bỏ vật lý như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình ảnh Đã Cắt**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) loại bỏ dữ liệu ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình bày được lưu, các pixel đã xóa sẽ không còn khả dụng cho thao tác hủy cắt sau này.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình bày. Nếu hình ảnh gốc cũng được các khung ảnh khác sử dụng, các khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các khu vực đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả cắt thành PNG.

## **Nén Hình ảnh Raster**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/compressimage/) giảm độ phân giải raster so với kích thước hiển thị của ảnh. Nó cũng có thể loại bỏ các khu vực đã cắt trong cùng một thao tác. Phương thức trả về `true` khi ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/net/aspose.slides.export/picturescompression/) đã định nghĩa trước khi độ phân giải mục tiêu chuẩn là đủ:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Một giá trị DPI dương tùy chỉnh có thể được truyền thay cho giá trị enum khi cần mục tiêu cụ thể.

Nén được thiết kế cho hình ảnh raster. Nội dung SVG và metafile không bị giảm bằng quy trình nén raster này. Cũng nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình bày đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình ảnh thực sự sẽ được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Quản lý Hiệu ứng Biến đổi Hình ảnh**

Để xem quy trình hoàn chỉnh bao gồm độ sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác minh vòng lặp, tham khảo [Image Transform Effects](/slides/vi/net/image-transform-effects/).

## **Khóa Hình học Khung ảnh**

Cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa bị vô hiệu hoá cho một khung ảnh. Ví dụ, khóa tỷ lệ duy trì tỉ lệ hình dạng khi thay đổi kích thước.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc hình ảnh nguồn phải được lấy mẫu lại hoặc luôn thay đổi tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Phần trăm dương tạo một lề vào từ cạnh, trong khi phần trăm âm tạo một lề ra.

Điều này khác với cắt. Các giá trị cắt chọn phần nào của ảnh nguồn hiển thị; offset stretch thay đổi hình chữ nhật mà ảnh lấp đầy được kéo dãn vào.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Sử dụng offset stretch để đặt vị trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Xem xét Lưu trữ, Kích thước Tệp và Xuất**

Các đánh đổi chính dễ quản lý hơn khi lưu trữ ảnh và định dạng khung ảnh được xử lý riêng rẽ:

- **Hình ảnh nhúng** làm cho bản trình bày tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía server, nhưng ảnh raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp bên ngoài vẫn còn khả dụng tại các đường dẫn hoặc vị trí lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn nhúng cho đến khi các khu vực đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng nó hy sinh độ phân giải nguồn. Nên áp dụng sau khi biết kích thước hiển thị trên slide.
- **Hình ảnh SVG** nên giữ dưới dạng SVG khi việc bảo lưu vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) hiện có khi có thể thay vì tải cùng một tệp nhiều lần vào quy trình bản trình bày.

Đối với các bản trình bày lớn, tối ưu hoá ảnh thường hiệu quả nhất khi được thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **CÂU HỎI THƯỜNG GẶP**

**Khung ảnh và tài nguyên hình ảnh có gì khác nhau?**

[IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) đại diện cho một tài nguyên hình ảnh liên kết với bản trình bày. [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần truy cập tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc giữ các tệp ảnh bên ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt bình thường ẩn một phần ảnh nguồn nhưng vẫn giữ các pixel bên dưới. Sử dụng [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) hoặc nén ảnh kèm loại bỏ khu vực đã cắt khi các pixel đó có thể bị xóa vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc xóa các khu vực đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình bày nếu sau này có thể cần chỉnh sửa độ phân giải cao.

**Nên xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ chính xác vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh ép kiểu không an toàn khi đọc slide hiện có?**

Kiểm tra loại hình dạng trước khi sử dụng các thành viên chuyên cho khung ảnh. Phép khớp mẫu với [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) hoặc lọc bộ sưu tập hình dạng theo giao diện này giúp tránh ép kiểu không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.