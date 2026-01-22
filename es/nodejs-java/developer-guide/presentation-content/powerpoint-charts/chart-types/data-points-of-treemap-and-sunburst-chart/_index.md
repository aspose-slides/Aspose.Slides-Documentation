---
title: Personalizar puntos de datos en gráficos de Treemap y Sunburst usando JavaScript
linktitle: Puntos de datos en gráficos de Treemap y Sunburst
type: docs
url: /es/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- punto de datos
- color de etiqueta
- color de rama
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo gestionar puntos de datos en gráficos treemap y sunburst con JavaScript y Aspose.Slides para Node.js a través de Java, compatible con los formatos de PowerPoint."
---

Entre los demás tipos de gráficos de PowerPoint, existen dos tipos “jerárquicos”: el gráfico **Treemap** y el gráfico **Sunburst** (también conocido como Gráfico de Sunburst, Diagrama de Sunburst, Gráfico Radial, Gráfica Radial o Gráfico de Tarta Multinivel). Estos gráficos muestran datos jerárquicos organizados como un árbol, de las hojas hasta la parte superior de la rama. Las hojas se definen mediante los puntos de datos de la serie, y cada nivel de agrupación anidado posterior se define por la categoría correspondiente. Aspose.Slides para Node.js mediante Java permite dar formato a los puntos de datos del gráfico Sunburst y Treemap en JavaScript.

Aquí tienes un gráfico Sunburst, donde los datos de la columna Series1 definen los nodos hoja, mientras que las demás columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico Sunburst a la presentación:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="Ver también" %}} 
- [**Crear o actualizar gráficos de presentaciones PowerPoint en JavaScript**](/slides/es/nodejs-java/create-chart/)
{{% /alert %}}

Si es necesario dar formato a los puntos de datos del gráfico, debemos usar lo siguiente:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager),  
[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) clases  
y el método [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) proporcionan acceso para dar formato a los puntos de datos de los gráficos Treemap y Sunburst.  
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager) se usa para acceder a categorías de varios niveles; representa el contenedor de objetos [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel).  
Básicamente es un contenedor para [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) con propiedades añadidas específicas para los puntos de datos.  
La clase [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) tiene dos métodos: [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) y [**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) que proporcionan acceso a la configuración correspondiente.

## **Mostrar valor del punto de datos**
Mostrar el valor del punto de datos "Leaf 4":
```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer etiqueta y color del punto de datos**
Establecer la etiqueta del dato "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría. Después, establecer el color del texto a amarillo:
```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Establecer color de rama del punto de datos**
Cambiar el color de la rama "Steam 4":
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**¿Puedo cambiar el orden (clasificación) de los segmentos en Sunburst/Treemap?**

No. PowerPoint ordena los segmentos automáticamente (generalmente por valores descendentes, en sentido horario). Aspose.Slides refleja este comportamiento: no puedes cambiar el orden directamente; lo logras preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y etiquetas?**

Los colores del gráfico heredan el [tema/paleta](/slides/es/nodejs-java/presentation-theme/) de la presentación a menos que establezcas explícitamente rellenos/fuentes. Para obtener resultados consistentes, fija rellenos sólidos y el formato de texto en los niveles requeridos.

**¿La exportación a PDF/PNG preserva los colores personalizados de las ramas y la configuración de etiquetas?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza con el formato del gráfico aplicado.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar superposiciones personalizadas sobre el gráfico?**

Sí. Tras validar el diseño del gráfico, están disponibles X real y Y real para los elementos (por ejemplo, un [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)), lo que facilita la posición precisa de superposiciones.