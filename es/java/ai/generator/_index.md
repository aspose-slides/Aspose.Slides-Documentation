---
title: Generador de Diapositivas Multilingüe con IA
linktitle: Generador con IA
type: docs
weight: 40
url: /es/java/ai/generator/
keywords:
- presentación multilingüe
- diapositiva multilingüe
- generador de presentaciones con IA
- generador de diapositivas con IA
- funcionalidad impulsada por IA
- agente de IA
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Genere diapositivas multilingües a partir de texto con Aspose.Slides para Java. Aplique su plantilla y exporte presentaciones pulidas a PowerPoint y OpenDocument. Aprenda más."
---

## **Aspose.Slides Presentation AI API: Generador de Diapositivas con IA**

Aspose.Slides introduce una nueva función impulsada por IA, el Generador de Presentaciones, que permite a los desarrolladores crear automáticamente presentaciones de PowerPoint bien estructuradas a partir de entradas de texto simples, como descripciones de temas, resúmenes, citas o viñetas.

Los usuarios pueden ajustar el nivel de detalle del contenido y, opcionalmente, aplicar una plantilla de presentación personalizada para definir el diseño visual.

Actualmente, el Generador de Presentaciones con IA organiza el contenido usando bloques de texto, listas con viñetas y tablas. La generación de imágenes aún no es compatible; sin embargo, las imágenes pueden añadirse fácilmente después utilizando las herramientas de Aspose.Slides o manualmente.

El resultado es una presentación de PowerPoint completa que puede usarse tal cual o exportarse a cualquier formato compatible con la API de Aspose.Slides. Aunque el generador produce resultados de alta calidad, puede ser necesario realizar una pequeña edición posterior para cumplir con requisitos específicos.

## **Cómo funciona**

Aspose.Slides no incluye modelos de IA incorporados; en su lugar, se integra con servicios de IA externos a través de Internet. Esta integración la maneja la clase [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/), que utiliza una implementación de la interfaz [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) para comunicarse con el modelo de IA.

Puede utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) incorporado, que se conecta a la API de OpenAI, o proporcionar una implementación personalizada de [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) para trabajar con otro proveedor de IA o modelo de lenguaje. Aspose.Slides gestiona toda la comunicación con el servicio de IA y procesa las respuestas de la IA para generar diapositivas. Tenga en cuenta que la API de OpenAI es un servicio de pago, por lo que se requiere una cuenta y una clave de API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) incorporado.

## **Vamos a programar**

### **Ejemplo 1**

Este ejemplo muestra cómo generar una presentación sobre el tema Aspose.Slides utilizando el [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) incorporado.
```java
// Crear una instancia de OpenAIWebClient, la implementación incorporada del cliente web OpenAI.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Crear una instancia de SlidesAIAgent, que brinda acceso a funciones impulsadas por IA.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definir la instrucción para generar la presentación.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Generar una presentación con una cantidad media de contenido basada en la instrucción.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Guardar la presentación generada en el disco local como un archivo PowerPoint (.pptx) file.
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


### **Ejemplo 2**

El siguiente ejemplo muestra las sobrecargas del método [generatePresentation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). En este caso, se utilizan una instancia de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gestionada externamente y la `presentación maestra` del usuario.

De forma predeterminada, el [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) incorporado crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. Sin embargo, si prefiere gestionar la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) usted mismo—por ejemplo, al usar un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) para una mejor gestión de recursos y rendimiento—puede proporcionar su propia instancia de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) al construir el [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/).
```java
// Pasar el HttpURLConnection al constructor de OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Crear una instancia de SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definir la instrucción para generar la presentación.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Cargar una presentación maestra del disco local para usarla como plantilla de diseño.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Generar una presentación detallada usando la instrucción y la plantilla maestra.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Guardar la presentación generada como PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


## **Beneficios clave**

El nuevo Generador de Presentaciones con IA en Aspose.Slides ofrece una forma rápida y flexible de producir conjuntos de diapositivas estructurados a partir de simples indicaciones de texto. Con soporte para plantillas personalizadas e instancias de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) gestionadas externamente, puede integrarse sin problemas en una amplia gama de aplicaciones.

Los casos de uso típicos incluyen la creación de presentaciones de marketing, materiales educativos, informes para clientes y conjuntos de diapositivas internos. Aunque la generación de imágenes aún no es compatible, la herramienta ya ofrece una base sólida para automatizar la creación de presentaciones, y se esperan mejoras adicionales en el futuro.