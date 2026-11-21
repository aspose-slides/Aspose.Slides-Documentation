---
title: Notizseitengröße und -ausrichtung auf Android ändern
linktitle: Notizseitengröße
type: docs
weight: 10
url: /de/androidjava/notes-size/
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
- Android
- Java
- Aspose.Slides
description: "Lesen und ändern Sie die Notizseitengröße in Aspose.Slides für Android mittels Java, wechseln Sie die Ausrichtung, überprüfen Sie die gespeicherten Größen und exportieren Sie Notizen oder Handouts als PDF und Bilder."
---
## **Übersicht**

Verwenden Sie [Presentation.getNotesSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getNotesSize--) um auf die Notizseiteneinstellungen der Präsentation zuzugreifen. Es gibt ein [INotesSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/inotessize/) Objekt zurück, dessen [setSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) Methode die Seitengröße festlegt. Obwohl das Einstellungsobjekt selbst nicht ersetzt werden kann, können Sie über diese Methode neue Abmessungen zuweisen.

Breite und Höhe werden in **Punkte** angegeben, wobei 72 Punkte pro Zoll entsprechen. Zum Beispiel entsprechen 900 × 600 Punkte 12,5 × 8⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Steuert die Abmessungen der Notizseite und die für den Handout‑Export verwendeten Seitengrößen. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Steuert die regulären Folienabmessungen der Präsentation über [ISlideSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidesize/). |

Das Ändern einer der Einstellungen bewirkt nicht automatisch die Änderung der anderen. Das Ändern der Ausrichtung der Notizseite dreht die regulären Folien ebenfalls nicht. Siehe [Foliengröße](/slides/de/androidjava/slide-size/) um reguläre Folien zu skalieren.

Die nachstehenden Beispiele verwenden eine vorhandene Datei `sample.pptx`. Für die Exportbeispiele benutzen Sie eine Präsentation mit mindestens einer Folie, die Sprecher‑Notizen enthält. Jedes Beispiel kann unabhängig ausgeführt werden.

## **Lesen der Notizseitengröße und -ausrichtung**

Lesen Sie Breite und Höhe und vergleichen Sie sie, um die Ausrichtung zu bestimmen: Eine breitere Seite ist im Querformat, eine höhere Seite im Hochformat, und gleiche Abmessungen beschreiben eine quadratische Seite. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standardpapiergröße anzunehmen.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Auf Querformat umschalten, ohne die Papiergröße zu ändern**

Um nur die Ausrichtung zu ändern, vertauschen Sie die vorhandene Breite und Höhe. Dadurch bleiben die Längen beider Seiten erhalten, einschließlich einer benutzerdefinierten Papiergröße. Die nachstehende Bedingung verhindert, dass eine bereits im Querformat befindliche Seite zurück ins Hochformat gewechselt wird, und lässt eine quadratische Seite unverändert.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für Hochformat verwenden Sie dieselbe Zuweisung, wenn `size.getWidth() > size.getHeight()`. Ersetzen Sie nicht A4‑ oder Letter‑Abmessungen, es sei denn, Sie möchten ebenfalls die Papiergröße ändern.

## **Festlegen und Verifizieren einer benutzerdefinierten Notizseitengröße**

Weisen Sie beide Abmessungen gemeinsam zu und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), um die Präsentation zu speichern. Dieses Beispiel legt eine 900 × 600‑Point‑Querformatseite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die persistierten Werte zu prüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Points für Fließkommawerte; dies garantiert nicht die Präzision für jedes Dateiformat.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Das erwartete Ergebnis ist `900.0 x 600.0 points` und `Size preserved: true`. Das Prüfen einer neu geöffneten Präsentation verifiziert die gespeicherte Datei, nicht nur die Einstellungen im Speicher.

## **Exportieren von Notizen und Handouts**

Die Seitengrößen definieren den verfügbaren Bereich für Notizen‑ oder Handout‑Layouts. Sie aktivieren diese Layouts nicht von selbst: konfigurieren Sie ebenfalls die Exportoptionen. Der Export regulärer Folien verwendet weiterhin die Folienabmessungen.

### **Notizen nach PDF und PNG exportieren**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notescommentslayoutingoptions/) [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) zu, um Notizen in das PDF einzubeziehen. Dieses Beispiel rendert außerdem die erste Folie mit Notizen nach PNG mithilfe von [Slide.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) und [RenderingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/renderingoptions/).

Der Modus [BottomTruncated](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notespositions/) hält die Notizen auf einer Seite; nicht passende Notizen können abgeschnitten werden. Das PDF verwendet 900 × 600‑Point‑Seiten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 hat das PNG 900 × 600 Pixel. Points beschreiben die Seiteng eometrie; Pixel beschreiben die Rasterausgabe, deren Abmessungen ebenfalls vom Rendermaßstab abhängen.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Für den PDF‑Export mit langen Notizen ermöglicht [BottomFull](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notespositions/) bei Bedarf zusätzliche Seiten. Verwenden Sie diesen Modus nicht mit dem oben genannten Einzel‑Folien‑Bildaufruf, der ihn nicht unterstützt. Nach dem Ändern der Größe prüfen Sie die Ausgabe auf abgeschnittene Notizen und die Platzierung vorhandener notes‑master‑Objekte; das alleinige Ändern der Seitengröße sollte nicht als Garantie dafür angesehen werden, dass sämtlicher Inhalt passt. Siehe [Convert PowerPoint to PDF with Notes](/slides/de/androidjava/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notizexport.

### **Handouts nach PDF exportieren**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handoutlayoutingoptions/) für mehrere Folienminiaturbilder auf einer Seite. Das folgende Beispiel legt eine 900 × 600‑Point‑Seite fest und nutzt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handouttype/), um bis zu vier Folien pro Seite anzuordnen. Die horizontale Vorgabe steuert die Folienreihenfolge; die Seitenausrichtung ergibt sich aus ihrer Breite und Höhe.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Das Ändern der Seitengröße ändert den für das Handout‑Raster verfügbaren Bereich, ohne die Abmessungen der Quellfolien zu ändern. Für Handout‑Bilder verwenden Sie [Presentation.getImages](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) mit dem Handout‑Layout, anstatt die Bildmethode einer einzelnen Folie zu nutzen. In Aspose.Slides verwendet das Handout‑Rendering auf Präsentationsebene die Notizseitengrößen, während der Bildaufruf einer einzelnen Folie die Handout‑Seite nicht erzeugt. Siehe [Handout Mode](/slides/de/androidjava/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Betrachtern, Export und Druck**

Bewahren Sie die gespeicherte Präsentationsgröße, die exportierte Seitengröße und die gedruckte Papiergröße getrennt:

- **Präsentationsbetrachter:** Ein Betrachter kann Notizen mit eigenen Layoutregeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen erneut; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Exportformate:** Die oben gezeigten PDF‑Beispiele für Notizen und Handouts verwenden die konfigurierten Seitengrößen. Rasterbilder nutzen ganzzahlige Pixelabmessungen und einen Rendermaßstab, sodass Bruchteil‑Point‑Werte im Bildausgang gerundet werden können. Der Export regulärer Folien wendet die Notizseitengröße nicht an.
- **Druckertreiber:** Die Papierauswahl, automatische Drehung und Fit‑to‑Page‑Einstellungen können die physische Ausgabe ändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu ändern. Für eine bestimmte Papiergröße passen Sie die Druckereinstellungen an und prüfen die Druckvorschau.

## **FAQ**

**Kann ich die Notizgröße nur für eine Folie festlegen?**

Die Notizseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft bietet keine separate Seitengröße für jede Folie.

**Warum hat das Ändern der Notizorientierung meine Folien nicht geändert?**

Notizseiten und reguläre Folien haben unabhängige Abmessungen. Verwenden Sie die Einstellungen für die reguläre Foliengröße, wenn Sie die Folien selbst skalieren möchten.

**Warum hat mein gespeichertes oder gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie zunächst die gespeicherte Präsentation erneut und vergleichen Sie deren Notizabmessungen. Wenn sich diese geändert haben, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen geändert hat. Wenn nicht, überprüfen Sie das Export‑Layout, den Bildmaßstab, die Betrachter‑Einstellungen und die Papierauswahl des Druckers.