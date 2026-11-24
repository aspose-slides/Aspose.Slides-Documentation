---
title: Управление рабочими книгами диаграмм в презентациях с Python
linktitle: Рабочая книга диаграмм
type: docs
weight: 70
url: /ru/python-net/chart-workbook/
keywords:
- рабочая книга диаграмм
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Откройте для себя Aspose.Slides for Python via .NET: без проблем управлять рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграмм через потоки рабочих книг, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных для диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/python-net/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение линий диаграмм доступных режимов отображения.

## **Включать данные из скрытых строк и столбцов**

Используйте [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) для управления тем, будет ли диаграмма строить данные из скрытых строк и столбцов листа. Установите `True`, чтобы строить только видимые ячейки, или `False`, чтобы включить как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не показывает строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму как первую форму на первом слайде. Встроенный лист, `Sheet1`, содержит следующий исходный диапазон, `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) и читайте [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) для проверки их скрытого статуса. Это свойство только для чтения. В этом файле B2 видим, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и загрузите её снова с помощью [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). При включении всех ячеек также используйте [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) для восстановления полного диапазона, включая скрытую категорию февраля. Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом примере.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

                # Обновить данные диаграммы из встроенной рабочей книги.
                workbook_stream.seek(0)
                chart.chart_data.write_workbook_stream(workbook_stream)
                if not visible_only:
                    # Восстановить полный исходный диапазон, включая скрытые категории.
                    chart.chart_data.set_range("Sheet1!$A$1:$C$4")

                presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20), а другую со всеми шестью значениями. Ниже показанные изображения были отрендерены из сохранённых презентаций после их повторного открытия; оба файла сохраняют назначенную настройку построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`True`) | Все ячейки (`False`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и оптовой торговли для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/python-net/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` отделяет его от диапазона ячеек, а `$A$1:$D$5` указывает ячейки от A1 до D5 включительно. Знаки доллара означают абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, будет вызвано исключение. Для получения дополнительной информации см. [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Этот пример открывает презентацию и проверяет формы непосредственно на каждом слайде в поисках диаграмм. Он выводит имя каждой диаграммы и её исходный диапазон. Если диапазон невозможно получить, выводится диагностическое сообщение, и поиск продолжается со следующей диаграммой.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for Python via .NET предоставляет методы [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные в Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь структуру, похожую на исходную.

В этом примере используется презентация с диаграммой в качестве первой формы на первом слайде. Встроенная рабочая книга читается в поток, существующие серии и категории очищаются, и та же рабочая книга записывается обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Проверка макета диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет свои первоначальные коллекции серий и категорий. Это несоответствие может вызвать ошибку [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) с индексом вне диапазона. Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. В примере используется диаграмма, которая является первой формой на первом слайде. Комментарий отмечает, где происходит редактирование рабочей книги; исполняемый пример записывает оригинальную книгу обратно и проверяет макет в памяти.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Измените поток рабочей книги здесь, например, используя Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Восстановите необходимые сопоставления серий и категорий для обновлённой книги перед использованием диаграммы.

## **Выбор способа хранения меток категорий**

Установите [ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) пока коллекция категорий пуста. Установите `True` для меток, ссылающихся на ячейки листа или образующих иерархию, например кварталы, сгруппированные по годам. Установите `False` для единого уровня меток, заданных строками. Эта настройка применяется только к категориям. Оба примера используют ячейки листа для своих числовых значений серии.

Пример создаёт две столбчатые диаграммы и выводит режим хранения и метки `Q1 Q2 Q3 Q4` для каждой. Для меток, основанных на ячейках, [ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) возвращает ячейку листа, а [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) — метку, хранящуюся в ней. Для буквальных меток читается строка напрямую из [ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка пользовательских числовых форматов для ячеек рабочей книги**

Используйте [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) для управления тем, как числовые значения отображаются в встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться отображать коэффициент конверсии в виде процента с четырьмя знаками после запятой и коэффициент с пятью знаками после запятой. Сохраняйте оба значения числовыми, чтобы они оставались доступными для расчётов и построения диаграмм.

Числовой формат изменяет только отображение, а не сохранённое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет хранимое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346`, не округляя сохранённое значение. Если пользовательский формат пустой строкой (`""`), вместо него используется [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/).

В следующем примере создаётся столбчатая диаграмма и получает доступ к её ячейкам через [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает подписи значений, связанные с исходными форматами.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Форматы ячеек рабочей книги отличаются от форматов, задаваемых непосредственно на осях диаграммы или подписьах данных. В этом примере каждая подпись отображает значение исходной ячейки, потому что включён [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/), и следует исходному числовому формату, поскольку [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) установлено в `True`. После сохранения и повторного открытия презентации подписи показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`, с [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) = `False`.

Чтобы задать независимый формат подписи, снимите флаг ссылки на источник (`False`) и задайте её [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Это не меняет формат ячейки рабочей книги. Например, независимый формат подписи `0.00` отображает первое значение как `0.13`, тогда как B2 остаётся `12.5000%`. См. [Chart Data Labels](/slides/ru/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования подписи.

Изображение ниже было отрендерено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с подписью, связанной с источником, показывающая 12.5000% и 0.12346, а также независимо отформатированную числовую ось.](custom-cell-formats.png)

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

Вы можете использовать текст из ячеек рабочей книги в качестве меток данных диаграммы.

Этот пример добавляет пузырьковую диаграмму с данными по умолчанию на первый слайд существующей презентации. Он использует ячейки A10:A12 на листе 0 для первых трёх меток первой серии, включает подписи из ячеек и сохраняет обновлённую презентацию.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление листами**

Свойство [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имя каждого листа в консоль.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Указание типа источника данных**

Значения точек серии также могут быть сохранены непосредственно как числовые литералы. См. [Set Series Values Using Numeric Literals](/slides/ru/python-net/chart-series/#set-series-values-using-numeric-literals) для полного примера, показывающего их сохранение и чтение. Тип источника точечных значений отделён от внутренней или внешней конфигурации рабочей книги диаграммы; использование числовых литералов само по себе не удаляет встроенную рабочую книгу.

Этот пример создаёт 3D столбчатую диаграмму с данными по умолчанию и задаёт два имени серии, используя разные источники данных. Первое имя задаётся строковым литералом; второе использует ячейку C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает формат Excel binary workbook (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) объекта [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Этот пример проверяет формы на первом слайде существующей презентации, пропускает формы, не являющиеся диаграммами, и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Читайте или изменяйте поддерживаемые данные рабочей книги диаграммы здесь.
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) для экспорта встроенной рабочей книги диаграммы в файл и привязки диаграммы к этой внешней рабочей книге.

Этот пример создаёт круговую диаграмму с данными по умолчанию и экспортирует её рабочую книгу. Поток вывода закрывается перед назначением внешней рабочей книги в качестве источника данных диаграммы, затем сохраняется презентация со ссылкой.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Назначение внешней рабочей книги**

С помощью метода [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если файл был перемещён).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

В примере используется внешняя рабочая книга, лист которой `Sheet1` содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает её с рабочей книгой и использует [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) для сопоставления A1:B4 к одной серии и трём категориям. Затем сохраняет презентацию со связанной диаграммой.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) управляет тем, будет ли загружена рабочая книга.

* Когда `update_chart_data` установлено в `False`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому рабочая книга может быть недоступна.
* Когда `update_chart_data` установлено в `True`, данные диаграммы обновляются из целевой рабочей книги.

Следующий пример назначает заполнитель URL с `update_chart_data`, установленным в `False`. Он сохраняет данные круговой диаграммы по умолчанию и сохраняет презентацию без загрузки недоступной рабочей книги.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Получение пути к внешней рабочей книге, используемой диаграммой**

Чтобы определить, какая рабочая книга привязана к диаграмме, проверьте, использует ли диаграмма внешний источник данных, и получите её путь.

Этот пример проверяет первую форму на первом слайде презентации со связанной внешней рабочей книгой. Если это диаграмма, привязанная к внешней рабочей книге, пример выводит [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) в консоль. Затем сохраняет копию презентации.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как меняете содержимое внутренних книг. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

Этот пример использует диаграмму, являющуюся первой формой на первом слайде и привязанную к доступной внешней рабочей книге. Он задаёт значение, основанное на ячейке, для первой точки данных первой серии = 100 и сохраняет обновлённую презентацию. Редактирование значений ячеек может обновлять связанную внешнюю XLSX‑файл, поэтому используйте копию, если требуется сохранить оригинальную рабочую книгу.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), настройте его [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), и установите [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) в `True` перед открытием презентации.

Следующий пример на Python восстанавливает данные рабочей книги для диаграммы, являющейся первой формой на первом слайде и ссылающейся на недоступную внешнюю рабочую книгу. Доступ к восстановленным данным получается через [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) и [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Читайте или изменяйте восстановленные данные рабочей книги здесь.
    else:
        print("The first shape is not a chart.")
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides бросает исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемым резервным вариантом, поскольку кэш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) и [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно лишь использовать как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Редактирование данных диаграммы, основанных на ячейках, может также обновлять связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычно предварительно снимают защиту или подготавливают расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) и привязывают к ней.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, изменение этого файла будет отражено в каждой диаграмме при следующей загрузке данных.