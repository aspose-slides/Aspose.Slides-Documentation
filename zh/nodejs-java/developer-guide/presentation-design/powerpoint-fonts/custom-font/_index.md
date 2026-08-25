---
title: 使用 JavaScript 定制 PowerPoint 字体
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
description: "使用 JavaScript 和 Aspose.Slides for Node.js 通过 Java 在 PowerPoint 幻灯片中定制字体，使您的演示文稿在任何设备上保持清晰一致。"
---
## **概述**

Aspose.Slides 允许您在演示文稿中使用自定义字体，而无需在操作系统上安装这些字体。您可以从自定义文件夹加载字体，针对特定演示文稿通过文档级别的字体来源提供字体，或直接从二进制数据加载外部字体。

加载的字体在演示文稿渲染或导出时使用，例如导出为 PDF、图像以及其他支持的格式。这有助于在不同环境中保持演示文稿输出的一致性。本文还说明了如何检查 Aspose.Slides 使用的字体文件夹以及在使用外部字体后如何清除字体缓存。

为渲染注册自定义字体与将字体嵌入 PPTX 文件是分开的。如果必须将字体存储在演示文稿本身中，请明确使用字体嵌入功能。

演示文稿主题可以为各个书写系统引用不同的字体族。这些映射仅存储字体名称，并不安装或加载字体文件。请参阅[脚本特定主题字体](/slides/zh/nodejs-java/script-specific-font-mappings/)以管理映射，并使用下面的加载选项使引用的字体可用于一致的渲染。

{{% alert color="info" title="注意" %}}

Aspose Slides 允许您使用[loadExternalFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)方法加载这些字体：

* TrueType（.ttf）和 TrueType Collection（.ttc）字体。参见[TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType（.otf）字体。参见[OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您在不将字体安装到系统的情况下加载演示文稿使用的字体。这会影响导出输出——如 PDF、图像以及其他支持的格式——从而使生成的文档在不同环境中保持一致。字体从自定义目录加载。

1. 指定一个或多个包含字体文件的文件夹。
2. 调用静态[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)方法从这些文件夹加载字体。
3. 加载并渲染/导出演示文稿。
4. 调用[FontsLoader.clearCache](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/clearcache/)清除字体缓存。

以下代码示例演示了字体加载过程：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 定义包含自定义字体文件的文件夹。
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// 从指定的文件夹加载自定义字体。
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // 使用已加载的字体渲染/导出演示文稿（例如导出为 PDF、图像或其他格式）。
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // 在完成工作后清除字体缓存。
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="注意" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)会向字体搜索路径添加额外的文件夹，但不会改变字体初始化顺序。  
字体按以下顺序初始化：

1. 默认操作系统字体路径。  
1. 通过[FontsLoader](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/)加载的路径。

{{%/alert %}}

## **获取自定义字体文件夹**

Aspose.Slides 提供[getFontFolders](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)方法，帮助您查找字体文件夹。该方法返回通过`LoadExternalFonts`方法添加的文件夹以及系统字体文件夹。

以下 JavaScript 代码展示了如何使用[getFontFolders](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 此行输出搜索字体文件的文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **指定演示文稿使用的自定义字体**

Aspose.Slides 提供[setDocumentLevelFontSources](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)属性，允许您指定将在演示文稿中使用的外部字体。

以下 JavaScript 代码展示了如何使用[setDocumentLevelFontSources](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)属性：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // 处理演示文稿
    // CustomFont1、CustomFont2，及来自 assets\fonts 与 global\fonts 文件夹及其子文件夹的字体可用于演示文稿
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **外部管理字体**

Aspose.Slides 提供[loadExternalFont](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)方法，允许您从二进制数据加载外部字体。

以下 JavaScript 代码演示了字节数组字体加载过程：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // 在演示文稿的生命周期内已加载外部字体
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### 自定义字体会影响所有导出格式（PDF、PNG、SVG、HTML）吗？

会。已连接的字体在所有导出格式的渲染器中使用。

### 自定义字体会自动嵌入生成的 PPTX 吗？

不会。为渲染注册字体与将字体嵌入 PPTX 并非同一操作。如果需要将字体随演示文稿文件一起携带，必须使用显式的[嵌入功能](/slides/zh/nodejs-java/embedded-font/)。

### 当自定义字体缺少某些字形时，我能控制回退行为吗？

可以。配置[字体替代](/slides/zh/nodejs-java/font-substitution/)、[替换规则](/slides/zh/nodejs-java/font-replacement/)和[回退集](/slides/zh/nodejs-java/fallback-font/)即可精确定义在缺少请求字形时使用的字体。

### 我能在 Linux/Docker 容器中使用字体而无需系统范围安装吗？

可以。指向您自己的字体文件夹或从字节数组加载字体，这样即可消除容器镜像对系统字体目录的依赖。

### 关于授权——我可以在没有限制的情况下嵌入任何自定义字体吗？

您必须自行负责字体授权合规性。授权条款各不相同，有些授权禁止嵌入或商业使用。分发输出前，请务必查看该字体的最终用户许可协议（EULA）。