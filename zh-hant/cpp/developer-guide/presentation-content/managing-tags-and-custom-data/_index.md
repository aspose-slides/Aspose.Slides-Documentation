---
title: 使用 C++ 管理簡報中的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/cpp/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 新增標籤
- 鍵值對
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中新增、讀取、更新與移除標籤與自訂資料，並提供 PowerPoint 與 OpenDocument 簡報的範例。"
---
## **概述**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤與自訂資料。它簡要概述資料在 PPTX 檔案中的儲存方式，指出簡報特定的資料可作為標籤與自訂 XML 部分存在，並將標籤描述為鍵值字串對。  
它還示範如何讀取標籤值，以及如何將標籤新增至簡報、單一投影片或形狀。此外，本文還涵蓋常見的標籤管理工作，例如清除所有標籤、依名稱移除標籤以及取得標籤名稱列表。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 .pptx 的項目）以 PresentationML 格式儲存，該格式屬於 Office Open XML 規範的一部份。Office Open XML 格式定義了簡報內資料的結構。

在簡報中，*投影片* 是其中的一個元素，*投影片部件* 包含單一投影片的內容。投影片部件可以與許多部件建立明確的關聯——例如由 ISO/IEC 29500 定義的使用者自訂標籤。

自訂資料（特定於簡報）或使用者可以以標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itagcollection/)）和自訂 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
標籤本質上是字串鍵值對。 
{{% /alert %}} 

## **取得標籤值**

在投影片中，標籤對應到 IDocumentProperties.Keywords 屬性。以下範例程式碼示範如何使用 Aspose.Slides for C++ 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的標籤值：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **將標籤新增至簡報**

Aspose.Slides 允許您將標籤新增至簡報。標籤通常由兩個項目組成：

- 自訂屬性的名稱 - `MyTag`
- 自訂屬性的值 - `My Tag Value`

如果您需要根據特定規則或屬性對簡報進行分類，則可以透過新增標籤來達成。例如，若想將所有來自北美國家的簡報歸類在一起，您可以建立一個北美標籤，然後將相關的國家（美國、墨西哥與加拿大）作為其值。

以下範例程式碼示範如何使用 Aspose.Slides for C++ 為一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 新增標籤：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

標籤也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/)：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

或任意單一的 [Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/)：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **限制**

透過 `get_CustomData()->get_Tags()` 於自訂資料標籤集合新增的標籤僅儲存在 PowerPoint 檔案中。當簡報匯出為 PDF 時，這些標籤 **不會** 轉移至 PDF 標籤結構。因此，作為標籤分配的自訂識別碼無法從帶標籤的 PDF 中取得。

**解決方法**：您可以將自訂識別碼儲存在物件的 **Alt Text**（例如 `shape->set_AlternativeText(u"MyId")`）中。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標籤結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或形狀的所有標籤嗎？**

是的。[tag collection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/clear/) 操作，可一次刪除所有鍵–值對。

**如何在不遍歷整個集合的情況下，僅依名稱刪除單一標籤？**

使用 [Remove(name)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/remove/) 於 [TagCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 上的操作，以鍵名刪除該標籤。

**如何取得完整的標籤名稱列表以供分析或篩選？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 上使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/getnamesoftags/)，它會返回所有標籤名稱的陣列。