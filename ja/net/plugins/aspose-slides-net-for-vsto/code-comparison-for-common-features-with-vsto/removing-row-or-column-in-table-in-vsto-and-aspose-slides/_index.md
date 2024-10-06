---
title: VSTO と Aspose.Slides におけるテーブルの行または列を削除する
type: docs
weight: 130
url: /ja/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
以下は、VSTO プレゼンテーションを使用してテーブルから行または列を削除するためのコードです:

``` csharp

    string FileName = "テーブルの行または列を削除する.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //最初のスライドを取得

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
Aspose.Slides for .NET は、最も簡単な方法でテーブルを作成するためのシンプルな API を提供しています。スライドにテーブルを作成し、テーブルに対して基本的な操作を行うには、以下の手順に従ってください:

- Presentation クラスのインスタンスを作成する
- インデックスを使用してスライドの参照を取得する
- 幅を持つ列の配列を定義する
- 高さを持つ行の配列を定義する
- IShapes オブジェクトによって公開される AddTable メソッドを使用してスライドにテーブルを追加する
- テーブルの行を削除する
- テーブルの列を削除する
- 変更されたプレゼンテーションを PPTX ファイルとして保存する

``` csharp

   string FileName = "テーブルの行または列を削除する.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //最初のスライドを取得

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **コードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Removing Row Or Column in Table/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)