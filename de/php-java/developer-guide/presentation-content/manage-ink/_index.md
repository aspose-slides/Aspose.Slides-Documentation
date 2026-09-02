---
title: Präsentations‑Ink‑Objekte in PHP verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/php-java/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Tinte verwalten
- Tinte zeichnen
- Zeichnen
- Tinte Export
- Tinte Rendering
- Tinte ausblenden
- InkOptions
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Ink‑Objekte, bearbeiten Sie Spuren und Pinsel‑Eigenschaften und steuern Sie das Aussehen von Ink beim Export von PDF, HTML, SVG, TIFF und Bildern mit Aspose.Slides für PHP via Java."
---
## **Einleitung**

PowerPoint bietet eine Ink‑Funktion, mit der Sie Freihand‑Striche zeichnen können. Ink kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Aspose.Slides stellt die Typen bereit, die für die Arbeit mit Ink‑Objekten erforderlich sind. Beispielsweise repräsentiert die [Ink](https://reference.aspose.com/slides/de/php-java/aspose.slides/ink/)‑Klasse ein Ink‑Objekt auf einer Folie.

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/)‑Objekte dargestellt. In seiner einfachsten Form ist ein Shape ein Container, der den Bereich des Objekts selbst (seinen Rahmen) sowie Eigenschaften wie Containergröße, Form und Hintergrund definiert. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/de/php-java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Ink‑Objekt verarbeitet, ignoriert es alle Eigenschaften des Objekt‑Rahmens (Containers) mit Ausnahme seiner Größe. Die Größe des Container‑Bereichs wird durch die Standardmethoden [Shape.getWidth](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getWidth) und [Shape.getHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getHeight) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink‑Spuren**

Eine Ink‑Spur ist ein Basiselement, das die Flugbahn einer Feder aufzeichnet, wenn ein Benutzer digitale Ink schreibt. Eine Spur speichert eine Sequenz verbundener Punkte.

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Abtastpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte einer Ink‑Spur verbinden. Der Pinsel hat seine eigene Farbe und Größe, die durch die Methoden [InkBrush.getColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkbrush/#getColor) und [InkBrush.getSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkbrush/#getSize) angegeben werden.

### **Ink‑Pinselfarbe festlegen**

Dieser PHP‑Code zeigt, wie die Farbe eines Ink‑Pinsels festgelegt wird:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Ink‑Pinselgröße festlegen**

Dieser PHP‑Code zeigt, wie die Größe eines Ink‑Pinsels festgelegt wird:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Im Allgemeinen stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der entsprechende Datenabschnitt ist ausgegraut). Stimmen Breite und Höhe des Pinsels überein, zeigt PowerPoint die Größe folgendermaßen an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke null ist (siehe das vorherige Bild).

Daher muss zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße seiner Spuren berücksichtigt werden. Hier wurde das Zielobjekt (die handschriftliche Textspur) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Steuerung des Ink‑Erscheinungsbildes beim Export und Rendering**

Aspose.Slides stellt die [InkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/)‑Klasse bereit, um zu steuern, wie Ink‑Objekte in exportierten oder gerenderten Ausgaben erscheinen. Mit ihren Eigenschaften können Sie Ink vollständig ausblenden oder festlegen, wie Pinsel‑Masken‑Operationen interpretiert werden.

Ink‑Optionen sind über die Export‑ oder Rendering‑Optionen für mehrere Ausgabetypen verfügbar:

| Ausgabe | Ink‑Optionseigenschaft |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Folien‑Bild | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Die folgenden [InkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/)‑Methoden stellen dieselben beiden Einstellungen bereit:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#getHideInk) bestimmt, ob Ink‑Objekte in die Ausgabe aufgenommen werden. Der Standardwert ist `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) bestimmt, ob eine Masken‑Operation beim Rendering eines Ink‑Pinsels als Opazität interpretiert wird. Der Standardwert ist `true`; rufen Sie [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) mit `false` auf, um stattdessen die ROP‑Operation zu verwenden.

### **Ink‑Objekte in PDF‑Ausgabe ausblenden**

Standardmäßig bleiben Ink‑Objekte beim Export sichtbar. Um eine saubere Ausgabe ohne handschriftliche Anmerkungen oder anderen Ink‑Inhalt zu erstellen, rufen Sie [InkOptions.setHideInk](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#setHideInk) mit `true` auf.

Das folgende PHP‑Beispiel exportiert eine Präsentation nach PDF und blendet dabei alle Ink‑Objekte aus:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Ink‑Objekte beim Rendering einer Folie als Bild ausblenden**

Um Ink‑Objekte beim Rendering von Folien als Bitmap‑Bilder auszublenden, konfigurieren Sie [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/#getInkOptions) und übergeben Sie die Rendering‑Optionen an [Slide.getImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage).

Das folgende PHP‑Beispiel rendert die erste Folie als PNG‑Bild ohne Ink‑Objekte:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Steuerung des Ink‑Masken‑Renderings**

Die Einstellung [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) steuert, wie Masken‑Operationen beim Rendering von Ink‑Pinseln interpretiert werden. Der Standardwert ist `true` (Verwendung von Opazität). Um stattdessen die ROP‑Operation zu nutzen, rufen Sie [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) mit `false` auf.

Das folgende PHP‑Beispiel exportiert eine Folie nach SVG und verwendet ROP‑basiertes Rendering für Ink‑Masken‑Operationen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Die gleiche Einstellung kann über [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/#getInkOptions) angewendet werden, wenn eine Präsentation nach TIFF exportiert oder eine Folie nach TIFF gerendert wird.

### **Auswählen, ob Ink ausgeblendet oder erhalten bleiben soll**

Wenn Sie für die Verteilung eine bereinigte Version einer annotierten Präsentation benötigen, rufen Sie [InkOptions.setHideInk](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#setHideInk) während des Exports mit `true` auf.

Lassen Sie [InkOptions.getHideInk](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#getHideInk) auf seinem Standardwert `false`, wenn Ink‑Anmerkungen Teil des beabsichtigten Inhalts sind, etwa Review‑Kommentare, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im exportierten Ergebnis sichtbar bleiben sollen. Damit können Anwendungen aus derselben Präsentation separate Review‑ und Endausgaben erzeugen, ohne die Quell‑Ink‑Objekte zu ändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines bestehenden Ink‑Strichs ändern?**

Ja. Rufen Sie die Spur über [Ink.getTraces](https://reference.aspose.com/slides/de/php-java/aspose.slides/ink/#getTraces) ab und ändern Sie anschließend ihr [InkTrace.getBrush](https://reference.aspose.com/slides/de/php-java/aspose.slides/inktrace/#getBrush). Verwenden Sie [InkBrush.setColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkbrush/#setColor) oder [InkBrush.setSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkbrush/#setSize), um den Pinsel zu ändern.

**Ändert das Ausblenden von Ink die Quell‑Präsentation?**

Nein. Der Aufruf von [InkOptions.setHideInk](https://reference.aspose.com/slides/de/php-java/aspose.slides/inkoptions/#setHideInk) beeinflusst nur das gerenderte oder exportierte Ergebnis; er entfernt oder ändert keine Ink‑Objekte in der Quell‑Präsentation.

**Welche Exportformate unterstützen Ink‑Optionen?**

Sie können Ink‑Optionen für PDF, HTML, SVG, TIFF und Bitmap‑Folien‑Bilder über die jeweiligen Export‑ bzw. Rendering‑Optionen konfigurieren, die oben aufgeführt sind.

**Weiterführende Literatur**

* Für allgemeine Informationen zu Formen siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/de/php-java/powerpoint-shapes/).
* Für Details zu effektiven Werten siehe [Shape Effective Properties](https://docs.aspose.com/slides/de/php-java/shape-effective-properties/#get-effective-font-height-value).
* Für Informationen zum PDF‑Export siehe [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/de/php-java/convert-powerpoint-to-pdf/).
* Für Informationen zum HTML‑Export siehe [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/de/php-java/convert-powerpoint-to-html/).
* Für Informationen zum SVG‑Export siehe [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/de/php-java/render-a-slide-as-an-svg-image/).
* Für Informationen zum TIFF‑Export siehe [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/de/php-java/convert-powerpoint-to-tiff/).
* Für Details zum Rendering von Folien zu Bildern siehe [Convert Presentation Slides to Images](https://docs.aspose.com/slides/de/php-java/convert-slide/).