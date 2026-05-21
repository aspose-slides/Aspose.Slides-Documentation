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
description: "Erfahren Sie, wie Sie PowerPoint SmartArt mit Aspose.Slides für Java erstellen und bearbeiten, anhand klarer Codebeispiele, die das Design und die Automatisierung von Folien beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotenformen und einem Layout besteht. Mit Aspose.Slides für Java können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, versteckte Knoten untersuchen, Organisations‑Chart‑Layouts konfigurieren und Bild‑Organisations‑Charts erstellen.

## **Text aus einem SmartArt‑Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Shapes enthalten. Um den sichtbaren Text zu lesen, iterieren Sie über [ISmartArt.getAllNodes](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartart/#getAllNodes--), dann lesen Sie das von [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartartshape/#getTextFrame--) zurückgegebene [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/).

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

## **Layouttyp eines SmartArt‑Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`‑Wert, ändert ihn zu dem Wert `BasicProcess` und speichert die Präsentation.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartartnode/#isHidden--) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente darstellt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle`‑Wert verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des Knotens.

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

## **Organisations‑Chart‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisations‑Chart‑Layout verwenden, definieren [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) und [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) wie Kindknoten unter einem übergeordneten Knoten angeordnet werden. Beispielsweise können Sie Kindknoten links, rechts oder an beiden Seiten hängen lassen, je nach ausgewähltem [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/java/com.aspose.slides/OrganizationChartLayoutType).

Das folgende Beispiel erstellt ein Organisations‑Chart und legt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/de/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`‑Wert fest.

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

## **Bild‑Organisations‑Chart erstellen**

Ein Bild‑Organisations‑Chart ist ein SmartArt‑Layout, das für Hierarchie‑Diagramme mit Bildplatzhaltern entwickelt wurde. Verwenden Sie beim Hinzufügen des SmartArt‑Objekts zu einer Folie den [SmartArtLayoutType](https://reference.aspose.com/slides/de/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`‑Wert.

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

Ja. Die Methode [ISmartArt.setReversed](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartart/#setReversed-boolean-) ändert die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links oder umgekehrt, wenn das ausgewählte SmartArt‑Layout die Umkehr unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in eine andere Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die SmartArt‑Form [SmartArt‑Shape klonen](/slides/de/java/shape-manipulations/) mit [ShapeCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) oder die gesamte Folie, die die SmartArt enthält, [ganze Folie klonen](/slides/de/java/clone-slides/). Beide Vorgehensweisen erhalten Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Raster‑Bild für die Vorschau oder den Web‑Export?**

Sie können die Folie [Folie rendern](/slides/de/java/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG konvertieren. SmartArt wird dabei als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt‑Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**

Legen Sie einen eindeutigen [Shape.getAlternativeText](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getAlternativeText--) oder [Shape.getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getName--) Wert für die SmartArt‑Form fest, suchen Sie diesen Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseslide/#getShapes--), und prüfen Sie anschließend, ob die gefundene Form ein [ISmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartart/) ist.