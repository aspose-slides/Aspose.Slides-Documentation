---
title: 在 .NET 中管理簡報的標籤和自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/net/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 自訂 XML
- 自訂 XML 部分
- XML 中繼資料
- ItemId
- 新增標籤
- 鍵值對
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 管理 PowerPoint 簡報中的標籤與自訂 XML 資料，包括新增、讀取、更新、稽核與移除自訂 XML 部分。"
---
## **概觀**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤與自訂資料。簡報特定的資料可以以標籤或自訂 XML 部分儲存。標籤是簡單的鍵值字串對，而自訂 XML 部分則可存放結構化的中繼資料與應用程式專屬的 XML 載荷。  
Aspose.Slides 提供 API 用於在簡報、投影片與形狀層級上新增、讀取、更新、稽核與移除自訂 XML 部分。自訂 XML 部分對於整合應用非常有用，可在簡報中儲存諸如文件管理識別碼、工作流程狀態、合規性中繼資料、範本繫結資料或其他結構化應用程式資料等資訊。

## **簡報檔案中的資料儲存**

PPTX 檔案——副檔名為 `.pptx` 的檔案——以 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部分。Office Open XML 定義了用於儲存簡報內容與相關資料的封裝結構與關聯性。  
一個簡報由多個透過關聯連結的部件組成。例如，投影片部件包含單一投影片的內容，且可對其他部件具有 ISO/IEC 29500 定義的明確關聯。  
自訂資料可以以標籤 ([ITagCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itagcollection)) 或自訂 XML 部分 ([ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpartcollection)) 儲存。兩者皆可透過 [`ICustomData`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomdata/) 介面取得。

{{% alert color="info" %}}
標籤儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可與簡報、投影片或形狀關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomdata/customxmlparts/) 屬性會回傳與特定簡報物件關聯的自訂 XML 部分集合。例如：

- `presentation.CustomData.CustomXmlParts` 包含與簡報本身關聯的自訂 XML 部分。
- `slide.CustomData.CustomXmlParts` 包含與特定投影片關聯的自訂 XML 部分。
- `shape.CustomData.CustomXmlParts` 包含與特定形狀關聯的自訂 XML 部分。

當需要檢查簡報中所有自訂 XML 部分（不論其關聯於何處）時，可使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/allcustomxmlparts/)。

### **將自訂 XML 部分新增至簡報**

使用 [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpartcollection/add/) 可將 XML 資料新增至自訂 XML 部分集合。XML 必須是有效且非空的。  
下列範例將結構化的中繼資料新增至簡報層級的自訂資料集合：

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add 會自動指派識別碼。僅在需要時才設定特定的 GUID。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

`Add` 方法也可接受 XML 的位元組陣列或串流，這在 XML 內容已以二進位形式存在時相當有用。

### **將自訂 XML 部分新增至投影片或形狀**

自訂 XML 資料可以關聯至特定投影片或形狀，而非整個簡報。當中繼資料僅描述單一物件（例如範本金鑰、外部記錄識別碼或繫結資訊）時，這非常有用。  
以下範例將一個自訂 XML 部分新增至投影片，另一個新增至形狀：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

新增部件的層級決定了哪個物件的 `CustomData.CustomXmlParts` 集合會包含與該部件的關聯。簡報層級的資料適用於全文件的中繼資料，投影片層級的資料則屬於特定投影片的資訊，而形狀層級的資料則綁定於單一形狀的中繼資料。

### **列出並稽核所有自訂 XML 部分**

使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/allcustomxmlparts/) 可從簡報中取得所有自訂 XML 部分。每個 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpart/) 都會顯示其識別碼、XML 內容以及相關的命名空間結構描述。  
以下範例列出所有自訂 XML 部分及其命名空間結構描述：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpart/namespaceschemas/) 會回傳與自訂 XML 部分關聯的 XML 結構描述。當稽核包含外部系統產生 XML 的簡報時，這資訊相當有用。

### **讀取與更新 XML 內容及 ItemId**

使用 [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpart/xmlasstring/) 以 UTF-8 字串方式操作 XML，或使用 [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpart/xmldata/) 以原始 XML 位元組方式操作。兩個屬性皆可讀取與更新。  
`[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpart/itemid/)` 屬性包含在 Office Open XML 文件中識別自訂 XML 部分的 GUID。當整合需要新識別碼時，也可以變更此屬性。  
以下範例更新 XML 內容與識別碼：

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// 讀取目前的 XML 為文字。
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// 以 UTF-8 字串更新 XML。
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData 以原始位元組提供相同的 XML 內容。
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// 整合需求時置換識別碼。
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

在指派 `XmlAsString` 或 `XmlData` 時，請提供有效且非空的 XML。依應用程式主要使用字串或位元組資料的情況，選擇其中一種表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種方式移除自訂 XML 資料：

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpart/remove/) 會從簡報中移除自訂 XML 部分。  
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpartcollection/remove/) 從自訂 XML 部分集合中移除特定部件。  
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpartcollection/removeat/) 依指定的集合索引移除部件。  
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icustomxmlpartcollection/clear/) 會清除特定集合中的所有部件。  

以下範例以參考方式移除一個簡報層級的自訂 XML 部分：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

如果已擁有 `ICustomXmlPart`，且想直接從簡報中移除該部件而非針對特定集合，請呼叫 `customXmlPart.Remove()`。  
也可以依索引移除項目：

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **從集合中清除所有自訂 XML 部分**

當需要移除與特定簡報物件關聯的所有自訂 XML 部分時，使用 `Clear`。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` 只會影響所選的集合。例如，清除投影片的集合不會清除簡報層級或形狀層級的集合。  
若要移除簡報中的所有自訂 XML 部分，可遍歷 `AllCustomXmlParts` 並逐一移除：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **處理連結或共享的自訂 XML 部分**

在 Office Open XML 簡報中，同一個自訂 XML 部分可以被多個簡報物件參考。例如，現有檔案可能包含來自多個投影片或形狀指向相同底層自訂 XML 部分的關聯。  
共享的部件應視為具有多個參考的一個資料物件：

- 更新其 `XmlAsString`、`XmlData` 或 `ItemId` 會修改底層自訂 XML 部分，因而在所有參考該部件的地方皆會套用變更。  
- `ItemId` 可用於在稽核物件層級集合時辨識相同的自訂 XML 部分。  
- 從特定 `CustomXmlParts` 集合中移除部件，只會從該集合移除。若要將部件本身從簡報中移除，請使用 `ICustomXmlPart.Remove()`。  
- 在刪除或取代共享部件之前，請檢查物件層級的集合，以判斷是否仍有其他投影片或形狀參考它。  

`Add` 重載會根據 XML 內容建立新的自訂 XML 部分；它們不接受已存在的 `ICustomXmlPart`。因此，共享關聯最常在載入已包含此類部件的簡報時遇到。  
以下範例依據 `ItemId` 稽核簡報、投影片與形狀層級的集合，並報告被多處參考的部件：

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

此類稽核在修改或刪除外部系統產生的簡報中的自訂 XML 資料之前非常有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標籤值**

在 Slides 中，標籤對應到 `IDocumentProperties.Keywords` 屬性。以下範例程式碼示範如何使用 Aspose.Slides for .NET 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 的標籤值：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **將標籤新增至簡報**

Aspose.Slides 允許您為簡報新增標籤。標籤通常由兩項組成：

- 自訂屬性的名稱，例如 `MyTag`；  
- 自訂屬性的值，例如 `My Tag Value`。  

如果需要根據特定規則或屬性對簡報進行分類，可以新增相應的標籤。例如，若要將北美國家的簡報分類，您可以建立一個北美標籤，並將相關國家指定為其值。  
以下範例程式碼示範如何使用 Aspose.Slides for .NET 為 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 新增標籤：

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

也可以為 [Slide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide) 設定標籤：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

或為單一 [Shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape) 設定標籤：

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **限制**

透過 `CustomData.Tags` 集合新增的標籤僅儲存在 PowerPoint 檔案中。當簡報匯出成 PDF 時，這些標籤 **不會** 轉移至 PDF 的標籤結構。因此，作為標籤的自訂識別碼無法從已標記的 PDF 中取得。  
**解決方案**：您可以將自訂識別碼存放於物件的 **Alt Text**（例如 `shape.AlternativeText = "MyId"`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 的標籤結構中。

## **常見問題**

**我可以一次移除簡報、投影片或形狀的所有標籤嗎？**  
可以。[tag collection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/) 支援 [Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/clear/) 操作，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，僅依名稱刪除單一標籤？**  
在 [TagCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/) 上使用 [Remove(name)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/remove/) 以鍵名刪除標籤。

**我要如何取得所有標籤名稱的完整清單以進行分析或篩選？**  
在 [tag collection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/) 上使用 [GetNamesOfTags](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/tagcollection/getnamesoftags/)，它會回傳所有標籤名稱的陣列。

**我要如何找出所有自訂 XML 部分，無論它們儲存在何處？**  
使用 [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/allcustomxmlparts/) 以取得簡報中所有自訂 XML 部分。

**應該使用 `XmlAsString` 還是 `XmlData` 來更新自訂 XML 部分？**  
當應用程式使用 UTF-8 XML 文字時，使用 `XmlAsString`。當 XML 已以位元組陣列形式存在，或二進位處理較為方便時，使用 `XmlData`。兩個屬性皆表示同一自訂 XML 部分的 XML 內容。