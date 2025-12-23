---
title: Traductor de Presentaciones con IA
linktitle: Traductor con IA
type: docs
weight: 20
url: /es/php-java/ai/translator/
keywords:
- Traductor de presentaciones con IA
- Traductor de diapositivas con IA
- Funcionalidad impulsada por IA
- Presentación multilingüe
- Diapositiva multilingüe
- Traducción de presentaciones
- Traducción de diapositivas
- Funciones impulsadas por IA
- Capacidades de IA
- Agente de IA
- Cliente web
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Traduzca diapositivas de PowerPoint con IA usando Aspose.Slides para PHP. Localice PPT, PPTX y ODP preservando el diseño, rápido y fácil para desarrolladores. Pruébelo."
---

## **API de Traducción de Presentaciones de Aspose.Slides: Traducción de Diapositivas Multilingüe con IA**

Aspose.Slides es una API potente para gestionar presentaciones de PowerPoint de forma programática. Además de crear, editar y convertir diapositivas, ofrece funciones impulsadas por IA, como la API de Traducción de Presentaciones para contenido de diapositivas multilingüe.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA incorporadas, pero se integra con modelos de IA externos a través de internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/php-java/aspose.slides/slidesaiagent/) para comunicarse con servicios de IA.

Puede usar el cliente incorporado [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) para conectarse a la API de OpenAI.

Aspose.Slides maneja la comunicación, analiza las respuestas de IA e inserta de manera inteligente el contenido traducido, manteniendo el diseño y formato original de la diapositiva.

{{% alert color="primary" %}}
Tenga en cuenta que la API de OpenAI es un servicio de pago, por lo que deberá crear una cuenta y proporcionar su clave API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) incorporado.
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés usando el [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) incorporado con un [modelo](https://platform.openai.com/docs/models) de OpenAI especificado.
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


Por defecto, el [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) incorporado crea y gestiona su propia instancia interna de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), manejando su ciclo de vida automáticamente. Sin embargo, si prefiere gestionar la [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) usted mismo — principalmente para configurar ajustes esenciales como un proxy, o para usar una [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) o un [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) diferente para una mejor gestión de recursos y rendimiento — puede proporcionar su propia instancia `HttpURLConnection` al construir el [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/).
```php
// Suponga que tiene una instancia de HttpURLConnection preconfigurada (p. ej., con tiempos de espera personalizados, configuración de proxy, etc.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```


## **Beneficios clave**

La API de Traducción de Presentaciones de Aspose.Slides ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción mientras preserva el diseño y la maquetación, ahorra tiempo y minimiza errores en comparación con los flujos de trabajo manuales. Ya sea que sea desarrollador, educador o profesional empresarial, esta API le permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando su alcance y mejorando la comunicación.