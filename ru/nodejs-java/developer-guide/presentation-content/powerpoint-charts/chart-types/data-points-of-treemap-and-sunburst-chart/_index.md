---
title: "Настройка точек данных в диаграммах Treemap и Sunburst с использованием JavaScript"
linktitle: "Точки данных в диаграммах Treemap и Sunburst"
type: docs
url: /ru/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
  - диаграмма Treemap
  - диаграмма Sunburst
  - иерархическая диаграмма
  - точка данных
  - подпись данных
  - цвет ветки
  - PowerPoint
  - презентация
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, подписи и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Node.js via Java."
---
## **Обзор**

Диаграммы Treemap и Sunburst отображают один и тот же тип иерархических данных, но используют разные макеты. Treemap рисует иерархию в виде вложенных прямоугольников, площади которых представляют значения листьев. Sunburst отображает её как концентрические кольца: группы верхнего уровня находятся ближе к центру, а категории‑листья — на внешнем кольце.

В Aspose.Slides for Node.js via Java каждый числовой показатель представляет собой [ChartDataPoint](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatapoint/). Его метод [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) предоставляет доступ к листу и его родительским группам. В этой статье объясняется это отображение и показано, как создать и отформатировать оба типа диаграмм из одних и тех же образцовых данных.

![Диаграмма Treemap с ветвями Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

Ниже приведён пример с тремя уровнями категорий и одной числовой серией:

| Раздел | Подраздел | Элемент | Выручка |
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

Индексы, возвращаемые [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), идут от листа вверх:

| `getDataPointLevels()` индекс | Логический уровень | Отображение Treemap | Отображение Sunburst |
| ---: | --- | --- | --- |
| `0` | Leaf | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Stem | Прямоугольник или заголовок родителя | Сегмент среднего кольца |
| `2` | Branch | Прямоугольник или заголовок верхнего уровня | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, хотя их визуальные макеты различаются. Родительский сегмент используется несколькими листами. Чтобы отформатировать его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветка `Consumer` начинается с точки `Laptops`, а стебель `Software` — с точки `Licenses`. Хранить ссылки на эти точки безопаснее, чем использовать необъяснённые выражения вроде `dataPoints.get_Item(0)` или `dataPoints.get_Item(6)`.

## **Создание и настройка обоих типов диаграмм**

Следующий полный пример создаёт Treemap на первом слайде и Sunburst на втором слайде. Он строит иерархию, отображает значение для `Tablets`, применяет фиксированные цвета к выбранным уровням, форматирует подпись ветки и сохраняет презентацию.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Добавьте категории листьев. Элемент группировки устанавливается только когда начинается новая группа;
        // следующие категории остаются в этой группе, пока не будет установлен другой элемент.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Показать категорию и значение на листе Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Отформатировать ветку Consumer через первый лист в этой ветке.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Отформатировать стебель Software через первый лист в этом стебле.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout влияет на метки родителей в Treemap; Sunburst использует сегменты колец.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ячейки категорий и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекции остаются согласованными. Когда вы работаете с существующей диаграммой, а не создаёте новую, сначала проверьте строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете форматировать.

## **Поведение и практические соображения**

### **Различия Treemap и Sunburst**

- Treemap использует площадь для передачи значения и вложенные прямоугольники для передачи иерархии. Метод [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) управляет отображением меток родителей в этом типе диаграммы.
- Sunburst использует угол для передачи значения и глубину кольца для передачи иерархии. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) не управляет метками её колец.
- Оба типа диаграмм используют одни и те же уровни группировки категорий и одинаковый порядок лист‑родитель, возвращаемый [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), поэтому код построения данных и форматирования уровней можно использовать совместно.
- Значения родительских сегментов рассчитываются из их дочерних листьев. Не добавляйте отдельные числовые точки для веток или стеблей.

### **Сортировка и порядок сегментов**

Движок размещения диаграмм определяет финальное расположение прямоугольников и кольцевых сегментов. Сгруппируйте связанные строки категорий вместе перед их добавлением, но не полагайтесь на конкретную позицию прямоугольника или начальный угол. Если порядок имеет смысл, включите его в метки или используйте тип диаграммы с явно выраженной категорией по оси.

### **Тема и фиксированные цвета**

Неотформатированные уровни диаграммы наследуют цвета из темы презентации. В примере использованы явные RGB‑заливки для предсказуемого результата. Если диаграмма должна следовать изменению темы, используйте схемные цвета вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверяйте контраст меток после изменения заливки ветки или стебля.

### **Метки и доступное пространство**

PowerPoint может скрывать или обрезать метки, если сегмент слишком мал. Увеличение размеров диаграммы, сокращение названий категорий или отображение меньшего количества полей меток обычно дают более чёткий результат. Метка может комбинировать название категории, название серии и значение через [DataLabelFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabelformat/), но включение всех полей часто делает иерархические диаграммы трудными для чтения.

### **Экспорт и рендеринг**

Сохранение в PPTX оставляет диаграмму редактируемой. При рендеринге презентации Aspose.Slides в PDF или изображение поддерживаемые заливки и настройки меток отображаются вместе с диаграммой. Подстановка шрифтов и небольшие различия в доступном пространстве могут изменить перенос строк или видимость меток, поэтому установите необходимые шрифты и проверьте важные цели экспорта.

## **FAQ**

**Почему изменение уровня родителя влияет на несколько листьев?**

Ветка или стебель — это общий визуальный сегмент. Его [ChartDataPointLevel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdatapointlevel/) можно достичь через дочерний лист, но форматирование относится к общему родительскому сегменту, а не только к этому листу.

**Почему отсутствует метка данных?**

Сначала включите необходимые поля в объекте [DataLabelFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabelformat/) метки. Затем проверьте, достаточно ли места у сегмента. Раскладка родительских меток Treemap, размеры диаграммы, длина метки, размер шрифта и количество включённых полей влияют на возможность отображения метки.

**Можно ли задать точный порядок или координаты сегментов?**

Можно управлять порядком строк‑источников и сохранять каждую группу сплошной, но нельзя задавать точные прямоугольники Treemap или углы Sunburst. Движок размещения диаграмм вычисляет их из иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заливки, основанные на теме, предназначены следовать цветовой палитре презентации. Применяйте явные RGB‑цвета к уровням, которые должны оставаться фиксированными, либо используйте схемные цвета, если предпочтительно адаптировать их к новой теме.

**Сохранится ли пользовательское форматирование при экспорте в PDF и изображения?**

Да, поддерживаемые заливки диаграмм и параметры меток включаются в процесс рендеринга. Для согласованного результата на разных системах обеспечьте наличие требуемых шрифтов и протестируйте конечный размер экспорта, поскольку размещение меток зависит от макета.

## **Смотрите также**

- [Create Treemap charts](/slides/ru/nodejs-java/create-chart/#creating-tree-map-charts)
- [Create Sunburst charts](/slides/ru/nodejs-java/create-chart/#creating-sunburst-charts)
- [Export presentation charts](/slides/ru/nodejs-java/export-chart/)
- [Manage presentation themes](/slides/ru/nodejs-java/presentation-theme/)