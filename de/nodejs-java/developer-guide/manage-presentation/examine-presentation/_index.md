---
title: Präsentationsinformationen in JavaScript abrufen und aktualisieren
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
description: "Erkunden Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit JavaScript für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation erkennen und deren Dokumentmetadaten auslesen, ohne ein vollständiges Präsentationsobjektmodell zu erstellen. Das ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen müssen, bevor Sie entscheiden, ob Sie den Präsentationsinhalt laden und verarbeiten.

Dieser Artikel demonstriert die leichte Inspektion über [PresentationFactory](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/) und [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/), sowie gezielte Aktualisierungen über [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/).

## **Prüfen des Präsentationsformats**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/), um eine Datei zu prüfen, ohne eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz zu erstellen. Die Methode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/getloadformat/) gibt das erkannte Format zurück, z. B. PPTX, PPT oder ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Leichtes Präsentationsinventar erstellen**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar für Validierung, Indexierung oder ein Dokument‑Management‑System. In diesem Szenario nutzen Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/), um ein [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/)‑Objekt zu erhalten, und rufen dann [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) auf, um die Dokumentmetadaten auszulesen. Dieser Ansatz erstellt keine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz und erfordert kein Durchlaufen des vollständigen Präsentationsobjektmodells.

Die erweiterten Eigenschaften, die von [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/) bereitgestellt werden, liefern folgende Inventarwerte:

| Methode | Inventarwert |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getSlides) | Gesamtzahl der Folien. |
| [getHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Anzahl versteckter Folien. |
| [getNotes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getNotes) | Anzahl der Folien, die Notizen enthalten. |
| [getParagraphs](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Gesamtzahl der Absätze, falls verfügbar. |
| [getWords](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getWords) | Gesamtzahl der Wörter. |
| [getMultimediaClips](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Gesamtzahl der Audio‑ und Video‑Clips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Es kombiniert außerdem [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) mit [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts), um Inhaltsgruppen wie Schriftarten, Designs und Folientitel anzuzeigen.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Jedes [HeadingPair](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/headingpair/) liefert über [HeadingPair.getName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/headingpair/#getName) einen Gruppennamen und über [HeadingPair.getCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/headingpair/#getCount) die Anzahl der Elemente in dieser Gruppe. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) gibt ein flaches, geordnetes Array zurück, sodass Sie die angegebene Anzahl aufeinanderfolgender Titel jeder Überschriftengruppe konsumieren.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) zurückgegebenen Inventareigenschaften spiegeln die im Quelldokument verfügbaren Metadaten wider. Aspose.Slides lädt und durchläuft das Präsentationsobjektmodell nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format stellt erweiterte Dokumenteigenschaften für Folien‑, Notiz‑, versteckte‑Folien‑, Absatz‑, Wort‑ und Multimedia‑Zähler sowie Überschriftenpaare und Teil‑Titel bereit. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.
- **PPT:** Das Binärformat kann entsprechende Dokument‑Zusammenfassungs‑Eigenschaften speichern. Wenn eine Eigenschaft fehlt oder nicht vom Dokumentersteller aktualisiert wurde, gibt Aspose.Slides ihren gespeicherten oder Standardwert zurück, anstatt sie aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten liefern allgemeine Dokumentstatistiken, wie Seiten‑, Absatz‑ und Wort‑Zähler, aber diese Werte lassen sich nicht auf jede PowerPoint‑spezifische erweiterte Eigenschaft abbilden. Metadaten zu versteckten Folien, Notiz‑Folien, Multimedia, Überschriftenpaaren und Teil‑Titeln können fehlen, und die Inventar‑Eigenschaften können Standardwerte zurückgeben. Behandeln Sie keinen Null‑Wert oder ein leeres Array als autoritativen Beweis dafür, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadatenansatz für Inventare und Vorabprüfungen. Laden Sie die Präsentation und prüfen Sie ihr Live‑Objektmodell, wenn das Ergebnis im Speichergehalt reflektiert werden muss oder wenn Sie den tatsächlichen Präsentationsinhalt verifizieren müssen.

## **Präsentationseigenschaften aktualisieren**

Die von [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz zu erstellen. Wenden Sie die Änderungen mit [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) an und schreiben Sie anschließend die gebundene Präsentation mit [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften.

![Originale Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Das folgende Beispiel ändert den Titel und den Zeitpunkt der letzten Speicherung und schreibt das Ergebnis in eine neue Datei:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Das folgende Bild zeigt die aktualisierten Dokumenteigenschaften.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Präsentationen mit Passwort schützen](/slides/de/nodejs-java/password-protected-presentation/)
- [Präsentationen vor Schreibzugriff schützen](/slides/de/nodejs-java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation.getFontsManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getfontsmanager/). Rufen Sie [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) auf, um die eingebetteten Schriftarten zu erhalten, und [FontsManager.getFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getfonts/), um die von der Präsentation verwendeten Schriftarten zu erhalten. Vergleichen Sie die beiden Ergebnisse, um Schriftarten zu finden, die für die Wiedergabe benötigt, aber nicht eingebettet sind.

**Wie kann ich schnell feststellen, ob die Datei versteckte Folien enthält und wie viele?**

Wenn gespeicherte Dokumentmetadaten ausreichen, lesen Sie [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) über [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) und [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Dies eignet sich für ein leichtes Inventar. Wenn die Präsentation im Speicher verändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein, oder Sie müssen Live‑Werte prüfen, indem Sie durch [Presentation.getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslides/) iterieren und für jede Folie die Methode [Slide.getHidden](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/gethidden/) prüfen.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und Ausrichtung verwendet wird und ob sie von den Vorgaben abweicht?**

Ja. Laden Sie die Präsentation und rufen Sie [Presentation.getSlideSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslidesize/) auf. Verwenden Sie [SlideSize.getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/getsize/) und [SlideSize.getOrientation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/getorientation/), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchsuchen Sie jede [Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/) und rufen Sie [ChartData.getDataSourceType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) auf. Für ein externes Arbeitsbuch rufen Sie [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) auf. Der Datentyp und der Pfad identifizieren eine externe Referenz, aber die Überprüfung, ob das Ziel verfügbar ist, erfordert eine separate Ressourcenprüfung.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation.getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslides/) und für jede Folie die Sammlung [BaseSlide.getShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getShapes). Nutzen Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Screening‑Signal und messen Sie ein repräsentatives Render‑ oder Export‑Ergebnis, bevor Sie eine Folie als bestätigten Leistungsengpass einstufen.