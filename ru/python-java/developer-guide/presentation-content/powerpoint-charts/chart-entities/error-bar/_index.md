---
title: Настройка линейок ошибок в диаграммах презентаций с использованием Python
linktitle: Линейка ошибок
type: docs
url: /ru/python-java/error-bar/
keywords:
- линейка ошибок
- пользовательское значение
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как добавлять и настраивать линейки ошибок в диаграммах с помощью Aspose.Slides для Python через Java — оптимизируйте визуализацию данных в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как работать с линейками ошибок в диаграммах презентаций, используя Aspose.Slides. Показано, как добавить линейки ошибок к серии диаграммы, настроить параметры линейок ошибок по осям X и Y и применить различные типы значений, такие как фиксированные, процентные и пользовательские.

Также показано, как назначить пользовательские значения линейок ошибок для отдельных точек данных в серии, используя соответствующую коллекцию точек данных. Кроме того, в статье содержатся краткие замечания о том, как линейки ошибок ведут себя при экспорте, их совместимости с маркерами и подписью данных, а также где найти связанные классы и перечисления справочника API.

## **Добавить линейки ошибок**

Aspose.Slides for Python via Java предоставляет простой API для управления значениями линейок ошибок. Следующий пример кода использует фиксированные и процентные типы значений.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат линейки ошибок по оси X.
1. Получите первую серию диаграммы и задайте формат линейки ошибок по оси Y.
1. Установите значения линейки ошибок и их форматирование.
1. Запишите изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    # Создать пузырчатую диаграмму.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Добавить линейки ошибок и задать их форматирование.
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

    # Сохранить презентацию.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавить пользовательские значения линейки ошибок**

Aspose.Slides for Python via Java предоставляет простой API для управления пользовательскими значениями линейок ошибок. Следующий пример кода применяется, когда [getValueType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/errorbarsformat/#getValueType) возвращает [ErrorBarValueType.Custom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/errorbarvaluetype/#Custom). Чтобы задать значение, используйте [getErrorBarsCustomValues](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) для конкретной точки данных в коллекции, возвращаемой методом серии [getDataPoints](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getDataPoints).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Добавьте пузырчатую диаграмму на нужный слайд.
1. Получите первую серию диаграммы и задайте формат линейки ошибок по оси X.
1. Получите первую серию диаграммы и задайте формат линейки ошибок по оси Y.
1. Получите отдельные точки данных в серии диаграммы и задайте их значения линейки ошибок.
1. Установите значения линейки ошибок и их форматирование.
1. Запишите изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    # Создать пузырчатую диаграмму.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Добавить пользовательские линейки ошибок и задать их форматирование.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Получить точки данных серии диаграммы и настроить источники значений линейки ошибок.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Задать значения линейки ошибок для точек данных серии диаграммы.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Сохранить презентацию.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Что происходит с линейками ошибок при экспорте презентации в PDF или изображения?**

Они отображаются как часть диаграммы и сохраняются при конвертации вместе с остальным форматированием диаграммы, при условии совместимой версии или рендерера.

**Можно ли комбинировать линейки ошибок с маркерами и подписью данных?**

Да. Линейки ошибок являются отдельным элементом и совместимы с маркерами и подписью данных; если элементы перекрываются, возможно, потребуется скорректировать их форматирование.

**Где можно найти список свойств и классов для работы с линейками ошибок в API?**

В справочнике API: класс [ErrorBarsFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/errorbarsformat/) и связанные классы [ErrorBarType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/errorbartype/) и [ErrorBarValueType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/errorbarvaluetype/).