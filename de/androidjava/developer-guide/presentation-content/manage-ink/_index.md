---
title: Verwalten von Präsentations‑Tintenobjekten auf Android
linktitle: Tinte verwalten
type: docs
weight: 95
url: /de/androidjava/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenverlauf
- Tinte verwalten
- Tinte zeichnen
- Zeichnung
- Tintenexport
- Tintenrendering
- Tinte ausblenden
- IInkOptions
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Tintenobjekte, bearbeiten Sie Verläufe und Pinsel‑Eigenschaften und steuern Sie das Aussehen von Tinte beim Export von PDF, HTML, SVG, TIFF und Bildern mit Aspose.Slides für Android."
---
## **Einleitung**

PowerPoint bietet eine Tintenfunktion, mit der Sie Freihandlinien zeichnen können. Tinte kann verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse zu zeigen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Aspose.Slides stellt die Typen bereit, die zum Arbeiten mit Tintenobjekten benötigt werden. Das [IInk](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iink/)‑Interface stellt beispielsweise ein Tintenobjekt auf einer Folie dar.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint‑Folien werden typischerweise durch Shape‑Objekte dargestellt. In seiner einfachsten Form ist ein Shape ein Container, der den Bereich des eigentlichen Objekts (seinen Rahmen) zusammen mit Eigenschaften wie Containergröße, Form und Hintergrund definiert. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/de/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Tintenobjekt verarbeitet, ignoriert es alle Eigenschaften des Objekt‑Rahmens (Containers) außer seiner Größe. Die Größe des Container‑Bereichs wird durch die Standardmethoden [IShape.getWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getWidth--) und [IShape.getHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getHeight--) bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintenverläufe**

Ein Tintenverlauf ist ein Basiselement, das die Bahn eines Stifts aufzeichnet, während ein Benutzer digitale Tinte schreibt. Ein Verlauf speichert eine Sequenz zusammenhängender Punkte.

Die einfachste Form der Codierung gibt die X‑ und Y‑Koordinaten jedes Abtastpunkts an. Werden alle verbundenen Punkte gerendert, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Ein Pinsel wird verwendet, um Linien zu zeichnen, die die Punkte eines Tintenverlaufs verbinden. Der Pinsel verfügt über eine eigene Farbe und Größe, die durch die Methoden [IInkBrush.getColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkbrush/#getColor--) und [IInkBrush.getSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkbrush/#getSize--) bereitgestellt werden.

### **Farbe des Tintenpinsels festlegen**

Dieser Java‑Code zeigt, wie die Farbe eines Tintenpinsels festgelegt wird:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **Größe des Tintenpinsels festlegen**

Dieser Java‑Code zeigt, wie die Größe eines Tintenpinsels festgelegt wird:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der entsprechende Datenbereich ist ausgegraut). Stimmen Breite und Höhe überein, zeigt PowerPoint die Größe folgendermaßen an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Veranschaulichung erhöhen wir die Höhe des Tintenobjekts und betrachten die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke null ist (siehe das vorherige Bild).

Daher muss zur Bestimmung des sichtbaren Bereichs des gesamten Tintenobjekts die Pinselgröße seiner Verläufe berücksichtigt werden. Hier wurde das Zielobjekt (der handschriftliche Textverlauf) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint verwendet ein ähnliches Verhalten für Textobjekte:

![ink_powerpoint6](ink_powerpoint6.png)

## **Darstellung von Tinte beim Export und Rendering steuern**

Aspose.Slides stellt das [IInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/)‑Interface bereit, um zu kontrollieren, wie Tintenobjekte in exportierten oder gerenderten Ausgaben erscheinen. Mit dessen Eigenschaften können Sie Tinte vollständig ausblenden oder ändern, wie Pinsel‑Masken‑Operationen interpretiert werden.

Tintenoptionen stehen über die Export‑ bzw. Rendering‑Optionen für mehrere Ausgabeformate zur Verfügung:

| Ausgabe | Eigenschaft der Tintenoptionen |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Folien‑Bild | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Die folgenden [IInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/)‑Methoden stellen dieselben beiden Einstellungen bereit:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) bestimmt, ob Tintenobjekte in die Ausgabe einbezogen werden. Der Standardwert ist `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bestimmt, ob eine Masken‑Operation beim Rendern eines Tintenpinsels als Opazität interpretiert wird. Der Standardwert ist `true`; rufen Sie [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) mit `false` auf, um stattdessen die ROP‑Operation zu verwenden.

### **Tintenobjekte in PDF‑Ausgabe ausblenden**

Standardmäßig bleiben Tintenobjekte beim Export sichtbar. Um eine saubere Ausgabe ohne handschriftliche Anmerkungen oder andere Tinteninhalte zu erzeugen, rufen Sie [IInkOptions.setHideInk](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) mit `true` auf.

Das folgende Java‑Beispiel exportiert eine Präsentation nach PDF und blendet dabei alle Tintenobjekte aus:

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

### **Tintenobjekte beim Rendering einer Folie als Bild ausblenden**

Um Tintenobjekte beim Rendern von Folien als Bitmap‑Bilder auszublenden, konfigurieren Sie [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) und übergeben Sie die Rendering‑Optionen an [ISlide.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Das folgende Java‑Beispiel rendert die erste Folie als PNG‑Bild ohne Tintenobjekte:

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

### **Masken‑Rendering für Tinte steuern**

Die Einstellung [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) legt fest, wie Masken‑Operationen beim Rendern von Tintenpinseln interpretiert werden. Der Standardwert ist `true`, wodurch Opazität verwendet wird. Um stattdessen die ROP‑Operation zu nutzen, rufen Sie [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) mit `false` auf.

Das folgende Java‑Beispiel exportiert eine Folie nach SVG und verwendet ROP‑basiertes Rendering für Tintenmasken‑Operationen:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Die gleiche Einstellung kann über [TiffOptions.getInkOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) beim Export einer Präsentation oder beim Rendern einer Folie nach TIFF angewendet werden.

### **Auswählen, ob Tinte ausgeblendet oder erhalten bleiben soll**

Wenn Sie eine bereinigte Version einer annotierten Präsentation für die Verteilung ohne Review‑Markierungen benötigen, rufen Sie [IInkOptions.setHideInk](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) mit `true` während des Exports auf.

Lassen Sie [IInkOptions.getHideInk](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) auf seinem Standardwert `false`, wenn Tintenantworten Teil des beabsichtigten Inhalts sind, z. B. Review‑Kommentare, handschriftliche Notizen, Hervorhebungen oder Zeichnungen, die im exportierten Ergebnis sichtbar bleiben sollen. Dadurch können Anwendungen separate Review‑ und Endausgaben aus derselben Präsentation erzeugen, ohne die Quell‑Tintenobjekte zu ändern.

## **FAQ**

**Kann ich die Farbe oder Größe eines vorhandenen Tintenstrichs ändern?**

Ja. Rufen Sie den Verlauf über [IInk.getTraces](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iink/#getTraces--) ab und ändern Sie anschließend dessen [IInkTrace.getBrush](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinktrace/#getBrush--). Verwenden Sie [IInkBrush.setColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) oder [IInkBrush.setSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-), um den Pinsel zu ändern.

**Verändert das Ausblenden von Tinte die Quell‑Präsentation?**

Nein. Der Aufruf von [IInkOptions.setHideInk](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) wirkt sich nur auf das gerenderte oder exportierte Ergebnis aus; er entfernt oder ändert keine Tintenobjekte in der Quell‑Präsentation.

**Welche Exportformate unterstützen Tintenoptionen?**

Sie können Tintenoptionen für PDF, HTML, SVG, TIFF und bitmap‑Folien‑Bilder über die entsprechenden Export‑ bzw. Rendering‑Optionen konfigurieren, die oben aufgeführt sind.

**Weiterführende Literatur**

* Um allgemeine Informationen zu Shapes zu erhalten, lesen Sie den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/de/androidjava/powerpoint-shapes/).
* Für weitere Details zu effektiven Werten siehe [Shape Effective Properties](https://docs.aspose.com/slides/de/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Details zum PDF‑Export finden Sie unter [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/de/androidjava/convert-powerpoint-to-pdf/).
* Details zum HTML‑Export finden Sie unter [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/de/androidjava/convert-powerpoint-to-html/).
* Details zum SVG‑Export finden Sie unter [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/de/androidjava/render-a-slide-as-an-svg-image/).
* Details zum TIFF‑Export finden Sie unter [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/de/androidjava/convert-powerpoint-to-tiff/).
* Details zum Rendering von Folien zu Bildern finden Sie unter [Convert Presentation Slides to Images](https://docs.aspose.com/slides/de/androidjava/convert-slide/).