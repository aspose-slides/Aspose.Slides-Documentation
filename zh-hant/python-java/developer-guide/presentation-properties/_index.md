---
title: 在 Python 中管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/python-java/presentation-properties/
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
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中精通簡報屬性，並簡化您在 PowerPoint 與 OpenDocument 檔案中的搜尋、品牌化與工作流程。"
---
## **介紹**

Aspose.Slides for Python via Java 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性來讀取和更新簡報的中繼資料，例如作者、標題以及使用者自訂的值。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的實例可由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 取得。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="注意" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用於識別產生輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性儲存描述性資訊於簡報內容旁。它們分為兩類：

- **內建屬性** 包含標準的中繼資料，例如標題、作者與文件統計資訊。
- **自訂屬性** 儲存使用者自訂的名稱/值配對。

Aspose.Slides for Python via Java 提供對兩種類別的存取。在 PowerPoint 中，選取 **檔案 → 資訊 → 屬性 → 詳細屬性** 以檢查文件中繼資料。此對話方塊會將資訊分為 **概要**、**統計**、**內容** 與 **自訂** 等標籤。使用 **自訂** 標籤來管理使用者自訂的屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常同時保護簡報內容與文件屬性。若在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 時使用 `False` 進行加密，文件屬性將保留為公開。此時應用程式可呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `True`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 載入的內容；它不會解密任何資料。如果屬性已被加密，未提供密碼的載入將失敗。若簡報未加密，則會忽略此選項並載入完整簡報。

此範例需要一個已加密且文件屬性保留為公開的簡報。它透過 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 檢查載入模式，然後透過 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 讀取內建屬性：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

在此模式下，幻燈片內容不會被載入。幻燈片、母片、版面配置、形狀、媒體以及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應始終先檢查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="警告" %}}
公開的中繼資料可能會暴露作者姓名、標題、主旨、關鍵字、公司資訊、註解以及自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統明確要求在未提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，若在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 時傳入 `True`，載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法在此僅文件屬性的物件上保存變更，因為公開屬性必須與加密簡報內部的對應資料保持一致。因此，更新必須在使用正確開啟密碼且完整載入簡報的情況下進行。

此範例需要一個具有公開文件屬性的加密 PPTX 簡報以及其開啟密碼。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) 完整載入簡報，更新公開的內建屬性，然後保存結果。接著使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

如果應用程式無法解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 類別透過 getter 方法公開內建中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)、[getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) 以及 [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime)。此範例開啟現有簡報，並將其儲存的中繼資料列印到主控台。值取決於輸入的簡報；某些欄位可能為空。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **修改內建屬性**

要更新內建中繼資料，使用由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 回傳的物件上的 setter 方法。此範例開啟現有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)、[setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)、[setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)、[setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) 與 [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager)，然後使用 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 保存更新後的簡報。已保存的 PPTX 會包含新的中繼資料。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **管理超連結基底**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) 會返回文件層級的相對超連結基底。使用 [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) 可以變更或清除它。這在將簡報及其連結檔案搬移至其他位置時很有用。它與單一超連結的 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) 分離：變更基底不會改寫已存儲的連結位址或改變絕對目的地。

此範例需要一個同時包含相對連結（例如 `target.html`）與絕對連結（例如 `https://example.org/absolute.html`）的簡報。它讀取現有基底，指定新基底位址，然後保存並重新開啟簡報以檢查值。之後以空字串清除基底，並在另一個已保存的檔案中驗證空值。請將範例基底位址取代為您連結檔案的實際位置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

兩個驗證訊息都應該輸出 `True`。清除基底不會影響個別超連結的位址。

相對連結 `target.pptx` 在基底指向 `old` 資料夾時會開啟 `old/target.pptx`。將基底改為 `new` 資料夾、保存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟相同檔案。請在搬移簡報或變更基底前後於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 方法允許您以屬性名稱指定值。此範例建立一個簡報，加入兩個文字值與一個整數版本值（使用 `jpype.JInt` 傳遞 Java 整數），並使用 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 保存簡報。對已存在的名稱賦值會覆寫該屬性的值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取與修改自訂屬性**

此範例開啟包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) 迭代其項目。[getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) 接受從零開始的索引，返回用於 [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 的名稱。範例列印每個原始名稱與值，將所有值以編號字串取代（不論原始類型），並保存變更。若不存在自訂屬性，迴圈將不會產生任何變更。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **即時範例**

嘗試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問答**

**如何從簡報中移除內建屬性？**

內建屬性是簡報不可分割的一部分，無法完全移除。不過，您可以變更其值，或在該屬性允許的情況下將其設定為空。

**如果加入已存在的自訂屬性會發生什麼事？**

若加入已存在的自訂屬性，原有的值會被新值覆寫。您不必事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性值。

**能否在未完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 再搭配 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/python-java/examine-presentation/) 以取得完整的報表範例與格式限制說明。

**能否在未提供開啟密碼的情況下讀取加密簡報的公開屬性？**

可以。前提是簡報在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 並傳入 `False` 後進行加密，且載入時使用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `True`。

**能否在僅文件屬性模式下更新已加密的 PPTX 檔案？**

不能。公開與加密的屬性資料必須保持一致，因此更新已加密的 PPTX 檔案必須使用正確的開啟密碼完整載入簡報。