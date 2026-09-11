---
title: 在 Python 中透過 Java 自訂 PowerPoint 字型
linktitle: 自訂字型
type: docs
weight: 20
url: /zh-hant/python-java/custom-font/
keywords:
- 字型
- 自訂字型
- 外部字型
- 載入字型
- 管理字型
- 字型資料夾
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 Java 自訂 PowerPoint 投影片的字型，以確保您的簡報在任何裝置上皆保持清晰且一致。"
---
## **概述**

Aspose.Slides 允許您在簡報中使用自訂字型，而無需在作業系統上安裝它們。您可以從自訂資料夾載入字型，透過文件層級字型來源為特定簡報提供字型，或直接從二進位資料載入外部字型。

載入的字型會在簡報呈現或匯出時使用，例如匯出為 PDF、影像以及其他支援的格式。這有助於保持簡報輸出在不同環境間的一致性。本文亦說明如何檢查 Aspose.Slides 使用的字型資料夾，以及在使用外部字型後如何清除字型快取。

註冊自訂字型以供呈現與將字型嵌入 PPTX 檔案是分開的作業。如果必須將字型儲存在簡報本體內，請明確使用字型嵌入功能。

簡報主題可以為各個書寫系統參照不同的字型系列。這些對映會儲存字型名稱，但不會安裝或載入字型檔案。請參閱[Script-Specific Theme Fonts](/slides/zh-hant/python-java/script-specific-font-mappings/)以管理這些對映，並使用以下載入選項使參照的字型可用於一致的呈現。

{{% alert color="info" title="Note" %}}
Aspose.Slides 允許您使用 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadExternalFonts) 方法載入這些字型：

* TrueType (.ttf) 與 TrueType Collection (.ttc) 字型。請參閱[TrueType](https://en.wikipedia.org/wiki/TrueType)。
* OpenType (.otf) 字型。請參閱[OpenType](https://en.wikipedia.org/wiki/OpenType)。
{{% /alert %}}

## **載入自訂字型**

Aspose.Slides 允許您在不將字型安裝到系統的情況下載入簡報中使用的字型。這會影響匯出輸出——例如 PDF、影像以及其他支援的格式——使最終文件在各環境中保持一致。字型會從自訂目錄載入。

1. 指定包含字型檔案的一個或多個資料夾。
2. 呼叫靜態 [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadExternalFonts) 方法，從這些資料夾載入字型。
3. 載入並呈現/匯出簡報。
4. 呼叫 [FontsLoader.clearCache](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#clearCache) 以清除字型快取。

以下程式碼範例示範字型載入過程：

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# 定義包含自訂字型檔案的資料夾。
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# 從指定的資料夾載入自訂字型。
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # 使用已載入的字型呈現/匯出簡報。
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # 工作完成後清除字型快取。
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadExternalFonts) 會將額外的資料夾加入字型搜尋路徑，但不會更改字型初始化順序。  
字型會依照以下順序初始化：

1. 作業系統的預設字型路徑。
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/) 載入的路徑。
{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供 [getFontFolders](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#getFontFolders) 方法讓您取得字型資料夾。此方法會回傳透過 [loadExternalFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadExternalFonts) 方法加入的資料夾以及系統字型資料夾。

以下 Python 程式碼示範如何使用 [getFontFolders](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#getFontFolders)：

```python
from asposeslides.api import FontsLoader

# 取得透過 loadExternalFonts 新增的資料夾以及系統字型資料夾。
font_folders = FontsLoader.getFontFolders()
```

## **指定簡報使用的自訂字型**

Aspose.Slides 提供 [getDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) 方法，讓您指定將在簡報中使用的外部字型。

以下 Python 程式碼示範如何使用 [getDocumentLevelFontSources](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) 方法：

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # 處理簡報。
    # CustomFont1、CustomFont2 以及來自 assets/fonts 和 global/fonts 的字型
    # 以及它們的子資料夾可供簡報使用。
    pass
finally:
    presentation.dispose()
```

## **外部管理字型**

Aspose.Slides 提供 [loadExternalFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsloader/#loadExternalFont) 方法，讓您從二進位資料載入外部字型。

以下 Python 程式碼示範位元組陣列字型載入流程：

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # 外部字型在簡報生命週期內載入。
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **常見問題**

**自訂字型會影響匯出至所有格式（PDF、PNG、SVG、HTML）嗎？**  
會。已註冊的字型會被渲染器在所有匯出格式中使用。

**自訂字型會自動嵌入到產生的 PPTX 中嗎？**  
不會。為渲染註冊字型並不等同於將其嵌入 PPTX。若需要字型隨簡報檔案一起攜帶，必須使用明確的[嵌入功能](/slides/zh-hant/python-java/embedded-font/)。

**當自訂字型缺少某些字形時，我能控制回退行為嗎？**  
可以。可設定[字型替代](/slides/zh-hant/python-java/font-substitution/)、[取代規則](/slides/zh-hant/python-java/font-replacement/)和[回退集合](/slides/zh-hant/python-java/fallback-font/)，以明確指定當請求的字形缺失時使用哪個字型。

**我能在 Linux/Docker 容器中使用字型而無需全系統安裝嗎？**  
可以。指向您自己的字型資料夾或從位元組陣列載入字型，即可避免對容器映像中系統字型目錄的任何依賴。

**關於授權—我可以在沒有限制的情況下嵌入任何自訂字型嗎？**  
您需自行負責字型授權合規性。授權條款各異；有些授權禁止嵌入或商業使用。發布輸出前，請務必檢查字型的最終使用者授權協議（EULA）。