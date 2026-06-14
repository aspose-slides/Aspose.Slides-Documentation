---
title: 使用 Java 管理簡報中的標記與自訂資料
linktitle: 標記與自訂資料
type: docs
weight: 300
url: /zh-hant/java/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標記
- 自訂資料
- 新增標記
- 鍵值對
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中新增、讀取、更新與移除標記與自訂資料，並提供 PowerPoint 與 OpenDocument 簡報的示例。"
---
## **概述**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標記和自訂資料。它簡要概述資料在 PPTX 檔案中的儲存方式，指出簡報特定的資料可以以標記和自訂 XML 部分的形式存在，並將標記描述為鍵值字串對。

此外，本文還展示如何讀取標記值以及如何將標記新增至簡報、單一投影片或圖形。除此之外，本文還涵蓋常見的標記管理工作，例如清除所有標記、依名稱移除標記，以及取得標記名稱清單。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 .pptx 的項目）以 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部份。Office Open XML 格式定義了簡報中資料的結構。

在簡報中，*投影片* 是其中一個元素，*投影片部件* 包含單一投影片的內容。投影片部件允許與多個部件建立明確的關聯，例如由 ISO/IEC 29500 定義的使用者自訂標記。

自訂資料（特定於簡報）或使用者可以以標記（[ITagCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITagCollection)）及 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection)）的形式存在。

{{% alert color="primary" %}} 
標記本質上是字串鍵值對。 
{{% /alert %}} 

## **取得標記的值**

在簡報中，標記對應到 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IDocumentProperties#getKeywords--) 和 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。以下範例程式碼示範如何使用 Aspose.Slides for Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 的標記值：

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **將標記新增至簡報**

Aspose.Slides 允許您將標記新增至簡報。標記通常由兩個項目組成：

- 自訂屬性的名稱 - `MyTag` 
- 自訂屬性的值 - `My Tag Value`

如果您需要根據特定規則或屬性對簡報進行分類，則可透過為這些簡報新增標記來受惠。例如，若想將所有來自北美國家的簡報歸類在一起，您可以建立一個 North American 標記，並將相關國家（美國、墨西哥、加拿大）設定為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 新增標記：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

標記也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide)：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

或任何單一的 [Shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **限制**

透過 `getCustomData().getTags()` 新增的自訂資料標記集合僅儲存在 PowerPoint 檔案中。當簡報匯出為 PDF 時，這些標記 **不會** 轉移至 PDF 的標記結構。因此，作為標記的自訂識別碼無法從已標記的 PDF 中取得。

**解決方法**：您可以將自訂識別碼儲存在物件的 **Alt Text**（例如 `shape.setAlternativeText("MyId")`）中。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標記結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或圖形上的所有標記嗎？**

可以。 [tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#clear--) 操作，一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標記？**

使用 [Remove(name)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作於 [tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/)，即可依鍵刪除該標記。

**如何取得全部標記名稱清單以進行分析或篩選？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 上使用 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#getNamesOfTags--)；它會返回所有標記名稱的陣列。