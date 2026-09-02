---
title: Präsentationsinformationen in Python abrufen und aktualisieren
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
## **Übersicht**

Dieser Artikel zeigt, wie Sie Präsentationsinformationen in Aspose.Slides inspizieren können. Er erklärt, wie Sie das aktuelle Format einer Präsentation bestimmen, ohne die gesamte Datei zu laden, deren Dokumenteigenschaften lesen und bei Bedarf diese Eigenschaften aktualisieren können.

Die Beispiele basieren auf den APIs [PresentationInfo](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/) und demonstrieren typische Vorgänge zum Arbeiten mit Präsentationsmetadaten.

## **Prüfen eines Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) die Präsentation derzeit vorliegt.

Sie können das Format einer Präsentation prüfen, ohne die Präsentation zu laden. Siehe diesen Python-Code:

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

Dieser Python-Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) abrufen können:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Möglicherweise möchten Sie die [Eigenschaften in der Klasse DocumentProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/#properties) sehen.

## **Aktualisieren von Präsentationseigenschaften**

Aspose.Slides stellt die Methode [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Codebeispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten können:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Die Ergebnisse der Änderung der Dokumenteigenschaften werden unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen zu erhalten, könnten diese Links nützlich sein:

- [Präsentationen mit Passwort schützen](/slides/de/python-net/password-protected-presentation/)
- [Präsentationen vor Schreibzugriff schützen](/slides/de/python-net/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach [Informationen zu eingebetteten Schriftarten](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [tatsächlich im Inhalt verwendeten Schriftarten](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_fonts/), um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [Folien‑Sammlung](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidecollection/) und prüfen Sie das [Sichtbarkeits‑Flag](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/hidden/) jeder Folie.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und Ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [Foliengröße](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slide_size/) und Ausrichtung mit den Standard‑Voreinstellungen; dies hilft, das Verhalten beim Drucken und Export vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu prüfen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [Diagramme](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/), prüfen Sie deren [Datenquelle](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/data_source_type/) und stellen Sie fest, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich „schwere“ Folien bewerten, die die Darstellung oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Performance‑Engpässe zu kennzeichnen.