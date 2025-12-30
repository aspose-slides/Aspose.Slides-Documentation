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
description: "使用 Aspose.Slides for PHP via Java 自定义 PowerPoint 幻灯片中的字体，让您的演示在任何设备上都保持清晰一致。"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载以下字体：

* TrueType（.ttf）和 TrueType Collection（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿中使用的字体。这会影响导出输出——例如 PDF、图像以及其他受支持的格式——从而使生成的文档在不同环境中保持一致。字体将从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。  
2. 调用静态 [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) 方法从这些文件夹加载字体。  
3. 加载并渲染/导出演示文稿。  
4. 调用 [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/) 清除字体缓存。

以下代码示例演示了字体加载过程：
```php
// 定义包含自定义字体文件的文件夹。
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// 从指定文件夹加载自定义字体。
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // 使用已加载的字体渲染/导出演示文稿（例如，导出为 PDF、图像或其他格式）。
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // 工作完成后清除字体缓存。
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="注意" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) 会向字体搜索路径添加额外的文件夹，但不会改变字体初始化顺序。  
字体按以下顺序初始化：

1. 默认操作系统字体路径。  
1. 通过 [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) 加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**
Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) 方法，帮助您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

下面的 PHP 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)：
```php
  # 此行输出搜索字体文件的文件夹。
  # 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
  $fontFolders = FontsLoader->getFontFolders();
```


## **指定演示文稿使用的自定义字体**
Aspose.Slides 提供 [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性，允许您指定将在演示文稿中使用的外部字体。

下面的 PHP 代码展示了如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性：
```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if (!java_is_null($dis1)) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if (!java_is_null($dis2)) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(array("assets/fonts", "global/fonts" ));
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    # 与演示文稿一起工作
    # CustomFont1、CustomFont2，以及来自 assets\fonts & global\fonts 文件夹及其子文件夹的字体可用于演示文稿
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **外部管理字体**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，允许您从二进制数据加载外部字体。

下面的 PHP 代码演示了字节数组字体加载过程：
```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      # 在演示生命周期期间加载的外部字体
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **常见问题**

**自定义字体会影响所有格式（PDF、PNG、SVG、HTML）的导出吗？**

会。已连接的字体会被渲染器在所有导出格式中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**

不会。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的 [嵌入功能](/slides/zh/php-java/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**

可以。配置 [字体替换](/slides/zh/php-java/font-substitution/)、[替换规则](/slides/zh/php-java/font-replacement/) 和 [回退集](/slides/zh/php-java/fallback-font/) 可精确定义在请求的字形缺失时使用的字体。

**我可以在 Linux/Docker 容器中使用字体而无需在系统范围内安装吗？**

可以。指向您自己的字体文件夹或从字节数组加载字体，即可消除容器镜像对系统字体目录的依赖。

**关于许可——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需自行负责字体许可合规性。许可条款各异，有些禁止嵌入或商业使用。分发输出前请务必查看字体的 EULA。