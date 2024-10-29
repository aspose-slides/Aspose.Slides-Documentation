---
title: 自定义PowerPoint字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/php-java/custom-font/
keywords: "字体，自定义字体，PowerPoint演示文稿，Java，Aspose.Slides for PHP via Java"
description: "PowerPoint自定义字体"
---

{{% alert color="primary" %}} 

Aspose Slides允许你使用[loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)方法加载这些字体：

* TrueType (.ttf)和TrueType Collection (.ttc)字体。参见[TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf)字体。参见[OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides允许你加载在演示文稿中渲染的字体，而不必安装这些字体。这些字体是从自定义目录加载的。

1. 创建[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/)类的实例并调用[loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)方法。
2. 加载将被渲染的演示文稿。
3. 在[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader)类中[清除缓存](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--)。

以下PHP代码演示了字体加载过程：

```php
  # 搜索字体的文件夹
  $folders = array($externalFontsDir );
  # 加载自定义字体目录的字体
  FontsLoader->loadExternalFonts($folders);
  # 进行一些工作并执行演示文稿/幻灯片渲染
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
Aspose.Slides提供[getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)方法，允许你查找字体文件夹。该方法返回通过`LoadExternalFonts`方法添加的文件夹和系统字体文件夹。

以下PHP代码向你展示如何使用[getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)：

```php
  # 此行输出搜索字体文件的文件夹。
  # 这些是通过LoadExternalFonts方法添加的文件夹和系统字体文件夹。
  $fontFolders = FontsLoader->getFontFolders();

```

## **指定与演示文稿一起使用的自定义字体**
Aspose.Slides提供[setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)属性，以允许你指定将与演示文稿一起使用的外部字体。

以下PHP代码向你展示如何使用[setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)属性：

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
    # 使用演示文稿
    # CustomFont1、CustomFont2以及来自assets\fonts和global\fonts文件夹及其子文件夹的字体可用于演示文稿
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **外部管理字体**

Aspose.Slides提供[loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)方法，以允许你从二进制数据加载外部字体。

以下PHP代码演示了字节数组字体加载过程：

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
      # 在演示文稿生命周期中加载的外部字体
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```