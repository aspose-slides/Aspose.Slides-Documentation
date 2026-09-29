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
- Java
- Aspose.Slides
description: "Откройте для себя Aspose.Slides for Python via Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, чтобы упростить данные вашей презентации."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве подписей данных диаграмм, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Она также охватывает работу с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Управление отображением пустых ячеек](/slides/ru/python-java/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение линейной диаграммы доступных режимов отображения.

## **Включение данных из скрытых строк и столбцов**

Используйте [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), чтобы контролировать, будет ли диаграмма отображать данные из скрытых строк и столбцов листа. Установите `True`, чтобы отображать только видимые ячейки, или `False`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не показывает строки или столбцы листа.

Скачайте [hidden-source-data.pptx](hidden-source-data.pptx) и разместите его в рабочем каталоге. Его первый слайд содержит столбчатую диаграмму как первую фигуру. Встроенный лист, `Sheet1`, содержит диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Получайте доступ к исходным ячейкам через [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getChartDataWorkbook) и проверяйте [ChartDataCell.isHidden](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#isHidden), чтобы определить их статус скрытия. Этот метод сообщает о статусе скрытия без изменения его. В этом файле B2 видима, B3 принадлежит скрытой строке, а C2 — скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [readWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#readWorkbookStream) и загрузите её заново с помощью [writeWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#writeWorkbookStream). При включении всех ячеек также используйте [setRange](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setRange), чтобы восстановить полный диапазон, включая скрытую категорию February. Простое изменение флага недостаточно для обновления кешированных данных диаграммы и меток категорий в этом образце.

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

            # Обновите данные диаграммы из встроенной рабочей книги.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Восстановите полный диапазон источника, включая скрытые категории.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Пример сохраняет `hidden_cells_True.pptx` только с видимыми розничными значениями (10 и 20) и `hidden_cells_False.pptx` со всеми шестью значениями. Ниже показаны изображения двух режимов построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`True`) | Все ячейки (`False`) |
| --- | --- |
| ![Только видимые ячейки: розничные значения 10 и 20 для January и March.](hidden_cells_True.png) | ![Все ячейки: розничные и оптовые значения для January, February и March.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#setDisplayBlanksAs) контролирует, как отображаются отсутствующие значения; она не включает и не исключает скрытые исходные данные. См. [Управление отображением пустых ячеек](/slides/ru/python-java/chart-series/#control-the-display-of-empty-cells) для примера.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for Python via Java предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#readWorkbookStream) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#writeWorkbookStream), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаковым образом или иметь схожую структуру с источником.

Этот пример открывает `chart.pptx`, который должен содержать диаграмму как первую фигуру на первом слайде. Он читает встроенную рабочую книгу в массив байтов, очищает существующие серии и категории и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет оригинальные коллекции серий и категорий. Это несоответствие может привести к ошибке [Chart.validateChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#validateChartLayout) с «index‑out‑of‑range». Очистите существующие серии и категории перед записью обновленной рабочей книги обратно в диаграмму. Этот пример требует `chart.pptx` с диаграммой как первой фигурой на первом слайде. Комментарий отмечает место, где должно происходить редактирование рабочей книги; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет макет в памяти.

```python
import jpime
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

        # Измените байты рабочей книги здесь, например, с помощью Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Очистка коллекций удаляет устаревшие ссылки на данные перед записью рабочей книги. Восстановите при необходимости необходимые сопоставления серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установка ячейки рабочей книги в качестве подписи данных диаграммы**

Вы можете использовать текст из ячеек рабочей книги в качестве подписей данных диаграммы. Ниже показаны шаги, как связать подписи в пузырчатой диаграмме с ячейками её рабочей книги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите первый слайд по его индексу, начинающемуся с нуля.
3. Добавьте пузырчатую диаграмму с данными по умолчанию.
4. Получите доступ к сериям диаграммы.
5. Установите ячейку рабочей книги в качестве подписи данных.
6. Сохраните презентацию.

Этот пример открывает `chart2.pptx`, который должен содержать как минимум один слайд, и добавляет пузырчатую диаграмму с данными по умолчанию. Он использует ячейки A10:A12 листа 0 для первых трёх подписей в первой серии, включает подписи из ячеек и сохраняет результат в `resultchart.pptx`.

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

Метод [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#getWorksheets) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит каждое имя листа в консоль.

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

## **Указание типа источника данных**

Этот пример создаёт 3D‑столбчатую диаграмму с данными по умолчанию и задаёт два имени серий, используя разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/datasourcetype/) выбирает источник для каждого имени. Результат сохраняется в `pres.pptx`.

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

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает формат бинарных рабочих книг Excel (.xlsb), которые могут быть встроены в некоторые диаграммы. Вы можете использовать метод [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) класса [ChartData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/workbooktype/), чтобы обнаружить неподдерживаемые форматы и пропустить такие диаграммы. Этот пример проверяет фигуры на первом слайде `sample.pptx`, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

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
        # Читайте или изменяйте поддерживаемые данные рабочей книги диаграммы здесь.
finally:
    presentation.dispose()
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [readWorkbookStream](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#readWorkbookStream) и [setExternalWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook), чтобы экспортировать встроенную рабочую книгу диаграммы в файл и связать диаграмму с этой внешней книгой.

Этот пример создаёт круговую диаграмму с данными по умолчанию, записывает её рабочую книгу в `externalWorkbook1.xlsx` и завершает запись файла перед назначением файла в качестве источника данных диаграммы. Он сохраняет связанную презентацию в `externalWorkbook.pptx`.

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

С помощью метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также может использоваться для обновления пути к внешней рабочей книге (если файл был перемещён).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Пример требует `externalWorkbook.xlsx` в рабочем каталоге. Его лист `Sheet1` должен содержать имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [setRange](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setRange) для сопоставления A1:B4 с одной серией и тремя категориями. Результат сохраняется в `Presentation_with_externalWorkbook.pptx`.

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

Параметр `updateChartData` метода [setExternalWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#setExternalWorkbook) контролирует, будет ли рабочая книга загружена.

* Когда `updateChartData` равен `False`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому она может быть недоступна.
* Когда `updateChartData` равен `True`, данные диаграммы обновляются из целевой рабочей книги.

Следующий пример задаёт фиктивный URL с `updateChartData`, установленным в `False`. Он сохраняет диаграмму с данными по умолчанию и сохраняет презентацию без загрузки недоступной рабочей книги.

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

### **Получение пути к рабочей книге внешнего источника данных диаграммы**

Чтобы определить, к какой рабочей книге привязана диаграмма, сначала проверьте, использует ли диаграмма внешний источник данных. Если да, вы можете получить путь к рабочей книге, выполнив следующие шаги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите первый слайд по его индексу, начинающемуся с нуля.
3. Убедитесь, что первая фигура — это диаграмма.
4. Прочитайте тип источника данных диаграммы.
5. Если источник — внешняя рабочая книга, прочитайте её путь.

Этот пример открывает `externalWorkbook.pptx`, созданный в предыдущем примере, и проверяет первую фигуру на первом слайде. Если это диаграмма, связанная с внешней рабочей книгой, пример выводит [getExternalWorkbookPath](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) в консоль. Затем он сохраняет копию презентации в `Result.pptx`.

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

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как изменяете содержимое внутренних книг. Когда внешнюю рабочую книгу загрузить невозможно, генерируется исключение.

Этот пример требует `presentation.pptx` с диаграммой как первой фигурой на первом слайде и доступной внешней рабочей книги. Он задаёт значение первого пункта первой серии, основанное на ячейке, равным 100 и сохраняет презентацию в `presentation_out.pptx`. Изменение значений ячеек может обновить связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную книгу.

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

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, кешированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/), вызовите [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) и установите [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) в `True` перед открытием презентации.

Следующий пример на Python открывает `presentation.pptx`, первая фигура на первом слайде которого должна быть диаграммой, ссылающейся на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [Chart.getChartData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/#getChartData) и [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Прочитайте или измените данные восстановленной рабочей книги здесь.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование кешированных данных диаграммы приемлемо, поскольку кеш может не содержать изменений, сделанных во внешней рабочей книге после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getDataSourceType) и [path to an external workbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); если источник — внешняя рабочая книга, вы можете считать её полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении рабочей книги может потребоваться обновить ссылку.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут выступать в роли внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут использоваться только как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Редактирование подписи, основанной на ячейке, может также обновить связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно сначала удаляют защиту или создают расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) и связывают с этой копией.

**Может ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если они указывают на один и тот же файл, изменение этого файла отразится во всех диаграммах при следующей загрузке данных.