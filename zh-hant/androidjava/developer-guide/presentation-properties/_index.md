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
description: "在 Aspose.Slides for Android via Java 中精通簡報屬性，並簡化 PowerPoint 與 OpenDocument 檔案的搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for Android via Java 支援 **內建** 和 **自訂** 文件屬性。使用這些屬性來讀取與更新簡報的中繼資料，例如作者、標題以及使用者自訂的值。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例是由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 取得。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用於識別產生輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標準的中繼資料，例如標題、作者與文件統計資訊。
- **自訂屬性** 儲存使用者自訂的名稱/值配對。

Aspose.Slides for Android via Java 提供對這兩類屬性的存取。在 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢視文件中繼資料。對話方塊會將資訊分為 **Summary**、**Statistics**、**Contents** 與 **Custom** 等分頁。使用 **Custom** 分頁來管理使用者自訂屬性。

## **讀取已加密簡報的公開屬性**

開啟密碼通常同時保護簡報內容與文件屬性。當簡報在呼叫 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 並傳入 `false` 後進行加密時，其文件屬性會保持公開。此時應用程式可呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並傳入 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 控制 Aspose.Slides 會載入哪些內容；它不會進行解密。如果屬性已被加密，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，完整簡報會被載入。

此範例需要一個已加密且文件屬性保持公開的簡報。它透過 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) 驗證載入模式，並使用 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 讀取內建屬性：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、圖形、媒體以及其他簡報物件均不可使用。應用程式在執行需要完整簡報物件模型的操作前，應先檢查 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)。

{{% alert color="warning" title="Warning" %}}
公開的中繼資料可能會洩露作者名稱、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在未提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新已加密簡報的屬性**

對於已加密的 PPTX 檔案，在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並傳入 `true` 後載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法將此僅含中繼資料的物件中變更的屬性儲存，因為公開屬性必須與加密簡報內的對應資料保持一致。因此，更新這些屬性需要正確的開啟密碼並完整載入簡報。

此範例需要一個具公開文件屬性且已知開啟密碼的已加密 PPTX 簡報。它先使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 開啟完整簡報，更新公開的內建屬性，並儲存結果。然後利用 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) 確認加密仍然保持，並在不提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

```java
import com.aspose.slides.IDocumentProperties;
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
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

如果應用程式不被允許解密或載入簡報內容，則必須將已加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 介面透過 getter 方法公開內建的中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--)、[getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) 與 [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--)。此範例開啟既有簡報並將其儲存的中繼資料輸出至主控台。數值取決於輸入的簡報；某些欄位可能為空。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **修改內建屬性**

要更新內建中繼資料，請使用由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 回傳之物件的 setter 方法。本範例開啟既有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)、[setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)、[setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)、[setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) 與 [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)，然後使用 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理超連結基底**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) 取得文件層級的相對超連結基底。使用 [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) 可變更或清除該基底。當將簡報及其連結檔案搬移至其他位置時，此功能非常有用。它與個別超連結的 [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) 分離：變更基底不會重新寫入已儲存的連結位址或變更絕對目的地。

此範例需要一個同時包含相對連結（例如 `target.html`）與絕對連結（例如 `https://example.org/absolute.html`）的簡報。它讀取現有基底，指定新基底位址，然後儲存並重新開啟簡報以檢查該值。接著以空字串清除基底，並在另一個儲存檔案中驗證空值。請將範例基底位址替換為您連結檔案所在的位置。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

兩個驗證訊息應顯示 `true`。清除基底不會影響個別超連結的位址。

當基底指向 `old` 資料夾時，指向 `target.pptx` 的相對連結會開啟 `old/target.pptx`。將基底改為 `new` 資料夾，儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則持續開啟相同檔案。在搬移簡報或變更基底前後，請在 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 方法允許您以屬性名稱指定值。此範例建立一個簡報，加入兩個文字值與一個整數版本值，並使用 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存簡報。對已存在的名稱指派值會取代該屬性的原有值。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取與修改自訂屬性**

此範例開啟包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) 迭代取得它們。[getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) 接受零基索引，回傳用於 [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 的名稱。範例列印每個原始名稱與值，將所有值以編號字串取代（不論原始類型），並儲存變更。若沒有自訂屬性，迴圈將不會產生變更。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **即時範例**

嘗試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 來了解如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報不可分割的一部份，無法完全移除。然而，您可以更改其值，或在該屬性允許的情況下將其設為空白。

**如果加入已存在的自訂屬性會發生什麼？**

若加入已存在的自訂屬性，其現有值會被新值覆寫。您不必事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 再呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 即可在不建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參考 [建立輕量級簡報清單](/slides/zh-hant/androidjava/examine-presentation/) 取得完整的報告範例與格式特定的限制。

**我可以在不提供開啟密碼的情況下讀取已加密簡報的公開屬性嗎？**

可以。簡報必須是在呼叫 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 並傳入 `false` 後加密，且在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並傳入 `true` 後載入。

**我可以在僅載入文件屬性模式下更新已加密的 PPTX 檔案嗎？**

不能。公開與加密的屬性資料必須保持一致，因此更新已加密的 PPTX 檔案必須以正確的開啟密碼完整載入簡報。