---
title: 使用 JavaScript 在演示文稿中管理图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/nodejs-java/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 嵌入图像
- 链接图像
- 提取图像
- 光栅图像
- SVG 图像
- 裁剪图像
- 删除裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对比例
- 图像效果
- 宽高比
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（通过 Java）在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是一种在幻灯片中显示图像的形状。在 Aspose.Slides 中，图像资源和显示它的形状是分离的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 通过其 [ImageCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imagecollection/) 拥有嵌入的图像资源，而一个 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像需要显示多次时，这种分离非常有用。将图像一次添加到演示文稿中，保留返回的 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等光栅图像以及 SVG 向量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。选择哪种方式会影响可移植性、文件大小、提取和导出行为，因此在应用格式或优化之前，最好先决定图像的存储方式。

## **添加并格式化嵌入图像**

对于嵌入图像，将图像数据添加到演示文稿并使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 创建图片框。图像会成为演示文稿包的一部分，因此演示文稿在移动到另一台计算机时仍然是自包含的。

以下示例添加 PNG 图像，以图像的原始尺寸创建框，并应用线条格式和旋转：

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

图片框控制显示的几何形状；更改框的大小不会更改嵌入图像资源中存储的原始像素尺寸。当以后进行裁剪或压缩时，这一点尤为重要。

## **使用相对比例**

[PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 通过 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) 和 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) 暴露框的相对宽高比例。值 `1.0` 对应原始图片大小的 100%。当工作流需要保持与源图像尺寸的比例关系，而不是手动计算最终尺寸时，相对比例非常有用。

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

相对比例会更改框的比例设置；它不会重新采样或压缩嵌入的图像。

## **嵌入和链接的图像**

嵌入图片将图像数据存储在演示文稿内部，是可移植性和可预测渲染最安全的选择。链接图片则通过 [Picture.setLinkPathLong](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) 方法存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。链接的文件必须保持可访问，供打开或渲染演示文稿的应用程序使用。如果路径更改、文件移动或资源不可用，链接图片可能无法如预期显示。对于需要通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

以下示例创建一个图片框并指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，特意未混入此示例中。

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

当外部文件管理是有意为之时使用链接。不要仅将其作为压缩的替代方案：一个带有破损图像依赖的“小” PPTX 往往不如一个较大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿中提取图像之前，先检查形状是否实际是 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 并且它包含嵌入图像。链接图片框可能不包含可以以相同方式提取的图像字节。

### **提取光栅图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/)。以下示例查找幻灯片上第一个嵌入的光栅图片并将其保存为 PNG：

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

通过 [IImage.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/#save) 保存会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是转换后的光栅文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 暴露一个 [SvgImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/) 对象。这样可以直接获取 SVG 数据，而无需先将图片栅格化。

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

将 SVG 内容保持为 SVG 可以在演示文稿中保留向量源。PNG 或 JPEG 等光栅导出必然将向量内容渲染为像素。PDF 或 SVG 幻灯片导出同样是渲染操作，因此导出的图形不应视为原始嵌入 SVG 的逐字副本；当需要原始向量资源本身时，请使用嵌入的 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/#getSvgData--) 数据。

## **裁剪图像**

裁剪改变框内可见的图像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪最初并不会删除嵌入图像中的隐藏像素；它仅改变可见区域。

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

由于隐藏的图像数据仍然存在，裁剪可以在以后更改而不丢失原始像素。如果文件大小比可逆性更重要，可以如下一节所述物理删除裁剪区域。

## **删除裁剪的图像数据**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，被删除的像素将不再可用于后续的取消裁剪操作。

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

该方法可能会向演示文稿添加新的图像资源。如果原始图像还被其他图片框使用，这些框仍需要其现有资源，因此删除裁剪区域并不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果栅格化为 PNG。

## **压缩光栅图像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 根据图片显示的尺寸相对降低光栅图像分辨率。它也可以在同一次操作中删除裁剪区域。当图像被重新尺寸或裁剪时返回 `true`，如果没有必要进行更改则返回 `false`。

当标准目标分辨率足够时，使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturescompression/) 值：

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

如果需要特定目标，也可以传入自定义正 DPI 值。

压缩旨在针对光栅图像。SVG 和矢量图元内容不会通过此光栅压缩工作流减少。同样要记住，降低分辨率和删除裁剪区域后，无法从优化后的演示文稿中恢复。应根据图像实际观看或导出的最大尺寸选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像变换效果**

有关覆盖亮度、对比度、颜色变换、模糊、透明度效果、有序链、检查、移除以及往返验证的完整工作流，请参见 [Image Transform Effects](/nodejs-java/image-transform-effects/)。

## **锁定图片框几何**

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

锁定适用于图片框形状本身。它不会强制源图像重新采样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值相对于图片框的边界框定义填充矩形。正百分比会从边缘向内缩进，负百分比会向外延伸。

这与裁剪不同。裁剪值决定源图像的哪一部分可见；stretch offset 改变可见图片填充被拉伸进入的矩形。

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

使用 stretch offset 来定位填充。使用裁剪属性时的目标是隐藏源图像的边缘。

## **存储、文件大小和导出注意事项**

当图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的选项，但大型光栅图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以保持包体积更小，但演示文稿依赖外部文件在存储路径或位置保持可用。
- **裁剪** 初始为非破坏性。隐藏的像素会一直嵌入，直到显式删除裁剪区域或在压缩期间移除。
- **压缩** 能显著减小超大光栅图像的文件大小，但会牺牲源分辨率。应在确定幻灯片上的最终显示尺寸后再应用。
- **SVG 图像** 在需要保留向量时应保持为 SVG。需要向量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能复用已有的 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 资源，而不是在工作流中反复加载同一文件。

对于大型演示文稿，图像优化通常在选择性执行时最有效：将徽标和图表保留为向量内容，按实际显示尺寸压缩照片，仅在不需要后期编辑时删除裁剪像素，除非部署设计中包含依赖管理，否则避免使用外部链接。

## **常见问题**

**图片框和图像资源有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 表示与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 是幻灯片上的一种形状，用于显示图像并存储框级几何和格式，如大小、旋转、裁剪值、效果和锁定。

**应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时，请嵌入图像。仅当有意将图像文件保留在 PPTX 外部且能够可靠维护外部位置时才使用链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独裁剪不会。普通裁剪设置隐藏源图像的部分，但保留底层像素。要永久丢弃这些像素，请使用 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 或在压缩时移除裁剪区域。

**压缩后可以恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿外保留原始源图像。

**SVG 图像应如何处理？**

当向量保真度重要时，将 SVG 内容保持为 SVG。可以直接提取嵌入的 [SvgImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgimage/)。将幻灯片渲染为 PNG 或 JPEG 等光栅格式时，会将 SVG 栅格化为幻灯片图像的一部分。

**读取现有幻灯片时如何避免不安全的强制转换？**

在使用图片框特定成员之前，先检查形状类型。对 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 进行 `java.instanceOf` 检查，可避免无效强制转换，并使代码能够处理不包含图片框的幻灯片。