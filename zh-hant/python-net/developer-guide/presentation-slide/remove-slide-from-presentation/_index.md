---
title: 在 Python 中從簡報中移除投影片
linktitle: 移除投影片
type: docs
weight: 30
url: /zh-hant/python-net/remove-slide-from-presentation/
keywords:
- 移除投影片
- 刪除投影片
- 移除未使用的投影片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET，以 Python 使用 Aspose.Slides，輕鬆從 PowerPoint 與 OpenDocument 簡報中移除投影片。取得清晰的程式碼範例，提升工作流程。"
---
## **簡介**

如果不再需要投影片（或其內容），您可以將其刪除。Aspose.Slides 提供的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別，封裝了 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/)，用於儲存簡報中所有投影片的倉庫。使用已知 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 物件的參照或索引，您可以移除目標投影片。

## **依參照移除投影片**

當您已經取得目標 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 的參照時，可直接移除它。這樣可避免索引查找，讓程式碼更簡潔清晰。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 透過其 ID 或索引取得投影片的參照。  
3. 從簡報中移除該參照的投影片。  
4. 儲存已修改的簡報。  

以下 Python 範例示範如何依參照移除投影片：

```python
import aspose.slides as slides

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 透過投影片集合中的索引存取投影片。
    slide = presentation.slides[0]

    # 依參照移除投影片。
    presentation.slides.remove(slide)

    # 儲存已修改的簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **依索引移除投影片**

如果您知道投影片在簡報中的位置，可依索引將其刪除。特別適用於迴圈或批次操作，事先已知位置的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引移除投影片。  
3. 儲存已修改的簡報。  

以下 Python 範例示範如何依索引移除投影片：

```python
import aspose.slides as slides

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 依索引移除投影片。
    presentation.slides.remove_at(0)

    # 儲存已修改的簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **移除未使用的版面投影片**

Aspose.Slides 在 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別中提供 `remove_unused_layout_slides` 方法，用於刪除不需要的未使用版面投影片。以下 Python 範例示範如何從 PowerPoint 簡報中移除未使用的版面投影片：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **移除未使用的母版投影片**

Aspose.Slides 在 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別中提供 `remove_unused_master_slides` 方法，用於刪除不需要的未使用母版投影片。以下 Python 範例示範如何從 PowerPoint 簡報中移除未使用的母版投影片：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**刪除投影片後，投影片索引會發生什麼變化？**  
刪除後，[collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 會重新編號：所有後續的投影片向左移動一個位置，因此先前的索引號碼不再正確。若需要穩定的參照，請使用每張投影片的持久化 ID，而非其索引。

**投影片的 ID 與索引不同嗎？當相鄰投影片被刪除時，ID 會改變嗎？**  
是的。索引代表投影片的位置，當投影片被新增或刪除時會變動。投影片 ID 為持久化識別碼，其他投影片被刪除時不會改變。

**刪除投影片會如何影響投影片分節？**  
如果該投影片屬於某個分節，該分節的投影片數量會減少一個。分節結構仍然保留；若分節變成空的，您可以 [remove or reorganize sections](/slides/zh-hant/python-net/slide-section/) 。

**刪除投影片時，附加於該投影片的備註與評論會發生什麼情況？**  
[Notes](/slides/zh-hant/python-net/presentation-notes/) 與 [comments](/slides/zh-hant/python-net/presentation-comments/) 皆與特定投影片綁定，會隨該投影片一起被移除。其他投影片的內容不受影響。

**刪除投影片與清理未使用的版面/母版有何不同？**  
刪除會將特定的一般投影片從簡報中移除。清理未使用的版面/母版則是刪除沒有任何參照的版面或母版投影片，可減少檔案大小，同時不會改變剩餘投影片的內容。這兩個動作是互補的：通常先刪除投影片，然後再進行清理。