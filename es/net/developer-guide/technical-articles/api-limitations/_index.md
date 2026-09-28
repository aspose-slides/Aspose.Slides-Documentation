---
title: Limitaciones de metadatos de salida
type: docs
weight: 320
url: /es/net/api-limitations/
keywords:
- Limitaciones de API
- Formato de exportación
- Aplicación
- Productor
- Propiedades del documento
- Metadatos
- Generador
- PowerPoint
- OpenDocument
- Presentación
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET escribe metadatos fijos de aplicación, creador y productor en los archivos PPTX, PDF y ODP guardados, sin importar el nombre de aplicación que establezca."
---
## **Resumen**

Cuando se crean o exportan presentaciones con Aspose.Slides, se escribe cierta metadata técnica en el archivo de salida. Este artículo explica las limitaciones relacionadas con los campos de metadata `Application`, `Creator`, `Producer` y generator en archivos PPTX, PDF y ODP.

## **Aplicación y Productor**

Cuando crea o exporta presentaciones con Aspose.Slides para .NET, se escribe cierta metadata técnica en el archivo. Dos campos suelen generar preguntas:

**Application** identifica el programa que creó o guardó por última vez una presentación **PPTX**. En Aspose.Slides para .NET, este valor es fijo y muestra el nombre de la biblioteca en lugar del nombre de su aplicación, incluso si establece [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/es/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifica el motor de renderizado que generó el archivo final durante la exportación. En exportaciones **PDF**, la metadata utiliza los campos **Creator** y **Producer**. Con Aspose.Slides para .NET, ambos son fijos y reflejan la biblioteca y su versión.

**Qué está restringido**

No puede sobrescribir estos campos a través de la API para los formatos anteriores. Para **PPTX**, la propiedad Application se escribe como "Aspose.Slides for .NET". Para **PDF**, las propiedades Creator y Producer se escriben como "Aspose.Slides for .NET" seguido de la versión de la biblioteca. Para **ODP**, el campo generator se escribe como "Aspose.Slides for .NET" seguido de la versión de la biblioteca. Este comportamiento es intencional y se aplica independientemente de cómo cargue o guarde el archivo, y sin importar los valores asignados a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/es/net/aspose.slides/documentproperties/nameofapplication/).

Esta restricción no se aplica a archivos **PPT**: en un archivo PPT, el nombre de la aplicación que establezca en [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/es/net/aspose.slides/documentproperties/nameofapplication/) se guarda.