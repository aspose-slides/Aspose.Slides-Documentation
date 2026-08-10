---
title: 在 PHP 中将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿转 SVG
- 幻灯片转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- SVG 导出选项
- 交互式 SVG
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 与事件。"
---
## **概述**

SVG 是一种基于 XML 的可伸缩图像格式，适用于网页发布、幻灯片查看器、可访问性工作流以及自动化后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须保持紧凑、在各浏览器之间保持可预测，或需要用于交互式使用时，请使用[SVGOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)，选择幻灯片，并使用[Slide.writeAsSvg](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#writeAsSvg)将其写入流。以下示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

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

文件名使用[Slide.getSlideNumber](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getSlideNumber)而不是循环索引。您还可以使用[Shape.writeAsSvg](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#writeAsSvg)导出单个形状，以便幻灯片查看器或网页仅需要该形状时使用。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setUseFrameSize) 将文本框纳入渲染区域，而[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setUseFrameRotation) 决定是否应用框的旋转。将[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) 设置为 `true` 可在渲染文本时禁用连字。

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

## **控制文本和字体**

### **矢量化所有文本**

将[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setVectorizeText) 设置为 `true`，可将所有幻灯片文本写为矢量图形。这样可消除字体依赖，使视觉效果在各浏览器之间更一致，但文本将不再可被选择或搜索为 SVG 文本。

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

### **选择外部字体的处理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgexternalfontshandling/#setExternalFontsHandling) 使用[SvgExternalFontsHandling](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgexternalfontshandling/) 的取值来处理外部加载的字体。选择 `AddLinksToFontFiles` 以引用单独的字体文件，选择 `Embed` 将字体数据嵌入 SVG，或选择 `Vectorize` 将使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

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

## **缩小嵌入图像尺寸**

使用[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setPicturesCompression)降低嵌入图片的分辨率，使用[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)省略已裁剪的源区域，并使用[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setJpegQuality)控制 JPEG 编码质量。这些设置会在降低文件大小的同时牺牲图像保真度或保留的图像数据。

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

## **为形状和文本分配稳定的 ID**

为[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setShapeFormattingController)提供格式化回调，以为每个 SVG 形状设置[SvgShape.setId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgshape/#setId)。回调还可以为文本 `tspan` 元素设置[SvgTSpan.setId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgtspan/#setId) 的值。

当 PhpJavaBridge 在流模式下运行时，`writeAsSvg` 无法调用 PHP 回调。请将格式化逻辑放入一个小的 Java 辅助类中，编译后将生成的 JAR 文件添加到桥接的类路径。该辅助类可以使用[Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getOfficeInteropShapeId)，该 ID 在形状生命周期内保持稳定，并使用可重复的计数器为其文本跨度生成 ID。有关辅助代码，请参阅[Java 实现的 `StableSvgIdController`](/slides/zh/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)。

将编译好的 `com.example.slides.StableSvgIdController` 类添加到桥接类路径后，从 PHP 实例化并将其分配给 `SVGOptions`：

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

## **添加 SVG 事件处理程序**

在格式化回调中，使用[SvgShape.setEventHandler](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgshape/#setEventHandler)并传入[SvgEvent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgevent/) 值，即可为导出的形状添加 JavaScript 事件处理程序。通过[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setShapeFormattingController)分配回调，并在承载结果的页面或 SVG 文档中定义相应的 JavaScript 函数。

与稳定 ID 类似，在 PhpJavaBridge 使用流模式时，请在 Java 辅助类中实现回调。[`SvgEventController`] 的 Java 实现为名为 `ActionButton` 的形状分配 ID 并添加 `OnClick` 处理程序。编译该辅助类，将其作为 `com.example.slides.SvgEventController` 添加到桥接类路径，并在 PHP 中按如下方式使用：

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

宿主页面可以定义由处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可支持幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流。

## **常见问题**

**何时应使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#setVectorizeText)而不是[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，使用[SVGOptions.setVectorizeText]。当仅需将使用外部字体的文本转换为图形时，使用[SvgExternalFontsHandling.Vectorize]。

**怎样才能让 SVG 更小？**

首先压缩嵌入图片、删除裁剪的图像区域，并在目标环境能够提供时使用链接的字体文件。需要测试结果，因为降低图片分辨率、降低 JPEG 质量以及矢量化文本都会对质量和体积产生不同的权衡。

**导出后可以修改 SVG 元素吗？**

可以。通过格式化回调分配 ID，然后在后处理工具或浏览器脚本中选择相应的 SVG 元素进行修改。