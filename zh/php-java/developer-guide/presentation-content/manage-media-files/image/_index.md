---
title: 使用 PHP 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/php-java/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 外部 SVG 资源
- SVG 解析器
- 链接的 SVG 图像
- SVG 字体
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- EMF
- SVG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 中简化图像管理，优化性能并自动化工作流。"
---
## **简介**

图像使演示更加生动且具有视觉吸引力。 在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源将图片插入到幻灯片。 类似地，Aspose.Slides 允许以多种方式向演示幻灯片添加图像。

{{% alert title="提示" color="primary" %}} 

Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可让您快速从图像创建演示文稿。 

{{% /alert %}} 

{{% alert title="信息" color="info" %}}

如果您想将图像作为图片框添加——尤其是计划调整大小、应用效果或使用其他标准格式选项——请参阅 [图片框](/slides/zh/php-java/picture-frame/)。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}}

您可以将图像从一种格式转换为另一种格式。请参阅以下页面：转换 [image to JPG](https://products.aspose.com/slides/zh/php-java/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/zh/php-java/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/zh/php-java/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/zh/php-java/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/zh/php-java/conversion/png-to-svg/)、以及 [SVG to PNG](https://products.aspose.com/slides/zh/php-java/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides 支持 JPEG、PNG、BMP、GIF 等流行格式的图像。 

## **将本地存储的图像添加到幻灯片**

您可以将一个或多个存储在计算机上的图像添加到演示幻灯片。以下 PHP 示例代码展示了如何将图像添加到幻灯片：

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **将网络图像添加到幻灯片**

如果要添加到幻灯片的图像未存储在本机上，您可以直接从网络添加。

以下 PHP 示例代码展示了如何从网络将图像添加到幻灯片：

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **将图像添加到幻灯片母版**

幻灯片母版存储并控制主题和布局等信息。当您将图像添加到幻灯片母版时，图像会出现在基于该母版的每张幻灯片上。

以下 PHP 示例代码展示了如何将图像添加到幻灯片母版：

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **将图像用作幻灯片背景**

您可以将图片用作一张或多张幻灯片的背景。详情请参阅 *[将图像设为幻灯片背景](/slides/zh/php-java/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 添加到演示文稿**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 类将 SVG 内容添加到演示文稿。生成的 SVG 图像对象随后可以添加到演示文稿的图像集合中，并用于创建图片框。

以下 PHP 示例导入了一个自包含的 SVG 字符串。该 SVG 中使用的所有图像、样式和其他资源均直接嵌入在 SVG 内容中。

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **导入带有外部资源的 SVG 内容**

从设计工具、图表编辑器、图标系统和 Web 管道导出的 SVG 文件可能会引用存储在 SVG 文档之外的资源。例如，SVG 可以包含诸如 `images/photo.png` 的图像链接、CSS `url(...)` 值或字体 URL。

要导入此类 SVG 内容，需要实现一个 [ExternalResourceResolver](https://reference.aspose.com/slides/zh/php-java/aspose.slides/externalresourceresolver/) 并将其与基 URI 一起传递给相应的 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 构造函数。基 URI 标识 SVG 文档的位置，并用于解析相对链接。

SVG 图像对象提供对已导入 SVG 信息的访问：

- `getSvgContent()` 返回 SVG 标记字符串。
- `getSvgData()` 返回 SVG 内容的字节数组。
- `getBaseUri()` 返回用于相对链接的基 URI。
- `getExternalResourceResolver()` 返回分配给 SVG 图像的解析器。

### **实现外部资源解析器**

解析器具有两个方法：

- `resolveUri` 将基 URI 与相对资源链接组合并返回绝对 URI。当链接无法解析或不被允许时返回 `null`。
- `getEntity` 为绝对资源 URI 返回可读流。当资源缺失、被阻止或不可用时返回 `null`。在适当情况下也可以返回回退流。

以下解析器仅从允许的本地目录加载链接资源。网络资源和超出允许目录的路径将被阻止。对于未解析的图像链接，将返回可选的回退图像。

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // 此解析器有意仅允许本地文件。
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

                // 仅对图像资源使用回退。返回图像流
                // 对缺失的字体或样式表则无效。
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **在 SVG 导入期间解析链接资源**

假设 `assets/diagram.svg` 包含如下相对引用：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 PHP 示例将 SVG 文件 URI 作为基 URI 并提供自定义解析器。解析器将相对图像链接转换为绝对 URI，并在 Aspose.Slides 处理 SVG 时返回包含链接资源的流。

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// 基本 URI 表示 SVG 文档的位置。
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// SVG 图像对象公开源内容、二进制数据、基本 URI 和解析器。
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`SvgImage` 类还提供接受字节数组或输入流的重载，并可同时指定外部资源解析器和基 URI。

{{% alert title="重要" color="warning" %}}

资源解析器在 Aspose.Slides 处理并渲染 SVG 时使外部资源可用。它不会修改原始 SVG 标记，也不会自动将已解析的资源嵌入其中。

当 SVG 图像被添加到演示文稿的图像集合时，PPTX 文件可能同时包含原始 SVG 表示和光栅回退图像。链接资源可以出现在生成的回退图像中，而诸如 `images/photo.png` 的相对链接在存储的 SVG 中保持不变。渲染原生 SVG 表示的应用程序在原始外部资源不可用时可能会省略链接内容。

{{% /alert %}}

### **创建可移植的 SVG 图片**

在创建 `SvgImage` 之前，将 SVG 设为自包含，以使其不依赖外部文件。例如，用包含图像数据的 `data:` URI 替换链接的图像 URL：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必需资源嵌入到 SVG 内容后，创建 `SvgImage`，将其添加到演示文稿的图像集合中，并按前例插入到图片框中。

### **处理缺失或被阻止的资源**

当资源 URI 无效、被禁止或无法解析时，`resolveUri` 应返回 `null`。当资源无法读取时，`getEntity` 应返回 `null`。Aspose.Slides 在可能的情况下将在没有该资源的情况下继续处理 SVG。

可以为缺失的资源返回回退流，但其内容必须与请求的资源类型兼容。例如，仅为缺失的图像返回图像流，而不是为字体或样式表返回图像流。

{{% alert title="安全" color="warning" %}}

不要从不受信任的 SVG 文件解析任意文件路径或不受限制的网络 URL。限制允许的方案、目录和主机。对于网络资源，还应应用连接超时、响应大小限制和内容验证。

{{% /alert %}}

## **将 SVG 转换为形状集合**

Aspose.Slides 可以将 SVG 转换为一组形状，类似于 PowerPoint 中的相应功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [ShapeCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/) 类的 [addGroupShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addgroupshape/) 方法的重载提供，该重载接受一个 [SvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgimage/) 对象作为首个参数。

以下 PHP 示例代码展示了如何使用此方法将 SVG 文件转换为形状集合：

```php
// 源 SVG 文件名。
$svgFileName = "sample.svg";

// 输出演示文件名。
$outPptxPath = "presentation.pptx";

// 创建新演示文稿。
$presentation = new Presentation();
try {
    // 读取 SVG 文件内容。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // 创建 SvgImage 对象。
    $svgImage = new SvgImage($svgContent);

    // 获取幻灯片尺寸。
    $slideSize = $presentation->getSlideSize()->getSize();

    // 将 SVG 图像转换为形状组并按幻灯片尺寸进行缩放。
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // 以 PPTX 格式保存演示文稿。
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **将图像作为 EMF 添加到幻灯片**

Aspose.Slides for PHP via Java 允许您使用 Aspose.Cells 从 Excel 工作表生成 EMF 图像并将其添加到演示幻灯片。

以下 PHP 示例代码展示了如何实现：

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// 将工作簿保存到流中。
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // 按原样添加文件，以便图片保持矢量 EMF 而不是栅格化。
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **替换图像集合中的图像**

Aspose.Slides 允许您替换演示文稿图像集合中存储的图像，包括幻灯片形状使用的图像。本节介绍了更新集合中图像的几种方法。您可以使用原始字节数据、[IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 实例或集合中已存在的另一图像来替换图像。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类加载包含图像的演示文件。
2. 将新图像从文件加载到字节数组中。
3. 使用字节数组将目标图像替换为新图像。
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 对象并使用该对象替换目标图像。
5. 在第三种方法中，将目标图像替换为演示文稿图像集合中已存在的图像。
6. 将修改后的演示保存为 PPTX 文件。

```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation("sample.pptx");
try {
    // 第一种方式。
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 第二种方式。
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // 第三种方式。
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // 将演示文稿保存到文件。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="信息" color="info" %}}

使用 Aspose 的免费 [Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器，您可以轻松为文本添加动画并创建 GIF。

{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素被保留，但最终外观取决于在幻灯片上对 [picture](/slides/zh/php-java/picture-frame/) 的缩放方式以及保存时是否进行了压缩。

**一次性替换数十张幻灯片中的相同徽标的最佳方法是什么？**

将徽标放置在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——所有使用该资源的元素都会随之更新。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，之后各个部件即可使用标准形状属性进行编辑。

**如何一次性将图片设为多张幻灯片的背景？**

在母版幻灯片或相应布局上 [将图像设为背景](/slides/zh/php-java/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止演示文稿因大量图片而变得过大？**

复用单个图像资源而非重复使用，选择合理的分辨率，保存时进行压缩，并在适当的情况下将重复图形保存在母版上。