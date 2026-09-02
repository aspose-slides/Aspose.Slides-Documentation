---
title: Abrufen und Aktualisieren von Präsentationsinformationen in JavaScript
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit JavaScript für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Präsentationsinformationen in Aspose.Slides inspiziert. Er erklärt, wie man das aktuelle Format einer Präsentation ermittelt, ohne die gesamte Datei zu laden, ihre Dokumenteigenschaften ausliest und bei Bedarf diese Eigenschaften aktualisiert.

Die Beispiele basieren auf den APIs [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/) und demonstrieren typische Vorgänge beim Arbeiten mit Metadaten von Präsentationen.

## **Prüfen des Präsentationsformats**

Bevor Sie mit einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und weitere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation prüfen, ohne die Präsentation zu laden. Siehe dazu diesen JavaScript‑Code:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Präsentations‑Eigenschaften abrufen**

Dieser JavaScript‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) erhalten:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Sie können die [Eigenschaften in der Klasse DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) einsehen.

## **Präsentations‑Eigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Originale Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Dieses Code‑Beispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten dargestellt.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen finden Sie hier:

- [Password-Protect Presentations](/slides/de/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/nodejs-java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche das sind?**

Suchen Sie nach [Informationen zu eingebetteten Schriftarten](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit dem Satz der [tatsächlich im Inhalt verwendeten Schriften](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getfonts/), um zu ermitteln, welche Schriften für die Darstellung kritisch sind.

**Wie erkenne ich schnell, ob die Datei verborgene Folien enthält und wie viele es sind?**

Durchlaufen Sie die [Slide‑Collection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidecollection/) und prüfen Sie bei jeder Folie die [Sichtbarkeits‑Flagge](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/gethidden/).

**Kann ich feststellen, ob benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgabewerten abweichen?**

Ja. Vergleichen Sie die aktuelle [Foliengröße](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslidesize/) und Ausrichtung mit den Standard‑Presets; das hilft, das Verhalten beim Drucken und Exportieren vorherzusehen.

**Gibt es eine schnelle Methode, um zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [Charts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/), prüfen Sie deren [Datenquelle](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) und notieren Sie, ob die Daten intern oder verknüpft sind, einschließlich eventuell defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und suchen Sie nach großen Bildern, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Performance‑Hotspots zu kennzeichnen.