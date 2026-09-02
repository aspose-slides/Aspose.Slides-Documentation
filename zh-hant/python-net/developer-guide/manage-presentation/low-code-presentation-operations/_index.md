---
title: Python 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/python-net/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 收集圖形
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面投影片
- 壓縮內嵌字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 低程式碼 API 轉換與合併簡報、收集圖形，並減少簡報檔案大小。"
---
## **概述**

[aspose.slides.lowcode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/) 模組提供常見簡報操作的輔助類別。這些輔助類別將常用的物件模型工作流程封裝成專注的方法，讓您能以較少的程式碼執行檔案轉換、合併、收集圖形以及移除未使用的內容。

當操作適用於整個檔案或簡報，且預設工作流程符合需求時，低程式碼輔助工具最為實用。若需要對個別投影片、母片、版面配置、圖形、匯出設定或簡報元素之間的關係進行精細控制，請使用完整的 [Aspose.Slides 物件模型](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/)。

下表彙總了可用的輔助工具：

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/) | 直接以檔案對檔案的呼叫將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/merger/) | 合併相同格式的完整簡報檔案。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/collect/) | 從整個簡報中取得圖形，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) | 移除未使用的母片與版面配置，並減少內嵌字型資料。 |

## **轉換簡報**

當輸出檔案的副檔名即可決定匯出格式時，使用 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/auto_by_extension/)。此方法會開啟來源簡報，根據輸出路徑判斷所需格式，然後寫入結果。

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/) 類別也提供 PDF、SVG、JPEG、PNG 與 TIFF 的專屬輸出方法。若需要在匯出前檢查或修改簡報，或設定選擇的輔助工具未公開的匯出選項，請使用完整的物件模型。請參閱 [Convert Presentation](/slides/zh-hant/python-net/convert-presentation/) 了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/merger/process/) 只要一次呼叫即可合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

此輔助工具適用於所有投影片都要直接附加至結果檔案，且不需要逐一選取或重新映射。若需要合併指定投影片、套用目標母片或版面配置、明確保留區段，或調整不同投影片尺寸，請使用完整的物件模型。相關情境請參閱 [Merge Presentations](/slides/zh-hant/python-net/merge-presentation/)。

## **收集圖形**

當需要取得簡報中所有圖形的集合時，使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/collect/shapes/)。這在需要多次篩選、計數或處理相同圖形集合時相當有用。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

若遍歷順序、提前退出、處理前篩選或需要細緻的父子控制很重要，請直接使用迴圈收集。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別可移除未使用的結構元素並減少內嵌字型資料：

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 移除沒有任何正常投影片參照的版面投影片。
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) 移除不再使用的母片投影片。
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 從內嵌字型中移除未使用的字元。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

請先移除未使用的版面，之後再移除未使用的母片，因為版面清理後可能產生未被參照的母片，亦可一併移除。若之後可能仍需原始的母片、版面或完整的內嵌字型資料，請將最佳化後的簡報另存為新檔。更多細節請參閱 [Slide Master](/slides/zh-hant/python-net/slide-master/) 與 [Embedded Font](/slides/zh-hant/python-net/embedded-font/)。

## **常見問題**

**何時該使用低程式碼 API 而非完整物件模型？**

當標準操作適用於整個檔案或簡報且不需要對個別元素進行細部控制時，使用低程式碼輔助工具。若需要選取特定投影片、控制母片與版面關係、檢查中間狀態，或設定輔助工具未提供的行為，則使用完整物件模型。

**Merger 能合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/merger/process/) 要求輸入簡報必須是相同格式。請先使用例如 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/auto_by_extension/) 之類的方式將檔案轉換為相同格式，再進行合併。

**Collect.shapes 包含哪些內容？**

[Collect.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/collect/shapes/) 會從簡報中取得圖形，以便保留、篩選、計數或多次遍歷。若需要精確控制要拜訪的投影片類型或巢狀物件，請使用直接的集合迴圈。

**Compress 總是會讓簡報檔案變小嗎？**

未必。結果取決於簡報是否包含未使用的版面、未使用的母片或含有未使用字元的內嵌字型。若上述項目皆不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 操作可能不會減少檔案大小。

**Compress 所做的變更會自動保存嗎？**

不會。這些輔助工具作用於記憶體中的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件。執行完 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 後，必須呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 才會寫入結果。

## **相關文章**

- [Convert Presentation](/slides/zh-hant/python-net/convert-presentation/)
- [Merge Presentations](/slides/zh-hant/python-net/merge-presentation/)
- [Slide Master](/slides/zh-hant/python-net/slide-master/)
- [Manage Text Box](/slides/zh-hant/python-net/manage-textbox/)
- [Embedded Font](/slides/zh-hant/python-net/embedded-font/)