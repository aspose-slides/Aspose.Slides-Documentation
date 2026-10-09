---
title: "Управление книгами диаграмм в презентациях с помощью Python через Java"
linktitle: "Книга диаграммы"
type: docs
weight: 70
url: /ru/python-java/chart-workbook/
keywords:
- "книга диаграммы"
- "данные диаграммы"
- "ячейка книги"
- "метка данных"
- "лист"
- "источник данных"
- "внешняя книга"
- "внешние данные"
- "кеш диаграммы"
- "восстановление книги"
- "PowerPoint"
- "презентация"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Откройте для себя Aspose.Slides for Python via Java: легко управлять книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграммы через потоки книги, использовать ячейки книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю книгу, получить путь к внешней книге, связанной с диаграммой, и редактировать данные диаграммы, когда книга доступна.

Для ячеек книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/python-java/chart-series/) — различия между пустой ячейкой и нулём, а также сравнение режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), чтобы управлять тем, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `True`, чтобы отображать только видимые ячейки, или `False`, чтобы включить как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не отображает строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму в виде первой фигуры на первом слайде. Встроенный лист `Sheet1` имеет диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничные | C: Оптовые (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте исходные ячейки через [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) и читайте [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden), чтобы проверить их скрытый статус. Этот метод сообщает статус скрытия без изменения его. В данном файле B2 видим, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраняйте встроенную книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) и загрузите её вновь с помощью [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), чтобы восстановить полный диапазон, включая скрытую категорию «Февраль». Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом примере.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Обновить данные диаграммы из встроенной книги.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Восстановить полный исходный диапазон, включая скрытые категории.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Пример сохраняет две версии презентации: одну только с видимыми значениями розничных продаж (10 и 20), и другую со всеми шестью значениями. Ниже показаны изображения двух режимов построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных книгах.

| Только видимые ячейки (`True`) | Все ячейки (`False`) |
| --- | --- |
| ![Только видимые ячейки: значения розничных продаж 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розничных и оптовых продаж для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) контролирует, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/python-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — название листа, `!` разделяет его от диапазона ячеек, а `$A$1:$D$5` указывает ячейки от A1 до D5 включительно. Знаки доллара обозначают абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её книги. Если диаграмма не использует книгу как источник данных, он бросает `InvalidOperationException`. Подробнее см. в [справочнике API ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Этот пример открывает презентацию и проверяет фигуры непосредственно на каждом слайде на наличие диаграмм. Он выводит имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует книгу, выводится сообщение и проверка продолжается со следующей диаграммой.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Чтение и запись данных диаграммы из книги**

Aspose.Slides for Python via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) и [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream), позволяющие читать и записывать книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы аналогично исходному формату или иметь схожую структуру.

В этом примере используется презентация с диаграммой в виде первой фигуры на первом слайде. Встроенная книга считывается в массив байтов, очищаются существующие серии и категории, после чего та же книга записывается обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Проверка макета диаграммы после изменения книги**

При замене встроенной книги модифицированной диаграмма сохраняет свои оригинальные коллекции серий и категорий. Такое несоответствие может привести к ошибке [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) с сообщением об индексе вне диапазона. Очистите существующие серии и категории перед записью обновлённой книги обратно в диаграмму. Этот пример использует диаграмму, являющуюся первой фигурой на первом слайде. Комментарий помечает место, где могла бы происходить правка книги; исполняемый пример записывает оригинальную книгу обратно и проверяет макет в памяти.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Измените байты книги здесь, например, с помощью Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Очистка коллекций удаляет устаревшие ссылки данных перед записью книги. Восстановите необходимые отображения серий и категорий для обновлённой книги перед использованием диаграммы.

## **Установить ячейку книги в качестве метки данных диаграммы**

Можно использовать текст из ячеек книги в качестве меток данных диаграммы.

В этом примере добавляется пузырьковая диаграмма с данными по умолчанию на первый слайд существующей презентации. Используются ячейки A10:A12 листа 0 для первых трёх меток первой серии, включаются метки из ячеек, и сохраняется обновлённая презентация.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Управление листами**

Метод [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) предоставляет доступ к листам в книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имя каждого листа в консоль.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Указание типа источника данных**

Этот пример создаёт 3‑D столбчатую диаграмму с данными по умолчанию и задаёт два имени серии, используя разные источники данных. Первое имя задаётся литералом строки; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Обнаружение неподдерживаемых форматов встроенных книг**

Aspose.Slides не поддерживает формат двоичной книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) на объекте [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм. Этот пример проверяет фигуры на первом слайде существующей презентации, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с вложенной книгой .xlsb.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Читайте или изменяйте поддерживаемые данные книги диаграммы здесь.
finally:
    presentation.dispose()
```

## **Внешняя книга**

Aspose.Slides поддерживает использование внешних книг в качестве источника данных для диаграмм.

### **Создать внешнюю книгу**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) и [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), чтобы экспортировать встроенную книгу диаграммы в файл и привязать диаграмму к этой внешней книге.

Этот пример создаёт круговую диаграмму с данными по умолчанию и экспортирует её книгу. После завершения записи файла назначается внешняя книга как источник данных диаграммы, затем сохраняется презентация со ссылкой.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Назначить внешнюю книгу**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) можно назначить внешнюю книгу диаграмме в качестве источника данных. Этот метод также позволяет обновить путь к внешней книге (если она была перемещена).

Редактировать данные в книгах, хранящихся в удалённых местах или ресурсах, нельзя, но такие книги можно использовать как внешний источник данных. Если указать относительный путь к внешней книге, он автоматически преобразуется в абсолютный.

В примере используется внешняя книга, лист которой `Sheet1` содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает книгу и использует [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) для сопоставления A1:B4 с одной серией и тремя категориями. Презентация сохраняется с привязанной диаграммой.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) управляет тем, будет ли книга загружена.

* Когда `updateChartData` равно `False`, обновляется только путь к книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* Когда `updateChartData` равно `True`, данные диаграммы обновляются из целевой книги.

В следующем примере задаётся URL‑заполнитель с `updateChartData`, установленным в `False`. Сохраняется презентация без загрузки недоступной книги, а круговая диаграмма остаётся с данными по умолчанию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Получить путь к внешней книге‑источнику данных диаграммы**

Чтобы определить, к какой книге привязана диаграмма, проверьте, использует ли диаграмма внешний источник данных, и получите путь к её книге.

Пример проверяет первую фигуру на первом слайде презентации со связанной внешней книгой. Если это диаграмма, связанная с внешней книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) в консоль, после чего сохраняет копию презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Редактировать данные диаграммы**

Можно редактировать данные во внешних книгах так же, как и во внутренних. Если внешняя книга не может быть загружена, будет выброшено исключение.

Пример использует диаграмму, являющуюся первой фигурой на первом слайде и привязанную к доступной внешней книге. Он задаёт значение первого точки данных первой серии равным 100 и сохраняет обновлённую презентацию. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если нужно сохранить оригинальную книгу.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Восстановить книгу из кэша диаграммы**

Если диаграмма использует внешнюю книгу, которой нет или она недоступна, Aspose.Slides может восстановить книгу диаграммы из кэшированных данных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) и установите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) в `True` перед открытием презентации.

Следующий пример на Python восстанавливает данные книги для диаграммы, являющейся первой фигурой на первом слайде и ссылающейся на недоступную внешнюю книгу. Доступ к восстановленным данным осуществляется через [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) и [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Читайте или изменяйте восстановленные данные книги здесь.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Если внешняя книга недоступна и восстановление отключено, Aspose.Slides бросает исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемым вариантом, так как кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) и [путь к внешней книге](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); если источник — внешняя книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация хранит абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить ссылку.

**Можно ли использовать книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут быть использованы в качестве внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно только использовать как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Редактирование данных диаграммы, основанных на ячейках, может также обновить связанный локальный файл XLSX. Используйте копию книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при установке ссылки. Обычный подход — снять защиту заранее или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) и привязать её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла будет отражено во всех диаграммах при следующей загрузке данных.