---
title: PowerPoint-Präsentationen nach TIFF in Python konvertieren
linktitle: PowerPoint zu TIFF
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
- PowerPoint zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) mithilfe von Aspose.Slides für Python über Java einfach in hochwertige TIFF‑Bilder konvertieren, mit Code‑Beispielen."
---
## **Einführung**

TIFF (**Tagged Image File Format**) ist ein Rasterbildformat, das mehrere Seiten und verlustfreie Kompression unterstützt. Es ist nützlich, um gerenderte Folien in einer einzigen Bilddatei zu speichern.

Mit Aspose.Slides für Python über Java können Sie PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen in TIFF konvertieren. Jeder Beispielcode startet bei Bedarf die Java‑Virtuelle Maschine und gibt die Präsentation nach Gebrauch frei.

## **Präsentation in TIFF konvertieren**

Mit der [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)-Methode der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF umwandeln. Das resultierende mehrseitige TIFF enthält ein gerendertes Bild jeder Folie in der Standardgröße.

Dieser Code zeigt, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Speichern Sie alle Folien in einer mehrseitigen TIFF-Datei.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Präsentation in Schwarz‑Weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setBwConversionMode) in der [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/)-Klasse ermöglicht es, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑Weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die [setCompressionType](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setCompressionType)-Methode auf [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) oder [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) gesetzt ist.

{{% alert color="info" title="Note" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setBwConversionMode) ist eine Export‑Einstellung, die einen Pixel‑Konvertierungsalgorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie ein einzelnes Shape im Schwarz‑Weiß‑Anzeige‑Modus dargestellt wird, verwenden Sie [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setBlackWhiteMode). Siehe [Control Black-and-White Rendering for Shapes](/slides/de/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.

{{% /alert %}}

Angenommen, wir haben eine Datei „sample.pptx“ mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser Code zeigt, wie die farbige Folie in ein Schwarz‑Weiß‑TIFF konvertiert wird:

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

![Schwarz‑Weiß TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über Methoden der [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/)-Klasse festlegen. Beispielsweise ermöglicht die [setImageSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setImageSize)-Methode die Definition der Größe des resultierenden Bildes.

Dieser Code demonstriert die Konvertierung einer PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Setzen Sie die horizontale und vertikale Auflösung.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Setzen Sie die Ausgabedimensionen in Pixeln.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Fügen Sie die vollständigen Referenten-Notizen unter jeder Folie ein.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Mit der [setPixelFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#setPixelFormat)-Methode der [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/)-Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser Code zeigt, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

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

Probieren Sie Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) aus.

{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie anstelle einer gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienanzahl beim Konvertieren einer Präsentation in TIFF?**

Für den TIFF‑Export gibt es keine feste Begrenzung der Folienzahl. Verfügbarer Speicher, Folienkomplexität und Ausgangs‑Abmessungen beeinflussen die Größe der verarbeitbaren Präsentationen.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF erhalten?**

Nein, TIFF ist ein statisches Bildformat. Deshalb werden Animationen und Übergangseffekte nicht übernommen; es werden nur statische Schnappschüsse der Folien exportiert.