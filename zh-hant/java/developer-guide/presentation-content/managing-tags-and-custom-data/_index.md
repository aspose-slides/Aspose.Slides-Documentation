---
title: 使用 Java 管理簡報中的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/java/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 自訂 XML
- 自訂 XML 部分
- XML 中繼資料
- ItemId
- 新增標籤
- 配對值
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中管理標籤與自訂 XML 資料，包括新增、讀取、更新、稽核與移除自訂 XML 部分。"
---
## **概述**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中處理標籤與自訂資料。簡報特定的資料可以儲存為標籤或自訂 XML 部分。標籤是簡單的鍵值字串對，而自訂 XML 部分則可儲存結構化的中繼資料與應用程式專屬的 XML 載荷。

Aspose.Slides 提供在簡報、投影片與圖形層級加入、讀取、更新、稽核與移除自訂 XML 部分的 API。自訂 XML 部分適用於需要在簡報內存放文件管理識別碼、工作流程狀態、合規性中繼資料、範本繫結資料或其他結構化應用程式資料的整合情境。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx`）採用 PresentationML 格式，屬於 Office Open XML 規範的一部份。Office Open XML 定義了用於儲存簡報內容與相關資料的套件結構與關聯性。

一個簡報包含多個部件，這些部件透過關聯性相互連結。例如，投影片部件包含單一投影片的內容，並可對其他部件建立 ISO/IEC 29500 定義的明確關聯。

自訂資料可以以標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITagCollection)）或自訂 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection)）儲存。兩者皆可透過 [`ICustomData`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomData/) 介面取得。

{{% alert color="primary" %}}
標籤儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可與簡報、投影片或圖形關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomData#getCustomXmlParts--) 方法會傳回與特定簡報物件關聯的自訂 XML 部分集合。例如：

- `presentation.getCustomData().getCustomXmlParts()` 包含與整個簡報關聯的自訂 XML 部分。
- `slide.getCustomData().getCustomXmlParts()` 包含與特定投影片關聯的自訂 XML 部分。
- `shape.getCustomData().getCustomXmlParts()` 包含與特定圖形關聯的自訂 XML 部分。

當需要檢查簡報中所有自訂 XML 部分（不論關聯到哪裡）時，請使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getAllCustomXmlParts--)。

### **將自訂 XML 部分新增至簡報**

使用 [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) 可將 XML 資料加入自訂 XML 部分集合。XML 必須是有效且非空的。

以下範例將結構化的中繼資料加入簡報層級的自訂資料集合：

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"\">" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add 會自動指派識別碼。只有在需要時才設定特定的 UUID。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 方法也接受 byte 陣列或輸入串流形式的 XML，這在 XML 已以二進位形式存在時很有用。

### **將自訂 XML 部分新增至投影片或圖形**

自訂 XML 資料也可以關聯到特定投影片或圖形，而非整個簡報。這在中繼資料僅描述單一物件（例如範本鍵、外部記錄識別碼或繫結資訊）時特別有用。

以下範例於一張投影片加入一個自訂 XML 部分，並於一個圖形加入另一個：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

加入部件的層級決定哪個物件的 `getCustomData().getCustomXmlParts()` 集合會包含對該部件的關聯。簡報層級的資料適用於整份文件的中繼資料，投影片層級的資料適用於屬於特定投影片的資訊，而圖形層級的資料則適用於綁定到單一圖形的中繼資料。

### **列出並稽核所有自訂 XML 部分**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) 取得簡報中的全部自訂 XML 部分。每個 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart/) 都會曝露其識別碼、XML 內容與相關的命名空間結構描述。

以下範例列出全部自訂 XML 部分及其命名空間結構描述：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) 會回傳與該自訂 XML 部分關聯的 XML 結構描述。此資訊在稽核包含外部系統產生 XML 的簡報時相當有幫助。

### **讀取與更新 XML 內容與 ItemId**

使用 [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) 和 [`setXmlAsString()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) 以 UTF-8 字串方式操作 XML，或使用 [`getXmlData()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getXmlData--) 和 [`setXmlData()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) 以原始位元組方式操作。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getItemId--) 方法會回傳在 Office Open XML 文件中辨識該自訂 XML 部分的 UUID。當整合需要新的識別碼時，可使用 [`setItemId()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-)。

以下範例更新 XML 內容與識別碼：

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 以文字形式讀取當前的 XML。
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // 以 UTF-8 字串更新 XML。
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData 提供相同的 XML 內容，以原始位元組表示。
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 當整合需求時取代識別碼。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

呼叫 `setXmlAsString` 或 `setXmlData` 時，必須提供有效且非空的 XML。根據應用程式主要處理字串或位元組的需求，選擇其中一種表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種方式移除自訂 XML 資料：

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#remove--) 從簡報中移除該自訂 XML 部分。
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) 從自訂 XML 部分集合中移除特定部件。
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) 依集合索引移除部件。
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#clear--) 移除特定集合中的全部部件。

以下範例依參照移除一個簡報層級的自訂 XML 部分：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果已取得 `ICustomXmlPart`，且想直接從簡報中移除該部件，而不是針對特定集合，請呼叫 `customXmlPart.remove()`。

也可以依索引移除項目：

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **一次清除集合中的全部自訂 XML 部分**

當需要移除與特定簡報物件關聯的全部自訂 XML 部分時，使用 `clear`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` 只影響所選集合。例如，清除投影片的集合不會影響簡報層級或圖形層級的集合。

若要移除簡報中的所有自訂 XML 部分，可遍歷 `getAllCustomXmlParts()`，並逐一呼叫 `remove`：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **處理已連結或共用的自訂 XML 部分**

在 Office Open XML 簡報中，同一個自訂 XML 部分可能被多個簡報物件參照。例如，同一檔案可能包含多張投影片或多個圖形指向相同的底層自訂 XML 部分。

對共用部件的處理方式如下：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 進行更新時，會修改底層的自訂 XML 部分，因而在所有參照處皆生效。
- `getItemId()` 可用於在稽核物件層級集合時辨識相同的自訂 XML 部分。
- 從特定 `getCustomXmlParts()` 集合中移除部件，只會將其從該集合中剔除。若要從整個簡報中移除部件本身，請使用 `ICustomXmlPart.remove()`。
- 在刪除或取代共用部件之前，請先檢查物件層級的集合，以確認是否仍有其他投影片或圖形參照該部件。

`add` 的多載會根據 XML 內容建立新自訂 XML 部分，並不接受已存在的 `ICustomXmlPart`。因此，當載入已包含共用部件的簡報時最常會遇到此情況。

以下範例以 `ItemId` 為基礎稽核簡報、投影片與圖形層級的集合，並回報被多處參照的部件：

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

此類稽核在修改或刪除外部系統產生的簡報之自訂 XML 資料之前非常有用，因為同一個中繼資料部件可能參與多個關聯。

## **取得標籤的值**

在 Slides 中，標籤對應到 `IDocumentProperties.getKeywords()` 方法。以下範例示範如何使用 Aspose.Slides for Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 的標籤值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **將標籤新增至簡報**

Aspose.Slides 允許將標籤新增至簡報。標籤通常由兩個項目組成：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

若需要依特定規則或屬性對簡報進行分類，可為此目的新增標籤。例如，若要將來自北美國家的簡報分類，可建立「North American」標籤，並將相關國家設定為其值。

以下範例示範如何使用 Aspose.Slides for Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 新增標籤：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

也可以為 [Slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 設定標籤：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

或為單一 [Shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape) 設定標籤：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **限制**

透過 `getCustomData().getTags()` 集合新增的標籤僅儲存在 PowerPoint 檔案中。匯出為 PDF 時，這些標籤 **不會** 轉移至 PDF 的標籤結構。因此，作為標籤的自訂識別碼無法在已標記的 PDF 中取得。

**解決方法**：可以將自訂識別碼儲存在物件的 **Alt Text**（例如 `shape.setAlternativeText("MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標籤結構中。

## **常見問題**

**是否可以一次移除簡報、投影片或圖形上所有標籤？**

可以。[tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#clear--) 作業，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 上使用 [remove(name)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 可依鍵名刪除標籤。

**如何取得全部標籤名稱以供分析或篩選？**

使用 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#getNamesOfTags--) 可在 [tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 上取得所有標籤名稱的陣列。

**如何找出所有自訂 XML 部分，不論它們儲存在何處？**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) 取得簡報中所有自訂 XML 部分。

**我應該使用 `getXmlAsString`/`setXmlAsString` 還是 `getXmlData`/`setXmlData` 來更新自訂 XML 部分？**

當應用程式以 UTF-8 XML 文字為主時，使用 `getXmlAsString` 與 `setXmlAsString`。當 XML 已以 byte 陣列形式存在，或二進位處理較為方便時，使用 `getXmlData` 與 `setXmlData`。兩種表示方式皆指向同一自訂 XML 部分的內容。