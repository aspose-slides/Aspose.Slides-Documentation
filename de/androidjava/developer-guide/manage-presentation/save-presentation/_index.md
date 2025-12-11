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
description: "Entdecken Sie, wie Sie Präsentationen in Java mit Aspose.Slides für Android speichern—Export zu PowerPoint oder OpenDocument bei gleichzeitigem Erhalt von Layouts, Schriftarten und Effekten."
---

## **Übersicht**

[Open Presentations on Android](/slides/de/androidjava/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie nach Abschluss speichern. Mit Aspose.Slides für Android können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse aufrufen. Übergeben Sie dem Aufruf den Dateinamen und das Speicherformat. Das folgende Beispiel zeigt, wie Sie eine Präsentation mit Aspose.Slides speichern.
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
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

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im Beispiel unten erzeugen wir eine neue Präsentation und speichern sie in einen Dateistream.
```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
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


## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/)‑Klasse. Verwenden Sie die [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-)‑Methode mit einem Wert aus der [ViewType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/)‑Aufzählung.
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Präsentationen im Strict Office Open XML-Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/)‑Klasse und setzen Sie deren *conformance*‑Eigenschaft beim Speichern. Wenn Sie [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.
```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation();
try {
    // Speichern Sie die Präsentation im Strict Office Open XML-Format.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **Präsentationen im Office Open XML-Format im Zip64-Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das 4 GB (2^32 Bytes) für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtabmessungen des Archivs begrenzt und außerdem maximal 65 535 (2^16‑1) Dateien zulässt. Die ZIP64‑Format‑Erweiterungen erhöhen diese Grenzen auf 2^64.

Die [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-)‑Methode ermöglicht es Ihnen, festzulegen, wann beim Speichern einer Office Open XML‑Datei ZIP64‑Erweiterungen verwendet werden.

Diese Methode kann mit den folgenden Modi verwendet werden:

- [IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64‑Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) verwendet niemals ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) verwendet immer ZIP64‑Erweiterungen.

Der folgende Code demonstriert, wie Sie eine Präsentation als PPTX mit aktivierten ZIP64‑Erweiterungen speichern:
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


{{% alert title="HINWEIS" color="warning" %}}
Wenn Sie mit [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) speichern, wird eine [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen ohne Aktualisierung des Thumbnails speichern**

Die [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-)‑Methode steuert die Thumbnail‑Erstellung beim Speichern einer Präsentation im PPTX‑Format:

- Wenn sie auf `true` gesetzt ist, wird das Thumbnail während des Speicherns aktualisiert. Dies ist der Standardwert.
- Wenn sie auf `false` gesetzt ist, bleibt das vorhandene Thumbnail erhalten. Hat die Präsentation kein Thumbnail, wird keines erzeugt.

Im nachfolgenden Code wird die Präsentation als PPTX gespeichert, ohne das Thumbnail zu aktualisieren.
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
Diese Option verkürzt die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit.
{{% /alert %}}

## **Fortschrittsupdates beim Speichern in Prozent**

Das [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/)‑Interface wird über die `setProgressCallback`‑Methode des [ISaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isaveoptions/)‑Interfaces bzw. der abstrakten [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/)‑Klasse verwendet. Durch Zuweisung einer [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/)‑Implementierung mittels `setProgressCallback` erhalten Sie Speicher‑Fortschrittsupdates als Prozentsatz.

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
        // Verwenden Sie hier den Fortschrittsprozentsatz.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
Aspose hat eine kostenfreie PowerPoint‑Splitter‑App entwickelt, die über die eigene API verfügt. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird „schnelles Speichern“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erzeugt; ein inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Instanz ist nicht threadsicher; Sie sollte nur aus einem einzigen Thread gespeichert werden.

**Was passiert mit Hyperlinks und extern verlinkten Dateien beim Speichern?**

[Hyperlinks](/slides/de/androidjava/manage-hyperlinks/) bleiben erhalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin erreichbar sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/androidjava/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.