---
title: Verwalten von PowerPoint‑Tintenobjekten in JavaScript
linktitle: Tinte verwalten
type: docs
weight: 95
url: /de/nodejs-java/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Tinte verwalten
- Tinte zeichnen
- Zeichnung
- Tintexport
- Tintendarstellung
- Tinte ausblenden
- InkOptions
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Tintenobjekte, bearbeiten Sie Spuren und Pinsel‑Eigenschaften und steuern Sie das Erscheinungsbild von Tinte beim Export von PDF, HTML, SVG, TIFF und Bildern mit Aspose.Slides für Node.js über Java."
---
## **Einführung**

PowerPoint bietet eine Tintenfunktion, mit der Sie Freihandstriche zeichnen können. Tinte kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Abläufe darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Aspose.Slides stellt die benötigten Typen zum Arbeiten mit Tintenobjekten bereit. Die Klasse [Ink](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ink/) repräsentiert beispielsweise ein Tintenobjekt auf einer Folie.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint‑Folien werden typischerweise durch Shape‑Objekte (Formen) dargestellt. In seiner einfachsten Form ist eine Shape ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit Eigenschaften wie Containergröße, Form und Hintergrund definiert. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/de/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Tintenobjekt verarbeitet, ignoriert es alle Eigenschaften des Objektrahmens (Containers) mit Ausnahme seiner Größe. Die Größe des Containerbereichs wird durch die Standardmethoden [Shape.getWidth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getWidth--) und [Shape.getHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getHeight--) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tinten‑Spuren**

Ein Tinten‑Trace ist ein Basiselement, das die Bahn eines Stifts aufzeichnet, während ein Benutzer digitale Tinte schreibt. Ein Trace speichert eine Sequenz verbundener Punkte.

Die einfachste Form der Codierung gibt die X‑ und Y‑Koordinaten jedes Stichpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte eines Tinten‑Traces verbinden. Der Pinsel hat seine eigene Farbe und Größe, die durch die Methoden [InkBrush.getColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkbrush/#getColor--) und [InkBrush.getSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkbrush/#getSize--) bereitgestellt werden.

### **Farbe des Ink Brush setzen**

Dieser JavaScript‑Code zeigt, wie die Farbe eines Ink Brush gesetzt wird:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Größe des Ink Brush setzen**

Dieser JavaScript‑Code zeigt, wie die Größe eines Ink Brush gesetzt wird:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der entsprechende Datenabschnitt ist ausgegraut). Stimmen Breite und Höhe überein, zeigt PowerPoint die Größe folgendermaßen an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Tintenobjekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke Null ist (siehe vorheriges Bild).

Daher muss zur Bestimmung des sichtbaren Bereichs des gesamten Tintenobjekts die Pinselgröße seiner Traces berücksichtigt werden. Hier wurde das Zielobjekt (die handschriftliche Textspur) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Steuerung des Ink Appearance During Export and Rendering**

Aspose.Slides stellt die Klasse [InkOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/) zur Verfügung, um zu steuern, wie Tintenobjekte in exportierten oder gerenderten Ausgaben erscheinen. Mit ihren Eigenschaften können Sie Tinte vollständig ausblenden oder festlegen, wie Maskenoperationen von Ink‑Pinseln interpretiert werden.

Ink‑Optionen sind über die Export‑ bzw. Rendering‑Optionen für mehrere Ausgabetypen verfügbar:

| Ausgabe | Ink‑options‑Eigenschaft |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Folien‑Bild | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Die folgenden [InkOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/) Methoden stellen dieselben beiden Einstellungen bereit:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#getHideInk--) bestimmt, ob Tintenobjekte in die Ausgabe einbezogen werden. Der Standardwert ist `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) legt fest, ob eine Maskenoperation beim Rendern eines Ink‑Brush als Opazität interpretiert wird. Der Standardwert ist `true`; rufen Sie [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) mit `false` auf, um stattdessen die ROP‑Operation zu verwenden.

### **Tintenobjekte in PDF‑Ausgabe ausblenden**

Standardmäßig bleiben Tintenobjekte beim Export sichtbar. Um eine saubere Ausgabe ohne handschriftliche Anmerkungen oder andere Tinteninhalte zu erzeugen, rufen Sie [InkOptions.setHideInk](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) mit `true` auf.

Das folgende JavaScript‑Beispiel exportiert eine Präsentation nach PDF und blendet dabei alle Tintenobjekte aus:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Tintenobjekte beim Rendern einer Folie als Bild ausblenden**

Um Tintenobjekte beim Rendern von Folien als Bitmap‑Bilder auszublenden, konfigurieren Sie [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) und übergeben die Rendering‑Optionen an [Slide.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Das folgende JavaScript‑Beispiel rendert die erste Folie als PNG‑Bild ohne Tintenobjekte:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Steuerung des Ink Mask Rendering**

Die Einstellung [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) steuert, wie Maskenoperationen beim Rendern von Ink‑Pinseln interpretiert werden. Der Standardwert ist `true`, wodurch Opazität verwendet wird. Um stattdessen die ROP‑Operation zu nutzen, rufen Sie [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) mit `false` auf.

Das folgende JavaScript‑Beispiel exportiert eine Folie nach SVG und verwendet ROP‑basiertes Rendering für Ink‑Maskenoperationen:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Die gleiche Einstellung kann über [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) angewendet werden, wenn eine Präsentation exportiert oder eine Folie nach TIFF gerendert wird.

### **Auswahl, ob Tinte ausgeblendet oder erhalten bleiben soll**

Wenn Sie für die Verteilung eine saubere Version einer annotierten Präsentation ohne Review‑Markierungen benötigen, rufen Sie während des Exports [InkOptions.setHideInk](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) mit `true` auf.

Lassen Sie [InkOptions.getHideInk](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#getHideInk--) auf seinem Standardwert `false`, wenn Tinten‑Anmerkungen Teil des vorgesehenen Inhalts sind, etwa Review‑Kommentare, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im exportierten Ergebnis sichtbar bleiben sollen. Auf diese Weise können Anwendungen aus derselben Präsentation separate Review‑ und Endausgaben erzeugen, ohne die Quell‑Tintenobjekte zu verändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines bestehenden Tintenstrichs ändern?**

Ja. Rufen Sie den Trace über [Ink.getTraces](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ink/#getTraces--) ab und ändern Sie anschließend dessen [InkTrace.getBrush](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inktrace/#getBrush--). Verwenden Sie [InkBrush.setColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) oder [InkBrush.setSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-), um den Pinsel zu ändern.

**Verändert das Ausblenden von Tinte die Quellpräsentation?**

Nein. Ein Aufruf von [InkOptions.setHideInk](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) wirkt sich nur auf das gerenderte bzw. exportierte Ergebnis aus; er entfernt oder modifiziert keine Tintenobjekte in der Quellpräsentation.

**Welche Exportformate unterstützen Tintenoptionen?**

Sie können Tintenoptionen für PDF, HTML, SVG, TIFF und bitmap‑Foliendarstellungen über die jeweiligen Export‑ bzw. Rendering‑Optionen konfigurieren, die oben gezeigt werden.

**Weiterführende Literatur**

* Um allgemeine Informationen zu Formen zu erhalten, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/de/nodejs-java/powerpoint-shapes/).
* Für weitere Details zu effektiven Werten lesen Sie [Shape Effective Properties](https://docs.aspose.com/slides/de/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Details zum PDF‑Export finden Sie unter [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/de/nodejs-java/convert-powerpoint-to-pdf/).
* Details zum HTML‑Export finden Sie unter [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/de/nodejs-java/convert-powerpoint-to-html/).
* Details zum SVG‑Export finden Sie unter [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/de/nodejs-java/render-a-slide-as-an-svg-image/).
* Details zum TIFF‑Export finden Sie unter [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/de/nodejs-java/convert-powerpoint-to-tiff/).
* Details zum Rendern von Folien zu Bildern finden Sie unter [Convert Presentation Slides to Images](https://docs.aspose.com/slides/de/nodejs-java/convert-slide/).