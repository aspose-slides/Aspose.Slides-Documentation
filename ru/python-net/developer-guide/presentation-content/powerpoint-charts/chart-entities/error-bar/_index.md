---
title: Ошибка Штриховка
type: docs
url: /ru/python-net/error-bar/
keywords: "Ошибка штриховка, значения ошибки штриховки презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление ошибки штриховки в презентации PowerPoint на Python"
---

## **Добавить Ошибку Штриховки**
Aspose.Slides для Python через .NET предоставляет простой API для управления значениями ошибок штриховки. Пример кода применяется при использовании пользовательского типа значения. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте пузырьковую диаграмму на желаемый слайд.
1. Получите первую серию диаграммы и установите формат ошибки штриховки X.
1. Получите первую серию диаграммы и установите формат ошибки штриховки Y.
1. Установите значения и формат штриховок.
1. Запишите измененную презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание пустой презентации
with slides.Presentation() as presentation:
    # Создание пузырьковой диаграммы
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Добавление ошибок штриховки и установка их формата
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

    # Сохранение презентации
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Добавить Пользовательское Значение Ошибки Штриховки**
Aspose.Slides для Python через .NET предоставляет простой API для управления пользовательскими значениями ошибок штриховки. Пример кода применяется, когда свойство **IErrorBarsFormat.ValueType** равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте пузырьковую диаграмму на желаемый слайд.
1. Получите первую серию диаграммы и установите формат ошибки штриховки X.
1. Получите первую серию диаграммы и установите формат ошибки штриховки Y.
1. Получите индивидуальные точки данных серии диаграммы и установите значения Ошибки Штриховки для отдельной точки данных серии.
1. Установите значения и формат штриховок.
1. Запишите измененную презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание пустой презентации
with slides.Presentation() as presentation:
    # Создание пузырьковой диаграммы
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Добавление пользовательских ошибок штриховки и установка их формата
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Доступ к точкам данных серии диаграммы и установка значений ошибок штриховки для отдельной точки
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Установка ошибок штриховки для точек серии диаграммы
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Сохранение презентации
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```