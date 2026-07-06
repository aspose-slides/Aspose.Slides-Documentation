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
- 添加图像
- 创建图像
- 提取图像
- 光栅图像
- 矢量图像
- 裁剪图像
- 裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 长宽比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 向 PowerPoint 和 OpenDocument 演示文稿添加图片框。简化工作流程并提升幻灯片设计。"
---
## **介绍**

图片框是一种包含图像的形状——它就像装在框里的图片。

您可以通过图片框向幻灯片添加图像。这样，您可以通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——帮助用户快速从图像创建演示文稿。 
{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [ImagesCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ImageCollection) 添加图像，创建 `PPImage` 对象，用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片的形状对象公开的 `addPictureFrame` 方法，根据图像的宽度和高度创建 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFrame)。  
6. 将包含图片的图片框添加到幻灯片。  
7. 将修改后的演示文稿写入 PPTX 文件。  

下面的 JavaScript 代码演示了如何创建图片框：

```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 实例化 Image 类
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 添加一个图片框，其高度和宽度与图片相同
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

图片框可帮助您快速基于图像创建演示文稿幻灯片。将图片框与 Aspose.Slides 的保存选项结合使用，可对输入/输出操作进行操控，以实现图像格式之间的转换。

## **创建具有相对比例的图片框**

通过调整图像的相对缩放，您可以创建更复杂的图片框。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向演示文稿的图像集合中添加图像。  
4. 通过向与演示文稿对象关联的 [ImagesCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ImageCollection) 添加图像，创建 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PPImage) 对象，用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入 PPTX 文件。  

下面的 JavaScript 代码演示了如何创建具有相对比例的图片框：

```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 实例化 Image 类
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 添加高度和宽度等同于图片的图片框
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 设置相对比例高度和宽度
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **从图片框中提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFrame) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示了如何从文档 “sample.pptx” 中提取图像并以 PNG 格式保存。

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **从图片框中提取 SVG 图像**

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for Node.js via Java 可让您完整保真地检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/)，检查底层的 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以原生 SVG 格式保存到磁盘或流中。

下面的代码示例演示了如何从图片框中提取 SVG 图像：

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **获取图像的透明度**

Aspose.Slides 可让您获取应用于图像的透明度效果。下面的 JavaScript 代码演示了此操作：

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **获取图像的亮度和对比度**

Aspose.Slides 可让您获取应用于图像的亮度和对比度效果。`Luminance` 类（[Luminance](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/luminance/)）表示此图像变换效果。

下面的 JavaScript 代码演示了如何从图片框获取亮度和对比度设置：

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **图片框格式化**

Aspose.Slides 提供多种可应用于图片框的格式化选项。使用这些选项，您可以调整图片框以满足特定需求。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [ImagesCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ImageCollection) 添加图像，创建 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PPImage) 对象，用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过 [ShapeCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addPictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 方法，根据图像的宽度和高度创建 `PictureFrame`。  
6. 将包含图片的图片框添加到幻灯片。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过给出正值或负值来旋转图片框。  
   * 正值顺时针旋转图像。  
   * 负值逆时针旋转图像。  
10. 将图片框（包含图片）再次添加到幻灯片。  
11. 将修改后的演示文稿写入 PPTX 文件。  

下面的 JavaScript 代码演示了图片框格式化过程：

```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 实例化 Image 类
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 添加高度和宽度等同于图片的图片框
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 对 PictureFrameEx 应用一些格式设置
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose 最近推出了一个 [免费拼图制作工具](https://products.aspose.app/slides/zh/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/zh/collage/photo-grid)，都可以使用此服务。 
{{% /alert %}}

## **将图像作为链接添加**

为避免演示文稿体积过大，您可以通过链接方式添加图像（或视频），而不是直接嵌入文件。下面的 JavaScript 代码展示了如何在占位符中添加图像和视频：

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **裁剪图像**

下面的 JavaScript 代码展示了如何裁剪幻灯片中已有的图像：

```javascript
var pres = new aspose.slides.Presentation();
// 创建新的图像对象
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 向幻灯片添加 PictureFrame
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // 裁剪图像（百分比值）
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // 保存结果
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **删除图片框的裁剪区域**

如果想删除框中图像的裁剪区域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 方法。该方法在不需要裁剪时返回原始图像。

下面的 JavaScript 代码演示了此操作：

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 获取第一张幻灯片上的 PictureFrame
    var picFrame = slide.getShapes().get_Item(0);
    // 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // 保存结果
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
`deletePictureCroppedAreas()` 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在已处理的 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 中使用，此设置可降低演示文稿体积；否则，生成的演示文稿中的图像数量会增加。

该方法在裁剪操作中会将 WMF/EMF 元文件转换为光栅 PNG 图像。 
{{% /alert %}}

## **压缩图像**

您可以使用 [PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 方法压缩演示文稿中的图片。此方法根据形状大小和指定分辨率压缩图像，并可选择删除裁剪区域。

它的工作方式类似于 PowerPoint 的 **图片格式 → 压缩图片 → 分辨率** 功能。

下面的 JavaScript 示例演示了如何通过指定目标分辨率并可选删除裁剪区域来压缩演示文稿中的图像：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 使用目标分辨率 150 DPI（网页分辨率）压缩图像并删除裁剪区域。
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // 检查压缩结果。
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

或使用另一个预定义的 DPI 值：

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // 将图像压缩至 96 DPI（邮件分辨率），并删除裁剪区域。
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
该方法根据形状大小和提供的 DPI 将图像转换为较低分辨率。裁剪区域也可被删除以优化文件大小。  
如果图像是元文件（WMF/EMF）或 SVG，则不会应用压缩。JPEG 的质量会根据分辨率略有降低，行为与 PowerPoint 处理高分辨率 JPEG 时相同。 
{{% /alert %}}

## **锁定宽高比**

如果希望包含图像的形状在更改图像尺寸后仍保持宽高比，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 方法设置 *锁定宽高比*。

下面的 JavaScript 代码演示了如何锁定形状的宽高比：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // 设置形状在调整大小时保持宽高比
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
此 *锁定宽高比* 设置仅保持形状本身的宽高比，而不影响其中包含的图像。 
{{% /alert %}}

## **使用 StretchOff 属性**

通过 [PictureFillFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFillFormat) 类的 [setStretchOffsetLeft](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-)、[setStretchOffsetTop](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--)、[setStretchOffsetRight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) 和 [setStretchOffsetBottom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) 方法，可以指定填充矩形。

当为图像指定拉伸时，源矩形会按比例缩放以适应指定的填充矩形。填充矩形的每条边由相对于形状边界框对应边缘的百分比偏移定义。正百分比表示内缩，负百分比表示外伸。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 `AutoShape`。  
4. 创建图像。  
5. 设置形状的填充类型。  
6. 设置形状的图片填充模式。  
7. 添加要填充形状的图像。  
8. 指定图像相对于形状边界框对应边缘的偏移。  
9. 将修改后的演示文稿写入 PPTX 文件。  

下面的 JavaScript 代码演示了使用 StretchOff 属性的过程：

```javascript
// 实例化表示 PPTX 文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 实例化 ImageEx 类
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 添加设置为矩形的 AutoShape
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 设置形状的填充类型
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // 设置形状的图片填充模式
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // 设置用于填充形状的图像
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // 指定图像相对于形状边界框对应边缘的偏移
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // 将 PPTX 文件写入磁盘
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常见问题**

**如何查找 PictureFrame 支持的图像格式？**  
Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 的图像对象，支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的功能重叠。

**添加大量大图像会如何影响 PPTX 大小和性能？**  
嵌入大图像会增加文件大小和内存占用；通过链接图像可以保持演示文稿体积较小，但需要确保外部文件保持可访问。Aspose.Slides 提供通过链接方式添加图像的功能，以减小文件大小。

**如何锁定图像对象以防止意外移动/缩放？**  
对 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/getpictureframelock/)（例如禁用移动或缩放）即可。锁定机制支持多种形状类型，包括 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/)。  

**导出为 PDF/图像时是否保留 SVG 矢量的保真度？**  
Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 中提取原始矢量 SVG。导出为 PDF（/slides/zh/nodejs-java/convert-powerpoint-to-pdf/）或光栅格式（/slides/zh/nodejs-java/convert-powerpoint-to-png/）时，结果可能会根据导出设置被光栅化；但提取行为已验证原始 SVG 仍然保留为矢量。