---
title: 管理 Java 中的簡報屬性
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

Aspose.Slides for Java 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性可以讀取與更新簡報的中繼資料，例如作者、標題以及使用者自訂的值。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例是由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="注意" %}}

Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位會標示產生輸出的軟體。

{{% /alert %}}

## **管理簡報屬性**

文件屬性會將描述性資訊與簡報內容一起儲存。它們分為兩類：

- **內建屬性** 含有標準的中繼資料，例如標題、作者與文件統計資訊。
- **自訂屬性** 儲存使用者自訂的名稱/值組合。

Aspose.Slides for Java 同時提供兩類屬性的存取。在 PowerPoint 中，選取 **檔案 → 資訊 → 屬性 → 詳細屬性** 以檢視文件中繼資料。對話方塊會將資訊分為 **摘要**、**統計**、**內容** 與 **自訂** 等分頁。使用 **自訂** 分頁可管理使用者自訂的屬性。

## **從已加密的簡報讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。當在呼叫 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 並傳入 `false` 後對簡報進行加密時，其文件屬性仍保持公開。此時應用程式可以呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並傳入 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 控制 Aspose.Slides 載入的內容；它不會執行任何解密動作。如果屬性已包含在加密中，未提供密碼而載入將失敗。若簡報未加密，則會忽略此選項，完整載入簡報。

此範例需要一個文件屬性已設定為公開的加密簡報。它會透過 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) 檢查載入模式，然後使用 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 讀取內建屬性：

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

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、形狀、媒體以及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應先檢查 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)。

{{% alert color="warning" title="警告" %}}
公開的中繼資料可能會洩漏作者名稱、標題、主旨、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統必須在未提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新已加密簡報的屬性**

對於已加密的 PPTX 檔案，若在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並傳入 `true` 後載入簡報，僅用於讀取公開的中繼資料。Aspose.Slides 無法在此僅文件屬性的物件上儲存變更，因為公開屬性必須與加密簡報中的相應資料保持一致。因此，更新這些屬性必須提供正確的開啟密碼並完整載入簡報。

此範例需要一個文件屬性為公開且已知開啟密碼的加密 PPTX 簡報。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 完整開啟簡報，更新公開的內建屬性，並儲存結果。接著使用 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) 驗證加密仍然保留，並在不提供密碼的情況下重新開啟公開的中繼資料，以驗證新值：

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

若應用程式無法解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) 介面透過 getter 方法公開內建中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--)、[getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) 與 [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--)。此範例開啟已存在的簡報，並將其儲存的中繼資料列印到主控台。值會依輸入的簡報而異，某些欄位可能為空。

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

### **報告版本號與編輯時間**

若要在 `presentations` 資料夾中為每個 PPTX 檔案報告一列，請呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 以在不載入投影片的情況下讀取其 [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/)。Java API 會以毫秒回傳編輯時長。範例會將其格式化為時、分、秒，若時長超過 24 小時則顯示天數。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

System.out.println("File | RevisionNumber | TotalEditingTime");
try (DirectoryStream<Path> files = Files.newDirectoryStream(Paths.get("presentations"), "*.pptx")) {
    for (Path path : files) {
        if (!Files.isRegularFile(path)) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(path.toString());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format("%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf("%s | %d | %s%n", path.getFileName(), properties.getRevisionNumber(), editingTime);
    }
}
```

對於編輯時間為 1 天 2 小時 5 分鐘的簡報，報告會顯示以下輸出。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getRevisionNumber--) 讀取可由 [setRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) 變更的值。僅憑版本號無法判斷簡報保存了多少次，亦無法重建其版本歷史。

[getTotalEditingTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) 讀取檔案中記錄的編輯時長。`00:00:00` 代表儲存的時長為零，即使有人編輯過簡報。

## **修改內建屬性**

要更新內建中繼資料，請使用由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 回傳之物件的 setter 方法。此範例開啟已存在的簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)、[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)、[setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)、[setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)、[setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)，然後使用 [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理超連結基礎位址**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) 會回傳文件層級的相對超連結基礎位址。使用 [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) 可變更或清除它。當搬移簡報及其相關檔案至其他位置時，此功能很有用。它與個別超連結的 [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) 分開：變更基礎位址不會重新寫入已儲存的連結位址，也不會改變絕對目的地。

此範例需要一個同時包含相對連結（如 `target.html`）與絕對連結（如 `https://example.org/absolute.html`）的簡報。它會讀取現有基礎位址、指派新基礎位址，然後儲存並重新開啟簡報以檢查值。接著以空字串清除基礎位址，並在另一個儲存的檔案中驗證空值。請將範例基礎位址替換為您連結檔案所在的位置。

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

兩個驗證訊息皆應印出 `true`。清除基礎位址不會影響個別超連結的位址。

相對連結 `target.pptx` 在基礎位址指向 `old` 資料夾時會開啟 `old/target.pptx`。將基礎位址改為 `new` 資料夾後，儲存並重新開啟簡報，相同連結會開啟 `new/target.pptx`。絕對連結則仍會開啟相同檔案。請在搬移簡報或變更基礎位址前後，於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 方法允許您以屬性名稱指派值。此範例建立一個簡報，新增兩個文字值與一個整數版本值，然後使用 [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存簡報。對已存在的名稱指派值會取代該屬性的原有值。

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

此範例開啟包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) 迭代它們。[getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) 接受從 0 起算的索引，回傳用於 [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 的名稱。範例會列印每個原始名稱與值，將每個值以編號字串取代（不論原始型別），最後儲存變更。若無自訂屬性，迴圈不會執行任何變更。

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

線上試試 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 應用程式，了解如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題集**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的整體組成部分，無法完全移除。不過，您可以變更其值，或在該屬性允許的情況下將其設為空值。

**如果新增已存在的自訂屬性會發生什麼？**

若新增的自訂屬性名稱已存在，原有值會被新值覆寫。您不必事先移除或檢查此屬性，因為 Aspose.Slides 會自動更新屬性值。

**是否可以在未完整載入簡報的情況下存取簡報屬性？**

可以。先使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)，再呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 讀取儲存的文件中繼資料，而不必建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 實例。相關完整報告範例與格式限制請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/java/examine-presentation/)。

**是否可以在未提供開啟密碼的情況下讀取已加密簡報的公開屬性？**

可以。前提是簡報在呼叫 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 並傳入 `false` 後才進行加密，且必須在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並傳入 `true` 後載入。

**是否可以在僅文件屬性模式下更新已加密的 PPTX 檔案？**

不能。公開與加密的屬性資料必須保持一致，因此更新已加密的 PPTX 檔案必須使用正確的開啟密碼完整載入簡報。