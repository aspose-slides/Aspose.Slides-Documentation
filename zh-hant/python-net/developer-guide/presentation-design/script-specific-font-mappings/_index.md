---
title: 在 Python 中管理腳本特定的主題字型
linktitle: 腳本特定的主題字型
type: docs
weight: 15
url: /zh-hant/python-net/script-specific-font-mappings/
keywords:
- 腳本特定字型
- 主題字型對映
- 多語言簡報
- 書寫系統
- 西里爾字型
- 阿拉伯字型
- 日文字型
- 喬治亞字型
- 塔安字型
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 PowerPoint 主題中使用 Aspose.Slides for Python (透過 .NET) 檢查、加入、替換與移除腳本特定的字型對映。"
---
## **概觀**

簡報主題可以為不同的書寫系統選擇不同的字型系列。這讓仍使用主題字型的多語言文字能在使用適合的西里爾字、阿拉伯字、日文、喬治亞字、塔安字等字型時，仍遵循同一協調的字型方案。

主題的[FontScheme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/fontscheme/)包含主要字型集合（通常用於標題）與次要字型集合（通常用於正文）。除了它們的拉丁與東亞字型屬性外，兩個集合皆透過[Fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/)類別提供從書寫系統標籤到字型系列名稱的對映。

本文說明如何在簡報的主題母版中檢查與修改這些對映，並驗證變更在儲存與重新載入的循環中仍然存在。

## **了解腳本標籤**

腳本字型方法使用四個字母的 BCP 47 子標籤來識別書寫系統。常見值包括：

| 腳本標籤 | 文字系統 |
|---|---|
| `Cyrl` | 西里爾文 |
| `Arab` | 阿拉伯文 |
| `Hans` | 簡體中文 |
| `Jpan` | 日文 |
| `Geor` | 喬治亞文 |
| `Thaa` | 塔安文 |

這些對映屬於主題字型方案，而非個別文字段落。簡報可能為主要與次要集合定義不同的對映，亦可能對某些腳本未定義對映。

## **存取與檢查腳本字型對映**

使用[Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/)存取簡報層級的主題。`FontScheme.major`與`FontScheme.minor`屬性回傳兩個[Fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/)集合。

呼叫[Fonts.get_script_font_map](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/get_script_font_map/)取得集合中所有的對映。若要查詢單一書寫系統，使用[Fonts.get_script_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/get_script_font/)並傳入其腳本標籤。當該集合未定義請求的對映時，`get_script_font`會回傳 `None`。

## **修改對映並驗證持久性**

使用[Fonts.set_script_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/set_script_font/)建立對映或取代目前的字型系列。使用[Fonts.remove_script_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/remove_script_font/)移除對映。

以下端對端範例會讀取所有既有的主要與次要對映，查找日文的主要字型，變更西里爾文的主要字型，移除塔安文的次要對映，儲存簡報，然後重新開啟以驗證兩項變更。為了使移除步驟不受初始主題影響，範例會在未先前定義塔安文對映時先建立一筆對映。

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

驗證使用與一般查詢相同的 `None` 行為：移除後儲存，`get_script_font("Thaa")` 於次要集合會回傳 `None`。

## **區分主題對映與其他字型設定**

腳本特定的主題對映會參與字型選取，但它解決的問題與直接文字格式、置換與回退不同：

| 機制 | 目的 | 變更主題對映時的影響 |
|---|---|---|
| Script-specific theme font mapping | 為書寫系統選取主要或次要主題字型。 | 仍使用對應主題字型的文字會解析為新對映的字型系列。 |
| Font assigned explicitly to a text portion | 在該段落上直接指定字型系列，而非依賴主題。 | 直接格式會覆寫主題選擇，段落可能保持不變。 |
| Font substitution | 當請求的字型不可用或符合置換規則時，替換為其他字型。 | 在字型已被請求後才發生，並不重新定義主題的腳本對映。 |
| Font fallback | 為選取的字型缺少的字形提供補充，通常針對特定 Unicode 範圍。 | 填補缺失的字形，未改變已儲存的主題對映。 |

欲了解最後兩種機制，請參閱[Font Substitution](/slides/zh-hant/python-net/font-substitution/)與[Fallback Fonts](/slides/zh-hant/python-net/fallback-font/)。

變更[Presentation.master_theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/master_theme/)僅會影響仍依賴該主題的有效格式內容。文字可能改為從母版、版面配置或投影片的主題覆寫繼承，或使用明確指派的字型。當可見結果未遵循簡報層級的對映時，請檢查這些層級。

## **確保對映字型可用並驗證結果**

腳本對映只儲存字型系列名稱，並不安裝或載入相應的字型檔案。為了在渲染與匯出時保持一致，每個對映的字型必須於執行環境中安裝，或透過自訂來源（例如[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/load_external_fonts/)或[LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/document_level_font_sources/)）提供給 Aspose.Slides。請參考[Custom Fonts](/slides/zh-hant/python-net/custom-font/)取得可用的載入方式。

驗證已儲存的對映僅能確認主題定義已保留，並不保證字型可用、包含所有必要字形，或產生預期的版面。請針對每個必需的書寫系統渲染代表性文字為影像或 PDF，並檢查輸出。此步驟可在簡報發佈前捕捉缺少字型、字形覆蓋不完整、回退行為與版面變更等問題。請參閱[Convert PowerPoint Presentations](/slides/zh-hant/python-net/convert-powerpoint/)取得渲染與匯出範例。

## **常見問題**

**當腳本未對映時，`get_script_font` 會回傳什麼？**

[Fonts.get_script_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/get_script_font/) 於請求的腳本對映未在該主要或次要字型集合中定義時，回傳 `None`。

**`set_script_font` 會在腳本已存在時新增第二筆對映嗎？**

不會。[Fonts.set_script_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fonts/set_script_font/) 會在缺少時建立對映，若相同腳本標籤已存在則取代其字型系列。

**為什麼變更主題對映後，有些文字沒有改變？**

這些文字可能已明確指派字型、透過覆寫繼承了不同的主題，或在渲染時受到置換或回退的影響。簡報層級的腳本對映僅控制仍依賴該主題字型集合的文字。

**僅儲存並重新開啟能驗證多語言輸出嗎？**

不能。重新開啟只能驗證主題資料的持久性。還需渲染每個必需書寫系統的代表性文字，以確認對映的字型可用且包含必要字形。