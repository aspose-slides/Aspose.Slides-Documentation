---
title: 将 PowerPoint 转换为 PNG
type: docs
weight: 30
url: /zh/nodejs-java/convert-powerpoint-to-png/
keywords: PowerPoint 转 PNG, PPT 转 PNG, PPTX 转 PNG, java, Aspose.Slides for Node.js via Java
description: 将 PowerPoint 演示文稿转换为 PNG
---

## **关于 PowerPoint 到 PNG 转换**

PNG（Portable Network Graphics）格式的流行程度不如 JPEG（Joint Photographic Experts Group），但它仍然非常流行。

**使用场景：** 当您有复杂的图像且大小不是问题时，PNG 比 JPEG 更适合作为图像格式。

{{% alert title="Tip" color="primary" %}} 您可能想了解 Aspose 免费的 **PowerPoint 转 PNG 转换器**： [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本页所述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
2. 通过 [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) 方法获取返回的集合中的幻灯片对象，属于 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 类。
3. 使用 [Slide.getImage()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 方法获取每张幻灯片的缩略图。
4. 使用 [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) 方法将幻灯片缩略图保存为 PNG 格式。

以下 JavaScript 代码演示如何将 PowerPoint 演示文稿转换为 PNG：
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


## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果您想获取特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，以确定生成的缩略图的尺寸。

以下 JavaScript 代码演示上述操作：
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


## **使用自定义大小将 PowerPoint 转换为 PNG**

如果您想获取特定尺寸的 PNG 文件，可以为 `ImageSize` 传递所需的 `width` 和 `height` 参数。

以下代码展示了在指定图像大小的情况下，将 PowerPoint 转换为 PNG 的方法： 
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

**如何仅导出特定形状（例如图表或图片），而不是整张幻灯片？**

Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/nodejs-java/create-shape-thumbnails/)；您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

可以，但请 [不要共享](/slides/zh/nodejs-java/multithreading/) 单个演示文稿实例跨线程。请为每个线程或进程使用单独的实例。

**试用版在导出 PNG 时有哪些限制？**

评估模式会在输出图像上添加水印，并在加装许可证之前执行 [其他限制](/slides/zh/nodejs-java/licensing/)。