---
title: Настройка кольцевых диаграмм в презентациях с использованием Python через Java
linktitle: Кольцевая диаграмма
type: docs
weight: 30
url: /ru/python-java/doughnut-chart/
keywords:
- кольцевая диаграмма
- центральный зазор
- размер отверстия
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как создавать и настраивать кольцевые диаграммы в Aspose.Slides для Python через Java, поддерживая форматы PowerPoint для динамических презентаций."
---
## **Обзор**

В этой статье показано, как работать с кольцевой диаграммой в Aspose.Slides, добавляя диаграмму на слайд, устанавливая размер её центрального отверстия и сохраняя презентацию. В ней рассматривается метод [setDoughnutHoleSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) и демонстрируются базовые шаги, необходимые для настройки этого типа диаграммы в коде.

Также включён короткий раздел FAQ, охватывающий связанные сценарии с кольцевыми диаграммами, такие как использование нескольких рядов для создания нескольких колец, работа с «взрывными» кольцевыми диаграммами и экспорт диаграммы в растровое изображение или SVG.

## **Указать центральный зазор в кольцевой диаграмме**

{{% alert color="info" title="Примечание" %}}

Aspose.Slides for Python via Java поддерживает указание размера отверстия в кольцевой диаграмме. В этом разделе демонстрируется, как задать размер отверстия на примере.

{{% /alert %}}

Чтобы указать размер отверстия в кольцевой диаграмме, выполните следующие действия:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Добавьте кольцевую диаграмму на слайд.
3. Укажите размер отверстия в кольцевой диаграмме.
4. Запишите презентацию на диск.

Следующий пример задает размер отверстия в кольцевой диаграмме.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Создать экземпляр класса Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Сохранить презентацию на диск.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я создать многослойный кольцевой график с несколькими кольцами?**

Да. Добавьте несколько рядов в одну кольцевую диаграмму — каждый ряд станет отдельным кольцом. Порядок колец определяется порядком рядов в коллекции.

**Поддерживается ли «взрывной» кольцевой график (разделённые сектора)?**

Да. Существует тип диаграммы Exploded Doughnut [chart type](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/) и свойство взрыва для точек данных; вы можете отделять отдельные сектора.

**Как получить изображение кольцевой диаграммы (PNG/SVG) для отчёта?**

Диаграмма является [shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/); её можно отрендерить в [raster image](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) или экспортировать диаграмму в SVG‑изображение.