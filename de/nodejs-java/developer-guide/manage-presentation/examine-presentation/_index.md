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
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit JavaScript für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation ermitteln und die Metadaten des Dokuments lesen, ohne ein vollständiges Präsentationsobjektmodell zu erstellen. Das ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen wollen, bevor Sie entscheiden, ob der Präsentationsinhalt geladen und verarbeitet werden soll.

Dieser Artikel demonstriert die leichte Inspektion über [PresentationFactory](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/) und [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/), sowie gezielte Aktualisierungen über [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/).

## **Präsentationsformat prüfen**

Falls Sie bereits eine geladene Präsentation haben, lesen Sie [Determine the Original Presentation Format](/slides/de/nodejs-java/detect-presentation-source-format/) für die Erkennung nach dem Laden und die Einschränkungen von legacy PPT-, PPS- und POT‑Streams.

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/), um eine Datei zu inspizieren, ohne eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz zu erstellen. Die Methode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/getloadformat/) gibt das erkannte Format zurück, z. B. PPTX, PPT oder ODP.

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

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar für Validierung, Indexierung oder ein Dokumenten‑Management‑System. Verwenden Sie in diesem Szenario [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/), um ein [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/)‑Objekt zu erhalten, und rufen Sie dann [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) auf, um die Dokument‑Metadaten zu lesen. Dieser Ansatz erstellt keine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz und erfordert nicht, das komplette Präsentationsobjektmodell zu traversieren.

Die von [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/) bereitgestellten erweiterten Eigenschaften liefern die folgenden Inventarwerte:

| Methode | Inventarwert |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getSlides) | Gesamtzahl der Folien. |
| [getHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Anzahl der ausgeblendeten Folien. |
| [getNotes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getNotes) | Anzahl der Folien, die Notizen enthalten. |
| [getParagraphs](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Gesamtzahl der Absätze, falls verfügbar. |
| [getWords](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getWords) | Gesamtzahl der Wörter. |
| [getMultimediaClips](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Gesamtzahl der Audio‑ und Videoclips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Es kombiniert zudem [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) mit [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts), um Inhaltsgruppen wie Schriftarten, Designs und Folientitel anzuzeigen.

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

Jedes [HeadingPair](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/headingpair/) liefert einen Gruppennamen über [HeadingPair.getName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/headingpair/#getName) und die Anzahl der Elemente in dieser Gruppe über [HeadingPair.getCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) gibt ein flaches, geordnetes Array zurück, sodass Sie die angegebene Anzahl aufeinanderfolgender Titel pro HeadingPair konsumieren.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) zurückgegebenen Inventareigenschaften spiegeln die Metadaten wider, die im Quell-Dokument vorhanden sind. Aspose.Slides lädt und traversiert das Präsentationsobjektmodell nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format stellt erweiterte Dokumenteigenschaften für Folien‑, Notiz‑, ausgeblendete‑Folien‑, Absatz‑, Wort‑ und Multimedia‑Zähler sowie Heading‑Pairs und Part‑Titles bereit. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.
- **PPT:** Das Binärformat kann entsprechende Dokument‑Summary‑Eigenschaften speichern. Ist eine Eigenschaft nicht vorhanden oder wurde vom Dokumentersteller nicht aktualisiert, gibt Aspose.Slides ihren gespeicherten oder Standardwert zurück, anstatt sie aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten liefern allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wortzählungen, diese Werte lassen sich jedoch nicht immer den PowerPoint‑spezifischen erweiterten Eigenschaften zuordnen. Metadaten zu ausgeblendeten Folien, Notizen‑Folien, Multimedia, Heading‑Pairs und Part‑Titles können fehlen, und die Inventareigenschaften können Standardwerte zurückgeben. Behandeln Sie weder einen Null‑Wert noch ein leeres Array als eindeutigen Beweis dafür, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadaten‑Ansatz für Inventare und Vorab‑Prüfungen. Laden Sie die Präsentation und inspizieren Sie ihr Live‑Objektmodell, wenn das Ergebnis in‑Speicher‑Änderungen widerspiegeln muss oder Sie den tatsächlichen Präsentationsinhalt verifizieren wollen.

## **Präsentationseigenschaften aktualisieren**

Die von [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne ein [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt zu erstellen. Wenden Sie die Änderungen mit [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) an und schreiben Sie die gebundene Präsentation mit [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) nieder.

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften.

![Original document properties of the PowerPoint presentation](input_properties.png)

Das folgende Beispiel ändert den Titel und den zuletzt gespeicherten Zeitpunkt und schreibt das Ergebnis in eine neue Datei:

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

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Password-Protect Presentations](/slides/de/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/nodejs-java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation.getFontsManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getfontsmanager/). Rufen Sie [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) auf, um die eingebetteten Schriftarten zu erhalten, und [FontsManager.getFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsmanager/getfonts/), um die von der Präsentation genutzten Schriftarten zu erhalten. Vergleichen Sie beide Ergebnisse, um Schriftarten zu finden, die zum Rendern erforderlich, aber nicht eingebettet sind.

**Wie kann ich schnell erkennen, ob die Datei ausgeblendete Folien enthält und wie viele?**

Wenn die gespeicherten Dokumentmetadaten ausreichen, lesen Sie [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) über [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) und [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Das ist für ein leichtes Inventar geeignet. Wenn die Präsentation jedoch im Speicher geändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein; in diesem Fall iterieren Sie über [Presentation.getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslides/) und prüfen jede Folie über [Slide.getHidden](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/gethidden/).

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und Ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Laden Sie die Präsentation und rufen Sie [Presentation.getSlideSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslidesize/) auf. Verwenden Sie [SlideSize.getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/getsize/) und [SlideSize.getOrientation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/getorientation/), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchsuchen Sie jedes [Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/) und rufen Sie [ChartData.getDataSourceType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) auf. Für eine externe Arbeitsmappe rufen Sie [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) auf. Der Datentyp und der Pfad identifizieren eine externe Referenz, aber die Verfügbarkeit des Ziels muss separat geprüft werden.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendering oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Traversieren Sie [Presentation.getSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslides/) und jede Folie über die [BaseSlide.getShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getShapes)-Sammlung. Verwenden Sie die Anzahl der Shapes sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Screening‑Signale und messen Sie ein repräsentatives Rendering oder den Export, bevor Sie eine Folie als bestätigten Performance‑Flaschenhals einstufen.