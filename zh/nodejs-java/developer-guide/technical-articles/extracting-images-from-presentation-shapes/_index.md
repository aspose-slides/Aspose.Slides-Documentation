---
title: 从演示文稿形状中提取图像
type: docs
weight: 100
url: /zh/nodejs-java/extracting-images-from-presentation-shapes/
keywords: "提取图像, PowerPoint, PPT, PPTX, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中从 PowerPoint 演示文稿提取图像"
---

{{% alert color="primary" %}} 

图像通常添加到形状中，也经常用作幻灯片的背景。图像对象通过[ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/)添加，该集合包含[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)对象。

本文说明了如何提取添加到演示文稿中的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，必须先遍历每个幻灯片，再遍历每个形状以定位图像。找到或确定图像后，即可提取并将其保存为新文件。 
```javascript
function extractImages() {
    const folderPath = "./";
    const pres = new aspose.slides.Presentation(folderPath + "ExtractImages.pptx");
    let img = null;
    let backImage = null;

    let slideIndex = 0;
    let imageType = 0;
    let ifImageFound = false;

    for (let i = 0; i < pres.getSlides().size(); i++) {
        slideIndex++;
        let sl = pres.getSlides().get_Item(i);

        if (sl.getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_Slide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        } else if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_LayoutSlide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        }

        for (let j = 0; j < sl.getShapes().size(); j++) {
            let sh = sl.getShapes().get_Item(j);

            if (java.instanceOf(sh, "com.aspose.slides.IAutoShape")) {
                let ashp = sh;
                if (ashp.getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
                    img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }
            } else if (java.instanceOf(sh, "com.aspose.slides.IPictureFrame")) {
                let pf = sh;
                img = pf.getPictureFormat().getPicture().getImage();
                imageType = getImageTType(img);
                ifImageFound = true;
            }

            if (ifImageFound) {
                const imagePath = folderPath + "backImage_Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                saveImage(img, imagePath, imageType);
            }
            ifImageFound = false;
        }
    }
}

function getImageTType(image) {
    let imageContentType = image.getContentType();
    imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
    imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
    return imageContentType;
}

function capitalize(str) {
    if (!str || str.length <= 1) return str;
    return str.charAt(0).toUpperCase() + str.slice(1);
}

function saveImage(image, path, imageType) {    
    var ImageFormatClass = java.import('com.aspose.slides.ImageFormat');
    let imageTypeValue = java.callStaticMethodSync("com.aspose.slides.ImageFormat", "getValue", ImageFormatClass.class, capitalize(imageType));
    
    image.getImage().save(path, java.newInstanceSync("java.lang.Integer", imageTypeValue.longValue));
    console.log(`Image saved to ${path}`);
}
```


## **FAQ**

**是否可以在不进行裁剪、特效或形状转换的情况下提取原始图像？**

是的。当您访问形状的图像时，会从演示文稿的[image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/)中获取图像对象，这意味着获得的是未裁剪或未添加样式效果的原始像素。工作流遍历演示文稿的 image collection 和[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)对象，这些对象存储原始数据。

**一次保存大量图像时是否存在生成相同文件的风险？**

是的，如果不加区分地全部保存，会出现这种情况。演示文稿的[image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/)可能包含被不同形状或幻灯片引用的相同二进制数据。为避免重复，在写入之前应比较提取数据的哈希值、大小或内容。

**如何确定演示文稿集合中哪些形状链接到特定图像？**

Aspose.Slides 不会存储从[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)到形状的反向链接。请在遍历过程中手动构建映射：每当发现对[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)的引用时，记录使用该图像的形状。

**能否提取嵌入在 OLE 对象（如附件文档）中的图像？**

不能直接提取，因为 OLE 对象是一个容器。需要先提取 OLE 包本身，然后使用其他工具分析其内容。演示文稿的图片形状通过[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)工作；OLE 属于不同的对象类型。