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
description: "掌握 Aspose.Slides for Node.js via Java 的簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for Node.js via Java 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性可讀取與更新簡報的中繼資料，例如作者、標題與使用者自訂值。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) 類別操作簡報文件屬性。此類別的實例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}

Aspose.Slides 會在儲存簡報時管理應用程式與製作者的中繼資料；這些欄位用以識別產生輸出的軟體。

{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述資訊。它們分為兩類：

- **內建屬性** 包含標題、作者與文件統計等標準中繼資料。
- **自訂屬性** 儲存使用者自訂的名稱/值配對。

Aspose.Slides for Node.js via Java 同時提供對兩類屬性的存取。在 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢視文件中繼資料。此對話方塊將資訊分為 **Summary**、**Statistics**、**Contents** 與 **Custom** 等分頁。使用 **Custom** 分頁來管理使用者自訂屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。當在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 時將 `false` 作為參數，表示加密文件屬性保持公開。此時應用程式可呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 並將 `true` 傳入，於不提供開啟密碼的情況下讀取公開中繼資料。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 載入的內容；它不會執行解密。如果屬性已被加密，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，完整簡報仍會被載入。

以下範例需要一個文件屬性保持公開的加密簡報。它會透過 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) 檢查載入模式，然後使用 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 讀取內建屬性：

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

在此模式下，不會載入投影片內容。投影片、母片、版面配置、圖形、媒體與其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，務必先檢查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公開中繼資料可能會洩漏作者姓名、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一併加密。僅在索引、分類、搜尋或文件管理系統必須在未提供密碼的情況下存取時，才保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，若在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 並傳入 `true` 後載入的簡報，僅用於讀取公開中繼資料。Aspose.Slides 無法從僅含文件屬性的物件儲存變更，因為公開屬性必須與加密簡報內相應資料保持一致。因此，更新必須使用正確的開啟密碼並完整載入簡報。

以下範例需要一個文件屬性公開且已知開啟密碼的加密 PPTX 簡報。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) 完整載入簡報，更新公開的內建屬性，並儲存結果。接著使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開中繼資料以驗證新值：

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

如果應用程式不被允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) 類別透過 getter 方法公開內建中繼資料，包含 [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor)、[getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) 與 [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime)。此範例開啟現有簡報並將其儲存的中繼資料印出至主控台。值取決於輸入的簡報；某些欄位可能為空。

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

## **修改內建屬性**

若要更新內建中繼資料，請使用由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 回傳的物件上的 setter 方法。此範例開啟現有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)、[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle)、[setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject)、[setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) 與 [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager)，然後使用 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 儲存更新後的簡報。儲存的 PPTX 會包含新中繼資料。

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

## **管理超連結基底**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) 會回傳文件層級的相對超連結基底。使用 [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) 可變更或清除它。此功能在將簡報與其連結檔案搬移至其他位置時非常有用。它與個別超連結的 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) 是分開的：變更基底不會改寫已儲存的連結位址或變更絕對目的地。

以下範例需要一個同時包含相對連結（如 `target.html`）與絕對連結（如 `https://example.org/absolute.html`）的簡報。它會讀取現有基底、指派新基底位址，然後儲存並重新開啟簡報以檢查值。之後以空字串清除基底，並在另一個儲存檔案中驗證空值。請將範例基底位址取代為您連結檔案的實際位置。

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

兩個驗證訊息應印出 `true`。清除基底不會影響個別超連結位址。

相對連結 `target.pptx` 在基底指向 `old` 資料夾時會開啟 `old/target.pptx`。將基底改為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟相同檔案。請在搬移簡報或變更基底前後於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) 方法允許您以屬性名稱指派值。此範例建立一個簡報，加入兩個文字值與一個整數版本值，並使用 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 儲存簡報。對已存在的名稱指派值會取代該屬性的原有值。

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

此範例開啟包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) 迭代它們。[getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) 以零基索引取得名稱，該名稱用於 [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item)。範例會列印每個原始名稱與值，將所有值替換為編號字串（不論原始型別），最後儲存變更。若無自訂屬性，迴圈不會產生任何變更。

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

請試用線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 了解如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。但您可以變更其值，或在屬性允許的情況下將其設為空。

**如果加入已存在的自訂屬性會發生什麼？**

若加入已存在的自訂屬性，原有的值會被新值覆寫。您不需要事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**我可以在未完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) 取得資訊，然後呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) 讀取儲存的文件中繼資料，而不必建立 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 實例。請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/nodejs-java/examine-presentation/) 以取得完整報表範例與格式限制說明。

**我可以在未提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。簡報必須在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 並傳入 `false` 後才加密，且必須在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 並傳入 `true` 後載入。

**我可以在僅文件屬性模式下更新加密的 PPTX 檔案嗎？**

不能。公開屬性與加密屬性資料必須保持一致，更新加密的 PPTX 檔案必須使用正確的開啟密碼並完整載入簡報。