---
title: Apply Shape Effects in Presentations Using JavaScript
linktitle: Shape Effect
type: docs
weight: 30
url: /nodejs-java/shape-effect/
keywords:
- shape effect
- shadow effect
- reflection effect
- glow effect
- soft edges effect
- effect format
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Transform your PPT and PPTX files with advanced shape effects using JavaScript and Aspose.Slides for Node.js—create striking, professional slides in seconds."
---

## **Introduction**

While effects in PowerPoint can be used to make a shape stand out, they differ from [fills](/slides/nodejs-java/shape-formatting/#gradient-fill) or outlines. Using PowerPoint effects, you can create convincing reflections on a shape, spread a shape's glow, etc.

![Shape effect](shape-effect.png)

PowerPoint provides six effects that can be applied to shapes. You can apply one or more effects to a shape.

Some combinations of effects look better than others. For this reason, PowerPoint provides options under **Preset**. The Preset options are combinations of two or more effects that are known to look good. This way, by selecting a preset, you won't have to waste time testing or combining different effects to find a nice combination.

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **Apply a Shadow Effect**

Aspose.Slides for Node.js via Java supports outer and inner shadows for shapes. You can customize their color, direction, distance, and blur radius to match your presentation's design.

### **Apply an Outer Shadow**

Use an outer shadow to make a card or panel stand out against the slide background. The shadow extends beyond the shape's edges, creating the impression that the shape is raised above the slide. Adjust its color, direction, distance, and blur radius to match the lighting and styling of your template.

This JavaScript code shows how to apply the [outer shadow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) to a rectangle:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **Apply an Inner Shadow**

When reproducing a template's visual styling, use an inner shadow to give a card or panel a recessed appearance. An outer shadow extends outside the shape and makes it appear raised, while an inner shadow shades the inside of its edges.

Call [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), then configure the shadow returned by [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Larger blur radius values produce softer edges.

This JavaScript example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file. The shadow direction is 225 degrees, its distance is 7 points, and its blur radius is 6 points:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

To remove the inner shadow, call [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) on the shape's effect format.

## **Apply a Reflection Effect**

To apply a reflection effect in Aspose.Slides for Node.js via Java, you can add a mirror-like reflection to shapes, adjusting parameters such as distance, transparency, and size. This effect enhances the aesthetic of your presentations by giving shapes a more polished and sophisticated look. It’s easy to implement with simple code, enabling quick application across multiple elements for a consistent design.

This JavaScript code shows how to apply the [reflection effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) to a shape:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflection effect](reflection_effect.png)

## **Apply a Glow Effect**

To apply a glow effect to a shape in Aspose.Slides for Node.js via Java, you can add a soft, luminous aura around shapes, adjusting properties like color and size. This effect helps make shapes stand out and adds an attractive, eye-catching visual element to your presentation. It's easy to implement with minimal code, enhancing the overall look of your slides.

This JavaScript code shows how to apply the [glow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) to a shape:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glow effect](glow_effect.png)

## **Apply a Soft Edges Effect**

To apply a soft edges effect in Aspose.Slides for Node.js via Java, you can create a smooth, blurred transition around the edges of a shape. This effect adds a more subtle and refined look, perfect for designs that need a gentle, softer appearance. You can easily adjust parameters like radius to achieve the desired effect across various shapes in your presentation.

This JavaScript code shows how to apply the [soft edges effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) to a shape:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **Apply a Blur Effect**

Use shape blur to soften a shape's fill and outline while keeping the shape editable. Call [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) on the shape's effect format. The radius is measured in points (1/72 inch): use a nonnegative value, with larger values producing stronger blur. A radius of zero leaves the appearance unchanged.

The [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) setting controls the visible bounds of the effect. With `false`, the blur is clipped to the original painted bounds, including the outline. With `true`, the blur can extend beyond those bounds. Neither setting changes the shape's position or dimensions.

The comparison below uses the same fill, outline, and shape dimensions throughout. The top row uses `grow = false`; the bottom row uses `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

This JavaScript example creates an orange rectangle with a dark blue outline, applies a 5-point blur, and then updates it to a 15-point blur by calling [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) again. It saves both blurred states, then calls [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) and saves the shape without blur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Shape blur affects the fill and outline together. A soft edges effect fades the shape's edges, while shadow blur softens only the shadow. Image transformation effects operate on image content; this example applies blur directly to the shape's effect format without converting the shape to an image.

## **FAQ**

**Can I apply multiple effects to the same shape?**

Yes, you can combine different effects, such as shadow, reflection, and glow, on a single shape to create a more dynamic appearance.

**What shapes can I apply effects to?**

You can apply effects to various shapes, including autoshapes, charts, tables, pictures, SmartArt objects, OLE objects, and more.

**Can I apply effects to grouped shapes?**

Yes, you can apply effects to grouped shapes. The effect will apply to the entire group.
