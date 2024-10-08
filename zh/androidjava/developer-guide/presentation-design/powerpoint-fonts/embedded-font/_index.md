---
title: 嵌入字体 - PowerPoint Java API
linktitle: 嵌入字体
type: docs
weight: 40
url: /androidjava/embedded-font/
keywords: "字体, 嵌入字体, 添加字体, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中使用 PowerPoint 演示文稿中的嵌入字体"

---

**PowerPoint 中的嵌入字体** 在你希望你的演示文稿在任何系统或设备上正确显示时非常有用。如果你使用了第三方或非标准字体，因为你在工作中发挥了创意，那么你更有理由嵌入你的字体。否则（没有嵌入字体），幻灯片上的文本或数字、布局、样式等可能会变化或变成令人困惑的矩形。

[FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 类、[FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) 类、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) 类及其接口包含了处理 PowerPoint 演示文稿中嵌入字体所需的大多数属性和方法。

## **从演示文稿中获取或移除嵌入字体**

Aspose.Slides 提供了 [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) 方法（由 [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) 类公开），允许你获取（或查找）嵌入演示文稿中的字体。要移除字体，使用 [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) 方法（由同一类公开）。

以下 Java 代码展示了如何从演示文稿中获取和移除嵌入字体：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 渲染一个包含使用嵌入字体“FunSized”的文本框的幻灯片
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //以 JPEG 格式将图像保存到磁盘
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // 获取所有嵌入字体
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // 查找“Calibri”字体
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // 移除“Calibri”字体
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // 渲染演示文稿；“Calibri”字体被现有字体替换
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //以 JPEG 格式将图像保存到磁盘
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // 将不包含嵌入“Calibri”字体的演示文稿保存到磁盘
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **向演示文稿添加嵌入字体**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) 枚举和两个重载的 [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 方法，你可以选择你首选的（嵌入）规则来将字体嵌入到演示文稿中。以下 Java 代码展示了如何向演示文稿中嵌入和添加字体：

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

为了允许你压缩嵌入在演示文稿中的字体并减少其文件大小，Aspose.Slides 提供了 [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 方法（由 [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) 类公开）。

以下 Java 代码展示了如何压缩嵌入的 PowerPoint 字体：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```