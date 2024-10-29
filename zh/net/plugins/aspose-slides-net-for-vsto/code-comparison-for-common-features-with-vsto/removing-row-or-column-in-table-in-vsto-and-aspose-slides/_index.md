---
title: 在 VSTO 和 Aspose.Slides 中删除表格的行或列
type: docs
weight: 130
url: /zh/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
以下是使用 VSTO 演示文稿删除表格行或列的代码：

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //获取第一张幻灯片

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
Aspose.Slides for .NET 提供了最简单的 API，以最简单的方式创建表格。要在幻灯片中创建表格并对表格执行一些基本操作，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 通过使用其索引获取幻灯片的引用
- 定义带宽度的列数组
- 定义带高度的行数组
- 使用 IShapes 对象暴露的 AddTable 方法将表格添加到幻灯片
- 删除表格行
- 删除表格列
- 将修改后的演示文稿保存为 PPTX 文件

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //获取第一张幻灯片

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);

``` 
## **下载运行代码**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Removing Row Or Column in Table/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)