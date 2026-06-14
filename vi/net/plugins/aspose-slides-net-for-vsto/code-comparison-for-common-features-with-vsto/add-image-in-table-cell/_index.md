---
title: Thêm hình ảnh vào ô bảng
type: docs
weight: 10
url: /vi/net/add-image-in-table-cell/
---
## **VSTO**
Dưới đây là mã để thêm hình ảnh vào ô bảng:

``` csharp

    //Mở lớp Presentation chứa bảng

   //Lấy slide đầu tiên

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides cho .NET đã cung cấp API đơn giản nhất để tạo bảng một cách dễ dàng. Để thêm hình ảnh vào ô bảng khi tạo một bảng mới, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó
- Định nghĩa mảng các cột với độ rộng
- Định nghĩa mảng các hàng với chiều cao
- Thêm một bảng vào slide bằng phương thức AddTable được cung cấp bởi đối tượng IShapes
- Tạo một đối tượng Bitmap để chứa tệp hình ảnh
- Thêm hình ảnh Bitmap vào đối tượng IPPImage
- Đặt định dạng Fill của ô bảng là Picture
- Thêm hình ảnh vào ô đầu tiên của bảng
- Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Lấy slide đầu tiên

  ISlide sld = MyPresentation.Slides[0];

  //Tạo đối tượng Bitmap Image để chứa tệp hình ảnh

  using IImage image = Images.FromFile(ImageFile);

  //Tạo đối tượng IPPImage bằng cách sử dụng đối tượng bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Thêm hình ảnh vào ô bảng đầu tiên

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Lưu PPTX vào ổ đĩa

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Tải mã chạy**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)