---
title: Рабочее решение для изменения размера листа
type: docs
weight: 40
url: /ru/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предпросмотра
- изменение размера изображения
- Excel
- рабочий лист
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Исправьте изменение размера OLE листа Excel в презентациях: два способа поддерживать согласованность рамок объектов — масштабировать рамку или лист — в форматах PPT и PPTX."
---

{{% alert color="primary" %}} 

Было обнаружено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint через компоненты Aspose, после первого активации изменяются до неопределённого масштаба. Это приводит к заметной визуальной разнице в презентации между состоянием OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предоставили решение, которое описано в этой статье.

{{% /alert %}} 

## **Общее описание**

В статье [Управление OLE](/slides/ru/net/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for .NET. Чтобы решить проблему [предпросмотра объекта](/slides/ru/net/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑объекта. В результирующей презентации, когда вы двойным щелчком открываете OLE‑кадр с изображением листа, активируется книга Excel. Пользователи могут вносить любые изменения в реальную книгу Excel, а затем возвращаться к слайду, щёлкнув за пределами активированной книги. Размер OLE‑кадра изменится при возврате к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и встроенной книги Excel. 

## **Причина изменения размера**

Поскольку у книги Excel собственный размер окна, при первой активации она пытается сохранить исходный размер. С другой стороны, OLE‑кадр имеет свой размер. По данным Microsoft, при активации книги Excel Excel и PowerPoint согласовывают размер, чтобы сохранить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размером и позицией OLE‑кадра. 

## **Рабочее решение**

Существует два возможных подхода, позволяющих избежать эффекта изменения размера.

- Масштабировать размер OLE‑кадра в презентации PowerPoint так, чтобы он соответствовал высоте и ширине требуемого количества строк и столбцов в OLE‑кадре.
- Сохранить постоянный размер OLE‑кадра и масштабировать размеры участвующих строк и столбцов, чтобы они поместились в выбранный размер OLE‑кадра.

### **Масштабировать размер OLE‑кадра**

В этом подходе мы узнаем, как задать размер OLE‑кадра встроенной книги Excel, соответствующий совокупному размеру участвующих строк и столбцов листа Excel.

Предположим, у нас есть шаблон листа Excel, который нужно добавить в презентацию как OLE‑кадр. В этом случае размер OLE‑кадра сначала рассчитывается на основе совокупных высот строк и ширин столбцов участвующих в книге. Затем мы задаём размер OLE‑кадра этим вычисленным значением. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также захватим изображение нужных частей строк и столбцов в книге и установим его как изображение OLE‑кадра.
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

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

В этом подходе мы научимся масштабировать высоты участвующих строк и ширину участвующих столбцов так, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Предположим, у нас есть шаблон листа Excel, который нужно добавить в презентацию как OLE‑кадр. В этом случае мы задаём размер OLE‑кадра и масштабируем размеры строк и столбцов, участвующих в области OLE‑кадра. Затем сохраняем книгу в поток, чтобы применить изменения, и конвертируем её в массив байтов для добавления в OLE‑кадр. Чтобы избавиться от красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также захватим изображение нужных частей строк и столбцов в книге и установим его как изображение OLE‑кадра.
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Установите отображаемый размер, когда файл рабочей книги используется как OLE-объект в PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру кадра.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Нам нужно использовать изменённую рабочую книгу.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Добавьте OLE-изображение в ресурсы презентации.
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

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

{{% alert color="primary" %}}

Существует два подхода к исправлению проблемы изменения размера листа. Выбор подходящего зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений по размеру OLE‑кадра.

{{% /alert %}}

## FAQ

**В: Почему встроенный лист Excel меняет размер при первом активации в PowerPoint?**  
Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызвать изменение масштаба.

**В: Можно ли полностью предотвратить эту проблему изменения размера?**  
Да. Масштабируя OLE‑кадр под размер диапазона ячеек Excel или масштабируя диапазон ячеек под желаемый размер OLE‑кадра, можно избежать нежелательного изменения масштаба.

**В: Какой метод масштабирования использовать: масштабирование OLE‑кадра или диапазона ячеек?**  
Выбирайте **масштабирование OLE‑кадра**, если хотите сохранить исходные размеры строк и столбцов Excel. Выбирайте **масштабирование диапазона ячеек**, если нужен фиксированный размер OLE‑кадра в презентации.

**В: Работают ли эти решения, если моя презентация основана на шаблоне?**  
Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

**В: Есть ли ограничение по размеру OLE‑кадра при использовании этих методов?**  
Нет. Вы можете задать любой размер OLE‑объекта, если правильно установить масштаб.

**В: Как избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?**  
Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑кадра, можно заменить стандартный заполнитель на собственное изображение.

## **См. также**

[Создание диаграммы Excel и встраивание её в презентацию как OLE‑объект](/slides/ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)