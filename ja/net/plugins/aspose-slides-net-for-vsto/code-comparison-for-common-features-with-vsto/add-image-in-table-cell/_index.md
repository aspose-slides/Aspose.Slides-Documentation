---
title: テーブルセルに画像を追加
type: docs
weight: 10
url: /ja/net/add-image-in-table-cell/
---

## **VSTO**
以下はテーブルセルに画像を追加するコードです:

``` csharp

    //Open Prsentation class that contains the table

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
Aspose.Slides for .NET は、テーブルを最も簡単な方法で作成できる API を提供しています。新しいテーブルを作成しながらテーブルセルに画像を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- インデックスを使用してスライドの参照を取得する
- 幅を指定した列の配列を定義する
- 高さを指定した行の配列を定義する
- IShapes オブジェクトが公開する AddTable メソッドを使用してスライドにテーブルを追加する
- 画像ファイルを保持する Bitmap オブジェクトを作成する
- Bitmap 画像を IPPImage オブジェクトに追加する
- テーブルセルの塗りつぶし形式を画像に設定する
- 画像をテーブルの最初のセルに追加する
- 変更したプレゼンテーションを PPTX ファイルとして保存する

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  //Creating a Bitmap Image object to hold the image file

  using IImage image = Images.FromFile(ImageFile);

  //Create an IPPImage object using the bitmap object

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Add image to first table cell

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Save PPTX to Disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)