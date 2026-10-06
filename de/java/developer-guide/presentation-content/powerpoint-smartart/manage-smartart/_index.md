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
- Ausgeblendete Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-SmartArt mit Aspose.Slides für Java erstellen und bearbeiten, indem Sie klare Codebeispiele nutzen, die das Entwerfen und Automatisieren von Folien beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint‑Diagramm, das aus Knoten, Knotengeformen und einem Layout besteht. Mit Aspose.Slides für Java können Sie SmartArt erstellen, Text aus dessen Knoten auslesen, das Layout ändern, versteckte Knoten untersuchen, Organisationsdiagramm‑Layouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt‑Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Formen enthalten. Um Text aus den Knotengeformen auszulesen, iterieren Sie über [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--), dann lesen Sie das [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) aus, das von [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--) zurückgegeben wird.

Das Beispiel erfordert eine Präsentation mit mindestens einer Folie und einem SmartArt‑Objekt als erster Form auf dieser Folie. Es gibt jedes verfügbare Textfeld in der Konsole aus.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Layouttyp eines SmartArt‑Objekts ändern**

Das SmartArt‑Layout steuert, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/)‑Wert `BasicBlockList`, ändert ihn auf den Wert `BasicProcess` und speichert die Präsentation. Die an [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) übergebenen Position und Größe werden in Punkt gemessen. Verwenden Sie [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-), um das Layout zu ändern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Überprüfen, ob ein SmartArt‑Knoten ausgeblendet ist**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente anzeigt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/)‑Wert `RadialCycle` verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des hinzugefügten Knotens. Es gibt eine Meldung aus, wenn der Knoten ausgeblendet ist, und speichert das Diagramm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organisation‑Diagrammlayout erhalten oder festlegen**

Für SmartArt‑Diagramme, die ein Organisations‑Diagrammlayout verwenden, definieren [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) und [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-), wie Kindknoten unter einem übergeordneten Knoten angeordnet werden. Beispielsweise können Sie Kindknoten links, rechts oder an beiden Seiten hängen lassen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisations‑Diagramm und setzt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/)‑Wert `LeftHanging`. Der nullbasierte Index `0` wählt den ersten Knoten der obersten Ebene aus; seine Kindknoten verwenden die gewählte Anordnung. Die geänderte Präsentation wird anschließend gespeichert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Bild‑Organisationsdiagramm erstellen**

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bild‑Platzhaltern konzipiert ist. Verwenden Sie den [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/)‑Wert `PictureOrganizationChart`, wenn Sie das SmartArt‑Objekt zu einer Folie hinzufügen. Dieses Beispiel speichert ein Diagramm mit Bild‑Platzhaltern; die Platzhalter werden nicht mit Bildern gefüllt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy‑Diagramme in Gruppen von Formen konvertieren**

Beim Modernisieren einer bestehenden Präsentation müssen Sie möglicherweise ein Organisations‑Diagramm aktualisieren, das ursprünglich in PowerPoint 97–2003 erstellt wurde. Aspose.Slides stellt diese Legacy‑Diagramme als [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/)‑Objekte dar. Verwenden Sie [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--), um ein Diagramm in eine Gruppe von Formen zu konvertieren, sodass Sie einzelne visuelle Elemente bearbeiten können. Weitere Details finden Sie in der [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/).

Die Konvertierung fügt der Formensammlung eine neue Gruppe hinzu, ohne das ursprüngliche Diagramm zu entfernen. Nach erfolgreicher Konvertierung entfernen Sie das Original mit [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-), um doppelte Inhalte zu vermeiden. Sammeln Sie die Legacy‑Diagramme in einer Liste, bevor Sie sie konvertieren, damit das Hinzufügen und Entfernen von Formen die Iteration nicht stört.

Das folgende Beispiel öffnet eine Präsentation, durchsucht jede Folie, konvertiert die Diagramme in Gruppen von Formen und speichert die aktualisierte Präsentation als PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die gespeicherte Präsentation enthält bearbeitbare Gruppen von Formen anstelle der konvertierten Legacy‑Diagramme, wobei keine Originaldiagramme mehr vorhanden sind. Öffnen Sie die PPTX in PowerPoint, um einzelne Elemente innerhalb jeder Gruppe zu bearbeiten, etwa deren Text, Füllung oder Position.

## **FAQ**

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL‑Sprachen?**

Ja. Die Methode [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) schaltet die Diagramm­richtung von links‑nach‑rechts zu rechts‑nach‑links um bzw. zurück, sofern das ausgewählte SmartArt‑Layout die Umkehr unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**

Sie können die [SmartArt‑Form klonen](/slides/de/java/shape-manipulations/) mit [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) oder die gesamte Folie, die SmartArt enthält, [klonen](/slides/de/java/clone-slides/). Beide Ansätze bewahren Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für die Vorschau oder den Web‑Export?**

[Rendern Sie die Folie](/slides/de/java/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn mehrere vorhanden sind?**

Verwenden Sie [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) oder [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-), um dem SmartArt‑Objekt einen eindeutigen Alternativtext oder Namen zuzuweisen, suchen Sie diesen Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--), und prüfen Sie anschließend, ob die gefundene Form ein [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/) ist.