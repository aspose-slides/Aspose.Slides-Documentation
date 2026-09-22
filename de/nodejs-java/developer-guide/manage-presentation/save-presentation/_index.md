---
title: Präsentationen in JavaScript speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/nodejs-java/save-presentation/
keywords:
- PowerPoint speichern
- OpenDocument speichern
- Präsentation speichern
- Folie speichern
- PPT speichern
- PPTX speichern
- ODP speichern
- Präsentation in Datei
- Präsentation in Stream
- vordefinierter Ansichtstyp
- Striktes Office Open XML-Format
- Zip64-Modus
- Thumbnail aktualisieren
- Speicherfortschritt
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in JavaScript mit Aspose.Slides in Dateien oder Streams speichern und die PPTX-Ausgabe sowie Fortschrittsberichte konfigurieren."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene öffnen](/slides/de/nodejs-java/open-presentation/), verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) Methode, um das Ergebnis zu schreiben. Aspose.Slides für Node.js via Java kann eine Präsentation in eine Datei oder einen Stream in PowerPoint-, OpenDocument-, PDF- und anderen Formaten speichern. Die folgenden Abschnitte behandeln die Standard‑Speichervorgänge und die für PPTX‑Ausgabe verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save)‑Methode. Der Formatwert bestimmt den Dateityp, den Aspose.Slides erstellt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Präsentationsinhalte hier hinzufügen oder ändern.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Originalformat speichern**

Beispiele zur Date- und Stream‑Erkennung, zum Verhalten neu erstellter Präsentationen und zum Unterschied zwischen Quell‑ und Ausgabeformaten finden Sie unter [Determine the Original Presentation Format](/slides/de/nodejs-java/detect-presentation-source-format/).

In einer Stapelverarbeitungs‑Anwendung ist das Eingabeformat möglicherweise nicht im Voraus bekannt. Nach dem Laden einer Datei lesen Sie das Originalformat über die Methode [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSourceFormat). Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sourceformat/)‑Wert an [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideutil/#toSaveFormat), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/)‑Wert zu erhalten, und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save), um die geänderte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in ein Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideutil/#toSaveFormat) ordnet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML den jeweiligen Präsentations‑Speicherformaten zu. Es mappt nur Präsentations‑Quellformate; es ist nicht dazu gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Die Übergabe eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sourceformat/)‑Werts führt zu einem Fehler.

Legacy‑PPT-, PPS‑ und POT‑Dateien verwenden denselben Binärcontainer. Wird eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn die Beibehaltung dieser Legacy‑Subtypen erforderlich ist, bewahren Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat auf und verwenden Sie diese bei der Wahl des Ausgabedateinamens und -formats.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne sich auf einen endgültigen Dateipfad zu verlassen, übergeben Sie einen beschreibbaren Stream und einen [SaveFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save)‑Methode. Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Web‑Service zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

Das folgende Beispiel speichert eine neue Präsentation in einen Dateistream:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Verwenden Sie die Methode [ViewProperties.setLastView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#setLastView) mit einem [ViewType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewtype/)‑Wert vor dem Speichern.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Anfangsansicht:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im strikten Office Open XML‑Format speichern**

Um eine PPTX‑Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erzeugen Sie eine Instanz von [PptxOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/) und verwenden deren Methode [setConformance](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/#setConformance) mit [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Anschließend übergeben Sie die Optionen an die [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save)‑Methode.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtarchivgröße und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen erhöhen die jeweiligen Größen‑ und Eintragsanzahl‑Grenzen.

Verwenden Sie die Methode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode), um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- [IfNecessary](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#Never) deaktiviert ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#Always) schreibt stets ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert ZIP64‑Erweiterungen für die Ausgabepäsentation stets:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Wenn [Zip64Mode.Never](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#Never) verwendet wird und die Präsentation nicht in die Standard‑ZIP‑Grenzen passt, wirft der Speicher­vorgang eine [PptxException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Kompressionsstufen speichern**

Für PPTX‑Ausgaben können Sie die Speicher­geschwindigkeit gegenüber der Dateigröße ausbalancieren, indem Sie die Methode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) verwenden. Die Klasse [CompressionLevel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/) stellt folgende Werte bereit:

- [None](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#None) speichert Daten ohne Kompression.
- [Level1](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level1) liefert die schnellste Kompression und das größte komprimierte Ergebnis.
- [Level2](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level2) bis [Level5](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level5) bevorzugen zunehmend kleinere Ausgaben gegenüber der Speicher­geschwindigkeit.
- [Level6](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level6) balanciert Speicher­geschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- [Level7](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level7) und [Level8](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level8) bevorzugen noch stärker kleinere Ausgaben gegenüber der Geschwindigkeit.
- [Level9](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level9) bietet die stärkste Kompression und erfordert die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Kompression:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Das folgende Beispiel verwendet die maximale Kompressionsstufe:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Präsentationen ohne Aktualisierung des Thumbnails speichern**

Wenn eine Präsentation als PPTX gespeichert wird, steuert die Methode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) das Dokument‑Thumbnail:

- `true` regeneriert das Thumbnail während des Speicher­vorgangs. Dies ist der Standardwert.
- `false` bewahrt das vorhandene Thumbnail. Hat die Präsentation kein Thumbnail, erzeugt Aspose.Slides keines.

Das folgende Beispiel speichert eine Präsentation, ohne ihr Thumbnail zu aktualisieren:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Das Deaktivieren der Thumbnail‑Aktualisierung kann die zum Speichern einer PPTX‑Datei benötigte Zeit verkürzen.
{{% /alert %}}

## **Speicher‑Fortschritts‑Updates in Prozent**

Um einen Speicher­vorgang zu überwachen, implementieren Sie das [IProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/)‑Interface mit einem Java‑Proxy und übergeben die Implementierung an die Methode [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides ruft dann die Methode [IProgressCallback.reporting](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/#reporting-double-) mit Fortschrittswerten während des Exports auf.

Das folgende Beispiel meldet den Fortschritt eines PDF‑Exports in der Konsole:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) an, der mit der Aspose.Slides‑API erstellt wurde. Er speichert ausgewählte Folien einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „Fast Save“?**

Nein. Jeder Speicher­vorgang schreibt eine vollständige Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz ist [is not thread-safe](/slides/de/nodejs-java/multithreading/). Greifen Sie auf jede Instanz zu und speichern Sie sie jeweils nur von einem Thread.

**Was passiert mit Hyperlinks und extern verlinkten Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) bleiben in der Präsentation erhalten. Aspose.Slides kopiert keine extern verlinkten Dateien, sodass die gespeicherte Präsentation weiterhin auf deren Speicherorte zugreifen muss.

**Kann ich Dokument‑Metadaten wie Autor, Titel, Firma und Erstellungsdatum speichern?**

Ja. Setzen Sie vor dem Speichern die entsprechenden [document properties](/slides/de/nodejs-java/presentation-properties/), und Aspose.Slides schreibt sie in die Ausgabedatei.