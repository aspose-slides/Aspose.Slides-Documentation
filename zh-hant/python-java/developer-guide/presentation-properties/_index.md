---
title: 管理 Python 中的簡報屬性
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
description: "在 Aspose.Slides for Python via Java 中掌握簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中精簡搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種類型的文件屬性：**內建**與**自訂**。這兩種屬性類型都可以輕鬆透過 Aspose.Slides API 來存取與管理。

Aspose.Slides 讓您透過 [DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/) 類別來處理簡報文件屬性。此類別的實例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDocumentProperties) 取得。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="注意" %}}
請注意，**Application** 與 **AppVersion** 欄位不可修改。Aspose.Slides 會在每次儲存時重新寫入這些欄位，因此儲存的簡報始終會顯示「Aspose.Slides for Java」以及產生它的函式庫版本。傳遞給 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#setNameOfApplication) 的任何值在寫入簡報時都會被捨棄。
{{% /alert %}}

## **PowerPoint 中的文件屬性**

Microsoft PowerPoint 2007 允許您管理簡報檔案的文件屬性。點選 Office 圖示並選擇 **準備 | 屬性 | 高階屬性**，如下所示：

|**選取「高階屬性」功能表項目**|
| :- |
|![PowerPoint 文件屬性](https://i.imgur.com/ZrmuCD6.jpg)|

選取 **高階屬性** 後，會出現對話方塊，您可以在其中管理 PowerPoint 檔案的文件屬性：

|**屬性對話方塊**|
| :- |
|![PowerPoint 文件屬性](https://i.imgur.com/LibmdQd.jpg)|

**屬性對話方塊** 包含 **General**、**Summary**、**Statistics**、**Contents** 與 **Custom** 等分頁。這些分頁讓您設定 PowerPoint 檔案的不同資訊。請使用 **Custom** 分頁管理自訂屬性。

## **使用 Aspose.Slides for Python via Java 處理文件屬性**

如前所述，Aspose.Slides for Python via Java 支援 **內建** 與 **自訂** 兩種文件屬性。[DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/) 類別代表與簡報檔案關聯的文件屬性。

使用 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDocumentProperties) 可依下列說明存取這些屬性。

## **從受保護的簡報讀取公共屬性**

開啟密碼通常同時保護簡報內容與文件屬性。當透過將 `false` 傳遞給 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 來加密簡報時，其文件屬性仍保留為公共。此時應用程式可以將 `true` 傳遞給 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ，在不提供開啟密碼的情況下讀取公共中繼資料。

文件屬性僅載入選項控制 Aspose.Slides 載入的內容；它不會解密任何資料。如果屬性已被加密，未提供密碼載入會失敗。若簡報未加密，則會忽略此選項並完整載入簡報。

以下範例透過 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 驗證載入模式，然後透過 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDocumentProperties) 讀取內建屬性：

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

在此模式下，簡報內容不會被載入。投影片、母片、版面配置、形狀、媒體以及其他簡報物件皆不可使用。應用程式在執行需要完整簡報物件模型的操作前，應先檢查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="警告" %}}
公共中繼資料可能會暴露作者名稱、標題、主旨、關鍵字、公司資訊、備註以及自訂值。請將敏感屬性與簡報一起加密。只有在索引、分類、搜尋或文件管理系統明確需求在無密碼情況下存取時，才將其保留為公共。
{{% /alert %}}

## **更新受保護簡報的屬性**

對於已加密的 PPTX 檔案，以文件屬性僅載入模式載入的簡報旨在讀取公共中繼資料。Aspose.Slides 無法從僅含中繼資料的物件保存變更的屬性，因為公共屬性必須與加密簡報內的對應資料保持一致。因此，更新這些屬性必須提供正確的開啟密碼並完整載入簡報。

以下範例使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setPassword) 開啟簡報，更新公共內建屬性，並儲存結果。然後使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#isEncrypted) 驗證加密狀態，並在不提供密碼的情況下重新開啟公共中繼資料以驗證新值：

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

如果應用程式無法解密或載入簡報內容，則必須將受保護 PPTX 檔案的公共屬性視為唯讀。

## **存取內建屬性**

[DocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/) 所提供的內建屬性包括：**Creator**（作者）、**Description**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否與其他製作者共享？）、**PresentationFormat**、**Subject** 與 **Title**。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# 實例化表示簡報的 Presentation 類別
presentation = Presentation("Presentation.pptx")
try:
    # 建立與 Presentation 相關聯的 DocumentProperties 物件之參考
    properties = presentation.getDocumentProperties()

    # 顯示內建屬性
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **修改內建屬性**

修改內建屬性與存取它們同樣簡單，使用相對應的 setter 即可指派新值。以下範例示範如何使用 Aspose.Slides for Python via Java 修改內建文件屬性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # 建立與 Presentation 相關聯的 DocumentProperties 物件之參考
    properties = presentation.getDocumentProperties()

    # 設定內建屬性
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # 將簡報儲存至檔案
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此範例會修改簡報的內建屬性，結果如圖所示：

|**修改後的內建文件屬性**|
| :- |
|![PowerPoint 文件屬性](https://i.imgur.com/zz1N9de.jpg)|

## **新增自訂文件屬性**

Aspose.Slides for Python via Java 亦允許開發者向簡報新增自訂文件屬性。以下範例新增三個自訂屬性，然後查找索引為 2 的名稱並將其移除，最終儲存的簡報僅保留兩個屬性。自訂屬性依字母順序編號，而非加入順序。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 取得文件屬性
    properties = presentation.getDocumentProperties()

    # 新增自訂屬性
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # 取得特定索引處的屬性名稱
    property_name = properties.getCustomPropertyName(2)

    # 移除選取的屬性
    properties.removeCustomProperty(property_name)

    # 儲存簡報
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**已新增的自訂文件屬性**|
| :- |
|![PowerPoint 文件屬性](https://i.imgur.com/HdKcxI9.png)|

## **存取與修改自訂屬性**

Aspose.Slides for Python via Java 亦允許開發者存取自訂屬性的值。以下範例示範如何在簡報中存取並修改所有自訂屬性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # 建立與 Presentation 相關聯的 DocumentProperties 物件之參考
    properties = presentation.getDocumentProperties()

    # 存取並修改自訂屬性
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # 顯示自訂屬性的名稱與值
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # 修改自訂屬性的值
        properties.set_Item(property_name, f"New Value {i + 1}")

    # 將簡報儲存至檔案
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此範例會修改 [PPTX](https://docs.fileformat.com/presentation/pptx/) 簡報的自訂屬性。以下圖示分別顯示修改前後的自訂屬性：

|**修改前的自訂屬性**|
| :- |
|![PowerPoint 文件屬性](https://i.imgur.com/Ze7YHvi.jpg)|

|**修改後的自訂屬性**|
| :- |
|![PowerPoint 文件屬性](https://i.imgur.com/Tofu0CL.jpg)|

## **進階文件屬性**

{{% alert color="info" title="注意" %}}
已為 [PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/) 新增方法 [readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) 與 [writeBindedPresentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#writeBindedPresentation)，且 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#setLastSavedTime) 方法的行為已變更。
{{% /alert %}}

[PresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/) 類別已加入兩個新方法 [readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 與 [updateDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#updateDocumentProperties)。它們提供快速存取文件屬性，且允許在不載入整個簡報的情況下變更與更新屬性。

載入屬性、變更其值並更新文件的典型工作流程如下：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# 讀取簡報資訊
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# 取得目前的屬性
properties = presentation_info.readDocumentProperties()

# 設定作者與標題欄位的新值
properties.setAuthor("New Author")
properties.setTitle("New Title")

# 以新值更新簡報
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

另一種方式是將特定簡報的屬性作為範本，以更新其他簡報的屬性：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

也可以從頭建立新範本，然後用來更新多個簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **設定校對語言**

Aspose.Slides 提供 [PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#setLanguageId) 方法，讓您為 PowerPoint 文件設定校對語言。校對語言是檢查簡報拼寫與文法時所使用的語言。

以下 Python 程式碼示範如何為 PowerPoint 設定校對語言：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # 設定校對語言的 ID

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **設定預設語言**

以下 Python 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # 加入一個帶文字的矩形形狀
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # 檢查第一個段落的語言
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **線上示範**

嘗試使用 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 線上應用程式，了解如何透過 Aspose.Slides API 處理文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。但您可以變更其值，或在該屬性允許的情況下將其設為空白。

**如果新增的自訂屬性已存在，會發生什麼事？**

若新增的自訂屬性已存在，現有的值會被新值覆寫。您無需事先移除或檢查該屬性，Aspose.Slides 會自動更新其值。

**是否可以在不完整載入簡報的情況下存取簡報屬性？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 再呼叫 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/python-java/examine-presentation/) 以取得完整的報告範例與格式限制說明。

**是否可以在不提供開啟密碼的情況下讀取受保護簡報的公共屬性？**

可以。前提是文件屬性加密在簡報加密之前已被停用，且簡報以僅載入文件屬性的模式開啟。

**是否可以在僅載入文件屬性模式下更新受保護的 PPTX 檔案？**

不能。公共屬性與加密屬性資料必須保持一致，因而更新受保護的 PPTX 檔案必須使用正確的開啟密碼完整載入簡報。