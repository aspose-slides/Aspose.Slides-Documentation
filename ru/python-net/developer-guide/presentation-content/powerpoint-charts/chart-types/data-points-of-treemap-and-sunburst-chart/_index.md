---
title: Настройка точек данных в диаграммах Treemap и Sunburst на Python
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/python-net/data-points-of-treemap-and-sunburst-chart/
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
- Aspose.Slides
description: "Узнайте, как создавать иерархические данные и настраивать уровни, подписи и цвета в диаграммах Treemap и Sunburst с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Диаграммы Treemap и Sunburst отображают один и тот же тип иерархических данных, но используют разные схемы расположения. Treemap рисует иерархию как вложенные прямоугольники, площадь которых соответствует значениям листьев. Sunburst отображает её в виде концентрических колец: группы верхнего уровня находятся ближе к центру, а категории листьев — на внешнем кольце.

В Aspose.Slides for Python via .NET каждое числовое значение представлено объектом [ChartDataPoint](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/). Его коллекция [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) предоставляет доступ к листу и его родительским группам. В этой статье объясняется это сопоставление и показывается, как создать и отформатировать оба типа диаграмм на основе одних и тех же примерных данных.

![Диаграмма Treemap с ветвями Consumer и Business](treemap-hierarchy.png)

![Диаграмма Sunburst с той же иерархией Consumer и Business](sunburst-hierarchy.png)

## **Понимание категорий, точек данных и уровней**

В примере ниже три уровня категорий и один числовой ряд:

| Ветка | Стебель | Лист | Выручка |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Каждая строка создаёт одну категорию‑лист и одну точку данных. Уровни группировки категорий описывают путь от листа к его родителям. Для первой строки путь выглядит так: `Consumer > Computers > Laptops`.

Индексы в [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) считаются от листа к корню:

| `data_point_levels` index | Логический уровень | Представление Treemap | Представление Sunburst |
| ---: | --- | --- | --- |
| `0` | Лист | Прямоугольник значения | Сегмент внешнего кольца |
| `1` | Стебель | Родительский прямоугольник или заголовок | Сегмент среднего кольца |
| `2` | Ветка | Прямоугольник верхнего уровня или заголовок | Сегмент внутреннего кольца |

Этот порядок одинаков для обоих типов диаграмм, хотя их визуальные схемы различаются. Родительский сегмент совместно используется несколькими листьями. Чтобы отформатировать его, используйте соответствующий уровень первой точки данных в этой группе. Например, ветка `Consumer` начинается с точки `Laptops`, а стебель `Software` — с точки `Licenses`. Хранить ссылки на эти точки яснее и безопаснее, чем использовать необъяснённые выражения типа `data_points[0]` или `data_points[6]`.

## **Создание и настройка обоих типов диаграмм**

Ниже приведён полный пример, который создаёт Treemap на первом слайде и Sunburst на втором слайде. Пример строит иерархию, отображает значение для `Tablets`, задаёт фиксированные цвета выбранным уровням, формирует подпись ветки и сохраняет презентацию.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Добавьте категории листьев. Элемент группировки устанавливается только при начале новой группы;
    # последующие категории остаются в этой группе, пока не будет установлен другой элемент.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Отобразите категорию и значение у листа Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Отформатируйте ветку Consumer через первый лист в этой ветке.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Отформатируйте стебель Software через первый лист в этом стебле.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout влияет на подписи родителя в Treemap; Sunburst использует сегменты колец.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Ячейки категорий и ячейки значений используют одну и ту же строку листа, поэтому их позиции в коллекциях остаются согласованными. При работе с существующей диаграммой, а не при её создании, сначала изучите строки категорий и сохраните именованные ссылки на точки данных и уровни, которые планируете форматировать.

## **Поведение и практические соображения**

### **Различия между Treemap и Sunburst**

- Treemap использует площадь для передачи значения и вложенные прямоугольники для передачи иерархии. Свойство [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/parent_label_layout/) управляет отображением подписей родителя в этом типе диаграммы.
- Sunburst использует угол для передачи значения и глубину кольца для передачи иерархии. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartseries/parent_label_layout/) не управляет подписями её колец.
- Оба типа используют одинаковые уровни группировки категорий и одинаковый порядок лист‑родитель в `data_point_levels`, поэтому код построения данных и форматирования уровней может быть общим.
- Значения родительских элементов вычисляются из их дочерних листьев. Не добавляйте отдельные числовые точки для веток или стеблей.

### **Сортировка и порядок сегментов**

Движок размещения диаграммы определяет окончательное расположение прямоугольников и сегментов колец. Сгруппируйте связанные строки категорий вместе перед их добавлением, но не полагайтесь на конкретную позицию прямоугольника или начальный угол. Если порядок имеет смысл, включите его в подписи или используйте тип диаграммы с явной категорической осью.

### **Тема и фиксированные цвета**

Неотформатированные уровни диаграммы наследуют цвета из темы презентации. В примере использованы явные RGB‑заполнения для предсказуемого результата. Если диаграмма должна следовать изменениям темы, используйте цвета схемы вместо фиксированных RGB‑значений и избегайте переопределения каждого уровня. Также проверяйте контраст подписи после изменения заливки ветки или стебля.

### **Подписи и доступное пространство**

PowerPoint может скрывать или усекать подписи, когда сегмент слишком маленький. Увеличение размера диаграммы, сокращение названий категорий или отображение меньшего количества полей подписи обычно приводит к более ясному результату. Подпись может комбинировать название категории, имя ряда и значение через [DataLabelFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/), но включение всех полей часто делает иерархические диаграммы трудно читаемыми.

### **Экспорт и рендеринг**

Сохранение в PPTX сохраняет возможность редактировать диаграмму. Когда Aspose.Slides рендерит презентацию в PDF или изображение, поддерживаемые заливки и настройки подписей отображаются вместе с диаграммой. Подстановка шрифтов и небольшие различия в доступном пространстве макета могут изменить перенос строк или видимость подписи, поэтому установите требуемые шрифты и проверьте важные цели экспорта.

## **Вопросы и ответы**

**Почему изменение уровня родителя влияет на несколько листов?**

Ветка или стебель — это общий визуальный сегмент. К его [ChartDataPointLevel](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatapointlevel/) можно получить доступ через дочерний лист, но форматирование относится к общему родительскому сегменту, а не только к этому листу.

**Почему отсутствует подпись данных?**

Сначала включите необходимые поля в объекте [DataLabelFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datalabelformat/) подписи. Затем проверьте, хватает ли сегменту места. Макет родительской подписи Treemap, размеры диаграммы, длина подписи, размер шрифта и количество включённых полей влияют на возможность отображения подписи.

**Можно ли задать точный порядок или координаты сегментов?**

Можно контролировать порядок строк‑источников и держать каждую группу сплошной, но задать точные прямоугольники Treemap или углы Sunburst нельзя. Движок размещения рассчитывает их из иерархии, значений и доступного пространства.

**Почему цвета меняются после изменения темы презентации?**

Заполнения, основанные на теме, предназначены для следования палитре презентации. Примените явные RGB‑цвета к уровням, которые должны оставаться фиксированными, или сохраняйте цвета схемы, если предпочтительно адаптироваться к новой теме.

**Сохранится ли пользовательское форматирование при экспорте в PDF и изображения?**

Да, поддерживаемые заливки диаграммы и настройки подписей включаются в процесс рендеринга. Для согласованных результатов на разных системах сделайте требуемые шрифты доступными и протестируйте окончательный размер экспорта, так как подгонка подписи зависит от макета.

## **См. также**

- [Create Treemap charts](/slides/ru/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ru/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ru/python-net/export-chart/)
- [Manage presentation themes](/slides/ru/python-net/presentation-theme/)