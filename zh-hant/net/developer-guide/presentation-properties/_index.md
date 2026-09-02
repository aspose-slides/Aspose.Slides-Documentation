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

Aspose.Slides for .NET 支援兩種文件屬性類型：**內建**和**自訂**。這兩種屬性類型都可以透過 Aspose.Slides for .NET API 輕鬆存取與管理。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [Presentation.DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/documentproperties/) 屬性回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意，**Application** 與 **Producer** 欄位無法被修改，因為這些欄位始終會顯示 "Aspose Ltd." 與 "Aspose.Slides for .NET x.x.x"。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔案中加入屬性的功能。這些文件屬性允許將有用的資訊與檔案一起儲存。文件屬性分為兩種類型：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建**屬性包含文件的一般資訊，例如文件標題、作者名稱、文件統計資料等。

**自訂**屬性由使用者以 **名稱/值** 配對的方式定義，名稱與值皆由使用者自行指定。

使用 Aspose.Slides for .NET，開發人員可以存取並修改內建與自訂屬性。

Microsoft PowerPoint 允許使用者點選 Office 圖示，然後選取 **檔案 → 資訊 → 屬性** 來管理文件屬性。選擇 **進階屬性** 後，會出現對話方塊，您可以在其中管理簡報檔案的所有文件屬性。

在 **屬性** 對話方塊中，有多個分頁，如 **一般**、**摘要**、**統計**、**內容** 與 **自訂**。每個分頁提供設定與 PowerPoint 檔案相關的特定資訊的選項。**自訂** 分頁用於管理使用者自訂的屬性。

## **存取內建屬性**

這些屬性由 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面提供，包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**SharedDoc**（指示文件是否在不同製作者之間共享）、**PresentationFormat**、**Subject**、**Title** 等。

```cs
using Aspose.Slides;

// 建立代表簡報檔案的 Presentation 類別實例。
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

修改簡報檔案的內建屬性與存取它們同樣簡單。只需將字串值指派給任意所需的屬性，即可更新屬性值。以下範例示範如何修改簡報檔案的內建文件屬性。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立代表簡報檔案的 Presentation 類別實例。
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// 取得與簡報相關聯的 IDocumentProperties 物件參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 設定內建屬性。
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// 將簡報儲存至檔案。
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **新增自訂簡報屬性**

自訂簡報屬性讓開發人員能在簡報檔案中儲存額外的中繼資料或特定資訊。Aspose.Slides 提供簡便的程式化方式建立與管理這些自訂屬性。以下範例示範如何將自訂屬性新增至您的簡報。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立 Presentation 類別的實例。
using Presentation presentation = new Presentation();

// 取得與簡報相關聯的 IDocumentProperties 物件參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 新增自訂屬性。
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// 將簡報儲存至檔案。
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **存取與修改自訂屬性**

Aspose.Slides 亦允許開發人員輕鬆存取現有的自訂屬性並修改其值。此功能有助於維持正確的中繼資料，並支援根據使用者輸入或業務邏輯的動態更新。以下範例說明如何在簡報中取得與更新自訂屬性值。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 建立代表 PPTX 檔案的 Presentation 類別實例。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// 取得與簡報相關聯的 IDocumentProperties 物件參考。
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

// 將簡報儲存至檔案。
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **即時範例**

試試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 了解如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部份，無法完全移除。然而，您可以變更其值，或在特定屬性允許的情況下將其設為空白。

**如果新增的自訂屬性已存在，會發生什麼情況？**

若新增的自訂屬性已存在，原有的值會被新值覆寫。您不需要事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性值。

**是否能在不完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 再搭配 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/net/examine-presentation/) 取得完整的報告範例與格式特定的限制說明。