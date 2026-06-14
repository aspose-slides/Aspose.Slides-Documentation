---
title: Xóa hàng hoặc cột trong bảng bằng VSTO và Aspose.Slides
type: docs
weight: 130
url: /vi/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Dưới đây là mã để xóa hàng hoặc cột khỏi bảng bằng VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Lấy slide đầu tiên

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides cho .NET đã cung cấp API đơn giản nhất để tạo bảng một cách dễ dàng. Để tạo một bảng trong slide và thực hiện một số thao tác cơ bản trên bảng, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó
- Định nghĩa mảng các cột với độ rộng
- Định nghĩa mảng các hàng với chiều cao
- Thêm một bảng vào slide bằng phương thức AddTable được cung cấp bởi đối tượng IShapes
- Xóa hàng trong bảng
- Xóa cột trong bảng
- Ghi bản trình bày đã chỉnh sửa thành tệp PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Lấy slide đầu tiên

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)