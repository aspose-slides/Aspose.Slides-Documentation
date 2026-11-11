---
title: Rendern von Präsentationsfolien als SVG‑Bilder in Python über Java
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
description: "Exportieren Sie PowerPoint‑Folien als SVG‑Bilder in Python über Java und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML‑basiertes Bildformat, das sich gut für die Webveröffentlichung, Folienbetrachter, Barrierefreiheits‑Workflows und die automatische Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Steuerung, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) wenn das exportierte SVG kompakt, browserübergreifend vorhersagbar oder für interaktive Verwendung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) in einen Stream. Die Beispiele benötigen eine vorhandene Datei `presentation.pptx`. Jedes Beispiel startet die JVM bei Bedarf und schließt seine Ausgabeströme. Das folgende Beispiel exportiert jede Folie einer Präsentation in eine separate SVG‑Datei.

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

Der Dateiname verwendet [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber), anstatt des Schleifenindex. Sie können auch eine einzelne Form mit [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) steuert das Rendering von SVG. Für Textfelder fügt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) das Textfeld in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) auf `True`, wenn Text ohne Ligaturen gerendert werden muss.

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

## **Beschneidung von Linienenden an Pfeilspitzen steuern**

SVG 1.1 verfügt über keine Markereinstellung, um festzulegen, wo eine Linie unterhalb einer Pfeilspitze enden soll. Standardmäßig verkürzt Aspose.Slides die exportierte Linie, sodass die Kontur nicht durch das Markierungssymbol hindurchragt. Rufen Sie [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) mit `True` auf, um die Kontur bis zum ursprünglichen Endpunkt der Linie zu zeichnen. Diese Einstellung wirkt sich nur auf die SVG‑Ausgabe aus. Die Linie behält ihre Position und Länge auf der Folie bei.

Das Beispiel zeichnet Dreieck‑ und Rautenspitzpfeile auf Linien mit einer Breite von 2 bzw. 10 Punkten. Es exportiert dieselbe Folie zweimal und ändert nur die Beschneidungsoption.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Der Vergleich zeigt die dreieckige Pfeilspitze auf der 10‑Punkt‑Linie. Bei aktivierter Beschneidung ist die Spitze scharf. Bei deaktivierter Beschneidung ragt die Kontur durch die schrägen Seiten des Markers und hat ein flaches Ende.

![Vergrößertes 10‑Punkt‑Dreieck mit scharfer Spitze bei aktivierter Beschneidung und flachem Ende bei deaktivierter Beschneidung](line-end-cropping.png)

In den übrigen Linien des Beispiels ist die hervortretende Kontur bei dem 2‑Punkt‑Dreieck weniger sichtbar. Der ausgefüllte Raute deckt das Ende der Kontur bei beiden Breiten ab.

## **Text und Schriftarten steuern**

Beim Export von Folien nach SVG können Sie steuern, ob Text als Text bleibt oder in Vektorgrafiken umgewandelt wird und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftartabhängigkeiten im exportierten SVG auszubalancieren.

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) auf `True`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dies eliminiert Schriftartabhängigkeiten und sorgt für ein über Browser hinweg konsistenteres visuelles Ergebnis, jedoch ist der Text anschließend nicht mehr auswähl- oder durchsuchbar als SVG‑Text.

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

### **Auswahl der Behandlung externer Schriftarten**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/)‑Wert für extern geladene Schriftarten. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafik zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

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

## **Größe eingebetteter Bilder reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verkleinern die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Auflösung der Metadatei‑Rasterung steuern**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) legt die untere Auflösungsgrenze für die Rasterung von Metadateien beim SVG‑Export fest. Verwenden Sie sie, um Details und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild rasterisiert wird. Sie definiert nicht ein globales DPI für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonallinien enthält. Das folgende Beispiel exportiert seine erste Folie mit drei Rasterungsauflösungen über [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Alle anderen Exporteinstellungen bleiben identisch, damit die Ergebnisse vergleichbar sind.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

In der Ausgabe wurde das EMF in jedem SVG zu einem eingebetteten PNG. Die folgenden Messwerte beziehen sich auf die mitgelieferte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelabmessungen dar.

| Metadatei‑Rasterungs‑DPI | Eingebettete PNG‑Abmessungen | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der nachstehende Vergleich zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigegröße. Die Diagonallinien zeigen bei 72 DPI eine sichtbare Pixelung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei größer wird. Eine Erhöhung des Werts verbessert nicht zwingend jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonallinien‑Details bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) steuert die Reduzierung der Bildauflösung und kann die Auswirkung einer Änderung der Metadatei‑Rasterungsauflösung maskieren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) steuert die JPEG‑Kodierungsqualität, nicht die Metadatei‑Rasterungsauflösung.

## **Stabile IDs für Formen und Text zuweisen**

Verwenden Sie einen Python‑Formatierungs‑Controller, der über `jpype.JProxy` registriert ist, um [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId)-Werte zu Formen und [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId)-Werte zu Text‑`tspan`‑Elementen zuzuweisen. Registrieren Sie den Proxy mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Der folgende Controller verwendet [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), das für die Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für deren Text‑Spans. Dadurch eignen sich die generierten IDs für die Nachbearbeitung einer unveränderten Präsentation.

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

## **SVG‑Ereignis‑Handler hinzufügen**

Rufen Sie in einem Python‑Formatierungs‑Controller [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) mit einem [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/)‑Wert auf, um einem exportierten Objekt einen JavaScript‑Ereignis‑Handler hinzuzufügen. Registrieren Sie den Controller über `jpype.JProxy` und weisen Sie ihn mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) zu. Definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

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

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignis‑Handlern ermöglicht Folienbetrachter, Barrierefreiheits‑Verbesserungen und weitere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG zu verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Verwendung verlinkter Schriftdateien, sofern die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie über einen Formatierungs‑Controller IDs zu und wählen Sie anschließend die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browser‑Skript aus.