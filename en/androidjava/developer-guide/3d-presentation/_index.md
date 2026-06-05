---
title: Create 3D Effects in Presentations on Android
linktitle: 3D Presentation
type: docs
weight: 232
url: /androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentation
- 3D rotation
- 3D depth
- 3D extrusion
- 3D gradient
- 3D text
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Apply and render 3D effects for PowerPoint shapes and text on Android with Aspose.Slides. Configure camera, lighting, material, extrusion, fills, and 3D text."
---

## **Overview**

Aspose.Slides for Android via Java can create, edit, preserve, and render PowerPoint-style 3D formatting for shapes and text. This article covers 3D effects such as rotation, extrusion, bevels, lighting, material, gradient or picture fills, and 3D text.

{{% alert color="primary" %}}

This article is about 3D formatting effects on PowerPoint shapes and text. It is not about inserting or editing standalone 3D model files. When you export a slide to an image, PDF, or HTML, Aspose.Slides renders those 3D effects into the exported 2D output.

{{% /alert %}}

## **3D Formatting Concepts**

Use the [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) method to apply 3D formatting to a shape. The method returns [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), which controls the 3D scene for that shape.

For text, use the [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) method. This applies 3D formatting to the text frame instead of the shape body.

The most important API members are:

| API member | What it controls | When to use it |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Viewpoint, preset camera type, rotation, zoom, and perspective. | Rotate the object in 3D space or match a PowerPoint 3D rotation preset. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Light preset, direction, and light rotation. | Change how highlights and shadows appear on the 3D surface. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Surface material, such as flat, matte, plastic, or metal. | Make the same geometry look flatter, softer, glossy, or metallic. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | How far the shape extends backward from its front face. | Turn a flat shape into a visibly thick 3D object. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Color of the extruded sides. | Make depth visible or coordinate the side color with the front fill. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Additional 3D depth used by PowerPoint 3D formatting. | Fine-tune depth for shapes or text, especially together with bevel and material settings. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Raised or rounded edges on the front and back faces. | Add a softened or molded edge instead of a sharp flat face. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), and [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Outline around the 3D object. | Emphasize the object boundary in rendered output. |

## **Create a 3D Shape**

A shape usually needs four kinds of settings before it looks convincingly 3D:

- Camera settings, because the default front view may hide the extrusion.
- Light settings, because lighting makes the faces and sides readable.
- Material settings, because the surface affects how light is rendered.
- Extrusion or depth settings, because a flat shape needs thickness.

The following example creates a rectangle, adds text to its front face, applies 3D formatting, saves the presentation as PPTX, and renders the slide to a PNG image.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The rendered slide image shows the rectangle as a thick 3D block:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Rotate a Shape with the Camera**

In PowerPoint, 3D rotation is configured from the 3-D Rotation pane. The X, Y, and Z rotation values correspond to the rotation you set through the camera API.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

In Aspose.Slides, set the camera type and rotation through [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Use the camera when you need to change how the viewer sees the object. It does not change the 2D shape geometry on the slide. It changes the 3D viewpoint used by PowerPoint and by Aspose.Slides when rendering.

## **Add Extrusion and Depth**

Extrusion makes a shape look thick by extending it behind the front face. In PowerPoint, the depth control sets this visible thickness, and the color control sets the color of the side faces.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Set [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) for the thickness and [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) for the side color:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Use [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) when you need to work with PowerPoint's depth value directly or combine depth with bevel, material, and text effects. In many shape scenarios, `setExtrusionHeight` is the clearer setting because it directly expresses the visible extrusion.

## **Use Gradient or Picture Fills with 3D Effects**

3D formatting is independent from the shape fill. You can apply a solid color, gradient, pattern, or picture fill to the front face and still use the same camera, light, material, and extrusion settings.

This example applies a gradient fill to the shape and a darker extrusion color to the sides:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

The rendered output keeps the gradient on the front face and renders the extrusion separately:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

To use a picture fill instead, add the image to the presentation and assign it to the shape fill:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

The picture is rendered on the front face, while the extrusion is rendered as the 3D side surface:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Apply 3D Formatting to Text**

Shape 3D formatting affects the shape body. Text 3D formatting affects the text frame. This is useful for WordArt-like effects where the letters themselves need extrusion, material, lighting, and camera settings.

The following example creates text with a pattern fill, applies a WordArt transform, and configures 3D settings on [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/):

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The text is rendered as curved, extruded 3D lettering:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Export and Rendering Behavior**

Aspose.Slides preserves 3D formatting when saving to PowerPoint formats such as PPTX. When rendering or exporting to fixed-layout formats, the 3D scene is rasterized or drawn into the output as a 2D result. This applies when you render slides to [PNG](/slides/androidjava/convert-powerpoint-to-png/), export to [PDF](/slides/androidjava/convert-powerpoint-to-pdf/), export to [HTML](/slides/androidjava/convert-powerpoint-to-html/), or generate frames for [video conversion](/slides/androidjava/convert-powerpoint-to-video/).

Keep these points in mind:

- Exported images and PDFs are not interactive. The object cannot be rotated by the viewer after export.
- The final appearance depends on the combination of camera, light rig, material, extrusion, fill, and slide scaling.
- If you need to inspect inherited or theme-based formatting values, read the [effective shape properties](/slides/androidjava/shape-effective-properties/).
- Some output formats cannot store editable PowerPoint 3D formatting. In those formats, the visual result is rendered rather than preserved as editable 3D settings.

## **FAQ**

**Can Aspose.Slides create interactive 3D presentations?**

Aspose.Slides creates and renders PowerPoint 3D effects for shapes and text. It does not make exported images, PDFs, or HTML pages interactive 3D scenes that a viewer can rotate. In PPTX, the 3D formatting remains editable in PowerPoint where the format supports it.

**What is the difference between a 3D model and a 3D effect?**

A 3D model is a separate 3D object inserted into a presentation. A 3D effect is formatting applied to a regular PowerPoint shape or text, such as rotation, extrusion, bevel, lighting, and material. This article covers 3D effects.

**Which settings are required for a visible 3D shape?**

At minimum, set a camera rotation and either extrusion or depth. In practice, also set a light rig and material so the rendered faces have clear highlights and shadows.

**Can I apply 3D effects to both shapes and text?**

Yes. Use [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) for the shape body and [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) for text.

**Will 3D effects appear when exporting to images, PDF, HTML, or video frames?**

Yes. Aspose.Slides renders 3D effects when producing slide images, PDF output, HTML output, and frames used for video conversion. The exported output contains the rendered appearance, not an editable 3D object.

**Can I read the final 3D values after inheritance and theme settings are applied?**

Yes. Use the effective formatting APIs described in [Shape Effective Properties](/slides/androidjava/shape-effective-properties/) to read final camera, light rig, bevel, and related 3D values.
