---
title: Настройка точек данных в диаграммах Treemap и Sunburst на Android
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма Treemap
- диаграмма Sunburst
- иерархическая диаграмма
- точка данных
- подпись данных
- цвет ветви
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, подписи и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Диаграммы Treemap и Sunburst отображают один и тот же тип иерархических данных, но используют разные компоновки. Treemap отображает иерархию в виде вложенных прямоугольников, площадь которых соответствует значениям листов. Sunburst представляет её в виде концентрических колец: группы верхнего уровня находятся ближе к центру, а категории листов — на внешнем кольце.

В Aspose.Slides for Android via Java каждое числовое значение является [IChartDataPoint](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/). Его метод [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) предоставляет доступ к листу и его родительским группам. В этой статье объясняется соответствие и показывается, как создать и оформить оба типа диаграмм, используя одни и те же примерные данные.

![Диаграмма Treemap с ветвями Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

В примере ниже три уровня категорий и один числовой ряд:

| Отдел | Ствол | Элемент | Выручка |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Каждая строка создает одну категорию‑лист и одну точку данных. Уровни группировки категорий описывают путь от листа к его родителям. Для первой строки путь выглядит так: `Consumer > Computers > Laptops`.

Индексы, возвращаемые [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), идут от листа к корню:

| `getDataPointLevels()` index | Логический уровень | Представление Treemap | Представление Sunburst |
| ---: | --- | --- | --- |
| `0` | Лист | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Ствол | Прямоугольник или заголовок родителя | Сегмент среднего кольца |
| `2` | Ветвь | Прямоугольник или заголовок верхнего уровня | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, хотя их визуальная компоновка различается. Родительский сегмент разделяется несколькими листами. Чтобы оформить его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветвь `Consumer` начинается с точки `Laptops`, а ствол `Software` — с точки `Licenses`. Сохранять ссылки на эти точки понятнее и безопаснее, чем использовать неочевидные выражения вроде `dataPoints.get_Item(0)` или `dataPoints.get_Item(6)`.

## **Создание и настройка обоих типов диаграмм**

Следующий полностью готовый пример создаёт Treemap на первом слайде и Sunburst на втором слайде. Он строит иерархию, выводит значение для `Tablets`, задаёт фиксированные цвета выбранным уровням, форматирует подпись ветви и сохраняет презентацию.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Добавьте листовые категории. Элемент группировки задаётся только когда начинается новая группа;
        // последующие категории остаются в этой группе, пока не будет установлен другой элемент.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Отобразите название категории и значение у листа Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Отформатируйте ветвь Consumer через первый лист в этой ветви.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Отформатируйте ствол Software через первый лист в этом стволе.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout влияет на подписи родительских элементов Treemap; Sunburst использует кольцевые сегменты.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ячейки категорий и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекциях остаются согласованными. При работе с уже существующей диаграммой, а не с созданием новой, сначала проанализируйте строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете форматировать.

## **Поведение и практические соображения**

### **Различия между Treemap и Sunburst**

- Treemap использует площадь для передачи значения и вложенные прямоугольники для передачи иерархии. Метод [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) управляет отображением подписи родителя в этом типе диаграммы.
- Sunburst использует угол для передачи значения и глубину кольца для передачи иерархии. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) не управляет подписью кольца.
- Оба типа диаграмм используют одинаковые уровни группировки категорий и одинаковый порядок лист‑к‑родителю, возвращаемый [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), поэтому код построения данных и форматирования уровней можно использовать совместно.
- Значения родительских узлов вычисляются из их дочерних листов. Не добавляйте отдельные числовые точки для ветвей или стволов.

### **Сортировка и порядок сегментов**

Движок компоновки диаграммы определяет окончательное расположение прямоугольников и кольцевых сегментов. Сгруппируйте связанные строки категорий вместе перед их добавлением, но не полагайтесь на конкретную позицию прямоугольника или начальный угол. Если порядок имеет смысл, включите его в подписи или используйте тип диаграммы с явной осью категорий.

### **Тема и фиксированные цвета**

Неоформленные уровни диаграммы наследуют цвет из темы презентации. В примере используются явные RGB‑заполнения для предсказуемого результата. Если диаграмма должна следовать изменениям темы, используйте цвета схемы вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверьте контраст подписи после изменения заливки ветви или ствола.

### **Подписи и доступное пространство**

PowerPoint может скрывать или усекать подписи, если сегмент слишком мал. Увеличение размера диаграммы, сокращение названий категорий или отображение меньшего количества полей подписи обычно дают более ясный результат. Подпись может комбинировать название категории, название ряда и значение через [IDataLabelFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idatalabelformat/), но включение всех полей часто делает иерархические диаграммы трудно читаемыми.

### **Экспорт и рендеринг**

Сохранение в PPTX сохраняет возможность редактирования диаграммы. При рендеринге презентации в PDF или образ в Aspose.Slides поддерживаются заполнения и настройки подписи. Замена шрифтов и небольшие различия в доступном пространстве макета могут изменить перенос строк или видимость подписи, поэтому установите необходимые шрифты и проверьте важные цели экспорта.

## **Вопросы и ответы**

**Почему изменение уровня родителя влияет на несколько листов?**

Ветка или ствол — это общий визуальный сегмент. Его [IChartDataPointLevel](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichartdatapointlevel/) доступен через дочерний лист, но форматирование относится к общему родительскому сегменту, а не только к этому листу.

**Почему отсутствует подпись данных?**

Сначала включите требуемые поля в объекте [IDataLabelFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/idatalabelformat/) подписи. Затем проверьте, достаточно ли места у сегмента. Макет подписи родителя в Treemap, размеры диаграммы, длина подписи, размер шрифта и количество включенных полей влияют на то, будет ли подпись отображена.

**Можно ли задать точный порядок или координаты сегментов?**

Можно контролировать порядок исходных строк и сохранять каждую группу сплошной, но нельзя назначать точные прямоугольники Treemap или углы Sunburst. Движок компоновки вычисляет их из иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заполнения, основанные на теме, предназначены следовать палитре презентации. Задайте явные RGB‑цвета уровням, которые должны оставаться фиксированными, либо оставьте цвета схемы, если предпочтительнее адаптировать их к новой теме.

**Сохранится ли пользовательское форматирование при экспорте в PDF и изображения?**

Да, поддерживаемые заполнения диаграмм и настройки подписи включаются во время рендеринга. Для согласованных результатов на разных системах обеспечьте наличие необходимых шрифтов и протестируйте окончательный размер экспорта, так как подгонка подписи зависит от макета.

## **См. также**

- [Создать диаграммы Treemap](/slides/ru/androidjava/create-chart/#create-tree-map-charts)
- [Создать диаграммы Sunburst](/slides/ru/androidjava/create-chart/#create-sunburst-charts)
- [Экспортировать диаграммы презентаций](/slides/ru/androidjava/export-chart/)
- [Управление темами презентаций](/slides/ru/androidjava/presentation-theme/)