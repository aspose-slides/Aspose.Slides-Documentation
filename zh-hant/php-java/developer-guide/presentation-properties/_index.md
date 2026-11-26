---
title: 在 PHP 中管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/php-java/presentation-properties/
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
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中管理簡報屬性，並在 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for PHP via Java 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性來讀取和更新簡報的中繼資料，例如作者、標題以及使用者自訂的值。

Aspose.Slides 讓您可以透過 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的實例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) 取得。以下範例示範如何讀取、修改與管理這些屬性。它們假設已初始化 PHP/Java Bridge 與 Aspose.Slides PHP 包裝器。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用來識別建立輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標準中繼資料，例如標題、作者與文件統計資訊。
- **自訂屬性** 儲存使用者自訂的名稱/值配對。

Aspose.Slides for PHP via Java 提供對兩種屬性的存取。於 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢視文件中繼資料。對話方塊會將資訊分為 **Summary**、**Statistics**、**Contents** 與 **Custom** 等分頁。使用 **Custom** 分頁來管理使用者自訂屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常同時保護簡報內容與文件屬性。當在呼叫 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 並傳入 `false` 後對簡報進行加密時，其文件屬性會保持為公開。此時應用程式可以呼叫 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `true`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 所載入的內容；它不會執行解密。如果屬性已包含在加密中，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，並載入完整的簡報。

此範例需要一個文件屬性保持公開的已加密簡報。它透過 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 檢查載入模式，然後使用 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) 讀取內建屬性：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

在此模式下，不會載入投影片內容。投影片、投影片母片、版面配置、圖形、媒體以及其他簡報物件皆無法存取。應用程式在執行需要完整簡報物件模型的操作前，應先檢查 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公開的中繼資料可能會洩漏作者名稱、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一併加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在未提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新已加密簡報的屬性**

對於已加密的 PPTX 檔案，若在呼叫 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `true` 後載入簡報，則僅用於讀取公開的中繼資料。Aspose.Slides 無法從僅含中繼資料的物件儲存變更的屬性，因為公開屬性必須與加密簡報內的相應資料保持一致。因此更新這些屬性需要正確的開啟密碼以及完整載入簡報。

此範例需要一個具有公開文件屬性且已知開啟密碼的已加密 PPTX 簡報。它以 [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) 開啟完整簡報，更新公開的內建屬性，並儲存結果。接著使用 [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) 來驗證加密仍然保留，並在不提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

如果應用程式不被允許解密或載入簡報內容，則必須將已加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 類別透過 getter 方法公開內建中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor)、[getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) 與 [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime)。此範例開啟現有簡報，並將其儲存的中繼資料輸出至主控台。值取決於輸入的簡報；某些欄位可能為空。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

### **報告修訂號與編輯時間**

要報告 `presentations` 資料夾中每個 PPTX 檔案的修訂號與總編輯時間，可使用 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取其 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/)，而不載入投影片以進行編輯。PHP via Java API 以毫秒傳回編輯時間。此範例將其轉換為時、分、秒，並在持續時間超過 24 小時時加入天數。

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

對於修訂號為 17、且記錄的編輯時間為 1 天 2 小時 5 分鐘的簡報，報告會顯示以下輸出。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) 讀取一個值，應用程式可使用 [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) 變更。單憑修訂號無法確定簡報被儲存的次數或重建其版本歷史。

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) 讀取檔案中記錄的編輯持續時間。即使有人編輯過，簡報的儲存時間也可能為零 (`00:00:00`)。

## **修改內建屬性**

若要更新內建中繼資料，請使用由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) 回傳之物件的 setter 方法。此範例開啟現有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor)、[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle)、[setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject)、[setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) 與 [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager)，然後以 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 儲存更新後的簡報。儲存的 PPTX 內含新的中繼資料。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **管理超連結基礎 URL**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) 取得相對超連結的文件層級基礎 URL。使用 [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) 變更或清除它。當將簡報及其連結檔案搬移到其他位置時此功能很有用。它與個別超連結的 [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) 是分離的：變更基礎不會重新寫入已儲存的連結位址或改變絕對目的地。

此範例需要一個簡報，其中同時包含相對連結（例如 `target.html`）與絕對連結（例如 `https://example.org/absolute.html`）。它讀取現有的基礎，指派新的基礎位址，並儲存與重新開啟簡報以檢查該值。接著以空字串清除基礎，並在另一個已儲存的檔案中驗證該空值。請將範例基礎位址替換為您連結檔案的實際位置。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

兩個驗證訊息應該會印出 `true`。清除基礎不會影響個別超連結的位址。

當基礎指向 `old` 資料夾時，指向 `target.pptx` 的相對連結會開啟 `old/target.pptx`。將基礎變更為 `new` 資料夾後，儲存並重新開啟簡報，相同的連結會開啟 `new/target.pptx`。絕對連結仍會開啟相同的檔案。請在搬移簡報或變更基礎前後，於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) 方法允許您依屬性名稱指派值。此範例建立一個簡報，加入兩個文字值與一個整數版本值，並以 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 儲存簡報。對已存在的名稱指派值會取代該屬性的值。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **存取與修改自訂屬性**

此範例開啟包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) 迭代它們。[getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) 接受零基索引，並回傳由 [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) 使用的名稱。範例列印每個原始名稱與值，將所有值以編號字串取代（不論原始類型），並儲存變更。若沒有自訂屬性，迴圈不會做任何變更。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **即時範例**

嘗試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 處理文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以變更它們的值，或在該屬性允許的情況下將其設為空白。

**如果我加入已存在的自訂屬性會發生什麼？**

如果您加入已存在的自訂屬性，其原有值會被新值覆寫。您不需要事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**是否可以在不完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 然後呼叫 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 以在不建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 實例的情況下讀取儲存的文件中繼資料。請參閱 [建立輕量簡報清單](/slides/zh-hant/php-java/examine-presentation/) 以取得完整的報告範例及格式限制說明。

**是否可以在未提供開啟密碼的情況下讀取已加密簡報的公開屬性？**

可以。必須在呼叫 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 並傳入 `false` 後對簡報進行加密，且在呼叫 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `true` 後載入。

**是否可以在僅載入文件屬性模式下更新已加密的 PPTX 檔案？**

不能。公開與加密的屬性資料必須保持一致，因而在僅載入文件屬性模式下更新已加密的 PPTX 檔案需以正確的開啟密碼載入完整簡報。