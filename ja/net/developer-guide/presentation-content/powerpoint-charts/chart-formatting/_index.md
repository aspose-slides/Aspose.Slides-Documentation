---
title: .NET でプレゼンテーションのチャートをフォーマットする
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/net/chart-formatting/
keywords:
- チャートの書式設定
- チャート書式設定
- チャートエンティティ
- チャートのプロパティ
- チャート設定
- チャートオプション
- フォントのプロパティ
- 角丸境界
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET におけるチャート書式設定を学び、カスタム軸、フォント、数値形式、角丸チャート枠線で PowerPoint プレゼンテーションを向上させましょう。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーション内のグラフの書式設定方法を説明します。軸、グリッド線、タイトル、凡例、プロット領域、壁の塗りつぶしなど、主要なグラフ要素をカスタマイズして、データの外観と可読性を向上させる方法を示します。

また、グラフテキストのフォントプロパティを設定する方法、グラフデータにプリセットの数値形式を適用する方法、グラフ領域の角を丸める方法も実演します。これらの例を合わせて、プレゼンテーション内のグラフの視覚スタイルとデータ表示の両方を制御する方法がわかります。

上昇区間と下降区間で別々の塗りつぶしとアウトラインを設定する方法については、[株価チャートの例](/slides/ja/net/create-chart/#create-stock-charts)をご覧ください。

## **グラフ要素の書式設定**

[IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) を使用して、グラフのタイトル、軸、グリッド線、凡例、プロット領域の書式設定を行います。この例では、マーカー付きの折れ線グラフをデフォルトデータで作成し、値軸とカテゴリ軸に別々のテキストと線のスタイルを適用します。フォントサイズと線幅はポイントで指定し、カテゴリラベルは 45 度回転させます。

値軸はソースセルとは独立して [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) を使用します。スケールは -2 から 15 までで、主要間隔は 2、副間隔は 0.5 です。この例では、パーセンテージ書式と [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) を千単位に設定した組み合わせも示しています。データの意味と規模に合わせて設定を調整してください。凡例は [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) が無効になっているためプロット領域の外側に配置されます。バックウォールとフロアの塗りつぶしは [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) と [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) で設定しますが、これらの面は 3D グラフでのみ表示されます。

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

## **グラフのフォントプロパティを設定する**

[Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) を使用して、グラフテキストの既定フォントサイズを設定します。この例では、フォントサイズ 20 ポイントのクラスター縦棒グラフを作成し、最初の系列の値ラベルを [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) で有効にしています。個別に明示的なフォント設定が付与されたテキスト要素は、グラフの既定設定を上書きできます。

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

## **凡例のテキストフレーム書式を再利用する**

凡例をスライドの見出しに合わせるには、最初の段落の [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) にフォントを設定します。凡例の [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) に対して [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) を呼び出すと、テキストフレーム設定、最初の段落の書式、およびその段落の既定フォントプロパティが取得されます。個々の部分や後続の段落に直接適用された書式は、元のソースにローカルに残ります。

この例では、ネイビーの 26 ポイント Calibri 太字見出しをテンプレートとして使用します。凡例のスタイリング後、[CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) を使って同じ書式を別のキャプションに適用します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

保存されたプレゼンテーションでは、凡例とキャプションがサイズ、太さ、色の点で見出しと一致します。凡例は依然として系列名を表示し、キャプションは独自のテキストを保持します。キャプション内の一部に明示的なフォントサイズが設定されている場合、そのサイズがコピーされた段落の既定サイズより優先されます。

| コピー前 | コピー後 |
| --- | --- |
| ![通常の黒い凡例ラベルと黒いキャプションが付いた四半期売上グラフ](legend-formatting-before.png) | ![凡例ラベルが大きくなり、太字のネイビーに、キャプションも一致した同じグラフ](legend-formatting.png) |

## **数値形式を設定する**

[IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) を使用して、グラフのブックセルに組み込み数値形式を適用します。この例では、デフォルトのセルバックデータを持つクラスター縦棒グラフを作成し、各系列の値セルに書式インデックス 10 (`0.00%`) を適用しています。これにより、基になる数値は変わらずにブック上での表示が 0.25 → 25.00% のように変更されます。軸とデータラベルの書式は別々に設定可能です。

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

以下の表は、英語（米国）ロケール向けの代表的な Excel 書式とともに、組み込み数値形式インデックスを一覧にしたものです。正確な書式文字列と表示はアプリケーションやロケールにより異なる場合があり、特に通貨や日付で顕著です。一部の Excel 書式は OOXML 標準の既定書式と異なることがあり、詳細は [Microsoft の数値形式実装ノート](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) を参照してください。

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

## **グラフ領域の角丸境界を設定する**

[IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) を有効にして、グラフ領域の角を丸めます。この例では、クラスター縦棒グラフを作成し、[LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) を使用して輪郭を単色のグレーにし、単一線スタイルを設定した上でプレゼンテーションを保存します。

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

## **既存のグラフ注釈を編集する**

グラフには、レポートのステータスを説明するテキスト注釈などのカスタム形状を含めることができます。これらの形状は [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) から取得でき、Chart API Reference の [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) にも一覧化されています。その [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) コレクションには、グラフが所有する形状が含まれます。

グラフ上に配置された普通のテキストボックスはスライドに属し、グラフの一部に見えてもスライドの形状として扱われます。[Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) を列挙すると、グラフとスライド上の普通の形状は取得できますが、グラフ内部の個々の形状は列挙されません。グラフのタイトルやデータラベルは別個のグラフ要素であり、このコレクションのカスタム注釈には含まれません。

[chart-annotations.pptx](chart-annotations.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。最初のスライドには、"Preliminary results" という未グループ化の注釈、グラフが所有する線、"Slide overlay" という普通のスライドテキストボックスが含まれています。この例では、そのスライド上の最初のグラフを取得し、レポートの公開準備が整ったら注釈を "Final results" に変更します。コレクションが空でないかチェックし、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) で非 null の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) を持ち、期待するテキストが含まれるものだけを編集します。

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

線とスライドのテキストボックスは変更されません。以下の画像は、入力と保存後に再度開いた結果を示しています。

| 編集前 | 編集後 |
| --- | --- |
| ![「Preliminary results」と表示されたチャート注釈](chart-annotations-before.png) | ![「Final results」と表示されたチャート注釈](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}

この例はトップレベルのグラフ所有形状のみを検査します。注釈が [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) 内にある場合は、そのグループの [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) コレクションも検査してください。入れ子になったグループに対しても同様に再帰的に処理し、子形状に対して同じテキストチェックを適用します。グループ自体はコンテナであり、テキストボックスとして扱わないでください。

{{% /alert %}}

## **FAQ**

**列や領域に半透明の塗りつぶしを設定し、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度と輪郭は個別に設定できます。これにより、密集した可視化においてグリッドやデータの可読性を向上させることができます。

**ラベルが重なった場合、どのように対処すればよいですか？**

フォントサイズを縮小する、不要なラベル要素（例：カテゴリ）を非表示にする、ラベル位置を調整する、必要に応じて選択したポイントのみラベルを表示する、または形式を「値＋凡例」に切り替えるなどの方法があります。

**系列に対してグラデーションやパターンの塗りつぶしを適用できますか？**

はい。系列は単色、グラデーション、パターンの塗りつぶしをサポートします。実務では、グラデーションは控えめに使用し、グリッドやテキストとのコントラストが低下する組み合わせは避けてください。