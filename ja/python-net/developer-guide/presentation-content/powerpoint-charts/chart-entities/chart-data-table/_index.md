---
title: Python でプレゼンテーションのチャート データテーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/python-net/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションのチャート データテーブルのフォント、境界線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for Python via .NET を使用すると、チャートのデータテーブルを表示し、テキストの書式設定、境界線、凡例キーをカスタマイズできます。本記事では、テーブルの有効化、テキストの書式設定、各種境界線の制御、凡例キーの表示/非表示方法を説明します。サンプルは構成されたチャートを PPTX ファイルに保存します。

## **フォント プロパティの設定**

チャートのデータテーブルを表示するには、[has_data_table](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/has_data_table/) を `True` に設定します。[chart_data_table](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/chart_data_table/) を使用してテーブルにアクセスし、テキスト書式を設定できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。  
1. 最初のスライドにクラスター化縦棒グラフを追加します。  
1. チャートのデータテーブルを有効にします。  
1. [font_bold](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/font_bold/) で太字を有効にし、[font_height](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/font_height/) を `20` に設定して 20 ポイントのテキストにします。  
1. 変更したプレゼンテーションを保存します。

以下の例は、作業ディレクトリに少なくとも 1 枚のスライドが含まれる `test.pptx` が必要です。位置 (50, 50) に幅 600 ポイント、高さ 400 ポイントのデフォルト データのチャートを追加します。保存された `output.pptx` には、データテーブルが有効化され、指定したフォント設定が適用されたチャートが含まれます。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **データテーブルの境界線のカスタマイズ**

[Chart.has_data_table](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/has_data_table/) でテーブルを有効にし、[Chart.chart_data_table](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/chart_data_table/) でアクセスします。3 種類の境界線を個別に制御できます。

- [has_border_horizontal](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datatable/has_border_horizontal/) は水平セル境界線を制御します。  
- [has_border_vertical](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datatable/has_border_vertical/) は垂直セル境界線を制御します。  
- [has_border_outline](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datatable/has_border_outline/) はテーブルの外枠境界線を制御します。

各プロパティを `True` に設定すると境界線が表示され、`False` に設定すると非表示になります。以下の例は、デフォルト データのクラスター化縦棒グラフを作成し、水平境界線と外枠を表示し、垂直境界線を非表示にします。入力ファイルは不要です。チャートの位置とサイズはポイント単位で指定されます。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

以下の比較は、4 つのケースすべてで同じチャート データと凡例キー設定を使用しています。すべての境界線が有効な状態から開始し、各バリアントは 1 つの境界線プロパティだけを無効にします。左下のバリアントは例の境界線設定と一致します。

![すべての境界線が有効、水平境界線なし、垂直境界線なし、外枠なしのチャート データテーブル](data-table-borders.png)

## **凡例キーの表示/非表示**

凡例キーは、データテーブルの系列名の横に表示される小さな色付きマーカーです。読者が各テーブル行とチャート系列を対応付けるのに役立ちます。[show_legend_key](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datatable/show_legend_key/) を `True` に設定するとこれらのマーカーが表示され、`False` に設定すると非表示になります。

チャートの個別凡例は [Chart.has_legend](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/has_legend/) で制御します。これらの設定は独立しており、個別凡例を非表示にしてもデータテーブル内のキーは非表示にならず、テーブルのキーを非表示にしても個別凡例は非表示になりません。

以下の例は、デフォルト データのチャートを作成し、データテーブルを有効にして凡例キーを表示し、個別凡例を非表示にします。すべてのテーブル境界線は明示的に有効化されています。入力プレゼンテーションは必要ありません。テーブルのキーだけを非表示にするには、`data_table.show_legend_key` を `False` に変更します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

以下の比較は、凡例キーが有効な場合と無効な場合の同じテーブルを示しています。すべての境界線は有効のままで、個別のチャート凡例は両方とも非表示です。

![左側に凡例キーが表示され、右側に非表示のチャート データテーブル](data-table-legend-keys.png)

## **よくある質問**

**チャートのデータテーブルに凡例キーを表示できますか？**  
はい。凡例キーを表示するには [show_legend_key](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datatable/show_legend_key/) を `True` に、非表示にするには `False` に設定します。

**プレゼンテーションを PDF、HTML、または画像にエクスポートする際、データテーブルは保持されますか？**  
はい。Aspose.Slides は、エクスポート時にチャートと表示されたデータテーブルをスライドの一部としてレンダリングします。PDF にエクスポートする場合は [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、HTML にエクスポートする場合は [HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、画像にエクスポートする場合は [images](/slides/ja/python-net/convert-powerpoint-to-png/) を使用します。

**テンプレートからロードしたチャートのデータテーブルを操作できますか？**  
はい。既存のプレゼンテーションまたはテンプレートからロードしたチャートの場合、[has_data_table](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/has_data_table/) を使用してデータテーブルの表示有無を確認または変更できます。

**データテーブルが有効になっているチャートをどうやって見つけますか？**  
各スライドのシェイプを反復処理し、チャートを特定して [has_data_table](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/has_data_table/) プロパティを確認します。値が `True` の場合、データテーブルが有効になっていることを示します。