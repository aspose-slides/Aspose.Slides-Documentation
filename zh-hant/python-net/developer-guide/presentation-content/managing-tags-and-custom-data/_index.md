---
title: 使用 Python 在簡報中管理標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/python-net/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 新增標籤
- 成對值
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中新增、讀取、更新與移除標籤與自訂資料，並提供 PowerPoint 與 OpenDocument 簡報的範例。"
---
## **概覽**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤和自訂資料。它簡要概述了資料如何儲存在 PPTX 檔案中，指出簡報特定的資料可以以標籤和自訂 XML 部分的形式存在，並將標籤描述為鍵值字串對。它還展示了如何讀取標籤值以及如何將標籤新增到簡報、單一投影片或圖形中。此外，本文還涵蓋了常見的標籤管理任務，例如清除所有標籤、依名稱移除標籤，以及取得標籤名稱清單。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 .pptx 的項目）以 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部份。Office Open XML 格式定義了簡報中資料的結構。

在簡報中，*投影片* 是其中一個元素，*投影片部件* 包含單一投影片的內容。投影片部件允許與許多部件（例如使用者自訂標籤）建立明確的關聯，這些關聯由 ISO/IEC 29500 定義。

自訂資料（特定於簡報）或使用者可以以標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/itagcollection/)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/icustomxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
標籤本質上是字串鍵值對。 
{{% /alert %}} 

## **取得標籤的值**

在簡報中，標籤對應到 IDocumentProperties.Keywords 屬性。以下範例程式碼示範如何使用 Aspose.Slides for Python via .NET 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 的標籤值：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **將標籤新增至簡報**

Aspose.Slides 允許您將標籤新增至簡報。一個標籤通常由兩個項目組成：

- 自訂屬性的名稱 - `MyTag`
- 自訂屬性的值 - `My Tag Value`

如果您需要根據特定規則或屬性對簡報進行分類，則可透過將標籤新增至這些簡報來達成。例如，若想將所有北美國家的簡報歸類在一起，您可以建立一個 North American 標籤，並將相關國家（美國、墨西哥與加拿大）作為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Python via .NET 為 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 新增標籤：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

標籤也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/)：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

或任何單一的 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/)：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **限制**

透過 `custom_data.tags` 集合新增的標籤僅儲存在 PowerPoint 檔案中。匯出為 PDF 時，這些標籤 **不會** 轉移至 PDF 的標籤結構。因此，作為標籤指派的自訂識別碼無法從已標籤的 PDF 中取得。

**解決方法**：您可以將自訂識別碼儲存在物件的 **Alt Text**（例如 `shape.alternative_text = "MyId"`）中。匯出為 PDF 後，Alt Text 可能會出現在 PDF 的標籤結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或圖形的所有標籤嗎？**  
可以。[tag collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/clear/) 操作，可一次刪除所有鍵‑值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**  
使用 [TagCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/) 上的 [remove(name)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/remove/) 操作，以鍵名刪除該標籤。

**如何取得完整的標籤名稱清單以用於分析或篩選？**  
在 [tag collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/) 上使用 [get_names_of_tags](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/get_names_of_tags/)，它會回傳所有標籤名稱的陣列。