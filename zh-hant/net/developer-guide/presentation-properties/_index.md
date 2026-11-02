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
description: "在 Aspose.Slides for .NET 中掌握簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for .NET 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性來讀取和更新簡報的中繼資料，例如作者、標題和使用者自訂值。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時管理應用程式與製作者的中繼資料；這些欄位可識別建立輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述資訊。它們分為兩類：

- **內建屬性** 包含標準中繼資料，例如標題、作者和文件統計資訊。
- **自訂屬性** 儲存使用者定義的名稱/值對。

Aspose.Slides for .NET 提供對兩類屬性的存取。在 PowerPoint 中，選取 **檔案 → 資訊 → 屬性 → 進階屬性** 以檢視文件中繼資料。對話方塊將資訊分組於 **摘要**、**統計資訊**、**內容** 與 **自訂** 分頁。使用 **自訂** 分頁管理使用者定義的屬性。

## **從加密的簡報讀取公開屬性**

開啟密碼通常同時保護簡報內容與文件屬性。當簡報以 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 設為 `false` 加密時，其文件屬性仍保持公開。此時應用程式可將 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 設為 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 控制 Aspose.Slides 會載入什麼；它不會進行任何解密。如果屬性已被加密，未提供密碼載入將失敗。若簡報未加密，則會忽略此選項並完整載入簡報。

此範例需要一個文件屬性已設為公開的加密簡報。它透過 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 驗證載入模式，然後透過 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 讀取內建屬性：

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、圖形、媒體及其他簡報物件皆無法使用。應用程式應始終在執行需要完整簡報物件模型的操作前，先檢查 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="Security" %}}
公開的中繼資料可能會洩漏作者姓名、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統必須在未提供密碼的情況下存取時，才將它們保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，使用 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 載入的簡報僅供讀取公開的中繼資料。Aspose.Slides 無法從僅含中繼資料的物件儲存變更的屬性，因為公開屬性必須與加密簡報內對應的資料保持一致。因此，更新必須使用正確的開啟密碼並完整載入簡報。

此範例需要一個具有公開文件屬性的加密 PPTX 簡報，且已知開啟密碼。它使用 [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 完整開啟簡報，更新公開的內建屬性，並儲存結果。接著使用 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開中繼資料，以驗證新值：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

如果應用程式不允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 介面透過類型化屬性公開內建中繼資料，包括 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) 與 [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/)。此範例開啟既有簡報，並將其儲存的中繼資料輸出至主控台。值取決於輸入的簡報；某些欄位可能為空。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **修改內建屬性**

若要更新內建中繼資料，請對 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 所公開的可寫屬性賦值。此範例開啟現有簡報，設定 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/)、[Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) 與 [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/)，然後使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **管理超連結基礎**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) 保存文件層級的相對超連結基礎。當您將簡報及其連結檔案搬移至其他位置時，此功能非常有用。它與個別超連結的 [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) 分離：變更基礎不會重寫已儲存的連結位址，也不會改變絕對目標。

此範例需要一個同時包含相對連結（如 `target.html`）與絕對連結（如 `https://example.org/absolute.html`）的簡報。它讀取現有基礎，指定新基礎位址，然後儲存並重新開啟簡報以檢查值。接著以 `string.Empty` 清除基礎，並在另一個儲存檔案中驗證空值。請將範例基礎位址替換為您連結檔案所在的位置。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

兩個驗證訊息應印出 `True`。清除基礎不會影響個別超連結的位址。

當基礎指向 `old` 資料夾時，指向 `target.pptx` 的相對連結會開啟 `old/target.pptx`。在將基礎改為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟相同檔案。在搬移簡報或變更基礎前後，請於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[IDocumentProperties 索引子](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 允許您依屬性名稱指派值。此範例建立簡報，新增兩個文字值與一個整數版本值，並使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 儲存簡報。對已存在的名稱賦值會取代該屬性的值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **存取與修改自訂屬性**

此範例開啟含有自訂屬性的簡報，並使用 [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) 迭代它們。[GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) 接受零基索引，回傳由 [IDocumentProperties 索引子](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 使用的名稱。範例列印每個原始名稱與值，無論原始型別為何，都以編號字串取代每個值，最後儲存變更。若無自訂屬性，迴圈不會產生任何變更。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **即時範例**

嘗試使用 [**檢視與編輯 PowerPoint 中繼資料**](https://products.aspose.app/slides/metadata) 線上應用程式，了解如何使用 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。不過，您可以變更它們的值，或在該屬性允許的情況下將其設為空。

**如果我新增已存在的自訂屬性會發生什麼？**

若新增的自訂屬性已存在，其現有值會被新值覆寫。不需要事先移除或檢查屬性，Aspose.Slides 會自動更新屬性的值。

**我能在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/)，然後呼叫 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 實例的情況下讀取儲存的文件中繼資料。請參閱 [建立輕量級簡報清單](/slides/zh-hant/net/examine-presentation/) 以取得完整的報告範例與格式特定限制。

**我可以在不提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。前提是簡報在加密時將 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 設為 `false`，且載入時將 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 設為 `true`。

**我可以在僅文件屬性模式下更新加密的 PPTX 檔案嗎？**

不能。公開與加密的屬性資料必須保持一致，因此更新加密的 PPTX 檔案必須使用正確的開啟密碼載入完整簡報。