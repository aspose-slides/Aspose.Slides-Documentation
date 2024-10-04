---
title: Problemas Conocidos en Aspose.Slides para PHP a través de Java 14.4.0
type: docs
weight: 30
url: /php-java/known-issues-in-aspose-slides-for-java-14-4-0/
---

{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java 14.4.0 proporciona una nueva decisión para el procesamiento de documentos de PowerPoint. Existen algunas restricciones y problemas conocidos, que serán eliminados en próximas versiones:

- Algunas formas tienen geometría incorrecta en los documentos PPT serializados (arco, flecha circular, llamadas).
- No todas las funciones de formato de texto de PPTX son compatibles en la serialización de PPT (tabulación, sangría y limitaciones de formato de párrafo).
- No hay información sobre el idioma del texto y la configuración de ortografía en los documentos PPT serializados.
- No se admiten todas las funciones de tema de PPTX en la serialización de PPT (solo serialización de formatos de relleno, formatos de línea y fuente).
- Hay problemas conocidos en la serialización OLE/ActiveX de PPT a PPT.
- La serialización y representación de WordArt no son compatibles.

{{% /alert %}}