---
title: 管理 Android 上簡報的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/androidjava/managing-tags-and-custom-data
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 新增標籤
- 鍵值配對
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中新增、讀取、更新與移除標籤與自訂資料，並提供適用於 PowerPoint 與 OpenDocument 簡報的 Java 範例。"
---
## **概觀**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤和自訂資料。它簡要概述了資料如何儲存在 PPTX 檔案中，指出簡報特定的資料可以以標籤和自訂 XML 部分的形式存在，並將標籤描述為鍵值字串對。

同時也示範如何讀取標籤值以及如何將標籤新增至簡報、單一投影片或形狀。此外，本文還涵蓋常見的標籤管理工作，如一次清除所有標籤、依名稱移除標籤，及取得標籤名稱清單。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 .pptx）採用 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部分。Office Open XML 格式定義了簡報中資料的結構。

在簡報中，*投影片* 是其中一個元素，*投影片部件* 包含單一投影片的內容。投影片部件可以與許多部件（例如使用者自訂標籤）建立明確關聯，這些關聯由 ISO/IEC 29500 定義。

自訂資料（特定於簡報）或使用者可以以標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITagCollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPartCollection)）的形式存在。

{{% alert color="primary" %}} 
標籤本質上是字串鍵值對。 
{{% /alert %}} 

## **取得標籤的值**

在簡報中，標籤對應到 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) 與 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。以下範例程式碼示範如何使用 Aspose.Slides for Android via Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 中標籤的值：

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **將標籤新增至簡報**

Aspose.Slides 允許您為簡報新增標籤。標籤通常由兩個項目組成：

- 自訂屬性的名稱 - `MyTag` 
- 自訂屬性的值 - `My Tag Value`

如果需要根據特定規則或屬性對簡報進行分類，您可以透過新增標籤來達成。例如，若想將所有北美國家的簡報集中在一起，可建立一個「North American」標籤，並將相關國家（美國、墨西哥與加拿大）作為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Android via Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 新增標籤：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

標籤也可設定於 [Slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlide)：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

或任意單一的 [Shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape)：

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

透過 `getCustomData().getTags()` 所加入的自訂資料標籤集合僅儲存在 PowerPoint 檔案內。當簡報匯出為 PDF 時，這些標籤 **不會** 轉移至 PDF 的標籤結構。因此，作為標籤指派的自訂識別碼無法從已加標籤的 PDF 中取得。

**解決方法**：您可以將自訂識別碼存放於物件的 **Alt Text**（例如 `shape.setAlternativeText("MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標籤結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或形狀上的所有標籤嗎？**

可以。[tag collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/#clear--) 作業，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，以名稱刪除單一標籤？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/) 上使用 [remove(name)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) 作業，即可依鍵刪除該標籤。

**我該如何取得所有標籤名稱的完整清單以供分析或過濾？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/) 上呼叫 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--)，即會回傳所有標籤名稱的陣列。