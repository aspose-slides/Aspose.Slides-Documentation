---
title: 使用 Python 在簡報中管理標籤和自訂資料
linktitle: 標籤和自訂資料
type: docs
weight: 300
url: /zh-hant/python-net/managing-tags-and-custom-data/
keywords:
- 文件屬性
- 標籤
- 自訂資料
- 自訂 XML
- 自訂 XML 部分
- XML 中繼資料
- ItemId
- 新增標籤
- 鍵值對
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中管理標籤和自訂 XML 資料，包括新增、讀取、更新、稽核和移除自訂 XML 部分。"
---
## **概觀**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標籤和自訂資料。簡報特定的資料可以儲存為標籤或自訂 XML 部分。標籤是簡單的鍵值字串對，而自訂 XML 部分則可儲存結構化的中繼資料與應用程式專屬的 XML 負載。

Aspose.Slides 提供用於在簡報、投影片與圖形層級新增、讀取、更新、稽核與移除自訂 XML 部分的 API。自訂 XML 部分對於整合項目很有用，可在簡報內儲存諸如文件管理識別碼、工作流程狀態、合規性中繼資料、範本繫結資料或其他結構化的應用程式資料。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx` 的檔案）以 PresentationML 格式儲存，該格式屬於 Office Open XML 規範的一部分。Office Open XML 定義了用於儲存簡報內容與相關資料的封裝結構與關聯性。

一個簡報包含多個由關聯連結的部件。例如，投影片部件包含單一投影片的內容，並可依 ISO/IEC 29500 定義與其他部件建立明確的關聯。

自訂資料可以以標籤（[TagCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/)）或自訂 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/customxmlpartcollection/)）儲存。兩者皆可透過 [`CustomData`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/customdata/) 類別取得。

{{% alert color="primary" %}}
標籤儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可與簡報、投影片或圖形關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

`CustomData.custom_xml_parts` 屬性會回傳與特定簡報物件相關聯的自訂 XML 部分集合。例如：

- `presentation.custom_data.custom_xml_parts` 包含與簡報本身相關聯的自訂 XML 部分。
- `slide.custom_data.custom_xml_parts` 包含與特定投影片相關聯的自訂 XML 部分。
- `shape.custom_data.custom_xml_parts` 包含與特定圖形相關聯的自訂 XML 部分。

當需要檢視簡報中所有自訂 XML 部分（不論其關聯位置）時，請使用 `Presentation.all_custom_xml_parts`。

### **新增自訂 XML 部分至簡報**

使用 `CustomXmlPartCollection.add` 可將 XML 資料新增至自訂 XML 部分集合。XML 必須是有效且非空的。

下列範例將結構化的中繼資料新增至簡報層級的自訂資料集合：

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add 會自動指派識別碼。僅在需要時才設定特定的 GUID。
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`add` 方法也可以接受作為位元組陣列或串流的 XML，這在 XML 內容已以二進位形式存在時十分有用。

### **將自訂 XML 部分新增至投影片或圖形**

自訂 XML 資料可與特定投影片或圖形關聯，而非整個簡報。當中繼資料僅描述單一物件（例如範本鍵、外部記錄識別碼或繫結資訊）時，此功能相當有用。

下列範例將一個自訂 XML 部分新增至投影片，另一個新增至圖形：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

新增部件的層級決定了哪個物件的 `custom_data.custom_xml_parts` 集合包含對該部件的關聯。簡報層級資料適用於整份文件的中繼資料，投影片層級資料適用於屬於特定投影片的資訊，圖形層級資料則適用於與單一圖形相關的中繼資料。

### **列出與稽核所有自訂 XML 部分**

使用 `Presentation.all_custom_xml_parts` 可從簡報中取得所有自訂 XML 部分。每個 `CustomXmlPart` 皆會顯示其識別碼、XML 內容以及相關的命名空間結構描述。

下列範例列出所有自訂 XML 部分及其命名空間結構描述：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

`CustomXmlPart.namespace_schemas` 會回傳與自訂 XML 部分相關聯的 XML 結構描述。稽核包含外部系統產生之 XML 的簡報時，此資訊會很有幫助。

### **讀取與更新 XML 內容與 ItemId**

使用 `CustomXmlPart.xml_as_string` 可將 XML 視為 UTF-8 字串處理，或使用 `CustomXmlPart.xml_data` 直接處理原始 XML 位元組。這兩個屬性皆可讀取與更新。

`CustomXmlPart.item_id` 屬性包含在 Office Open XML 文件中識別自訂 XML 部分的 GUID。當整合需要新的識別碼時，也可以變更此屬性。

下列範例更新 XML 內容與識別碼：

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # 以文字形式讀取目前的 XML。
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # 以 UTF-8 字串更新 XML。
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data 以原始位元組形式提供相同的 XML 內容。
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # 當整合需要時置換識別碼。
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

在指定 `xml_as_string` 或 `xml_data` 時，請提供有效且非空的 XML。根據應用程式主要使用字串或位元組資料，選擇其中一種表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種移除自訂 XML 資料的方法：

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/customxmlpart/remove/) 從簡報中移除自訂 XML 部分。
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/customxmlpartcollection/remove/) 從自訂 XML 部分集合中移除特定部件。
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/customxmlpartcollection/remove_at/) 依指定的集合索引移除部件。
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/customxmlpartcollection/clear/) 清除特定集合中的所有部件。

下列範例依參考移除一個簡報層級的自訂 XML 部分：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

如果已擁有 `CustomXmlPart`，且想直接從簡報中移除該部件而非針對特定集合，請呼叫 `custom_xml_part.remove()`。

也可以依索引移除項目：

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **清除集合中的所有自訂 XML 部分**

當需移除與特定簡報物件相關的所有自訂 XML 部分時，請使用 `clear`。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` 只會影響所選取的集合。例如，清除投影片的集合不會清除簡報層級或圖形層級的集合。

若要移除簡報中的所有自訂 XML 部分，可遍歷 `all_custom_xml_parts` 並逐一移除：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **處理連結或共享的自訂 XML 部分**

在 Office Open XML 簡報中，相同的自訂 XML 部分可能被多個簡報物件引用。例如，現有檔案可能包含多個投影片或圖形與同一底層自訂 XML 部分的關聯。

共享的部件應視為具有多重引用的單一資料物件：

- 更新其 `xml_as_string`、`xml_data` 或 `item_id` 會改變底層自訂 XML 部分，因而使所有引用該部件的地方皆同步變更。
- `item_id` 可用於在稽核物件層級集合時識別相同的自訂 XML 部分。
- 從特定 `custom_xml_parts` 集合中移除部件，只會將其從該集合移除。若需將部件本身從簡報中移除，請使用 `CustomXmlPart.remove()`。
- 在刪除或取代共享部件之前，請檢查物件層級的集合，以判斷是否仍有其他投影片或圖形引用該部件。

`add` 的多載會從 XML 內容建立新的自訂 XML 部分；它們不接受已存在的 `CustomXmlPart`。因此，共享關聯最常在載入已包含此類部件的簡報時遇到。

下列範例依 `item_id` 稽核簡報、投影片與圖形層級的集合，並報告被多處引用的部件：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

在修改或刪除外部系統建立的簡報之自訂 XML 資料前，執行此類稽核相當有用，因為同一中繼資料部件可能參與多個關聯。

## **取得標籤的值**

在 Slides 中，標籤對應到 `DocumentProperties.keywords` 屬性。以下範例程式碼示範如何在 Aspose.Slides for Python via .NET 中取得 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 的標籤值：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **將標籤新增至簡報**

Aspose.Slides 允許您將標籤新增至簡報。標籤通常包含兩個項目：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

若需根據特定規則或屬性對簡報進行分類，可為此目的新增標籤。例如，若要將來自北美國家的簡報分類，可建立一個北美標籤，並將相關國家指定為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Python via .NET 為 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 新增標籤：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

標籤也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/)：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

或設定於個別的 [Shape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/)：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **限制**

透過 `custom_data.tags` 集合新增的標籤僅儲存在 PowerPoint 檔案中。當簡報匯出為 PDF 時，這些標籤 **不會** 轉移至 PDF 的標籤結構。因此，作為標籤指定的自訂識別碼無法從已標記的 PDF 中取得。

**解決方法**：可將自訂識別碼存放於物件的 **Alt Text**（例如 `shape.alternative_text = "MyId"`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 的標籤結構中。

## **常見問題**

**我可以一次移除簡報、投影片或圖形中的所有標籤嗎？**

是的。`[tag collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/)` 支援 `[clear](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/clear/)` 操作，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標籤？**

使用 `[remove(name)](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/remove/)` 在 `[TagCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/)` 上依鍵刪除標籤。

**如何取得完整的標籤名稱清單以供分析或過濾？**

在 `[tag collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/)` 上使用 `[get_names_of_tags](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/tagcollection/get_names_of_tags/)`，它會回傳所有標籤名稱的陣列。

**如何找出所有自訂 XML 部分，無論其儲存位置？**

使用 `[Presentation.all_custom_xml_parts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/all_custom_xml_parts/)` 以取得簡報中所有自訂 XML 部分。

**我應該使用 `xml_as_string` 還是 `xml_data` 來更新自訂 XML 部分？**

當應用程式使用 UTF-8 XML 文字時，請使用 `xml_as_string`。當 XML 已以位元組陣列形式存在，或二進位處理較為方便時，請使用 `xml_data`。兩個屬性皆代表同一自訂 XML 部分的內容。