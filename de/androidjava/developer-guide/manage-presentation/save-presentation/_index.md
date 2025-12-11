---
title: Präsentationen auf Android speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/androidjava/save-presentation/
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
- Thumbnail aktualisieren
- Speicherfortschritt
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in Java mit Aspose.Slides für Android speichern — exportieren Sie zu PowerPoint oder OpenDocument und behalten dabei Layouts, Schriftarten und Effekte bei."
---

## **Übersicht**

[Öffnen von Präsentationen auf Android](/slides/de/androidjava/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie nach Abschluss speichern. Mit Aspose.Slides für Android können Sie in einer **Datei** oder einem **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie eine Präsentation mit Aspose.Slides gespeichert wird.
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Führen Sie hier einige Arbeiten aus...

    // Speichern Sie die Präsentation in einer Datei.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im nachfolgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Speichern Sie die Präsentation in den Stream.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **Präsentationen mit vordefiniertem Ansichtsmodus speichern**

Aspose.Slides ermöglicht das Festlegen der anfänglichen Ansicht, die PowerPoint beim Öffnen der generierten Präsentation verwendet, über die [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/)‑Klasse. Verwenden Sie die [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-)‑Methode mit einem Wert aus der [ViewType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/)‑Aufzählung.
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Präsentationen im Strict Office Open XML‑Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/)‑Klasse und setzen Sie deren `conformance`‑Eigenschaft beim Speichern. Wenn Sie [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das nachstehende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.
```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
Presentation presentation = new Presentation();
try {
    // Speichern Sie die Präsentation im Strict Office Open XML-Format.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) Grenzen für die nicht komprimierte Größe einzelner Dateien, die komprimierte Größe einzelner Dateien und die Gesamtgröße des Archivs festlegt und zudem die Anzahl der Dateien auf 65 535 (2^16‑1) begrenzt. ZIP64‑Formatserweiterungen erhöhen diese Grenzen auf 2^64.

Die [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑Methode ermöglicht die Auswahl, wann ZIP64‑Formatserweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden sollen.

Diese Methode kann mit den folgenden Modi verwendet werden:

- [IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64‑Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) verwendet ZIP64‑Erweiterungen niemals.
- [Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) verwendet ZIP64‑Erweiterungen immer.

Der folgende Code demonstriert, wie eine Präsentation als PPTX mit aktivierten ZIP64‑Erweiterungen gespeichert wird:
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}}
Wenn Sie mit [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) speichern, wird eine [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen ohne Aktualisierung des Thumbnails speichern**

Die [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)‑Methode steuert die Thumbnail‑Erzeugung beim Speichern einer Präsentation im PPTX‑Format:

- Ist sie auf `true` gesetzt, wird das Thumbnail beim Speichern aktualisiert. Dies ist die Standardeinstellung.
- Ist sie auf `false` gesetzt, bleibt das aktuelle Thumbnail erhalten. Gibt es kein Thumbnail, wird keines erzeugt.

Im nachstehenden Code wird die Präsentation im PPTX‑Format gespeichert, ohne das Thumbnail zu aktualisieren.
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
Diese Option reduziert die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit.
{{% /alert %}}

## **Speicherfortschritt in Prozent anzeigen**

Das [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/)‑Interface wird über die `setProgressCallback`‑Methode der [ISaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isaveoptions/)‑Schnittstelle und der abstrakten [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/)‑Klasse verwendet. Implementieren Sie ein [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) und übergeben Sie es mit `setProgressCallback`, um Speicherfortschritts‑Updates als Prozentsatz zu erhalten.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.
```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Verwenden Sie hier den Fortschrittswert in Prozent.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
Aspose hat eine **kostenlose PowerPoint Splitter‑App** (https://products.aspose.app/slides/splitter) entwickelt, die die eigene API nutzt. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „Fast Save“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die gesamte Zieldatei neu erstellt; inkrementelles „Fast Save“ wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads thread‑sicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Instanz ist **nicht thread‑sicher** (/slides/de/androidjava/multithreading/); speichern Sie sie aus einem einzigen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

[Hyperlinks](/slides/de/androidjava/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin erreichbar sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/androidjava/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.