---
title: Problemas conocidos en Aspose.Slides for Java 14.4.0
type: docs
weight: 30
url: /es/java/known-issues-in-aspose-slides-for-java-14-4-0/
keywords:
- problema conocido
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise los problemas conocidos en Aspose.Slides for Java 14.4.0 para garantizar un trabajo preciso con archivos PowerPoint y OpenDocument y evitar sorpresas en sus presentaciones."
---
{{% alert color="info" %}}

Aspose.Slides for Java 14.4.0 ofrece una nueva solución para el procesamiento de documentos PowerPoint. Existen algunas restricciones y problemas conocidos, que se eliminarán en próximas versiones:

- Algunas formas tienen geometría incorrecta en los documentos PPT serializados (arco, flecha circular, cuadros de llamada).
- No todas las funciones de formato de texto de PPTX son compatibles en la serialización a PPT (tabulaciones, sangrías y limitaciones de formato de párrafo).
- La información sobre el idioma del texto y la configuración de ortografía no está presente en los documentos PPT serializados.
- No todas las funciones de temas de PPTX son compatibles en la serialización a PPT (solo se serializan los formatos de relleno, formatos de línea y fuentes).
- Existen problemas conocidos en la serialización OLE/ActiveX de PPT a PPT.
- La serialización y el renderizado de WordArt no son compatibles.

{{% /alert %}}