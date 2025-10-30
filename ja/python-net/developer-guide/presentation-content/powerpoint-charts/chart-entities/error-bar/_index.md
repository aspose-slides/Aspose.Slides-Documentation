---
title: "Python 用 .NET でプレゼンテーション チャートのエラーバーをカスタマイズ"
linktitle: "エラーバー"
type: docs
url: /ja/python-net/error-bar/
keywords:
- エラーバー
- カスタム値
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのチャートにエラーバーを追加およびカスタマイズする方法を学び、データの視覚化を最適化します。"
---

## **エラーバーの追加**
Aspose.Slides for Python via .NET は、エラーバー値を管理するためのシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの **DataPoints** コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート シリーズにアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート シリーズにアクセスし、エラーバー Y の書式を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 空のプレゼンテーションを作成
with slides.Presentation() as presentation:
    # バブルチャートを作成
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # エラーバーを追加し、その書式を設定
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # プレゼンテーションを保存
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタム エラーバー値の追加**
Aspose.Slides for Python via .NET は、カスタムエラーバー値を管理するためのシンプルな API を提供します。サンプルコードは **IErrorBarsFormat.ValueType** プロパティが **Custom** に等しい場合に適用されます。値を指定するには、シリーズの **DataPoints** コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート シリーズにアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート シリーズにアクセスし、エラーバー Y の書式を設定します。
1. チャート シリーズの個々のデータ ポイントにアクセスし、個別のデータ ポイントのエラーバー値を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 空のプレゼンテーションを作成
with slides.Presentation() as presentation:
    # バブルチャートを作成
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # カスタム エラーバーを追加し、その書式を設定
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # チャート シリーズのデータ ポイントにアクセスし、個別のポイントのエラーバー値を設定
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # チャート シリーズ ポイントのエラーバーを設定
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # プレゼンテーションを保存
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**プレゼンテーションを PDF または画像にエクスポートする際、エラーバーはどうなりますか？**

エラーバーはチャートの一部としてレンダリングされ、変換時にも他のチャート書式と同様に保持されます。（互換性のあるバージョンまたはレンダラを使用していることが前提です。）

**エラーバーはマーカーやデータ ラベルと組み合わせられますか？**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと共存できます。要素が重なる場合は、書式を調整する必要があります。

**API でエラーバーを操作するためのプロパティと列挙型の一覧はどこで見つけられますか？**

API リファレンスで確認できます: [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) クラスおよび関連列挙型の [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) と [ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/)。