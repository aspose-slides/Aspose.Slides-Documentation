---
title: 管理 Android 上的腳本特定主題字型
linktitle: 腳本特定主題字型
type: docs
weight: 15
url: /zh-hant/androidjava/script-specific-font-mappings/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java 檢查、加入、取代與移除 PowerPoint 主題中的腳本特定字型映射。"
---
## **概觀**

簡報主題可為不同的書寫系統選擇不同的字型族。這讓仍使用主題字型的多語言文字，能在使用適合西里爾文、阿拉伯文、日文、喬治亞文、塔納文以及其他腳本的字型時，仍遵循同一協調的字型方案。

主題的[IFontScheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/)包含一個主要字型集合，通常用於標題，與一個次要字型集合，通常用於內文。除了它們的拉丁與東亞字型設定外，兩個集合皆透過[IFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifonts/)介面提供從書寫系統標籤到字型族名稱的映射。

本文說明如何檢查與修改簡報母版主題中的這些映射，並驗證變更在儲存與重新載入週期中仍能保留。

## **了解腳本標籤**

腳本字型方法使用四字母 BCP 47 腳本子標籤來識別書寫系統。常見值包括：

| 腳本標籤 | 書寫系統 |
|---|---|
| `Cyrl` | 西里爾文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 喬治亞文 |
| `Thaa` | 塔納文 |

這些映射屬於主題字型方案，而非個別文字片段。簡報可能為主要與次要集合定義不同的映射，也可能省略某些腳本的映射。

## **存取與檢查腳本字型映射**

使用[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getMasterTheme--)存取簡報層級的主題。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/#getMajor--)與[IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifontscheme/#getMinor--)方法分別回傳兩個[IFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifonts/)集合。

呼叫[IFonts.getScriptFontMap](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fonts/#getScriptFontMap--)可取得集合中所有映射。若要查詢單一書寫系統，使用[IFonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)並傳入其腳本標籤。當該集合未定義請求的映射時，`getScriptFont`會回傳 `null`。

## **修改映射並驗證持久性**

使用[IFonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)建立映射或取代現有字型族。使用[IFonts.removeScriptFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-)可移除映射。

以下端對端範例會讀取所有現有的主要與次要映射，查詢日文主要字型，變更西里爾文主要字型，移除塔納文次要映射，儲存簡報後重新開啟以驗證兩項變更。為了讓移除步驟不受原始主題限制，範例會在尚未定義塔納文映射時先建立一筆。

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

驗證使用與普通查詢相同的 `null` 行為：移除後儲存，對次要集合執行 `getScriptFont("Thaa")` 會回傳 `null`。

## **將主題映射與其他字型設定區分開來**

腳本特定的主題映射會參與字型選擇，但它解決的問題與直接文字格式、字型替換與回退機制不同：

| 機制 | 目的 | 變更主題映射的影響 |
|---|---|---|
| 腳本特定主題字型映射 | 為特定書寫系統選取主要或次要主題字型。 | 仍使用對應主題字型的文字會解析為新映射的字型族。 |
| 明確指派給文字片段的字型 | 在該片段上固定請求的字型族，而不依賴主題。 | 直接格式會覆寫主題選擇，文字可能保持不變。 |
| 字型替換 | 在字型不可用或符合替換規則時，取代請求的字型。 | 發生在字型已被請求之後，並不會重新定義主題的腳本映射。 |
| 字型回退 | 為所選字型未包含的字形提供補足，常用於特定 Unicode 範圍。 | 補足缺少的字形，並不會改變已儲存的主題映射。 |

欲取得上述兩種機制的更多資訊，請參閱[Font Substitution](/slides/zh-hant/androidjava/font-substitution/)與[Fallback Fonts](/slides/zh-hant/androidjava/fallback-font/)。

變更[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getMasterTheme--)中的映射，只會影響仍依賴該主題的有效格式內容。文字也可能繼承自母版、版面配置或投影片的主題覆寫，或使用明確指派的字型。當可見結果未遵循簡報層級映射時，請檢查這些層級。

## **使映射字型可用並驗證結果**

腳本映射僅儲存字型族名稱；不會安裝或載入相應的字型檔。為了確保一致的渲染與匯出，所有映射的字型必須已安裝於環境中，或透過自訂來源提供給 Aspose.Slides，例如[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)或[LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--)。請參閱[Custom Fonts](/slides/zh-hant/androidjava/custom-font/)了解可用的載入選項。

驗證已儲存的映射僅能確認主題定義已被保留，並不保證字型可用、包含所有必要字形，或產生預期的版面配置。請將每個必要書寫系統的代表文字渲染為圖片或 PDF，並檢查輸出。這可在簡報分發前偵測缺少字型、字形覆蓋不足、回退行為與版面變更。請參閱[Convert PowerPoint Presentations](/slides/zh-hant/androidjava/convert-powerpoint/)了解渲染與匯出範例。

## **常見問題**

**`getScriptFont` 在腳本未映射時回傳什麼？**

[IFonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) 在所請求的腳本映射未在該主要或次要字型集合中定義時，回傳 `null`。

**`setScriptFont` 在腳本已存在時會新增第二筆映射嗎？**

不會。[IFonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) 在缺少映射時會建立，若相同腳本標籤已存在則會替換該映射的字型族。

**為何變更主題映射後某些文字未改變？**

該文字可能已明確指派字型、透過覆寫繼承了不同的主題，或在渲染時受到替換或回退的影響。簡報層級的腳本映射僅控制仍依賴該主題字型集合的文字。

**僅儲存並重新開啟就能驗證多語言輸出嗎？**

不能。重新開啟只能驗證主題資料的持久性。還需渲染每個必要書寫系統的代表文字，以確認映射的字型可用且包含所需字形。