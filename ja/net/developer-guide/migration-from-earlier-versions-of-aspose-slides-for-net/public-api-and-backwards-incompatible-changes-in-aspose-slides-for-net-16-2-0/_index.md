---
title: Aspose.Slides for .NET 16.2.0 の公開 API と互換性を損なう変更
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 16.2.0 API で導入された、追加または削除されたクラス、メソッド、プロパティなど、すべての変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Properties UpdateDateTimeFields と UpdateSlideNumberFields が削除されました**
Properties UpdateDateTimeFields と UpdateSlideNumberFields は Aspose.Slides.Presentation クラスおよび Aspose.Slides.IPresentation インターフェイスから削除されました。  
Aspose.Slides.TextFrame、Paragraph、Portion クラスと Aspose.Slides.ITextFrame、IParagraph、IPortion インターフェイスの Text プロパティは、更新された「datetime」フィールドを含むテキストを返します。  
また、Presentation.DocumentProperties.CreatedTime、LastSavedTime、LastPrinted プロパティは読み取り専用になりました。
#### **Enum Slides.Charts.CategoryAxisType が public に変更されました**
IAxis.CategoryAxisType と Axis.CategoryAxisType プロパティで使用され、カテゴリ軸の種類を決定します。  
CategoryAxisType.Auto - シリアライズ時にカテゴリ軸の種類が自動的に決定されます（現在は実装されていません）  
CategoryAxisType.Text - カテゴリ軸の種類は Text  
CategoryAxisType.Date - カテゴリ軸の種類は DateTime
#### **高速テキスト抽出**
Presentation クラスに新しい静的メソッド GetPresentationText が追加されました。このメソッドには 2 つのオーバーロードがあります:

``` csharp
 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
``` 

ExtractionMode 列挙型の引数は、テキスト結果の出力方法を指定し、次の値に設定できます:  
Unarranged - スライド上の位置を考慮せずに生テキストを取得  
Arranged - スライド上の順序と同じ順序でテキストを取得  

速度が重要な場合は Unarranged モードを使用できます。Arranged モードよりも高速です。

PresentationText はプレゼンテーションから抽出された生テキストを表します。Aspose.Slides.Util 名前空間の SlidesText プロパティは ISlideText オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。ISlideText オブジェクトは次のプロパティを持ちます:

ISlideText.Text - スライドのシェイプ上のテキスト  
ISlideText.MasterText - このスライドのマスタースライド上のシェイプのテキスト  
ISlideText.LayoutText - このスライドのレイアウトスライド上のシェイプのテキスト  
ISlideText.NotesText - このスライドのノートページ上のシェイプのテキスト  

SlideText クラスは ISlideText インターフェイスを実装しています。

新しい API は次のように使用できます:

``` csharp
 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)
``` 
#### **ILegacyDiagram インターフェイスと LegacyDiagram クラスが追加されました**
Aspose.Slides.ILegacyDiagram インターフェイスと Aspose.Slides.LegacyDiagram クラスが追加され、レガシーダイアグラム オブジェクトを表現します。レガシーダイアグラムは PowerPoint 97‑2003 の古い形式です。新クラスはレガシーダイアグラムを最新の編集可能な SmartArt オブジェクトまたは編集可能な GroupShape に変換するメソッドを提供します。
#### **New Aspose.Slides.TextAlignment enum membed added (JustifyLow)**
TextAlignment 列挙型に新しいメンバーが追加されました:  
JustifyLow - カシーダ（Kashida）を使用した低レベルの両端揃え。
#### **New properties for Aspose.Slides.IOleObjectFrame and OleObjectFrame**
IOleObjectFrame インターフェイスおよびこれを実装する OleObjectFrame クラスに新しいプロパティが追加され、プレゼンテーションに埋め込まれたオブジェクトに関する情報を提供します:  
EmbeddedFileExtension - 埋め込まれたオブジェクトのファイル拡張子を返します。リンクでない場合は空文字列  
EmbeddedFileLabel - 埋め込まれた OLE オブジェクトのファイル名を返します  
EmbeddedFileName - 埋め込まれた OLE オブジェクトのパスを返します
#### **New property CategoryAxisType has been added to IAxis and Axis classes**
CategoryAxisType プロパティはカテゴリ軸の種類を指定します。

``` csharp
 using (Presentation pres = new Presentation(sourcePptxFileName))
{
   IChart chart = pres.Slides[0].Shapes[0] as IChart;
   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
   chart.Axes.HorizontalAxis.MajorUnit = 1;
   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
   pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **New property ShowLabelAsDataCallout has been added to DataLabelFormat class and IDataLabelFormat interface**
ShowLabelAsDataCallout プロパティは、指定したチャートのデータラベルがデータコールアウトとして表示されるか、データラベルとして表示されるかを決定します。

``` csharp
 using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
   pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **Property DrawSlidesFrame has been added to PdfOptions and XpsOptions**
Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions インターフェイスおよび関連クラス Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions に Boolean プロパティ DrawSlidesFrame が追加されました。このプロパティを true に設定すると、各スライドの周囲に黒いフレームが描画されます。

``` csharp
 using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```