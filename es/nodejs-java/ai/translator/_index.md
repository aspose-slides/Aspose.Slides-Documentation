---
title: Traductor de presentaciones impulsado por IA
linktitle: Traductor impulsado por IA
type: docs
weight: 20
url: /es/nodejs-java/ai/translator/
keywords:
- Traductor de presentaciones con IA
- Traductor de diapositivas con IA
- Función impulsada por IA
- Presentación multilingüe
- Diapositiva multilingüe
- Traducción de presentaciones
- Traducción de diapositivas
- Características impulsadas por IA
- Capacidades de IA
- Agente de IA
- Cliente web
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Traduce diapositivas de PowerPoint con IA usando Aspose.Slides para Node.js. Localiza PPT, PPTX y ODP manteniendo el diseño—rápido y fácil para desarrolladores. Pruébalo."
---
## **Introducción**

Aspose.Slides es una API potente para gestionar programáticamente presentaciones de PowerPoint. Además de crear, editar y convertir diapositivas, ofrece características impulsadas por IA, como la API de Traducción de Presentaciones para contenido multilingüe.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA integradas, pero se integra con modelos de IA externos a través de Internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidesaiagent/) para comunicarse con servicios de IA.

Puedes utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/openaiwebclient/) incorporado para conectar con la API de OpenAI.

Aspose.Slides gestiona la comunicación, analiza las respuestas de la IA e inserta inteligentemente el contenido traducido manteniendo el diseño y formato original de la diapositiva.

{{% alert color="info" title="Nota" %}}
Ten en cuenta que la API de OpenAI es un servicio de pago, por lo que deberás crear una cuenta y proporcionar tu clave API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés utilizando el [OpenAIWebClient](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/openaiwebclient/) incorporado con un [modelo](https://platform.openai.com/docs/models) de OpenAI especificado.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Cargar una presentación para traducir.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializar SlidesAIAgent con el cliente de IA.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Traducir la presentación al japonés.
    aiAgent.translate(presentation, "japanese");

    // Guardar la presentación traducida como PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Por defecto, el [OpenAIWebClient](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/openaiwebclient/) crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. Sin embargo, si prefieres gestionar tú mismo la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) —principalmente para configurar ajustes esenciales como un proxy, o para usar una [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para una mejor gestión de recursos y rendimiento— puedes proporcionar tu propia instancia de `HttpURLConnection` al construir el [OpenAIWebClient](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/openaiwebclient/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Crear y preconfigurar una instancia de HttpURLConnection (por ejemplo, con tiempos de espera personalizados, configuración de proxy, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Ejemplo de Azure OpenAI**

Puedes configurar el traductor para que utilice tu despliegue de Azure OpenAI con el [OpenAICompatibleWebClient](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/openaicompatiblewebclient/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Este fragmento muestra cómo traducir una presentación usando tu punto de enlace de Azure OpenAI. Sustituye los valores marcadores de posición por el nombre de tu despliegue, la clave API y la URL del punto de enlace.

## **Ventajas clave**

La API de Traducción de Presentaciones de Aspose.Slides ofrece una solución impulsada por IA para entregar presentaciones de PowerPoint multilingües. Al automatizar la traducción y preservar el diseño y la maquetación, ahorra tiempo y minimiza errores frente a los flujos de trabajo manuales. Tanto si eres desarrollador, educador o profesional empresarial, esta API te permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando tu alcance y mejorando la comunicación.