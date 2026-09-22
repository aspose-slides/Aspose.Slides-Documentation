---
title: Präsentationen in Python speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/python-net/save-presentation/
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
- Python
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen in Python mit Aspose.Slides in Dateien oder Streams speichern und PPTX-Ausgabeoptionen konfigurieren."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene öffnen](/slides/de/python-net/open-presentation/), verwenden Sie die [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipresentation/save/)‑Methode, um das Ergebnis zu schreiben. Aspose.Slides für Python via .NET kann eine Präsentation in einer Datei oder einem Stream im PowerPoint-, OpenDocument-, PDF‑ und anderen Formaten speichern. Die folgenden Abschnitte beschreiben die Standard‑Speichervorgänge und die für PPTX‑Ausgaben verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipresentation/save/)‑Methode. Der Formatwert bestimmt, welchen Dateityp Aspose.Slides erstellt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Präsentationsinhalt hier hinzufügen oder ändern.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen im Originalformat speichern**

Für Beispiele zur Datei‑ und Stream‑Erkennung, das Verhalten neu erstellter Präsentationen und den Unterschied zwischen Quell‑ und Ausgabeformaten siehe [Determine the Original Presentation Format](/slides/de/python-net/detect-presentation-source-format/).

In einer Batch‑Verarbeitungsanwendung ist das Eingabeformat möglicherweise nicht im Voraus bekannt. Nach dem Laden einer Datei lesen Sie das Originalformat aus der Eigenschaft [Presentation.source_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/source_format/). Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/sourceformat/)‑Wert an [SlideUtil.to_save_format](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/to_save_format/), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/)‑Wert zu erhalten, und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipresentation/save/), um die geänderte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in ein Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/to_save_format/) ordnet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML ihren jeweiligen Präsentations‑Speicherformaten zu. Es mappt nur Präsentations‑Quellformate; es ist nicht dazu gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Die Übergabe eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/sourceformat/)‑Werts löst eine Ausnahme aus.

Legacy‑PPT, PPS und POT‑Dateien verwenden denselben binären Container. Wenn eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen wird, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn das Beibehalten dieser alten Subtypen erforderlich ist, bewahren Sie den ursprünglichen Dateinamen oder Metadaten des Formats separat auf und verwenden Sie diese bei der Auswahl des Ausgabedateinamens und -formats.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne sich auf einen endgültigen Dateipfad zu verlassen, übergeben Sie einen beschreibbaren [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO)‑Stream und einen [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/)‑Wert an die [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipresentation/save/)‑Methode. Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Web‑Service zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

Das folgende Beispiel speichert eine neue Präsentation in einen Dateistream:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Sie können angeben, in welcher Ansicht PowerPoint eine gespeicherte Präsentation zunächst öffnet. Setzen Sie vor dem Speichern die Eigenschaft [ViewProperties.last_view](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewproperties/last_view/) auf einen [ViewType](https://reference.aspose.com/slides/de/python-net/aspose.slides/viewtype/)‑Wert.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Anfangsansicht:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen im Strict‑Office‑Open‑XML‑Format speichern**

Um eine PPTX‑Datei zu erzeugen, die dem Strict‑Profil von Office Open XML entspricht, erstellen Sie eine [PptxOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/)‑Instanz und setzen deren [conformance](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/conformance/)‑Eigenschaft auf `Conformance.ISO_29500_2008_STRICT`. Übergeben Sie dann die Optionen an die [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipresentation/save/)‑Methode.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Präsentationen im Office‑Open‑XML‑Format im Zip64‑Modus speichern**

Ein Standard‑ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtarchivgröße und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen heben die jeweiligen Größen‑ und Eintragszähl‑Grenzen auf.

Verwenden Sie die Eigenschaft [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/zip_64_mode/), um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- `IF_NECESSARY` verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- `NEVER` deaktiviert ZIP64‑Erweiterungen.
- `ALWAYS` schreibt immer ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert ZIP64‑Erweiterungen für die Ausgabepäsentation stets:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Wenn `Zip64Mode.NEVER` verwendet wird und die Präsentation nicht in die Standard‑ZIP‑Grenzen passt, löst der Speicher‑Vorgang eine [PptxException](https://reference.aspose.com/slides/de/python-net/aspose.slides/pptxexception/) aus.
{{% /alert %}}

## **Präsentationen im Office‑Open‑XML‑Format mit Komprimierungsstufen speichern**

Für PPTX‑Ausgaben können Sie die Speicher‑Geschwindigkeit gegen die Dateigröße abwägen, indem Sie die Eigenschaft [PptxOptions.compression_level](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/compression_level/) setzen. Die Aufzählung [CompressionLevel](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/compressionlevel/) liefert folgende Werte:

- `NONE` speichert Daten ohne Kompression.
- `LEVEL1` liefert die schnellste Kompression und die größte komprimierte Ausgabe.
- `LEVEL2` bis `LEVEL5` bevorzugen sukzessive kleinere Ausgaben gegenüber der Speichergeschwindigkeit.
- `LEVEL6` balanciert Speichergeschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- `LEVEL7` und `LEVEL8` favorisieren kleinere Ausgaben stärker als die Geschwindigkeit.
- `LEVEL9` bietet die stärkste Kompression und benötigt die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Kompression:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Das folgende Beispiel verwendet die maximale Komprimierungsstufe:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Präsentationen ohne Aktualisieren des Thumbnails speichern**

Wenn eine Präsentation als PPTX gespeichert wird, steuert die Eigenschaft [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) ihr Dokument‑Thumbnail:

- `True` generiert das Thumbnail während des Speicher‑Vorgangs neu. Dies ist der Standardwert.
- `False` bewahrt das vorhandene Thumbnail. Hat die Präsentation kein Thumbnail, erzeugt Aspose.Slides keins.

Das folgende Beispiel speichert eine Präsentation, ohne ihr Thumbnail zu aktualisieren:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Das Deaktivieren der Thumbnail‑Aktualisierung kann die zum Speichern einer PPTX‑Datei benötigte Zeit verkürzen.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose bietet einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) an, der mit der Aspose.Slides‑API gebaut wurde. Er speichert ausgewählte Folien einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „Fast Save“?**

Nein. Jeder Speicher‑Vorgang schreibt eine vollständige Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz [ist nicht threadsicher](/slides/de/python-net/multithreading/). Greifen Sie von jeweils nur einem Thread aus zu und speichern Sie sie dort.

**Was passiert mit Hyperlinks und extern verknüpften Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) bleiben in der Präsentation erhalten. Aspose.Slides kopiert extern verknüpfte Dateien nicht, sodass die gespeicherte Präsentation weiterhin auf deren Speicherorte zugreifen muss.

**Kann ich Dokument‑Metadaten wie Autor, Titel, Unternehmen und Erstellungsdatum speichern?**

Ja. Setzen Sie die entsprechenden [Dokument‑Eigenschaften](/slides/de/python-net/presentation-properties/) vor dem Speichern, und Aspose.Slides schreibt sie in die Ausgabedatei.