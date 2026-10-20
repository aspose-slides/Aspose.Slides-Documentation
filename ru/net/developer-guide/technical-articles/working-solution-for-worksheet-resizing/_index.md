---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 40
url: /ru/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предварительного просмотра
- изменение размера изображения
- Excel
- лист
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Исправьте изменение размера OLE листа Excel в презентациях: два способа сохранить согласованность рамок объектов — масштабировать рамку или лист — для форматов PPT и PPTX."
---
{{% alert color="info" title="Примечание" %}}

Встроенные в презентацию PowerPoint листы Excel в виде OLE‑объектов с использованием компонентов Aspose могут неожиданно менять размер после первой активации. Такое поведение создаёт заметную визуальную разницу между OLE‑объектом до и после активации. В этой статье описывается проблема и два способа её решения.

{{% /alert %}} 

## **Фон**

В статье [Управление OLE](/slides/ru/net/manage-ole/) мы объяснили, как добавить OLE‑рамку в презентацию PowerPoint с использованием Aspose.Slides для .NET. Чтобы решить [проблема предварительного просмотра объекта](/slides/ru/net/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑рамке. В полученной презентации, когда вы дважды щёлкните по OLE‑рамке, отображающей изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые изменения в реальную книгу Excel, а затем вернуться к слайду, щёлкнув за пределами активированной книги Excel. Размер OLE‑рамки изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑рамки и встроенной рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel есть собственный размер окна, при первой активации она пытается сохранить свой исходный размер. С другой стороны, OLE‑объект имеет собственный размер. По данным Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы обеспечить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размером и положением OLE‑рамки.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать OLE‑рамку в презентации PowerPoint так, чтобы она соответствовала общей высоте и ширине выбранных строк и столбцов.
- Оставить размер OLE‑рамки постоянным и масштабировать выбранные строки и столбцы, чтобы они помещались внутри неё.

### **Масштабировать размер OLE‑рамки**

Этот подход задаёт размер OLE‑рамки, соответствующий общей высоте и ширине выбранных строк и столбцов во встроенном листе Excel.

В примере загружается существующая рабочая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием нулевых индексов. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) определяет отображаемый диапазон. Предпросмотр отрисовывается с разрешением 96 DPI, а его пиксельные размеры преобразуются в пункты, используя 72 пункта на дюйм. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) внедряет изменённую книгу в рамку с этими размерами. Предпросмотр назначается через [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) для замены заполнителя «EMBEDDED OLE OBJECT» в сохранённой презентации.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Установить отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Получить ширину и высоту OLE‑изображения в пунктах.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Нам необходимо использовать изменённую рабочую книгу.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Добавить OLE‑изображение в ресурсы презентации.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Создать рамку OLE‑объекта.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Помощник предварительного просмотра задаёт [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) выбранному диапазону и удаляет поля, колонтитулы и нижние колонтитулы. При включённом [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) создаёт изображение диапазона в формате PNG. Помощник откатывает поток изображения перед возвратом для использования в презентации.

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **Масштабировать размер диапазона ячеек**

Этот подход масштабирует высоту выбранных строк и ширину выбранных столбцов, чтобы они соответствовали пользовательскому размеру OLE‑рамки.

В примере загружается существующая рабочая книга Excel и выбираются первые 10 строк и 13 столбцов первого листа с использованием нулевых индексов. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) определяет отображаемый диапазон, а нижеприведённый помощник масштабирует этот диапазон до рамки шириной 400 пунктов и высотой 100 пунктов. После сохранения изменённой книги в поток, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) внедряет её с указанными размерами. Предпросмотр, отрисованный с разрешением 96 DPI, назначается через [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), поэтому сохранённая презентация отображает выбранные ячейки вместо стандартного заполнителя.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Установить отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру рамки.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Нам необходимо использовать изменённую рабочую книгу.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Добавить OLE‑изображение в ресурсы презентации.
var oleImage = presentation.Images.AddImage(imageStream);

// Создать рамку OLE‑объекта.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Помощник масштабирования вычисляет отдельные коэффициенты ширины и высоты для выбранного диапазона, сохраняющие относительные ширины его столбцов и относительные высоты его строк. Он преобразует вычисленные размеры из пунктов в дуймы перед применением их с помощью [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) и [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). Выбранный диапазон должен иметь ненулевую ширину и высоту.

```cs
/// <param name="width">Ожидаемая ширина диапазона ячеек в пунктах.</param>
/// <param name="height">Ожидаемая высота диапазона ячеек в пунктах.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Этот помощник предварительного просмотра отрисовывает изменённый диапазон с использованием [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Он ограничивает [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) этим диапазоном, удаляет поля, колонтитулы и нижние колонтитулы и возвращает поток PNG, установленный в начало.

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Заключение**

{{% alert color="info" title="Примечание" %}}

Существует два подхода к исправлению проблемы изменения размера листа. Выберите подход, который лучше всего соответствует вашим требованиям и сценариям использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или «с нуля». Кроме того, в данном решении нет ограничений по размеру OLE‑рамки.

{{% /alert %}}

## **FAQ**

**Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?**

Это происходит because Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑рамка в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызвать изменение размера.

**Можно ли полностью предотвратить эту проблему с изменением размера?**

Да. Масштабируя OLE‑рамку под размер диапазона ячеек Excel или масштабируя диапазон ячеек под требуемый размер OLE‑рамки, можно полностью избавиться от нежелательного изменения размера.

**Какой метод масштабирования следует использовать: масштабирование OLE‑рамки или масштабирование диапазона ячеек?**

Выбирайте **масштабирование OLE‑рамки**, если хотите сохранить исходные размеры строк и столбцов Excel. Выбирайте **масштабирование диапазона ячеек**, если вам нужен фиксированный размер OLE‑рамки в презентации.

**Будут ли эти решения работать, если моя презентация основана на шаблоне?**

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для создаваемых с нуля.

**Существует ли ограничение размера OLE‑рамки при использовании этих методов?**

Нет. Вы можете задать любой размер OLE‑объекта, если корректно зададите масштаб.

**Можно ли избавиться от текста заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**

Да. Сделав снимок целевого диапазона Excel и установив его в качестве изображения‑заполнителя OLE‑рамки, вы можете отображать пользовательское изображение вместо стандартного заполнителя.

## **Связанные статьи**

[Создание диаграммы Excel и внедрение её в презентацию как OLE‑объект](/slides/ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)