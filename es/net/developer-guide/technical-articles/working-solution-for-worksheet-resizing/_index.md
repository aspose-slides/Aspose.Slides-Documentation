---
title: Solución funcional para el redimensionado de la hoja de cálculo
type: docs
weight: 40
url: /es/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionado de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Soluciona el redimensionado OLE de la hoja de cálculo de Excel en presentaciones: dos formas de mantener los marcos de objetos consistentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---
{{% alert color="info" title="Note" %}}

Los hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint mediante componentes Aspose pueden cambiar de tamaño inesperadamente después de su primera activación. Este comportamiento crea una diferencia visual notable entre el objeto OLE antes y después de la activación. Este artículo explica el problema y describe dos formas de abordarlo.

{{% /alert %}} 

## **Contexto**

En el artículo [Manage OLE](/slides/es/net/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides for .NET. Para abordar el [object preview issue](/slides/es/net/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de la hoja de cálculo seleccionada al marco del objeto OLE. En la presentación resultante, al hacer doble clic en el marco del objeto OLE que muestra la imagen de la hoja, se activa el libro de Excel. Los usuarios pueden realizar los cambios deseados en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de cambio de tamaño variará según el tamaño del marco del objeto OLE y del libro de Excel incrustado. 

## **Causa del Cambio de Tamaño**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para garantizar que mantenga las proporciones correctas como parte del proceso de incrustación. El cambio de tamaño ocurre en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución Funcional**

Existen dos soluciones posibles para evitar el efecto de cambio de tamaño.

- Escalar el marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura totales de las filas y columnas seleccionadas.
- Mantener constante el tamaño del marco OLE y escalar las filas y columnas seleccionadas para que quepan dentro de él.

### **Escalar el Tamaño del Marco OLE**

Este enfoque establece el tamaño del marco OLE para que coincida con la altura y anchura totales de las filas y columnas seleccionadas en la hoja de cálculo de Excel incrustada.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja mediante índices basados en cero. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) define el rango mostrado. La vista previa se renderiza a 96 DPI, y sus dimensiones en píxeles se convierten a puntos usando 72 puntos por pulgada. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) incrusta el libro modificado en un marco con esas dimensiones. La vista previa se asigna mediante [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) para reemplazar el marcador de posición "EMBEDDED OLE OBJECT" en la presentación guardada.

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

// Establece el tamaño mostrado cuando el archivo del libro se usa como objeto OLE en PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Obtiene el ancho y la altura de la imagen OLE en puntos.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Necesitamos usar el libro modificado.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Añade la imagen OLE a los recursos de la presentación.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Crea el marco del objeto OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

El asistente de vista previa establece [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) al rango seleccionado y elimina márgenes, encabezados y pies de página. Con [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) habilitado, [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) renderiza el rango como una imagen PNG. El asistente rebobina el flujo de imagen antes de devolverlo para su uso en la presentación.

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

### **Escalar el Tamaño del Rango de Celdas**

Este enfoque escala las alturas de las filas seleccionadas y las anchuras de las columnas seleccionadas para que coincidan con un tamaño de marco OLE personalizado.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja mediante índices basados en cero. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) define el rango mostrado, y el asistente a continuación escala ese rango para que quepa en un marco de 400 puntos de ancho y 100 puntos de alto. Después de guardar el libro modificado en un flujo, [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) lo incrusta con el tamaño especificado. Una vista previa renderizada a 96 DPI se asigna mediante [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/), de modo que la presentación guardada muestra las celdas seleccionadas en lugar del marcador de posición predeterminado.

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

// Establece el tamaño mostrado cuando el archivo del libro se usa como objeto OLE en PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Escala el rango de celdas para que encaje en el tamaño del marco.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Necesitamos usar el libro modificado.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Añade la imagen OLE a los recursos de la presentación.
var oleImage = presentation.Images.AddImage(imageStream);

// Crea el marco del objeto OLE.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

El asistente de escalado calcula ratios de anchura y altura separados para el rango seleccionado, preservando las anchuras relativas de sus columnas y las alturas relativas de sus filas. Convierte las dimensiones calculadas de puntos a pulgadas antes de aplicarlas con [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) y [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/). El rango seleccionado debe tener anchura y altura distintas de cero.

```cs
/// <param name="width">La anchura esperada del rango de celdas en puntos.</param>
/// <param name="height">La altura esperada del rango de celdas en puntos.</param>
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

Este asistente de vista previa renderiza el rango redimensionado usando [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/). Limita [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) a ese rango, elimina márgenes, encabezados y pies de página, y devuelve un flujo PNG posicionado al inicio.

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

## **Conclusión**

{{% alert color="info" title="Note" %}}

Existen dos enfoques para corregir el problema de cambio de tamaño de la hoja de cálculo. Elija el que mejor se adapte a sus requisitos y caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como si se crean desde cero. Además, no hay límite al tamaño del marco del objeto OLE en esta solución.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño al activarse por primera vez en PowerPoint?**

Esto ocurre porque Excel intenta mantener el tamaño original de su ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el cambio de tamaño.

**¿Es posible evitar este problema de cambio de tamaño por completo?**

Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al tamaño deseado del marco OLE, puede evitar redimensiones no deseadas.

**¿Qué método de escalado debo usar, escalado del marco OLE o escalado del rango de celdas?**

Seleccione **escalado del marco OLE** si desea conservar los tamaños originales de filas y columnas de Excel. Seleccione **escalado del rango de celdas** si desea un tamaño fijo para el marco OLE en su presentación.

**¿Funcionarán estas soluciones si mi presentación se basa en una plantilla?**

Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite al tamaño del marco OLE al usar estos métodos?**

No. Puede establecer el marco del objeto OLE a cualquier tamaño siempre que ajuste la escala adecuadamente.

**¿Hay una forma de evitar el texto marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**

Sí. Capturando una instantánea del rango de celdas de Excel objetivo y estableciéndola como imagen del marcador de posición del marco OLE, puede mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.

## **Artículos relacionados**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/es/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)