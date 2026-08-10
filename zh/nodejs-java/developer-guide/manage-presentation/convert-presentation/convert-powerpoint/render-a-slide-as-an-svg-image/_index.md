---
title: 在 JavaScript 中将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/nodejs-java/render-a-slide-as-an-svg-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 和事件。"
---
## **概览**

SVG 是一种可伸缩的基于 XML 的图像格式，适用于 Web 发布、幻灯片查看器、辅助功能工作流以及自动化后处理。Aspose.Slides for Node.js via Java 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在各浏览器间可预测或准备好交互使用时，请使用 [SVGOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)，选择一张幻灯片，并使用 [Slide.writeAsSvg](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/writeassvg/) 将其写入流。下面的示例将演示如何将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

文件名使用 [Slide.getSlideNumber](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/getslidenumber/) 而不是循环索引。当幻灯片查看器或网页只需要某个形状时，您也可以使用 [Shape.writeAsSvg](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/writeassvg/) 将单个形状导出为 SVG。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setuseframesize/) 将文本框包含在渲染区域内，且 [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) 决定是否应用框的旋转。若文本必须在不使用连字的情况下渲染，请将 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) 设置为 `true`。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **控制文本和字体**

### **矢量化所有文本**

将 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 设置为 `true`，即可将所有幻灯片文本写为矢量图形。这样可消除字体依赖，使视觉效果在各浏览器之间更一致，但文本将不再可作为 SVG 文本进行选择或搜索。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **选择外部字体的处理方式**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) 使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgexternalfontshandling/) 值来处理外部加载的字体。选择 `AddLinksToFontFiles` 可引用独立的字体文件，选择 `Embed` 可将字体数据嵌入 SVG，选择 `Vectorize` 则将使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **减小嵌入图像尺寸**

使用 [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) 可降低嵌入图片的分辨率，使用 [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) 可省略被裁剪的源区域，使用 [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setjpegquality/) 可控制 JPEG 编码质量。这些设置会在降低图像保真度或保留图像数据的情况下减小文件大小。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **为形状和文本分配稳定的 ID**

向 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) 传递一个格式化控制器，以便为每个 SVG 形状设置 [SvgShape.setId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgshape/setid/) 。能够处理文本跨度的控制器还能为文本 `tspan` 元素设置 [SvgTSpan.setId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgtspan/setid/) 值。

下面的控制器使用 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)，该 ID 在形状的整个生命周期内保持稳定，并为其文本跨度使用可重复的计数器。这使生成的 ID 适合对未更改的演示文稿进行后处理。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **添加 SVG 事件处理程序**

在格式化控制器中，使用带有 [SvgEvent](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgevent/) 值的 [SvgShape.setEventHandler](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgshape/seteventhandler/) 来为导出的形状添加 JavaScript 事件处理程序。通过 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) 分配该控制器，并在承载结果的页面或 SVG 文档中定义相应的 JavaScript 函数。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

宿主页面可以定义由处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可支持幻灯片查看器、辅助功能增强以及其他交互式 SVG 工作流。

## **常见问题**

**何时应使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，请使用 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)。如果仅需将使用外部字体的文本转换为图形，则使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgexternalfontshandling/)。

**如何最好地减小 SVG 大小？**

首先压缩嵌入的图片、删除裁剪的图像区域，并在目标环境能够提供时选择链接的字体文件。请对结果进行测试，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本都会在质量和体积之间产生不同的权衡。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择相应的 SVG 元素。