---
title: Traductor de presentaciones impulsado por IA
linktitle: Traductor impulsado por IA
type: docs
weight: 20
url: /es/java/ai/translator/
keywords:
- traductor de presentaciones con IA
- traductor de diapositivas con IA
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
- Java
- Aspose.Slides
description: "Traduzca diapositivas de PowerPoint con IA usando Aspose.Slides para Java. Localice PPT, PPTX y ODP preservando el diseño—rápido y fácil para desarrolladores. Pruébelo."
---
## **Introducción**

Aspose.Slides es una API potente para gestionar programáticamente presentaciones de PowerPoint. Además de crear, editar y convertir diapositivas, ofrece funciones impulsadas por IA, como la API de Traducción de Presentaciones para contenido multilingüe de diapositivas.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA integradas, pero se integra con modelos de IA externos a través de Internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidesaiagent/), que utiliza una implementación de la interfaz [IAIWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaiwebclient/) para comunicarse con los servicios de IA.

Puede utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/openaiwebclient/) incorporado para conectar con la API de OpenAI o implementar su propio [IAIWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/iaiwebclient/) para usar un proveedor de IA o modelo de lenguaje diferente.

Aspose.Slides gestiona la comunicación, analiza las respuestas de la IA e inserta de forma inteligente el contenido traducido mientras conserva el diseño y formato original de la diapositiva.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que la API de OpenAI es un servicio de pago, por lo que deberá crear una cuenta y proporcionar su clave API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés utilizando el [OpenAIWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/openaiwebclient/) incorporado con un [modelo](https://platform.openai.com/docs/models) de OpenAI especificado.

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

Por defecto, el [OpenAIWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/openaiwebclient/) incorporado crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. Sin embargo, si prefiere gestionar la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) usted mismo — principalmente para configurar ajustes esenciales como un proxy, o para usar una [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para una mejor gestión de recursos y rendimiento — puede proporcionar su propia instancia `HttpURLConnection` al crear el [OpenAIWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Configure una instancia de HttpURLConnection usted mismo (tiempos de espera personalizados, configuración de proxy, etc.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Ejemplo de Azure OpenAI**

Puede configurar el traductor para que utilice su implementación de Azure OpenAI con el [OpenAICompatibleWebClient](https://reference.aspose.com/slides/es/java/com.aspose.slides/openaicompatiblewebclient/).

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

Este fragmento muestra cómo traducir una presentación usando su punto de enlace de Azure OpenAI. Reemplace los valores de marcador de posición con el nombre de su implementación, la clave API y la URL del punto de enlace.

## **Beneficios clave**

La API de Traducción de Presentaciones de Aspose.Slides ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción y conservar el diseño y la maquetación, ahorra tiempo y minimiza errores respecto a los flujos de trabajo manuales. Ya sea que sea desarrollador, educador o profesional empresarial, esta API le permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando su alcance y mejorando la comunicación.