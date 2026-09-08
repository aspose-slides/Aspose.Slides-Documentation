---
title: Ink‑Objekte in Präsentationen mit Python via Java verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/python-java/manage-ink/
keywords:
- Tinte
- Ink‑Objekt
- Ink‑Spur
- Ink verwalten
- Ink zeichnen
- Zeichnung
- Ink‑Export
- Ink‑Rendern
- Ink ausblenden
- InkOptions
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Ink‑Objekte, bearbeiten Sie Spuren und Pinsel‑Eigenschaften und steuern Sie das Erscheinungsbild von Ink beim Export von PDF, HTML, SVG, TIFF und Bildern mit Aspose.Slides für Python via Java."
---
## **Einleitung**

PowerPoint bietet eine Ink‑Funktion, mit der Sie Freihand‑Striche zeichnen können. Ink kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Aspose.Slides stellt die Typen bereit, die zum Arbeiten mit Ink‑Objekten erforderlich sind. Beispielsweise repräsentiert die [Ink](https://reference.aspose.com/slides/de/python-java/aspose.slides/ink/)‑Klasse ein Ink‑Objekt auf einer Folie.

## **Unterschiede zwischen normalen Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch Shape‑Objekte dargestellt. In seiner einfachsten Form ist ein Shape ein Container, der den Bereich des eigentlichen Objekts (seinen Rahmen) zusammen mit Eigenschaften wie Größe, Form und Hintergrund definiert. Weitere Informationen finden Sie unter [Shape Layout Format](/slides/de/python-java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Ink‑Objekt verarbeitet, ignoriert es alle Eigenschaften des Objekt‑Rahmens (Containers) außer seiner Größe. Die Größe des Container‑Bereichs wird durch die Standardmethoden [Shape.getWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getWidth) und [Shape.getHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getHeight) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink‑Spuren**

Eine Ink‑Spur ist ein Basiselement, das die Laufbahn einer Feder aufzeichnet, während ein Benutzer digitale Ink schreibt. Eine Spur speichert eine Sequenz verbundener Punkte.

Die einfachste Form der Codierung gibt die X‑ und Y‑Koordinaten jedes Sample‑Punktes an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte einer Ink‑Spur verbinden. Der Pinsel verfügt über eigene Farbe und Größe, die durch die Methoden [InkBrush.getColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkbrush/#getColor) und [InkBrush.getSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkbrush/#getSize) bereitgestellt werden.

### **Ink‑Pinsel‑Farbe festlegen**

Dieser Python‑Code zeigt, wie die Farbe eines Ink‑Pinsels festgelegt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Ink‑Pinsel‑Größe festlegen**

Dieser Python‑Code zeigt, wie die Größe eines Ink‑Pinsels festgelegt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der entsprechende Datenbereich ist ausgegraut). Stimmen Breite und Höhe überein, wird die Größe in PowerPoint wie folgt angezeigt:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Veranschaulichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel – er geht stets davon aus, dass die Linien­dicke Null ist (siehe das vorherige Bild).

Um therefore die sichtbare Fläche des gesamten Ink‑Objekts zu bestimmen, muss die Pinselgröße seiner Spuren berücksichtigt werden. Hier wurde das Zielobjekt (die handgeschriebene Textspur) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Container‑Größe, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Steuerung des Ink‑Erscheinungsbildes beim Export und Rendern**

Aspose.Slides stellt die Klasse [InkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/) bereit, um zu steuern, wie Ink‑Objekte in exportierten oder gerenderten Ausgaben erscheinen. Mit ihren Eigenschaften können Sie Ink vollständig ausblenden oder ändern, wie Ink‑Pinsel‑Masken‑Operationen interpretiert werden.

Ink‑Optionen stehen über die Export‑ bzw. Rendering‑Optionen für mehrere Ausgabetypen zur Verfügung:

| Ausgabe | Ink‑Option‑Eigenschaft |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Folien‑Bild | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Die folgenden [InkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/)-Methoden stellen dieselben beiden Einstellungen bereit:

- [getHideInk](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#getHideInk) bestimmt, ob Ink‑Objekte in die Ausgabe einbezogen werden. Der Standardwert ist `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bestimmt, ob eine Masken‑Operation beim Rendern eines Ink‑Pinsels als Deckkraft interpretiert wird. Der Standardwert ist `True`; rufen Sie [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) mit `False` auf, um stattdessen die ROP‑Operation zu verwenden.

### **Ink‑Objekte in PDF‑Ausgabe ausblenden**

Standardmäßig bleiben Ink‑Objekte beim Export sichtbar. Um eine saubere Ausgabe ohne handschriftliche Anmerkungen oder andere Ink‑Inhalte zu erzeugen, rufen Sie [InkOptions.setHideInk](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#setHideInk) mit `True` auf.

Das folgende Python‑Beispiel exportiert eine Präsentation als PDF und blendet dabei alle Ink‑Objekte aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Ink‑Objekte beim Rendern einer Folie als Bild ausblenden**

Um Ink‑Objekte beim Rendern von Folien als Bitmap‑Bilder auszublenden, konfigurieren Sie [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/#getInkOptions) und übergeben Sie die Rendering‑Optionen an [Slide.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getImage).

Das folgende Python‑Beispiel rendert die erste Folie als PNG‑Bild ohne Ink‑Objekte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Steuerung der Ink‑Masken‑Darstellung**

Die Einstellung [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) kontrolliert, wie Masken‑Operationen beim Rendern von Ink‑Pinseln interpretiert werden. Der Standardwert ist `True`, was Deckkraft verwendet. Um stattdessen die ROP‑Operation zu nutzen, rufen Sie [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) mit `False` auf.

Das folgende Python‑Beispiel exportiert eine Folie als SVG und verwendet ROP‑basiertes Rendering für Ink‑Masken‑Operationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Die gleiche Einstellung kann über [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/#getInkOptions) angewendet werden, wenn eine Präsentation als TIFF exportiert oder eine Folie gerendert wird.

### **Auswählen, ob Ink ausgeblendet oder erhalten bleibt**

Wenn Sie für die Verteilung eine saubere Version einer annotierten Präsentation ohne Prüfzeichen benötigen, rufen Sie [InkOptions.setHideInk](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#setHideInk) mit `True` während des Exports auf.

Lassen Sie [InkOptions.getHideInk](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#getHideInk) bei seinem Standardwert `False`, wenn Ink‑Anmerkungen Teil des beabsichtigten Inhalts sind, etwa Prüfbemerkungen, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im exportierten Ergebnis sichtbar bleiben sollen. Dadurch können Anwendungen separate Prüf‑ und Endausgaben aus derselben Präsentation erzeugen, ohne die Quell‑Ink‑Objekte zu ändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines bestehenden Ink‑Strichs ändern?**

Ja. Holen Sie die Spur über [Ink.getTraces](https://reference.aspose.com/slides/de/python-java/aspose.slides/ink/#getTraces) und ändern Sie deren [InkTrace.getBrush](https://reference.aspose.com/slides/de/python-java/aspose.slides/inktrace/#getBrush). Rufen Sie [InkBrush.setColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkbrush/#setColor) oder [InkBrush.setSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkbrush/#setSize) auf, um den Pinsel zu ändern.

**Ändert das Ausblenden von Ink die Quell‑Präsentation?**

Nein. Der Aufruf von [InkOptions.setHideInk](https://reference.aspose.com/slides/de/python-java/aspose.slides/inkoptions/#setHideInk) wirkt sich nur auf das gerenderte bzw. exportierte Ergebnis aus; er entfernt oder verändert Ink‑Objekte in der Quell‑Präsentation nicht.

**Welche Export‑Formate unterstützen Ink‑Optionen?**

Sie können Ink‑Optionen für PDF, HTML, SVG, TIFF und bitmap‑Folien‑Bilder über die entsprechenden Export‑ bzw. Rendering‑Optionen, die oben gezeigt wurden, konfigurieren.

**Weiterführende Lektüre**

* Für allgemeine Informationen zu Shapes siehe den Abschnitt [PowerPoint Shapes](/slides/de/python-java/powerpoint-shapes/).
* Für Details zu effektiven Werten siehe [Shape Effective Properties](/slides/de/python-java/shape-effective-properties/#get-effective-font-height-value).
* Für Details zum PDF‑Export siehe [Convert PPT and PPTX to PDF](/slides/de/python-java/convert-powerpoint-to-pdf/).
* Für Details zum HTML‑Export siehe [Convert PowerPoint Presentations to HTML](/slides/de/python-java/convert-powerpoint-to-html/).
* Für Details zum SVG‑Export siehe [Render Presentation Slides as SVG Images](/slides/de/python-java/render-a-slide-as-an-svg-image/).
* Für Details zum TIFF‑Export siehe [Convert PowerPoint Presentations to TIFF](/slides/de/python-java/convert-powerpoint-to-tiff/).
* Für Details zum Rendern von Folien zu Bildern siehe [Convert Presentation Slides to Images](/slides/de/python-java/convert-slide/).