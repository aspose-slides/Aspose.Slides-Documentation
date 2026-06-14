---
title: 使用 PHP 管理簡報中的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/php-java/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 新增標籤
- 鍵值對
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中新增、讀取、更新與移除標籤與自訂資料，並提供 PowerPoint 與 OpenDocument 簡報的範例。"
---
## **概覽**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標記（tags）和自訂資料。它簡要概述了資料在 PPTX 檔案中的儲存方式，指出簡報特定的資料可以以標記和自訂 XML 部分的形式存在，並將標記描述為鍵值字串對。

它還示範了如何讀取標記值，以及如何將標記新增到簡報、單一投影片或形狀中。此外，本文還涵蓋了常見的標記管理任務，例如清除所有標記、依名稱移除特定標記，以及取得標記名稱清單。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 .pptx 的項目）以 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部分。Office Open XML 格式定義了簡報中資料的結構。

在簡報中，*投影片* 是其中一個元素，*投影片部件* 包含單一投影片的內容。投影片部件允許與多個部件（例如使用者定義的標記）建立明確的關聯，這些關聯由 ISO/IEC 29500 定義。

自訂資料（特定於簡報）或使用者可以以標記（[TagCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/)）和 CustomXmlParts（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
標記本質上是字串鍵值對。 
{{% /alert %}} 

## **取得標記的值**

在投影片中，標記對應於 [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#getKeywords) 與 [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#setKeywords) 方法。以下範例程式碼示範如何使用 Aspose.Slides for PHP via Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 的標記值：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將標記新增至簡報**

Aspose.Slides 允許您將標記新增至簡報。標記通常由兩個項目組成：

- 自訂屬性的名稱 - `MyTag` 
- 自訂屬性的值 - `My Tag Value`

如果您需要根據特定規則或屬性對某些簡報進行分類，則可以透過新增標記來實現。例如，若要將所有來自北美國家的簡報歸類在一起，您可以建立一個「北美」標記，並將相關國家（美國、墨西哥與加拿大）作為其值。

以下範例程式碼示範如何使用 Aspose.Slides for PHP via Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 新增標記：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

標記也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/)：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

或任意單一 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **限制**

透過 `getCustomData()->getTags()` 加入自訂資料標記集合的標記僅儲存於 PowerPoint 檔案中。匯出為 PDF 時，它們 **不會** 轉移至 PDF 標記結構。因此，作為標記指派的自訂識別碼無法從已標記的 PDF 中取得。

**解決方法**：您可以將自訂識別碼儲存在物件的 **Alt Text**（例如，`$shape->setAlternativeText("MyId")`）中。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標記結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或形狀的所有標記嗎？**

可以。[tag collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/clear/) 操作，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標記？**

使用 [remove(name)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/remove/) 操作於 [tag collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/)，即可依鍵名刪除該標記。

**如何取得所有標記名稱的完整清單以進行分析或篩選？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/) 上呼叫 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/getnamesoftags/)，它會回傳所有標記名稱的陣列。