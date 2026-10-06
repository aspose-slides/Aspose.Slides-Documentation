---
title: Limitaciones de la metadata de salida
type: docs
weight: 320
url: /es/java/api-limitations/
keywords:
- Limitaciones de la API
- formato de exportación
- aplicación
- productor
- propiedades del documento
- metadatos
- generador
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aspose.Slides for Java escribe metadatos fijos de aplicación, creador y productor en los archivos PPTX, PDF y ODP guardados, sea cual sea el nombre de aplicación que establezca."
---
## **Descripción general**

Cuando se crean o exportan presentaciones con Aspose.Slides, se escribe cierta metadata técnica en el archivo de salida. Este artículo explica las limitaciones relacionadas con los campos de metadata `Application`, `Creator`, `Producer` y generator en archivos PPTX, PDF y ODP.

## **Application y Producer**

Cuando crea o exporta presentaciones con Aspose.Slides for Java, se escribe alguna metadata técnica en el archivo. Dos campos suelen generar preguntas:

**Application** identifica el programa que creó o guardó por última vez una presentación **PPTX**. En Aspose.Slides for Java, este valor es fijo y muestra el nombre de la biblioteca en lugar del nombre de su aplicación, incluso si utiliza [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/es/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifica el motor de renderizado que generó el archivo final durante la exportación. En exportaciones **PDF**, la metadata utiliza los campos **Creator** y **Producer**. Con Aspose.Slides for Java, ambos son fijos y reflejan la biblioteca y su versión.

**Qué está restringido**

No puede sobrescribir estos campos a través de la API para los formatos anteriores. Para **PPTX**, la propiedad Application se escribe como "Aspose.Slides for Java". Para **PDF**, las propiedades Creator y Producer se escriben como "Aspose.Slides for Java" seguidas de la versión de la biblioteca. Para **ODP**, el campo generator se escribe como "Aspose.Slides for Java" seguido de la versión de la biblioteca. Este comportamiento es intencional y se aplica independientemente de cómo cargue o guarde el archivo, y sin importar los valores asignados mediante [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/es/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Esta restricción no se aplica a los archivos **PPT**: en un archivo PPT, el nombre de la aplicación que establezca con [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/es/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) se guarda.