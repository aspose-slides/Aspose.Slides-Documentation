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
- 收集形狀
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、收集形狀，並減少簡報大小。"
---
## **概觀**

The [aspose.slides.lowcode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/) 模組提供用於常見簡報操作的輔助類別。這些輔助類別將常用的物件模型工作流程封裝為專注的方法，讓您能以更少的程式碼轉換或合併檔案、收集形狀，並移除未使用的內容。

低程式碼輔助功能在操作適用於整個檔案或簡報且預設工作流程符合需求時最為有用。當您需要對單個投影片、母片、版面配置、形狀、匯出設定或簡報元素之間的關係進行細緻控制時，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/)。

以下表格總結了可用的輔助功能：

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/) | 將簡報轉換為另一種格式的直接檔案對檔案呼叫。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/merger/) | 合併相同格式的完整簡報檔案。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/collect/) | 從整個簡報中擷取形狀以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) | 移除未使用的母片和版面配置，並減少嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以選擇匯出格式時，請使用 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/auto_by_extension/)。此方法會開啟來源簡報，從輸出路徑判斷所需格式，並寫入結果。

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

[Convert](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/) 類別也提供針對 PDF、SVG、JPEG、PNG 與 TIFF 輸出的專用方法。當您需要在匯出前檢查或修改簡報，或設定未由所選輔助功能公開的匯出選項時，請使用完整的物件模型。請參閱 [Convert Presentation](/python-net/convert-presentation/) 了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger.process](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/merger/process/) 可一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

此輔助功能適用於所有投影片皆應直接附加至單一結果，且不需要逐一選取或重新對應。當您需要合併特定投影片、套用目標母片或版面配置、明確保留節，或調整不同投影片尺寸時，請使用完整的物件模型。請參閱 [Merge Presentations](/python-net/merge-presentation/) 了解相關情境。

## **收集形狀**

當您需要取得簡報中所有形狀的集合時，請使用 [Collect.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/collect/shapes/)。這在相同的集合需要多次過濾、計數或處理時非常有用。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

如果遍歷順序、提前退出、處理前過濾或對父子關係的細緻控制很重要，請使用直接的集合迴圈。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別可以移除未使用的結構元素並減少嵌入字型資料：

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 移除沒有一般投影片參照的版面配置投影片。
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) 移除不再使用的母片投影片。
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) 從嵌入字型中移除未使用的字元。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

請先移除未使用的版面配置，再移除未使用的母片，這樣在版面配置清理後變成未被參照的母片也能一起移除。若您可能日後需要原始的母片、版面配置或完整的嵌入字型資料，請將最佳化後的簡報儲存為新檔案。欲取得更多細節，請參閱 [Slide Master](/python-net/slide-master/) 與 [Embedded Font](/python-net/embedded-font/)。

## **常見問題**

**什麼時候應該使用低程式碼 API 而非完整物件模型？**

當標準操作適用於完整檔案或簡報且不需要對個別元素進行詳細控制時，使用低程式碼輔助功能。當您需要選取特定投影片、控制母片與版面配置的關係、檢查中間狀態，或設定輔助功能未公開的行為時，請使用完整物件模型。

**Merger 能夠合併不同檔案格式的簡報嗎？**

不能。[Merger.process](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/merger/process/) 需要輸入的簡報具有相同的格式。請先使用例如 [Convert.auto_by_extension](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/convert/auto_by_extension/) 將輸入檔案轉換為相同格式，然後再合併轉換後的檔案。

**Collect.shapes 會包含什麼？**

[Collect.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/collect/shapes/) 從簡報中取得形狀，以便保留、過濾、計數或多次遍歷。若您需要精確控制訪問哪種類型的投影片或巢狀物件，請使用直接的集合迴圈。

**Compress 總是會讓簡報檔案變小嗎？**

不一定。結果取決於簡報是否包含未使用的版面配置、未使用的母片，或具有未使用字元的嵌入字型。若上述情況皆不存在，相應的 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 操作可能不會減少檔案大小。

**Compress 所做的變更會自動儲存嗎？**

不會。這些輔助功能在記憶體中的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件上操作。執行 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 後，請呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 以寫入結果。

## **相關文章**

- [轉換簡報](/python-net/convert-presentation/)
- [合併簡報](/python-net/merge-presentation/)
- [投影片母片](/python-net/slide-master/)
- [管理文字方塊](/python-net/manage-textbox/)
- [嵌入字型](/python-net/embedded-font/)