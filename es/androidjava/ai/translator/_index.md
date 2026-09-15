---
title: Traductor de Presentaciones impulsado por IA
linktitle: Traductor impulsado por IA
type: docs
weight: 20
url: /es/androidjava/ai/translator/
keywords:
- traductor de presentaciones IA
- traductor de diapositivas IA
- característica impulsada por IA
- presentación multilingüe
- diapositiva multilingüe
- traducción de presentaciones
- traducción de diapositivas
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
description: "Traduce diapositivas de PowerPoint con IA usando Aspose.Slides para Android mediante Java. Localiza PPT, PPTX y ODP manteniendo el diseño—rápido y fácil para desarrolladores. Pruébalo."
---
## **Introducción**

Aspose.Slides es una API potente para gestionar programáticamente presentaciones de PowerPoint. Además de crear, editar y convertir diapositivas, ofrece funciones impulsadas por IA, como la API de Traducción de Presentaciones para contenido de diapositivas multilingüe.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA integradas, pero se integra con modelos de IA externos a través de Internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidesaiagent/), que utiliza una implementación de la interfaz [IAIWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iaiwebclient/) para comunicarse con los servicios de IA.

Puedes usar el [OpenAIWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/openaiwebclient/) incorporado para conectar con la API de OpenAI o implementar tu propio [IAIWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iaiwebclient/) para usar un proveedor de IA diferente o un modelo de lenguaje distinto.

Aspose.Slides gestiona la comunicación, analiza las respuestas de la IA e inserta de forma inteligente el contenido traducido mientras preserva el diseño y el formato original de la diapositiva.

{{% alert color="info" title="Note" %}}
Ten en cuenta que la API de OpenAI es un servicio de pago, por lo que necesitarás crear una cuenta y proporcionar tu clave API al utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés usando el [OpenAIWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/openaiwebclient/) incorporado con un [modelo](https://platform.openai.com/docs/models) de OpenAI especificado.

```java
import com.aspose.slides.*;

// Cargar una presentación para traducir.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
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

De forma predeterminada, el [OpenAIWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/openaiwebclient/) incorporado crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. Sin embargo, si prefieres gestionar tú mismo la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) —principalmente para configurar ajustes esenciales como un proxy, o para utilizar una [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para una mejor gestión de recursos y rendimiento— puedes proporcionar tu propia instancia `HttpURLConnection` al construir el [OpenAIWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Configura una instancia de HttpURLConnection tú mismo (por ejemplo, con tiempos de espera personalizados, ajustes de proxy, etc.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Pasa la conexión al constructor de OpenAIWebClient.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Ejemplo Azure OpenAI**

Puedes configurar el traductor para que use tu implementación de Azure OpenAI con el [OpenAICompatibleWebClient](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/openaicompatiblewebclient/).

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Este fragmento muestra cómo traducir una presentación usando tu endpoint de Azure OpenAI. Sustituye los valores de marcador de posición por el nombre de tu implementación, la clave API y la URL del endpoint.

## **Ventajas clave**

La API de Traducción de Presentaciones de Aspose.Slides ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción mientras se preserva el diseño y la maquetación, ahorra tiempo y minimiza errores en comparación con los flujos de trabajo manuales. Tanto si eres desarrollador, educador o profesional empresarial, esta API te permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando tu alcance y mejorando la comunicación.