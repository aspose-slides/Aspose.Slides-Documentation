---
title: Limitaciones de API
type: docs
weight: 320
url: /es/cpp/api-limitations/
keywords:
- Limitaciones de API
- formato de exportación
- aplicación
- productor
- propiedades del documento
- metadatos
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Conozca los límites de Aspose.Slides for C++: las exportaciones establecen metadatos fijos de Application/Producer en PPT, PPTX, ODP y PDF, lo que le ayuda a planificar integraciones sin sorpresas."
---

## **Aplicación y Productor**

Al crear o exportar presentaciones con Aspose.Slides for C++, se escribe alguna metainformación técnica en el archivo. Dos campos suelen generar preguntas:

**Application** identifica el programa que creó o guardó por última vez una presentación **PPTX**. En Aspose.Slides for C++, este valor es fijo y muestra el proveedor de la biblioteca en lugar del nombre de su aplicación, incluso si usa [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identifica el motor de renderizado que generó el archivo final durante la exportación. En exportaciones **PDF**, la metainformación usa los campos **Creator** y **Producer**. Con Aspose.Slides for C++, ambos están fijos y reflejan la biblioteca y su versión.

**Qué está restringido**

No puede sobrescribir estos campos mediante la API para los formatos anteriores. Para **PPTX**, la propiedad Application se escribe como "Aspose.Slides for C++". Para **PDF**, las propiedades Creator y Producer se escriben como "Aspose.Slides for C++ x.x.x". Este comportamiento es intencional y se aplica independientemente de cómo cargue o guarde el archivo, y sin importar los valores asignados usando [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).