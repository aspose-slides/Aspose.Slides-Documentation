---
title: 在 JavaScript 中自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 与 Aspose.Slides for Node.js（通过 Java）在 PowerPoint 幻灯片中自定义字体，使您的演示文稿在任何设备上保持清晰一致。"
---

{{% alert color="primary" %}} 

Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载这些字体：

* TrueType (.ttf) 和 TrueType Collection (.ttc) 字体。请参阅 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字体。请参阅 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿中使用的字体。这会影响导出输出——如 PDF、图像以及其他支持的格式——从而使生成的文档在不同环境中保持一致。字体会从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用 [FontsLoader.clearCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/clearcache/) 清除字体缓存。

```js
// 定义包含自定义字体文件的文件夹。
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 从指定的文件夹加载自定义字体。
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // 使用已加载的字体渲染/导出演示文稿（例如，PDF、图像或其他格式）。
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 完成工作后清除字体缓存。
    aspose.slides.FontsLoader.clearCache();
}
```


{{% alert color="info" title="注意" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 会向字体搜索路径添加额外的文件夹，但不会更改字体初始化顺序。字体的初始化顺序如下：

1. 默认的操作系统字体路径。
1. 通过 [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) 加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**
Aspose.Slides 提供了 [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) 方法，允许您查找字体文件夹。此方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

```javascript
// 此行输出搜索字体文件的文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **指定在演示文稿中使用的自定义字体**
Aspose.Slides 提供了 [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 属性，允许您指定将在演示文稿中使用的外部字体。

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // 在演示文稿上工作
    // CustomFont1、CustomFont2，以及来自 assets\fonts 与 global\fonts 文件夹及其子文件夹的字体可供演示文稿使用
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **外部管理字体**

Aspose.Slides 提供了 [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，允许您从二进制数据加载外部字体。

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // 外部字体在演示文稿生命周期期间已加载
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **常见问题**

**自定义字体会影响所有格式（PDF、PNG、SVG、HTML）的导出吗？**

是的。已连接的字体会被渲染器在所有导出格式中使用。

**自定义字体会自动嵌入生成的 PPTX 吗？**

否。为渲染注册字体并不等同于将其嵌入 PPTX。如果需要将字体随演示文稿文件一起携带，必须使用显式的 [嵌入功能](/slides/zh/nodejs-java/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**

是的。通过配置 [字体替换](/slides/zh/nodejs-java/font-substitution/)、[替换规则](/slides/zh/nodejs-java/font-replacement/) 和 [回退集](/slides/zh/nodejs-java/fallback-font/) 来精确定义在请求的字形缺失时使用哪个字体。

**我可以在 Linux/Docker 容器中使用字体而无需在系统范围内安装吗？**

是的。指向您自己的字体文件夹或从字节数组加载字体。这消除对容器镜像中系统字体目录的任何依赖。

**关于许可——我可以在没有限制的情况下嵌入任何自定义字体吗？**

您需自行负责字体许可的合规性。条款各不相同；某些许可证禁止嵌入或商业使用。始终在分发输出之前检查字体的最终用户许可协议（EULA）。