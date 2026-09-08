---
title: 使用 Python 管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/python-java/manage-ole/
keywords:
- OLE 物件
- 物件鏈結與嵌入
- 新增 OLE
- 嵌入 OLE
- 新增物件
- 嵌入物件
- 新增檔案
- 嵌入檔案
- 連結物件
- 連結檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 抽取 OLE
- 抽取物件
- 抽取檔案
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，優化在 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫地嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}

OLE（Object Linking & Embedding）是 Microsoft 的技術，可讓在一個應用程式中建立的資料和物件透過鏈結或嵌入的方式放入另一個應用程式。

{{% /alert %}}

以在 Microsoft Excel 中建立的圖表為例。該圖表接著被放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。

- OLE 物件可能顯示為圖示。此時雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選擇要開啟或編輯物件的應用程式。
- OLE 物件也可能直接顯示其實際內容，例如圖表本身。此時圖表在 PowerPoint 中被啟用，圖表介面載入，您即可在 PowerPoint 內修改圖表資料。

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/zh-hant/python-java/) 允許您將 OLE 物件插入投影片，作為 OLE 物件框（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)）。

## **將 OLE 物件框新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並想透過 Aspose.Slides for Python via Java 將其嵌入投影片作為 OLE 物件框，可依照下列方式操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 依照索引取得投影片參考。
3. 將 Excel 檔案讀取為位元組陣列。
4. 使用位元組陣列與 OLE 物件的其他資訊，將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 新增至投影片。
5. 將修改後的簡報寫入 PPTX 檔案。

在下方範例中，我們使用 Aspose.Slides for Python via Java，將 Excel 檔案中的圖表以 OLE 物件框的方式新增至投影片。

**Note**  [OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleembeddeddatainfo/) 建構函式的第二個參數是可嵌入物件的副檔名。此副檔名讓 PowerPoint 能正確辨識檔案類型並選擇適當的應用程式開啟此 OLE 物件。

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

    # 將 OLE 物件框新增至投影片。
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **新增連結的 OLE 物件框**

Aspose.Slides for Python via Java 允許您在不嵌入資料的情況下，僅以檔案連結的方式新增 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)。

以下 Python 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 新增至投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增一個連結至 Excel 檔案的 OLE 物件框。
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取 OLE 物件框**

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆找到或存取它：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例，以載入含有嵌入 OLE 物件的簡報。
2. 依照索引取得投影片參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 形狀。
   在本例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，接著檢查該物件是否為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)。這就是要存取的目標 OLE 物件框。
4. 取得 OLE 物件框後，即可對其執行任何操作。

以下範例示範如何存取 OLE 物件框（嵌入於投影片中的 Excel 圖表物件）以及其檔案資料。

```python
import jpase
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

        # 取得嵌入檔案資料。
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # 取得嵌入檔案的副檔名。
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **存取連結 OLE 物件框屬性**

Aspose.Slides 允許您存取連結 OLE 物件框的屬性。

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
            # 列印連結檔案的完整路徑。
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # 若有則列印連結檔案的相對路徑。
            # 僅 PPT 簡報可以包含相對路徑。
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

如果投影片中已嵌入 OLE 物件，您可以依照以下步驟存取該物件並修改其資料：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例，以載入含有嵌入 OLE 物件的簡報。
2. 依照索引取得投影片參考。
3. 存取 OLE 物件框形狀。
   在本例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，接著檢查該物件是否為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)。這就是要存取的目標 OLE 物件框。
4. 取得 OLE 物件框後，即可對其執行任何操作。
5. 建立一個 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 物件並存取 OLE 資料。
6. 存取所需的 [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) 並修改資料。
7. 將更新後的 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 儲存至串流。
8. 從串流變更 OLE 物件資料。

以下範例示範如何存取 OLE 物件框（嵌入於投影片中的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

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

        # 將 OLE 物件資料讀取為 Workbook 物件。
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # 修改 Workbook 資料。
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # 變更 OLE 框的物件資料。
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for Python via Java 還允許您將其他類型的檔案嵌入投影片，例如 HTML、PDF 和 ZIP 檔案。使用者雙擊插入的物件時，會自動以相關程式開啟，或提示使用者選擇適當的程式。

以下 Python 程式碼示範如何將 HTML 與 ZIP 檔案嵌入投影片：

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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新物件，或將不受支援的 OLE 物件換成受支援的類型。Aspose.Slides for Python via Java 允許您設定嵌入物件的檔案類型，從而更新 OLE 框的資料或副檔名。

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

嵌入 OLE 物件後，系統會自動新增一個包含圖示影像的預覽。這個預覽即是使用者在存取或開啟 OLE 物件前所看到的內容。如果您希望使用特定的影像與文字作為預覽元素，可透過 Aspose.Slides for Python via Java 設定圖示影像與標題。

以下 Python 程式碼示範如何為嵌入物件設定圖示影像與標題：

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

    # 新增影像至簡報資源。
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # 設定 OLE 預覽的標題與影像。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **防止 OLE 物件框被重新調整大小或重新定位**

將連結的 OLE 物件加入簡報投影片後，於 PowerPoint 開啟簡報時，可能會出現要求更新連結的訊息。點擊「Update Links」按鈕可能會因 PowerPoint 從連結的 OLE 物件更新資料並重新整理預覽，而導致 OLE 物件框的大小與位置改變。為避免 PowerPoint 提示更新物件資料，請將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 類別的 [setUpdateAutomatic](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 方法設為 `False`：

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

Aspose.Slides for Python via Java 允許您以以下方式擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立一個包含欲擷取 OLE 物件之 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 迭代簡報中的所有形狀，存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 形狀。
3. 從 OLE 物件框取得嵌入檔案的資料，並寫入磁碟。

以下 Python 程式碼示範如何擷取投影片中以 OLE 物件形式嵌入的檔案：

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

**將 OLE 內容匯出為 PDF/圖片時會被渲染嗎？**

投影片上可見的內容會被渲染——也就是圖示/替代影像（預覽）。「即時」的 OLE 內容不會在渲染過程中執行。如有需要，可自行設定預覽影像，以確保匯出 PDF 時呈現預期外觀。

**如何在投影片上鎖定 OLE 物件，使使用者無法在 PowerPoint 中移動或編輯？**

鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/python-java/applying-protection-to-presentation/)。這不是加密，但可有效防止意外的編輯與移動。

**為什麼連結的 Excel 物件在開啟簡報時會「跳動」或變更大小？**

PowerPoint 可能會重新整理連結 OLE 的預覽。若需穩定外觀，請遵循 [Working Solution for Worksheet Resizing](/slides/zh-hant/python-java/working-solution-for-worksheet-resizing/) 的做法——將框架調整至範圍大小，或將範圍縮放至固定框架，同時設定適當的替代影像。

**在 PPTX 格式中，連結的 OLE 物件會保留相對路徑嗎？**

在 PPTX 中不會保留「相對路徑」資訊—僅有完整路徑。相對路徑僅存在於較舊的 PPT 格式。為提升可攜性，建議使用可靠的絕對路徑/可存取的 URI，或直接嵌入檔案。