---
title: Настройка легенд диаграмм в презентациях с использованием Python
linktitle: Легенда диаграммы
type: docs
url: /ru/python-java/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides для Python через Java, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. Эта статья показывает, как задать позицию и размер легенды, установить размер шрифта для всей легенды и применить форматирование к отдельному элементу легенды.

Она также охватывает несколько сопутствующих вопросов в разделе FAQ, включая использование режима без наложения, чтобы область построения оставляла место для легенды, разрешение длительных подписей легенды переносить строки или использовать разрывы строк, а также наследование форматирования легенды из темы презентации, если не заданы явные параметры текста и заливки.

## **Позиционирование легенды**

Чтобы задать свойства легенды, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Добавьте диаграмму на слайд.
1. Задайте свойства легенды.
1. Сохраните презентацию в файл PPTX.

Следующий пример задает позицию и размер легенды диаграммы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Создать пустую презентацию.
presentation = Presentation()
try:
    # Получить ссылку на слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить сгруппированную колонную диаграмму на слайд.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Установить свойства легенды.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Сохранить презентацию на диск.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка размера шрифта легенды**

Aspose.Slides для Python через Java позволяет задать размер шрифта легенды. Выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Создайте диаграмму по умолчанию.
1. Задайте размер шрифта.
1. Задайте минимальное значение оси.
1. Задайте максимальное значение оси.
1. Сохраните презентацию на диск.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Создать пустую презентацию.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка размера шрифта отдельного элемента легенды**

Aspose.Slides для Python через Java позволяет задать размер шрифта отдельным элементам легенды. Выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Создайте диаграмму по умолчанию.
1. Получите доступ к элементу легенды.
1. Задайте размер шрифта.
1. Сохраните презентацию на диск.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Создать пустую презентацию.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я включить легенду так, чтобы диаграмма автоматически выделяла для неё место, а не накладывала её?**

Да. Используйте [setOverlay](https://reference.aspose.com/slides/ru/python-java/aspose.slides/legend/#setOverlay) со значением `False`, чтобы включить режим без наложения; в этом случае область построения уменьшится, чтобы разместить легенду.

**Могу ли я создать многострочные подписи легенды?**

Да. Длинные подписи автоматически переносятся, когда места недостаточно; принудительные разрывы строк поддерживаются символами новой строки в имени серии.

**Как заставить легенду использовать цветовую схему темы презентации?**

Не задавайте явные цвета, заливки или шрифты для легенды или её текста. Тогда они будут наследоваться из темы и корректно обновятся при изменении дизайна.