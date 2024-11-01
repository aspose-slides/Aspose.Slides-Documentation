---
title: 在表格单元格中添加图片
type: docs
weight: 10
url: /zh/net/add-image-in-table-cell/
---

## **VSTO**
下面是将图片添加到表格单元格中的代码：

``` csharp

    // 打开包含表格的演示文稿类

   string FileName = "在表格单元格中添加图片.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   // 获取第一张幻灯片

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell = shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides for .NET 提供了最简单的 API，以最简单的方式创建表格。要在创建新表格时将图片添加到表格单元格，请按照以下步骤操作：

- 创建一个 Presentation 类的实例
- 使用索引获取幻灯片的引用
- 定义具有宽度的列数组
- 定义具有高度的行数组
- 使用 IShapes 对象暴露的 AddTable 方法向幻灯片添加表格
- 创建一个 Bitmap 对象以保存图像文件
- 将 Bitmap 图像添加到 IPPImage 对象
- 将表格单元格的填充格式设置为图片
- 将图像添加到表格的第一个单元格
- 将修改后的演示文稿保存为 PPTX 文件

``` csharp

   string FileName = "在表格单元格中添加图片.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation MyPresentation = new Presentation(FileName);

   // 获取第一张幻灯片

   ISlide sld = MyPresentation.Slides[0];

   // 创建一个 Bitmap 图像对象以保存图像文件

   using IImage image = Images.FromFile(ImageFile);

   // 使用 bitmap 对象创建一个 IPPImage 对象

   IPPImage imgx1 = MyPresentation.Images.AddImage(image);

   foreach (IShape shp in sld.Shapes)

   if (shp is ITable)

   {

     ITable tbl = (ITable)shp;

     // 将图像添加到第一个表格单元格

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  // 将 PPTX 保存到磁盘

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **下载运行代码**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/在表格单元格中添加图片/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/在表格单元格中添加图片)