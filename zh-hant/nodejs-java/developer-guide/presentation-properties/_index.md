---
title: 在 JavaScript 中管理投影片屬性
linktitle: 投影片屬性
type: docs
weight: 70
url: /zh-hant/nodejs-java/presentation-properties/
keywords:
- PowerPoint 屬性
- 投影片屬性
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
- 投影片
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中掌握投影片屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **介紹**

Aspose.Slides 支援兩種文件屬性類型：**Built-in** 和 **Custom**。這兩種類型的屬性都可以輕鬆地透過 Aspose.Slides API 進行存取與管理。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/) 類別操作投影片文件屬性。此類別的實例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 方法回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意，**Application** 與 **AppVersion** 欄位無法修改。Aspose.Slides 會在每次儲存時重新寫入這些欄位，因此已儲存的投影片始終顯示「Aspose.Slides for Node.js via Java」以及產生它的函式庫版本。傳遞給 `setNameOfApplication` 的任何值在寫入投影片時都會被捨棄。
{{% /alert %}} 

## **管理投影片屬性**

Microsoft PowerPoint 提供了向投影片檔案新增屬性的功能。這些文件屬性允許在文件（投影片檔案）中儲存一些有用的資訊。文件屬性分為以下兩種：

- 系統定義（Built-in）屬性
- 使用者自訂（Custom）屬性

**Built-in** 屬性包含文件的一般資訊，如文件標題、作者名稱、文件統計資料等。**Custom** 屬性是使用者以 **Name/Value** 配對方式自行定義的屬性，名稱與值皆由使用者決定。使用 Aspose.Slides for Node.js via Java，開發人員可以存取與修改內建屬性及自訂屬性的值。

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理投影片檔案的文件屬性。只要點擊 Office 圖示，然後選取 **Prepare | Properties | Advanced Properties** 功能表項目，即可，如下圖所示：

|**選取「Advanced Properties」功能表項目**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

選取 **Advanced Properties** 功能表項目後，會出現對話方塊，允許您管理 PowerPoint 檔案的文件屬性，如下圖所示：

|**屬性對話方塊**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **Properties Dialog** 中，您可以看到有多個分頁，例如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。所有這些分頁皆可設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

使用 Aspose.Slides for Node.js via Java 處理文件屬性

如前所述，Aspose.Slides for Node.js via Java 支援兩種文件屬性：**Built-in** 與 **Custom**。因此，開發人員可透過 Aspose.Slides for Node.js via Java API 存取這兩類屬性。Aspose.Slides for Node.js via Java 提供 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties) 類別，代表與投影片檔案相關的文件屬性，可透過 **Presentation.DocumentProperties** 屬性存取。

開發人員可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 物件所公開的 **DocumentProperties** 屬性，以下說明如何存取投影片檔案的文件屬性：

## **存取內建屬性**

透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties) 物件可取得以下屬性：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 與 **Title**。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化代表投影片的 Presentation 類別
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件之參考
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

修改投影片檔案的內建屬性與存取它們同樣簡單。您只需將字串值指定給任意想要的屬性，即可修改該屬性的值。以下範例示範如何使用 Aspose.Slides for Node.js via Java 修改投影片檔案的內建文件屬性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件之參考
    var dp = pres.getDocumentProperties();
    // 設定內建屬性
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // 將投影片儲存至檔案
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此範例會修改內建屬性，結果如以下所示：

|**修改後的內建文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for Node.js via Java 也允許開發人員為投影片文件屬性加入自訂值。以下範例示範如何為投影片設定自訂屬性。

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
    // 取得特定索引處的屬性名稱
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 移除選取的屬性
    dProps.removeCustomProperty(getPropertyName);
    // 儲存投影片
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

Aspose.Slides for Node.js via Java 也允許開發人員存取自訂屬性的值。以下範例示範如何存取與修改投影片的所有自訂屬性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 DocumentProperties 物件之參考
    var dp = pres.getDocumentProperties();
    // 存取並修改自訂屬性
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 顯示自訂屬性的名稱與值
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // 修改自訂屬性的值
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // 將投影片儲存至檔案
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此範例修改 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 投影片的自訂屬性。下列圖示顯示自訂屬性在修改前後的樣子：

|**修改前的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="info" title="Note" %}}
已新增新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)、以及 [WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) 至 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo)，且 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 屬性設定器的邏輯已被更改。
{{% /alert %}} 

兩個新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) 與 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 已加入至 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo) 類別。它們提供快速存取文件屬性，且可在不載入整個投影片的情況下變更與更新屬性。

典型的情境是載入屬性、變更某些值，然後更新文件，可依以下方式實作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 讀取投影片資訊
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// 取得目前的屬性
var props = info.readDocumentProperties();
// 設定 Author 與 Title 欄位的新值
props.setAuthor("New Author");
props.setTitle("New Title");
// 使用新值更新投影片
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

另一種方式是將特定投影片的屬性作為範本，以更新其他投影片的屬性：

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

可以從頭建立新範本，然後用來更新多個投影片：

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

## **設定校對語言**

Aspose.Slides 提供 LanguageId 屬性（由 PortionFormat 類別公開），讓您可以設定 PowerPoint 文件的校對語言。校對語言即 PowerPoint 會檢查拼寫與文法的語言。以下 JavaScript 程式碼示範如何為 PowerPoint 設定校對語言：xxx 為何 JavaScript PortionFormat 類別中缺少 LanguageId？

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
    portionFormat.setLanguageId("zh-CN");// 設定校對語言的 Id
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定預設語言**

以下 JavaScript 程式碼示範如何為整個 PowerPoint 投影片設定預設語言：

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
    // 檢查第一個 Portion 的語言
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **即時範例**

請試用線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 以了解如何透過 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**我該如何從投影片中移除內建屬性？**

內建屬性是投影片的一部份，無法完全移除。然而，您可以變更其值，或在該屬性允許的情況下將其設為空值。

**如果我新增已存在的自訂屬性會發生什麼情況？**

如果您新增已存在的自訂屬性，原有的值會被新值覆寫。您無需事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性值。

**我能在不完整載入投影片的情況下存取投影片屬性嗎？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)，然後呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 即可在未建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/nodejs-java/examine-presentation/) 取得完整的報告範例與格式限制說明。