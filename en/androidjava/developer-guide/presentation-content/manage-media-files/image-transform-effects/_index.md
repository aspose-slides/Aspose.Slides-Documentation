---
title: Manage Image Transform Effects in Presentations on Android
linktitle: Image Transform Effects
type: docs
weight: 11
url: /androidjava/image-transform-effects/
keywords:
- image transform
- picture effect
- brightness
- contrast
- grayscale
- duotone
- tint
- HSL
- color replacement
- blur
- transparency
- alpha effect
- effect chain
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Apply, chain, inspect, remove, and verify image transform effects for picture frames with Aspose.Slides for Android via Java."
---

## **Overview**

Aspose.Slides represents picture adjustments as an ordered collection of image transform operations. For a picture frame, start with the frame's [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) and access [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). The returned [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) lets you append, enumerate, inspect, remove, and clear effects without rewriting the original image bytes.

This article demonstrates a complete workflow for brightness and contrast, color transformations, blur, transparency, ordered effect chains, effective values, removal, and PPTX round-trip verification.

## **Understand Effect Ownership and Image Reuse**

An image resource and the picture that displays it are different objects:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) stores or references the source image data owned by the presentation.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) belongs to a picture fill and refers to an image resource while storing the image transform collection.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) is the slide shape that owns the relevant picture fill, geometry, crop settings, and other frame-level formatting.

Therefore, image transform operations do not modify the bytes in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). When the same `IPPImage` is passed to [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) more than once, each new picture frame receives its own `ISlidesPicture` and its own transform collection. Applying grayscale to one frame does not make the other frames grayscale, even though all of them reuse the same embedded image resource.

The same `ISlidesPicture.getImageTransform` model is also used by other picture fills, such as a shape or slide background. The examples below focus on picture frames.

## **Use Valid Parameter Ranges and Units**

The demonstrated methods use the following semantic ranges and units. Keep values in these ranges even if a particular library version does not reject every out-of-range value immediately; the target presentation format may normalize, omit, or reject invalid data during save or when PowerPoint opens the file.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` through `100`, percent; `0` leaves the component unchanged. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | No numeric parameters. Alpha is unchanged. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Two colors for dark and light pixels. RGB and alpha channel values used by `android.graphics.Color` range from `0` through `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue is `0` inclusive through `360` exclusive, in degrees; amount is `-100` through `100`, percent. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue is `0` inclusive through `360` exclusive, in degrees; saturation and luminance are `-100` through `100`, percent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | The replacement color uses channel values from `0` through `255`. Existing alpha values are unchanged. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius is nonnegative and is measured in points; `grow` is a Boolean that controls whether blurred content may extend outside the original bounds. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nonnegative percent. Use `0` through `100` for ordinary opacity scaling: `0` is fully transparent and `100` preserves the existing alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` through `100`, percent opacity. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` through `100`, percent alpha threshold. Values below it become transparent; values at or above it become opaque. |

For fixed alpha modulation, transparency and opacity are complementary. For example, 35% transparency corresponds to an alpha modulation amount of 65%.

## **Apply Brightness and Contrast**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) returns an [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) operation. Its scalar settings are supplied when the operation is created. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) returns calculated read-only values that can be inspected or logged.

The following example increases brightness by 15% and contrast by 20%, then renders a preview without modifying the embedded image:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) is an Office 2010 picture-effect extension and is less portable than the standard DrawingML luminance effect. When brightness and contrast must remain editable after a PPTX round trip, use [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) and verify the result after reopening the file. The format limitations section explains this distinction in more detail.

## **Apply Color Transformations**

Color effects can be applied independently to different picture frames that reuse one image resource. The following example creates five frames and applies grayscale, duotone, tint, HSL adjustment, and color replacement.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) contains two independently editable color parameters: `color1` maps dark pixels, while `color2` maps light pixels. This makes it a useful example of an effect whose settings are more complex than a single scalar value.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) replaces every pixel's color with one fixed color while preserving alpha. It is different from [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), which maps one source color to another and exposes both source and target color formats.

## **Add Blur, Transparency, and Alpha Effects**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) affects all color channels, including alpha. Set `grow` to `true` when the blurred edge may extend beyond the original picture bounds.

For uniform transparency, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). It multiplies every existing alpha value, so partially transparent pixels remain proportionally different. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) instead assigns one alpha value to all pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) converts alpha to two levels based on a threshold.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Other parameter-free alpha operations include [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), which makes every nonzero alpha fully opaque; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), which makes every alpha below 100% fully transparent; and [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), which changes alpha to `100% - alpha`.

## **Build an Ordered Effect Chain**

Every `add...Effect` method appends a new operation to the end of the collection. The renderer uses the collection as an ordered pipeline: the output of operation 0 becomes the input of operation 1, and so on. Consequently, the same operations in a different order can produce a different image.

For example, grayscale followed by tint first removes chromatic information and then recolors the luminance result. Tint followed by grayscale removes the tint again. Similarly, alpha replacement can override alpha values calculated by earlier operations, while alpha modulation preserves their relative differences.

The following example builds a four-operation chain, saves it as PPTX, reopens the presentation, checks both the operation types and their order, and renders the reopened result:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

The collection does not impose a compatibility matrix that restricts color, alpha, and blur operations to separate chains. They can be combined, but combinations are not always useful. A fixed color replacement removes RGB variation produced by earlier color effects; grayscale after duotone removes the two selected colors; and alpha ceiling, floor, replacement, or bi-level operations can discard alpha detail created earlier. Build the chain according to the desired pixel-processing sequence rather than treating its items as unordered formatting flags.

## **Inspect Editable and Effective Values**

An editable operation is the object stored in `ISlidesPicture.getImageTransform`. Depending on the effect, it may expose writable members directly. For example, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) exposes writable `radius` and `grow` values, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) exposes a writable `amount`, and [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) exposes a writable `threshold`. Color effects such as [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) expose mutable [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) objects.

Some operation interfaces, including [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), and [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), do not expose their creation scalars as writable properties. To change those settings, remove the operation and add a replacement at the required position.

Effective data returned by `getEffective()` is calculated and read-only. It is useful for resolving theme-dependent colors and reading the normalized values that the renderer uses, but it is not another editing surface. The following example enumerates the chain and inspects effective values where the corresponding API provides them:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Parameter-free effects such as grayscale, alpha ceiling, and alpha inverse still have an effective-data object, but there are no scalar settings to print. Their presence and position in the collection are the important information.

## **Remove or Clear Image Transforms**

Use [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) to remove one operation by index. Because indexes shift after removal, search for the target first and remove it after enumeration. Use [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) to remove the entire chain.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Removing or clearing transforms changes only the picture formatting. It does not delete, recompress, or otherwise alter the reused [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) resource.

## **Consider Presentation Formats and Export Targets**

Image transforms originate in DrawingML, so PPTX is the preferred editable format for effect chains. Even with PPTX, not every operation has identical portability:

- Standard DrawingML operations such as luminance, grayscale, duotone, tint, HSL, blur, and common alpha operations have the best chance of surviving a PPTX round trip. Always reopen the generated file and inspect the collection when preservation is a requirement.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) is an Office 2010 extension rather than the standard DrawingML luminance operation. It can be used for in-memory rendering, but it is not guaranteed to remain as an editable [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) after saving and reopening PPTX. Prefer [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) for persistent brightness and contrast adjustments.
- The binary PPT format predates the full DrawingML effect model. Saving to PPT can omit unsupported operations, reduce a chain to a supported subset, or approximate the appearance. Do not use PPT as the verification format for a complex editable chain.
- Rendering to PNG, JPEG, TIFF, PDF, SVG, HTML, or other visual output applies the supported chain to the rendered appearance. Those outputs do not contain an editable `IImageTransformOperationCollection`; raster formats flatten the result into pixels, and document/vector exports store their own rendering representation.
- Effects do not make a linked image self-contained. Rendering a linked picture still depends on the linked resource being available when the presentation is loaded.

Different presentation consumers may render edge cases differently, especially when several alpha or color-quantizing operations are combined. For critical output, test both the editable round trip and the final export format with the same Aspose.Slides version used in production.

## **FAQ**

**Do image transform effects modify the embedded image data?**

No. The operations belong to the `ISlidesPicture` used by the picture fill. The underlying `IPPImage` bytes remain unchanged.

**Will two picture frames that reuse the same image share their effects?**

No. Reusing an `IPPImage` avoids duplicate image data, but each picture frame normally has a separate `ISlidesPicture` and image transform collection.

**Can color, blur, and alpha effects be combined?**

Yes. The collection accepts them in one ordered chain. Consider what each operation does to the output of the previous one because replacement and threshold operations may discard earlier color or alpha detail.

**Why are effective values read-only?**

Effective data represents calculated values used for rendering, including resolved colors. Edit the operation stored in the transform collection where writable members exist; otherwise remove it and add a replacement with new creation parameters.

**Which format should I use to preserve a transform chain?**

Use PPTX and verify the file by reopening it. Legacy PPT cannot represent the full DrawingML effect model, and rendered export formats preserve appearance rather than editable transform operations.

