---
title: PowerPoint-Präsentationen nach TIFF in Python konvertieren
linktitle: PowerPoint nach TIFF
type: docs
weight: 90
url: /de/python-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint nach TIFF
- Präsentation nach TIFF
- Folie nach TIFF
- PPT nach TIFF
- PPTX nach TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) ganz einfach in hochwertige TIFF‑Bilder mit Aspose.Slides für Python über Java konvertieren, inklusive Code‑Beispielen."
---
## **Einführung**

TIFF (**Tagged Image File Format**) ist ein Rasterbildformat, das mehrere Seiten und verlustfreie Kompression unterstützt. Es ist nützlich, gerenderte Folien in einer einzigen Bilddatei zu speichern.

Mit Aspose.Slides für Python über Java können Sie PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen in TIFF konvertieren. Jeder nachfolgende Code startet die virtuelle Java‑Maschine bei Bedarf und gibt die Präsentation nach der Verwendung frei.

## **Präsentation in TIFF konvertieren**

Mit der [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)‑Methode der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Das resultierende mehrseitige TIFF enthält ein gerendertes Bild jeder Folie in Standardgröße.

Der folgende Code zeigt, wie Sie eine PowerPoint‑Präsentation in TIFF konvertieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Alle Folien in einer mehrseitigen TIFF-Datei speichern.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Präsentation in Schwarz‑und‑Weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setBwConversionMode) in der Klasse [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/) ermöglicht es, den beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑und‑Weiß‑TIFF zu verwendenden Algorithmus festzulegen. Beachten Sie, dass diese Einstellung nur gilt, wenn die Methode [setCompressionType](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setCompressionType) auf [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) oder [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) gesetzt ist.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setBwConversionMode) ist eine Export‑Einstellung, die einen Pixel‑Konversionsalgorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie ein einzelnes Shape aussehen soll, wenn der Schwarz‑und‑Weiß‑Anzeigemodus aktiv ist, verwenden Sie [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setBlackWhiteMode). Weitere Beispiele finden Sie unter [Control Black-and-White Rendering for Shapes](/slides/de/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes).
{{% /alert %}}

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Der folgende Code zeigt, wie Sie die farbige Folie in ein Schwarz‑und‑Weiß‑TIFF konvertieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Schwarz‑und‑Weiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise ermöglicht die Methode [setImageSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setImageSize) die Definition der Größe des resultierenden Bildes.

Der folgende Code zeigt, wie Sie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertieren:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Setze die horizontale und vertikale Auflösung.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Setze die Ausgabedimensionen in Pixeln.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Füge die vollständigen Referenten-Notizen unter jeder Folie ein.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Präsentation in TIFF mit benutzerdefiniertem Bildpixel‑Format konvertieren**

Mit der Methode [setPixelFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setPixelFormat) aus der Klasse [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/) können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Der folgende Code zeigt, wie Sie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Tip" color="success" %}}
Schauen Sie sich Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie anstelle der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Es gibt kein festes Limit für die Anzahl der Folien beim TIFF‑Export. Verfügbarer Arbeitsspeicher, die Komplexität der Folien und die Ausgabedimensionen beeinflussen die Größe der Präsentationen, die Sie verarbeiten können.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF erhalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht übernommen; es werden nur statische Momentaufnahmen der Folien exportiert.