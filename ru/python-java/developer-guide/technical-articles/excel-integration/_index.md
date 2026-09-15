---
title: Интеграция данных Excel в презентации PowerPoint
linktitle: Интеграция Excel
type: docs
weight: 330
url: /ru/python-java/excel-integration/
keywords:
- Excel
- рабочая книга
- чтение Excel
- интеграция Excel
- источник данных
- слияние писем
- импорт таблицы
- Excel в PowerPoint
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Чтение данных из книг Excel в Aspose.Slides для Python через Java с использованием API ExcelDataWorkbook. Загрузка листов и ячеек и использование их значений для создания презентаций PowerPoint, управляемых данными."
---
## **Введение**

Презентации PowerPoint — мощный способ отображать и передавать информацию. Их часто используют вместе с книгами Excel, где Excel служит отличным источником структурированных данных, а PowerPoint превосходно визуализирует эти данные для аудитории.

Существует множество практических сценариев, где сочетание Excel и PowerPoint необходимо: слияние писем, заполнение таблиц данными, генерация одного слайда на запись данных (пакетное создание слайдов), создание учебных материалов и консолидация нескольких отчетов Excel в одну презентацию, и многое другое.

До недавнего времени реализация таких функций с помощью API Aspose.Slides требовала использования сторонних решений, таких как Aspose.Cells. Хотя эти инструменты надежны, они могут быть излишне сложными и дорогими для пользователей, которым нужна только базовая интеграция данных.

## **Как это работает**

Чтобы упростить работу с данными Excel и сделать её более удобной, Aspose.Slides представил новые классы для чтения данных из книг Excel и импорта содержимого в презентацию. Эта функция открывает мощные новые возможности для пользователей API, желающих использовать Excel в качестве источника данных в своих рабочих процессах презентаций.

Новая функциональность предназначена для общего доступа к данным и не интегрирована в объектную модель документа презентации (DOM). Это значит, *она не позволяет редактировать или сохранять файлы Excel* — её единственная цель — открывать книги и перемещаться по их содержимому для получения значений ячеек.

В основе этой функции лежит новый класс [ExcelDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/exceldataworkbook/). Этот класс позволяет загрузить книгу Excel из локального файла или потока. После загрузки он предоставляет несколько перегрузок метода [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/exceldataworkbook/#getCell), с помощью которых можно получать конкретные ячейки по их позиции (например, по индексам строки и столбца или по именованным диапазонам).

Каждый вызов [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/exceldataworkbook/#getCell) возвращает объект [ExcelDataCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/exceldatacell/). Этот объект представляет одну ячейку в книге Excel и предоставляет доступ к её значению простым и понятным способом.

#### **Импорт диаграммы Excel**

Следующим шагом расширения функциональности является класс [ExcelWorkbookImporter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/excelworkbookimporter/). Этот вспомогательный класс предоставляет возможности импорта содержимого из книги Excel в презентацию. Он содержит несколько перегрузок метода [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), которые помогают извлечь выбранную диаграмму из указанной книги Excel и добавить её в конец указанной коллекции фигур по заданным координатам.

#### **Импорт таблицы Excel**

Класс [ExcelWorkbookImporter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/excelworkbookimporter/) также содержит несколько перегрузок метода [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Эти методы позволяют импортировать указанный диапазон ячеек с указанного листа и добавить его в виде таблицы в конец указанной коллекции фигур по заданным координатам.

Короче говоря, это лёгкий и прост в использовании API для чтения данных Excel — именно то, что требуется многим разработчикам без нагрузки полной библиотеки обработки электронных таблиц.

## **Давайте закодируем**

### **Пример сценария слияния писем**

В следующем примере мы реализуем простой сценарий слияния писем, генерируя несколько презентаций на основе данных, хранящихся в книге Excel.

Для начала нам нужны две вещи:

1. Книга Excel, содержащая данные  

   ![Пример данных Excel](example1_image0.png)

2. Шаблон презентации PowerPoint  

   ![Пример шаблона PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Загрузите книгу Excel с данными сотрудников.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Загрузите шаблон презентации.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Переберите строки Excel (исключая заголовок в строке 0).
    for row_index in range(1, 5):

        # Создайте презентацию для каждой записи сотрудника.
        employee_presentation = Presentation()

        try:
            # Удалите стандартный пустой слайд.
            employee_presentation.getSlides().removeAt(0)

            # Клонируйте шаблонный слайд в презентацию.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Получите абзацы из целевой формы (предполагается, что используется индекс формы 1).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Замените заполнители данными из Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Сохраните персонализированную презентацию в отдельный файл.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Результат](example1_image2.png)

### **Пример таблицы Excel**

Во втором примере мы просто копируем данные из таблицы Excel и отображаем их на слайде PowerPoint в более визуально привлекательном виде.

В этом примере мы повторно используем ту же книгу Excel из первого примера, в которой находится простая таблица сотрудников.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Загрузите книгу Excel, содержащую данные сотрудников.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Создайте презентацию PowerPoint.
presentation = Presentation()

try:
    # Добавьте форму таблицы на первый слайд.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Заполните таблицу PowerPoint данными из книги Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Сохраните полученную презентацию в файл.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Результат](example2_image0.png)

### **Пример импорта диаграммы Excel**

В этом примере мы импортируем диаграмму с первого листа книги Excel, использованной в предыдущем примере. Диаграмма будет ссылаться на внешний файл книги в полученной презентации.

Сначала мы добавляем круговую диаграмму в книгу Excel на основе таблицы сотрудников.

![Пример диаграммы Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Создайте презентацию PowerPoint.
presentation = Presentation()
try:
    # Получите коллекцию фигур первого слайда.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Импортируйте диаграмму с именем "Chart 1" с первого листа книги и добавьте её в коллекцию фигур.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Сохраните полученную презентацию в файл.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Результат](example3_image1.png)

### **Пример импорта всех диаграмм Excel**

Представьте, что у вас есть книга Excel, заполненная диаграммами, и вам нужно импортировать их все в презентацию. Каждая диаграмма должна быть размещена на новом слайде.

Следующий код перебирает все листы исходного файла Excel, извлекает диаграммы с каждого листа и добавляет каждую диаграмму на отдельный слайд, используя пустой макет слайда. В полученной презентации будут встроены только данные диаграмм, а не вся книга.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Загрузите книгу Excel, содержащую данные сотрудников.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Создайте презентацию PowerPoint.
presentation = Presentation()
try:
    # Получите макет пустого слайда.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Удалите стандартный слайд, чтобы результат содержал один слайд на каждую диаграмму.
    presentation.getSlides().removeAt(0)

    # Получите имена всех листов, содержащихся в книге Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Получите карту, сопоставляющую индексы диаграмм с их именами для листа.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Добавьте слайд, используя пустой макет.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Импортируйте указанную диаграмму из книги Excel в коллекцию фигур слайда.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Сохраните полученную презентацию в файл.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Пример импорта таблицы Excel**

В этом примере мы импортируем отформатированную таблицу с листа Excel непосредственно в презентацию PowerPoint.

Исходный лист Excel содержит отформатированную таблицу с данными сотрудников:

![Пример таблицы Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Создайте презентацию PowerPoint.
presentation = Presentation()
try:
    # Получите первый слайд и его коллекцию фигур.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Импортируйте таблицу с первого листа книги и добавьте её в коллекцию фигур.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Сохраните полученную презентацию в файл.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Результат](example4_image1.png)

## **Итоги**

Этот механизм, доступный непосредственно в Aspose.Slides, объединяет работу с данными Excel и презентациями в одном месте. Он позволяет создавать слайды с визуальными диаграммами и данными, представленными в виде таблиц Excel, — без дополнительных библиотек или сложных интеграций.