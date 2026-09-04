---
title: 在 Android 上管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中掌握簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種類型的文件屬性：**內建**和**自訂**。這兩種屬性類型都可以輕鬆地透過 Aspose.Slides API 存取和管理。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.ipresentation/#getDocumentProperties--) 取得。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意，**Application** 和 **AppVersion** 欄位無法修改。Aspose.Slides 會在每次儲存時重新寫入這兩個欄位，因此已儲存的簡報會始終報告 Aspose.Slides 產品名稱以及產生該簡報的函式庫版本。傳遞給 `setNameOfApplication` 的任何值在寫入簡報時都會被捨棄。
{{% /alert %}} 

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。您只需要點選 Office 圖示，然後進入 **Prepare | Properties | Advanced Properties** 功能表項目，如下圖所示：

|**選取「Advanced Properties」功能表項目**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
選取 **Advanced Properties** 功能表項目後，會顯示一個對話方塊，允許您管理 PowerPoint 檔案的文件屬性，如下圖所示：

|**屬性對話方塊**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
在上述 **屬性對話方塊** 中，您可以看到有多個分頁，例如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。所有這些分頁皆允許設定與 PowerPoint 檔案相關的各種資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

## 使用 Aspose.Slides for Android via Java 處理文件屬性

正如前面所述，Aspose.Slides for Android via Java 支援兩種類型的文件屬性，即 **Built-in** 與 **Custom** 屬性。因此，開發人員可透過 Aspose.Slides for Android via Java API 存取這兩種屬性。Aspose.Slides for Android via Java 提供了 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.idocumentproperties) 類別，代表與簡報檔案相關的文件屬性，透過 **Presentation.DocumentProperties** 屬性取得。

開發人員可使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 物件所公開的 **IDocumentProperties** 屬性，存取簡報檔案的文件屬性，如下所示：

## **從加密簡報讀取公開屬性**

開啟密碼通常同時保護簡報內容與文件屬性。若在呼叫 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.iprotectionmanager/#setEncryptDocumentProperties-boolean-) 時傳入 `false`，則簡報的文件屬性仍保持公開。此時應用程式可傳入 `true` 給 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.loadoptions/#setOnlyLoadDocumentProperties-boolean-)，在未提供開啟密碼的情況下讀取公開的中繼資料。

document-properties-only 選項僅控制 Aspose.Slides 載入的內容；它不會解密任何資料。若屬性已被包含在加密之中，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，完整的簡報將被載入。

以下範例透過 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) 驗證載入模式，然後使用 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.ipresentation/#getDocumentProperties--) 讀取內建屬性：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、圖形、媒體及其他簡報物件皆無法使用。應用程式在執行需要完整簡報物件模型的操作前，請務必先檢查 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)。

{{% alert color="warning" title="Warning" %}}
公開的中繼資料可能會洩露作者姓名、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在未提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，以 document-properties-only 模式載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法從此僅含中繼資料的物件儲存變更的屬性，因為公開屬性必須與加密簡報內相對應的資料保持一致。因此，更新這些屬性必須提供正確的開啟密碼並完整載入簡報。

以下範例使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.loadoptions/#setPassword-java.lang.String-) 開啟簡報，更新公開的內建屬性，並儲存結果。接著利用 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.ipresentationinfo/#isEncrypted--) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開的中繼資料，以驗證新值：

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

如果應用程式無法解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

這些由 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.idocumentproperties) 物件公開的屬性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同製作者間共享？）、**PresentationFormat**、**Subject** 與 **Title**

```java
import com.aspose.slides.*;

// 實例化代表簡報的 Presentation 類別
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件參考
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

修改簡報檔案的內建屬性和存取它們一樣簡單。您只需將字串值指派給任意想要的屬性，即可完成屬性值的修改。以下範例示範了如何使用 Aspose.Slides for Android via Java 變更簡報檔案的內建文件屬性。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 IDocumentProperties 物件參考
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 設定內建屬性
    dp.setAuthor("Aspose.Slides for Android via Java");
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
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for Android via Java 亦允許開發人員為簡報的文件屬性新增自訂值。以下範例新增三個自訂屬性，然後查找索引 2 處儲存的名稱並將其移除，因而儲存的簡報僅保留其中兩個。自訂屬性會依字母順序索引，而非依新增順序。

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
    
    // 取得特定索引的屬性名稱
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
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **存取與修改自訂屬性**

Aspose.Slides for Android via Java 也允許開發人員存取自訂屬性的值。以下範例示範如何存取並修改簡報的所有自訂屬性。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // 建立與 Presentation 相關聯的 DocumentProperties 物件參考
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

此範例會修改 [PPTX](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。下列圖示分別顯示修改前後的簡報自訂屬性：

|**修改前的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="info" title="Note" %}}
已在 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.IPresentationInfo) 中加入新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 以及 [WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.IPresentationInfo#writeBindedPresentation-java.lang.String-)。另外，已變更 [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.idocumentproperties#setLastSavedTime-java.util.Date-) 屬性設定子的邏輯。
{{% /alert %}} 

這兩個新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.IPresentationInfo#readDocumentProperties--) 與 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 已加入至 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.IPresentationInfo) 介面。它們提供快速存取文件屬性的方式，且可在不載入完整簡報的情況下變更與更新屬性。

一般情境是載入屬性、變更某些值，然後更新文件，可依下列方式實作：

```java
import com.aspose.slides.*;

// 讀取簡報資訊
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// 取得目前的屬性
IDocumentProperties props = info.readDocumentProperties();

// 設定 Author 與 Title 欄位的新值
props.setAuthor("New Author");
props.setTitle("New Title");

// 使用新值更新簡報
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

另一種方式是將特定簡報的屬性作為範本，以更新其他簡報的屬性：

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

可以從頭建立新範本，然後用來更新多個簡報：

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **設定校對語言**

Aspose.Slides 提供 LanguageId 屬性（由 PortionFormat 類別公開），讓您為 PowerPoint 文件設定校對語言。校對語言即 PowerPoint 會檢查拼寫與文法的語言。

以下 Java 程式碼示範如何為 PowerPoint 設定校對語言：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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
    // 新增一個包含文字的矩形形狀
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 檢查第一個 Portion 的語言
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **即時範例**

嘗試線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 以了解如何透過 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。但您可以變更其值，或在該屬性允許的情況下將其設為空值。

**如果新增已存在的自訂屬性會發生什麼情況？**

若新增的自訂屬性已存在，原有的值會被新值覆蓋。您無需事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**是否能在未完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.presentationfactory/#getPresentationInfo-java.lang.String-)，再呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.ipresentationinfo/#readDocumentProperties--)，即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides.presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/androidjava/examine-presentation/) 取得完整的報告範例及格式特定的限制。

**是否能在沒有開啟密碼的情況下讀取加密簡報的公開屬性？**

可以。必須在簡報加密之前停用文件屬性加密，且簡報必須以 document-properties-only 模式載入。

**是否能在 document-properties-only 模式下更新加密的 PPTX 檔案？**

不能。公開屬性與加密屬性資料必須保持一致，因此要更新加密的 PPTX 檔案，必須使用正確的開啟密碼完整載入簡報。