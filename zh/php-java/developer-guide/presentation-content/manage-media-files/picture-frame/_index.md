---
title: 使用 PHP 管理演示文稿中的图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/php-java/picture-frame/
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
- 删除已裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对比例
- 图像效果
- 长宽比
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是一种用于显示图像的幻灯片形状。在 Aspose.Slides 中，图像资源与显示图像的形状是分离的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 通过其 [ImageCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 拥有嵌入的图像资源，而一个 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

这种分离在同一图像需要显示多次时非常有用。将图像添加到演示文稿一次，保留返回的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG、JPEG 等光栅图像以及 SVG 向量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取和导出行为，因此在应用格式或优化之前，确定图像应如何存储是有意义的。

## **添加和格式化嵌入图像**

对于嵌入图像，先将图像数据添加到演示文稿，然后使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addpictureframe/) 创建图片框。图像成为演示文稿包的一部分，因此演示文稿在移动到另一台计算机时仍是自包含的。

以下示例添加 JPEG 图像，在图像的原始尺寸下创建框，并应用线条格式和旋转：

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

图片框控制显示的几何形状；更改框的大小不会改变嵌入图像资源中存储的原始像素尺寸。当以后进行裁剪或压缩图像时，这一点非常重要。

## **使用相对比例**

[PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 通过 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/setrelativescalewidth/) 和 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/setrelativescaleheight/) 公开相对宽度和高度的缩放。值为 `1.0` 对应原图大小的 100%。当工作流需要保持与源图像尺寸的比例关系而不是手动计算最终尺寸时，使用相对比例非常有用。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

相对比例更改的是框的缩放设置；它不会重新取样或压缩嵌入的图像。

## **嵌入图像和链接图像**

嵌入图片将图像数据存储在演示文稿内部，因此是最安全的可移植性和可预测渲染的选择。链接图片通过 [Picture::setLinkPathLong](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picture/setlinkpathlong/) 方法存储外部位置，而不是以相同方式嵌入图像数据。

链接图像可以降低 PPTX 中存储的图像数据量，但会引入外部依赖。打开或渲染演示文稿的应用程序必须能够访问链接的文件。如果路径更改、文件移动或资源不可用，链接图片可能无法按预期显示。对于必须通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

以下示例创建图片框并指向本地图像文件。它只处理图像链接；视频链接是单独的媒体工作流，故意未在此示例中混合。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在外部文件管理是有意为之时使用链接。不应仅将其作为压缩的替代方案：一个带有损坏图像依赖的体积小的 PPTX 通常不如一个较大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿提取图像之前，先检查形状是否真的为 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/)，并且它包含嵌入图像。链接图片框可能不包含可用来提取的图像字节。

### **提取光栅图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/)。下面的示例查找幻灯片上第一个嵌入的光栅图片并将其保存为 PNG：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

通过 [IImage::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/#save) 保存会将提取的图像转换为请求的输出格式。如果需要的是演示文稿中存储的编码字节而不是已转换的光栅文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 暴露一个 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 对象。这允许直接检索 SVG 数据，而不必先光栅化图片。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

将 SVG 内容保持为 SVG 可以在演示文稿中保留向量源。PNG、JPEG 等光栅导出必然将该向量内容渲染为像素。PDF 或 SVG 幻灯片导出同样是渲染操作，因此导出的图形不应被视为原始嵌入 SVG 的逐字节拷贝；当需要原始向量资源本身时，请使用嵌入的 [SvgImage::getSvgData](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/getsvgdata/) 数据。

## **裁剪图像**

裁剪更改框内可见的图像部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪不会立即从嵌入图像中删除隐藏的像素；它仅更改可见区域。

下面的示例安全地找到图片框并应用裁剪值：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

由于隐藏的图像数据仍然存在，之后可以更改裁剪而不会丢失原始像素。如果文件大小比可逆性更重要，可以按照下一节所述物理删除裁剪区域。

## **删除裁剪后的图像数据**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 会删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，被删除的像素将不再可用于后续的取消裁剪操作。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

此方法可能会向演示文稿添加一个新图像资源。如果原始图像同样被其他图片框使用，这些框仍需要它们现有的资源，因此删除裁剪区域不一定会减少图像总数。使用该方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩光栅图像**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 根据图片显示尺寸相对降低光栅图像分辨率。它还可以在同一次操作中删除裁剪区域。当图像被重新尺寸化或裁剪时返回 `true`，当不需要更改时返回 `false`。

当标准目标分辨率足够时，可使用预定义的 [PicturesCompression](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturescompression/) 值：

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

需要特定目标时，可传入自定义的正 DPI 值而非预定义值。

压缩仅针对光栅图像。SVG 和元文件内容不会通过此光栅压缩工作流减小。同样要记住，降低分辨率和删除裁剪区域后无法从优化后的演示文稿中恢复。应根据图像实际观看或导出的最大尺寸来选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像变换效果**

完整的工作流，包括亮度、对比度、颜色变换、模糊、透明度效果、顺序链、检查、移除以及往返验证，请参阅 [Image Transform Effects](/slides/zh/php-java/image-transform-effects/)。

## **锁定图片框几何形状**

[PictureFrameLock](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframelock/) 设置控制对图片框的哪些编辑操作被禁用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 在调整大小时保持形状的比例。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

锁定作用于图片框形状本身。它不会强制源图像重新取样或永久更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定义相对于图片框边界框的填充矩形。正百分比会从边缘向内缩进，负百分比会向外延伸。

这与裁剪不同。裁剪值决定源图像的哪一部分可见；stretch offset 改变可见图片填充被拉伸到的矩形。

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在需要放置填充时使用 stretch offset；在需要隐藏源图像边缘时使用裁剪属性。

## **存储、文件大小和导出考虑事项**

当图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的选择，但大型光栅图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以让包更小，但演示文稿依赖于外部文件在指定路径或位置保持可用。
- **裁剪** 初始为非破坏性。隐藏的像素会一直嵌入，直到显式删除裁剪区域或在压缩时移除。
- **压缩** 能显著减小超大光栅图像的文件大小，但会牺牲源分辨率。应在确定幻灯片上实际显示尺寸后再应用。
- **SVG 图像** 在需要保持向量完整性时应保持为 SVG。需要向量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 尽可能复用已有的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 资源，而不是在工作流中反复加载相同文件。

对于大型演示文稿，图像优化通常在有选择地进行时最有效：将标志和图表保留为向量内容，根据实际显示尺寸压缩照片，仅在不需要后续编辑时删除裁剪像素，并且除非部署设计中包含依赖管理，否则避免使用外部链接。

## **FAQ**

**图片框和图像资源有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 表示与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 是幻灯片上的一种形状，用于显示图像并存储框级几何和格式信息，例如大小、旋转、裁剪值、效果和锁定。

**应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时，请嵌入图像。仅在有意将图像文件放在 PPTX 之外且能够可靠维护外部位置时才使用链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独的裁剪不会。普通裁剪设置会隐藏图像的部分，但仍保留底层像素。使用 [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 或在压缩时删除裁剪区域，才能永久丢弃这些像素并减小文件。

**压缩后能恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢失图像数据。如果以后可能需要高分辨率编辑，请在演示文稿之外保留原始源图像。

**SVG 图像应如何处理？**

当向量保真度重要时，保持 SVG 内容为 SVG。可以直接提取嵌入的 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/)。将幻灯片渲染为 PNG、JPEG 等光栅格式会将 SVG 光栅化为幻灯片图像的一部分。

**读取现有幻灯片时如何避免不安全的类型转换？**

在使用图片框特定成员之前，先检查形状类型。对 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 进行 `java_instanceof` 检查，可避免无效转换并让代码能够处理不包含图片框的幻灯片。