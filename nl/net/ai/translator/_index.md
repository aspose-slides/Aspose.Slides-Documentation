---
title: AI-aangedreven presentatietranslator
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/net/ai/translator/
keywords:
- AI presentatietranslator
- AI diavertaler
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
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor .NET. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft—snel en ontwikkelaarvriendelijk. Probeer het."
---
## **Introduction**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gestuurde functionaliteit – zoals de [Presentation Translation API](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/) voor meertalige dia‑inhoud.

## **How It Works**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via internet. Deze mogelijkheid wordt blootgelegd via de klasse [SlidesAIAgent](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/slidesaiagent) die een implementatie van de interface [IAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/iaiwebclient/) gebruikt om te communiceren met AI‑diensten.

Je kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) gebruiken om verbinding te maken met de OpenAI‑API, of je eigen [IAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/iaiwebclient/) implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides verzorgt de communicatie, verwerkt de AI‑reacties en voegt vertaalde inhoud intelligent in, terwijl de oorspronkelijke dia‑indeling en opmaak behouden blijven.

{{% alert color="primary" %}}
Let op dat de OpenAI‑API een betaalde dienst is, dus je moet een account aanmaken en je API‑sleutel opgeven wanneer je de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) gebruikt.
{{% /alert %}}

## **Example**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) en een gespecificeerd OpenAI‑[model](https://platform.openai.com/docs/models).

```csharp
// Laad een presentatie om te vertalen.
using var presentation = new Presentation("sample.pptx");

// Maak een AI-client met OpenAIWebClient, geef je model en API-sleutel op.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialiseer SlidesAIAgent met de AI-client.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Vertaal de presentatie naar het Japans.
await aiAgent.TranslateAsync(presentation, "japanese");

// Sla de vertaalde presentatie op als PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/) een eigen interne [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)‑instantie aan en beheert deze, waarbij de levenscyclus en afvoer automatisch worden afgehandeld. Als je echter de [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) zelf wilt beheren – bijvoorbeeld bij gebruik van een [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) voor betere hulpbronnenbeheer en prestaties – kun je je eigen `HttpClient`‑instantie leveren bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Ga er vanuit dat je een IHttpClientFactory-instantiatie hebt (bijv. geïnjecteerd via dependency injection).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides wordt vaak gebruikt in synchronisatie‑omgevingen. Om dit te ondersteunen biedt de klasse [SlidesAIAgent](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/slidesaiagent/) zowel synchrone als asynchrone methoden – zodat je de aanpak kunt kiezen die het beste past bij de workflow van je applicatie.

## **Key Benefits**

De Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/nl/net/aspose.slides.ai/) biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren terwijl layout en ontwerp behouden blijven, bespaar je tijd en minimaliseer je fouten ten opzichte van handmatige processen. Of je nu ontwikkelaar, docent of bedrijfsprofessional bent, deze API stelt je in staat om boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – waardoor je bereik wordt vergroot en de communicatie verbetert.