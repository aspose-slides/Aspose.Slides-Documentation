---
title: 在 .NET 中優化簡報的圖片管理
linktitle: 管理圖片
type: docs
weight: 10
url: /zh-hant/net/image/
keywords:
- 新增圖片
- 新增圖片
- 新增點陣圖
- 替換圖片
- 替換圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 外部 SVG 資源
- SVG 解析器
- 連結的 SVG 圖片
- SVG 字型
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 簡化 PowerPoint 與 OpenDocument 的圖片管理，提升效能並自動化工作流程。"
---
## **簡介**

圖片使簡報更具吸引力且視覺上更佳。 在 Microsoft PowerPoint 中，您可以從檔案、網路或其他來源將圖片插入投影片。 同樣地，Aspose.Slides 允許您以多種方式將圖片加入簡報投影片。

{{% alert title="提示" color="info" %}} 
Aspose 提供免費的轉換工具——[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓您能快速從圖片建立簡報。 
{{% /alert %}} 

{{% alert title="資訊" color="info" %}}
如果您想將圖片作為圖片框添加——尤其是您計畫調整大小、套用效果或使用其他標準格式選項——請參閱 [圖片框](/slides/zh-hant/net/picture-frame/)。 
{{% /alert %}} 

{{% alert title="注意" color="warning" %}}
您可以將圖片從一種格式轉換為另一種格式。請參閱以下頁面：轉換 [影像轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/image-to-jpg/)、[JPG 轉 影像](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-image/)、[JPG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-png/)、[PNG 轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-jpg/)、[PNG 轉 SVG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-svg/)、以及 [SVG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/svg-to-png/)。
{{% /alert %}}

Aspose.Slides 支援常見的圖片格式，例如 JPEG、PNG、BMP、GIF 等等。

## **將本機儲存的圖片加入投影片**

您可以將儲存在電腦上的一張或多張圖片加入簡報投影片。以下 C# 範例程式碼示範如何將圖片加入投影片：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **從網路加入圖片至投影片**

如果您想要加入投影片的圖片未儲存在電腦上，您可以直接從網路加入。

以下 C# 範例程式碼示範如何從網路將圖片加入投影片：

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **將圖片加入投影片母片**

投影片母片會儲存並控制使用該母片之投影片的主題與版面配置等資訊。當您將圖片加入投影片母片時，該圖片會顯示在所有基於此母片的投影片上。

以下 C# 範例程式碼示範如何將圖片加入投影片母片：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **將圖片設為投影片背景**

您可以將圖片作為一張或多張投影片的背景。詳情請參閱 *[將圖片設為投影片背景](/slides/zh-hant/net/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 加入簡報**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/svgimage/) 類別將 SVG 內容加入簡報。產生的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 物件隨後可加入簡報的圖片集合，並用於建立圖片框。

以下 C# 範例匯入一個自包含的 SVG 字串。此 SVG 所使用的所有圖片、樣式及其他資源皆直接嵌入在 SVG 內容中。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **匯入含外部資源的 SVG 內容**

從設計工具、圖表編輯器、圖示系統與 Web 管線匯出的 SVG 檔案可能會參照儲存在 SVG 文件之外的資源。例如，SVG 可能包含像 `images/photo.png` 的圖片連結、CSS `url(...)` 值，或字型 URL。

若要匯入此類 SVG 內容，請建立 [IExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/iexternalresourceresolver/) 的實作，並連同基礎 URI 一起傳遞給適當的 `SvgImage` 建構函式。基礎 URI 用於識別 SVG 文件的位置，並用於解析相對連結。

此 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 介面提供取得匯入之 SVG 資訊的功能：

- `SvgContent` 會回傳 SVG 標記的字串。
- `SvgData` 會回傳 SVG 內容的位元組陣列。
- `BaseUri` 會回傳用於相對連結的基礎 URI。
- `ExternalResourceResolver` 會回傳指派給 SVG 圖片的解析器。

### **實作外部資源解析器**

此解析器有兩個方法：

- [ResolveUri](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) 結合基礎 URI 與相對資源連結，並回傳絕對 URI。當連結無法解析或不被允許時，回傳 `null`。
- [GetEntity](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/iexternalresourceresolver/getentity/) 為絕對資源 URI 回傳可讀取的串流。當資源遺失、被阻擋或無法取得時，回傳 `null`。在適當情況下亦可回傳備援串流。

以下解析器僅從允許的本機目錄載入連結資源。網路資源以及超出允許目錄的路徑將被阻擋。對於無法解析的圖片連結，會回傳可選的備援圖片。

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // 此解析器特意只允許本機檔案。
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // 僅對圖像資源使用備援。對缺少的字型或樣式表返回圖像串流不適用。
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **在 SVG 匯入期間解析連結資源**

假設 `assets/diagram.svg` 包含以下相對參照：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 C# 範例將 SVG 檔案的 URI 作為基礎 URI 並提供自訂解析器。解析器會將相對圖片連結轉換為絕對 URI，並在 Aspose.Slides 處理 SVG 時回傳包含連結資源的串流。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// 基礎 URI 代表 SVG 文件的位置。
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage 會公開來源內容、二進位資料、基礎 URI 與解析器。
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

`SvgImage` 類別亦提供接受 SVG 資料（以位元組陣列或串流形式）以及外部資源解析器和基礎 URI 的多載方法。

{{% alert title="重要" color="warning" %}}
資源解析器在 Aspose.Slides 處理與呈現 SVG 時，使外部資源可用。它不會修改原始 SVG 標記，也不會自動將解析後的資源嵌入其中。

當 `ISvgImage` 被加入簡報的圖片集合時，PPTX 檔案可能同時包含原始 SVG 表示與點陣備援圖片。連結資源可能出現在產生的備援圖片中，而像 `images/photo.png` 這樣的相對連結則在儲存的 SVG 中保持不變。若應用程式僅渲染原生 SVG 表示，則當原始外部資源不可用時，可能會省略該連結內容。
{{% /alert %}}

### **建立可攜式 SVG 圖片**

若要建立不依賴外部檔案的 SVG 圖片，請在建立 `SvgImage` 前先讓 SVG 成為自包含。舉例來說，將連結的圖片 URL 替換為包含圖片資料的 `data:` URI：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必要資源嵌入 SVG 內容後，建立 `SvgImage`、將其加入簡報的圖片集合，並如先前範例所示插入圖片框中。

### **處理缺失或被阻擋的資源**

當資源 URI 無效、被禁止或無法解析時，於 `ResolveUri` 回傳 `null`。當資源無法讀取時，於 `GetEntity` 回傳 `null`。在可能的情況下，Aspose.Slides 會在缺少該資源的情形下繼續處理 SVG。

對於缺失的資源可回傳備援串流，但其內容必須與請求的資源類型相容。例如，僅對缺少的圖片回傳圖片串流，不能用於字型或樣式表。

{{% alert title="安全" color="warning" %}}
請勿從不受信任的 SVG 檔案解析任意檔案路徑或不受限制的網路 URL。應限制允許的協定、目錄與主機。對於網路資源，亦需套用連線逾時、回應大小限制與內容驗證。
{{% /alert %}}

## **將 SVG 轉換為形狀集合**

Aspose.Slides 可以將 SVG 轉換為形狀集合，類似於 PowerPoint 中的相應功能：

![PowerPoint 彈出選單](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection) 介面的 [AddGroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 方法的多載提供，該多載的第一個參數接受 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage) 物件。

以下 C# 範例程式碼示範如何使用此方法將 SVG 檔案轉換為形狀集合：

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 來源 SVG 檔案名稱
string svgFileName = "sample.svg";

// 輸出簡報檔案名稱
string outPptxPath = "presentation.pptx";

// 建立新的簡報
using (IPresentation presentation = new Presentation())
{
    // 讀取 SVG 檔案內容
    string svgContent = File.ReadAllText(svgFileName);

    // 建立 SvgImage 物件
    ISvgImage svgImage = new SvgImage(svgContent);

    // 取得投影片大小
    SizeF slideSize = presentation.SlideSize.Size;

    // 將 SVG 圖片轉換為形狀群組並縮放至投影片大小
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 以 PPTX 格式儲存簡報
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **將圖片以 EMF 加入投影片**

Aspose.Slides for .NET 允許您使用 Aspose.Cells 從 Excel 工作表產生 EMF 圖片，並將其加入簡報投影片。

以下 C# 範例程式碼示範如何執行此操作：

``` csharp
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // 將工作簿儲存到串流
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **取代圖片集合中的圖片**

Aspose.Slides 允許您取代儲存在簡報圖片集合中的圖片，包括投影片形狀所使用的圖片。本節說明多種更新集合中圖片的方法。您可以使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 實例，或集合中已存在的其他圖片來取代圖片。

請依照以下步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入包含圖片的簡報檔案。  
2. 從檔案載入新圖片至位元組陣列。  
3. 使用位元組陣列將目標圖片替換為新圖片。  
4. 在第二種做法中，將圖片載入 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件，並以該物件取代目標圖片。  
5. 在第三種做法中，以簡報的圖片集合中已存在的圖片取代目標圖片。  
6. 將修改後的簡報寫入為 PPTX 檔案。  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示簡報檔案的 Presentation 類別。
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

// 將簡報儲存至檔案。
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="資訊" color="info" %}}
使用 Aspose 提供的免費 [文字轉 GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字製作動畫並產生 GIF。 
{{% /alert %}}

## **常見問答**

**插入後原始圖片解析度是否保持不變？**  
是的。會保留來源像素，但最終呈現取決於投影片上 [圖片](/slides/zh-hant/net/picture-frame/) 的縮放方式以及儲存時的壓縮情況。

**一次性在多張投影片中取代相同標誌的最佳方法是什麼？**  
將標誌放在母片或版面配置上，然後在簡報的圖片集合中取代它——所有使用該資源的元件都會自動更新。

**插入的 SVG 能否轉換為可編輯的形狀？**  
可以。您可以將 SVG 轉換為一組形狀，之後各個部件即可使用標準形狀屬性進行編輯。

**如何一次性將圖片設為多張投影片的背景？**  
[將圖片指定為背景](/slides/zh-hant/net/presentation-background/) 放在母片或相關版面配置上——使用該母片/版面的投影片都會繼承此背景。

**如何防止簡報因大量圖片而變得過大？**  
重複使用單一圖片資源而非多個副本，選擇適當的解析度，儲存時使用壓縮，並在適當情況下將重複的圖形放在母片上。