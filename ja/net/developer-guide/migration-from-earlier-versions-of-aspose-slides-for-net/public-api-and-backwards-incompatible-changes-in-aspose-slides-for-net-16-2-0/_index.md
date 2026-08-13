---
title: Aspose.Slides for .NET 16.2.0 の公開 API と下位互換性のない変更
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
description: "Aspose.Slides for .NET の公開 API 更新および破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーションソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for .NET 16.2.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)されたクラス、メソッド、プロパティ等、およびその他の変更をすべて一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **プロパティ UpdateDateTimeFields および UpdateSlideNumberFields が削除されました**
Aspose.Slides.Presentation クラスおよび Aspose.Slides.IPresentation インターフェイスから、プロパティ UpdateDateTimeFields と UpdateSlideNumberFields が削除されました。  
Aspose.Slides.TextFrame、Paragraph、Portion クラスおよび Aspose.Slides.ITextFrame、IParagraph、IPortion インターフェイスの Text プロパティは、更新された「datetime」フィールドを含むテキストを返します。  
また、Presentation.DocumentProperties.CreatedTime、LastSavedTime、LastPrinted の各プロパティは読み取り専用になりました。  

#### **列挙体 Slides.Charts.CategoryAxisType がパブリックに変更されました**
IAxis.CategoryAxisType および Axis.CategoryAxisType プロパティで、カテゴリ軸のタイプを決定するために使用されます。  

CategoryAxisType.Auto - カテゴリ軸のタイプはシリアライズ時に自動的に決定されます（この動作は現在実装されていません）  
CategoryAxisType.Text - カテゴリ軸のタイプは Text です  
CategoryAxisType.Date - カテゴリ軸のタイプは DateTime です  

#### **高速テキスト抽出**
Presentation クラスに新しい静的メソッド GetPresentationText が追加されました。このメソッドには 2 つのオーバーロードがあります：

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 列挙体の引数は、テキスト結果の出力方式を示し、次の値に設定できます：  
Unarranged - スライド上の位置を考慮せずに取得した生テキスト  
Arranged - テキストがスライド上の順序と同じ順序で配置されます  

速度が重要な場合は Unarranged モードを使用できます。Arranged モードよりも高速です。  

PresentationText はプレゼンテーションから抽出された生テキストを表します。Aspose.Slides.Util 名前空間の SlidesText プロパティを含み、ISlideText オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。ISlideText オブジェクトは以下のプロパティを持ちます：  

- ISlideText.Text - スライドのシェイプ上のテキスト  
- ISlideText.MasterText - このスライドのマスターページ上のシェイプのテキスト  
- ISlideText.LayoutText - このスライドのレイアウトページ上のシェイプのテキスト  
- ISlideText.NotesText - このスライドのノートページ上のシェイプのテキスト  

また、ISlideText インターフェイスを実装する SlideText クラスもあります。  

新しい API は以下のように使用できます：

``` csharp
using System;
using Aspose.Slides;

// スライド上の位置を考慮せずにテキストを抽出します（最速モード）。
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// スライド上の順序と同じ順序でテキストを抽出します。
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 

#### **ILegacyDiagram インターフェイスと LegacyDiagram クラスが追加されました**
Aspose.Slides.ILegacyDiagram インターフェイスと Aspose.Slides.LegacyDiagram クラスが、レガシーダイアグラムオブジェクトを表すために追加されました。レガシーダイアグラムオブジェクトは、PowerPoint 97-2003 の古い形式のダイアグラムです。  
新しいクラスは、レガシーダイアグラムを最新の編集可能な SmartArt オブジェクトまたは編集可能な GroupShape に変換するメソッドを提供します。  

#### **新しい Aspose.Slides.TextAlignment 列挙体メンバーが追加されました (JustifyLow)**
TextAlignment 列挙体に新しいメンバーが追加されました:  
JustifyLow - Kashida で低レベルの両端揃えです。  

#### **Aspose.Slides.IOleObjectFrame と OleObjectFrame の新しいプロパティ**
IOleObjectFrame インターフェイスと、これを実装する OleObjectFrame クラスに新しいプロパティが追加されました。これらのプロパティは、プレゼンテーションに埋め込まれたオブジェクトに関する情報を提供するために使用されます：  

- EmbeddedFileExtension - 現在の埋め込みオブジェクトのファイル拡張子を返します。オブジェクトがリンクでない場合は空文字列です。  
- EmbeddedFileLabel - 埋め込み OLE オブジェクトのファイル名を返します。  
- EmbeddedFileName - 埋め込み OLE オブジェクトのパスを返します。  

#### **IAxis と Axis クラスに新しいプロパティ CategoryAxisType が追加されました**
CategoryAxisType プロパティはカテゴリ軸のタイプを指定します。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

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
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

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
ブール型プロパティ DrawSlidesFrame が、インターフェイス Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions および関連クラス Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions に追加されました。  
このプロパティが true に設定されている場合、各スライドの周囲に黒いフレームが描画されます。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```