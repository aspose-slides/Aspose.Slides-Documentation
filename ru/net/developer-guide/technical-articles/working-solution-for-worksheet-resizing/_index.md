---
title: Рабочее решение для изменения размера листов
type: docs
weight: 40
url: /ru/net/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Было замечено, что листы Excel, встроенные как OLE в презентацию PowerPoint с помощью компонентов Aspose, изменяются до неопределенной шкалы после первого активации. Это поведение создает значительную визуальную разницу в презентации между состояниями до и после активации диаграммы. Мы подробно исследовали эту проблему и нашли решение, которое описано в данной статье. 

{{% /alert %}} 
## **Предыстория**
В статье [Добавление OLE рамок]() мы объяснили, как добавить OLE рамку в презентацию PowerPoint с использованием Aspose.Slides для .NET. Чтобы учесть [проблему с изменением объекта](/slides/ru/net/object-changed-issue-when-adding-oleobjectframe/), мы присвоили изображение листа выбранной области OLE объектной рамке диаграммы. В выходной презентации, когда мы дважды щелкаем OLE объектную рамку, показывающую изображение листа, активируется диаграмма Excel. Конечные пользователи могут внести любые желаемые изменения в фактическую книгу Excel, а затем вернуться к соответствующему слайду, щелкнув за пределами активной книги Excel. Размер OLE объектной рамки изменится, когда пользователь вернется к слайду. Коэффициент изменения размера будет различным для различных размеров OLE объектной рамки и встроенной книги Excel. 
## **Причина изменения размера**
Поскольку книга Excel имеет собственный размер окна, она пытается сохранить свой исходный размер при первой активации. С другой стороны, OLE объектная рамка будет иметь свой собственный размер. Согласно данным Microsoft, при активации книги Excel, Excel и PowerPoint согласовывают размер и гарантируют, что он имеет правильные пропорции в рамках операции встраивания. В зависимости от различий между размером окна Excel и размером / положением OLE объектной рамки происходит изменение размера. 
## **Рабочее решение**
Существует два возможных решения, чтобы избежать эффекта изменения размера.

- Изменить размер OLE рамки в PPT так, чтобы он соответствовал размеру в терминах высоты/ширины необходимого количества строк/столбцов в OLE рамке.
- Сохранить постоянный размер OLE рамки и изменить размер участвующих строк/столбцов, чтобы они вписывались в выбранный размер OLE рамки.
## **Изменение размера OLE рамки в соответствии с размерами выбранных строк/столбцов листа**
В этом подходе мы научимся устанавливать размер OLE рамки встроенной книги Excel, эквивалентный суммарному размеру количества участвующих строк и столбцов на листе Excel. 
## **Пример**
Предположим, мы определили шаблонную excel таблицу и хотим добавить ее в презентацию как OLE рамку. В этом случае размер OLE объектной рамки будет вычислен в первую очередь на основе суммарной высоты строк и ширины столбцов участвующих строк и столбцов книги. Затем мы установим размер OLE рамки на это вычисленное значение. Чтобы избежать красного сообщения **Встроенный объект** для OLE рамки в PowerPoint, мы также получим изображение желаемых частей строк и столбцов в книге и установим его в качестве изображения OLE рамки. 

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //Установка новой высоты строк и ширины столбцов

    return new Size((int)(Math.Round(actualWidth, 2) * 576), (int)(Math.Round(actualHeight, 2) * 576));
}
```
```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //Установка активного индекса листа книги
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Получение книги и выбранного листа  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //Установка размера OLE в соответствии с выбранными строками и столбцами
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //Установка размера OLE в книге
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Установка параметров изображения для получения изображения листа
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Добавление изображения в коллекцию изображений слайда
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Сохранение книги в поток и копирование в массив байтов
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Добавление OLE объектной рамки
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //Установка имени изображения OLE рамки и альтернативного текстового свойства    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```

## **Изменение высоты строк и ширины столбцов листа в соответствии с размером OLE рамки**
В этом подходе мы научимся изменять высоты участвующих строк и ширину участвующего столбца в соответствии с заданным размером OLE рамки.
## **Пример**
Предположим, мы определили шаблонную excel таблицу и хотим добавить ее в презентацию как OLE рамку. В этом случае мы установим размер OLE рамки и изменим размеры строк и столбцов, участвующих в области OLE рамки. Затем мы сохраним книгу в потоке, чтобы сохранить изменения и преобразовать ее в массив байтов для добавления в OLE рамку. Чтобы избежать красного сообщения **Встроенный объект** для OLE рамки в PowerPoint, мы также получим изображение желаемых частей строк и столбцов в книге и установим его в качестве изображения OLE рамки. 

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static void SetOleAccordingToCustomHeighWidth(Workbook workbook, Int32 startRow,
    Int32 endRow, Int32 startCol, Int32 endCol, double slideWidth, double slideHeight, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;
    double newWidth = slideWidth;
    double tem = 0;
    double newTem = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    ///Установка новой высоты строк и ширины столбцов

    for (int i = startRow; i <= endRow; i++)
    {
        tem = work.Cells.GetRowHeightInch(i);
        newTem = (tem / actualHeight) * newHeight;
        work.Cells.SetRowHeightInch(i, newTem);
    }

    for (int i = startCol; i <= endCol; i++)
    {
        tem = work.Cells.GetColumnWidthInch(i);
        newTem = (tem / actualWidth) * newWidth;
        work.Cells.SetColumnWidthInch(i, newTem);

    }
}

```

```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //Установка активного индекса листа книги
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Получение книги и выбранного листа  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //Установка размера OLE в соответствии с выбранными строками и столбцами
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //Установка размера OLE в книге
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Установка параметров изображения для получения изображения листа
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Добавление изображения в коллекцию изображений слайда
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Сохранение книги в поток и копирование в массив байтов
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Добавление OLE объектной рамки
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //Установка имени изображения OLE рамки и альтернативного текстового свойства    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```

## **Заключение**

{{% alert color="primary" %}} Существуют два подхода для исправления проблемы изменения размера листа. Выбор подходящего подхода зависит от требований и конкретного случая. Оба подхода работают одинаково, независимо от того, создается ли презентация из шаблона или с нуля. Кроме того, в решении нет ограничений по размеру OLE объектной рамки. {{% /alert %}} 
## **Связанные разделы**
[Создание и встраивание диаграммы Excel как объекта OLE в презентацию](/slides/ru/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Автоматическое обновление OLE объектов](/slides/ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)