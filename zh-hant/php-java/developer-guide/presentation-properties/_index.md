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
description: "在 Aspose.Slides for PHP via Java 中精通簡報屬性，並簡化您在 PowerPoint 與 OpenDocument 檔案中的搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for PHP via Java 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性可以讀取與更新簡報的中繼資料，例如作者、標題以及使用者自訂的值。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 類別來操作簡報文件屬性。此類別的實例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) 取得。以下範例示範如何讀取、修改與管理這些屬性。範例假設已初始化 PHP/Java Bridge 與 Aspose.Slides PHP 包裝器。

{{% alert color="info" title="注意" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作方的中繼資料；這些欄位用於識別產生輸出之軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述資訊。它們分為兩類：

- **內建屬性** 包含標準中繼資料，例如標題、作者與文件統計資訊。
- **自訂屬性** 儲存使用者自行定義的名稱/值配對。

Aspose.Slides for PHP via Java 同時提供存取這兩類屬性。在 PowerPoint 中，選取 **檔案 → 資訊 → 屬性 → 進階屬性** 以檢視文件中繼資料。此對話方塊將資訊分為 **摘要**、**統計**、**內容** 與 **自訂** 等分頁。使用 **自訂** 分頁可管理使用者定義的屬性。

## **從加密簡報中讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。當在呼叫 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) 並將 `false` 傳入後加密簡報時，其文件屬性仍保持公開。此時應用程式可呼叫 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 並將 `true` 傳入，於不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 決定 Aspose.Slides 載入的內容；它不會解密任何資料。若屬性已被加密，未提供密碼載入會失敗。若簡報未加密，則會忽略此選項，完整載入簡報。

此範例需要一個文件屬性已設定為公開的加密簡報。它透過 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) 檢查載入模式，然後使用 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) 讀取內建屬性：

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

在此模式下，幻燈片內容不會被載入。幻燈片、母片、版面配置、圖形、媒體與其他簡報物件皆無法存取。應用程式在執行需要完整簡報物件模型的操作前，務必先檢查 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="警告" %}}
公開的中繼資料可能會洩漏作者名稱、標題、主旨、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一併加密。僅在索引、分類、搜尋或文件管理系統必須在未提供密碼的情況下存取時，才將其設為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，在呼叫 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 並傳入 `true` 後載入的簡報僅供讀取公開中繼資料。Aspose.Slides 無法從此僅含屬性的物件儲存變更，因為公開屬性必須與加密簡報內的對應資料保持一致。因此，更新必須在提供正確開啟密碼並完整載入簡報的情況下執行。

此範例需要一個文件屬性為公開且已知開啟密碼的加密 PPTX 簡報。它使用 [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/) 完整載入簡報，更新公開的內建屬性，然後儲存結果。接著利用 [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) 檢查加密仍然存在，並在不提供密碼的情況下重新開啟公開中繼資料以驗證新值：

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

如果應用程式無法解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 類別透過 getter 方法公開內建中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/)、[getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) 與 [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/)。此範例開啟現有簡報，並將其儲存的中繼資料輸出至主控台。值取決於輸入的簡報；某些欄位可能為空。

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

## **修改內建屬性**

若要更新內建中繼資料，請使用由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) 取得的物件的 setter 方法。此範例開啟現有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/)、[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/)、[setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/)、[setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) 與 [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/)，然後使用 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 儲存已更新的簡報。儲存的 PPTX 會包含新的中繼資料。

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

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) 會回傳文件層級的相對超連結基礎 URL。使用 [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) 可變更或清除它。此功能在將簡報與其連結檔案移至其他位置時相當有用。它與個別超連結的 [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) 分離：變更基礎不會重新寫入已儲存的連結位址或改變絕對目的地。

此範例需要一個同時包含相對連結（例如 `target.html`）與絕對連結（例如 `https://example.org/absolute.html`）的簡報。它會讀取現有基礎、指派新基礎位址，然後儲存並重新開啟簡報以檢查值。接著以空字串清除基礎，並在另一個已儲存的檔案中驗證空值。請將範例基礎位址替換為您連結檔案的實際位置。

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

兩個驗證訊息皆應印出 `true`。清除基礎不會影響個別超連結位址。

若基礎指向 `old` 資料夾，則相對連結 `target.pptx` 會開啟 `old/target.pptx`。將基礎改為 `new` 資料夾後儲存並重新開啟簡報，同一連結會開啟 `new/target.pptx`。絕對連結則持續開啟相同檔案。請在搬移簡報或變更基礎前後於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性用於儲存沒有對應內建欄位的中繼資料。[DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) 方法允許您依屬性名稱指派值。此範例建立簡報，新增兩個文字值與一個整數版本值，最後使用 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 儲存簡報。對已存在的名稱指派新值會覆寫該屬性的原有值。

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

此範例開啟一個包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) 迭代它們。[getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) 接受從零開始的索引，回傳由 [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) 使用的名稱。範例會列印每個原始名稱與值，將所有值以編號字串取代（不論原始類型），並儲存變更。若沒有自訂屬性，迴圈不會執行任何變更。

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

試用線上應用程式 [**檢視與編輯 PowerPoint 中繼資料**](https://products.aspose.app/slides/metadata) 了解如何使用 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部份，無法完全移除。然而，您可以變更其值，或在該屬性允許的情況下將其設為空白。

**如果加入已存在的自訂屬性會發生什麼？**

若加入已存在的自訂屬性，原有的值會被新值覆寫。您不需要事先移除或檢查該屬性，Aspose.Slides 會自動更新其值。

**我可以在未完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/)，然後呼叫 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 實例的前提下讀取儲存的文件中繼資料。請參閱 [建立輕量級簡報清單](/slides/zh-hant/php-java/examine-presentation/) 以取得完整的報告範例與格式限制說明。

**我可以在未提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。前提是簡報在呼叫 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) 並傳入 `false` 後進行加密，且載入時使用 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 並傳入 `true`。

**我可以在僅載入文件屬性模式下更新加密的 PPTX 檔案嗎？**

不能。公開屬性與加密屬性資料必須保持一致，因此更新加密 PPTX 檔案必須使用正確的開啟密碼完整載入簡報。