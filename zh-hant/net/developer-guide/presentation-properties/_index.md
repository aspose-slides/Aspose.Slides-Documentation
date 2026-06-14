---
title: 在 .NET 中管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/net/presentation-properties/
keywords:
- PowerPoint 屬性
- 簡報屬性
- 文件屬性
- 內建屬性
- 自訂屬性
- 進階屬性
- 管理屬性
- 修改屬性
- 文件中繼資料
- 編輯中繼資料
- 校對語言
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中精通簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for .NET 支援兩種文件屬性類型：**內建**和**自訂**。這兩種屬性類型皆可透過 Aspose.Slides for .NET API 輕鬆存取與管理。

Aspose.Slides 讓您可透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [Presentation.DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/documentproperties/) 屬性回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="primary" %}} 
請注意，**Application** 與 **Producer** 欄位無法修改，因為這兩個欄位會始終顯示「Aspose Ltd.」以及「Aspose.Slides for .NET x.x.x」。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供了向簡報檔案添加屬性的功能。這些文件屬性可將有用資訊與檔案一起儲存。文件屬性分為兩種：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建**屬性包含有關文件的一般資訊，如文件標題、作者姓名、文件統計資料等。

**自訂**屬性由使用者以 **Name/Value**（名稱/值）配對定義，名稱與值皆由使用者指定。

使用 Aspose.Slides for .NET，開發人員可以存取與修改內建與自訂屬性。

Microsoft PowerPoint 允許使用者點選 Office 圖示，然後選擇 **File → Info → Properties** 來管理文件屬性。選取 **Advanced Properties** 後，會出現對話方塊，讓您管理簡報檔的所有文件屬性。

在 **Properties** 對話方塊中，有多個分頁，例如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。每個分頁提供設定 PowerPoint 檔案相關特定資訊的選項。**Custom** 分頁用於管理使用者自訂的屬性。

## **存取內建屬性**

這些屬性由 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面提供，包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**SharedDoc**（表示文件是否在不同製作者之間共享）、**PresentationFormat**、**Subject**、**Title** 等。

```cs
// 實例化代表簡報檔案的 Presentation 類別。
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **修改內建屬性**

修改簡報檔案的內建屬性與存取它們同樣簡單。只要將字串值指派給任意屬性，即可更新該屬性的值。以下範例示範如何修改簡報檔的內建文件屬性。

```cs
// 實例化代表簡報檔案的 Presentation 類別。
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// 取得與簡報關聯的 IDocumentProperties 物件參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 設定內建屬性。
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// 將簡報儲存為檔案。
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **新增自訂簡報屬性**

自訂簡報屬性讓開發人員能在簡報檔案中儲存額外的中繼資料或特定資訊。Aspose.Slides 讓程式化建立與管理這些自訂屬性變得簡單。以下範例示範如何將自訂屬性新增至簡報。

```cs
// 實例化 Presentation 類別。
using Presentation presentation = new Presentation();

// 取得與簡報關聯的 IDocumentProperties 物件參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 新增自訂屬性。
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// 將簡報儲存為檔案。
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **存取與修改自訂屬性**

Aspose.Slides 亦讓開發人員能輕鬆存取現有的自訂屬性並修改其值。此功能有助於維持正確的中繼資料，並支援根據使用者輸入或業務邏輯進行動態更新。以下範例說明如何在簡報中取得與更新自訂屬性值。

```cs
// 實例化代表 PPTX 檔案的 Presentation 類別。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// 取得與簡報關聯的 IDocumentProperties 物件參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 存取並修改自訂屬性。
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // 顯示自訂屬性的名稱與值。
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // 修改自訂屬性的值。
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// 將簡報儲存為檔案。
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **實作範例**

Try the [**檢視與編輯 PowerPoint 中繼資料**](https://products.aspose.app/slides/zh-hant/metadata) online app to see how to work with document properties using the Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## ***FAQ**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。但您可以變更其值，或在特定屬性允許的情況下將其設為空值。

**如果新增的自訂屬性已存在，會發生什麼情況？**

若新增的自訂屬性已存在，其現有值會被新值覆寫。您不需要事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**我能在不完整載入簡報的情況下存取簡報屬性嗎？**

可以，您可透過使用 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/) 類別的 `GetPresentationInfo` 方法，在不完整載入簡報的情況下存取簡報屬性。接著，使用 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/) 介面提供的 `ReadDocumentProperties` 方法，能有效讀取屬性，節省記憶體並提升效能。