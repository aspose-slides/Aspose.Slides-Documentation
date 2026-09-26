---
title: "Notizseitengröße und -orientierung in JavaScript ändern"
linktitle: "Notizseitengröße"
type: docs
weight: 10
url: /de/nodejs-java/notes-size/
keywords:
- Notizseitengröße
- Notizorientierung
- Notizen im Querformat
- Notizen im Hochformat
- Handzettelgröße
- PowerPoint
- Präsentation
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Lesen und Ändern der Notizseitengrößen in Aspose.Slides für Node.js über Java, Orientierung umschalten, gespeicherte Größen überprüfen und Notizen oder Handzettel in PDF und Bilder exportieren."
---
## **Übersicht**

Verwenden Sie [Presentation.getNotesSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getnotessize/), um auf die Notizseiteneinstellungen der Präsentation zuzugreifen. Sie gibt ein [NotesSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notessize/) Objekt zurück, dessen [setSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notessize/setsize/) Methode die Seitengröße festlegt. Obwohl das Einstellungsobjekt selbst nicht ersetzt werden kann, können Sie über diese Methode neue Abmessungen zuweisen.

Breite und Höhe werden in **Punkten** angegeben, wobei 72 Punkte einem Zoll entsprechen. Beispielsweise entsprechen 900 × 600 Punkte 12,5 × 8 ⅓ Zoll. Diese Einstellungen gelten für die gesamte Präsentation und nicht für die Notizen einer einzelnen Folie.

| Einstellung | Zweck |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getnotessize/) | Steuert die Abmessungen der Notizseite und die Seitengröße, die beim Export von Handouts verwendet wird. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getslidesize/) | Steuert die regulären Folienabmessungen der Präsentation über [SlideSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesize/). |

Das Ändern einer der Einstellungen wirkt sich nicht automatisch auf die andere aus. Das Ändern der Orientierung der Notizseite dreht die regulären Folien ebenfalls nicht. Siehe [Slide Size](/slides/de/nodejs-java/slide-size/), um reguläre Folien zu skalieren.

Die nachfolgenden Beispiele verwenden ein vorhandenes `sample.pptx`. Für die Exportbeispiele verwenden Sie eine Präsentation mit mindestens einer Folie, die Sprecher‑Notizen enthält. Jedes Beispiel kann eigenständig ausgeführt werden.

## **Lesen der Notizseitengröße und Orientierung**

Lesen Sie die Breite und Höhe und vergleichen Sie diese, um die Orientierung zu bestimmen: Eine breitere Seite ist im Querformat, eine höhere Seite im Hochformat, und gleiche Abmessungen beschreiben ein quadratisches Blatt. Dieses Beispiel gibt die tatsächlichen Abmessungen in Punkten aus, ohne eine Standardpapiergröße anzunehmen.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Wechsel zu Querformat ohne Änderung der Papiergröße**

Um nur die Orientierung zu ändern, tauschen Sie die vorhandene Breite und Höhe. Dadurch bleiben die Längen beider Seiten erhalten, auch bei einer benutzerdefinierten Papiergröße. Die nachstehende Bedingung verhindert, dass eine bereits im Querformat befindliche Seite zurück ins Hochformat gewechselt wird, und lässt eine quadratische Seite unverändert.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für das Hochformat verwenden Sie dieselbe Zuweisung, wenn `size.getWidth() > size.getHeight()`. Ersetzen Sie A4- oder Letter‑Abmessungen nicht, es sei denn, Sie möchten ebenfalls die Papiergröße ändern.

## **Festlegen und Überprüfen einer benutzerdefinierten Notizseitengröße**

Weisen Sie beide Abmessungen zusammen zu und verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/save/), um die Präsentation zu speichern. Dieses Beispiel legt eine 900 × 600‑Punkte‑Querformatseite fest, speichert sie als PPTX und öffnet die gespeicherte Datei erneut, um die gespeicherten Werte zu prüfen. Der Vergleich erlaubt eine Toleranz von 0,01 Punkten für Fließkommawerte; er ist keine Garantie für Präzision bei jedem Dateiformat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Das erwartete Ergebnis ist `900 x 600 points` und `Size preserved: true`. Das Überprüfen einer neu geöffneten Präsentation verifiziert die gespeicherte Datei und nicht nur die In‑Memory‑Einstellungen.

## **Exportieren von Notizen und Handzetteln**

Die Seitengrößen definieren den verfügbaren Bereich für Notizen‑ oder Handzettel‑Layouts. Sie aktivieren diese Layouts nicht von themselves aus; konfigurieren Sie auch die Exportoptionen. Der reguläre Folien‑Export verwendet weiterhin die Folienabmessungen.

### **Exportieren von Notizen zu PDF und PNG**

Weisen Sie [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notescommentslayoutingoptions/) [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) zu, um Notizen in das PDF einzubeziehen. Dieses Beispiel rendert zudem die erste Folie mit Notizen als PNG mithilfe von [Slide.getImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) und [RenderingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/).

Der Modus [BottomTruncated](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notespositions/) hält die Notizen auf einer Seite; Notizen, die nicht passen, können abgeschnitten werden. Das PDF verwendet Seiten mit 900 × 600 Punkten. Bei dem unten verwendeten Bildmaßstab von 1 × 1 beträgt das PNG 900 × 600 Pixel. Punkte beschreiben die Seitengeometrie; Pixel beschreiben das Rasterausgabe, deren Abmessungen ebenfalls vom Rendermaßstab abhängen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Für den PDF‑Export mit langen Notizen ermöglicht [BottomFull](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notespositions/) bei Bedarf zusätzliche Seiten. Verwenden Sie diesen Modus nicht mit dem oben genannten Einzel‑Folien‑Bildaufruf, da dieser ihn nicht unterstützt. Nach der Größenänderung prüfen Sie die Ausgabe auf abgeschnittene Notizen und die Platzierung vorhandener notes‑master‑Objekte; die reine Änderung der Seitengröße sollte nicht als Garantie dafür angesehen werden, dass sämtlicher Inhalt passt. Siehe [Convert PowerPoint to PDF with Notes](/slides/de/nodejs-java/convert-powerpoint-to-pdf-with-notes/) für weitere Informationen zum Notiz‑Export.

### **Exportieren von Handzetteln zu PDF**

Verwenden Sie [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handoutlayoutingoptions/) für mehrere Folien‑Thumbnails auf einer Seite. Das folgende Beispiel legt eine 900 × 600‑Punkte‑Seite fest und nutzt [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handouttype/), um bis zu vier Folien pro Seite anzuordnen. Die horizontale Vorgabe steuert die Folienreihenfolge; die Seitenausrichtung ergibt sich aus ihrer Breite und Höhe.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Durch Ändern der Seitengröße wird der für das Handzettel‑Raster verfügbare Bereich geändert, ohne die Abmessungen der Quellfolien zu verändern. Für Handzettel‑Bilder verwenden Sie [Presentation.getImages](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/getimages/) mit dem Handzettel‑Layout, anstatt die Bildmethode einer einzelnen Folie zu nutzen. In Aspose.Slides verwendet das Handzettel‑Rendering auf Präsentationsebene die Notizseitengrößen, während der einzelne Folien‑Bildaufruf keine Handzettel‑Seite erzeugt. Siehe [Handout Mode](/slides/de/nodejs-java/convert-powerpoint-in-handout-mode/) für Layout‑Optionen.

## **Seitengröße in Betrachtern, Export und Druck**

Bewahren Sie die gespeicherte Präsentationsgröße, die exportierte Seitengröße und die gedruckte Papiergröße getrennt:

- **Präsentationsbetrachter:** Ein Betrachter kann Notizen mit eigenen Layoutregeln anzeigen oder drucken. Wenn eine andere Anwendung die Datei speichert, öffnen Sie sie erneut und prüfen Sie die Abmessungen; die Formatkonvertierung dieser Anwendung kann sie normalisieren.
- **Exportformate:** Die oben genannten PDF‑Beispiele für Notizen und Handzettel verwenden die konfigurierten Seitengrößen. Rasterbilder nutzen ganzzahlige Pixelabmessungen und einen Rendermaßstab, sodass Bruchteil‑Punkte‑Werte im Bildausgabe gerundet werden können. Der Export regulärer Folien berücksichtigt die Notizseitengröße nicht.
- **Druckertreiber:** Die Papierauswahl, automatische Drehung und Einstellungen zum Anpassen an die Seite können die physische Ausgabe ändern, ohne die in der Präsentation oder im PDF gespeicherten Abmessungen zu verändern. Für eine bestimmte Papiergröße passen Sie die Druckereinstellungen an und prüfen Sie die Druckvorschau.

## **FAQ**

**Kann ich die Notizgröße nur für eine Folie festlegen?**

Die Notizseitengröße ist eine Einstellung auf Präsentationsebene. Einzelne Folien können unterschiedliche Notizinhalte haben, aber diese Eigenschaft stellt keine separate Seitengröße für jede Folie bereit.

**Warum hat das Ändern der Notizorientierung meine Folien nicht geändert?**

Notizseiten und reguläre Folien haben unabhängige Abmessungen. Verwenden Sie die Einstellungen für die reguläre Foliengröße, wenn Sie die Folien selbst skalieren möchten.

**Warum hat mein gespeichertes oder gedrucktes Ergebnis eine andere Größe?**

Öffnen Sie zunächst die gespeicherte Präsentation erneut und vergleichen Sie deren Notizabmessungen. Wenn diese sich geändert haben, prüfen Sie, ob das Speichern oder Konvertieren der Datei in einer anderen Anwendung die Seiteneinstellungen geändert hat. Wenn nicht, überprüfen Sie das Export‑Layout, den Bildmaßstab, die Betrachter‑Einstellungen und die Drucker‑Papierauswahl.