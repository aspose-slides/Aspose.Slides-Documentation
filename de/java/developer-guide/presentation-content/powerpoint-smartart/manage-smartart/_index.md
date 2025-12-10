---
title: SmartArt in PowerPoint-Präsentationen mit Java verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/java/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides for Java erstellen und bearbeiten, indem Sie klare Code‑Beispiele verwenden, die das Entwerfen und Automatisieren von Folien beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Die TextFrame‑Methode wurde jetzt zur [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape)-Schnittstelle und zur [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape)-Klasse hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus einem [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) abzurufen, wenn nicht nur Knotentexte vorhanden sind. Der folgende Beispielcode hilft, den Text aus einem SmartArt‑Knoten zu erhalten.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Layouttyp eines SmartArt-Objekts ändern**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu ändern, folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
- Rufen Sie die Referenz einer Folie über ihren Index ab.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX‑Datei. Im untenstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutTyp zu BasicProcess ändern
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Präsentation speichern
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Überprüfen der Hidden‑Eigenschaft eines SmartArt-Objekts**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)) gibt **true** zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die Hidden‑Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu prüfen, folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)‑Eigenschaft.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im untenstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Knoten zu SmartArt hinzufügen 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Check isHidden property
    boolean hidden = node.isHidden(); // Gibt true zurück

    if (hidden)
    {
        // Einige Aktionen oder Benachrichtigungen ausführen
    }
    // Präsentation speichern
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Organisation‑Diagrammtyp abrufen oder festlegen**
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) und [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen bzw. Festlegen des Organisation‑Diagrammtyps, der dem aktuellen Knoten zugeordnet ist. Um den Organisation‑Diagrammtyp abzurufen oder festzulegen, folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
- Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf einer Folie hinzu.
- Rufen Sie den Organisation‑Diagrammtyp ab oder [setzen Sie den Organisation‑Diagrammtyp](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX‑Datei. Im untenstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Organisationsdiagrammtyp abrufen oder festlegen
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Präsentation speichern
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Picture‑Organization‑Diagramm erstellen**
Aspose.Slides for Java bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Rufen Sie die Referenz einer Folie über ihren Index ab.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt‑Zustand abrufen oder festlegen**
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu ändern, folgen Sie den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Fügen Sie [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf einer Folie hinzu.
1. [Get](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) oder [Set](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) Sie den Zustand des SmartArt‑Diagramms.
1. Schreiben Sie die Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```java
// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Abrufen oder Festlegen des Zustands des SmartArt-Diagramms
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Präsentation speichern
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umkehren für RTL‑Sprachen?**

Ja. Die Methode [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) schaltet die Diagrammrichtung (LTR/RTL) um, wenn der ausgewählte SmartArt‑Typ eine Umkehr unterstützt.

**Wie kann ich SmartArt in dieselbe Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form über die Shapes‑Sammlung [clone the SmartArt shape](/slides/de/java/shape-manipulations/) ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) oder die gesamte Folie, die diese Form enthält, [clone the entire slide](/slides/de/java/clone-slides/) duplizieren. Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt in ein Rasterbild für die Vorschau oder den Web‑Export?**

[Render the slide](/slides/de/java/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Methode ist die Verwendung von [alternative text](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt‑Text) oder einem [name](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) und das Suchen nach der Form anhand dieses Attributs innerhalb der [slide shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--). Anschließend prüfen Sie den Typ, um sicherzustellen, dass es sich um ein [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.