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
- Folien speichern
- PPT speichern
- PPTX speichern
- ODP speichern
- Präsentation in Datei
- Präsentation in Stream
- vordefinierter Ansichtstyp
- Strict Office Open XML-Format
- Zip64-Modus
- Vorschaubild aktualisieren
- Speicherfortschritt
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie, wie Sie Präsentationen mit Aspose.Slides für Node.js über Java speichern – Export nach PowerPoint oder OpenDocument unter Beibehaltung von Layouts, Schriften und Effekten."
---
## **Übersicht**

[Open Presentations in JavaScript](/slides/de/nodejs-java/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse enthält den Inhalt einer Präsentation. Ob Sie nun eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für Node.js können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie Sie mit Aspose.Slides eine Präsentation speichern.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Führen Sie hier einige Arbeiten aus...

    // Speichern Sie die Präsentation in einer Datei.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Speichern Sie die Präsentation in den Stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Präsentationen mit einem vordefinierten Ansichtstyp speichern**

Aspose.Slides lässt Sie die anfängliche Ansicht festlegen, die PowerPoint verwendet, wenn die erzeugte Präsentation geöffnet wird, über die [ViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/)‑Klasse. Verwenden Sie die [setLastView](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/#setLastView)‑Methode mit einem Wert aus der [ViewType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewtype/)‑Aufzählung.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Strict Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/)‑Klasse und setzen Sie deren conformance‑Eigenschaft beim Speichern. Wenn Sie [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das nachfolgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Speichern Sie die Präsentation im Strict Office Open XML-Format.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Office Open XML-Format im Zip64-Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) Grenzen für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtgröße des Archivs auferlegt und außerdem das Archiv auf 65 535 (2^16‑1) Dateien beschränkt. ZIP64‑Format‑Erweiterungen erhöhen diese Grenzen auf 2^64.

Die [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode)‑Methode lässt Sie wählen, wann ZIP64‑Format‑Erweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden sollen.

Diese Methode kann mit den folgenden Modi verwendet werden:

- [IfNecessary](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64‑Format‑Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#Never) verwendet ZIP64‑Format‑Erweiterungen nie.
- [Always](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#Always) verwendet ZIP64‑Format‑Erweiterungen immer.

Der folgende Code demonstriert, wie Sie eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Format‑Erweiterungen speichern:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Wenn Sie mit [Zip64Mode.Never](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zip64mode/#Never) speichern, wird eine [PptxException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen im Office Open XML-Format mit Komprimierungsstufen speichern**

Bei großen Präsentationen können Sie die Komprimierungsstufe anpassen, um Dateigröße und Verarbeitungszeit auszubalancieren. Je nach Anforderung bevorzugen Sie eventuell schnellere Verarbeitung oder kleinere Ausgabedateien.

Aspose.Slides bietet die [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel)‑Methode, mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format verwendete Komprimierungsstufe festlegen können.

Folgende Komprimierungsstufen stehen zur Verfügung:

- [**None**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#None): Es wird keine Komprimierung angewendet. Dateien werden unverändert gespeichert.
- [**Level1**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level1): Schnellste Komprimierung bei geringstem Komprimierungs‑Verhältnis.
- [**Level2**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level2): Schnellere Komprimierung mit leicht besserem Komprimierungs‑Verhältnis als **Level1**.
- [**Level3**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level3): Bietet bessere Komprimierung als **Level2** bei mäßigem Einfluss auf die Verarbeitungszeit.
- [**Level4**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level4): Bietet bessere Komprimierung als **Level3**.
- [**Level5**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level5): Verbesserte Komprimierung gegenüber **Level4** mit zusätzlicher Verarbeitungszeit.
- [**Level6**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level6): Standard‑Komprimierung, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standard‑Komprimierungsstufe*.
- [**Level7**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level7): Bietet bessere Komprimierung als **Level6** bei langsamerer Verarbeitung.
- [**Level8**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level8): Bietet bessere Komprimierung als **Level7**.
- [**Level9**](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compressionlevel/#Level9): Maximale Komprimierung. Erzeugt die kleinste Dateigröße auf Kosten der längsten Verarbeitungszeit.

Das folgende Beispiel zeigt, wie Sie eine Präsentation als PPTX‑Datei *ohne Komprimierung* speichern:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Dieses Beispiel zeigt, wie Sie eine Präsentation als PPTX‑Datei mit *maximaler Komprimierung* speichern:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Präsentationen speichern, ohne das Vorschaubild zu aktualisieren**

Die [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail)‑Methode steuert die Generierung des Vorschaubilds beim Speichern einer Präsentation als PPTX:

- Wenn sie auf `true` gesetzt ist, wird das Vorschaubild während des Speicherns aktualisiert. Dies ist die Vorgabe.
- Wenn sie auf `false` gesetzt ist, bleibt das aktuelle Vorschaubild erhalten. Hat die Präsentation kein Vorschaubild, wird keines erzeugt.

Im folgenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Vorschaubild zu aktualisieren.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format erforderliche Zeit zu reduzieren.
{{% /alert %}}

## **Speicherfortschritts‑Updates in Prozent**

Die Fortschrittsberichterstattung beim Speichern wird über die [setProgressCallback](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveoptions/#setProgressCallback)‑Methode auf [SaveOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveoptions/) und deren Unterklassen konfiguriert. Geben Sie einen Java‑Proxy an, der das [IProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/)‑Interface implementiert; während des Exports erhält der Callback periodische Prozent‑Updates.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Verwenden Sie hier den Fortschrittsprozentsatz.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose hat eine *kostenlose* PowerPoint‑Splitter‑App entwickelt, die die eigene API nutzt. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „Schnellspeichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die komplette Zieldatei erstellt; ein inkrementelles „Schnellspeichern“ wird nicht unterstützt.

**Ist das Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Instanz ist nicht threadsicher; speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

[Hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) festlegen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/nodejs-java/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.