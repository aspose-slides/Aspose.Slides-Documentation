---
title: 使用 Python 管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/python-net/presentation-properties/
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
description: "在 Aspose.Slides for Python via .NET 中精通簡報屬性，並在您的 PowerPoint 檔案中簡化搜尋、品牌化與工作流程。"
---
## **介紹**

Aspose.Slides for Python via .NET 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性可讀取與更新簡報的中繼資料，例如作者、標題以及使用者自訂的值。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的實例由 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 取得。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="注意" %}}

Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位會標示產生輸出的軟體。

{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述資訊。它們分為兩類：

- **內建屬性** 包含標題、作者與文件統計等標準中繼資料。
- **自訂屬性** 儲存使用者自行定義的名稱/值配對。

Aspose.Slides for Python via .NET 同時提供存取這兩類屬性。在 PowerPoint 中，選取 **檔案 → 資訊 → 屬性 → 進階屬性** 以檢視文件中繼資料。對話框會將資訊分為 **摘要**、**統計**、**內容** 與 **自訂** 等分頁。使用 **自訂** 分頁管理使用者定義的屬性。

## **從加密簡報中讀取公開屬性**

開啟密碼通常同時保護簡報內容與文件屬性。當簡報使用 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 並將參數設為 `False` 時，其文件屬性會保持公開。此時應用程式可以將 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 設為 `True`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 控制 Aspose.Slides 載入的內容；它不會進行任何解密。如果屬性已被包含在加密中，未提供密碼的載入將失敗。若簡報未加密，則此選項會被忽略，完整簡報會被載入。

以下範例需要一個文件屬性保持公開的加密簡報。它透過 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) 驗證載入模式，然後透過 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 讀取內建屬性：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

在此模式下，不會載入投影片內容。投影片、母片、版面配置、圖形、媒體及其他簡報物件皆不可用。應用程式在執行任何需要完整簡報物件模型的操作前，務必先檢查 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)。

{{% alert color="warning" title="安全性" %}}
公開的中繼資料可能會暴露作者名稱、標題、主旨、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統必須在不使用密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，使用 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 載入的簡報僅用於讀取公開中繼資料。Aspose.Slides 無法從僅含文件屬性的物件儲存變更，因為公開屬性必須與加密簡報內對應的資料保持一致。因此，更新這些屬性必須提供正確的開啟密碼並完整載入簡報。

以下範例需要一個文件屬性為公開的加密 PPTX 簡報以及其開啟密碼。它使用 [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) 完整載入簡報，更新公開的內建屬性，並儲存結果。接著使用 [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) 驗證加密仍然存在，並在不提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

如果應用程式不允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 類別透過型別化屬性公開內建中繼資料，包括 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) 與 [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/)。此範例開啟現有簡報並將其儲存的中繼資料列印到主控台。值取決於輸入的簡報；某些欄位可能為空。

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

### **報告修訂號與編輯時間**

若要對 `presentations` 資料夾中的每個 PPTX 檔案報告修訂號與總編輯時間，可使用 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) 取得其 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/)，而不必載入投影片供編輯。Python 會以 `timedelta` 顯示持續時間，當記錄時間超過 24 小時時會包含天數。

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

對於一個記錄了 1 天 2 小時 5 分鐘編輯時間的簡報，報告會包含以下列：

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) 為可寫入的中繼資料。僅憑此值無法判斷簡報被儲存了多少次，也無法重建其版本歷史。

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) 回報檔案中儲存的編輯持續時間。值為 `0:00:00` 表示記錄的持續時間為零，即使有人編輯過簡報。

## **修改內建屬性**

若要更新內建中繼資料，請對由 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 暴露的可寫屬性賦值。此範例開啟現有簡報，設定 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、[DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/)、[DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/)、以及 [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/)，然後以 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **管理超連結基礎 URL**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) 儲存文件層級的相對超連結基礎 URL。這在將簡報及其鏈接檔案移至其他位置時非常有用。它與個別超連結的 [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) 分離：更改基礎 URL 不會改寫已儲存的鏈接位址或變更絕對目的地。

此範例需要一個同時包含相對鏈接（例如 `target.html`）與指向檔案或網站的絕對鏈接的簡報。它讀取現有基礎 URL，指派新基礎位址，然後儲存並重新開啟簡報以檢查值。接著以 `""` 清除基礎，並在另一個儲存檔案中驗證空值。請將範例基礎位址替換為您鏈接檔案的實際位置。

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

兩個驗證訊息應皆列印 `True`。清除基礎不會影響個別超連結的位址。

相對鏈接 `target.pptx` 在基礎指向 `old` 資料夾時會開啟 `old/target.pptx`。將基礎改為 `new` 資料夾、儲存並重新開啟簡報後，同一鏈接會開啟 `new/target.pptx`。絕對鏈接則仍會開啟相同檔案。請在 PowerPoint 中測試相對鏈接於移動簡報或變更基礎前後的行為。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 方法允許您以屬性名稱指定值。此範例建立簡報，新增兩個文字值與一個整數版本值，並以 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 儲存簡報。對已存在的名稱賦值會取代該屬性的值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **存取與修改自訂屬性**

此範例開啟包含自訂屬性的簡報，使用 [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) 迭代所有屬性。[DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) 接受零基索引並回傳用於 [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 的名稱。此範例需要一個所有自訂屬性皆為字串的簡報。它會列印每個原始名稱與值，將每個值替換為編號字串，並儲存變更。若沒有自訂屬性，迴圈將不會執行任何變更。

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) 透過其第二個參數傳入的單元素清單回傳值。占位符必須與儲存屬性的類型相符：字串使用 `[""]`，整數使用 `[0]`。類型不匹配會拋出 `InvalidCastException`；請依自訂屬性的結構選擇相應的占位符。

## **即時範例**

試用線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問答**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部份，無法完全移除。但您可以更改其值，或在該屬性允許的情況下將其設定為空。

**如果新增的自訂屬性已存在會發生什麼事？**

若新增的自訂屬性已存在，其原有值將被新值覆寫。您不需要事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) 然後呼叫 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 實例的情況下讀取儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/python-net/examine-presentation/) 了解完整報告範例與格式限制。

**可以在不提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。前提是簡報在加密時將 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 設為 `False`，且載入時將 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 設為 `True`。

**可以在「僅載入文件屬性」模式下更新加密的 PPTX 檔案嗎？**

不能。公開與加密的屬性資料必須保持一致，因而在更新加密的 PPTX 檔案時必須使用正確的開啟密碼完整載入簡報。