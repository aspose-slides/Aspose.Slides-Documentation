---
title: Ink‑Objekte in PowerPoint mit Python verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/python-net/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tinten-Spur
- Tinte verwalten
- Tinte zeichnen
- Zeichnen
- Tinten-Export
- Tinten-Rendering
- Tinte ausblenden
- InkOptions
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Ink‑Objekte, bearbeiten Sie Spuren und Pinsel‑Eigenschaften und steuern Sie das Aussehen von Ink beim Export nach PDF, HTML, SVG, TIFF und Bild mit Aspose.Slides für Python via .NET."
---
## **Einleitung**

PowerPoint bietet eine Ink‑Funktion, mit der Sie Freihand‑Striche zeichnen können. Tinte kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Der Namespace [aspose.slides.ink](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/) enthält die Klassen, die zum Arbeiten mit Ink‑Objekten benötigt werden. Beispielsweise stellt die Klasse [Ink](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/ink/) ein Ink‑Objekt auf einer Folie dar.

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch Shape‑Objekte dargestellt. In seiner einfachsten Form ist ein Shape ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit Eigenschaften wie Containergröße, Form und Hintergrund definiert. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/de/python-net/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Ink‑Objekt verarbeitet, ignoriert es alle Eigenschaften des Objekt‑Frames (Containers) mit Ausnahme seiner Größe. Die Größe des Container‑Bereichs wird durch die Standard‑Eigenschaften [Ink.width](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/ink/width/) und [Ink.height](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/ink/height/) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink‑Spuren**

Eine Ink‑Spur ist ein Basiselement, das die Flugbahn einer Schreibfeder aufzeichnet, wenn ein Benutzer digitale Tinte schreibt. Eine Spur speichert eine Sequenz verbundener Punkte.

Die einfachste Form der Codierung gibt die X‑ und Y‑Koordinaten jedes Stichprobenpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte einer Ink‑Spur verbinden. Seine Eigenschaften [InkBrush.color](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/inkbrush/color/) und [InkBrush.size](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/inkbrush/size/) steuern Farbe und Größe.

### **Ink‑Pinselfarbe festlegen**

Dieses Python‑Beispiel zeigt, wie die Farbe eines Ink‑Pinsels festgelegt wird:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Ink‑Pinselgröße festlegen**

Dieses Python‑Beispiel zeigt, wie die Größe eines Ink‑Pinsels festgelegt wird:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Im Allgemeinen stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der entsprechende Datenbereich ist ausgegraut). Stimmen Breite und Höhe des Pinsels überein, zeigt PowerPoint die Größe folgendermaßen an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Veranschaulichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel – er geht immer davon aus, dass die Linienstärke Null ist (siehe das vorherige Bild).

Daher muss zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße seiner Spuren berücksichtigt werden. Hier wurde das Zielobjekt (die handgeschriebene Textspur) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Container‑Größe, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Ink‑Darstellung bei Export und Rendering steuern**

Aspose.Slides stellt die Klasse [InkOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/) bereit, um zu steuern, wie Ink‑Objekte in exportierten oder gerenderten Ausgaben angezeigt werden. Mit ihren Eigenschaften können Sie Ink vollständig ausblenden oder ändern, wie Masken‑Operationen des Ink‑Pinsels interpretiert werden.

Ink‑Optionen stehen über die Export‑ oder Rendering‑Optionen für verschiedene Ausgabetypen zur Verfügung:

| Ausgabe | Ink‑Optionen‑Eigenschaft |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Über diese Eigenschaften stehen dieselben beiden Einstellungen zur Verfügung:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/hide_ink/) bestimmt, ob Ink‑Objekte in die Ausgabe aufgenommen werden. Der Standardwert ist `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) bestimmt, ob eine Masken‑Operation als Deckkraft interpretiert wird, wenn ein Ink‑Pinsel gerendert wird. Der Standardwert ist `True`; setzen Sie ihn auf `False`, um stattdessen die ROP‑Operation zu verwenden.

### **Ink‑Objekte im PDF‑Ausgabe ausblenden**

Standardmäßig bleiben Ink‑Objekte beim Export sichtbar. Setzen Sie [InkOptions.hide_ink](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/hide_ink/) auf `True`, wenn Sie ein sauberes Ergebnis ohne handschriftliche Anmerkungen oder andere Ink‑Inhalte benötigen.

Das folgende Python‑Beispiel exportiert eine Präsentation nach PDF und blendet alle Ink‑Objekte aus:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ink‑Objekte beim Rendern einer Folie als Bild ausblenden**

Um Ink‑Objekte beim Rendern von Folien als Bitmap‑Bilder auszublenden, konfigurieren Sie [RenderingOptions.ink_options](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/ink_options/) und übergeben Sie die Rendering‑Optionen an die Methode [Slide.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/).

Das folgende Python‑Beispiel rendert die erste Folie als PNG‑Bild ohne Ink‑Objekte:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Ink‑Masken‑Rendering steuern**

Die Eigenschaft [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) steuert, wie Masken‑Operationen interpretiert werden, wenn Ink‑Pinsel gerendert werden. Der Standardwert ist `True`, wodurch Deckkraft verwendet wird. Setzen Sie die Eigenschaft auf `False`, um stattdessen die ROP‑Operation zu nutzen.

Das folgende Python‑Beispiel exportiert eine Folie nach SVG und verwendet ROP‑basiertes Rendering für Ink‑Masken‑Operationen:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Dieselbe Einstellung kann über [TiffOptions.ink_options](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/ink_options/) angewendet werden, wenn eine Präsentation exportiert oder eine Folie nach TIFF gerendert wird.

### **Auswahl, ob Ink ausgeblendet oder erhalten bleiben soll**

Setzen Sie [InkOptions.hide_ink](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/hide_ink/) auf `True`, wenn die exportierte Datei eine bereinigte Version einer kommentierten Präsentation sein soll, beispielsweise eine Endkopie zur Verteilung ohne Überprüfungsmarken.

Belassen Sie [InkOptions.hide_ink](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/hide_ink/) bei seinem Standardwert `False`, wenn Ink‑Anmerkungen Teil des gewünschten Inhalts sind, etwa Prüfkriterien, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im exportierten Ergebnis sichtbar bleiben sollen. Damit können Anwendungen getrennte Prüf‑ und Endausgaben aus derselben Präsentation erzeugen, ohne die Quell‑Ink‑Objekte zu verändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines vorhandenen Ink‑Strichs ändern?**

Ja. Holen Sie die Spur über [Ink.traces](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/ink/traces/), ändern Sie dann deren [InkTrace.brush](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/inktrace/brush/). Sie können die Eigenschaften [InkBrush.color](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/inkbrush/color/) und [InkBrush.size](https://reference.aspose.com/slides/de/python-net/aspose.slides.ink/inkbrush/size/) des Pinsels setzen.

**Ändert das Ausblenden von Ink die Quellpräsentation?**

Nein. [InkOptions.hide_ink](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/inkoptions/hide_ink/) wirkt sich nur auf das gerenderte oder exportierte Ergebnis aus; es entfernt oder ändert keine Ink‑Objekte in der Quellpräsentation.

**Welche Exportformate unterstützen Ink‑Optionen?**

Sie können Ink‑Optionen für PDF, HTML, SVG, TIFF und Bitmap‑Folienbilder über die jeweiligen Export‑ bzw. Rendering‑Optionen konfigurieren, die oben aufgeführt sind.

**Weiterführende Literatur**

* Für allgemeine Informationen zu Shapes siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/de/python-net/powerpoint-shapes/).
* Weitere Informationen zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/de/python-net/shape-effective-properties/#get-effective-font-height-value).
* Für Details zum PDF‑Export siehe [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/de/python-net/convert-powerpoint-to-pdf/).
* Für Details zum HTML‑Export siehe [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/de/python-net/convert-powerpoint-to-html/).
* Für Details zum SVG‑Export siehe [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/de/python-net/render-a-slide-as-an-svg-image/).
* Für Details zum TIFF‑Export siehe [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/de/python-net/convert-powerpoint-to-tiff/).
* Für Details zum Rendern von Folien zu Bildern siehe [Convert Presentation Slides to Images](https://docs.aspose.com/slides/de/python-net/convert-slide/).