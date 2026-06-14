---
title: Thêm Khung Hình Ảnh vào Bản Trình Bày
type: docs
weight: 50
url: /vi/net/add-picture-frame-to-presentation/
---
## **VSTO**
Dưới đây là mã để thêm hình ảnh vào bản trình bày VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Để thêm một khung hình ảnh đơn giản vào slide của bạn, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp Presentation.
1. Lấy tham chiếu tới một slide bằng cách sử dụng chỉ số của nó.
1. Tạo một đối tượng Image bằng cách thêm một hình ảnh vào bộ sưu tập Images liên kết với đối tượng Presentation, đối tượng này sẽ được dùng để lấp đầy Shape.
1. Tính chiều rộng và chiều cao của hình ảnh.
1. Tạo một PictureFrame dựa trên chiều rộng và chiều cao của hình ảnh bằng cách sử dụng phương thức AddPictureFrame được cung cấp bởi đối tượng Shapes liên kết với slide đã tham chiếu.
1. Thêm một khung hình ảnh (chứa hình) vào slide.
1. Ghi bản trình bày đã sửa đổi thành tệp PPTX.

Các bước trên được thực hiện trong ví dụ được đưa ra dưới đây.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX

  Presentation pres = new Presentation();

  //Lấy slide đầu tiên

  ISlide sld = pres.Slides[0];

  //Tạo một đối tượng lớp ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Thêm khung hình ảnh với chiều cao và chiều rộng bằng với hình ảnh

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)