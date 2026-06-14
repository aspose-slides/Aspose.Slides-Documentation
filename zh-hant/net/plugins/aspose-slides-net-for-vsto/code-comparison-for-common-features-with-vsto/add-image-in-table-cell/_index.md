---
title: 在表格儲存格中加入影像
type: docs
weight: 10
url: /zh-hant/net/add-image-in-table-cell/
---
## **VSTO**
以下是將影像加入表格儲存格的程式碼：

``` csharp

    //開啟包含表格的 Presentation 類別

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //取得第一張投影片

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
Aspose.Slides for .NET 提供了最簡單的 API，可最輕鬆地建立表格。若要在建立新表格時於儲存格中加入影像，請遵循以下步驟：

- 建立 Presentation 類別的實例
- 使用索引取得投影片的參考
- 定義具有寬度的 Columns 陣列
- 定義具有高度的 Rows 陣列
- 使用 IShapes 物件提供的 AddTable 方法將表格新增至投影片
- 建立 Bitmap 物件以保存影像檔案
- 將 Bitmap 影像加入 IPPImage 物件
- 將表格儲存格的填滿格式設定為圖片
- 將影像新增至表格的第一個儲存格
- 將修改後的簡報儲存為 PPTX 檔案

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //取得第一張投影片

  ISlide sld = MyPresentation.Slides[0];

  //建立 Bitmap 影像物件以保存圖片檔案

  using IImage image = Images.FromFile(ImageFile);

  //使用 bitmap 物件建立 IPPImage 物件

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //將影像加入第一個表格儲存格

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //將 PPTX 儲存至磁碟

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)