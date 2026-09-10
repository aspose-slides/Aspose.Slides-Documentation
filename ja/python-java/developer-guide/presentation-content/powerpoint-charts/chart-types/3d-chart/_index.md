---
title: Python を使用したプレゼンテーションの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/python-java/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で 3-D チャートを作成およびカスタマイズする方法を学び、PPT と PPTX ファイルに対応し、プレゼンテーションを今すぐ強化しましょう。"
---
## **概要**

この記事では、Aspose.Slides の 3D チャートを、[Rotation3D](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotation3d/) の設定（[setRotationX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotation3d/#setRotationX)、[setRotationY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotation3d/#setRotationY)、[setDepthPercents](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotation3d/#setDepthPercents)、[setRightAngleAxes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/rotation3d/#setRightAngleAxes) など）を構成することでカスタマイズする方法を説明します。プレゼンテーションの作成、デフォルト データでの 3D チャートの追加、必要な 3D ビュー設定の適用、そして変更されたプレゼンテーションを PPTX ファイルとして保存する手順を順に示します。

## **3D チャートの X 回転、Y 回転、深さの設定**

Aspose.Slides for Python via Java は、これらのプロパティを設定するためのシンプルな API を提供します。以下の例は、3D チャートの X 回転、Y 回転、深さを設定する方法を示しています。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. 3D 回転プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # 最初のスライドにアクセスします。
    slide = presentation.getSlides().get_Item(0)

    # デフォルトデータでチャートを追加します。
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # チャートデータのワークシートインデックスを設定します。
    default_worksheet_index = 0

    # チャートデータのブックを取得します。
    workbook = chart.getChartData().getChartDataWorkbook()

    # 系列を追加します。
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # カテゴリを追加します。
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # 3D 回転プロパティを設定します。
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # 2 番目のチャート系列にアクセスします。
    series = chart.getChartData().getSeries().get_Item(1)

    # 系列データを入力します。
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # プレゼンテーションを保存します。
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、カラム チャートの 3D バリアントや、[ChartType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートします。正確で最新の一覧は、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスター画像を取得できますか？**

はい。チャートを画像としてエクスポートするには、[chart API](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) またはスライド全体を PNG や JPEG などの形式に変換することができます（/slides/ja/python-java/convert-powerpoint-to-png/）。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずに文書、ダッシュボード、ウェブページにチャートを埋め込む際に便利です。

**大規模な 3D チャートの構築およびレンダリングのパフォーマンスはどの程度ですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るためには、3D 効果は最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限りシリーズあたりのデータポイント数を制限し、ターゲットとなる表示または印刷要件に合わせて解像度とサイズを調整した出力にレンダリングしてください。