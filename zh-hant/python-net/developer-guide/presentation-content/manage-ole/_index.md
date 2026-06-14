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
- 新增 物件
- 嵌入 物件
- 新增 檔案
- 嵌入 檔案
- 已連結 物件
- 已連結 檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 擷取 OLE
- 擷取 物件
- 擷取 檔案
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 優化 PowerPoint 和 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新及匯出 OLE 內容。"
---
## **介紹**

{{% alert title="資訊" color="info" %}}

**OLE（Object Linking & Embedding）** 是 Microsoft 的技術，可讓在一個應用程式中建立的資料與物件，連結或嵌入至另一個應用程式。

{{% /alert %}}

例如，在 Microsoft Excel 中建立的圖表放到 PowerPoint 投影片上，就是一個 OLE 物件。

- OLE 物件可能以圖示顯示。雙擊圖示會在其關聯的應用程式（例如 Excel）中開啟物件，或提示您選擇應用程式以開啟或編輯。
- OLE 物件也可能直接顯示其內容（例如圖表）。此時，PowerPoint 會啟動嵌入的物件，載入圖表介面，並允許您在 PowerPoint 內編輯圖表資料。

Aspose.Slides for Python 讓您將 OLE 物件以 OLE 物件框（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/)）插入投影片。

## **將 OLE 物件加入投影片**

如果您已在 Microsoft Excel 中建立圖表，並想使用 Aspose.Slides for Python 以 OLE 物件框的方式嵌入至投影片，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 將 Excel 檔案讀取為位元組陣列。
1. 將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 加入投影片，提供位元組陣列及其他 OLE 物件細節。
1. 將修改後的簡報另存為 PPTX 檔案。

以下範例示範將 Excel 檔案中的圖表嵌入投影片，作為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/)。

**注意：**[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) 的建構式在第二個參數接受可嵌入物件的檔案副檔名。PowerPoint 會利用此副檔名辨識檔案類型，並選取適當的應用程式開啟 OLE 物件。

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # 為 OLE 物件準備資料。
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # 將 OLE 物件框加入投影片。
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **加入連結的 OLE 物件**

Aspose.Slides for Python 允許您加入指向檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/)，而非嵌入其資料。

以下 Python 範例示範如何在投影片上加入連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/)：

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 加入帶有連結 Excel 檔案的 OLE 物件框。
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **存取 OLE 物件**

如果投影片中已嵌入 OLE 物件，您可以依下列方式存取：

1. 以建立 Presentation 類別的實例方式載入包含嵌入 OLE 物件的簡報。
1. 依索引取得投影片參考。
1. 存取 OleObjectFrame 形狀。
1. 取得 OLE 物件框後，對其執行任何所需的操作。

以下範例存取 OLE 物件框──一個嵌入的 Excel 圖表──並取得其檔案資料。此範例使用第一張投影片上僅有單一形狀的 PPTX。

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 取得嵌入檔案的資料。
        file_data = ole_frame.embedded_data.embedded_file_data

        # 取得嵌入檔案的副檔名。
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **存取連結 OLE 物件屬性**

Aspose.Slides 允許您存取連結 OLE 物件框的屬性。

下面的 Python 範例檢查 OLE 物件是否為連結，若是，則取得連結檔案的路徑：

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # 檢查 OLE 物件是否為連結。
        if ole_frame.is_object_link:
            # 印出連結檔案的完整路徑。
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # 印出連結檔案的相對路徑（若存在）。
            # 僅 .ppt 簡報可以包含相對路徑。
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **變更 OLE 物件資料**

{{% alert color="primary" %}}

本節的程式碼範例使用 [Aspose.Cells for Python via .NET](/cells/python-net/)。

{{% /alert %}}

如果 OLE 物件已嵌入投影片，您可以存取並修改其資料，步驟如下：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例方式載入簡報。
1. 依索引取得目標投影片。
1. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 形狀。
1. 取得 OLE 物件框後，對其執行所需操作。
1. 建立 `Workbook` 物件並讀取 OLE 資料。
1. 開啟目標 `Worksheet` 並編輯資料。
1. 將更新後的 `Workbook` 儲存至串流。
1. 使用該串流取代 OLE 物件的資料。

以下範例存取一個 OLE 物件框（嵌入的 Excel 圖表），並修改其檔案資料以更新圖表。範例使用先前建立的、第一張投影片上僅有單一形狀的 PPTX。

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
            # 以 Workbook 物件讀取 OLE 物件資料。
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # 修改工作簿資料。
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # 更改 OLE 框物件資料。
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **在投影片中嵌入檔案**

除了 Excel 圖表之外，Aspose.Slides for Python 還允許您在投影片中嵌入其他類型檔案。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。使用者雙擊插入的物件時，會自動在關聯的應用程式中開啟，或提示使用者選擇適當的程式。

以下 Python 程式碼示範如何在投影片中嵌入 HTML 與 ZIP 檔案：

```py
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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不支援的 OLE 物件換成支援的。Aspose.Slides for Python 讓您設定嵌入物件的檔案類型，從而更新 OLE 框資料或其檔案副檔名。

以下 Python 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # 將檔案類型變更為 ZIP。
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **設定嵌入物件的圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入以圖示為基礎的預覽。此預覽是使用者在存取或開啟 OLE 物件前看到的畫面。若您想在預覽中使用特定圖片與文字，可透過 Aspose.Slides for Python 設定圖示影像與標題。

以下 Python 程式碼示範如何為嵌入物件設定圖示影像與標題：

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # 將圖片加入簡報資源。
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # 設定 OLE 預覽的標題與圖片。
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **防止 OLE 物件框被重新調整大小與重新定位**

將連結 OLE 物件加入投影片後，開啟簡報時 PowerPoint 可能會提示您更新連結。若選取「更新連結」，PowerPoint 會以連結物件的資料重新整理預覽，從而改變 OLE 物件框的大小與位置。若要防止 PowerPoint 提示您更新物件資料，請將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 類別的 `update_automatic` 屬性設定為 `False`：

```py
ole_frame.update_automatic = False
```

## **擷取嵌入的檔案**

Aspose.Slides for Python 讓您依下列步驟擷取投影片中以 OLE 物件形式嵌入的檔案：

1. 建立包含欲擷取 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別實例。
1. 逐一遍歷簡報中的所有形狀，找出 OLEObjectFrame 形狀。
1. 從每個 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/oleobjectframe/) 取得嵌入檔案資料，並寫入磁碟。

以下 Python 程式碼示範如何擷取投影片中以 OLE 物件嵌入的檔案：

```py
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

## **常見問題集**

**匯出投影片為 PDF／影像時，會呈現 OLE 內容嗎？**

會渲染投影片上可見的部分──圖示或替代影像（預覽）。「即時」的 OLE 內容在渲染過程中不會被執行。若有需要，可自行設定預覽影像，以確保匯出 PDF 時的外觀符合預期。

**如何在投影片上鎖定 OLE 物件，使使用者無法在 PowerPoint 中移動或編輯？**

鎖定形狀：Aspose.Slides 提供[形狀層級的鎖定](/slides/zh-hant/python-net/applying-protection-to-presentation/)。這不是加密，只是防止意外編輯與移動。

**為何連結的 Excel 物件在開啟簡報時會「跳動」或變更大小？**

PowerPoint 可能會重新整理連結 OLE 的預覽。為獲得穩定外觀，請遵循[工作表重新調整大小的解決方案](/slides/zh-hant/python-net/working-solution-for-worksheet-resizing/)，將框架調整至範圍，或將範圍縮放至固定框架並設定適當的替代影像。

**PPTX 格式會保留連結 OLE 物件的相對路徑嗎？**

在 PPTX 中，僅保存完整路徑，沒有「相對路徑」資訊。相對路徑僅在舊版 PPT 格式中存在。為了攜帶性，建議使用可靠的絕對路徑、可存取的 URI，或直接嵌入檔案。