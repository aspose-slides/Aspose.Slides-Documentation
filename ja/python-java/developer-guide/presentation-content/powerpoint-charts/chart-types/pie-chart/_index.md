---
title: Python via Java を使用したプレゼンテーションの円グラフカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/python-java/pie-chart/
keywords:
- 円グラフ
- チャートの管理
- チャートのカスタマイズ
- チャートオプション
- チャート設定
- プロットオプション
- スライスカラー
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用し、Python via Java で円グラフを作成およびカスタマイズする方法を学び、PowerPoint へエクスポートしてデータストーリーテリングを数秒で強化できます。"
---
## **概要**

本稿では、Aspose.Slidesで円グラフを扱う方法を説明します。Pie of Pie および Bar of Pie チャートのセカンドプロットオプションの設定方法と、標準的な円グラフのスライスの自動着色を有効にする方法を示します。

例では、スライドへのチャート追加、系列およびラベル設定の調整、デフォルトのチャートデータをカスタムのカテゴリと値に置き換えること、そして更新されたプレゼンテーションの保存といった、実用的なチャートカスタマイズ手順に焦点を当てています。

## **Pie of Pie と Bar of Pie チャートのセカンドプロットオプション**

Aspose.Slides for Python via Java は、Pie of Pie および Bar of Pie チャートのセカンドプロットオプションをサポートしています。このセクションでは、Aspose.Slides を使用してそれらのオプションを指定する方法を示します。以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトのインスタンスを作成します。
1. スライドにチャートを追加します。
1. チャートのセカンドプロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例は、Pie of Pie チャートのさまざまなプロパティを設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # スライドにチャートを追加します。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # 異なるプロパティを設定します。
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # プレゼンテーションをディスクに保存します。
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **自動円グラフスライス色の設定**

Aspose.Slides for Python via Java は、円グラフのスライスの自動色設定のためのシンプルな API を提供しています。以下の例では、これらの設定を適用する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャートのタイトルを設定します。
1. チャート データ ワークシートのインデックスを設定します。
1. チャート データ ワークブックを取得します。
1. デフォルトの系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しい系列を追加します。
1. 新しい系列を値の表示に設定します。

変更されたプレゼンテーションを PPTX ファイルに書き込みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # デフォルトデータでチャートを追加します。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # チャートのタイトルを設定します。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # チャート データ ワークシートのインデックスを設定します。
    default_worksheet_index = 0

    # チャート データ ワークブックを取得します。
    workbook = chart.getChartData().getChartDataWorkbook()

    # デフォルトの系列とカテゴリを削除します。
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # 新しいカテゴリを追加します。
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # 新しい系列を追加します。
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # 系列データを入力します。
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # 新しい系列を値の表示に設定します。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**'Pie of Pie' と 'Bar of Pie' のバリエーションはサポートされていますか？**

はい、ライブラリは円グラフのセカンドプロット（'Pie of Pie' および 'Bar of Pie' タイプを含む）を[サポート](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/)しています。

**チャートだけを画像（例：PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体ではなく、チャート自体を画像（PNG など）として[エクスポート](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage)できます。