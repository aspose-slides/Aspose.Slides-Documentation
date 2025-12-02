---
title: Limitaciones de API
type: docs
weight: 320
url: /es/nodejs-java/api-limitations/
keywords:
- Limitaciones de API
- Formato de exportación
- Aplicación
- Productor
- Propiedades del documento
- Metadatos
- PowerPoint
- OpenDocument
- Presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Conozca los límites de Aspose.Slides for Node.js: las exportaciones establecen metadatos fijos de Application/Producer en PPT, PPTX, ODP y PDF, lo que le ayuda a planificar integraciones sin sorpresas."
---

## **Aplicación y Productor**

Cuando crea o exporta presentaciones con Aspose.Slides for Node.js via Java, se escribe metadatos técnicos en el archivo. Dos campos suelen generar preguntas:

**Application** identifica el programa que creó o guardó por última vez una presentación **PPTX**. En Aspose.Slides for Node.js via Java, este valor es fijo y muestra el proveedor de la biblioteca en lugar del nombre de su aplicación, incluso si usa [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifica el motor de renderizado que generó el archivo final durante la exportación. En exportaciones **PDF**, los metadatos usan los campos **Creator** y **Producer**. Con Aspose.Slides for Node.js via Java, ambos están fijos y reflejan la biblioteca y su versión.

**Qué está restringido**

No puede sobrescribir estos campos a través de la API para los formatos anteriores. Para **PPTX**, la propiedad Application se escribe como "Aspose.Slides for Node.js via Java". Para **PDF**, las propiedades Creator y Producer se escriben como "Aspose.Slides for Node.js via Java x.x.x." Este comportamiento es intencional y se aplica sin importar cómo cargue o guarde el archivo, y sin importar los valores asignados usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).