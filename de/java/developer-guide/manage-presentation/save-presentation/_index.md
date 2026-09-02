---
title: Präsentationen in Java speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/java/save-presentation/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in Java mit Aspose.Slides — Export nach PowerPoint oder OpenDocument bei gleichzeitiger Beibehaltung von Layouts, Schriftarten und Effekten."
---
## **Übersicht**

[Open Presentations in Java](/slides/de/java/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse zum Öffnen einer Präsentation verwendet wird. Dieser Artikel erklärt, wie Präsentationen erstellt und gespeichert werden. Die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine bestehende ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides for Java können Sie in eine **Datei** oder einen **Stream** speichern. Dieser Artikel erklärt die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie eine Präsentation mit Aspose.Slides gespeichert wird.

```java
import com.aspose.slides.*;

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

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im Beispiel unten erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

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

Aspose.Slides ermöglicht das Festlegen der anfänglichen Ansicht, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die [ViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/)‑Klasse. Verwenden Sie die [setLastView](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/#setLastView-int-)‑Methode mit einem Wert aus der Aufzählung [ViewType](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Strict Office Open XML‑Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die [PptxOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxoptions/)‑Klasse und setzen Sie deren `conformance`‑Eigenschaft beim Speichern. Wenn Sie [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das Beispiel unten erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.

```java
import com.aspose.slides.*;

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

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Grenzen von 4 GB (2^32 Bytes) für die entkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die gesamte Archivgröße festlegt und zudem die Anzahl der Dateien auf 65 535 (2^16‑1) begrenzt. Die ZIP64‑Formatserweiterungen erhöhen diese Grenzen auf 2^64.

Mit der Methode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) können Sie festlegen, wann beim Speichern einer Office Open XML‑Datei ZIP64‑Formatserweiterungen verwendet werden.

Diese Methode kann mit den folgenden Modi verwendet werden:

- [IfNecessary](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64‑Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#Never) verwendet niemals ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#Always) verwendet immer ZIP64‑Erweiterungen.

Der folgende Code zeigt, wie eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Erweiterungen gespeichert wird:

```java
import com.aspose.slides.*;

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
Wenn Sie mit [Zip64Mode.Never](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#Never) speichern, wird eine [PptxException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Kompressionsstufen speichern**

Bei großen Präsentationen können Sie die Kompressionsstufe anpassen, um Dateigröße und Verarbeitungszeit auszubalancieren. Je nach Anforderung bevorzugen Sie möglicherweise schnellere Verarbeitung oder kleinere Ausgabedateien.

Aspose.Slides bietet die Methode [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format zu verwendende Kompressionsstufe festlegen können.

Die folgenden Kompressionsstufen stehen zur Verfügung:

- [**None**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#None): Es wird keine Kompression angewendet. Dateien werden unverändert gespeichert.
- [**Level1**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level1): Schnellste Kompression mit dem niedrigsten Kompressionsverhältnis.
- [**Level2**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level2): Schnellere Kompression mit leicht besserem Kompressionsverhältnis als **Level1**.
- [**Level3**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level3): Bietet bessere Kompression als **Level2** bei moderatem Einfluss auf die Verarbeitungszeit.
- [**Level4**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level4): Bietet bessere Kompression als **Level3**.
- [**Level5**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level5): Verbesserte Kompression gegenüber **Level4** mit zusätzlicher Verarbeitungszeit.
- [**Level6**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level6): Standardkompression, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standard‑Kompressionsstufe*.
- [**Level7**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level7): Bietet bessere Kompression als **Level6** bei langsamerer Verarbeitung.
- [**Level8**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level8): Bietet bessere Kompression als **Level7**.
- [**Level9**](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level9): Maximale Kompression. Produziert die kleinste Dateigröße, kostet jedoch die längste Verarbeitungszeit.

Das folgende Beispiel demonstriert, wie eine Präsentation als PPTX‑Datei *ohne Kompression* gespeichert wird:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Dieses Beispiel zeigt, wie eine Präsentation als PPTX‑Datei mit *maximaler Kompression* gespeichert wird:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Präsentationen speichern, ohne das Thumbnail zu aktualisieren**

Die Methode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) steuert die Thumbnail‑Erstellung beim Speichern einer Präsentation im PPTX‑Format:

- Bei `true` wird das Thumbnail beim Speichern aktualisiert. Dies ist die Vorgabe.
- Bei `false` bleibt das aktuelle Thumbnail erhalten. Hat die Präsentation kein Thumbnail, wird keins erzeugt.

Im nachfolgenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Thumbnail zu aktualisieren.

```java
import com.aspose.slides.*;

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
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit zu reduzieren.
{{% /alert %}}

## **Speicherfortschritt in Prozent anzeigen**

Das Interface [IProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/) wird über die Methode `setProgressCallback` verwendet, die vom Interface [ISaveOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/isaveoptions/) und der abstrakten Klasse [SaveOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveoptions/) bereitgestellt wird. Implementieren Sie ein [IProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/)-Objekt und übergeben Sie es mit `setProgressCallback`, um Speicherfortschritts‑Updates in Prozent zu erhalten.

Der folgende Code‑Abschnitt zeigt die Verwendung von `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Verwenden Sie hier den Fortschritts-Prozentwert.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint Splitter‑App](https://products.aspose.app/slides/de/splitter) entwickelt, die seine eigene API nutzt. Die App ermöglicht das Aufteilen einer Präsentation in mehrere Dateien, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Wird ein „schnelles“ Speichern (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erstellt; ein inkrementelles „schnelles“ Speichern wird nicht unterstützt.

**Ist das gleichzeitige Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz ist [nicht threadsicher](/slides/de/java/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verlinkten Dateien beim Speichern?**

[Hyperlinks](/slides/de/java/manage-hyperlinks/) bleiben erhalten. Externe verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Firma, Datum) setzen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/java/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.