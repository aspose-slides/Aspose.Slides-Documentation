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
- Versteckte Eigenschaft
- Organisationsdiagramm
- Bild-Organisationsdiagramm
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint SmartArt mit Aspose.Slides für Android erstellen und bearbeiten, mit klaren Java-Codebeispielen, die das Folien-Design und die Automatisierung beschleunigen."
---
## **Übersicht**

SmartArt ist ein PowerPoint-Diagramm, das aus Knoten, Knotformen und einem Layout besteht. Mit Aspose.Slides für Android über Java können Sie SmartArt erstellen, Text aus seinen Knoten lesen, das Layout ändern, versteckte Knoten untersuchen, Organisationsdiagramm‑Layouts konfigurieren und Bild‑Organisationsdiagramme erstellen.

## **Text aus einem SmartArt-Objekt abrufen**

Ein SmartArt‑Knoten kann ein oder mehrere Shapes enthalten. Um Text aus den Knot‑Shapes zu lesen, iterieren Sie über [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), und lesen dann das über [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) zurückgegebene [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

Das Beispiel erfordert eine Präsentation mit mindestens einer Folie und einem SmartArt‑Objekt als erstes Shape auf dieser Folie. Es gibt jeden verfügbaren Textframe in der Konsole aus.

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

## **Typ des Layouts eines SmartArt-Objekts ändern**

Das SmartArt‑Layout bestimmt, wie Knoten angeordnet und verbunden werden. Das folgende Beispiel erstellt ein SmartArt‑Objekt mit dem [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/)‑Wert `BasicBlockList`, ändert ihn auf den Wert `BasicProcess` und speichert die Präsentation. Die an [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) übergebenen Position und Größe werden in Punkten angegeben. Verwenden Sie [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-), um das Layout zu ändern.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) gibt an, ob der Knoten im SmartArt‑Datenmodell ausgeblendet ist. Ausgeblendete Knoten können in der Struktur existieren, selbst wenn das ausgewählte Layout sie nicht als sichtbare Diagrammelemente darstellt.

Das folgende Beispiel fügt einem SmartArt‑Objekt, das den [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/)‑Wert `RadialCycle` verwendet, einen Knoten hinzu und prüft den ausgeblendeten Zustand des hinzugefügten Knotens. Es gibt eine Meldung aus, wenn der Knoten ausgeblendet ist, und speichert das Diagramm.

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

## **Organisationsdiagramm‑Layout abrufen oder festlegen**

Für SmartArt‑Diagramme, die ein Organisationsdiagramm‑Layout verwenden, definieren [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) und [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-), wie Kindknoten unter einem Elternknoten angeordnet werden. Beispielsweise können Sie Kindknoten links, rechts oder an beiden Seiten hängen lassen, abhängig vom ausgewählten [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

Das folgende Beispiel erstellt ein Organisationsdiagramm und legt das Layout für den ersten Knoten auf den [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/)‑Wert `LeftHanging` fest. Der nullbasierte Index `0` wählt den ersten Knoten der obersten Ebene aus; seine Kindknoten verwenden die ausgewählte Anordnung. Die modifizierte Präsentation wird anschließend gespeichert.

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

Ein Bild‑Organisationsdiagramm ist ein SmartArt‑Layout, das für Hierarchiediagramme mit Bild‑Platzhaltern konzipiert ist. Verwenden Sie beim Hinzufügen des SmartArt‑Objekts zu einer Folie den [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/)‑Wert `PictureOrganizationChart`. Dieses Beispiel speichert ein Diagramm mit Bild‑Platzhaltern; es füllt die Platzhalter nicht mit Bildern.

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

## **Legacy‑Diagramme in Shape‑Gruppen konvertieren**

Beim Modernisieren einer bestehenden Präsentation müssen Sie möglicherweise ein Organisationsdiagramm aktualisieren, das ursprünglich in PowerPoint 97‑2003 erstellt wurde. Aspose.Slides stellt diese Legacy‑Diagramme als [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/)‑Objekte dar. Verwenden Sie [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--), um ein Diagramm in eine Shape‑Gruppe zu konvertieren, sodass Sie einzelne Bildelemente bearbeiten können. Die Details finden Sie in der [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/).

Die Konvertierung fügt der Shape‑Sammlung eine neue Gruppe hinzu, ohne das ursprüngliche Diagramm zu entfernen. Entfernen Sie nach erfolgreicher Konvertierung das Original mit [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) , um doppelte Inhalte zu vermeiden. Sammeln Sie die Legacy‑Diagramme in einer Liste, bevor Sie sie konvertieren, damit das Hinzufügen und Entfernen von Shapes die Iteration nicht stört.

Das folgende Beispiel öffnet eine Präsentation, durchsucht jede Folie, konvertiert die Diagramme in Shape‑Gruppen und speichert die aktualisierte Präsentation als PPTX.

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

Die gespeicherte Präsentation enthält bearbeitbare Shape‑Gruppen anstelle der konvertierten Legacy‑Diagramme, wobei keine Originaldiagramme mehr vorhanden sind. Öffnen Sie die PPTX in PowerPoint, um einzelne Elemente innerhalb jeder Gruppe zu bearbeiten, z. B. deren Text, Füllung oder Position.

## **FAQ**

**Unterstützt SmartArt das Spiegeln oder Umkehren für RTL‑Sprachen?**  
Ja. Die Methode [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) wechselt die Diagrammrichtung von links‑nach‑rechts zu rechts‑nach‑links bzw. zurück, wenn das ausgewählte SmartArt‑Layout die Umkehrung unterstützt.

**Wie kann ich SmartArt auf derselben Folie oder in einer anderen Präsentation kopieren und dabei die Formatierung beibehalten?**  
Sie können die SmartArt‑Form mit [die SmartArt‑Form klonen](/slides/de/androidjava/shape-manipulations/) und [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) klonen oder die gesamte Folie mit [die gesamte Folie klonen](/slides/de/androidjava/clone-slides/) klonen, die die SmartArt enthält. Beide Ansätze erhalten Größe, Position und Formatierung.

**Wie rendere ich SmartArt zu einem Rasterbild für Vorschau oder Web‑Export?**  
Rendern Sie die Folie mit [die Folie rendern](/slides/de/androidjava/convert-powerpoint-to-png/) oder die gesamte Präsentation zu PNG oder JPEG. SmartArt wird als Teil der Folie gerendert.

**Wie kann ich ein bestimmtes SmartArt‑Objekt auf einer Folie finden, wenn mehrere vorhanden sind?**  
Verwenden Sie [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) oder [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-), um dem SmartArt‑Shape einen eindeutigen Alternativtext oder Namen zuzuweisen, suchen Sie diesen Wert in [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), und prüfen Sie anschließend, ob das gefundene Shape ein [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).