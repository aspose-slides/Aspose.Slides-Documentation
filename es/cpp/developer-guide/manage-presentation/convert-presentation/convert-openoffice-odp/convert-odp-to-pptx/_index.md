---
title: Convertir ODP a PPTX en C++
linktitle: ODP a PPTX
type: docs
weight: 10
url: /es/cpp/convert-odp-to-pptx/
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
- C++
- Aspose.Slides
description: "Convertir ODP a PPTX con Aspose.Slides para C++. Ejemplos de código claros, consejos por lotes y resultados de alta calidad—no se necesita PowerPoint."
---

## **Conversión de ODP a PPTX**

Aspose.Slides para .NET ofrece la clase Presentation que representa un archivo de presentación. La clase [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ahora también puede acceder a ODP a través del constructor Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.
``` cpp
// La ruta al directorio de documentos.
String dataDir = GetDataPath();

// Abrir el archivo ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Guardar la presentación ODP en formato PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Ejemplo en vivo**

Puede visitar la aplicación web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) construida con **Aspose.Slides API.** La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides funciona de forma independiente y no requiere aplicaciones de terceros para leer o escribir ODP/PPTX.

**¿Se conservan las diapositivas maestras, los diseños y los temas durante la conversión?**

Sí. La biblioteca utiliza un modelo de objetos de presentación completo y conserva la estructura, incluidas las diapositivas maestras y los diseños, de modo que el diseño permanece correcto después de la conversión.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí. Aspose.Slides admite la detección de protección, la apertura y el trabajo con [presentaciones protegidas](/slides/es/cpp/password-protected-presentation/) (incluido ODP) cuando se proporciona la contraseña, así como la configuración de cifrado y el acceso a las propiedades del documento.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puede usar la biblioteca local en su propio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); ambas opciones admiten la conversión ODP → PPTX.