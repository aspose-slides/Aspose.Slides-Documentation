---
title: 使用 JavaScript 管理簡報中的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/nodejs-java/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 自訂 XML
- 自訂 XML 部分
- XML 中繼資料
- ItemId
- 新增標籤
- 鍵值配對
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中管理標籤與自訂 XML 資料，包括新增、讀取、更新、稽核與移除自訂 XML 部分。"
---
## **概述**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中處理標籤與自訂資料。簡報特定的資料可以儲存為標籤或自訂 XML 部分。標籤是簡單的鍵值字串對，而自訂 XML 部分則可儲存結構化的中繼資料與應用程式專屬的 XML 負載。

Aspose.Slides 提供在簡報、投影片與圖形層級上新增、讀取、更新、稽核與移除自訂 XML 部分的 API。自訂 XML 部分對於需要在簡報中儲存諸如文件管理識別碼、工作流程狀態、合規性中繼資料、範本綁定資料或其他結構化應用程式資料的整合非常有用。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx`）採用 PresentationML 格式儲存，該格式屬於 Office Open XML 規範的一部份。Office Open XML 定義了用於儲存簡報內容及相關資料的套件結構與關聯。

一個簡報由多個部件透過關聯連結組成。例如，投影片部件包含單一投影片的內容，並可依 ISO/IEC 29500 定義與其他部件建立明確的關聯。

自訂資料可以以標籤（[TagCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/)) 或自訂 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpartcollection/)) 儲存。兩者皆可透過 [`CustomData`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customdata/) 類別取得。

{{% alert color="primary" %}}
標籤儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可以與簡報、投影片或圖形相關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

`CustomData`（[`CustomData`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customdata/)）的 `getCustomXmlParts()` 方法會回傳與特定簡報物件相關聯的自訂 XML 部分集合。例如：

- `presentation.getCustomData().getCustomXmlParts()` 包含與簡報本身相關聯的自訂 XML 部分。
- `slide.getCustomData().getCustomXmlParts()` 包含與特定投影片相關聯的自訂 XML 部分。
- `shape.getCustomData().getCustomXmlParts()` 包含與特定圖形相關聯的自訂 XML 部分。

當您需要檢查簡報中所有自訂 XML 部分（無論其關聯於何處）時，可使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)。

### **將自訂 XML 部分新增至簡報**

使用 [`CustomXmlPartCollection`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpartcollection/) 的 `add` 方法將 XML 資料新增至自訂 XML 部分集合。XML 必須是有效且非空的。

以下範例將結構化的中繼資料新增至簡報層級的自訂資料集合：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add 會自動指派一個識別碼。僅在需要時設定特定的 UUID。
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 方法也可接受以位元組陣列形式的 XML，這在 XML 內容已以二進位形式存在時很有用。

### **將自訂 XML 部分新增至投影片或圖形**

自訂 XML 資料可與特定投影片或圖形關聯，而非整個簡報。當中繼資料僅描述單一物件（例如範本金鑰、外部記錄識別碼或綁定資訊）時，此方式非常有用。

以下範例將一個自訂 XML 部分新增至投影片，另一個新增至圖形：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

新增部件的層級決定哪個物件的 `getCustomData().getCustomXmlParts()` 集合包含對該部件的關聯。簡報層級的資料適用於全文件的中繼資料，投影片層級的資料則屬於特定投影片的資訊，圖形層級的資料則與單一圖形的中繼資料相關。

### **列出與稽核所有自訂 XML 部分**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 可從簡報中取得所有自訂 XML 部分。每個 [`CustomXmlPart`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpart/) 會揭露其識別碼、XML 內容以及相關的命名空間結構描述。

以下範例列出所有自訂 XML 部分及其命名空間結構描述：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

`CustomXmlPart.getNamespaceSchemas()` 會返回與自訂 XML 部分相關聯的 XML 結構描述。當稽核包含外部系統產生之 XML 的簡報時，此資訊相當有用。

### **讀取與更新 XML 內容與 ItemId**

使用 [`CustomXmlPart`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpart/) 的 `getXmlAsString()` 與 `setXmlAsString()` 以 UTF-8 字串形式處理 XML，或使用 `getXmlData()` 與 `setXmlData()` 以原始 XML 位元組處理。

`getItemId()` 方法會回傳用於在 Office Open XML 文件中識別自訂 XML 部分的 UUID。當整合需要新識別碼時，請使用 `setItemId()`。

以下範例更新 XML 內容與識別碼：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 將目前的 XML 讀取為文字。
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // 更新 XML 為 UTF-8 字串。
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData 以原始位元組提供相同的 XML 內容。
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // 在整合需要時取代識別碼。
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

呼叫 `setXmlAsString` 或 `setXmlData` 時，請提供有效且非空的 XML。依照應用程式主要使用字串或位元組資料的情況，選擇其中一種表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種方式移除自訂 XML 資料：

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpart/) 從簡報中移除自訂 XML 部分。
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpartcollection/) 從自訂 XML 部分集合中移除特定部件。
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpartcollection/) 移除位於指定集合索引的部件。
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/customxmlpartcollection/) 移除特定集合中的所有部件。

以下範例依參考移除一個簡報層級的自訂 XML 部分：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果您已擁有 `CustomXmlPart`，且希望直接從簡報中移除該部件，而不是針對特定集合，請呼叫 `customXmlPart.remove()`。

您也可以依索引移除項目：

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **清除集合中的所有自訂 XML 部分**

當需要移除與特定簡報物件相關聯的所有自訂 XML 部分時，請使用 `clear`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` 僅影響所選集合。例如，清除投影片的集合不會清除簡報層級或圖形層級的集合。

若要移除簡報中的所有自訂 XML 部分，可遍歷 `getAllCustomXmlParts()` 並逐一移除每個部件：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **處理連結或共用的自訂 XML 部分**

在 Office Open XML 簡報中，同一個自訂 XML 部分可能被多個簡報物件參照。例如，現有檔案可能包含來自多個投影片或圖形指向相同底層自訂 XML 部分的關聯。

共用部件應視為具有多個參照的單一資料物件：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 進行更新會變更底層的自訂 XML 部分，因而在所有引用該部件的地方都會套用此變更。
- `getItemId()` 可於稽核物件層級集合時辨識相同的自訂 XML 部分。
- 從特定的 `getCustomXmlParts()` 集合中移除部件，只會從該集合移除。若需將部件本身從簡報中移除，請使用 `CustomXmlPart.remove()`。
- 在刪除或取代共用部件之前，請檢查物件層級的集合，以判斷其他投影片或圖形是否仍在引用該部件。

`add` 的多載會從 XML 內容建立新的自訂 XML 部分；它們不接受現有的 `CustomXmlPart`。因此，當載入已包含此類關聯的簡報時，最常會遇到共用關聯的情況。

以下範例依照 `ItemId` 稽核簡報、投影片與圖形層級的集合，並報告被多個位置引用的部件：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

在修改或刪除由外部系統建立的簡報中的自訂 XML 資料之前，進行此類稽核非常有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標籤的值**

在 Slides 中，標籤對應到 `DocumentProperties.getKeywords()` 方法。以下範例程式碼示範如何使用 Aspose.Slides for Node.js via Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 的標籤值：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **將標籤新增至簡報**

Aspose.Slides 允許您為簡報新增標籤。標籤通常由兩個項目組成：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

如果您需要根據特定規則或屬性對簡報進行分類，可以為此新增標籤。例如，若想將北美國家的簡報分類，您可以建立一個北美標籤，並將相關的國家名稱設定為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Node.js via Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 新增標籤：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

標籤也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/)：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

或是個別的 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **限制**

透過 `getCustomData().getTags()` 集合新增的標籤僅儲存在 PowerPoint 檔案中。當簡報匯出為 PDF 時，這些標籤 **不會** 轉移至 PDF 標籤結構。因此，作為標籤指派的自訂識別碼無法從已標記的 PDF 中取得。

**解決方法**：您可以將自訂識別碼存放於物件的 **Alt Text**（例如 `shape.setAlternativeText("MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標籤結構中。

## **常見問題**

**我可以一次移除簡報、投影片或圖形的所有標籤嗎？**

可以。[標籤集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/) 操作，可一次刪除所有鍵值對。

**如何僅透過標籤名稱刪除單一標籤，而不必遍歷整個集合？**

使用 [標籤集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/) 的 `remove(name)` 依鍵名刪除該標籤。

**如何取得全部標籤名稱的清單，以供分析或過濾使用？**

在 [標籤集合](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tagcollection/) 上使用 `getNamesOfTags()`，它會返回所有標籤名稱的陣列。

**如何找出所有自訂 XML 部分，不論它們儲存在何處？**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 可取得簡報中所有自訂 XML 部分。

**在更新自訂 XML 部分時，我該使用 `getXmlAsString`/`setXmlAsString` 還是 `getXmlData`/`setXmlData`？**

若應用程式以 UTF-8 XML 文字為主，請使用 `getXmlAsString` 與 `setXmlAsString`。若 XML 已以位元組陣列形式存在，或二進位處理較為方便，則使用 `getXmlData` 與 `setXmlData`。兩種表示方式皆指向同一自訂 XML 部分的 XML 內容。