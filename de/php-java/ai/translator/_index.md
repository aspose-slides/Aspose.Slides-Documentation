---
title: KI-gestützter Präsentationsübersetzer
linktitle: KI-gestützter Übersetzer
type: docs
weight: 20
url: /de/php-java/ai/translator/
keywords:
- KI-Präsentationsübersetzer
- KI-Folienübersetzer
- KI-gestützte Funktion
- mehrsprachige Präsentation
- mehrsprachige Folie
- Präsentationsübersetzung
- Folienübersetzung
- KI-gesteuerte Funktionen
- KI-Fähigkeiten
- KI-Agent
- Web-Client
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Übersetzen Sie PowerPoint-Folien mit KI mithilfe von Aspose.Slides für PHP. Lokalisieren Sie PPT, PPTX und ODP, wobei das Layout erhalten bleibt – schnell und entwicklerfreundlich. Probieren Sie es aus."
---

## **Aspose.Slides Präsentations-Übersetzungs-API: KI-gestützte mehrsprachige Folienübersetzung**

Aspose.Slides ist eine leistungsstarke API zum programmgesteuerten Verwalten von PowerPoint-Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI-gestützte Funktionen - beispielsweise die Präsentations-Übersetzungs-API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI-Funktionen, integriert jedoch externe KI-Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/php-java/aspose.slides/slidesaiagent/) bereitgestellt, um mit KI-Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) verwenden, um sich mit der API von OpenAI zu verbinden.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI-Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="primary" %}}
Beachten Sie, dass die OpenAI-API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API-Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint-Präsentation ins Japanische mithilfe des integrierten [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) und eines angegebenen OpenAI-[Modells](https://platform.openai.com/docs/models).
```php
// Lade eine Präsentation zum Übersetzen.
$presentation = new Presentation("sample.pptx");

// Erstelle einen KI-Client mit OpenAIWebClient, gib dein Modell und den API-Schlüssel an.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialisiere SlidesAIAgent mit dem KI-Client.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Übersetze die Präsentation ins Japanische.
    $aiAgent->translate($presentation, "japanese");

    // Speichere die übersetzte Präsentation als PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```


Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-Instanz und übernimmt deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten - hauptsächlich, um wichtige Einstellungen wie einen Proxy zu konfigurieren oder eine [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) bzw. einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und eine bessere Leistung zu verwenden - können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`-Instanz bereitstellen.
```php
// Angenommen, Sie haben eine vorkonfigurierte HttpURLConnection-Instanz (z. B. mit benutzerdefinierten Timeouts, Proxy-Einstellungen usw.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```


## **Wesentliche Vorteile**

Die Aspose.Slides Präsentations‑Übersetzungs‑API bietet eine KI-gestützte Lösung zum Erstellen mehrsprachiger PowerPoint-Präsentationen. Durch die automatisierte Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und reduziert Fehler im Vergleich zu manuellen Arbeitsabläufen. Unabhängig davon, ob Sie Entwickler, Lehrender oder Geschäftsprofi sind, ermöglicht diese API das Erstellen ansprechender, lokalisierter Präsentationen für ein globales Publikum - wodurch Sie Ihre Reichweite erweitern und die Kommunikation verbessern.