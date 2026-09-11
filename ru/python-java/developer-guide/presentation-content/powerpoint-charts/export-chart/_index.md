---
title: Экспорт диаграмм презентаций в Python через Java
linktitle: Экспорт диаграммы
type: docs
weight: 90
url: /ru/python-java/export-chart/
keywords:
- диаграмма
- диаграмма в изображение
- диаграмма как изображение
- извлечение изображения диаграммы
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как экспортировать диаграммы презентаций с помощью Aspose.Slides для Python через Java, поддерживая форматы PPT и PPTX, и упростите генерацию отчетов в любом рабочем процессе."
---
## **Обзор**

Aspose.Slides позволяет экспортировать диаграмму из презентации в виде изображения. В этой статье показано, как получить изображение диаграммы и сохранить его, что полезно, когда необходимо использовать визуальные элементы диаграммы за пределами презентации PowerPoint.

Помимо базового процесса экспорта изображений, статья также рассматривает распространённые вопросы, связанные с экспортом, включая сохранение содержимого диаграммы в SVG, управление размером вывода с помощью параметров рендеринга, загрузку шрифтов для сохранения внешнего вида подписей и легенды, а также сохранение оригинального форматирования презентации, такого как темы, стили, заливки и эффекты, во время рендеринга.

## **Получить изображение диаграммы**
Aspose.Slides for Python via Java поддерживает извлечение изображения конкретной диаграммы. Ниже приведён пример, демонстрирующий, как это сделать.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Могу ли я экспортировать диаграмму как вектор (SVG), а не как растровое изображение?**  
Да. Диаграмма является фигурой, и её содержимое можно сохранить в SVG с помощью [метода сохранения shape-to-SVG](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Как задать точный размер экспортируемой диаграммы в пикселях?**  
Используйте перегрузки рендеринга изображения, позволяющие задать размер или масштаб — библиотека поддерживает рендеринг объектов с указанными размерами/масштабом.

**Что делать, если шрифты в подписях и легенде выглядят некорректно после экспорта?**  
[Загрузите необходимые шрифты](/slides/ru/python-java/custom-font/) через [FontsLoader](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsloader/), чтобы рендеринг диаграммы сохранял метрики и внешний вид текста.

**Сохраняет ли экспорт тему, стили и эффекты PowerPoint?**  
Да. Рендерер Aspose.Slides применяет форматирование презентации (темы, стили, заливки, эффекты), поэтому внешний вид диаграммы сохраняется.

**Где можно найти доступные возможности рендеринга/экспорта помимо изображений диаграмм?**  
Смотрите [API](https://reference.aspose.com/slides/ru/python-java/aspose.slides/)/[документацию](/slides/ru/python-java/convert-powerpoint/) для целевых форматов вывода ([PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/ru/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ru/python-java/convert-powerpoint-to-xps/), [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), и др.) и связанные параметры рендеринга.