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
- Miniaturbild aktualisieren
- Speicherfortschritt
- Python
- Java
- Aspose.Slides
description: "Speichern Sie PowerPoint- und OpenDocument-Präsentationen in Dateien oder Streams in Python über Java mit Aspose.Slides und konfigurieren Sie die PPTX-Ausgabe sowie die Fortschrittsberichterstattung."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene öffnen](/slides/de/python-java/open-presentation/), verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode, um das Ergebnis zu schreiben. Aspose.Slides für Python über Java kann eine Präsentation in PowerPoint, OpenDocument, PDF und anderen Formaten in einer Datei oder einem Stream speichern. Die folgenden Abschnitte behandeln die Standard‑Speichervorgänge und die für PPTX‑Ausgaben verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode. Der Formatwert bestimmt den Dateityp, den Aspose.Slides erzeugt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Fügen Sie hier Präsentationsinhalt hinzu oder ändern Sie ihn.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Präsentationen im Originalformat speichern**

In einer Batch‑Verarbeitungsanwendung ist das Eingabeformat möglicherweise nicht im Voraus bekannt. Nach dem Laden einer Datei lesen Sie ihr Originalformat über die [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSourceFormat)‑Methode. Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/sourceformat/)‑Wert an [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#toSaveFormat), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/)‑Wert zu erhalten, und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save), um die modifizierte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in ein Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#toSaveFormat) ordnet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint XML ihren jeweiligen Präsentations‑Speicherformaten zu. Es mappt ausschließlich Präsentations‑Quellformate; es ist nicht dafür gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Das Übergeben eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/sourceformat/)‑Wertes führt zu einer [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy‑PPT-, PPS‑ und POT‑Dateien verwenden denselben Binärcontainer. Wenn eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen wird, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn das Beibehalten dieser Legacy‑Subtypen erforderlich ist, bewahren Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat auf und nutzen Sie sie bei der Auswahl des Ausgabedateinamens und -formats.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne einen endgültigen Dateipfad zu benötigen, übergeben Sie einen schreibbaren Stream und einen [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode. Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Web‑Service zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

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

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Verwenden Sie vor dem Speichern die [ViewProperties.setLastView](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewproperties/#setLastView)‑Methode mit einem [ViewType](https://reference.aspose.com/slides/de/python-java/aspose.slides/viewtype/)‑Wert.

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

## **Präsentationen im Strict Office Open XML‑Format speichern**

Um eine PPTX‑Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erzeugen Sie eine [PptxOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/)‑Instanz und verwenden deren [setConformance](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setConformance)‑Methode mit [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/de/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Übergeben Sie anschließend die Optionen an die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode.

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

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtarchivgröße und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen heben die jeweiligen Größen‑ und Eintrags‑Grenzwerte an.

Verwenden Sie die [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setZip64Mode)‑Methode, um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- [IfNecessary](https://reference.aspose.com/slides/de/python-java/aspose.slides/zip64mode/#IfNecessary) verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- [Never](https://reference.aspose.com/slides/de/python-java/aspose.slides/zip64mode/#Never) deaktiviert ZIP64‑Erweiterungen.
- [Always](https://reference.aspose.com/slides/de/python-java/aspose.slides/zip64mode/#Always) schreibt stets ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert ZIP64‑Erweiterungen für die Ausgabepäsentation durchgehend:

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

Für PPTX‑Ausgaben können Sie mithilfe der [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setCompressionLevel)‑Methode das Gleichgewicht zwischen Speichergeschwindigkeit und Dateigröße steuern. Die [CompressionLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/)‑Klasse liefert folgende Werte:

- [None](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#None) speichert Daten ohne Kompression.
- [Level1](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level1) bietet die schnellste Kompression und die größte komprimierte Ausgabe.
- [Level2](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level2) bis [Level5](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level5) begünstigen zunehmend kleinere Ausgaben gegenüber der Speichergeschwindigkeit.
- [Level6](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level6) balanciert Speichergeschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- [Level7](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level7) und [Level8](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level8) bevorzugen weiter kleinere Ausgaben gegenüber der Speichergeschwindigkeit.
- [Level9](https://reference.aspose.com/slides/de/python-java/aspose.slides/compressionlevel/#Level9) bietet die stärkste Kompression und erfordert die meiste Verarbeitungszeit.

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

## **Präsentationen ohne Aktualisierung des Miniaturbilds speichern**

Wenn eine Präsentation als PPTX gespeichert wird, steuert die [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/de/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail)‑Methode das Dokument‑Miniaturbild:

- `True` regeneriert das Miniaturbild während des Speicher‑Vorgangs. Dies ist der Standardwert.
- `False` bewahrt das vorhandene Miniaturbild. Hat die Präsentation kein Miniaturbild, erzeugt Aspose.Slides keines.

Das folgende Beispiel speichert eine Präsentation, ohne ihr Miniaturbild zu aktualisieren:

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
Das Deaktivieren der Miniaturbild‑Aktualisierung kann die zum Speichern einer PPTX‑Datei benötigte Zeit verkürzen.
{{% /alert %}}

## **Speicherfortschritt als Prozentsatz melden**

Um einen Speicher‑Vorgang zu überwachen, registrieren Sie einen Python‑Fortschritts‑Handler über `jpype.JProxy` und übergeben ihn an die [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveoptions/#setProgressCallback)‑Methode. Aspose.Slides ruft dann die `reporting`‑Methode des Handlers mit Fortschrittswerten während des Exports auf.

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

**Unterstützt Aspose.Slides inkrementelles oder „Fast Save“?**

Nein. Jeder Speicherungs‑vorgang schreibt eine vollständige Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz ist nicht thread‑sicher. Greifen Sie nur von einem Thread gleichzeitig darauf zu und speichern Sie sie ebenfalls nur von einem Thread.

**Was passiert mit Hyperlinks und extern verlinkten Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/python-java/manage-hyperlinks/) bleiben in der Präsentation erhalten. Aspose.Slides kopiert keine extern verlinkten Dateien, sodass die gespeicherte Präsentation weiterhin Zugriff auf deren Standorte haben muss.

**Kann ich Dokument‑Metadaten wie Autor, Titel, Firma und Erstellungsdatum speichern?**

Ja. Setzen Sie vor dem Speichern die entsprechenden [Dokument‑eigenschaften](/slides/de/python-java/presentation-properties/), und Aspose.Slides schreibt sie in die Ausgabedatei.