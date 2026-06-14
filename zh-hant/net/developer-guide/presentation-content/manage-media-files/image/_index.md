---
title: 在 .NET 中優化簡報的圖像管理
linktitle: 管理圖像
type: docs
weight: 10
url: /zh-hant/net/image/
keywords:
- 新增圖像
- 新增圖片
- 新增位圖
- 替換圖像
- 替換圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 簡化 PowerPoint 與 OpenDocument 中的圖像管理，優化效能並自動化工作流程。"
---
## **簡介**

圖像使簡報更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以從檔案、網際網路或其他位置將圖片插入投影片。類似地，Aspose.Slides 允許您通過不同的方式將圖像添加到簡報的投影片中。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免費轉換器——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能夠快速從圖像建立簡報。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想將圖像作為框架物件添加——尤其是計畫使用標準格式化選項變更其大小、添加效果等——請參閱 [圖片框架](https://docs.aspose.com/slides/zh-hant/net/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以操作涉及圖像和 PowerPoint 簡報的輸入/輸出，以將圖像從一種格式轉換為另一種格式。請參閱以下頁面：轉換 [圖像至 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/image-to-jpg/); 轉換 [JPG 至圖像](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-image/); 轉換 [JPG 至 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-png/), 轉換 [PNG 至 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-jpg/); 轉換 [PNG 至 SVG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-svg/), 轉換 [SVG 至 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides 支援這些常見格式的圖像操作：JPEG、PNG、BMP、GIF 等。 

## **將本機儲存的圖像添加至投影片**

您可以將電腦上的一張或多張圖像添加到簡報的投影片中。以下 C# 範例程式碼示範如何將圖像添加至投影片：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **從網路將圖像添加至投影片**

如果您想要添加至投影片的圖像在電腦上不存在，您可以直接從網路添加圖像。 
以下範例程式碼示範如何在 C# 中從網路將圖像添加至投影片：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **將圖像添加至投影片主版**

投影片主版是位於最上層的投影片，用於儲存與控制其下所有投影片的資訊（主題、版面配置等）。因此，當您將圖像添加至投影片主版時，該圖像會出現在該主版下的所有投影片上。 
以下 C# 範例程式碼示範如何將圖像添加至投影片主版：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **將圖像設為投影片背景**

您可能會決定將圖片用作特定投影片或多張投影片的背景。在此情況下，請參閱 *[將圖像設為投影片背景](https://docs.aspose.com/slides/zh-hant/net/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 添加至簡報**

您可以使用屬於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection) 介面的 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/methods/addpictureframe) 方法，將任意圖像添加或插入至簡報中。 
若要根據 SVG 圖像建立圖像物件，您可以這樣做： 
1. 建立 SvgImage 物件以插入至 ImageShapeCollection 
2. 從 ISvgImage 建立 PPImage 物件 
3. 使用 IPPImage 介面建立 PictureFrame 物件 
以下範例程式碼示範如何實作上述步驟，將 SVG 圖像添加至簡報中：

``` csharp 
// 文件目錄的路徑
string dataDir = @"D:\Documents\";

// 原始 SVG 檔案名稱
string svgFileName = dataDir + "sample.svg";

// 輸出簡報檔案名稱
string outPptxPath = dataDir + "presentation.pptx";

// 建立新簡報
using (var p = new Presentation())
{
    // 讀取 SVG 檔案內容
    string svgContent = File.ReadAllText(svgFileName);

    // 建立 SvgImage 物件
    ISvgImage svgImage = new SvgImage(svgContent);

    // 建立 PPImage 物件
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // 建立新的圖片框架 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // 以 PPTX 格式儲存簡報
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **將 SVG 轉換為形狀集合**

Aspose.Slides 將 SVG 轉換為形狀集合的功能類似於 PowerPoint 用於處理 SVG 圖像的功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection) 介面的 [AddGroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 方法的其中一個重載提供，該重載以 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage) 物件作為第一個參數。 
以下範例程式碼示範如何使用上述方法將 SVG 檔案轉換為形狀集合：

``` csharp 
// 文件目錄的路徑
string dataDir = @"D:\Documents\";

// 原始 SVG 檔案名稱
string svgFileName = dataDir + "sample.svg";

// 輸出簡報檔案名稱
string outPptxPath = dataDir + "presentation.pptx";

// 建立新簡報
using (IPresentation presentation = new Presentation())
{
    // 讀取 SVG 檔案內容
    string svgContent = File.ReadAllText(svgFileName);

    // 建立 SvgImage 物件
    ISvgImage svgImage = new SvgImage(svgContent);

    // 取得投影片大小
    SizeF slideSize = presentation.SlideSize.Size;

    // 將 SVG 圖片轉換為形狀群組，並按投影片大小縮放
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 以 PPTX 格式儲存簡報
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **將圖像作為 EMF 添加至投影片**

Aspose.Slides for .NET 允許您從 Excel 工作表生成 EMF 圖像，並使用 Aspose.Cells 將這些圖像作為 EMF 添加至投影片中。 
以下範例程式碼示範如何執行上述任務：

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //將工作簿儲存至串流
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **取代圖像集合中的圖像**

Aspose.Slides 允許您取代儲存在簡報圖像集合中的圖像（包括投影片形狀使用的圖像）。本節展示了更新集合中圖像的多種方法。API 提供直接的方式，可使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 實例，或集合中已存在的其他圖像來取代圖像。 
請依照以下步驟： 
1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入包含圖像的簡報檔案。 
2. 從檔案載入新圖像至位元組陣列。 
3. 使用位元組陣列將目標圖像取代為新圖像。 
4. 在第二種方法中，將圖像載入 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件，並使用該物件取代目標圖像。 
5. 在第三種方法中，使用簡報圖像集合中已存在的圖像取代目標圖像。 
6. 將修改後的簡報寫入為 PPTX 檔案。 
```cs
// 實例化代表簡報檔案的 Presentation 類別。
using Presentation presentation = new Presentation("sample.pptx");

// 第一種方法。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 第二種方法。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 第三種方法。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// 將簡報儲存為檔案。
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}
使用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆地對文字進行動畫化、從文字建立 GIF 等。 
{{% /alert %}}

## **常見問題**

**插入後原始圖像解析度是否保持完整？**

是。保留原始像素，但最終顯示效果取決於投影片上 [picture](/slides/zh-hant/net/picture-frame/) 的縮放方式以及儲存時所套用的壓縮。 

**一次取代數十張投影片中的相同標誌的最佳方法是什麼？**

將標誌放置於主投影片或版面配置上，並在簡報的圖像集合中取代它——更新將會傳播到所有使用該資源的元素。 

**插入的 SVG 可以轉換為可編輯的形狀嗎？**

可以。您可以將 SVG 轉換為形狀群組，之後各個部件即可使用標準形狀屬性進行編輯。 

**如何一次為多張投影片設定圖片背景？**

在主投影片或相關版面配置上 [Assign the image as the background](/slides/zh-hant/net/presentation-background/)，使用該主版/版面的投影片皆會繼承此背景。 

**如何防止因大量圖片導致簡報檔案尺寸急遽增大？**

重複使用單一圖像資源而非多次複製，選擇合理的解析度，儲存時套用壓縮，並在適當情況下將重複圖形放置於主投影片上。