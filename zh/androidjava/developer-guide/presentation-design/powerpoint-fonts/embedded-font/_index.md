---
title: 在 Android 上的演示文稿中嵌入字体
linktitle: 嵌入字体
type: docs
weight: 40
url: /zh/androidjava/embedded-font/
keywords:
- 添加字体
- 嵌入字体
- 字体嵌入
- 获取嵌入字体
- 添加嵌入字体
- 移除嵌入字体
- 压缩嵌入字体
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Java 使用适用于 Android 的 Aspose.Slides 将 TrueType 字体嵌入 PowerPoint 和 OpenDocument 演示文稿，确保在所有平台上精准渲染。"
---

**PowerPoint 中的嵌入字体** 在您希望演示文稿在任何系统或设备上打开时都能正确显示时非常有用。如果您因创意使用了第三方或非标准字体，则更有理由嵌入字体。否则（未嵌入字体），幻灯片上的文本或数字、布局、样式等可能会改变或变成混乱的方框。

[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 类、[FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) 类、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) 类及其接口包含了在 PowerPoint 演示文稿中使用嵌入字体所需的大多数属性和方法。

## **获取和移除嵌入字体**

Aspose.Slides 提供了 [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) 方法（由 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 类公开），帮助您获取（或查找）演示文稿中嵌入的字体。要移除字体，可使用同一类的 [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) 方法。

下面的 Java 代码演示如何获取和移除演示文稿中的嵌入字体：
```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 渲染包含使用嵌入的 "FunSized" 字体的文本框的幻灯片
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // 将图像以 JPEG 格式保存到磁盘
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // 获取所有嵌入的字体
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // 查找 "Calibri" 字体
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // 移除 "Calibri" 字体
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // 渲染演示文稿；"Calibri" 字体被现有字体替换
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // 将图像以 JPEG 格式保存到磁盘
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // 将演示文稿（未嵌入 "Calibri" 字体）保存到磁盘
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **添加嵌入字体**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) 枚举以及 [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 方法的两个重载，您可以选择首选的（嵌入）规则将字体嵌入到演示文稿中。下面的 Java 代码演示如何嵌入并添加字体到演示文稿：
```java
// 加载演示文稿
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // 将演示文稿保存到磁盘
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **压缩嵌入字体**

为了让您压缩演示文稿中嵌入的字体并减小文件大小，Aspose.Slides 提供了由 [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) 类公开的 [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 方法。

下面的 Java 代码演示如何压缩嵌入的 PowerPoint 字体：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**如何判断演示文稿中的特定字体在渲染时即使已嵌入仍会被替换？**

检查字体管理器中的 [substitution information](/slides/zh/androidjava/font-substitution/) 以及 [fallback/substitution rules](/slides/zh/androidjava/fallback-font/)：如果字体不可用或受限，将使用回退字体。

**嵌入像 Arial/Calibri 这样的“系统”字体值得吗？**

通常不需要——这些字体几乎总是可用。但在“精简”环境（Docker、未预装字体的 Linux 服务器）中，为了实现完全可移植，嵌入系统字体可以消除意外替换的风险。