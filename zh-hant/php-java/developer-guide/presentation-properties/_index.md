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
description: "在 Aspose.Slides for PHP via Java 中精通簡報屬性，並在 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種類型的文件屬性：**內建** 和 **自訂**。這兩種屬性都能透過 Aspose.Slides API 簡單存取與管理。

Aspose.Slides 讓您可透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的實例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDocumentProperties) 方法回傳。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="primary" %}} 

請注意 **Application** 與 **Producer** 欄位無法修改，這兩個欄位始終顯示 "Aspose Ltd." 與 "Aspose.Slides for PHP via Java x.x.x"。

{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔案中加入屬性的功能。這些文件屬性允許將一些有用的資訊與文件（簡報檔案）一起儲存。文件屬性分為以下兩類：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建** 屬性包含文件的一般資訊，如文件標題、作者名稱、文件統計資料等。**自訂** 屬性則是使用者以 **名稱/值** 配對自行定義的屬性。使用 Aspose.Slides for PHP via Java，開發人員可以存取與修改內建屬性以及自訂屬性的值。

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。只需點選 Office 圖示，接著選擇 **Prepare | Properties | Advanced Properties** 功能，如下圖所示：

|**選取 Advanced Properties 功能表項目**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

選取 **Advanced Properties** 功能表項目後，會出現以下對話框，讓您管理 PowerPoint 檔案的文件屬性：

|**屬性對話框**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **屬性對話框** 中，您可以看到多個分頁，如 **General**、**Summary**、**Statistics**、**Contents** 和 **Custom**。這些分頁允許設定與 PowerPoint 檔案相關的各種資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

### 使用 Aspose.Slides for PHP via Java 處理文件屬性

如前所述，Aspose.Slides for PHP via Java 支援 **內建** 與 **自訂** 兩種文件屬性。因此，開發人員可透過 Aspose.Slides for PHP via Java API 取得兩種屬性。Aspose.Slides for PHP via Java 提供 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties) 類別，代表與簡報檔案關聯的文件屬性，並可透過 **Presentation.DocumentProperties** 屬性存取。

開發人員可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 物件公開的 **DocumentProperties** 屬性來存取簡報檔案的文件屬性，說明如下：

## **存取內建屬性**

由 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties) 物件公開的內建屬性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 和 **Title**。

```php
  # 實例化代表簡報的 Presentation 類別
  $pres = new Presentation("Presentation.pptx");
  try {
    # 建立與 Presentation 相關聯的 IDocumentProperties 物件參考
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

修改簡報檔案的內建屬性與存取它們同樣簡單。只要將字串值指定給任意欲修改的屬性，即可變更屬性值。以下範例示範如何使用 Aspose.Slides for PHP via Java 修改簡報檔案的內建文件屬性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 建立與 Presentation 相關聯的 IDocumentProperties 物件參考
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

此範例會修改簡報的內建屬性，修改後的顯示如下：

|**修改後的內建文件屬性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for PHP via Java 也允許開發人員為簡報的文件屬性新增自訂值。以下範例展示如何為簡報設定自訂屬性。

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

|**已新增的自訂文件屬性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **存取與修改自訂屬性**

Aspose.Slides for PHP via Java 亦允許開發人員存取自訂屬性的值。以下範例示範如何存取與修改簡報的所有自訂屬性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 建立與 Presentation 相關聯的 DocumentProperties 物件參考
    $dp = $pres->getDocumentProperties();
    # 存取與修改自訂屬性
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

此範例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。下圖分別顯示修改前與修改後的自訂屬性：

|**修改前的自訂屬性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="primary" %}} 

已於 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo) 新增以下方法：`readDocumentProperties`、`updateDocumentProperties` 與 `writeBindedPresentation`，同時變更了 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#setLastSavedTime) 屬性設置器的實作。

{{% /alert %}} 

兩個新方法 `readDocumentProperties` 與 `updateDocumentProperties` 已加入至 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo) 類別。它們提供快速存取文件屬性，且可在不載入完整簡報的情況下變更與更新屬性。

以下示範典型情境：載入屬性、變更某些值，然後更新文件：

```php
  # 讀取簡報資訊
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 取得目前的屬性
  $props = $info->readDocumentProperties();
  # 設定作者與標題欄位的新值
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 以新值更新簡報
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

另一種做法是使用特定簡報的屬性作為範本，更新其他簡報的屬性：

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

也可以從頭建立新範本，然後用來更新多個簡報：

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

Aspose.Slides 提供 `LanguageId` 屬性（由 PortionFormat 類別公開），允許您為 PowerPoint 文件設定校對語言。校對語言是 PowerPoint 進行拼寫與文法檢查時所使用的語言。

以下 PHP 程式碼示範如何為 PowerPoint 設定校對語言：xxx 為何 Java 的 PortionFormat 類別缺少 LanguageId？

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// 設定校對語言的 ID

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
    # 新增具有文字的矩形形狀
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 檢查第一個文字片段的語言
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

## **常見問題**

**如何移除簡報中的內建屬性？**

內建屬性是簡報的基本組成部分，無法完全移除。不過，您可以變更其值，或在該屬性允許的情況下將其設為空值。

**若加入已存在的自訂屬性會發生什麼？**

若新增的自訂屬性名稱已存在，原有的值會被新值覆寫。您不需要事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性值。

**是否可以在不完整載入簡報的情況下存取簡報屬性？**

可以，您可以使用 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/) 類別的 `getPresentationInfo` 方法取得簡報資訊，然後呼叫 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/) 類別的 `readDocumentProperties` 方法來高效讀取屬性，從而節省記憶體並提升效能。