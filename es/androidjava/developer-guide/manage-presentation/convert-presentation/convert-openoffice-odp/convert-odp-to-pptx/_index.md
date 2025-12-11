---
title: Convertir ODP a PPTX en Android
linktitle: ODP a PPTX
type: docs
weight: 10
url: /es/androidjava/convert-odp-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Convertir ODP a PPTX con Aspose.Slides para Android. Ejemplos de código Java limpios, consejos por lotes y resultados de alta calidad—no se necesita PowerPoint."
---

## **Convertir ODP a Presentación PPTX/PPT**
Aspose.Slides para Android mediante Java ofrece la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que representa un archivo de presentación. La clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) ahora también puede acceder a ODP a través del constructor [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.
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
Puede visitar la aplicación web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) que está construida con **Aspose.Slides API.** La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides funciona de forma independiente y no requiere aplicaciones de terceros para leer o escribir ODP/PPTX.

**¿Se conservan las diapositivas maestras, los diseños y los temas durante la conversión?**

Sí. La biblioteca utiliza un modelo de objetos de presentación completo y mantiene la estructura, incluidas las diapositivas maestras y los diseños, por lo que el diseño permanece correcto después de la conversión.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí. Aspose.Slides admite la detección de protección, la apertura y el trabajo con [presentaciones protegidas](/slides/es/androidjava/password-protected-presentation/) (incluido ODP) cuando se proporciona la contraseña, así como la configuración del cifrado y el acceso a las propiedades del documento.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puede utilizar la biblioteca local en su propio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); ambas opciones admiten la conversión ODP → PPTX.