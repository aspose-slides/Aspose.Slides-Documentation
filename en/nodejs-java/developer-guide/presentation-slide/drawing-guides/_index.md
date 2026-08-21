---
title: Manage Drawing Guides in Presentations in JavaScript
linktitle: Drawing Guides
type: docs
weight: 85
url: /nodejs-java/drawing-guides/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Add, access, and clear horizontal and vertical drawing guides in PowerPoint presentations using Aspose.Slides for Node.js via Java."
---

## **Overview**

Drawing guides are adjustable horizontal and vertical lines that help users align shapes consistently while editing a presentation in PowerPoint. They are especially useful when an application generates a presentation that will later be refined manually: the application can save the same alignment aids that authors should follow when adding or moving content.

Drawing guides are editing aids, not slide content. They do not appear in a slide show or rendered output. Aspose.Slides for Node.js via Java exposes them through the [DrawingGuidesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguidescollection/) class. A guide is represented by [DrawingGuide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguide/) and has an orientation, a position, and a color.

The position is measured in points from the top-left corner of the relevant slide or master. A vertical guide uses a horizontal coordinate, typically between zero and the slide width. A horizontal guide uses a vertical coordinate, typically between zero and the slide height.

## **Add Guides to the Slide View**

Use [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) to manage guides displayed while editing normal slides. Call [DrawingGuidesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguidescollection/#add) with an [Orientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/orientation/) value and a position in points.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Access Drawing Guides**

The [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguidescollection/#getCount) and [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) methods provide access to existing guides. The [DrawingGuide.getOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguide/#getPosition), and [DrawingGuide.getColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguide/#getColor) methods return values that can also be changed through the corresponding setter methods.

The following example reads the slide-view guides from the presentation created above:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Add Guides to Master and Layout Slides**

A slide master and each of its layout slides can have their own drawing-guide collections. Use [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) for a master slide and [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) for a layout slide.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Add Guides to Notes and Handout Masters**

Notes masters and handout masters also support drawing guides. Use [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) and [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) to access their collections. If a presentation does not contain one of these masters, `MasterNotesSlideManager.setDefaultMasterNotesSlide` or `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` creates the default master and returns it.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clear Drawing Guides**

Call [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguidescollection/#clear) to remove every guide from a particular collection. Clearing one collection does not affect guides stored in another scope.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
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

No. The [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/drawingguidescollection/#clear) method removes only the guides in the selected collection. Shapes and other slide content remain unchanged.
