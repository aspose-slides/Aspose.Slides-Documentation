---
title: 在 JavaScript 中管理腳本特定的主題字型
linktitle: 腳本特定主題字型
type: docs
weight: 15
url: /zh-hant/nodejs-java/script-specific-font-mappings/
keywords:
- 腳本特定字型
- 主題字型映射
- 多語言簡報
- 書寫系統
- 西里爾字型
- 阿拉伯字型
- 日文字型
- 喬治亞字型
- 塔納字型
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 檢查、添加、替換與移除 PowerPoint 主題中的腳本特定字型映射。"
---
## **概觀**

簡報主題可以為不同的書寫系統選擇不同的字型系列。這使得仍使用主題字型的多語言文字能夠遵循統一的字型方案，同時為西里爾文、阿拉伯文、日文、喬治亞文、塔納文及其他文字使用適當的字型。

主題的 [FontScheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 包含一個主要字型集合，通常用於標題，及一個次要字型集合，通常用於正文。除了它們的拉丁文字與東亞文字設定，這兩個集合皆透過 [Fonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/) 類別公開從書寫系統標籤到字型系列名稱的映射。

本文展示如何檢視與修改簡報母版主題中的這些映射，並驗證變更在存檔重新載入的循環中仍然存在。

## **了解腳本標籤**

腳本字型方法使用四字母的 BCP 47 腳本子標籤來識別書寫系統。常見的值包括：

| Script tag | Writing system |
|---|---|
| `Cyrl` | 西里爾文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 喬治亞文 |
| `Thaa` | 塔納文 |

這些映射屬於主題字型方案，而非個別文字段落。簡報可能為主要與次要集合定義不同的映射，也可能對某些腳本省略映射。

## **存取與檢查腳本字型映射**

使用 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/) 取得簡報層級的主題。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 與 [FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontscheme/) 方法會回傳兩個 [Fonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/) 集合。

呼叫 [Fonts.getScriptFontMap](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/) 可取得集合中所有的映射。若要查詢單一書寫系統，請使用其腳本標籤呼叫 [Fonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/)。當該集合未定義請求的映射時，`getScriptFont` 會回傳 `null`。

## **修改映射並驗證持久性**

使用 [Fonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/) 以建立映射或取代目前的字型系列。使用 [Fonts.removeScriptFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/) 以移除映射。

以下的端到端範例讀取所有現有的主要與次要映射，查詢日文的主要字型，變更西里爾文的主要字型，移除塔納文的次要映射，儲存簡報，並重新開啟以驗證兩項變更。為使移除步驟不受初始主題影響，範例會在尚未定義塔納文映射時先建立該映射。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

驗證使用與一般查詢相同的 `null` 行為：在移除後儲存，`getScriptFont("Thaa")` 於次要集合會回傳 `null`。

## **區分主題映射與其他字型設定**

腳本特定的主題映射參與字型選擇，但它們解決的問題與直接文字格式設定、字型替代與回退不同：

| 機制 | 目的 | 變更主題映射的影響 |
|---|---|---|
| 腳本特定主題字型映射 | 為書寫系統選擇主要或次要的主題字型。 | 仍使用相應主題字型的文字可以解析為新映射的字型系列。 |
| 明確指派給文字段落的字型 | 在該段落上固定請求的字型系列，而非依賴主題。 | 該段落可能保持不變，因為其直接格式化會覆寫主題的選擇。 |
| 字型替代 | 當請求的字型不可用或符合替代規則時，取代該字型。 | 它在字型已被請求後才作用；不會重新定義主題的腳本映射。 |
| 字型回退 | 提供所選字型未包含的字形，通常用於特定 Unicode 範圍。 | 它填補缺失的字形覆蓋；不會變更已儲存的主題映射。 |

欲取得關於最後兩種機制的更多資訊，請參閱 [Font Substitution](/slides/zh-hant/nodejs-java/font-substitution/) 與 [Fallback Fonts](/slides/zh-hant/nodejs-java/fallback-font/)。

在 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getmastertheme/) 中變更映射僅會影響仍依賴該主題的有效格式化內容。文字可能改為從母版、版面配置或投影片繼承主題覆寫，或使用明確指派的字型。若可見結果未遵循簡報層級的映射，請檢查這些層級。

## **使映射字型可用並驗證結果**

腳本映射僅儲存字型系列名稱；它不會安裝或載入對應的字型檔案。為確保一致的算繪與匯出，所有映射的字型必須在環境中安裝，或透過自訂來源（例如 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) 或 [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/)）提供給 Aspose.Slides。請參閱 [Custom Fonts](/slides/zh-hant/nodejs-java/custom-font/) 了解可用的載入選項。

驗證已儲存的映射僅能確認主題定義已被保留，並不能證明字型是否可用、包含所有必要字形，或產生預期的版面配置。請將每個必要書寫系統的代表性文字算繪成影像或 PDF，並檢查輸出。此步驟可在簡報發佈前發現缺少的字型、字形覆蓋不完整、回退行為及版面變更。請參閱 [Convert PowerPoint Presentations](/slides/zh-hant/nodejs-java/convert-powerpoint/) 取得算繪與匯出範例。

## **常見問題**

**當腳本未映射時，`getScriptFont` 會回傳什麼？**  
[Fonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/) 當請求的腳本映射未在該主要或次要字型集合中定義時，會回傳 `null`。

**當腳本已存在時，`setScriptFont` 會新增第二個映射嗎？**  
不會。[Fonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fonts/) 會在缺少映射時建立，若相同腳本標籤已存在則取代已映射的字型系列。

**為何變更主題映射未影響某些文字？**  
該文字可能已明確指派字型、透過覆寫繼承了不同的主題，或在算繪時受到替代或回退的影響。簡報層級的腳本映射僅控制仍參考該主題字型集合的有效格式化文字。

**僅儲存與重新開啟就足以驗證多語言輸出嗎？**  
不是。重新開啟只能驗證主題資料的持久性。還需將每個必要書寫系統的代表性文字算繪出來，以確認映射的字型是否可用且包含所需的字形。