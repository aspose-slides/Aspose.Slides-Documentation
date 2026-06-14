---
title: 使用 Java 在簡報中嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/java/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得已嵌入的字型
- 新增已嵌入的字型
- 移除已嵌入的字型
- 壓縮已嵌入的字型
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 與 OpenDocument 簡報中嵌入 TrueType 字型，確保在所有平台上精確呈現。"
---
## **簡介**

**嵌入式字型於 PowerPoint** 在您希望簡報在任何系統或裝置上開啟時都能正確顯示時非常有用。如果您因為在作品中發揮創意而使用了第三方或非標準字型，那麼更有理由將字型嵌入。否則（未嵌入字型時），投影片上的文字或數字、版面配置、樣式等可能會改變，甚至變成令人困惑的方塊。

[FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager) 類別、[FontData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontdata/) 類別、[Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) 類別以及它們的介面包含了在 PowerPoint 簡報中處理嵌入式字型所需的大多數屬性與方法。

## **取得與移除嵌入式字型**

Aspose.Slides 提供 [getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) 方法（由 [FontsManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontsManager) 類別公開），讓您取得（或查詢）簡報中嵌入的字型。若要移除字型，則使用同一類別的 [removeEmbeddedFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) 方法。

此 Java 程式碼示範如何取得與移除簡報中的嵌入式字型：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // 轉譯包含使用嵌入式 "FunSized" 文字框的投影片
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // 將影像以 JPEG 格式儲存至磁碟
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // 取得所有嵌入的字型
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // 尋找 "Calibri" 字型
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // 移除 "Calibri" 字型
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // 轉譯簡報；"Calibri" 字型將被現有字型取代
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // 將影像以 JPEG 格式儲存至磁碟
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // 將未嵌入 "Calibri" 字型的簡報儲存至磁碟
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **加入嵌入式字型**

使用 [EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/embedfontcharacters/) 列舉以及 [addEmbeddedFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) 方法的兩個重載，您可以選擇偏好的（嵌入）規則將字型嵌入簡報中。以下 Java 程式碼示範如何在簡報中嵌入與加入字型：

```java
// 載入簡報
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

    // 將簡報儲存至磁碟
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **壓縮嵌入式字型**

為了讓您壓縮簡報中嵌入的字型並減少檔案大小，Aspose.Slides 提供 [compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) 方法（由 [Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) 類別公開）。

此 Java 程式碼示範如何壓縮嵌入的 PowerPoint 字型：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**如何判斷簡報中已嵌入的特定字型在渲染時仍會被取代？**

請檢查字型管理員中的 [substitution information](/slides/zh-hant/java/font-substitution/) 以及 [fallback/substitution rules](/slides/zh-hant/java/fallback-font/)：如果字型不可用或受到限制，系統會使用備援字型。

**嵌入像 Arial/Calibri 這類「系統」字型值得嗎？**

通常不需要——它們幾乎隨處可得。但在「精簡」環境（Docker、未預先安裝字型的 Linux 伺服器）中，為了確保完整可移植性，嵌入系統字型可降低意外取代的風險。