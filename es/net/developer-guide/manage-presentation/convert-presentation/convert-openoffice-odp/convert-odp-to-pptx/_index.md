---
title: Convertir ODP a PPTX en .NET
linktitle: ODP a PPTX
type: docs
weight: 10
url: /es/net/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir ODP
- OpenDocument a PPTX
- ODP a PPTX
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Convertir ODP a PPTX con Aspose.Slides para .NET. Ejemplos de código C# limpios, consejos por lotes y resultados de alta calidad—no se necesita PowerPoint."
---

## **Resumen**

Este artículo explica los siguientes temas.

- [C# Convertir ODP a PPTX](#csharp-odp-to-pptx)
- [C# Convertir ODP a PowerPoint](#csharp-odp-to-powerpoint)

## **Conversión de ODP a PPTX**

Aspose.Slides para .NET ofrece la clase Presentation que representa un archivo de presentación. La clase [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) ahora también puede acceder a ODP a través del constructor Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Pasos: Convertir ODP a PPTX en C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Pasos: Convertir ODP a PowerPoint en C#</strong></a>
```c#
// Abrir el archivo ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Guardar la presentación ODP en formato PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Ejemplo en Vivo**

Puede visitar la aplicación web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/), que está construida con **Aspose.Slides API**. La aplicación muestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides funciona de forma independiente y no requiere aplicaciones de terceros para leer o escribir ODP/PPTX.

**¿Se conservan las diapositivas master, los diseños y los temas durante la conversión?**

Sí. La biblioteca utiliza un modelo de objeto de presentación completo y mantiene la estructura, incluidas las diapositivas master y los diseños, de modo que el diseño sigue siendo correcto después de la conversión.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí. Aspose.Slides admite la detección de protección, la apertura y el trabajo con [presentaciones protegidas](/slides/es/net/password-protected-presentation/) (incluido ODP) cuando se proporciona la contraseña, así como la configuración del cifrado y el acceso a las propiedades del documento.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puede usar la biblioteca local en su propio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); ambas opciones admiten la conversión ODP → PPTX.