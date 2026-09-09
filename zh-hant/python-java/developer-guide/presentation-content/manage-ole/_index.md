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
- 新增物件
- 嵌入物件
- 新增檔案
- 嵌入檔案
- 連結物件
- 連結檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 擷取 OLE
- 擷取物件
- 擷取檔案
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，優化在 PowerPoint 和 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}
OLE（Object Linking & Embedding）是微軟技術，允許在一個應用程式中建立的資料和物件透過連結或嵌入的方式放入另一個應用程式中。
{{% /alert %}}

考慮在 Microsoft Excel 中建立的圖表，然後將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。

- OLE 物件可能以圖示顯示。此時，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選擇開啟或編輯物件的應用程式。
- OLE 物件也可能直接顯示其實際內容，例如圖表本身。此時，圖表在 PowerPoint 中被啟動，圖表介面載入，您可以在 PowerPoint 內修改圖表資料。

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/zh-hant/python-java/) 允許您將 OLE 物件插入投影片作為 OLE 物件框（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)）。

## **將 OLE 物件框新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，且想使用 Aspose.Slides for Python via Java 將其以 OLE 物件框嵌入投影片，可依下列方式操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片參考。
3. 將 Excel 檔案讀取為位元組陣列。
4. 將包含位元組陣列及其他 OLE 物件資訊的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 新增至投影片。
5. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們使用 Aspose.Slides for Python via Java，將 Excel 檔案中的圖表以 OLE 物件框的形式加入投影片。

**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleembeddeddatainfo/) 的建構函式將可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確解讀檔案類型，並選擇正確的應用程式開啟此 OLE 物件。

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

Aspose.Slides for Python via Java 允許您加入一個以檔案連結方式而非嵌入資料的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)。

此 Python 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 新增至投影片：

```python
import jpipe
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增具有連結 Excel 檔案的 OLE 物件框。
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **存取 OLE 物件框**

如果 OLE 物件已嵌入投影片中，您可以依下列方式輕鬆尋找或存取它：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例方式載入含有嵌入 OLE 物件的簡報。
2. 依索引取得投影片參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 形狀。於本範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，接著檢查該物件是否為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)。這就是欲存取的 OLE 物件框。
4. 一旦取得 OLE 物件框，即可對其執行任何操作。

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

此 Python 程式碼示範如何檢查 OLE 物件是否為連結狀態，並取得連結檔案的路徑：

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
            # 只有 PPT 簡報可以包含相對路徑。
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}
在本節中，下方程式碼範例使用 [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/)。
{{% /alert %}}

如果 OLE 物件已嵌入投影片中，您可以依下列方式輕鬆存取該物件並修改其資料：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例方式載入含有嵌入 OLE 物件的簡報。
2. 依索引取得投影片參考。
3. 存取 OLE 物件框形狀。於本範例中，我們使用先前建立的在第一張投影片上僅有一個形狀的 PPTX，接著檢查該物件是否為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/)。這就是欲存取的 OLE 物件框。
4. 一旦取得 OLE 物件框，即可對其執行任何操作。
5. 建立 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 物件並存取 OLE 資料。
6. 存取目標 [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) 並修改資料。
7. 將更新後的 [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) 儲存至串流。
8. 從串流中變更 OLE 物件資料。

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

        # 變更 OLE 框物件資料。
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for Python via Java 也允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。使用者雙擊插入的物件時，會自動於相關程式中開啟，或提示使用者選擇適當的程式開啟。

此 Python 程式碼示範如何將 HTML 與 ZIP 嵌入投影片：

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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不支援的 OLE 物件換成受支援的。Aspose.Slides for Python via Java 允許您設定嵌入物件的檔案類型，從而更新 OLE 框資料或其副檔名。

此 Python 程式碼示範如何將嵌入 OLE 物件的檔案類型設為 `zip`：

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

    # 更改檔案類型為 ZIP。
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定嵌入物件的圖示與標題**

在 OLE 物件嵌入後，系統會自動加入由圖示圖像組成的預覽。此預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。若您想使用特定圖像與文字作為預覽元素，可透過 Aspose.Slides for Python via Java 設定圖示圖像與標題。

此 Python 程式碼示範如何為嵌入物件設定圖示圖像與標題：

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

    # 將影像新增至簡報資源。
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # 設定標題與影像作為 OLE 預覽。
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **防止 OLE 物件框被重新調整大小與重新定位**

在將連結 OLE 物件加入簡報投影片後，於 PowerPoint 開啟簡報時可能會看到更新連結的提示。點選「Update Links」按鈕可能會因 PowerPoint 從連結 OLE 物件更新資料並重新整理預覽，而改變 OLE 物件框的大小與位置。為防止 PowerPoint 提示更新物件資料，請將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 類別的 [setUpdateAutomatic](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) 方法設為 `False`：

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

Aspose.Slides for Python via Java 允許您依下列方式擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立包含欲擷取 OLE 物件之 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 逐一遍歷簡報中的所有形狀，取得 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 形狀。
3. 從 OLE 物件框存取嵌入檔案的資料，並寫入磁碟。

此 Python 程式碼示範如何將投影片中以 OLE 物件形式嵌入的檔案擷取出來：

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

**Will the OLE content be rendered when exporting slides to PDF/images?**  
投影片上可見的部分會被渲染——即圖示/替代影像（預覽）。「即時」的 OLE 內容在渲染過程中不會被執行。若有需要，請自行設定預覽影像，以確保匯出為 PDF 時的外觀符合預期。

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**  
鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/python-java/applying-protection-to-presentation/)。這並非加密，但可有效防止意外編輯與移動。

**Why does a linked Excel object "jump" or change size when I open the presentation?**  
PowerPoint 可能會重新整理連結 OLE 的預覽。為獲得穩定外觀，請依照 [Working Solution for Worksheet Resizing](/slides/zh-hant/python-java/working-solution-for-worksheet-resizing/) 的做法執行——或將框架調整至範圍大小，或將範圍縮放至固定框架，並設定適當的替代影像。

**Will relative paths for linked OLE objects be preserved in the PPTX format?**  
在 PPTX 中不提供「相對路徑」資訊——僅有完整路徑。相對路徑僅出現在較舊的 PPT 格式。為提升可攜性，建議使用可靠的絕對路徑 / 可存取的 URI，或直接嵌入檔案。