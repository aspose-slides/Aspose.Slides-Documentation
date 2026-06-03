---
title: 用 JavaScript 管理演示文稿中的图片框
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
description: "使用 Aspose.Slides for Node.js via Java 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿。简化工作流并提升幻灯片设计。"
---
## **介绍**

图片框是一种包含图像的形状——它就像框中的图片。

您可以通过图片框向幻灯片添加图像。这样，您就可以通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——帮助用户快速从图像创建演示文稿。 

{{% /alert %}} 

## **创建图片框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [ImagesCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ImageCollection) 添加图像，创建一个 `PPImage` 对象，以用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片关联的形状对象公开的 `addPictureFrame` 方法，基于图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PictureFrame)。  
6. 将包含图片的图片框添加到幻灯片。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 JavaScript 代码展示了如何创建图片框：

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

图片框可帮助您快速基于图像创建演示文稿幻灯片。将图片框与 Aspose.Slides 的保存选项结合使用，可对输入/输出操作进行操控，实现图像格式之间的转换。

## **创建具有相对比例的图片框**

通过调整图像的相对缩放，可以创建更复杂的图片框。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将图像添加到演示文稿的图像集合中。  
4. 通过向与演示文稿对象关联的 [ImagesCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ImageCollection) 添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PPImage) 对象，以用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 JavaScript 代码展示了如何创建具有相对比例的图片框：

```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 实例化 Image 类
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 添加与图片等高宽的图片框
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // 设置相对比例的宽度和高度
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

当演示文稿包含放置在 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 形状中的 SVG 图形时，Aspose.Slides for Node.js via Java 可让您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/)，检查底层的 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ppimage/) 是否包含 SVG 内容，然后将该图像以本机 SVG 格式保存到磁盘或流中。

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

Aspose.Slides 允许您获取应用于图像的透明度效果。下面的 JavaScript 代码演示了该操作：

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

## **图片框格式化**

Aspose.Slides 提供多种可应用于图片框的格式化选项。使用这些选项，您可以对图片框进行更改，以满足特定需求。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [ImagesCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ImageCollection) 添加图像，创建一个 [PPImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PPImage) 对象，以用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过 [Shapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ShapeCollection) 对象公开的 [addPictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) 方法，基于图像的宽度和高度创建一个 `PictureFrame`。  
6. 将包含图片的图片框添加到幻灯片。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过提供正值或负值旋转图片框。  
   * 正值顺时针旋转图像。  
   * 负值逆时针旋转图像。  
10. 将包含图片的图片框再次添加到幻灯片。  
11. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 JavaScript 代码演示了图片框格式化过程：

```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 实例化 Image 类
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // 添加与图片等高宽的图片框
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

Aspose 最近推出了免费 [Collage Maker](https://products.aspose.app/slides/zh/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/zh/collage/photo-grid)，可以使用此服务。 

{{% /alert %}}

## **将图像添加为链接**

为避免演示文稿体积过大，您可以通过链接而不是直接嵌入文件的方式添加图像（或视频）。下面的 JavaScript 代码展示了如何向占位符中添加图像和视频：

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

下面的 JavaScript 代码展示了如何裁剪幻灯片中