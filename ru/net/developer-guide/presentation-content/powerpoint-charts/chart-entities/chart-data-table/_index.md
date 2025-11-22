---
title: Таблица данных диаграммы
type: docs
url: /ru/net/chart-data-table/
keywords: "Свойства шрифта, таблица данных диаграммы, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Установите свойства шрифта для таблицы данных диаграммы в презентациях PowerPoint на C# или .NET"
---

## **Установить свойства шрифта для таблицы данных диаграммы**
Aspose.Slides for .NET предоставляет возможность изменять цвет категорий в цветовом ряду.  

1. Создать объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавить диаграмму на слайд.
1. Установить таблицу диаграммы.
1. Установить высоту шрифта.
1. Сохранить изменённую презентацию.

Ниже приведён пример.  
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


## **Часто задаваемые вопросы**

**Можно ли отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**

Да. Таблица данных поддерживает [legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/), и их можно включать или отключать.

**Будет ли таблица данных сохраняться при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/net/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/net/convert-powerpoint-to-html/)/[image](/slides/ru/net/convert-powerpoint-to-png/) включает диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из шаблона?**

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, можно проверить и изменить, отображается ли таблица данных, используя свойства диаграммы.

**Как быстро определить, какие диаграммы в файле имеют включённую таблицу данных?**

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных, и пройдитесь по слайдам, чтобы определить диаграммы с включённой таблицей.