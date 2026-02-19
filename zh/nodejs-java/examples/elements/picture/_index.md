---
title: 图片
type: docs
weight: 50
url: /zh/nodejs-java/examples/elements/picture/
keywords:
- 代码示例
- 图片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中处理图片：插入、裁剪、压缩、重新着色，并使用 PPT、PPTX 和 ODP 演示文稿的示例导出图像。"
---
本文演示如何使用 **Aspose.Slides for Node.js via Java** 插入和访问图片。下面的示例从文件读取图像，将其放置在幻灯片上，然后检索它。

## **添加图片**

此代码从文件读取图像，并将其作为图片框插入到第一张幻灯片上。

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // 在第一张幻灯片上插入显示该图像的图片框。
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **访问图片**

此示例确保幻灯片包含图片框，然后访问找到的第一个图片框。

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```