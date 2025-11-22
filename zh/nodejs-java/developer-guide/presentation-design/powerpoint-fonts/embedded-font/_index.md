---
title: 嵌入字体 - PowerPoint JavaScript API
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/nodejs-java/embedded-font/
keywords: "字体, 嵌入字体, 添加字体, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中使用 PowerPoint 演示文稿的嵌入字体"
---

**嵌入式字体在 PowerPoint 中** 在您希望演示文稿在任何系统或设备上打开时都能正确显示时非常有用。如果您使用了第三方或非标准字体，因为您在作品中进行了创意设计，那么您更有理由嵌入该字体。否则（如果没有嵌入式字体），幻灯片上的文本或数字、布局、样式等可能会发生变化或变成令人困惑的矩形。

[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) 类、[FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) 类、[Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) 类及其成员包含处理 PowerPoint 演示文稿中嵌入式字体所需的多数属性和方法。

## **获取或移除演示文稿中的嵌入式字体**

Aspose.Slides 提供了由 [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) 类公开的 [getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) 方法，允许您获取（或查明）演示文稿中嵌入的字体。要移除字体，可使用同一类的 [removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) 方法。

下面的 JavaScript 代码演示了如何获取和移除演示文稿中的嵌入式字体：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // 渲染包含使用嵌入式 "FunSized" 文本框的幻灯片
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 将图像以 JPEG 格式保存到磁盘
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // 获取所有嵌入式字体
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // 查找 "Calibri" 字体
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // 移除 "Calibri" 字体
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // 渲染演示文稿；"Calibri" 字体被替换为现有字体
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 将图像以 JPEG 格式保存到磁盘
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // 将演示文稿保存为不包含嵌入的 "Calibri" 字体的文件到磁盘
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **向演示文稿添加嵌入式字体**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) 枚举以及 [addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) 方法的两个重载，您可以选择首选的（嵌入）规则将字体嵌入演示文稿。下面的 JavaScript 代码演示了如何嵌入并向演示文稿添加字体：
```javascript
// 加载演示文稿
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // 将演示文稿保存到磁盘
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **压缩嵌入式字体**

为了帮助您压缩演示文稿中嵌入的字体并减小文件大小，Aspose.Slides 提供了由 [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) 类公开的 [compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) 方法。

下面的 JavaScript 代码演示了如何压缩嵌入的 PowerPoint 字体：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**如何判断即使已嵌入，演示文稿中的特定字体在渲染时仍会被替换？**

在字体管理器中查看 [substitution information](/slides/zh/nodejs-java/font-substitution/) 以及 [fallback/substitution rules](/slides/zh/nodejs-java/fallback-font/)：如果字体不可用或受限，系统将使用回退字体。

**将诸如 Arial、Calibri 等“系统”字体嵌入值得吗？**

通常不需要——这些字体几乎总是可用。但在 “轻量” 环境（Docker、未预装字体的 Linux 服务器）中，为了实现完全可移植性，嵌入系统字体可以消除意外替换的风险。