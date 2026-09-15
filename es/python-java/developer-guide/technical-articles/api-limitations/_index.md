---
title: Limitaciones de la API
type: docs
weight: 320
url: /es/python-java/api-limitations/
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
- Python
- Java
- Aspose.Slides
description: "Aprenda sobre las limitaciones de Aspose.Slides for Python via Java: metadatos fijos de Application, Creator y Producer en archivos PPTX y PDF."
---
## **Descripción general**

Cuando se crean o exportan presentaciones con Aspose.Slides, se escribe cierta metainformación técnica en el archivo de salida. Este artículo explica las limitaciones relacionadas con los campos de metadatos `Application`, `Creator` y `Producer` en archivos PPTX y PDF.

## **Application y Producer**

Al crear o exportar presentaciones con Aspose.Slides for Python via Java, se escribe metainformación técnica en el archivo. Dos campos suelen generar preguntas:

**Application** identifica el programa que creó o guardó por última vez una presentación **PPTX**. En Aspose.Slides for Python via Java, este valor es fijo y muestra el proveedor de la biblioteca en lugar del nombre de tu aplicación, incluso si utilizas [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** identifica el motor de renderizado que generó el archivo final durante la exportación. En exportaciones **PDF**, la metainformación utiliza los campos **Creator** y **Producer**. Con Aspose.Slides for Python via Java, ambos son fijos y reflejan la biblioteca y su versión.

**Qué está restringido**

No puedes sobrescribir estos campos mediante la API para los formatos anteriores. Para **PPTX**, la propiedad Application se escribe como "Aspose.Slides for Java". Para **PDF**, las propiedades Creator y Producer se escriben como "Aspose.Slides for Java x.x.x". Este comportamiento es intencional y se aplica independientemente de cómo cargues o guardes el archivo, y sin importar los valores asignados mediante [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **Preguntas frecuentes**

**¿Puedo reemplazar el valor de Application en un archivo PPTX con el nombre de mi aplicación?**

No. El valor es fijo, incluso si utilizas [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/es/python-java/aspose.slides/documentproperties/#setnameofapplication).

**¿Puedo sobrescribir los campos Creator y Producer en exportaciones PDF?**

No. Ambos campos son fijos y reflejan la biblioteca y su versión, sin importar cómo cargues o guardes la presentación.