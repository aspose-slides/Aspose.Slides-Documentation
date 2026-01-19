---
title: VSTO と Aspose.Slides でテーブルの行または列を削除する
type: docs
weight: 130
url: /ja/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
以下は VSTO プレゼンテーションを使用してテーブルの行または列を削除するコードです。

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
Aspose.Slides for .NET は、テーブルを最も簡単に作成できるシンプルな API を提供しています。スライドにテーブルを作成し、テーブルに対して基本的な操作を行うには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- インデックスを使用してスライドの参照を取得する
- 幅を指定した列の配列を定義する
- 高さを指定した行の配列を定義する
- IShapes オブジェクトが提供する AddTable メソッドを使用してスライドにテーブルを追加する
- テーブルの行を削除する
- テーブルの列を削除する
- 変更されたプレゼンテーションを PPTX ファイルとして書き出す

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

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