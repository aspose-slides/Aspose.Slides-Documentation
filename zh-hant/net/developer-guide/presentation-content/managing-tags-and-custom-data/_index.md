---
title: 在 .NET 中管理簡報的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/net/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 新增標籤
- 成對值
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "瞭解如何在 Aspose.Slides for .NET 中新增、讀取、更新與移除標籤與自訂資料，並提供 PowerPoint 與 OpenDocument 簡報的範例。"
---
## **概覽**

本文說明 Aspose.Slides 在 PowerPoint 簡報中如何使用標籤與自訂資料。簡要概述資料在 PPTX 檔案中的儲存方式，指出簡報特有的資料可以以標籤與自訂 XML 部分的形式存在，並將標籤描述為鍵值字串配對。

同時示範如何讀取標籤值，以及如何將標籤新增至簡報、單一投影片或圖形。此外，本文還涵蓋常見的標籤管理工作，如清除所有標籤、依名稱移除標籤，以及取得標籤名稱清單。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 .pptx）以 PresentationML 格式儲存，該格式屬於 Office Open XML 規範的一部分。Office Open XML 格式定義了簡報中資料的結構。

在簡報中，*投影片* 是其中的元素之一，*投影片部件* 包含單一投影片的內容。投影片部件可以與多個部件（例如使用者自訂標籤）建立明確的關聯，這些關聯由 ISO/IEC 29500 定義。

自訂資料（特定於簡報）或使用者可以以標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itagcollection)）與自訂 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpartcollection)）的形式存在。

{{% alert color="primary" %}} 
標籤本質上是字串鍵值對。 
{{% /alert %}} 

## **取得標籤值**

在 Slides 中，標籤對應到 `IDocumentProperties.Keywords` 屬性。以下範例程式碼示範如何使用 Aspose.Slides for .NET 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 的標籤值：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **將標籤新增至簡報**

Aspose.Slides 允許您將標籤新增至簡報。標籤通常由兩個項目組成：

- 自訂屬性的名稱 - `MyTag`
- 自訂屬性的值 - `My Tag Value`

如果您需要依特定規則或屬性對簡報進行分類，則可透過新增標籤來達成。例如，若要將所有北美國家的簡報歸類在一起，您可以建立「North American」標籤，並將相關國家（美國、墨西哥、加拿大）作為其值。

以下範例程式碼示範如何使用 Aspose.Slides for .NET 為 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 新增標籤：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

標籤也可以為 [Slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide) 設定：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

或為任意單一的 [Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape) 設定：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **限制**

透過 `CustomData.Tags` 集合新增的標籤僅儲存在 PowerPoint 檔案中。匯出為 PDF 時，這些標籤 **不會** 轉換至 PDF 的標籤結構。因此，作為標籤的自訂識別碼無法從已標記的 PDF 中取得。

**解決方法**：您可以將自訂識別碼儲存在物件的 **Alt Text**（例如 `shape.AlternativeText = "MyId"`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標籤結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或圖形中的所有標籤嗎？**

可以。[標籤集合](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection) 支援 [clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/clear) 作業，可一次刪除所有鍵值配對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**

使用 [Remove(name)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/remove) 作業於 [TagCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection) 以鍵名刪除標籤。

**我該如何取得全部標籤名稱的清單以進行分析或篩選？**

使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/getnamesoftags) 於 [標籤集合](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection)；它會回傳所有標籤名稱的陣列。