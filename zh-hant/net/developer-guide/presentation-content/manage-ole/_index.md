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
- 新增 物件
- 嵌入 物件
- 新增 檔案
- 嵌入 檔案
- 連結 物件
- 連結 檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 抽取 OLE
- 抽取 物件
- 抽取 檔案
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 優化在 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}

OLE（Object Linking & Embedding）是 Microsoft 的技術，可讓在一個應用程式中建立的資料與物件，透過連結或嵌入的方式放置到另一個應用程式中。

{{% /alert %}} 

想像在 MS Excel 中建立的圖表，接著將該圖表放入 PowerPoint 投影片中。此 Excel 圖表即視為 OLE 物件。

- OLE 物件可能顯示為圖示。此時，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選取要開啟或編輯物件的應用程式。  
- OLE 物件也可能直接顯示實際內容，例如圖表本身。此時，圖表在 PowerPoint 中被啟動，圖表介面載入，您即可在 PowerPoint 內修改圖表資料。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) 允許您將 OLE 物件插入投影片，作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)）。

## **將 OLE 物件框架加入投影片**

假設您已在 Microsoft Excel 中建立圖表，想使用 Aspose.Slides for .NET 將其以 OLE 物件框架的方式嵌入投影片，可依下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將 Excel 檔案讀取為位元組陣列。  
4. 將 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 加入投影片，並提供位元組陣列及其他 OLE 物件資訊。  
5. 將已修改的簡報寫出為 PPTX 檔案。

在下方範例中，我們使用 Aspose.Slides for .NET，將 Excel 檔案中的圖表以 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 的形式加入投影片。  
**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) 建構函式接受可嵌入物件的副檔名作為第二個參數。此副檔名可讓 PowerPoint 正確辨識檔案類型，並選擇正確的應用程式開啟此 OLE 物件。

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

    // 將 OLE 物件框架新增至投影片。
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **新增連結的 OLE 物件框架**

Aspose.Slides for .NET 允許您新增一個 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)，不嵌入資料，而僅以檔案連結的方式呈現。

以下 C# 程式碼示範如何將帶有連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 加入投影片：

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增一個帶有連結 Excel 檔案的 OLE 物件框架。
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **存取 OLE 物件框架**

若 OLE 物件已嵌入投影片，您可以依下列方式輕鬆找到或存取它：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例，載入包含嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參考。  
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 形狀。  
   在本範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe)。這就是要存取的目標 OLE 物件框架。  
4. 取得 OLE 物件框架後，您即可對其執行任何操作。

以下範例示範如何存取一個 OLE 物件框架（嵌入於投影片的 Excel 圖表）及其檔案資料。

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 取得第一個形狀作為 OLE 物件框架。
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // 取得嵌入檔案資料。
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // 取得嵌入檔案的副檔名。
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **存取連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取連結 OLE 物件框架的屬性。

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

        // 如有存在，列印連結檔案的相對路徑。
        // 只有 PPT 簡報會包含相對路徑。
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}

本節的程式碼範例使用 [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/)。

{{% /alert %}}

若 OLE 物件已嵌入投影片，您可以依以下步驟存取該物件並修改其資料：

1. 透過建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別的實例，載入包含嵌入 OLE 物件的簡報。  
2. 使用索引取得投影片的參考。  
3. 存取 [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 形狀。  
   在本範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe)。這就是要存取的目標 OLE 物件框架。  
4. 取得 OLE 物件框架後，您即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流。  
8. 從串流變更 OLE 物件資料。

以下範例示範如何存取一個 OLE 物件框架（嵌入於投影片的 Excel 圖表），並修改其檔案資料以更新圖表資料。

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
            // 以 Workbook 物件讀取 OLE 物件資料。
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

除了 Excel 圖表外，Aspose.Slides for .NET 亦允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。當使用者雙擊插入的物件時，會自動在相關程式中開啟，或提示使用者選取適當的程式開啟。

以下 C# 程式碼示範如何將 HTML 與 ZIP 嵌入投影片：

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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不受支援的 OLE 物件換成受支援的。Aspose.Slides for .NET 允許您設定嵌入物件的檔案類型，從而更新 OLE 框架資料或其副檔名。

以下 C# 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

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

## **為嵌入物件設定圖示影像與標題**

嵌入 OLE 物件後，系統會自動加入包含圖示影像的預覽。此預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。如果您想使用特定的影像與文字作為預覽元素，可透過 Aspose.Slides for .NET 設定圖示影像與標題。

以下 C# 程式碼示範如何為嵌入物件設定圖示影像與標題：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // 將影像新增至簡報資源中。
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // 設定 OLE 預覽的標題與影像。
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **防止 OLE 物件框架被調整大小與重新定位**

當您將連結的 OLE 物件加入簡報投影片後，於 PowerPoint 開啟簡報時可能會看到訊息要求更新連結。點選「更新連結」按鈕可能會因 PowerPoint 從連結 OLE 物件更新資料並重新整理預覽，而改變 OLE 物件框架的大小與位置。若要防止 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) 介面的 `UpdateAutomatic` 屬性設定為 `false`：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // 在 PowerPoint 更新連結時，保持 OLE 物件框架的大小與位置。
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **擷取嵌入檔案**

Aspose.Slides for .NET 允許您依以下方式擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立包含欲擷取 OLE 物件的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 類別實例。  
2. 迭代簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) 形狀。  
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

以下 C# 程式碼示範如何將投影片中嵌入的檔案作為 OLE 物件擷取：

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

## **常見問答**

**在將投影片匯出為 PDF/圖片時，會渲染 OLE 內容嗎？**

會渲染投影片上可見的部分——圖示/替代影像（預覽）。「即時」的 OLE 內容在渲染過程中不會被執行。如有需要，可自行設定預覽影像，以確保匯出 PDF 時的外觀符合預期。

若同時希望將嵌入檔案作為 PDF 附件保留，請將 [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) 設為 `true`。此選項預設為關閉。相關範例與檢查附件的說明請參考 [Preserve Embedded OLE Files as PDF Attachments](/slides/zh-hant/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何在投影片上鎖定 OLE 物件，使使用者無法在 PowerPoint 中移動或編輯？**

鎖定形狀：Aspose.Slides 提供[形狀層級的鎖定](/slides/zh-hant/net/applying-protection-to-presentation/)。這不是加密，但可有效防止意外的編輯與移動。

**為何連結的 Excel 物件在開啟簡報時會「跳動」或改變大小？**

PowerPoint 可能會重新整理連結 OLE 的預覽。若需穩定外觀，請遵循[Worksheet Resizing 的工作解決方案](/slides/zh-hant/net/working-solution-for-worksheet-resizing/)——將框架調整至與範圍相符，或將範圍縮放至固定框架並設定適當的替代影像。

**在 PPTX 格式中，連結 OLE 物件的相對路徑會被保留嗎？**

在 PPTX 中不會保留「相對路徑」資訊——僅有完整路徑。相對路徑僅出現在較舊的 PPT 格式。為了可移植性，建議使用可靠的絕對路徑/可存取的 URI 或直接嵌入。