---
title: Настройка пузырьковых диаграмм в презентациях с помощью Python
linktitle: Пузырьковая диаграмма
type: docs
url: /ru/python-net/bubble-chart/
keywords:
- пузырьковая диаграмма
- размер пузыря
- масштабирование размера
- представление размера
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте мощные пузырьковые диаграммы в PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, легко улучшая визуализацию данных."
---

## **Масштабирование размеров пузырьковой диаграммы**
Aspose.Slides for Python via .NET предоставляет поддержку масштабирования размеров пузырьковой диаграммы. В Aspose.Slides for Python via .NET **ChartSeries.bubble_size_scale** и **ChartSeriesGroup.bubble_size_scale** добавлены свойства. Ниже приведён пример.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Представление данных в виде размеров пузырьковой диаграммы**
В классы ChartSeries и ChartSeriesGroup добавлено свойство **bubble_size_representation**. **bubble_size_representation** указывает, как значения размера пузыря представлены в диаграмме. Возможные значения: **BubbleSizeRepresentationType.AREA** и **BubbleSizeRepresentationType.WIDTH**. Соответственно, в перечисление **BubbleSizeRepresentationType** добавлены варианты представления данных в виде размеров пузырей. Пример кода ниже.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Поддерживается ли “пузырьковая диаграмма с 3‑D‑эффектом”, и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3-D». Он применяет 3‑D‑оформление к пузырькам, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Тип доступен в перечислении [тип диаграммы](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

**Есть ли ограничение на количество рядов и точек в пузырьковой диаграмме?**

Жёсткого ограничения на уровне API нет; ограничения определяются производительностью и целевой версией PowerPoint. Рекомендуется держать количество точек разумным для читаемости и скорости рендеринга.

**Как экспорт влияет на внешний вид пузырьковой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.