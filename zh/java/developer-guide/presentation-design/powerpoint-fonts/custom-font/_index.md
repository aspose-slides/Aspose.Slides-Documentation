---
title: 在 Java 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/java/custom-font/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 幻灯片中自定义字体，使您的演示在任何设备上保持清晰一致。"
---

{{% alert color="primary" %}} 
Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载这些字体：

* TrueType（.ttf）和 TrueType Collection（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**
Aspose.Slides 允许您加载在演示文稿中渲染的字体，而无需安装这些字体。这些字体从自定义目录加载。

1. 创建 [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) 类的实例，并调用 [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法。
2. 加载将被渲染的演示文稿。
3. 在 [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) 类中 [Clear the cache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--)。

下面的 Java 代码演示了字体加载过程：
```java
// 用于搜索字体的文件夹
String[] folders = new String[] { externalFontsDir };

// 加载自定义字体目录中的字体
FontsLoader.loadExternalFonts(folders);

// 执行一些操作并进行演示/幻灯片渲染
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
Aspose.Slides 提供了 [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) 方法，使您能够查找字体文件夹。此方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

下面的 Java 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--)：
```java
// 此行输出搜索字体文件的文件夹。
// 这些文件夹包括通过 LoadExternalFonts 方法添加的文件夹和系统字体文件夹。
String[] fontFolders = FontsLoader.getFontFolders();
```


## **为演示文稿指定使用的自定义字体**
Aspose.Slides 提供了 [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性，允许您指定将在演示文稿中使用的外部字体。

下面的 Java 代码展示了如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性：
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 与演示文稿一起工作
    // CustomFont1、CustomFont2 和来自 assets\fonts 与 global\fonts 文件夹及其子文件夹的字体均可用于演示文稿
} finally {
    if (pres != null) pres.dispose();
}
```


## **外部管理字体**
Aspose.Slides 提供了 [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，以便从二进制数据加载外部字体。

下面的 Java 代码演示了字节数组字体加载过程：
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 在演示文稿生命周期期间已加载外部字体
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **常见问题**
**自定义字体是否会影响导出到所有格式（PDF、PNG、SVG、HTML）？**  
是的。已连接的字体在所有导出格式的渲染器中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**  
否。注册用于渲染的字体并不等同于将其嵌入到 PPTX 中。如果需要将字体随演示文稿文件一起携带，必须使用显式的 [embedding features](/slides/zh/java/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**  
可以。配置 [font substitution](/slides/zh/java/font-substitution/)、[replacement rules](/slides/zh/java/font-replacement/) 和 [fallback sets](/slides/zh/java/fallback-font/) 以精确定义在请求的字形缺失时使用哪个字体。

**我可以在 Linux/Docker 容器中使用字体而无需系统范围安装吗？**  
可以。指向您自己的字体文件夹或从字节数组加载字体。这消除了容器镜像中对系统字体目录的任何依赖。

**关于许可证——我可以在没有限制的情况下嵌入任何自定义字体吗？**  
您有责任遵守字体许可协议。条款各不相同；某些许可禁止嵌入或商业使用。在分发输出之前，请始终查看字体的 EULA。