---
title: 在 PHP 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/php-java/custom-font/
keywords:
- 字体
- 自定义字体
- 外部字体
- 加载字体
- 管理字体
- 字体文件夹
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 自定义 PowerPoint 幻灯片中的字体，确保您的演示在任何设备上都保持清晰一致。"
---
## **概述**

Aspose.Slides 允许您在演示文稿中使用自定义字体，而无需在操作系统上安装这些字体。您可以从自定义文件夹加载字体，通过文档级字体源为特定演示文稿提供字体，或直接从二进制数据加载外部字体。

已加载的字体会在渲染或导出演示文稿时使用，例如导出为 PDF、图像以及其他受支持的格式。这有助于在不同环境中保持演示文稿输出的一致性。本文还说明了如何检查 Aspose.Slides 使用的字体文件夹以及在使用外部字体后如何清除字体缓存。

为渲染注册自定义字体与将字体嵌入 PPTX 文件是分开的。如果必须将字体存储在演示文稿本身内，请显式使用字体嵌入功能。

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载这些字体：

* TrueType（.ttf）和 TrueType 集合（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿中使用的字体。这会影响导出输出——如 PDF、图像和其他受支持的格式——从而使生成的文档在各环境中保持一致。字体从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用 [FontsLoader::clearCache](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/#clearCache--) 清除字体缓存。

以下代码示例演示了字体加载过程：

```php
// 定义包含自定义字体文件的文件夹。
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// 从指定的文件夹加载自定义字体。
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // 使用已加载的字体渲染/导出演示文稿（例如导出为 PDF、图像或其他格式）。
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 在完成工作后清除字体缓存。
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 会向字体搜索路径添加额外的文件夹，但不会更改字体初始化顺序。
字体按以下顺序初始化：

1. 默认操作系统字体路径。
1. 通过 [FontsLoader](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/) 加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**

Aspose.Slides 提供了 [getFontFolders](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/#getFontFolders--) 方法，帮助您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

以下 PHP 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/#getFontFolders--)：

```php
# 此行输出搜索字体文件的文件夹。
# 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
$fontFolders = FontsLoader::getFontFolders();
```

## **指定演示文稿使用的自定义字体**

Aspose.Slides 提供了 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 方法，允许您为演示文稿指定将使用的外部字体。

以下 PHP 代码展示了如何使用 [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 方法：

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # 对演示文稿进行操作
    # CustomFont1、CustomFont2，及来自 assets\fonts 与 global\fonts 文件夹及其子文件夹的字体可供演示文稿使用
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **外部管理字体**

Aspose.Slides 提供了 [loadExternalFont](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，允许您从二进制数据加载外部字体。

以下 PHP 代码演示了字节数组字体加载过程：

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # 演示文稿生命周期期间已加载外部字体
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **常见问题**

**自定义字体会影响所有导出格式（PDF、PNG、SVG、HTML）吗？**

是的。已连接的字体会在渲染器中用于所有导出格式。

**自定义字体会自动嵌入生成的 PPTX 吗？**

不会。为渲染注册字体与将其嵌入 PPTX 并不相同。如果需要将字体随演示文稿文件一起携带，必须使用显式的[嵌入功能](/slides/zh/php-java/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**

可以。配置[字体替换](/slides/zh/php-java/font-substitution/)、[替换规则](/slides/zh/php-java/font-replacement/)和[回退集合](/slides/zh/php-java/fallback-font/)，即可明确指定在缺少请求字形时使用哪种字体。

**我可以在 Linux/Docker 容器中使用字体而无需系统范围安装吗？**

可以。指向您自己的字体文件夹或从字节数组加载字体，这样就消除了容器镜像对系统字体目录的依赖。

**关于授权——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需要自行负责字体授权合规性。授权条款各不相同，有些授权禁止嵌入或商业使用。分发