---
title: Traductor de presentaciones potenciado por IA
linktitle: Traductor potenciado por IA
type: docs
weight: 20
url: /es/net/ai/translator/
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
- .NET
- C#
- Aspose.Slides
description: "Traduce diapositivas de PowerPoint con IA utilizando Aspose.Slides para .NET. Localiza PPT, PPTX y ODP conservando el diseño—rápido y fácil para desarrolladores. Pruébalo."
---
## **Introducción**

Aspose.Slides es una potente API para gestionar programáticamente presentaciones de PowerPoint. Además de crear, editar y convertir diapositivas, ofrece funcionalidades impulsadas por IA, como la [Presentation Translation API](https://reference.aspose.com/slides/es/net/aspose.slides.ai/) para contenido de diapositivas multilingüe.

## **Cómo funciona**

Aspose.Slides no incluye capacidades de IA integradas, pero se integra con modelos de IA externos a través de internet. Esta funcionalidad se expone mediante la clase [SlidesAIAgent](https://reference.aspose.com/slides/es/net/aspose.slides.ai/slidesaiagent) que utiliza una implementación de la interfaz [IAIWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/iaiwebclient/) para comunicarse con los servicios de IA.

Puede usar el [OpenAIWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/openaiwebclient/) incorporado para conectarse a la API de OpenAI o implementar su propio [IAIWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/iaiwebclient/) para utilizar un proveedor de IA o modelo de lenguaje diferente.

Aspose.Slides gestiona la comunicación, analiza las respuestas de la IA e inserta de manera inteligente el contenido traducido preservando el diseño y el formato original de la diapositiva.

{{% alert color="info" title="Note" %}}
Tenga en cuenta que la API de OpenAI es un servicio de pago, por lo que deberá crear una cuenta y proporcionar su clave API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Ejemplo**

En este ejemplo, traducimos una presentación de PowerPoint al japonés usando el [OpenAIWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/openaiwebclient/) incorporado con un [model](https://platform.openai.com/docs/models) de OpenAI especificado.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Carga una presentación para traducir.
using var presentation = new Presentation("sample.pptx");

// Crea un cliente de IA con OpenAIWebClient, especificando tu modelo y clave API.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Inicializa SlidesAIAgent con el cliente de IA.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Traduce la presentación al japonés.
await aiAgent.TranslateAsync(presentation, "japanese");

// Guarda la presentación traducida como PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Por defecto, el [OpenAIWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/openaiwebclient/) incorporado crea y gestiona su propia instancia interna de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), manejando su ciclo de vida y eliminación automáticamente. Sin embargo, si prefiere gestionar el [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) usted mismo, por ejemplo al usar un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) para una mejor gestión de recursos y rendimiento, puede proporcionar su propia instancia `HttpClient` al construir el [OpenAIWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Utiliza un HttpClient que manejes tú mismo - por ejemplo, uno creado por un IHttpClientFactory
// inyectado mediante inyección de dependencias.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides se usa habitualmente en entornos sincrónicos. Para admitir esto, la clase [SlidesAIAgent](https://reference.aspose.com/slides/es/net/aspose.slides.ai/slidesaiagent/) ofrece métodos sincrónicos y asíncronos, lo que le permite elegir el enfoque que mejor se adapte al flujo de trabajo de su aplicación.

### **Ejemplo de Azure OpenAI**

Aspose.Slides para .NET admite proveedores compatibles con OpenAI, incluido Azure OpenAI. Puede configurar el traductor para usar su implementación interna de Azure mediante el [OpenAICompatibleWebClient](https://reference.aspose.com/slides/es/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Este fragmento muestra cómo traducir una presentación utilizando su punto de enlace de Azure OpenAI. Reemplace los valores del marcador de posición con el nombre de su implementación, la clave API y la URL del punto de enlace.

## **Beneficios clave**

La [Presentation Translation API](https://reference.aspose.com/slides/es/net/aspose.slides.ai/) de Aspose.Slides ofrece una solución impulsada por IA para ofrecer presentaciones de PowerPoint multilingües. Al automatizar la traducción mientras se preserva el diseño y la maquetación, ahorra tiempo y minimiza errores comparado con flujos de trabajo manuales. Ya sea que sea desarrollador, educador o profesional empresarial, esta API le permite crear presentaciones atractivas y localizadas para audiencias globales, ampliando su alcance y mejorando la comunicación.