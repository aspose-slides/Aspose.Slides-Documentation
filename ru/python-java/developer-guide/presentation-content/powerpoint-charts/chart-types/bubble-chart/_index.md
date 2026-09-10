---
title: Настройка пузырьковых диаграмм в презентациях с использованием Python
linktitle: Пузырьковая диаграмма
type: docs
url: /ru/python-java/bubble-chart/
keywords:
- пузырьковая диаграмма
- размер пузырька
- масштабирование размера
- представление размера
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте и настраивайте мощные пузырьковые диаграммы в PowerPoint с помощью Aspose.Slides for Python via Java, чтобы легко улучшить визуализацию данных."
---
## **Обзор**

В этой статье показано, как работать с пузырьковыми диаграммами в Aspose.Slides. Описаны два конкретных варианта настройки: масштабирование размеров пузырьков с помощью метода [setBubbleSizeScale](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) и управление тем, как представляются значения размеров пузырьков, с помощью метода [setBubbleSizeRepresentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Примеры демонстрируют, как создать пузырьковую диаграмму, скорректировать масштабирование её размеров и переключить представление размеров пузырьков на использование ширины. Статья также содержит краткий раздел FAQ, в котором разъясняется поддержка типа диаграммы «Bubble with 3‑D», отмечается, что практические ограничения диаграмм зависят от производительности и версии целевого PowerPoint, а также объясняется, что экспорт сохраняет внешний вид диаграммы через движок рендеринга Aspose.Slides.

## **Масштабирование размеров пузырьковой диаграммы**
Aspose.Slides for Python via Java поддерживает масштабирование размеров пузырьковой диаграммы через методы [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) и [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Ниже показан пример масштабирования размеров пузырьков.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Представление данных в виде размеров пузырьковой диаграммы**
Методы [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) и [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) доступны в классе [ChartSeriesGroup](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseriesgroup/). Представление размера пузырька определяет, как значения размеров пузырьков отображаются в диаграмме. Возможные значения: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bubblesizerepresentationtype/#Area) и [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Перечисление [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/ru/python-java/aspose.slides/bubblesizerepresentationtype/) задаёт возможные способы представления данных в виде размеров пузырьковой диаграммы. Ниже показан пример представления размеров пузырьков с использованием ширины.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Поддерживается ли «пузырьковая диаграмма с 3‑D‑эффектом», и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3‑D». Он применяет 3‑D‑оформление к пузырькам, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Этот тип доступен в классе [chart type](https://reference.aspose.com/slides/ru/python-java/aspose.slides/charttype/).

**Есть ли ограничение на количество серий и точек в пузырьковой диаграмме?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и версией целевого PowerPoint. Рекомендуется держать количество точек в разумных пределах для удобочитаемости и скорости рендеринга.

**Как экспорт влияет на внешний вид пузырьковой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.