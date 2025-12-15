---
title: SmartArt in PowerPoint‑Präsentationen auf Android verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt‑Text
- Layouttyp
- versteckte Eigenschaft
- Organigramm
- Bild‑Organigramm
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑SmartArt mit Aspose.Slides für Android erstellen und bearbeiten, indem Sie klare Java‑Code‑Beispiele verwenden, die die Foliengestaltung und Automatisierung beschleunigen."
---

## **Text aus einem SmartArt-Objekt abrufen**
Die TextFrame‑Methode wurde nun jeweils dem Interface [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) und der Klasse [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) hinzugefügt. Diese Eigenschaft ermöglicht es, den gesamten Text aus [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) abzurufen, falls er nicht nur Knotentexte enthält. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt‑Knoten zu erhalten.
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
Um den Layouttyp von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu ändern, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie über deren Index.
- Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList hinzu.
- Ändern Sie den [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) zu BasicProcess.
- Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
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


## **Versteckte Eigenschaft eines SmartArt-Objekts prüfen**
Bitte beachten Sie: Die Methode [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)) gibt true zurück, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist. Um die versteckte Eigenschaft eines beliebigen Knotens von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu prüfen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle hinzu.
- Fügen Sie einen Knoten zur SmartArt hinzu.
- Prüfen Sie die Eigenschaft [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) .
- Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
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


## **Organigrammtyp abrufen oder festlegen**
Die Methoden [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) und [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) ermöglichen das Abrufen bzw. Festlegen des mit dem aktuellen Knoten verknüpften Organigrammtyps. Um den Organigrammtyp abzurufen oder festzulegen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
- Rufen Sie den Organigrammtyp ab oder [setzen Sie ihn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Speichern Sie die Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir einen Verbinder zwischen zwei Formen hinzugefügt.
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess hinzufügen
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Organigrammtyp abrufen oder festlegen
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Präsentation speichern
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ein Bild‑Organigramm erstellen**
Aspose.Slides für Android via Java bietet eine einfache API zum Erstellen von PictureOrganization‑Diagrammen auf einfache Weise. So erstellen Sie ein Diagramm auf einer Folie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
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
Um den Zustand von [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) zu ändern, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
2. Fügen Sie eine [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) auf der Folie hinzu.
3. [Rufen Sie den Zustand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) ab oder [setzen Sie ihn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) des SmartArt‑Diagramms.
4. Schreiben Sie die Präsentation als PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.
```java
// Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei darstellt
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

**Unterstützt SmartArt das Spiegeln/Umkehren für RTL‑Sprachen?**  
Ja. Die Methode [setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) wechselt die Diagrammrichtung (LTR/RTL), wenn der ausgewählte SmartArt‑Typ die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**  
Sie können die SmartArt‑Form über die Shapes‑Collection [duplizieren](/slides/de/androidjava/shape-manipulations/) ([ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) oder die gesamte Folie, die diese Form enthält, [duplizieren](/slides/de/androidjava/clone-slides/). Beide Ansätze erhalten Größe, Position und Stil.

**Wie rendere ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**  
Sie können die Folie [rendern](/slides/de/androidjava/convert-powerpoint-to-png/) (oder die gesamte Präsentation) zu PNG/JPEG über die API, die Folien/Präsentationen in Bilder konvertiert – SmartArt wird dabei als Teil der Folie gezeichnet.

**Wie kann ich programmgesteuert ein bestimmtes SmartArt auf einer Folie auswählen, wenn mehrere vorhanden sind?**  
Eine übliche Vorgehensweise ist die Verwendung von [Alternativtext](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) oder einem [Namen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getName--) und das Suchen der Form nach diesem Attribut innerhalb der [Folienformen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), dann den Typ prüfen, um zu bestätigen, dass es sich um [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/) handelt. Die Dokumentation beschreibt typische Techniken zum Finden und Arbeiten mit Formen.