---
title: Präsentationen in .NET speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/net/save-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Speichern Sie PowerPoint- und OpenDocument‑Präsentationen in Dateien oder Streams in C# mit Aspose.Slides für .NET und konfigurieren Sie die PPTX‑Ausgabe sowie die Fortschrittsanzeige."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene öffnen](/slides/de/net/open-presentation/), verwenden Sie die Methode [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/), um das Ergebnis zu schreiben. Aspose.Slides für .NET kann eine Präsentation in einer Datei oder einem Stream im PowerPoint-, OpenDocument-, PDF- und anderen Formaten speichern. Die folgenden Abschnitte behandeln die Standard‑Speichervorgänge und die für PPTX‑Ausgabe verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/)-Wert an die Methode [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/). Der Formatwert bestimmt den Dateityp, den Aspose.Slides erstellt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Präsentationen im Originalformat speichern**

Beispiele zur Datei‑ und Stream‑Erkennung, zum Verhalten neu erstellter Präsentationen und zum Unterschied zwischen Quell‑ und Ausgabeformaten finden Sie unter [Determine the Original Presentation Format](/slides/de/net/detect-presentation-source-format/).

In einer Stapelverarbeitungs‑Anwendung ist das Eingabeformat möglicherweise nicht im Voraus bekannt. Nachdem Sie eine Datei geladen haben, lesen Sie ihr Originalformat aus der Eigenschaft [IPresentation.SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/sourceformat/). Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/sourceformat/)-Wert an [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/tosaveformat/), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/)-Wert zu erhalten, und verwenden Sie anschließend [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/), um die geänderte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in ein Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.util/slideutil/tosaveformat/) mappt PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML auf die entsprechenden Präsentations‑Speicherformate. Es mappt nur Präsentationsquellformate; es ist nicht dazu gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Das Übergeben eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/net/aspose.slides/sourceformat/)-Werts führt zu einer [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Legacy‑PPT-, PPS‑ und POT‑Dateien verwenden denselben Binärcontainer. Wird eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn die Beibehaltung dieser Legacy‑Subtypen erforderlich ist, behalten Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat und verwenden Sie diese bei der Auswahl des Ausgabedateinamens und -formats.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne sich auf einen endgültigen Dateipfad zu verlassen, übergeben Sie einen beschreibbaren [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) und einen [SaveFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/)-Wert an die Methode [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/). Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Webservice zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

Das folgende Beispiel speichert eine neue Präsentation in einen Dateistream:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Setzen Sie vor dem Speichern die Eigenschaft [ViewProperties.LastView](https://reference.aspose.com/slides/de/net/aspose.slides/viewproperties/lastview/) auf einen [ViewType](https://reference.aspose.com/slides/de/net/aspose.slides/viewtype/)-Wert.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Anfangsansicht:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Präsentationen im Strict‑Office‑Open‑XML‑Format speichern**

Um eine PPTX‑Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erzeugen Sie eine Instanz von [PptxOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/pptxoptions/) und setzen Sie deren [Conformance](https://reference.aspose.com/slides/de/net/aspose.slides.export/pptxoptions/conformance/)‑Eigenschaft auf `Conformance.Iso29500_2008_Strict`. Übergeben Sie anschließend die Optionen an die Methode [Presentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Präsentationen im Office‑Open‑XML‑Format im Zip64‑Modus speichern**

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtarichgröße und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen erhöhen die entsprechenden Größen‑ und Eintrags‑Grenzwerte.

Verwenden Sie die Eigenschaft [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/de/net/aspose.slides.export/pptxoptions/zip64mode/), um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- `IfNecessary` verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- `Never` deaktiviert ZIP64‑Erweiterungen.
- `Always` schreibt stets ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert stets ZIP64‑Erweiterungen für die Ausgabepäsentation:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Wenn `Zip64Mode` auf `Never` gesetzt ist und die Präsentation nicht in die Standard‑ZIP‑Grenzen passt, löst der Speicher‑Vorgang eine [PptxException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxexception/) aus.
{{% /alert %}}

## **Präsentationen im Office‑Open‑XML‑Format mit Komprimierungsstufen speichern**

Für PPTX‑Ausgabe können Sie die Speichergeschwindigkeit gegen die Dateigröße abwägen, indem Sie die Eigenschaft [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/de/net/aspose.slides.export/pptxoptions/compressionlevel/) festlegen. Die Aufzählung [CompressionLevel](https://reference.aspose.com/slides/de/net/aspose.slides.export/compressionlevel/) bietet folgende Werte:

- `None` speichert Daten ohne Kompression.
- `Level1` liefert die schnellste Kompression und die größte komprimierte Ausgabe.
- `Level2` bis `Level5` begünstigen zunehmend kleinere Ausgaben zulasten der Speichergeschwindigkeit.
- `Level6` balanciert Speichergeschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- `Level7` und `Level8` bevorzugen noch stärker kleinere Ausgaben gegenüber der Speichergeschwindigkeit.
- `Level9` liefert die stärkste Kompression und erfordert die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Kompression:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Das folgende Beispiel verwendet die maximale Komprimierungsstufe:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Präsentationen ohne Aktualisierung des Vorschaubildes speichern**

Beim Speichern einer Präsentation als PPTX steuert die Eigenschaft [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/de/net/aspose.slides.export/pptxoptions/refreshthumbnail/) ihr Dokument‑Vorschaubild:

- `true` regeneriert das Vorschaubild während des Speicher‑Vorgangs. Dies ist der Standardwert.
- `false` bewahrt das vorhandene Vorschaubild. Hat die Präsentation kein Vorschaubild, erzeugt Aspose.Slides keines.

Das folgende Beispiel speichert eine Präsentation ohne Aktualisierung ihres Vorschaubildes:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Das Deaktivieren der Vorschaubild‑Aktualisierung kann die zum Speichern einer PPTX‑Datei erforderliche Zeit verkürzen.
{{% /alert %}}

## **Speicherfortschritt in Prozent melden**

Um einen Speicher‑Vorgang zu überwachen, implementieren Sie das Interface [IProgressCallback](https://reference.aspose.com/slides/de/net/aspose.slides/iprogresscallback/) und weisen Sie die Implementierung der Eigenschaft [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/de/net/aspose.slides.export/isaveoptions/progresscallback/) zu. Aspose.Slides ruft dann während des Exports die Methode [IProgressCallback.Reporting](https://reference.aspose.com/slides/de/net/aspose.slides/iprogresscallback/reporting/) mit Fortschrittswerten auf.

Das folgende Beispiel meldet den Fortschritt eines PDF‑Exports in die Konsole:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose stellt einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) zur Verfügung, der mit der Aspose.Slides‑API erstellt wurde. Er speichert ausgewählte Folien aus einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „Fast Save“?**

Nein. Jeder Speicher‑Vorgang schreibt eine komplette Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Instanz [ist nicht thread‑sicher](/slides/de/net/multithreading/). Greifen Sie pro Instanz nur von einem Thread gleichzeitig zu und speichern Sie sie.

**Was passiert mit Hyperlinks und extern verknüpften Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) bleiben in der Präsentation erhalten. Aspose.Slides kopiert keine extern verknüpften Dateien, sodass die gespeicherte Präsentation weiterhin Zugriff auf deren Speicherorte haben muss.

**Kann ich Dokument‑Metadaten wie Autor, Titel, Unternehmen und Erstellungsdatum speichern?**

Ja. Setzen Sie vor dem Speichern die entsprechenden [Dokument‑Eigenschaften](/slides/de/net/presentation-properties/), und Aspose.Slides schreibt sie in die Ausgabedatei.