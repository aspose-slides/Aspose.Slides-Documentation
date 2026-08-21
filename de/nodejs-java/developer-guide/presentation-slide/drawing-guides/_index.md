---
title: "Zeichnungsführungen in Präsentationen mit JavaScript verwalten"
linktitle: "Zeichnungsführungen"
type: docs
weight: 85
url: /de/nodejs-java/drawing-guides/
keywords:
- Zeichnungsführung
- Horizontale Führung
- Vertikale Führung
- Ausrichtungsführung
- Folienansicht
- Masterfolie
- Layoutfolie
- Notizen-Master
- Handzettel-Master
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Horizontale und vertikale Zeichnungsführungen in PowerPoint-Präsentationen hinzufügen, darauf zugreifen und löschen mit Aspose.Slides für Node.js via Java."
---
## **Übersicht**

Zeichnungsführungen sind einstellbare horizontale und vertikale Linien, die Benutzern helfen, Formen beim Bearbeiten einer Präsentation in PowerPoint konsistent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation erzeugt, die später manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungshilfen speichern, denen Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollten.

Zeichnungsführungen sind Bearbeitungshilfen, kein Folieninhalt. Sie erscheinen nicht in einer Bildschirmpräsentation oder gerenderten Ausgabe. Aspose.Slides für Node.js via Java stellt sie über die Klasse [DrawingGuidesCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguidescollection/) bereit. Eine Führung wird durch [DrawingGuide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguide/) repräsentiert und besitzt eine Ausrichtung, eine Position und eine Farbe.

Die Position wird in Punkten vom linken oberen Eck der jeweiligen Folie oder des Masters gemessen. Eine vertikale Führung verwendet eine horizontale Koordinate, typischerweise zwischen Null und der Folienbreite. Eine horizontale Führung verwendet eine vertikale Koordinate, typischerweise zwischen Null und der Folienhöhe.

## **Zeichnungsführungen zur Folienansicht hinzufügen**

Verwenden Sie [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides), um die während der Bearbeitung normaler Folien angezeigten Führungen zu verwalten. Rufen Sie [DrawingGuidesCollection.add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguidescollection/#add) mit einem [Orientation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/orientation/)-Wert und einer Position in Punkten auf.

Das folgende Beispiel fügt eine vertikale Führung rechts vom Folienmittelpunkt und eine horizontale Führung darunter hinzu:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zeichnungsführungen abrufen**

Die Methoden [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguidescollection/#getCount) und [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) ermöglichen den Zugriff auf vorhandene Führungen. Die Methoden [DrawingGuide.getOrientation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguide/#getPosition) und [DrawingGuide.getColor](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguide/#getColor) geben Werte zurück, die ebenfalls über die entsprechenden Setter‑Methoden geändert werden können.

Das folgende Beispiel liest die Folienansichts‑Führungen aus der oben erstellten Präsentation:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Zeichnungsführungen zu Master- und Layout-Folien hinzufügen**

Ein Folien‑Master und jede seiner Layout‑Folien können eigene Zeichnungs‑Führungs‑Sammlungen besitzen. Verwenden Sie [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) für einen Master‑Slide und [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) für eine Layout‑Folie.

Das folgende Beispiel fügt eine vertikale Führung zur ersten Master‑Folie und eine horizontale Führung zur ersten Layout‑Folie hinzu:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zeichnungsführungen zu Notizen- und Handzettel‑Mastern hinzufügen**

Notizen‑Master und Handzettel‑Master unterstützen ebenfalls Zeichnungsführungen. Verwenden Sie [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) und [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides), um auf deren Sammlungen zuzugreifen. Enthält eine Präsentation keinen dieser Master, erzeugt `MasterNotesSlideManager.setDefaultMasterNotesSlide` bzw. `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` den Standard‑Master und gibt ihn zurück.

Das folgende Beispiel fügt einer Notizen‑Master‑Folien eine horizontale Führung und einer Handzettel‑Master‑Folien eine vertikale Führung hinzu:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zeichnungsführungen löschen**

Rufen Sie [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguidescollection/#clear) auf, um jede Führung aus einer bestimmten Sammlung zu entfernen. Das Leeren einer Sammlung wirkt sich nicht auf Führungen aus, die in einem anderen Geltungsbereich gespeichert sind.

Das folgende Beispiel löscht die Folienansichts‑Führungen sowie alle Führungen auf Folien‑Mastern, Layout‑Folien, dem Notizen‑Master und dem Handzettel‑Master, ohne fehlende Master zu erstellen:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Erscheinen Zeichnungsführungen in einer Bildschirmpräsentation oder exportierten Bildern?**

Nein. Zeichnungsführungen sind Hilfsmittel zur Ausrichtung während der Bearbeitung und werden nicht als Präsentationsinhalt gerendert.

**Kann eine Zeichnungsführung direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Bearbeitungsführungen für Normal‑Folien werden in den Folienansicht‑Eigenschaften der Präsentation gespeichert. Separate Führungs‑Sammlungen stehen für Folien‑Master, Layout‑Folien, Notizen‑Master und Handzettel‑Master zur Verfügung.

**Welche Einheiten werden für Führungspositionen verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Zeichnungsführungen Formen oder ändert den Folieninhalt?**

Nein. Die Methode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/drawingguidescollection/#clear) entfernt nur die Führungen in der ausgewählten Sammlung. Formen und anderer Folieninhalt bleiben unverändert.