---
title: Verwalten von Zeichnungsguides in Präsentationen auf Android
linktitle: Zeichnungsguides
type: docs
weight: 85
url: /de/androidjava/drawing-guides/
keywords:
- Zeichnungsguide
- horizontaler Guide
- vertikaler Guide
- Ausrichtungsguide
- Folienansicht
- Masterfolie
- Layoutfolie
- Notizenmaster
- Handout-Master
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Hinzufügen, Zugreifen auf und Löschen von horizontalen und vertikalen Zeichnungsguides in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java."
---
## **Übersicht**

Zeichnungsguides sind einstellbare horizontale und vertikale Linien, die Benutzern helfen, Formen beim Bearbeiten einer PowerPoint‑Präsentation konsistent auszurichten. Sie sind besonders nützlich, wenn eine Anwendung eine Präsentation erzeugt, die später manuell verfeinert wird: Die Anwendung kann dieselben Ausrichtungs­hilfen speichern, denen die Autoren beim Hinzufügen oder Verschieben von Inhalten folgen sollen.

Zeichnungsguides sind Bearbeitungs­hilfen, keine Folieninhalte. Sie erscheinen nicht in einer Bildschirmpräsentation oder ausgegebenen Ausgabe. Aspose.Slides for Android via Java stellt sie über die [IDrawingGuidesCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguidescollection/)‑Schnittstelle bereit. Ein Guide wird durch [IDrawingGuide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguide/) repräsentiert und besitzt eine Orientierung, eine Position und eine Farbe.

Die Position wird in Punkten vom oberen linken Eck der jeweiligen Folie oder des Masters gemessen. Ein vertikaler Guide verwendet eine horizontale Koordinate, typischerweise zwischen null und der Folienbreite. Ein horizontaler Guide verwendet eine vertikale Koordinate, typischerweise zwischen null und der Folienhöhe.

## **Guides zur Folienansicht hinzufügen**

Verwenden Sie [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) um die während der Bearbeitung normaler Folien angezeigten Guides zu verwalten. Rufen Sie [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) mit einem [Orientation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/orientation/)‑Wert und einer Position in Punkten auf.

Das folgende Beispiel fügt einen vertikalen Guide rechts von der Folienmitte und einen horizontalen Guide darunter hinzu:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zugriff auf Zeichnungsguides**

Die Methoden [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) und [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) ermöglichen den Zugriff auf vorhandene Guides. Die Methoden [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguide/#getPosition--) und [IDrawingGuide.getColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguide/#getColor--) geben Werte zurück, die über die jeweiligen Setter‑Methoden ebenfalls geändert werden können.

Das folgende Beispiel liest die Folienansichts‑Guides aus der zuvor erstellten Präsentation:

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

## **Guides zu Master‑ und Layout‑Folien hinzufügen**

Ein Folien‑Master und jede seiner Layout‑Folien können eigene Zeichnungsguide‑Sammlungen besitzen. Verwenden Sie [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) für einen Master‑Slide und [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) für einen Layout‑Slide.

Das folgende Beispiel fügt einen vertikalen Guide zur ersten Master‑Folien und einen horizontalen Guide zur ersten Layout‑Folien hinzu:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Guides zu Notizen‑ und Handzettel‑Mastern hinzufügen**

Notizen‑Master und Handzettel‑Master unterstützen ebenfalls Zeichnungsguides. Verwenden Sie [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) und [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--), um auf ihre Sammlungen zuzugreifen. Ist in einer Präsentation keiner dieser Master enthalten, erzeugt [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) bzw. [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) den Standard‑Master und gibt ihn zurück.

Das folgende Beispiel fügt einem Notizen‑Master einen horizontalen Guide und einem Handzettel‑Master einen vertikalen Guide hinzu:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zeichnungsguides löschen**

Rufen Sie [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) auf, um alle Guides aus einer bestimmten Sammlung zu entfernen. Das Löschen einer Sammlung beeinflusst nicht die Guides, die in einem anderen Geltungsbereich gespeichert sind.

Das folgende Beispiel löscht die Folienansichts‑Guides und alle Guides auf Folien‑Mastern, Layout‑Folien, dem Notizen‑Master und dem Handzettel‑Master, ohne fehlende Master zu erzeugen:

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

**Erscheinen Zeichnungsguides in einer Bildschirmpräsentation oder exportierten Bildern?**

Nein. Zeichnungsguides dienen nur als Ausrichtungs­hilfen beim Bearbeiten und werden nicht als Präsentationsinhalt gerendert.

**Kann ein Zeichnungsguide direkt zu einer einzelnen normalen Folie hinzugefügt werden?**

Guides für die normale Folienbearbeitung werden in den Folien‑Ansicht‑Eigenschaften der Präsentation gespeichert. Separate Guide‑Sammlungen stehen für Folien‑Master, Layout‑Folien, Notizen‑Master und Handzettel‑Master zur Verfügung.

**Welche Einheiten werden für Guide‑Positionen verwendet?**

Positionen werden in Punkten angegeben, wobei 72 Punkte einem Zoll entsprechen. Vertikale Positionen werden vom linken Rand gemessen, horizontale Positionen vom oberen Rand.

**Entfernt das Löschen von Zeichnungsguides Formen oder ändert es Folieninhalt?**

Nein. Die Methode [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) entfernt nur die Guides in der ausgewählten Sammlung. Formen und anderer Folieninhalt bleiben unverändert.