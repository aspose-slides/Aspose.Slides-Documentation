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
description: "通过 Java 为 PHP 的 Aspose.Slides 定制 PowerPoint 幻灯片中的字体，确保您的演示在任何设备上都保持清晰一致。"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载以下字体：

* TrueType（.ttf）和 TrueType 集合（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在演示文稿中渲染字体而无需在系统中安装这些字体。字体将从自定义目录加载。

1. 创建 [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) 类的实例并调用 [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法。
2. 加载将要渲染的演示文稿。
3. 在 [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader) 类中 [Clear the cache](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--)。

以下 PHP 代码演示了字体加载过程：
```php
  # 查找字体的文件夹
  $folders = array($externalFontsDir );
  # 加载自定义字体目录中的字体
  FontsLoader->loadExternalFonts($folders);
  # 执行一些工作并进行演示/幻灯片渲染
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # 清除字体缓存
    FontsLoader->clearCache();
  }
```


## **获取自定义字体文件夹**

Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) 方法，帮助您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

以下 PHP 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)：
```php
  # 此行输出搜索字体文件的文件夹。
  # 这些是通过 LoadExternalFonts 方法添加的文件夹以及系统字体文件夹。
  $fontFolders = FontsLoader->getFontFolders();

```


## **指定演示文稿使用的自定义字体**

Aspose.Slides 提供 [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性，以便您指定在演示文稿中使用的外部字体。

以下 PHP 代码展示了如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性：
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
    # 对演示文稿进行操作
    # CustomFont1、CustomFont2，以及来自 assets\fonts 与 global\fonts 文件夹及其子文件夹的字体可供演示文稿使用
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **外部管理字体**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，允许您从二进制数据加载外部字体。

以下 PHP 代码演示了字节数组字体加载过程：
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
      # 在演示文稿生命周期期间加载的外部字体
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **常见问题**

**自定义字体会影响导出到所有格式（PDF、PNG、SVG、HTML）吗？**  
是的。已连接的字体会被渲染器在所有导出格式中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**  
不会。将字体注册用于渲染并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的[嵌入功能](/slides/zh/php-java/embedded-font/)。

**当自定义字体缺少某些字形时，我能控制回退行为吗？**  
可以。通过配置[字体替换](/slides/zh/php-java/font-substitution/)、[替换规则](/slides/zh/php-java/font-replacement/)和[回退集合](/slides/zh/php-java/fallback-font/)，可以明确指定在请求的字形缺失时使用哪种字体。

**我可以在 Linux/Docker 容器中使用字体而无需全系统安装吗？**  
可以。指向自己的字体文件夹或从字节数组加载字体。这消除了容器镜像中对系统字体目录的任何依赖。

**关于许可证——我可以在没有限制的情况下嵌入任何自定义字体吗？**  
您需要自行负责字体许可证的合规性。条款各不相同，有些许可证禁止嵌入或商业使用。在分发输出之前，请务必查看字体的最终用户许可协议（EULA）。