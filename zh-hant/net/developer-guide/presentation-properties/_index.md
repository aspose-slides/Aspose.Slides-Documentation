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
description: "在 Aspose.Slides for .NET 中精通簡報屬性，並簡化 PowerPoint 與 OpenDocument 檔案的搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for .NET 支援兩種類型的文件屬性：**內建**和**自訂**。這兩種屬性類型都可以輕鬆使用 Aspose.Slides for .NET API 進行存取與管理。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面處理簡報文件屬性。此介面的實例由 [Presentation.DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/documentproperties/) 屬性返回。以下範例展示如何讀取、修改和管理這些屬性。

{{% alert color="info" %}} 
請注意，**Application** 和 **Producer** 欄位無法修改，因為這些欄位始終顯示「Aspose Ltd.」以及「Aspose.Slides for .NET x.x.x」。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供將屬性加入簡報檔案的功能。這些文件屬性允許將有用資訊與檔案一起儲存。文件屬性有兩種類型：

- 系統定義的（內建）屬性
- 使用者定義的（自訂）屬性

**內建** 屬性包含文件的一般資訊，例如文件標題、作者姓名、文件統計資料等。

**自訂** 屬性由使用者以 **Name/Value** 配對方式定義，名稱與值皆由使用者指定。

使用 Aspose.Slides for .NET，開發人員可以存取與修改內建與自訂屬性。

Microsoft PowerPoint 允許使用者點選 Office 圖示，然後選取 **File → Info → Properties** 來管理文件屬性。選擇 **Advanced Properties** 後，會出現對話框，您可以在其中管理簡報檔案的所有文件屬性。

在 **Properties** 對話框中，有多個分頁，例如 **General**、**Summary**、**Statistics**、**Contents** 和 **Custom**。每個分頁提供設定與 PowerPoint 檔案相關之特定資訊類型的選項。**Custom** 分頁用於管理使用者定義的屬性。

## **存取內建屬性**

這些屬性透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面公開，包含：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**SharedDoc**（表示文件是否在不同製作者之間共享）、**PresentationFormat**、**Subject**、**Title**，以及其他。

```cs
using Aspose.Slides;

// Instantiate the Presentation class that represents a presentation file.
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

修改簡報檔案的內建屬性和存取它們一樣簡單。您只需要將字串值指派給任意想要的屬性，即可更新該屬性的值。以下範例示範如何修改簡報檔案的內建文件屬性。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// 取得與簡報相關聯的 IDocumentProperties 物件的參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 設定內建屬性。
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// 將簡報另存為檔案。
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **新增自訂簡報屬性**

自訂簡報屬性讓開發人員能在簡報檔案中儲存額外的中繼資料或特定資訊。Aspose.Slides 讓以程式方式建立與管理這些自訂屬性變得簡單。以下範例示範如何將自訂屬性新增至您的簡報。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化 Presentation 類別。
using Presentation presentation = new Presentation();

// 取得與簡報相關聯的 IDocumentProperties 物件的參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 新增自訂屬性。
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// 將簡報儲存為檔案。
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **存取與修改自訂屬性**

Aspose.Slides 亦允許開發人員輕鬆存取現有的自訂屬性並修改其值。此功能有助於維持正確的中繼資料，並支援根據使用者輸入或業務邏輯的動態更新。以下範例說明如何在簡報中取得與更新自訂屬性值。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate the Presentation class that represents a PPTX file.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Display the name and value of the custom property.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modify the value of the custom property.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Save the presentation to a file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **即時範例**

嘗試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 以了解如何使用 Aspose.Slides API 處理文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## ***常見問題**

### 如何從簡報中移除內建屬性？

內建屬性是簡報的核心組成部分，無法完全移除。不過，您可以變更其值，或在該屬性允許的情況下將其設為空值。

### 如果新增的自訂屬性已存在，會發生什麼情況？

如果新增的自訂屬性已存在，其現有值會被新值覆寫。您無需事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

### 是否可以在不完整載入簡報的情況下存取簡報屬性？

是的，您可以透過使用 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/) 類別的 `GetPresentationInfo` 方法，在不完整載入簡報的情況下存取簡報屬性。接著，利用 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/) 介面提供的 `ReadDocumentProperties` 方法有效讀取屬性，節省記憶體並提升效能。