---
title: Настройка таблиц данных диаграмм в презентациях с использованием Python
linktitle: Таблица данных
type: docs
url: /ru/python-java/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Настройте шрифты, границы и ключи легенды таблицы данных диаграмм в презентациях PowerPoint с использованием Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет отображать таблицу данных диаграммы и настраивать её форматирование текста, границы и ключи легенды. В этой статье объясняется, как включить таблицу, форматировать её текст, управлять каждым типом границы и показывать или скрывать ключи легенды. Примеры сохраняют настроенные диаграммы в файлы PPTX.

## **Установить свойства шрифта**

Чтобы отобразить таблицу данных диаграммы, передайте `True` в [setDataTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDataTable). Используйте [getChartDataTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#getChartDataTable) для доступа к таблице и настройки её форматирования текста.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Добавьте сгруппированную столбчатую диаграмму на первый слайд.
1. Включите таблицу данных диаграммы.
1. Включите полужирный шрифт с помощью [setFontBold](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setFontBold) и передайте `20` в [setFontHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setFontHeight) для текста размером 20 пунктов.
1. Сохраните изменённую презентацию.

Следующий пример требует файл `test.pptx` в рабочем каталоге, содержащий хотя бы один слайд. Он добавляет диаграмму с данными по умолчанию в позицию (50, 50) с шириной 600 пунктов и высотой 400 пунктов. Сохранённый `output.pptx` содержит диаграмму с включенной таблицей данных и применёнными настройками шрифта.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Настройка границ таблицы данных**

Включите таблицу с помощью [Chart.setDataTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDataTable) и получите к ней доступ через [Chart.getChartDataTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#getChartDataTable). Вы можете независимо управлять тремя типами границ:

- [setBorderHorizontal](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datatable/#setBorderHorizontal) управляет горизонтальными границами ячеек.
- [setBorderVertical](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datatable/#setBorderVertical) управляет вертикальными границами ячеек.
- [setBorderOutline](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datatable/#setBorderOutline) управляет внешней границей таблицы.

Передайте `True` в каждый метод, чтобы отобразить границы, или `False`, чтобы скрыть их. Ниже приведён пример, который создаёт сгруппированную столбчатую диаграмму с данными по умолчанию, отображает горизонтальные границы и внешнюю границу, а вертикальные границы скрывает. Входной файл не требуется. Позиция и размер диаграммы указаны в пунктах.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сравнение ниже использует одни и те же данные диаграммы и настройку ключей легенды во всех четырёх случаях. Начиная с включёнными всеми границами, каждый последующий вариант отключает только одну настройку границы. Нижний‑левый вариант соответствует настройкам границ в примере.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Показ или скрытие ключей легенды**

Ключи легенды — это небольшие цветные маркеры рядом с названиями рядов в таблице данных. Они помогают читателю сопоставить каждую строку таблицы с серией диаграммы. Передайте `True` в [setShowLegendKey](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datatable/#setShowLegendKey), чтобы показать эти маркеры, или `False`, чтобы скрыть их.

Отдельная легенда диаграммы управляется методом [Chart.setLegend](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setLegend). Эти настройки независимы: скрытие отдельной легенды не скрывает ключи внутри таблицы данных, и скрытие ключей таблицы не скрывает отдельную легенду.

Следующий пример создаёт диаграмму с данными по умолчанию, включает её таблицу данных и показывает ключи легенды внутри неё, при этом скрывая отдельную легенду. Все границы таблицы явно включены. Входная презентация не требуется. Чтобы скрыть только ключи таблицы, передайте `False` в [setShowLegendKey](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сравнение ниже показывает одну и ту же таблицу с включёнными и отключёнными ключами легенды. Все границы остаются включёнными, а отдельная легенда диаграммы скрыта в обоих случаях.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Можно ли показать ключи легенды в таблице данных диаграммы?**

Да. Передайте `True` в [setShowLegendKey](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datatable/#setShowLegendKey), чтобы отобразить ключи легенды, или `False`, чтобы скрыть их.

**Будет ли таблица данных сохранена при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму и её отображаемую таблицу данных как часть слайда при экспорте в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), или [images](/slides/ru/python-java/convert-powerpoint-to-png/).

**Можно ли работать с таблицами данных в диаграммах, загруженных из шаблона?**

Да. Для диаграммы, загруженной из существующей презентации или шаблона, используйте [hasDataTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#hasDataTable) и [setDataTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDataTable), чтобы проверить или изменить, отображается ли её таблица данных.

**Как найти диаграммы, у которых включена таблица данных?**

Пройдитесь по всем фигурам на каждом слайде, идентифицируйте диаграммы и вызовите их метод [hasDataTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#hasDataTable). Значение `True` указывает, что таблица данных включена.