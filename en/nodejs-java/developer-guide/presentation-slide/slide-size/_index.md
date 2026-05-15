---
title: Change the Presentation Slide Size in JavaScript
linktitle: Slide Size
type: docs
weight: 70
url: /nodejs-java/slide-size/
keywords:
- slide size
- aspect ratio
- standard
- widescreen
- 4:3
- 16:9
- set slide size
- change slide size
- custom slide size
- special slide size
- unique slide size
- full-size slide
- screen type
- do not scale
- ensure fit
- maximize
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Learn how to quickly resize slides in PPT, PPTX and ODP files with Node.js and Aspose.Slides, optimize presentations for any screen without losing quality."
---

## **Introduction**

Aspose.Slides provides comprehensive tools to adjust the slide size and aspect ratio in PowerPoint presentations, critical for both printing and on-screen display. 

Popular Slide Sizes and Ratios:

- **Standard (4:3 Aspect Ratio)**: Ideal for older screens and devices.
- **Widescreen (16:9 Aspect Ratio)**: Recommended for modern projectors and displays.

Ensure consistency throughout your presentation as a single slide size and aspect ratio apply to all slides. For optimal results, set your slide dimensions at the beginning of your presentation creation process to avoid complications.

{{% alert color="primary" %}} 
By default, presentations created with Aspose.Slides use the standard 4:3 aspect ratio.
{{% /alert %}}

## **Changing the Slide Size in Presentations**

 This sample code shows you how to change the slide size in a presentation in JavaScript using Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Specifying Custom Slide Sizes in Presentations**

If you find the common slide sizes (4:3 and 16:9) unsuitable for your work, you may decide to use a specific or unique slide size. For example, if you plan to print full-size slides from your presentation on a custom page layout or if you intend to display your presentation on certain screen types, you are likely to benefit from using a custom size setting for your presentation. 

This sample code shows you how to use Aspose.Slides for Node.js via Java to specify a custom slide size for a presentation in JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 paper size
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dealing With Issues When Changing the Size of Slides in Presentations**

After you change the slide size for a presentation, the slides’ contents (images or objects, for example) may become distorted. By default, the objects get automatically resized to fit the new slide size. However, when changing a presentation's slide size, you can specify a setting that determines how Aspose.Slides deals with the contents on the slides.

Depending on what you intend to do or achieve, you can use any of these settings:

- `DoNotScale`

  If you do NOT want the objects on the slides to be resized, use this setting.

- `EnsureFit`

  If you want to scale to a smaller slide size and you need Aspose.Slides to scale down the slides’ objects to ensure they all fit on slides (this way, you avoid losing content), use this setting. 

- `Maximize`

  If you want to scale to a larger slide size and you need Aspose.Slides to enlarge the slides’ objects to make them proportional to the new slide size, use this setting. 

This sample code shows you how to use the `Maximize` setting when changing the size of a presentation’s slide:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

Yes. Aspose.Slides uses points internally, where 1 point equals 1/72 of an inch. You can convert any unit (such as millimeters or centimeters) to points and use the converted values to define slide width and height.

**Will a very large custom slide size affect performance and memory usage during rendering?**

Yes. Larger slide dimensions (in points) combined with higher rendering scale lead to increased memory consumption and longer processing times. Aim for a practical slide size and adjust rendering scale only as needed to achieve the desired output quality.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

You can’t [merge presentations](/slides/nodejs-java/merge-presentation/) while they have different slide sizes — first, resize one presentation to match the other. When changing the slide size, you can choose how existing content is handled via the [SlideSizeScaleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/) option. After aligning sizes, you can merge slides while preserving formatting.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

Yes. Aspose.Slides can render thumbnails for [entire slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) as well as for [selected shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage). The resulting images reflect the current slide size and aspect ratio, ensuring consistent framing and geometry.
