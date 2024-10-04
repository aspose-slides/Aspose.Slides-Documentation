---
title: Solución Funcional para el Redimensionamiento de Hojas de Cálculo
type: docs
weight: 40
url: /es/net/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Se ha observado que las Hojas de Cálculo de Excel incrustadas como OLE en una Presentación de PowerPoint a través de componentes de Aspose se redimensionan a una escala no identificada después de la primera activación. Este comportamiento crea una diferencia visual considerable en la presentación entre los estados previos y posteriores a la activación del gráfico. Hemos investigado este problema en detalle y encontrado la solución a este problema que se ha cubierto en este artículo.

{{% /alert %}} 
## **Antecedentes**
En [el artículo de Añadir Marco Ole](), hemos explicado cómo añadir un Marco Ole en la presentación de una Presentación de PowerPoint utilizando Aspose.Slides para .NET. Para acomodar el [problema de objeto modificado](/slides/es/net/object-changed-issue-when-adding-oleobjectframe/), asignamos la imagen de la hoja de cálculo del área seleccionada al Marco de OLE Object del Gráfico. En la presentación de salida, cuando hacemos doble clic en el Marco de OLE Object que muestra la Imagen de la hoja de cálculo, se activa el Gráfico de Excel. Los usuarios finales pueden realizar cualquier cambio deseado en el Libro de Trabajo de Excel real y luego regresar a la Diapositiva correspondiente haciendo clic fuera del Libro de Trabajo de Excel activado. El tamaño del Marco de OLE Object cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento será diferente para los diferentes tamaños del Marco de OLE Object y del Libro de Trabajo de Excel incrustado. 
## **Causa del Redimensionamiento**
Dado que el Libro de Trabajo de Excel tiene su propio tamaño de ventana, intenta mantener su tamaño original en la primera activación. Por otro lado, el Marco de OLE Object tendrá su propio tamaño. Según Microsoft, al activar el Libro de Trabajo de Excel, Excel y PowerPoint negocian el tamaño y aseguran que esté en las proporciones correctas como parte de la operación de incrustación. Basado en las diferencias en el tamaño de las Ventanas de Excel y el tamaño / posición del Marco de OLE Object, ocurre el redimensionamiento. 
## **Solución Funcional**
Existen dos posibles soluciones para evitar el efecto de redimensionamiento.

- Escalar el tamaño del marco Ole en PPT para que coincida con el tamaño en términos de altura/ancho del número deseado de filas/columnas en el Marco Ole
- Manteniendo el tamaño del marco Ole constante y escalando el tamaño de las filas/columnas participantes para que se ajusten al tamaño del marco Ole seleccionado
## **Escalar el tamaño del marco Ole al tamaño de filas/columnas seleccionadas de la Hoja de Cálculo**
En este enfoque, aprenderemos cómo establecer el tamaño del marco Ole del Libro de Trabajo de Excel incrustado equivalente al tamaño acumulativo del número de filas y columnas participantes en la Hoja de Cálculo de Excel. 
## **Ejemplo**
Supongamos que hemos definido una hoja de Excel plantilla y deseamos agregarla a la presentación como marco Ole. En este escenario, el tamaño del Marco de OLE Object se calculará primero basado en la altura acumulativa de las filas y el ancho de las columnas de las filas y columnas del libro de trabajo que participan respectivamente. Luego estableceremos el tamaño del marco Ole a ese valor calculado. Para evitar el mensaje rojo de **Objeto Incrustado** para el marco Ole en PowerPoint, también obtendremos la imagen de las porciones deseadas de filas y columnas en el Libro de Trabajo y estableceremos eso como la imagen del marco Ole. 

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
private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol,Int32 endCol, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //Estableciendo nueva altura y ancho de fila

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

    //Estableciendo el índice de la hoja activa del libro de trabajo
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Obteniendo el Libro de Trabajo y la hoja de cálculo seleccionada  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //Estableciendo tamaño Ole de acuerdo a las filas y columnas seleccionadas
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //Establecer tamaño Ole en el Libro de Trabajo
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Estableciendo opciones de imagen para tomar la imagen de la hoja de cálculo
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Agregando imagen a la colección de imágenes de la diapositiva
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Guardando el libro de trabajo en un stream y copiando en un array de bytes
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Agregando Marco de Objeto Ole
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //Estableciendo el nombre de la imagen y la propiedad de Texto Alternativo del marco ole    
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

## **Escalar la altura de filas y el ancho de columnas de la hoja de cálculo de acuerdo al tamaño del marco Ole**
En este enfoque, aprenderemos cómo escalar las alturas de las filas participantes y el ancho de las columnas participantes de acuerdo con el tamaño del marco ole establecido por el usuario.
## **Ejemplo**
Supongamos que hemos definido una hoja de Excel plantilla y deseamos agregarla a la presentación como marco Ole. En este escenario, estableceremos el tamaño del marco Ole y escalaremos el tamaño de las filas y columnas que participan en el área del marco Ole. Luego guardaremos el libro de trabajo en un stream para guardar los cambios y convertir eso en un array de bytes para agregarlo en el marco Ole. Para evitar el mensaje rojo de **Objeto Incrustado** para el marco Ole en PowerPoint, también obtendremos la imagen de las porciones deseadas de filas y columnas en el Libro de Trabajo y estableceremos eso como la imagen del marco Ole. 

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
    ///Estableciendo nueva altura y ancho de fila

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

    //Estableciendo el índice de la hoja activa del libro de trabajo
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Obteniendo el Libro de Trabajo y la hoja de cálculo seleccionada  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //Estableciendo tamaño Ole de acuerdo a las filas y columnas seleccionadas
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //Establecer tamaño Ole en el Libro de Trabajo
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //Estableciendo opciones de imagen para tomar la imagen de la hoja de cálculo
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //Agregando imagen a la colección de imágenes de la diapositiva
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //Guardando el libro de trabajo en un stream y copiando en un array de bytes
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Agregando Marco de Objeto Ole
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //Estableciendo el nombre de la imagen y la propiedad de Texto Alternativo del marco ole    
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

## **Conclusión**


{{% alert color="primary" %}}  Hay dos enfoques para solucionar el problema de redimensionamiento de la hoja de cálculo. La selección del enfoque apropiado depende de los requisitos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sean las presentaciones creadas a partir de una plantilla o creadas desde cero. Además, no hay un límite en el tamaño del Marco de OLE Object en la solución. {{% /alert %}} 
## **Secciones Relacionadas**
[Creando e Incrustando un Gráfico de Excel como Objeto OLE en una Presentación](/slides/es/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Actualizando Objetos OLE automáticamente](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)