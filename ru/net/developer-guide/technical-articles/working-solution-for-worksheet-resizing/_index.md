---
title: Рабочее решение проблемы изменения размера листа
type: docs
weight: 40
url: /ru/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- изображение предпросмотра
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
{{% alert color="info" %}} 

Было замечено, что листы Excel, встроенные как OLE‑объекты в презентацию PowerPoint через компоненты Aspose, изменяют размер до неопределённого масштаба после первой активации. Это поведение создаёт заметную визуальную разницу в презентации между состояниями OLE‑объекта до и после активации. Мы подробно исследовали эту проблему и предоставили решение, которое описано в этой статье.

{{% /alert %}} 

## **Предыстория**

В статье [Manage OLE](/slides/ru/net/manage-ole/) мы объяснили, как добавить OLE‑рамку в презентацию PowerPoint с помощью Aspose.Slides for .NET. Чтобы решить проблему [object preview issue](/slides/ru/net/object-preview-issue-when-adding-oleobjectframe/), мы присвоили изображение выбранной области листа OLE‑объекту. В результирующей презентации, когда вы дважды щелкните OLE‑рамку, отображающую изображение листа, активируется рабочая книга Excel. Пользователи могут внести любые изменения в реальную рабочую книгу Excel, а затем вернуться к слайду, щелкнув за пределами активированной рабочей книги. Размер OLE‑рамки изменится, когда пользователь вернётся к слайду. Коэффициент изменения размера будет зависеть от размеров OLE‑рамки и встроенной рабочей книги Excel. 

## **Причина изменения размера**

Поскольку у рабочей книги Excel есть собственный размер окна, при первой активации она пытается сохранить свой исходный размер. С другой стороны, OLE‑рамка имеет свой размер. По словам Microsoft, когда рабочая книга Excel активируется, Excel и PowerPoint согласуют размер, чтобы обеспечить правильные пропорции в процессе встраивания. Изменение размера происходит из‑за различий между размером окна Excel и размером и положением OLE‑рамки. 

## **Рабочее решение**

Существует два возможных решения, позволяющих избежать эффекта изменения размера.

- Масштабировать размер OLE‑рамки в презентации PowerPoint так, чтобы он соответствовал высоте и ширине желаемого количества строк и столбцов в OLE‑рамке.  
- Сохранить постоянный размер OLE‑рамки и масштабировать размеры участвующих строк и столбцов, чтобы они помещались в выбранный размер OLE‑рамки.  

### **Масштабирование размера OLE‑рамки**

В этом подходе мы узнаем, как задать размер OLE‑рамки встроенной рабочей книги Excel, чтобы он соответствовал суммарному размеру участвующих строк и столбцов листа Excel.

Предположим, у нас есть шаблон листа Excel, который необходимо добавить в презентацию в виде OLE‑рамки. В этом случае размер OLE‑объекта сначала рассчитывается на основе суммарных высоты строк и ширины столбцов участвующих в рабочей книге. Затем мы устанавливаем размер OLE‑рамки в полученное значение. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑рамки в PowerPoint, мы также сделаем снимок нужных частей строк и столбцов в рабочей книге и зададим его как изображение OLE‑рамки.

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

// Установите отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Получите ширину и высоту OLE‑изображения в пунктах.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Нужна использовать модифицированную рабочую книгу.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Добавьте OLE‑изображение в ресурсы презентации.
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

### **Масштабирование размера диапазона ячеек**

В этом подходе мы узнаем, как масштабировать высоту участвующих строк и ширину участвующих столбцов, чтобы они соответствовали пользовательскому размеру OLE‑рамки.

Предположим, у нас есть шаблон листа Excel, который необходимо добавить в презентацию в виде OLE‑рамки. В этом случае мы задаём размер OLE‑рамки и масштабируем размеры строк и столбцов, участвующих в области OLE‑рамки. Затем сохраняем рабочую книгу в поток, чтобы применить изменения, и преобразуем её в массив байтов для добавления в OLE‑рамку. Чтобы избежать красного сообщения «EMBEDDED OLE OBJECT» для OLE‑рамки в PowerPoint, мы также сделаем снимок нужных частей строк и столбцов в рабочей книге и зададим его как изображение OLE‑рамки.

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

// Установите отображаемый размер, когда файл рабочей книги используется как OLE‑объект в PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Масштабируйте диапазон ячеек, чтобы он соответствовал размеру рамки.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Нужно использовать изменённую рабочую книгу.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Добавьте OLE‑изображение в ресурсы презентации.
var oleImage = presentation.Images.AddImage(imageStream);

// Создайте OLE‑объектную рамку.
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

{{% alert color="info" %}}

Существует два подхода к устранению проблемы изменения размера листа. Выбор подходящего метода зависит от конкретных требований и сценария использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в этом решении нет ограничения на размер OLE‑рамки.

{{% /alert %}}

## **FAQ**

### Почему встроенный лист Excel меняет размер при первой активации в PowerPoint?

Это происходит потому, что Excel пытается сохранить исходный размер окна при активации, тогда как OLE‑рамка в PowerPoint имеет свои собственные размеры. PowerPoint и Excel согласуют размер, чтобы сохранить соотношение сторон, что может привести к изменению размера.

### Можно ли полностью предотвратить эту проблему изменения размера?

Да. Масштабируя OLE‑рамку до размера диапазона ячеек Excel либо масштабируя диапазон ячеек до желаемого размера OLE‑рамки, можно предотвратить нежелательное изменение размера.

### Какой метод масштабирования следует использовать: масштабирование OLE‑рамки или диапазона ячеек?

Выберите **масштабирование OLE‑рамки**, если хотите сохранить оригинальные размеры строк и столбцов Excel. Выберите **масштабирование диапазона ячеек**, если вам нужен фиксированный размер OLE‑рамки в презентации.

### Будут ли эти решения работать, если моя презентация основана на шаблоне?

Да. Оба решения работают как для презентаций, созданных из шаблонов, так и для созданных с нуля.

### Есть ли ограничение на размер OLE‑рамки при использовании этих методов?

Нет. Вы можете задать любой размер OLE‑объекта, если корректно зададите масштаб.

### Есть ли способ избавиться от текста‑заполнителя «EMBEDDED OLE OBJECT» в PowerPoint?

Да. Сделав снимок целевого диапазона ячеек Excel и установив его в качестве изображения‑заполнителя OLE‑рамки, можно отобразить пользовательское превью вместо стандартного заполнителя.

## **Связанные статьи**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)