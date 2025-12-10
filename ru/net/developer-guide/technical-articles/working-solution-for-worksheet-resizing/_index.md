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
description: "Исправление изменения размера OLE листа Excel в презентациях: два способа сохранить согласованность рамок объектов — масштабировать рамку или лист — в форматах PPT и PPTX."
---

{{% alert color="primary" %}} 

Было обнаружено, что листы Excel, встроенные в презентацию PowerPoint в виде OLE‑объектов с помощью компонентов Aspose, изменяют размер до неопределённого масштаба после первой активации. Такое поведение создаёт заметную визуальную разницу в презентации между состоянием OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предоставили решение, которое описано в этой статье.

{{% /alert %}} 

## **Предыстория**

В статье [Управление OLE](/slides/ru/net/manage-ole/) мы объяснили, как добавить OLE‑кадр в презентацию PowerPoint с помощью Aspose.Slides for .NET. Чтобы решить проблему [проблема предварительного просмотра объекта](/slides/ru/net/object-preview-issue-when-adding-oleobjectframe/), мы назначили изображение выбранной области листа OLE‑кадру. В выходной презентации, если дважды щёлкнуть OLE‑кадр, отображающий изображение листа, активируется рабочая книга Excel. Пользователи могут вносить любые желаемые изменения в реальную рабочую книгу Excel, а затем вернуться к слайду, щёлкнув вне активированной рабочей книги Excel. Размер OLE‑кадра изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑кадра и встроенной рабочей книги Excel.

## **Причина изменения размера**

Поскольку у рабочей книги Excel есть собственный размер окна, при первой активации она пытается сохранить свой исходный размер. С другой стороны, OLE‑кадр имеет собственный размер. Согласно Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласовывают размер, чтобы обеспечить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размером и положением OLE‑кадра.

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать размер OLE‑кадра в презентации PowerPoint, чтобы он соответствовал высоте и ширине необходимого количества строк и столбцов в OLE‑кадре.
- Оставить размер OLE‑кадра постоянным и масштабировать размер участвующих строк и столбцов, чтобы они помещались в выбранный размер OLE‑кадра.

### **Масштабировать размер OLE‑кадра**

В этом подходе мы узнаем, как задать размер OLE‑кадра встроенной рабочей книги Excel, чтобы он соответствовал суммарному размеру участвующих строк и столбцов листа Excel.

Предположим, у нас есть шаблон листа Excel, который мы хотим добавить в презентацию в виде OLE‑кадра. В этом случае размер OLE‑кадра сначала будет вычислен на основе суммарных высот строк и ширин столбцов участвующих в книге. Затем мы зададим размер OLE‑кадра этим вычисленным значением. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также сделаем снимок нужных частей строк и столбцов в книге и установим его как изображение OLE‑кадра.
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

В этом подходе мы узнаем, как масштабировать высоты участвующих строк и ширину участвующих столбцов, чтобы они соответствовали пользовательскому размеру OLE‑кадра.

Предположим, у нас есть шаблон листа Excel, который мы хотим добавить в презентацию в виде OLE‑кадра. В этом случае мы зададим размер OLE‑кадра и масштабируем размер строк и столбцов, участвующих в области OLE‑кадра. Затем мы сохраним рабочую книгу в поток, чтобы применить изменения, и преобразуем её в массив байтов для добавления в OLE‑кадр. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑кадра в PowerPoint, мы также сделаем снимок нужных частей строк и столбцов в книге и установим его как изображение OLE‑кадра.
```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Установить отображаемый размер, когда файл книги используется как OLE‑объект в PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабировать диапазон ячеек, чтобы он соответствовал размеру рамки.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Нужно использовать изменённую книгу.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Добавить OLE‑изображение в ресурсы презентации.
var oleImage = presentation.Images.AddImage(imageStream);

// Создать OLE‑объектную рамку.
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

Существует два подхода к исправлению проблемы изменения размера листа. Выбор подходящего подхода зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничений на размер OLE‑кадра.

{{% /alert %}}

## **Часто задаваемые вопросы**

**Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?**  
Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑кадр в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласовывают размер, чтобы сохранить соотношение сторон, что может вызвать изменение масштаба.

**Можно ли полностью предотвратить эту проблему изменения размера?**  
Да. Масштабировав OLE‑кадр под размер диапазона ячеек Excel или масштабировав диапазон ячеек под желаемый размер OLE‑кадра, можно избежать нежелательного изменения масштаба.

**Какой метод масштабирования выбрать: масштабирование OLE‑кадра или диапазона ячеек?**  
Выберите **масштабирование OLE‑кадра**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если вам нужен фиксированный размер OLE‑кадра в презентации.

**Работают ли эти решения, если моя презентация основана на шаблоне?**  
Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для создаваемых с нуля.

**Есть ли ограничение по размеру OLE‑кадра при использовании этих методов?**  
Нет. Вы можете задать любой размер OLE‑кадра, при условии правильной настройки масштаба.

**Можно ли избавиться от текста‑заменителя «EMBEDDED OLE OBJECT» в PowerPoint?**  
Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заменителя OLE‑кадра, можно отобразить пользовательское превью вместо стандартного текста‑заменителя.

## **Связанные статьи**

[Создание диаграммы Excel и встраивание её в презентацию как OLE‑объект](/slides/ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE‑объектов с помощью надстройки MS PowerPoint](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)