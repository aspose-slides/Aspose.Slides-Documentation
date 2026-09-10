---
title: Python でプレゼンテーションのチャートにトレンドラインを追加
linktitle: トレンドライン
type: docs
url: /ja/python-java/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- べき乗トレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PowerPoint のチャートにトレンドラインをすばやく追加・カスタマイズし、聴衆を引きつける実践的なガイド。"
---
## **概要**

この記事では、Aspose.Slides を使用してプレゼンテーションのチャートにトレンドラインを追加する方法を説明します。チャートの作成、チャート系列へのトレンドラインの追加、および指数、線形、対数、移動平均、多項式、べき乗などの複数のトレンドラインタイプの使用方法を示します。

また、ラインシェイプを挿入してチャートにカスタムラインを追加する方法についても説明し、前方および後方のトレンドライン投影値や、PDF や SVG へのエクスポート、画像としてチャートをレンダリングする際にトレンドラインが保持されるかどうかに関する簡単な FAQ も含まれています。

## **トレンドラインの追加**

Aspose.Slides for Python via Java は、さまざまなチャートのトレンドラインを管理するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. デフォルトデータと目的のタイプでチャートを追加します（この例では [ChartType.ClusteredColumn](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/#ClusteredColumn) を使用）。
4. チャート系列 1 に指数トレンドラインを追加します。
5. チャート系列 1 に線形トレンドラインを追加します。
6. チャート系列 2 に対数トレンドラインを追加します。
7. チャート系列 2 に移動平均トレンドラインを追加します。
8. チャート系列 3 に多項式トレンドラインを追加します。
9. チャート系列 3 にべき乗トレンドラインを追加します。
10. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

以下のコードは、トレンドライン付きのチャートを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # クラスタードカラムチャートを作成します。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # チャート系列 1 に指数トレンドラインを追加します。
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # チャート系列 1 に線形トレンドラインを追加します。
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # チャート系列 2 に対数トレンドラインを追加します。
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # チャート系列 2 に移動平均トレンドラインを追加します。
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # チャート系列 3 に多項式トレンドラインを追加します。
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # チャート系列 3 にべき乗トレンドラインを追加します。
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # プレゼンテーションを保存します。
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **カスタムラインの追加**

Aspose.Slides for Python via Java は、チャートにカスタムラインを追加するためのシンプルな API を提供します。選択したスライド上のチャートに直線を追加するには、以下の手順に従います。

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドへの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) クラスの [addChart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addChart) メソッドを使用して新しいチャートを作成します。
- [addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape) メソッドと [ShapeType.Line](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#Line) を使用してラインシェイプを追加します。
- シェイプのラインの色を設定します。
- 変更されたプレゼンテーションを PPTX ファイルに書き出します。

以下のコードは、カスタムライン付きのチャートを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**トレンドラインの「forward」および「backward」は何を意味しますか？**

トレンドラインを前方または後方に投影した長さを表します。散布図（XY）チャートの場合は軸単位で測定され、散布図でないチャートの場合はカテゴリ数で測定されます。0 以上の値のみが許可されます。

**プレゼンテーションを PDF または SVG にエクスポートする際、またはスライドを画像としてレンダリングする際にトレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/python-java/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を [エクスポート](/slides/ja/python-java/create-shape-thumbnails/)するメソッドも利用可能です。