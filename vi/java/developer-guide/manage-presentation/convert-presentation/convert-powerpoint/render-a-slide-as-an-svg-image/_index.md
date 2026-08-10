---
title: Kết xuất slide bài thuyết trình dưới dạng hình ảnh SVG trong Java
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bài thuyết trình sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xuất slide PowerPoint dưới dạng hình ảnh SVG trong Java và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, phù hợp cho việc xuất bản trên web, trình xem slide, quy trình tiếp cận, và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Use [SVGOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **Xuất một slide dưới dạng SVG**

Create a [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), select a slide, and write it to a stream with [ISlide.writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). The following example exports every slide in a presentation as a separate SVG file.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

The filename uses [ISlide.getSlideNumber](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getSlideNumber--) rather than the loop index. You can also export an individual shape with [IShape.writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) when a slide viewer or web page needs only that shape.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/) controls SVG rendering. For text frames, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) includes the text frame in the rendering area, and [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determines whether the frame rotation is applied. Set [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) to `true` when text must be rendered without ligatures.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Kiểm soát văn bản và phông chữ**

### **Vector hoá toàn bộ văn bản**

Set [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) to `true` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Chọn cách xử lý phông chữ bên ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgexternalfontshandling/) value for fonts that are loaded externally. Choose `AddLinksToFontFiles` to reference separate font files, `Embed` to include font data in the SVG, or `Vectorize` to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Giảm kích thước hình ảnh nhúng**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) to reduce the resolution of embedded pictures, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) to omit cropped source areas, and [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Gán ID ổn định cho hình dạng và văn bản**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgshapeformattingcontroller/) to set [ISvgShape.setId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) for each SVG shape. To set [ISvgTSpan.setId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) values on text `tspan` elements as well, implement [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Assign either controller with [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

The following controller uses [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), which is stable for the lifetime of the shape, and a repeatable counter for its text spans. This makes the generated IDs suitable for post-processing an unchanged presentation.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISvgShape slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Thêm bộ xử lý sự kiện SVG**

In an [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgshapeformattingcontroller/), call [ISvgShape.setEventHandler](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) with a [SvgEvent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the controller with [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) and define the JavaScript function in the page or SVG document that hosts the result.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

The host page can define the JavaScript function referenced by the handler. Assigning IDs and event handlers enables slide viewers, accessibility enhancements, and other interactive SVG workflows.

## **FAQ**

**When should I use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) instead of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgexternalfontshandling/)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) when all text must be independent of fonts. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgexternalfontshandling/) when only text that uses external fonts should be converted to graphics.

**What is the best way to make an SVG smaller?**

Start by compressing embedded pictures, deleting cropped image areas, and choosing linked font files when the target environment can serve them. Test the result because lower image resolution, lower JPEG quality, and vectorized text each have different quality and size tradeoffs.

**Can I modify exported SVG elements after export?**

Yes. Assign IDs through a formatting controller, then select the matching SVG elements in your post-processing tool or browser script.