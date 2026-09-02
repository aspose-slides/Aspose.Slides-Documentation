---
title: Manage Drawing Guides in Presentations in Java
linktitle: Drawing Guides
type: docs
weight: 85
url: /java/drawing-guides/
keywords:
- drawing guide
- horizontal guide
- vertical guide
- alignment guide
- slide view
- master slide
- layout slide
- notes master
- handout master
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Add, access, and clear horizontal and vertical drawing guides in PowerPoint presentations using Aspose.Slides for Java."
---

## **Overview**

Drawing guides are adjustable horizontal and vertical lines that help users align shapes consistently while editing a presentation in PowerPoint. They are especially useful when an application generates a presentation that will later be refined manually: the application can save the same alignment aids that authors should follow when adding or moving content.

Drawing guides are editing aids, not slide content. They do not appear in a slide show or rendered output. Aspose.Slides for Java exposes them through the [IDrawingGuidesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguidescollection/) interface. A guide is represented by [IDrawingGuide](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguide/) and has an orientation, a position, and a color.

The position is measured in points from the top-left corner of the relevant slide or master. A vertical guide uses a horizontal coordinate, typically between zero and the slide width. A horizontal guide uses a vertical coordinate, typically between zero and the slide height.

## **Add Guides to the Slide View**

Use [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) to manage guides displayed while editing normal slides. Call [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) with an [Orientation](https://reference.aspose.com/slides/java/com.aspose.slides/orientation/) value and a position in points.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

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

## **Access Drawing Guides**

The [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguidescollection/#getCount--) and [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) methods provide access to existing guides. The [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguide/#getPosition--), and [IDrawingGuide.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguide/#getColor--) methods return values that can also be changed through the corresponding setter methods.

The following example reads the slide-view guides from the presentation created above:

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

## **Add Guides to Master and Layout Slides**

A slide master and each of its layout slides can have their own drawing-guide collections. Use [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getDrawingGuides--) for a master slide and [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) for a layout slide.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

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

## **Add Guides to Notes and Handout Masters**

Notes masters and handout masters also support drawing guides. Use [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) and [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) to access their collections. If a presentation does not contain one of these masters, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) or [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) creates the default master and returns it.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

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

## **Clear Drawing Guides**

Call [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguidescollection/#clear--) to remove every guide from a particular collection. Clearing one collection does not affect guides stored in another scope.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

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

**Do drawing guides appear in a slide show or exported images?**

No. Drawing guides are alignment aids for editing and are not rendered as presentation content.

**Can a drawing guide be added directly to an individual normal slide?**

Normal-slide editing guides are stored in the presentation's slide-view properties. Separate guide collections are available for slide masters, layout slides, notes masters, and handout masters.

**Which units are used for guide positions?**

Positions are specified in points, where 72 points equal one inch. Vertical positions are measured from the left edge, and horizontal positions are measured from the top edge.

**Does clearing drawing guides remove shapes or change slide content?**

No. The [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/idrawingguidescollection/#clear--) method removes only the guides in the selected collection. Shapes and other slide content remain unchanged.
