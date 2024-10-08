---
title: 图片框
type: docs
weight: 10
url: /java/picture-frame/
keywords: "添加图片框，创建图片框，添加图像，创建图像，提取图像，StretchOff 属性，图片框格式，图片框属性，PowerPoint 演示文稿，Java，Aspose.Slides for Java"
description: "在 Java 中向 PowerPoint 演示文稿添加图片框"

---

图片框是一个包含图像的形状——就像框中的一张图片。

您可以通过图片框向幻灯片添加图像。这样，您可以通过格式化图片框来格式化图像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——允许人们快速从图像创建演示文稿。

{{% /alert %}} 

## **创建图片框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 通过将图像添加到与演示对象关联的 [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) 中创建一个 [IPPImage]() 对象，这将用于填充形状。
4. 指定图像的宽度和高度。
5. 通过与引用的幻灯片关联的形状对象公开的 `AddPictureFrame` 方法，基于图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame)。
6. 将包含图片的图片框添加到幻灯片。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码展示了如何创建一个图片框：

```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 实例化图像类
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 添加具有图片等效高度和宽度的图片框
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

图片框允许您快速创建基于图像的演示幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操作输入/输出操作，将图像从一种格式转换为另一种格式。您可能希望查看这些页面：转换 [图像为 JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)；转换 [JPG 为图像](https://products.aspose.com/slides/java/conversion/jpg-to-image/)；转换 [JPG 为 PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)，转换 [PNG 为 JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)；转换 [PNG 为 SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)，转换 [SVG 为 PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

## **以相对比例创建图片框**

通过改变图像的相对缩放，您可以创建一个更复杂的图片框。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向演示文稿图像集合添加一个图像。
4. 通过将图像添加到与演示对象关联的 [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) 中创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，这将用于填充形状。
5. 在图片框中指定图像的相对宽度和高度。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码展示了如何以相对比例创建图片框：

```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 实例化图像类
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 添加与图片高度和宽度相等的图片框
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 设置相对缩放高度和宽度
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **从图片框提取图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) 对象中提取图像并将其保存为 PNG、JPG 和其他格式。下面的代码示例演示了如何从文档 "sample.pptx" 中提取图像并将其保存为 PNG 格式。

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
                IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
                slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
            } finally {
                     if (slideImage != null) slideImage.dispose();
                 }
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **获取图像的透明度**

Aspose.Slides 允许您获取图像的透明度。以下 Java 代码演示了该操作：

```java
Presentation presentation = new Presentation(folderPath + "Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("图片透明度: " + transparencyValue);
    }
}
```

## **图片框格式**

Aspose.Slides 提供许多可以应用于图片框的格式设置选项。使用这些选项，您可以更改图片框以满足特定要求。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 通过将图像添加到与演示对象关联的 [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) 中创建一个 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) 对象，这将用于填充形状。
4. 指定图像的宽度和高度。
5. 通过与引用的幻灯片关联的 [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) 对象公开的 [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，基于图像的宽度和高度创建一个 `PictureFrame`。
6. 将包含图片的图片框添加到幻灯片。
7. 设置图片框的线条颜色。
8. 设置图片框的线条宽度。
9. 通过给定正值或负值旋转图片框。
   * 正值顺时针旋转图像。
   * 负值逆时针旋转图像。
10. 将包含图片的图片框添加到幻灯片。
11. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了图片框格式设置过程：

```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 实例化图像类
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 添加与图片高度和宽度相等的图片框
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 对 PictureFrameEx 应用一些格式设置
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="提示" color="primary" %}}

Aspose 最近开发了一个 [免费的拼贴制作器](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，您可以使用此服务。 

{{% /alert %}}

## **作为链接添加图像**

为了避免演示文稿的文件大小过大，您可以通过链接添加图像（或视频），而不是将文件直接嵌入演示文稿。以下 Java 代码展示了如何将图像和视频添加到占位符中：

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **裁剪图像**

以下 Java 代码展示了如何裁剪幻灯片上现有图像：

```java
Presentation pres = new Presentation();
// 创建新图像对象
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 向幻灯片添加图片框
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // 裁剪图像（百分比值）
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // 保存结果
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 删除图片的裁剪区域

如果您想删除包含在框中的图像的裁剪区域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。此方法返回裁剪后的图像或原始图像（如果不需要裁剪）。

以下 Java 代码演示了该操作：

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 获取第一张幻灯片中的 PictureFrame
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // 保存结果
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法将裁剪后的图像添加到演示文稿图像集合中。如果该图像仅在处理的 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) 中使用，此设置可减小演示文稿的大小。否则，结果演示文稿中的图像数量将增加。

该方法在裁剪操作中将 WMF/EMF 元文件转换为光栅 PNG 图像。

{{% /alert %}}

## **锁定纵横比**

如果您希望包含图像的形状在更改图像尺寸后保持其纵横比，可以使用 [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法设置 *锁定纵横比* 设置。

以下 Java 代码展示了如何锁定形状的纵横比：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // 设置形状以在调整大小时保留纵横比
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

此 *锁定纵横比* 设置仅保留形状的纵横比，而不保留其包含的图像。

{{% /alert %}}

## **使用 StretchOff 属性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 属性，从 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) 类中，您可以指定填充矩形。

当为图像指定拉伸时，源矩形将缩放以适应指定的填充矩形。填充矩形的每个边由与形状边界框相应边的百分比偏移量定义。正百分比指定内嵌，而负百分比指定外嵌。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个矩形 `AutoShape`。 
4. 创建一个图像。
5. 设置形状的填充类型。
6. 设置形状的图片填充模式。
7. 添加一个 set 图像以填充该形状。
8. 指定与形状边界框相应边缘的图像偏移量。
9. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码展示了使用 StretchOff 属性的过程：

```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 实例化图像类
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 添加设置为矩形的 AutoShape
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 设置形状的填充类型
    aShape.getFillFormat().setFillType(FillType.Picture);

    // 设置形状的图片填充模式
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 设置图像以填充形状
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 指定与形状边界框相应边缘的图像偏移量
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // 将 PPTX 文件写入磁盘
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```