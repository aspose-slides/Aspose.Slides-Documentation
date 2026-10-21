---
title: Управление рабочими книгами диаграмм в презентациях с помощью Python через Java
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/python-java/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кэш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Познакомьтесь с Aspose.Slides для Python via Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных для диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь внешней рабочей книги, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/python-java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режима отображения на линейной диаграмме.

## **Включить данные из скрытых строк и столбцов**

Используйте [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), чтобы управлять тем, будет ли диаграмма строить данные из скрытых строк и столбцов листа. Установите `True`, чтобы строить только видимые ячейки, или `False`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не раскрывает строки или столбцы листа.

[пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму в качестве первой фигуры на первом слайде. Встроенный лист `Sheet1` содержит следующий исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптом (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте исходные ячейки через [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) и читайте [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden), чтобы проверить их статус скрытости. Этот метод сообщает статус скрытости без изменения его. В этом файле B2 видима, B3 относится к скрытой строке, а C2 относится к скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) и загрузите её снова с помощью [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), чтобы восстановить полный диапазон, включая скрытую категорию февраля. Простое изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категорий в этом примере.

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

            # Обновить данные диаграммы из встроенной рабочей книги.
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

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20), другую со всеми шестью значениями. Ниже приведены изображения, иллюстрирующие два режима построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`True`) | Все ячейки (`False`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для января и марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и опта для января, февраля и марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/python-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Прежде чем обновлять данные рабочей книги в существующей презентации, проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` отделяет его от диапазона ячеек, а `$A$1:$D$5` обозначает ячейки от A1 до D5 включительно. Знаки доллара указывают на абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, он бросает `InvalidOperationException`. Для получения дополнительной информации см. [Ссылка на API ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Этот пример открывает презентацию и проверяет фигуры непосредственно на каждом слайде на наличие диаграмм. Он выводит имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует рабочую книгу, выводится сообщение, и обработка продолжается со следующей диаграммой.

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

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for Python via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) и [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream), позволяющие читать и записывать рабочие книги диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы аналогично или иметь схожую структуру с исходными.

Этот пример использует презентацию с диаграммой в качестве первой фигуры на первом слайде. Он читает встроенную рабочую книгу в массив байтов, очищает существующие серии и категории и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка макета диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу изменённой, диаграмма сохраняет свои оригинальные коллекции серий и категорий. Это несоответствие может вызвать ошибку [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) с индексом за пределами диапазона. Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. Пример использует диаграмму, являющуюся первой фигурой первого слайда. Комментарий указывает, где должно происходить редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет макет в памяти.

```python
import jpway
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Измените байты рабочей книги здесь, например, используя Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Перестройте любые необходимые сопоставления серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установить пользовательские числовые форматы для ячеек рабочей книги**

Используйте [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat), чтобы контролировать отображение числовых значений в встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться отображать коэффициент конверсии в виде процента с четырьмя десятичными знаками и коэффициент с пятью десятичными знаками. Оставьте оба значения числовыми, чтобы они оставались доступными для вычислений и построения диаграммы.

Числовой формат изменяет только отображение, а не сохранённое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346` без округления сохранённого значения. Если пользовательский формат — пустая строка (`""`), используется формат, возвращаемый [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat).

В следующем примере создаётся столбчатая диаграмма и получаются её ячейки через [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает подписи значений, связанные с исходными форматами.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Форматы ячеек рабочей книги отличаются от форматов, задаваемых напрямую на осях диаграммы или подписи данных. В этом примере каждая подпись отображает значение своей исходной ячейки, поскольку [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) установлен в `True`, и следует исходному числовому формату, потому что [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) установлен в `True`. После сохранения и повторного открытия презентации подписи показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный числовой формат, заданный через [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) как `0.00`, а [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) установлен в `False`.

Чтобы отформатировать подпись данных независимо, установите её флаг привязки к источнику в `False` и задайте формат через [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Это не меняет формат ячейки рабочей книги. Например, независимый формат подписи `0.00` отображает первое значение как `0.13`, тогда как B2 всё ещё отображает `12.5000%`. См. [Метки данных диаграммы](/slides/ru/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования подписи.

Ниже изображение, полученное из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с метками, связанными с источником, показывающими 12.5000% и 0.12346, и независимо отформатированной числовой осью.](custom-cell-formats.png)

## **Установить ячейку рабочей книги в качестве метки данных диаграммы**

Вы можете использовать текст из ячеек рабочей книги в качестве меток данных диаграммы.

В этом примере добавляется пузырьковая диаграмма с данными по умолчанию на первый слайд существующей презентации. Он использует ячейки A10:A12 листа 0 для первых трёх меток первой серии, включает метки из ячеек и сохраняет обновлённую презентацию.

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

Метод [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит в консоль имена каждого листа.

```python
import jpype
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

## **Указать тип источника данных**

Этот пример создаёт 3D столбчатую диаграмму с данными по умолчанию и задаёт два имени серии, используя разные источники данных. Первое имя задаётся строковым литералом; второе использует ячейку C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

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

## **Обнаружение неподдерживаемых форматов внедрённой рабочей книги**

Aspose.Slides не поддерживает формат Excel binary workbook (.xlsb), который может быть внедрён в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) объекта [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска таких диаграмм. Этот пример исследует фигуры на первом слайде существующей презентации, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с внедрённой рабочей книгой .xlsb.

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
        # Чтение или изменение поддерживаемых данных рабочей книги диаграммы здесь.
finally:
    presentation.dispose()
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) и [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), чтобы экспортировать встроенную рабочую книгу диаграммы в файл и связать диаграмму с этой внешней книгой.

Этот пример создаёт круговую диаграмму с данными по умолчанию и экспортирует её рабочую книгу. Он завершает запись файла перед назначением внешней рабочей книги в качестве источника данных диаграммы, затем сохраняет связанную презентацию.

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

### **Установка внешней рабочей книги**

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых расположениях или ресурсах, их всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

В примере используется внешняя рабочая книга, лист которой с именем `Sheet1` содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) для сопоставления A1:B4 с одной серией и тремя категориями. Затем сохраняет презентацию с связанной диаграммой.

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

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) управляет тем, будет ли загружена рабочая книга.

* Когда `updateChartData` установлен в `False`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому рабочая книга может быть недоступна.
* Когда `updateChartData` установлен в `True`, данные диаграммы обновляются из целевой рабочей книги.

В следующем примере задаётся заполнитель URL с `updateChartData`, установленным в `False`. Сохраняется круговая диаграмма с данными по умолчанию, и презентация сохраняется без загрузки недоступной рабочей книги.

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

### **Получить путь к внешней рабочей книге источника данных диаграммы**

Чтобы определить, к какой рабочей книге привязана диаграмма, проверьте, использует ли диаграмма внешний источник данных, и получите её путь к рабочей книге.

Этот пример исследует первую фигуру первого слайда презентации с привязанной внешней рабочей книгой. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [путь к внешней рабочей книге](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) в консоль. Затем сохраняет копию презентации.

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

Вы можете редактировать данные во внешних рабочих книгах так же, как вносите изменения во внутренние книги. Когда внешняя рабочая книга не может быть загружена, генерируется исключение.

Этот пример использует диаграмму, являющуюся первой фигурой первого слайда и привязанную к доступной внешней рабочей книге. Он задаёт значение первого пункта данных первой серии равным 100 и сохраняет обновлённую презентацию. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную рабочую книгу.

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

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) и установите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) в `True` перед открытием презентации.

В следующем примере на Python восстанавливаются данные рабочей книги для диаграммы, являющейся первой фигурой первого слайда и ссылающейся на недоступную внешнюю рабочую книгу. Доступ к восстановленным данным осуществляется через [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) и [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Чтение или изменение восстановленных данных рабочей книги здесь.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides выбрасывает исключение. Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой заменой, поскольку кэш может не содержать изменения, внесённые во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. Диаграмма имеет [тип источника данных](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновление ссылки.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых рабочих книг из Aspose.Slides не поддерживается — они могут использоваться только в качестве источника.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Презентация хранит [ссылку на внешний файл](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Редактирование данных диаграммы, привязанных к ячейкам, также может обновлять связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно пароль снимают заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) и связывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит собственную ссылку. Если они все указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.