---
title: Настройка пузырчатых диаграмм в презентациях в .NET
linktitle: Пузырчатая диаграмма
type: docs
url: /ru/net/bubble-chart/
keywords:
- пузырчатая диаграмма
- размер пузыря
- масштабирование размера
- представление размера
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и настраивайте мощные пузырчатые диаграммы в PowerPoint с помощью Aspose.Slides for .NET, чтобы легко улучшать визуализацию данных."
---

## **Масштабирование размеров пузырчатой диаграммы**
Aspose.Slides for .NET предоставляет поддержку масштабирования размеров пузырчатой диаграммы. В Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** и **IChartSeriesGroup.BubbleSizeScale** свойства были добавлены. Ниже приведён пример.
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```





## **Представление данных как размеров пузырчатой диаграммы**
Свойство **BubbleSizeRepresentation** было добавлено в интерфейсы IChartSeries, IChartSeriesGroup и связанные классы. **BubbleSizeRepresentation** определяет, как значения размеров пузырей представляются в пузырчатой диаграмме. Возможные значения: **BubbleSizeRepresentationType.Area** и **BubbleSizeRepresentationType.Width**. Соответственно, перечисление **BubbleSizeRepresentationType** было добавлено для указания возможных способов представления данных как размеров пузырчатой диаграммы. Пример кода приведён ниже.
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **ЧаВо**

**Поддерживается ли «пузырчатая диаграмма с 3‑D эффектом», и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3-D». Он применяет 3‑D оформление к пузырям, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Тип доступен в перечислении [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**Есть ли ограничение на количество рядов и точек в пузырчатой диаграмме?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и версией целевого PowerPoint. Рекомендуется поддерживать разумное количество точек для читаемости и скорости рендеринга.

**Как экспорт влияет на отображение пузырчатой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, сглаживание), поэтому выбирайте достаточное DPI для печати.