---
title: Problemas Conocidos en Aspose.Slides para Android a través de Java 14.3.0
type: docs
weight: 20
url: /androidjava/known-issues-in-aspose-slides-for-java-14-3-0/
---

Aspose.Slides para Android a través de Java 14.3.0 (14.4.0) proporciona una implementación completamente nueva del procesamiento de PPT. Hay muchas mejoras, conversión parcial de PPTX a PPT. Pero hay algunas características no implementadas:

- Algunas formas tienen geometría incorrecta en documentos PPT serializados (Llamadas)
- No todas las características de formato de texto de PPTX son compatibles con la serialización de PPT
- La información sobre el idioma del texto y la configuración de ortografía no está presente en los documentos PPT serializados
- No todas las características de los temas de PPTX son compatibles con la serialización de PPT

**Hay algunas diferencias en comparación con Aspose.Slides para Android a través de Java 8.6.0:**

- Hay problemas conocidos en la serialización OLE/ActiveX de PPT a PPT

**Hay algunas diferencias en comparación con Aspose.Slides para .NET 14.3.0:**

- El soporte para impresión de presentaciones no está disponible en Aspose.Slides para Android a través de Java