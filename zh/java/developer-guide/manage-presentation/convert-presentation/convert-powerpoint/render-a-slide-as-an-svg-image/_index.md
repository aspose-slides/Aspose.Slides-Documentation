---
title: 将演示文稿幻灯片渲染为 Java 中的 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿 转 SVG
- 幻灯片 转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- SVG 导出选项
- 交互式 SVG
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中将 PowerPoint 幻灯片导出为 SVG 图像，并控制字体、文本、图像、ID 和事件。"
---
## **概述**

SVG是一种可伸缩的基于XML的图像格式，适用于网络发布、幻灯片查看器、可访问性工作流以及自动后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在各浏览器之间保持可预测或准备好用于交互使用时，请使用 [SVGOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)，选择一张幻灯片，并使用 [ISlide.writeAsSvg](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) 将其写入流。以下示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

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

文件名使用 [ISlide.getSlideNumber](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/#getSlideNumber--) 而不是循环索引。当幻灯片查看器或网页只需要某个形状时，也可以使用 [IShape.writeAsSvg](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) 将文本框包含在渲染区域中，而 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) 决定是否应用框的旋转。当文本必须在不使用连字的情况下渲染时，将 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) 设置为 `true`。

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

## **控制文本和字体**

### **向量化所有文本**

将 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 设置为 `true`，以将所有幻灯片文本写为矢量图形。这消除了字体依赖，使视觉效果在各浏览器之间更一致，但文本将不再可作为 SVG 文本进行选择或搜索。

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

### **选择外部字体的处理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) 对外部加载的字体使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgexternalfontshandling/) 值。选择 `AddLinksToFontFiles` 以引用单独的字体文件，`Embed` 将字体数据嵌入 SVG，或 `Vectorize` 将仅使用外部字体的文本渲染为图形。在嵌入字体之前请验证字体许可。

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

## **减小嵌入图像大小**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 降低嵌入图片的分辨率，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) 省略裁剪的源区域，并使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) 控制 JPEG 编码质量。这些设置会在降低图像保真度或保留图像数据的代价下减小文件大小。

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

## **为形状和文本分配稳定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgshapeformattingcontroller/) 为每个 SVG 形状设置 [ISvgShape.setId](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgshape/#setId-java.lang.String-)。若要在文本 `tspan` 元素上也设置 [ISvgTSpan.setId](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) 值，请实现 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgshapeandtextformattingcontroller/)。使用 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 分配任一控制器。

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

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **添加 SVG 事件处理程序**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgshapeformattingcontroller/) 中，使用 [ISvgShape.setEventHandler](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) 并传入 [SvgEvent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgevent/) 值，为导出的形状添加 JavaScript 事件处理程序。通过 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 分配该控制器，并在承载结果的页面或 SVG 文档中定义 JavaScript 函数。

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

宿主页面可以定义由处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可实现幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流。

## **常见问题**

**何时应该使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，请使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)。仅当只需将使用外部字体的文本转换为图形时，请使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgexternalfontshandling/)。

**怎样才能让 SVG 更小？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供时选择链接的字体文件。请测试结果，因为降低图像分辨率、降低 JPEG 质量以及向量化文本各自会对质量和大小产生不同的权衡。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择相应的 SVG 元素。