---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 30
url: /es/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico de Excel
- incrustar gráfico
- objeto OLE
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Crear un gráfico de Excel con Aspose.Cells para Node.js a través de Java e incrustar el libro de trabajo en una presentación de PowerPoint con Aspose.Slides, incluyendo una vista previa del gráfico."
---
## **Visión general**

Este artículo muestra cómo crear un gráfico de columnas de Excel con Aspose.Cells para Node.js a través de Java e incrustar su libro de trabajo en una presentación de PowerPoint con Aspose.Slides para Node.js a través de Java. El libro de trabajo incrustado contiene tanto los datos de origen como el gráfico. Una vista previa PNG independiente muestra el gráfico en la diapositiva antes de que se active el objeto OLE.

El resultado es un objeto Excel incrustado, no un gráfico nativo de PowerPoint. Editar el libro de trabajo mediante OLE requiere una aplicación de escritorio que admita la activación OLE y una instalación compatible de Excel.

## **Requisitos previos**

Instale los paquetes `aspose.cells`, `aspose.slides.via.java` y `java` de Node.js. Ejecute los ejemplos como dos scripts CommonJS en procesos Node.js separados: primero `create-chart.js`, luego `embed-chart.js`, usando el mismo directorio de trabajo. Ambos paquetes Aspose inicializan el puente Java durante la carga, por lo que estos ejemplos los mantienen en procesos separados. No se necesita Microsoft Office para generar la presentación con estas bibliotecas.

No se requiere ningún libro de trabajo ni imagen existente. El primer script crea `ChartWorkbook.xlsx` y `ChartPreview.png`; el segundo lee esos archivos y escribe `OutputChart.pptx` en el directorio de trabajo actual. Aplique licencias para ambos productos al ejecutarse fuera del modo de evaluación.

## **Cómo funciona la incrustación**

1. Crear un libro de trabajo con una hoja de datos y una hoja de gráfico.  
1. Hacer que la hoja de gráfico sea la activa para que el libro de trabajo se abra en el gráfico.  
1. Establecer el rango de visualización OLE del libro de trabajo y renderizar el gráfico a PNG.  
1. Guardar el libro de trabajo como XLSX e incrustar sus bytes en una diapositiva en un proceso Node.js separado.  
1. Asignar el PNG como vista previa del objeto OLE y guardar la presentación como PPTX.

El rango de visualización del libro de trabajo y el marco en la diapositiva tienen roles diferentes. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) recibe índices de fila y columna de inicio/fin basados en cero. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) en cambio recibe la fila superior, columna izquierda, fila inferior y columna derecha. El ejemplo utiliza el índice de fila 55 y el índice de columna 25 como límites inferiores derechos; estos valores son decisiones de diseño, no el número de filas o columnas de datos.

El marco de la diapositiva usa puntos. El ejemplo lo ajusta dentro de la diapositiva y lo centra preservando la relación de aspecto del PNG, en lugar de estirar la vista previa para llenar la diapositiva.

## **Crear e incrustar el gráfico**

Guarde el primer ejemplo como `create-chart.js`. Rellena `DataSheet` con cuatro filas y cinco columnas de valores. Cada fila se convierte en una serie del gráfico. `ChartSheet` se selecciona como la hoja activa antes de guardar el libro de trabajo.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderizar la vista previa del gráfico y serializar el libro de trabajo editable por separado.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Todo el trabajo síncrono ha finalizado; detener el proceso del puente Java.
process.exit(0);
```

Guarde el siguiente ejemplo como `embed-chart.js`. Ejecútelo después de que `create-chart.js` haya creado ambos archivos de entrada. Centra el marco OLE y conserva la relación de aspecto de la imagen de vista previa.

El segundo script incrusta el libro de trabajo guardado y usa el PNG como su vista previa. El libro de trabajo se guarda explícitamente como XLSX, coincidiendo con la extensión `xlsx` pasada a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). El PNG se carga directamente desde sus bytes sin una conversión intermedia a mapa de bits. El puente Java requiere matrices de bytes Java explícitas para la imagen y los datos del libro de trabajo, y valores float Java para las coordenadas del marco de la diapositiva. Asignarlo mediante [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) reemplaza el marcador de posición OLE predeterminado.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Ajustar la vista previa dentro de la diapositiva sin cambiar su relación de aspecto.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Todo el trabajo síncrono ha finalizado; detener el proceso del puente Java.
process.exit(0);
```

## **Resultado esperado**

`OutputChart.pptx` contiene una diapositiva con un libro de trabajo Excel incrustado y una vista previa del gráfico. El libro de trabajo contiene los datos originales y un gráfico de columnas con cuatro series. La vista previa está centrada en la diapositiva y conserva sus proporciones.

![Gráfico de columnas de Excel mostrado como vista previa de un libro de trabajo incrustado](excel-chart-ole-preview.png)

En un entorno de escritorio PowerPoint compatible con Excel disponible, haga doble clic en el objeto para activar y editar el libro de trabajo incrustado. La activación y edición dependen del soporte OLE y de la configuración de seguridad de la aplicación anfitriona.

## **Preguntas frecuentes**

**¿Por qué se necesita una imagen de vista previa?**

El libro de trabajo incrustado y su vista previa en la diapositiva son contenidos separados. Proporcione una imagen del gráfico para que la diapositiva muestre el gráfico en lugar del marcador de posición predeterminado "EMBEDDED OLE OBJECT". Consulte [Object Preview Issue when Adding OleObjectFrame](/slides/es/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**¿Se actualiza automáticamente la vista previa cuando cambio el libro de trabajo en el código?**

Considere la vista previa como una instantánea. Al actualizar los datos del libro de trabajo programáticamente, regenere la imagen del gráfico y reemplace tanto la vista previa como los datos del libro de trabajo incrustado.

**¿Puedo usar XLS en lugar de XLSX?**

Sí. Guarde el libro de trabajo en formato XLS y use `xls` como la extensión de datos incrustados. La extensión debe coincidir con el formato real del libro de trabajo; cambiar solo la extensión no convierte los datos.

**¿Por qué el objeto puede cambiar de tamaño después de la activación?**

La aplicación anfitriona puede actualizar la presentación del objeto OLE cuando activa el libro de trabajo. Tanto el rango de visualización OLE del libro de trabajo como las dimensiones del marco de la diapositiva importan. Consulte [Working Solution for Chart Resizing in PPTX](/slides/es/java/working-solution-for-chart-resizing-in-pptx/).

## **Secciones relacionadas**

- [Working Solution for Chart Resizing in PPTX](/slides/es/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/es/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)