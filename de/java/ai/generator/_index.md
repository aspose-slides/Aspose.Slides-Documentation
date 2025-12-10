---
title: KI-gestützter mehrsprachiger Foliengenerator
linktitle: KI-gestützter Generator
type: docs
weight: 40
url: /de/java/ai/generator/
keywords:
- mehrsprachige Präsentation
- mehrsprachige Folie
- KI-Präsentationsgenerator
- KI-Foliengenerator
- KI-gestütztes Feature
- KI-Agent
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Generieren Sie mehrsprachige Folien aus Text mit Aspose.Slides für Java. Wenden Sie Ihre Vorlage an und exportieren Sie fertige Decks nach PowerPoint und OpenDocument. Erfahren Sie mehr."
---

## **Aspose.Slides Presentation AI API: KI‑gestützter Foliengenerator**

Aspose.Slides führt ein neues KI‑gestütztes Feature, den Presentation Generator, ein, das Entwicklern ermöglicht, automatisch gut strukturierte PowerPoint‑Präsentationen aus einfachen Texteingaben wie Themenbeschreibungen, Zusammenfassungen, Zitaten oder Aufzählungspunkten zu erstellen.

Benutzer können das Detailniveau des Inhalts anpassen und optional eine benutzerdefinierte Präsentationsvorlage anwenden, um das visuelle Design festzulegen.

Derzeit strukturiert der KI‑Presentation‑Generator Inhalte mit Textblöcken, Aufzählungslisten und Tabellen. Die Bildgenerierung wird noch nicht unterstützt; Bilder können jedoch anschließend problemlos mit den Aspose.Slides‑Werkzeugen oder manuell hinzugefügt werden.

Die Ausgabe ist eine vollständige PowerPoint‑Präsentation, die so verwendet oder in jedes von der Aspose.Slides‑API unterstützte Format exportiert werden kann. Während der Generator hochwertige Ergebnisse liefert, kann eine geringfügige Nachbearbeitung erforderlich sein, um spezifische Anforderungen zu erfüllen.

## **Wie es funktioniert**

Aspose.Slides enthält keine eingebauten KI‑Modelle; stattdessen integriert es externe KI‑Dienste über das Internet. Diese Integration wird von der Klasse [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/) bereitgestellt, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) verwendet, um mit dem KI‑Modell zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) nutzen, der sich mit der OpenAI‑API verbindet, oder eine eigene Implementierung von [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) bereitstellen, um mit einem anderen KI‑Anbieter oder Sprachmodell zu arbeiten. Aspose.Slides verwaltet die gesamte Kommunikation mit dem KI‑Dienst und verarbeitet die Antworten der KI, um Folien zu erzeugen. Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist; ein Konto und ein API‑Schlüssel sind erforderlich, wenn der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) verwendet wird.

## **Lass uns coden**

### **Beispiel 1**

Dieses Beispiel zeigt, wie man mit dem integrierten [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) eine Präsentation zum Thema Aspose.Slides erzeugt.
```java
// Erstelle eine Instanz von OpenAIWebClient, der integrierten Implementierung des OpenAI-Webclients.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Erstelle eine Instanz von SlidesAIAgent, die Zugriff auf KI-gestützte Funktionen bietet.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definiere die Anweisung für die Erstellung der Präsentation.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Generiere eine Präsentation mit einem mittleren Inhaltsumfang basierend auf der Anweisung.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Speichere die generierte Präsentation auf der lokalen Festplatte als PowerPoint (.pptx)-Datei.
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


### **Beispiel 2**

Das folgende Beispiel demonstriert die Überladungen der Methode [generatePresentation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). In diesem Fall wird eine extern verwaltete Instanz von [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) und die `master presentation` des Benutzers verwendet.

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) seine eigene interne Instanz von [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) und übernimmt deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – beispielsweise bei Verwendung eines [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) oder eines [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für verbessertes Ressourcenmanagement und bessere Performance – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) Ihre eigene [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-Instanz übergeben.
```java
// Übergibt die HttpURLConnection an den OpenAIWebClient-Konstruktor.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Erstellt eine Instanz von SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definiert die Anweisung zur Erstellung der Präsentation.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Lädt eine Master-Präsentation von der lokalen Festplatte, um sie als Designvorlage zu verwenden.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Generiert eine detaillierte Präsentation anhand der Anweisung und der Master-Vorlage.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Speichert die generierte Präsentation als PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


## **Wesentliche Vorteile**

Der neue KI‑Presentation‑Generator in Aspose.Slides bietet einen schnellen und flexiblen Weg, strukturierte Foliendecks aus einfachen Texteingaben zu erstellen. Mit Unterstützung für benutzerdefinierte Vorlagen und extern verwaltete [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-Instanzen lässt er sich nahtlos in eine Vielzahl von Anwendungen integrieren.

Typische Anwendungsfälle umfassen die Erstellung von Marketing‑Präsentationen, Schulungsmaterialien, Kundenberichten und internen Foliendecks. Obwohl die Bildgenerierung noch nicht unterstützt wird, bietet das Tool bereits eine solide Grundlage zur Automatisierung der Präsentationserstellung, wobei in Zukunft weitere Verbesserungen erwartet werden.