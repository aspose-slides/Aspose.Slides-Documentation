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
description: "在 Aspose.Slides for PHP via Java 中精通簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種文件屬性類型：**內建**和**自訂**。這兩種屬性類型都可以輕鬆透過 Aspose.Slides API 進行存取和管理。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/) 類別來操作簡報文件屬性。此類別的實例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getDocumentProperties) 方法回傳。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意，**Application** 與 **AppVersion** 欄位無法修改。Aspose.Slides 會在每次儲存時重新寫入這些欄位，因此已儲存的簡報始終顯示「Aspose.Slides for PHP via Java」以及產生它的函式庫版本。傳遞給 `setNameOfApplication` 的任何值在寫入簡報時都會被捨棄。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔中加入屬性的功能。這些文件屬性可將一些有用資訊與文件（簡報檔）一起儲存。文件屬性分為以下兩種：

- 系統定義（內建）屬性
- 使用者自訂（自訂）屬性

**內建**屬性包含有關文件的一般資訊，例如文件標題、作者姓名、文件統計資料等。**自訂**屬性則由使用者以 **Name/Value** 配對的方式自行定義，名稱與值皆由使用者決定。使用 Aspose.Slides for PHP via Java，開發人員可以存取與修改內建屬性及自訂屬性的值。

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許管理簡報檔的文件屬性。只要點選 Office 圖示，然後選取 **Prepare | Properties | Advanced Properties** 功能表項目，如下圖所示：

|**選取「Advanced Properties」功能表項目**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

在選取 **Advanced Properties** 功能表項目後，會出現對話方塊允許您管理 PowerPoint 檔的文件屬性，如下圖所示：

|**屬性對話方塊**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **屬性對話方塊** 中，您可以看到有多個分頁，例如 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom**。所有這些分頁允許設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

### 使用 Aspose.Slides for PHP via Java 處理文件屬性

如前所述，Aspose.Slides for PHP via Java 支援兩種文件屬性，即 **內建** 與 **自訂** 屬性。因此，開發人員可透過 Aspose.Slides for PHP via Java API 存取兩種屬性。Aspose.Slides for PHP via Java 提供 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties) 類別，代表與簡報檔相關聯的文件屬性，透過 **Presentation.DocumentProperties** 屬性存取。

開發人員可使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 物件所公開的 **DocumentProperties** 屬性，依下列方式存取簡報檔的文件屬性：

## **存取內建屬性**

透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties) 物件公開的這些屬性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同製作人之間共享？）、**PresentationFormat**、**Subject** 和 **Title**。

```php
  # 實例化表示簡報的 Presentation 類別
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

修改簡報檔的內建屬性與存取它們同樣簡單。只需將字串值指派給任意欲更改的屬性，即可修改屬性值。以下範例示範如何使用 Aspose.Slides for PHP via Java 修改簡報檔的內建文件屬性。

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
    # 將簡報儲存為檔案
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此範例修改簡報的內建屬性，結果如下所示：

|**修改後的內建文件屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **新增自訂文件屬性**

Aspose.Slides for PHP via Java 也允許開發人員為簡報的文件屬性新增自訂值。以下範例示範如何為簡報設定自訂屬性。

```php
  $pres = new Presentation();
  try {
    # 取得文件屬性
    $dProps = $pres->getDocumentProperties();
    # 新增自訂屬性
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # 取得特定索引處的屬性名稱
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

Aspose.Slides for PHP via Java 也允許開發人員存取自訂屬性的值。以下範例示範如何存取並修改簡報的所有自訂屬性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 建立與 Presentation 相關聯的 DocumentProperties 物件參考
    $dp = $pres->getDocumentProperties();
    # 存取並修改自訂屬性
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # 顯示自訂屬性的名稱與值
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # 修改自訂屬性的值
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # 將簡報儲存為檔案
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此範例修改 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。下列圖示分別顯示修改前後的簡報自訂屬性：

|**修改前的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改後的自訂屬性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **進階文件屬性**

{{% alert color="info" title="Note" %}}
已在 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo) 中加入新方法 [readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) 與 [writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)。[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/#setLastSavedTime) 屬性設定子的邏輯已被修改。
{{% /alert %}} 

已在 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo) 類別中加入兩個新方法 [readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) 與 [updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)。它們可快速存取文件屬性，且在不載入整個簡報的情況下變更與更新屬性。

典型的情境是載入屬性、變更某些值後更新文件，可透過以下方式實作：

```php
  # 讀取簡報資訊
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 取得目前的屬性
  $props = $info->readDocumentProperties();
  # 設定 Author 與 Title 欄位的新值
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 使用新值更新簡報
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

另一種方法是將特定簡報的屬性作為範本，來更新其他簡報的屬性：

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

可以從零建立新範本，然後用來更新多個簡報：

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

Aspose.Slides 提供 LanguageId 屬性（由 PortionFormat 類別公開），讓您為 PowerPoint 文件設定校對語言。校對語言是 PowerPoint 進行拼字與文法檢查的語言。

此 PHP 程式碼示範如何為 PowerPoint 設定校對語言：xxx 為何 Java 的 PortionFormat 類別缺少 LanguageId？

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
    $portionFormat->setLanguageId("zh-CN");// 設定校對語言的 ID

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定預設語言**

此 PHP 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 新增一個帶文字的矩形圖形
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 檢查第一個部分的語言
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **即時範例**

試用線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) ，以了解如何透過 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以變更其值，或在該屬性允許的情況下將其設為空值。

**如果新增已存在的自訂屬性會發生什麼？**

若新增的自訂屬性已存在，則會以新值覆寫其原有值。您不必事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**是否能在未完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationfactory/)，接著呼叫 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例的情況下讀取已存儲的文件中繼資料。請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/php-java/examine-presentation/) 以取得完整的報告範例與格式相關的限制。