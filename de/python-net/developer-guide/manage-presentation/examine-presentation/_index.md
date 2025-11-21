---
title: Abrufen und Aktualisieren von Präsentationsinformationen in Python
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/python-net/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Python für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---

Aspose.Slides für Python via .NET ermöglicht es Ihnen, eine Präsentation zu untersuchen, um ihre Eigenschaften zu ermitteln und ihr Verhalten zu verstehen. 

{{% alert title="Info" color="info" %}} 

Die Klassen [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) enthalten die Eigenschaften und Methoden, die hier verwendet werden. 

{{% /alert %}} 

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation aktuell befindet.

Sie können das Format einer Präsentation überprüfen, ohne sie zu laden. Siehe diesen Python-Code:
```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```


## **Abrufen von Präsentationseigenschaften**

Dieser Python-Code zeigt Ihnen, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) erhalten:
```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```


Sie möchten möglicherweise die [Eigenschaften der DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) Klasse sehen.

## **Aktualisieren von Präsentationseigenschaften**

Aspose.Slides stellt die Methode [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) zur Verfügung, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Nehmen wir an, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Originale Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt Ihnen, wie Sie einige Präsentationseigenschaften bearbeiten:
```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```


Die Ergebnisse der Änderung der Dokumenteigenschaften werden unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen zu einer Präsentation und ihren Sicherheitsaspekten zu erhalten, können diese Links hilfreich sein:

- [Prüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Prüfen, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Prüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des zum Schutz einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Wie kann ich überprüfen, ob Schriftarten eingebettet sind und welche es sind?**

Suchen Sie nach [embedded-font information](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [fonts actually used across content](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/), um zu ermitteln, welche Schriftarten für die Wiedergabe kritisch sind.

**Wie kann ich schnell feststellen, ob die Datei verborgene Folien enthält und wie viele?**

Iterieren Sie durch die [slide collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) und prüfen Sie das [visibility flag](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) jeder Folie.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Vorgaben abweicht?**

Ja. Vergleichen Sie die aktuelle [slide size](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) und Ausrichtung mit den Standard‑Presets; das hilft, das Verhalten beim Drucken und Exportieren vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchsuchen Sie alle [charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), prüfen Sie deren [data source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), und notieren Sie, ob die Daten intern oder verlinkt sind, einschließlich eventueller defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF-Export verlangsamen könnten?**

Für jede Folie zählen Sie Objektanzahlen und achten auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie einen groben Komplexitäts‑Score, um potenzielle Performance‑Hotspots zu kennzeichnen.