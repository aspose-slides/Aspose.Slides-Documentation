---
title: 管理 .NET 中的簡報屬性
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

Aspose.Slides for .NET 支援 **內建** 與 **自訂** 文件屬性。透過這些屬性可以讀取與更新簡報的中繼資料，例如作者、標題與使用者自行定義的值。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 介面來操作簡報文件屬性。此介面的實例可由 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 取得。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="注意" %}}

Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用來識別產生輸出的軟體。

{{% /alert %}}

## **管理簡報屬性**

文件屬性會將描述性資訊與簡報內容一起儲存。它們分為兩大類：

- **內建屬性** 含有標題、作者與文件統計等標準中繼資料。
- **自訂屬性** 用於儲存使用者自行定義的名稱/值組合。

Aspose.Slides for .NET 同時提供存取這兩類屬性。在 PowerPoint 中，選取 **檔案 → 資訊 → 屬性 → 進階屬性** 以檢視文件中繼資料。對話方塊會將資訊分到 **摘要**、**統計資料**、**內容** 與 **自訂** 等分頁。使用 **自訂** 分頁即可管理使用者定義的屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。當簡報使用 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 並將其設定為 `false` 時，文件屬性會保持公開。此時應用程式可將 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 設為 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 控制 Aspose.Slides 所載入的內容；它不會解密任何資料。如果屬性已被加密，未提供密碼就載入會失敗。若簡報未加密，則會忽略此選項並完整載入簡報。

此範例需要一個文件屬性保持公開的加密簡報。它會透過 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 來驗證載入模式，然後透過 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 讀取內建屬性：

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

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、圖形、媒體與其他簡報物件皆不可用。應用程式在執行需完整簡報物件模型的操作前，應先檢查 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="安全性" %}}
公開的中繼資料可能會洩漏作者姓名、標題、主旨、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統必須在不提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，使用 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 載入的簡報僅供讀取公開的中繼資料。Aspose.Slides 無法從僅包含文件屬性的物件儲存變更，因為公開屬性必須與加密簡報內的相應資料保持一致。因此，更新必須在提供正確開啟密碼且完整載入簡報的情況下進行。

此範例需要一個文件屬性為公開且已知開啟密碼的加密 PPTX 簡報。它會使用 [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 完整載入簡報，更新公開的內建屬性，然後儲存結果。接著使用 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) 來驗證加密仍然存在，並在不提供密碼的情況下重新開啟公開中繼資料以驗證新值：

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

如果應用程式未獲授權解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 介面透過型別化屬性公開內建中繼資料，包括 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) 與 [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/)。此範例會開啟現有簡報並將其儲存的中繼資料印出至主控台。值取決於輸入的簡報；某些欄位可能為空。

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

### **報告修訂編號與編輯時間**

若要為 `presentations` 資料夾中的每個 PPTX 檔案產生一列報告，請呼叫 [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 以在不載入投影片的情況下取得其 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)。`TimeSpan` 的標準 `c` 格式在持續時間達到 24 小時時會包含天數。

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

範例輸出（編輯時間為 1 天 2 小時 5 分鐘）：

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) 為可寫入的中繼資料。僅憑其值無法判斷簡報被儲存了多少次，也無法重建其版本歷史。

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) 為檔案中記錄的編輯持續時間。`00:00:00` 表示已儲存的持續時間為零，並不代表沒有人編輯過該簡報。

## **修改內建屬性**

若要更新內建中繼資料，請對由 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 所曝露的可寫屬性賦值。此範例會開啟現有簡報，設定 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/)、[Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) 與 [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/)，然後使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

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

## **管理超連結基礎 URL**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) 儲存文件層級的相對超連結基礎 URL。當移動簡報及其相關檔案至其他位置時，此設定非常有用。它與個別超連結的 [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) 分離：變更基礎 URL 不會重新寫入已儲存的連結位址或改變絕對目的地。

此範例需要一個同時包含相對連結（例如 `target.html`）與絕對連結（例如 `https://example.org/absolute.html`）的簡報。它會讀取現有基礎、指派新基礎位址，儲存並重新開啟簡報以檢查值。接著使用 `string.Empty` 清除基礎，並在另一個儲存的檔案中驗證空值。請將範例基礎位址替換為您連結檔案的實際位置。

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

兩個驗證訊息皆應輸出 `True`。清除基礎不會影響個別超連結的位址。

相對連結 `target.pptx` 在基礎指向 `old` 資料夾時會開啟 `old/target.pptx`。將基礎改為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟相同檔案。請在 PowerPoint 中測試相對連結於移動簡報或變更基礎前後的行為。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。透過 [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 可依屬性名稱指派值。此範例建立一個簡報，新增兩個文字值與一個整數版號，然後使用 [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 儲存簡報。對已存在的名稱賦值會覆寫該屬性的值。

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

此範例開啟包含自訂屬性的簡報，並使用 [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) 迭代它們。 [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) 接受零基索引並回傳由 [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 使用的名稱。範例會列印每個原始名稱與值，將所有值以編號字串（不論原始型別）取代，最後儲存變更。如果沒有自訂屬性，迴圈不會執行任何變更。

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

試試線上應用程式 **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/metadata)**，看看如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。不過，您可以變更它們的值，或在該屬性允許的情況下將其設為空值。

**如果加入已存在的自訂屬性會怎樣？**

若加入已存在的自訂屬性，其現有值會被新值覆寫。您不必事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**能否在未完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) 後，再呼叫 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 實例的情況下讀取儲存的文件中繼資料。請參考 **[Build a Lightweight Presentation Inventory](/slides/zh-hant/net/examine-presentation/)** 取得完整的報告範例與格式特定限制說明。

**能否在不提供開啟密碼的情況下讀取加密簡報的公開屬性？**

可以。前提是簡報必須以 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 設為 `false` 進行加密，且載入時將 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 設為 `true`。

**能否在僅載入文件屬性模式下更新加密的 PPTX 檔案？**

不能。公開與加密的屬性資料必須保持一致，因此更新加密的 PPTX 檔案必須使用正確的開啟密碼完整載入簡報。