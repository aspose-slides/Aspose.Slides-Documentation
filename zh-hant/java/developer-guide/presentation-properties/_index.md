---
title: 在 Java 中管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/java/presentation-properties/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中掌握簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **介紹**

Aspose.Slides 支援兩種文件屬性類型：**Built-in** 和 **Custom**。這兩種屬性類型均可透過 Aspose.Slides API 輕鬆存取與管理。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties/) 介面來處理簡報文件屬性。此介面的實例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getDocumentProperties--) 方法回傳。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="primary" %}} 
請注意，**Application** 與 **Producer** 欄位無法修改，這兩個欄位始終會顯示 "Aspose Ltd." 與 "Aspose.Slides for Java x.x.x"。
{{% /alert %}} 

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。您只需要點選 Office 圖示，然後在 Microsoft PowerPoint 2007 中選取 **Prepare | Properties | Advanced Properties** 功能表項目，如下所示：

|**選取 Advanced Properties 功能表項目**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

選取 **Advanced Properties** 功能表項目後，會出現一個對話方塊，允許您如圖所示管理 PowerPoint 檔案的文件屬性：

|**屬性對話方塊**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **Properties Dialog** 中，您可以看到多個分頁，如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。所有這些分頁皆可設定與 PowerPoint 檔案相關的各種資訊。**Custom** 分頁則用於管理 PowerPoint 檔案的自訂屬性。

### 使用 Aspose.Slides for Java 處理文件屬性

正如前述，Aspose.Slides for Java 支援 **Built-in** 與 **Custom** 兩種文件屬性。因此開發人員可以透過 Aspose.Slides for Java API 取得兩種屬性。Aspose.Slides for Java 提供了 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties) 類別，透過 **Presentation.DocumentProperties** 屬性取得與簡報檔案關聯的文件屬性。

開發人員可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 物件所公開的 **IDocumentProperties** 屬性，依下列方式存取簡報檔案的文件屬性：

## **存取內建屬性**

這些屬性由 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties) 物件提供，包括：**Creator** (Author)、**Description**、**Keywords** **Created** (Creation Date)、**Modified** Modification Date、**Printed** Last Print Date、**LastModifiedBy**、**Keywords**、**SharedDoc** (Is shared between different producers?)、**PresentationFormat**、**Subject** 與 **Title**

```java
// 實例化代表簡報的 Presentation 類別
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件的參考
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 顯示內建屬性
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **修改內建屬性**

修改簡報檔案的內建屬性與存取它們同樣簡單。只要將字串值指派給任意想要的屬性，即可完成修改。以下範例示範如何使用 Aspose.Slides for Java 修改簡報檔案的內建文件屬性。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件的參考
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 設定內建屬性
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // 將簡報儲存為檔案
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

此範例會修改簡報的內建屬性，結果如下面所示：

|**修改後的內建文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for Java 亦允許開發人員為簡報的文件屬性新增自訂值。以下範例示範如何為簡報設定自訂屬性。

```java
Presentation pres = new Presentation();
try {
    // 取得文件屬性
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // 新增自訂屬性
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 取得特定索引處的屬性名稱
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 移除所選屬性
    dProps.removeCustomProperty(getPropertyName);
    
    // 儲存簡報
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**已新增的自訂文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **存取與修改自訂屬性**

Aspose.Slides for Java 亦允許開發人員存取自訂屬性的值。以下範例示範如何存取並修改簡報的所有自訂屬性。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 DocumentProperties 物件的參考
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 存取並修改自訂屬性
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 顯示自訂屬性的名稱與值
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // 修改自訂屬性的值
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // 將簡報儲存為檔案
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

此範例會修改 [PPTX ](https://docs.fileformat.com/presentation/pptx/)簡報的自訂屬性。下圖分別顯示修改前與修改後的簡報自訂屬性：

|**修改前的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="primary" %}} 
已在 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo) 中加入新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、以及 [WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)；[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 屬性設定器的邏輯亦已變更。
{{% /alert %}} 

兩個新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) 與 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 已加入至 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo) 介面。它們提供快速存取文件屬性的方式，且可在不載入整個簡報的情況下變更與更新屬性。

典型情境為載入屬性、變更某些值，然後更新文件，可依下列方式實作：

```java
// 讀取簡報資訊
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

另一種方式是將特定簡報的屬性作為範本，來更新其他簡報的屬性：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

也可以從頭建立新的範本，然後用來更新多個簡報：

```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **設定校對語言**

Aspose.Slides 提供由 PortionFormat 類別所公開的 LanguageId 屬性，讓您為 PowerPoint 文件設定校對語言。校對語言即是 PowerPoint 進行拼寫與文法檢查時所使用的語言。

此 Java 程式碼示範如何為 PowerPoint 設定校對語言：xxx 為什麼 Java PortionFormat 類別缺少 LanguageId？

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // 設定校對語言的 Id

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定預設語言**

此 Java 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 新增一個帶有文字的矩形形狀
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 檢查第一段文字的語言
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **即時範例**

嘗試線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 以了解如何透過 Aspose.Slides API 處理文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## ***常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報不可分割的一部份，無法完全移除。您只能變更其值，或在該屬性允許的情況下將其設為空字串。

**如果新增已存在的自訂屬性會發生什麼事？**

若新增的自訂屬性已經存在，系統會以新值覆寫原有值。您不必先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。您可以透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/) 類別的 `getPresentationInfo` 方法取得簡報資訊，然後使用 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/) 介面的 `readDocumentProperties` 方法有效地讀取屬性，從而節省記憶體並提升效能。