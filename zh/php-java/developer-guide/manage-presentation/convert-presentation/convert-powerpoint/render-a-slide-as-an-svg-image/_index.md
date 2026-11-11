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
description: 在 PHP 中将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 和事件。
---
## **概述**

SVG 是一种基于 XML 的可伸缩图像格式，适用于 Web 发布、幻灯片查看器、可访问性工作流和自动化后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在各浏览器之间保持一致或准备好进行交互使用时，请使用[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/)。

## **导出幻灯片为 SVG**

创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)，选择幻灯片，并使用[Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg)将其写入流。下面的示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

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

文件名使用[Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber)而不是循环索引。当幻灯片查看器或网页仅需要某个形状时，也可以使用[Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg)导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) 将文本框包含在渲染区域内，而[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) 决定是否应用框的旋转。若文本必须在不使用连字的情况下渲染，请将[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) 设置为 `true`。

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

在将幻灯片导出为 SVG 时，您可以控制文本是保持为文本还是转换为矢量图形，以及外部字体如何被包含或引用。以下选项帮助您在导出的 SVG 中平衡视觉一致性、文本选择以及字体依赖。

### **矢量化全部文本**

将[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) 设置为 `true`，即可将所有幻灯片文本写入为矢量图形。这消除了字体依赖，使在各浏览器之间的视觉效果更一致，但文本将不再可作为 SVG 文本进行选择或搜索。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) 使用[SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) 值来处理外部加载的字体。选择 `AddLinksToFontFiles` 可引用单独的字体文件，`Embed` 将字体数据嵌入 SVG，`Vectorize` 则将使用外部字体的文本渲染为图形。嵌入字体前请确认字体授权。

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

## **减小嵌入图像大小**

使用[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) 降低嵌入图片的分辨率，使用[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) 删除裁剪的源区域，并使用[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) 控制 JPEG 编码质量。这些设置会以牺牲图像保真度或保留的图像数据为代价来减小文件大小。

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

## **控制元文件光栅化分辨率**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) 为 SVG 导出期间对元文件进行光栅化设置了最低分辨率限制。可在光栅化 EMF 或 WMF 图像时平衡细节与文件大小。它并未为 SVG 定义全局 DPI，也不会强制幻灯片上的每个对象都转为光栅图像。

下载[metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含一张对角线紧密排列的 EMF 图像。下面的示例通过[Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) 将其第一张幻灯片在三种光栅化分辨率下导出。所有其他导出设置保持一致，以便进行比较。

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

在输出中，EMF 被转换为每个 SVG 中的一个嵌入 PNG。以下测量数据针对提供的演示文稿；它们并非将 DPI 转换为像素尺寸的通用公式。

| 元文件光栅化 DPI | 嵌入 PNG 尺寸 | SVG 文件大小（字节） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下面的比较展示了在相同放大显示尺寸下嵌入光栅的相同区域。对角线在 72 DPI 时出现可见像素化，在更高分辨率下边缘更平滑，然而 SVG 文件会随之增大。提升该数值并不一定能改善所有细节或改变每张导出图像。

![放大后的对角线细节（72、150、300 DPI）](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) 控制图像分辨率的降低，并可能掩盖更改元文件光栅化分辨率的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) 控制 JPEG 编码质量，而非元文件光栅化分辨率。

## **为形状和文本分配稳定的 ID**

通过向[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) 提供格式化回调，为每个 SVG 形状设置[SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId)。该回调还可以在文本 `tspan` 元素上设置[SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) 值。

当 PhpJavaBridge 在流模式下运行时，`writeAsSvg` 不能调用 PHP 回调。请将格式化逻辑放入一个小型 Java 辅助类，编译后将生成的 JAR 文件加入桥接类路径。辅助类可以使用[Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)，该 ID 在形状生命周期内保持稳定，并使用可重复的计数器为其文本跨度生成 ID。有关辅助代码，请参见[Java implementation of `StableSvgIdController`](/slides/zh/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)。

在将编译好的 `com.example.slides.StableSvgIdController` 类添加到桥接类路径后，从 PHP 实例化它并分配给 `SVGOptions`：

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

在格式化回调中，使用[SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) 并传入[SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) 值，可为导出的形状添加 JavaScript 事件处理程序。通过[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) 分配该回调，并在承载结果的页面或 SVG 文档中定义相应的 JavaScript 函数。

与稳定 ID 类似，在 PhpJavaBridge 使用流模式时，请在 Java 辅助类中实现回调。[Java implementation of `SvgEventController`](/slides/zh/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) 为名为 `ActionButton` 的形状分配 ID 并添加 `OnClick` 处理程序。编译该辅助类，将其以 `com.example.slides.SvgEventController` 添加到桥接类路径，并按如下方式在 PHP 中使用：

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

宿主页面可以定义被处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可支持幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流。

## **常见问题**

**何时应该使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)而不是[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，请使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)。仅当只需将使用外部字体的文本转换为图形时，才使用[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)。

**让 SVG 更小的最佳方法是什么？**

首先压缩嵌入的图片、删除裁剪的图像区域，并在目标环境能够提供时选择使用链接的字体文件。请对结果进行测试，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本各自有不同的质量与大小取舍。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化回调为元素分配 ID，然后在后处理工具或浏览器脚本中选择匹配的 SVG 元素进行修改。