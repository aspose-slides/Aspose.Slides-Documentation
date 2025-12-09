---
title: Aspose.Slides for .NET 16.2.0のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 16.2.0 APIで導入された、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)されたクラス、メソッド、プロパティなど、その他の変更をすべて一覧表示します。

{{% /alert %}} 
## **Public API の変更**
#### **Properties UpdateDateTimeFields と UpdateSlideNumberFields が削除されました**
Properties UpdateDateTimeFields と UpdateSlideNumberFields は Aspose.Slides.Presentation クラスおよび Aspose.Slides.IPresentation インターフェイスから削除されました。  
Aspose.Slides.TextFrame、Paragraph、Portion クラスおよび Aspose.Slides.ITextFrame、IParagraph、IPortion インターフェイスの Text プロパティは、更新された「datetime」フィールドを含むテキストを返します。  
また、プロパティ Presentation.DocumentProperties.CreatedTime、LastSavedTime、および LastPrinted は読み取り専用になりました。  

#### **Enum Slides.Charts.CategoryAxisType が public に変更されました**
IAxis.CategoryAxisType および Axis.CategoryAxisType プロパティで、カテゴリ軸のタイプを決定するために使用されます。  

CategoryAxisType.Auto - カテゴリ軸タイプはシリアライズ時に自動的に決定されます（この動作は現在実装されていません）  
CategoryAxisType.Text - カテゴリ軸タイプは Text です  
CategoryAxisType.Date - カテゴリ軸タイプは DateTime です  

#### **高速テキスト抽出**
Presentation クラスに新しい static メソッド GetPresentationText が追加されました。このメソッドには 2 つのオーバーロードがあります。

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 列挙体の引数は、テキスト結果の出力方式を示し、次の値に設定できます。  
Unarranged - スライド上の位置を考慮せずに生のテキストが出力されます  
Arranged - テキストはスライド上の順序と同じ順序で配置されます  

速度が重要な場合は Unarranged モードを使用できます。Arranged モードよりも高速です。  

PresentationText はプレゼンテーションから抽出された生テキストを表します。Aspose.Slides.Util 名前空間の SlidesText プロパティを含み、ISlideText オブジェクトの配列を返します。各オブジェクトは対応するスライドのテキストを表します。ISlideText オブジェクトは以下のプロパティを持ちます。  
ISlideText.Text - スライドのシェイプ上のテキスト  
ISlideText.MasterText - このスライドのマスターページのシェイプ上のテキスト  
ISlideText.LayoutText - このスライドのレイアウトページのシェイプ上のテキスト  
ISlideText.NotesText - このスライドのノートページのシェイプ上のテキスト  

また、ISlideText インターフェイスを実装する SlideText クラスもあります。  

新しい API は以下のように使用できます。

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **ILegacyDiagram インターフェイスと LegacyDiagram クラスが追加されました**
Aspose.Slides.ILegacyDiagram インターフェイスと Aspose.Slides.LegacyDiagram クラスが、レガシーダイアグラムオブジェクトを表すために追加されました。レガシーダイアグラムオブジェクトは、PowerPoint 97-2003 の古い形式のダイアグラムです。  
新しいクラスは、レガシーダイアグラムを最新の編集可能な SmartArt オブジェクトまたは編集可能な GroupShape に変換するメソッドを提供します。  

#### **新しい Aspose.Slides.TextAlignment 列挙体メンバーが追加されました (JustifyLow)**
TextAlignment 列挙体に新しいメンバーが追加されました。  
JustifyLow - カシダ（Kashida）による低い揃え。  

#### **Aspose.Slides.IOleObjectFrame と OleObjectFrame の新しいプロパティ**
IOleObjectFrame インターフェイスと、これを実装する OleObjectFrame クラスに新しいプロパティが追加されました。これらのプロパティは、プレゼンテーションに埋め込まれたオブジェクトに関する情報を提供します。  
EmbeddedFileExtension - 現在の埋め込みオブジェクトのファイル拡張子を返します。オブジェクトがリンクでない場合は空文字列を返します  
EmbeddedFileLabel - 埋め込み OLE オブジェクトのファイル名を返します  
EmbeddedFileName - 埋め込み OLE オブジェクトのパスを返します  

#### **CategoryAxisType プロパティが IAxis と Axis クラスに追加されました**
CategoryAxisType プロパティは、カテゴリ軸のタイプを指定します。

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
#### **ShowLabelAsDataCallout プロパティが DataLabelFormat クラスと IDataLabelFormat インターフェイスに追加されました**
ShowLabelAsDataCallout プロパティは、指定したチャートのデータラベルをデータコールアウトとして表示するか、データラベルとして表示するかを決定します。

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
#### **DrawSlidesFrame プロパティが PdfOptions と XpsOptions に追加されました**
ブール型プロパティ DrawSlidesFrame がインターフェイス Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions および関連クラス Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions に追加されました。このプロパティを true に設定すると、各スライドの周囲に黒いフレームが描画されます。

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```