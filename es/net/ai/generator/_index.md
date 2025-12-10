---
title: Generador de Diapositivas Multilingüe con IA
linktitle: Generador con IA
type: docs
weight: 40
url: /es/net/ai/generator/
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
- .NET
- C#
- Aspose.Slides
description: "Genere diapositivas multilingües a partir de texto con Aspose.Slides para .NET. Aplique su plantilla y exporte decks pulidos a PowerPoint y OpenDocument. Obtenga más información."
---

## **API de IA de Presentaciones de Aspose.Slides: Generador de Diapositivas con IA**

Aspose.Slides introduce una nueva funcionalidad impulsada por IA, el Generador de Presentaciones, que permite a los desarrolladores crear automáticamente presentaciones de PowerPoint bien estructuradas a partir de entradas de texto simples, como descripciones de temas, resúmenes, citas o viñetas.

Los usuarios pueden ajustar el nivel de detalle del contenido y, opcionalmente, aplicar una plantilla de presentación personalizada para definir el diseño visual.

Actualmente, el Generador de Presentaciones de IA estructura el contenido usando bloques de texto, listas con viñetas y tablas. La generación de imágenes aún no está soportada; sin embargo, las imágenes pueden añadirse fácilmente después utilizando las herramientas de Aspose.Slides o de forma manual.

El resultado es una presentación completa de PowerPoint que puede usarse tal cual o exportarse a cualquier formato compatible con la API de Aspose.Slides. Aunque el generador produce resultados de alta calidad, puede ser necesario realizar pequeñas ediciones posteriores para cumplir requisitos específicos.

## **Cómo funciona**

Aspose.Slides no incluye modelos de IA integrados; en su lugar, se integra con servicios externos de IA a través de internet. Esta integración la gestiona la clase [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) , que utiliza una implementación de la interfaz [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) para comunicarse con el modelo de IA.

Puede usar el [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) incorporado, que se conecta a la API de OpenAI, o proporcionar una implementación personalizada de [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) para trabajar con otro proveedor de IA o modelo de lenguaje. Aspose.Slides gestiona toda la comunicación con el servicio de IA y procesa las respuestas de la IA para generar diapositivas. Tenga en cuenta que la API de OpenAI es un servicio de pago, por lo que se necesita una cuenta y una clave de API al usar el [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

## **Vamos a codificar**

### **Ejemplo 1**

Este ejemplo muestra cómo generar una presentación sobre el tema Aspose.Slides usando el [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) incorporado.

```csharp
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Create an instance of SlidesAIAgent, which provides access to AI-powered features.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generate a presentation with a medium amount of content based on the instruction.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Ejemplo 2**

El siguiente ejemplo muestra las sobrecargas del método [GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/). En este caso se utilizan una instancia de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gestionada externamente y la `presentación maestra` del usuario.

Por defecto, el [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) crea y gestiona su propia instancia interna de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), manejando su ciclo de vida y eliminación automáticamente. Sin embargo, si prefiere gestionar el [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) usted mismo —por ejemplo, cuando usa un [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) para mejorar la gestión de recursos y el rendimiento— puede proporcionar su propia instancia de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) al construir el [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Create an externally managed HttpClient instance.
using var httpClient = new HttpClient();

// Pass the HttpClient to the OpenAIWebClient constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a detailed presentation using the instruction and master template.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Save the generated presentation as a PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Vale la pena mencionar que muchos clientes usan Aspose.Slides en contextos sincrónicos. Para admitir esto, la clase [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) proporciona tanto métodos sincrónicos como asincrónicos, lo que le permite elegir el enfoque que mejor se adapte al flujo de trabajo de su aplicación.

## **Beneficios clave**

El nuevo Generador de Presentaciones de IA en Aspose.Slides ofrece una forma rápida y flexible de producir decks de diapositivas estructurados a partir de simples indicaciones de texto. Con soporte para plantillas personalizadas, instancias de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) gestionadas externamente y flujos de trabajo tanto sincrónicos como asincrónicos, puede integrarse sin problemas en una amplia gama de aplicaciones.

Los casos de uso típicos incluyen la creación de presentaciones de marketing, material educativo, informes para clientes y decks internos. Aunque la generación de imágenes aún no está soportada, la herramienta ya brinda una base sólida para automatizar la creación de presentaciones, y se esperan mejoras adicionales en el futuro.