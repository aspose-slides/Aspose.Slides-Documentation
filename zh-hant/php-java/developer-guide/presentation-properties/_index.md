---
title: 管理 PHP 中的簡報屬性
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
description: "在 Aspose.Slides for PHP via Java 中掌握簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種文件屬性類型：**內建** 和 **自訂**。這兩種屬性類型都可以透過 Aspose.Slides API 輕鬆存取與管理。

Aspose.Slides 讓您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的實例是由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDocumentProperties) 方法回傳。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}

請注意 **Application** 與 **AppVersion** 欄位無法修改。Aspose.Slides 於每次儲存時會重新寫入它們，因此已儲存的簡報始終顯示「Aspose.Slides for PHP via Java」以及產生它的程式庫版本。傳入 `setNameOfApplication` 的任何值在寫入簡報時都會被捨棄。

{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔案中加入某些屬性的功能。這些文件屬性允許將有用的資訊與文件（簡報檔案）一起儲存。文件屬性分為以下兩種：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建** 屬性包含文件的通用資訊，如文件標題、作者名稱、文件統計資料等。**自訂** 屬性則是使用者以 **名稱/值** 配對的方式自行定義。使用 Aspose.Slides for PHP via Java，開發人員可以存取與修改內建屬性以及自訂屬性的值。

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。您只需點選 Office 圖示，然後選取 **Prepare | Properties | Advanced Properties** 如下圖所示：

|**選取 Advanced Properties 功能表項目**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
選取 **Advanced Properties** 功能表項目後，會出現如圖所示的對話方塊，可管理 PowerPoint 檔案的文件屬性：

|**屬性對話方塊**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
在上述 **屬性對話方塊** 中，您可以看到多個分頁，如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。所有這些分頁都允許設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

使用 Aspose.Slides for PHP via Java 操作文件屬性

如前所述，Aspose.Slides for PHP via Java 支援兩種文件屬性：**內建** 與 **自訂**。開發人員可透過 Aspose.Slides for PHP via Java API 取得這兩種屬性。Aspose.Slides for PHP via Java 提供 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties) 類別，透過 **Presentation.DocumentProperties** 屬性表示與簡報檔案關聯的文件屬性。

開發人員可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 物件公開的 **DocumentProperties** 屬性，存取簡報檔案的文件屬性，如下所示：

## **從加密簡報中讀取公共屬性**

開啟密碼通常會保護簡報內容與文件屬性。當簡報透過將 `false` 傳給 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 進行加密時，其文件屬性保持為公共。此時應用程式可以將 `true` 傳給 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties)，在不提供開啟密碼的情況下讀取公共中繼資料。

文件屬性僅載入選項會控制 Aspose.Slides 載入的內容；它不會解密任何資料。如果屬性已包含在加密中，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，並載入完整簡報。

以下範例透過 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 驗證載入模式，然後透過 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDocumentProperties) 讀取內建屬性：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

在此模式下，幻燈片內容不會被載入。幻燈片、母片、版面配置、形狀、媒體以及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應始終檢查 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公共中繼資料可能會洩露作者名稱、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。只有在索引、分類、搜尋或文件管理系統明確要求在未提供密碼的情況下存取時，才將它們保持為公共。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，以文件屬性僅載入模式載入的簡報僅用於讀取公共中繼資料。Aspose.Slides 無法儲存從僅文件屬性物件中變更的屬性，因為公共屬性必須與加密簡報內的相應資料保持一致。因此，更新這些屬性需要正確的開啟密碼與完整載入。

以下範例使用 [LoadOptions::setPassword](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/#setPassword) 開啟簡報，更新公共內建屬性，並儲存結果。接著使用 [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#isEncrypted) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公共中繼資料以驗證新值：

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

如果應用程式不允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公共屬性視為唯讀。

## **存取內建屬性**

由 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties) 物件公開的屬性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同製作者間共享？）、**PresentationFormat**、**Subject** 與 **Title**。

```php
  # 實例化代表簡報的 Presentation 類別
  $pres = new Presentation("Presentation.pptx");
  try {
    # 建立與 Presentation 相關聯的 IDocumentProperties 物件的參考
    $dp = $pres->getDocumentProperties();
    # 顯示內建屬性
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **修改內建屬性**

修改簡報檔案的內建屬性與存取它們同樣簡單。只需將字串值指派給任意想要的屬性，即可修改屬性值。以下範例示範如何使用 Aspose.Slides for PHP via Java 修改簡報的內建文件屬性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 建立與 Presentation 相關聯的 IDocumentProperties 物件的參考
    $dp = $pres->getDocumentProperties();
    # 設定內建屬性
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # 將簡報儲存至檔案
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此範例修改了簡報的內建屬性，修改後的結果如圖所示：

|**修改後的內建文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for PHP via Java 亦允許開發人員為簡報文件屬性新增自訂值。以下範例說明如何為簡報設定自訂屬性。

```php
  $pres = new Presentation();
  try {
    # 取得文件屬性
    $dProps = $pres->getDocumentProperties();
    # 新增自訂屬性
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # 取得特定索引的屬性名稱
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # 移除選取的屬性
    $dProps->removeCustomProperty($getPropertyName);
    # 儲存簡報
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**已新增的自訂文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **存取與修改自訂屬性**

Aspose.Slides for PHP via Java 亦允許開發人員存取自訂屬性的值。以下範例說明如何存取與修改簡報的所有自訂屬性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 建立與 Presentation 相關聯的 DocumentProperties 物件的參考
    $dp = $pres->getDocumentProperties();
    # 存取並修改自訂屬性
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # 顯示自訂屬性的名稱與值
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # 修改自訂屬性的值
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # 將簡報儲存至檔案
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此範例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。下圖分別展示了修改前後的自訂屬性：

|**修改前的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="info" title="Note" %}}

已於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo) 新增方法 [readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) 與 [writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)，且 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#setLastSavedTime) 屬性設定器的邏輯也已變更。

{{% /alert %}} 

已於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo) 類別中新增兩個方法 [readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) 與 [updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)。它們提供快速存取文件屬性的方式，且可在不載入整個簡報的情況下變更與更新屬性。

以下示範典型情境：載入屬性、變更某些值並更新文件：

```php
  # 讀取簡報資訊
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 取得目前的屬性
  $props = $info->readDocumentProperties();
  # 設定 Author 與 Title 欄位的新值
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 以新值更新簡報
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

另一種做法是將特定簡報的屬性作為範本，更新其他簡報的屬性：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

也可以從頭建立新範本，然後用於更新多個簡報：

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **設定校對語言**

Aspose.Slides 提供 LanguageId 屬性（由 PortionFormat 類別公開），讓您為 PowerPoint 文件設定校對語言。校對語言即 PowerPoint 進行拼寫與文法檢查的語言。

以下 PHP 程式碼示範如何為 PowerPoint 設定校對語言：xxx 為何 Java PortionFormat 類別中缺少 LanguageId？

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// 設定校對語言的 Id

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定預設語言**

以下 PHP 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 新增一個帶文字的矩形形狀
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 檢查第一段落的語言
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **線上範例**

試用 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 線上應用程式，了解如何透過 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問答**

**如何移除簡報中的內建屬性？**

內建屬性是簡報不可分割的一部分，無法完全移除。不過，您可以更改其值，或在該屬性允許的情況下將其設定為空。

**如果新增的自訂屬性已存在，會發生什麼？**

若新增的自訂屬性已存在，系統會以新值覆寫既有值。您不必先移除或檢查該屬性，Aspose.Slides 會自動更新屬性值。

**能否在不完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/) 再呼叫 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/php-java/examine-presentation/) 取得完整報告範例與格式限制說明。

**能否在未提供開啟密碼的情況下讀取加密簡報的公共屬性？**

可以。前提是文件屬性加密在簡報加密之前已停用，且簡報必須以僅文件屬性模式載入。

**能否在僅文件屬性模式下更新加密的 PPTX 檔案？**

不能。公共屬性與加密屬性資料必須保持一致，因此必須以正確的開啟密碼完整載入簡報才能更新加密的 PPTX 檔案。