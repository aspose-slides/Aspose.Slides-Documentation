---
title: 使用 C++ 管理簡報中的標記與自訂資料
linktitle: 標記與自訂資料
type: docs
weight: 300
url: /zh-hant/cpp/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標記
- 自訂資料
- 自訂 XML
- 自訂 XML 部分
- XML 中繼資料
- ItemId
- 新增標記
- 成對值
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中管理標記和自訂 XML 資料，包括新增、讀取、更新、稽核和移除自訂 XML 部分。"
---
## **概覽**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標記和自訂資料。簡報特定的資料可以儲存為標記或自訂 XML 部分。標記是簡單的鍵值字串配對，而自訂 XML 部分則可儲存結構化的中繼資料與應用程式特定的 XML 載荷。

Aspose.Slides 提供了在簡報、投影片與圖形層級新增、讀取、更新、稽核與移除自訂 XML 部分的 API。自訂 XML 部分對於需要在簡報內儲存文件管理識別碼、工作流程狀態、合規性中繼資料、範本綁定資料，或其他結構化應用程式資料的整合非常有用。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx`）以 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部分。Office Open XML 定義了用於儲存簡報內容與相關資料的套件結構與關聯性。

一個簡報包含多個透過關聯性連接的部件。例如，投影片部件包含單一投影片的內容，並可對其他部件建立 ISO/IEC 29500 定義的明確關聯。

自訂資料可以以標記（[ITagCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itagcollection/)）或自訂 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/)）的形式儲存。兩者皆可透過 [`ICustomData`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomdata/) 介面取得。

{{% alert color="primary" %}}
標記儲存簡單的字串鍵值配對。自訂 XML 部分儲存結構化的 XML 資料，且可與簡報、投影片或圖形關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomdata/get_customxmlparts/) 方法會回傳與特定簡報物件關聯的自訂 XML 部分集合。例如：

- `presentation->get_CustomData()->get_CustomXmlParts()` 包含與簡報本身關聯的自訂 XML 部分。
- `slide->get_CustomData()->get_CustomXmlParts()` 包含與特定投影片關聯的自訂 XML 部分。
- `shape->get_CustomData()->get_CustomXmlParts()` 包含與特定圖形關聯的自訂 XML 部分。

若需檢查簡報中所有自訂 XML 部分（不論關聯於何處），請使用 [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_allcustomxmlparts/)。

### **將自訂 XML 部分加入簡報**

使用 [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/add/) 可將 XML 資料新增至自訂 XML 部分集合。XML 必須有效且非空。

以下範例將結構化中繼資料加入簡報層級的自訂資料集合：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String customXmlContent =
    u"<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Draft</workflowState>"
    u"</metadata>";

auto presentation = System::MakeObject<Presentation>();
auto customXmlPart = presentation->get_CustomData()->get_CustomXmlParts()->Add(customXmlContent);

// Add 會自動指派識別碼。僅在需要時才設定特定的 GUID。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"presentation_with_custom_xml.pptx", SaveFormat::Pptx);
```

`Add` 方法也可接受 XML 的位元組陣列或串流，這在 XML 內容已以二進位形式存在時很有用。

### **將自訂 XML 部分加入投影片或圖形**

自訂 XML 資料可以關聯至特定投影片或圖形，而非整個簡報。當中繼資料僅描述單一物件（例如範本鍵、外部記錄識別碼或綁定資訊）時，這非常有用。

以下範例在投影片中加入一個自訂 XML 部分，並在圖形中加入另一個：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

slide->get_CustomData()->get_CustomXmlParts()->Add(
    u"<slideMetadata xmlns=\"urn:example:slides\">"
        u"<templateKey>TitleSlide</templateKey>"
    u"</slideMetadata>");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 250.0f, 80.0f);

shape->get_TextFrame()->set_Text(u"Customer data");
shape->get_CustomData()->get_CustomXmlParts()->Add(
    u"<shapeMetadata xmlns=\"urn:example:shapes\">"
        u"<recordId>CRM-4281</recordId>"
    u"</shapeMetadata>");

presentation->Save(u"object_custom_xml.pptx", SaveFormat::Pptx);
```

新增部件的層級決定了哪個物件的 `get_CustomData()->get_CustomXmlParts()` 集合會包含對該部件的關聯。簡報層級的資料適用於整個文件的中繼資料，投影片層級適用於屬於特定投影片的資訊，圖形層級則適用於與單一圖形相關的中繼資料。

### **列出並稽核所有自訂 XML 部分**

使用 [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_allcustomxmlparts/) 可從簡報中取得所有自訂 XML 部分。每個 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/) 都會公開其識別碼、XML 內容與關聯的命名空間結構。

以下範例列出所有自訂 XML 部分及其命名空間結構：

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    System::Console::WriteLine(System::String(u"ItemId: ") + customXmlPart->get_ItemId().ToString());
    System::Console::WriteLine(u"XML:");
    System::Console::WriteLine(customXmlPart->get_XmlAsString());

    for (auto namespaceSchema : customXmlPart->get_NamespaceSchemas())
    {
        System::Console::WriteLine(System::String(u"Namespace schema: ") + namespaceSchema);
    }

    System::Console::WriteLine();
}
```

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) 會回傳與該自訂 XML 部分關聯的 XML 結構描述。這在稽核包含外部系統產生之 XML 的簡報時相當有用。

### **讀取與更新 XML 內容與 ItemId**

使用 [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) 與 `set_XmlAsString` 以 UTF-8 字串方式操作 XML，或使用 [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_xmldata/) 與 `set_XmlData` 以原始 XML 位元組方式操作。兩種表示法皆可讀取與更新。

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_itemid/) 方法會回傳在 Office Open XML 文件中識別該自訂 XML 部分的 GUID。若整合需要新識別碼，也可以使用 `set_ItemId` 變更該識別碼。

以下範例更新 XML 內容與識別碼：

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlPart = presentation->get_AllCustomXmlParts()->idx_get(0);

// 讀取目前的 XML 為文字。
auto currentXmlContent = customXmlPart->get_XmlAsString();
System::Console::WriteLine(currentXmlContent);

// 更新 XML 為 UTF-8 文字串。
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData 提供相同的 XML 內容作為原始位元組。
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// 根據整合需求替換識別碼。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

在使用 `set_XmlAsString` 或 `set_XmlData` 指定 XML 時，請提供有效且非空的 XML。根據應用程式主要處理字串或位元組資料的需求，選擇其中一種表示法。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種方式移除自訂 XML 資料：

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/remove/) 從簡報中移除自訂 XML 部分。
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/remove/) 從自訂 XML 部分集合中移除特定部件。
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/removeat/) 於指定的集合索引處移除部件。
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/clear/) 移除特定集合中的所有部件。

以下範例依參考移除一個簡報層級的自訂 XML 部分：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto customXmlParts = presentation->get_CustomData()->get_CustomXmlParts();

if (customXmlParts->get_Count() > 0)
{
    auto customXmlPart = customXmlParts->idx_get(0);
    customXmlParts->Remove(customXmlPart);
}

presentation->Save(u"custom_xml_removed.pptx", SaveFormat::Pptx);
```

如果您已擁有 `ICustomXmlPart` 並想直接從簡報中移除該部件，而不是針對特定集合，請呼叫 `customXmlPart->Remove()`。

您也可以依索引移除項目：

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **清除集合中的所有自訂 XML 部分**

當需要移除與特定簡報物件關聯的所有自訂 XML 部分時，可使用 `Clear`。

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->get_Slides()->idx_get(0)->get_CustomData()->get_CustomXmlParts()->Clear();

presentation->Save(u"slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
```

`Clear` 只會影響所選集合。例如，清除投影片的集合不會清除簡報層級或圖形層級的集合。

若要移除簡報中的每一個自訂 XML 部分，可遍歷 `get_AllCustomXmlParts()` 並逐一移除：

```cpp
#include <DOM/ICustomXmlPart.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (auto customXmlPart : presentation->get_AllCustomXmlParts())
{
    customXmlPart->Remove();
}

presentation->Save(u"all_custom_xml_removed.pptx", SaveFormat::Pptx);
```

### **處理連結或共享的自訂 XML 部分**

在 Office Open XML 簡報中，同一自訂 XML 部分可能被多個簡報物件參考。例如，同一檔案可能包含多個投影片或圖形指向相同底層自訂 XML 部分的關聯。

共享的部件應視為單一資料物件，具有多個參考：

- 使用 `set_XmlAsString`、`set_XmlData` 或 `set_ItemId` 進行更新時，會變更底層自訂 XML 部分，因而在所有參考該部件的地方皆會套用變更。
- `get_ItemId()` 可於稽核物件層級集合時辨識相同的自訂 XML 部分。
- 從特定 `get_CustomXmlParts()` 集合中移除部件，只會將其從該集合中拔除。若需將部件本身從簡報中移除，請使用 `ICustomXmlPart::Remove()`。
- 在刪除或取代共享部件之前，請檢查物件層級集合，以判斷是否仍有其他投影片或圖形參考它。

`Add` 的多載會從 XML 內容建立新自訂 XML 部分；不接受既有的 `ICustomXmlPart`。因此，當載入已包含此類關聯的簡報時，最常會遇到共享關聯的情況。

以下範例依 `ItemId` 稽核簡報、投影片與圖形層級的集合，並報告被多處參考的部件：

```cpp
#include <algorithm>
#include <vector>
#include <DOM/ICustomData.h>
#include <DOM/ICustomXmlPart.h>
#include <DOM/ICustomXmlPartCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/string.h>

using namespace Aspose::Slides;

struct CustomXmlReferenceEntry
{
    System::Guid itemId;
    std::vector<System::String> owners;
};

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
std::vector<CustomXmlReferenceEntry> referencesByItemId;

auto registerCustomXmlParts = [&referencesByItemId](
    const System::String& ownerName,
    const System::SharedPtr<ICustomXmlPartCollection>& customXmlParts)
{
    for (int32_t partIndex = 0; partIndex < customXmlParts->get_Count(); ++partIndex)
    {
        auto customXmlPart = customXmlParts->idx_get(partIndex);
        auto itemId = customXmlPart->get_ItemId();

        auto entry = std::find_if(
            referencesByItemId.begin(),
            referencesByItemId.end(),
            [&itemId](const CustomXmlReferenceEntry& referenceEntry)
            {
                return referenceEntry.itemId == itemId;
            });

        if (entry == referencesByItemId.end())
        {
            referencesByItemId.push_back({ itemId, { ownerName } });
        }
        else
        {
            entry->owners.push_back(ownerName);
        }
    }
};

registerCustomXmlParts(u"Presentation", presentation->get_CustomData()->get_CustomXmlParts());

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); ++slideIndex)
{
    auto slide = presentation->get_Slides()->idx_get(slideIndex);
    registerCustomXmlParts(
        System::String::Format(u"Slide {0}", slideIndex + 1),
        slide->get_CustomData()->get_CustomXmlParts());

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
    {
        auto shape = slide->get_Shapes()->idx_get(shapeIndex);
        registerCustomXmlParts(
            System::String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex),
            shape->get_CustomData()->get_CustomXmlParts());
    }
}

for (const auto& referenceEntry : referencesByItemId)
{
    if (referenceEntry.owners.size() > 1)
    {
        System::Console::WriteLine(
            System::String(u"Shared custom XML part: ") + referenceEntry.itemId.ToString());

        for (const auto& ownerName : referenceEntry.owners)
        {
            System::Console::WriteLine(System::String(u"  Referenced by: ") + ownerName);
        }
    }
}
```

在修改或刪除由外部系統建立的簡報之自訂 XML 資料之前，進行此類稽核非常有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標記的值**

在 Slides 中，標記對應 `IDocumentProperties::get_Keywords` 屬性。以下範例程式碼示範如何使用 Aspose.Slides for C++ 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的標記值：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **將標記加入簡報**

Aspose.Slides 允許您為簡報加入標記。標記通常由兩個項目組成：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

如果需要根據特定規則或屬性對簡報進行分類，您可以加入標記。例如，若要將來自北美國家的簡報分類，可建立「北美」標記，並將相關國家作為其值。

以下範例示範如何使用 Aspose.Slides for C++ 為 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 加入標記：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

標記也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/)：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

或於單一 [Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/)：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICustomData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITagCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **限制**

透過 `get_CustomData()->get_Tags()` 集合加入的標記僅儲存在 PowerPoint 檔案中。匯出為 PDF 時，它們 **不會** 轉移至 PDF 的標記結構。因此，作為標記的自訂識別碼無法從已加標記的 PDF 中取得。

**解決方法**：您可以將自訂識別碼存放於物件的 **Alt Text**（例如 `shape->set_AlternativeText(u"MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標記結構中。

## **常見問題**

**我能否一次性移除簡報、投影片或圖形中的所有標記？**

可以。[標記集合](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 支援 [Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/clear/) 作業，一次刪除所有鍵值配對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標記？**

在 [TagCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 上使用 [Remove(name)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/remove/) 即可依鍵刪除標記。

**如何取得全部標記名稱的清單，以進行分析或篩選？**

在 [標記集合](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 上使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/getnamesoftags/)，會回傳所有標記名稱的陣列。

**如何找出所有自訂 XML 部分，無論它們儲存於何處？**

使用 [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_allcustomxmlparts/) 取得簡報中所有自訂 XML 部分。

**在更新自訂 XML 部分時，我應該使用 `get_XmlAsString`/`set_XmlAsString` 還是 `get_XmlData`/`set_XmlData`？**

當應用程式以 UTF-8 XML 文字為主時，使用 `get_XmlAsString` 與 `set_XmlAsString`。當 XML 已以位元組陣列形式存在，或二進位導向的処理較方便時，使用 `get_XmlData` 與 `set_XmlData`。兩種表示法皆指向同一自訂 XML 部分的內容。