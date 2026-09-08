---
title: Präsentationen in Python über Java speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/python-java/save-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Speichern Sie PowerPoint- und OpenDocument-Präsentationen in Dateien oder Streams in Python über Java mit Aspose.Slides und konfigurieren Sie die PPTX-Ausgabe sowie die Fortschrittsberichterstattung."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene geöffnet](/slides/de/python-java/open-presentation/), verwenden Sie die Methode [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), um das Ergebnis zu schreiben. Aspose.Slides für Python über Java kann eine Präsentation in eine Datei oder einen Stream im PowerPoint-, OpenDocument-, PDF- und anderen Formaten speichern. Die folgenden Abschnitte behandeln die üblichen Speicheroperationen und die für PPTX‑Ausgabe verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/)-Wert an die Methode [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save). Der Formatwert bestimmt den Dateityp, den Aspose.Slides erzeugt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Präsentationsinhalt hier hinzufügen oder ändern.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Präsentationen im Originalformat speichern**

In einer Stapelverarbeitungsanwendung ist das Eingabeformat möglicherweise nicht im Voraus bekannt. Nach dem Laden einer Datei lesen Sie das Originalformat mit der Methode [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSourceFormat). Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/sourceformat/)-Wert an [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#toSaveFormat), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/)-Wert zu erhalten, und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), um die geänderte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in ein Ausgabeverzeichnis im ursprünglichen Format:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#toSaveFormat) ordnet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML ihren entsprechenden Präsentations‑Speicherformaten zu. Es mappt nur Präsentations‑Quellformate; es ist nicht dafür gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Das Übergeben eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/sourceformat/)-Werts führt zu einer [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy‑PPT-, PPS- und POT-Dateien verwenden denselben Binärcontainer. Wenn eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen wird, kann eine PPS- oder POT-Datei daher als PPT identifiziert werden. Wenn das Beibehalten dieser alten Subtypen erforderlich ist, speichern Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat und verwenden Sie diese bei der Auswahl von Ausgabedateinamen und -format.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne einen endgültigen Dateipfad zu verwenden, übergeben Sie einen schreibbaren Stream und einen [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/)-Wert an die Methode [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save). Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Webservice zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

Das folgende Beispiel speichert eine neue Präsentation in einen Dateistream:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Verwenden Sie die Methode [ViewProperties.setLastView](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#setLastView) mit einem [ViewType](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewtype/)-Wert vor dem Speichern.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Anfangsansicht:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Präsentationen im strikten Office Open XML‑Format speichern**

Um eine PPTX-Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erstellen Sie eine Instanz von [PptxOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/) und verwenden deren Methode [setConformance](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setConformance) mit [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Anschließend übergeben Sie die Optionen an die Methode [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtarchivgröße und die Anzahl der Einträge. Da eine PPTX-Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen erhöhen die entsprechenden Größen‑ und Eintragszähler‑Grenzen.

Verwenden Sie die Methode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setZip64Mode), um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- [IfNecessary](https://reference.aspose.com/slides/de/python-java/aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/python-java/aspose.slides/zip64mode/#Never) deaktiviert ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/de/python-java/aspose.slides/zip64mode/#Always) schreibt immer ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert stets ZIP64‑Erweiterungen für die Ausgabepäsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warnung" %}}
Wenn [Zip64Mode.Never](https://reference.aspose.com/slides/de/python-java/aspose.slides/zip64mode/#Never) verwendet wird und die Präsentation nicht in die Standard‑ZIP‑Grenzen passt, wirft der Speichervorgang eine [PptxException](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Komprimierungsstufen speichern**

Für PPTX‑Ausgaben können Sie die Geschwindigkeit des Speicherns gegenüber der Dateigröße ausbalancieren, indem Sie die Methode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setCompressionLevel) verwenden. Die Klasse [CompressionLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/) bietet folgende Werte:

- [None](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#None) speichert Daten ohne Kompression.
- [Level1](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level1) liefert die schnellste Kompression und die größte komprimierte Ausgabe.
- [Level2](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level2) bis [Level5](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level5) bevorzugen zunehmend kleinere Ausgaben gegenüber der Speicher‑geschwindigkeit.
- [Level6](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level6) balanciert Speicher‑geschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- [Level7](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level7) und [Level8](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level8) bevorzugen noch stärker kleinere Ausgaben gegenüber der Speicher‑geschwindigkeit.
- [Level9](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level9) liefert die stärkste Kompression und erfordert die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Kompression:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Das folgende Beispiel verwendet die maximale Komprimierungsstufe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Präsentationen ohne Aktualisieren des Vorschaubilds speichern**

Wenn eine Präsentation als PPTX gespeichert wird, steuert die Methode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) das Vorschaubild des Dokuments:

- `True` regeneriert das Vorschaubild während des Speicher‑vorgangs. Dies ist der Standardwert.
- `False` bewahrt das vorhandene Vorschaubild. Hat die Präsentation kein Vorschaubild, erzeugt Aspose.Slides keines.

Das folgende Beispiel speichert eine Präsentation, ohne ihr Vorschaubild zu aktualisieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Hinweis" %}}
Das Deaktivieren der Vorschaubild‑Aktualisierung kann die zum Speichern einer PPTX-Datei benötigte Zeit reduzieren.
{{% /alert %}}

## **Speicherfortschritts‑Updates in Prozent**

Um einen Speicher‑vorgang zu überwachen, registrieren Sie einen Python‑Fortschritts‑Handler über `jpype.JProxy` und übergeben ihn an die Methode [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides ruft dann die `reporting`‑Methode des Handlers mit Fortschrittswerten während des Exports auf.

Das folgende Beispiel gibt den Fortschritt eines PDF‑Exports in der Konsole aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Hinweis" %}}
Aspose stellt einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) bereit, der mit der Aspose.Slides‑API gebaut wurde. Er speichert ausgewählte Folien einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „schnelles Speichern“?**

Nein. Jeder Speicher‑vorgang schreibt eine vollständige Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz [ist nicht thread‑sicher](/slides/de/python-java/multithreading/). Greifen Sie jeweils nur aus einem Thread auf eine Instanz zu und speichern Sie sie.

**Was passiert mit Hyperlinks und extern verknüpften Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/python-java/manage-hyperlinks/) bleiben in der Präsentation erhalten. Aspose.Slides kopiert keine extern verknüpften Dateien, sodass die gespeicherte Präsentation weiterhin auf deren Speicherorte zugreifen muss.

**Kann ich Dokument‑Metadaten wie Autor, Titel, Unternehmen und Erstellungsdatum speichern?**

Ja. Setzen Sie vor dem Speichern die entsprechenden [Dokument‑Eigenschaften](/slides/de/python-java/presentation-properties/), und Aspose.Slides schreibt sie in die Ausgabedatei.