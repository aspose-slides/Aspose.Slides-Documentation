---
title: AI-aangedreven presentatievertaler
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/net/ai/translator/
keywords:
- AI presentatievertaler
- AI dia-vertaler
- AI-aangedreven functie
- meertalige presentatie
- meertalige dia
- presentatievertaling
- diavertaling
- AI-gedreven functies
- AI-mogelijkheden
- AI-agent
- webclient
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor .NET. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Introductie**

Aspose.Slides is een krachtige API voor het programmatically beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gedreven functies – zoals de [Presentation Translation API](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/) voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑mogelijkheden, maar integreert met externe AI‑modellen via het internet. Deze functionaliteit wordt beschikbaar gesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/slidesaiagent)‑klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/iaiwebclient/)‑interface gebruikt om met AI‑services te communiceren.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI, of uw eigen [IAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/iaiwebclient/) implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides regelt de communicatie, parseert de AI‑reacties en voegt op intelligente wijze vertaalde inhoud in, terwijl de oorspronkelijke dia‑indeling en opmaak behouden blijven.

{{% alert color="info" %}}
Let op: de OpenAI‑API is een betaalde dienst, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) en een opgegeven OpenAI‑[model](https://platform.openai.com/docs/models).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Laad een presentatie om te vertalen.
using var presentation = new Presentation("sample.pptx");

// Maak een AI-client met OpenAIWebClient, waarbij je model en API-sleutel opgeeft.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialiseer SlidesAIAgent met de AI-client.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Vertaal de presentatie naar Japans.
await aiAgent.TranslateAsync(presentation, "japanese");

// Sla de vertaalde presentatie op als PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) een eigen interne [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)‑instantie aan en beheert deze, waarbij de levenscyclus en vrijgave automatisch worden afgehandeld. Als u echter de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) zelf wilt beheren — bijvoorbeeld bij gebruik van een [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) voor betere resource‑beheer en prestaties — kunt u uw eigen `HttpClient`‑instantie doorgeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Gebruik een HttpClient die u zelf beheert - bijvoorbeeld een die gemaakt is door een IHttpClientFactory
// geïnjecteerd via dependency injection.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides wordt vaak gebruikt in synchrone omgevingen. Om dit te ondersteunen biedt de [SlidesAIAgent](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/slidesaiagent/)‑klasse zowel synchrone als asynchrone methoden — zodat u de aanpak kunt kiezen die het beste past bij de workflow van uw applicatie.

## **Belangrijkste voordelen**

De Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/) biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren en tegelijkertijd indeling en ontwerp te behouden, bespaart het tijd en vermindert het fouten ten opzichte van handmatige werkwijzen. Of u nu ontwikkelaar, docent of bedrijfsprofessional bent, deze API stelt u in staat boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek — waardoor uw bereik wordt vergroot en de communicatie verbetert.