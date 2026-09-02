---
title: Настройка точек данных в диаграммах Treemap и Sunburst в Java
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- диаграмма treemap
- диаграмма sunburst
- иерархическая диаграмма
- точка данных
- метка данных
- цвет ветки
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, метки и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Java."
---
## **Обзор**

Диаграммы Treemap и Sunburst отображают одинаковый тип иерархических данных, но используют различные макеты. Treemap рисует иерархию в виде вложенных прямоугольников, площади которых соответствуют значениям листьев. Sunburst отображает её в виде концентрических колец: группы верхнего уровня находятся ближе к центру, а категории листьев – на внешнем кольце.

В Aspose.Slides for Java каждое числовое значение представляет собой [IChartDataPoint](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/). Его метод [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) предоставляет доступ к листу и его родительским группам. В этой статье объясняется это отображение и показывается, как создать и оформить оба типа диаграмм из одних и тех же примерных данных.

![Диаграмма Treemap с ветвями Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

Ниже использованный пример содержит три уровня категорий и один числовой ряд:

| Подразделение | Подгруппа | Лист | Выручка |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Каждая строка создаёт одну категорию‑лист и одну точку данных. Уровни группировки категорий описывают путь от этого листа к его родителям. Для первой строки путь выглядит так: `Consumer > Computers > Laptops`.

Индексы, возвращаемые [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), идут от листа к корню:

| Индекс `getDataPointLevels()` | Логический уровень | Представление Treemap | Представление Sunburst |
| ---: | --- | --- | --- |
| `0` | Лист | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Подгруппа | Прямоугольник или заголовок родителя | Сегмент среднего кольца |
| `2` | Подразделение | Прямоугольник или заголовок верхнего уровня | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, хотя их визуальные макеты различаются. Сегмент‑родитель используется несколькими листьями. Чтобы оформить его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветка `Consumer` начинается с точки `Laptops`, а подгруппа `Software` — с точки `Licenses`. Хранение ссылок на такие точки делает код понятнее и безопаснее, чем использование необъяснённых выражений типа `dataPoints.get_Item(0)` или `dataPoints.get_Item(6)`.

## **Создание и настройка обоих типов диаграмм**

Ниже приведён полностью работающий пример, который создаёт Treemap на первом слайде и Sunburst на втором. Он строит иерархию, отображает значение для `Tablets`, задаёт фиксированные цвета выбранным уровням, форматирует подпись ветки и сохраняет презентацию.

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

        // Добавить категории листов. Элемент группировки устанавливается только когда начинается новая группа;
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

        // Показать категорию и значение у листа Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Отформатировать ветку Consumer через первый лист в этой ветке.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Отформатировать подгруппу Software через первый лист в этой подгруппе.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout влияет на метки родителей в Treemap; Sunburst использует кольцевые сегменты.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ячейки категорий и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекции остаются согласованными. Когда вы работаете с уже существующей диаграммой, а не создаёте новую, сначала проанализируйте строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете форматировать.

## **Поведение и практические соображения**

### **Различия между Treemap и Sunburst**

- Treemap использует площадь для передачи значения и вложенные прямоугольники для передачи иерархии. Метод [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) управляет отображением меток родителей в этом типе диаграммы.
- Sunburst использует угол для передачи значения и глубину кольца для передачи иерархии. Метод [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) **не** управляет метками кольца.
- Оба типа диаграмм используют одни и те же уровни группировки категорий и одинаковый порядок лист‑к‑родителю, возвращаемый [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), поэтому код построения данных и форматирования уровней может быть общим.
- Значения родителей вычисляются из их дочерних листьев. Не добавляйте отдельные числовые точки для ветвей или подгрупп.

### **Сортировка и порядок сегментов**

Движок макета диаграммы определяет окончательное расположение прямоугольников и кольцевых сегментов. Сгруппируйте связанные строки категорий перед их добавлением, но не полагайтесь на конкретную позицию прямоугольника или начальный угол. Если порядок имеет смысл, включите его в метки или используйте тип диаграммы с явной осью категорий.

### **Тема и фиксированные цвета**

Неоформленные уровни диаграммы наследуют цвета из темы презентации. В примере используются явные заливки RGB для предсказуемого результата. Если диаграмма должна реагировать на изменения темы, используйте цвета схемы вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверьте контраст меток после изменения заливки ветки или подгруппы.

### **Метики и доступное пространство**

PowerPoint может скрывать или усекать метки, когда сегмент слишком мал. Увеличение размера диаграммы, сокращение названий категорий или отображение меньшего количества полей метки обычно дают более чёткий результат. Метка может комбинировать название категории, название ряда и значение через [IDataLabelFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idatalabelformat/), но включение всех полей часто делает иерархические диаграммы трудно читаемыми.

### **Экспорт и рендеринг**

Сохранение в PPTX сохраняет возможность редактирования диаграммы. При рендеринге презентации Aspose.Slides в PDF или изображение поддерживаемые заливки и параметры меток отображаются вместе с диаграммой. Подстановка шрифтов и небольшие различия в доступном пространстве могут изменить перенос строк или видимость меток, поэтому установите необходимые шрифты и проверьте важные цели экспорта.

## **FAQ**

**Почему изменение уровня родителя влияет на несколько листьев?**

Ветка или подгруппа — это общий визуальный сегмент. Его [IChartDataPointLevel](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ichartdatapointlevel/) можно достичь через дочерний лист, но форматирование относится к общему сегменту‑родителю, а не только к этому листу.

**Почему отсутствует метка данных?**

Сначала включите требуемые поля в объекте [IDataLabelFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/idatalabelformat/) метки. Затем проверьте, достаточно ли места у сегмента. Макет родительских меток Treemap, размеры диаграммы, длина метки, размер шрифта и количество включённых полей влияют на возможность отображения метки.

**Можно ли задать точный порядок или координаты сегментов?**

Можно управлять порядком строк‑источников и держать каждую группу сплошной, но задать точные прямоугольники Treemap или углы Sunburst нельзя. Движок макета рассчитывает их на основе иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заливки, основанные на теме, предназначены для следования палитре презентации. Применяйте явные RGB‑цвета к тем уровням, которые должны оставаться фиксированными, или сохраняйте цвета схемы, если предпочтительно адаптировать их к новой теме.

**Сохраняются ли пользовательские форматы при экспорте в PDF и изображения?**

Да, поддерживаемые заливки диаграммы и параметры меток включаются при рендеринге. Для согласованных результатов на разных системах сделайте шрифты доступными и протестируйте окончательный размер экспорта, поскольку вписание меток зависит от макета.

## **Смотрите также**

- [Create Treemap charts](/slides/ru/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ru/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ru/java/export-chart/)
- [Manage presentation themes](/slides/ru/java/presentation-theme/)