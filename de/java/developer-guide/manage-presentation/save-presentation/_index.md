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
- Vorschaubild aktualisieren
- Speicherfortschritt
- Java
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in Java mit Aspose.Slides in Dateien oder Streams speichern und PPTX-Ausgabe sowie Fortschrittsberichte konfigurieren."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene geöffnet](/slides/de/java/open-presentation/), verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) Methode, um das Ergebnis zu schreiben. Aspose.Slides für Java kann eine Präsentation in einer Datei oder einem Stream in PowerPoint, OpenDocument, PDF und anderen Formaten speichern. Die folgenden Abschnitte behandeln die standardmäßigen Speicheroperationen und die für PPTX‑Ausgabe verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) Methode. Der Formatwert bestimmt den Dateityp, den Aspose.Slides erstellt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Präsentationsinhalt hier hinzufügen oder ändern.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Originalformat speichern**

Für Beispiele zur Datei‑ und Stream‑Erkennung, das Verhalten neu erstellter Präsentationen und den Unterschied zwischen Quell‑ und Zielformaten siehe [Determine the Original Presentation Format](/slides/de/java/detect-presentation-source-format/).

In einer Batch‑Verarbeitung kann das Eingabeformat im Voraus unbekannt sein. Nachdem Sie eine Datei geladen haben, lesen Sie ihr Originalformat mit der [IPresentation.getSourceFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getSourceFormat--) Methode aus. Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/sourceformat/)‑Wert an [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideutil/#toSaveFormat-int-), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/)‑Wert zu erhalten, und verwenden Sie dann [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-), um die modifizierte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in einem Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

SlideUtil.toSaveFormat ordnet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML den entsprechenden Präsentations‑Speicherformaten zu. Es mappt nur Präsentations‑Quellformate; es ist nicht dafür gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Das Übergeben eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/sourceformat/)‑Werts führt zu einer [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy‑PPT-, PPS‑ und POT‑Dateien verwenden denselben Binärc‑Container. Wird eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn das Beibehalten dieser Legacy‑Subtypen erforderlich ist, behalten Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat und verwenden Sie sie bei der Auswahl des Ausgabedateinamens und -formats.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne einen endgültigen Dateipfad zu benötigen, übergeben Sie einen schreibbaren Stream und einen [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) Methode. Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Web‑Service zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

Das folgende Beispiel speichert eine neue Präsentation in einen Dateistream:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Präsentationen mit einem vordefinierten Ansichtstyp speichern**

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Verwenden Sie die [ViewProperties.setLastView](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/#setLastView-int-) Methode mit einem [ViewType](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewtype/)‑Wert vor dem Speichern.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Anfangsansicht:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im strengen Office Open XML‑Format speichern**

Um eine PPTX‑Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erzeugen Sie eine [PptxOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxoptions/) Instanz und verwenden Sie deren [setConformance](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxoptions/#setConformance-int-) Methode mit [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). Übergeben Sie dann die Optionen an die [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode.

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die gesamte Archivgröße und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen erhöhen die geltenden Größen‑ und Eintragsanzahl‑Grenzen.

Verwenden Sie die [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) Methode, um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- [IfNecessary](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standard‑Modus.
- [Never](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#Never) deaktiviert ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#Always) schreibt stets ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert ZIP64‑Erweiterungen für die Ausgabep­rä­sen­ta­ti­on stets:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Wenn [Zip64Mode.Never](https://reference.aspose.com/slides/de/java/com.aspose.slides/zip64mode/#Never) verwendet wird und die Präsentation nicht in die Standard‑ZIP‑Grenzen passt, wirft der Speicher­vorgang eine [PptxException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Komprimierungsstufen speichern**

Für PPTX‑Ausgabe können Sie die Speichergeschwindigkeit gegen die Dateigröße abwägen, indem Sie die [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) Methode verwenden. Die [CompressionLevel](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/) Klasse stellt folgende Werte bereit:

- [None](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#None) speichert Daten ohne Kompression.
- [Level1](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level1) bietet die schnellste Kompression und die größte komprimierte Ausgabe.
- [Level2](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level2) bis [Level5](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level5) favorisieren zunehmend kleinere Ausgaben gegenüber der Speicher‑Geschwindigkeit.
- [Level6](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level6) balanciert Speicher‑Geschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- [Level7](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level7) und [Level8](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level8) favorisieren weiter kleinere Ausgaben gegenüber der Speicher‑Geschwindigkeit.
- [Level9](https://reference.aspose.com/slides/de/java/com.aspose.slides/compressionlevel/#Level9) bietet die stärkste Kompression und erfordert die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Kompression:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Das folgende Beispiel verwendet die maximale Komprimierungsstufe:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Präsentationen ohne Aktualisierung des Vorschaubildes speichern**

Wenn eine Präsentation als PPTX gespeichert wird, steuert die [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) Methode das Dokument‑Vorschaubild:

- `true` regeneriert das Vorschaubild während des Speichervorgangs. Dies ist der Standardwert.
- `false` behält das vorhandene Vorschaubild bei. Hat die Präsentation kein Vorschaubild, erzeugt Aspose.Slides keines.

Das folgende Beispiel speichert eine Präsentation, ohne das Vorschaubild zu aktualisieren:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Das Deaktivieren der Vorschaubild‑Aktualisierung kann die zum Speichern einer PPTX‑Datei erforderliche Zeit reduzieren.
{{% /alert %}}

## **Speicherfortschritts‑Updates in Prozent**

Um einen Speicher­vorgang zu überwachen, implementieren Sie die [IProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/) Schnittstelle und übergeben die Implementierung an die [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) Methode. Aspose.Slides ruft dann die [IProgressCallback.reporting](https://reference.aspose.com/slides/de/java/com.aspose.slides/iprogresscallback/#reporting-double-) Methode mit Fortschrittswerten während des Exports auf.

Das folgende Beispiel gibt den Fortschritt eines PDF‑Exports in der Konsole aus:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose stellt einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) bereit, der mit der Aspose.Slides‑API gebaut ist. Er speichert ausgewählte Folien einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „schnelles Speichern“?**

Nein. Jeder Speicher­vorgang schreibt eine komplette Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Instanz ist nicht thread‑sicher. Zugriff und Speicherung jeder Instanz nur von einem Thread gleichzeitig.

**Was passiert mit Hyperlinks und extern verknüpften Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/java/manage-hyperlinks/) bleiben in der Präsentation. Aspose.Slides kopiert keine extern verknüpften Dateien, sodass die gespeicherte Präsentation weiterhin auf deren Speicherorte zugreifen muss.

**Kann ich Dokument‑Metadaten wie Autor, Titel, Unternehmen und Erstellungsdatum speichern?**

Ja. Setzen Sie die entsprechenden [document properties](/slides/de/java/presentation-properties/) bevor Sie speichern, und Aspose.Slides schreibt sie in die Ausgabedatei.