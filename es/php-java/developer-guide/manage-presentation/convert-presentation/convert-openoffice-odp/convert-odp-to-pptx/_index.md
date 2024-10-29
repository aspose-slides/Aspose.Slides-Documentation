---
title: Convertir ODP a PPTX
type: docs
weight: 10
url: /es/php-java/convert-odp-to-pptx/
---

## **Convertir ODP a PPTX/PPT Presentación**
Aspose.Slides para PHP a través de Java ofrece la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que representa un archivo de presentación. La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) ahora también puede acceder a ODP a través del constructor [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.

```php
// Abrir el archivo ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Guardar la presentación ODP en formato PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Ejemplo en Vivo**
Puedes visitar [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/) aplicación web, que está construida con **Aspose.Slides API.** La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con la API de Aspose.Slides.