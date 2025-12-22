---
title: Solución funcional para el cambio de tamaño de la hoja de cálculo
type: docs
weight: 20
url: /es/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionamiento de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Soluciona el cambio de tamaño OLE de hojas de cálculo de Excel en presentaciones: dos formas de mantener los marcos de objetos consistentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---

{{% alert color="primary" %}}

Se ha observado que las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint mediante los componentes Aspose se redimensionan a una escala no identificada después de la primera activación. Este comportamiento crea una diferencia visual notable en la presentación entre los estados antes y después de la activación del objeto OLE. Hemos investigado este problema en detalle y proporcionado una solución, que se cubre en este artículo.

{{% /alert %}}

## **Antecedentes**

En el artículo [Administrar OLE](/slides/es/androidjava/manage-ole/), explicamos cómo agregar un marco OLE a una presentación de PowerPoint usando Aspose.Slides para Android vía Java. Para abordar el [problema de vista previa del objeto](/slides/es/androidjava/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de la hoja de cálculo seleccionada al marco del objeto OLE. En la presentación de salida, al hacer doble clic en el marco OLE que muestra la imagen de la hoja, se activa el libro de Excel. Los usuarios pueden realizar los cambios deseados en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento variará según el tamaño del marco OLE y del libro de Excel incrustado.

## **Causa del redimensionamiento**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para garantizar que mantenga las proporciones correctas como parte del proceso de incrustación. El redimensionamiento ocurre en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución funcional**

Existen dos soluciones posibles para evitar el efecto de redimensionamiento.

- Escalar el tamaño del marco OLE en la presentación de PowerPoint para que coincida con la altura y el ancho del número deseado de filas y columnas en el marco OLE.
- Mantener constante el tamaño del marco OLE y escalar el tamaño de las filas y columnas participantes para que quepan dentro del tamaño seleccionado del marco OLE.

### **Escalar el tamaño del marco OLE**

En este enfoque, aprenderemos cómo establecer el tamaño del marco OLE del libro de Excel incrustado para que coincida con el tamaño acumulado de las filas y columnas participantes en la hoja de cálculo de Excel.

Supongamos que tenemos una hoja de Excel plantilla y queremos agregarla a una presentación como un marco OLE. En este escenario, el tamaño del marco del objeto OLE se calculará primero en función de las alturas acumuladas de las filas y los anchos acumulados de las columnas participantes en el libro. Luego, estableceremos el tamaño del marco OLE a este valor calculado. Para evitar el mensaje rojo "EMBEDDED OLE OBJECT" del marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas en el libro y la estableceremos como la imagen del marco OLE.
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Establecer el tamaño mostrado cuando el archivo del libro se usa como objeto OLE en PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Obtener el ancho y alto de la imagen OLE en puntos.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Necesitamos usar el libro modificado.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Añadir la imagen OLE a los recursos de la presentación.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crear el marco de objeto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
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

En este enfoque, aprenderemos cómo escalar las alturas de las filas participantes y el ancho de las columnas participantes para que coincidan con un tamaño de marco OLE personalizado.

Supongamos que tenemos una hoja de Excel plantilla y queremos agregarla a una presentación como un marco OLE. En este escenario, estableceremos el tamaño del marco OLE y escalaremos el tamaño de las filas y columnas que participan en el área del marco OLE. Luego guardaremos el libro en un flujo para aplicar los cambios y lo convertiremos a una matriz de bytes para agregarlo al marco OLE. Para evitar el mensaje rojo "EMBEDDED OLE OBJECT" del marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas en el libro y la estableceremos como la imagen del marco OLE.
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Establecer el tamaño mostrado cuando el archivo del libro se usa como objeto OLE en PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Escalar el rango de celdas para que se ajuste al tamaño del marco.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Necesitamos usar el libro modificado.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Agregar la imagen OLE a los recursos de la presentación.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Crear el marco de objeto OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     La anchura esperada del rango de celdas en puntos.
 * @param height    La altura esperada del rango de celdas en puntos.
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

```java
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

{{% alert color="primary" %}} 

Existen dos enfoques para corregir el problema de redimensionamiento de la hoja de cálculo. La selección del enfoque apropiado depende de los requisitos específicos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o desde cero. Además, no hay límite al tamaño del marco del objeto OLE en esta solución.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño cuando se activa por primera vez en PowerPoint?**

Esto ocurre porque Excel intenta mantener el tamaño original de la ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción de aspecto, lo que puede provocar el redimensionamiento.

**¿Es posible evitar este problema de redimensionamiento por completo?**

Sí. Al escalar el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o al escalar el rango de celdas para que se ajuste al tamaño deseado del marco OLE, se puede evitar el redimensionamiento no deseado.

**¿Qué método de escalado debo usar, escalado del marco OLE o escalado del rango de celdas?**

Seleccione **escalado del marco OLE** si desea mantener los tamaños originales de filas y columnas de Excel. Seleccione **escalado del rango de celdas** si desea un tamaño fijo para el marco OLE en su presentación.

**¿Funcionarán estas soluciones si mi presentación está basada en una plantilla?**

Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite al tamaño del marco OLE al usar estos métodos?**

No. Puede establecer el marco del objeto OLE a cualquier tamaño siempre que ajuste la escala de forma adecuada.

**¿Hay una forma de evitar el texto de marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**

Sí. Tomando una captura del rango de celdas de Excel objetivo y estableciéndola como la imagen de marcador de posición del marco OLE, puede mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.