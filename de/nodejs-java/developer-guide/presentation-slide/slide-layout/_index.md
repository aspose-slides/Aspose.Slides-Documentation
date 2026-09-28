---
title: Folienlayouts in JavaScript anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/nodejs-java/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- nicht verwendetes Layout
- Fußzeilen‑Sichtbarkeit
- Titelfolie
- Titel und Inhalt
- Abschnittsüberschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und vertikaler Text
- Vertikaler Titel und Text
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Folienlayouts in Aspose.Slides für Node.js über Java anwenden, erstellen und ändern, Platzhalter hinzufügen, nicht verwendete Layouts entfernen und die Sichtbarkeit der Fußzeile steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und die Formatierung von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Durch das Anwenden eines Layouts erhalten Folien eine einheitliche Struktur, wobei jede Folie ihren eigenen Inhalt enthalten kann.

Die gängigsten Layouts umfassen:

- **Titelfolie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemeinen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhalts‑Platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layout‑Vererbung**

Eine Präsentation hat drei verwandte Ebenen:

1. A [Masterfolie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [Layoutfolie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [Normale Folie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

Ein normaler Folie erbt Thema und Formatierung von ihrem Layout, und das Layout erbt vom Master. Ein direkt auf einer normalen Folie festgelegter Wert überschreibt den geerbten Wert auf dieser Ebene. Wenn eine normale Folie erstellt wird, werden ihre Platzhalterformen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur normalen Folie gehört.

Fügen Sie einem Layout erforderliche Platzhalter hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalterform zu bereits vorhandenen normalen Folien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern geerbter Formatierung oder vorhandener Platzhaltergeometrie in einem Layout kann jede abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits verwendeten Layouts prüfen Sie dessen abhängige Folien und prüfen die resultierende Präsentation.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur unverwendete Layouts.

Für weitere Informationen zur obersten Ebene dieser Hierarchie siehe [Folienmaster](/slides/de/nodejs-java/slide-master/).

Um geerbte Logos oder dekorative Master‑Formen auf einer Folie oder über ein gemeinsames Layout auszublenden, siehe [Steuerung der Sichtbarkeit von Master‑Grafiken](/slides/de/nodejs-java/slide-master/). Das Beispiel vergleicht zwei Folien, die denselben Master verwenden.

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen [SlideLayoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidelayouttype/)‑Wert, wenn die Präsentation den standardmäßigen PowerPoint‑Layout‑Definitionen folgt. Layout‑Namen sind vom Benutzer editierbar und können lokalisierbar sein, daher ist die Auswahl anhand von Namen weniger zuverlässig, es sei denn, Sie kontrollieren die Quellvorlage.

Das folgende Beispiel sucht nach **Titel und Inhalt** im ersten Master. Ist dieses Layout nicht verfügbar, wird bewusst auf **Leer** zurückgegriffen. Die zweite Null‑Prüfung ist notwendig, weil eine Präsentation nur benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die [Slide.setLayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#setLayoutSlide)‑Methode auf die erste normale Folie angewendet.

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

Das Ändern des Layouts einer Folie entfernt nicht die normalen Formen, die direkt zur Folie hinzugefügt wurden. Platzhalterpositionen, geerbte Formatierung und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout können sich jedoch ändern, sodass das Ergebnis beim Wechsel zwischen deutlich unterschiedlichen Layouts geprüft werden sollte.

## **Hinzufügen einer Layoutfolie**

Auswahl und Erstellung sind getrennte Vorgänge. Das vorherige Beispiel wählt ein vorhandenes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterlayoutslidecollection/#add)‑Methode auf der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Titel und Inhalt**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine normale Folie darauf basierend. Layout‑Namen müssen innerhalb der Sammlung eindeutig sein.

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

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert ein geeignetes Layout bereits, wählen und verwenden Sie es stattdessen, anstatt ein Duplikat zu erstellen.

## **Hinzufügen von Platzhaltern zu einer Layoutfolie**

Die [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager)‑Methode liefert einen [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/) zum Hinzufügen von Platzhalterformen zu einem Layout.

| PowerPoint‑Platzhalter            | `LayoutPlaceholderManager` Method |
| --------------------------------- | --------------------------------- |
| ![Content](content.png)           | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                 | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)     | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)           | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)               | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)               | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)         | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)               | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)  | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Das folgende Beispiel prüft, ob das **Leer**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine normale Folie, die das geänderte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die normale Folie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalterformen auf dieser Folie generieren kann.

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

{{% alert color="warning" title="Warning" %}}
Das Ändern geerbter Formatierung oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bestehende normale Folien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen nicht verwendeter Layoutfolien**

Verwenden Sie die [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑Methode, um Layouts zu entfernen, auf die keine normale Folie verweist. Die Methode lässt Layouts, die noch verwendet werden, unverändert.

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

Um ein bestimmtes Layout zu entfernen, rufen Sie zuerst dessen [hasDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides)‑ oder [getDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getDependingSlides)‑Methode auf. Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [LayoutSlide.remove](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#remove) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Footer‑Sichtbarkeit auf einer Layoutfolie**

Ein Layout besitzt eigene Fußzeilen‑, Folien‑Nummer‑ und Datum‑Zeit‑Platzhalter. Verwenden Sie die [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager)‑Methode, um diese Platzhalter für ein Layout zu steuern. Dies ist nützlich, wenn z. B. Inhalts‑Layouts Fußzeilen zeigen sollen, Titel‑Layouts jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht dessen Fußzeilenelemente sichtbar:

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

## **Steuerung der Footer‑Sichtbarkeit auf einem Master und dessen untergeordneten Layouts**

Um konsistente Fußzeileneinstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager)‑Methode. Die Propagations‑Methoden von [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑ und Normalfolien; sie zielen nicht nur auf eine einzelne normale Folie.

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

Eine Masterfolie definiert das Thema und die geteilte Formatierung der Präsentation. Eine Layoutfolie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normale Folien verwenden diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layoutfolie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der [addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone)‑Methode eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen prüfen Sie zusätzlich Schriftarten, Themen, Bilder und weitere Ressourcen, die das Quell‑Layout nutzt.

**Was passiert, wenn ich ein bereits genutztes Layout ändere?**

Abhängige Folien erben die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschrieben haben. Platzhaltergeometrie und geerbte Stile können deshalb auf vielen Folien gleichzeitig ändern. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getDependingSlides), um die betroffenen Folien vor dem Bearbeiten zu ermitteln.

**Was passiert, wenn ich ein Layout entferne, das noch verwendet wird?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pptxeditexception/). Ordnen Sie zuerst die abhängigen Folien neu zu oder verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), um nur nicht referenzierte Layouts zu entfernen.