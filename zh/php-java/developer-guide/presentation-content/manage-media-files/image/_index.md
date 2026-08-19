---
title: 使用 PHP 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/php-java/image/
keywords:
- 添加图像
- 添加图片
- 替换图像
- 图像集合
- 图片框
- 链接图像
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- SVG 转形状
- 外部 SVG 资源
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中添加、复用、链接、替换和管理光栅图像及 SVG 图像。"
---
## **介绍**

Aspose.Slides for PHP via Java 提供了多种处理图像的方式，每种方式都有不同的用途。您可以将图像存储在演示文稿中，在图片框中显示，将其用作幻灯片背景，链接到外部图像，替换共享图像资源，或将 SVG 内容转换为可编辑的形状。

本文重点介绍图像资源以及它们在整个演示文稿中的使用方式。有关对单个图片框进行裁剪、透明度、效果、拉伸以及其他格式设置，请参阅[图片框](/slides/zh/php-java/picture-frame/)。

## **了解图像模型**

以下 API 概念密切相关但不可互换：

- [演示文稿图像集合](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 存储演示文稿使用的图像资源。使用[ImageCollection::addImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 添加图像数据并获取一个[PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/)资源。
- [图片框](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 是在幻灯片、母版或布局上显示图像的形状。使用[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addpictureframe/) 将图像资源放置到幻灯片上。
- 幻灯片背景使用图像作为幻灯片填充的一部分，而不是作为形状。因此它的行为不同于图片框。
- [PPImage::replaceImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 替换图像资源。如果多个演示文稿元素使用该资源，它们全部使用替换后的图像。
- 将 SVG 转换为形状会创建可编辑的幻灯片形状。转换后，内容不再作为单一图片资源进行管理。

典型的工作流程是：将图像数据添加到图像集合，获取一个[PPImage]，然后在一个或多个图片框或填充中使用该资源。

## **添加嵌入图像**

要插入本地图像，加载文件，将其添加到图像集合，并创建使用返回的 `PPImage` 的图片框。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以这种方式添加的图像会嵌入到演示文稿中，因此生成的文件不依赖于原始图像文件的可用性。

### **从网络添加图像**

当图像通过 HTTP 或 HTTPS 可用时，下载其字节，将其添加到演示文稿图像集合，并以与本地图像相同的方式使用返回的图像资源。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在长时间运行的应用程序中，应复用 HTTP 客户端或适合应用程序的连接管理策略，而不是反复创建不必要的网络基础设施。并且在来源不受信任时，需要验证远程 URL、响应大小以及内容类型。

## **在幻灯片之间重复使用图像**

如果同一图像需要使用多次，只需在演示文稿中添加一次，并在创建其他图片框时复用返回的[PPImage]。这样可以避免反复加载相同的源数据，并使共享图像资源与其使用之间的关系更加明确。

对于应自动出现在许多幻灯片上的图形（例如公司徽标），建议将图片框放置在[幻灯片母版](/slides/zh/php-java/slide-master/)或布局上，而不是在每张幻灯片上添加相同的形状。

## **将图像用作幻灯片背景**

背景图像被分配给幻灯片填充；它不是作为图片框形状添加的。当图片需要覆盖整个幻灯片背景且不应像普通幻灯片对象那样被操作时，这种方式非常有用。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

有关更多背景选项，包括母版和布局背景，请参阅[演示文稿背景](/slides/zh/php-java/presentation-background/)。

## **嵌入图像和链接图像**

嵌入图像和链接图像在可移植性和文件大小方面各有取舍：

- **嵌入图像**：图像数据存储在演示文稿内部。演示文稿是自包含的，但文件大小包含图像数据。
- **链接图像**：演示文稿存储指向外部图像的路径或 URL。这样可以减小演示文稿大小，但在打开或渲染演示文稿时必须能够访问外部资源。

可以通过[Picture::setLinkPathLong](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picture/) 为外部路径或 URL 赋值来创建链接图片，而不是嵌入图像数据。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

仅在部署环境能够可靠地访问外部资源时才使用链接图像。对于必须离线工作或在系统之间移动的演示文稿，嵌入图像通常更安全。

## **使用 SVG 图像**

SVG 是矢量格式，适用于需要在不失真情况下缩放的图标、图表和其他图形。Aspose.Slides 同时支持将 SVG 作为图像资源以及作为可编辑幻灯片形状的来源。

### **将 SVG 添加为图像**

创建一个[SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/)，将其添加到图像集合，并在图片框中放置生成的图像资源。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **带有外部资源的 SVG 文件**

SVG 可以引用外部图像、样式表或字体。针对这些情况，[SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 提供接受[ExternalResourceResolver](https://reference.aspose.com/slides/zh/php-java/aspose.slides/externalresourceresolver/) 和基 URI 的构造函数。解析器可以将相对 URI 映射为允许的绝对 URI 并返回对应资源的流。

解析器在 Aspose.Slides 处理 SVG 时提供外部资源，但不会将 SVG 重写为自包含文档。如果 SVG 必须保持可移植，请在 SVG 本身中嵌入所需资源，例如使用 `data:` URI 链接图像。

当 SVG 文件来自不可信来源时，应限制解析器可以访问的协议、文件位置和主机。网络解析器还应实施超时、响应大小限制和内容验证。

### **将 SVG 转换为可编辑形状**

Aspose.Slides 可以将 SVG 转换为一组可编辑的幻灯片形状，类似于对应的 PowerPoint 命令。

![PowerPoint 弹出菜单](img_01_01.png)

使用接受[SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 的[ShapeCollection::addGroupShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addgroupshape/) 重载来执行转换。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

当需要将单个矢量元素编辑为 PowerPoint 形状时使用 SVG 到形状的转换。如果 SVG 只需要显示，保持为图像更简单，并且可以避免创建大量单独的形状。

## **替换现有图像资源**

当需要替换已有的图像资源时，请使用[PPImage::replaceImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/)。这在共享图形（如徽标）特别有用。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果多个图片框、背景、母版或布局使用相同的图像资源，替换该资源会更新所有这些使用位置。如果仅想更改一个图片框，请为该框分配不同的图像，而不是替换共享资源。

`PPImage::replaceImage` 还提供接受字节数组或另一个[PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 的重载。

## **实用图像管理指南**

### **控制演示文稿大小**

大型光栅图像会使演示文稿体积不必要地增大。使用符合预期显示尺寸的源图像，尽可能复用共享图像资源，并避免嵌入同一高分辨率图形的重复副本。

对于已经放置在图片框中的光栅图片，可使用[PictureFillFormat::compressImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picturefillformat/) 根据选定的分辨率和裁剪设置压缩图像数据。这属于图片框处理而非图像集合管理，相关的格式化操作请参阅[图片框](/slides/zh/php-java/picture-frame/)。

### **在嵌入与链接内容之间做选择**

嵌入使演示文稿可移植，因为所有必需的图像数据随文件一起携带。链接可以减小文件大小，但会引入外部依赖。仅在该依赖可接受且可靠时使用链接。

### **复用共享品牌素材**

对于重复出现的徽标、水印或装饰图形，使用单一图像资源并复用它。如果该图形属于演示文稿设计而非幻灯片内容，请将其放置在母版或布局上，以便被相应的幻灯片继承。

### **保持 SVG 资源可移植**

自包含的 SVG 更易于移动并能够一致渲染，优于依赖外部文件或网络资源的 SVG。条件允许时，请在导入 SVG 前嵌入所需资源。仅在需要编辑单个矢量元素时才将 SVG 转换为形状。

### **使用现代跨平台图像 API**

对于新的 PHP via Java 代码，请使用 Aspose.Slides 的[IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 和[Images](https://reference.aspose.com/slides/zh/php-java/aspose.slides/images/) API，取代基于 `java.awt.image.BufferedImage` 的传统公共 API。迁移指南请参阅[现代 API](/slides/zh/php-java/modern-api/)。

WMF 和 EMF 需要特殊考虑。当这些格式通过[IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 传递时，[ImageCollection::addImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 会在插入前将元文件转换为光栅 PNG 表示。如果需要保留元文件数据，请改用基于流的[ImageCollection::addImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagecollection/) 重载。从电子表格或其他产品生成 EMF 内容属于单独的集成工作流，本文不作讨论。

## **常见问题**

**图像集合和图片框有什么区别？**  
图像集合存储可复用的图像资源。图片框是一种幻灯片形状，用于显示这些资源并提供裁剪、效果等图片专属的格式设置。

**如何在所有位置统一替换同一徽标？**  
如果徽标已经作为单一图像资源共享，使用[PPImage::replaceImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 替换该资源。对于全演示文稿的品牌标识，也可以将徽标放在母版或布局上，以减少重复的幻灯片内容。

**为什么链接图像在另一台电脑上消失？**  
链接图片依赖其外部文件或 URL。如果在另一台电脑上无法访问该资源，链接图像将不可用。需要自包含的演示文稿时请嵌入图像。

**插入的 SVG 能否编辑为 PowerPoint 形状？**  
可以。使用[ShapeCollection::addGroupShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addgroupshape/) 将 SVG 转换，生成的组包含可编辑的幻灯片形状，而不是单一的 SVG 图片。

**如何让包含大量图像的演示文稿保持更小？**  
复用共享图像资源，避免使用不必要的大尺寸光栅源，在适当情况下压缩光栅图片，将重复的品牌素材放在母版或布局上，仅在外部依赖可接受时使用链接图像。