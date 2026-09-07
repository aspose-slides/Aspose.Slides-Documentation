---
title: Präsentationsfolien als SVG-Bilder in Python über Java rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- SVG-Exportoptionen
- interaktives SVG
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in Python über Java und steuern Sie Schriften, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares XML-basiertes Bildformat, das sich gut für Web‑Veröffentlichungen, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriften, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, plattformübergreifend vorhersehbar oder für interaktive Verwendung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [Slide.writeAsSvg](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) in einen Stream. Die Beispiele benötigen eine vorhandene `presentation.pptx`‑Datei. Jedes Beispiel startet die JVM bei Bedarf und schließt seine Ausgabeströme. Das folgende Beispiel exportiert jede Folie einer Präsentation in eine separate SVG‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Der Dateiname verwendet [Slide.getSlideNumber](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getSlideNumber) anstelle des Schleifenindex. Sie können auch ein einzelnes Shape mit [Shape.writeAsSvg](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur dieses Shape benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/) steuert das SVG‑Rendering. Für Textfelder fügt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setUseFrameSize) das Textfeld in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setUseFrameRotation) bestimmt, ob die Frame‑Rotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) auf `True`, wenn Text ohne Ligaturen gerendert werden muss.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Text und Schriften steuern**

### **Allen Text vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setVectorizeText) auf `True`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch entfallen Schriftabhängigkeiten und das visuelle Ergebnis wird über Browser hinweg konsistenter, jedoch ist der Text nicht mehr als SVG‑Text auswähl‑ oder durchsuchbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Auswahl, wie externe Schriften behandelt werden**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgexternalfontshandling/)-Wert für extern geladene Schriften. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftinformationen in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriften verwendet, als Grafik zu rendern. Prüfen Sie die Lizenzierung der Schriften, bevor Sie sie einbetten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Eingebettete Bildgröße reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setPicturesCompression), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setJpegQuality), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen reduzieren die Dateigröße zulasten der Bildtreue oder der erhaltenen Bilddaten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Stabile IDs für Shapes und Text zuweisen**

Verwenden Sie einen Python‑Formatierungs‑Controller, der über `jpype.JProxy` registriert wird, um [SvgShape.setId](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgshape/#setId)-Werte zu Shapes und [SvgTSpan.setId](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgtspan/#setId)-Werte zu Text‑`tspan`‑Elementen zuzuweisen. Registrieren Sie den Proxy mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Der folgende Controller verwendet [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getOfficeInteropShapeId), das für die Lebensdauer des Shapes stabil ist, und einen wiederholbaren Zähler für seine Text‑Spans. Dadurch sind die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation geeignet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **SVG‑Ereignishandler hinzufügen**

Rufen Sie in einem Python‑Formatierungs‑Controller [SvgShape.setEventHandler](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgshape/#setEventHandler) mit einem [SvgEvent](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgevent/)-Wert auf, um einem exportierten Shape einen JavaScript‑Ereignishandler hinzuzufügen. Registrieren Sie den Controller über `jpype.JProxy` und weisen Sie ihn mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setShapeFormattingController) zu. Definieren Sie die JavaScript‑Funktion in der Seite oder im SVG‑Dokument, das das Ergebnis hostet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folienbetrachter, Barrierefreiheits‑Verbesserungen und weitere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setVectorizeText) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#setVectorizeText), wenn sämtlicher Text unabhängig von Schriften sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), wenn nur Text, der externe Schriften nutzt, in Grafiken konvertiert werden soll.

**Wie mache ich ein SVG am besten kleiner?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Auswahl verknüpfter Schriften, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da eine niedrigere Bildauflösung, niedrigere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse bedeuten.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie anschließend die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browserskript aus.