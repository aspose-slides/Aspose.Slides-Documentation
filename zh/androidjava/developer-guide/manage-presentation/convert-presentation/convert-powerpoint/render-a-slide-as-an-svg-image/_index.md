---
title: 在 Android 上将演示幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 将 PowerPoint 幻灯片导出为 SVG 图像，并控制字体、文本、图像、ID 和事件。"
---
## **概述**

SVG 是一种可伸缩的基于 XML 的图像格式，适用于 Web 发布、幻灯片查看器、可访问性工作流和自动化后处理。Aspose.Slides for Android via Java 将每张幻灯片导出为单独的 SVG 文件，并允许您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在各浏览器之间保持一致或准备进行交互使用时，请使用[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)，选择幻灯片，并使用[ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-)将其写入流。下面的示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

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

文件名使用[ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--)而不是循环索引。当幻灯片查看器或网页只需要特定形状时，您也可以使用[IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) 将文本框包含在渲染区域中，且[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) 决定是否应用框的旋转。将[SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) 设置为 `true`，可在渲染文本时禁用连字。

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

## **控制箭头端的线段裁剪**

SVG 1.1 没有标记内嵌设置来指定线段在箭头下方的停止位置。默认情况下，Aspose.Slides 会缩短导出线段，使其笔画不穿过标记。调用[SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) 并传入 `true`，即可将笔画绘制至线段的原始端点。此设置仅影响 SVG 输出，线段在幻灯片上的位置和长度保持不变。

示例在第 2 条和第 10 条宽线的线上绘制三角形和菱形箭头，并分别以不同的裁剪选项导出同一幻灯片两次。

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;

    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

对比显示 10 点宽线的三角形箭头。启用裁剪时，尖端锋利；禁用裁剪时，笔画会穿过斜侧标记并呈现平直的末端。

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

在示例的其他线段中，2 点宽三角形的突出处不太明显。填充的菱形在两种宽度下都覆盖了笔画的末端。

## **控制文本和字体**

导出幻灯片为 SVG 时，您可以控制文本是保持为文本还是转换为矢量图形，以及外部字体的包含或引用方式。以下选项帮助您在导出的 SVG 中平衡视觉一致性、文本可选取性和字体依赖性。

### **将所有文本矢量化**

将[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 设置为 `true`，即可将所有幻灯片文本写入为矢量图形。这消除了字体依赖，使视觉结果在各浏览器间更一致，但文本将不再可以作为 SVG 文本被选取或搜索。

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) 使用[SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 的值来处理外部加载的字体。选择[SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 以引用独立的字体文件，选择[SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 以在 SVG 中嵌入字体数据，或选择[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 将使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

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

## **减小嵌入图像的大小**

使用[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 降低嵌入图片的分辨率，使用[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) 删除裁剪后的源区域，并使用[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) 控制 JPEG 编码质量。这些设置会在牺牲图像保真度或保留的图像数据的前提下减小文件体积。

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

## **控制图元光栅化分辨率**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) 设置在 SVG 导出期间对图元进行光栅化时的最低分辨率限制。它用于在对 EMF 或 WMF 图像进行光栅化时平衡细节与文件大小，并不为整个 SVG 定义全局 DPI，也不会强制幻灯片上的每个对象都转为光栅图像。

下载[metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含一张对角线间距紧密的 EMF 图像。下面的示例通过[ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 以三种不同的光栅化分辨率导出其第一页。其他导出设置保持相同，以便对比结果。

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

在输出中，EMF 在每个 SVG 中均转为一个嵌入的 PNG。以下测量针对所提供的演示文稿；它们并非将 DPI 转换为像素尺寸的通用公式。

| 图元光栅化 DPI | 嵌入 PNG 尺寸 | SVG 文件大小（字节） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下图显示相同区域的嵌入光栅在相同放大显示尺寸下的效果。72 DPI 时对角线出现明显像素化，高分辨率下边缘更平滑，同时 SVG 文件体积增大。提升该值并不一定能改进所有细节或改变每个导出图像。

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) 控制图像分辨率降低，可能掩盖更改图元光栅化分辨率的效果。[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) 控制 JPEG 编码质量，而非图元光栅化分辨率。

## **为形状和文本分配稳定的 ID**

使用[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) 为每个 SVG 形状设置[ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-)。若要在文本 `tspan` 元素上也设置[ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) 值，请实现[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/)。通过[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 分配任一控制器。

下面的控制器使用[IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 获取在形状生命周期内保持稳定的 ID，并使用可重复的计数器为其文本跨度生成 ID。这使生成的 ID 适用于对未改变的演示文稿进行后处理。

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

## **为 SVG 添加事件处理程序**

在[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) 中，调用[ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) 并传入[SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) 值，即可为导出的形状添加 JavaScript 事件处理程序。通过[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) 分配该控制器，并在承载结果的页面或 SVG 文档中定义相应的 JavaScript 函数。

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

宿主页面可以定义由处理程序引用的 JavaScript 函数。分配 ID 与事件处理程序后，可在幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流中发挥作用。

## **常见问题**

**何时应使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

当所有文本都必须独立于字体时，请使用[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)。当仅需要将使用外部字体的文本转换为图形时，请使用[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)。

**怎样才能让 SVG 文件更小？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供字体文件时选择使用链接的字体文件。请对结果进行测试，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本各自会在质量和大小之间产生不同的权衡。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择匹配的 SVG 元素进行修改。