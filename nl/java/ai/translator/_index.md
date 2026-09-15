---
title: AI‑gedreven presentatietranslator
linktitle: AI‑gedreven vertaler
type: docs
weight: 20
url: /nl/java/ai/translator/
keywords:
- AI‑presentatietranslator
- AI‑dia‑translator
- AI‑gedreven functie
- meertalige presentatie
- meertalige dia
- presentatievertaling
- diavertaling
- AI‑gedreven functies
- AI‑mogelijkheden
- AI‑agent
- Webclient
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor Java. Lokaliseer PPT, PPTX en ODP terwijl de lay-out behouden blijft - snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Inleiding**

Aspose.Slides is een krachtige API voor het programmatisch beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia's, biedt het AI‑gedreven functies – zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑functionaliteit, maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt beschikbaar gesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesaiagent/) klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/) interface gebruikt om te communiceren met AI‑services.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI, of uw eigen [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/) implementeren om een andere AI‑provider of taalmodel te gebruiken.

Aspose.Slides verzorgt de communicatie, parses de AI‑reacties, en voegt op intelligente wijze vertaalde inhoud in, terwijl de oorspronkelijke dia‑lay-out en opmaak behouden blijven.

{{% alert color="info" title="Note" %}}
Let op dat de OpenAI‑API een betaalde dienst is, dus u moet een account aanmaken en uw API‑sleutel opgeven wanneer u de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) gebruikt.
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) en een opgegeven OpenAI‑[model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Laad een presentatie om te vertalen.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialiseer SlidesAIAgent met de AI-client.
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

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) een eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑instantie aan en beheert deze automatisch. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren – bijvoorbeeld om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor beter resource‑beheer en prestaties – kunt u uw eigen `HttpURLConnection`‑instantie meegeven bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Configureer zelf een HttpURLConnection instantie (aangepaste timeouts, proxy instellingen, enz.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI‑voorbeeld**

U kunt de vertaler configureren om uw Azure OpenAI‑implementatie te gebruiken met de [OpenAICompatibleWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaicompatiblewebclient/).

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

Dit fragment laat zien hoe u een presentatie vertaalt met uw Azure OpenAI‑endpoint. Vervang de placeholder‑waarden door uw implementatienaam, API‑sleutel en endpoint‑URL.

## **Belangrijke voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren terwijl de lay-out en het ontwerp behouden blijven, bespaart het tijd en vermindert het fouten ten opzichte van handmatige workflows. Of u nu ontwikkelaar, docent of zakelijke professional bent, deze API stelt u in staat om boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek – waardoor uw bereik wordt vergroot en de communicatie verbetert.