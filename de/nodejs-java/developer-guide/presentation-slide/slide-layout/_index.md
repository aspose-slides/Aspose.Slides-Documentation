---
title: Slide-Layouts in JavaScript anwenden oder ändern
linktitle: Slide-Layout
type: docs
weight: 60
url: /de/nodejs-java/slide-layout/
keywords:
- Slide-Layout
- Inhalts-Layout
- Platzhalter
- Präsentationsdesign
- Folienlayout
- Unbenutztes Layout
- Fußzeilen-Sichtbarkeit
- Titelfolie
- Titel und Inhalt
- Abschnittsüberschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und Vertikaler Text
- Vertikaler Titel und Text
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Slide-Layouts in Aspose.Slides für Node.js über Java anwenden, erstellen und ändern, Platzhalter hinzufügen, unbenutzte Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und Formatierungen von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die gebräuchlichsten Layouts sind:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemeinen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhaltsplatzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layout‑Vererbung**

Eine Präsentation hat drei verwandte Ebenen:

1. Eine [Masterfolie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) definiert das Design, die gemeinsam genutzte Formatierung, Hintergründe und gemeinsame Objekte.
1. Eine [Layoutfolie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [Normalfolie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine Normalfolie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom Master. Ein direkt auf einer Normalfolie gesetzter Wert überschreibt den geerbten Wert auf dieser Ebene. Beim Erstellen einer Normalfolie werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur Normalfolie gehört.

Fügen Sie erforderliche Platzhalter einem Layout hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch eine entsprechende Platzhalterform zu bereits vorhandenen Normalfolien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern der geerbten Formatierung oder der vorhandenen Platzhaltergeometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits verwendeten Layouts sollten Sie dessen abhängige Folien prüfen und die resultierende Präsentation überprüfen.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zunächst einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Folienmaster](/slides/de/nodejs-java/slide-master/).

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen [SlideLayoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidelayouttype/)‑Wert, wenn die Präsentation den standardmäßigen PowerPoint‑Layout‑Definitionen folgt. Layout‑Namen sind vom Benutzer editierbar und können lokalisiert werden, sodass die Auswahl basierend auf Namen weniger zuverlässig ist, es sei denn, Sie kontrollieren die Ausgangsvorlage.

Das folgende Beispiel sucht **Titel und Inhalt** im ersten Master. Ist dieses Layout nicht verfügbar, wird bewusst auf **Leer** zurückgegriffen. Die zweite Null‑Prüfung ist nötig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die [Slide.setLayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#setLayoutSlide)‑Methode auf die erste Normalfolie angewendet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ändern des Layouts einer Folie entfernt nicht die normalen Formen, die direkt zur Folie hinzugefügt wurden. Platzhalterpositionen, geerbte Formatierung und die Zuordnung zwischen bestehenden Platzhaltern und dem neuen Layout können sich jedoch ändern, sodass das Ergebnis beim Wechsel zwischen stark unterschiedlichen Layouts geprüft werden sollte.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind getrennte Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterlayoutslidecollection/#add)‑Methode auf der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und legt anschließend eine Normalfolie darauf an. Layout‑Namen müssen innerhalb der Sammlung eindeutig sein.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage wirklich eine weitere wiederverwendbare Struktur benötigt. Existiert ein geeignetes Layout bereits, wählen Sie es aus und verwenden Sie es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layoutfolie hinzufügen**

Die [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager)‑Methode liefert einen [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout.

| PowerPoint‑Platzhalter               | LayoutPlaceholderManager‑Methode |
| ------------------------------------ | --------------------------------- |
| ![Inhalt](content.png)               | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhalt (Vertikal)](contentV.png)   | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                    | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertikal)](textV.png)        | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Bild](picture.png)                 | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagramm](chart.png)               | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabelle](table.png)                | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)            | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medium](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑Bild](onlineImage.png)      | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout existiert, fügt vier Platzhalter hinzu und erstellt anschließend eine Normalfolie, die das geänderte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die Normalfolie erzeugt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie erzeugen kann.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Platzhalter auf der Layoutfolie](add_placeholders.png)

{{% alert color="warning" title="Warnung" %}}
Das Ändern geerbter Formatierung oder der Geometrie bestehender Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bereits vorhandene Normalfolien übernommen. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Unbenutzte Layoutfolien entfernen**

Verwenden Sie die [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑Methode, um Layouts zu entfernen, auf die keine Normalfolie verweist. Layouts, die noch verwendet werden, bleiben unverändert.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um ein bestimmtes Layout zu entfernen, nutzen Sie zuerst dessen [hasDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides)‑ oder [getDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getDependingSlides)‑Methode. Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [LayoutSlide.remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#remove) aufrufen. Der Versuch, ein noch verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑Nummer‑ und Datums‑Zeit‑Platzhalter. Verwenden Sie die [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager)‑Methode, um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn z. B. Inhalts‑Layouts Fußzeilen anzeigen sollen, Titel‑Layouts jedoch nicht.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und dessen untergeordneten Layouts**

Um konsistente Fußzeilen‑Einstellungen über eine Master‑Hierarchie hinweg anzuwenden, nutzen Sie die [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager)‑Methode. Die Propagations‑Methoden von [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normalfolien; sie richten sich nicht nur an eine einzelne Normalfolie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das Design und die gemeinsam genutzte Formatierung der gesamten Präsentation. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normalfolien verwenden diese Layouts und speichern den folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie eine Kopie zur Ziel‑Sammlung mit der [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone)‑Methode hinzu. Beim Kopieren zwischen Präsentationen sollten Sie zudem Schriftarten, Designs, Bilder und weitere Ressourcen des Quell‑Layouts prüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien erben die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschrieben haben. Platzhaltergeometrie und vererbtes Styling können daher auf vielen Folien gleichzeitig geändert werden. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getDependingSlides), um die betroffenen Folien vor dem Bearbeiten des Layouts zu identifizieren.

**Was passiert, wenn ich ein Layout entferne, das noch verwendet wird?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/). Ordnen Sie die abhängigen Folien zuvor neu zu, oder nutzen Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), um nur nicht referenzierte Layouts zu entfernen.