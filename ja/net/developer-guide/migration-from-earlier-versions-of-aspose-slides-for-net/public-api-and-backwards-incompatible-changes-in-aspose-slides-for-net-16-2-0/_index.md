---
title: Aspose.Slides for .NET 16.2.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 
このページでは、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)されたクラス、メソッド、プロパティなど、その他の変更を一覧表示します。これらは Aspose.Slides for .NET 16.2.0 API で導入されたものです。 
{{% /alert %}} 
## **パブリック API の変更**
#### **Properties UpdateDateTimeFields と UpdateSlideNumberFields が削除されました**
Aspose.Slides.Presentation クラスおよび Aspose.Slides.IPresentation インターフェイスから Properties UpdateDateTimeFields と UpdateSlideNumberFields が削除されました。  
Aspose.Slides.TextFrame、Paragraph、Portion クラスおよび Aspose.Slides.ITextFrame、IParagraph、IPortion インターフェイスの Text プロパティは、更新された "datetime" フィールドを含むテキストを返します。  
また、プロパティ Presentation.DocumentProperties.CreatedTime、LastSavedTime、LastPrinted は読み取り専用になりました。  
#### **Enum Slides.Charts.CategoryAxisType がパブリックに変更されました**
IAxis.CategoryAxisType と Axis.CategoryAxisType プロパティで使用され、カテゴリ軸のタイプを決定します。  
CategoryAxisType.Auto - シリアル化中にカテゴリ軸のタイプが自動的に決定されます（この動作は現在実装されていません）  
CategoryAxisType.Text - カテゴリ軸のタイプは Text です  
CategoryAxisType.Date - カテゴリ軸のタイプは DateTime です  
#### **高速テキスト抽出**
Presentation クラスに新しい静的メソッド GetPresentationText が追加されました。このメソッドには 2 つのオーバーロードがあります:
``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 列挙型の引数は、テキスト結果の出力方式を示し、次の値に設定できます:
Unarranged - スライド上の位置を考慮しない生テキスト  
Arranged - テキストがスライド上の順序と同じ位置に配置されます  

速度が重要な場合は Unarranged モードを使用できます。Arranged モードより高速です。

PresentationText はプレゼンテーションから抽出された生テキストを表します。Aspose.Slides.Util 名前空間の SlidesText プロパティを含み、ISlideText オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。ISlideText オブジェクトは次のプロパティを持ちます:
ISlideText.Text - スライドのシェイプ上のテキスト  
ISlideText.MasterText - このスライドのマスターページ上のシェイプのテキスト  
ISlideText.LayoutText - このスライドのレイアウトページ上のシェイプのテキスト  
ISlideText.NotesText - このスライドのノートページ上のシェイプのテキスト  

ISlideText インターフェイスを実装する SlideText クラスもあります。  

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
Aspose.Slides.ILegacyDiagram インターフェイスと Aspose.Slides.LegacyDiagram クラスが、レガシーダイアグラムオブジェクトを表すために追加されました。レガシーダイアグラムオブジェクトは、PowerPoint 97-2003 の旧形式のダイアグラムです。  
新しいクラスは、レガシーダイアグラムを最新の編集可能な SmartArt オブジェクトまたは編集可能な GroupShape に変換するメソッドを提供します。  
#### **新しい Aspose.Slides.TextAlignment 列挙型メンバーが追加 (JustifyLow)**
TextAlignment 列挙型に新しいメンバーが追加されました:  
JustifyLow - カシダ低位置揃え。  
#### **Aspose.Slides.IOleObjectFrame と OleObjectFrame の新しいプロパティ**
IOleObjectFrame インターフェイスと、これを実装する OleObjectFrame クラスに新しいプロパティが追加されました。これらのプロパティは、プレゼンテーションに埋め込まれたオブジェクトの情報を提供するために使用されます:
EmbeddedFileExtension - 現在の埋め込みオブジェクトのファイル拡張子を返します。リンクでない場合は空文字列です  
EmbeddedFileLabel - 埋め込み OLE オブジェクトのファイル名を返します  
EmbeddedFileName - 埋め込み OLE オブジェクトのパスを返します  
#### **IAxis と Axis クラスに新しいプロパティ CategoryAxisType が追加されました**
CategoryAxisType プロパティはカテゴリ軸のタイプを指定します。  
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
#### **DataLabelFormat クラスと IDataLabelFormat インターフェイスに新しいプロパティ ShowLabelAsDataCallout が追加されました**
ShowLabelAsDataCallout プロパティは、指定されたチャートのデータラベルがデータコールアウトとして表示されるか、データラベルとして表示されるかを決定します。  
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
#### **PdfOptions と XpsOptions に DrawSlidesFrame プロパティが追加されました**
ブール型プロパティ DrawSlidesFrame がインターフェイス Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions および関連クラス Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions に追加されました。  
このプロパティが true に設定されていると、各スライドの周囲に黒フレームが描画されます。  
``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```