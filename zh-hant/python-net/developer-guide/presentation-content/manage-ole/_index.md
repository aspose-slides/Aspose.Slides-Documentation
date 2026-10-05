---
title: 使用 Python 管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/python-net/manage-ole/
keywords:
- OLE 物件
- 物件連結與嵌入
- 新增 OLE
- 嵌入 OLE
- 新增物件
- 嵌入物件
- 新增檔案
- 嵌入檔案
- 已連結物件
- 已連結檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 擷取 OLE
- 擷取物件
- 擷取檔案
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，最佳化在 PowerPoint 與 OpenDocument 檔案中 OLE 物件的管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** 是一項 Microsoft 技術，可讓在一個應用程式中建立的資料與物件，連結或嵌入到另一個應用程式中。

{{% /alert %}}

舉例而言，在 Microsoft Excel 中建立的圖表，若放到 PowerPoint 投影片上，即為 OLE 物件。

- OLE 物件可能以圖示方式顯示。雙擊圖示會在其關聯的應用程式（例如 Excel）中開啟物件，或提示您選擇要開啟或編輯的應用程式。
- OLE 物件也可能直接顯示內容（例如圖表）。此時，PowerPoint 會啟動嵌入的物件，載入圖表介面，讓您在 PowerPoint 內編輯圖表資料。

Aspose.Slides for Python 可讓您將 OLE 物件插入投影片，作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)）。

## **將 OLE 物件加入投影片**

如果您已在 Microsoft Excel 中建立圖表，且想使用 Aspose.Slides for Python 以 OLE 物件框架的方式嵌入投影片，請依照以下步驟執行：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 將 Excel 檔案讀取為位元組陣列。
1. 將 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 新增至投影片，並提供位元組陣列及其他 OLE 物件資訊。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下範例示範如何將 Excel 檔案中的圖表以 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 的形式嵌入投影片。

**注意：** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) 建構函式的第二個參數為可嵌入物件的檔案副檔名。PowerPoint 會依此副檔名辨識檔案類型，並選擇適當的應用程式開啟 OLE 物件。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # 為 OLE 物件準備資料.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # 在投影片中新增 OLE 物件框架.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **新增已連結的 OLE 物件**

Aspose.Slides for Python 允許您加入一個連結至檔案的 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)，而非嵌入其資料。

以下 Python 範例示範如何在投影片上加入連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 新增一個連結至 Excel 檔案的 OLE 物件框架.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **存取 OLE 物件**

如果投影片中已嵌入 OLE 物件，您可以按下列方式存取它：

1. 透過建立 Presentation 類別的實例，載入包含嵌入 OLE 物件的簡報。
1. 依索引取得投影片的參考。
1. 取得 OleObjectFrame 形狀。
1. 取得 OLE 物件框架後，執行任何所需的操作。

下列範例存取 OLE 物件框架（嵌入的 Excel 圖表），並取得其檔案資料。此範例使用一個在第一張投影片上僅有單一形狀的 PPTX。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 取得嵌入檔案資料.
        file_data = ole_frame.embedded_data.embedded_file_data

        # 取得嵌入檔案的副檔名.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **存取已連結 OLE 物件的屬性**

Aspose.Slides 讓您可以存取已連結 OLE 物件框架的屬性。

以下 Python 範例會檢查 OLE 物件是否已連結，若是，則取得連結檔案的路徑：

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 檢查 OLE 物件是否已連結.
        if ole_frame.is_object_link:
            # 列印連結檔案的完整路徑.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # 列印連結檔案的相對路徑（若存在）.
            # 只有 .ppt 簡報可以包含相對路徑.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}

本節的程式碼範例使用 [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/)。

{{% /alert %}}

如果投影片中已嵌入 OLE 物件，您可以依照以下步驟存取並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例，載入簡報。
1. 依索引取得目標投影片。
1. 取得 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 形狀。
1. 取得 OLE 物件框架後，執行所需的操作。
1. 建立 `Workbook` 物件並讀取 OLE 資料。
1. 開啟目標 `Worksheet` 並編輯資料。
1. 將更新後的 `Workbook` 儲存至串流。
1. 使用該串流取代 OLE 物件的資料。

以下範例示範如何存取 OLE 物件框架（嵌入的 Excel 圖表），並修改其檔案資料以更新圖表。此範例使用先前建立、在第一張投影片上僅有單一形狀的 PPTX。

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # 將 OLE 物件資料讀取為 Workbook 物件。
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # 修改 Workbook 資料。
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # 變更 OLE 框架物件資料。
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **在投影片中嵌入檔案**

除了 Excel 圖表之外，Aspose.Slides for Python 也支援將其他檔案類型嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案插入為物件。使用者雙擊插入的物件時，系統會自動在關聯的應用程式中開啟，或提示使用者選擇適當的程式。

以下 Python 程式碼示範如何在投影片中嵌入 HTML 與 ZIP 檔案：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **設定嵌入物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不支援的 OLE 物件換成支援的。Aspose.Slides for Python 允許您設定嵌入物件的檔案類型，以便更新 OLE 框架資料或其副檔名。

以下 Python 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # 將檔案類型變更為 ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **設定嵌入物件的圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入以圖示為基礎的預覽。這個預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。若您想使用特定的影像與文字作為預覽，可透過 Aspose.Slides for Python 設定圖示影像與標題。

以下 Python 程式碼示範如何為嵌入物件設定圖示影像與標題：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # 將影像新增至簡報資源。
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # 為 OLE 預覽設定標題與影像。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **防止 OLE 物件框架被調整大小或重新定位**

在將已連結的 OLE 物件加入投影片後，開啟簡報時 PowerPoint 可能會提示您更新連結。若選取「更新連結」，PowerPoint 會重新整理預覽，可能會改變 OLE 物件框架的大小與位置。為避免 PowerPoint 提示您更新物件資料，請將 [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 類別的 `update_automatic` 屬性設為 `False`：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **擷取嵌入的檔案**

Aspose.Slides for Python 可讓您依下列方式擷取投影片中以 OLE 物件形式嵌入的檔案：

1. 建立包含欲擷取 OLE 物件之檔案的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別實例。
1. 逐一走訪簡報中的所有形狀，找出 OLEObjectFrame 形狀。
1. 從每個 [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) 取得嵌入檔案的資料，並寫入磁碟。

以下 Python 程式碼示範如何將投影片中以 OLE 物件形式嵌入的檔案擷取出來：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **常見問題**

**在匯出投影片為 PDF/影像時，會呈現 OLE 內容嗎？**

投影片上可見的部份會被渲染——即圖示或替代影像（預覽）。「即時」的 OLE 內容不會在渲染過程中執行。如有需要，請自行設定預覽影像，以確保匯出 PDF 時呈現預期外觀。

若亦需將嵌入檔案保留為 PDF 附件，請將 [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) 設為 `True`。此選項預設為停用。範例與檢查附件的方法請參閱 [Preserve Embedded OLE Files as PDF Attachments](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何鎖定投影片上的 OLE 物件，使使用者在 PowerPoint 中無法移動或編輯？**

鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/python-net/applying-protection-to-presentation/)。這不是加密，但可有效防止意外編輯與移動。

**為何已連結的 Excel 物件在開啟簡報時會「跳動」或尺寸變化？**

PowerPoint 可能會重新整理已連結 OLE 的預覽。若需穩定外觀，請遵循 [Working Solution for Worksheet Resizing](/slides/zh-hant/python-net/working-solution-for-worksheet-resizing/) 的做法——將框架調整至範圍大小，或將範圍縮放至固定框架，並設定適當的替代影像。

**在 PPTX 格式中，已連結 OLE 物件的相對路徑會被保留嗎？**

在 PPTX 中不會保留「相對路徑」資訊，只會保存完整路徑。相對路徑資訊僅存在於較舊的 PPT 格式。為確保可移植性，建議使用可靠的絕對路徑、可存取的 URI，或直接嵌入檔案。