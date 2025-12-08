---
title: Convertir ODP a PPTX en Python
linktitle: ODP a PPTX
type: docs
weight: 10
url: /es/python-net/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir ODP
- OpenDocument a PPTX
- ODP a PPTX
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Convertir ODP a PPTX con Aspose.Slides para Python a través de .NET. Ejemplos de código claros, consejos para procesamiento por lotes y resultados de alta calidad—no se necesita PowerPoint."
---

## **Exportar ODP a PPTX**

Aspose.Slides para Python a través de .NET ofrece la clase **Presentation** que representa un archivo de presentación. La clase [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ahora también puede acceder a ODP a través del constructor Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.
```py
# Importar el módulo Aspose.Slides para Python a través de .NET
import aspose.slides as slides

# Abrir el archivo ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Guardar la presentación ODP en formato PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Ejemplo en vivo**

Puede visitar la aplicación web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), que está construida con **Aspose.Slides API**. La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides funciona de manera independiente y no requiere aplicaciones de terceros para leer o escribir ODP/PPTX.

**¿Se conservan las diapositivas maestras, los diseños y los temas durante la conversión?**

Sí. La biblioteca utiliza un modelo de objetos de presentación completo y conserva la estructura, incluidas las diapositivas maestras y los diseños, de modo que el diseño sigue siendo correcto después de la conversión.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí. Aspose.Slides admite la detección de protección, la apertura y el trabajo con [presentaciones protegidas](/slides/es/python-net/password-protected-presentation/) (incluido ODP) cuando se proporciona la contraseña, además de permitir la configuración del cifrado y el acceso a las propiedades del documento.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puede utilizar la biblioteca local en su propio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); ambas opciones admiten la conversión ODP → PPTX.