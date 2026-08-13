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
- 自訂 XML
- 自訂 XML 部分
- XML 中繼資料
- ItemId
- 新增標籤
- 成對值
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中管理標籤與自訂 XML 資料，包括新增、讀取、更新、稽核與移除自訂 XML 部分。"
---
## **概觀**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤與自訂資料。簡報的特定資料可以以標籤或自訂 XML 部分的形式儲存。標籤是簡單的鍵值字串對，而自訂 XML 部分則可儲存結構化的中繼資料與應用程式特定的 XML 載荷。

Aspose.Slides 提供在簡報、投影片與圖形層級新增、讀取、更新、稽核與移除自訂 XML 部分的 API。自訂 XML 部分對於需要在簡報內儲存如文件管理識別碼、工作流程狀態、合規性中繼資料、範本綁定資料或其他結構化應用程式資料的整合非常有用。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx`）採用 PresentationML 格式，屬於 Office Open XML 規範的一部份。Office Open XML 定義了用於儲存簡報內容與相關資料的封裝結構與關聯。

一個簡報包含多個由關聯連接的部件。例如，投影片部件包含單一投影片的內容，並可與其他依 ISO/IEC 29500 定義的部件建立明確的關聯。

自訂資料可以以標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itagcollection/)）或自訂 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/)）的形式儲存。這兩者皆可透過 [`ICustomData`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomdata/) 介面存取。

{{% alert color="info" %}}
標籤儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可以與簡報、投影片或圖形關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

[`ICustomData::get_CustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomdata/get_customxmlparts/) 方法會傳回與特定簡報物件關聯的自訂 XML 部分集合。例如：

- `presentation->get_CustomData()->get_CustomXmlParts()` 包含與整個簡報關聯的自訂 XML 部分。
- `slide->get_CustomData()->get_CustomXmlParts()` 包含與特定投影片關聯的自訂 XML 部分。
- `shape->get_CustomData()->get_CustomXmlParts()` 包含與特定圖形關聯的自訂 XML 部分。

當需要檢查簡報中所有自訂 XML 部分（不論關聯於何處）時，使用 [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_allcustomxmlparts/)。

### **將自訂 XML 部分新增至簡報**

使用 [`ICustomXmlPartCollection::Add`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/add/) 將 XML 資料新增至自訂 XML 部分集合。XML 必須有效且非空。

以下示例將結構化的中繼資料新增至簡報層級的自訂資料集合：

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

`Add` 方法也可以接受位元組陣列或串流形式的 XML，這在 XML 已以二進位形式取得時相當有用。

### **將自訂 XML 部分新增至投影片或圖形**

自訂 XML 資料也可以關聯至特定投影片或圖形，而非整個簡報。當中繼資料僅描述單一物件（例如範本金鑰、外部記錄識別碼或綁定資訊）時，此方式非常實用。

以下示例將一個自訂 XML 部分新增至投影片，另一個新增至圖形：

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

新增部件的層級決定了哪個物件的 `get_CustomData()->get_CustomXmlParts()` 集合會包含與該部件的關聯。簡報層級的資料適用於整份文件的中繼資料，投影片層級的資料適用於屬於特定投影片的資訊，圖形層級的資料則用於與單一圖形相關的中繼資料。

### **列出並稽核所有自訂 XML 部分**

使用 [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_allcustomxmlparts/) 取得簡報中的全部自訂 XML 部分。每個 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/) 都會顯示其識別碼、XML 內容以及相關的命名空間綱要。

以下示例列出所有自訂 XML 部分及其命名空間綱要：

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

[`ICustomXmlPart::get_NamespaceSchemas`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_namespaceschemas/) 會回傳與該自訂 XML 部分關聯的 XML 綱要。此資訊在稽核包含外部系統產生 XML 的簡報時相當有用。

### **讀取與更新 XML 內容與 ItemId**

使用 [`ICustomXmlPart::get_XmlAsString`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_xmlasstring/) 與 `set_XmlAsString` 以 UTF-8 字串方式操作 XML，或使用 [`ICustomXmlPart::get_XmlData`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_xmldata/) 與 `set_XmlData` 以原始位元組方式操作。兩種表示法皆可讀取與更新。

[`ICustomXmlPart::get_ItemId`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/get_itemid/) 會傳回用於在 Office Open XML 文件中識別自訂 XML 部分的 GUID。若整合需求需要新識別碼，也可使用 `set_ItemId` 變更此識別碼。

以下示例同時更新 XML 內容與識別碼：

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

// 以 UTF-8 字串更新 XML。
customXmlPart->set_XmlAsString(
    u"<metadata xmlns=\"urn:example:metadata\">"
        u"<documentId>DOC-1001</documentId>"
        u"<workflowState>Approved</workflowState>"
    u"</metadata>");

// XmlData 以原始位元組形式提供相同的 XML 內容。
auto customXmlData = customXmlPart->get_XmlData();
System::Console::WriteLine(System::Text::Encoding::get_UTF8()->GetString(customXmlData));

// 當整合需要時，取代識別碼。
customXmlPart->set_ItemId(System::Guid::NewGuid());

presentation->Save(u"updated_custom_xml.pptx", SaveFormat::Pptx);
```

在以 `set_XmlAsString` 或 `set_XmlData` 指定 XML 時，請提供有效且非空的 XML。依應用程式主要使用字串或位元組資料的情況，選擇其中一種表示法即可。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種方式移除自訂 XML 資料：

- [`ICustomXmlPart::Remove`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpart/remove/) 從簡報中移除該自訂 XML 部分。
- [`ICustomXmlPartCollection::Remove`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/remove/) 從自訂 XML 部分集合中移除特定部件。
- [`ICustomXmlPartCollection::RemoveAt`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/removeat/) 依集合索引移除部件。
- [`ICustomXmlPartCollection::Clear`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icustomxmlpartcollection/clear/) 移除集合中的所有部件。

以下示例依參考移除一個簡報層級的自訂 XML 部分：

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

如果已取得 `ICustomXmlPart`，想直接從簡報中移除該部件（而非針對特定集合），只需呼叫 `customXmlPart->Remove()`。

也可以依索引移除項目：

```cpp
presentation->get_CustomData()->get_CustomXmlParts()->RemoveAt(0);
```

### **一次清除集合中的全部自訂 XML 部分**

當需要移除與特定簡報物件關聯的所有自訂 XML 部分時，使用 `Clear`。

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

`Clear` 只會影響被選取的集合。例如，清除投影片的集合不會影響簡報層級或圖形層級的集合。

若要移除簡報中所有自訂 XML 部分，可遍歷 `get_AllCustomXmlParts()` 並逐一移除：

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

### **處理已連結或共享的自訂 XML 部分**

在 Office Open XML 簡報中，同一個自訂 XML 部分可能被多個簡報物件參考。例如，現有檔案可能包含多個投影片或圖形對同一底層自訂 XML 部分的關聯。

共享的部件應視為單一資料物件，只是有多個參考：

- 使用 `set_XmlAsString`、`set_XmlData` 或 `set_ItemId` 進行更新時，會變更底層自訂 XML 部分，因而在所有參考處同步生效。
- `get_ItemId()` 可用於在稽核物件層級集合時辨識相同的自訂 XML 部分。
- 從特定 `get_CustomXmlParts()` 集合中移除部件，只會將其從該集合中移除。若需將部件本身從整個簡報中移除，請使用 `ICustomXmlPart::Remove()`。
- 在刪除或取代共享部件之前，先檢查物件層級的集合，以確定是否仍有其他投影片或圖形參考它。

`Add` 的多載會根據 XML 內容建立新自訂 XML 部分，並不接受既有的 `ICustomXmlPart`。因此，當載入已包含共享關聯的簡報時，最常會遇到此情況。

以下示例依 `ItemId` 稽核簡報、投影片與圖形層級的集合，並報告被多處參考的部件：

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

此類稽核在修改或刪除外部系統產生的簡報中的自訂 XML 資料之前非常有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標籤值**

在 Slides 中，標籤對應 `IDocumentProperties::get_Keywords` 屬性。以下範例程式碼示範如何使用 Aspose.Slides for C++ 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的標籤值：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto keywords = presentation->get_DocumentProperties()->get_Keywords();
```

## **為簡報新增標籤**

Aspose.Slides 允許您為簡報新增標籤。標籤通常由兩個項目組成：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

如果需要依特定規則或屬性對簡報進行分類，可新增相應的標籤。例如，要將北美國家的簡報歸類，可建立「NorthAmerican」標籤並將相關國家設為其值。

以下範例示範如何使用 Aspose.Slides for C++ 為 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 新增標籤：

```cpp
#include <DOM/ICustomData.h>
#include <DOM/ITagCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto tags = presentation->get_CustomData()->get_Tags();
tags->idx_set(u"MyTag", u"My Tag Value");
```

標籤也可以為 [Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/) 設定：

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

或為單一 [Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/) 設定：

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

### **限制條件**

透過 `get_CustomData()->get_Tags()` 集合新增的標籤僅儲存在 PowerPoint 檔案中。匯出為 PDF 時，這些標籤 **不會** 轉換為 PDF 的標籤結構。因此，作為標籤的自訂識別碼無法在已標籤的 PDF 中取得。

**解決方法**：可將自訂識別碼儲存在物件的 **Alt Text**（例如 `shape->set_AlternativeText(u"MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 的標籤結構中。

## **常見問題集**

**我可以一次性移除簡報、投影片或圖形中的所有標籤嗎？**  
可以。[標籤集合](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 支援 [Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/clear/) 作業，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**  
使用 [Remove(name)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/remove/) 於 [TagCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/) 直接依鍵名刪除標籤。

**如何取得所有標籤名稱的完整清單以供分析或過濾？**  
使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/getnamesoftags/) 於 [標籤集合](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/tagcollection/)，會回傳所有標籤名稱的陣列。

**我要如何找出所有自訂 XML 部分，無論它們儲存在何處？**  
使用 [`Presentation::get_AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_allcustomxmlparts/) 取得簡報中所有自訂 XML 部分。

**在更新自訂 XML 部分時，我該使用 `get_XmlAsString`/`set_XmlAsString`，還是 `get_XmlData`/`set_XmlData`？**  
當應用程式以 UTF-8 XML 文字為主時，使用 `get_XmlAsString` 與 `set_XmlAsString`。當 XML 已以位元組陣列形式存在，或二進位處理較方便時，使用 `get_XmlData` 與 `set_XmlData`。兩者皆指向同一自訂 XML 部分的內容。