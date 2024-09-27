---
title: Экспорт графика
type: docs
weight: 90
url: /ru/net/export-chart/
keywords: "График, изображение графика, извлечение изображения графика, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Получение изображений графиков в презентации PowerPoint на C# или .NET"
---

## **Получение изображения графика**
Aspose.Slides для .NET предоставляет поддержку извлечения изображения конкретного графика. Ниже приведен пример.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	Image img = chart.GetThumbnail();
	img.Save("image.png", ImageFormat.Png);
}
```