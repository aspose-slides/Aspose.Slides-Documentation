---
title: KI-gestützter Präsentationsübersetzer
linktitle: KI-gestützter Übersetzer
type: docs
weight: 20
url: /de/python-net/ai/translator/
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
- Python
- Aspose.Slides
description: "Übersetzen Sie PowerPoint-Folien mit KI mithilfe von Aspose.Slides für Python. Lokalisieren Sie PPT, PPTX und ODP und erhalten Sie das Layout - schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einleitung**

Aspose.Slides ist eine leistungsstarke API zum programmgesteuerten Verwalten von PowerPoint‑Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI‑gestützte Funktionen – wie die Presentation Translation API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Funktionen, sondern integriert externe KI‑Modelle über das Internet. Diese Funktionalität wird über die SlidesAIAgent‑Klasse bereitgestellt, die Unterklassen von IAIWebClient verwendet, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten OpenAIWebClient verwenden, um eine Verbindung zur OpenAI‑API herzustellen, oder Ihren eigenen IAIWebClient implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="info" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist. Sie müssen daher ein Konto erstellen und Ihren API‑Schlüssel angeben, wenn Sie den integrierten OpenAIWebClient verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mithilfe des integrierten OpenAIWebClient und eines angegebenen OpenAI‑Modells.

```py
import aspose.slides as slides

# Laden Sie eine Präsentation zum Übersetzen.
with slides.Presentation("sample.pptx") as presentation:

    # Erstellen Sie einen KI-Client mit OpenAIWebClient und geben Sie Ihr Modell und den API-Schlüssel an.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # Initialisieren Sie SlidesAIAgent mit dem KI-Client.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Übersetzen Sie die Präsentation ins Japanische.
        ai_agent.translate(presentation, "japanese")

        # Speichern Sie die übersetzte Präsentation als PDF.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI Beispiel**

Seit Version **26.7.0** unterstützt Aspose.Slides für Python über .NET OpenAI‑kompatible Anbieter, einschließlich Azure OpenAI. Sie können den Übersetzer so konfigurieren, dass er Ihre interne Azure‑Bereitstellung mit dem OpenAICompatibleWebClient verwendet.

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Dieses Snippet zeigt, wie eine Präsentation mit Ihrem Azure‑OpenAI‑Endpunkt übersetzt wird. Ersetzen Sie die Platzhalterwerte durch Ihren Bereitstellungsnamen, Ihren API‑Schlüssel und die Endpunkt‑URL.

## **Wesentliche Vorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung zur Bereitstellung mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und reduziert Fehler im Vergleich zu manuellen Arbeitsabläufen. Egal, ob Sie Entwickler, Pädagoge oder Business‑Professional sind, ermöglicht Ihnen diese API, ansprechende, lokalisierte Präsentationen für ein globales Publikum zu erstellen – wodurch Ihre Reichweite erweitert und die Kommunikation verbessert wird.