---
title: Limitaciones de la API
type: docs
weight: 320
url: /es/net/api-limitations/
keywords:
- Limitaciones de la API
- formato de exportación
- aplicación
- productor
- propiedades del documento
- metadatos
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Conozca los límites de Aspose.Slides for .NET: las exportaciones establecen metadatos fijos de Application/Producer en PPT, PPTX, ODP y PDF, lo que le ayuda a planificar integraciones sin sorpresas."
---

## **Aplicación y Productor**

Cuando crea o exporta presentaciones con Aspose.Slides for .NET, se escribe metadata técnica en el archivo. Dos campos suelen generar preguntas:

**Application** identifica el programa que creó o guardó por última vez una presentación **PPTX**. En Aspose.Slides for .NET, este valor es fijo y muestra el proveedor de la biblioteca en lugar del nombre de su aplicación, incluso si establece [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifica el motor de renderizado que generó el archivo final durante la exportación. En exportaciones **PDF**, la metadata utiliza los campos **Creator** y **Producer**. Con Aspose.Slides for .NET, ambos son fijos y reflejan la biblioteca y su versión.

**Qué está restringido**

No puede sobrescribir estos campos mediante la API para los formatos anteriores. Para **PPTX**, la propiedad Application se escribe como "Aspose.Slides for .NET". Para **PDF**, las propiedades Creator y Producer se escriben como "Aspose.Slides for .NET x.x.x". Este comportamiento es intencional y se aplica independientemente de cómo cargue o guarde el archivo, y sin importar los valores asignados a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).
