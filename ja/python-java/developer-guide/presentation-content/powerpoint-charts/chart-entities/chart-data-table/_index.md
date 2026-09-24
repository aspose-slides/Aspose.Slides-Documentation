---
title: Python を使用したプレゼンテーションのチャート データテーブルのカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/python-java/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションのチャート データテーブルのフォント、枠線、凡例キーをカスタマイズします。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、チャートのデータテーブルを表示し、テキストの書式設定、枠線、凡例キーをカスタマイズできます。この記事では、テーブルの有効化、テキストの書式設定、各種枠線の制御、および凡例キーの表示/非表示の方法を説明します。例では、設定したチャートを PPTX ファイルに保存します。

## **フォント プロパティの設定**

チャートのデータテーブルを表示するには、`True` を [setDataTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDataTable) に渡します。[getChartDataTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#getChartDataTable) を使用してテーブルにアクセスし、テキストの書式設定を構成します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
1. 最初のスライドにクラスター化された縦棒グラフを追加します。
1. チャートのデータテーブルを有効にします。
1. [setFontBold](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setFontBold) で太字を有効にし、[setFontHeight](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setFontHeight) に `20` を渡して 20 ポイントのテキストにします。
1. 変更したプレゼンテーションを保存します。

次の例では、作業ディレクトリに少なくとも 1 枚のスライドが含まれる `test.pptx` が必要です。位置 (50, 50) に幅 600 ポイント、高さ 400 ポイントのデフォルト データのチャートを追加します。保存された `output.pptx` には、データテーブルが有効化され、指定したフォント設定が適用されたチャートが含まれます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **データテーブルの枠線をカスタマイズ**

[Chart.setDataTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDataTable) でテーブルを有効にし、[Chart.getChartDataTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#getChartDataTable) で取得します。以下の 3 種類の枠線を個別に制御できます。

- [setBorderHorizontal](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datatable/#setBorderHorizontal) は水平セル枠線を制御します。
- [setBorderVertical](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datatable/#setBorderVertical) は垂直セル枠線を制御します。
- [setBorderOutline](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datatable/#setBorderOutline) はテーブルの外枠を制御します。

各メソッドに `True` を渡すと枠線が表示され、`False` を渡すと非表示になります。次の例は、デフォルト データのクラスター化縦棒グラフを作成し、水平枠線と外枠を表示し、垂直枠線を非表示にします。入力ファイルは不要です。チャートの位置とサイズはポイント単位で指定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下の比較は、同じチャート データと凡例キー設定を 4 つのケースで使用しています。すべての枠線を有効にした状態から、残りのバリアントはそれぞれ 1 つの枠線設定だけを無効にします。左下のバリアントが例の枠線設定と一致します。

![すべての枠線が有効、水平枠線なし、垂直枠線なし、外枠なしのチャート データテーブル](data-table-borders.png)

## **凡例キーの表示または非表示**

凡例キーは、データテーブルの系列名の横に表示される小さな色付きマーカーです。テーブルの各行をチャートの系列に対応させるのに役立ちます。[setShowLegendKey](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datatable/#setShowLegendKey) に `True` を渡すとこれらのマーカーが表示され、`False` を渡すと非表示にできます。

個別のチャート凡例は [Chart.setLegend](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setLegend) で制御します。これらの設定は独立しており、個別凡例を非表示にしてもデータテーブル内のキーは非表示にならず、テーブルのキーを非表示にしても個別凡例は影響を受けません。

次の例は、デフォルト データのチャートを作成し、データテーブルを有効にして凡例キーを表示し、個別凡例を非表示にします。すべてのテーブル枠線は明示的に有効化されています。入力プレゼンテーションは不要です。テーブルのキーだけを非表示にしたい場合は、[setShowLegendKey](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datatable/#setShowLegendKey) に `False` を渡します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下の比較は、凡例キーが有効なテーブルと無効なテーブルを同じチャートで示しています。すべての枠線は引き続き有効で、個別のチャート凡例は両方のケースで非表示です。

![左側に凡例キーが表示され、右側に非表示のチャート データテーブル](data-table-legend-keys.png)

## **よくある質問**

**チャートのデータテーブルに凡例キーを表示できますか？**

はい。`True` を [setShowLegendKey](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datatable/#setShowLegendKey) に渡すと凡例キーが表示され、`False` を渡すと非表示にできます。

**PDF、HTML、画像にエクスポートする際にデータテーブルは保持されますか？**

はい。Aspose.Slides はスライドの一部としてチャートと表示されたデータテーブルをレンダリングし、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/python-java/convert-powerpoint-to-html/)、[画像](/slides/ja/python-java/convert-powerpoint-to-png/) にエクスポートします。

**テンプレートからロードしたチャートのデータテーブルを操作できますか？**

はい。既存のプレゼンテーションまたはテンプレートからロードしたチャートについては、[hasDataTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#hasDataTable) と [setDataTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDataTable) を使用して、データテーブルが表示されているかどうかを確認または変更できます。

**データテーブルが有効になっているチャートを検索する方法は？**

各スライドのシェイプを列挙し、チャートを特定して、[hasDataTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#hasDataTable) メソッドを呼び出します。戻り値が `True` の場合、データテーブルが有効になっていることを示します。