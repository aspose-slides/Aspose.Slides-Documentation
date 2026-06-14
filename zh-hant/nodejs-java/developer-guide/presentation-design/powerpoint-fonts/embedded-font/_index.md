---
title: 使用 JavaScript 在簡報中嵌入字型
linktitle: 嵌入字型
type: docs
weight: 40
url: /zh-hant/nodejs-java/embedded-font/
keywords:
- 新增字型
- 嵌入字型
- 字型嵌入
- 取得嵌入字型
- 新增嵌入字型
- 移除嵌入字型
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 PowerPoint 與 OpenDocument 簡報中嵌入 TrueType 字型，使用 Aspose.Slides for Node.js（透過 Java），確保在所有平台上渲染準確。"
---
## **簡介**

**PowerPoint 中的嵌入式字型** 在您希望簡報在任何系統或裝置上打開時都能正確顯示時非常有用。倘若您因為創意而使用第三方或非標準字型，則更應該將字型嵌入。否則（未嵌入字型時），投影片上的文字或數字、版面配置、樣式等可能會變形或變成令人困惑的方塊。

[FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontsManager) 類別、[FontData](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontdata/) 類別、[Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) 類別以及它們的類別包含您在 PowerPoint 簡報中處理嵌入式字型所需的大多數屬性與方法。

## **取得或移除簡報中的嵌入式字型**

Aspose.Slides 提供了 [getEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) 方法（由 [FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontsManager) 類別公開），讓您取得（或查詢）簡報中嵌入的字型。若要移除字型，則使用同一類別的 [removeEmbeddedFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) 方法。

以下 JavaScript 程式碼示範如何取得與移除簡報中的嵌入式字型：

```javascript
// 實例化一個表示簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // 渲染包含使用嵌入式 "FunSized" 字型的文字框的投影片
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 將影像以 JPEG 格式儲存到磁碟
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // 取得所有嵌入的字型
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // 尋找 "Calibri" 字型
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // 移除 "Calibri" 字型
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // 渲染簡報；"Calibri" 字型會被現有的字型取代
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // 將影像以 JPEG 格式儲存到磁碟
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // 將未嵌入 "Calibri" 字型的簡報儲存到磁碟
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將嵌入式字型加入簡報**

透過使用 [EmbedFontCharacters](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/embedfontcharacters/) 列舉以及 [addEmbeddedFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) 方法的兩個重載，您可以選擇偏好的（嵌入）規則將字型嵌入簡報中。以下 JavaScript 程式碼示範如何嵌入並加入字型至簡報：

```javascript
// 載入簡報
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
    // 將簡報儲存到磁碟
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **壓縮嵌入式字型**

為了讓您壓縮簡報中嵌入的字型並減少檔案大小，Aspose.Slides 提供了 [compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) 方法（由 [Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) 類別公開）。

以下 JavaScript 程式碼示範如何壓縮嵌入的 PowerPoint 字型：

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

## **常見問題**

**如何判斷簡報中即使已嵌入的特定字型仍會在轉譯時被替換？**

請檢查字型管理器中的 [substitution information](/slides/zh-hant/nodejs-java/font-substitution/) 以及 [fallback/substitution rules](/slides/zh-hant/nodejs-java/fallback-font/)：若字型不可用或受限制，系統將使用備援字型。

**嵌入像 Arial / Calibri 這類「系統」字型值得嗎？**

通常不需要——這些字型幾乎總是可用。但在需要完整可移植性的「精簡」環境（如 Docker、未預先安裝字型的 Linux 伺服器）中，嵌入系統字型可消除意外替換的風險。