---
title: Solución práctica para el redimensionado de gráficos en PPTX
type: docs
weight: 40
url: /es/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionado de gráficos
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Corrige el redimensionado inesperado de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para Node.js a través de Java. Establece dimensiones fijas del gráfico para mantener consistentes los tamaños del gráfico y del marco OLE."
---
## **Visión general**

Los gráficos de Excel incrustados como objetos OLE en presentaciones de PowerPoint mediante los componentes Aspose pueden cambiar de tamaño después de su primera activación. Esto puede provocar una diferencia notable en la apariencia del gráfico antes y después de la activación. Este artículo explica por qué se produce el cambio de tamaño y muestra cómo evitarlo haciendo coincidir las dimensiones fijas del gráfico con el marco OLE.

En [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/es/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells para Node.js a través de Java e incrustarlo en una presentación de PowerPoint usando Aspose.Slides para Node.js a través de Java. Para abordar el [object preview issue](/slides/es/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, al hacer doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden editar el libro de Excel incrustado y luego volver a la diapositiva haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de redimensionado varía según los tamaños originales tanto del marco OLE como del libro de Excel incrustado.

## **Causa del cambio de tamaño**

El libro de Excel incrustado tiene sus propias dimensiones de ventana, que Excel intenta conservar cuando el objeto se activa por primera vez. El marco OLE en la diapositiva tiene dimensiones definidas de forma independiente. Cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño del objeto para mantener sus proporciones como parte del proceso de incrustación. Las diferencias entre la ventana del libro y el marco OLE pueden, por tanto, provocar el redimensionado del objeto.

## **Solución funcional**

Haga coincidir el tamaño del gráfico con el marco OLE en la diapositiva y mantenga las dimensiones del gráfico independientes de la ventana del libro. Esta solución funciona con una presentación nueva o con una plantilla existente.

El ejemplo requiere Aspose.Cells para Node.js a través de Java y Aspose.Slides para Node.js a través de Java. Instale los paquetes Node.js `aspose.cells`, `aspose.slides.via.java` y `java`. Ejecute los dos scripts CommonJS a continuación en procesos Node.js separados, usando el mismo directorio de trabajo, porque ambos paquetes Aspose inicializan el puente Java durante la carga. Crea un gráfico de columnas simple en una hoja de gráficos activa y incrusta el libro en formato XLS. No se asigna ninguna imagen de vista previa del gráfico; el gráfico se vuelve visible cuando el objeto OLE se activa en PowerPoint.

El ejemplo crea una nueva presentación con un marco OLE de 9.5 × 4 pulgadas situado a 0.5 pulgadas del borde izquierdo y a 1 pulgada de la parte superior. Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada). Para una presentación existente, consulte [Use a Template](#use-a-template).

## **Establecer un tamaño de gráfico fijo**

Configure [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) a false para que las dimensiones del gráfico sean independientes de la ventana del libro. Establezca las dimensiones de [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) mediante [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) y [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), convirtiendo puntos a píxeles usando 96 píxeles por pulgada: un marco de 684 × 288 puntos corresponde a un gráfico de 912 × 384 píxeles. Configure [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) al valor CUSTOM de `PrintSizeType`. El ejemplo incrusta el libro con [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) y guarda una presentación con un marco OLE de 9.5 × 4 pulgadas.

Guarde este primer script como `create-fixed-chart.js`. Crea `chart-fixed-size.xls` con un gráfico de 912 × 384 píxeles, que coincide con el marco de 684 × 288 puntos usado por el segundo script. No se requiere un libro de entrada.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Coincidir las dimensiones del marco OLE en puntos (72 puntos por pulgada).
    const width = 684; // 9,5 pulgadas.
    const height = 288; // 4 pulgadas.

    chart.setSizeWithWindow(false);
    // Convertir puntos a píxeles del gráfico usando 96 píxeles por pulgada.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Todo el trabajo síncrono ha finalizado; detener el proceso del puente Java.
process.exit(0);
```

Guarde el segundo script como `embed-fixed-chart.js` y ejecútelo después de `create-fixed-chart.js`. Lee el libro XLS generado y guarda `chart-fixed-size.pptx`. El puente Java requiere una matriz de bytes Java explícita para los datos del libro y valores flotantes Java para las coordenadas y dimensiones del marco. La extensión `xls` coincide con el formato guardado del libro.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada).
    const width = 684; // 9,5 pulgadas.
    const height = 288; // 4 pulgadas.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Todo el trabajo síncrono ha finalizado; detener el proceso del puente Java.
process.exit(0);
```

## **Utilizar una plantilla**

La lógica de dimensionado es la misma para una presentación existente. Para adaptar el ejemplo:

1. Cargue la presentación de plantilla en lugar de crear una presentación vacía.
1. Verifique que la primera diapositiva contenga al menos tres formas y use la forma en el índice 2 como marcador de posición.
1. Obtenga el ancho y alto del marco de esa forma en lugar de usar los valores fijos 684 y 288. Utilice las mismas dimensiones en el script de creación del libro, manteniendo sin cambios los cálculos de dimensionado, y regenere el libro XLS antes de incrustarlo.
1. Añada el marco OLE en la posición del marcador de posición en lugar de las coordenadas fijas 36 y 72.
1. Elimine el marcador de posición antes de guardar la presentación.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede provocar el redimensionado.

**¿Cómo puedo mantener consistentes los tamaños del gráfico y del marco OLE?**

Establezca dimensiones fijas del gráfico que coincidan con el marco OLE y utilice un tamaño de impresión de gráfico personalizado antes de incrustar el libro. El ejemplo anterior muestra la configuración requerida y las conversiones de unidades.

**¿Es suficiente hacer coincidir el tamaño de la ventana del libro?**

Hacer coincidir solo el tamaño de la ventana del libro no evita de forma fiable que el marco OLE cambie de tamaño tras la activación. Use dimensiones fijas del gráfico como se muestra en el ejemplo.

**¿Esta solución funciona tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Para una plantilla, use las dimensiones y la posición del marcador de posición. Para una presentación nueva, especifique directamente las dimensiones y la posición del marco.

**¿Puedo usar este ejemplo con gráficos creados en otros programas de hoja de cálculo?**

El ejemplo usa un libro de Excel creado con Aspose.Cells. No demuestra el comportamiento de activación para otros programas de hoja de cálculo.

## **Secciones relacionadas**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/es/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)