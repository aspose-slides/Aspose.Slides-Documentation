---
title: Manage Presentation Shapes in JavaScript
linktitle: Shape Manipulation
type: docs
weight: 40
url: /nodejs-java/shape-manipulations/
keywords:
- PowerPoint shape
- presentation shape
- shape on slide
- find shape
- clone shape
- remove shape
- hide shape
- change shape order
- get interop shape ID
- shape alternative text
- shape layout formats
- shape as SVG
- shape to SVG
- align shape
- flip shape
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to identify, clone, remove, hide, reorder, export, align, and flip presentation shapes with Aspose.Slides for Node.js via Java."
---

## **Overview**

Aspose.Slides for Node.js via Java represents the shapes on a slide as an ordered [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/). The collection is both the place where you find and modify shapes and the source of their stacking order: index `0` is the backmost shape, while the last index is the frontmost shape.

This article follows that model. It first explains how to identify a shape reliably, then shows how to clone, remove, hide, and reorder shapes. The final sections cover layout-level formatting, SVG export, alignment, and flip settings. Each example is independent, so you can use only the operations your workflow requires.

## **Identify and Find Shapes**

Collection indexes are convenient while processing a known file, but they are not stable identifiers. Adding, removing, or reordering a shape can change its index. Choose an identifier according to how the presentation is authored and maintained:

- [Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getname/) is useful for developer-controlled templates and is easy to inspect in PowerPoint's Selection Pane. Names can be edited and are not guaranteed to be unique, so establish a naming convention if code depends on them.
- [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/) is useful when an accessibility description or an author-supplied tag already identifies the shape. It is visible to users, may be localized or rewritten for accessibility, and is not guaranteed to be unique. Do not silently repurpose meaningful accessibility text as a database key.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) is a read-only identifier that is unique within a slide and corresponds to the shape ID used by PowerPoint interop. Use it when integrating with PowerPoint or when you need an unambiguous reference during the lifetime of a shape. A cloned or recreated shape is a different shape and receives its own ID.

The related [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getuniqueid/) method returns an identifier with presentation scope, but that identifier is intended for add-ins and can be reassigned. It should not be treated as a permanent external key. If long-term identity is essential, keep the mapping in application data and validate that the expected shape still exists.

The following example searches by name with an exact comparison and reports the slide-scoped interop ID. When the template does not contain the expected shape, the code reports that result instead of continuing with the wrong object.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

When an operation is specific to a shape type, check the runtime class before using type-specific members. This example updates text and alternative text only if the named object is an [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Modify the Shape Collection**

The add, clone, remove, and reorder methods operate on the collection immediately. If an operation changes the number or order of shapes, do not continue to rely on indexes captured before that operation.

### **Clone a Shape**

[addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) creates an independent copy and appends it to the target collection. [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/insertclone/) also creates a copy but places it at a specified z-order index. The overloads that accept coordinates move the clone without changing its size; overloads with width and height can resize it as well.

The example creates a destination slide, clones a labeled rectangle to the front, and inserts a second clone at the back. Changes to either clone do not modify the source shape.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cloning copies the shape's content and formatting, including its name and alternative text. Assign new logical identifiers to the clone when those values must be unique. Resources used by complex shapes are handled by the presentation, but a clone remains a new collection item with a new shape identity.

### **Remove Shapes**

[remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) deletes a specific shape object from its collection. When removing multiple matches during indexed iteration, traverse from the end so that each remaining index stays valid.

This example removes every shape with a designated name. It reads the shape at the current index and does not assume a specific shape type.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

After removal, the shape count and the indexes of later shapes change. References to unaffected shapes remain more reliable than saved indexes. Also consider connectors, animations, and other presentation features that may refer to the removed object; removing a visible shape can change more than the slide's appearance.

### **Hide a Shape**

Setting [Hidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/sethidden/) to `true` keeps the shape in the collection but prevents it from appearing in the normal slide show. Its index, formatting, and content remain available to code, so hiding is appropriate for optional elements that may be restored later.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hiding is not deletion or security. The object can still be discovered and unhidden by a user or by code, and it remains part of the presentation file.

### **Change the Z-Order**

Overlapping shapes are painted in collection order. [reorder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/reorder/) moves an existing shape to a target index without cloning it. Index `0` is the back; `size() - 1` is the front.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The rectangle is created first and initially sits behind the ellipse. Moving it to the final index puts it in front. Finalize z-order after adding or cloning all related shapes, because those operations append or insert new collection items and can alter the intended stack.

## **Inspect Shapes on Layout Slides**

Normal slides, layout slides, and master slides have separate shape collections. A shape in a layout collection is not the same object as a similarly positioned shape on a normal slide. Inspect layout shapes when you need to understand or change formatting supplied by a layout.

The following example reads each layout shape's [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getfillformat/) and [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getlineformat/) without assuming that every shape is an `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Editing a layout can affect multiple slides that use it. Before changing a layout shape, determine whether a normal slide inherits the object or contains a local override, and test every slide that uses that layout.

## **Export a Shape to SVG**

[writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) writes one shape's rendered content to a stream. The result contains the shape, not the entire slide background or neighboring shapes.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Keep the presentation open while rendering. The output depends on the shape's formatting and on resources such as fonts and images. If you need the whole composition, export the slide rather than an individual shape. The caller owns the stream and must close it.

## **Align Shapes**

The [SlideUtil.alignShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideutil/alignshapes/) overloads align either all shapes or selected collection indexes. [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapesalignmenttype/) specifies the edge, center line, or distribution mode. Set `alignToSlide` to `true` to use the slide edges; set it to `false` to align the selected shapes relative to one another.

This example aligns three shapes to the top edge of the slide. The returned shape references are converted to their current indexes immediately before alignment.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alignment changes positions, not z-order. Relative alignment normally needs at least two shapes, while horizontal or vertical distribution needs enough shapes to define spacing. Recompute indexes if you modify the collection before calling the method.

## **Flip a Shape**

The [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) class stores position, size, horizontal and vertical flip settings, and rotation. Its `getFlipH` and `getFlipV` values use [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/): `True` enables the flip, `False` disables it, and `NotDefined` preserves the unspecified/default state.

The input presentation below contains one unflipped shape.

![The shape before flipping](shape_to_be_flipped.png)

The example preserves every other frame value and replaces only the two flip settings. This is important because assigning a new [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setframe/) replaces the complete frame.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The saved shape is mirrored horizontally and vertically while keeping its position, size, and rotation.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Only for short-lived processing when the collection will not change before the index is used. Prefer a validated `Name` or `AlternativeText` convention for authored templates, or `OfficeInteropShapeId` for slide-scoped interop work.

**Does hiding a shape remove it from the z-order?**

No. A hidden shape remains in the collection at the same index. It can be found, reordered, edited, or made visible again.

**Why did a cloned shape appear in front of another shape?**

`addClone` appends the clone to the end of the collection, which is the front of the z-order. Use `insertClone` to choose the initial index or `reorder` after all shapes have been added.
