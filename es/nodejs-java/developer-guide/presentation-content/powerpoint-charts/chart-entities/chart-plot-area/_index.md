---
title: Área de trazado del gráfico
type: docs
url: /es/nodejs-java/chart-plot-area/
---

## **Obtener ancho, altura del área de trazado del gráfico**

Aspose.Slides for Node.js via Java proporciona una API simple para .

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Acceda a la primera diapositiva.
3. Agregue un gráfico con datos predeterminados.
4. Llame al método [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) antes de obtener los valores reales.
5. Obtiene la ubicación X real (izquierda) del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
6. Obtiene la posición superior real del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
7. Obtiene el ancho real del elemento del gráfico.
8. Obtiene la altura real del elemento del gráfico.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer modo de diseño del área de trazado del gráfico**

Aspose.Slides for Node.js via Java proporciona una API simple para establecer el modo de diseño del área de trazado del gráfico. Los métodos [**setLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) y [**getLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) se han añadido a la clase [**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea) y a la clase [**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea). Si el diseño del área de trazado se define manualmente, esta propiedad especifica si se diseña el área de trazado por su interior (sin incluir los ejes y las etiquetas de los ejes) o por su exterior (incluyendo los ejes y las etiquetas de los ejes). Hay dos valores posibles que se definen en el enum [**LayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Inner) - especifica que el tamaño del área de trazado determina el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Outer) - especifica que el tamaño del área de trazado determina el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

Se muestra el código de ejemplo a continuación.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿En qué unidades se devuelven X real, Y real, ancho real y altura real?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el área de trazado del área del gráfico en cuanto al contenido?**

El área de trazado es la región donde se dibujan los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En gráficos 3D, el área de trazado también incluye las paredes/suelo y los ejes.

**¿Cómo se interpretan X, Y, ancho y altura del área de trazado cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está deshabilitado y se utilizan las fracciones que usted establezca.

**¿Por qué cambió la posición del área de trazado después de agregar/mover la leyenda?**

La leyenda se encuentra en el área del gráfico fuera del área de trazado, pero afecta el diseño y el espacio disponible, por lo que el área de trazado puede desplazarse cuando el posicionamiento automático está activo. (Este es el comportamiento estándar de los gráficos de PowerPoint.)