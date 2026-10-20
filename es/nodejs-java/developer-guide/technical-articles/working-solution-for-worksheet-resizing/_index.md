---
title: Solución práctica para el redimensionamiento de la hoja de cálculo
type: docs
weight: 20
url: /es/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionamiento de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Soluciona el redimensionamiento OLE de hojas de cálculo de Excel en presentaciones: dos formas de mantener los marcos de objetos consistentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---
{{% alert color="info" title="Note" %}}
Las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint mediante componentes Aspose pueden cambiar de tamaño de forma inesperada después de su primera activación. Este comportamiento crea una diferencia visual notable entre el objeto OLE antes y después de la activación. Este artículo explica el problema y describe dos formas de solucionarlo.
{{% /alert %}}

## **Antecedentes**

En el artículo [Gestionar OLE](/slides/es/nodejs-java/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides para Node.js mediante Java. Para abordar el [problema de vista previa del objeto](/slides/es/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área seleccionada de la hoja al marco del objeto OLE. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen de la hoja, se activa el libro de Excel. Los usuarios pueden realizar los cambios deseados en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de cambio de tamaño variará según el tamaño del marco del objeto OLE y del libro de Excel incrustado.

## **Causa del cambio de tamaño**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para asegurarse de que mantenga las proporciones correctas como parte del proceso de incrustación. El cambio de tamaño ocurre basándose en las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución funcional**

Existen dos soluciones posibles para evitar el efecto de cambio de tamaño.

- Escalar el marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura total de las filas y columnas seleccionadas.
- Mantener el tamaño del marco OLE constante y escalar las filas y columnas seleccionadas para que quepan dentro de él.

### **Escalar el tamaño del marco OLE**

Este enfoque establece el tamaño del marco OLE para que coincida con la altura y anchura total de las filas y columnas seleccionadas en la hoja de Excel incrustada.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja usando índices basados en cero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) define el rango mostrado. La vista previa se renderiza a 96 DPI, y sus dimensiones en píxeles se convierten a puntos usando 72 puntos por pulgada. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) incrusta el libro modificado en un marco con esas dimensiones. La vista previa se asigna mediante [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) para reemplazar el marcador de posición "EMBEDDED OLE OBJECT" en la presentación guardada.

Instala los paquetes `aspose.cells`, `aspose.slides.via.java` y `java` y coloca `sample.xlsx` en el directorio de trabajo. Para cada enfoque, ejecuta primero el script de preparación y luego el script de incrustación en un proceso Node.js separado en el mismo directorio. Los dos paquetes Aspose inicializan el puente Java por separado.

Guarda este script de preparación como `prepare-frame-scaled.js` y ejecútalo con `node prepare-frame-scaled.js`. Genera `frame-scaled.xlsx` y `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Todo el trabajo síncrono está completo; detenga el proceso del puente Java.
process.exit(0);
```

Guarda este script de incrustación como `embed-frame-scaled.js` y ejecútalo con `node embed-frame-scaled.js`. Lee esos archivos y genera `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Todo el trabajo síncrono está completo; detenga el proceso del puente Java.
process.exit(0);
```

El asistente de vista previa establece [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) al rango seleccionado y elimina márgenes, encabezados y pies de página. Con [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) habilitado, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) renderiza el rango como una imagen PNG. El asistente guarda la imagen PNG en un archivo para usarla en la presentación.

### **Escalar el tamaño del rango de celdas**

Este enfoque escala las alturas de las filas seleccionadas y las anchuras de las columnas seleccionadas para que coincidan con un tamaño de marco OLE personalizado.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja usando índices basados en cero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) define el rango mostrado, y el asistente escala ese rango para que quepa en un marco de 400 puntos de ancho y 100 puntos de alto. Después de guardar el libro modificado en un archivo, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) lo incrusta con el tamaño especificado. Una vista previa renderizada a 96 DPI se asigna mediante [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de modo que la presentación guardada muestra las celdas seleccionadas en lugar del marcador de posición predeterminado.

Guarda este script de preparación como `prepare-cells-scaled.js` y ejecútalo con `node prepare-cells-scaled.js`. Genera `cells-scaled.xlsx` y `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Todo el trabajo síncrono está completo; detenga el proceso del puente Java.
process.exit(cellsPrepared ? 0 : 1);
```

Guarda este script de incrustación como `embed-cells-scaled.js` y ejecútalo con `node embed-cells-scaled.js`. Lee esos archivos y genera `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Todo el trabajo síncrono está completo; detenga el proceso del puente Java.
process.exit(0);
```

El asistente de escalado calcula ratios de ancho y alto por separado para el rango seleccionado, preservando las anchuras relativas de sus columnas y las alturas relativas de sus filas. Convierte las dimensiones calculadas de puntos a pulgadas antes de aplicarlas con [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) y [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). El rango seleccionado debe tener ancho y alto diferentes de cero.

Este asistente de vista previa renderiza el rango redimensionado usando [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) a ese rango, elimina márgenes, encabezados y pies de página, y guarda la imagen PNG en un archivo.

## **Conclusión**
{{% alert color="info" title="Note" %}}
Existen dos enfoques para solucionar el problema de cambio de tamaño de la hoja de cálculo. Elige el enfoque que mejor se adapte a tus requisitos y caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como desde cero. Además, no hay límite en el tamaño del marco del objeto OLE en esta solución.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño al activarse por primera vez en PowerPoint?**
Esto ocurre porque Excel intenta mantener el tamaño original de la ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede causar el cambio de tamaño.

**¿Es posible evitar completamente este problema de cambio de tamaño?**
Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al tamaño deseado del marco OLE, puedes evitar el cambio de tamaño no deseado.

**¿Qué método de escalado debería usar, escalado del marco OLE o escalado del rango de celdas?**
Selecciona **escalado del marco OLE** si deseas mantener los tamaños originales de filas y columnas de Excel. Selecciona **escalado del rango de celdas** si deseas un tamaño fijo para el marco OLE en tu presentación.

**¿Funcionarán estas soluciones si mi presentación se basa en una plantilla?**
Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite al tamaño del marco OLE al usar estos métodos?**
No. Puedes hacer que el marco del objeto OLE tenga cualquier tamaño siempre que establezcas la escala adecuadamente.

**¿Hay una forma de evitar el texto del marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**
Sí. Capturando una instantánea del rango de celdas de Excel objetivo y estableciéndola como la imagen de marcador de posición del marco OLE, puedes mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.

## **Artículos relacionados**

[Crear un gráfico de Excel e incrustarlo en una presentación como objeto OLE](/slides/es/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Actualizar objetos OLE automáticamente usando un complemento de MS PowerPoint](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)