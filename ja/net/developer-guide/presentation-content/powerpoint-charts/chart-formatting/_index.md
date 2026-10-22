---
title: .NET でプレゼンテーション チャートをフォーマットする
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/net/chart-formatting/
keywords:
- チャートをフォーマット
- チャートの書式設定
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸ボーダー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET におけるチャートの書式設定を学び、カスタム軸、フォント、数値書式、角丸チャート境界を使用して PowerPoint プレゼンテーションを向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーション内のチャートの書式設定方法を説明します。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなど、主要なチャート要素をカスタマイズして、チャート データの外観と可読性を向上させる方法を示します。

また、チャート テキストのフォント プロパティの設定、数値形式のプリセット適用、チャート領域の角を丸める方法も実演します。これらの例を通じて、プレゼンテーション内のチャートのビジュアル スタイルとデータ表現の両方を制御する方法がわかります。

## **チャートエンティティの書式設定**

[IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) を使用して、チャート タイトル、軸、グリッド線、凡例、プロット領域の書式設定を行います。この例では、マーカー付きの折れ線グラフをデフォルト データで作成し、値軸とカテゴリ軸に個別のテキストと線のスタイルを適用します。フォント サイズと線の太さはポイント単位で指定し、カテゴリ ラベルは 45 度回転させます。

値軸は、ソース セルとは独立して [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) を使用します。スケールは -2 から 15 までで、メジャー間隔は 2、マイナー間隔は 0.5 です。例では、パーセンテージ書式と [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/)（千単位）を組み合わせているので、データの意味と規模に合わせて設定を調整してください。凡例は [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) が無効になっているため、プロット領域の外側に配置されます。背面壁と床の塗りつぶしは [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) と [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) で構成しますが、これらの面は 3D チャートでのみ表示されます。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **チャート テキストのフォント プロパティの設定**

[Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) を使用して、チャート テキストのデフォルト フォント サイズを設定します。この例では、20 ポイント フォントのクラスター化列グラフを作成し、[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) を使用して最初の系列の値ラベルを有効にしています。個別に明示的なフォント設定が行われたテキスト要素は、チャートのデフォルト設定を上書きできます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **数値書式の設定**

[IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) を使用して、チャート ワークブック セルに組み込み数値書式を適用します。この例では、デフォルトのセル バック データを持つクラスター化列グラフを作成し、各系列の値セルに書式インデックス 10（`0.00%`）を適用しています。これにより、基になる数値を変更せずにワークブックでの表示が変わります（例: 0.25 は 25.00% と表示）。軸およびデータ ラベルの書式は個別に設定できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

以下の表は、英語（米国）ロケール向けの代表的な Excel 書式と対応する組み込み数値書式インデックスを示しています。正確な書式文字列と表示は、アプリケーションやロケールによって異なる場合があり、特に通貨や日付で顕著です。一部の Excel 書式は、[Microsoft の数値書式実装メモ](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) に記載されている OOXML 標準のデフォルトとは異なることがあります。

| インデックス | 書式 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **チャート領域の角丸境界の設定**

[IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) を有効にして、チャート領域の角を丸めます。この例では、クラスター化列グラフを作成し、[LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) を使用してアウトラインに単色のグレーと単一本線スタイルを設定し、プレゼンテーションを保存しています。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **既存のチャート注釈の編集**

チャートには、レポートのステータスを説明するテキスト注釈など、カスタム シェイプを含めることができます。これらのシェイプは [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) で取得でき、Chart API リファレンスの [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) にも記載されています。その [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) コレクションには、チャートが所有するシェイプが含まれます。

チャート上に配置された普通のテキスト ボックスはスライドに属し、チャートの一部に見えても同様です。[Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) を反復処理すると、チャートと通常のスライド シェイプが取得できますが、チャート内部の個々のシェイプは列挙されません。チャート タイトルやデータ ラベルは別個のチャート要素であり、このコレクションのカスタム 注釈ではありません。

[chart-annotations.pptx](chart-annotations.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。最初のスライドには、未グループ化の注釈「Preliminary results」、チャート所有の線、そして「Slide overlay」というテキスト ボックスが含まれています。例では、そのスライド上の最初のチャートを取得し、レポートが公開できる状態になったときに注釈を「Final results」に変更します。コレクションが空でないか確認し、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) で非 null の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) を持ち、期待するテキストを含むものだけを編集します。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

線とスライド テキスト ボックスは変更されません。以下の画像は、入力と保存後に再度開いた結果を示しています。

| 編集前 | 編集後 |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
例はトップレベルのチャート所有シェイプのみを検査します。注釈が [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) 内にある場合は、そのグループの [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) コレクションも検査してください。入れ子になったグループに対しては同様に再帰的に処理し、子シェイプのテキストチェックを適用します。グループ自体はコンテナであり、テキスト ボックスとして扱わないでください。
{{% /alert %}}

## **FAQ**

**列やエリアに半透明の塗りつぶしを設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度とアウトラインは別々に設定できます。これにより、密に配置されたビジュアル化においてグリッドやデータの可読性を向上させることができます。

**ラベルが重なったときはどう対処すればよいですか？**

フォント サイズを小さくする、不要なラベル要素（例: カテゴリ）を非表示にする、ラベル位置を調整する、必要に応じて選択したポイントのみラベルを表示する、または「値 + 凡例」の形式に切り替えるなどの方法があります。

**系列にグラデーションやパターンの塗りつぶしを適用できますか？**

はい。系列は単色、グラデーション、パターン塗りつぶしをサポートします。実務ではグラデーションは控えめに使用し、グリッドやテキストとのコントラストが低下する組み合わせは避けてください。