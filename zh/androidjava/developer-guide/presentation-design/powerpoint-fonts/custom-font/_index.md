---
title: 在 Android 上自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "通过 Aspose.Slides for Android 使用 Java 在 PowerPoint 幻灯片中自定义字体，使您的演示在任何设备上保持清晰一致。"
---

{{% alert color="primary" %}} 
Aspose Slides 允许您使用[loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)方法加载这些字体：

* TrueType（.ttf）和 TrueType Collection（.ttc）字体。详见[TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字体。详见[OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿中使用的字体。这会影响导出输出——例如 PDF、图像以及其他支持的格式——从而使生成的文档在不同环境中保持一致。字体会从自定义目录中加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用[FontsLoader.clearCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--)清除字体缓存。

以下代码示例演示了字体加载过程：
```java
// 定义包含自定义字体文件的文件夹。
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// 从指定文件夹加载自定义字体。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // 使用已加载的字体渲染/导出演示文稿（例如，导出为 PDF、图像或其他格式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 在工作完成后清除字体缓存。
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 会向字体搜索路径添加额外的文件夹，但不会更改字体初始化顺序。字体按以下顺序初始化：

1. 默认操作系统字体路径。
1. 通过[FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/)加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**
Aspose.Slides 提供[getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)方法，以便您查找字体文件夹。该方法返回通过`LoadExternalFonts`方法添加的文件夹以及系统字体文件夹。

以下 Java 代码展示了如何使用[getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)：
```java
// 此行输出搜索字体文件的文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
String[] fontFolders = FontsLoader.getFontFolders();
```


## **指定演示文稿使用的自定义字体**
Aspose.Slides 提供[setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)属性，以便您指定将在演示文稿中使用的外部字体。

以下 Java 代码展示了如何使用[setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)属性：
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 对演示文稿进行操作
    // CustomFont1、CustomFont2，以及来自 assets\fonts 和 global\fonts 文件夹及其子文件夹的字体可供演示文稿使用
} finally {
    if (pres != null) pres.dispose();
}
```


## **外部管理字体**

Aspose.Slides 提供[loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)方法，以便您从二进制数据加载外部字体。

以下 Java 代码演示了字节数组字体加载过程：
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 演示文稿生命周期期间加载的外部字体
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **常见问题**

**自定义字体会影响所有格式（PDF、PNG、SVG、HTML）的导出吗？**  
会。连接的字体会被渲染器在所有导出格式中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**  
不会。将字体注册用于渲染并不等同于将其嵌入 PPTX。如果需要将字体随演示文件一起携带，必须使用显式的[嵌入功能](/slides/zh/androidjava/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**  
会。配置[字体替代](/slides/zh/androidjava/font-substitution/)、[替换规则](/slides/zh/androidjava/font-replacement/)和[回退集合](/slides/zh/androidjava/fallback-font/)即可明确指定在请求的字形缺失时使用哪种字体。

**我可以在 Linux/Docker 容器中使用字体而不在系统范围内安装它们吗？**  
会。指向您自己的字体文件夹或从字节数组加载字体，这可以消除容器镜像对系统字体目录的任何依赖。

**关于许可——我可以在没有限制的情况下嵌入任何自定义字体吗？**  
您需自行负责字体许可合规。许可条款各不相同，有的许可禁止嵌入或商业使用。分发输出前，请务必查看字体的最终用户许可协议（EULA）。