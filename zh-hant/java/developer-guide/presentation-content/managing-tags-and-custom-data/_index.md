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
- 成對值
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中管理標籤與自訂 XML 資料，包括新增、讀取、更新、稽核與移除自訂 XML 部分。"
---
## **概觀**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤和自訂資料。簡報特定的資料可以儲存為標籤或自訂 XML 部分。標籤是簡單的鍵值字串對，而自訂 XML 部分則可以儲存結構化的中繼資料和應用程式特定的 XML 載荷。

Aspose.Slides 提供 API 以在簡報、投影片和形狀層級新增、讀取、更新、稽核與移除自訂 XML 部分。自訂 XML 部分在整合時非常有用，可儲存例如文件管理辨識碼、工作流程狀態、合規性中繼資料、範本繫結資料或其他結構化的應用程式資料於簡報內。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx` 的檔案）以 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部份。Office Open XML 定義了用於儲存簡報內容與相關資料的封裝結構與關聯性。

簡報包含多個由關聯連結的部件。例如，投影片部件包含單一投影片的內容，且可以依 ISO/IEC 29500 定義與其他部件建立明確的關聯。

自訂資料可以儲存為標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ITagCollection)）或自訂 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection)）。兩者皆可透過 [`ICustomData`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomData/) 介面取得。

{{% alert color="info" %}}
標籤儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可與簡報、投影片或形狀關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomData#getCustomXmlParts--) 方法傳回與特定簡報物件關聯的自訂 XML 部分集合。例如：

- `presentation.getCustomData().getCustomXmlParts()` 包含與簡報本身關聯的自訂 XML 部分。
- `slide.getCustomData().getCustomXmlParts()` 包含與特定投影片關聯的自訂 XML 部分。
- `shape.getCustomData().getCustomXmlParts()` 包含與特定形狀關聯的自訂 XML 部分。

當您需要檢查簡報中所有自訂 XML 部分（無論其關聯於何處）時，使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getAllCustomXmlParts--)。

### **將自訂 XML 部分新增至簡報**

使用 [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) 可將 XML 資料新增至自訂 XML 部分集合。XML 必須是有效且非空的。

以下範例將結構化中繼資料新增至簡報層級的自訂資料集合：

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // 新增會自動指派識別碼。僅在需要時才設定特定的 UUID。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 方法也可接受 XML 的位元組陣列或輸入串流，這在 XML 內容已以二進位形式存在時很有用。

### **將自訂 XML 部分新增至投影片或形狀**

自訂 XML 資料可以關聯至特定投影片或形狀，而非整個簡報。當中繼資料僅描述單一物件（例如範本鍵、外部記錄辨識碼或繫結資訊）時，此方式很有用。

以下範例將一個自訂 XML 部分新增至投影片，另一個新增至形狀：

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

部件被新增的層級決定了哪個物件的 `getCustomData().getCustomXmlParts()` 集合會包含與該部件的關聯。簡報層級的資料適用於整個文件的中繼資料，投影片層級的資料適用於屬於特定投影片的資訊，形狀層級的資料則適用於與單一形狀綁定的中繼資料。

### **列出並稽核所有自訂 XML 部分**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) 可從簡報中取得所有自訂 XML 部分。每個 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart/) 皆會公開其識別碼、XML 內容以及相關的命名空間綱要。

以下範例列出所有自訂 XML 部分及其命名空間綱要：

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) 會傳回與該自訂 XML 部分關聯的 XML 綱要。此資訊在稽核包含外部系統產生之 XML 的簡報時相當有用。

### **讀取與更新 XML 內容及 ItemId**

使用 [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) 與 [`setXmlAsString()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) 以 UTF-8 文字字串處理 XML，或使用 [`getXmlData()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getXmlData--) 與 [`setXmlData()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) 以原始 XML 位元組處理。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#getItemId--) 方法傳回在 Office Open XML 文件中識別自訂 XML 部分的 UUID。當整合需要新辨識碼時，使用 [`setItemId()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-)。

以下範例更新 XML 內容與識別碼：

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // 讀取目前的 XML 為文字。
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // 以 UTF-8 字串更新 XML。
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData 提供相同的 XML 內容作為原始位元組。
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 在整合需要時取代識別碼。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

呼叫 `setXmlAsString` 或 `setXmlData` 時，請提供有效且非空的 XML。根據應用程式主要以字串或位元組資料處理，選擇其中一種表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種方式移除自訂 XML 資料：

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPart#remove--) 從簡報中移除自訂 XML 部分。
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) 從自訂 XML 部分集合中移除特定部件。
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) 移除位於指定集合索引的部件。
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ICustomXmlPartCollection#clear--) 移除特定集合中的所有部件。

以下範例以參照方式移除一個簡報層級的自訂 XML 部分：

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

如果您已擁有 `ICustomXmlPart`，且想直接從簡報中移除該部件，而不是針對特定集合，請呼叫 `customXmlPart.remove()`。

您也可以依索引移除項目：

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **清除集合中的所有自訂 XML 部分**

當需要移除與特定簡報物件關聯的所有自訂 XML 部分時，使用 `clear`。

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

`clear` 只會影響所選的集合。例如，清除投影片的集合不會清除簡報層級或形狀層級的集合。

若要移除簡報中的所有自訂 XML 部分，遍歷 `getAllCustomXmlParts()` 並移除每個部件：

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

### **處理連結或共享的自訂 XML 部分**

在 Office Open XML 簡報中，同一個自訂 XML 部分可以被多個簡報物件參照。例如，現有檔案可能包含多個投影片或形狀與同一底層自訂 XML 部分的關聯。

共享的部件應視為具多個參照的單一資料物件：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 進行更新會變更底層的自訂 XML 部分，因而在所有引用該部件的地方皆會反映變更。
- 在稽核物件層級集合時，可使用 `getItemId()` 來辨識相同的自訂 XML 部分。
- 從特定的 `getCustomXmlParts()` 集合中移除部件，只會從該集合中移除。若需將部件本身從簡報中移除，請使用 `ICustomXmlPart.remove()`。
- 在刪除或取代共享部件之前，先檢查物件層級的集合，以判斷是否仍有其他投影片或形狀參照它。

`add` 的多載會從 XML 內容建立新的自訂 XML 部分；它們不接受既有的 `ICustomXmlPart`。因此，共享關聯最常在載入已包含此類關聯的簡報時出現。

以下範例依 `ItemId` 稽核簡報、投影片與形狀層級的集合，並報告被多處參照的部件：

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

此類稽核在修改或刪除由外部系統建立的簡報內自訂 XML 資料之前相當有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標籤的值**

在 Slides 中，標籤對應到 `IDocumentProperties.getKeywords()` 方法。以下範例程式碼示範如何使用 Aspose.Slides for Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 的標籤值：

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

Aspose.Slides 允許您為簡報新增標籤。標籤通常由兩個項目組成：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

如果需要根據特定規則或屬性對簡報進行分類，您可以為此新增標籤。例如，若要將來自北美國家的簡報分類，您可以建立北美標籤，並將相應的國家指定為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 新增標籤：

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

標籤也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide)：

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

或是單一的 [Shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)：

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

透過 `getCustomData().getTags()` 集合新增的標籤僅儲存在 PowerPoint 檔案中。當簡報匯出為 PDF 時，這些標籤 **不會** 轉移到 PDF 的標籤結構。因此，作為標籤指定的自訂辨識碼無法從已標記的 PDF 中取得。

**解決方法**：您可以將自訂辨識碼存放於物件的 **Alt Text**（例如 `shape.setAlternativeText("MyId")`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 的標籤結構中。

## **常見問題集**

**我可以一次性移除簡報、投影片或形狀的所有標籤嗎？**

是的。[tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#clear--) 作業，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**

使用 [remove(name)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 在 [tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 上，以鍵名刪除該標籤。

**如何取得完整的標籤名稱清單以供分析或篩選？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/) 上使用 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tagcollection/#getNamesOfTags--)；它會回傳所有標籤名稱的陣列。

**如何找出所有自訂 XML 部分，無論它們儲存於何處？**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) 取得簡報中的所有自訂 XML 部分。

**在更新自訂 XML 部分時，我該使用 `getXmlAsString`/`setXmlAsString` 還是 `getXmlData`/`setXmlData`？**

當應用程式處理 UTF-8 XML 文字時，使用 `getXmlAsString` 與 `setXmlAsString`。當 XML 已以位元組陣列形式存在，或二進位導向的處理較為方便時，使用 `getXmlData` 與 `setXmlData`。兩種表示方式皆指向同一自訂 XML 部分的 XML 內容。