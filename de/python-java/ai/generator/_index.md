---
title: KI-gestützter mehrsprachiger Folien-Generator
linktitle: KI-gestützter Generator
type: docs
weight: 40
url: /de/python-java/ai/generator/
keywords:
- mehrsprachige Präsentation
- mehrsprachige Folie
- KI-Präsentationsgenerator
- KI-Foliengenerator
- Präsentationsvorlage
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Erstellen Sie mehrsprachige Präsentationen aus Text mit Aspose.Slides für Python über Java. Wählen Sie den Detailgrad des Inhalts, wenden Sie eine Vorlage an und exportieren Sie nach PowerPoint oder PDF."
---
## **Einleitung**

Der KI‑Präsentationsgenerator in Aspose.Slides für Python über Java erstellt Präsentationen aus Themenbeschreibungen, Zusammenfassungen, Zitaten oder Aufzählungspunkten. Geben Sie die gewünschte Sprache in Ihrer Eingabeaufforderung an, wählen Sie die Menge des Inhalts und können optional eine Präsentationsvorlage bereitstellen, um Layout und Design zu definieren.

Der Generator strukturiert den Inhalt mithilfe von Textblöcken, Aufzählungslisten und Tabellen. Er erzeugt keine Bilder; Sie können diese nachträglich zur resultierenden Präsentation hinzufügen. Überprüfen Sie den generierten Inhalt und das Layout, bevor Sie die Präsentation weitergeben.

## **Funktionsweise**

[SlidesAIAgent](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesaiagent/) verwendet einen KI‑Client, um mit einem externen Modell zu kommunizieren. Die nachstehenden Beispiele nutzen den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/python-java/aspose.slides/openaiwebclient/). Aspose.Slides verarbeitet die Antworten des Modells und erstellt eine Präsentation, die Sie bearbeiten oder exportieren können.

Verwenden Sie [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesaiagent/#generatePresentation) mit einer Textbeschreibung und einem [PresentationContentAmountType](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationcontentamounttype/)-Wert. Die Überladung mit einem dritten Argument akzeptiert eine Präsentation, die als Designtemplate verwendet wird.

## **Voraussetzungen**

Befolgen Sie die Anweisungen unter [Installation](/slides/de/python-java/installation/), um Python, Java, JPype und Aspose.Slides zu konfigurieren. Setzen Sie die Umgebungsvariablen `OPENAI_API_KEY` und `OPENAI_MODEL`, bevor Sie die Beispiele ausführen. Wählen Sie ein vom integrierten Client unterstütztes Modell, das in Ihrem API‑Konto verfügbar ist.

{{% alert color="info" title="Hinweis" %}}
Der KI‑Dienst erfordert eine Internetverbindung und separaten API‑Zugang. Eingabeaufforderungen werden an den konfigurierten Dienst gesendet, und dessen Nutzungskosten gelten unabhängig von Ihrer Aspose.Slides‑Lizenz.
{{% /alert %}}

Jedes Beispiel startet die JVM nur, wenn sie noch nicht läuft, und lässt sie für nachfolgende Vorgänge verfügbar. Siehe [JVM-Lebenszyklus‑Leitfaden](/slides/de/python-java/limitations-and-api-differences/#import-the-library), wenn Sie den Code für Notebooks anpassen.

## **Eine Präsentation aus Text erzeugen**

Dieses Beispiel erzeugt eine englische Präsentation mit einer [Medium](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationcontentamounttype/#Medium) Menge an Inhalt und speichert sie als PowerPoint‑Datei.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Eine Präsentation mit einer Vorlage erzeugen**

Legen Sie `masterPresentation.pptx` im Arbeitsverzeichnis ab. Dieses Beispiel lädt sie mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), erzeugt eine spanische Präsentation mit [Detailed](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationcontentamounttype/#Detailed) Inhalt und exportiert sie nach PDF. Sowohl die Vorlage als auch die erzeugte Präsentation werden freigegeben, selbst wenn die Erzeugung oder das Speichern fehlschlägt.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Falls Sie einen Proxy oder Verbindungszeitlimits konfigurieren müssen, siehe [HTTP‑Verbindung konfigurieren](/slides/de/python-java/ai/translator/#configure-the-http-connection). Sie können den resultierenden Client ebenfalls an den Generator übergeben.

## **Wesentliche Vorteile**

Die Generierung kann die anfängliche Ausarbeitungsarbeit für Schulungsunterlagen, Produktübersichten, Kundenberichte und interne Präsentationen reduzieren. Eingabeaufforderungen steuern das Thema und die Sprache, während eine Vorlage Ihnen ermöglicht, ein bestehendes Präsentationsdesign wiederzuverwenden.

## **FAQ**

**Wie kann ich die Länge der erzeugten Präsentation steuern?**

Wählen Sie [Brief](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationcontentamounttype/#Medium) oder [Detailed](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Diese Einstellungen beeinflussen sowohl die Anzahl der Folien als auch die Detailtiefe jeder Folie; sie geben keine feste Folienanzahl vor.

**Kann ich Folien in einer anderen Sprache erzeugen?**

Ja. Geben Sie die gewünschte Sprache in der Textbeschreibung an. Das Ergebnis hängt von den Sprachfähigkeiten des ausgewählten Modells ab.

**Kann ich beim Export nach PDF eine bearbeitbare Version behalten?**

Ja. Bevor Sie die erzeugte Präsentation freigeben, speichern Sie sie zusätzlich als PPTX, indem Sie die Vorgehensweise aus dem ersten Beispiel verwenden.