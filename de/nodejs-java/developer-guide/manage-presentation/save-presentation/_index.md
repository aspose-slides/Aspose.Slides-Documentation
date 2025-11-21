---
title: Präsentationen in JavaScript speichern
linktitle: Präsentationen speichern
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
- Strict Office Open XML-Format
- Zip64-Modus
- Vorschaubild aktualisieren
- Speicherfortschritt
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in JavaScript mit Aspose.Slides—Export nach PowerPoint oder OpenDocument bei gleichzeitiger Beibehaltung von Layouts, Schriftarten und Effekten."
---

## **Übersicht**

[Open Presentations in JavaScript](/slides/de/nodejs-java/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine bestehende ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für Node.js können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man eine Präsentation mit Aspose.Slides speichert.
```js
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

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erzeugen wir eine neue Präsentation und speichern sie in einen Dateistream.
```js
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


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die Anfangsansicht festzulegen, die PowerPoint verwendet, wenn die erzeugte Präsentation geöffnet wird, über die [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/) Klasse. Verwenden Sie die [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) Methode mit einem Wert aus der [ViewType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/) Aufzählung.
```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Präsentationen im Strict Office Open XML-Format speichern**

Aspose.Slides ermöglicht es Ihnen, eine Präsentation im Strict Office Open XML‑Format zu speichern. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/) Klasse und setzen Sie deren Conformance‑Eigenschaft beim Speichern. Wenn Sie [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) … setzen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.
```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation();
try {
    // Speichern Sie die Präsentation im Strict Office Open XML‑Format.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Präsentationen im Office Open XML-Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Grenzen von 4 GB (2^32 Bytes) für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtabmessungen des Archivs festlegt und zudem auf 65 535 (2^16‑1) Dateien beschränkt. ZIP64‑Format‑Erweiterungen erhöhen diese Grenzen auf 2^64.

Die Methode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) ermöglicht es Ihnen, festzulegen, wann beim Speichern einer Office Open XML‑Datei ZIP64‑Format‑Erweiterungen verwendet werden sollen.

Diese Methode kann mit den folgenden Modi verwendet werden:

- [IfNecessary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64‑Format‑Erweiterungen nur, wenn die Präsentation die oben genannten Einschränkungen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) verwendet ZIP64‑Format‑Erweiterungen nie.
- [Always](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Always) verwendet ZIP64‑Format‑Erweiterungen immer.

Der folgende Code demonstriert, wie man eine Präsentation als PPTX mit aktivierten ZIP64‑Format‑Erweiterungen speichert:
```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="HINWEIS" color="warning" %}}
Wenn Sie mit [Zip64Mode.Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) … speichern, wird eine [PptxException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxexception/) … ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen ohne Aktualisierung des Vorschaubildes speichern**

Die Methode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) steuert die Erzeugung des Vorschaubildes beim Speichern einer Präsentation als PPTX:

- Wenn auf `true` gesetzt, wird das Vorschaubild beim Speichern aktualisiert. Dies ist die Standardeinstellung.
- Wenn auf `false` gesetzt, bleibt das aktuelle Vorschaubild erhalten. Hat die Präsentation kein Vorschaubild, wird keines erzeugt.

Im nachfolgenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Vorschaubild zu aktualisieren.
```js
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
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit zu verkürzen.
{{% /alert %}}

## **Speicherfortschritt in Prozent melden**

Die Meldung des Speicherfortschritts wird über die Methode [setProgressCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) auf [SaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) und deren Unterklassen konfiguriert. Stellen Sie einen Java‑Proxy bereit, der das [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) Interface implementiert; während des Exports erhält das Callback periodisch Prozent‑Updates.

Die folgenden Code‑Snippets zeigen, wie man `IProgressCallback` verwendet.
```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Verwenden Sie hier den Fortschrittswert in Prozent.
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
Aspose hat eine [kostenlose PowerPoint‑Splitter‑App](https://products.aspose.app/slides/splitter) entwickelt, die es ermöglicht, eine Präsentation in mehrere Dateien zu teilen, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „Fast Save“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die komplette Zieldatei erstellt; inkrementelles „Fast Save“ wird nicht unterstützt.

**Ist es thread‑sicher, dieselbe Presentation‑Instanz aus mehreren Threads zu speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Instanz [ist nicht thread‑sicher](/slides/de/nodejs-java/multithreading/); speichern Sie sie aus einem einzigen Thread.

**Was passiert mit Hyperlinks und extern verlinkten Dateien beim Speichern?**

[Hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) werden beibehalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin erreichbar sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Unternehmen, Datum) setzen/speichern?**

Ja. Standard‑[document properties](/slides/de/nodejs-java/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.