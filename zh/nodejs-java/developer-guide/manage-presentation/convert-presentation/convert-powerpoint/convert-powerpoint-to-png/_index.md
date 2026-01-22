---
title: 将 PowerPoint 幻灯片转换为 JavaScript 中的 PNG
linktitle: PowerPoint 到 PNG
type: docs
weight: 30
url: /zh/nodejs-java/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 到 PNG
- 演示文稿到 PNG
- 幻灯片到 PNG
- PPT 到 PNG
- PPTX 到 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js 快速将 PowerPoint 演示文稿转换为高质量 PNG 图像，确保精确、自动化的结果。"
---

## **关于 PowerPoint 到 PNG 转换**

PNG（Portable Network Graphics）格式不如 JPEG（Joint Photographic Experts Group）流行，但仍然非常流行。

**使用场景：** 当你有复杂图像且尺寸不是问题时，PNG 比 JPEG 更合适的图像格式。

{{% alert title="Tip" color="primary" %}} 您可能想查看 Aspose 免费 **PowerPoint 到 PNG 转换器**： [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本页所述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) 方法返回的集合中获取 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 类的幻灯片对象。
3. 使用 [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 方法获取每个幻灯片的缩略图。
4. 使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 方法将幻灯片缩略图保存为 PNG 格式。

下面的 JavaScript 代码展示了如何将 PowerPoint 演示文稿转换为 PNG：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 转换为 PNG（自定义尺寸）**

如果您想获得特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这些值决定生成的缩略图的尺寸。

下面的 JavaScript 代码演示了上述操作：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 转换为 PNG（自定义大小）**

如果您想获得特定大小的 PNG 文件，可以为 `ImageSize` 传入首选的 `width` 和 `height` 参数。

下面的代码展示了在指定图像尺寸的情况下将 PowerPoint 转换为 PNG：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**如何仅导出特定形状（例如图表或图片）而不是整张幻灯片？**  
Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/nodejs-java/create-shape-thumbnails/)，您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**  
是的，但 [不要跨线程共享](/slides/zh/nodejs-java/multithreading/) 同一 Presentation 实例。请为每个线程或进程使用单独的实例。

**导出为 PNG 时试用版有什么限制？**  
评估模式会在输出图像上添加水印，并在未应用许可证前强制执行 [其他限制](/slides/zh/nodejs-java/licensing/)。