---
title: Verwalten von Zeichenhilfen in Präsentationen in Java
linktitle: Zeichenhilfen
type: docs
weight: 85
url: /de/java/drawing-guides/
keywords:
- Zeichenhilfe
- horizontale Hilfslinie
- vertikale Hilfslinie
- Ausrichtungshilfe
- Folienansicht
- Masterfolie
- Layoutfolie
- Notizen-Master
- Handzettel-Master
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Horizontale und vertikale Zeichenhilfen in PowerPoint‑Präsentationen hinzufügen, darauf zugreifen und löschen mit Aspose.Slides für Java."
---
## **Übersicht**

Zeichnungshilfen sind einstellbare horizontale und vertikale Linien, die Benutzern helfen, Formen beim Bearbeiten einer Präsentation in PowerPoint konsistent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation erzeugt, die später manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungshilfen speichern, denen die Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollten.

Zeichnungshilfen sind Bearbeitungshilfen, nicht Folieninhalt. Sie erscheinen nicht in einer Bildschirmpräsentation oder gerenderten Ausgabe. Aspose.Slides für Java stellt sie über das Interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguidescollection/) bereit. Eine Hilfslinie wird durch [IDrawingGuide](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguide/) repräsentiert und hat eine Ausrichtung, eine Position und eine Farbe.

Die Position wird in Punkten vom oberen linken Eck der jeweiligen Folie oder des Masters gemessen. Eine vertikale Hilfslinie verwendet eine horizontale Koordinate, typischerweise zwischen Null und der Folienbreite. Eine horizontale Hilfslinie verwendet eine vertikale Koordinate, typischerweise zwischen Null und der Folienhöhe.

## **Hilfslinien zur Folienansicht hinzufügen**

Verwenden Sie [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/de/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) um die beim Bearbeiten normaler Folien angezeigten Hilfslinien zu verwalten. Rufen Sie [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) mit einem [Orientation](https://reference.aspose.com/slides/de/java/com.aspose.slides/orientation/)‑Wert und einer Position in Punkten auf.

Das folgende Beispiel fügt eine vertikale Hilfslinie rechts von der Folienmitte und eine horizontale Hilfslinie darunter hinzu:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zugriff auf Zeichnungshilfen**

Die Methoden [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguidescollection/#getCount--) und [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) ermöglichen den Zugriff auf vorhandene Hilfslinien. Die Methoden [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguide/#getPosition--) und [IDrawingGuide.getColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguide/#getColor--) geben Werte zurück, die ebenfalls über die entsprechenden Setter‑Methoden geändert werden können.

Das folgende Beispiel liest die Hilfslinien der Folienansicht aus der oben erstellten Präsentation aus:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Hilfslinien zu Master‑ und Layout‑Folien hinzufügen**

Ein Folien‑Master und jede seiner Layout‑Folien können eigene Collections von Zeichnungshilfen besitzen. Verwenden Sie [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/#getDrawingGuides--) für einen Master‑Slide und [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) für einen Layout‑Slide.

Das folgende Beispiel fügt einer ersten Master‑Folie eine vertikale Hilfslinie und einer ersten Layout‑Folie eine horizontale Hilfslinie hinzu:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hilfslinien zu Notizen‑ und Handzettel‑Mastern hinzufügen**

Notizen‑Master und Handzettel‑Master unterstützen ebenfalls Zeichnungshilfen. Verwenden Sie [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) und [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--), um auf deren Collections zuzugreifen. Wenn eine Präsentation keinen dieser Master enthält, erzeugt [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) bzw. [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) den Standard‑Master und gibt ihn zurück.

Das folgende Beispiel fügt einem Notizen‑Master eine horizontale Hilfslinie und einem Handzettel‑Master eine vertikale Hilfslinie hinzu:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zeichnungshilfen entfernen**

Rufen Sie [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguidescollection/#clear--) auf, um alle Hilfslinien aus einer bestimmten Collection zu entfernen. Das Löschen einer Collection hat keinen Einfluss auf in einem anderen Bereich gespeicherte Hilfslinien.

Das folgende Beispiel löscht die Hilfslinien der Folienansicht sowie alle Hilfslinien auf Folien‑Mastern, Layout‑Folien, dem Notizen‑Master und dem Handzettel‑Master, ohne fehlende Master zu erzeugen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Erscheinen Zeichnungshilfen in einer Bildschirmpräsentation oder exportierten Bildern?**

Nein. Zeichnungshilfen sind Ausrichtungshilfen für die Bearbeitung und werden nicht als Präsentationsinhalt gerendert.

**Kann eine Zeichnungshilfe direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Bearbeitungshilfen für normale Folien werden in den Folien‑Ansicht‑Eigenschaften der Präsentation gespeichert. Separate Hilfslinien‑Collections stehen für Folien‑Master, Layout‑Folien, Notizen‑Master und Handzettel‑Master zur Verfügung.

**Welche Einheiten werden für die Positionen von Hilfslinien verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Zeichnungshilfen Formen oder ändert es Folieninhalt?**

Nein. Die Methode [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/idrawingguidescollection/#clear--) entfernt nur die Hilfslinien in der ausgewählten Collection. Formen und andere Folieninhalte bleiben unverändert.