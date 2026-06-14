---
title: 在 VSTO 和 Aspose.Slides 中移除表格的列或欄
type: docs
weight: 130
url: /zh-hant/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
以下是使用 VSTO Presentation 從表格中移除列或欄的程式碼：

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //取得第一張投影片

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
Aspose.Slides for .NET 提供了最簡單的 API，讓您以最簡便的方式建立表格。若要在投影片中建立表格並對表格執行一些基本操作，請依照以下步驟：

- 建立 Presentation 類別的實例
- 使用索引取得投影片的參考
- 定義具有寬度的欄陣列
- 定義具有高度的列陣列
- 使用 IShapes 物件提供的 AddTable 方法將表格加入投影片
- 移除表格列
- 移除表格欄
- 將已修改的投影片寫入為 PPTX 檔案

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //取得第一張投影片

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