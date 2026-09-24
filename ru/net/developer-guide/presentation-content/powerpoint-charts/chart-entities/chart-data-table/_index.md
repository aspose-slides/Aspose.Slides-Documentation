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
description: "Настройте шрифты, границы и ключи легенды таблицы данных диаграмм в презентациях PowerPoint, используя Aspose.Slides для .NET и C#."
---
## **Обзор**

Aspose.Slides for .NET позволяет отображать таблицу данных диаграммы и настраивать её форматирование текста, границы и ключи легенды. В этой статье объясняется, как включить таблицу, отформатировать её текст, управлять каждым типом границы и показывать или скрывать ключи легенды. Примеры сохраняют сконфигурированные диаграммы в файлы PPTX.

## **Установить свойства шрифта**

Чтобы отобразить таблицу данных диаграммы, установите [HasDataTable](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chart/hasdatatable/) в `true`. Используйте [ChartDataTable](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chart/chartdatatable/) для доступа к таблице и настройки её форматирования текста.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Добавьте сгруппированную столбцовую диаграмму на первый слайд.
1. Включите таблицу данных диаграммы.
1. Включите полужирный текст с помощью [FontBold](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/fontbold/) и установите [FontHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/fontheight/) в `20` для 20‑пунктового текста.
1. Сохраните изменённую презентацию.

Следующий пример требует наличия `test.pptx` в рабочем каталоге как минимум с одним слайдом. Он добавляет диаграмму с данными по умолчанию в позицию (50, 50) с шириной 600 пунктов и высотой 400 пунктов. Сохранённый `output.pptx` содержит диаграмму с включённой таблицей данных и применёнными указанными параметрами шрифта.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Настроить границы таблицы данных**

Включите таблицу с помощью [IChart.HasDataTable](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/hasdatatable/) и получите к ней доступ через [IChart.ChartDataTable](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/chartdatatable/). Вы можете независимо управлять тремя типами границ:

- [HasBorderHorizontal](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatatable/hasborderhorizontal/) управляет горизонтальными границами ячеек.
- [HasBorderVertical](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatatable/hasbordervertical/) управляет вертикальными границами ячеек.
- [HasBorderOutline](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatatable/hasborderoutline/) управляет внешней границей таблицы.

Установите каждое свойство в `true`, чтобы отображать его границы, или в `false`, чтобы скрыть их. Следующий пример создаёт сгруппированную столбцовую диаграмму с данными по умолчанию, отображает горизонтальные границы и внешнюю границу, а вертикальные границы скрывает. Для него не требуется входной файл. Позиция и размер диаграммы указываются в пунктах.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Сравнение ниже использует одинаковые данные диаграммы и настройки ключей легенды во всех четырёх случаях. Начиная с включённых всех границ, каждый последующий вариант отключает только одно свойство границы. Вариант в левом нижнем углу соответствует настройкам границ из примера.

![Таблицы данных диаграммы с включёнными всеми границами, без горизонтальных границ, без вертикальных границ и без внешней границы](data-table-borders.png)

## **Показать или скрыть ключи легенды**

Ключи легенды — это небольшие цветные маркеры рядом с названиями серий в таблице данных. Они помогают читателям сопоставлять каждую строку таблицы с соответствующей серией диаграммы. Установите [ShowLegendKey](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatatable/showlegendkey/) в `true`, чтобы показывать эти маркеры, или в `false`, чтобы скрыть их.

Отдельная легенда диаграммы управляется [IChart.HasLegend](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/haslegend/). Эти настройки независимы: скрытие отдельной легенды не скрывает ключи внутри таблицы данных, а скрытие ключей таблицы не скрывает отдельную легенду.

Следующий пример создаёт диаграмму с данными по умолчанию, включает её таблицу данных и отображает ключи легенды внутри неё, одновременно скрывая отдельную легенду. Все границы таблицы явно включены. Входная презентация не требуется. Чтобы скрыть только ключи таблицы, измените `dataTable.ShowLegendKey` на `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Сравнение ниже показывает одну и ту же таблицу с включёнными и отключёнными ключами легенды. Все границы остаются включёнными, а отдельная легенда диаграммы скрыта в обоих случаях.

![Таблицы данных диаграммы с отображёнными слева ключами легенды и скрытыми справа](data-table-legend-keys.png)

## **Часто задаваемые вопросы**

**Можно ли отображать ключи легенды в таблице данных диаграммы?**

Да. Установите [ShowLegendKey](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/datatable/showlegendkey/) в `true`, чтобы отобразить ключи легенды, или в `false`, чтобы скрыть их.

**Сохранится ли таблица данных при экспорте презентации в PDF, HTML или изображения?**

Да. Aspose.Slides рендерит диаграмму и её отображаемую таблицу данных как часть слайда при экспорте в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/net/convert-powerpoint-to-html/), или [изображения](/slides/ru/net/convert-powerpoint-to-png/).

**Можно ли работать с таблицами данных в диаграммах, загруженных из шаблона?**

Да. Для диаграммы, загруженной из существующей презентации или шаблона, используйте [HasDataTable] чтобы проверить или изменить, отображается ли её таблица данных.

**Как найти диаграммы, у которых включена таблица данных?**

Пройдитесь по объектам shape на каждом слайде, определите диаграммы и проверьте их свойство [HasDataTable]. Значение `true` указывает, что таблица данных включена.