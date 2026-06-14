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
## **簡介**

Aspose.Slides 支援兩種文件屬性類型：**Built-in** 和 **Custom**。這兩種屬性類型都可以輕鬆地透過 Aspose.Slides API 存取和管理。

Aspose.Slides 允許您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/) 類別操作簡報文件屬性。此類別的實例由 [Presentation.document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/document_properties/) 屬性返回。以下範例說明如何讀取、修改和管理這些屬性。

{{% alert color="primary" %}} 
請注意，您無法設定 **Application** 和 **Producer** 欄位的值，因為會顯示 Aspose Ltd. 以及 Aspose.Slides for Python via .NET x.x.x 在這些欄位中。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供將屬性加入簡報檔案的功能。這些文件屬性允許在文件（簡報檔案）中儲存一些有用的資訊。文件屬性分為以下兩類：

- 系統定義（Built-in）屬性
- 使用者定義（Custom）屬性

**Built-in** 屬性包含有關文件的一般資訊，例如文件標題、作者姓名、文件統計資料等。**Custom** 屬性則是使用者以 **Name/Value** 配對的方式自行定義，名稱與值皆由使用者決定。使用 Aspose.Slides for Python via .NET，開發人員可以存取和修改內建屬性以及自訂屬性的值。Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。您只需點選 Office 圖示，接著選取 **Prepare | Properties | Advanced Properties** 功能表項目。選取 **Advanced Properties** 後，會出現對話方塊，讓您管理 PowerPoint 檔案的文件屬性。在 **Properties Dialog** 中，您會看到多個分頁，如 **General, Summary, Statistics, Contents and Custom**。所有這些分頁允許設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

## **存取內建屬性**

這些由 **IDocumentProperties** 物件公開的屬性包括：**Creator(Author)**、**Description**、**Keywords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 以及 **Title**。
```py
import aspose.slides as slides

# 實例化代表簡報的 Presentation 類別
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # 建立與 Presentation 相關聯的物件參考
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

修改簡報檔案的內建屬性與存取它們同樣簡單。您只需將字串值指派給任意屬性，即可修改該屬性的值。以下範例展示了如何修改簡報檔案的內建文件屬性。
```py
import aspose.slides as slides

# 實例化代表簡報的 Presentation 類別
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # 建立與 Presentation 關聯的物件參考
    documentProperties = presentation.document_properties

    # 設定內建屬性
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # 將簡報保存至檔案
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **新增自訂簡報屬性**

Aspose.Slides for Python via .NET 也允許開發人員為簡報文件屬性新增自訂值。以下範例示範如何為簡報設定自訂屬性。
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

    # 取得特定索引的屬性名稱
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 移除選取的屬性
    documentProperties.remove_custom_property(getPropertyName)

    # 儲存簡報
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **存取與修改自訂屬性**

Aspose.Slides for Python via .NET 也允許開發人員存取自訂屬性的值。以下範例說明如何存取並修改簡報的所有自訂屬性。
```py
import aspose.slides as slides

# 實例化代表 PPTX 的 Presentation 類別
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # 建立與 Presentation 相關聯的 document_properties 物件參考
    documentProperties = presentation.document_properties

    # 存取並修改自訂屬性
    for i in range(documentProperties.count_of_custom_properties):
        # 顯示自訂屬性的名稱與值
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # 修改自訂屬性的值
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # 將簡報保存至檔案
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定校對語言**

Aspose.Slides 提供 `Language_Id` 屬性（由 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 類別公開），讓您為 PowerPoint 文件設定校對語言。校對語言是 PowerPoint 進行拼寫與文法檢查時使用的語言。

以下 Python 程式碼示範如何為 PowerPoint 設定校對語言：
```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
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

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以更改其值，或在該屬性允許的情況下將其設為空值。

**如果我新增的自訂屬性已經存在，會發生什麼情況？**

如果新增的自訂屬性已經存在，其原有值會被新值覆寫。您無需事先移除或檢查該屬性，因為 Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

是的，您可以透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/) 類別的 [get_presentation_info](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationfactory/get_presentation_info/) 方法，在不完整載入簡報的情況下存取簡報屬性。然後使用 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/) 類別提供的 [read_document_properties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentationinfo/read_document_properties/) 方法有效地讀取屬性，節省記憶體並提升效能。