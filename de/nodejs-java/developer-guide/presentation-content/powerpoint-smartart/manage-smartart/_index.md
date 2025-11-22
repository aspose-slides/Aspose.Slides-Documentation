---
title: SmartArt verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-smartart/
---

## **Text aus SmartArt abrufen**
Die TextFrame‑Methode wurde jetzt zur Klasse [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) und zur Klasse [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) abzurufen, falls dieser nicht nur Knotentexte enthält. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Layouttyp von SmartArt ändern**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Holen Sie sich die Referenz einer Folie über deren Index.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // LayoutTyp zu BasicProcess ändern
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // Präsentation speichern
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Überprüfen der versteckten Eigenschaft von SmartArt**
Bitte beachten Sie: Die Methode [SmartArtNode.isHidden()]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)) gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) zu überprüfen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die [isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)‑Eigenschaft.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // Knoten zu SmartArt hinzufügen
    var node = smart.getAllNodes().addNode();
    // isHidden-Eigenschaft prüfen
    var hidden = node.isHidden();// Gibt true zurück
    if (hidden) {
        // Einige Aktionen oder Benachrichtigungen ausführen
    }
    // Präsentation speichern
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Organisationstyp abrufen oder festlegen**
Die Methoden [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) und [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen oder Festlegen des Organisationstyp‑Layouts, das dem aktuellen Knoten zugeordnet ist. Um den Organisationstyp abzurufen oder festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
- Abrufen oder [den Organisationstyp festlegen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Organisationstyp abrufen oder festlegen
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // Präsentation speichern
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Bild-Organisationsdiagramm erstellen**
Aspose.Slides für Node.js via Java bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen auf einfache Weise. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt‑Zustand abrufen oder festlegen**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) zur Folie hinzu.
1. Rufen Sie den Zustand des SmartArt‑Diagramms ab oder legen Sie ihn fest.
1. Schreiben Sie die Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```javascript
// Instanziiere die Presentation-Klasse, die die PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // Zustand des SmartArt-Diagramms abrufen oder festlegen
    smart.setReversed(true);
    var flag = smart.isReversed();
    // Präsentation speichern
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umdrehen für RTL‑Sprachen?**

Ja. Die Methode [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) wechselt die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ das Umdrehen unterstützt.

**Wie kann ich SmartArt in derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form [clone the SmartArt shape](/slides/de/nodejs-java/shape-manipulations/) über die Formen‑Sammlung ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) oder die gesamte Folie [clone the entire slide](/slides/de/nodejs-java/clone-slides/) klonen, die diese Form enthält. Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**

[Render the slide](/slides/de/nodejs-java/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis besteht darin, [alternative text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt‑Text) oder [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) zu verwenden und die Form über [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) nach diesem Attribut zu suchen, dann den Typ zu prüfen, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.