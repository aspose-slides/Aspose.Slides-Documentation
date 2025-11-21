---
title: Präsentation untersuchen
type: docs
weight: 30
url: /de/nodejs-java/examine-presentation/
keywords:
- PowerPoint
- Präsentation
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- PPTX
- PPT
- JavaScript
- Node
description: "PowerPoint-Präsentationseigenschaften in Node lesen und ändern"
---

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, eine Präsentation zu untersuchen, um deren Eigenschaften zu ermitteln und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die Klassen [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) und [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/) enthalten die Eigenschaften und Methoden, die in den hier beschriebenen Vorgängen verwendet werden.

{{% /alert %}} 

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation überprüfen, ohne sie zu laden. Siehe diesen JavaScript-Code:
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```


## **Abrufen von Präsentationseigenschaften**

Dieser JavaScript-Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) abrufen können:
```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```


Sie möchten möglicherweise die [Eigenschaften in der DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) Klasse sehen.

## **Aktualisieren von Präsentationseigenschaften**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) zur Verfügung, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint-Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten können:
```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```


Die Ergebnisse der Änderung der Dokumenteigenschaften werden unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen zu erhalten, können diese Links nützlich sein:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor sie geladen wird](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des zur Sicherung einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Wie kann ich prüfen, ob Schriften eingebettet sind und welche das sind?**

Suchen Sie nach [Informationen zu eingebetteten Schriften](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [tatsächlich im Inhalt verwendeten Schriften](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/), um zu ermitteln, welche Schriften für die Darstellung kritisch sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [Folienkollektion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) und prüfen Sie für jede Folie das [Sichtbarkeits‑Flag](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/).

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Standardeinstellungen abweicht?**

Ja. Vergleichen Sie die aktuelle [Foliengröße](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslidesize/) und Ausrichtung mit den Standard‑Voreinstellungen; dies hilft, das Verhalten beim Drucken und Export vorherzusehen.

**Gibt es eine schnelle Methode, um zu erkennen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchlaufen Sie alle [Diagramme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/), prüfen Sie deren [Datenquelle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) und stellen Sie fest, ob die Daten intern oder verknüpft sind, einschließlich etwaiger defekter Links.

**Wie kann ich „schwere“ Folien bewerten, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und achten Sie auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um mögliche Leistungsspitzen zu kennzeichnen.