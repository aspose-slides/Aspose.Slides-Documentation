---
title: Fuentes Predeterminadas - API de Java para PowerPoint
linktitle: Fuentes Predeterminadas
type: docs
weight: 30
url: /es/php-java/default-font/
description: La API de Java para PowerPoint te permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir la fuente DefaultRegular y la fuente DefaultAsian para usarlas como fuentes predeterminadas.
---


## **Uso de Fuentes Predeterminadas para Renderizar Presentaciones**
Aspose.Slides te permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir la fuente DefaultRegular y la fuente DefaultAsian para usarlas como fuentes predeterminadas. Por favor, sigue los pasos a continuación para cargar fuentes desde directorios externos utilizando Aspose.Slides para PHP a través de la API de Java:

1. Crea una instancia de [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
1. [Establece la DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) a la fuente deseada. En el siguiente ejemplo, he usado Wingdings.
1. [Establece la DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) a la fuente deseada. He usado Wingdings en el siguiente ejemplo.
1. Carga la presentación usando Presentation y configurando las opciones de carga.
1. Ahora, genera la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se da a continuación.

```php
  # Utiliza opciones de carga para definir las fuentes regulares y asiáticas predeterminadas
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Carga la presentación
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Genera la miniatura de la diapositiva
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # guarda la imagen en el disco.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Genera PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Genera XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```