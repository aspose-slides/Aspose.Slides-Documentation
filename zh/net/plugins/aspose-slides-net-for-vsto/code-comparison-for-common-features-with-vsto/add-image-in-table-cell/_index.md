---
title: 在表格单元格中添加图像
type: docs
weight: 10
url: /zh/net/add-image-in-table-cell/
---

## **VSTO**
以下是向表格单元格添加图像的代码：

``` csharp

    //打开包含表格的 Presentation 类
   string FileName = "Adding Image in Table Cell.pptx";
   string ImageFile = "AsposeLogo.jpg";
   Presentation pres = Application.Presentations.Open(FileName);
   //获取第一张幻灯片
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
Aspose.Slides for .NET 提供了最简便的 API 来创建表格。要在创建新表格时向表格单元格添加图像，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 使用索引获取幻灯片的引用
- 定义具有宽度的列数组
- 定义具有高度的行数组
- 使用 IShapes 对象提供的 AddTable 方法向幻灯片添加表格
- 创建 Bitmap 对象以保存图像文件
- 将 Bitmap 图像添加到 IPPImage 对象
- 将表格单元格的填充格式设置为图片
- 将图像添加到表格的第一个单元格
- 将修改后的演示文稿保存为 PPTX 文件

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";
  string ImageFile = "AsposeLogo.jpg";
  Presentation MyPresentation = new Presentation(FileName);
  //获取第一张幻灯片
  ISlide sld = MyPresentation.Slides[0];
  //创建 Bitmap 图像对象以保存图像文件
  using IImage image = Images.FromFile(ImageFile);
  //使用 bitmap 对象创建 IPPImage 对象
  IPPImage imgx1 = MyPresentation.Images.AddImage(image);
  foreach (IShape shp in sld.Shapes)
  if (shp is ITable)
  {
     ITable tbl = (ITable)shp;
     //向第一个表格单元格添加图像
     tbl[0, 0].FillFormat.FillType = FillType.Picture;
     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;
   }
  //将 PPTX 保存到磁盘
  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)