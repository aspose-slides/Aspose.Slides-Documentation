---
title: 使用 PHP 管理簡報中的標記與自訂資料
linktitle: 標記與自訂資料
type: docs
weight: 300
url: /zh-hant/php-java/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標記
- 自訂資料
- 自訂 XML
- 自訂 XML 部分
- XML 中繼資料
- ItemId
- 新增標記
- 配對值
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中管理標記與自訂 XML 資料，包括新增、讀取、更新、稽核和移除自訂 XML 部分。"
---
## **概觀**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標記 (tags) 與自訂資料。與簡報相關的資料可以儲存為標記或自訂 XML 部分。標記是簡單的鍵值字串對，而自訂 XML 部分則可儲存結構化的中繼資料與應用程式專屬的 XML 負載。

Aspose.Slides 提供用於在簡報、投影片和圖形層級新增、讀取、更新、稽核與移除自訂 XML 部分的 API。自訂 XML 部分對於需要在簡報內儲存諸如文件管理識別碼、工作流程狀態、合規性中繼資料、範本繫結資料或其他結構化應用程式資料的整合非常有用。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx` 的檔案）以 PresentationML 格式儲存，該格式屬於 Office Open XML 規範的一部分。Office Open XML 定義了用於儲存簡報內容及相關資料的封裝結構與關聯。

一個簡報包含多個透過關聯連結的部件。例如，投影片部件包含單一投影片的內容，並且可以與 ISO/IEC 29500 定義的其他部件建立明確的關聯。

自訂資料可以儲存為標記（[TagCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/)）或自訂 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpartcollection/)）。兩者皆可透過 [`CustomData`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customdata/) 類別取得。

{{% alert color="primary" %}}
標記儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，並且可以與簡報、投影片或圖形關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

`[`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customdata/#getCustomXmlParts)` 方法會回傳與特定簡報物件關聯的自訂 XML 部分集合。例如：

- `$presentation->getCustomData()->getCustomXmlParts()` 包含與簡報本身關聯的自訂 XML 部分。
- `$slide->getCustomData()->getCustomXmlParts()` 包含與特定投影片關聯的自訂 XML 部分。
- `$shape->getCustomData()->getCustomXmlParts()` 包含與特定圖形關聯的自訂 XML 部分。

在需要檢視簡報中所有自訂 XML 部分（不論其關聯於何處）時，請使用 [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getAllCustomXmlParts)。

### **將自訂 XML 部分新增至簡報**

使用 [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpartcollection/#add) 可將 XML 資料加入自訂 XML 部分集合。XML 必須有效且非空。

以下範例將結構化的中繼資料新增至簡報層級的自訂資料集合：

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add 會自動指派識別碼。僅在需要時才設定特定的 UUID。
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`add` 方法也可以接受 XML 的位元組陣列或輸入串流，這在 XML 內容已以二進位形式存在時相當有用。

### **將自訂 XML 部分新增至投影片或圖形**

自訂 XML 資料可以關聯至特定投影片或圖形，而非整個簡報。當中繼資料僅描述單一物件（例如範本鍵、外部記錄識別碼或繫結資訊）時，此方式相當有用。

以下範例將一個自訂 XML 部分新增至投影片，另一個新增至圖形：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

加入部件的層級決定哪個物件的 `getCustomData()->getCustomXmlParts()` 集合會包含對該部件的關聯。簡報層級的資料適用於整份文件的中繼資料，投影片層級的資料適用於屬於特定投影片的資訊，而圖形層級的資料則適用於與單一圖形綁定的中繼資料。

### **列舉與稽核所有自訂 XML 部分**

使用 [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getAllCustomXmlParts) 可從簡報中取得所有自訂 XML 部分。每個 [`CustomXmlPart`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/) 都會顯示其識別碼、XML 內容以及關聯的命名空間綱要。

以下範例列出所有自訂 XML 部分以及其命名空間綱要：

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) 會回傳與自訂 XML 部分關聯的 XML 綱要。在稽核包含外部系統產生之 XML 的簡報時，此資訊相當有用。

### **讀取與更新 XML 內容與 ItemId**

使用 [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#getXmlAsString) 與 [`setXmlAsString()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#setXmlAsString) 以 UTF-8 文字字串操作 XML，或使用 [`getXmlData()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#getXmlData) 與 [`setXmlData()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#setXmlData) 以原始 XML 位元組操作。

[`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#getItemId) 方法會回傳在 Office Open XML 文件中識別自訂 XML 部分的 UUID。當整合需要新的識別碼時，請使用 [`setItemId()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#setItemId)。

以下範例更新 XML 內容與識別碼：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // 以文字形式讀取目前的 XML。
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // 以 UTF-8 字串更新 XML。
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData 以原始位元組提供相同的 XML 內容。
    $customXmlData = $customXmlPart->getXmlData();

    // 當整合需求時取代識別碼。
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

呼叫 `setXmlAsString` 或 `setXmlData` 時，請提供有效且非空的 XML。根據應用程式主要使用字串或位元組資料，選擇其中一種表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種移除自訂 XML 資料的方法：

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpart/#remove) 從簡報中移除該自訂 XML 部分。
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpartcollection/#remove) 從自訂 XML 部分集合中移除特定部件。
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpartcollection/#removeAt) 移除集合中指定索引的部件。
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/customxmlpartcollection/#clear) 清除特定集合中的所有部件。

以下範例依參考移除一個簡報層級的自訂 XML 部分：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

如果您已擁有 `CustomXmlPart`，且想直接從簡報中移除該部件（而非針對特定集合），請呼叫 `$customXmlPart->remove()`。

您也可以依索引移除項目：

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **清除集合中的所有自訂 XML 部分**

當需要移除與特定簡報物件關聯的全部自訂 XML 部分時，使用 `clear`。

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` 只作用於所選集合。例如，清除投影片的集合不會影響簡報層級或圖形層級的集合。

若要移除簡報中的所有自訂 XML 部分，可遍歷 `getAllCustomXmlParts()` 並逐一移除每個部件：

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **處理已連結或共用的自訂 XML 部分**

在 Office Open XML 簡報中，同一個自訂 XML 部分可能被多個簡報物件參照。例如，現有檔案可能包含多個投影片或圖形與相同底層自訂 XML 部分之間的關聯。

共用的部件應視為單一資料物件，擁有多個參照：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 更新時，會變更底層的自訂 XML 部分，因此所有參照該部件的地方皆會套用變更。
- `getItemId()` 可用於在稽核物件層級集合時識別相同的自訂 XML 部分。
- 從特定的 `getCustomXmlParts()` 集合中移除部件，只會從該集合中刪除。若要將部件本身從簡報移除，請使用 `CustomXmlPart::remove()`。
- 在刪除或取代共用部件之前，請檢查物件層級的集合，以判斷是否仍有其他投影片或圖形參照它。

`add` 的多載會從 XML 內容建立新的自訂 XML 部分；它們不接受現有的 `CustomXmlPart`。因此，當載入已包含共用關聯的簡報時，最常會遇到共用關係。

以下範例依 `ItemId` 稽核簡報、投影片與圖形層級的集合，並報告被多個位置參照的部件：

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

在修改或刪除外部系統建立的簡報中的自訂 XML 資料之前，執行此類稽核相當有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標記值**

在 Slides 中，標記對應 `DocumentProperties::getKeywords()` 方法。以下範例程式碼示範如何使用 Aspose.Slides for PHP via Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 的標記值：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **將標記新增至簡報**

Aspose.Slides 允許您為簡報新增標記。標記通常包含兩個項目：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

如果需要根據特定規則或屬性對簡報進行分類，可為此目的新增標記。例如，若要將來自北美洲國家的簡報分類，可建立一個北美標記，並將相應的國家設為其值。

以下範例程式碼示範如何使用 Aspose.Slides for PHP via Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 新增標記：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

也可以為 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 設定標記：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

或為個別的 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 設定標記：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **限制**

透過 `getCustomData()->getTags()` 集合新增的標記僅儲存在 PowerPoint 檔案中。當簡報匯出為 PDF 時，它們 **不會** 轉移至 PDF 的標記結構。因此，作為標記指派的自訂識別碼無法從已加標記的 PDF 中取得。

**解決方法**：您可以將自訂識別碼儲存在物件的 **Alt Text** 中（例如 `$shape->setAlternativeText("MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 的標記結構中。

## **常見問題**

**我可以一次移除簡報、投影片或圖形的所有標記嗎？**

可以。 [tag collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/#clear) 操作，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標記？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/) 上使用 [remove(name)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/#remove) 即可依鍵名刪除標記。

**如何取得完整的標記名稱列表，以供分析或篩選使用？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/) 上使用 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tagcollection/#getNamesOfTags)；它會回傳所有標記名稱的陣列。

**如何找出所有自訂 XML 部分，不論它們儲存於何處？**

使用 [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getAllCustomXmlParts) 以取得簡報中所有自訂 XML 部分。

**我應該使用 `getXmlAsString`/`setXmlAsString` 還是 `getXmlData`/`setXmlData` 來更新自訂 XML 部分？**

當應用程式使用 UTF-8 XML 文字時，請使用 `getXmlAsString` 與 `setXmlAsString`。當 XML 已以位元組陣列形式存在，或二進位導向的處理較為便利時，請使用 `getXmlData` 與 `setXmlData`。兩種表示方式皆指向同一自訂 XML 部分的 XML 內容。