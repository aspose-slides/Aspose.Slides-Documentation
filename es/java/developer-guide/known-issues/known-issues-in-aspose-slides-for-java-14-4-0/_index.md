---
title: Problemas conocidos en Aspose.Slides para Java 14.4.0
type: docs
weight: 30
url: /java/known-issues-in-aspose-slides-for-java-14-4-0/
---

{{% alert color="primary" %}} 

Aspose.Slides para Java 14.4.0 proporciona una nueva decisión para el procesamiento de documentos de PowerPoint. Hay algunas restricciones y problemas conocidos, que se eliminarán en próximas versiones:

- Algunas formas tienen geometría incorrecta en documentos PPT serializados (arco, flecha circular, llamadas).
- No todas las características de formato de texto de PPTX son compatibles con la serialización de PPT (tabulación, sangría y limitaciones de formato de párrafo).
- La información sobre el idioma del texto y las configuraciones de ortografía no están presentes en los documentos PPT serializados.
- No todas las características del tema de PPTX son compatibles con la serialización de PPT (solo la serialización de formatos de relleno, formatos de línea y fuente).
- Existen problemas conocidos en la serialización de OLE/ActiveX de PPT a PPT.
- La serialización y renderización de WordArt no son compatibles.

{{% /alert %}}