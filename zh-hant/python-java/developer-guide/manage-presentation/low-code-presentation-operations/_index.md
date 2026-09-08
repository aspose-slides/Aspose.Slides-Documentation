---
title: 在 Python via Java 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/python-java/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷圖形
- 遍歷文字
- 收集圖形
- 壓縮簡報
- 移除未使用的母版投影片
- 移除未使用的版面配置投影片
- 壓縮內嵌字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集圖形，並減少簡報大小。"
---
## **概覽**

[Aspose.Slides for Python via Java](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/) API 提供靜態輔助類別，用於常見的簡報操作。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您能以更少的程式碼執行檔案轉換或合併、處理簡報元素、收集圖形，以及移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合需求時，低程式碼輔助類別最為有用。若需要對單一投影片、母版、版面配置、圖形、匯出設定或簡報元素之間的關係進行精細控制，請使用完整的 [Aspose.Slides 物件模型](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/)。

下表彙總了可用的輔助類別：

| 輔助類別 | 用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/convert/) | 直接以檔案對檔案方式將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/) | 為每一張投影片、圖形、段落或文字部份執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/collect/) | 從整個簡報中取得圖形，以供重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/) | 移除未使用的母版與版面配置並減少內嵌字型資料。 |

## **轉換簡報**

當輸出檔案的副檔名足以決定匯出格式時，請使用 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/convert/#autoByExtension)。此方法會開啟來源簡報、從輸出路徑判斷所需格式，然後寫出結果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/convert/) 類別同時提供針對 PDF、SVG、JPEG、PNG 與 TIFF 輸出的專屬方法。若需在匯出前檢查或修改簡報，或設定輔助類別未公開的匯出選項，請使用完整的物件模型。請參閱 [Convert Presentation](/slides/zh-hant/python-java/convert-presentation/) 了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/merger/#process) 以一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

當所有投影片都要直接附加至最終結果、且不需要逐一選取或重新映射時，此輔助類別相當合適。若需要合併特定投影片、套用目標母版或版面配置、明確保留分節，或調整不同投影片大小，請使用完整的物件模型。請參閱 [Merge Presentations](/slides/zh-hant/python-java/merge-presentation/) 了解相關情境。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/) 類別會對每一種請求的簡報元素類型呼叫回呼函式。它可避免巢狀集合迴圈，並在整份簡報的檢查或格式變更時相當方便。

以下範例使用 [ForEach.slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#slide)、[ForEach.shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#paragraph) 與 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#portion) 來檢查相應元素：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

預設情況下，遍歷整份簡報的圖形與文字會包含一般投影片、母版與版面配置投影片。帶有 `includeNotes` 參數的重載可同時處理備註投影片。若遍歷順序、提前退出、在呼叫回呼前篩選，或需要精細的父子控制，請改用直接的集合迴圈。

## **收集圖形**

當您需要取得簡報中所有圖形的集合，而非對每個圖形立即執行回呼時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/collect/#shapes)。這在需要多次過濾、計數或重複處理同一組圖形時相當有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

若每個圖形都能立即處理且不需要保留收集結果，請改用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#shape)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/) 類別可移除未使用的結構元素並減少內嵌字型資料：

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 移除未被任何一般投影片參考的版面配置投影片。
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/#removeUnusedMasterSlides) 移除不再使用的母版投影片。
- [compressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/#compressEmbeddedFonts) 從內嵌字型中移除未使用的字元。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

請先移除未使用的版面配置，再移除未使用的母版，因為版面配置清理後可能會產生未被參考的母版，亦可一併移除。若日後可能仍需原始的母版、版面配置或完整的內嵌字型資料，請將最佳化後的簡報儲存為新檔案。有關更多細節，請參閱 [Slide Master](/slides/zh-hant/python-java/slide-master/) 與 [Embedded Font](/slides/zh-hant/python-java/embedded-font/)。

## **常見問題**

**何時應使用低程式碼 API 而非完整物件模型？**

當標準操作適用於整個檔案或簡報且不需要對單一元素進行詳細控制時，請使用低程式碼輔助類別。若需選取特定投影片、控制母版與版面配置的關係、檢查中間狀態，或設定輔助類別未公開的行為，則使用完整的物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/merger/#process) 必須使用相同格式的輸入簡報。請先使用例如 [Convert.autoByExtension](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/convert/#autoByExtension) 將檔案轉換為相同格式，再執行合併。

**ForEach 會處理母版、版面配置與備註投影片嗎？**

[ForEach.slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#slide) 只遍歷一般的簡報投影片。整份簡報的 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#shape)、[ForEach.paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#paragraph) 與 [ForEach.portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#portion) 預設會包含一般、母版與版面配置投影片。使用帶有 `includeNotes` 且設定為 `True` 的重載即可包含備註投影片。

**ForEach.shape 與 Collect.shapes 有何不同？**

使用 [ForEach.shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/#shape) 可在回呼函式中立即處理每個圖形。使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/collect/#shapes) 則會取得可保留的可疊代結果，方便後續過濾、計數或多次遍歷。

**Compress 是否總能讓簡報檔案變小？**

未必。結果取決於簡報是否包含未使用的版面配置、未使用的母版，或內嵌字型中有未使用的字元。若上述情況皆不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/) 操作可能不會減少檔案大小。

**ForEach 或 Compress 的變更會自動保存嗎？**

不會。這些輔助類別在記憶體中的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件上工作。於 [ForEach](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/foreach/) 回呼或執行 [Compress](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/) 後，請呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 以寫入結果。

## **相關文章**

- [Convert Presentation](/slides/zh-hant/python-java/convert-presentation/)
- [Merge Presentations](/slides/zh-hant/python-java/merge-presentation/)
- [Slide Master](/slides/zh-hant/python-java/slide-master/)
- [Manage Text Box](/slides/zh-hant/python-java/manage-textbox/)
- [Embedded Font](/slides/zh-hant/python-java/embedded-font/)