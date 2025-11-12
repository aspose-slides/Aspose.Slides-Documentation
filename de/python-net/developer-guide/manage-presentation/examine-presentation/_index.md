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
Die Klassen PresentationInfo und DocumentProperties enthalten die Eigenschaften und Methoden, die hier verwendet werden. 
{{% /alert %}} 

## **Präsentationsformat prüfen**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP usw.) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation prüfen, ohne die Präsentation zu laden. Siehe diesen Python‑Code:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Präsentationseigenschaften abrufen**

Dieser Python‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen über die Präsentation) erhalten:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Sie können die [properties unter der DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties)-Klasse ansehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode PresentationInfo.update_document_properties zur Verfügung, mit der Sie Änderungen an den Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Originale Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Code‑Beispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Die Ergebnisse der Änderungen der Dokumenteigenschaften sind unten dargestellt.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen über eine Präsentation und deren Sicherheitsattribute zu erhalten, können diese Links nützlich sein:

- [Überprüfung, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfung, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfung, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigung des zum Schutz einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach eingebetteten Schriftartinformationen auf der Präsentationsebene und vergleichen Sie diese Einträge anschließend mit dem Satz der tatsächlich im Inhalt verwendeten Schriftarten, um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die Folienkollektion und prüfen Sie für jede Folie das Sichtbarkeitsflag.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Standardwerten abweichen?**

Ja. Vergleichen Sie die aktuelle Foliengröße und -ausrichtung mit den Standardvorgaben; dies hilft, das Verhalten für Druck und Export vorherzusehen.

**Gibt es eine schnelle Methode, um zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle Diagramme, prüfen Sie deren Datenquelle und notieren Sie, ob die Daten intern oder verlinkt sind, einschließlich eventuell defekter Links.

**Wie kann ich 'schwere' Folien beurteilen, die die Darstellung oder den PDF‑Export verlangsamen könnten?**

Für jede Folie zählen Sie die Objektanzahl und achten auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Leistungshotspots zu kennzeichnen.