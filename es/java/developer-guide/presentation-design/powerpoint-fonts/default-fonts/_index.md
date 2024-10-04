---
title: Fuentes Predeterminadas - PowerPoint Java API
linktitle: Fuentes Predeterminadas
type: docs
weight: 30
url: /es/java/default-font/
description: PowerPoint Java API te permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir la FuenteRegularPredeterminada y la FuenteAsiáticaPredeterminada para usarse como fuentes predeterminadas.
---


## **Uso de Fuentes Predeterminadas para Renderizar Presentaciones**
Aspose.Slides te permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir la FuenteRegularPredeterminada y la FuenteAsiáticaPredeterminada para usarse como fuentes predeterminadas. Sigue los pasos a continuación para cargar fuentes desde directorios externos utilizando Aspose.Slides para Java API:

1. Crea una instancia de [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [Establece la FuenteRegularPredeterminada](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a la fuente deseada. En el siguiente ejemplo, he usado Wingdings.
1. [Establece la FuenteAsiáticaPredeterminada](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a la fuente deseada. He usado Wingdings en el siguiente ejemplo.
1. Carga la presentación usando Presentation y configurando las opciones de carga.
1. Ahora, genera la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se da a continuación.

```java
// Usa opciones de carga para definir las fuentes regular y asiática predeterminadas
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Carga la presentación
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Genera la miniatura de la diapositiva
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // guarda la imagen en el disco.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Genera PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Genera XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```