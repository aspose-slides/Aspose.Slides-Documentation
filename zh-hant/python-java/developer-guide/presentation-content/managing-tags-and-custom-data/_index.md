---
title: 使用 Python 在簡報中管理標記與自訂資料
linktitle: 標記與自訂資料
type: docs
weight: 300
url: /zh-hant/python-java/managing-tags-and-custom-data/
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
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中管理標記與自訂 XML 資料，包括新增、讀取、更新、稽核及移除自訂 XML 部分。"
---
## **概述**

本文說明 Aspose.Slides 如何在 PowerPoint 簡報中使用標記和自訂資料。簡報特定資料可以儲存為標記或自訂 XML 部分。標記是簡單的鍵值字串對，而自訂 XML 部分則可儲存結構化的中繼資料和應用程式特定的 XML 負載。

Aspose.Slides 提供在簡報、投影片與圖形層級上新增、讀取、更新、稽核與移除自訂 XML 部分的 API。自訂 XML 部分對於儲存文件管理識別碼、工作流程狀態、合規性中繼資料、範本繫結資料，或簡報內其他結構化應用程式資料的整合非常有用。

## **簡報檔案中的資料儲存**

PPTX 檔案（副檔名為 `.pptx` 的檔案）採用 PresentationML 格式儲存，該格式屬於 Office Open XML 規範的一部分。Office Open XML 定義了用於儲存簡報內容與相關資料的套件結構與關聯性。

一個簡報包含多個透過關聯連結的部件。例如，投影片部件包含單一投影片的內容，並可依 ISO/IEC 29500 定義與其他部件建立明確的關聯。

自訂資料可以儲存為標記（[TagCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tagcollection/)）或自訂 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/)）。兩者皆可透過 [CustomData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/) 類別取得。

{{% alert color="info" title="Note" %}}
標記儲存簡單的字串鍵值對。自訂 XML 部分儲存結構化的 XML 資料，且可與簡報、投影片或圖形關聯。
{{% /alert %}}

## **使用自訂 XML 部分**

[CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/#getCustomXmlParts) 方法會傳回與特定簡報物件相關聯的自訂 XML 部分集合。例如：

- 簡報的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含與簡報本身相關聯的自訂 XML 部分。
- 投影片的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含與特定投影片相關聯的自訂 XML 部分。
- 圖形的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含與特定圖形相關聯的自訂 XML 部分。

當您需要檢查簡報中所有自訂 XML 部分（不論它們與何物關聯）時，請使用 [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAllCustomXmlParts)。

### **將自訂 XML 部分新增至簡報**

使用 [CustomXmlPartCollection.add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/#add) 將 XML 資料新增至自訂 XML 部分集合。XML 必須有效且非空。

以下範例將結構化中繼資料新增至簡報層級的自訂資料集合：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add 會自動指派識別碼。僅在需要時設定特定的 UUID。
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/#add) 方法也可接受以位元組陣列或輸入串流形式的 XML，當 XML 內容已以二進位形式存在時非常有用。

### **將自訂 XML 部分新增至投影片或圖形**

自訂 XML 資料可以與特定投影片或圖形關聯，而非整個簡報。當中繼資料僅描述單一物件（例如範本金鑰、外部記錄識別碼或繫結資訊）時，此方式相當有用。

以下範例將一個自訂 XML 部分新增至投影片，另一個新增至圖形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

新增部件的層級決定哪個物件的 [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合包含該部件的關聯。簡報層級的資料適用於整份文件的中繼資料，投影片層級的資料適用於屬於特定投影片的資訊，圖形層級的資料則適用於與單一圖形相關聯的中繼資料。

### **列出與稽核所有自訂 XML 部分**

使用 [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAllCustomXmlParts) 從簡報中取得所有自訂 XML 部分。每個 [CustomXmlPart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/) 皆會公開其識別碼、XML 內容與相關的命名空間綱要。

以下範例列出所有自訂 XML 部分及其命名空間綱要：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) 會回傳與自訂 XML 部分關聯的 XML 綱要。此資訊在稽核包含外部系統產生之 XML 的簡報時相當有用。

### **讀取與更新 XML 內容與 ItemId**

使用 [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#getXmlAsString) 與 [setXmlAsString](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlAsString) 以 UTF-8 字串方式操作 XML，或使用 [getXmlData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#getXmlData) 與 [setXmlData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlData) 以原始 XML 位元組方式操作。

[CustomXmlPart.getItemId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#getItemId) 方法會回傳在 Office Open XML 文件中識別自訂 XML 部分的 UUID。當整合需要新識別碼時，請使用 [setItemId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setItemId)。

以下範例更新 XML 內容與識別碼：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # 讀取目前的 XML 為文字。
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # 更新 XML 為 UTF-8 字串。
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData 以原始位元組提供相同的 XML 內容。
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # 當整合需要時取代識別碼。
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

呼叫 [setXmlAsString](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlAsString) 或 [setXmlData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlData) 時，請提供有效且非空的 XML。根據應用程式主要使用字串或位元組資料，選擇其中一種表示方式。

### **移除自訂 XML 部分**

Aspose.Slides 提供多種移除自訂 XML 資料的方法：

- [CustomXmlPart.remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#remove) 會從簡報中移除該自訂 XML 部分。
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/#remove) 會從自訂 XML 部分集合中移除特定部件。
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/#removeAt) 會移除集合中指定索引位置的部件。
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/#clear) 會清除特定集合中的全部部件。

以下範例依參照移除一個簡報層級的自訂 XML 部分：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果您已經擁有 [CustomXmlPart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/) 並想要直接從簡報中移除該部件，而不是針對特定集合操作，請呼叫 [CustomXmlPart.remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#remove)。

您也可以依索引移除項目：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **清除集合中的所有自訂 XML 部分**

當需要移除與特定簡報物件相關的全部自訂 XML 部分時，請使用 [clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/#clear)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear] 只會影響所選取的集合。例如，清除投影片的集合不會清除簡報層級或圖形層級的集合。

若要移除簡報中所有自訂 XML 部分，可遍歷 [getAllCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAllCustomXmlParts) 並逐一移除：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **處理連結或共享的自訂 XML 部分**

在 Office Open XML 簡報中，同一個自訂 XML 部分可以被多個簡報物件參照。例如，現有檔案可能包含多個投影片或圖形與同一底層自訂 XML 部分之間的關聯。

共享的部件應視為單一資料物件，具有多個參照：

- 使用 [setXmlAsString](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlAsString)、[setXmlData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlData) 或 [setItemId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setItemId) 更新它，會變更底層的自訂 XML 部分，因此變更會套用到所有參照該部件的地方。
- [getItemId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#getItemId) 可用於在稽核物件層級集合時識別相同的自訂 XML 部分。
- 從特定的 [getCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/#getCustomXmlParts) 集合中移除部件，只會將它從該集合移除。若需將部件本身從簡報中移除，請使用 [CustomXmlPart.remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#remove)。
- 在刪除或取代共享部件之前，請檢查物件層級的集合，以判斷是否仍有其他投影片或圖形參照該部件。

[add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpartcollection/#add) 的重載會從 XML 內容建立全新的自訂 XML 部分；它們不接受現有的 [CustomXmlPart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/)。因此，當載入已包含這類關聯的簡報時，最常會遇到共享關係。

以下範例依 `ItemId` 稽核簡報、投影片與圖形層級的集合，並報告被多個位置參照的部件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

在修改或刪除外部系統製作的簡報中的自訂 XML 資料之前，進行此類稽核相當有用，因為相同的中繼資料部件可能參與多個關聯。

## **取得標記的值**

在 Slides 中，標記對應到 [DocumentProperties.getKeywords](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#getKeywords) 方法。以下範例程式碼示範如何使用 Aspose.Slides for Python via Java 取得 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 的標記值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **將標記新增至簡報**

Aspose.Slides 允許您為簡報新增標記。標記通常由兩個項目組成：

- 自訂屬性的名稱，例如 `MyTag`；
- 自訂屬性的值，例如 `My Tag Value`。

如果需要根據特定規則或屬性對簡報進行分類，您可以為此新增標記。例如，若要將北美國家的簡報分類，您可以建立一個北美標記，並將相關國家設定為其值。

以下範例程式碼示範如何使用 Aspose.Slides for Python via Java 為 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 新增標記：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

標記也可以設定於 [Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

或設定於個別的 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **限制**

透過 [CustomData.getTags](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customdata/#getTags) 集合新增的標記僅儲存在 PowerPoint 檔案中。當簡報匯出為 PDF 時，這些標記 **不會** 轉移至 PDF 標記結構。因此，作為標記指派的自訂識別碼無法從已標記的 PDF 中取得。

**解決方法**：您可以將自訂識別碼儲存在物件的 **Alt Text**（例如，使用 [Shape.setAlternativeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setAlternativeText) 並設定值為 `"MyId"`）。匯出為 PDF 後，Alt Text 可能會出現在 PDF 標記結構中。

## **常見問題**

**我可以一次性移除簡報、投影片或圖形的所有標記嗎？**

可以。[tag collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tagcollection/) 支援 [clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tagcollection/#clear) 操作，可一次刪除所有鍵值對。

**如何在不遍歷整個集合的情況下，依名稱刪除單一標記？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tagcollection/) 上使用 [remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tagcollection/#remove) 即可依鍵名稱刪除標記。

**如何取得完整的標記名稱清單以用於分析或過濾？**

在 [tag collection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tagcollection/) 上使用 [getNamesOfTags](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tagcollection/#getNamesOfTags)；它會回傳所有標記名稱的陣列。

**如何找出所有自訂 XML 部分，不論它們儲存於何處？**

使用 [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getAllCustomXmlParts) 取得簡報中所有的自訂 XML 部分。

**我應該使用 [getXmlAsString]/[setXmlAsString] 還是 [getXmlData]/[setXmlData] 來更新自訂 XML 部分？**

當應用程式使用 UTF-8 XML 文字時，請使用 [getXmlAsString](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#getXmlAsString) 與 [setXmlAsString](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlAsString)。如果 XML 已以位元組陣列形式存在，或二進位處理較為方便，則使用 [getXmlData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#getXmlData) 與 [setXmlData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/customxmlpart/#setXmlData)。這兩種表示方式皆指向相同自訂 XML 部分的 XML 內容。