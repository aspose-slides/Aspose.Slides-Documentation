---
title: JavaScript 中的自定义 PowerPoint 字体
linktitle: 自定义字体
type: docs
weight: 20
url: /zh/nodejs-java/custom-font/
keywords: "字体, 自定义字体, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript 中的 PowerPoint 自定义字体"
---

{{% alert color="primary" %}} 
Aspose Slides 允许您使用 [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法加载这些字体：

* TrueType（.ttf）和 TrueType Collection（.ttc）字体。参见 [TrueType](https://en.wikipedia.org/wiki/TrueType)。

* OpenType（.otf）字体。参见 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

{{% /alert %}}

## **加载自定义字体**

Aspose.Slides 允许您加载在演示文稿中渲染的字体，而无需安装这些字体。字体会从自定义目录加载。

1. 创建 [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) 类的实例并调用 [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) 方法。
2. 加载将要渲染的演示文稿。
3. 在 [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader) 类中 [Clear the cache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader#clearCache--)。

以下 JavaScript 代码演示了字体加载过程：
```javascript
// 查找字体的文件夹
var folders = java.newArray("java.lang.String", [externalFontsDir]);
// 加载自定义字体目录中的字体
aspose.slides.FontsLoader.loadExternalFonts(folders);
// 执行一些工作并进行演示/幻灯片渲染
var pres = new aspose.slides.Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
    // 清除字体缓存
    aspose.slides.FontsLoader.clearCache();
}
```


## **获取自定义字体文件夹**
Aspose.Slides 提供了 [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) 方法，让您查找字体文件夹。该方法返回通过 `LoadExternalFonts` 方法添加的文件夹以及系统字体文件夹。

以下 JavaScript 代码展示了如何使用 [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):
```javascript
// 此行输出搜索字体文件的文件夹。
// 这些文件夹是通过 LoadExternalFonts 方法添加的以及系统字体文件夹。
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **指定演示文稿使用的自定义字体**
Aspose.Slides 提供了 [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 属性，以便您指定将在演示文稿中使用的外部字体。

以下 JavaScript 代码展示了如何使用 [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) 属性：
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // 在演示文稿上工作
    // CustomFont1、CustomFont2，以及来自 assets\fonts & global\fonts 文件夹及其子文件夹的字体，可供演示文稿使用
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **外部管理字体**
Aspose.Slides 提供了 [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) 方法，以便您从二进制数据加载外部字体。

以下 JavaScript 代码演示了字节数组字体加载过程：
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // 演示文稿生命周期内已加载外部字体
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **常见问题**

**自定义字体是否会影响导出到所有格式（PDF、PNG、SVG、HTML）？**  
是的。已连接的字体会在渲染器中用于所有导出格式。

**自定义字体是否会自动嵌入生成的 PPTX 中？**  
否。将字体注册用于渲染并不等同于将其嵌入 PPTX。如果需要将字体嵌入演示文稿文件中，必须使用显式的 [embedding features](/slides/zh/nodejs-java/embedded-font/)。

**当自定义字体缺少某些字形时，我可以控制回退行为吗？**  
可以。通过配置 [font substitution](/slides/zh/nodejs-java/font-substitution/)、[replacement rules](/slides/zh/nodejs-java/font-replacement/) 和 [fallback sets](/slides/zh/nodejs-java/fallback-font/) 来明确指定在请求的字形缺失时使用哪种字体。

**我可以在 Linux/Docker 容器中使用字体而无需在系统范围内安装吗？**  
可以。指向您自己的字体文件夹或从字节数组加载字体。这消除了容器镜像中对系统字体目录的任何依赖。

**关于许可证—我可以在没有限制的情况下嵌入任何自定义字体吗？**  
您需自行负责字体许可证的合规性。条款各不相同，有些许可证禁止嵌入或商业使用。分发输出前请务必查看字体的 EULA。