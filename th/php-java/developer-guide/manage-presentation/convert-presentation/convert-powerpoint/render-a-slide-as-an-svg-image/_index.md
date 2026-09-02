---
title: เรนเดอร์สไลด์พรีเซนเทชันเป็นภาพ SVG ใน PHP
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG แบบโต้ตอบ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน PHP และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพแบบ XML ที่สามารถปรับขนาดได้ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำงานเพื่อการเข้าถึง, และการประมวลผลต่อเนื่องอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพ, และองค์ประกอบ SVG.

Use [SVGOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **ส่งออกสไลด์เป็น SVG**

Create a [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/), select a slide, and write it to a stream with [Slide.writeAsSvg](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#writeAsSvg). The following example exports every slide in a presentation as a separate SVG file.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

The filename uses [Slide.getSlideNumber](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getSlideNumber) rather than the loop index. You can also export an individual shape with [Shape.writeAsSvg](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#writeAsSvg) when a slide viewer or web page needs only that shape.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/) controls SVG rendering. For text frames, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setUseFrameSize) includes the text frame in the rendering area, and [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setUseFrameRotation) determines whether the frame rotation is applied. Set [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) to `true` when text must be rendered without ligatures.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **ควบคุมข้อความและฟอนต์**

### **ทำให้ข้อความทั้งหมดเป็นเวกเตอร์**

Set [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setVectorizeText) to `true` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **เลือกวิธีการจัดการฟอนต์ภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgexternalfontshandling/) value for fonts that are loaded externally. Choose `AddLinksToFontFiles` to reference separate font files, `Embed` to include font data in the SVG, or `Vectorize` to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **ลดขนาดภาพที่ฝังไว้**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setPicturesCompression) to reduce the resolution of embedded pictures, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) to omit cropped source areas, and [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setJpegQuality) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

Provide a formatting callback to [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setShapeFormattingController) to set [SvgShape.setId](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgshape/#setId) for each SVG shape. The callback can also set [SvgTSpan.setId](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgtspan/#setId) values on text `tspan` elements.

PhpJavaBridge cannot invoke a PHP callback from `writeAsSvg` when it runs in stream mode. Put the formatting logic in a small Java helper class, compile it, and add the resulting JAR file to the bridge classpath. The helper can use [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getOfficeInteropShapeId), which is stable for the lifetime of the shape, and a repeatable counter for its text spans. See the [Java implementation of `StableSvgIdController`](/slides/th/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) for the helper code.

After adding the compiled `com.example.slides.StableSvgIdController` class to the bridge classpath, instantiate it from PHP and assign it to `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **เพิ่มตัวจัดการเหตุการณ์ SVG**

In a formatting callback, call [SvgShape.setEventHandler](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgshape/#setEventHandler) with a [SvgEvent](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the callback with [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setShapeFormattingController) and define the JavaScript function in the page or SVG document that hosts the result.

As with stable IDs, implement the callback in a Java helper when PhpJavaBridge uses stream mode. The [Java implementation of `SvgEventController`](/slides/th/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) assigns an ID and an `OnClick` handler to a shape named `ActionButton`. Compile that helper, add it to the bridge classpath as `com.example.slides.SvgEventController`, and use it from PHP as follows:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

The host page can define the JavaScript function referenced by the handler. Assigning IDs and event handlers enables slide viewers, accessibility enhancements, and other interactive SVG workflows.

## **คำถามที่พบบ่อย**

**When should I use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setVectorizeText) instead of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgexternalfontshandling/)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#setVectorizeText) when all text must be independent of fonts. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgexternalfontshandling/) when only text that uses external fonts should be converted to graphics.

**What is the best way to make an SVG smaller?**

Start by compressing embedded pictures, deleting cropped image areas, and choosing linked font files when the target environment can serve them. Test the result because lower image resolution, lower JPEG quality, and vectorized text each have different quality and size tradeoffs.

**Can I modify exported SVG elements after export?**

Yes. Assign IDs through a formatting callback, then select the matching SVG elements in your post-processing tool or browser script.