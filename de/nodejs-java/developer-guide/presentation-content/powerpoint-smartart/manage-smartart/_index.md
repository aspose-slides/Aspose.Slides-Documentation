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
- versteckte Eigenschaft
- Organigramm
- Bild-Organigramm
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Node.js SmartArt in PowerPoint erstellen und bearbeiten, anhand klarer JavaScript‑Codebeispiele, die das Entwerfen von Folien und die Automatisierung beschleunigen."
---

## **Text aus SmartArt abrufen**
Die TextFrame‑Methode wurde jetzt zur Klasse [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) und zur Klasse [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) zu erhalten, wenn dieser nicht nur Knotentext enthält. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
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
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) zu ändern, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Holen Sie sich die Referenz einer Folie über deren Index.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX‑Datei.
Im unten angegebenen Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // LayoutType zu BasicProcess ändern
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // Präsentation speichern
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Sichtbarkeits‑Eigenschaft von SmartArt prüfen**
Bitte beachten Sie: Die Methode [SmartArtNode.isHidden()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) gibt true zurück, wenn dieser Knoten ein ausgeblendeter Knoten im Datenmodell ist. Um die ausgeblendete Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) zu prüfen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die [visibility](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/)‑Eigenschaft.
- Schreiben Sie die Präsentation als PPTX‑Datei.
Im unten angegebenen Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
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


## **Organisation‑Diagrammtyp abrufen oder festlegen**
Die Methoden [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) und [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen oder Festlegen des Organisation‑Diagrammtyps, der dem aktuellen Knoten zugeordnet ist. Um den Organisation‑Diagrammtyp zu erhalten oder zu setzen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) zur Folie hinzu.
- Rufen Sie den Organisation‑Diagrammtyp ab oder [setzen Sie ihn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX‑Datei.
Im unten angegebenen Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Organisationsdiagrammtyp abrufen oder festlegen
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // Präsentation speichern
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Bild‑Organisation‑Diagramm erstellen**
Aspose.Slides für Node.js via Java bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen auf einfache Weise. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
4. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

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
Um den Zustand eines SmartArt‑Diagramms zu ändern, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
2. Fügen Sie [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) zur Folie hinzu.
3. [Abrufen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) oder [Setzen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) Sie den Zustand des SmartArt‑Diagramms.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```javascript
// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // Den Zustand des SmartArt-Diagramms abrufen oder festlegen
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

**Unterstützt SmartArt das Spiegeln/Umkehren für RTL‑Sprachen?**

Ja. Die Methode [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) wechselt die Diagramm‑Richtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Formen‑Sammlung ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) duplizieren oder die gesamte Folie, die diese Form enthält, klonen. Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendern ich SmartArt zu einem Raster‑Bild für eine Vorschau oder den Web‑Export?**

Rendern Sie die Folie (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder umwandelt – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Vorgehensweise ist die Verwendung von [alternativem Text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt‑Text) oder [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) und die Suche nach der Form über [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), dann den Typ prüfen, um sicherzustellen, dass es sich um ein [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Auffinden und Arbeiten mit Formen.