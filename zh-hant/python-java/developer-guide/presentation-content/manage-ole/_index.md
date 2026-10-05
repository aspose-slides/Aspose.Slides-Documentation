---
title: 使用 Python 管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/python-java/manage-ole/
keywords:
- OLE 物件
- 物件連結與嵌入
- 新增 OLE
- 嵌入 OLE
- 新增 物件
- 嵌入 物件
- 新增 檔案
- 嵌入 檔案
- 連結 物件
- 連結 檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 提取 OLE
- 提取 物件
- 提取 檔案
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，優化 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}

OLE（Object Linking & Embedding）是 Microsoft 的技術，可讓在一個應用程式中建立的資料和物件透過連結或嵌入的方式放入另一個應用程式。

{{% /alert %}}

假設在 Microsoft Excel 中建立了一個圖表，然後將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。

- OLE 物件可能顯示為圖示。此時，雙擊圖示會在相關的應用程式（Excel）中開啟圖表，或會要求您選取開啟或編輯物件的應用程式。
- OLE 物件也可能直接顯示其實際內容，例如圖表的內容。此時圖表在 PowerPoint 中被啟動，圖表介面載入，您即可在 PowerPoint 內修改圖表的資料。

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) allows you to insert OLE objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，且想使用 Aspose.Slides for Python via Java 將其以 OLE 物件框架的形式嵌入投影片，您可以這樣做：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 Excel 檔案讀取為位元組陣列。
1. 將 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 加入投影片，包含位元組陣列以及其他 OLE 物件資訊。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下範例示範我們如何使用 Aspose.Slides for Python via Java，將 Excel 檔案中的圖表以 OLE 物件框架的方式新增至投影片。

**注意** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) 建構函式將可嵌入物件的副檔名作為第二個參數。此副檔名允許 PowerPoint 正確判讀檔案類型並選擇適當的應用程式開啟此 OLE 物件。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # 為 OLE 物件準備資料。
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # 將 OLE 物件框架加入投影片。
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **新增已連結的 OLE 物件框架**

Aspose.Slides for Python via Java 允許您加入 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)，其連結指向檔案而非嵌入資料。

以下 Python 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 新增至投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增具連結 Excel 檔案的 OLE 物件框架。
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取 OLE 物件框架**

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆尋找或存取它：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例，以載入含有嵌入 OLE 物件的簡報。
2. 依索引取得投影片的參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 形狀。在本例中，我們使用先前建立的 PPTX，該檔案的第一張投影片只有一個形狀。我們接著檢查該物件是否為 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)。這就是要存取的目標 OLE 物件框架。
4. 取得 OLE 物件框架後，即可對其執行任何操作。

以下範例示範存取 OLE 物件框架（嵌入投影片的 Excel 圖表物件）及其檔案資料。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # 取得嵌入檔案的資料。
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # 取得嵌入檔案的副檔名。
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **存取已連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取已連結 OLE 物件框架的屬性。

以下 Python 程式碼示範如何檢查 OLE 物件是否為連結，並取得連結檔案的路徑：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # 檢查 OLE 物件是否為連結。
        if ole_frame.isObjectLink():
            # 輸出連結檔案的完整路徑。
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # 若存在，輸出連結檔案的相對路徑。
            # 只有 PPT 簡報會包含相對路徑。
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}

本節中的程式碼範例使用 [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/)。

{{% /alert %}}

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆存取該物件並修改其資料：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例，以載入含有嵌入 OLE 物件的簡報。
2. 依索引取得投影片的參考。
3. 存取 OLE 物件框架形狀。在本例中，我們使用先前建立的 PPTX，其第一張投影片上僅有一個形狀。我們接著檢查該物件是否為 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)。這就是要存取的目標 OLE 物件框架。
4. 取得 OLE 物件框架後，即可對其執行任何操作。
5. 建立 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 物件，並存取 OLE 資料。
6. 取得目標 [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) 並修改資料。
7. 將更新後的 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 儲存至串流。
8. 從串流變更 OLE 物件資料。

以下範例示範存取 OLE 物件框架（嵌入投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # 以 Workbook 物件讀取 OLE 物件資料。
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # 修改工作簿資料。
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # 更改 OLE 框架物件資料。
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for Python via Java 也允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 及 ZIP 檔案插入為物件。使用者雙擊插入的物件時，會自動在相關程式中開啟，或提示使用者選取適當的程式開啟。

以下 Python 程式碼示範如何將 HTML 與 ZIP 嵌入投影片：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定嵌入物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新物件，或將不支援的 OLE 物件換成支援的。Aspose.Slides for Python via Java 允許您設定嵌入物件的檔案類型，以便更新 OLE 框架資料或其副檔名。

以下 Python 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # 將檔案類型變更為 ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定嵌入物件的圖示影像與標題**

在 OLE 物件嵌入後，系統會自動加入由圖示影像組成的預覽。此預覽即為使用者在存取或開啟 OLE 物件前所看到的畫面。若您想在預覽中使用特定的影像與文字，可使用 Aspose.Slides for Python via Java 設定圖示影像與標題。

以下 Python 程式碼示範如何為嵌入的物件設定圖示影像與標題：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # 將影像加入簡報資源。
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # 為 OLE 預覽設定標題與影像。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **防止 OLE 物件框架被調整大小與重新定位**

在您將已連結的 OLE 物件新增至簡報投影片後，於 PowerPoint 開啟簡報時，可能會出現要求更新連結的訊息。點選「Update Links」按鈕可能會因 PowerPoint 從已連結 OLE 物件更新資料並重新整理物件預覽，而改變 OLE 物件框架的大小與位置。若要阻止 PowerPoint 提示更新物件資料，請以 `False` 呼叫 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 類別的 [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **擷取嵌入檔案**

Aspose.Slides for Python via Java 可讓您透過以下方式擷取投影片中嵌入的 OLE 物件檔案：

1. 建立包含欲擷取 OLE 物件之 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
2. 遍歷簡報中所有形狀，並存取 [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) 形狀。
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入至磁碟。

以下 Python 程式碼示範如何將投影片中嵌入的檔案以 OLE 物件形式擷取：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **常見問題**

**在將投影片匯出為 PDF/影像時，會呈現 OLE 內容嗎？**

投影片上可見的內容會被渲染——即圖示/替代影像（預覽）。在渲染過程中不會執行「即時」的 OLE 內容。如有需要，請自行設定預覽圖像，以確保匯出 PDF 時的外觀符合預期。若要同時將嵌入的檔案保留為 PDF 附件，請以 `True` 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData)。此選項預設為停用。欲參考範例與檢查附件的說明，請見 [將嵌入 OLE 檔案保留為 PDF 附件](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何將 OLE 物件鎖定在投影片上，使使用者在 PowerPoint 中無法移動/編輯？**

鎖定形狀：Aspose.Slides 提供 [形狀層級鎖定](/slides/zh-hant/python-java/applying-protection-to-presentation/)。這不是加密，但可有效防止意外編輯與移動。

**為什麼已連結的 Excel 物件在開啟簡報時會「跳動」或變更大小？**

PowerPoint 可能會重新整理已連結 OLE 的預覽。為獲得穩定的外觀，請遵循 [工作解決方案：工作表大小調整](/slides/zh-hant/python-java/working-solution-for-worksheet-resizing/) 的做法——要麼將框架調整至符合範圍，要麼將範圍縮放至固定框架，並設定適當的替代影像。

**在 PPTX 格式中，已連結 OLE 物件的相對路徑會被保留嗎？**

在 PPTX 中，並不存在「相對路徑」資訊——僅有完整路徑。相對路徑僅在較舊的 PPT 格式中出現。為確保可移植性，建議使用可靠的絕對路徑/可存取的 URI 或採用嵌入方式。