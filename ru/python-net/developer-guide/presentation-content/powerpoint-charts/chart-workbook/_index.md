---
title: Управление рабочими книгами диаграмм в презентациях с помощью Python
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/python-net/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- подпись данных
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
description: "Откройте для себя Aspose.Slides for Python via .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, чтобы оптимизировать данные вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграмм через потоки книги, использовать ячейки книги в качестве подписей данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними книгами в качестве источников данных для диаграмм. В примерах демонстрируется, как создать и назначить внешнюю книгу, получить путь к внешней книге, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

Для ячеек книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/python-net/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) для управления тем, использует ли диаграмма данные из скрытых строк и столбцов листа. Установите `True`, чтобы строить только видимые ячейки, или `False`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не делает видимыми строки или столбцы листа.

Скачайте [hidden-source-data.pptx](hidden-source-data.pptx) и поместите его в рабочий каталог. На первом слайде находится столбчатая диаграмма как первая фигура. Встроенный лист, `Sheet1`, содержит диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) и читайте [ChartDataCell.is_hidden](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdatacell/is_hidden/) для проверки их скрытого статуса. Это свойство только для чтения. В этом файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную книгу с помощью [read_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и загрузите её обратно с помощью [write_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). При включении всех ячеек также используйте [set_range](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_range/) для восстановления полного диапазона, включая скрытую категорию «Февраль». Простое изменение флага недостаточно для обновления кешированных данных диаграммы и меток категорий в этом образце.

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
                # Восстановить полный диапазон источника, включая скрытые категории.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Пример сохраняет `hidden_cells_True.pptx` только с видимыми значениями розницы (10 и 20), и `hidden_cells_False.pptx` со всеми шести значениями. Изображения ниже были созданы из сохранённых презентаций после их повторного открытия; оба файла сохраняют свою установленную настройку построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных книгах.

| Только видимые ячейки (`True`) | Все ячейки (`False`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и оптовой цены для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.display_blanks_as](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/display_blanks_as/) управляет тем, как отображаются отсутствующие значения; она не включает и не исключает скрытые исходные данные. См. [Control the Display of Empty Cells](/slides/ru/python-net/chart-series/#control-the-display-of-empty-cells) для примера.

## **Чтение и запись данных диаграммы из книги**

Aspose.Slides for Python via .NET предоставляет методы [read_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [write_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), позволяющие читать и записывать книги данных диаграммы (содержащие данные, отредактированные в Aspose.Cells). **Note** что данные диаграммы должны быть организованы таким же образом или иметь структуру, похожую на исходную.

Этот пример открывает `chart.pptx`, который должен содержать диаграмму как первую фигуру на первом слайде. Он считывает встроенную книгу в поток, очищает существующие серии и категории и записывает ту же книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка компоновки диаграммы после изменения книги**

Когда вы заменяете встроенную книгу модифицированной, диаграмма сохраняет оригинальные коллекции серий и категорий. Это несоответствие может привести к ошибке [Chart.validate_chart_layout](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/validate_chart_layout/) с индексом вне диапазона. Очистите существующие серии и категории перед записью обновлённой книги обратно в диаграмму. Этот пример требует `chart.pptx` с диаграммой как первой фигурой на первом слайде. Комментарий помечает место, где могла бы происходить правка книги; исполняемый пример записывает оригинальную книгу обратно и проверяет компоновку в памяти.

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

Очистка коллекций удаляет устаревшие ссылки на данные перед записью книги. Перед использованием диаграммы перестройте необходимые отображения серий и категорий для обновлённой книги.

## **Установить ячейку книги в качестве подписи данных диаграммы**

Можно использовать текст из ячеек книги в качестве подписей данных диаграммы. Ниже приведены шаги, показывающие, как связать подписи в пузырьковой диаграмме с ячейками её книги данных.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получить первый слайд по нулевому индексу.
3. Добавить пузырьковую диаграмму с данными по умолчанию.
4. Получить серии диаграммы.
5. Установить ячейку книги в качестве подписи данных.
6. Сохранить презентацию.

Этот пример открывает `chart2.pptx`, который должен содержать как минимум один слайд, и добавляет пузырьковую диаграмму с данными по умолчанию. Он использует ячейки A10:A12 на листе 0 для первых трёх подписей первой серии, включает подписи из ячеек и сохраняет результат в `resultchart.pptx`.

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

Свойство [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) предоставляет доступ к листам в книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имена всех листов в консоль.

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

## **Указать тип источника данных**

Этот пример создаёт 3D‑столбчатую диаграмму с данными по умолчанию и задаёт два имени серий, используя разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/datasourcetype/) выбирает источник для каждого имени. Результат сохраняется в `pres.pptx`.

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

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает бинарный формат Excel‑книги (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство [embedded_workbook_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) на объекте [ChartData](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/workbooktype/) для выявления неподдерживаемых форматов и пропуска соответствующих диаграмм. Этот пример проверяет фигуры на первом слайде `sample.pptx`, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с встроенной книгой .xlsb.

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

        # Прочитайте или измените поддерживаемые данные рабочей книги диаграммы здесь.
```

## **Внешняя книга**

Aspose.Slides поддерживает использование внешних книг в качестве источника данных для диаграмм.

### **Создать внешнюю книгу**

Используйте [read_workbook_stream](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) и [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) для экспорта встроенной книги диаграммы в файл и привязки диаграммы к этой внешней книге.

Этот пример создаёт круговую диаграмму с данными по умолчанию, записывает её книгу в `externalWorkbook1.xlsx` и закрывает выходной поток перед назначением файла в качестве источника данных диаграммы. Затем он сохраняет связанную презентацию в `externalWorkbook.pptx`.

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

### **Установить внешнюю книгу**

С помощью метода [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) можно назначить внешнюю книгу диаграмме в качестве источника её данных. Этот метод также может использоваться для обновления пути к внешней книге (если она была перемещена).

Хотя редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, нельзя, их всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней книге, он автоматически преобразуется в полный путь.

Для примера требуется `externalWorkbook.xlsx` в рабочем каталоге. Лист с именем `Sheet1` должен содержать имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает книгу и использует [set_range](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_range/) для сопоставления диапазона A1:B4 с одной серией и тремя категориями. Результат сохраняется в `Presentation_with_externalWorkbook.pptx`.

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

Параметр `update_chart_data` метода [set_external_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/set_external_workbook/) контролирует, будет ли загружена книга.

* Когда `update_chart_data` равен `False`, обновляется только путь к книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* Когда `update_chart_data` равен `True`, данные диаграммы обновляются из целевой книги.

В следующем примере задаётся заполнитель URL с `update_chart_data`, установленным в `False`. Диаграмма сохраняет свои данные по умолчанию и сохраняет презентацию без загрузки недоступной книги.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Получить путь к книге внешнего источника данных диаграммы**

Чтобы определить, к какой книге привязана диаграмма, сначала проверьте, использует ли диаграмма внешний источник данных. Если да, можно получить путь к книге, выполнив следующие шаги.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
2. Получить первый слайд по нулевому индексу.
3. Убедиться, что первая фигура — диаграмма.
4. Прочитать тип источника данных диаграммы.
5. Если источник — внешняя книга, прочитать её путь.

Этот пример открывает `externalWorkbook.pptx`, созданный в предыдущем примере, и проверяет первую фигуру на первом слайде. Если это диаграмма, связанная с внешней книгой, пример выводит [external_workbook_path](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/) в консоль. Затем он сохраняет копию презентации в `Result.pptx`.

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

Можно редактировать данные во внешних книгах так же, как меняете содержимое внутренних книг. Если внешняя книга не может быть загружена, генерируется исключение.

Этот пример требует `presentation.pptx` с диаграммой как первой фигурой на первом слайде и доступной внешней книгой. Он задаёт значение первой точки первой серии, полученное из ячейки, равным 100 и сохраняет презентацию в `presentation_out.pptx`. Редактирование значений ячеек может обновлять связанную внешнюю XLSX‑книгу, поэтому используйте копию, если нужно сохранить оригинальную книгу.

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

### **Восстановить книгу из кеша диаграммы**

Если диаграмма использует внешнюю книгу, которой нет или она недоступна, Aspose.Slides может восстановить книгу диаграммы из данных, закешированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/), настройте её [spreadsheet_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/spreadsheet_options/), и установите [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ru/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) в `True` перед открытием презентации.

Следующий пример на Python открывает `presentation.pptx`, где первая фигура первого слайда должна быть диаграммой, ссылающейся на недоступную внешнюю книгу, и получает восстановленные данные через [Chart.chart_data](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/chart_data/) и [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Прочитайте или измените восстановленные данные рабочей книги здесь.
    else:
        print("The first shape is not a chart.")
```

Если внешняя книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кешированных данных диаграммы является приемлемым вариантом, так как кеш может не содержать изменений, внесённых в внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, привязана ли конкретная диаграмма к внешней или встроенной книге?**

Да. Диаграмма имеет [data source type](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/data_source_type/) и [path to an external workbook](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/); если источник — внешняя книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить ссылку.

**Можно ли использовать книги, находящиеся на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако редактирование удалённых книг напрямую из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [link to the external file](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Редактирование данных диаграммы, привязанных к ячейкам, также может обновлять связанный локальный XLSX‑файл. Используйте копию книги, если оригинал должен оставаться без изменений.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязывании. Обычно защищённость снимают заранее или подготавливают расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) и привязывают к ней.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при последующей загрузке данных.