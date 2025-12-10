---
title: Especificar fuentes predeterminadas de presentación en Java
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/java/default-font/
keywords:
- fuente predeterminada
- fuente regular
- fuente normal
- fuente asiática
- exportación PDF
- exportación XPS
- exportación de imágenes
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Establezca fuentes predeterminadas en Aspose.Slides para Java para garantizar una conversión adecuada de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Usar fuentes predeterminadas para renderizar una presentación**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlos como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos utilizando la API de Aspose.Slides para Java:

1. Cree una instancia de [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. Use [Set the DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) para establecer la fuente deseada. En el siguiente ejemplo, he usado Wingdings.
1. Use [Set the DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) para establecer la fuente deseada. He usado Wingdings en el siguiente ejemplo.
1. Cargue la presentación usando Presentation y configurando las opciones de carga.
1. Ahora, genere la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

```java
// Utilice opciones de carga para definir las fuentes predeterminadas regular y asiática
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generar miniatura de diapositiva
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // guardar la imagen en el disco.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Generar PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Generar XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Qué afecta exactamente DefaultRegularFont y DefaultAsianFont—solo la exportación o también las miniaturas, PDF, XPS, HTML y SVG?**

Participan en el proceso de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/java/convert-powerpoint-to-pdf/), [XPS](/slides/es/java/convert-powerpoint-to-xps/), [imágenes rasterizadas](/slides/es/java/convert-powerpoint-to-png/), [HTML](/slides/es/java/convert-powerpoint-to-html/), y [SVG](/slides/es/java/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar simplemente un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas importan cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los fragmentos de fuente almacenados ni la estructura del archivo. Las fuentes predeterminadas entran en juego durante operaciones que renderizan o reorganizan el texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se tendrán en cuenta al elegir fuentes predeterminadas?**

Sí. [Custom font sources](/slides/es/java/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [fallback rules](/slides/es/java/fallback-font/) se resolverán contra esas fuentes primero, proporcionando una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas del texto (kerning, avances) y, por tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [embed the original fonts](/slides/es/java/embedded-font/) o seleccione familias predeterminadas y de reserva compatibles métricamente.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque [embedded fonts](/slides/es/java/embedded-font/) ya garantizan una apariencia constante. Las fuentes predeterminadas aún sirven como medida de seguridad para los caracteres no cubiertos por el subconjunto incrustado o cuando un archivo mezcla texto incrustado y no incrustado.