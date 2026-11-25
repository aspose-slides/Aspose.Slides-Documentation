---
title: Personalizar gráficos 3D en presentaciones en Android
linktitle: Gráfico 3D
type: docs
url: /es/androidjava/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Cree gráficos 3D en presentaciones de PowerPoint con Aspose.Slides para Android mediante Java. Ajuste la rotación, las proporciones de altura, la profundidad del gráfico y el espaciado entre series con ejemplos en Java."
---
## **Visión general**

Aspose.Slides for Android via Java le permite personalizar la vista de un gráfico 3D a través del método [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Este artículo muestra cómo ajustar la rotación, las proporciones de altura, la profundidad, los ejes en ángulo recto y el espaciado entre series, y luego guardar la presentación en formato PPTX.

## **Establecer la rotación y la profundidad de un gráfico 3D**

El ejemplo a continuación crea una [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y usa [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) para añadir un gráfico de columnas 3D apilado a su primera diapositiva. Reemplaza las series y categorías predeterminadas con dos series que contienen tres valores cada una. El índice de hoja de cálculo `0` identifica la primera hoja de datos del gráfico; la fila `0` contiene los nombres de las series, y la columna `0` contiene las etiquetas de categoría.

Los métodos [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) y [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) establecen la rotación del gráfico en 40 y 270 grados, respectivamente. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) establece su profundidad al 150 % de su ancho, mientras que [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) habilita ejes en ángulo recto en lugar de perspectiva. La presentación resultante contiene el gráfico poblado con estos ajustes de vista 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aplicar un relleno de imagen a la superficie de un gráfico 3D**

Un gráfico 3D tiene tres superficies que pueden rellenarse de forma independiente: la [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), la [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) y el [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) . Establezca el [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) de la superficie a `Picture` y asigne una imagen. Defina tanto el [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) como el [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) de la superficie a `Stretch` para que una copia de la imagen cubra toda la superficie.

Guarde [arrow.png](arrow.png) en el directorio de trabajo. El ejemplo rota el gráfico y eleva el valor máximo del eje vertical para que el piso sea visible entre las columnas. Luego clona la diapositiva dos veces y aplica la flecha a una superficie distinta en cada diapositiva. Los tres gráficos conservan los mismos datos, ángulo de visión y fondo.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint muestra las tres diapositivas de la siguiente manera.

| Pared lateral | Pared posterior | Piso |
| --- | --- | --- |
| ![Flecha apuntando hacia el interior del gráfico a lo largo de la pared lateral](side-wall.png) | ![Flecha apuntando a la derecha a lo largo de la pared posterior](back-wall.png) | ![Flecha apuntando a la derecha a lo largo del piso entre las columnas](floor.png) |

## **Ajustar las proporciones de altura de un gráfico 3D**

Utilice [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) para establecer la altura de un gráfico 3D como porcentaje de su ancho. Esto cambia las proporciones de la escena 3D sin redimensionar el objeto del gráfico en la diapositiva.

El siguiente ejemplo crea un gráfico [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) con los datos predeterminados: tres series y cuatro categorías. Guarda tres presentaciones con proporciones de altura del 50 %, 100 % y 200 %. La posición, ancho y altura del gráfico permanecen fijos. Los datos, la rotación, la profundidad, el espaciado entre series y el formato son idénticos en los tres archivos; solo cambia el porcentaje de altura.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Las imágenes siguientes ilustran los mismos ajustes de altura en el ejemplo .NET equivalente y fueron exportadas con Microsoft PowerPoint. Un porcentaje menor produce una escena más plana, mientras que un porcentaje mayor genera una escena más alta dentro del mismo objeto del gráfico. PowerPoint también puede ajustar los intervalos de marcas de eje y la colocación de etiquetas para adaptar la escena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de columnas 3D con altura al 50 % de su ancho](height_percent_50.png) | ![Gráfico de columnas 3D con altura al 100 % de su ancho](height_percent_100.png) | ![Gráfico de columnas 3D con altura al 200 % de su ancho](height_percent_200.png) |

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Altura de la escena 3D como porcentaje de su ancho. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Altura del objeto del gráfico en la diapositiva, en puntos. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profundidad de la escena 3D como porcentaje de su ancho. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |

El ajuste de altura afecta a los gráficos de columnas y barras 3D, incluidas sus variantes cilíndrica, cónica y piramidal, así como a los gráficos de líneas, áreas, sectores y superficies 3D. La comparación anterior utiliza el tipo verificado `Column3D`. El ajuste no altera la apariencia de un gráfico 2D `ClusteredColumn` ni de un gráfico `BubbleWith3D`; estos nombres son miembros de la clase [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Para otros ajustes de apariencia del gráfico, consulte [Chart Formatting](/slides/es/androidjava/chart-formatting/).

## **Ajustar el espacio entre series**

Utilice [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) para controlar la distancia entre series de datos a lo largo del eje de profundidad de un gráfico 3D, expresada como porcentaje del ancho del marcador. Use valores entre **0 y 500**, inclusive: `0` elimina el espacio, mientras que valores mayores aumentan el espaciado. Con una profundidad de gráfico fija, aumentar el espacio hace que los marcadores sean más estrechos a lo largo del eje de profundidad.

Acceda al grupo mediante [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . El ajuste se aplica a todas las series de ese grupo, no solo a la serie utilizada para acceder a él. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) devuelve el espacio de profundidad y refleja el ajuste del grupo padre.

Este ajuste afecta a los gráficos de columnas y barras 3D, incluidas sus variantes cilíndrica, cónica y piramidal, así como a los gráficos de líneas y áreas 3D. La apariencia depende de si las series están dispuestas en profundidad, agrupadas o apiladas. Para una comparación clara de los espacios entre series separadas, utilice `ChartType.Column3D` de la clase [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Estos métodos controlan diferentes aspectos del gráfico:

| Método | Efecto |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Espaciado entre grupos de barras o columnas adyacentes, como porcentaje del ancho de la barra o columna. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Profundidad total del gráfico, como porcentaje del ancho del gráfico. |

El siguiente ejemplo autocontenido usa los datos predeterminados del gráfico, que contienen tres series y cuatro categorías. Guarda dos presentaciones con datos idénticos, rotación, ancho de espacio y profundidad del gráfico; solo cambia el espacio de profundidad.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Las imágenes siguientes ilustran los mismos ajustes de espacio de profundidad en el ejemplo .NET equivalente y fueron exportadas con Microsoft PowerPoint.

| Espacio de profundidad: 0 % | Espacio de profundidad: 500 % |
| --- | --- |
| ![Gráfico de columnas 3D sin espacio entre series a lo largo del eje de profundidad](gap_depth_0.png) | ![Gráfico de columnas 3D con un espacio del 500 % entre series a lo largo del eje de profundidad](gap_depth_500.png) |

## **Cambiar el tipo de serie 3D y la forma de la barra**

En un gráfico de cilindros agrupados, la primera serie comienza con una barra de forma cilíndrica. El ejemplo muestra los valores enteros devueltos por [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) y [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) antes y después de cada cambio. La tabla muestra los nombres de constantes correspondientes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Cambio en la primera serie | Tipo de serie | Forma de barra |
| --- | --- | --- |
| Crear el gráfico | `ClusteredCylinder` | `Cylinder` |
| Establecer el tipo de serie a `ClusteredCone` | `ClusteredCone` | `Cone` |
| Establecer la forma de barra a `Box` | `ClusteredColumn3D` | `Box` |

Establecer la forma a `Box` también cambia el tipo de serie a `ClusteredColumn3D`. Si su código bifurca según el tipo de serie, llame a `series.getType()` después de cambiar la forma. Un valor almacenado en caché antes de la asignación aún seleccionaría la rama `ClusteredCone`.

![Comparación en PowerPoint que muestra la primera serie como cilindros, conos y columnas rectangulares de izquierda a derecha](series-shapes.png)

## **FAQ**

**¿Qué tipos de gráfico admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100 % Stacked Column 3D, junto con los tipos 3D relacionados expuestos mediante la clase [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) en la referencia de API de la versión instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen con [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) o [renderizar toda la diapositiva](/slides/es/androidjava/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa rasterizada o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y el renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y de la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a un tamaño de salida adecuado (resolución y dimensiones) que coincida con el dispositivo de visualización o impresión objetivo.