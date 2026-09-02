---
title: Verwalten von Präsentations‑Tintenobjekten in .NET
linktitle: Tinte verwalten
type: docs
weight: 95
url: /de/net/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Tinte verwalten
- Tinte zeichnen
- Zeichnung
- Tintenexport
- Tintenrendering
- Tinte ausblenden
- IInkOptions
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Tintenobjekte, bearbeiten Sie Spuren und Pinsel‑Eigenschaften und steuern Sie das Aussehen von Tinte beim Export von PDF, HTML, SVG, TIFF und Bilddateien mit Aspose.Slides für .NET."
---
## **Einleitung**

PowerPoint bietet eine Tinten‑Funktion, mit der Sie Freihand‑Striche zeichnen können. Tinte kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Der Namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/de/net/aspose.slides.ink/) enthält die Klassen und Schnittstellen, die zum Arbeiten mit Tinten‑Objekten erforderlich sind. Zum Beispiel repräsentiert die Schnittstelle [IInk](https://reference.aspose.com/slides/de/net/aspose.slides.ink/iink/) ein Tinten‑Objekt auf einer Folie.

## **Unterschiede zwischen regulären Objekten und Tinten‑Objekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch Shape‑Objekte dargestellt. In seiner einfachsten Form ist ein Shape ein Container, der den Bereich des eigentlichen Objekts (sein Rahmen) zusammen mit Eigenschaften wie Container‑Größe, Form und Hintergrund definiert. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/de/net/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Tinten‑Objekt verarbeitet, ignoriert es alle Eigenschaften des Objekt‑Rahmens (Containers) außer seiner Größe. Die Größe des Container‑Bereichs wird durch die Standard‑Eigenschaften [IShape.Width](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/width/) und [IShape.Height](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/height/) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tinten‑Spuren**

Eine Tinten‑Spur ist ein Basiselement, das die Trajektorie eines Stifts aufzeichnet, während ein Benutzer digitale Tinte schreibt. Eine Spur speichert eine Sequenz verbundener Punkte.

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Abtastpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte einer Tinten‑Spur verbinden. Der Pinsel hat seine eigene Farbe und Größe, dargestellt durch die Eigenschaften [IInkBrush.Color](https://reference.aspose.com/slides/de/net/aspose.slides.ink/iinkbrush/color/) und [IInkBrush.Size](https://reference.aspose.com/slides/de/net/aspose.slides.ink/iinkbrush/size/).

### **Ink‑Pinsel‑Farbe festlegen**

Dieser C#‑Code zeigt, wie die Farbe eines Ink‑Pinsels festgelegt wird:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Ink‑Pinsel‑Größe festlegen**

Dieser C#‑Code zeigt, wie die Größe eines Ink‑Pinsels festgelegt wird:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Im Allgemeinen stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinsel‑Größe nicht anzeigt (der entsprechende Datenbereich ist ausgegraut). Stimmen Breite und Höhe des Pinsels überein, zeigt PowerPoint die Größe folgendermaßen an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Tinten‑Objekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke Null ist (siehe das vorherige Bild).

Daher muss zur Bestimmung des sichtbaren Bereichs des gesamten Tinten‑Objekts die Pinselgröße seiner Spuren berücksichtigt werden. Hier wurde das Zielobjekt (die handschriftliche Textspur) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Steuerung des Tinten‑Aussehens beim Export und Rendering**

Aspose.Slides stellt die Schnittstelle [IInkOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/) bereit, um zu steuern, wie Tinten‑Objekte im exportierten oder gerenderten Ergebnis erscheinen. Mit ihren Eigenschaften können Sie Tinte vollständig ausblenden oder ändern, wie Tinten‑Pinsel‑Masken‑Operationen interpretiert werden.

Ink‑Optionen stehen über die Export‑ bzw. Rendering‑Optionen für mehrere Ausgabetypen zur Verfügung:

| Ausgabe | Ink‑Optionen‑Eigenschaft |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/de/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/de/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/de/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Folien‑Bild | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/de/net/aspose.slides.export/renderingoptions/inkoptions/) |

Über diese Eigenschaften stehen dieselben beiden Einstellungen zur Verfügung:

- [`HideInk`](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/hideink/) bestimmt, ob Tinten‑Objekte in die Ausgabe einbezogen werden. Der Standardwert ist `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) bestimmt, ob eine Masken‑Operation beim Rendern eines Tinten‑Pinsels als Opazität interpretiert wird. Der Standardwert ist `true`; setzen Sie ihn auf `false`, um stattdessen die ROP‑Operation zu verwenden.

### **Tinten‑Objekte im PDF‑Export ausblenden**

Standardmäßig bleiben Tinten‑Objekte beim Export sichtbar. Setzen Sie [IInkOptions.HideInk](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/hideink/) auf `true`, wenn Sie ein sauberes Ergebnis ohne handschriftliche Anmerkungen oder andere Tinten‑Inhalte benötigen.

Das folgende C#‑Beispiel exportiert eine Präsentation als PDF und blendet alle Tinten‑Objekte aus:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Tinten‑Objekte beim Rendern einer Folie als Bild ausblenden**

Um Tinten‑Objekte beim Rendern von Folien als Bitmap‑Bilder auszublenden, konfigurieren Sie [RenderingOptions.InkOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/renderingoptions/inkoptions/) und übergeben die Rendering‑Optionen an die Methode [ISlide.GetImage](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/).

Das folgende C#‑Beispiel rendert die erste Folie als PNG‑Bild ohne Tinten‑Objekte:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Steuerung des Renderns von Tinten‑Masken**

Die Eigenschaft [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) steuert, wie Masken‑Operationen beim Rendern von Tinten‑Pinseln interpretiert werden. Der Standardwert ist `true` (Opazität). Setzen Sie die Eigenschaft auf `false`, um stattdessen die ROP‑Operation zu verwenden.

Das folgende C#‑Beispiel exportiert eine Folie als SVG und verwendet ROP‑basiertes Rendering für Tinten‑Masken‑Operationen:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Dasselbe Setting kann über [TiffOptions.InkOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/inkoptions/) angewendet werden, wenn eine Präsentation exportiert oder eine Folie als TIFF gerendert wird.

### **Auswählen, ob Tinte ausgeblendet oder erhalten bleibt**

Verwenden Sie [IInkOptions.HideInk](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/hideink/) mit dem Wert `true`, wenn die exportierte Datei eine saubere Version einer annotierten Präsentation sein soll, z. B. eine endgültige Kopie zur Verteilung ohne Review‑Markierungen.

Belassen Sie [IInkOptions.HideInk](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/hideink/) auf dem Standardwert `false`, wenn Tinten‑Anmerkungen Teil des beabsichtigten Inhalts sind, etwa Review‑Kommentare, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im exportierten Ergebnis sichtbar bleiben sollen. So können Anwendungen aus derselben Präsentation separate Review‑ und Final‑Ausgaben erzeugen, ohne die Quell‑Tinten‑Objekte zu ändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines vorhandenen Tinten‑Strichs ändern?**

Ja. Holen Sie die Spur aus [IInk.Traces](https://reference.aspose.com/slides/de/net/aspose.slides.ink/iink/traces/), und ändern Sie dann deren [IInkTrace.Brush](https://reference.aspose.com/slides/de/net/aspose.slides.ink/iinktrace/brush/). Sie können die Eigenschaften [IInkBrush.Color](https://reference.aspose.com/slides/de/net/aspose.slides.ink/iinkbrush/color/) und [IInkBrush.Size](https://reference.aspose.com/slides/de/net/aspose.slides.ink/iinkbrush/size/) des Pinsels setzen.

**Ändert das Ausblenden von Tinte die Quell‑Präsentation?**

Nein. [IInkOptions.HideInk](https://reference.aspose.com/slides/de/net/aspose.slides.export/iinkoptions/hideink/) wirkt sich nur auf das gerenderte oder exportierte Ergebnis aus; es entfernt oder verändert keine Tinten‑Objekte in der Quell‑Präsentation.

**Welche Export‑Formate unterstützen Ink‑Optionen?**

Sie können Ink‑Optionen für PDF, HTML, SVG, TIFF und Bitmap‑Folien‑Bilder über die oben gezeigten entsprechenden Export‑ bzw. Rendering‑Optionen konfigurieren.

**Weiterführende Lektüre**

* Informationen zu Shapes allgemein finden Sie im Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/de/net/powerpoint-shapes/).
* Für Details zu effektiven Werten siehe [Shape Effective Properties](https://docs.aspose.com/slides/de/net/shape-effective-properties/#get-effective-font-height-value).
* Details zum PDF‑Export: [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/de/net/convert-powerpoint-to-pdf/).
* Details zum HTML‑Export: [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/de/net/convert-powerpoint-to-html/).
* Details zum SVG‑Export: [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/de/net/render-a-slide-as-an-svg-image/).
* Details zum TIFF‑Export: [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/de/net/convert-powerpoint-to-tiff/).
* Details zum Rendern von Folien zu Bildern: [Convert Presentation Slides to Images](https://docs.aspose.com/slides/de/net/convert-slide/).