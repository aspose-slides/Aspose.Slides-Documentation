---
title: Настройка точек данных в диаграммах Treemap и Sunburst на Python
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/python-java/data-points-of-treemap-and-sunburst-chart/
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
- Python
- Java
- Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, метки и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Диаграммы Treemap и Sunburst отображают один и тот же тип иерархических данных, но используют разные макеты. Treemap рисует иерархию в виде вложенных прямоугольников, площади которых представляют значения листьев. Sunburst изображает её в виде концентрических колец: группы верхнего уровня находятся ближе к центру, а категории‑листья — во внешнем кольце.

В Aspose.Slides для Python через Java каждое числовое значение представляет собой [ChartDataPoint](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/). Его метод [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) предоставляет доступ к листу и его родительским группам. Эта статья объясняет это сопоставление и показывает, как создать и отформатировать оба типа диаграмм из одних и тех же примерных данных.

![Диаграмма Treemap с ветками Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

Ниже использованный пример содержит три уровня категорий и одну числовую серию:

| Ветка | Подветка | Лист | Выручка |
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

Индексы, возвращаемые [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), идут от листа к верхним уровням:

| `getDataPointLevels()` индекс | Логический уровень | Представление Treemap | Представление Sunburst |
| ---: | --- | --- | --- |
| `0` | Лист | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Подветка | Прямоугольник или заголовок родителя | Сегмент среднего кольца |
| `2` | Ветка | Прямоугольник или заголовок верхнего уровня | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, хотя их визуальные макеты различаются. Родительский сегмент разделяется несколькими листьями. Чтобы отформатировать его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветка `Consumer` начинается с точки `Laptops`, а подветка `Software` — с точки `Licenses`. Сохранение ссылок на эти точки гораздо понятнее и надёжнее, чем использование неочевидных выражений типа `data_points.get_Item(0)` или `data_points.get_Item(6)`.

## **Создание и настройка обоих типов диаграмм**

Следующий полный пример создаёт Treemap на первом слайде и Sunburst на втором слайде. Он формирует иерархию, отображает значение для `Tablets`, задаёт фиксированные цвета выбранных уровней, форматирует метку ветки и сохраняет презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Добавьте категории листов. Элемент группировки устанавливается только при начале новой группы;
        # последующие категории остаются в этой группе, пока не будет установлен другой элемент.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Показать категорию и значение на листе Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Форматировать ветку Consumer через первый лист в этой ветке.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Форматировать стебель Software через первый лист в этом стебле.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout влияет на метки родителей в Treemap; Sunburst использует кольцевые сегменты.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ячейки категорий и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекции остаются согласованными. При работе с существующей диаграммой, а не с созданием новой, сначала проверьте строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете форматировать.

## **Поведение и практические соображения**

### **Различия Treemap и Sunburst**

- Treemap использует площадь для передачи значения и вложенные прямоугольники для передачи иерархии. Метод [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#setParentLabelLayout) управляет отображением меток родителей в этом типе диаграммы.
- Sunburst использует угол для передачи значения и глубину кольца для передачи иерархии. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartseries/#setParentLabelLayout) не управляет метками её колец.
- Оба типа диаграмм используют одинаковые уровни группировки категорий и один и тот же порядок leaf‑to‑parent, возвращаемый [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), поэтому код построения данных и форматирования уровней может быть общим.
- Значения родителей вычисляются из их потомков‑листов. Не добавляйте отдельные числовые точки для веток или подветок.

### **Сортировка и порядок сегментов**

Движок раскладки диаграммы определяет окончательное размещение прямоугольников и кольцевых сегментов. Группируйте связанные строки категорий вместе перед их добавлением, но не полагайтесь на конкретное положение прямоугольника или начальный угол. Если последовательность имеет смысл, включайте её в метки или используйте тип диаграммы с явной осью категорий.

### **Тема и фиксированные цвета**

Неотформатированные уровни диаграммы наследуют цвета из темы презентации. В примере использованы явные RGB‑заполнения для предсказуемого вывода. Если диаграмма должна следовать изменениям темы, используйте цвета схемы вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверьте контраст меток после изменения заливки ветки или подветки.

### **Методы и доступное пространство**

PowerPoint может скрывать или усекать метки, если сегмент слишком мал. Увеличение размера диаграммы, сокращение названий категорий или отображение меньшего количества полей метки обычно дают более ясный результат. Метка может комбинировать название категории, название серии и значение через [DataLabelFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/), но включение всех полей часто делает иерархические диаграммы трудными для чтения.

### **Экспорт и отрисовка**

Сохранение в PPTX сохраняет диаграмму редактируемой. Когда Aspose.Slides рендерит презентацию в PDF или изображение, поддерживаемые заполнения и настройки меток отображаются в диаграмме. Подстановка шрифтов и небольшие различия в доступном пространстве макета могут изменить перенос строк или видимость меток, поэтому установите необходимые шрифты и проверьте важные цели экспорта.

## **FAQ**

**Почему изменение уровня родителя влияет на несколько листов?**

Ветка или подветка — это общий визуальный сегмент. Его [ChartDataPointLevel](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatapointlevel/) можно достичь через потомка‑лист, но форматирование принадлежит общему родительскому сегменту, а не только этому листу.

**Почему отсутствует метка данных?**

Сначала включите требуемые поля в объекте [DataLabelFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datalabelformat/) метки. Затем проверьте, достаточно ли места у сегмента. Макет родительской метки Treemap, размеры диаграммы, длина метки, размер шрифта и количество включённых полей влияют на возможность отображения метки.

**Могу ли я задать точный порядок или координаты сегментов?**

Можно контролировать порядок строк‑источников и сохранять каждую группу непрерывной, но задать точные прямоугольники Treemap или углы Sunburst нельзя. Движок раскладки рассчитывает их из иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заполнения, основанные на теме, предназначены для следования палитре презентации. Примените явные RGB‑цвета к уровням, которые должны оставаться фиксированными, либо сохраняйте цвета схемы, если предпочтительнее адаптация к новой теме.

**Сохранится ли пользовательское форматирование при экспорте в PDF и изображения?**

Да, поддерживаемые заполнения диаграммы и настройки меток включаются в процесс рендеринга. Для согласованных результатов на разных системах сделайте требуемые шрифты доступными и протестируйте окончательный размер экспорта, поскольку расположение меток зависит от макета.

## **Смотрите также**

- [Create Treemap charts](/slides/ru/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ru/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ru/python-java/export-chart/)
- [Manage presentation themes](/slides/ru/python-java/presentation-theme/)