---
title: Manage Presentation Shapes in Python via Java
linktitle: Shape Manipulation
type: docs
weight: 40
url: /python-java/shape-manipulations/
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
- shape adjustment point
- preset shape adjustment
- shape geometry
- shape layout formats
- shape as SVG
- shape to SVG
- align shape
- flip shape
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to identify, adjust, clone, remove, hide, reorder, export, align, and flip presentation shapes with Aspose.Slides for Python via Java."
---

## **Overview**

Aspose.Slides for Python via Java represents the shapes on a slide as an ordered [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/). The collection is both the place where you find and modify shapes and the source of their stacking order: index `0` is the backmost shape, while the last index is the frontmost shape.

This article follows that model. It first explains how to identify a shape reliably and modify preset shape adjustment points, then shows how to clone, remove, hide, and reorder shapes. The final sections cover layout-level formatting, SVG export, alignment, and flip settings. Each example is independent, so you can use only the operations your workflow requires.

## **Identify and Find Shapes**

Collection indexes are convenient while processing a known file, but they are not stable identifiers. Adding, removing, or reordering a shape can change its index. Choose an identifier according to how the presentation is authored and maintained:

- [Name](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getName) is useful for developer-controlled templates and is easy to inspect in PowerPoint's Selection Pane. Names can be edited and are not guaranteed to be unique, so establish a naming convention if code depends on them.
- [AlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) is useful when an accessibility description or an author-supplied tag already identifies the shape. It is visible to users, may be localized or rewritten for accessibility, and is not guaranteed to be unique. Do not silently repurpose meaningful accessibility text as a database key.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) is a read-only identifier that is unique within a slide and corresponds to the shape ID used by PowerPoint interop. Use it when integrating with PowerPoint or when you need an unambiguous reference during the lifetime of a shape. A cloned or recreated shape is a different shape and receives its own ID.

The related [getUniqueId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getUniqueId) method returns an identifier with presentation scope, but that identifier is intended for add-ins and can be reassigned. It should not be treated as a permanent external key. If long-term identity is essential, keep the mapping in application data and validate that the expected shape still exists.

The following example searches by name with an exact comparison and reports the slide-scoped interop ID. When the template does not contain the expected shape, the code reports that result instead of continuing with the wrong object.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

When an operation is specific to a shape type, check the type before using type-specific members. This example updates text and alternative text only if the named object is an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identify and Modify Preset Shape Adjustments**

Preset geometry shapes can expose adjustment points that control features such as corner size, arrow proportions, or arc angles. Access them through the read-only [GeometryShape.getAdjustments](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getAdjustments) collection. The collection itself is supplied by the shape, but each [AdjustValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/) contains a value that can be changed.

Do not rely only on a fixed collection index. Iterate through the adjustments and inspect the read-only [getType](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getType) method, whose [ShapeAdjustmentType](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/) value describes what the adjustment controls. The read-only [getName](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getName) method provides additional identification information and is especially useful when a preset contains more than one adjustment with the same semantic type.

Use the value method that matches the adjustment's meaning:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Size of rounded corners | [setRawValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Thickness of an arrow tail | [setRawValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Length of an arrowhead | [setRawValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Width of an arrowhead | [setRawValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Start angle of a pie or arc | [setAngleValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | End angle of a pie or arc | [setAngleValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getType) and [getName](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getName) return read-only information. [getRawValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getRawValue) and [setRawValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setRawValue) work with an integer in the preset's native geometry units, while [getAngleValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getAngleValue) and [setAngleValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setAngleValue) work with an angle in degrees. The number, order, meaning, and valid range of adjustments depend on the preset [ShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getShapeType). A value that is valid for one preset may be invalid or have a different effect for another.

When [getType](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getType) returns [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/shapeadjustmenttype/#Custom), the API does not recognize a standard semantic meaning. Inspect [getName](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getName), the preset type, and the existing value, and leave the adjustment unchanged unless the expected meaning and range are known. Even for recognized types, check whether the same type occurs more than once before selecting a value. The [Connector](/slides/python-java/connector/) article shows this situation with connector bend adjustments.

The following complete example creates default and modified versions of three preset shapes. It iterates through every adjustment, reports its name and type, changes size-related values through [setRawValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setRawValue), changes angles through [setAngleValue](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#setAngleValue), and saves the result. The left column retains the default geometry; the right column shows the adjusted rounded rectangle, four-way arrow, and pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Adds headers for the default and adjusted shape columns.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Checking the semantic type before changing a value makes the code explicit about its intent and avoids assuming that a particular collection index has the same meaning across different preset shapes.

## **Modify the Shape Collection**

The add, clone, remove, and reorder methods operate on the collection immediately. If an operation changes the number or order of shapes, do not continue to rely on indexes captured before that operation.

### **Clone a Shape**

[addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) creates an independent copy and appends it to the target collection. [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#insertClone) also creates a copy but places it at a specified z-order index. The overloads that accept coordinates move the clone without changing its size; overloads with width and height can resize it as well.

The example creates a destination slide, clones a labeled rectangle to the front, and inserts a second clone at the back. Changes to either clone do not modify the source shape.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cloning copies the shape's content and formatting, including its name and alternative text. Assign new logical identifiers to the clone when those values must be unique. Resources used by complex shapes are handled by the presentation, but a clone remains a new collection item with a new shape identity.

### **Remove Shapes**

[remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) deletes a specific shape object from its collection. When removing multiple matches during indexed iteration, traverse from the end so that each remaining index stays valid.

This example removes every shape with a designated name. It reads the shape at the current index, not a fixed collection item, and it does not cast the shape unnecessarily.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

After removal, the shape count and the indexes of later shapes change. References to unaffected shapes remain more reliable than saved indexes. Also consider connectors, animations, and other presentation features that may refer to the removed object; removing a visible shape can change more than the slide's appearance.

### **Hide a Shape**

Setting [Hidden](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHidden) to `True` keeps the shape in the collection but prevents it from appearing in the normal slide show. Its index, formatting, and content remain available to code, so hiding is appropriate for optional elements that may be restored later.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hiding is not deletion or security. The object can still be discovered and unhidden by a user or by code, and it remains part of the presentation file.

### **Change the Z-Order**

Overlapping shapes are painted in collection order. [reorder](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#reorder) moves an existing shape to a target index without cloning it. Index `0` is the back; the collection [size](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#size) minus one is the front.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The rectangle is created first and initially sits behind the ellipse. Moving it to the final index puts it in front. Finalize z-order after adding or cloning all related shapes, because those operations append or insert new collection items and can alter the intended stack.

## **Inspect Shapes on Layout Slides**

Normal slides, layout slides, and master slides have separate shape collections. A shape in a layout collection is not the same object as a similarly positioned shape on a normal slide. Inspect layout shapes when you need to understand or change formatting supplied by a layout.

The following example reads each layout shape's [FillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getFillFormat) and [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) without assuming that every shape is an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Editing a layout can affect multiple slides that use it. Before changing a layout shape, determine whether a normal slide inherits the object or contains a local override, and test every slide that uses that layout.

## **Export a Shape to SVG**

The `writeAsSvg` method of [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) writes one shape's rendered content to a stream. The result contains the shape, not the entire slide background or neighboring shapes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Keep the presentation open while rendering. The output depends on the shape's formatting and on resources such as fonts and images. If you need the whole composition, export the slide rather than an individual shape. The caller owns the stream and must close it.

## **Align Shapes**

The [SlideUtil.alignShapes](https://reference.aspose.com/slides/python-java/aspose.slides/slideutil/#alignShapes) overloads align either all shapes or selected collection indexes. [ShapesAlignmentType](https://reference.aspose.com/slides/python-java/aspose.slides/shapesalignmenttype/) specifies the edge, center line, or distribution mode. Set `align_to_slide` to `True` to use the slide edges; set it to `False` to align the selected shapes relative to one another.

This example aligns three shapes to the top edge of the slide. The returned shape references are converted to their current indexes immediately before alignment.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alignment changes positions, not z-order. Relative alignment normally needs at least two shapes, while horizontal or vertical distribution needs enough shapes to define spacing. Recompute indexes if you modify the collection before calling the method.

## **Flip a Shape**

The [ShapeFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapeframe/) class stores position, size, horizontal and vertical flip settings, and rotation. Its [getFlipH](https://reference.aspose.com/slides/python-java/aspose.slides/shapeframe/#getFlipH) and [getFlipV](https://reference.aspose.com/slides/python-java/aspose.slides/shapeframe/#getFlipV) values use [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/): `True` enables the flip, `False` disables it, and `NotDefined` preserves the unspecified/default state.

The input presentation below contains one unflipped shape.

![The shape before flipping](shape_to_be_flipped.png)

The example preserves every other frame value and replaces only the two flip settings. This is important because assigning a new [Frame](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setFrame) replaces the complete frame.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The saved shape is mirrored horizontally and vertically while keeping its position, size, and rotation.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Only for short-lived processing when the collection will not change before the index is used. Prefer a validated [Name](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getName) or [AlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) convention for authored templates, or [OfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) for slide-scoped interop work.

**Does hiding a shape remove it from the z-order?**

No. A hidden shape remains in the collection at the same index. It can be found, reordered, edited, or made visible again.

**Why did a cloned shape appear in front of another shape?**

[addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) appends the clone to the end of the collection, which is the front of the z-order. Use [insertClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#insertClone) to choose the initial index or [reorder](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#reorder) after all shapes have been added.

**Can I use a fixed index to identify a preset shape adjustment?**

Only after validating the exact preset and collection layout. Prefer iterating through [GeometryShape.getAdjustments](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getAdjustments) and checking [AdjustValue.getType](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getType); use [AdjustValue.getName](https://reference.aspose.com/slides/python-java/aspose.slides/adjustvalue/#getName) as additional information when the same semantic type appears more than once.
