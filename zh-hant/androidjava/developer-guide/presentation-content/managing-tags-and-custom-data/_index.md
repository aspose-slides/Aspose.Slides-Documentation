---
title: 在 Android 上管理簡報中的標籤與自訂資料
linktitle: 標籤與自訂資料
type: docs
weight: 300
url: /zh-hant/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PowerPoint 簡報中管理標籤與自訂 XML 資料，包括新增、讀取、更新、稽核與移除自訂 XML 部分。"
---
## **概觀**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤和自訂資料。簡報特定的資料可以儲存為標籤或自訂 XML 部分。標籤是簡單的鍵值字串對，而自訂 XML 部分則可儲存結構化的中繼資料和應用程式特定的 XML 負載。

Aspose.Slides 提供用於在簡報、投影片和圖形層級加入、讀取、更新、稽核及移除自訂 XML 部分的 API。自訂 XML 部分對於需要在簡報內儲存文件管理識別碼、工作流程狀態、合規中繼資料、範本繫結資料或其他結構化應用程式資料的整合非常有用。

## **簡報檔案中的資料儲存**

PPTX 檔案——副檔名為 `.pptx` 的檔案——以 PresentationML 格式儲存，該格式是 Office Open XML 規範的一部份。Office Open XML 定義了用於儲存簡報內容與相關資料的套件結構與關聯。

一個簡報包含多個由關聯連接的部件。例如，投影片部件包含單一投影片的內容，並可依 ISO/IEC 29500 定義與其他部件建立明確關聯。

自訂資料可以儲存為標籤（[ITagCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITagCollection)）或自訂 XML 部分（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPartCollection)）。兩者皆可透過 [`ICustomData`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomData/) 介面存取。

{{% alert color="primary" %}}
標籤儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可與簡報、投影片或圖形關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

[`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) 方法會傳回特定簡報物件所關聯的自訂 XML 部分集合。例如：

- `presentation.getCustomData().getCustomXmlParts()` 包含與簡報本身關聯的自訂 XML 部分。
- `slide.getCustomData().getCustomXmlParts()` 包含與特定投影片關聯的自訂 XML 部分。
- `shape.getCustomData().getCustomXmlParts()` 包含與特定圖形關聯的自訂 XML 部分。

在需要檢查簡報中所有自訂 XML 部分（不論其關聯位置）時，請使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--)。

### **將自訂 XML 部分加入簡報**

使用 [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) 將 XML 資料加入自訂 XML 部分集合。XML 必須有效且非空。

以下範例將結構化中繼資料加入簡報層級的自訂資料集合：

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

    // add 會自動分配識別碼。僅在需要時才設定特定的 UUID。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`add` 方法也可接受 XML 位元組陣列或輸入串流，這在 XML 已以二進位形式存在時非常有用。

### **將自訂 XML 部分加入投影片或圖形**

自訂 XML 資料可關聯至特定投影片或圖形，而非整個簡報。當中繼資料僅描述單一物件（例如範本金鑰、外部記錄識別碼或繫結資訊）時，這很實用。

以下範例將一個自訂 XML 部分加入投影片，另一個加入圖形：

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

加入部件的層級決定哪個物件的 `getCustomData().getCustomXmlParts()` 集合會包含對該部件的關聯。簡報層級資料適合文件全域的中繼資料，投影片層級資料適合屬於特定投影片的資訊，圖形層級資料適合與單一圖形相關的中繼資料。

### **列出並稽核全部自訂 XML 部分**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) 取得簡報中的所有自訂 XML 部分。每個 [`ICustomXmlPart`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart/) 皆會公開其識別碼、XML 內容以及相關的命名空間結構。

以下範例列出所有自訂 XML 部分及其命名空間結構：

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) 會回傳與自訂 XML 部分關聯的 XML 結構。此資訊在稽核包含外部系統產生 XML 的簡報時相當有用。

### **讀取與更新 XML 內容與 ItemId**

使用 [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) 與 [`setXmlAsString()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) 以 UTF-8 字串操作 XML，或使用 [`getXmlData()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) 與 [`setXmlData()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) 以原始 XML 位元組操作。

[`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) 方法會回傳辨識自訂 XML 部分於 Office Open XML 文件中的 UUID。當整合需要新識別碼時，使用 [`setItemId()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-)。

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

    // 將 XML 更新為 UTF-8 字串。
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData 會以原始位元組提供相同的 XML 內容。
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // 當整合需要時取代識別碼。
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

呼叫 `setXmlAsString` 或 `setXmlData` 時，請提供有效且非空的 XML。依應用程式主要以字串或位元組處理為考量，選擇其一表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種方式移除自訂 XML 資料：

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPart#remove--) 從簡報中移除該自訂 XML 部分。
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) 從自訂 XML 部分集合中移除特定部件。
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) 移除指定索引位置的部件。
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) 移除特定集合中的所有部件。

以下範例依參考移除一個簡報層級的自訂 XML 部分：

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

如果已持有 `ICustomXmlPart`，且想直接從簡報移除該部件，而不是針對特定集合，請呼叫 `customXmlPart.remove()`。

您也可以依索引移除項目：

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **從集合中清除所有自訂 XML 部分**

當需移除與特定簡報物件關聯的全部自訂 XML 部分時，使用 `clear`。

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

`clear` 只影響所選集合。例如，清除投影片的集合不會清除簡報層級或圖形層級的集合。

若要移除簡報中所有自訂 XML 部分，請遍歷 `getAllCustomXmlParts()` 並逐一移除：

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

### **處理連結或共用的自訂 XML 部分**

在 Office Open XML 簡報中，同一自訂 XML 部分可能被多個簡報物件參考。例如，同一檔案可能同時由多個投影片或圖形建立指向相同基礎自訂 XML 部分的關聯。

共用部件應視為具有多個參考的單一資料物件：

- 使用 `setXmlAsString`、`setXmlData` 或 `setItemId` 更新時，會變更基礎的自訂 XML 部分，因而影響所有參考該部件的地方。
- `getItemId()` 可用於在稽核物件層級集合時辨識相同的自訂 XML 部分。
- 從特定 `getCustomXmlParts()` 集合移除部件，只會從該集合中移除。若部件本身需從簡報中移除，請使用 `ICustomXmlPart.remove()`。
- 在刪除或取代共用部件前，請檢查物件層級集合，以確定其他投影片或圖形是否仍參考它。

`add` 重載會從 XML 內容建立新自訂 XML 部分；它們不接受既有 `ICustomXmlPart`。因此，共用關聯最常在載入已包含此類關聯的簡報時出現。

以下範例以 `ItemId` 為基礎稽核簡報、投影片與圖形層級的集合，並報告被多處參考的部件：

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

此類稽核在修改或刪除由外部系統產生的簡報之自訂 XML 資料前十分有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標籤值**

在 Slides 中，標籤對應 `IDocumentProperties.getKeywords()` 方法。以下範例示範如何使用 Aspose.Slides for Android via Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 的標籤值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **為簡報新增標籤**

Aspose.Slides 允許您為簡報新增標籤。標籤通常由兩個項目組成：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

若需依特定規則或屬性對簡報進行分類，可為此目的新增標籤。例如，若要將北美國家的簡報歸類，可建立北美標籤並將相關國家設定為其值。

以下範例示範如何使用 Aspose.Slides for Android via Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 新增標籤：

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

標籤也可以為 [Slide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlide) 設定：

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

或為個別的 [Shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape) 設定：

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

透過 `getCustomData().getTags()` 集合新增的標籤僅儲存在 PowerPoint 檔案中。它們**不會**在將簡報匯出為 PDF 時轉移至 PDF 標籤結構。因此，作為標籤的自訂識別碼無法從已加標籤的 PDF 中取得。

**替代方案**：您可以將自訂識別碼儲存在物件的**替代文字**（例如 `shape.setAlternativeText("MyId")`）中。匯出為 PDF 後，替代文字可能會出現在 PDF 標籤結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或圖形上的所有標籤嗎？**

可以。[tag collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/#clear--) 作業，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**

對 [tag collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/) 使用 [remove(name)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) 以鍵名刪除標籤。

**我要如何取得完整的標籤名稱清單以供分析或過濾？**

使用 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) 於 [tag collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tagcollection/) 取得所有標籤名稱的陣列。

**如何找出所有自訂 XML 部分，不論它們儲存於何處？**

使用 [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) 取得簡報中的全部自訂 XML 部分。

**在更新自訂 XML 部分時，應該使用 `getXmlAsString`/`setXmlAsString` 還是 `getXmlData`/`setXmlData`？**

當應用程式以 UTF-8 XML 文字為主時，使用 `getXmlAsString` 與 `setXmlAsString`。當 XML 已以位元組陣列形式存在，或二進位處理較方便時，使用 `getXmlData` 與 `setXmlData`。兩種表示方式皆指向同一自訂 XML 部分的內容。