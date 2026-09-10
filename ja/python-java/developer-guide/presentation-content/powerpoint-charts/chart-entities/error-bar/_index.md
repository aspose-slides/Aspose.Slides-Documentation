---
title: プレゼンテーションチャートでPythonを使用した誤差棒のカスタマイズ
linktitle: 誤差棒
type: docs
url: /ja/python-java/error-bar/
keywords:
- 誤差棒
- カスタム値
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してチャートに誤差棒を追加およびカスタマイズする方法を学び、PowerPoint プレゼンテーションでデータの可視化を最適化します。"
---
## **Overview**

この文章では、Aspose.Slides を使用してプレゼンテーションのチャートで誤差棒を操作する方法を説明します。チャート系列に誤差棒を追加し、X と Y の誤差棒設定を構成し、固定値、パーセンテージ、カスタム値などのさまざまな値タイプを適用する方法を示します。

また、系列内の個々のデータポイントに対してカスタム誤差棒値を割り当てる方法を、対応するデータポイントコレクションを使用して示します。さらに、エクスポート時の誤差棒の動作、マーカーやデータラベルとの互換性、および関連する API リファレンスクラスや列挙体の場所に関する簡単な注意事項も含まれています。

## **Add Error Bars**

Aspose.Slides for Python via Java は、誤差棒の値を管理するためのシンプルな API を提供します。以下のサンプルコードは、固定値とパーセンテージ値のタイプを使用しています。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、誤差棒 X の書式を設定します。
1. 最初のチャート系列にアクセスし、誤差棒 Y の書式を設定します。
1. 誤差棒の値と書式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # バブルチャートを作成します。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # 誤差棒を追加し、書式を設定します。
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # プレゼンテーションを保存します。
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add Custom Error Bar Values**

Aspose.Slides for Python via Java は、カスタム誤差棒値を管理するためのシンプルな API を提供します。以下のサンプルコードは、[getValueType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/errorbarsformat/#getValueType) が [ErrorBarValueType.Custom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/errorbarvaluetype/#Custom) を返す場合に適用されます。値を指定するには、系列メソッド [getDataPoints](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getDataPoints) が返すコレクション内の特定のデータポイントに対して [getErrorBarsCustomValues](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) を使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、誤差棒 X の書式を設定します。
1. 最初のチャート系列にアクセスし、誤差棒 Y の書式を設定します。
1. チャート系列内の個々のデータポイントにアクセスし、それらの誤差棒値を設定します。
1. 誤差棒の値と書式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # バブルチャートを作成します。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # カスタム誤差棒を追加し、書式を設定します。
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # チャート系列のデータポイントにアクセスし、誤差棒値のソースを設定します。
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # チャート系列のデータポイントに対して誤差棒の値を設定します。
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # プレゼンテーションを保存します。
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**

互換性のあるバージョンまたはレンダラを前提として、誤差棒はチャートの一部として描画され、変換時にチャート全体の書式と共に保持されます。

**Can error bars be combined with markers and data labels?**

はい。誤差棒は別個の要素であり、マーカーやデータラベルと互換性があります。要素が重なる場合は、書式を調整する必要があるかもしれません。

**Where can I find the list of properties and classes for working with error bars in the API?**

API リファレンスで確認できます。具体的には、[ErrorBarsFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/errorbarsformat/) クラスおよび関連クラスの [ErrorBarType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/errorbartype/) と [ErrorBarValueType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/errorbarvaluetype/) です。