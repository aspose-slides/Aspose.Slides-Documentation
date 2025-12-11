---
title: Traductor de Presentaciones impulsado por IA
linktitle: Traductor con IA
type: docs
weight: 20
url: /es/androidjava/ai/translator/
keywords:
- traductor de presentación con IA
- traductor de diapositiva con IA
- característica impulsada por IA
- presentación multilingüe
- diapositiva multilingüe
- traducción de presentación
- traducción de diapositiva
- características impulsadas por IA
- capacidades de IA
- agente de IA
- cliente web
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Traduce diapositivas de PowerPoint con IA usando Aspose.Slides para Android vía Java. Localiza PPT, PPTX y ODP mientras preservas el diseño—rápido y fácil para desarrolladores. Pruébalo."
---

## **Aspose.Slides API de Traducción de Presentaciones: Traducción Multilingüe de Diapositivas impulsada por IA**

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA integradas, pero se integra con modelos de IA externos a través de internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) , que utiliza una implementación de la interfaz [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) para comunicarse con los servicios de IA.

Puede usar el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado para conectarse a la API de OpenAI o implementar su propio [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) para usar un proveedor de IA diferente o un modelo de lenguaje distinto.

Aspose.Slides gestiona la comunicación, analiza las respuestas de la IA e inserta inteligentemente el contenido traducido mientras preserva el diseño y el formato original de la diapositiva.

{{% alert color="primary" %}}
Nota que la API de OpenAI es un servicio de pago, por lo que necesitará crear una cuenta y proporcionar su clave API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado.
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés usando el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado con un [modelo](https://platform.openai.com/docs/models) de OpenAI especificado.
```java
// Cargar una presentación para traducir.
Presentation presentation = new Presentation("sample.pptx");

// Crear un cliente de IA con OpenAIWebClient, especificando tu modelo y clave API.
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


Por defecto, el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) incorporado crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. Sin embargo, si prefiere gestionar el [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) usted mismo —por ejemplo, para configurar ajustes esenciales como un proxy, o para usar un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para una mejor gestión de recursos y rendimiento— puede proporcionar su propia instancia `HttpURLConnection` al crear el [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/).
```java
// Supón que tienes una instancia HttpURLConnection preconfigurada (p.ej., con tiempos de espera personalizados, configuraciones de proxy, etc.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Beneficios clave**

El Aspose.Slides API de Traducción de Presentaciones ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción mientras preserva el diseño y la estética, ahorra tiempo y minimiza errores en comparación con los flujos de trabajo manuales. Tanto si es desarrollador, educador o profesional de negocios, esta API le permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando su alcance y mejorando la comunicación.