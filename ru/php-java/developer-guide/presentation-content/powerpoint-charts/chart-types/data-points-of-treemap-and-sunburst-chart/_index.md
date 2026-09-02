---
title: Настройка точек данных в диаграммах Treemap и Sunburst на PHP
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/php-java/data-points-of-treemap-and-sunburst-chart/
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
- PHP
- Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, подписи и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides for PHP via Java."
---
## **Обзор**

Treemap и Sunburst диаграммы отображают одинаковый тип иерархических данных, но используют разные макеты. Treemap рисует иерархию в виде вложенных прямоугольников, площади которых представляют значения листьев. Sunburst отображает её в виде concentric кольцев: группы верхнего уровня находятся ближе к центру, а категории листьев — на внешнем кольце.

В Aspose.Slides for PHP via Java каждое числовое значение представлено объектом [ChartDataPoint](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/). Его метод [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) предоставляет доступ к листу и его родительским группам. Эта статья объясняет это сопоставление и показывает, как создать и настроить оба типа диаграмм, используя одни и те же примерные данные.

![Диаграмма Treemap с ветвями Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

В приведённом примере используется три уровня категорий и один числовой ряд:

| Ветка | Ствол | Лист | Выручка |
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

Индексы, возвращаемые [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), идут от листа к вершине:

| `getDataPointLevels()` индекс | Логический уровень | Представление Treemap | Представление Sunburst |
| ---: | --- | --- | --- |
| `0` | Лист | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Ствол | Прямоугольник или заголовок родителя | Сегмент среднего кольца |
| `2` | Ветка | Прямоугольник или заголовок верхнего уровня | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, хотя их визуальные макеты различаются. Родительский сегмент используется несколькими листами. Чтобы отформатировать его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветка `Consumer` начинается с точки `Laptops`, а ствол `Software` начинается с точки `Licenses`. Хранить ссылки на эти точки яснее и безопаснее, чем использовать необъяснённые выражения, такие как `$dataPoints->get_Item(0)` или `$dataPoints->get_Item(6)`.

## **Создание и настройка обоих типов диаграмм**

Ниже приведён полный пример, который создаёт диаграмму Treemap на первом слайде и диаграмму Sunburst на втором слайде. Он строит иерархию, отображает значение для `Tablets`, применяет фиксированные цвета к выбранным уровням, форматирует подпись ветки и сохраняет презентацию.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Добавить категории листьев. Элемент группировки устанавливается только при начале новой группы;
        // последующие категории остаются в этой группе, пока не будет установлен другой элемент.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Показать категорию и значение у листа Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Отформатировать ветку Consumer через первый лист в этой ветке.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Отформатировать ствол Software через первый лист в этом стволе.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout влияет на подписи родителей в Treemap; Sunburst использует сегменты кольца.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ячейки категорий и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекциях остаются согласованными. Когда вы работаете с существующей диаграммой, а не создаёте её, сначала изучите строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете форматировать.

## **Поведение и практические соображения**

### **Отличия Treemap и Sunburst**

- Treemap использует площадь для отображения значения и вложенные прямоугольники для отображения иерархии. Метод [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setParentLabelLayout) управляет тем, как отображаются подписи родителей в этом типе диаграмм.
- Sunburst использует угол для отображения значения и глубину кольца для отображения иерархии. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartseries/#setParentLabelLayout) не управляет подписями кольца.
- Оба типа диаграмм используют одни и те же уровни группировки категорий и одинаковый порядок лист‑родитель, возвращаемый [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), поэтому код построения данных и форматирования уровней может быть общим.
- Значения родителей рассчитываются из их дочерних листьев. Не добавляйте отдельные числовые точки для ветвей или стволов.

### **Сортировка и порядок сегментов**

Механизм компоновки диаграммы определяет окончательное размещение прямоугольников и сегментов кольца. Сгруппируйте связанные строки категорий вместе перед их добавлением, но не полагайтесь на конкретное положение прямоугольника или начальный угол. Если порядок имеет значение, включите его в подписи или используйте тип диаграммы с явной осью категорий.

### **Тема и фиксированные цвета**

Неотформатированные уровни диаграммы наследуют цвета из темы презентации. В примере используются явные RGB‑заполнения для предсказуемого результата. Если диаграмма должна подстраиваться под изменения темы, используйте цвета схемы вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверьте контраст подписи после изменения заполнения ветки или ствола.

### **Подписи и доступное пространство**

PowerPoint может скрывать или усекать подписи, когда сегмент слишком мал. Увеличение размера диаграммы, сокращение названий категорий или отображение меньшего количества полей подписи обычно дает более ясный результат. Подпись может объединять название категории, название ряда и значение с помощью [DataLabelFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datalabelformat/), но включение всех полей часто делает иерархические диаграммы трудночитаемыми.

### **Экспорт и рендеринг**

Сохранение в формате PPTX сохраняет возможность редактирования диаграммы. Когда Aspose.Slides рендерит презентацию в PDF или изображение, поддерживаемые заполнения и параметры подписи отображаются вместе с диаграммой. Подстановка шрифтов и небольшие различия в доступном пространстве компоновки могут изменить перенос строк или видимость подписи, поэтому установите необходимые шрифты и проверьте важные цели экспорта.

## **Вопросы и ответы**

**Почему изменение уровня родителя влияет на несколько листьев?**

Ветка или ствол представляют собой общий визуальный сегмент. Его [ChartDataPointLevel](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdatapointlevel/) можно достичь через дочерний лист, но форматирование относится к общему родительскому сегменту, а не только к этому листу.

**Почему отсутствует подпись данных?**

Сначала включите необходимые поля в объекте [DataLabelFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/datalabelformat/) подписи. Затем проверьте, хватает ли места у сегмента. Макет подписи родителя в Treemap, размеры диаграммы, длина подписи, размер шрифта и количество включённых полей влияют на возможность отображения подписи.

**Могу ли я задать точный порядок или координаты сегментов?**

Можно контролировать порядок строк‑источников и держать каждую группу сплошной, но нельзя задавать точные прямоугольники Treemap или углы Sunburst. Механизм компоновки диаграммы вычисляет их из иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заполнения, основанные на теме, предназначены для следования палитре презентации. Применяйте явные RGB‑цвета к уровням, которые должны оставаться фиксированными, либо сохраняйте цвета схемы, если предпочтительно адаптировать их к новой теме.

**Будут ли пользовательские форматы сохранены при экспорте в PDF и изображения?**

Да, поддерживаемые заполнения диаграммы и параметры подписи включаются при рендеринге. Для согласованных результатов на разных системах обеспечьте наличие необходимых шрифтов и проверьте окончательный размер экспорта, так как размещение подписи зависит от компоновки.

## **Смотрите также**

- [Создать диаграммы Treemap](/slides/ru/php-java/create-chart/#create-tree-map-charts)
- [Создать диаграммы Sunburst](/slides/ru/php-java/create-chart/#create-sunburst-charts)
- [Экспортировать диаграммы презентации](/slides/ru/php-java/export-chart/)
- [Управление темами презентации](/slides/ru/php-java/presentation-theme/)