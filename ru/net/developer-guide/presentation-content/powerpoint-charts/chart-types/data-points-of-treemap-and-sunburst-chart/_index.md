---
title: Настройка точек данных в диаграммах Treemap и Sunburst в .NET
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- иерархическая диаграмма
- точка данных
- метка данных
- цвет ветки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, метки и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides для .NET."
---
## **Обзор**

Treemap и Sunburst‑диаграммы отображают один и тот же тип иерархических данных, но используют разные макеты. Treemap рисует иерархию в виде вложенных прямоугольников, площадь которых представляет значения листьев. Sunburst отображает её в виде концентрических колец: группы верхнего уровня находятся ближе к центру, а категории листьев — на внешнем кольце.

В Aspose.Slides for .NET каждый числовой параметр является [IChartDataPoint](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/). Его коллекция [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) предоставляет доступ к листу и его родительским группам. Эта статья объясняет это сопоставление и показывает, как создать и отформатировать оба типа диаграмм из одних и тех же пробных данных.

![Диаграмма Treemap с ветвями Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

В примере ниже используется три уровня категорий и один числовой ряд:

| Ветка | Подуровень | Лист | Выручка |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Каждая строка создает одну листовую категорию и одну точку данных. Уровни группировки категорий описывают путь от этого листа к его родителям. Для первой строки путь выглядит так: `Consumer > Computers > Laptops`.

Индексы в [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) идут от листа вверх:

| `DataPointLevels` index | Логический уровень | Представление Treemap | Представление Sunburst |
| ---: | --- | --- | --- |
| `0` | Лист | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Подуровень | Прямоугольник родителя или заголовок | Сегмент среднего кольца |
| `2` | Ветка | Прямоугольник верхнего уровня или заголовок | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, несмотря на различия в визуальном макете. Родительский сегмент разделяется несколькими листами. Чтобы отформатировать его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветка `Consumer` начинается с точки `Laptops`, а подуровень `Software` — с точки `Licenses`. Хранение ссылок на эти точки понятнее и надёжнее, чем использование неочевидных выражений вроде `dataPoints[0]` или `dataPoints[6]`.

## **Создание и настройка обоих типов диаграмм**

Следующий полный пример создает Treemap на первом слайде и Sunburst на втором. Он строит иерархию, выводит значение для `Tablets`, задаёт фиксированные цвета выбранным уровням, форматирует подпись ветки и сохраняет презентацию.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Добавьте листовые категории. Элемент группировки устанавливается только при начале новой группы;
    // следующие категории остаются в этой группе, пока не будет установлен другой элемент.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Отобразить категорию и значение у листа Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Форматировать ветку Consumer через первый лист в этой ветке.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Форматировать стебель Software через первый лист в этом стебле.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout влияет на метки родителей в Treemap; Sunburst использует кольцевые сегменты.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Ячейки категории и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекции остаются согласованными. Когда вы работаете с существующей диаграммой вместо создания новой, сначала проанализируйте строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете отформатировать.

## **Поведение и практические соображения**

### **Различия между Treemap и Sunburst**

- Treemap использует площадь для передачи значения и вложенные прямоугольники для передачи иерархии. Свойство [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/parentlabellayout/) управляет отображением меток родителей в этом типе диаграммы.
- Sunburst использует угол для передачи значения и глубину кольца для передачи иерархии. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/parentlabellayout/) не управляет метками кольца.
- Оба типа диаграмм используют одинаковые уровни группировки категорий и одинаковый порядок лист‑к‑родителю в `DataPointLevels`, поэтому код построения данных и форматирования уровней может быть общим.
- Значения родительских элементов рассчитываются из их дочерних листьев. Не добавляйте отдельные числовые точки для веток или подуровней.

### **Сортировка и порядок сегментов**

Движок компоновки диаграммы определяет окончательное размещение прямоугольников и кольцевых сегментов. Сгруппируйте связанные строки категорий перед добавлением, но не полагайтесь на конкретное положение прямоугольника или начальный угол. Если порядок имеет смысл, включите его в метки или используйте тип диаграммы с явной осью категорий.

### **Тема и фиксированные цвета**

Неотформатированные уровни диаграммы наследуют цвета из темы презентации. В примере используются явные заливки RGB для предсказуемого вывода. Если диаграмма должна следовать изменениям темы, используйте схемные цвета вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверяйте контраст меток после изменения заливки ветки или подуровня.

### **Подписи и доступное пространство**

PowerPoint может скрывать или усекать подписи, когда сегмент слишком мал. Увеличение размера диаграммы, сокращение названий категорий или отображение меньшего числа полей подписи обычно дают более чистый результат. Метка может комбинировать название категории, название ряда и значение через [IDataLabelFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/), но включение всех полей часто делает иерархические диаграммы трудными для чтения.

### **Экспорт и рендеринг**

Сохранение в PPTX сохраняет диаграмму редактируемой. При рендеринге презентации в PDF или изображение Aspose.Slides использует поддерживаемые заливки и настройки меток. Подмена шрифтов и небольшие различия в доступном пространстве могут изменить перенос строк или видимость метки, поэтому установите требуемые шрифты и проверьте важные цели экспорта.

## **Часто задаваемые вопросы**

**Почему изменение уровня родителя влияет на несколько листов?**

Ветка или подуровень — это общий визуальный сегмент. К его [IChartDataPointLevel](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapointlevel/) можно обратиться через дочерний лист, но форматирование относится к общему родительскому сегменту, а не только к этому листу.

**Почему отсутствует подпись данных?**

Сначала включите необходимые поля в объекте [IDataLabelFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/idatalabelformat/) метки. Затем проверьте, достаточно ли места у сегмента. Макет меток родителя в Treemap, размеры диаграммы, длина подписи, размер шрифта и количество включённых полей влияют на то, будет ли подпись отображена.

**Можно ли задать точный порядок или координаты сегментов?**

Можно контролировать порядок исходных строк и держать каждую группу непрерывной, но нельзя назначать точные прямоугольники Treemap или углы Sunburst. Движок компоновки рассчитывает их из иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заливки, основанные на теме, предназначены следовать палитре презентации. Примените явные RGB‑цвета к уровням, которые должны оставаться постоянными, или используйте схемные цвета, если предпочтительно адаптировать их к новой теме.

**Сохранится ли пользовательское форматирование при экспорте в PDF и изображения?**

Да, поддерживаемые заливки диаграммы и настройки меток включаются в процесс рендеринга. Для согласованных результатов на разных системах обеспечьте наличие необходимых шрифтов и протестируйте конечный размер экспорта, поскольку подгонка меток зависит от компоновки.

## **См. также**

- [Create Treemap charts](/slides/ru/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ru/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ru/net/export-chart/)
- [Manage presentation themes](/slides/ru/net/presentation-theme/)