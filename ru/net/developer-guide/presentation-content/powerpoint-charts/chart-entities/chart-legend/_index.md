---
title: Настройка легенд диаграмм в презентациях на .NET
linktitle: Легенда диаграммы
type: docs
url: /ru/net/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for .NET, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for .NET предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. В этой статье показано, как задать позицию и размер легенды, установить размер шрифта для всей легенды, отформатировать отдельный элемент легенды и скрыть или восстановить выбранные элементы.

В разделе FAQ рассматриваются связанные поведения, включая резервирование места для легенды, отображение многострочных подписей и наследование форматирования из темы презентации.

## **Расположение легенды**

Используйте свойства легенды [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) и [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) для указания её позиции и размеров как долей от размеров диаграммы.

Этот пример создаёт презентацию и добавляет на первый слайд сгруппированную столбчатую диаграмму с данными по умолчанию. Делением желаемых смещений и размеров легенды на ширину и высоту диаграммы они переводятся в относительные значения: легенда смещена на 50 пунктов от верхнего левого угла диаграммы и имеет размеры 100 × 100 пунктов.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Задайте позицию и размер легенды относительно диаграммы.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Установка размера шрифта легенды**

Используйте свойство легенды [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) для доступа к её форматированию текста и задайте [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) в пунктах.

Этот пример создаёт диаграмму с данными по умолчанию и задаёт размер текста легенды 20 пунктов. Он также отключает автоматические границы вертикальной оси и задаёт её диапазон от -5 до 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Установка размера шрифта отдельного элемента легенды**

Используйте коллекцию легенды [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) для доступа к форматированию конкретного элемента. Индексы элементов начинаются с нуля, поэтому индекс `1` относится ко второму элементу.

Этот пример создаёт сгруппированную столбчатую диаграмму, в данных которой по умолчанию присутствует как минимум две серии. Он форматирует второй элемент легенды полужирным, курсивом и синим текстом размером 20 пунктов.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Скрытие отдельных элементов легенды**

Чтобы исключить вспомогательную серию из легенды, сохранив её данные видимыми, установите [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) в `true` через [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Это скрывает только выбранный элемент легенды; серия и её точки данных не удаляются. Установка [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) в `false`, наоборот, скрывает всю легенду.

Пример ниже создаёт сгруппированную столбчатую диаграмму с несколькими сериями, используя данные по умолчанию. Он скрывает элемент легенды второй серии (индекс `1`) и сохраняет презентацию. Затем восстанавливает элемент, задав `Hide` в `false`, и сохраняет вторую копию. Столбцы остаются видимыми в обоих файлах.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Восстановить тот же элемент без изменения данных диаграммы.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Сравнение ниже показывает одну и ту же диаграмму с полностью видимыми элементами легенды и со скрытым вторым элементом. Столбцы второй серии остаются неизменными.

![Сравнение диаграммы с видимыми всеми элементами легенды и со скрытым элементом Series 2; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбчатых, линейных и гистограммах элементы легенды идентифицируют серии. В круговых диаграммах они идентифицируют отдельные точки данных (слайсы), поэтому используйте [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) для выбранного слайса. API документирует это свойство точек данных для типов диаграмм `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` и `BarOfPie`. Не следует считать, что оно применяется к кольцевым диаграммам, которые в этом списке не указаны.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**  
Да. Установите [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) в `false`, чтобы резервировать место для легенды вместо её наложения на область построения.

**Can I make multiline legend labels?**  
Да. Длинные подписи могут переноситься, если доступная ширина недостаточна. Вы также можете использовать символы перехода на новую строку в названиях серий, чтобы задать разрывы строк.

**How do I make the legend follow the presentation theme's color scheme?**  
Оставьте цвета, заливки и шрифты легенды не заданы, чтобы они наследовали форматирование темы. Явное форматирование переопределяет соответствующие настройки темы.