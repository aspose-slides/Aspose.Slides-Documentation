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
description: "在 Aspose.Slides for Android via Java 中掌握簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化及工作流程。"
---
## **簡介**

Aspose.Slides for Android via Java 支援 **內建** 和 **自訂** 文件屬性。使用這些屬性可讀取和更新簡報的中繼資料，例如作者、標題和使用者自訂值。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 取得。以下示例說明如何讀取、修改和管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用於識別產生輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標題、作者、文件統計資訊等標準中繼資料。
- **自訂屬性** 儲存使用者定義的名稱/值配對。

Aspose.Slides for Android via Java 提供對兩種屬性的存取。於 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢查文件中繼資料。對話方塊將資訊分為 **Summary**、**Statistics**、**Contents** 與 **Custom** 等分頁。使用 **Custom** 分頁即可管理使用者自訂屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。若在呼叫 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 時傳入 `false`，則其文件屬性仍保持公開。此時應用程式可以使用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並設定為 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 控制 Aspose.Slides 載入的內容；它不會解密任何資料。如果屬性已被加密，則在未提供密碼的情況下載入會失敗。若簡報未加密，則會忽略此選項，完整載入簡報。

此示例需要一個文件屬性保持公開的加密簡報。它透過 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) 檢查載入模式，然後透過 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 讀取內建屬性：

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

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、形狀、媒體及其他簡報物件皆無法存取。應用程式在執行需要完整簡報物件模型的操作前，務必先檢查 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)。

{{% alert color="warning" title="Warning" %}}
公開的中繼資料可能會洩漏作者名稱、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統必須在不提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，在使用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並設定 `true` 後載入的簡報僅供讀取公開中繼資料。Aspose.Slides 無法從僅載入文件屬性的物件儲存變更，因為公開屬性必須與加密簡報內的對應資料保持一致。因此，更新屬性必須提供正確的開啟密碼並完整載入簡報。

此示例需要一個文件屬性公開且已知開啟密碼的加密 PPTX 簡報。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 完整載入簡報，更新公開的內建屬性，然後儲存結果。接著使用 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) 驗證加密仍然存在，並在不提供密碼的情況下重新開啟公開中繼資料以驗證新值：

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

如果應用程式未被允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 介面透過 getter 方法公開內建中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--)、[getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) 與 [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) 等。此示例開啟現有簡報並將其儲存的中繼資料輸出至主控台。值取決於輸入的簡報；某些欄位可能為空。

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

### **報告修訂號與編輯時間**

若 Android 應用程式需為資料夾中的每個 PPTX 檔案產生一列報告，可呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 讀取其 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 而不載入投影片供編輯。Android via Java API 以毫秒為單位回傳編輯時長。請將範例資料夾路徑替換為您自己的檔案路徑。此示例會將時長格式化為「時、分、秒」，若時長超過 24 小時則亦顯示天數。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.File;
import java.util.Locale;

File folder = new File("/path/to/presentations");
File[] files = folder.listFiles();
if (files == null) {
    System.out.println("Cannot list files in " + folder);
} else {
    System.out.println("File | RevisionNumber | TotalEditingTime");
    for (File file : files) {
        if (!file.isFile() || !file.getName().toLowerCase(Locale.ROOT).endsWith(".pptx")) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(file.getAbsolutePath());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format(Locale.ROOT, "%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf(Locale.ROOT, "%s | %d | %s%n", file.getName(), properties.getRevisionNumber(), editingTime);
    }
}
```

若簡報的編輯時間為 1 天 2 小時 5 分鐘，報告會顯示如下輸出。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getRevisionNumber--) 讀取的值可透過 [setRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) 變更。單純的修訂號無法判斷簡報被儲存了多少次，也無法還原其版本歷史。

[getTotalEditingTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) 讀取檔案中記錄的編輯時長。若值為 `00:0:0`，即使有人編輯過簡報，儲存的時長仍為零。

## **修改內建屬性**

若要更新內建中繼資料，請使用由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 取得之物件的 setter 方法。本示例開啟現有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)、[setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)、[setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)、[setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)、[setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)，然後使用 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

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

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) 會回傳文件層級的相對超連結基礎位址。使用 [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) 可變更或清除它。當簡報及其連結檔案搬移到其他位置時，這項功能非常有用。它與個別超連結的 [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) 分開：變更基礎不會改寫已儲存的連結位址或改變絕對目的地。

此示例需要一個同時包含相對連結（如 `target.html`）與絕對連結（如 `https://example.org/absolute.html`）的簡報。它會讀取現有基礎、指派新基礎位址，然後儲存並重新開啟簡報以檢查值。接著以空字串清除基礎，並在另一個儲存檔案中驗證空值。請將示例基礎位址替換為您連結檔案所在的位置。

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

兩條驗證訊息均應顯示 `true`。清除基礎不會影響個別超連結的位址。

相對連結 `target.pptx` 在基礎指向 `old` 資料夾時會開啟 `old/target.pptx`。將基礎改為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟原檔案。請在搬移簡報或變更基礎前後於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性用於儲存沒有對應內建欄位的中繼資料。使用 [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 方法可依屬性名稱指定值。此示例建立一個簡報，加入兩個文字值與一個整數版本值，然後使用 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 儲存。若使用已存在的名稱設定值，會取代該屬性的原有值。

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

此示例開啟一個包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) 迭代它們。[getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) 接受零基索引並回傳由 [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 使用的名稱。示例會列印每個原始名稱與值，將每個值以編號字串取代（不論原始型別），並儲存變更。若無自訂屬性，迴圈不會產生變更。

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

## **線上範例**

使用線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 來體驗如何使用 Aspose.Slides API 處理文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問與答**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。但您可以變更其值，或在該屬性允許的情況下將其設為空字串。

**如果新增的自訂屬性已存在會發生什麼？**

若新增的自訂屬性名稱已存在，原有值會被新值覆寫。您不必事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**是否能在未完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)，然後呼叫 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 即可在不建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 實例的情況下讀取儲存的文件中繼資料。請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/androidjava/examine-presentation/) 瞭解完整的報告示例與格式限制。

**是否能在未提供開啟密碼的情況下讀取加密簡報的公開屬性？**

可以。前提是簡報在呼叫 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 並傳入 `false` 後加密，且載入時使用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 並設定為 `true`。

**能否在僅載入文件屬性模式下更新加密的 PPTX 檔案？**

不能。公開與加密的屬性資料必須保持一致，因而在更新加密 PPTX 檔案時必須使用正確的開啟密碼完整載入簡報。