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
- 校訂語言
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中精通簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種文件屬性類型：**內建**和**自訂**。這兩種屬性類型皆可透過 Aspose.Slides API 輕鬆存取和管理。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/) 類別來處理簡報文件屬性。此類別的實例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 方法回傳。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意，**Application** 和 **AppVersion** 欄位無法修改。Aspose.Slides 會在每次儲存時重新寫入這兩個欄位，因此已儲存的簡報總是顯示 “Aspose.Slides for Node.js via Java” 以及產生該簡報的函式庫版本。傳遞給 `setNameOfApplication` 的任何值在寫入簡報時都會被捨棄。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔案中加入一些屬性的功能。這些文件屬性可將有用的資訊與文件（簡報檔案）一起儲存。文件屬性可分為以下兩種：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建**屬性包含有關文件的一般資訊，例如文件標題、作者名稱、文件統計資訊等。**自訂**屬性則是使用者以 **名稱/值** 配對的方式自行定義，名稱與值皆由使用者決定。使用 Aspose.Slides for Node.js via Java，開發人員可以存取並修改內建屬性與自訂屬性的值。

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。您只需點選 Office 圖示，然後選取 **Prepare | Properties | Advanced Properties** 功能，如下圖所示：

|**選取 Advanced Properties 功能表項目**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

選取 **Advanced Properties** 功能表項目後，會出現對話方塊，讓您管理 PowerPoint 檔案的文件屬性，如下圖所示：

|**屬性對話方塊**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **Properties Dialog** 中，您可以看到多個分頁，例如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。所有這些分頁均允許設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

使用 Aspose.Slides for Node.js via Java 處理文件屬性

正如前面所述，Aspose.Slides for Node.js via Java 支援兩種文件屬性，即 **Built-in** 和 **Custom** 屬性。因此，開發人員可透過 Aspose.Slides for Node.js via Java API 存取這兩類屬性。Aspose.Slides for Node.js via Java 提供 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties) 類別，用以表示與簡報檔案相關的文件屬性，可透過 **Presentation.DocumentProperties** 屬性存取。

開發人員可使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 物件所提供的 **DocumentProperties** 屬性，依如下說明存取簡報檔案的文件屬性：

## **從加密簡報讀取公開屬性**

開啟密碼通常會同時保護簡報內容與文件屬性。若在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 時傳入 `false`，則該簡報的文件屬性仍保持公開。此時應用程式可傳入 `true` 給 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties)，在未提供開啟密碼的情況下讀取公開的中繼資料。

document-properties-only 選項僅控制 Aspose.Slides 載入的內容；它不會執行解密。如果屬性已被加密，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，完整簡報將被載入。

以下範例透過 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 驗證載入模式，然後使用 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 讀取內建屬性：

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，投影片內容不會被載入。投影片、母片、布局、圖形、媒體以及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應先檢查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公開的中繼資料可能會洩漏作者姓名、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感屬性與簡報一併加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在未提供密碼的情況下存取時，才可保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，以 document-properties-only 模式載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法從僅含中繼資料的物件儲存變更的屬性，因為公開屬性必須與加密簡報內對應的資料保持一致。因此，要更新這些屬性必須提供正確的開啟密碼並完整載入簡報。

以下範例使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/loadoptions/#setPassword) 開啟簡報，更新公開的內建屬性，並儲存結果。接著使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開的中繼資料，以驗證新值：

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

如果應用程式未被允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties) 物件公開的屬性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 以及 **Title**。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化代表簡報的 Presentation 類別
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立指向與 Presentation 相關聯的 IDocumentProperties 物件的參考
    var dp = pres.getDocumentProperties();
    // 顯示內建屬性
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **修改內建屬性**

修改簡報檔案的內建屬性同存取它們一樣簡單。只需為任何想要的屬性指派字串值，即可修改屬性值。以下範例示範如何使用 Aspose.Slides for Node.js via Java 修改簡報檔案的內建文件屬性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立指向與 Presentation 相關聯的 IDocumentProperties 物件的參考
    var dp = pres.getDocumentProperties();
    // 設定內建屬性
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // 將簡報儲存為檔案
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此範例會修改簡報的內建屬性，結果如下圖所示：

|**修改後的內建文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for Node.js via Java 也允許開發人員為簡報的文件屬性新增自訂值。以下範例示範如何為簡報設定自訂屬性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // 取得文件屬性
    var dProps = pres.getDocumentProperties();
    // 新增自訂屬性
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 取得特定索引的屬性名稱
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 移除已選取的屬性
    dProps.removeCustomProperty(getPropertyName);
    // 儲存簡報
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**已新增的自訂文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **存取與修改自訂屬性**

Aspose.Slides for Node.js via Java 也允許開發人員存取自訂屬性的值。以下範例示範如何存取與修改簡報的所有自訂屬性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立指向與 Presentation 相關聯的 DocumentProperties 物件的參考
    var dp = pres.getDocumentProperties();
    // 存取並修改自訂屬性
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 顯示自訂屬性的名稱與值
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // 修改自訂屬性的值
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // 將簡報儲存為檔案
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此範例會修改 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。以下圖示分別顯示修改前後的簡報自訂屬性：

|**修改前的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="info" title="Note" %}}
已在 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo) 中新增了方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 與 [WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-)，以及更改了 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 屬性設定子的邏輯。
{{% /alert %}} 

這兩個新方法已加入至 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo) 類別。它們提供快速存取文件屬性，且允許在不載入整個簡報的情況下變更與更新屬性。

典型的情境是載入屬性、變更某些值，然後更新文件，可依以下方式實作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 讀取簡報資訊
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// 取得目前的屬性
var props = info.readDocumentProperties();
// 設定 Author 與 Title 欄位的新值
props.setAuthor("New Author");
props.setTitle("New Title");
// 以新值更新簡報
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

另一種方法是將特定簡報的屬性用作範本，以更新其他簡報的屬性：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

可以從頭建立新範本，然後用來更新多個簡報：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **設定校訂語言**

Aspose.Slides 提供 LanguageId 屬性（由 PortionFormat 類別公開），讓您為 PowerPoint 文件設定校訂語言。校訂語言是 PowerPoint 進行拼寫與文法檢查時所使用的語言。

以下 JavaScript 程式碼示範如何為 PowerPoint 設定校訂語言： xxx 為何 JavaScript PortionFormat 類別中缺少 LanguageId？

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定預設語言**

以下 JavaScript 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // 新增一個帶文字的矩形形狀
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 檢查第一個段落的語言
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **即時範例**

請嘗試線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata)，了解如何透過 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以變更其值，或在該屬性允許的情況下將其設為空白。

**如果我新增的自訂屬性已存在會發生什麼？**

若您新增的自訂屬性已存在，則其原有值會被新值覆寫。您無需事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**我能在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)，再呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 便可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 例項的情況下讀取已儲存的文件中繼資料。詳情請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/nodejs-java/examine-presentation/)，了解完整的報告範例與格式限制。

**我能在不提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。必須在簡報加密之前停用文件屬性的加密，且簡報需以 document-properties-only 模式載入。

**我能在 document-properties-only 模式下更新加密的 PPTX 檔案嗎？**

不能。公開屬性與加密屬性資料必須保持一致，因此更新加密的 PPTX 檔案必須載入完整簡報並提供正確的開啟密碼。