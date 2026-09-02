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
- 嵌入图像
- 链接图像
- 提取图像
- 栅格图像
- SVG 图像
- 裁剪图像
- 删除已裁剪区域
- 压缩图像
- 拉伸偏移
- 图片框格式化
- 相对比例
- 图像效果
- 宽高比
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是显示图像的幻灯片形状。在 Aspose.Slides 中，图像资源与显示该图像的形状是分离的对象：一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 通过其 [ImageCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 拥有嵌入的图像资源，而 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像需要显示多次时，这种分离非常有用。将图像添加到演示文稿一次，保留返回的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG 或 JPEG 等栅格图像，也可以包含 SVG 矢量图像。它们还可以引用链接的图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取以及导出行为，因此在应用格式或优化之前，决定图像应如何存储是有益的。

## **添加并格式化嵌入图像**

对于嵌入图像，向演示文稿添加图像数据并使用 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addpictureframe/) 创建图片框。图像将成为演示文稿包的一部分，因此将演示文稿移动到另一台计算机时仍然是自包含的。

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

图片框控制显示的几何形状；更改框的大小不会更改嵌入图像资源中存储的原始像素尺寸。当以后进行裁剪或压缩时，这一区别变得重要。

## **使用相对比例**

[PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 通过 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/setrelativescalewidth/) 和 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/setrelativescaleheight/) 暴露框的相对宽度和高度缩放。值 `1.0` 对应原始图片尺寸的 100%。当工作流需要保持与源图像尺寸的比例关系，而不是手动计算最终尺寸时，相对比例非常有用。

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

相对比例更改框的缩放设置；它不会重新采样或压缩嵌入的图像。

## **嵌入和链接图像**

嵌入图片将图像数据存储在演示文稿内部，因此是可移植性和可预测渲染的最安全选择。链接图片则通过 [Picture::setLinkPathLong](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picture/setlinkpathlong/) 方法存储外部路径，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。打开或渲染演示文稿的应用程序必须能够访问该链接文件。如果路径更改、文件被移动或资源不可用，链接图片可能无法按预期显示。对于必须通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

以下示例创建一个图片框并指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，特意未混入此示例。

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

当外部文件管理是有意为之时使用链接。不要仅将其用作压缩的替代方案：一个带有破损图像依赖的“小 PPTX”通常不如一个较大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿提取图像之前，首先检查形状是否实际上是 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 并且它包含嵌入图像。链接图片框可能不包含可用来提取的图像字节。

### **提取栅格图像**

现代图像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/)。以下示例在幻灯片上查找第一个嵌入的栅格图片并将其保存为 PNG：

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

通过 [IImage::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/#save) 保存会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是已转换的栅格文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 暴露出一个 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 对象。这样可以直接检索 SVG 数据，而无需先对图片进行栅格化。

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

将 SVG 内容保持为 SVG 可在演示文稿中保留矢量源。PNG 或 JPEG 等栅格导出必然将该矢量内容渲染为像素。PDF 或 SVG 幻灯片导出也是一种渲染操作，因此导出的图形不应被视为原始嵌入 SVG 的逐字节拷贝；当需要原始矢量资源本身时，请使用嵌入的 [SvgImage::getSvgData](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/getsvgdata/) 数据。

## **裁剪图像**

裁剪更改图像在框内可见的部分。[PictureFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/) 上的裁剪值是源图像尺寸的百分比。裁剪最初并不会删除嵌入图像中的隐藏像素；它仅改变可见区域。

以下示例安全地查找图片框并应用裁剪值：

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

由于隐藏的图像数据仍然存在，裁剪可以在以后更改而不会丢失原始像素。如果文件大小比可逆性更重要，可以按照下一节所述物理删除裁剪区域。

## **删除已裁剪的图像数据**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，被删除的像素将不再可用于后续的“取消裁剪”操作。

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

该方法可能会向演示文稿添加一个新的图像资源。如果原始图像也被其他图片框使用，则这些框仍需其现有资源，因此删除裁剪区域并不一定会减少图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果栅格化为 PNG。

## **压缩栅格图像**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 根据图片显示的尺寸相对降低栅格图像分辨率。它也可以在同一次操作中移除裁剪区域。当图像被重新尺寸化或裁剪时返回 `true`，若未进行任何更改则返回 `false`。

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

如果需要特定目标分辨率，也可以传入自定义的正 DPI 值。

压缩旨在用于栅格图像。SVG 和元文件内容不会通过此栅格压缩工作流被降低。同样要记住，较低的分辨率和已删除的裁剪区域无法从已优化的演示文稿中恢复。应根据实际查看或导出时的最大尺寸来选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像变换效果**

有关覆盖亮度、对比度、颜色变换、模糊、Alpha 效果、有序链、检查、删除以及往返验证的完整工作流，请参阅 [Image Transform Effects](/php-java/image-transform-effects/)。

## **锁定图片框几何形状**

[PictureFrameLock](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframelock/) 设置控制哪些编辑操作被禁用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 在调整大小时保持形状的比例。

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

锁定作用于图片框形状本身，并不会强制对源图像进行重新采样或永久性更改为相同的宽高比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[PictureFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定义相对于图片框边界框的填充矩形。正百分比会从边缘向内收缩，负百分比会向外延伸。

这不同于裁剪。裁剪值决定源图像的哪部分可见；stretch offset 改变可见图片填充被拉伸的矩形。

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

使用 stretch offset 来定位填充位置。若目标是隐藏源图像边缘，请使用裁剪属性。

## **存储、文件大小和导出考虑因素**

当图像存储和图片框格式被分开处理时，主要权衡更容易管理：

- **嵌入图像** 使演示文稿自包含，是共享和服务器端渲染最可靠的方式，但大型栅格图像会增加 PPTX 大小和内存使用。
- **链接图像** 可以保持包体更小，但演示文稿依赖于外部文件在存储路径或位置上保持可用。
- **裁剪** 最初是非破坏性的。隐藏的像素会保留在嵌入中，直到显式删除裁剪区域或在压缩期间移除。
- **压缩** 能显著降低超大栅格图像的文件大小，但会牺牲源分辨率。应在已知幻灯片上实际显示尺寸后再应用。
- **SVG 图像** 在需要保留矢量的情况下应保持为 SVG。需要矢量资源本身时直接提取嵌入的 SVG。栅格幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像** 应尽可能复用已有的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 资源，而不是在工作流中反复加载同一文件。

对于大型演示文稿，图像优化通常在有选择地执行时效果最佳：保持标志和图表为矢量内容，根据实际显示尺寸压缩照片，仅在不需要后续编辑时删除裁剪像素，并且除非依赖管理是部署设计的一部分，否则避免使用外部链接。

## **FAQ**

**图片框与图像资源之间有什么区别？**

[PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 表示与演示文稿关联的图像资源。[PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 是幻灯片上的形状，用于显示图像并存储框级几何和格式，例如大小、旋转、裁剪值、效果和锁定。

**我应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在无法访问外部资源的情况下渲染时，请嵌入图像。仅在有意将图像文件保持在 PPTX 之外且可以可靠维护外部位置时才链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独裁剪不会。普通裁剪设置隐藏源图像的部分，但保留底层像素。要永久删除这些像素，请使用 [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 或在图像压缩时移除裁剪区域。

**压缩后还能恢复图像质量吗？**

不能。压缩可能降低存储的栅格分辨率，删除裁剪区域会丢弃图像数据。如果以后需要高分辨率编辑，请在演示文稿外保留原始源图像。

**SVG 图像应如何处理？**

当矢量保真度重要时，保持 SVG 内容为 SVG。嵌入的 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 可以直接提取。将幻灯片渲染为 PNG、JPEG 等栅格格式会将 SVG 栅格化为幻灯片图像的一部分。

**读取现有幻灯片时如何避免不安全的转换？**

在使用图片框特定成员之前检查形状类型。针对 [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 的 `java_instanceof` 检查可避免无效转换，并让代码能够处理不包含图片框的幻灯片。