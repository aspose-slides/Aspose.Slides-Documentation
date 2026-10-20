---
title: Solución práctica para el cambio de tamaño de gráficos en PPTX
type: docs
weight: 40
url: /es/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- cambio de tamaño de gráfico
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Corrija el inesperado cambio de tamaño de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para PHP via Java. Establezca dimensiones fijas del gráfico para mantener coherentes los tamaños del gráfico y del marco OLE."
---
## **Visión general**

Los gráficos de Excel incrustados como objetos OLE en presentaciones de PowerPoint mediante componentes Aspose pueden cambiar de tamaño después de su primera activación. Esto puede provocar una diferencia visible en la apariencia del gráfico antes y después de la activación. Este artículo explica por qué se produce el cambio de tamaño y muestra cómo prevenirlo haciendo coincidir las dimensiones fijas del gráfico con el marco OLE.

En [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells para PHP via Java e incrustarlo en una presentación de PowerPoint usando Aspose.Slides para PHP via Java. Para abordar el [problema de vista previa del objeto](/slides/es/php-java/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, al hacer doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden editar el libro de Excel incrustado y luego volver a la diapositiva haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de cambio de tamaño varía según los tamaños originales tanto del marco del objeto OLE como del libro de Excel incrustado.

## **Causa del cambio de tamaño**

El libro de Excel incrustado tiene sus propias dimensiones de ventana, que Excel intenta mantener cuando el objeto se activa por primera vez. El marco OLE en la diapositiva tiene dimensiones definidas de forma independiente. Cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño del objeto para mantener sus proporciones como parte del proceso de incrustación. Por lo tanto, las diferencias entre la ventana del libro y el marco OLE pueden provocar que el objeto cambie de tamaño.

## **Solución práctica**

Alinee el tamaño del gráfico con el marco OLE de la diapositiva y mantenga las dimensiones del gráfico independientes de la ventana del libro. Esta solución funciona con una presentación nueva o con una plantilla existente.

El ejemplo requiere Aspose.Cells para PHP via Java y Aspose.Slides para PHP via Java. Configure ambos productos con la misma instancia de PHP/Java Bridge, cargue ambos envoltorios PHP y haga que ambas bibliotecas Java estén disponibles para el puente. No se necesitan archivos de entrada. Crea un gráfico de columnas sencillo en una hoja de gráfico activa e incrusta el libro en formato XLS. No se asigna ninguna imagen de vista previa del gráfico; el gráfico se vuelve visible cuando el objeto OLE se activa en PowerPoint.

El ejemplo crea una nueva presentación con un marco OLE de 9,5 × 4 pulgadas situado a 0,5 pulgadas del borde izquierdo y a 1 pulgada de la parte superior. Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada). Para una presentación existente, consulte [Uso de una plantilla](#use-a-template).

## **Establecer un tamaño de gráfico fijo**

Establezca [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) a false para que las dimensiones del gráfico sean independientes de la ventana del libro. Establezca las dimensiones de [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) a través de [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) y [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), convirtiendo puntos a píxeles usando 96 píxeles por pulgada: un marco de 684 × 288 puntos corresponde a un gráfico de 912 × 384 píxeles. Establezca [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) al valor CUSTOM de [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). El ejemplo incrusta el libro con [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) y guarda una presentación con un marco OLE de 9,5 × 4 pulgadas.

Los resultados numéricos de Java se convierten con `java_values` antes de usarse como índices PHP. Los bytes del libro permanecen en una matriz de bytes Java al pasarse a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada).
        $width = 684; // 9,5 pulgadas.
        $height = 288; // 4 pulgadas.

        $chart->setSizeWithWindow(false);
        // Convertir puntos a píxeles del gráfico usando 96 píxeles por pulgada.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Uso de una plantilla**

La lógica de dimensionado es la misma para una presentación existente. Para adaptar el ejemplo:

1. Cargue la presentación plantilla en lugar de crear una presentación vacía.
1. Compruebe que la primera diapositiva contenga al menos tres formas y, a continuación, use la forma en el índice 2 como marcador de posición.
1. Obtenga el ancho y alto del marco de esa forma en lugar de usar los valores fijos 684 y 288. Mantenga sin cambios los cálculos de dimensionado.
1. Añada el marco OLE en la posición del marcador de posición en lugar de las coordenadas fijas 36 y 72.
1. Elimine el marcador de posición antes de guardar la presentación.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el cambio de tamaño.

**¿Cómo puedo mantener consistentes los tamaños del gráfico y del marco OLE?**

Establezca dimensiones fijas del gráfico que coincidan con el marco OLE y utilice un tamaño de impresión de gráfico personalizado antes de incrustar el libro. El ejemplo anterior muestra los ajustes requeridos y las conversiones de unidades.

**¿Es suficiente igualar el tamaño de la ventana del libro?**

Igualar solo el tamaño de la ventana del libro no evita de forma fiable que el marco OLE cambie de tamaño tras la activación. Utilice dimensiones fijas del gráfico como se muestra en el ejemplo.

**¿Esta solución funciona tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Para una plantilla, use las dimensiones y la posición del marcador de posición. Para una presentación nueva, indique directamente las dimensiones y la posición del marco.

**¿Puedo usar este ejemplo con gráficos creados en otros programas de hojas de cálculo?**

El ejemplo utiliza un libro de Excel creado con Aspose.Cells. No muestra el comportamiento de activación de otros programas de hojas de cálculo.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)