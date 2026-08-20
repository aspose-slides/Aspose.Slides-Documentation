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
- shape layout formats
- shape as SVG
- shape to SVG
- align shape
- flip shape
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn how to identify, clone, remove, hide, reorder, export, align, and flip presentation shapes with Aspose.Slides for Python via .NET."
---

## **Overview**

Aspose.Slides for Python via .NET represents the shapes on a slide as an ordered [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/). The collection is both the place where you find and modify shapes and the source of their stacking order: index `0` is the backmost shape, while the last index is the frontmost shape.

This article follows that model. It first explains how to identify a shape reliably, then shows how to clone, remove, hide, and reorder shapes. The final sections cover layout-level formatting, SVG export, alignment, and flip settings. Each example is independent, so you can use only the operations your workflow requires.

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
