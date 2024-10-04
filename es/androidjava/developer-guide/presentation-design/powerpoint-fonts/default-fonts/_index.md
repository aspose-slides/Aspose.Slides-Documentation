---
title: Fuentes Predeterminadas - PowerPoint Java API
linktitle: Fuentes Predeterminadas
type: docs
weight: 30
url: /es/androidjava/default-font/
description: PowerPoint Java API te permite establecer la fuente predeterminada para renderizar la presentación en PDF, XPS o miniaturas. Este artículo muestra cómo definir la FuentePredeterminadaRegular y la FuentePredeterminadaAsiática para usarlas como fuentes predeterminadas.
---


## **Uso de Fuentes Predeterminadas para Renderizar la Presentación**
Aspose.Slides te permite establecer la fuente predeterminada para renderizar la presentación en PDF, XPS o miniaturas. Este artículo muestra cómo definir la FuentePredeterminadaRegular y la FuentePredeterminadaAsiática para usarlas como fuentes predeterminadas. Por favor, sigue los pasos a continuación para cargar fuentes desde directorios externos utilizando Aspose.Slides para Android a través de la API de Java:

1. Crea una instancia de [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
1. [Establece la FuentePredeterminadaRegular](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a tu fuente deseada. En el siguiente ejemplo, he utilizado Wingdings.
1. [Establece la FuentePredeterminadaAsiática](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a tu fuente deseada. He utilizado Wingdings en el siguiente ejemplo.
1. Carga la presentación usando Presentation y configurando las opciones de carga.
1. Ahora, genera la miniatura de la diapositiva, el PDF y el XPS para verificar los resultados.

La implementación de lo anterior se muestra a continuación.

```java
// Usa opciones de carga para definir las fuentes regulares y asiáticas predeterminadas
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