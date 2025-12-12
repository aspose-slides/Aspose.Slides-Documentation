---
title: Traductor de presentaciones con IA
linktitle: Traductor con IA
type: docs
weight: 20
url: /es/androidjava/ai/translator/
keywords:
- Traductor de presentaciones con IA
- Traductor de diapositivas con IA
- Funcionalidad impulsada por IA
- Presentación multilingüe
- Diapositiva multilingüe
- Traducción de presentaciones
- Traducción de diapositivas
- Funcionalidades impulsadas por IA
- Capacidades de IA
- Agente de IA
- Cliente web
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Traduzca diapositivas de PowerPoint con IA usando Aspose.Slides para Android mediante Java. Localice PPT, PPTX y ODP mientras conserva el diseño, rápido y amigable para desarrolladores. Pruébelo."
---

## **API de Traducción de Presentaciones de Aspose.Slides: Traducción Multilingüe de Diapositivas con IA**

Aspose.Slides es una API potente para gestionar programáticamente presentaciones de PowerPoint. Además de crear, editar y convertir diapositivas, ofrece funcionalidades impulsadas por IA, como la API de Traducción de Presentaciones para contenido multilingüe de diapositivas.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA incorporadas, pero se integra con modelos de IA externos a través de internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) que utiliza una implementación de la interfaz [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) para comunicarse con los servicios de IA.

Puedes usar el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado para conectarte a la API de OpenAI o implementar tu propio [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) para utilizar un proveedor de IA diferente o un modelo de lenguaje distinto.

Aspose.Slides gestiona la comunicación, analiza las respuestas de IA e inserta de forma inteligente el contenido traducido, preservando el diseño y el formato original de la diapositiva.

{{% alert color="primary" %}}
Ten en cuenta que la API de OpenAI es un servicio de pago, por lo que deberás crear una cuenta y proporcionar tu clave API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado.
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés utilizando el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado con un [modelo](https://platform.openai.com/docs/models) de OpenAI especificado.
```java
// Cargar una presentación para traducir.
Presentation presentation = new Presentation("sample.pptx");

// Crear un cliente de IA con OpenAIWebClient, especificando su modelo y clave API.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializar SlidesAIAgent con el cliente de IA.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Traducir la presentación al japonés.
    aiAgent.translate(presentation, "japanese");

    // Guardar la presentación traducida como PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


De forma predeterminada, el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. Sin embargo, si prefieres gestionar tú mismo la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) — principalmente para configurar ajustes esenciales como un proxy, o para usar un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para una mejor gestión de recursos y rendimiento — puedes proporcionar tu propia instancia `HttpURLConnection` al construir el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
```java
// Suponga que tiene una instancia de HttpURLConnection preconfigurada (p.ej., con tiempos de espera personalizados, configuración de proxy, etc.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Beneficios clave**

La API de Traducción de Presentaciones de Aspose.Slides ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción y preservar el diseño y la maquetación, ahorra tiempo y minimiza errores en comparación con los flujos de trabajo manuales. Ya seas desarrollador, educador o profesional de negocios, esta API te permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando tu alcance y mejorando la comunicación.