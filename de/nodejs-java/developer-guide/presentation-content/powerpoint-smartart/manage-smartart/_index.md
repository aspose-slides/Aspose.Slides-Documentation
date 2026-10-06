---
title: SmartArt in PowerPoint-Präsentationen mit JavaScript verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Node.js PowerPoint‑SmartArt erstellen und bearbeiten, indem Sie klare JavaScript‑Beispielcode verwenden, die das Erstellen von Folien und die Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint-Diagramm, das aus Knoten, Knotformen und einem Layout besteht. Mit Aspose.Slides für Node.js über Java können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, versteckte Knoten untersuchen, Organisationsdiagrammlayouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann eine oder mehrere Formen enthalten. Um Text aus den Knotformen zu lesen, iterieren Sie über [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), dann lesen Sie das [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) , das von [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/) zurückgegeben wird.

Das Beispiel erfordert eine Präsentation mit mindestens einer Folie und einem SmartArt‑Objekt als erste Form auf dieser Folie. Es gibt jeden verfügbaren TextFrame auf der Konsole aus.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Layouttyp eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑Wert, ändert ihn auf den Wert `BasicProcess` und speichert die Präsentation. Die an [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) übergebenen Position und Größe werden in Punkten angegeben. Verwenden Sie [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) , um das Layout zu ändern.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Überprüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑Wert verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des hinzugefügten Knotens. Es gibt eine Meldung aus, wenn der Knoten ausgeblendet ist, und speichert das Diagramm.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is not hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organisationsdiagramm‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisationsdiagramm‑Layout verwenden, definieren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) und [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) , wie untergeordnete Knoten unter einem übergeordneten Knoten angeordnet werden. Sie können beispielsweise untergeordnete Knoten so einstellen, dass sie links, rechts oder an beiden Seiten hängen, je nach dem ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisationsdiagramm und setzt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑Wert. Der nullbasierte Index `0` wählt den ersten obersten Knoten aus; seine untergeordneten Knoten verwenden die gewählte Anordnung. Die geänderte Präsentation wird dann gespeichert.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bild‑Organisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bild‑Platzhaltern entwickelt wurde. Verwenden Sie beim Hinzufügen des SmartArt‑Objekts zu einer Folie den [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑Wert. Dieses Beispiel speichert ein Diagramm mit Bild‑Platzhaltern; es füllt die Platzhalter nicht mit Bildern.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy‑Diagramme in Gruppen von Formen konvertieren**

Bei der Modernisierung einer bestehenden Präsentation müssen Sie möglicherweise ein Organisationsdiagramm aktualisieren, das ursprünglich in PowerPoint 97–2003 erstellt wurde. Aspose.Slides stellt diese Legacy‑Diagramme als [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/)‑Objekte dar. Verwenden Sie [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) , um ein Diagramm in eine Gruppe von Formen zu konvertieren, sodass Sie einzelne visuelle Elemente bearbeiten können. Siehe die [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) für Details.

Die Konvertierung fügt der Formensammlung eine neue Gruppe hinzu, ohne das Originaldiagramm zu entfernen. Nach erfolgreicher Konvertierung entfernen Sie das Original mit [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) , um doppelte Inhalte zu vermeiden. Sammeln Sie die Legacy‑Diagramme zuerst in einer Liste, bevor Sie sie konvertieren, damit das Hinzufügen und Entfernen von Formen die Iteration nicht stört.

Das folgende Beispiel öffnet eine Präsentation, durchsucht jede Folie, konvertiert die Diagramme in Gruppen von Formen und speichert die aktualisierte Präsentation als PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die gespeicherte Präsentation enthält bearbeitbare Gruppen von Formen anstelle der konvertierten Legacy‑Diagramme, wobei keine Originaldiagramme mehr daneben vorhanden sind. Öffnen Sie die PPTX in PowerPoint, um einzelne Elemente innerhalb jeder Gruppe zu bearbeiten, wie Text, Füllung oder Position.

## **FAQ**

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/)‑Methode schaltet die Diagrammrichtung von links nach rechts auf rechts nach links um, oder zurück, wenn das ausgewählte SmartArt‑Layout eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form mit [SmartArt‑Form klonen](/slides/de/nodejs-java/shape-manipulations/) über [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) klonen oder die gesamte Folie, die die SmartArt enthält, mit [gesamte Folie klonen](/slides/de/nodejs-java/clone-slides/) klonen. Beide Ansätze erhalten Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Webexport?**

[Folie rendern](/slides/de/nodejs-java/convert-powerpoint-to-png/) Sie die Folie oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn mehrere vorhanden sind?**

Verwenden Sie [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) oder [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) , um dem SmartArt‑Shape einen eindeutigen Alternativtext oder Namen zuzuweisen, suchen Sie nach diesem Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) , und prüfen Sie dann, ob das gefundene Shape ein [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) ist.