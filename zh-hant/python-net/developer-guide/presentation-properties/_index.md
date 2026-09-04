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
description: "在 Aspose.Slides for Python via .NET 中掌握簡報屬性，並在 PowerPoint 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種類型的文件屬性：**內建**和**自訂**。這兩種屬性類型皆可透過 Aspose.Slides API 輕鬆存取與管理。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) 類別處理簡報文件屬性。此類別的實例由 [Presentation.document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/document_properties/) 屬性回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意，您無法設定 **Application** 與 **Producer** 欄位的值，因為會顯示 Aspose Ltd. 與 Aspose.Slides for Python via .NET x.x.x 於這些欄位中。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供向簡報檔案加入一些屬性的功能。這些文件屬性允許在文件（簡報檔案）中儲存一些有用資訊。文件屬性分為以下兩種

- 系統定義（內建）屬性
- 使用者自訂（自訂）屬性

**內建**屬性包含文件的一般資訊，例如文件標題、作者名稱、文件統計資訊等。**自訂**屬性則是使用者定義的 **名稱/值** 配對，名稱與值皆由使用者自行定義。使用 Aspose.Slides for Python via .NET，開發人員可存取與修改內建屬性及自訂屬性的值。

Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。您只需點選 Office 圖示，然後進一步選取 **Prepare | Properties | Advanced Properties** 功能表項目。選取 **Advanced Properties** 功能表項目後，會顯示對話方塊，讓您管理 PowerPoint 檔案的文件屬性。在 **Properties Dialog** 中，您會看到多個分頁，如 **General、Summary、Statistics、Contents** 與 **Custom**。所有這些分頁皆允許設定與 PowerPoint 檔案相關的各種資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

## **讀取加密簡報的公開屬性**

開啟密碼通常會同時保護簡報內容與文件屬性。當簡報以 [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) 設為 `False` 加密時，其文件屬性仍保持公開。此時應用程式可以將 [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/only_load_document_properties/) 設為 `True`，在不提供開啟密碼的情況下讀取公開的中繼資料。

`only_load_document_properties` 控制 Aspose.Slides 會載入的內容；它不會進行任何解密。如果屬性已包含在加密中，未提供密碼載入會失敗。若簡報未加密，則會忽略此選項並載入完整的簡報。

以下範例透過 [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) 驗證載入模式，然後透過 [Presentation.document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/document_properties/) 讀取內建屬性：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

在此模式下，不會載入投影片內容。投影片、母片、版面配置、形狀、媒體及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應始終檢查 `is_only_document_properties_loaded`。

{{% alert color="warning" title="Security" %}}
公開的中繼資料可能會洩露作者姓名、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感屬性與簡報一同加密。僅在索引、分類、搜尋或文件管理系統明確需要在未提供密碼的情況下存取時，才保留其公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，使用 `only_load_document_properties` 載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法從僅含中繼資料的物件儲存已變更的屬性，因為公開屬性必須與加密簡報內的相應資料保持一致。因此，更新這些屬性需要正確的開啟密碼與完整載入。

以下範例使用 [LoadOptions.password](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/password/) 開啟簡報，更新公開的內建屬性，並儲存結果。接著利用 [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/is_encrypted/) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
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

若應用程式未被允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**
這些屬性由 **IDocumentProperties** 物件提供，包含：**Creator（作者）**、**Description（描述）**、**Keywords（關鍵字）**、**Created（建立日期）**、**Modified（修改日期）**、**Printed（最後列印日期）**、**LastModifiedBy（最後修改者）**、**SharedDoc（是否在不同製作者間共享）**、**PresentationFormat（簡報格式）**、**Subject（主題）**以及**Title（標題）**
```py
import aspose.slides as slides

# 實例化代表簡報的 Presentation 類別
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # 建立與 Presentation 相關的物件參考
    documentProperties = pres.document_properties

    # 顯示內建屬性
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **修改內建屬性**

修改簡報檔案的內建屬性與存取它們一樣簡單。您只需為任意想修改的屬性指派字串值，即可改變屬性值。以下範例示範了如何修改簡報檔案的內建文件屬性。

```py
import aspose.slides as slides

# 實例化代表簡報的 Presentation 類別
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # 建立與 Presentation 相關的物件參考
    documentProperties = presentation.document_properties

    # 設定內建屬性
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # 將簡報儲存為檔案
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **新增自訂簡報屬性**

Aspose.Slides for Python via .NET 亦允許開發人員為簡報文件屬性新增自訂值。以下範例示範如何為簡報設定自訂屬性。

```py
import aspose.slides as slides

# 實例化 Presentation 類別
with slides.Presentation() as presentation:
    # 取得文件屬性
    documentProperties = presentation.document_properties

    # 新增自訂屬性
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # 取得特定索引處的屬性名稱
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 移除選取的屬性
    documentProperties.remove_custom_property(getPropertyName)

    # 儲存簡報
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **存取與修改自訂屬性**

Aspose.Slides for Python via .NET 亦允許開發人員存取自訂屬性的值。以下範例展示如何存取與修改簡報的所有自訂屬性。

```py
import aspose.slides as slides

# 實例化代表 PPTX 的 Presentation 類別
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # 建立與 Presentation 相關聯的 document_properties 物件參考
    documentProperties = presentation.document_properties

    # 存取並修改自訂屬性
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # 顯示自訂屬性的名稱與值
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # 修改自訂屬性的值
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # 將簡報儲存為檔案
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` 透過其第二個參數傳入的一元素清單回傳值，且儲存的值會被轉型為該清單中已存在元素的類型。上述範例使用 `[""]`，因此會讀取字串屬性；若要讀取以數字儲存的屬性，請傳入數值佔位符，例如 `[0]`——否則呼叫會拋出 `InvalidCastException`。

## **設定校對語言**

Aspose.Slides 提供 `Language_Id` 屬性（由 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 類別公開），讓您為 PowerPoint 文件設定校對語言。校對語言是 PowerPoint 進行拼寫與文法檢查時所使用的語言。

以下 Python 程式碼示範如何為 PowerPoint 設定校對語言：

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # 設定校對語言的 Id
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **設定預設語言**

以下 Python 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **即時範例**

嘗試線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 以了解如何透過 Aspose.Slides API 處理文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以變更其值，或在該屬性允許的情況下將其設為空值。

**如果我新增已存在的自訂屬性會發生什麼情況？**

若您新增已存在的自訂屬性，其原有值會被新值覆寫。您不必先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 再搭配 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 便可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/python-net/examine-presentation/) 以取得完整報告範例及格式特定的限制說明。

**我可以在未提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。前提是簡報在加密時將 `encrypt_document_properties` 設為 `False`，且載入時將 `only_load_document_properties` 設為 `True`。

**我可以在僅載入文件屬性模式下更新已加密的 PPTX 檔案嗎？**

不能。公開與加密的屬性資料必須保持一致，故更新已加密的 PPTX 檔案必須使用正確的開啟密碼完整載入簡報。