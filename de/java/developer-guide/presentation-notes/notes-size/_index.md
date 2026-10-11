---
title: Notizseitengröße und -orientierung in Java ändern
linktitle: Notizseitengröße
type: docs
weight: 10
url: /de/java/notes-size/
keywords:
- Notizseitengröße
- Notizorientierung
- Querformat-Notizen
- Hochformat-Notizen
- Handout-Größe
- PowerPoint
- Präsentation
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Lesen und ändern Sie die Notizseitengrößen in Aspose.Slides für Java, wechseln Sie die Orientierung, überprüfen Sie die gespeicherten Größen und exportieren Sie Notizen oder Handouts zu PDF und Bildern."
---
## **Übersicht**

Verwenden Sie [Presentation.getNotesSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getNotesSize--) , um auf die Notizseiteneinstellungen der Präsentation zuzugreifen. Sie gibt ein [INotesSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/inotessize/) Objekt zurück, dessen [setSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) Methode die Seitenabmessungen festlegt. Obwohl das Einstellungsobjekt selbst nicht ersetzt werden kann, können Sie über diese Methode neue Abmessungen zuweisen.

Breite und Höhe werden in **Punkten** angegeben, wobei 72 Punkte einem Zoll entsprechen. Beispielsweise entsprechen 900 × 600 Punkte 12,5 × 8⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getNotesSize--) | Steuert die Abmessungen der Notizseite und die Seitenabmessungen, die für den Handout-Export verwendet werden. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSlideSize--) | Steuert die Abmessungen der regulären Präsentationsfolien über [ISlideSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/islidesize/). |

Das Ändern einer Einstellung ändert die andere nicht automatisch. Das Ändern der Notizseitenorientierung dreht die regulären Folien ebenfalls nicht. Siehe [Foliengröße](/slides/de/java/slide-size/) um reguläre Folien zu ändern.

Die Beispiele unten verwenden ein vorhandenes `sample.pptx`. Für die Exportbeispiele verwenden Sie eine Präsentation mit mindestens einer Folie, die Sprechernotizen enthält. Jedes Beispiel kann unabhängig ausgeführt werden.

## **Lesen der Notizseitengröße und -orientierung**

Lesen Sie die Breite und Höhe und vergleichen Sie sie, um die Orientierung zu bestimmen: Eine breitere Seite ist im Querformat, eine höhere Seite im Hochformat, und gleiche Abmessungen beschreiben eine quadratische Seite. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standardpapiergröße anzunehmen.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Wechseln Sie zu Querformat, ohne die Papiergröße zu ändern**

Um nur die Orientierung zu ändern, vertauschen Sie die vorhandene Breite und Höhe. Dadurch werden die Längen beider Seiten erhalten, einschließlich jener einer benutzerdefinierten Papiergröße. Die nachstehende Bedingung verhindert, dass eine bereits im Querformat befindliche Seite zurück ins Hochformat wechselt, und lässt eine quadratische Seite unverändert.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für die Hochformat‑Orientierung verwenden Sie die gleiche Zuweisung, wenn `size.getWidth() > size.getHeight()`. Ersetzen Sie nicht A4‑ oder Letter‑Abmessungen, es sei denn, Sie möchten auch die Papiergröße ändern.

## **Festlegen und Überprüfen einer benutzerdefinierten Notizseitengröße**

Weisen Sie beide Abmessungen gleichzeitig zu und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-), um die Präsentation zu schreiben. Dieses Beispiel legt eine 900 × 600‑Punkte‑Querformat‑Seite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die persistierten Werte zu prüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Punkten für Gleitkommawerte; er garantiert nicht die Präzision für jedes Dateiformat.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Das erwartete Ergebnis ist `900.0 x 600.0 points` und `Size preserved: true`. Das Prüfen einer neu geöffneten Präsentation bestätigt die gespeicherte Datei und nicht nur die In‑Memory‑Einstellungen.

## **Exportieren von Notizen und Handouts**

Die Seitenabmessungen bestimmen den verfügbaren Bereich für Notiz‑ oder Handout‑Layouts. Sie aktivieren diese Layouts nicht von selbst: Konfigurieren Sie ebenfalls die Exportoptionen. Der reguläre Folien‑Export verwendet weiterhin die Folienabmessungen.

### **Exportieren von Notizen zu PDF und PNG**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/notescommentslayoutingoptions/) [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) zu, um Notizen in das PDF aufzunehmen. Dieses Beispiel rendert zudem die erste Folie mit Notizen zu PNG mittels [Slide.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) und [RenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/renderingoptions/).

Der Modus [BottomTruncated](https://reference.aspose.com/slides/de/java/com.aspose.slides/notespositions/) hält die Notizen auf einer Seite; nicht passende Notizen können abgeschnitten werden. Das PDF verwendet Seiten von 900 × 600 Punkten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 beträgt das PNG 900 × 600 Pixel. Punkte beschreiben die Seitengeometrie; Pixel beschreiben die Rasterausgabe, deren Abmessungen ebenfalls vom Rendermaßstab abhängen.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Für den PDF‑Export mit langen Notizen ermöglicht [BottomFull](https://reference.aspose.com/slides/de/java/com.aspose.slides/notespositions/) bei Bedarf zusätzliche Seiten. Verwenden Sie diesen Modus nicht mit dem oben gezeigten Einzel‑Folien‑Bildaufruf, da er diesen nicht unterstützt. Nach der Größenänderung prüfen Sie die Ausgabe auf abgeschnittene Notizen und die Platzierung vorhandener Notes‑Master‑Objekte; das alleinige Ändern der Seitenabmessungen ist keine Garantie dafür, dass der gesamte Inhalt passt. Siehe [PowerPoint zu PDF mit Notizen konvertieren](/slides/de/java/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notiz‑Export.

### **Exportieren von Handouts zu PDF**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/handoutlayoutingoptions/) für mehrere Folien‑Thumbnails auf einer Seite. Das folgende Beispiel legt eine 900 × 600‑Punkte‑Seite fest und nutzt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/de/java/com.aspose.slides/handouttype/), um bis zu vier Folien pro Seite anzuordnen. Die horizontale Voreinstellung steuert die Folienreihenfolge; die Seitenorientierung ergibt sich aus ihrer Breite und Höhe.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Die Änderung der Seitengröße ändert den für das Handout‑Raster verfügbaren Bereich, ohne die Abmessungen der Quellfolien zu verändern. Für Handout‑Bilder verwenden Sie [Presentation.getImages](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) mit dem Handout‑Layout, anstatt die Bildmethode einer einzelnen Folie zu nutzen. In Aspose.Slides verwendet das handout‑Rendering auf Präsentationsebene die Notizseitengrößen, während der einzelne Folien‑Bildaufruf nicht die Handout‑Seite erzeugt. Siehe [Handout‑Modus](/slides/de/java/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Betrachtern, Export und Druck**

Bewahren Sie die gespeicherte Präsentationsgröße, die exportierte Seitengröße und die gedruckte Papiergröße getrennt:

- **Presentation viewers:** Ein Betrachter kann Notizen mit eigenen Layout‑Regeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Export formats:** Die oben gezeigten PDF‑Beispiele für Notizen und Handouts verwenden die konfigurierten Seitengrößen. Rasterbilder nutzen ganzzahlige Pixelabmessungen und einen Render‑Maßstab, sodass Bruchteil‑Punkte‑Werte im Bildausgang gerundet werden können. Der Export regulärer Folien wendet die Notizseitengröße nicht an.
- **Printer drivers:** Papierauswahl, automatische Drehung und Fit‑to‑Page‑Einstellungen können das physische Ergebnis ändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu verändern. Für eine bestimmte Papiergröße passen Sie die Druckereinstellungen an und prüfen die Druckvorschau.

## **FAQ**

**Kann ich die Notizgröße nur für eine Folie festlegen?**

Die Notizseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft liefert keine separate Seitengröße pro Folie.

**Warum hat das Ändern der Notizorientierung meine Folien nicht gedreht?**

Notizseiten und reguläre Folien besitzen unabhängige Abmessungen. Verwenden Sie die regulären Folien‑Größeneinstellungen, wenn Sie die Folien selbst skalieren möchten.

**Warum hat mein gespeichertes bzw. gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie die gespeicherte Präsentation erneut und vergleichen Sie deren Notizabmessungen. Wenn diese geändert wurden, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen verändert hat. Wenn nicht, prüfen Sie das Export‑Layout, den Bildmaßstab, die Betrachter‑Einstellungen und die Druckerpapiersauswahl.