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

Aspose.Slides 支援兩種類型的文件屬性：**內建** 與 **自訂**。這兩種屬性皆可透過 Aspose.Slides API 輕鬆存取與管理。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的執行個體可由 [Presentation.document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/document_properties/) 屬性取得。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="info" title="注意" %}}

請注意，您無法為 **Application** 與 **Producer** 欄位設定值，因為會顯示 Aspose Ltd. 與 Aspose.Slides for Python via .NET x.x.x 的資訊於這些欄位。

{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供將屬性加入簡報檔案的功能。這些文件屬性可在文件（簡報檔）中儲存一些有用資訊。文件屬性分為以下兩種：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建** 屬性包含文件的基本資訊，例如文件標題、作者名稱、文件統計資料等。**自訂** 屬性則是使用者以 **名稱/值** 配對自行定義的屬性。使用 Aspose.Slides for Python via .NET，開發人員可存取與修改內建屬性與自訂屬性的值。Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。只要點選 Office 圖示，接著選取 **Prepare | Properties | Advanced Properties** 即可。選取 **Advanced Properties** 後，會出現對話方塊，讓您管理 PowerPoint 檔案的文件屬性。在 **Properties Dialog** 中，您會看到多個分頁，如 **General、Summary、Statistics、Contents 與 Custom**。所有這些分頁皆可設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

## **存取內建屬性**
由 **IDocumentProperties** 物件公開的屬性包括：**Creator(Author)**、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 與 **Title**  
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

修改簡報檔案的內建屬性跟存取它們一樣簡單。您只需將字串值指派給任何想要的屬性，該屬性的值即會被修改。以下範例示範如何修改簡報檔案的內建文件屬性。

```py
import aspose.slides as slides

# 實例化代表簡報的 Presentation 類別
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # 建立與簡報相關的物件參考
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

Aspose.Slides for Python via .NET 亦允許開發人員為簡報的文件屬性新增自訂值。下方範例示範如何為簡報設定自訂屬性。

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

Aspose.Slides for Python via .NET 亦允許開發人員存取自訂屬性的值。下方範例示範如何存取與修改簡報的所有自訂屬性。

```py
import aspose.slides as slides

# 實例化代表 PPTX 的 Presentation 類別
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # 建立與簡報相關的 document_properties 物件參考
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

`get_custom_property_value` 會透過傳入的第二個參數（單元素清單）回傳值，且儲存的值會被轉型為該清單中已有元素的類型。上述範例使用 `[""]`，因此讀取的是字串屬性；若要讀取以數字儲存的屬性，請傳入諸如 `[0]` 的數值佔位符——否則會拋出 `InvalidCastException`。

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

嘗試線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 以了解如何透過 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報不可分割的一部分，無法完全移除。然而，您可以更改其值，或在特定屬性允許的情況下將其設為空。

**如果新增已存在的自訂屬會發生什麼事？**

若新增的自訂屬性已存在，原有的值會被新值覆寫。您無需先移除或檢查該屬性，Aspose.Slides 會自動更新屬性值。

**是否可以在不完全載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 再搭配 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/python-net/examine-presentation/) 以取得完整報告範例與格式限制說明。