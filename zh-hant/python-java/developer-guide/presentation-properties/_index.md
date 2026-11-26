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
description: "在 Aspose.Slides for Python via Java 中精通簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜索、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for Python via Java 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性可讀取和更新簡報的中繼資料，例如作者、標題和使用者自訂值。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 類別來操作簡報文件屬性。此類別的實例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 回傳。以下範例示範如何讀取、修改和管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式和製作者的中繼資料；這些欄位用於識別產生輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標準中繼資料，例如標題、作者和文件統計資訊。
- **自訂屬性** 儲存使用者定義的名稱/值配對。

Aspose.Slides for Python via Java 提供對兩種類別的存取。在 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢查文件中繼資料。對話框將資訊分為 **Summary**、**Statistics**、**Contents** 與 **Custom** 等索引標籤。使用 **Custom** 索引標籤管理使用者自訂屬性。

## **從加密簡報讀取公共屬性**

通常會使用開啟密碼同時保護簡報內容與文件屬性。當在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 並傳入 `False` 後加密簡報時，其文件屬性仍保持為公共。此時應用程式可呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `True`，在不提供開啟密碼的情況下讀取公共中繼資料。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 載入的內容；它不會執行解密。如果屬性已包含在加密中，未提供密碼載入將失敗。若簡報未加密，則此選項會被忽略，並載入完整簡報。

此範例需要一個已加密且文件屬性仍為公共的簡報。它透過 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 驗證載入模式，然後透過 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 讀取內建屬性：

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

在此模式下，幻燈片內容不會被載入。幻燈片、母片、版面配置、形狀、媒體及其他簡報物件皆不可使用。應用程式在執行需要完整簡報物件模型的操作前，應先檢查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公共中繼資料可能會洩漏作者名稱、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在未提供密碼的情況下存取時，才將其保留為公共。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，若在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `True` 後載入簡報，則僅用於讀取公共中繼資料。Aspose.Slides 無法從僅含中繼資料的物件儲存變更的屬性，因為公共屬性必須與加密簡報內的相應資料保持一致。因此，更新這些屬性需要正確的開啟密碼並完整載入簡報。

此範例需要一個具有公共文件屬性且已知開啟密碼的加密 PPTX 簡報。它以 [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) 開啟完整簡報，更新公共內建屬性，並儲存結果。接著使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) 來驗證加密仍然保持，並在不提供密碼的情況下重新開啟公共中繼資料，以驗證新值：

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

如果應用程式不被允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公共屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) 類別透過 getter 方法公開內建中繼資料，包括 [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)、[getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) 與 [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime)。此範例開啟現有簡報，並將其儲存的中繼資料輸出至主控台。值取決於輸入的簡報；某些欄位可能為空。

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

### **回報版本號與編輯時間**

為了對 `presentations` 資料夾中的每個 PPTX 檔案報告一列，使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 與 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取其 [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/)，而不載入幻燈片以供編輯。Python via Java API 以毫秒回傳編輯持續時間。範例將其格式化為小時、分鐘與秒，對於超過 24 小時的持續時間則同時顯示天數。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

對於編輯時間記錄為 1 天 2 小時 5 分鐘的簡報，報告會顯示以下輸出。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) 讀取一個值，應用程式可使用 [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber) 變更。僅有版本號無法判斷簡報儲存了多少次或重建其版本歷史。

[getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) 讀取檔案中記錄的編輯持續時間。值為 `00:00:00` 表示儲存的持續時間為零，即使有人編輯過簡報。

## **修改內建屬性**

若要更新內建中繼資料，請使用由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) 回傳之物件的設定方法。此範例開啟現有簡報，呼叫 [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)、[setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)、[setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)、[setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) 與 [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager)，然後以 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 儲存更新後的簡報。儲存的 PPTX 內含新中繼資料。

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

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) 會回傳相對超連結的文件層級基底。使用 [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) 可變更或清除它。當將簡報及其連結檔案移動到其他位置時，此功能相當有用。它與個別超連結的 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) 是分開的：變更基底不會重新寫入已儲存的連結位址或改變絕對目的地。

此範例需要一個同時包含相對連結（例如 `target.html`）與絕對連結（例如 `https://example.org/absolute.html`）的簡報。它讀取現有基底，指派新的基底位址，並儲存後重新開啟簡報以檢查該值。接著以空字串清除基底，並在另一個已儲存的檔案中驗證空值。請將範例基底位址替換為您連結檔案的實際位置。

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

兩個驗證訊息應印出 `True`。清除基底不會影響個別超連結的位址。

當基底指向 `old` 資料夾時，指向 `target.pptx` 的相對連結會開啟 `old/target.pptx`。將基底更改為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟相同檔案。在移動簡報或變更基底前後，請於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 方法允許您依屬性名稱指派值。此範例建立簡報，加入兩個文字值與一個整數版本值（使用 `jpype.JInt` 傳遞 Java 整數），並以 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 儲存簡報。對已有名稱指派值會取代該屬性的值。

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

此範例開啟包含自訂屬性的簡報，並使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) 來遍歷它們。[getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) 接受從零開始的索引，並回傳 [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) 使用的名稱。範例列印每個原始名稱與值，將所有值以編號字串取代（不論原始類型），並儲存變更。若無自訂屬性，迴圈將不會產生任何變更。

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

試試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata)，了解如何使用 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的整體組成，無法完全移除。但您可以變更其值，或在特定屬性允許的情況下將其設定為空。

**如果我加入已存在的自訂屬性，會發生什麼情況？**

若加入已存在的自訂屬性，其原有值會被新值覆寫。您不需要事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**我能在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 然後 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 讀取儲存的文件中繼資料，而不必建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 實例。請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/python-java/examine-presentation/) 取得完整的報告範例與格式特定限制。

**我能在不提供開啟密碼的情況下讀取加密簡報的公共屬性嗎？**

可以。簡報必須在呼叫 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 並傳入 `False` 後加密，且在呼叫 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 並傳入 `True` 後載入。

**我能在僅載入文件屬性模式下更新加密的 PPTX 檔案嗎？**

不能。公共屬性與加密屬性資料必須保持一致，因此更新加密的 PPTX 檔案需要以正確的開啟密碼完整載入簡報。