---
title: エラーバー
type: docs
url: /python-net/error-bar/
keywords: "エラーバー, エラーバー値 PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Python で PowerPoint プレゼンテーションにエラーバーを追加する"
---

## **エラーバーを追加する**
Aspose.Slides for Python via .NET は、エラーバーの値を管理するための簡単な API を提供します。サンプルコードは、カスタム値タイプを使用する際に適用されます。値を指定するには、系列の **DataPoints** コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバーの X フォーマットを設定します。
1. 最初のチャート系列にアクセスし、エラーバーの Y フォーマットを設定します。
1. バーの値とフォーマットを設定します。
1. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 空のプレゼンテーションを作成
with slides.Presentation() as presentation:
    # バブルチャートを作成
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # エラーバーを追加し、そのフォーマットを設定
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



## **カスタムエラーバー値を追加する**
Aspose.Slides for Python via .NET は、カスタムエラーバー値を管理するための簡単な API を提供します。サンプルコードは、**IErrorBarsFormat.ValueType** プロパティが **Custom** に等しい場合に適用されます。値を指定するには、系列の **DataPoints** コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバーの X フォーマットを設定します。
1. 最初のチャート系列にアクセスし、エラーバーの Y フォーマットを設定します。
1. チャート系列の個々のデータポイントにアクセスし、個々の系列データポイントのエラーバー値を設定します。
1. バーの値とフォーマットを設定します。
1. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 空のプレゼンテーションを作成
with slides.Presentation() as presentation:
    # バブルチャートを作成
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # カスタムエラーバーを追加し、そのフォーマットを設定
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # チャート系列のデータポイントにアクセスし、個々のポイントのエラーバー値を設定
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # チャート系列のポイントにエラーバーを設定
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # プレゼンテーションを保存
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```