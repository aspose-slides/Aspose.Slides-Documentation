---
title: Таблица данных графика
type: docs
url: /net/chart-data-table/
keywords: "Свойства шрифта, таблица данных графика, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Установите свойства шрифта для таблицы данных графика в презентациях PowerPoint на C# или .NET"
---

## **Установите свойства шрифта для таблицы данных графика**
Aspose.Slides для .NET предоставляет поддержку изменения цвета категорий в цвете серии.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте график на слайд.
1. Установите таблицу графика.
1. Установите высоту шрифта.
1. Сохраните изменённую презентацию.

 Ниже приведен пример кода.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```