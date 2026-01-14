---
title: Интеграция данных Excel в презентации PowerPoint
linktitle: Интеграция Excel
type: docs
weight: 330
url: /ru/net/excel-integration/
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
description: "Чтение данных из книг Excel в Aspose.Slides с помощью API ExcelDataWorkbook. Загрузка листов и ячеек и использование их значений для создания презентаций PowerPoint, управляемых данными."
---

## **Введение**

Презентации PowerPoint — мощный способ отображать и передавать информацию. Их часто используют совместно с книгами Excel, где Excel служит отличным источником структурированных данных, а PowerPoint excels в визуализации этих данных для аудитории.

Существует множество практических сценариев, в которых сочетание Excel и PowerPoint необходимо: слияние почты, заполнение таблиц данными, генерация одного слайда на запись данных (пакетная генерация слайдов), создание учебных материалов и объединение нескольких отчетов Excel в одну презентацию, и многие другие.

До настоящего времени реализация подобных функций с помощью API Aspose.Slides требовала использования сторонних решений, таких как Aspose.Cells. Хотя эти инструменты надёжны, они могут быть избыточно сложными и дорогими для пользователей, которым нужна только базовая интеграция данных.

## **Как это работает**

Чтобы упростить работу с данными Excel и сделать её более эффективной, Aspose.Slides представил новые классы для чтения данных из книг Excel и импорта содержимого в презентацию. Эта функция открывает мощные новые возможности для пользователей API, желающих использовать Excel как источник данных в своих рабочих процессах по созданию презентаций.

Новая функциональность предназначена для общего доступа к данным и не интегрирована в объектную модель документа презентации (DOM). Это означает, что *это не позволяет редактировать или сохранять файлы Excel* — её единственная цель — открыть книги и навигировать по их содержимому для получения данных ячеек.

В основе этой функции находится новый класс [ExcelDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/). Этот класс позволяет загрузить книгу Excel из локального файла или потока. После загрузки он предоставляет несколько перегрузок метода [GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/), которые можно использовать для получения конкретных ячеек по их позиции (например, по индексам строки и столбца или по именованным диапазонам).

Каждый вызов [GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/) возвращает экземпляр класса [ExcelDataCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldatacell/). Этот объект представляет одну ячейку в книге Excel и предоставляет доступ к её значению простым и интуитивным способом.

#### **Импорт диаграммы Excel**

Следующим шагом к расширению функциональности является класс [ExcelWorkbookImporter](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/). Этот вспомогательный класс предоставляет возможность импорта содержимого из книги Excel в презентацию. Он содержит несколько перегрузок метода [AddChartFromWorkbook](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), которые помогают получить выбранную диаграмму из указанной книги Excel и добавить её в конец заданной коллекции фигур по указанным координатам.

Короче говоря, это лёгкий и понятный API для чтения данных Excel — именно то, что требуется многим разработчикам без необходимости подключать полноценную библиотеку обработки электронных таблиц.

## **Давайте кодировать**

### **Пример сценария слияния почты**

В следующем примере мы реализуем простой сценарий слияния почты, генерируя несколько презентаций на основе данных, хранящихся в книге Excel.

Для начала нам нужны две вещи:
1. Книга Excel, содержащая данные

![Excel data example](example1_image0.png)

2.  Шаблон презентации PowerPoint

![PowerPoint template example](example1_image1.png)
```csharp
// Загрузите книгу Excel с данными сотрудников.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Загрузите шаблон презентации.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Пройдитесь по строкам Excel (исключая заголовок в строке 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Создайте новую презентацию для каждой записи сотрудника.
    using Presentation employeePresentation = new Presentation();

    // Удалите стандартный пустой слайд.
    employeePresentation.Slides.RemoveAt(0);

    // Клонируйте шаблонный слайд в новую презентацию.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Получите абзацы из целевой фигуры (предполагается, что используется индекс фигуры 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Замените заполнители данными из Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Сохраните персонализированную презентацию в отдельный файл.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```


![Result](example1_image2.png)

### **Пример таблицы Excel**

Во втором примере мы просто копируем данные из таблицы Excel и отображаем их на слайде PowerPoint в более визуально привлекательном виде.

В этом примере мы повторно используем ту же книгу Excel из первого примера, которая содержит простую таблицу сотрудников.
```csharp
// Загрузите книгу Excel, содержащую данные сотрудников.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Создайте новую презентацию PowerPoint.
using Presentation presentation = new Presentation();

// Добавьте элемент таблицы на первый слайд.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Заполните таблицу PowerPoint данными из книги Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Сохраните полученную презентацию в файл.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```


![Result](example2_image0.png)

### **Пример импорта диаграммы Excel**

В этом примере мы импортируем диаграмму из первого листа книги Excel, использованной в предыдущем примере. Диаграмма будет связана с внешней книгой в полученной презентации.

Сначала мы добавляем круговую диаграмму в книгу Excel на основе таблицы сотрудников.

![Excel Chart example](example3_image0.png)
```csharp
// Создайте новую презентацию PowerPoint.
using Presentation presentation = new Presentation();

// Получите коллекцию фигур первого слайда.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Импортируйте диаграмму с именем "Chart 1" из первого листа книги и добавьте её в коллекцию фигур.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Сохраните полученную презентацию в файл.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```

![Result](example3_image1.png)

### **Пример импорта всех диаграмм Excel**

Представьте, что у вас есть книга Excel, наполненная диаграммами, и вам нужно импортировать их все в презентацию. Каждая диаграмма должна быть размещена на отдельном слайде.

Следующий код перебирает все листы исходного файла Excel, извлекает диаграммы с каждого листа и добавляет каждую диаграмму на отдельный слайд, используя пустой макет слайда. В полученной презентации будут встраиваться только данные диаграмм, а не вся книга.
```csharp
// Загрузите книгу Excel, содержащую данные сотрудников.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Создайте новую презентацию PowerPoint.
using Presentation presentation = new Presentation();

// Получите макет пустого слайда.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Получите имена всех листов, содержащихся в книге Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();
foreach (var name in worksheetNames)
{
    // Получите словарь, сопоставляющий индексы диаграмм с их именами для листа.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Добавьте новый слайд, используя макет пустого слайда.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Импортируйте указанную диаграмму из книги Excel в коллекцию фигур слайда.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Сохраните полученную презентацию в файл.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```


## **Итоги**

Этот механизм, доступный напрямую в Aspose.Slides, объединяет работу с данными Excel и презентациями в одном месте. Он позволяет создавать слайды с визуальными диаграммами и данными, представленными в виде таблиц Excel, без дополнительных библиотек или сложных интеграций.