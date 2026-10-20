---
title: Solución práctica para el cambio de tamaño de gráficos en PPTX
type: docs
weight: 40
url: /es/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- cambio de tamaño de gráfico
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Corrige el cambio de tamaño inesperado de los gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para Android vía Java. Establece dimensiones fijas del gráfico para mantener consistentes el tamaño del gráfico y del marco OLE."
---
## **Visión general**

Los gráficos de Excel incrustados como objetos OLE en presentaciones de PowerPoint mediante componentes Aspose pueden cambiar de tamaño después de su primera activación. Esto puede causar una diferencia notable en la apariencia del gráfico antes y después de la activación. Este artículo explica por qué se produce el cambio de tamaño y muestra cómo evitarlo haciendo coincidir las dimensiones fijas del gráfico con el marco OLE.

En [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells for Android vía Java e incrustarlo en una presentación de PowerPoint usando Aspose.Slides for Android vía Java. Para abordar el [problema de vista previa del objeto](/slides/es/androidjava/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden editar el libro de Excel incrustado y luego volver a la diapositiva haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de cambio de tamaño varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

## **Causa del cambio de tamaño**

El libro de Excel incrustado tiene sus propias dimensiones de ventana, que Excel intenta conservar cuando el objeto se activa por primera vez. El marco OLE en la diapositiva tiene dimensiones definidas de forma independiente. Cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño del objeto para mantener sus proporciones como parte del proceso de incrustación. Las diferencias entre la ventana del libro y el marco OLE pueden, por lo tanto, provocar que el objeto cambie de tamaño.

## **Solución funcional**

Haz coincidir el tamaño del gráfico con el marco OLE en la diapositiva y mantén las dimensiones del gráfico independientes de la ventana del libro. Esta solución funciona con una presentación nueva o una plantilla existente.

El ejemplo requiere Aspose.Cells for Android vía Java y Aspose.Slides for Android vía Java. Crea un gráfico de columnas sencillo en una hoja de gráfico activa e incrusta el libro en formato XLS. Llama a `FixedChartSize.createPresentation(getFilesDir())` desde una actividad Android para guardar la salida en el directorio interno de archivos de la aplicación. La activación OLE requiere PowerPoint de escritorio y una instalación de Excel compatible. No se asigna ninguna imagen de vista previa del gráfico; el gráfico se vuelve visible cuando el objeto OLE se activa en PowerPoint.

El ejemplo crea una presentación nueva con un marco OLE de 9,5 × 4 pulgadas situado a 0,5 pulgadas del borde izquierdo y a 1 pulgada de la parte superior. Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada). Para una presentación existente, consulta [Usar una plantilla](#use-a-template).

## **Establecer un tamaño de gráfico fijo**

Establece [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) a false para que las dimensiones del gráfico sean independientes de la ventana del libro. Configura las dimensiones del [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) a través de [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) y [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), convirtiendo puntos a píxeles usando 96 píxeles por pulgada: un marco de 684 × 288 puntos corresponde a un gráfico de 912 × 384 píxeles. Establece [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) al valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). El ejemplo incrusta el libro con [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) y guarda una presentación con un marco OLE de 9,5 × 4 pulgadas.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("Data");
                dataSheet.getCells().get("A1").putValue(10);
                dataSheet.getCells().get("A2").putValue(20);

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                chart.getNSeries().add("Data!A1:A2", true);
                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

                Presentation presentation = new Presentation();
                try {
                    ISlide slide = presentation.getSlides().get_Item(0);

                    // Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada).
                    float width = 684f; // 9,5 pulgadas.
                    float height = 288f; // 4 pulgadas.

                    chart.setSizeWithWindow(false);
                    // Convertir puntos a píxeles del gráfico usando 96 píxeles por pulgada.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Usar una plantilla**

La lógica de dimensionado es la misma para una presentación existente. Para adaptar el ejemplo:

1. Carga la presentación de plantilla en lugar de crear una presentación vacía.
1. Comprueba que la primera diapositiva contenga al menos tres formas y, a continuación, usa la forma en el índice 2 como marcador de posición.
1. Obtén el ancho y alto del marco de esa forma en lugar de usar los valores fijos 684 y 288. Mantén los cálculos de dimensionado sin cambios.
1. Añade el marco OLE en la posición del marcador de posición en lugar de las coordenadas fijas 36 y 72.
1. Elimina el marcador de posición antes de guardar la presentación.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el cambio de tamaño.

**¿Cómo puedo mantener consistentes los tamaños del gráfico y del marco OLE?**

Establece dimensiones fijas del gráfico que coincidan con el marco OLE y usa un tamaño de impresión de gráfico personalizado antes de incrustar el libro. El ejemplo anterior muestra la configuración requerida y las conversiones de unidades.

**¿Es suficiente que el tamaño de la ventana del libro coincida?**

Que el tamaño de la ventana del libro coincida solo no evita de forma fiable que el marco OLE cambie de tamaño tras la activación. Utiliza dimensiones fijas del gráfico como se muestra en el ejemplo.

**¿Esta solución funciona tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Para una plantilla, utiliza las dimensiones y posición del marcador de posición. Para una presentación nueva, especifica directamente las dimensiones y posición del marco.

**¿Puedo usar este ejemplo con gráficos creados en otros programas de hojas de cálculo?**

El ejemplo utiliza un libro de Excel creado con Aspose.Cells. No demuestra el comportamiento de activación para otros programas de hojas de cálculo.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)