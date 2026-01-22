---
title: 在 JavaScript 中将 PPT 和 PPTX 转换为 JPG
linktitle: PowerPoint 转 JPG
type: docs
weight: 60
url: /zh/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 JPG
- 演示文稿 转 JPG
- 幻灯片 转 JPG
- PPT 转 JPG
- PPTX 转 JPG
- 将 PowerPoint 保存为 JPG
- 将 演示文稿 保存为 JPG
- 将 幻灯片 保存为 JPG
- 将 PPT 保存为 JPG
- 将 PPTX 保存为 JPG
- 导出 PPT 为 JPG
- 导出 PPTX 为 JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，在 JavaScript 中将 PowerPoint (PPT, PPTX) 幻灯片转换为高质量 JPG 图像，提供快速可靠的代码示例。"
---

## **关于 PowerPoint 转 JPG 转换**
使用[**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/)可以将 PowerPoint PPT 或 PPTX 演示文稿转换为 JPG 图像。还可以将 PPT/PPTX 转换为 JPEG、PNG 或 SVG。借助这些功能，您可以轻松实现自己的演示文稿查看器，为每张幻灯片创建缩略图。如果您想保护幻灯片版权、以只读模式展示演示文稿，这将非常有用。Aspose.Slides 支持将整个演示文稿或特定幻灯片转换为图像格式。

{{% alert color="primary" %}} 
为了查看 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，您可以尝试这些免费在线转换器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg)和[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **将 PowerPoint PPT/PPTX 转换为 JPG**
以下是将 PPT/PPTX 转换为 JPG 的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类型的实例。
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) 集合中获取 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 类型的幻灯片对象。
3. 为每张幻灯片创建缩略图并将其转换为 JPG。[**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) 方法用于获取幻灯片的缩略图，它返回 [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images) 对象。[getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) 方法必须在所需的 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 类型实例上调用，生成的缩略图比例作为参数传入该方法。
4. 获取幻灯片缩略图后，调用缩略图对象的 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 方法。将生成的文件名和图像格式作为参数传入。

{{% alert color="primary" %}}

**注意**：PPT/PPTX 转 JPG 的转换方式与 Aspose.Slides API 中其他类型的转换不同。对于其他类型，通常使用 [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 方法，而这里需要使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) 方法。

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // 创建全尺寸图像
        var slideImage = sld.getImage(1.0, 1.0);
        // 将图像以 JPEG 格式保存到磁盘
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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


## **使用自定义尺寸将 PowerPoint PPT/PPTX 转换为 JPG**
要更改生成的缩略图和 JPG 图像的尺寸，可以通过将 *ScaleX* 和 *ScaleY* 值传递给 [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) 方法来实现：
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // 定义尺寸
    var desiredX = 1200;
    var desiredY = 800;
    // 获取 X 和 Y 的缩放值
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // 创建全尺寸图像
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // 将图像以 JPEG 格式保存到磁盘
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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


## **在将演示文稿保存为图像时渲染批注**
Aspose.Slides for Node.js via Java 提供了在将幻灯片转换为图像时渲染批注的功能。下面的 JavaScript 代码演示了该操作：
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
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


{{% alert title="Tip" color="primary" %}}
Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid)，等等。
{{% /alert %}}

## **另见**
查看将 PPT/PPTX 转换为图像的其他选项，例如：

- [PPT/PPTX 到 SVG 的转换](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/).

## **常见问题**

**此方法是否支持批量转换？**

是的，Aspose.Slides 允许在一次操作中将多个幻灯片批量转换为 JPG。

**转换是否支持 SmartArt、图表和其他复杂对象？**

是的，Aspose.Slides 能渲染所有内容，包括 SmartArt、图表、表格、形状等。不过，与 PowerPoint 相比，渲染精度可能会有细微差异，尤其是使用自定义或缺失的字体时。

**处理的幻灯片数量是否有限制？**

Aspose.Slides 本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足的错误。