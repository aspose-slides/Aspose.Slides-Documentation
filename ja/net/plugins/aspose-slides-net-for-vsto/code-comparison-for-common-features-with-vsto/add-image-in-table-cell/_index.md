---
title: テーブルセルに画像を追加
type: docs
weight: 10
url: /net/add-image-in-table-cell/
---

## **VSTO**
以下は、テーブルセルに画像を追加するためのコードです：

``` csharp

    //テーブルを含むプレゼンテーションクラスを開く

   string FileName = "テーブルセルに画像を追加.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //最初のスライドを取得

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
Aspose.Slides for .NETは、非常に簡単な方法でテーブルを作成するための最も簡単なAPIを提供しています。新しいテーブルを作成しながらテーブルセルに画像を追加するには、以下の手順に従ってください：

- Presentationクラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- 幅を持つ列の配列を定義します
- 高さを持つ行の配列を定義します
- IShapesオブジェクトによって公開されているAddTableメソッドを使用してスライドにテーブルを追加します
- 画像ファイルを保持するBitmapオブジェクトを作成します
- Bitmap画像をIPPImageオブジェクトに追加します
- テーブルセルの塗りつぶし形式を画像として設定します
- テーブルの最初のセルに画像を追加します
- 修正されたプレゼンテーションをPPTXファイルとして保存します

``` csharp

   string FileName = "テーブルセルに画像を追加.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //最初のスライドを取得

  ISlide sld = MyPresentation.Slides[0];

  //画像ファイルを保持するBitmap Imageオブジェクトを作成

  using IImage image = Images.FromFile(ImageFile);

  //ビットマップオブジェクトを使用してIPPImageオブジェクトを作成

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //最初のテーブルセルに画像を追加

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //PPTXをディスクに保存

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **実行コードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding image in table cell/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)