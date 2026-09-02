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
## **簡介**

Aspose.Slides 支援兩種文件屬性類型：**內建**和**自訂**。這兩種屬性類型都可以透過 Aspose.Slides API 輕鬆存取和管理。

Aspose.Slides 讓您可以透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties/) 介面處理簡報文件屬性。此介面的實例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getDocumentProperties--) 方法傳回。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意 **Application** 與 **AppVersion** 欄位無法修改。Aspose.Slides 會在每次儲存時重新寫入它們，因此已儲存的簡報總是顯示「Aspose.Slides for Java」以及產生該檔案的程式庫版本。任何傳遞給 `setNameOfApplication` 的值都會在寫入簡報時被捨棄。
{{% /alert %}}

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。您只需要點擊 Office 圖示，然後選取 **Prepare | Properties | Advanced Properties** 功能表項目，如下所示：

|**選取「進階屬性」功能表項目**|** |
| :- | :- |
|![待辦: 圖像說明文字](https://i.imgur.com/ZrmuCD6.jpg)| |

選取 **Advanced Properties** 功能表項目後，會出現以下對話方塊，讓您管理 PowerPoint 檔案的文件屬性：

|**屬性對話框**|** |
| :- | :- |
|![待辦: 圖像說明文字](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **屬性對話框** 中，您可以看到許多分頁，例如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。所有這些分頁都允許配置與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

### 使用 Aspose.Slides for Java 處理文件屬性

如前所述，Aspose.Slides for Java 支援兩種文件屬性：**內建**與**自訂**屬性。因此，開發人員可以使用 Aspose.Slides for Java API 存取這兩種屬性。Aspose.Slides for Java 提供了 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties) 類別，透過 **Presentation.DocumentProperties** 屬性代表與簡報檔案相關的文件屬性。

開發人員可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 物件公開的 **IDocumentProperties** 屬性來存取簡報檔案的文件屬性，如下所示：

## **存取內建屬性**

由 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties) 物件公開的這些屬性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最近列印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 與 **Title**。

```java
import com.aspose.slides.*;

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

修改簡報檔案的內建屬性和存取它們一樣簡單。您只需將字串值指派給任何想要的屬性，即可修改該屬性值。以下範例示範如何使用 Aspose.Slides for Java 修改簡報的內建文件屬性。

```java
import com.aspose.slides.*;

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

此範例會修改簡報的內建屬性，修改後的結果如下所示：

|**修改後的內建文件屬性**|** |
| :- | :- |
|![待辦: 圖像說明文字](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for Java 也允許開發人員為簡報文件屬性新增自訂值。以下範例會新增三個自訂屬性，然後查詢索引 2 處的名稱並移除該屬性，最終儲存的簡報會保留兩個自訂屬性。自訂屬性會依字母順序排列，而非加入的順序。

```java
import com.aspose.slides.*;

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
    
    // 移除選取的屬性
    dProps.removeCustomProperty(getPropertyName);
    
    // 儲存簡報
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**已新增的自訂文件屬性**|** |
| :- | :- |
|![待辦: 圖像說明文字](https://i.imgur.com/HdKcxI9.png)| |

## **存取與修改自訂屬性**

Aspose.Slides for Java 也允許開發人員存取自訂屬性的值。以下範例示範如何存取與修改簡報的所有自訂屬性。

```java
import com.aspose.slides.*;

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

此範例會修改 [PPTX](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。以下圖示分別顯示修改前與修改後的自訂屬性：

|**修改前的自訂屬性**|** |
| :- | :- |
|![待辦: 圖像說明文字](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![待辦: 圖像說明文字](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="info" title="Note" %}}
已在 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo) 中加入新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、[WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)，且 [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 屬性設定器的邏輯已變更。
{{% /alert %}}

兩個新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) 與 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 已加入 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentationInfo) 介面。它們提供快速存取文件屬性的功能，且可在不載入完整簡報的情況下變更與更新屬性。

典型情境是載入屬性、變更某些值，然後更新文件，可依下列方式實作：

```java
import com.aspose.slides.*;

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

另一種方式是將特定簡報的屬性作為範本，套用到其他簡報：

```java
import com.aspose.slides.*;

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

也可從頭建立新範本，然後用於更新多個簡報：

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **設定校對語言**

Aspose.Slides 提供 LanguageId 屬性（由 PortionFormat 類別公開），可讓您為 PowerPoint 文件設定校對語言。校對語言是 PowerPoint 會檢查拼寫與文法的語言。

以下 Java 程式碼示範如何為 PowerPoint 設定校對語言：

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

    portionFormat.setLanguageId("zh-CN"); // 設定校對語言的 ID

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定預設語言**

以下 Java 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 新增一個帶文字的矩形形狀
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 檢查第一個段落的語言
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **即時範例**

嘗試線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 來瞭解如何透過 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以更改其值，或在該屬性允許的情況下將其設為空白。

**如果新增的自訂屬性已經存在會發生什麼事？**

如果新增的自訂屬性已存在，其原有的值會被新值覆寫。您不需要事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)，然後呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例的情況下讀取已存儲的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/java/examine-presentation/) 以取得完整的報告範例與格式特定限制。