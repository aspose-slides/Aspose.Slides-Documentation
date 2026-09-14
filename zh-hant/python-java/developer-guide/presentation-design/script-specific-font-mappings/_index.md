---
title: 透過 Java 在 Python 中管理腳本特定的佈景字型
linktitle: 腳本特定佈景字型
type: docs
weight: 15
url: /zh-hant/python-java/script-specific-font-mappings/
keywords:
- 腳本特定字型
- 佈景字型對映
- 多語系簡報
- 書寫系統
- 西里爾字型
- 阿拉伯字型
- 日文字型
- 喬治亞字型
- 塔納字型
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 於 Python（透過 Java）檢查、新增、取代與移除 PowerPoint 佈景中的腳本特定字型對映。"
---
## **概觀**

簡報佈景主題可以為不同的書寫系統選擇不同的字型族。這使得即使使用主題字型的多語言文字，也能遵循一套協調的字型方案，同時為西里爾文、阿拉伯文、日文、喬治亞文、塔納文以及其他腳本使用適當的字型。

此佈景的[FontScheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontscheme/)包含一個主要字型集合，通常用於標題，與一個次要字型集合，通常用於內文。除了它們的拉丁文與東亞字型設定外，兩個集合皆透過[Fonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/)類別公開從書寫系統標籤到字型族名稱的對映。

本文說明如何檢查與修改簡報主佈景中的這些對映，並驗證變更在儲存後重新載入的循環中仍能保留。

## **了解腳本標籤**

腳本字型方法使用四字母 BCP 47 腳本子標籤來識別書寫系統。常見的值包括：

| 腳本標籤 | 書寫系統 |
|---|---|
| `Cyrl` | 西里爾文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 喬治亞文 |
| `Thaa` | 塔納文 |

這些對映屬於主題字型方案，而非個別文字片段。簡報可能為主要與次要集合定義不同的對映，且可能省略某些腳本的對映。

## **存取與檢查腳本字型對映**

使用[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasterTheme)來存取簡報層級的佈景。[FontScheme.getMajor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontscheme/#getMajor)與[FontScheme.getMinor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontscheme/#getMinor)方法會回傳兩個[Fonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/)集合。

呼叫[Fonts.getScriptFontMap](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/#getScriptFontMap)以取得集合中所有的對映。若要查詢單一書寫系統，請使用其腳本標籤呼叫[Fonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/#getScriptFont)。當該集合未定義請求的對映時，`getScriptFont` 會回傳 `None`。

## **修改對映並驗證持久性**

使用[Fonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/#setScriptFont)來建立對映或取代其目前的字型族。使用[Fonts.removeScriptFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/#removeScriptFont)來移除對映。

以下端對端範例會讀取所有既有的主要與次要對映，查詢日文的主要字型，變更西里爾文的主要字型，移除塔納文的次要對映，儲存簡報，並重新開啟以驗證兩項變更。為了使移除步驟不受初始佈景影響，範例會在尚未定義塔納文對映時先建立一個。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

驗證使用與一般查詢相同的 `None` 行為：在移除後儲存，`getScriptFont("Thaa")` 會對次要集合回傳 `None`。

## **將佈景對映與其他字型設定區分**

腳本特定的佈景對映參與字型選擇，但它們解決的問題與直接文字格式設定、字型替換與回退不同：

| 機制 | 目的 | 變更佈景對映的影響 |
|---|---|---|
| 腳本特定佈景字型對映 | 為書寫系統選取主要或次要佈景字型。 | 仍使用對應佈景字型的文字會解析為新的對映字型族。 |
| 明確指派給文字片段的字型 | 在該片段上固定請求的字型族，而不依賴佈景。 | 該片段可能保持不變，因為直接格式設定會覆寫佈景的選擇。 |
| 字型替換 | 當請求的字型不存在或符合替換規則時，取代該字型。 | 此在字型被請求之後執行；不會重新定義佈景的腳本對映。 |
| 字型回退 | 提供已選取字型未包含的字形，通常針對特定 Unicode 範圍。 | 補足缺少的字形覆蓋；不會變更已儲存的佈景對映。 |

有關最後兩種機制的更多資訊，請參閱[Font Substitution](/slides/zh-hant/python-java/font-substitution/)與[Fallback Fonts](/slides/zh-hant/python-java/fallback-font/)。

在[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getMasterTheme)中變更對映僅影響仍依賴該佈景的實際格式化內容。文字可能改為從母片、版面配置或投影片繼承佈景覆寫，或使用明確指派的字型。當可見結果未遵循簡報層級的對映時，請檢查這些層級。

## **確保對映字型可用並驗證結果**

腳本對映僅儲存字型族名稱；不會安裝或載入相對應的字型檔案。為確保渲染與匯出一致，每個對映的字型必須在環境中安裝，或透過自訂來源提供給 Aspose.Slides，例如[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadExternalFonts)或[LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)。請參閱[Custom Fonts](/slides/zh-hant/python-java/custom-font/)了解可用的載入選項。

驗證已儲存的對映僅能確認佈景定義已被保留。它並不能證明字型可用、包含所有必要字形，或產生預期的版面配置。請將每個必要書寫系統的代表文字渲染為圖像或 PDF，並檢查輸出。此作業可在簡報分發前捕捉缺少的字型、字形覆蓋不完整、回退行為以及版面變更。請參閱[Convert PowerPoint Presentations](/slides/zh-hant/python-java/convert-powerpoint/)了解渲染與匯出範例。

## **常見問題**

**當腳本未被對映時，`getScriptFont` 會回傳什麼？**

[Fonts.getScriptFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/#getScriptFont) 在該主要或次要字型集合未定義請求的腳本對映時，會回傳 `None`。

**當腳本已存在時，`setScriptFont` 會新增第二個對映嗎？**

不會。[Fonts.setScriptFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fonts/#setScriptFont) 會在缺少時建立對映，若已存在相同腳本標籤則取代其字型族。

**為什麼變更佈景對映未改變某些文字？**

文字可能已明確指派字型、透過覆寫繼承了不同的佈景，或在渲染時受到替換或回退的影響。簡報層級的腳本對映僅控制仍依賴該佈景字型集合的文字。

**僅儲存並重新開啟是否足以驗證多語言輸出？**

不夠。重新開啟僅能驗證佈景資料的持久性。還需將每個必要書寫系統的代表文字渲染，確認對映的字型可用且包含所需的字形。