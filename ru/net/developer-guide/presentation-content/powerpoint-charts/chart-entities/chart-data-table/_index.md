---
title: Настройка таблиц данных диаграмм в презентациях на .NET
linktitle: Таблица данных
type: docs
url: /ru/net/chart-data-table/
keywords:
- данные диаграммы
- таблица данных
- свойства шрифта
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Настройте таблицы данных диаграмм в .NET для PPT и PPTX с помощью Aspose.Slides, чтобы повысить эффективность и привлекательность презентаций."
---

## **Установить свойства шрифта для таблицы данных диаграммы**
Aspose.Slides для .NET предоставляет возможность изменять цвет категорий в серии.  

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте диаграмму на слайд.
1. Установите таблицу диаграммы.
1. Задайте высоту шрифта.
1. Сохраните изменённую презентацию.

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

**Могу ли я отображать небольшие ключи легенды рядом со значениями в таблице данных диаграммы?**  

Да. Таблица данных поддерживает [legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/), и вы можете включать или отключать их.

**Будет ли таблица данных сохраняться при экспорте презентации в PDF, HTML или изображения?**  

Да. Aspose.Slides рендерит диаграмму как часть слайда, поэтому экспортированный [PDF](/slides/ru/net/convert-powerpoint-to-pdf/)/[HTML](/slides/ru/net/convert-powerpoint-to-html/)/[image](/slides/ru/net/convert-powerpoint-to-png/) содержит диаграмму с её таблицей данных.

**Поддерживаются ли таблицы данных для диаграмм, полученных из шаблонного файла?**  

Да. Для любой диаграммы, загруженной из существующей презентации или шаблона, вы можете проверить и изменить, отображается ли таблица данных [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) используя свойства диаграммы.

**Как быстро найти, какие диаграммы в файле имеют включённую таблицу данных?**  

Проверьте свойство каждой диаграммы, указывающее, отображается ли таблица данных [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/), и пройдите по слайдам, чтобы определить диаграммы, у которых она включена.