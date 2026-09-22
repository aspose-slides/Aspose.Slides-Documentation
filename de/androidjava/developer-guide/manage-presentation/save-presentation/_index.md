---
title: Präsentationen unter Android speichern
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
- Präsentation im Stream
- vordefinierter Ansichtstyp
- Strict Office Open XML-Format
- Zip64-Modus
- Vorschaubild aktualisieren
- Speicherfortschritt
- Android
- Java
- Aspose.Slides
description: "Speichern Sie PowerPoint- und OpenDocument-Präsentationen auf Android mit Aspose.Slides in Dateien oder Streams und konfigurieren Sie die PPTX-Ausgabe sowie die Fortschrittsberichterstattung."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [ein bestehendes öffnen](/slides/de/androidjava/open-presentation/), verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) Methode, um das Ergebnis zu schreiben. Aspose.Slides for Android via Java kann eine Präsentation in einer Datei oder einem Stream im PowerPoint-, OpenDocument-, PDF- und anderen Formaten speichern. Die folgenden Abschnitte behandeln die Standard‑Speichervorgänge und die für die PPTX‑Ausgabe verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) Methode. Der Formatwert bestimmt den Dateityp, den Aspose.Slides erzeugt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Fügen Sie hier Präsentationsinhalte hinzu oder ändern Sie sie.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Präsentationen im Originalformat speichern**

Beispiele für Datei‑ und Stream‑Erkennung, das Verhalten neu erstellter Präsentationen und die Unterscheidung zwischen Quell‑ und Zielformaten finden Sie unter [Ermitteln des Originalpräsentationsformats](/slides/de/androidjava/detect-presentation-source-format/).

In einer Batch‑Verarbeitungsanwendung ist das Eingabeformat möglicherweise nicht im Voraus bekannt. Nach dem Laden einer Datei lesen Sie das Originalformat über die [IPresentation.getSourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) Methode. Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sourceformat/)‑Wert an [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/)‑Wert zu erhalten, und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), um die geänderte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in ein Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) ordnet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML den jeweiligen Präsentations‑Speicherformaten zu. Es ordnet nur Präsentations‑Quellformate zu; es ist nicht dazu gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Das Übergeben eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sourceformat/)‑Werts führt zu einer [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Legacy‑PPT‑, PPS‑ und POT‑Dateien verwenden denselben Binärcontainer. Wenn eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen wird, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn die Beibehaltung dieser alten Subtypen erforderlich ist, bewahren Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat auf und verwenden Sie diese bei der Auswahl des Ausgabedateinamens und -formats.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne einen endgültigen Dateipfad zu benötigen, übergeben Sie einen beschreibbaren Stream und einen [SaveFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) Methode. Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Web‑Service zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

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

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Verwenden Sie vor dem Speichern die [ViewProperties.setLastView](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) Methode mit einem [ViewType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewtype/)‑Wert.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Initialansicht:

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

## **Präsentationen im Strict‑Office‑Open‑XML‑Format speichern**

Um eine PPTX‑Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erstellen Sie eine [PptxOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxoptions/)‑Instanz und verwenden deren [setConformance](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) Methode mit [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Übergeben Sie dann die Optionen an die [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode.

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

## **Präsentationen im Office‑Open‑XML‑Format im Zip64‑Modus speichern**

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtarchivgröße und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen heben die jeweils geltenden Größen‑ und Eintragszahl‑Grenzen an.

Verwenden Sie die [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) Methode, um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- [IfNecessary](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#Never) deaktiviert ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#Always) schreibt stets ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert ZIP64‑Erweiterungen für die Ausgabepäsentation immer:

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

{{% alert color="warning" title="Warnung" %}}
Wenn [Zip64Mode.Never](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/zip64mode/#Never) verwendet wird und die Präsentation nicht in die Standard‑ZIP‑Grenzen passt, wirft der Speicher‑Vorgang eine [PptxException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Präsentationen im Office‑Open‑XML‑Format mit Komprimierungsstufen speichern**

Für PPTX‑Ausgaben können Sie die Speicher‑Geschwindigkeit gegen die Dateigröße abwägen, indem Sie die [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) Methode verwenden. Die [CompressionLevel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/)‑Klasse liefert folgende Werte:

- [None](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#None) speichert Daten ohne Komprimierung.
- [Level1](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level1) liefert die schnellste Komprimierung und das größte komprimierte Ergebnis.
- [Level2](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level2) bis [Level5](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level5) bevorzugen schrittweise kleinere Ausgaben gegenüber der Speicher‑Geschwindigkeit.
- [Level6](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level6) balanciert Speicher‑Geschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- [Level7](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level7) und [Level8](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level8) bevorzugen noch stärker kleinere Ausgaben gegenüber der Speicher‑Geschwindigkeit.
- [Level9](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compressionlevel/#Level9) bietet die stärkste Komprimierung und erfordert die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Komprimierung:

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

Wenn eine Präsentation als PPTX gespeichert wird, steuert die [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) Methode ihr Dokumenten‑Vorschaubild:

- `true` regeneriert das Vorschaubild während des Speicher‑Vorgangs. Dies ist der Standardwert.
- `false` erhält das vorhandene Vorschaubild. Hat die Präsentation kein Vorschaubild, erzeugt Aspose.Slides keines.

Das folgende Beispiel speichert eine Präsentation, ohne ihr Vorschaubild zu aktualisieren:

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

{{% alert color="info" title="Hinweis" %}}
Das Deaktivieren der Vorschaubild‑Aktualisierung kann die zum Speichern einer PPTX‑Datei benötigte Zeit reduzieren.
{{% /alert %}}

## **Speicherfortschritt in Prozent anzeigen**

Um einen Speicher‑Vorgang zu überwachen, implementieren Sie die [IProgressCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprogresscallback/) Schnittstelle und übergeben die Implementierung an die [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) Methode. Aspose.Slides ruft dann die [IProgressCallback.reporting](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) Methode mit Fortschrittswerten während des Exports auf.

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

{{% alert color="info" title="Hinweis" %}}
Aspose stellt einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) bereit, der mit der Aspose.Slides‑API gebaut wurde. Er speichert ausgewählte Folien aus einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „schnelles Speichern“?**

Nein. Jeder Speicher‑Vorgang schreibt die komplette Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Instanz ist [nicht thread‑sicher](/slides/de/androidjava/multithreading/). Greifen Sie jeweils nur aus einem Thread auf eine Instanz zu und speichern Sie sie.

**Was passiert mit Hyperlinks und extern verknüpften Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/androidjava/manage-hyperlinks/) bleiben in der Präsentation. Aspose.Slides kopiert extern verknüpfte Dateien nicht, sodass die gespeicherte Präsentation weiterhin auf deren Speicherorte zugreifen können muss.

**Kann ich Dokument­metadaten wie Autor, Titel, Unternehmen und Erstellungsdatum speichern?**

Ja. Setzen Sie die entsprechenden [Dokumenteigenschaften](/slides/de/androidjava/presentation-properties/) vor dem Speichern, und Aspose.Slides schreibt sie in die Ausgabedatei.