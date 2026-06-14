---
title: 使用 JavaScript 管理簡報中的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/nodejs-java/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 新增標籤
- 鍵值對
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Node.js 中新增、讀取、更新和移除標籤與自訂資料，並提供 PowerPoint 與 OpenDocument 簡報的範例。"
---
## **概覽**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中處理標籤與自訂資料。它簡要概述了資料在 PPTX 檔案中的儲存方式，指出簡報特定的資料可以以標籤和自訂 XML 部分的形式存在，並將標籤描述為鍵值字串對。

它也示範了如何讀取標籤值以及如何將標籤新增至簡報、單一投影片或圖形。此外，本文還涵蓋了常見的標籤管理工作，例如清除所有標籤、依名稱移除標籤，以及取得標籤名稱清單。

## **簡報檔案中的資料儲存**

PPTX 檔案——副檔名為 .pptx 的項目——採用 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部分。Office Open XML 格式定義了簡報中資料的結構。

在簡報中，*投影片* 是其中一個元素，*投影片部件* 包含單一投影片的內容。投影片部件可以與許多部件建立明確關聯──例如使用 ISO/IEC 29500 定義的使用者自訂標籤。

自訂資料（特定於簡報）或使用者可以以標籤（[TagCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TagCollection)）和自訂 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/CustomXmlPartCollection)）的形式存在。

{{% alert color="primary" %}} 
標籤本質上是字串鍵值對。 
{{% /alert %}} 

## **取得標籤的值**

在 Slides 中，標籤對應到 [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) 和 [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) 方法。以下範例程式碼展示了如何使用 Aspose.Slides for Node.js via Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 中標籤的值：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將標籤加入簡報**

Aspose.Slides 允許您將標籤加入簡報。標籤通常由兩個項目組成：

- 自訂屬性的名稱 - `MyTag` 
- 自訂屬性的值 - `My Tag Value`

如果您需要根據特定規則或屬性對簡報進行分類，加入標籤會很有幫助。例如，若要將所有北美國家的簡報放在一起，您可以建立一個「北美」標籤，並將相關國家（美國、墨西哥、加拿大）設定為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Node.js via Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 新增標籤：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

標籤也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide)：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

或任何單一的 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **限制**

透過 `getCustomData().getTags()` 新增的自訂資料標籤集合僅儲存在 PowerPoint 檔案中。它們 **不會** 在將簡報匯出為 PDF 時轉移至 PDF 標籤結構。因此，作為標籤指派的自訂識別碼無法從已標記的 PDF 中取得。

**解決方式**: 您可以將自訂識別碼儲存在物件的 **Alt Text**（例如 `shape.setAlternativeText("MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標籤結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或圖形上的所有標籤嗎？**

是的。[標籤集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/clear/) 作業，可一次刪除所有鍵‑值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**

使用 [remove(name)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/remove/) 作業於 [TagCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/) 以鍵名刪除標籤。

**如何取得全部標籤名稱的清單以供分析或篩選？**

在[標籤集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/)上呼叫 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/getnamesoftags/)，會回傳所有標籤名稱的陣列。