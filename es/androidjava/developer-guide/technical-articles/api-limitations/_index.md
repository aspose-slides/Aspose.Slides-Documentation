---
title: Limitaciones de la API
type: docs
weight: 320
url: /es/androidjava/api-limitations/
keywords:
- Limitaciones de la API
- Formato de exportación
- Aplicación
- Productor
- Propiedades del documento
- Metadatos
- PowerPoint
- OpenDocument
- Presentación
- Android
- Java
- Aspose.Slides
description: "Conozca los límites de Aspose.Slides para Android: las exportaciones establecen metadatos fijos de Application/Producer en PPT, PPTX, ODP y PDF, lo que le ayuda a planificar integraciones sin sorpresas."
---

## **Aplicación y Productor**

Cuando crea o exporta presentaciones con Aspose.Slides for Android via Java, se escribe metadata técnica en el archivo. Dos campos suelen generar preguntas:

**Application** identifica el programa que creó o guardó por última vez una presentación **PPTX**. En Aspose.Slides for Android via Java, este valor es fijo y muestra el proveedor de la biblioteca en lugar del nombre de su aplicación, incluso si usa [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifica el motor de renderizado que generó el archivo final durante la exportación. En exportaciones **PDF**, la metadata usa los campos **Creator** y **Producer**. Con Aspose.Slides for Android via Java, ambos están fijos y reflejan la biblioteca y su versión.

**Qué está restringido**

No puede sobrescribir estos campos a través de la API para los formatos anteriores. Para **PPTX**, la propiedad Application se escribe como "Aspose.Slides for Android via Java". Para **PDF**, las propiedades Creator y Producer se escriben como "Aspose.Slides for Android via Java x.x.x." Este comportamiento es intencional y se aplica independientemente de cómo cargue o guarde el archivo, y sin importar los valores asignados mediante [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).