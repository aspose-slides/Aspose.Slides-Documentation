---
title: AI-gestuurde presentatietranslator
linktitle: AI-gestuurde vertaler
type: docs
weight: 20
url: /nl/androidjava/ai/translator/
keywords:
- AI presentatietranslator
- AI dia-vertaler
- AI-gestuurde functie
- meertalige presentatie
- meertalige dia
- presentatievertaling
- dia-vertaling
- AI-gestuurde functies
- AI-mogelijkheden
- AI-agent
- Webclient
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor Android via Java. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Inleiding**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gestuurde functies – zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt beschikbaar gesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesaiagent/)‑klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaiwebclient/)‑interface gebruikt om te communiceren met AI‑services.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI, of uw eigen [IAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaiwebclient/) implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides verwerkt de communicatie, parse de AI‑reacties en voegt op intelligente wijze vertaalde inhoud in, terwijl de oorspronkelijke dia‑lay-out en opmaak behouden blijven.

{{% alert color="info" title="Opmerking" %}}
Let op dat de OpenAI‑API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/) en een opgegeven OpenAI‑model.

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

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/) een eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie aan en beheert deze, waardoor de levenscyclus automatisch wordt afgehandeld. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren – bijvoorbeeld om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor beter bronnenbeheer en prestaties – kunt u uw eigen `HttpURLConnection`‑instantie opgeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Configureer zelf een HttpURLConnection‑instantie (bijv. met aangepaste time‑outs, proxy‑instellingen, enz.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Geef de verbinding door aan de OpenAIWebClient‑constructor.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI voorbeeld**

U kunt de vertaler configureren om uw Azure OpenAI‑implementatie te gebruiken met de [OpenAICompatibleWebClient](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/openaicompatiblewebclient/).

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

Dit fragment toont hoe een presentatie vertaald wordt met uw Azure OpenAI‑endpoint. Vervang de plaatsaanduidingen door uw implementatienaam, API‑sleutel en endpoint‑URL.

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren en tegelijkertijd de lay‑out en het ontwerp te behouden, bespaart het tijd en minimaliseert het fouten ten opzichte van handmatige workflows. Of u nu ontwikkelaar, docent of zakelijke professional bent, met deze API kunt u boeiende, gelokaliseerde presentaties maken voor een wereldwijd publiek – waardoor uw bereik wordt vergroot en de communicatie wordt verbeterd.