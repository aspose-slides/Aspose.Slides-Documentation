---
title: 管理 Java 中的腳本特定主題字體
linktitle: 腳本特定主題字體
type: docs
weight: 15
url: /zh-hant/java/script-specific-font-mappings/
keywords:
- 腳本特定字體
- 主題字體對映
- 多語言簡報
- 書寫系統
- 西里爾字體
- 阿拉伯字體
- 日文字體
- 喬治亞字體
- Thaana 字體
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "檢查、添加、取代以及移除 PowerPoint 主題中的腳本特定字體對映，使用 Aspose.Slides for Java。"
---
## **概述**

簡報主題可以為不同的書寫系統選擇不同的字族。這使得仍使用主題字體的多語言文字在使用西里爾文、阿拉伯文、日文、喬治亞文、Thaana 等文字時，仍能遵循同一套協調的字體方案，且使用適合該腳本的字體。

主題的[IFontScheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/)包含主要字體集合，通常用於標題，以及次要字體集合，通常用於正文。除了它們的拉丁字與東亞字設定外，兩個集合皆透過[IFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifonts/)介面提供從書寫系統標籤到字族名稱的對映。

本文示範如何檢查與修改簡報主題中的這些對映，並驗證變更在儲存與重新載入的週期中得以保留。

## **了解腳本標籤**

腳本字體方法使用四個字母的 BCP 47 腳本子標籤來識別書寫系統。常見值包括：

| 腳本標籤 | 書寫系統 |
|---|---|
| `Cyrl` | 西里爾文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 喬治亞文 |
| `Thaa` | Thaana |

這些對映屬於主題字體方案，而非個別文字片段。簡報可以為主要與次要集合定義不同的對映，也可以對某些腳本省略對映。

## **存取與檢查腳本字體對映**

使用[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getMasterTheme--)存取簡報層級的主題。  
[IFontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/#getMajor--)與[IFontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifontscheme/#getMinor--)方法會回傳兩個[IFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ifonts/)集合。

呼叫[IFonts.getScriptFontMap](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fonts/#getScriptFontMap--)以取得集合中所有的對映。若要查詢單一書寫系統，使用[IFonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)並傳入其腳本標籤。當該集合未定義請求的對映時，`getScriptFont` 會回傳 `null`。

## **修改對映並驗證持久性**

使用[IFonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)建立對映或取代目前的字族。使用[IFonts.removeScriptFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-)則可移除對映。

以下端對端範例會讀取所有現有的主要與次要對映、查詢日文主要字體、變更西里爾文主要字體、移除 Thaana 次要對映、儲存簡報，並重新開啟以驗證兩項變更。為了讓移除步驟不受初始主題影響，範例會在未先前定義 Thaana 對映時才建立該對映。

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

驗證使用與普通查詢相同的 `null` 行為：在移除後儲存，`getScriptFont("Thaa")` 於次要集合會回傳 `null`。

## **將主題對映與其他字體設定區分開來**

腳本特定的主題對映會參與字體選擇，但它解決的問題不同於直接的文字格式設定、替換與回退：

| 機制 | 目的 | 變更主題對映的效果 |
|---|---|---|
| 腳本特定的主題字體對映 | 為特定書寫系統選取主要或次要主題字體。 | 仍使用相應主題字體的文字會依新對映的字族解析。 |
| 明確指派給文字片段的字體 | 在該片段上固定請求的字族，而不依賴主題。 | 由於直接格式覆蓋主題選擇，文字可能保持不變。 |
| 字體替換 | 當請求的字體不存在或符合替換規則時，取代該字體。 | 替換發生在字體已被請求之後；不會重新定義主題的腳本對映。 |
| 字體回退 | 為所選字體未涵蓋的字形（常見於特定 Unicode 範圍）提供替代字形。 | 填補缺失的字形，並不會改變已儲存的主題對映。 |

欲取得關於最後兩種機制的更多資訊，請參閱[Font Substitution](/slides/zh-hant/java/font-substitution/)與[Fallback Fonts](/slides/zh-hant/java/fallback-font/)。

變更[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getMasterTheme--) 中的對映僅影響仍依賴該主題的有效格式內容。文字也可能從母版、佈局或投影片繼承主題覆寫，或使用明確指派的字體。當可見結果未遵循簡報層級的對映時，請檢查這些層級。

## **使對映字體可用並驗證結果**

腳本對映僅儲存字族名稱；它不會安裝或載入對應的字體檔。為了獲得一致的渲染與匯出，所有對映的字體必須安裝在執行環境中，或透過自訂來源提供給 Aspose.Slides，例如[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)或[LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--)。請參閱[Custom Fonts](/slides/zh-hant/java/custom-font/)了解可用的載入選項。

驗證已儲存的對映僅能確認主題定義已被保留，並不代表字體已安裝、包含所有必要字形，或產生預期的版面配置。請將每個必需書寫系統的代表性文字渲染為圖像或 PDF，並檢查輸出。此步驟可捕捉缺少字體、字形覆蓋不完整、回退行為與版面變更，避免在簡報發佈前發生問題。相關渲染與匯出範例請參閱[Convert PowerPoint Presentations](/slides/zh-hant/java/convert-powerpoint/)。

## **常見問題**

**當腳本未被對映時，`getScriptFont` 會回傳什麼？**

[IFonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) 於該主要或次要字體集合未定義請求的腳本對映時，回傳 `null`。

**`setScriptFont` 會在腳本已存在時新增第二筆對映嗎？**

不會。[IFonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) 只會在缺少對映時建立，若相同腳本標籤已存在則會取代原有的字族。

**為什麼變更主題對映後，有些文字並未改變？**

該文字可能已明確指派字體、透過覆寫繼承了不同的主題，或在渲染時受到替換或回退的影響。簡報層級的腳本對映僅控制仍依賴該主題字體集合的文字。

**儲存並重新開啟就能驗證多語言輸出嗎？**

不能。重新開啟只能驗證主題資料的持久性。仍需渲染每個必需書寫系統的代表性文字，以確認對映的字體可用且包含必要字形。