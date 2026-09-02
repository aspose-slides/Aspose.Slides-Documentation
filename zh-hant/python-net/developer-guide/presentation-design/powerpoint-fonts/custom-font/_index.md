---
title: 在 Python 中自訂 PowerPoint 字型
linktitle: 自訂字型
type: docs
weight: 20
url: /zh-hant/python-net/custom-font/
keywords:
- 字型
- 自訂字型
- 外部字型
- 載入字型
- 管理字型
- 字型資料夾
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Python (透過 .NET) 使用 Aspose.Slides 將自訂字型嵌入 PowerPoint 投影片，以確保簡報在任何裝置上皆保持清晰且一致。"
---
## **概觀**

Aspose.Slides for Python 允許您在執行階段提供自訂字型，以確保即使目標系統未安裝所需字型，簡報仍能正確呈現。匯出為 PDF 或影像時，您可以提供字型資料夾或記憶體中的字型資料，以保留文字版面配置、字形度量與排版。此功能讓伺服器端渲染在不同環境下具備可預測性，消除作業系統層級的字型依賴，防止不必要的替代或重新排版。本文說明如何註冊字型來源。

簡報主題可以針對不同書寫系統參考不同的字型系列。這些對應僅儲存字型名稱，並不會安裝或載入字型檔案。請參考 [Script-Specific Theme Fonts](/slides/zh-hant/python-net/script-specific-font-mappings/) 以管理對應，並使用下列載入選項讓參考的字型可供一致渲染。

Aspose.Slides 可使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/) 類別的 `load_external_font` 與 `load_external_fonts` 方法載入以下字型：

- TrueType（.ttf）與 TrueType Collection（.ttc）字型。請參閱 [TrueType](https://en.wikipedia.org/wiki/TrueType)。
- OpenType（.otf）字型。請參閱 [OpenType](https://en.wikipedia.org/wiki/OpenType)。

## **載入自訂字型**

Aspose.Slides 允許您在不將字型安裝至系統的情況下載入簡報使用的字型。此設定會影響匯出結果（例如 PDF、影像及其他支援格式），使產生的文件在不同環境下保持一致。字型來自自訂目錄。

1. 指定一個或多個包含字型檔案的資料夾。
2. 呼叫靜態 [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/load_external_fonts/) 方法，以從這些資料夾載入字型。
3. 載入並渲染/匯出簡報。
4. 呼叫 [FontsLoader.clear_cache](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/clear_cache/) 以清除字型快取。

以下程式碼範例示範字型載入流程：

```py
import aspose.slides as slides

# 定義包含自訂字型檔案的資料夾。
font_folders = ["fonts", "external_fonts"]

# 從指定的資料夾載入自訂字型。
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # 使用已載入的字型渲染/匯出簡報（例如 PDF、影像或其他格式）。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# 工作完成後清除字型快取。
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="注意" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/load_external_fonts/) 會將額外資料夾加入字型搜尋路徑，但不會改變字型初始化順序。  
字型的初始化順序如下：

1. 作業系統的預設字型路徑。  
1. 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/) 載入的路徑。  
{{%/alert %}}

## **取得自訂字型資料夾**

Aspose.Slides 提供 `get_font_folders` 方法取得字型資料夾。該方法會回傳透過 `load_external_fonts` 新增的資料夾以及系統字型資料夾。

以下 Python 程式碼示範如何使用 `get_font_folders`：

```python
import aspose.slides as slides

# 此呼叫會返回檢查字型檔案的資料夾。
# 其中包含透過 load_external_fonts 方法加入的資料夾以及系統字型資料夾。
font_folders = slides.FontsLoader.get_font_folders()
```

## **為簡報指定自訂字型**

Aspose.Slides 提供 `document_level_font_sources` 屬性，讓您為簡報指定外部字型。

以下 Python 範例說明如何使用 `document_level_font_sources`：

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # 處理簡報。
    # CustomFont1、CustomFont2，以及來自 assets\fonts 與 global\fonts 資料夾（含其子資料夾）的字型都可供簡報使用。
    # ...
    print(len(presentation.slides))
```

## **從二進位資料載入外部字型**

Aspose.Slides 提供 `load_external_font` 方法，從二進位資料載入外部字型。

以下 Python 範例示範從位元組陣列載入字型：

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# 從位元組陣列載入外部字型。
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # 外部字型在此簡報實例的生命週期內皆可使用。
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **常見問題**

### 自訂字型會影響所有匯出格式（PDF、PNG、SVG、HTML）嗎？

會。已連結的字型會在所有匯出格式的轉譯器中使用。

### 自訂字型會自動嵌入產生的 PPTX 檔案嗎？

不會。將字型註冊供渲染使用，並不等同於將其嵌入 PPTX。若需將字型隨簡報檔案一起攜帶，必須使用明確的 [embedding features](/slides/zh-hant/python-net/embedded-font/)。

### 當自訂字型缺少某些字形時，我可以控制替代行為嗎？

可以。請設定 [font substitution](/slides/zh-hant/python-net/font-substitution/)、[replacement rules](/slides/zh-hant/python-net/font-replacement/) 與 [fallback sets](/slides/zh-hant/python-net/fallback-font/)，以明確指定缺少字形時使用哪個字型。

### 我可以在 Linux/Docker 容器中使用字型而不需全域安裝嗎？

可以。指向您自己的字型資料夾或從位元組陣列載入字型，即可移除容器映像對系統字型目錄的任何依賴。

### 關於授權——我可以在沒有限制的情況下嵌入任何自訂字型嗎？

字型授權合規由您自行負責。授權條款各不相同，有些授權禁止嵌入或商業使用。分發輸出前，請務必檢視字型的最終使用者授權協議（EULA）。