---
title: Personalizar tablas de datos de gráficos en presentaciones con PHP
linktitle: Tabla de datos
type: docs
url: /es/php-java/chart-data-table/
keywords:
- datos del gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Personaliza las fuentes, los bordes y las claves de leyenda de la tabla de datos de gráficos en presentaciones de PowerPoint usando Aspose.Slides para PHP mediante Java."
---
## **Descripción general**

Aspose.Slides for PHP via Java le permite mostrar la tabla de datos de un gráfico y personalizar su formato de texto, bordes y claves de leyenda. Este artículo explica cómo habilitar la tabla, dar formato a su texto, controlar cada tipo de borde y mostrar u ocultar las claves de la leyenda. Los ejemplos guardan los gráficos configurados en archivos PPTX.

## **Establecer propiedades de fuente**

Para mostrar la tabla de datos de un gráfico, pase `true` a [setDataTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/setdatatable/). Utilice [getChartDataTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/getchartdatatable/) para acceder a la tabla y configurar su formato de texto.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Añada un gráfico de columnas agrupadas a la primera diapositiva.
1. Habilite la tabla de datos del gráfico.
1. Active el texto en negrita con [setFontBold](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setFontBold) y pase `20` a [setFontHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setFontHeight) para texto de 20 puntos.
1. Guarde la presentación modificada.

El siguiente ejemplo requiere `test.pptx` en el directorio de trabajo con al menos una diapositiva. Añade un gráfico con datos predeterminados en la posición (50, 50), con un ancho de 600 puntos y una altura de 400 puntos. El `output.pptx` guardado contiene el gráfico con su tabla de datos habilitada y los ajustes de fuente especificados aplicados.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Personalizar bordes de la tabla de datos**

Habilite la tabla con [Chart::setDataTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/setdatatable/) y acceda a ella mediante [Chart::getChartDataTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/getchartdatatable/). Puede controlar tres tipos de bordes de forma independiente:

- [setBorderHorizontal](https://reference.aspose.com/slides/es/php-java/aspose.slides/datatable/setborderhorizontal/) controla los bordes horizontales de las celdas.
- [setBorderVertical](https://reference.aspose.com/slides/es/php-java/aspose.slides/datatable/setbordervertical/) controla los bordes verticales de las celdas.
- [setBorderOutline](https://reference.aspose.com/slides/es/php-java/aspose.slides/datatable/setborderoutline/) controla el borde exterior de la tabla.

Passe `true` a cada método para mostrar sus bordes o `false` para ocultarlos. El siguiente ejemplo crea un gráfico de columnas agrupadas con datos predeterminados, muestra los bordes horizontales y el borde exterior, y oculta los bordes verticales. No requiere archivo de entrada. La posición y el tamaño del gráfico se especifican en puntos.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparación a continuación utiliza los mismos datos del gráfico y la configuración de la clave de leyenda en los cuatro casos. Partiendo de todos los bordes habilitados, cada variante restante desactiva solo una configuración de borde. La variante inferior izquierda coincide con la configuración de bordes del ejemplo.

![Tablas de datos del gráfico con todos los bordes habilitados, sin bordes horizontales, sin bordes verticales y sin borde exterior](data-table-borders.png)

## **Mostrar u ocultar claves de leyenda**

Las claves de leyenda son pequeños marcadores coloreados junto a los nombres de series en la tabla de datos. Ayudan a los lectores a asociar cada fila de la tabla con una serie del gráfico. Pase `true` a [setShowLegendKey](https://reference.aspose.com/slides/es/php-java/aspose.slides/datatable/setshowlegendkey/) para mostrar estos marcadores o `false` para ocultarlos.

La leyenda separada del gráfico se controla mediante [Chart::setLegend](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/setlegend/). Estas configuraciones son independientes: ocultar la leyenda separada no oculta las claves dentro de la tabla de datos, y ocultar las claves de la tabla no oculta la leyenda separada.

El siguiente ejemplo crea un gráfico con datos predeterminados, habilita su tabla de datos y muestra las claves de leyenda dentro de ella mientras oculta la leyenda separada. Todos los bordes de la tabla están explícitamente habilitados. No se necesita una presentación de entrada. Para ocultar solo las claves de la tabla, pase `false` a [setShowLegendKey](https://reference.aspose.com/slides/es/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparación a continuación muestra la misma tabla con las claves de leyenda habilitadas y deshabilitadas. Todos los bordes permanecen habilitados y la leyenda separada del gráfico está oculta en ambos casos.

![Tablas de datos del gráfico con claves de leyenda mostradas a la izquierda y ocultas a la derecha](data-table-legend-keys.png)

## **Preguntas frecuentes**

**¿Puedo mostrar claves de leyenda en la tabla de datos de un gráfico?**

Sí. Pase `true` a [setShowLegendKey](https://reference.aspose.com/slides/es/php-java/aspose.slides/datatable/setshowlegendkey/) para mostrar las claves de leyenda o `false` para ocultarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico y su tabla de datos mostrada como parte de la diapositiva al exportar a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/es/php-java/convert-powerpoint-to-html/) o [imágenes](/slides/es/php-java/convert-powerpoint-to-png/).

**¿Puedo trabajar con tablas de datos en gráficos cargados desde una plantilla?**

Sí. Para un gráfico cargado desde una presentación o plantilla existente, utilice [hasDataTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/hasdatatable/) y [setDataTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/setdatatable/) para comprobar o cambiar si su tabla de datos se muestra.

**¿Cómo puedo encontrar gráficos que tengan la tabla de datos habilitada?**

Itere a través de las formas en cada diapositiva, identifique los gráficos y llame a su método [hasDataTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/hasdatatable/). Un valor de `true` indica que la tabla de datos está habilitada.