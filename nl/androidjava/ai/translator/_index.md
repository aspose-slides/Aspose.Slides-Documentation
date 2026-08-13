---
title: AI-aangedreven presentatietranslator
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/androidjava/ai/translator/
keywords:
- AI-presentatievertaler
- AI-diavertaler
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
- Android
- Java
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor Android via Java. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Introductie**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gedreven functies – zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt blootgesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesaiagent/)‑klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaiwebclient/) interface gebruikt om met AI‑services te communiceren.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de OpenAI‑API, of uw eigen [IAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaiwebclient/) implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides verzorgt de communicatie, parseert de AI‑antwoorden en voegt automatisch vertaalde inhoud in, terwijl de oorspronkelijke dia‑lay‑out en opmaak behouden blijven.

{{% alert color="info" %}}
Let op: de OpenAI‑API is een betaalde dienst, dus u moet een account aanmaken en uw API‑sleutel opgeven bij gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/) en een opgegeven OpenAI‑[model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Laad een presentatie om te vertalen.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiseer SlidesAIAgent met de AI-client.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Vertaal de presentatie naar Japans.
    aiAgent.translate(presentation, "japanese");

    // Sla de vertaalde presentatie op als PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/) en beheert hij zijn eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie, waarbij de levenscyclus automatisch wordt afgehandeld. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren – bijvoorbeeld om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor beter resource‑beheer en prestaties – kunt u uw eigen `HttpURLConnection`‑instantie aanbieden bij het aanmaken van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Configureer zelf een HttpURLConnection-instantie (bijv. met aangepaste timeouts, proxy-instellingen, enz.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Geef de verbinding door aan de OpenAIWebClient-constructor.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren en tegelijk de lay‑out en het ontwerp te behouden, bespaart het tijd en minimaliseert het fouten in vergelijking met handmatige workflows. Of u nu ontwikkelaar, docent of zakenprofessional bent, deze API stelt u in staat boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – waardoor uw bereik groeit en de communicatie verbetert.