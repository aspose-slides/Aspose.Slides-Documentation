---
title: Ink-Objekte in PowerPoint-Präsentationen in Java verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/java/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Tinte verwalten
- Tinte zeichnen
- Zeichnung
- Tinten-Export
- Tinten-Rendering
- Tinte ausblenden
- IInkOptions
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Ink-Objekte, bearbeiten Sie Spuren und Pinsel-Eigenschaften und steuern Sie das Aussehen von Ink beim Export von PDF, HTML, SVG, TIFF und Bilddateien mit Aspose.Slides für Java."
---
## **Einführung**

PowerPoint bietet eine Ink‑Funktion, mit der Sie Freihandstriche zeichnen können. Ink kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Aspose.Slides stellt die erforderlichen Typen zur Arbeit mit Ink‑Objekten bereit. Zum Beispiel repräsentiert das [IInk](https://reference.aspose.com/slides/de/java/com.aspose.slides/iink/) Interface ein Ink‑Objekt auf einer Folie.

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folien werden typischerweise durch Shape‑Objekte dargestellt. In seiner einfachsten Form ist ein Shape ein Container, der den Bereich des Objekts selbst (seinen Rahmen) definiert sowie Eigenschaften wie Containergröße, Form und Hintergrund enthält. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/de/java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Ink‑Objekt verarbeitet, ignoriert es alle Eigenschaften des Objekt‑Frames (Containers) außer seiner Größe. Die Größe des Containerbereichs wird durch die Standardmethoden [IShape.getWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getWidth--) und [IShape.getHeight](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getHeight--) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink‑Spuren**

Eine Ink‑Spur ist ein Basiselement, das die Bahn einer Schreibspitze aufzeichnet, wenn ein Benutzer digitale Ink schreibt. Eine Spur speichert eine Sequenz verbundener Punkte.

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Probenpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte einer Ink‑Spur verbinden. Der Pinsel hat eine eigene Farbe und Größe, die durch die Methoden [IInkBrush.getColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkbrush/#getColor--) und [IInkBrush.getSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkbrush/#getSize--) dargestellt werden.

### **Ink‑Pinselfarbe festlegen**

Dieser Java‑Code zeigt, wie die Farbe eines Ink‑Pinsels festgelegt wird:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Ink‑Pinselgröße festlegen**

Dieser Java‑Code zeigt, wie die Größe eines Ink‑Pinsels festgelegt wird:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der entsprechende Datenabschnitt ist ausgegraut). Stimmen Breite und Höhe des Pinsels überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel – er geht immer davon aus, dass die Linienstärke Null ist (siehe das vorherige Bild).

Daher muss für die Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße seiner Spuren berücksichtigt werden. Hier wurde das Zielobjekt (die handschriftliche Textspur) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Containergröße, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Steuerung des Aussehens von Ink bei Export und Rendering**

Aspose.Slides stellt das Interface [IInkOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/) bereit, um zu steuern, wie Ink‑Objekte in exportierten oder gerenderten Ausgaben erscheinen. Mit seinen Eigenschaften können Sie Ink vollständig ausblenden oder ändern, wie Ink‑Pinsel‑Maskenoperationen interpretiert werden.

Ink‑Optionen sind über die Export‑ oder Rendering‑Optionen für verschiedene Ausgabetypen verfügbar:

| Ausgabe | Ink‑Optionen‑Eigenschaft |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/de/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Die folgenden [IInkOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/) Methoden stellen dieselben beiden Einstellungen bereit:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#getHideInk--) bestimmt, ob Ink‑Objekte in die Ausgabe einbezogen werden. Der Standardwert ist `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bestimmt, ob eine Maskenoperation beim Rendern eines Ink‑Pinsels als Deckkraft interpretiert wird. Der Standardwert ist `true`; rufen Sie [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) mit `false` auf, um stattdessen die ROP‑Operation zu verwenden.

### **Ink‑Objekte im PDF‑Ausgabe ausblenden**

Standardmäßig bleiben Ink‑Objekte beim Export sichtbar. Um eine saubere Ausgabe ohne handschriftliche Anmerkungen oder andere Ink‑Inhalte zu erstellen, rufen Sie [IInkOptions.setHideInk](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) mit `true` auf.

Das folgende Java‑Beispiel exportiert eine Präsentation nach PDF und blendet dabei alle Ink‑Objekte aus:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ink‑Objekte beim Rendern einer Folie als Bild ausblenden**

Um Ink‑Objekte beim Rendern von Folien als Bitmap‑Bilder auszublenden, konfigurieren Sie [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/renderingoptions/#getInkOptions--) und übergeben Sie die Rendering‑Optionen an [ISlide.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Das folgende Java‑Beispiel rendert die erste Folie als PNG‑Bild ohne Ink‑Objekte:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Ink‑Masken‑Rendering steuern**

Die Einstellung [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) steuert, wie Maskenoperationen beim Rendern von Ink‑Pinseln interpretiert werden. Der Standardwert ist `true`, was Deckkraft verwendet. Um stattdessen die ROP‑Operation zu nutzen, rufen Sie [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) mit `false` auf.

Das folgende Java‑Beispiel exportiert eine Folie nach SVG und verwendet ROP‑basiertes Rendering für Ink‑Maskenoperationen:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Dieselbe Einstellung kann über [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#getInkOptions--) angewendet werden, wenn eine Präsentation exportiert oder eine Folie nach TIFF gerendert wird.

### **Entscheiden, ob Ink ausgeblendet oder erhalten werden soll**

Wenn Sie eine saubere Version einer annotierten Präsentation zur Verteilung ohne Prüfungsmarken benötigen, rufen Sie während des Exports [IInkOptions.setHideInk](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) mit `true` auf.

Lassen Sie [IInkOptions.getHideInk](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#getHideInk--) bei seinem Standardwert `false`, wenn Ink‑Anmerkungen Teil des beabsichtigten Inhalts sind, z. B. Prüfungskommentare, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im exportierten Ergebnis sichtbar bleiben sollen. Dies ermöglicht Anwendungen, separate Prüf‑ und Endausgaben aus derselben Präsentation zu erzeugen, ohne die Quell‑Ink‑Objekte zu ändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines vorhandenen Ink‑Strichs ändern?**

Ja. Holen Sie die Spur über [IInk.getTraces](https://reference.aspose.com/slides/de/java/com.aspose.slides/iink/#getTraces--) und ändern Sie anschließend deren [IInkTrace.getBrush](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinktrace/#getBrush--). Rufen Sie [IInkBrush.setColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) oder [IInkBrush.setSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) auf, um den Pinsel zu ändern.

**Ändert das Ausblenden von Ink die Quell‑Präsentation?**

Nein. Das Aufrufen von [IInkOptions.setHideInk](https://reference.aspose.com/slides/de/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) wirkt sich nur auf das gerenderte oder exportierte Ergebnis aus; es entfernt oder ändert keine Ink‑Objekte in der Quell‑Präsentation.

**Welche Exportformate unterstützen Ink‑Optionen?**

Sie können Ink‑Optionen für PDF, HTML, SVG, TIFF und Bitmap‑Folienbilder über die oben gezeigten entsprechenden Export‑ oder Rendering‑Optionen konfigurieren.

**Weiterführende Informationen**

* Informationen zu Shapes im Allgemeinen finden Sie im Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/de/java/powerpoint-shapes/).
* Weitere Informationen zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/de/java/shape-effective-properties/#get-effective-font-height-value).
* Details zum PDF‑Export finden Sie unter [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/de/java/convert-powerpoint-to-pdf/).
* Details zum HTML‑Export finden Sie unter [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/de/java/convert-powerpoint-to-html/).
* Details zum SVG‑Export finden Sie unter [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/de/java/render-a-slide-as-an-svg-image/).
* Details zum TIFF‑Export finden Sie unter [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/de/java/convert-powerpoint-to-tiff/).
* Details zum Rendern von Folien zu Bildern finden Sie unter [Convert Presentation Slides to Images](https://docs.aspose.com/slides/de/java/convert-slide/).