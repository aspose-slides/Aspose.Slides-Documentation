---
title: Convertir ODP a PPTX en Java
linktitle: ODP a PPTX
type: docs
weight: 10
url: /es/java/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir presentación
- convertir diapositiva
- convertir ODP
- OpenDocument a PPTX
- ODP a PPTX
- guardar ODP como PPTX
- exportar ODP a PPTX
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Convertir ODP a PPTX con Aspose.Slides para Java. Ejemplos de código Java claros, consejos por lotes y resultados de alta calidad—no se necesita PowerPoint."
---

## **Convertir ODP a presentación PPTX/PPT**
Aspose.Slides para Java ofrece la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que representa un archivo de presentación. La clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) ahora también puede acceder a ODP a través del constructor [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#Presentation-java.lang.String-) cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una Presentación ODP en una Presentación PPTX.
```java
// Abrir el archivo ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Guardar la presentación ODP en formato PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ejemplo en vivo**
Puede visitar la aplicación web **[Aspose.Slides Conversion](https://products.aspose.app/slides/conversion/)**, que está construida con **Aspose.Slides API**. La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.