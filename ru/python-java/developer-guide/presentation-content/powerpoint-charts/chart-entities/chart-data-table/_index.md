---
title: "Настройка таблиц данных диаграмм в презентациях с использованием Python"
linktitle: "Таблица данных"
type: docs
url: /ru/python-java/chart-data-table/
keywords:
- "данные диаграммы"
- "таблица данных"
- "свойства шрифта"
- "PowerPoint"
- "презентация"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Настройте таблицы данных диаграмм в Python для PPT и PPTX с помощью Aspose.Slides for Python via Java, чтобы повысить эффективность и привлекательность презентаций."
---
## **Обзор**

В этой статье объясняется, как работать с таблицами данных диаграмм в Aspose.Slides. Показано, как отобразить таблицу данных для диаграммы и настроить её форматирование текста, задав свойства шрифта, такие как полужирный стиль и высота шрифта. Пример демонстрирует создание презентации, добавление диаграммы, включение таблицы данных диаграммы, применение параметров шрифта и сохранение обновлённой презентации.

Также включены краткие ответы на распространённые вопросы о отображении ключей легенды в таблице данных диаграммы, сохранении таблицы данных при экспорте, работе с диаграммами, загруженными из существующих презентаций или шаблонов, и определении диаграмм, у которых включена таблица данных.

## **Установить свойства шрифта для таблицы данных диаграммы**

Aspose.Slides for Python via Java позволяет показывать таблицу данных диаграммы и изменять свойства шрифта её текста.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Добавьте диаграмму на слайд.
1. Отобразите таблицу данных диаграммы.
1. Установите полужирный стиль и высоту шрифта текста таблицы данных.
1. Сохраните изменённую презентацию.

Следующий пример демонстрирует эти шаги.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Создайте пустую презентацию.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Вопросы и ответы**

**Могу ли я показывать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [legend keys](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datatable/#setShowLegendKey), и их можно включать или отключать.

**Будет ли таблица данных сохранена при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/python-java/convert-powerpoint-to-html/)/[image](/slides/ru/python-java/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из файла‑шаблона?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, можно проверить и изменить, отображается ли таблица данных, используя свойства диаграммы ([is shown](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#hasDataTable)).

**Как быстро найти, какие диаграммы в файле имеют включённую таблицу данных?**

Просмотрите свойство каждой диаграммы, указывающее, отображается ли таблица данных ([is shown](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#hasDataTable)), и пройдитесь по слайдам, чтобы определить диаграммы, у которых она включена.