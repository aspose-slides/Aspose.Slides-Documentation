---
title: Интеграция данных Excel в презентации PowerPoint
linktitle: Интеграция Excel
type: docs
weight: 330
url: /ru/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- рабочая книга
- чтение Excel
- интеграция Excel
- источник данных
- слияние почты
- импорт таблицы
- Excel в PowerPoint
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Чтение данных из рабочих книг Excel в Aspose.Slides с использованием API ExcelDataWorkbook. Загрузка листов и ячеек и использование значений для создания презентаций PowerPoint, управляемых данными."
---
## **Введение**

Презентации PowerPoint — мощный способ отображать и передавать информацию. Их часто используют вместе с книгами Excel, где Excel служит отличным источником структурированных данных, а PowerPoint превосходно визуализирует эти данные для аудитории.

Существует множество практических сценариев, где сочетание Excel и PowerPoint необходимо: слияние писем (mail merge), заполнение таблиц данными, генерация одного слайда на запись данных (пакетная генерация слайдов), создание обучающих материалов и объединение нескольких отчетов Excel в одну презентацию, и многое другое.

До настоящего времени реализация подобных функций с помощью API Aspose.Slides требовала использования сторонних решений, таких как Aspose.Cells. Хотя эти инструменты мощные, они могут быть излишне сложными и дорогими для пользователей, которым необходима лишь базовая функциональность интеграции данных.

## **Как это работает**

Чтобы упростить работу с данными Excel и сделать её более эффективной, Aspose.Slides представил новые классы для чтения данных из книг Excel и импорта содержимого в презентацию. Эта функция открывает новые мощные возможности для пользователей API, желающих использовать Excel в качестве источника данных в своих рабочих процессах создания презентаций.

Новая функциональность предназначена для общего доступа к данным и не интегрирована в объектную модель документа презентации (DOM). Это означает, что *она не позволяет редактировать или сохранять файлы Excel* — её единственная цель — открывать книги и перемещаться по их содержимому для получения данных ячеек.

В основе этой функции находится новый класс [ExcelDataWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.excel/exceldataworkbook/). Этот класс позволяет загружать книгу Excel из локального файла или потока. После загрузки он предоставляет несколько перегруженных вариантов метода [GetCell](https://reference.aspose.com/slides/ru/net/aspose.slides.excel/exceldataworkbook/getcell/), которые можно использовать для получения конкретных ячеек по их позиции (например, по индексам строки и столбца или именованным диапазонам).

Каждый вызов [GetCell](https://reference.aspose.com/slides/ru/net/aspose.slides.excel/exceldataworkbook/getcell/) возвращает экземпляр класса [ExcelDataCell](https://reference.aspose.com/slides/ru/net/aspose.slides.excel/exceldatacell/). Этот объект представляет одну ячейку в книге Excel и предоставляет доступ к её значению простым и интуитивным способом.

#### **Импорт диаграммы Excel**

Следующим шагом для расширения функциональности является класс [ExcelWorkbookImporter](https://reference.aspose.com/slides/ru/net/aspose.slides.import/excelworkbookimporter/). Этот вспомогательный класс предоставляет возможности импорта содержимого из книги Excel в презентацию. Он содержит несколько перегруженных вариантов метода [AddChartFromWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), который помогает получить выбранную диаграмму из указанной книги Excel и добавить её в конец заданной коллекции фигур по указанным координатам.

#### **Импорт таблицы Excel**

Класс [ExcelWorkbookImporter](https://reference.aspose.com/slides/ru/net/aspose.slides.import/excelworkbookimporter/) также содержит несколько перегруженных вариантов метода [AddTableFromWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Эти методы позволяют импортировать указанный диапазон ячеек из заданного листа и добавить его в виде таблицы в конец заданной коллекции фигур по указанным координатам.

Короче говоря, это облегчённый и простой API для чтения данных Excel — именно то, что нужно многим разработчикам без нагрузки полноценной библиотеки обработки электронных таблиц.

## **Давайте писать код**

### **Пример сценария слияния (Mail Merge)**

В следующем примере мы реализуем простой сценарий Mail Merge, генерируя несколько презентаций на основе данных, хранящихся в книге Excel.

Для начала нам понадобится два элемента:
1. Книга Excel, содержащая данные

![Excel data example](example1_image0.png)

2. Шаблон презентации PowerPoint

![PowerPoint template example](example1_image1.png)

```csharp
// Загрузить книгу Excel с данными сотрудников.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Загрузить шаблон презентации.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Пройти по строкам Excel (исключая заголовок в строке 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Создать новую презентацию для каждой записи сотрудника.
    using Presentation employeePresentation = new Presentation();

    // Удалить стандартный пустой слайд.
    employeePresentation.Slides.RemoveAt(0);

    // Склонировать шаблонный слайд в новую презентацию.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Получить абзацы из целевой фигуры (предполагается, что используется индекс фигуры 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Заменить заполнители данными из Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Сохранить персонализированную презентацию в отдельный файл.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Result](example1_image2.png)

### **Пример таблицы Excel**

Во втором примере мы просто копируем данные из таблицы Excel и отображаем их на слайде PowerPoint в более визуально привлекательном формате.

В этом примере мы повторно используем ту же книгу Excel из первого примера, которая содержит простую таблицу сотрудников.

```csharp
// Загрузить книгу Excel, содержащую данные сотрудников.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Создать новую презентацию PowerPoint.
using Presentation presentation = new Presentation();

// Добавить форму таблицы на первый слайд.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Заполнить таблицу PowerPoint данными из книги Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Сохранить полученную презентацию в файл.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Result](example2_image0.png)

### **Пример импорта диаграммы Excel**

В этом примере мы импортируем диаграмму из первого листа книги Excel, использованной в предыдущем примере. Диаграмма будет связана с внешней книгой в полученной презентации.

Сначала мы добавляем круговую диаграмму в книгу Excel на основе таблицы сотрудников.

![Excel Chart example](example3_image0.png)

```csharp
// Создать новую презентацию PowerPoint.
using Presentation presentation = new Presentation();

// Получить коллекцию фигур первого слайда.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Импортировать диаграмму с именем "Chart 1" из первого листа книги и добавить её в коллекцию фигур.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Сохранить полученную презентацию в файл.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **Пример импорта всех диаграмм Excel**

Представьте, что у вас есть книга Excel, полная диаграмм, и вам нужно импортировать их все в презентацию. Каждая диаграмма должна быть размещена на новом слайде.

Следующий код проходит по всем листам исходного файла Excel, извлекает диаграммы с каждого листа и добавляет каждую диаграмму на отдельный слайд, используя макет пустого слайда. В полученной презентации будет встроены только данные диаграмм, а не вся книга.

```csharp
// Загрузить книгу Excel, содержащую данные сотрудников.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Создать новую презентацию PowerPoint.
using Presentation presentation = new Presentation();

// Получить макет пустого слайда.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Получить имена всех листов, содержащихся в книге Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Получить словарь, который сопоставляет индексы диаграмм с их именами для листа.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Добавить новый слайд, используя пустой макет.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Импортировать указанную диаграмму из книги Excel в коллекцию фигур слайда.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Сохранить полученную презентацию в файл.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Пример импорта таблицы Excel**

В этом примере мы импортируем отформатированную таблицу с листа Excel непосредственно в презентацию PowerPoint.

Исходный лист Excel содержит отформатированную таблицу с данными о сотрудниках:

![Excel Table example](example4_image0.png)

```csharp
// Создать новую презентацию PowerPoint.
using Presentation presentation = new Presentation();

// Получить коллекцию фигур первого слайда.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Импортировать таблицу из первого листа книги и добавить её в коллекцию фигур.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Сохранить полученную презентацию в файл.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Result](example4_image1.png)

## **Резюме**

Этот механизм, доступный непосредственно в Aspose.Slides, объединяет работу с данными Excel и презентациями в одном месте. Он позволяет создавать слайды с визуальными диаграммами и данными, представленными в виде таблиц Excel, без каких‑либо дополнительных библиотек или сложных интеграций.