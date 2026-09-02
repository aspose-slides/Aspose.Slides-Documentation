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
description: "使用 Aspose.Slides for Java 在 PowerPoint 幻灯片中自定义字体，以确保您的演示在任何设备上保持清晰一致。"
---
## **概述**

Aspose.Slides 允许您在演示文稿中使用自定义字体，而无需在操作系统上安装它们。您可以从自定义文件夹加载字体，通过文档级字体源为特定演示文稿提供字体，或直接从二进制数据加载外部字体。

加载的字体会在渲染或导出演示文稿时使用，例如导出为 PDF、图像以及其他受支持的格式。这有助于在不同环境下保持演示文稿输出的一致性。本文还说明了如何检查 Aspose.Slides 使用的字体文件夹以及在使用外部字体后如何清除字体缓存。

为渲染注册自定义字体与将字体嵌入 PPTX 文件是分开的。如果必须将字体存储在演示文稿本身内部，请显式使用字体嵌入功能。

演示文稿主题可以为不同的书写系统引用不同的字体系列。这些映射仅存储字体名称，不会安装或加载字体文件。请参阅 [Script-Specific Theme Fonts](/slides/zh/java/script-specific-font-mappings/) 以管理这些映射，并使用下面的加载选项使引用的字体可用于一致的渲染。

{{% alert color="info" title="注意" %}}

Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载这些字体：

* TrueType（.ttf）和 TrueType 集合（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不在系统上安装字体的情况下加载演示文稿使用的字体。这会影响导出输出——例如 PDF、图像以及其他受支持的格式——从而使生成的文档在不同环境中保持一致。字体从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh/java/com.aspose.slides/FontsLoader#clearCache--) 清除字体缓存。

下面的代码示例演示了字体加载过程：

```java
import com.aspose.slides.*;

// 定义包含自定义字体文件的文件夹。
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// 从指定的文件夹加载自定义字体。
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // 使用已加载的字体渲染/导出演示文稿（例如，导出为 PDF、图像或其他格式）。
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 工作完成后清除字体缓存。
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="注意" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 会向字体搜索路径添加额外的文件夹，但不会改变字体初始化顺序。字体的初始化顺序如下：

1. 默认操作系统字体路径。
1. 通过 [FontsLoader](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/) 加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**

Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#getFontFolders--) 方法，帮助您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

下面的 Java 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#getFontFolders--)：

```java
import com.aspose.slides.*;

// 此行输出搜索字体文件的文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
String[] fontFolders = FontsLoader.getFontFolders();
```

## **为演示文稿指定使用的自定义字体**

Aspose.Slides 提供 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性，允许您指定将在演示文稿中使用的外部字体。

下面的 Java 代码展示了如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) 属性：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // 与演示文稿一起工作
    // CustomFont1、CustomFont2，以及来自 assets\fonts 与 global\fonts 文件夹及其子文件夹的字体可用于此演示文稿
} finally {
    if (pres != null) pres.dispose();
}
```

## **外部管理字体**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，允许您从二进制数据加载外部字体。

下面的 Java 代码演示了通过字节数组加载字体的过程：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // 演示文稿生命周期内加载的外部字体
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **常见问题**

### 自定义字体是否会影响所有格式的导出（PDF、PNG、SVG、HTML）？

是的。已连接的字体会被渲染器在所有导出格式中使用。

### 自定义字体会自动嵌入生成的 PPTX 吗？

不会。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的[嵌入功能](/slides/zh/java/embedded-font/)。

### 当自定义字体缺少某些字形时，我可以控制回退行为吗？

可以。配置[字体替代](/slides/zh/java/font-substitution/)、[替换规则](/slides/zh/java/font-replacement/)和[回退集合](/slides/zh/java/fallback-font/)，即可精确定义在请求的字形缺失时使用哪种字体。

### 我能在 Linux/Docker 容器中使用字体而无需系统范围安装吗？

可以。指向自定义字体文件夹或从字节数组加载字体即可，这样就不依赖容器镜像中的系统字体目录。

### 关于版权——我可以随意嵌入任何自定义字体吗？

您需要自行负责字体许可证的合规性。许可证条款各不相同，有的禁止嵌入或商业使用。分发输出前请务必查阅字体的最终用户许可协议（EULA）。