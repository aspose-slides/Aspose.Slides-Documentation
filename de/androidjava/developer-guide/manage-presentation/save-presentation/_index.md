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
- Vorschaubild aktualisieren
- Speicherfortschritt
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationen in Java mit Aspose.Slides für Android speichern—Export zu PowerPoint oder OpenDocument bei gleichzeitigem Erhalt von Layouts, Schriftarten und Effekten."
---
## **Übersicht**

[Open Presentations on Android](/slides/de/androidjava/open-presentation/) beschrieb, wie die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für Android können Sie in einer **Datei** oder **Stream** speichern. Dieser Artikel erläutert die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man eine Präsentation mit Aspose.Slides speichert.

```java
import com.aspose.slides.*;

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

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

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

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht das Festlegen der anfänglichen Ansicht, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die Klasse [ViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/). Verwenden Sie die Methode [setLastView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) mit einem Wert aus der Aufzählung [ViewType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewtype/).

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

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die Klasse [PptxOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxoptions/) und setzen Sie deren `conformance`‑Eigenschaft beim Speichern. Wenn Sie [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.

```java
import com.aspose.slides.*;

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

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Grenzen von 4 GB (2^32 Bytes) für die unkomprimierte Größe einer Datei, die komprimierte Größe einer Datei und die Gesamtausgröße des Archivs festlegt und zudem die Anzahl der Dateien auf 65 535 (2^16‑1) beschränkt. ZIP64‑Format-Erweiterungen erhöhen diese Grenzen auf 2^64.

Die Methode [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) ermöglicht die Auswahl, wann ZIP64‑Format-Erweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden.

Diese Methode kann mit den folgenden Modi verwendet werden:

- [IfNecessary](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64‑Format-Erweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#Never) verwendet ZIP64‑Format-Erweiterungen niemals.
- [Always](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#Always) verwendet ZIP64‑Format-Erweiterungen stets.

Der folgende Code zeigt, wie man eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Format-Erweiterungen speichert:

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
When you save with [Zip64Mode.Never](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#Never), a [PptxException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Komprimierungsstufen speichern**

Bei der Arbeit mit großen Präsentationen können Sie die Komprimierungsstufe anpassen, um Dateigröße und Verarbeitungszeit auszubalancieren. Je nach Ihren Anforderungen bevorzugen Sie möglicherweise schnelleres Verarbeiten oder kleinere Ausgabedateien.

Aspose.Slides stellt die Methode [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) bereit, mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format verwendete Komprimierungsstufe festlegen können.

Die folgenden Komprimierungsstufen stehen zur Verfügung:

- [**None**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#None): Es wird keine Komprimierung angewendet. Dateien werden unverändert gespeichert.
- [**Level1**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level1): Die schnellste Komprimierung mit dem niedrigsten Komprimierungsverhältnis.
- [**Level2**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level2): Schnellere Komprimierung mit leicht besserem Komprimierungsverhältnis als **Level1**.
- [**Level3**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level3): Bietet bessere Komprimierung als **Level2** mit moderatem Einfluss auf die Verarbeitungszeit.
- [**Level4**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level4): Bietet bessere Komprimierung als **Level3**.
- [**Level5**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level5): Bietet verbesserte Komprimierung gegenüber **Level4** mit zusätzlicher Verarbeitungszeit.
- [**Level6**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level6): Standardkomprimierung, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standard‑Komprimierungsstufe*.
- [**Level7**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level7): Bietet bessere Komprimierung als **Level6** bei langsamerer Verarbeitung.
- [**Level8**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level8): Bietet bessere Komprimierung als **Level7**.
- [**Level9**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level9): Maximale Komprimierung. Produziert die kleinste Dateigröße, jedoch mit der längsten Verarbeitungszeit.

Das folgende Beispiel demonstriert, wie man eine Präsentation als PPTX‑Datei *ohne Komprimierung* speichert:

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

Dieses Beispiel zeigt, wie man eine Präsentation als PPTX‑Datei mit *maximaler Komprimierung* speichert:

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

## **Präsentationen ohne Aktualisierung des Vorschaubildes speichern**

Die Methode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) steuert die Generierung des Vorschaubildes beim Speichern einer Präsentation als PPTX:

- Wenn sie auf `true` gesetzt ist, wird das Vorschaubild beim Speichern aktualisiert. Dies ist die Standardeinstellung.
- Wenn sie auf `false` gesetzt ist, wird das aktuelle Vorschaubild beibehalten. Hat die Präsentation kein Vorschaubild, wird keines erzeugt.

Im nachstehenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Vorschaubild zu aktualisieren.

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
This option helps reduce the time required to save a presentation in PPTX format.
{{% /alert %}}

## **Speicherfortschritt in Prozent aktualisieren**

Das Interface [IProgressCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprogresscallback/) wird über die Methode `setProgressCallback` verwendet, die von der Schnittstelle [ISaveOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isaveoptions/) und der abstrakten Klasse [SaveOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveoptions/) bereitgestellt wird. Ordnen Sie eine Implementierung von [IProgressCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprogresscallback/) mittels `setProgressCallback` zu, um Speicherfortschritts‑Updates als Prozentsatz zu erhalten.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Verwenden Sie hier den Fortschrittswert in Prozent.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/de/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.
{{% /alert %}}

## **FAQ**

**Wird „Fast Save“ (inkrementelles Speichern) unterstützt, sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die vollständige Zieldatei erstellt; inkrementelles „Fast Save“ wird nicht unterstützt.

**Ist das Speichern derselben Presentation‑Instanz aus mehreren Threads threadsicher?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) Instanz ist [nicht threadsicher](/slides/de/androidjava/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verlinkten Dateien beim Speichern?**

[Hyperlinks](/slides/de/androidjava/manage-hyperlinks/) bleiben erhalten. Extern verlinkte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin erreichbar sind.

**Kann ich Dokumente‑Metadaten (Autor, Titel, Unternehmen, Datum) festlegen/speichern?**

Ja. Standard‑[document properties](/slides/de/androidjava/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.