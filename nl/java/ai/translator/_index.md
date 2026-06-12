---
title: AI-aangedreven presentatievertaler
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/java/ai/translator/
keywords:
- AI presentatievertaler
- AI diavertaler
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
description: "Vertaal PowerPoint-dia's met AI met behulp van Aspose.Slides voor Java. Localiseer PPT, PPTX en ODP terwijl de lay-out behouden blijft — snel en ontwikkelaar-vriendelijk. Probeer het."
---
## **Inleiding**

Aspose.Slides is een krachtige API voor het programmatically beheren van PowerPoint‑presentaties. Naast het maken, bewerken en converteren van dia’s biedt het AI‑gedreven functies - zoals de Presentation Translation API voor meertalige dia‑inhoud.

## **Hoe het werkt**

Aspose.Slides bevat geen ingebouwde AI‑mogelijkheden, maar integreert met externe AI‑modellen via internet. Deze functionaliteit wordt blootgesteld via de [SlidesAIAgent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesaiagent/) klasse, die een implementatie van de [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/) interface gebruikt om te communiceren met AI‑diensten.

U kunt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) gebruiken om verbinding te maken met de API van OpenAI of uw eigen [IAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaiwebclient/) implementeren om een andere AI‑aanbieder of taalmodel te gebruiken.

Aspose.Slides regelt de communicatie, parse de AI‑antwoorden en voegt op intelligente wijze vertaalde inhoud in, terwijl de oorspronkelijke dia‑layout en opmaak behouden blijven.

{{% alert color="primary" %}}
Let op dat de OpenAI API een betaalde service is, dus u moet een account aanmaken en uw API‑sleutel opgeven bij het gebruik van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).
{{% /alert %}}

## **Voorbeeld**

In dit voorbeeld vertalen we een PowerPoint‑presentatie naar het Japans met behulp van de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) met een opgegeven OpenAI [model](https://platform.openai.com/docs/models).

```java
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

Standaard maakt de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/) een eigen interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) instantie aan en beheert deze, waarbij de levenscyclus automatisch wordt afgehandeld. Als u echter de [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) zelf wilt beheren - voornamelijk om essentiële instellingen zoals een proxy te configureren, of om een [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) of een andere [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) te gebruiken voor beter resourcebeheer en prestaties - kunt u uw eigen `HttpURLConnection`‑instantie leveren bij het construeren van de [OpenAIWebClient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/openaiwebclient/).

```java
// Stel dat u een vooraf geconfigureerde HttpURLConnection‑instantie hebt (bijv. met aangepaste timeouts, proxy‑instellingen, enz.).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Belangrijkste voordelen**

De Aspose.Slides Presentation Translation API biedt een AI‑aangedreven oplossing voor het leveren van meertalige PowerPoint‑presentaties. Door vertaling te automatiseren en tegelijkertijd layout en ontwerp te behouden, bespaart het tijd en minimaliseert het fouten ten opzichte van handmatige workflows. Of u nu ontwikkelaar, docent of zakelijk professional bent, deze API stelt u in staat om boeiende, gelokaliseerde presentaties te maken voor een wereldwijd publiek - waardoor uw bereik wordt vergroot en de communicatie wordt verbeterd.