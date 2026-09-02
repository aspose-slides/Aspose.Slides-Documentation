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
- 嵌入式图像
- 链接图像
- 提取图像
- 光栅图像
- SVG 图像
- 裁剪图像
- 删除裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对缩放
- 图像效果
- 宽高比
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: 使用 Aspose.Slides for Android via Java 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。
---
## **概述**

图片框是显示图像的幻灯片形状。在 Aspose.Slides 中，图像资源和显示它的形状是分开的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 通过其 [IImageCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimagecollection/) 拥有嵌入的图像资源，而一个 [IPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像显示多次时，这种分离非常有用。将图像添加到演示文稿一次，保留返回的 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等光栅图像以及 SVG 矢量图像。它们也可以引用链接的图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取和导出行为，因此在应用格式或优化之前决定图像的存储方式很有用。

## **添加并格式化嵌入式图像**

对于嵌入式图像，将图像数据添加到演示文稿并使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 创建图片框。图像成为演示文稿包的一部分，因此将演示文稿移动到另一台计算机时仍保持自包含。

以下示例添加 JPEG 图像，以图像的原始尺寸创建框，并应用线条格式和旋转：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

图片框控制显示的几何形状；更改框的尺寸不会改变嵌入式图像资源中存储的原始像素尺寸。当随后对图像进行裁剪或压缩时，这一点尤为重要。

## **使用相对缩放**

[IPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframe/) 通过 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) 和 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) 提供框的相对宽度和高度缩放。值为 `1.0` 对应原始图片尺寸的 100%。当工作流需要保留与源图像尺寸的关系，而不是手动计算最终尺寸时，相对缩放很有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相对缩放更改框的缩放设置；它不会对嵌入式图像进行重新采样或压缩。

## **嵌入式和链接图像**

嵌入式图片将图像数据存储在演示文稿内部，因此是最安全的可移植性和可预测渲染选择。链接图片则通过 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) 方法存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。链接文件必须对打开或渲染演示文稿的应用程序保持可访问。如果路径更改、文件移动或资源不可用，链接图片可能无法如预期显示。对于必须通过电子邮件发送、归档或在孤立环境中渲染的演示文稿，嵌入式图像通常更可靠。

### **添加链接图像**

以下示例创建一个图片框并指向本地图像文件。它仅处理图像链接；视频链接是另一个媒体工作流，故意未在此示例中混合。

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

当外部文件管理是有意为之时使用链接。不要仅将其作为压缩的替代方案：带有损坏图像依赖的 small PPTX 通常不如更大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿提取图像之前，先检查形状是否真的为 [IPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframe/)，并且它是否包含嵌入式图像。链接图片框可能不包含可按相同方式提取的图像字节。

### **提取光栅图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/)，不需要旧的 Java 图像包装器。以下示例在幻灯片上查找第一个嵌入的光栅图片并将其保存为 PNG：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

通过 [IImage.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 保存会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是转换后的光栅文件，请改用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 暴露一个 [ISvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 对象。这使您可以直接检索 SVG 数据，而无需先对图片进行光栅化。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

将 SVG 内容保持为 SVG 可保留演示文稿中的矢量源。PNG 或 JPEG 等光栅导出必然将该矢量内容渲染为像素。PDF 或 SVG 幻灯片导出同样是渲染操作，因此导出的图形不应视为原始嵌入 SVG 的逐字节副本；当需要原始矢量资源本身时，请使用嵌入的 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/#getSvgData--) 数据。

## **裁剪图像**

裁剪会更改帧内可见的图像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪不会立即从嵌入图像中删除隐藏的像素；它仅更改可见区域。

以下示例安全地查找图片框并应用裁剪值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

由于隐藏的图像数据仍然存在，之后可以更改裁剪而不丢失原始像素。如果文件大小比可逆性更重要，可以按照下一节所述物理删除裁剪区域。

## **删除裁剪的图像数据**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) 删除当前裁剪矩形之外的图像数据并返回生成的图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，已删除的像素不再可用于后续的取消裁剪操作。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

该方法可能向演示文稿添加新的图像资源。如果原始图像也被其他图片框使用，这些框仍需要其现有资源，因此删除裁剪区域不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩光栅图像**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) 根据图片显示的尺寸降低光栅图像分辨率。它还可以在同一操作中删除裁剪区域。当图像被重新调整大小或裁剪时，方法返回 `true`；若无需更改则返回 `false`。

当标准目标分辨率足够时，使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/picturescompression/) 值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

需要特定目标时，可以传入自定义的正 DPI 值，代替预定义值。

压缩仅针对光栅图像。SVG 和元文件内容不会通过此光栅压缩工作流被降低。同样要记住，降低的分辨率和已删除的裁剪区域无法从优化后的演示文稿中恢复。应根据图像实际查看或导出的最大尺寸选择目标分辨率，而不是全局使用最低 DPI。

## **检查图像效果**

图片效果存储在框使用的图片上。图像变换集合可以包含诸如固定 alpha 调制用于透明度、亮度用于明暗对比等效果。下面的示例安全地读取幻灯片上第一个图片框的两种效果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

这些效果改变图像在框中的渲染方式；它们不会改写原始嵌入的图像字节。

## **锁定图片框几何形状**

[IPictureFrameLock](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframelock/) 设置控制对图片框禁用的编辑操作。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) 在调整大小时保持形状的比例。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

锁定适用于图片框形状。它不会强制对源图像进行重新采样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[IPictureFillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/) 上的 stretch-offset 值相对于图片框的边界框定义填充矩形。正百分比产生向内凹进，负百分比产生向外突出。

这不同于裁剪。裁剪值选择源图像的可见部分；stretch offset 改变可见图片填充被拉伸的矩形。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用 stretch offset 进行填充定位。当目标是隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小和导出注意事项**

在图像存储和图片框格式分开处理时，主要的取舍更易管理：

- **嵌入式图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的方式，但大型光栅图像会增加 PPTX 大小和内存消耗。
- **链接图像** 可以保持包更小，但演示文稿依赖于存储路径或位置的外部文件保持可用。
- **裁剪** 最初是非破坏性的。隐藏像素保持嵌入状态，直至明确删除裁剪区域或在压缩时移除。
- **压缩** 可以显著减小超大光栅图像的文件大小，但会牺牲源分辨率。应在确定幻灯片上实际显示尺寸后再应用。
- **SVG 图像** 在需要保持矢量时应保持为 SVG。需要矢量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能重用现有的 [IPPImage] 资源，而不是在演示文稿工作流中反复加载相同文件。

对于大型演示文稿，图像优化通常在有选择地执行时效果最佳：将标志和图表保留为矢量内容，根据实际显示尺寸压缩照片，仅在不需要后续编辑时删除裁剪像素，并且除非依赖管理是部署设计的一部分，否则避免使用外部链接。

## **FAQ**

**图片框和图像资源有什么区别？**

[IPPImage] 表示与演示文稿关联的图像资源。[IPictureFrame] 是幻灯片上的一种形状，用于显示图像，并存储框级的几何和格式设置，如大小、旋转、裁剪值、效果和锁定。

**应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在未访问外部资源的情况下渲染时，请嵌入图像。仅当有意将图像文件保留在 PPTX 之外且外部位置能够可靠维护时，才使用链接图像。

**裁剪本身会减少 PPTX 文件大小吗？**

仅凭裁剪本身不会。普通裁剪设置会隐藏源图像的部分，但保留底层像素。当可以永久丢弃这些像素时，使用 [IPictureFillFormat.deletePictureCroppedAreas] 或带有裁剪区域删除的图像压缩。

**压缩后能恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢弃图像数据。如果以后可能需要高分辨率编辑，请在演示文稿外保留原始源图像。

**如何处理 SVG 图像？**

当矢量保真度重要时，保持 SVG 内容为 SVG。嵌入的 [ISvgImage] 可以直接提取。将幻灯片渲染为 PNG 或 JPEG 等光栅格式会将 SVG 栅格化为幻灯片图像的一部分。

**读取现有幻灯片时如何避免不安全的转换？**

在使用图片框特定成员之前检查形状类型。对 [IPictureFrame] 进行 `instanceof` 检查可避免无效强转，并使代码能够处理不包含图片框的幻灯片。