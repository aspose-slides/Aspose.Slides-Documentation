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
description: "在 Aspose.Slides for .NET 中掌握簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中精簡搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for .NET 支援兩種文件屬性類型：**內建** 與 **自訂**。這兩種屬性類型均可透過 Aspose.Slides for .NET API 輕鬆存取與管理。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/documentproperties/) 取得。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}

請注意，**Application** 與 **Producer** 欄位無法修改，因為這兩個欄位永遠會顯示「Aspose Ltd.」與「Aspose.Slides for .NET x.x.x」。

{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔案中新增屬性的功能。這些文件屬性允許將有用的資訊與檔案一起儲存。文件屬性有兩種類型：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建** 屬性包含關於文件的一般資訊，例如文件標題、作者名稱、文件統計資料等。

**自訂** 屬性則由使用者以 **名稱/值** 配對的方式定義，名稱與值皆由使用者自行指定。

使用 Aspose.Slides for .NET，開發人員可以存取與修改內建及自訂屬性。

Microsoft PowerPoint 允許使用者透過點選 Office 圖示，然後選取 **File → Info → Properties** 來管理文件屬性。選擇 **Advanced Properties** 後，會出現對話框，您可以在其中管理簡報檔案的所有文件屬性。

在 **Properties** 對話框中，有多個分頁，如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。每個分頁提供設定與 PowerPoint 檔案相關的特定資訊的選項。**Custom** 分頁用於管理使用者自訂屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。當簡報以 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 設為 `false` 加密時，其文件屬性仍為公開。此時應用程式可以將 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 設為 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

`OnlyLoadDocumentProperties` 控制 Aspose.Slides 載入的內容；它不會解密任何資料。如果屬性已被加密，未提供密碼的載入將失敗。若簡報未加密，則此選項會被忽略，完整簡報會被載入。

以下範例透過 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 驗證載入模式，接著透過 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/documentproperties/) 讀取內建屬性：

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

在此模式下，幻燈片內容不會被載入。幻燈片、母片、版面配置、圖形、媒體及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應先檢查 `IsOnlyDocumentPropertiesLoaded`。

{{% alert color="warning" title="Security" %}}
公開的中繼資料可能會洩漏作者名稱、標題、主旨、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一併加密。只有在索引、分類、搜尋或文件管理系統需要在無密碼情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，使用 `OnlyLoadDocumentProperties` 載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法從僅含公開屬性的物件中儲存變更，因為公開屬性必須與加密簡報內的相應資料保持一致。因此，更新這些屬性需要正確的開啟密碼與完整載入。

以下範例使用 [LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 開啟簡報，更新公開的內建屬性，並儲存結果。然後利用 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/isencrypted/) 驗證加密仍然保留，並在不提供密碼的情況下重新開啟公開中繼資料，以驗證新值：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

如果應用程式不被允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

這些屬性由 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 介面公開，包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**SharedDoc**（指示文件是否在不同製作者間共享）、**PresentationFormat**、**Subject**、**Title** 等等。

```cs
using Aspose.Slides;

// 實例化代表簡報檔案的 Presentation 類別。
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// 取得與簡報相關聯的 IDocumentProperties 類型物件的參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 顯示內建屬性。
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

修改簡報檔案的內建屬性與存取它們一樣簡單。只需將字串值指定給任意想要的屬性，即可更新屬性值。以下範例示範如何修改簡報檔案的內建文件屬性。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// 取得與簡報相關聯的 IDocumentProperties 類型物件的參考。
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

自訂簡報屬性讓開發人員能在簡報檔案中儲存額外的中繼資料或特定資訊。Aspose.Slides 使以程式方式建立與管理這些自訂屬性變得輕鬆。以下範例示範如何在簡報中新增自訂屬性。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化 Presentation 類別。
using Presentation presentation = new Presentation();

// 取得與簡報相關聯的 IDocumentProperties 類型物件的參考。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 新增自訂屬性。
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// 將簡報儲存至檔案。
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **存取與修改自訂屬性**

Aspose.Slides 亦允許開發人員存取現有自訂屬性並輕鬆修改其值。此功能有助於維持正確的中繼資料，並支援根據使用者輸入或業務邏輯動態更新。以下範例說明如何在簡報中取得與更新自訂屬性值。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表 PPTX 檔案的 Presentation 類別。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// 取得與簡報相關聯的 IDocumentProperties 類型物件的參考。
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

使用線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 試看看如何使用 Aspose.Slides API 處理文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問答**

**如何移除簡報中的內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。不過，您可以更改其值，或在特定屬性允許的情況下將其設為空值。

**如果新增已存在的自訂屬性會發生什麼事？**

若新增已存在的自訂屬性，原有的值會被新值覆寫。您不需要事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性值。

**可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 然後 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/net/examine-presentation/)，了解完整的報告範例與格式特定限制。

**可以在不提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。前提是簡報在加密時將 `EncryptDocumentProperties` 設為 `false`，且以 `OnlyLoadDocumentProperties` 設為 `true` 載入。

**可以在僅文件屬性模式下更新加密的 PPTX 檔案嗎？**

不能。公開與加密的屬性資料必須保持一致，因此更新加密的 PPTX 檔案必須使用正確的開啟密碼載入完整簡報。