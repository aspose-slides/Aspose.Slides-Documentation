---
title: Fuentes predeterminadas - API de JavaScript de PowerPoint
linktitle: Fuentes predeterminadas
type: docs
weight: 30
url: /es/nodejs-java/default-font/
description: La API de JavaScript de PowerPoint le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegular Font y DefaultAsian Font para usarlas como fuentes predeterminadas.
---

## **Uso de fuentes predeterminadas para renderizar presentaciones**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos usando Aspose.Slides para Node.js a través de la API Java:

1. Cree una instancia de [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions).
1. [Establezca el DefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a la fuente deseada. En el siguiente ejemplo, he usado Wingdings.
1. [Establezca el DefaultAsianFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a la fuente deseada. He usado Wingdings en el siguiente ejemplo.
1. Cargue la presentación usando Presentation y estableciendo las opciones de carga.
1. Ahora, genere la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

```javascript
// Usar opciones de carga para definir las fuentes predeterminadas regular y asiática
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Cargar la presentación
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generar miniatura de la diapositiva
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // guardar la imagen en el disco.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Generar PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Generar XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Qué afectan exactamente DefaultRegularFont y DefaultAsianFont: solo la exportación, o también miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/nodejs-java/convert-powerpoint-to-xps/), [imágenes raster](/slides/es/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/es/nodejs-java/convert-powerpoint-to-html/), y [SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar simplemente un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas importan cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los grupos de fuentes almacenados ni la estructura del archivo. Las fuentes predeterminadas intervienen durante operaciones que renderizan o reflujo de texto.

**¿Si añado mis propias carpetas de fuentes o suministro fuentes desde la memoria, se tendrán en cuenta al seleccionar las fuentes predeterminadas?**

Sí. [Fuentes personalizadas](/slides/es/nodejs-java/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [reglas de respaldo](/slides/es/nodejs-java/fallback-font/) se resolverán contra esas fuentes primero, proporcionando una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas de texto (kerning, avances) y, por lo tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/nodejs-java/embedded-font/) o seleccione familias predeterminadas y de respaldo métricamente compatibles.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque [fuentes incrustadas](/slides/es/nodejs-java/embedded-font/) ya garantizan una apariencia coherente. Las fuentes predeterminadas aún ayudan como red de seguridad para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo mezcla texto incrustado y no incrustado.