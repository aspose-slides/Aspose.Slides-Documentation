---
title: Traductor de Presentaciones impulsado por IA
linktitle: Traductor impulsado por IA
type: docs
weight: 20
url: /es/php-java/ai/translator/
keywords:
- traductor de presentaciones con IA
- traductor de diapositivas con IA
- característica impulsada por IA
- presentación multilingüe
- diapositiva multilingüe
- traducción de presentaciones
- traducción de diapositivas
- funciones impulsadas por IA
- capacidades de IA
- agente de IA
- cliente web
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Traduce diapositivas de PowerPoint con IA usando Aspose.Slides para PHP. Localiza PPT, PPTX y ODP manteniendo el diseño—rápido y fácil para desarrolladores. Pruébalo."
---
## **Introducción**

Aspose.Slides es una API potente para gestionar programáticamente presentaciones de PowerPoint. Además de crear, editar y convertir diapositivas, ofrece funciones impulsadas por IA, como la API de Traducción de Presentaciones para contenido multilingüe de diapositivas.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA integradas, pero se integra con modelos de IA externos a través de internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesaiagent/) para comunicarse con los servicios de IA.

Puede utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/es/php-java/aspose.slides/openaiwebclient/) incorporado para conectarse a la API de OpenAI.

Aspose.Slides gestiona la comunicación, analiza las respuestas de la IA e inserta de forma inteligente el contenido traducido mientras preserva el diseño y el formato originales de la diapositiva.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que la API de OpenAI es un servicio de pago, por lo que deberá crear una cuenta y proporcionar su clave API al utilizar el [OpenAIWebClient](https://reference.aspose.com/slides/es/php-java/aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés mediante el [OpenAIWebClient](https://reference.aspose.com/slides/es/php-java/aspose.slides/openaiwebclient/) incorporado con un [model](https://platform.openai.com/docs/models) de OpenAI especificado.

```php
// Cargar una presentación para traducir.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializar SlidesAIAgent con el cliente de IA.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Traducir la presentación al japonés.
    $aiAgent->translate($presentation, "japanese");

    // Guardar la presentación traducida como PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Por defecto, el [OpenAIWebClient](https://reference.aspose.com/slides/es/php-java/aspose.slides/openaiwebclient/) crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. No obstante, si prefiere gestionar usted mismo la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) —principalmente para configurar ajustes esenciales como un proxy, o para usar un [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para una mejor gestión de recursos y rendimiento— puede proporcionar su propia instancia `HttpURLConnection` al construir el [OpenAIWebClient](https://reference.aspose.com/slides/es/php-java/aspose.slides/openaiwebclient/).

```php
// Crear y preconfigurar tu propia instancia HttpURLConnection (tiempos de espera personalizados, configuración de proxy, etc.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Pasar la conexión al cliente de IA.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Ejemplo de Azure OpenAI**

Puede configurar el traductor para que utilice su despliegue de Azure OpenAI con el [OpenAICompatibleWebClient](https://reference.aspose.com/slides/es/php-java/aspose.slides/openaicompatiblewebclient/).

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Este fragmento muestra cómo traducir una presentación usando su punto de enlace de Azure OpenAI. Reemplace los valores de marcador de posición por el nombre de su despliegue, la clave API y la URL del punto de enlace.

## **Ventajas clave**

La API de Traducción de Presentaciones de Aspose.Slides ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción y conservar el diseño y la maquetación, ahorra tiempo y minimiza errores en comparación con los flujos de trabajo manuales. Tanto si es desarrollador, docente o profesional empresarial, esta API le permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando su alcance y mejorando la comunicación.