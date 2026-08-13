---
title: 在 .NET 中管理簡報的 OLE 物件
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/net/manage-ole/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 優化在 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫地嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert title="Info" color="info" %}}

OLE（Object Linking & Embedding）是 Microsoft 的一項技術，允許在一個應用程式中建立的資料與物件透過連結或嵌入的方式放入另一個應用程式。

{{% /alert %}} 

想像在 MS Excel 中建立的圖表，然後將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。

- OLE 物件可能顯示為圖示。此情況下，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選取開啟或編輯該物件的應用程式。
- OLE 物件也可能直接顯示實際內容，例如圖表本身。此時圖表在 PowerPoint 中被啟動，圖表介面載入，您可以直接在 PowerPoint 內修改圖表資料。

[Aspose.Slides for .NET](https://products.aspose.com/slides/zh-hant/net/) 允許您將 OLE 物件插入投影片，作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe)）。

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並想使用 Aspose.Slides for .NET 將其以 OLE 物件框架的形式嵌入投影片，您可以依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 將 Excel 檔案讀取為位元組陣列。
4. 將 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe) 加入投影片，並提供位元組陣列及其他 OLE 物件資訊。
5. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們使用 Aspose.Slides for .NET，將 Excel 檔案中的圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe) 的方式加入投影片。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.dom.ole/oleembeddeddatainfo/) 建構式的第二個參數為可嵌入物件的副檔名。此副檔名讓 PowerPoint 能正確判斷檔案類型，並選擇適當的應用程式開啟此 OLE 物件。

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // 為 OLE 物件準備資料。
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // 將 OLE 物件框架新增到投影片。
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **新增連結的 OLE 物件框架**

Aspose.Slides for .NET 允許您新增一個不嵌入資料、僅以檔案連結方式的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe)。

以下 C# 程式碼示範如何在投影片中加入連結到 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe)：

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增一個連結的 Excel 檔案的 OLE 物件框架。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **存取 OLE 物件框架**

如果投影片中已經嵌入 OLE 物件，您可以這樣輕鬆找到或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，載入包含嵌入 OLE 物件的簡報。
2. 使用索引取得投影片的參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe) 形狀。  
   在本範例中，我們使用先前建立的 PPTX（第一張投影片僅有一個形狀），然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe)。這就是我們要存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您可以對其執行任何操作。

以下範例展示如何存取 OLE 物件框架（嵌入於投影片的 Excel 圖表物件）以及其檔案資料。

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得第一個形狀作為 OLE 物件框架。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 取得嵌入檔案的資料。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 取得嵌入檔案的副檔名。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **存取連結的 OLE 物件框架屬性**

Aspose.Slides 允許您存取連結的 OLE 物件框架屬性。

以下 C# 程式碼示範如何檢查 OLE 物件是否為連結，並取得連結檔案的路徑：

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // 取得第一個形狀作為 OLE 物件框架。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // 檢查 OLE 物件是否為連結。
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // 列印連結檔案的完整路徑。
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // 若存在，列印連結檔案的相對路徑。
        // 僅 PPT 簡報可以包含相對路徑。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **變更 OLE 物件資料**

{{% alert color="info" %}} 

在本節中，以下程式碼範例使用 [Aspose.Cells for .NET](/cells/net/)。

{{% /alert %}}

如果投影片中已經嵌入 OLE 物件，您可以依照以下步驟存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例，載入包含嵌入 OLE 物件的簡報。
2. 透過索引取得投影片的參考。 
3. 存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe) 形狀。  
   在本範例中，我們使用先前建立的 PPTX（第一張投影片僅有一個形狀），然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe)。這就是我們要存取的 OLE 物件框架。
4. 取得 OLE 物件框架後，您可以對其執行任何操作。
5. 建立 `Workbook` 物件並存取 OLE 資料。
6. 取用目標 `Worksheet` 並修改資料。
7. 將更新後的 `Workbook` 儲存至流 (stream)。
8. 從流中變更 OLE 物件資料。

以下範例示範如何存取嵌入於投影片的 OLE 物件框架（Excel 圖表），並修改其檔案資料以更新圖表資料。

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得第一個形狀作為 OLE 物件框架。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // 讀取 OLE 物件資料為 Workbook 物件。
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // 修改工作簿資料。
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // 變更 OLE 框架的物件資料。
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for .NET 還允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。使用者雙擊插入的物件時，會自動以相關程式開啟，或提示使用者選取適當的程式。

以下 C# 程式碼示範如何將 HTML 與 ZIP 檔案嵌入投影片：

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **設定嵌入物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不支援的 OLE 物件換成支援的類型。Aspose.Slides for .NET 允許您設定嵌入物件的檔案類型，從而更新 OLE 框架的資料或副檔名。

以下 C# 程式碼示範如何將嵌入的 OLE 物件檔案類型設定為 `zip`：

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // 將檔案類型變更為 ZIP。
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **為嵌入物件設定圖示與標題**

嵌入 OLE 物件後，系統會自動加入由圖示組成的預覽畫面。這是使用者在開啟或存取 OLE 物件前看到的內容。若您想使用特定圖像與文字作為預覽元素，可透過 Aspose.Slides for .NET 設定圖示與標題。

以下 C# 程式碼示範如何為嵌入的物件設定圖示與標題：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // 新增影像至簡報資源。
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // 設定 OLE 預覽的標題與影像。
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **防止 OLE 物件框架被重新調整大小或重新定位**

將連結的 OLE 物件加入投影片後，於 PowerPoint 開啟簡報時可能會出現「更新連結」的訊息。點選「Update Links」按鈕會導致 OLE 物件框架的大小與位置改變，因為 PowerPoint 會從連結的 OLE 物件更新資料並重新整理預覽。若要防止 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleobjectframe/) 介面的 `UpdateAutomatic` 屬性設為 `false`：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // 在 PowerPoint 更新連結時保持 OLE 物件框架的大小與位置。
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **擷取嵌入的檔案**

Aspose.Slides for .NET 允許您依照以下方式擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立包含欲擷取 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別實例。
2. 迭代簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/oleobjectframe) 形狀。
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

以下 C# 程式碼示範如何擷取投影片中以 OLE 物件形式嵌入的檔案：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **常見問題 (FAQ)**

### 匯出投影片為 PDF/影像時，OLE 內容會被渲染嗎？

投影片上可見的部分會被渲染——即圖示或替代圖像（預覽）。「即時」的 OLE 內容不會在渲染過程中執行。若需要確保匯出 PDF 的外觀，請自行設定預覽圖像。

### 如何在投影片上鎖定 OLE 物件，使使用者在 PowerPoint 中無法移動或編輯？

鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/net/applying-protection-to-presentation/)。這不是加密，但可有效防止意外的編輯與移動。

### 為什麼連結的 Excel 物件在開啟簡報時會「跳動」或變更大小？

PowerPoint 可能會重新整理連結 OLE 的預覽。若要保持穩定外觀，請參考 [Worksheet Resizing 的作業解決方案](/slides/zh-hant/net/working-solution-for-worksheet-resizing/)，將框架調整至範圍，或將範圍縮放至固定框架，並設定適當的替代圖像。

### PPTX 格式會保留連結 OLE 物件的相對路徑嗎？

在 PPTX 中不支援「相對路徑」資訊——僅儲存完整路徑。相對路徑僅在舊版 PPT 格式中出現。為提升可移植性，建議使用可靠的絕對路徑/可存取的 URI，或直接嵌入檔案。