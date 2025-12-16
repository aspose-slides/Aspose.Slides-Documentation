---
title: Especificar fuentes predeterminadas de la presentación en Android
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Establezca fuentes predeterminadas en Aspose.Slides para Android mediante Java para garantizar una correcta conversión de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Usar fuentes predeterminadas para renderizar una presentación**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para usarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos usando Aspose.Slides para Android mediante la API de Java:

1. Crea una instancia de [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
2. Establezca el [DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a la fuente que desee. En el siguiente ejemplo, he usado Wingdings.
3. Establezca el [DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a la fuente que desee. He usado Wingdings en el siguiente ejemplo.
4. Cargue la presentación usando Presentation y configurando las opciones de carga.
5. Ahora, genere la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se muestra a continuación.
```java
// Utilice opciones de carga para definir las fuentes regulares y asiáticas predeterminadas
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Cargar la presentación
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


## **Preguntas frecuentes**

**¿Qué afectan exactamente DefaultRegularFont y DefaultAsianFont—solo la exportación o también miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/es/androidjava/convert-powerpoint-to-xps/), [imágenes rasterizadas](/slides/es/androidjava/convert-powerpoint-to-png/), [HTML](/slides/es/androidjava/convert-powerpoint-to-html/), y [SVG](/slides/es/androidjava/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al simplemente leer y guardar un PPTX sin renderizado?**

No. Las fuentes predeterminadas son relevantes cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no cambia los fragmentos de fuente almacenados ni la estructura del archivo. Las fuentes predeterminadas entran en juego durante operaciones que renderizan o reflujo del texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se considerarán al elegir fuentes predeterminadas?**

Sí. Las [fuentes personalizadas](/slides/es/androidjava/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [regla de reserva](/slides/es/androidjava/fallback-font/) se resolverán contra esas fuentes primero, proporcionando una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas de texto (kerning, avances) y por lo tanto a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/androidjava/embedded-font/) o seleccione familias predeterminadas y de reserva métricamente compatibles.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque las [fuentes incrustadas](/slides/es/androidjava/embedded-font/) ya garantizan una apariencia consistente. Las fuentes predeterminadas siguen siendo útiles como red de seguridad para caracteres no cubiertos por el subconjunto incrustado o cuando un archivo combina texto incrustado y no incrustado.