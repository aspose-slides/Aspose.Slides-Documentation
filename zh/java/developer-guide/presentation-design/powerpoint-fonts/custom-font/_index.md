---
title: 在 Java 中使用自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /java/custom-font/
keywords: "字体，自定义字体，PowerPoint 演示文稿，Java，Aspose.Slides for Java"
description: "在 Java 中使用 PowerPoint 自定义字体"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载这些字体：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字体。请参阅 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType (.otf) 字体。请参阅 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您加载无需安装的字体，这些字体会在演示文稿中呈现。字体将从自定义目录加载。

1. 创建 [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) 类的实例，并调用 [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法。
2. 加载将要呈现的演示文稿。
3. 在 [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) 类中 [清除缓存](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--)。

以下 Java 代码演示了字体加载过程：

```java
// 查找字体的文件夹
String[] folders = new String[] { externalFontsDir };

// 加载自定义字体目录中的字体
FontsLoader.loadExternalFonts(folders);

// 执行一些工作并进行演示文稿/幻灯片呈现
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // 清除字体缓存
    FontsLoader.clearCache();
}
```

## **获取自定义字体文件夹**
Aspose.Slides 提供了 [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) 方法，允许您查找字体文件夹。此方法返回通过 `LoadExternalFonts` 方法添加的文件夹和系统字体文件夹。

以下 Java 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--)：

```java
// 这一行输出搜索字体文件的文件夹。
// 这些是通过 LoadExternalFonts 方法添加的文件夹和系统字体文件夹。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **指定与演示文稿一起使用的自定义字体**
Aspose.Slides 提供了 [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性，允许您指定将与演示文稿一起使用的外部字体。

以下 Java 代码展示了如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性：

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 处理演示文稿
    // CustomFont1、CustomFont2 以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体可供演示文稿使用
} finally {
    if (pres != null) pres.dispose();
}
```

## **外部管理字体**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，允许您从二进制数据加载外部字体。

以下 Java 代码演示了字节数组字体加载过程：

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 在演示文稿生命周期内加载的外部字体
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```