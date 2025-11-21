---
title: Marcador de datos del gráfico
type: docs
url: /es/nodejs-java/chart-data-marker/
---

## **Configurar opciones de marcadores del gráfico**

Los marcadores pueden establecerse en los puntos de datos del gráfico dentro de series específicas. Para configurar las opciones de marcadores del gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Tomar la primera serie del gráfico.
- Añadir un nuevo punto de datos.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos configurado las opciones de marcadores del gráfico a nivel de los puntos de datos.
```javascript
// Creando presentación vacía
var pres = new aspose.slides.Presentation();
try {
    // Acceder a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Creando el gráfico predeterminado
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Obteniendo el índice de la hoja de datos del gráfico predeterminada
    var defaultWorksheetIndex = 0;
    // Obteniendo la hoja de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Eliminar serie de demostración
    chart.getChartData().getSeries().clear();
    // Añadir nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Cargar la imagen 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Cargar la imagen 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Obtener la primera serie del gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Añadir nuevo punto (1:3) allí.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Cambiando el marcador de la serie del gráfico
    series.getMarker().setSize(15);
    // Guardar presentación con el gráfico
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Qué formas de marcador están disponibles de forma predeterminada?**

Están disponibles formas estándar (círculo, cuadrado, diamante, triángulo, etc.); la lista está definida por la enumeración [MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/). Si necesita una forma no estándar, use un marcador con un relleno de imagen para emular visuales personalizados.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**

Sí. Al renderizar gráficos a [formatos raster](/slides/es/nodejs-java/convert-powerpoint-to-png/) o al guardar [formas como SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/), los marcadores conservan su apariencia y configuraciones, incluido el tamaño, el relleno y el contorno.