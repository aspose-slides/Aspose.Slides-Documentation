---
title: Управление рабочими книгами диаграмм в презентациях с Python
linktitle: Рабочая книга диаграммы
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
description: "Откройте для себя Aspose.Slides для Python через .NET: без усилий управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с листами диаграмм в Aspose.Slides. Описывается чтение и запись данных диаграммы через потоки листов, использование ячеек листа в качестве меток данных диаграммы, доступ к коллекциям листов и указание типа источника данных для значений диаграммы.

Также рассматривается работа с внешними листами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешний лист, получить путь к внешнему листу, связанному с диаграммой, и редактировать данные диаграммы, когда лист доступен.

Для ячеек листа, представляющих отсутствие данных, см. [Управление отображением пустых ячеек](/slides/ru/python-net/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) для управления тем, будет ли диаграмма использовать данные из скрытых строк и столбцов листа. Установите `True`, чтобы отображать только видимые ячейки, или `False`, чтобы включать как видимые, так и скрытые ячейки. Этот параметр управляет построением диаграммы; он не скрывает и не отображает строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму как первую форму на первом слайде. Встроенный лист `Sheet1` имеет диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничные | C: Оптовые (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к ячейкам‑источникам через [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) и читайте [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) для проверки их статуса скрытия. Это свойство только для чтения. В этом файле B2 видима, B3 принадлежит скрытой строке, а C2 – скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера после изменения параметра построения обновите данные диаграммы: сохраните встроенный лист с помощью [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и загрузите его заново с помощью [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). При включении всех ячеек также используйте [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) для восстановления полного диапазона, включая скрытую категорию «Февраль». Просто изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом примере.

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

            # Обновить данные диаграммы из встроенного листа.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Восстановить полный диапазон источника, включая скрытые категории.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Пример сохраняет две версии презентации: одну только с видимыми значениями Retail (10 и 20) и другую со всеми шестью значениями. Изображения ниже были получены из сохранённых презентаций после их повторного открытия; обе файлы сохраняют свой установленный параметр построения. Строка 3 и столбец C остаются скрытыми в обоих встроенных листах.

| Только видимые ячейки (`True`) | Все ячейки (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) управляет тем, как отображаются отсутствующие значения; она не включает и не исключает скрытые данные‑источники. См. [Управление отображением пустых ячеек](/slides/ru/python-net/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных листа в существующей презентации проверьте диапазоны источников, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) возвращает текущий диапазон данных как формулу, квалифицированную листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` – имя листа, `!` разделяет его от диапазона ячеек, а `$A$1:$D$5` обозначает ячейки от A1 до D5 включительно. Долларовые знаки указывают абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её листа. Если диаграмма не использует лист в качестве источника данных, будет выброшено исключение. Дополнительную информацию см. в [Справочнике API ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

В этом примере открывается презентация и проверяются формы на каждом слайде на наличие диаграмм. Выводятся имя каждой диаграммы и её диапазон источника. Если диапазон получить не удаётся, выводится диагностическое сообщение и переход к следующей диаграмме.

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

## **Чтение и запись данных диаграммы из листа**

Aspose.Slides for Python via .NET предоставляет методы [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), позволяющие читать и записывать листы данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаковым образом или иметь структуру, похожую на исходную.

В этом примере используется презентация с диаграммой как первой формой на первом слайде. Встроенный лист читается в поток, существующие серии и категории очищаются, затем тот же лист записывается обратно. Изменения остаются в памяти; презентация не сохраняется.

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

### **Проверка макета диаграммы после изменения листа**

Когда вы заменяете встроенный лист модифицированным, диаграмма сохраняет свои оригинальные коллекции серий и категорий. Это несоответствие может вызвать сбой [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) с ошибкой «index out of range». Очистите существующие серии и категории перед записью обновлённого листа обратно в диаграмму. В примере используется диаграмма, которая является первой формой на первом слайде. Комментарий отмечает, где должно происходить редактирование листа; исполняемый пример записывает оригинальный лист обратно и проверяет макет в памяти.

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

Очистка коллекций удаляет устаревшие ссылки на данные перед записью листа. Воссоздайте необходимые сопоставления серий и категорий для обновлённого листа перед использованием диаграммы.

## **Установка пользовательских числовых форматов для ячеек листа**

Используйте [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) для управления отображением числовых значений в встроенном листе диаграммы. Например, в отчёте может потребоваться отображать коэффициент конверсии в виде процента с четырьмя знаками после запятой и коэффициент с пятью знаками после запятой. Оставляйте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграмм.

Числовой формат изменяет только отображение, а не хранённое значение. Формат `0.0000%` выводит `0.125` как `12.5000%`; он не заменяет хранимое число на `12.5`. Аналогично, `0.00000` выводит `0.1234567` как `0.12346`, не округляя хранимое значение. Если пользовательский формат – пустая строка (`""`), используется [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/).

В следующем примере создаётся столбчатая диаграмма и доступ к её ячейкам осуществляется через [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 – коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает метки значений, связанные с форматами источников.

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

Форматы ячеек листа отделены от форматов, задаваемых напрямую на осях диаграммы или метках данных. В этом примере каждая метка отображает значение своей исходной ячейки, потому что включён [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/), и следует исходному числовому формату, поскольку [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) установлен в `True`. После сохранения и повторного открытия презентации метки показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует свой собственный [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`, при этом [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) равен `False`.

Чтобы форматировать метку независимо, установите её флаг ссылки на источник в `False` и задайте её [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Это не меняет формат ячейки листа. Например, независимый формат метки `0.00` выводит первое значение как `0.13`, в то время как B2 всё ещё отображает `12.5000%`. См. [Метки данных диаграммы](/slides/ru/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования меток.

Ниже изображение, полученное из сохранённой презентации после её повторного открытия:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Установить ячейку листа в качестве метки данных диаграммы**

Можно использовать текст из ячеек листа в качестве меток данных диаграммы.

В этом примере на первый слайд существующей презентации добавляется пузырьковая диаграмма с данными по умолчанию. Для первых трёх меток первой серии используются ячейки A10:A12 листа 0, включаются метки из ячеек, после чего презентация сохраняется.

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

Свойство [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) предоставляет доступ к листам в листе диаграммы. В этом примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена всех листов в консоль.

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

Значения точек серии можно также хранить непосредственно как числовые литералы. Смотрите [Установить значения серии с использованием числовых литералов](/slides/ru/python-net/chart-series/#set-series-values-using-numeric-literals) для полного примера сохранения и чтения их. Тип источника значений точек отделён от внутренней или внешней конфигурации листа диаграммы; использование числовых литералов само по себе не удаляет встроенный лист.

В этом примере создаётся 3D столбчатая диаграмма с данными по умолчанию и задаются два названия серий с различными источниками данных. Первое название использует строковый литерал; второе – ячейку C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) выбирает источник для каждого названия. Пример сохраняет презентацию с обновлёнными названиями серий.

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

## **Обнаружение неподдерживаемых форматов встроенного листа**

Aspose.Slides не поддерживает бинарный формат Excel‑листов (.xlsb), который может быть встроен в некоторые диаграммы. Можно использовать свойство [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) класса [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Пример проверяет формы на первом слайде существующей презентации, пропускает формы, не являющиеся диаграммами, и выводит диагностическое сообщение для каждой диаграммы со встроенным листом .xlsb.

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

        # Читать или изменять поддерживаемые данные рабочей книги диаграммы здесь.
```

## **Внешний лист**

Aspose.Slides поддерживает использование внешних листов в качестве источника данных для диаграмм.

### **Создание внешнего листа**

Используйте [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) для экспорта встроенного листа диаграммы в файл и привязки диаграммы к этому внешнему листу.

В этом примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её лист. Выводной поток закрывается перед назначением внешнего листа в качестве источника данных диаграммы, после чего связанная презентация сохраняется.

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


### **Назначить внешний лист**

С помощью метода [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) можно назначить внешний лист диаграмме в качестве источника данных. Этот метод также может использоваться для обновления пути к внешнему листу (если файл был перемещён).

Хотя редактировать данные в листах, хранящихся в удалённых местах или ресурсах, нельзя, такие листы всё равно могут использоваться как внешний источник данных. Если указан относительный путь к внешнему листу, он автоматически преобразуется в абсолютный путь.

В примере используется внешний лист, на листе которого `Sheet1` находятся имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает лист и использует [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) для сопоставления A1:B4 одной серии и трём категориям. Презентация сохраняется с привязанной диаграммой.

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

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) определяет, будет ли лист загружен.

* Когда `update_chart_data` равен `False`, обновляется только путь к листу. Данные диаграммы не загружаются и не обновляются из целевого листа, поэтому лист может быть недоступен.
* Когда `update_chart_data` равен `True`, данные диаграммы обновляются из целевого листа.

В следующем примере задаётся заглушка‑URL с параметром `update_chart_data`, установленным в `False`. Диаграмма сохраняет данные по умолчанию и презентация сохраняется без загрузки недоступного листа.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Получить путь к внешнему листу данных диаграммы**

Чтобы определить, к какому листу привязана диаграмма, проверьте, использует ли диаграмма внешний источник данных, и получите путь к её листу.

В примере проверяется первая форма на первом слайде презентации со связанным внешним листом. Если это диаграмма, привязанная к внешнему листу, в консоль выводится [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Затем сохраняется копия презентации.

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

### **Редактировать данные диаграммы**

Можно редактировать данные во внешних листах так же, как и во внутренних. Если внешний лист нельзя загрузить, будет выброшено исключение.

В примере используется диаграмма, являющаяся первой формой на первом слайде и привязанная к доступному внешнему листу. Значение первой точки первого ряда устанавливается в 100, после чего обновлённая презентация сохраняется. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому при необходимости сохранения оригинала используйте копию листа.

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

### **Восстановление листа из кэша диаграммы**

Если диаграмма использует внешний лист, который отсутствует или недоступен, Aspose.Slides может восстановить лист диаграммы из кэшированных данных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), настройте его [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), и установите [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) в `True` перед открытием презентации.

Следующий пример на Python восстанавливает данные листа для диаграммы, являющейся первой формой на первом слайде и ссылающейся на недоступный внешний лист. Данные получаются через [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) и [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Читать или изменять восстановленные данные рабочей книги здесь.
    else:
        print("The first shape is not a chart.")
```

Если внешний лист недоступен и восстановление отключено, Aspose.Slides выбрасывает исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, так как кэш может не содержать изменений, сделанных во внешнем листе после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, привязана ли конкретная диаграмма к внешнему или встроенному листу?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) и [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник – внешний лист, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним листам и как они сохраняются?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому перемещение листа может потребовать обновления ссылки.

**Можно ли использовать листы, расположенные на сетевых ресурсах/общих папках?**

Да, такие листы могут использоваться как внешний источник данных. Однако редактирование удалённых листов напрямую из Aspose.Slides не поддерживается – они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Редактирование данных диаграммы, привязанных к ячейкам, может также обновлять связанный локальный файл XLSX. При необходимости, чтобы оригинал оставался неизменным, используйте копию листа.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) и привязывают её.

**Могут ли несколько диаграмм ссылаться на один и тот же внешний лист?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, обновление этого файла будет отражено во всех диаграммах при следующей загрузке данных.