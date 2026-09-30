---
title: .NET でプレゼンテーションのチャート凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/net/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してチャート凡例をカスタマイズし、カスタム書式設定された凡例で PowerPoint プレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides for .NET は、PowerPoint プレゼンテーションにおけるチャート凡例のカスタマイズオプションを提供します。この記事では、凡例の位置とサイズの設定、凡例全体のフォントサイズの設定、個々の凡例エントリの書式設定、選択したエントリの非表示または復元方法を示します。

FAQ では、凡例のスペース確保、複数行ラベルの表示、プレゼンテーションテーマからの書式継承など、関連する動作について説明します。

## **凡例の位置指定**

凡例の [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) および [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) プロパティを使用して、チャートの寸法に対する割合で位置とサイズを指定します。

この例では、プレゼンテーションを作成し、デフォルトデータを使用したクラスター化列グラフを最初のスライドに追加します。目的の凡例のオフセットと寸法をチャートの幅と高さで割ることで相対値に変換します。凡例はチャートの左上隅から 50 ポイントオフセットし、サイズは 100×100 ポイントになります。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **凡例のフォントサイズの設定**

凡例の [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) を使用してテキスト書式にアクセスし、[FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) をポイントで設定します。

この例では、デフォルトデータのチャートを作成し、凡例テキストを 20 ポイントに設定します。また、縦軸の自動範囲を無効にし、範囲を -5 から 10 に設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **個別の凡例エントリのフォントサイズの設定**

凡例の [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) コレクションを使用して特定のエントリの書式にアクセスします。エントリのインデックスはゼロベースなので、インデックス `1` は2番目のエントリを指します。

この例では、デフォルトデータに少なくとも2つの系列が含まれるクラスター化列グラフを作成します。2番目の凡例エントリを太字・斜体・20ポイントの青色テキストで書式設定します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **個別の凡例エントリを非表示にする**

補助系列をデータは表示したまま凡例から除外するには、[ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) を `true` に設定し、[IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) を介して行います。これにより選択した凡例エントリのみが非表示になり、系列やデータポイントは削除されません。対照的に、[IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) を `false` に設定すると、凡例全体が非表示になります。

以下の例では、デフォルトデータを使用して複数系列のクラスター化列グラフを作成します。第2系列の凡例エントリ（インデックス `1`）を非表示にしてプレゼンテーションを保存します。その後、`Hide` を `false` に設定してエントリを復元し、2番目のコピーを保存します。列は両方のファイルで表示されたままです。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// チャートデータを変更せずに同じエントリを復元します。
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

以下の比較では、すべてのエントリが表示され、シリーズ 2 が凡例から非表示になったチャートの比較；すべての列は表示されたままです。

![すべての凡例エントリが表示され、シリーズ 2 が凡例から非表示になったチャートの比較；すべての列は表示されたまま。](hide-legend-entry.png)

柱状、棒、折れ線チャートでは、凡例エントリは系列を識別します。円グラフでは、個々のデータポイント（スライス）を識別するため、代わりに選択したスライスに対して [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) を使用します。API はこのデータポイントプロパティを `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, `BarOfPie` の各チャートタイプに対してドキュメント化しています。ドーナツチャートには適用されないことに注意してください。

## **よくある質問**

**チャートが凡例の上に重なるのではなく、凡例のためにスペースを確保するようにできますか？**

はい。[Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) を `false` に設定すると、プロット領域に重ねるのではなく凡例用のスペースを確保できます。

**複数行の凡例ラベルを作成できますか？**

はい。利用可能な幅が不足している場合、長いラベルは折り返されます。系列名に改行文字を含めて改行を指定することもできます。

**凡例をプレゼンテーションテーマのカラースキームに従わせるにはどうすればよいですか？**

凡例の色、塗りつぶし、フォントを設定しないままにしておくと、テーマの書式設定を継承します。明示的な書式設定は対応するテーマ設定を上書きします。