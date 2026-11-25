---
title: Personalizar gráficos 3D en presentaciones usando JavaScript
linktitle: Gráfico 3D
type: docs
url: /es/nodejs-java/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Cree gráficos 3D en presentaciones de PowerPoint con Aspose.Slides para Node.js a través de Java. Ajuste la rotación, las proporciones de altura, la profundidad del gráfico y el espaciado entre series con ejemplos en JavaScript."
---
## **Visión general**

Aspose.Slides para Node.js a través de Java le permite personalizar la vista de un gráfico 3D mediante el método [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Este artículo muestra cómo ajustar la rotación, las proporciones de altura, la profundidad, los ejes en ángulo recto y el espaciado entre series, y luego guardar la presentación en formato PPTX.

## **Establecer la rotación y la profundidad de un gráfico 3D**

El ejemplo a continuación crea una [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y utiliza [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) para añadir un gráfico de columnas 3D apilado a su primera diapositiva. Reemplaza las series y categorías predeterminadas por dos series que contienen tres valores cada una. El índice de la hoja de cálculo `0` identifica la primera hoja de datos del gráfico; la fila `0` contiene los nombres de las series y la columna `0` contiene las etiquetas de categoría.

Los métodos [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) y [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) establecen la rotación del gráfico en 40 y 270 grados, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) fija su profundidad al 150% de su ancho, mientras que [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) habilita ejes en ángulo recto en lugar de perspectiva. La presentación resultante contiene el gráfico poblado con estos ajustes de vista 3D.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aplicar un relleno de imagen a la superficie de un gráfico 3D**

Puede rellenar la [pared lateral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), la [pared trasera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) y el [suelo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) de un gráfico 3D de forma independiente. Establezca el [tipo de relleno](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) de la superficie a `Picture` y asigne una imagen. Establezca tanto el [modo de relleno de imagen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) como el [tipo de imagen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) de la superficie a `Stretch` para que una única copia de la imagen se ajuste a toda la superficie.

Guarde [arrow.png](arrow.png) en el directorio de trabajo. El ejemplo rota el gráfico y eleva el valor máximo en el eje vertical para que el suelo sea visible entre las columnas. Luego clona la diapositiva dos veces y aplica la flecha a una superficie diferente en cada diapositiva. Los tres gráficos conservan los mismos datos, ángulo de visión y fondo.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint muestra las tres diapositivas de la siguiente manera.

| Pared lateral | Pared trasera | Suelo |
| --- | --- | --- |
| ![Flecha apuntando al gráfico a lo largo de la pared lateral](side-wall.png) | ![Flecha apuntando a la derecha a través de la pared trasera](back-wall.png) | ![Flecha apuntando a la derecha a través del suelo entre las columnas](floor.png) |

## **Ajustar las proporciones de altura de un gráfico 3D**

Utilice [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) para establecer la altura de un gráfico 3D como porcentaje de su ancho. Esto cambia las proporciones de la escena 3D sin redimensionar el objeto del gráfico en la diapositiva.

El siguiente ejemplo crea un gráfico [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) con los datos predeterminados: tres series y cuatro categorías. Guarda tres presentaciones con proporciones de altura del 50%, 100% y 200%. La posición, el ancho y la altura del gráfico permanecen fijos. Los datos, la rotación, la profundidad, el espaciado entre series y el formato son idénticos en los tres archivos; solo cambia el porcentaje de altura.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Las siguientes imágenes ilustran los mismos ajustes de altura en el ejemplo .NET equivalente y fueron exportadas con Microsoft PowerPoint. Un porcentaje menor produce una escena más plana, mientras que un porcentaje mayor produce una escena más alta dentro del mismo objeto de gráfico. PowerPoint también puede ajustar los intervalos de marcas del eje y la colocación de etiquetas para adaptar la escena.

| Altura: 50% | Altura: 100% | Altura: 200% |
| --- | --- | --- |
| ![Gráfico de columnas 3D con la altura establecida al 50% de su ancho](height_percent_50.png) | ![Gráfico de columnas 3D con la altura establecida al 100% de su ancho](height_percent_100.png) | ![Gráfico de columnas 3D con la altura establecida al 200% de su ancho](height_percent_200.png) |

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Altura de la escena 3D como porcentaje de su ancho. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Altura del objeto del gráfico en la diapositiva, en puntos. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profundidad de la escena 3D como porcentaje de su ancho. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |

El ajuste de altura afecta a los gráficos de columnas y barras 3D, incluidas sus variantes cilindro, cono y pirámide, así como a los gráficos de líneas, áreas, sectores y superficies 3D. La comparación anterior utiliza el tipo verificado `Column3D`. El ajuste no modifica la apariencia de un gráfico 2D `ClusteredColumn` o de un `BubbleWith3D`; estos nombres son miembros de la clase [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Para otros ajustes de apariencia del gráfico, consulte [Formato de gráfico](/slides/es/nodejs-java/chart-formatting/).

## **Ajustar el espacio entre series**

Utilice [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) para controlar la distancia entre series de datos a lo largo del eje de profundidad de un gráfico 3D, expresada como porcentaje del ancho del marcador. Use valores de **0 a 500**, inclusive: `0` elimina el espacio, mientras que valores mayores aumentan el espaciado. Con una profundidad de gráfico fija, aumentar el espacio hace que los marcadores sean más delgados a lo largo del eje de profundidad.

Acceda al grupo mediante [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). La configuración se aplica a todas las series de ese grupo, no solo a la serie utilizada para acceder a él. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) devuelve el espacio de profundidad y refleja la configuración del grupo padre.

Esta configuración afecta a los gráficos de columnas y barras 3D, incluidas sus variantes cilindro, cono y pirámide, así como a los gráficos de líneas y áreas 3D. La apariencia depende de si las series están dispuestas en profundidad, agrupadas o apiladas. Para una comparación clara de los espacios entre series separadas, utilice `ChartType.Column3D` de la clase [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Espaciado entre grupos adyacentes de barras o columnas, como porcentaje del ancho de la barra o columna. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Profundidad total del gráfico, como porcentaje del ancho del gráfico. |

El siguiente ejemplo independiente utiliza los datos predeterminados del gráfico, que contienen tres series y cuatro categorías. Guarda dos presentaciones con datos, rotación, ancho de espacio y profundidad del gráfico idénticos; solo cambia la profundidad del espacio.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Las siguientes imágenes ilustran los mismos ajustes de profundidad del espacio en el ejemplo .NET equivalente y fueron exportadas con Microsoft PowerPoint.

| Profundidad del espacio: 0% | Profundidad del espacio: 500% |
| --- | --- |
| ![Gráfico de columnas 3D sin espacio entre series a lo largo del eje de profundidad](gap_depth_0.png) | ![Gráfico de columnas 3D con un espacio del 500% entre series a lo largo del eje de profundidad](gap_depth_500.png) |

## **Cambiar el tipo de serie 3D y la forma de la barra**

En un gráfico de cilindros agrupados, la primera serie comienza con una forma de barra cilíndrica. El ejemplo muestra los valores enteros devueltos por [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) y [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) antes y después de cada cambio. La tabla muestra los nombres de constantes correspondientes.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Cambio en la primera serie | Tipo de serie | Forma de barra |
| --- | --- | --- |
| Crear el gráfico | `ClusteredCylinder` | `Cylinder` |
| Establecer el tipo de serie a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Establecer la forma de la barra a `Box` | `ClusteredColumn3D` | `Box` |

Establecer la forma a `Box` también cambia el tipo de serie a `ClusteredColumn3D`. Si su código realiza bifurcaciones basadas en el tipo de serie, llame a `series.getType()` después de cambiar la forma. Un valor almacenado en caché antes de la asignación seguiría seleccionando la rama `ClusteredCone`.

![Comparación en PowerPoint que muestra la primera serie como cilindros, conos y columnas rectangulares de izquierda a derecha](series-shapes.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidas Column 3D, Clustered Column 3D, Stacked Column 3D y 100 % Stacked Column 3D, junto con los tipos 3D relacionados expuestos a través de la clase [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) en la referencia API de la versión que tenga instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen con [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) o [renderizar la diapositiva completa](/slides/es/nodejs-java/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa rasterizada o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en las paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y genere una salida con el tamaño apropiado (resolución y dimensiones) para adaptarse a la pantalla o impresión objetivo.