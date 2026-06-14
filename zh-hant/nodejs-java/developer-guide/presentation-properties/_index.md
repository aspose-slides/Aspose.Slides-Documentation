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
description: "在 Aspose.Slides for Node.js via Java 中精通簡報屬性，並在 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種類型的文件屬性：**Built-in** 和 **Custom**。這兩種屬性類型都可以透過 Aspose.Slides API 輕鬆存取與管理。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的執行個體由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 方法回傳。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="primary" %}} 
請注意，您無法為 **Application** 與 **Producer** 欄位設定值，因為會顯示 Aspose Ltd. 與 Aspose.Slides for Node.js via Java x.x.x 的資訊於這些欄位。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔案中加入屬性的功能。這些文件屬性允許將有用的資訊與文件（簡報檔案）一起儲存。文件屬性分為以下兩種：

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** 屬性包含文件的一般資訊，例如文件標題、作者名稱、文件統計資料等。**Custom** 屬性則由使用者以 **Name/Value** 配對自行定義。使用 Aspose.Slides for Node.js via Java，開發人員可以存取與修改內建屬性以及自訂屬性的值。

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 可管理簡報檔案的文件屬性。只需點選 Office 圖示，然後選取 **Prepare | Properties | Advanced Properties** 功能表項目，如下所示：

|**選取「進階屬性」功能表項目**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

選取 **Advanced Properties** 功能表項目後，會顯示對話方塊，允許您管理 PowerPoint 檔案的文件屬性，如下圖所示：

|**屬性對話方塊**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **Properties Dialog** 中，您可以看到多個分頁，如 **General**、**Summary**、**Statistics**、**Contents** 和 **Custom**。所有這些分頁均允許設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

## **使用 Aspose.Slides for Node.js via Java 處理文件屬性**

如前所述，Aspose.Slides for Node.js via Java 支援 **Built-in** 與 **Custom** 兩種文件屬性。開發人員可透過 Aspose.Slides for Node.js via Java API 同時存取這兩種屬性。Aspose.Slides for Node.js via Java 提供 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties) 類別，以 **Presentation.DocumentProperties** 屬性代表與簡報檔案相關的文件屬性。

開發人員可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 物件公開的 **DocumentProperties** 屬性，存取簡報檔案的文件屬性，如下所示：

## **存取內建屬性**

透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties) 物件可取得以下屬性：**Creator**（Author）、**Description**、**Keywords**、**Created**（Creation Date）、**Modified**（Modification Date）、**Printed**（Last Print Date）、**LastModifiedBy**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 與 **Title**。

```javascript
// 實例化代表簡報的 Presentation 類別
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件的參考
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

修改簡報檔案的內建屬性與存取它們一樣簡單。只需將字串值指派給任意欲修改的屬性，即可完成變更。以下範例示範如何使用 Aspose.Slides for Node.js via Java 修改簡報的內建文件屬性。

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件的參考
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

此範例修改了簡報的內建屬性，結果如圖所示：

|**修改後的內建文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for Node.js via Java 也允許開發人員為簡報文件屬性新增自訂值。以下範例說明如何為簡報設定自訂屬性。

```javascript
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

Aspose.Slides for Node.js via Java 同時允許開發人員存取自訂屬性的值。以下範例展示如何存取與修改簡報的所有自訂屬性。

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 DocumentProperties 物件的參考
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

此範例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。下圖分別顯示了修改前後的自訂屬性：

|**修改前的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="primary" %}} 
已在 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo) 中加入新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)、以及 [WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-)，且 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 屬性的設定子程式已修改。
{{% /alert %}} 

兩個新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) 與 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 已加入至 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PresentationInfo) 類別。它們提供快速存取文件屬性的能力，且無需載入整個簡報即可變更與更新屬性。

典型情境是載入屬性、變更某些值，然後更新文件，可依以下方式實作：

```javascript
// 讀取簡報資訊
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

另一種方式是將特定簡報的屬性作為範本，以更新其他簡報的屬性：

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

也可以從頭建立新範本，然後用來更新多個簡報：

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **設定校對語言**

Aspose.Slides 提供 PortionFormat 類別所公開的 LanguageId 屬性，讓您為 PowerPoint 文件設定校對語言。校對語言是 PowerPoint 進行拼寫與文法檢查時所使用的語言。

以下 JavaScript 程式碼示範如何為 PowerPoint 設定校對語言：xxx 為何 JavaScript PortionFormat 類別缺少 LanguageId？

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN");// 設定校對語言的 ID
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
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // 新增一個帶有文字的矩形形狀
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 檢查第一個部分的語言
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **線上示例**

試用[**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 線上應用程式，了解如何透過 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## ***FAQ**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。但是，您可以更改其值或在允許的情況下將其設為空白。

**如果新增已存在的自訂屬性會發生什麼？**

若新增的自訂屬性已存在，系統會以新值覆寫既有值。您無需先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**是否可以在不完整載入簡報的情況下存取簡報屬性？**

可以，您可以透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationfactory/) 類別的 `getPresentationInfo` 方法取得簡報資訊，然後使用 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentationinfo/) 類別的 `readDocumentProperties` 方法有效讀取屬性，從而節省記憶體並提升效能。