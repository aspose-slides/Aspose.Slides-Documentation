---
title: Пузырьковая диаграмма
type: docs
url: /ru/net/bubble-chart/
keywords: "Пузырьковая диаграмма, размер диаграммы, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Размер пузырьковой диаграммы в презентациях PowerPoint на C# или .NET"
---

## **Масштабирование размеров пузырьковой диаграммы**
Aspose.Slides for .NET предоставляет поддержку масштабирования размеров пузырьковой диаграммы. В Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** и **IChartSeriesGroup.BubbleSizeScale** свойства были добавлены. Ниже приведён пример.
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```





## **Представление данных как размеров пузырьковой диаграммы**
Свойство **BubbleSizeRepresentation** было добавлено в интерфейсы IChartSeries, IChartSeriesGroup и связанные классы. **BubbleSizeRepresentation** указывает, как значения размеров пузырьков представлены в пузырьковой диаграмме. Возможные значения: **BubbleSizeRepresentationType.Area** и **BubbleSizeRepresentationType.Width**. Соответственно, перечисление **BubbleSizeRepresentationType** было добавлено для указания возможных способов представления данных как размеров пузырьковой диаграммы. Пример кода приведён ниже.
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Поддерживается ли «пузырьковая диаграмма с 3‑D эффектом», и чем она отличается от обычной?**

Да. Существует отдельный тип диаграммы «Bubble with 3-D». Он применяет 3‑D стилизацию к пузырькам, но не добавляет дополнительную ось; данные остаются X‑Y‑S (размер). Тип доступен в перечислении [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**Есть ли ограничение на количество рядов и точек в пузырьковой диаграмме?**

На уровне API жёсткого ограничения нет; ограничения определяются производительностью и целевой версией PowerPoint. Рекомендуется держать количество точек разумным для читабельности и скорости рендеринга.

**Как экспорт влияет на внешний вид пузырьковой диаграммы (PDF, изображения)?**

Экспорт в поддерживаемые форматы сохраняет внешний вид диаграммы; рендеринг выполняется движком Aspose.Slides. Для растровых/векторных форматов применяются общие правила рендеринга графики диаграмм (разрешение, анти‑алиасинг), поэтому выбирайте достаточный DPI для печати.