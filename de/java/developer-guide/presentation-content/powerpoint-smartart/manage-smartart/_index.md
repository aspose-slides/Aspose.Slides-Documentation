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
- Organigramm
- Bild-Organigramm
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-SmartArt mit Aspose.Slides für Java erstellen und bearbeiten, indem Sie klare Code-Beispiele nutzen, die die Foliengestaltung und Automatisierung beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Die TextFrame-Methode wurde jetzt zur [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) Schnittstelle und zur [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) Klasse jeweils hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) abzurufen, falls er nicht nur Knotentexte enthält. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
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
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu ändern, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Holen Sie sich die Referenz einer Folie über deren Index.
- Fügen Sie zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie den [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) zu BasicProcess.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Connector zwischen zwei Formen eingefügt.
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


## **Sichtbarkeits-Eigenschaft eines SmartArt-Objekts prüfen**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) gibt true zurück, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu prüfen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Fügen Sie zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie dem SmartArt einen Knoten hinzu.
- Prüfen Sie die [visibility](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--)‑Eigenschaft.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Connector zwischen zwei Formen eingefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Knoten zum SmartArt hinzufügen 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Überprüfen der isHidden-Eigenschaft
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


## **Organisation‑Chart‑Typ abrufen oder festlegen**
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) und [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen bzw. Festlegen des Organisation‑Chart‑Typs, der dem aktuellen Knoten zugeordnet ist. Um den Organisation‑Chart‑Typ abzurufen oder festzulegen, gehen Sie wie folgt vor:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Fügen Sie zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
- Rufen Sie den Organisation‑Chart‑Typ ab oder [setzen Sie ihn](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Connector zwischen zwei Formen eingefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Organisation-Chart-Typ abrufen oder festlegen
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Präsentation speichern
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Picture‑Organization‑Chart erstellen**
Aspose.Slides for Java bietet eine einfache API zum Erstellen von Bild‑Organisations‑Charts. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
4. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

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
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) zu ändern, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Fügen Sie zu [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
3. [Get](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) oder [Set](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) Sie den Zustand des SmartArt‑Diagramms.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```java
// Instanziiere die Presentation-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Zustand des SmartArt-Diagramms abrufen oder festlegen
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Präsentation speichern
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umdrehen für RTL‑Sprachen?**

Ja. Die Methode [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) wechselt die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ das Umdrehen unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die [SmartArt‑Form klonen](/slides/de/java/shape-manipulations/) über die Formen‑Sammlung ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) oder die gesamte Folie, die diese Form enthält, [klonen](/slides/de/java/clone-slides/). Beide Verfahren erhalten Größe, Position und Styling.

**Wie rendere ich SmartArt zu einem Raster‑Bild für eine Vorschau oder den Web‑Export?**

[Rendern Sie die Folie](/slides/de/java/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis besteht darin, [Alternativtext](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt‑Text) oder einen [Namen](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) zu verwenden und nach der Form anhand dieses Attributs innerhalb der [Folien‑Formen](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) zu suchen, dann den Typ zu prüfen, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.