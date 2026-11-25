---
title: Personalizar gráficos 3D en presentaciones usando PHP
linktitle: Gráfico 3D
type: docs
url: /es/php-java/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Cree gráficos 3D en presentaciones de PowerPoint con Aspose.Slides para PHP a través de Java. Ajuste la rotación, las proporciones de altura, la profundidad del gráfico y el espaciado entre series con ejemplos en PHP."
---
## **Visión general**

Aspose.Slides for PHP via Java le permite personalizar la vista de un gráfico 3D mediante el método [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Este artículo muestra cómo ajustar la rotación, las proporciones de altura, la profundidad, los ejes en ángulo recto y el espaciado entre series, y luego guardar la presentación en formato PPTX.

## **Establecer la rotación y la profundidad de un gráfico 3D**

El ejemplo siguiente crea una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y utiliza [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) para añadir un gráfico de columnas 3D apilado a su primera diapositiva. Sustituye las series y categorías predeterminadas por dos series que contienen tres valores cada una. El índice de hoja de cálculo `0` identifica la primera hoja de datos del gráfico; la fila `0` contiene los nombres de las series y la columna `0` contiene las etiquetas de categoría.

Los métodos [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) y [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) establecen la rotación del gráfico en 40 y 270 grados, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) establece su profundidad al 150 % de su anchura, mientras que [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) habilita ejes en ángulo recto en lugar de perspectiva. La presentación resultante contiene el gráfico rellenado con estos ajustes de vista 3D.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aplicar un relleno de imagen a la superficie de un gráfico 3D**

Puede rellenar la [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), la [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) y el [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) de un gráfico 3D de forma independiente. Defina el [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) de la superficie como `Picture` y asigne una imagen. Establezca tanto el [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) como el [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) de la superficie en `Stretch` para que una única copia de la imagen ocupe toda la superficie.

Guarde [arrow.png](arrow.png) junto al script PHP. El ejemplo rota el gráfico y eleva el valor máximo del eje vertical para que el suelo sea visible entre las columnas. Luego clona la diapositiva dos veces y aplica la flecha a una superficie diferente en cada diapositiva. Los tres gráficos conservan los mismos datos, ángulo de visión y fondo.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint muestra las tres diapositivas de la siguiente manera.

| Pared lateral | Pared trasera | Suelo |
| --- | --- | --- |
| ![Flecha apuntando hacia el gráfico a lo largo de la pared lateral](side-wall.png) | ![Flecha apuntando hacia la derecha a través de la pared trasera](back-wall.png) | ![Flecha apuntando hacia la derecha a través del suelo entre las columnas](floor.png) |

## **Ajustar las proporciones de altura de un gráfico 3D**

Utilice [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) para establecer la altura de un gráfico 3D como porcentaje de su anchura. Esto modifica las proporciones de la escena 3D sin cambiar el tamaño del objeto del gráfico en la diapositiva.

El siguiente ejemplo crea un gráfico [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) con los datos predeterminados: tres series y cuatro categorías. Guarda tres presentaciones con proporciones de altura del 50 %, 100 % y 200 %. La posición, anchura y altura del gráfico permanecen fijas. Los datos, la rotación, la profundidad, el espaciado de series y el formato son idénticos en los tres archivos; solo cambia el porcentaje de altura.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Las imágenes siguientes ilustran los mismos ajustes de altura en el ejemplo .NET equivalente y fueron exportadas con Microsoft PowerPoint. Un porcentaje menor produce una escena más plana, mientras que un porcentaje mayor produce una escena más alta dentro del mismo objeto del gráfico. PowerPoint también puede ajustar los intervalos de marcas de eje y la ubicación de las etiquetas para adaptarse a la escena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de columnas 3D con altura establecida al 50 % de su anchura](height_percent_50.png) | ![Gráfico de columnas 3D con altura establecida al 100 % de su anchura](height_percent_100.png) | ![Gráfico de columnas 3D con altura establecida al 200 % de su anchura](height_percent_200.png) |

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Altura de la escena 3D como porcentaje de su anchura. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Altura del objeto del gráfico en la diapositiva, en puntos. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidad de la escena 3D como porcentaje de su anchura. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |

El ajuste de altura afecta a los gráficos de columnas y barras 3D, incluidas sus variantes de cilindro, cono y pirámide, así como a los gráficos 3D de líneas, áreas, sectores y superficie. La comparación anterior utiliza el tipo verificado `Column3D`. El ajuste no modifica la apariencia de un gráfico 2D `ClusteredColumn` ni de un gráfico `BubbleWith3D`; estos nombres son miembros de la clase [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Para otros ajustes de apariencia de gráficos, consulte [Chart Formatting](/slides/es/php-java/chart-formatting/).

## **Ajustar el espacio entre series**

Utilice [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) para controlar la distancia entre series de datos a lo largo del eje de profundidad de un gráfico 3D, expresada como porcentaje del ancho del marcador. Use valores de **0 a 500**, inclusive: `0` elimina el espacio, mientras que valores mayores incrementan el espaciado. Con una profundidad de gráfico fija, aumentar el espacio hace que los marcadores sean más delgados a lo largo del eje de profundidad.

Acceda al grupo a través de [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). El ajuste se aplica a todas las series de ese grupo, no solo a la serie utilizada para acceder a él. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) devuelve el espacio de profundidad y refleja el ajuste del grupo padre.

Este ajuste afecta a los gráficos de columnas y barras 3D, incluidas sus variantes de cilindro, cono y pirámide, así como a los gráficos 3D de líneas y áreas. La apariencia depende de si las series están organizadas en profundidad, agrupadas o apiladas. Para una comparación clara de los espacios entre series separadas, utilice `ChartType::Column3D` de la clase [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Espaciado entre grupos adyacentes de barras o columnas, como porcentaje del ancho de la barra o columna. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profundidad total del gráfico, como porcentaje de la anchura del gráfico. |

El siguiente ejemplo autocontenido utiliza los datos de gráfico predeterminados, que contienen tres series y cuatro categorías. Guarda dos presentaciones con datos, rotación, ancho de espacio y profundidad de gráfico idénticos; solo cambia la profundidad del espacio.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Las imágenes siguientes ilustran los mismos ajustes de profundidad del espacio en el ejemplo .NET equivalente y fueron exportadas con Microsoft PowerPoint.

| Profundidad del espacio: 0 % | Profundidad del espacio: 500 % |
| --- | --- |
| ![Gráfico de columnas 3D sin espacio entre series a lo largo del eje de profundidad](gap_depth_0.png) | ![Gráfico de columnas 3D con un espacio del 500 % entre series a lo largo del eje de profundidad](gap_depth_500.png) |

## **Cambiar el tipo de serie 3D y la forma de la barra**

En un gráfico de cilindros agrupados, la primera serie comienza con una forma de barra cilíndrica. El ejemplo muestra los valores enteros devueltos por [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) y [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) antes y después de cada cambio. La tabla proporciona los nombres de constante correspondientes.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Cambiar a la primera serie | Tipo de serie | Forma de la barra |
| --- | --- | --- |
| Crear el gráfico | `ClusteredCylinder` | `Cylinder` |
| Establecer el tipo de serie a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Establecer la forma de la barra a `Box` | `ClusteredColumn3D` | `Box` |

Establecer la forma a `Box` también cambia el tipo de serie a `ClusteredColumn3D`. Si su código ramifica según el tipo de serie, llame a [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) después de cambiar la forma. Un valor almacenado antes de la asignación seguiría seleccionando la rama `ClusteredCone`.

![Comparación en PowerPoint que muestra la primera serie como cilindros, conos y columnas rectangulares de izquierda a derecha](series-shapes.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráficos admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluyendo Column 3D, Clustered Column 3D, Stacked Column 3D y 100 % Stacked Column 3D, junto con tipos 3D relacionados expuestos mediante la clase [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) en la referencia de la API de la versión que tenga instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen con [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) o [renderizar toda la diapositiva](/slides/es/php-java/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa raster o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) que coincida con la pantalla o los requisitos de impresión del objetivo.