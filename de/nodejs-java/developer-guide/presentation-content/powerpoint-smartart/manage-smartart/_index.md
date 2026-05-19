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
- Ausgeblendete Eigenschaft
- Organigramm
- Bild-Organigramm
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Node.js erstellen und bearbeiten, anhand klarer JavaScript‑Beispielcodes, die das Foliendesign und die Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotformen und einem Layout besteht. Mit Aspose.Slides für Node.js über Java können Sie SmartArt erstellen, Text aus dessen Knoten lesen, das Layout ändern, ausgeblendete Knoten untersuchen, Organigramm‑Layouts konfigurieren und Bild‑Organigramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Shapes enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [SmartArt.getAllNodes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartart/#getAllNodes--), und lesen dann das von [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) zurückgegebene [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/).

```javascript
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
    }
} finally {
    presentation.dispose();
}
```

## **Layouttyp eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`‑Wert, ändert ihn zu dem Wert `BasicProcess` und speichert die Präsentation.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Überprüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartnode/ishidden/) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur vorhanden sein, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle`‑Wert verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des Knotens.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organigramm-Layout abrufen oder festlegen**

Bei SmartArt‑Diagrammen, die ein Organigramm‑Layout verwenden, definieren [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) und [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-), wie untergeordnete Knoten unter einem übergeordneten Knoten angeordnet werden. Zum Beispiel können Sie untergeordnete Knoten am linken, rechten oder an beiden Seiten hängen lassen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organigramm und legt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`‑Wert fest.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bild-Organigramm erstellen**

Ein Bild‑Organigramm ist ein SmartArt‑Layout, das für Hierarchie‑Diagramme mit Bild‑Platzhaltern entwickelt wurde. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`‑Wert, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die Methode [SmartArt.setReversed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartart/setreversed/) ändert die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links bzw. zurück, wenn das ausgewählte SmartArt‑Layout die Umkehrung unterstützt.

**Wie kann ich SmartArt auf dieselbe Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können das SmartArt‑Shape mit [clone the SmartArt shape](/slides/de/nodejs-java/shape-manipulations/) durch [ShapeCollection.addClone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/addclone/) klonen oder die gesamte Folie, die die SmartArt enthält, mit [clone the whole slide](/slides/de/nodejs-java/clone-slides/) duplizieren. Beide Verfahren erhalten Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

Rendern Sie die Folie mit [Render the slide](/slides/de/nodejs-java/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt‑Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**

Legen Sie einen eindeutigen [Shape.setAlternativeText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/setalternativetext/) oder [Shape.setName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/setname/) Wert auf der SmartArt‑Form fest, suchen Sie diesen Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getShapes) und prüfen Sie anschließend, ob das gefundene Shape ein [SmartArt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartart/) ist.