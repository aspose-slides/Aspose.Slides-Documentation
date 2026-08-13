---
title: 在 Android 上管理演示文稿中的图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/androidjava/picture-frame/
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
- 已裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 宽高比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android (Java) 向 PowerPoint 和 OpenDocument 演示文稿添加图片框。简化工作流程并提升幻灯片设计。"
---
## **简介**

图片框是一种包含图像的形状——它就像一个装在框中的图片。

您可以通过图片框向幻灯片添加图像。这样，您可以通过格式化图片框来格式化图像。

{{% alert title="提示" color="info" %}} 
Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——帮助用户快速把图像转换为演示文稿。 
{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IImageCollection) 添加图像，创建 [IPPImage]() 对象，以用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片关联的形状对象公开的 `AddPictureFrame` 方法，基于图像的宽度和高度创建 [PictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/PictureFrame)。  
6. 将包含图片的图片框添加到幻灯片中。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

以下 Java 代码演示如何创建图片框：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 实例化 Image 类
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 添加一个图片框，其高度和宽度与图片等同
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **创建带相对比例的图片框**

通过调整图像的相对缩放，可以创建更复杂的图片框。  

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向演示文稿的图像集合中添加图像。  
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IImageCollection) 添加图像，创建 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPPImage) 对象，以用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

以下 Java 代码演示如何创建带相对比例的图片框：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 实例化 Image 类
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // 添加图片框，其高度和宽度与图片等效
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // 设置相对比例的宽度和高度
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // 将 PPTX 文件写入磁盘
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **从图片框中提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/PictureFrame) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 "sample.pptx" 中提取图像并保存为 PNG 格式。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **从图片框中提取 SVG 图像**

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for Android（Java）可让您完整保真地检索原始矢量图像。获取其中包含 SVG 内容的 [PictureFrame] 的 [IPPImage] 后，您可以读取该 SVG 图像并以原生 SVG 格式保存到磁盘或流中。

以下代码示例演示如何从图片框中提取 SVG 图像：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **获取图像的透明度**

Aspose.Slides 允许获取应用于图像的透明度效果。以下 Java 代码演示此操作：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **获取图像的亮度和对比度**

Aspose.Slides 允许获取应用于图像的亮度和对比度效果。[ILuminance](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iluminance/) 接口表示此图像变换效果。

以下 Java 代码演示如何从图片框获取亮度和对比度设置：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **图片框格式化**

Aspose.Slides 提供大量可应用于图片框的格式化选项。使用这些选项，您可以修改图片框以满足特定需求。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IImageCollection) 添加图像，创建 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPPImage) 对象，以用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过 [IShapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection) 对象公开的 [AddPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 方法，基于图像的宽度和高度创建 `PictureFrame`。  
6. 将包含图片的图片框添加到幻灯片中。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过提供正值或负值来旋转图片框。  
   * 正值使图像顺时针旋转。  
   * 负值使图像逆时针旋转。  
10. 将包含图片的图片框添加到幻灯片中。  
11. 将修改后的演示文稿写入为 PPTX 文件。  

以下 Java 代码演示图片框格式化过程：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 实例化 Image 类
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 添加图片框，其高度和宽度与图片等同
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

{{% alert title="提示" color="info" %}} 
Aspose 最近推出了一个 [免费拼贴制作工具](https://products.aspose.app/slides/zh/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/zh/collage/photo-grid)，均可使用此服务。 
{{% /alert %}} 

## **将图像添加为链接**

为避免演示文稿文件过大，您可以通过链接方式添加图像（或视频），而不是直接嵌入文件。以下 Java 代码展示如何将图像和视频添加到占位符中：

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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

以下 Java 代码演示如何裁剪幻灯片上的现有图像：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// 创建新的图像对象
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
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
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **删除图片的裁剪区域**

如果要删除框中图像的裁剪区域，可以使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法。若无需裁剪，该方法将返回裁剪后的图像或原始图像。

以下 Java 代码演示此操作：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 获取第一张幻灯片上的 PictureFrame
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
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理过的 [PictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pictureframe/) 中使用，则此设置可以减小演示文稿大小。否则，生成的演示文稿中的图像数量会增加。

该方法在裁剪操作中会将 WMF/EMF 元文件转换为光栅 PNG 图像。 
{{% /alert %}} 

## **压缩图像**

您可以使用 [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 方法压缩演示文稿中的图片。该方法根据形状大小和指定的分辨率降低图像尺寸，并可选择删除裁剪区域。

它的工作方式类似于 PowerPoint 中的 **图片格式 > 压缩图片 > 分辨率** 功能。

下面的 Java 示例演示如何通过指定目标分辨率并可选删除裁剪区域来压缩演示文稿中的图像：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 使用目标分辨率 150 DPI（网络分辨率）压缩图像并删除裁剪区域。
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // 检查压缩结果。
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

或者直接使用自定义 DPI 值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // 压缩图像至 150 DPI（网络分辨率），并删除裁剪区域。
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 
该方法会根据形状的大小和提供的 DPI 将图像转换为较低分辨率。也可以删除裁剪区域以优化文件大小。  
如果图像是元文件（WMF/EMF）或 SVG，则不进行压缩。JPEG 图像的质量将依据分辨率保持不变或略有降低，这与 PowerPoint 对高分辨率 JPEG 的处理方式相同。 
{{% /alert %}} 

## **锁定宽高比**

如果希望包含图像的形状在更改图像尺寸后仍保持宽高比，可以使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 方法设置 *锁定宽高比* 选项。

以下 Java 代码演示如何锁定形状的宽高比：

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // 设置形状在调整大小时保持宽高比
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 
此 *锁定宽高比* 设置仅保持形状的宽高比，而不影响其所包含的图像。 
{{% /alert %}} 

## **使用 StretchOff 属性**

通过使用 [IPictureFillFormat] 接口和 [PictureFillFormat] 类中的 [StretchOffsetLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) 属性，您可以指定填充矩形。

当为图像指定拉伸时，源矩形会按比例缩放以适应指定的填充矩形。填充矩形的每一边由相对于形状边界框对应边缘的百分比偏移量定义。正百分比表示向内缩进，负百分比表示向外突出。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 `AutoShape`。  
4. 创建图像。  
5. 设置形状的填充类型。  
6. 设置形状的图片填充模式。  
7. 添加设置的图像以填充形状。  
8. 指定图像相对于形状边界框对应边缘的偏移量。  
9. 将修改后的演示文稿写入为 PPTX 文件。  

以下 Java 代码演示使用 StretchOff 属性的过程：

```java
import com.aspose.slides.*;

// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 实例化 ImageEx 类
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 添加一个设置为 Rectangle 的 AutoShape
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // 设置形状的填充类型
    aShape.getFillFormat().setFillType(FillType.Picture);

    // 设置形状的图片填充模式
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // 设置用于填充形状的图像
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 指定图像相对于形状边界框对应边缘的偏移量
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // 将 PPTX 文件写入磁盘
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题**

### 如何了解 PictureFrame 支持的图像格式？

Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pictureframe/) 的图像对象，支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的功能相吻合。

### 添加大量大图像会如何影响 PPTX 大小和性能？

嵌入大图像会增加文件大小和内存占用；通过链接方式添加图像可降低演示文稿大小，但需确保外部文件保持可访问。Aspose.Slides 提供了以链接方式添加图像的功能，以减小文件体积。

### 如何锁定图像对象防止意外移动/缩放？

可对 [PictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--)（例如禁用移动或缩放）来锁定图像对象。该锁定机制支持包括 [PictureFrame] 在内的多种形状类型。

### 导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得以保留？

Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pictureframe/) 中提取原始 SVG 矢量。对演示文稿进行 [导出为 PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/) 或 [导出为光栅格式](/slides/zh/androidjava/convert-powerpoint-to-png/) 时，结果可能会根据导出设置被光栅化；但提取行为确认原始 SVG 仍以矢量形式存储。