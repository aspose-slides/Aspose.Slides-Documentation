---
title: Aspose.Slides for .NET 16.2.0における公開APIおよび後方互換性のない変更
type: docs
weight: 230
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 16.2.0 APIで追加されたまたは削除されたすべての[追加された](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)または[削除された](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)クラス、メソッド、プロパティなど、およびその他の変更をリストしています。

{{% /alert %}} 
## **公開APIの変更**
#### **プロパティUpdateDateTimeFieldsおよびUpdateSlideNumberFieldsが削除されました**
プロパティUpdateDateTimeFieldsおよびUpdateSlideNumberFieldsは、Aspose.Slides.PresentationクラスおよびAspose.Slides.IPresentationインターフェースから削除されました。
Aspose.Slides.TextFrame、Paragraph、PortionクラスおよびAspose.Slides.ITextFrame、IParagraph、IPortionインターフェースのTextプロパティは、更新された「datetime」フィールドを持つテキストを返します。
また、プロパティPresentation.DocumentProperties.CreatedTime、LastSavedTimeおよびLastPrintedは読み取り専用になりました。
#### **Enum Slides.Charts.CategoryAxisTypeが公開に切り替えられました**
IAxis.CategoryAxisTypeおよびAxis.CategoryAxisTypeプロパティで使用され、カテゴリー軸のタイプを決定します。
CategoryAxisType.Auto - カテゴリー軸タイプはシリアル化中に自動的に決定されます（この動作は今は実装されていません）
CategoryAxisType.Text - カテゴリー軸タイプはテキストです
CategoryAxisType.Date - カテゴリー軸タイプはDateTimeです
#### **高速テキスト抽出**
新しい静的メソッドGetPresentationTextがPresentationクラスに追加されました。このメソッドには2つのオーバーロードがあります：

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode enum引数は、テキスト結果の出力を整理するモードを示し、次の値に設定できます：
Unarranged - スライド上の位置に関係なく生のテキスト
Arranged - テキストはスライド上の順序と同じ順序で配置されます

Unarrangedモードは、速度が重要な場合に使用されます。これはArrangedモードよりも速いです。

PresentationTextはプレゼンテーションから抽出された生のテキストを表します。これはAspose.Slides.Util名前空間のSlidesTextプロパティを含み、ISlideTextオブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。ISlideTextオブジェクトには次のプロパティがあります：

ISlideText.Text - スライドのシェイプ上のテキスト
ISlideText.MasterText - このスライドのマスターページのシェイプ上のテキスト
ISlideText.LayoutText - このスライドのレイアウトページのシェイプ上のテキスト
ISlideText.NotesText - このスライドのノートページのシェイプ上のテキスト

ISlideTextインターフェースを実装するSlideTextクラスもあります。

新しいAPIは次のように使用できます：

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **ILegacyDiagramインターフェースおよびLegacyDiagramクラスが追加されました**
インターフェースAspose.Slides.ILegacyDiagramおよびクラスAspose.Slides.LegacyDiagramは、レガシーダイアグラムオブジェクトを表すために追加されました。レガシーダイアグラムオブジェクトは、PowerPoint 97-2003の古いダイアグラムフォーマットです。
新しいクラスは、レガシーダイアグラムを現代の編集可能なSmartArtオブジェクトまたは編集可能なGroupShapeに変換するためのメソッドを提供します。
#### **新しいAspose.Slides.TextAlignment enumメンバーが追加されました (JustifyLow)**
TextAlignment enumの新しいメンバーが追加されました：
JustifyLow - カシダの低い整列。
#### **Aspose.Slides.IOleObjectFrameおよびOleObjectFrameの新しいプロパティ**
IOleObjectFrameインターフェースおよびこのインターフェースを実装するOleObjectFrameクラスに新しいプロパティが追加されました。これらのプロパティは、プレゼンテーションに埋め込まれたオブジェクトに関する情報を提供するために使用されます：
EmbeddedFileExtension - 現在の埋め込まれたオブジェクトのファイル拡張子を返すか、オブジェクトがリンクでない場合は空の文字列を返します
EmbeddedFileLabel - 埋め込まれたOLEオブジェクトのファイル名を返します
EmbeddedFileName - 埋め込まれたOLEオブジェクトのパスを返します
#### **IAxisおよびAxisクラスに新しいプロパティCategoryAxisTypeが追加されました**
プロパティCategoryAxisTypeは、カテゴリー軸のタイプを指定します。

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
#### **DataLabelFormatクラスおよびIDataLabelFormatインターフェースに新しいプロパティShowLabelAsDataCalloutが追加されました**
プロパティShowLabelAsDataCalloutは、指定されたチャートのデータラベルがデータコールアウトとして表示されるか、データラベルとして表示されるかを決定します。

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
#### **PdfOptionsおよびXpsOptionsにDrawSlidesFrameプロパティが追加されました**
BooleanプロパティDrawSlidesFrameがインターフェースAspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptionsおよび関連クラスAspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptionsに追加されました。
このプロパティが'true'に設定されている場合、各スライドの周りに黒いフレームが描画されます。

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

``` 