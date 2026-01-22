---
title: "SmartArt in PowerPoint-Präsentationen auf Android verwalten"
linktitle: "SmartArt verwalten"
type: docs
weight: 10
url: /de/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Lernen Sie, wie Sie SmartArt in PowerPoint mit Aspose.Slides für Android erstellen und bearbeiten, anhand klarer Java-Codebeispiele, die die Foliengestaltung und Automatisierung beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Die TextFrame-Methode wurde nun jeweils dem Interface [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) und der Klasse [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) hinzugefügt. Diese Eigenschaft ermöglicht das Abrufen des gesamten Textes aus [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), wenn nicht nur Knotentext vorhanden ist. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt-Knoten zu erhalten.
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
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Holen Sie sich die Referenz einer Folie über deren Index.
- Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) zu BasicProcess.
- Speichern Sie die Präsentation als PPTX-Datei.
  
Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutType zu BasicProcess ändern
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Präsentation speichern
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Sichtbarkeits‑Eigenschaft eines SmartArt-Objekts prüfen**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden) gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu prüfen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zur SmartArt hinzu.
- Prüfen Sie die [visibility](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden) Eigenschaft.
- Speichern Sie die Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Knoten zu SmartArt hinzufügen
    ISmartArtNode node = smart.getAllNodes().addNode();

    // isHidden-Eigenschaft prüfen
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
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) und [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen bzw. Festlegen des zu dem aktuellen Knoten zugeordneten Organisation‑Diagrammtyps. Um den Organisation‑Diagrammtyp abzurufen oder festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) zur Folie hinzu.
- Rufen Sie den Organisation‑Diagrammtyp ab oder [set the organization chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Speichern Sie die Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
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


## **Bild‑Organisationsdiagramm erstellen**
Aspose.Slides für Android via Java bietet eine einfache API zum Erstellen von PictureOrganization Diagrammen. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
4. Speichern Sie die geänderte Präsentation als PPTX-Datei.

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
Um den Zustand von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu ändern, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) zur Folie hinzu.
3. [Get](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) oder [Set](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) des Zustands des SmartArt‑Diagramms.
4. Speichern Sie die Präsentation als PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```java
// Instanziiere die Presentation-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Den Zustand des SmartArt-Diagramms abrufen oder festlegen
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Präsentation speichern
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Unterstützt SmartArt das Spiegeln/Umdrehen für RTL-Sprachen?**

Ja. Die Methode [setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) wechselt die Diagramm‑Richtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren, wobei die Formatierung erhalten bleibt?**

Sie können die [SmartArt‑Shape](/slides/de/androidjava/shape-manipulations/) über die Formensammlung ([ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) klonen oder die gesamte Folie, die diese Form enthält, [klonen](/slides/de/androidjava/clone-slides/). Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

Sie können die Folie [rendern](/slides/de/androidjava/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**

Eine gängige Praxis besteht darin, [alternativen Text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) (Alt‑Text) oder einen [Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getName--) zu verwenden und nach der Form anhand dieses Attributs innerhalb der [Folien‑Shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) zu suchen, dann den Typ zu prüfen, um sicherzustellen, dass es sich um [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.