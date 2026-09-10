---
title: Настройка областей построения диаграмм в презентациях на Python
linktitle: Область построения
type: docs
url: /ru/python-java/chart-plot-area/
keywords:
- диаграмма
- область построения
- ширина области построения
- высота области построения
- размер области построения
- режим макета
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как настраивать области построения диаграмм в презентациях PowerPoint с помощью Aspose.Slides для Python через Java. Легко улучшайте визуальное оформление слайдов."
---
## **Обзор**

В этой статье показано, как работать с областью построения диаграммы в Aspose.Slides. Описывается, как получить фактическое положение и размер области построения, проверив макет диаграммы и затем прочитав её значения X, Y, ширины и высоты.

Также демонстрируется, как настроить режим макета области построения, когда макет задаётся вручную, используя [LayoutTargetType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layouttargettype/) для определения, рассчитывается ли область построения по её внутренней области или по внешней вместе с осями и подписями осей.

## **Получить ширину и высоту области построения диаграммы**

Aspose.Slides for Python via Java предоставляет простой API для чтения фактического положения и размера области построения диаграммы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Вызовите метод [Chart.validateChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#validateChartLayout) перед получением фактических значений.
1. Получите фактическую позицию X (слева) элемента диаграммы относительно верхнего левого угла диаграммы.
1. Получите фактическую позицию Y (сверху) элемента диаграммы относительно верхнего левого угла диаграммы.
1. Получите фактическую ширину элемента диаграммы.
1. Получите фактическую высоту элемента диаграммы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Создайте экземпляр класса Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Установить режим макета области построения диаграммы**

Aspose.Slides for Python via Java предоставляет простой API для установки режима макета области построения диаграммы. Методы [setLayoutTargetType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) и [getLayoutTargetType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) доступны в классе [ChartPlotArea](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartplotarea/). Если макет области построения задаётся вручную, эта настройка указывает, следует ли размещать область построения по её внутренней части (исключая оси и подписи осей) или по внешней части (включая оси и подписи осей). Существует два возможных значения, определённых в перечислении [LayoutTargetType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layouttargettype/#Inner) указывает, что размер области построения исключает деления осей и подписи осей.
- [Outer](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layouttargettype/#Outer) указывает, что размер области построения включает деления осей и подписи осей.

Ниже приведён пример кода.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Создайте экземпляр класса Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**В каких единицах возвращаются фактические X, фактические Y, фактическая ширина и фактическая высота?**

В пунктах; 1 дюйм = 72 пункта. Это координатные единицы Aspose.Slides.

**Чем область построения отличается от области диаграммы по содержимому?**

Область построения — это область отрисовки данных (серии, линии сетки, трендлинии и т.п.); область диаграммы включает окружающие элементы (заголовок, легенду и т.д.). В 3D‑диаграммах область построения также включает стены/пол и оси.

**Как интерпретируются X, Y, ширина и высота области построения, когда макет задаётся вручную?**

Это дроби (0–1) от общего размера диаграммы; в этом режиме отключено автоматическое позиционирование, и используются заданные вами дробные значения.

**Почему положение области построения меняется после добавления или перемещения легенды?**

Легенда располагается в области диаграммы вне области построения, но влияет на макет и доступное пространство, поэтому при включённом автоматическом позиционировании область построения может сместиться. (Это стандартное поведение диаграмм PowerPoint.)