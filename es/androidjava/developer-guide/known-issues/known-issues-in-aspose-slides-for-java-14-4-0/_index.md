---
title: Problemas Conocidos en Aspose.Slides para Android a través de Java 14.4.0
type: docs
weight: 30
url: /es/androidjava/known-issues-in-aspose-slides-for-java-14-4-0/
---

{{% alert color="primary" %}} 

Aspose.Slides para Android a través de Java 14.4.0 proporciona una nueva decisión para el procesamiento de documentos de PowerPoint. Hay algunas restricciones y problemas conocidos, que se eliminarán en próximas versiones:

- Algunas formas tienen geometría incorrecta en documentos PPT serializados (arco, flecha circular, llamadas).
- No se admiten todas las características de formato de texto PPTX en la serialización PPT (tabulación, sangría y limitaciones de formato de párrafo).
- La información sobre el idioma del texto y la configuración de ortografía no está presente en documentos PPT serializados.
- No se admiten todas las características de tema PPTX en la serialización PPT (solo la serialización de formatos de relleno, formatos de línea y fuente).
- Hay problemas conocidos en la serialización OLE/ActiveX de PPT a PPT.
- La serialización y renderizado de WordArt no están soportados.

{{% /alert %}}