---
title: .NET のプレゼンテーションでチャート データ テーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/net/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET と C# を使用して、PowerPoint プレゼンテーションのチャート データ テーブルのフォント、枠線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for .NETは、チャートのデータテーブルを表示し、テキストの書式設定、枠線、凡例キーをカスタマイズできます。この記事では、テーブルの有効化、テキストの書式設定、各種枠線の制御、凡例キーの表示または非表示の方法を説明します。例では、設定したチャートをPPTXファイルに保存します。

## **フォント プロパティの設定**

チャートのデータテーブルを表示するには、[HasDataTable](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/hasdatatable/) を `true` に設定します。[ChartDataTable](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/chartdatatable/) を使用してテーブルにアクセスし、テキスト書式を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションを読み込みます。
1. 最初のスライドにクラスター化縦棒チャートを追加します。
1. チャートのデータテーブルを有効にします。
1. 太字テキストを[FontBold](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/fontbold/)で有効にし、[FontHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/fontheight/) を `20` に設定して 20 ポイントのテキストにします。
1. 変更されたプレゼンテーションを保存します。

次の例は、作業ディレクトリに少なくとも 1 枚のスライドがある `test.pptx` を必要とします。位置 (50, 50)、幅 600 ポイント、高さ 400 ポイントのデフォルト データのチャートを追加します。保存された `output.pptx` には、データテーブルが有効になり、指定したフォント設定が適用されたチャートが含まれます。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **データテーブル枠線のカスタマイズ**

[IChart.HasDataTable](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/hasdatatable/) でテーブルを有効にし、[IChart.ChartDataTable](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/chartdatatable/) でアクセスします。枠線は 3 種類を個別に制御できます。

- [HasBorderHorizontal](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatatable/hasborderhorizontal/) は水平セル枠線を制御します。
- [HasBorderVertical](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatatable/hasbordervertical/) は垂直セル枠線を制御します。
- [HasBorderOutline](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatatable/hasborderoutline/) はテーブルの外枠を制御します。

各プロパティを `true` に設定すると枠線が表示され、`false` に設定すると非表示になります。次の例は、デフォルト データのクラスター化縦棒チャートを作成し、水平枠線と外枠を表示し、垂直枠線を非表示にします。入力ファイルは不要です。チャートの位置とサイズはポイントで指定されます。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

下の比較では、すべてのケースで同じチャートデータと凡例キー設定を使用しています。すべての枠線が有効な状態から、残りの各バリアントは 1 つの枠線プロパティだけを無効にします。左下のバリアントが例の枠線設定と一致します。

![全枠線有効、水平枠線なし、垂直枠線なし、外枠なしのチャート データテーブル](data-table-borders.png)

## **凡例キーの表示または非表示**

凡例キーは、データテーブルの系列名の横にある小さな色付きマーカーです。読者が各テーブル行とチャート系列を対応させるのに役立ちます。[ShowLegendKey](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatatable/showlegendkey/) を `true` に設定するとこれらのマーカーが表示され、`false` に設定すると非表示になります。

チャートの個別凡例は[IChart.HasLegend](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/haslegend/)で制御されます。これらの設定は独立しており、個別凡例を非表示にしてもデータテーブル内のキーは非表示にならず、テーブルのキーを非表示にしても個別凡例は非表示になりません。

次の例は、デフォルト データのチャートを作成し、データテーブルを有効にして、個別凡例を非表示にしながらテーブル内に凡例キーを表示します。すべてのテーブル枠線が明示的に有効化されています。入力プレゼンテーションは不要です。テーブルのキーだけを非表示にするには、`dataTable.ShowLegendKey` を `false` に変更します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

下の比較では、凡例キーが有効な場合と無効な場合の同じテーブルを示します。すべての枠線は有効なままで、個別のチャート凡例は両方の場合で非表示です。

![左側に凡例キーが表示され、右側に非表示のチャート データテーブル](data-table-legend-keys.png)

## **FAQ**

**チャートのデータテーブルに凡例キーを表示できますか？**

はい。[ShowLegendKey](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/datatable/showlegendkey/) を `true` に設定すると凡例キーが表示され、`false` に設定すると非表示になります。

**プレゼンテーションを PDF、HTML、または画像にエクスポートするときにデータテーブルは保持されますか？**

はい。Aspose.Slides は、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/net/convert-powerpoint-to-html/)、[images](/slides/ja/net/convert-powerpoint-to-png/) にエクスポートする際、スライドの一部としてチャートと表示されたデータテーブルをレンダリングします。

**テンプレートからロードしたチャートのデータテーブルを操作できますか？**

はい。既存のプレゼンテーションまたはテンプレートからロードしたチャートについては、[HasDataTable](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/hasdatatable/) を使用してデータテーブルが表示されているかどうかを確認・変更できます。

**データテーブルが有効になっているチャートを見つけるにはどうすればよいですか？**

各スライド上のシェイプを走査し、チャートを特定して[HasDataTable](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/hasdatatable/)プロパティを確認します。`true` の値はデータテーブルが有効であることを示します。