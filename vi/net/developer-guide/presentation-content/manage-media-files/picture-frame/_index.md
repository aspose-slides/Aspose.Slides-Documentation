---
title: Quản lý Khung Ảnh trong Bản Trình Bày bằng .NET
linktitle: Khung Ảnh
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
- xóa vùng đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng ảnh
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

Khung ảnh là một hình dạng trên slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh nhúng thông qua bộ sưu tập [Images](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/images/), trong khi một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các thiết lập cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại đối tượng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) trả về và sử dụng tài nguyên hình ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa hình ảnh raster như PNG hoặc JPEG và hình ảnh vector SVG. Chúng cũng có thể tham chiếu tới hình ảnh được liên kết thay vì lưu trữ byte hình ảnh trong bản trình bày. Lựa chọn này ảnh hưởng đến khả năng di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy việc quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu là cần thiết.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình bày và tạo một khung ảnh bằng [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addpictureframe/). Hình ảnh trở thành một phần của gói bản trình bày, do đó bản trình bày vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một hình ảnh JPEG, tạo khung ở kích thước gốc của hình ảnh và áp dụng định dạng đường viền cùng xoay:

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

Khung ảnh điều khiển hình học hiển thị; thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) cung cấp khả năng tỷ lệ chiều rộng và chiều cao tương đối cho khung. Giá trị `1.0` tương đương 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình cần duy trì mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng bằng tay.

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

Tỷ lệ tương đối thay đổi các thiết lập tỷ lệ của khung; nó không tái mẫu hoặc nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Hình ảnh Liên kết**

Hình ảnh nhúng lưu dữ liệu hình ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho khả năng di động và việc hiển thị dự đoán được. Hình ảnh liên kết lưu vị trí bên ngoài thông qua đường dẫn liên kết [ISlidesPicture](https://reference.aspose.com/slides/vi/net/aspose.slides/islidespicture/) thay vì nhúng dữ liệu hình ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được cho ứng dụng mở hoặc hiển thị bản trình bày. Nếu đường dẫn thay đổi, tệp được di chuyển, hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không được hiển thị như mong đợi. Đối với các bản trình bày cần được gửi email, lưu trữ, hoặc hiển thị trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một khung ảnh và chỉ tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; liên kết video là một quy trình truyền thông riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Không sử dụng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc hình ảnh bị hỏng thường kém hữu ích hơn một bản trình bày lớn tự chứa.

## **Trích xuất Hình ảnh từ Khung ảnh**

Trước khi trích xuất hình ảnh từ một bản trình bày hiện có, kiểm tra xem hình dạng thực sự là một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) và nó có chứa hình ảnh nhúng hay không. Các khung ảnh liên kết có thể không chứa byte hình ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình ảnh Raster**

API hình ảnh hiện đại sử dụng trực tiếp [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) và không yêu cầu lớp bao bọc hệ thống hình ảnh cũ. Ví dụ sau tìm hình raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoá được lưu trong bản trình bày thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh.

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

Giữ nội dung SVG dưới dạng SVG bảo toàn nguồn vector trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide sang PDF hoặc SVG cũng là một hoạt động render, vì vậy đồ họa xuất ra không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; sử dụng dữ liệu [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) nhúng khi tài nguyên vector gốc thực sự cần thiết.

## **Cắt Hình ảnh**

Cắt thay đổi phần nào của hình ảnh hiển thị bên trong khung. Các giá trị cắt trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

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

Vì dữ liệu ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn khả năng đảo ngược, các vùng đã cắt có thể được loại bỏ vật lý như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) loại bỏ dữ liệu ảnh nằm ngoài vùng cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu phá hủy: sau khi bản trình bày được lưu, các pixel đã xóa không còn có thể phục hồi cho thao tác hủy cắt lại.

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

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình bày. Nếu ảnh gốc cũng được các khung ảnh khác sử dụng, các khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Hình ảnh Raster**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/compressimage/) giảm độ phân giải raster so với kích thước mà ảnh được hiển thị. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi ảnh được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng một giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/net/aspose.slides.export/picturescompression/) định sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Có thể truyền một giá trị DPI dương tùy chỉnh thay cho giá trị enum khi cần mục tiêu cụ thể.

Nén được thiết kế cho hình ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể phục hồi từ bản trình bày đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh thực sự sẽ được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Kiểm tra Hiệu ứng Ảnh**

Hiệu ứng ảnh được lưu trên ảnh được khung sử dụng. Bộ sưu tập biến đổi ảnh có thể chứa các hiệu ứng như điều chế alpha cố định cho độ trong suốt và độ sáng cho độ sáng và độ tương phản. Ví dụ dưới đây đọc an toàn cả hai loại hiệu ứng từ khung ảnh đầu tiên trên một slide:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Các hiệu ứng này thay đổi cách ảnh được render trong khung; chúng không ghi đè lên byte ảnh nhúng gốc.

## **Khóa Hình học Khung Ảnh**

Cài đặt [IPictureFrameLock](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, khóa tỷ lệ duy trì tỉ lệ hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn để có cùng tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [IPictureFillFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Phần trăm dương tạo một lề vào từ cạnh, trong khi phần trăm âm tạo một lề ra ngoài.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà ảnh lấp đầy được kéo dãn vào.

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

Sử dụng stretch offset để đặt vị trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Xem xét Khi Xuất**

Các cân nhắc chính trở nên dễ quản lý hơn khi việc lưu trữ ảnh và định dạng khung ảnh được xử lý riêng biệt:

- **Hình ảnh nhúng** làm cho bản trình bày tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các ảnh raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp bên ngoài vẫn phải có sẵn tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng sẽ đánh đổi độ phân giải nguồn. Nên áp dụng sau khi biết kích thước cuối cùng trên slide.
- **Hình ảnh SVG** nên được giữ dưới dạng SVG khi bảo toàn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển slide render sang pixel.
- **Hình ảnh lặp lại** nên tái sử dụng tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc của bản trình bày.

Đối với các bản trình bày lớn, tối ưu hóa ảnh thường hiệu quả nhất khi thực hiện có chọn lựa: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung ảnh và tài nguyên hình ảnh là gì?**

[IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) đại diện cho một tài nguyên hình ảnh gắn với bản trình bày. [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần truy cập tài nguyên bên ngoài. Liên kết hình ảnh chỉ khi việc giữ các tệp hình ảnh bên ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt bình thường ẩn các phần của ảnh nguồn nhưng vẫn giữ các pixel bên dưới. Sử dụng [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) hoặc nén ảnh với việc loại bỏ khu vực đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ bản gốc ảnh nguồn bên ngoài bản trình bày nếu sau này có thể cần chỉnh sửa ở độ phân giải cao.

**Cách xử lý ảnh SVG?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) nhúng có thể được trích xuất trực tiếp. Render slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh việc ép kiểu không an toàn khi đọc các slide hiện có?**

Kiểm tra loại hình dạng trước khi sử dụng các thành viên đặc thù của khung ảnh. Sử dụng pattern matching với [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) hoặc lọc bộ sưu tập hình dạng theo giao diện đó để tránh các ép kiểu không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.