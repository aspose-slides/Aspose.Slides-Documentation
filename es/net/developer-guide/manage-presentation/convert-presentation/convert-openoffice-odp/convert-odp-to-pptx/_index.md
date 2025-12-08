---
title: Convertir ODP a PPTX en C#
linktitle: Convertir ODP a PPTX
type: docs
weight: 10
url: /es/net/convert-odp-to-pptx/
keywords: "Convertir Presentación de OpenOffice, ODP, ODP a PPTX, C#, Csharp, .NET"
description: "Convertir ODP de OpenOffice a Presentación PowerPoint PPTX en C# o .NET"
---

## **Descripción general**

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

// Guardando la presentación ODP en formato PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **Ejemplo en vivo**

Puede visitar la aplicación web [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/) que está construida con **Aspose.Slides API**. La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides funciona de forma independiente y no requiere aplicaciones de terceros para leer o escribir ODP/PPTX.

**¿Se conservan las diapositivas maestras, diseños y temas durante la conversión?**

Sí. La biblioteca utiliza un modelo de objeto de presentación completo y mantiene la estructura, incluidas las diapositivas maestras y los diseños, de modo que el diseño permanece correcto después de la conversión.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí. Aspose.Slides admite la detección de protección, la apertura y el trabajo con [presentaciones protegidas](/slides/es/net/password-protected-presentation/) (incluidos ODP) cuando se proporciona la contraseña, así como la configuración del cifrado y el acceso a las propiedades del documento.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puede usar la biblioteca local en su propio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); ambas opciones admiten la conversión ODP → PPTX.