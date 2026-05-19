---
title: SmartArt in PowerPoint-Präsentationen auf Android verwalten
linktitle: SmartArt verwalten
type: docs
weight: 10
url: /de/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt-Text
- Layouttyp
- ausgeblendete Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-SmartArt mit Aspose.Slides für Android erstellen und bearbeiten, indem Sie klare Java-Code-Beispiele verwenden, die die Foliengestaltung und Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint-Diagramm, das aus Knoten, Knotenformen und einem Layout besteht. Mit Aspose.Slides für Android via Java können Sie SmartArt erstellen, Text aus seinen Knoten lesen, sein Layout ändern, versteckte Knoten untersuchen, Organisationsdiagramm‑Layouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Formen enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [ISmartArt.getAllNodes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartart/#getAllNodes--), dann lesen Sie das [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) das von [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) zurückgegeben wird.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Den Layouttyp eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`‑Wert, ändert ihn auf den `BasicProcess`‑Wert und speichert die Präsentation.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartartnode/#isHidden--) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle`‑Wert verwendet, einen Knoten hinzu und prüft den ausgeblendeten Status des Knotens.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Das Layout des Organisationsdiagramms abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisationsdiagramm‑Layout verwenden, definieren [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) und [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) wie untergeordnete Knoten unter einem übergeordneten Knoten angeordnet werden. Sie können beispielsweise untergeordnete Knoten am linken, rechten oder an beiden Seiten hängen lassen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OrganizationChartLayoutType).

Das folgende Beispiel erstellt ein Organisationsdiagramm und setzt das Layout des ersten Knotens auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`‑Wert.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Bild‑Organisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchie‑Diagramme mit Bild‑Platzhaltern entwickelt wurde. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`‑Wert, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die [ISmartArt.setReversed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-)‑Methode wechselt die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder umgekehrt, wenn das ausgewählte SmartArt‑Layout eine Umkehrung unterstützt.

**Wie kann ich SmartArt auf dieselbe Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form [clone the SmartArt shape](/slides/de/androidjava/shape-manipulations/) mit [ShapeCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) oder die gesamte Folie, die das SmartArt enthält, [clone the whole slide](/slides/de/androidjava/clone-slides/) klonen. Beide Vorgehensweisen erhalten Größe, Position und Formatierung.

**Wie render ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**

[Render the slide](/slides/de/androidjava/convert-powerpoint-to-png/) oder die gesamte Präsentation nach PNG oder JPEG. SmartArt wird dabei als Teil der Folie gerendert.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn mehrere vorhanden sind?**

Setzen Sie einen eindeutigen [Shape.getAlternativeText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getAlternativeText--) oder [Shape.getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getName--) Wert auf die SmartArt‑Form, suchen Sie nach diesem Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/baseslide/#getShapes--), und prüfen Sie dann, ob die gefundene Form ein [ISmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartart/) ist.