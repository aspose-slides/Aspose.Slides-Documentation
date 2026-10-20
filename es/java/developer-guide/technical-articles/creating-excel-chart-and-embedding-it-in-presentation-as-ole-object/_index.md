---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 30
url: /es/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico de Excel
- incrustar gráfico
- objeto OLE
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Crear un gráfico de Excel con Aspose.Cells for Java e incrustar el libro de trabajo en una presentación de PowerPoint con Aspose.Slides, incluida una vista previa del gráfico."
---
## **Visión general**

Este artículo muestra cómo crear un gráfico de columnas de Excel con Aspose.Cells for Java e incrustar su libro de trabajo en una presentación de PowerPoint con Aspose.Slides for Java. El libro de trabajo incrustado contiene tanto los datos fuente como el gráfico. Una vista previa PNG separada muestra el gráfico en la diapositiva antes de que se active el objeto OLE.

El resultado es un objeto de Excel incrustado, no un gráfico nativo de PowerPoint. Editar el libro de trabajo a través de OLE requiere una aplicación de escritorio que admita la activación OLE y una instalación de Excel compatible.

## **Requisitos previos**

Añada Aspose.Cells for Java y Aspose.Slides for Java a las dependencias de su proyecto. Ejecute el ejemplo dentro de un método Java. Microsoft Office no es necesario para generar la presentación con estas bibliotecas.

No se requieren archivos de entrada: el ejemplo crea los datos y el gráfico en memoria, luego escribe `OutputChart.pptx` en el directorio de trabajo actual. Aplique licencias para ambos productos al ejecutar fuera del modo de evaluación.

## **Cómo funciona la incrustación**

1. Cree un libro de trabajo con una hoja de datos y una hoja de gráfico.  
1. Active la hoja de gráfico para que el libro de trabajo se abra en el gráfico.  
1. Establezca el rango de visualización OLE del libro de trabajo y renderice el gráfico a PNG.  
1. Guarde el libro de trabajo como XLSX en memoria e incruste esos bytes en una diapositiva.  
1. Asigne el PNG como la vista previa del objeto OLE y guarde la presentación como PPTX.

El rango de visualización del libro de trabajo y el marco en la diapositiva tienen roles diferentes. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) toma índices de fila y columna de inicio/final basados en cero. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) en su lugar toma la fila superior, la columna izquierda, la fila inferior y la columna derecha. El ejemplo utiliza el índice de fila 55 y el índice de columna 25 como los límites inferiores derechos; estos valores son decisiones de diseño, no el número de filas o columnas de datos.

El marco de la diapositiva usa puntos. El ejemplo lo ajusta dentro de la diapositiva y lo centra manteniendo la proporción del PNG, en lugar de estirar la vista previa para llenar la diapositiva.

## **Crear e incrustar el gráfico**

El siguiente ejemplo completo rellena `DataSheet` con cuatro filas y cinco columnas de valores. Cada fila se convierte en una serie del gráfico. `ChartSheet` se selecciona como la hoja activa antes de guardar el libro de trabajo.

El libro de trabajo se guarda explícitamente como XLSX, coincidiendo con la extensión `xlsx` pasada a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). El PNG se carga directamente a partir de sus bytes sin una conversión intermedia a bitmap. Asignarlo mediante [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) sustituye el marcador de posición OLE predeterminado.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Renderizar la vista previa del gráfico y serializar el libro de trabajo editable por separado.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Ajustar la vista previa dentro de la diapositiva sin cambiar su relación de aspecto.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Resultado esperado**

`OutputChart.pptx` contiene una diapositiva con un libro de trabajo de Excel incrustado y una vista previa del gráfico. El libro de trabajo contiene los datos originales y un gráfico de columnas con cuatro series. La vista previa está centrada en la diapositiva y conserva sus proporciones.

![Gráfico de columnas de Excel mostrado como vista previa de un libro de trabajo incrustado](excel-chart-ole-preview.png)

En un entorno de escritorio compatible con PowerPoint y Excel disponible, haga doble clic en el objeto para activar y editar el libro de trabajo incrustado. La activación y la edición dependen del soporte OLE y la configuración de seguridad de la aplicación host.

## **Preguntas frecuentes**

**¿Por qué se necesita una imagen de vista previa?**

El libro de trabajo incrustado y su vista previa en la diapositiva son contenidos independientes. Proporcione una imagen del gráfico para que la diapositiva muestre el gráfico en lugar del marcador de posición predeterminado "EMBEDDED OLE OBJECT". Consulte [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/java/object-preview-issue-when-adding-oleobjectframe/).

**¿Se actualiza automáticamente la vista previa cuando modifico el libro de trabajo en el código?**

Considere la vista previa como una captura instantánea. Cuando actualice los datos del libro de trabajo mediante código, regenere la imagen del gráfico y reemplace la vista previa así como los datos del libro de trabajo incrustado.

**¿Puedo usar XLS en lugar de XLSX?**

Sí. Guarde el libro de trabajo en formato XLS y use `xls` como la extensión de datos incrustada. La extensión debe coincidir con el formato real del libro de trabajo; cambiar solo la extensión no convierte los datos.

**¿Por qué podría el objeto cambiar de tamaño después de la activación?**

La aplicación host puede actualizar la presentación del objeto OLE cuando activa el libro de trabajo. Tanto el rango de visualización OLE del libro de trabajo como las dimensiones del marco de la diapositiva son importantes. Consulte [Solución funcional para el cambio de tamaño del gráfico en PPTX](/slides/es/java/working-solution-for-chart-resizing-in-pptx/).

## **Secciones relacionadas**

- [Solución funcional para el cambio de tamaño del gráfico en PPTX](/slides/es/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/java/object-preview-issue-when-adding-oleobjectframe/)
- [Actualizar objetos OLE automáticamente usando un complemento de PowerPoint](/slides/es/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)