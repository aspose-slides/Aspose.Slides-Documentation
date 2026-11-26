---
title: 在 JavaScript 中管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中精通簡報屬性，並簡化 PowerPoint 與 OpenDocument 檔案的搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for Node.js via Java 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性來讀取和更新簡報的中繼資料，例如作者、標題，以及使用者定義的值。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) 類別處理簡報文件屬性。此類別的實例可由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 取得。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用於辨識產生輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性會在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標準中繼資料，例如標題、作者與文件統計資訊。
- **自訂屬性** 儲存使用者定義的名稱/值配對。

Aspose.Slides for Node.js via Java 提供對兩種屬性的存取。在 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢視文件的中繼資料。對話方塊將資訊分組為 **Summary**、**Statistics**、**Contents** 和 **Custom** 等標籤。使用 **Custom** 標籤來管理使用者定義的屬性。

## **從已加密的簡報讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。若在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 並傳入 `false` 後對簡報進行加密，其文件屬性將保持公開。此時應用程式可以呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 並傳入 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 載入的內容；它不會執行任何解密。如果屬性已被加密，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，並載入完整簡報。

此範例需要一個已加密且文件屬性保持公開的簡報。它透過 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) 檢查載入模式，然後透過 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 讀取內建屬性：

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、圖形、媒體以及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應始終檢查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) 。

{{% alert color="warning" title="Warning" %}}
公開的中繼資料可能會洩露作者姓名、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一併加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在未提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新已加密簡報的屬性**

對於已加密的 PPTX 檔案，於呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 並傳入 `true` 後載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法將該僅含中繼資料的物件的變更屬性儲存，因為公開的屬性必須與加密簡報內對應的資料保持一致。因此，更新這些屬性需要正確的開啟密碼與完整載入。

此範例需要一個具公開文件屬性且已知開啟密碼的已加密 PPTX 簡報。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) 開啟完整簡報，更新公開的內建屬性，並儲存結果。接著使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) 以驗證加密仍被保留，並在未提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

如果應用程式未被允許解密或載入簡報內容，則必須將已加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) 類別透過取得方法公開內建中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor)、[getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) 以及 [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime)。此範例開啟現有簡報，並將其儲存的中繼資料列印到主控台。值取決於輸入的簡報；某些欄位可能為空。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **報告修訂號碼與編輯時間**

若要報告 `presentations` 資料夾中每個 PPTX 檔案的修訂號碼與總編輯時間，請使用 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties)。它會回傳檔案的 [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties)，且不會載入投影片以供編輯。範例將記錄的毫秒時長轉換為時、分、秒。對於 24 小時或更長的時長，會在時間前加上完整天數。

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

對於一個記錄編輯時間為 1 天 2 小時 5 分鐘的簡報，報告將顯示如下輸出。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) 讀取一個值，應用程式可使用 [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber) 變更。僅靠修訂號碼無法判斷簡報儲存了多少次，也無法重建其版本歷史。

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) 讀取檔案中記錄的編輯時長。值為 `00:00:00` 表示儲存的時長為零，即使有人編輯過簡報。

## **修改內建屬性**

若要更新內建中繼資料，請對由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 回傳的物件使用設定方法。此範例開啟現有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)、[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle)、[setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject)、[setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) 與 [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager)，然後使用 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理超連結基礎**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) 會回傳相對超連結的文件層級基礎。使用 [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) 可以變更或清除它。當移動簡報及其相關檔案至其他位置時，此功能相當有用。它獨立於單一超連結的 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl)：變更基礎不會重新寫入已儲存的連結位址，也不會改變絕對目的地。

此範例需要一個同時包含相對連結（如 `target.html`）與絕對連結（如 `https://example.org/absolute.html`）的簡報。它讀取現有的基礎，指派新的基礎位址，並儲存與重新開啟簡報以檢查該值。接著以空字串清除基礎，並在另一個儲存的檔案中驗證其為空。請將範例基礎位址替換為您連結檔案的實際位置。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

兩個驗證訊息應該會印出 `true`。清除基礎不會影響個別超連結的位址。

當基礎指向 `old` 資料夾時，指向 `target.pptx` 的相對連結會開啟 `old/target.pptx`。將基礎更改為 `new` 資料夾，儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結仍會開啟相同的檔案。請在 PowerPoint 中於移動簡報或變更基礎前後測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) 方法允許您依屬性名稱指派值。此範例建立簡報，加入兩個文字值與一個整數版本值，並使用 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 儲存簡報。對已存在的名稱指派值會取代該屬性的值。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取與修改自訂屬性**

此範例開啟包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) 來遍歷它們。[getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) 接受從零開始的索引，並回傳 [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) 使用的名稱。範例列印每個原始名稱與值，將所有值以編號字串取代（不論原始類型），並儲存變更。若無自訂屬性，迴圈不會進行任何變更。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **即時範例**

嘗試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 處理文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的整體部分，無法完全移除。然而，您可以更改其值，或在該屬性允許的情況下將其設為空。

**如果我新增已存在的自訂屬性會發生什麼情況？**

如果您新增已存在的自訂屬性，其原有值會被新值覆寫。您不需要事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) 然後 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) 即可在不建立 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 實例的情況下讀取已儲存的文件中繼資料。請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/nodejs-java/examine-presentation/) 以取得完整的報告範例及格式特定的限制。

**可以在未提供開啟密碼的情況下讀取已加密簡報的公開屬性嗎？**

可以。簡報必須在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 並傳入 `false` 後才進行加密，且必須在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 並傳入 `true` 後載入。

**可以在僅載入文件屬性的模式下更新已加密的 PPTX 檔案嗎？**

不能。公開與加密的屬性資料必須保持一致，因此在僅載入文件屬性的模式下無法更新已加密的 PPTX 檔案，必須使用正確的開啟密碼載入完整簡報。