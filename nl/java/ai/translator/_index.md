---
title: AI-aangedreven presentatietranslator
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/java/ai/translator/
keywords:
- AI presentatietranslator
- AI dia-vertaler
- AI-aangedreven functie
- meertalige presentatie
- meertalige dia
- presentatievertaling
- diavertaling
- AI-gedreven functies
- AI-mogelijkheden
- AI-agent
- Webclient
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met Aspose.Slides voor Java. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaarvriendelijk. Probeer het."
---
## **Introductie**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gedreven functies – zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via internet. Deze functionaliteit is beschikbaar via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesaiagent/) klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/) interface gebruikt om met AI‑services te communiceren.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI, of uw eigen [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/) implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides regelt de communicatie, parseert de AI‑reacties en voegt op intelligente wijze vertaalde inhoud in, terwijl de oorspronkelijke dia‑lay-out en opmaak behouden blijven.

{{% alert color="info" %}}
Let op dat de OpenAI‑API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) en een opgegeven OpenAI‑[model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Laad een presentatie om te vertalen.
Presentation presentation = new Presentation("sample.pptx");

// Maak een AI-client met OpenAIWebClient, met vermelding van uw model en API-sleutel.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiseert SlidesAIAgent met de AI-client.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Vertaal de presentatie naar het Japans.
    aiAgent.translate(presentation, "japanese");

    // Sla de vertaalde presentatie op als PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) een eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instance aan en beheert deze, waarbij de levenscyclus automatisch wordt afgehandeld. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren — bijvoorbeeld om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor betere resource‑beheer en prestaties — kunt u uw eigen `HttpURLConnection`‑instance opgeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Configure een HttpURLConnection‑instantie zelf (aangepaste time‑outs, proxy‑instellingen, enz.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door de vertaling te automatiseren en tegelijk de lay‑out en het ontwerp te behouden, bespaart het tijd en minimaliseert het fouten ten opzichte van handmatige workflows. Of u nu een ontwikkelaar, docent of zakelijke professional bent, deze API stelt u in staat boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – waardoor uw bereik wordt vergroot en de communicatie verbeterd.