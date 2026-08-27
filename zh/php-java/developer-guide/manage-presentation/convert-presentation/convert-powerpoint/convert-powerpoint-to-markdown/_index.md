---
title: 在 PHP 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/php-java/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿 转 MD
- 幻灯片 转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将演示文稿保存为 Markdown
- 将幻灯片保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- Markdown 图像导出
- CDN 图像链接
- PowerPoint
- 演示文稿
- Markdown
- PHP
- Aspose.Slides
description: "在 PHP 中将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出的位图、元文件和 SVG 图像的保存位置和引用方式。"
---
## **概述**

Aspose.Slides for PHP via Java 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，用于文档编写、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 的风格，控制幻灯片内容的呈现方式，并决定导出图像的存放位置以及生成的 Markdown 如何引用它们。

默认情况下，Markdown 导出仅使用文本输出。若要导出视觉内容，请使用 [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 方法将导出类型设置为 [MarkdownExportType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownexporttype/) 枚举中的 `Sequential` 或 `Visual` 值。`Sequential` 按顺序单独渲染幻灯片项目，而 `Visual` 则将分组的项目保持在一起，以保留它们的视觉关系。`TextOnly` 值不会生成图像资源，因此在该模式下不会调用图像保存回调。

## **将演示文稿转换为 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 方法，并使用 [SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/) 枚举中的 `Md` 值。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **选择 Markdown 风格**

[MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 方法控制输出使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

下面的示例将演示文稿导出为 CommonMark：

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **使用默认本地保存行为导出图像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 类提供了两种方法来配置本地保存的图像：

- [setBasePath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 指定 Markdown 文档及其资源的基目录。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 指定图像子目录。默认值为 `Images`。

下面的示例渲染视觉内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

此行为还在自定义图像保存处理程序返回 `false` 时作为回退。

## **自定义图像保存和 Markdown 链接**

使用 [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 方法注册一个回调，以处理 Markdown 导出期间生成的非 SVG 位图和元文件资源。其 `MarkdownImageSavingHandler` 回调接收 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 对象、其 [ImageFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imageformat/) 值以及生成的 Markdown 链接（作为单元素 Java 字符串数组）。使用提供的格式保存或上传图像，并将 `$link[0]` 替换为必须出现在 Markdown 输出中的引用。

以 SVG 格式生成的资源单独处理。使用 [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 方法注册回调。其 `MarkdownSvgImageSavingHandler` 回调接收一个 [ISvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/isvgimage/) 对象和单元素 Java 字符串数组 `$link`。SVG 没有 `ImageFormat` 参数；请改为使用 [ISvgImage::getSvgData](https://reference.aspose.com/slides/zh/php-java/aspose.slides/isvgimage/) 方法写入或上传其 XML 数据。根据导出模式和视觉分组，源演示文稿中的 SVG 可能会被光栅化或与其他内容合并；生成的非 SVG 资源随后会传递给图像保存回调。当每个导出的视觉资源都需要自定义处理时，请注册这两个回调。

在 PHP via Java 中，用 PHP 类实现每个回调，并使用 `java_closure` 将该对象暴露为相应的 Java 接口。

{{% alert color="info" title="Note" %}}
在加载 `Java.inc` 之前，以启用 `JAVA_PREFER_VALUES` 的方式初始化 PHP/Java Bridge。[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 方法返回 `void`，且桥接的默认流模式无法在该排队调用期间调用 PHP 回调。下面的完整示例包含了所需的初始化。
{{% /alert %}}

处理程序的返回值决定了谁来处理图像：

- 返回 `true` 表示处理程序已保存、上传、转换或以其他方式处理图像，并为 `$link[0]` 分配了有效值。Aspose.Slides 将该值写入 Markdown 文档，并且不执行默认的本地保存。
- 返回 `false` 让 Aspose.Slides 按照由 [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 和 [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 设置的值本地保存图像并生成链接。

{{% alert color="warning" title="Important" %}}
返回 `true` 的处理程序需自行负责图像。如果返回 `true` 时未为 `$link[0]` 分配有效且非空的链接，导出将因 `InvalidOperationException` 而失败。
{{% /alert %}}

### **将图像保存到 CDN 源目录并使用外部 URL**

下面的示例将 `cdn-origin/presentations/quarterly-report` 视为已挂载或同步的 CDN 源目录。每个处理程序提取生成的文件名，将图像保存到该自定义目录，并将生成的本地引用替换为公共 CDN URL。示例本身不执行网络上传：只有在目录作为 CDN 源挂载或其文件已发布到 CDN 后，URL 才有效。若使用对象存储，请将文件系统写入替换为存储 SDK 的上传操作，并在上传成功后再为 `$link[0]` 赋值。

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

位图处理程序特意对小于 128 × 128 像素的图像返回 `false`，因此 Aspose.Slides 会使用默认行为将这些图像保存到 `output/fallback-images`。较大的位图、元文件资源以及 SVG 资源由自定义代码处理。例如，生成的本地引用 `fallback-images/image1.png` 将变为 `https://cdn.example.com/presentations/quarterly-report/image1.png`。处理程序仅在写入文件时使用操作系统路径；写入 Markdown 的链接使用正斜杠并对文件名进行 URL 转义。构建相对链接时也遵循同样的规则：使用 `/`，而不是平台特定的目录分隔符。

## **常见问题**

**一个处理程序能同时处理光栅图像和 SVG 图像吗？**

否。请使用 [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 处理生成的位图和元文件资源，使用 [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 处理以 SVG 形式生成的资源。前者提供 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 对象和 [ImageFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imageformat/) 值；后者提供可通过 [ISvgImage::getSvgData](https://reference.aspose.com/slides/zh/php-java/aspose.slides/isvgimage/) 读取 SVG 数据的 [ISvgImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/isvgimage/) 对象。导出期间被光栅化的源 SVG 将由图像保存回调处理。

**当图像保存处理程序返回 `false` 时会怎样？**

Aspose.Slides 将使用其默认的本地保存行为。图像位置和生成的引用由使用 [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 和 [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/zh/php-java/aspose.slides/markdownsaveoptions/) 设置的值控制。

**处理程序能在不本地保存图像的情况下提供 URL 吗？**

是。处理程序可以将图像上传到对象存储或交给其他服务，随后将得到的 URL 赋给 `$link[0]` 并返回 `true`。处理程序必须自行完成处理；返回 `true` 将阻止默认的本地保存。

**为什么 Markdown 导出会因处理程序抛出 `InvalidOperationException`？**

当处理程序返回 `true` 但未提供有效链接时会出现此异常。请在返回 `true` 之前分配应写入 Markdown 的相对路径或外部 URL。

**图像链接应该使用哪种路径分隔符？**

在 Markdown 链接和 URL 中使用正斜杠 `/`。仅在文件系统路径中使用 `DIRECTORY_SEPARATOR`，随后单独构建或规范化 Markdown 引用。

**Markdown 导出期间超链接会被保留吗？**

是。文本[超链接](/slides/zh/php-java/manage-hyperlinks/)会保留为标准的 Markdown 链接。幻灯片[切换](/slides/zh/php-java/slide-transition/)和[动画](/slides/zh/php-java/powerpoint-animation/)不会被转换。

**可以并行将演示文稿转换为 Markdown 吗？**

可以并行处理不同的演示文稿文件，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例。请遵循[多线程指南](/slides/zh/php-java/multithreading/)，并为每个文件使用单独的实例。