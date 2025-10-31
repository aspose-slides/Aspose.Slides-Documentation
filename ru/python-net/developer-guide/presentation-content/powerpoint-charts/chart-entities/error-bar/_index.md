---
title: "Настройка линий ошибок в диаграммах презентаций с помощью Python"
linktitle: "Линия ошибки"
type: docs
url: /ru/python-net/error-bar/
keywords:
- "линия ошибки"
- "пользовательское значение"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Узнайте, как добавлять и настраивать линии ошибок в диаграммах с помощью Aspose.Slides for Python via .NET — оптимизируйте визуализацию данных в презентациях PowerPoint и OpenDocument."
---

## **Добавить линию ошибки**
Aspose.Slides for Python via .NET предоставляет простой API для управления значениями линий ошибок. Пример кода применим при использовании пользовательского типа значения. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте пузырчатую диаграмму на нужный слайд.
3. Получите первую серию диаграммы и задайте формат линии ошибок по оси X.
4. Получите первую серию диаграммы и задайте формат линии ошибок по оси Y.
5. Задайте значения и формат линий.
6. Сохраните изменённую презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание пустой презентации
with slides.Presentation() as presentation:
    # Создание пузырчатой диаграммы
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Добавление линий ошибок и задание их формата
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

## **Добавить пользовательское значение линии ошибки**
Aspose.Slides for Python via .NET предоставляет простой API для управления пользовательскими значениями линий ошибок. Пример кода применим, когда свойство **IErrorBarsFormat.ValueType** равно **Custom**. Чтобы указать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Добавьте пузырчатую диаграмму на нужный слайд.
3. Получите первую серию диаграммы и задайте формат линии ошибок по оси X.
4. Получите первую серию диаграммы и задайте формат линии ошибок по оси Y.
5. Получите отдельные точки данных серии и задайте значения линий ошибок для каждой точки.
6. Задайте значения и формат линий.
7. Сохраните изменённую презентацию в файл PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание пустой презентации
with slides.Presentation() as presentation:
    # Создание пузырчатой диаграммы
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Добавление пользовательских линий ошибок и задание их формата
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Доступ к точкам данных серии и задание значений линий ошибок для каждой точки
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Задание линий ошибок для точек серии
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Сохранение презентации
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Что происходит с линиями ошибок при экспорте презентации в PDF или изображения?**

Они рендерятся как часть диаграммы и сохраняются при конвертации вместе с остальными параметрами оформления диаграммы, если используется совместимая версия или рендерер.

**Можно ли комбинировать линии ошибок с маркерами и подписью данных?**

Да. Линии ошибок являются отдельным элементом и совместимы с маркерами и подписью данных; при наложении элементов может потребоваться корректировка оформления.

**Где найти список свойств и перечислений для работы с линиями ошибок в API?**

В справочнике API: класс[ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) и связанные перечисления[ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) и[ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).