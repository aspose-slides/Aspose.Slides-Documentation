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
description: "在 Aspose.Slides for Python via .NET 中掌握簡報屬性，並簡化 PowerPoint 檔案的搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for Python via .NET 支援 **內建** 和 **自訂** 文件屬性。使用這些屬性來讀取和更新簡報的中繼資料，例如作者、標題和使用者自訂的值。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 類別來處理簡報文件屬性。此類別的實例可由 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 取得。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用來識別產生輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標準中繼資料，例如標題、作者和文件統計資訊。
- **自訂屬性** 儲存使用者定義的名稱/值配對。

Aspose.Slides for Python via .NET 為兩種分類皆提供存取。於 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢視文件中繼資料。對話方塊會將資訊分為 **Summary**、**Statistics**、**Contents** 與 **Custom** 等標籤。使用 **Custom** 標籤管理使用者自訂的屬性。

## **讀取加密簡報的公開屬性**

開啟密碼通常會同時保護簡報內容與文件屬性。若簡報以 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 設為 `False` 進行加密，則其文件屬性仍保持公開。此時應用程式可將 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 設為 `True`，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 控制 Aspose.Slides 會載入的內容；它不會解密任何資料。若屬性已被加密，則在未提供密碼的情況下載入會失敗。若簡報未加密，則此選項會被忽略，完整的簡報會被載入。

此範例需要一個文件屬性保持公開的加密簡報。它透過 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) 驗證載入模式，然後使用 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 讀取內建屬性：

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

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、形狀、媒體以及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應始終先檢查 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/)。

{{% alert color="warning" title="Security" %}}
公開的中繼資料可能會洩漏作者姓名、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感的屬性與簡報一併加密。僅在索引、分類、搜尋或文件管理系統明確需要在未提供密碼的情況下存取時，才可將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於加密的 PPTX 檔案，使用 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法從此僅含中繼資料的物件儲存變更的屬性，因為公開屬性必須與加密簡報內的相應資料保持一致。因此，更新這些屬性必須提供正確的開啟密碼並完整載入簡報。

此範例需要一個具有公開文件屬性且已知開啟密碼的加密 PPTX 簡報。它使用 [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) 開啟完整的簡報，更新公開的內建屬性，並儲存結果。然後使用 [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

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

如果應用程式不被允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) 類別透過具型別的屬性公開內建的中繼資料，包含 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、以及 [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/)。此範例開啟現有簡報，並將其儲存的中繼資料列印至主控台。值取決於輸入的簡報；某些欄位可能為空。

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

## **修改內建屬性**

若要更新內建的中繼資料，請對由 [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) 所公開的可寫屬性賦值。此範例開啟現有簡報，設定 [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、[DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/)、[DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/)、以及 [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/)，然後使用 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 儲存更新後的簡報。儲存的 PPTX 將包含新的中繼資料。

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

## **管理超連結基礎**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) 儲存文件層級的相對超連結基礎位址。當搬移簡報及其相關檔案至其他位置時，此設定非常有用。它與個別超連結的 [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) 是分離的：變更基礎位址不會重新寫入已儲存的連結位址或更改絕對目的地。

此範例需要一個同時包含相對連結（例如 `target.html`）與指向檔案或網站的絕對連結的簡報。它讀取現有的基礎位址，指派新的基礎位址，並儲存與重新開啟簡報以檢查該值。接著以 `""` 清除基礎位址，並在另一個儲存檔案中驗證其為空。請將範例基礎位址替換為您連結檔案所在的位置。

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

兩個驗證訊息應該會列印 `True`。清除基礎位址不會影響個別超連結的位址。

當基礎位址指向 `old` 資料夾時，相對連結 `target.pptx` 會開啟 `old/target.pptx`。將基礎位址改為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟原本的檔案。請在搬移簡報或變更基礎位址前後於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 方法允許您依屬性名稱指定值。此範例建立一個簡報，加入兩個文字值與一個整數版本值，並使用 [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 儲存簡報。對已存在的名稱賦值會取代該屬性的值。

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

此範例開啟一個包含自訂屬性的簡報，並使用 [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) 逐一遍歷。 [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) 接受零基索引並回傳用於 [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) 的名稱。此範例需要所有自訂屬性皆為字串的簡報。它列印每個原始名稱與值，將所有值取代為編號字串，並儲存變更。若沒有自訂屬性，迴圈將不會執行任何變更。

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) 會透過作為第二參數傳入的一元素清單返回值。此佔位符必須與儲存屬性的類型相符：字串使用 `[""]`，整數使用 `[0]`。類型不匹配會拋出 `InvalidCastException`；請依照自訂屬性結構選擇適當的佔位符。

## **即時範例**

嘗試線上應用程式 [**檢視與編輯 PowerPoint 中繼資料**](https://products.aspose.app/slides/metadata) 來了解如何使用 Aspose.Slides API 處理文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**如何從簡報中移除內建屬性？**

內建屬性是簡報不可分割的一部份，無法完全移除。不過，您可以變更其值，或在該屬性允許的情況下將其設為空值。

**如果新增的自訂屬性已存在會發生什麼情況？**

如果您新增的自訂屬性已存在，其現有的值將會被新值覆寫。您不需要事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**是否能在未完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) 然後 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 實例的情況下讀取儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/python-net/examine-presentation/) 以取得完整的報告範例與格式特定的限制。

**是否能在未提供開啟密碼的情況下讀取加密簡報的公開屬性？**

可以。簡報必須以 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 設為 `False` 進行加密，且必須使用 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) 設為 `True` 來載入。

**是否能在僅文件屬性模式下更新加密的 PPTX 檔案？**

不能。公開與加密的屬性資料必須保持一致，因此在僅文件屬性模式下更新加密的 PPTX 檔案需要使用正確的開啟密碼完整載入簡報。