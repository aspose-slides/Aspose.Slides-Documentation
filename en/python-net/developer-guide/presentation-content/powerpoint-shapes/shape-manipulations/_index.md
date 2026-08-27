---
title: Manage Presentation Shapes in Python
linktitle: Shape Manipulation
type: docs
weight: 40
url: /python-net/shape-manipulations/
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
- Aspose.Slides
description: "Learn how to identify, adjust, clone, remove, hide, reorder, export, align, and flip presentation shapes with Aspose.Slides for Python via .NET."
---

## **Overview**

Aspose.Slides for Python via .NET represents the shapes on a slide as an ordered [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/). The collection is both the place where you find and modify shapes and the source of their stacking order: index `0` is the backmost shape, while the last index is the frontmost shape.

This article follows that model. It first explains how to identify a shape reliably and modify preset shape adjustment points, then shows how to clone, remove, hide, and reorder shapes. The final sections cover layout-level formatting, SVG export, alignment, and flip settings. Each example is independent, so you can use only the operations your workflow requires.

## **Identify and Find Shapes**

Collection indexes are convenient while processing a known file, but they are not stable identifiers. Adding, removing, or reordering a shape can change its index. Choose an identifier according to how the presentation is authored and maintained:

- [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) is useful for developer-controlled templates and is easy to inspect in PowerPoint's Selection Pane. Names can be edited and are not guaranteed to be unique, so establish a naming convention if code depends on them.
- [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) is useful when an accessibility description or an author-supplied tag already identifies the shape. It is visible to users, may be localized or rewritten for accessibility, and is not guaranteed to be unique. Do not silently repurpose meaningful accessibility text as a database key.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/python-net/aspose.slides/shape/office_interop_shape_id/) is a read-only identifier that is unique within a slide and corresponds to the shape ID used by PowerPoint interop. Use it when integrating with PowerPoint or when you need an unambiguous reference during the lifetime of a shape. A cloned or recreated shape is a different shape and receives its own ID.

The related [Shape.unique_id](https://reference.aspose.com/slides/python-net/aspose.slides/shape/unique_id/) property has presentation scope, but it is intended for add-ins and can be reassigned. It should not be treated as a permanent external key. If long-term identity is essential, keep the mapping in application data and validate that the expected shape still exists.

The following example searches by `name` with an exact comparison and reports the slide-scoped interop ID. When the template does not contain the expected shape, the code reports that result instead of continuing with the wrong object.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

When an operation is specific to a shape type, check the type before using type-specific members. This example updates text and alternative text only if the named object is an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Identify and Modify Preset Shape Adjustments**

Preset geometry shapes can expose adjustment points that control features such as corner size, arrow proportions, or arc angles. Access them through the read-only [GeometryShape.adjustments](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/adjustments/) collection. The collection itself is supplied by the shape, but each [AdjustValue](https://reference.aspose.com/slides/python-net/aspose.slides/adjustvalue/) contains a value that can be changed.

Do not rely only on a fixed collection index. Iterate through the adjustments and inspect the read-only [AdjustValue.type](https://reference.aspose.com/slides/python-net/aspose.slides/adjustvalue/type/) property, whose [ShapeAdjustmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapeadjustmenttype/) value describes what the adjustment controls. The read-only [AdjustValue.name](https://reference.aspose.com/slides/python-net/aspose.slides/adjustvalue/name/) property provides additional identification information and is especially useful when a preset contains more than one adjustment with the same semantic type.

Use the value property that matches the adjustment's meaning:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CORNER_SIZE` | Size of rounded corners | [raw_value](https://reference.aspose.com/slides/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Thickness of an arrow tail | `raw_value` |
| `ARROWHEAD_LENGTH` | Length of an arrowhead | `raw_value` |
| `ARROWHEAD_WIDTH` | Width of an arrowhead | `raw_value` |
| `START_ANGLE` | Start angle of a pie or arc | [angle_value](https://reference.aspose.com/slides/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | End angle of a pie or arc | `angle_value` |

`type` and `name` cannot be assigned. `raw_value` is a read/write integer in the preset's native geometry units, while `angle_value` is a read/write angle in degrees. The number, order, meaning, and valid range of adjustments depend on the preset [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). A value that is valid for one preset may be invalid or have a different effect for another.

When `type` is `ShapeAdjustmentType.CUSTOM`, the API does not recognize a standard semantic meaning. Inspect `name`, the preset type, and the existing value, and leave the adjustment unchanged unless the expected meaning and range are known. Even for recognized types, check whether the same type occurs more than once before selecting a value. The [Connector](/slides/python-net/connector/) article shows this situation with connector bend adjustments.

The following complete example creates default and modified versions of three preset shapes. It iterates through every adjustment, reports its `name` and `type`, changes size-related values through `raw_value`, changes angles through `angle_value`, and saves the result. The left column retains the default geometry; the right column shows the adjusted rounded rectangle, four-way arrow, and pie.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add headers for the default and adjusted shape columns.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Checking the semantic type before changing a value makes the code explicit about its intent and avoids assuming that a particular collection index has the same meaning across different preset shapes.

## **Modify the Shape Collection**

The add, clone, remove, and reorder methods operate on the collection immediately. If an operation changes the number or order of shapes, do not continue to rely on indexes captured before that operation.

### **Clone a Shape**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) creates an independent copy and appends it to the target collection. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/insert_clone/) also creates a copy but places it at a specified z-order index. The overloads that accept coordinates move the clone without changing its size; overloads with width and height can resize it as well.

The example creates a destination slide, clones a labeled rectangle to the front, and inserts a second clone at the back. Changes to either clone do not modify the source shape.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Cloning copies the shape's content and formatting, including its name and alternative text. Assign new logical identifiers to the clone when those values must be unique. Resources used by complex shapes are handled by the presentation, but a clone remains a new collection item with a new shape identity.

### **Remove Shapes**

[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) deletes a specific shape object from its collection. When removing multiple matches during indexed iteration, traverse from the end so that each remaining index stays valid.

This example removes every shape with a designated name. It reads `slide.shapes[index]`, not a fixed collection item, and it does not cast the shape unnecessarily.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

After removal, the shape count and the indexes of later shapes change. References to unaffected shapes remain more reliable than saved indexes. Also consider connectors, animations, and other presentation features that may refer to the removed object; removing a visible shape can change more than the slide's appearance.

### **Hide a Shape**

Setting [Shape.hidden](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hidden/) to `True` keeps the shape in the collection but prevents it from appearing in the normal slide show. Its index, formatting, and content remain available to code, so hiding is appropriate for optional elements that may be restored later.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Hiding is not deletion or security. The object can still be discovered and unhidden by a user or by code, and it remains part of the presentation file.

### **Change the Z-Order**

Overlapping shapes are painted in collection order. [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/reorder/) moves an existing shape to a target index without cloning it. Index `0` is the back; `len(slide.shapes) - 1` is the front.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

The rectangle is created first and initially sits behind the ellipse. Moving it to the final index puts it in front. Finalize z-order after adding or cloning all related shapes, because those operations append or insert new collection items and can alter the intended stack.

## **Inspect Shapes on Layout Slides**

Normal slides, layout slides, and master slides have separate shape collections. A shape in a layout collection is not the same object as a similarly positioned shape on a normal slide. Inspect layout shapes when you need to understand or change formatting supplied by a layout.

The following example reads each layout shape's [Shape.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/fill_format/) and [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) without assuming that every shape is an `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Editing a layout can affect multiple slides that use it. Before changing a layout shape, determine whether a normal slide inherits the object or contains a local override, and test every slide that uses that layout.

## **Export a Shape to SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) writes one shape's rendered content to a stream. The result contains the shape, not the entire slide background or neighboring shapes.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Keep the presentation open while rendering. The output depends on the shape's formatting and on resources such as fonts and images. If you need the whole composition, export the slide rather than an individual shape. The caller owns the stream and must close it.

## **Align Shapes**

The [SlideUtil.align_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/align_shapes/) overloads align either all shapes or selected collection indexes. [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) specifies the edge, center line, or distribution mode. Set `align_to_slide` to `True` to use the slide edges; set it to `False` to align the selected shapes relative to one another.

This example aligns three shapes to the top edge of the slide. Their current indexes are resolved immediately before alignment.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Alignment changes positions, not z-order. Relative alignment normally needs at least two shapes, while horizontal or vertical distribution needs enough shapes to define spacing. Recompute indexes if you modify the collection before calling the method.

## **Flip a Shape**

The [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) class stores position, size, horizontal and vertical flip settings, and rotation. Its `flip_h` and `flip_v` values use [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/): `TRUE` enables the flip, `FALSE` disables it, and `NOT_DEFINED` preserves the unspecified or default state.

The input presentation below contains one unflipped shape.

![The shape before flipping](shape_to_be_flipped.png)

The example preserves every other frame value and replaces only the two flip settings. This is important because assigning a new [Shape.frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) replaces the complete frame.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

The saved shape is mirrored horizontally and vertically while keeping its position, size, and rotation.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Only for short-lived processing when the collection will not change before the index is used. Prefer a validated `name` or `alternative_text` convention for authored templates, or `office_interop_shape_id` for slide-scoped interop work.

**Does hiding a shape remove it from the z-order?**

No. A hidden shape remains in the collection at the same index. It can be found, reordered, edited, or made visible again.

**Why did a cloned shape appear in front of another shape?**

`add_clone` appends the clone to the end of the collection, which is the front of the z-order. Use `insert_clone` to choose the initial index or `reorder` after all shapes have been added.

**Can I use a fixed index to identify a preset shape adjustment?**

Only after validating the exact preset and collection layout. Prefer iterating through `GeometryShape.adjustments` and checking `AdjustValue.type`; use `AdjustValue.name` as additional information when the same semantic type appears more than once.
