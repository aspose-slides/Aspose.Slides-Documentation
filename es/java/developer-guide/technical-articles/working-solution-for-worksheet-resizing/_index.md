---
title: Solución funcional para el cambio de tamaño de la hoja de cálculo
type: docs
weight: 20
url: /es/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionamiento de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Corrige el cambio de tamaño OLE de la hoja de cálculo de Excel en presentaciones: dos maneras de mantener los marcos de objetos consistentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---
{{% alert color="info" title="Note" %}}
Las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint usando componentes Aspose pueden cambiar de tamaño inesperadamente después de su primera activación. Este comportamiento crea una diferencia visual notable entre el objeto OLE antes y después de la activación. Este artículo explica el problema y describe dos formas de solucionarlo.
{{% /alert %}}

## **Antecedentes**

En el artículo [Administrar OLE](/slides/es/java/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides for Java. Para abordar el [problema de vista previa del objeto](/slides/es/java/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de la hoja de cálculo seleccionada al marco del objeto OLE. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen de la hoja, el libro de Excel se activa. Los usuarios finales pueden realizar los cambios deseados en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de cambio de tamaño variará según el tamaño del marco del objeto OLE y del libro de Excel incrustado.

## **Causa del cambio de tamaño**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para garantizar que mantenga las proporciones correctas como parte del proceso de incrustación. El cambio de tamaño ocurre basándose en las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución funcional**

Existen dos soluciones posibles para evitar el efecto de cambio de tamaño.

- Escalar el marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura totales de las filas y columnas seleccionadas.
- Mantener el tamaño del marco OLE constante y escalar las filas y columnas seleccionadas para que quepan dentro de él.

### **Escalar el tamaño del marco OLE**

Este enfoque establece el tamaño del marco OLE para que coincida con la altura y anchura totales de las filas y columnas seleccionadas en la hoja de Excel incrustada.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja usando índices basados en cero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) define el rango mostrado. La vista previa se renderiza a 96 DPI, y sus dimensiones en píxeles se convierten a puntos usando 72 puntos por pulgada. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) incrusta el libro modificado en un marco con esas dimensiones. La vista previa se asigna mediante [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) para reemplazar el marcador de posición "EMBEDDED OLE OBJECT" en la presentación guardada.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Establecer el tamaño mostrado cuando el archivo del libro de trabajo se usa como objeto OLE en PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Necesitamos usar el libro de trabajo modificado.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Añadir la imagen OLE a los recursos de la presentación.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crear el marco del objeto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

El asistente de vista previa establece [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) al rango seleccionado y elimina márgenes, encabezados y pies de página. Con [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) habilitado, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) renderiza el rango como una imagen PNG. El asistente devuelve un nuevo flujo de entrada que contiene la imagen PNG, posicionado al principio para su uso en la presentación.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Escalar el tamaño del rango de celdas**

Este enfoque escala las alturas de las filas seleccionadas y las anchuras de las columnas seleccionadas para que coincidan con un tamaño de marco OLE personalizado.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja usando índices basados en cero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) define el rango mostrado, y el asistente a continuación escala ese rango para que encaje en un marco de 400 puntos de ancho y 100 puntos de alto. Después de guardar el libro modificado en un flujo, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) lo incrusta con el tamaño especificado. Una vista previa renderizada a 96 DPI se asigna mediante [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), de modo que la presentación guardada muestra las celdas seleccionadas en lugar del marcador de posición predeterminado.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Establecer el tamaño mostrado cuando el archivo del libro de trabajo se usa como objeto OLE en PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Escalar el rango de celdas para que se ajuste al tamaño del marco.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Necesitamos usar el libro de trabajo modificado.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Añadir la imagen OLE a los recursos de la presentación.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crear el marco del objeto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

El asistente de escalado calcula ratios de ancho y alto separados para el rango seleccionado, conservando las anchuras relativas de sus columnas y las alturas relativas de sus filas. Convierte las dimensiones calculadas de puntos a pulgadas antes de aplicarlas con [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) y [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). El rango seleccionado debe tener ancho y alto diferentes de cero.

```java
/**
 * @param width     Ancho esperado del rango de celdas en puntos.
 * @param height    Altura esperada del rango de celdas en puntos.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

Este asistente de vista previa renderiza el rango redimensionado usando [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) a ese rango, elimina márgenes, encabezados y pies de página, y devuelve un flujo PNG posicionado al principio.

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Conclusión**

{{% alert color="info" title="Note" %}}
Existen dos enfoques para solucionar el problema de cambio de tamaño de la hoja de cálculo. Elige el enfoque que mejor se ajuste a tus requisitos y caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como desde cero. Además, no hay límite en el tamaño del marco del objeto OLE en esta solución.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño cuando se activa por primera vez en PowerPoint?**  
Esto ocurre porque Excel intenta mantener el tamaño original de la ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el cambio de tamaño.

**¿Es posible evitar completamente este problema de cambio de tamaño?**  
Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al tamaño deseado del marco OLE, puedes evitar el cambio de tamaño no deseado.

**¿Qué método de escalado debo usar, escalado del marco OLE o escalado del rango de celdas?**  
Selecciona **escalado del marco OLE** si deseas mantener los tamaños originales de filas y columnas de Excel. Selecciona **escalado del rango de celdas** si deseas un tamaño fijo para el marco OLE en tu presentación.

**¿Funcionarán estas soluciones si mi presentación se basa en una plantilla?**  
Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite al tamaño del marco OLE al usar estos métodos?**  
No. Puedes establecer el marco del objeto OLE de cualquier tamaño siempre que ajustes la escala de manera adecuada.

**¿Hay alguna forma de evitar el texto del marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**  
Sí. Capturando una instantánea del rango de celdas de Excel objetivo y estableciéndola como la imagen del marcador de posición del marco OLE, puedes mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.

## **Artículos relacionados**

[Crear un gráfico de Excel e incrustarlo en una presentación como objeto OLE](/slides/es/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Actualizar objetos OLE automáticamente usando un complemento de MS PowerPoint](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)