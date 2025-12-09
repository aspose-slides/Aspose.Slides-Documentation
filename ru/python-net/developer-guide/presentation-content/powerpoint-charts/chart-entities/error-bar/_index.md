---
title: Настройка полос ошибок в диаграммах презентаций с Python
linktitle: Полоса ошибок
type: docs
url: /ru/python-net/error-bar/
keywords:
- полоса ошибок
- пользовательское значение
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как добавлять и настраивать полосы ошибок в диаграммах с помощью Aspose.Slides for Python via .NET - оптимизируйте визуализацию данных в презентациях PowerPoint и OpenDocument."
---

## **Добавить полосу ошибок**
Aspose.Slides for Python via .NET предоставляет простой API для управления значениями полос ошибок. Пример кода применим при использовании пользовательского типа значений. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат X‑error bar.
1. Получите первую серию диаграммы и задайте формат Y‑error bar.
1. Установка значений полос и их формат.
1. Запишите изменённую презентацию в файл PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание пустой презентации
with slides.Presentation() as presentation:
    # Создание пузырчатой диаграммы
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Добавление полос ошибок и установка их формата
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


## **Добавить пользовательское значение полосы ошибок**
Aspose.Slides for Python via .NET предоставляет простой API для управления пользовательскими значениями полос ошибок. Пример кода применим, когда свойство **IErrorBarsFormat.ValueType** равно **Custom**. Чтобы задать значение, используйте свойство **ErrorBarCustomValues** конкретной точки данных в коллекции **DataPoints** серии:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат X‑error bar.
1. Получите первую серию диаграммы и задайте формат Y‑error bar.
1. Получите отдельные точки данных серии и задайте значения Error Bar для каждой точки.
1. Установка значений полос и их формат.
1. Запишите изменённую презентацию в файл PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Создание пустой презентации
with slides.Presentation() as presentation:
    # Создание пузырчатой диаграммы
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Добавление пользовательских полос ошибок и установка их формата
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Доступ к точке данных серии диаграммы и установка значений полос ошибок для отдельной точки
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Установка полос ошибок для точек серии диаграммы
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Сохранение презентации
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Часто задаваемые вопросы**

**Что происходит с полосами ошибок при экспорте презентации в PDF или изображения?**

Они рендерятся как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимости версии или рендерера.

**Можно ли сочетать полосы ошибок с маркерами и подписями данных?**

Да. Полосы ошибок являются отдельным элементом и совместимы с маркерами и подписями данных; при наложении элементов может потребоваться корректировка форматирования.

**Где найти список свойств и перечислений для работы с полосами ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) и связанные перечисления [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).