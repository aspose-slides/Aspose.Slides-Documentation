---
title: 使用 JavaScript 管理演示文稿中的图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/nodejs-java/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 嵌入式图像
- 链接图像
- 提取图像
- 栅格图像
- SVG 图像
- 裁剪图像
- 删除已裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对缩放
- 图像效果
- 长宽比
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js (通过 Java) 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是一种在幻灯片上显示图像的形状。在 Aspose.Slides 中，图像资源和显示它的形状是分开的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 通过其 [ImageCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imagecollection/) 拥有嵌入的图像资源，而一个 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像需要显示多次时，这种分离非常有用。将图像添加到演示文稿一次，保留返回的 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/)，并在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等光栅图像，也可以包含 SVG 矢量图像。它们还可以引用链接图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取和导出行为，因此在应用格式或优化之前，决定图像的存储方式是有意义的。

## **添加和格式化嵌入图像**

对于嵌入图像，向演示文稿添加图像数据并使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 创建图片框。图像会成为演示文稿包的一部分，因此当演示文稿移动到另一台计算机时仍然是自包含的。

以下示例添加 PNG 图像，在图像的原始尺寸下创建框，并应用线条格式和旋转：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

图片框控制显示的几何形状；更改框的大小不会改变嵌入图像资源中存储的原始像素尺寸。这一点在以后裁剪或压缩图像时尤为重要。

## **使用相对缩放**

[PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 通过 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) 和 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) 为框公开相对宽度和高度缩放。值 `1.0` 对应原始图片大小的 100%。相对缩放在工作流需要保持与源图像尺寸的比例，而不是手动计算最终尺寸时非常有用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相对缩放仅更改框的缩放设置；它不会重新采样或压缩嵌入的图像。

## **嵌入图像和链接图像**

嵌入图片将图像数据存储在演示文稿内部，因此在可移植性和可预测渲染方面是最安全的选择。链接图片则通过 [Picture.setLinkPathLong](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) 方法存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减小 PPTX 中存储的图像数据量，但会引入外部依赖。打开或渲染演示文稿的应用程序必须能够访问链接的文件。如果路径更改、文件移动或资源不可用，链接图片可能无法如预期显示。对于必须通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

以下示例创建一个图片框并指向本地图像文件。它仅涉及图像链接；视频链接是单独的媒体工作流，故意不在此示例中混合。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在外部文件管理是刻意行为时使用链接。不要仅将其用作压缩的替代方案：带有损坏图像依赖的较小 PPTX 通常不如较大的自包含演示文稿有用。

## **从图片框中提取图像**

在从现有演示文稿提取图像之前，检查形状实际上是否为 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 且是否包含嵌入图像。链接图片框可能不包含可同样方式提取的图像字节。

### **提取栅格图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/)。以下示例查找幻灯片上第一个嵌入的栅格图片并将其另存为 PNG：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

通过 [IImage.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/#save) 保存会将提取的图像转换为所请求的输出格式。如果需要演示文稿中存储的编码字节而不是转换后的栅格文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 公开一个 [SvgImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/) 对象。这样可以直接检索 SVG 数据，而无需先对图片进行光栅化。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

将 SVG 内容保持为 SVG 可以在演示文稿内保留矢量来源。PNG 或 JPEG 等光栅导出必然将该矢量内容渲染为像素。PDF 或 SVG 幻灯片导出也是一次渲染操作，因此导出的图形不应被视为原始嵌入 SVG 的逐字副本；当需要原始矢量资源本身时，请使用嵌入的 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/#getSvgData--) 数据。

## **裁剪图像**

裁剪更改在框内可见的图像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/) 的裁剪值是相对于源图像尺寸的百分比。裁剪最初并不会从嵌入图像中删除隐藏的像素；它仅改变可见区域。

以下示例安全地查找图片框并应用裁剪值：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

由于隐藏的图像数据仍然存在，之后可以更改裁剪而不会丢失原始像素。如果文件大小比可逆性更重要，可以如下一节所述物理删除已裁剪区域。

## **删除已裁剪的图像数据**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：保存演示文稿后，已删除的像素将不再可用于后续的“取消裁剪”操作。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

该方法可能向演示文稿添加新的图像资源。如果原始图像也被其他图片框使用，则这些框仍需其现有资源，因此删除裁剪区域并不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩栅格图像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 根据图片显示的尺寸相对降低栅格图像分辨率。它也可以在同一次操作中删除已裁剪区域。当图像被重新尺寸化或裁剪时返回 `true`，若未需要更改则返回 `false`。

在标准目标分辨率足够时，可使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturescompression/) 值：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

当需要特定目标时，可以传入自定义的正 DPI 值而不是预定义值。

压缩旨在针对栅格图像。SVG 和元文件内容不会通过此栅格压缩工作流减少。还要记住，降低的分辨率和已删除的裁剪区域无法从优化后的演示文稿中恢复。应根据图像实际观看或导出的最大尺寸选择目标分辨率，而不是全局使用最低 DPI。

## **检查图像效果**

图片效果存储在框使用的图片上。图像变换集合可以包含透明度的固定 Alpha 调制以及亮度对比度的亮度调节等效果。下面的示例安全地读取幻灯片上第一个图片框的两类效果：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

这些效果改变图像在框内的渲染方式；它们不会重写原始嵌入图像的字节。

## **锁定图片框几何形状**

[PictureFrameLock](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframelock/) 设置控制哪些编辑操作对图片框被禁用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 在调整大小时保持形状比例。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

锁定作用于图片框形状本身。它不会强制对源图像进行重新采样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值相对于图片框的边界框定义填充矩形。正百分比在边缘产生内缩，负百分比产生外伸。

这不同于裁剪。裁剪值选择源图像的可见部分；stretch offset 改变可见图片填充被拉伸到的矩形。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用 stretch offset 进行填充定位。当目标是隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小和导出注意事项**

当图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的方式，但大型栅格图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以保持包体积更小，但演示文稿依赖外部文件在存储路径或位置保持可用。
- **裁剪** 最初是非破坏性的。隐藏的像素会一直嵌入，直至显式删除裁剪区域或在压缩时移除。
- **压缩** 可以显著降低过大栅格图像的文件大小，但会牺牲源分辨率。应在已知幻灯片实际显示尺寸后再执行。
- **SVG 图像** 在需要保留矢量时应保持为 SVG。需要矢量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能复用已有的 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 资源，而不是在工作流中反复加载同一文件。

对于大型演示文稿，图像优化通常在选择性执行时最有效：将标志和图表保持为矢量内容，根据实际显示尺寸压缩照片，仅在不再需要后期编辑时删除裁剪像素，并避免使用外部链接，除非依赖管理是部署设计的一部分。

## **常见问题**

**图片框和图像资源有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 表示与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 是幻灯片上的形状，用于显示图像并存储框级几何和格式，如大小、旋转、裁剪值、效果和锁定。

**应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时，请嵌入图像。仅在有意将图像文件置于 PPTX 之外且能够可靠维护外部位置时才使用链接。

**裁剪会减少 PPTX 文件大小吗？**

单独的裁剪不会。普通裁剪设置会隐藏源图像的部分，但仍保留底层像素。需要永久丢弃这些像素时，请使用 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 或在压缩时删除已裁剪区域。

**压缩后还能恢复图像质量吗？**

不能。压缩会降低存储的栅格分辨率，删除已裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿外保留原始源图像。

**应如何处理 SVG 图像？**

当矢量保真度重要时，请保持 SVG 内容为 SVG。嵌入的 [SvgImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/) 可以直接提取。将幻灯片渲染为 PNG 或 JPEG 等光栅格式时，SVG 会被光栅化为像素。

**读取现有幻灯片时如何避免不安全的类型转换？**

在使用图片框特定成员之前，先检查形状类型。对 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 进行 `java.instanceOf` 检查可避免无效的类型转换，并让代码能够处理不包含图片框的幻灯片。