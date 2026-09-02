---
title: Tối ưu hóa Quản lý Hình ảnh trong Bản trình chiếu bằng .NET
linktitle: Quản lý Hình ảnh
type: docs
weight: 10
url: /vi/net/image/
keywords:
- thêm hình ảnh
- thêm hình
- thay thế hình ảnh
- bộ sưu tập hình ảnh
- khung hình
- hình ảnh liên kết
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- SVG thành hình dạng
- tài nguyên SVG bên ngoài
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý hình ảnh raster và SVG trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho .NET."
---
## **Giới thiệu**

Aspose.Slides for .NET cung cấp một số cách để làm việc với hình ảnh, và mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ một hình ảnh trong bản trình chiếu, hiển thị nó trong một khung hình, sử dụng nó làm nền slide, liên kết tới một hình ảnh bên ngoài, thay thế một tài nguyên hình ảnh chia sẻ, hoặc chuyển nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào các tài nguyên hình ảnh và cách chúng được sử dụng trong toàn bộ bản trình chiếu. Đối với việc cắt, độ trong suốt, hiệu ứng, kéo dãn và các định dạng khác được áp dụng cho một khung hình riêng lẻ, xem [Picture Frame](/slides/vi/net/picture-frame/).

## **Hiểu mô hình hình ảnh**

- Bộ sưu tập hình ảnh của bản trình chiếu ([presentation image collection](https://reference.aspose.com/slides/vi/net/aspose.slides/iimagecollection/)) lưu trữ các tài nguyên hình ảnh được sử dụng bởi bản trình chiếu. Sử dụng [ImageCollection.AddImage](https://reference.aspose.com/slides/vi/net/aspose.slides/imagecollection/addimage/) để thêm dữ liệu hình ảnh và nhận một tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/).
- Một [picture frame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) là một hình dạng hiển thị hình ảnh trên slide, layout hoặc master. Sử dụng [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addpictureframe/) để đặt tài nguyên hình ảnh lên slide.
- Nền slide sử dụng hình ảnh như một phần của việc lấp đầy slide thay vì như một hình dạng. Do đó nó không hoạt động như một khung hình.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/replaceimage/) thay thế một tài nguyên hình ảnh. Nếu có nhiều phần tử trong bản trình chiếu sử dụng tài nguyên đó, tất cả chúng sẽ dùng tài nguyên đã thay thế.
- Chuyển đổi SVG thành các hình dạng tạo ra các hình dạng slide có thể chỉnh sửa. Sau khi chuyển đổi, nội dung không còn được quản lý như một tài nguyên hình ảnh duy nhất.

Một quy trình làm việc điển hình là: thêm dữ liệu hình ảnh vào bộ sưu tập hình ảnh, nhận một [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/), và sau đó sử dụng tài nguyên đó trong một hoặc nhiều khung hình hoặc lấp đầy.

## **Thêm hình ảnh nhúng**

Để chèn một hình ảnh cục bộ, đọc tệp, thêm dữ liệu của nó vào bộ sưu tập hình ảnh và tạo một khung hình sử dụng `IPPImage` được trả về.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Hình ảnh được thêm theo cách này sẽ được nhúng trong bản trình chiếu, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm hình ảnh từ web**

Khi một hình ảnh có sẵn qua HTTP hoặc HTTPS, tải xuống các byte của nó bằng `HttpClient`, thêm chúng vào bộ sưu tập hình ảnh của bản trình chiếu, và sử dụng tài nguyên hình ảnh trả về cùng cách như với hình ảnh cục bộ.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

Trong các ứng dụng chạy lâu, tái sử dụng `HttpClient` thay vì tạo một đối tượng mới cho mỗi yêu cầu. Đồng thời kiểm tra URL từ xa, kích thước phản hồi và kiểu nội dung khi nguồn không tin cậy.

## **Tái sử dụng hình ảnh trên nhiều slide**

Nếu cùng một hình ảnh được cần nhiều lần, hãy thêm nó vào bản trình chiếu một lần và tái sử dụng [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) khi tạo các khung hình bổ sung. Điều này tránh việc tải lại cùng dữ liệu nguồn và làm rõ mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các vị trí sử dụng của nó.

Đối với các đồ họa nên xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy cân nhắc đặt khung hình trên một [slide master](/slides/vi/net/slide-master/) hoặc layout thay vì thêm một hình dạng tương đương vào mỗi slide.

## **Sử dụng hình ảnh làm nền slide**

Một hình ảnh nền được gán cho phần lấp đầy slide; nó không được thêm như một hình dạng khung hình. Điều này hữu ích khi hình ảnh cần bao phủ toàn bộ nền slide và không nên được thao tác như một đối tượng slide thông thường.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Đối với các tùy chọn nền bổ sung, bao gồm nền master và layout, xem [Presentation Background](/slides/vi/net/presentation-background/).

## **Hình ảnh nhúng và hình ảnh liên kết**

Hình ảnh nhúng và hình ảnh liên kết có những cân bằng khác nhau về tính di động và kích thước tệp:

- **Hình ảnh nhúng:** dữ liệu hình ảnh được lưu bên trong bản trình chiếu. Bản trình chiếu tự chứa, nhưng kích thước tệp bao gồm dữ liệu hình ảnh.
- **Hình ảnh liên kết:** bản trình chiếu lưu một đường dẫn hoặc URL tới hình ảnh bên ngoài. Điều này có thể giảm kích thước bản trình chiếu, nhưng tài nguyên bên ngoài phải luôn khả dụng khi bản trình chiếu được mở hoặc render.

Một hình ảnh liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài qua [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/vi/net/aspose.slides/islidespicture/linkpathlong/) thay vì nhúng dữ liệu hình ảnh.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể tin cậy truy cập tài nguyên bên ngoài. Đối với các bản trình chiếu phải hoạt động ngoại tuyến hoặc di chuyển giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm việc với hình ảnh SVG**

SVG là định dạng vector, vì vậy nó hữu ích cho các biểu tượng, sơ đồ và các đồ họa khác cần phóng to mà không mất chi tiết như hình ảnh raster. Aspose.Slides hỗ trợ SVG vừa như một tài nguyên hình ảnh vừa như nguồn cho các hình dạng slide có thể chỉnh sửa.

### **Thêm SVG làm hình ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/svgimage/), thêm nó vào bộ sưu tập hình ảnh, và đặt tài nguyên hình ảnh kết quả vào một khung hình.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **Tệp SVG với tài nguyên bên ngoài**

SVG có thể tham chiếu đến các hình ảnh, stylesheet hoặc font bên ngoài. Trong các trường hợp này, [SvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/svgimage/) cung cấp các hàm khởi tạo nhận một [IExternalResourceResolver](https://reference.aspose.com/slides/vi/net/aspose.slides.import/iexternalresourceresolver/) và một URI cơ sở. Bộ giải quyết có thể ánh xạ một URI tương đối thành một URI tuyệt đối cho phép và trả về một luồng cho tài nguyên được yêu cầu.

Bộ giải quyết làm cho các tài nguyên bên ngoài có sẵn trong quá trình Aspose.Slides xử lý SVG, nhưng không chuyển đổi SVG thành một tài liệu tự chứa. Nếu SVG phải vẫn di động, nhúng các tài nguyên cần thiết vào chính SVG, ví dụ bằng cách sử dụng URI dạng `data:` cho các hình ảnh liên kết.

Khi các tệp SVG đến từ các nguồn không tin cậy, hạn chế các scheme, vị trí tệp và máy chủ mà bộ giải quyết có thể truy cập. Các bộ giải quyết mạng cũng nên áp dụng timeout, giới hạn kích thước phản hồi và xác thực nội dung.

### **Chuyển SVG thành các hình dạng có thể chỉnh sửa**

Aspose.Slides có thể chuyển một SVG thành một nhóm các hình dạng slide có thể chỉnh sửa, tương tự lệnh tương ứng trong PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Sử dụng hàm overload [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addgroupshape/) nhận một [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) để thực hiện chuyển đổi.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Hãy dùng chuyển đổi SVG‑to‑shapes khi các phần tử vector riêng lẻ cần được chỉnh sửa như các hình dạng PowerPoint. Nếu SVG chỉ cần được hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh tạo ra nhiều hình dạng riêng biệt.

## **Thay thế tài nguyên hình ảnh hiện có**

Sử dụng [IPPImage.ReplaceImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/replaceimage/) khi bạn muốn thay thế một tài nguyên hình ảnh hiện có. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Nếu nhiều khung hình, nền, master hoặc layout sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên sẽ cập nhật tất cả các vị trí sử dụng đó. Nếu chỉ một khung hình cần thay đổi, hãy gán một hình ảnh khác cho khung hình đó thay vì thay thế tài nguyên chia sẻ.

`ReplaceImage` cũng cung cấp các overload nhận một [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) hoặc một [IPPImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/) khác.

## **Hướng dẫn quản lý hình ảnh thực tiễn**

### **Kiểm soát kích thước bản trình chiếu**

Hình ảnh raster lớn có thể làm cho bản trình chiếu trở nên quá lớn. Sử dụng các hình ảnh nguồn có kích thước phù hợp với kích thước hiển thị dự kiến, tái sử dụng các tài nguyên hình ảnh chia sẻ khi có thể, và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải cao.

Đối với các hình ảnh raster đã được đặt trong khung hình, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/compressimage/) có thể giảm dữ liệu hình ảnh dựa trên độ phân giải và cài đặt cắt được chọn. Đây là xử lý cấp khung hình chứ không phải quản lý bộ sưu tập hình ảnh, vì vậy xem [Picture Frame](/slides/vi/net/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn giữa nội dung nhúng và liên kết**

Nhúng làm cho bản trình chiếu di động vì mọi dữ liệu hình ảnh cần thiết đi kèm với tệp. Liên kết có thể giảm kích thước tệp, nhưng tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái sử dụng thương hiệu chia sẻ**

Đối với các logo, watermark hoặc đồ họa trang trí lặp lại, sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bản trình chiếu chứ không phải nội dung slide, hãy đặt nó trên một master hoặc layout để các slide phù hợp kế thừa.

### **Giữ tài nguyên SVG di động**

Một SVG tự chứa dễ di chuyển và render nhất quán hơn so với SVG phụ thuộc vào các tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển SVG thành các hình dạng chỉ nên làm khi các phần tử vector riêng lẻ cần được chỉnh sửa.

### **Sử dụng API hình ảnh đa nền tảng hiện đại**

Đối với mã .NET mới, hãy sử dụng các API Aspose.Slides [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) và [Images](https://reference.aspose.com/slides/vi/net/aspose.slides/images/) thay vì dựa vào `System.Drawing.Image` hoặc `Bitmap`. Xem [Modern API](/slides/vi/net/modern-api/) để biết hướng dẫn di chuyển.

WMF và EMF cần xem xét đặc biệt. Khi các định dạng này được truyền qua một [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/), [ImageCollection.AddImage](https://reference.aspose.com/slides/vi/net/aspose.slides/imagecollection/addimage/) chuyển đổi metafile thành đại diện PNG raster trước khi chèn. Nếu việc bảo toàn dữ liệu metafile quan trọng, hãy sử dụng overload dựa trên stream của [ImageCollection.AddImage](https://reference.aspose.com/slides/vi/net/aspose.slides/imagecollection/addimage/). Tạo nội dung EMF từ bảng tính hoặc các sản phẩm khác là một quy trình tích hợp riêng và không nằm trong phạm vi của bài viết này.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa bộ sưu tập hình ảnh và khung hình là gì?**

Bộ sưu tập hình ảnh lưu trữ các tài nguyên hình ảnh có thể tái sử dụng. Một khung hình là một hình dạng slide hiển thị một trong các tài nguyên đó và cung cấp các định dạng đặc thù cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [IPPImage.ReplaceImage](https://reference.aspose.com/slides/vi/net/aspose.slides/ippimage/replaceimage/). Đối với thương hiệu trên toàn bộ bản trình chiếu, việc đặt logo trên một master hoặc layout cũng có thể giảm nội dung slide trùng lặp.

**Tại sao một hình ảnh liên kết lại biến mất trên máy tính khác?**

Hình ảnh liên kết phụ thuộc vào tệp hoặc URL bên ngoài. Nếu tài nguyên đó không thể truy cập được từ máy tính khác, hình ảnh liên kết sẽ không có sẵn. Nhúng hình ảnh khi bản trình chiếu phải tự chứa.

**SVG đã chèn có thể chỉnh sửa thành các hình dạng PowerPoint không?**

Có. Chuyển đổi SVG bằng [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addgroupshape/); nhóm kết quả chứa các hình dạng slide có thể chỉnh sửa thay vì một hình ảnh SVG duy nhất.

**Làm sao để giữ bản trình chiếu có nhiều hình ảnh mà vẫn nhỏ gọn?**

Tái sử dụng các tài nguyên hình ảnh chia sẻ, tránh sử dụng các nguồn raster không cần thiết lớn, nén các hình ảnh raster phù hợp khi cần, giữ các thương hiệu lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài là chấp nhận được.