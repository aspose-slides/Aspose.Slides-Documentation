---
title: 在 .NET 中優化簡報的圖像管理
linktitle: 管理圖像
type: docs
weight: 10
url: /zh-hant/net/image/
keywords:
- 新增圖像
- 新增圖片
- 新增點陣圖
- 替換圖像
- 替換圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 外部 SVG 資源
- SVG 解析器
- 已連結的 SVG 圖像
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
description: "使用 Aspose.Slides for .NET 簡化 PowerPoint 與 OpenDocument 的圖像管理，優化效能並自動化工作流程。"
---
## **簡介**

圖像讓簡報更具吸引力且視覺上更佳。 在 Microsoft PowerPoint 中，您可以從檔案、網路或其他來源將圖片插入投影片。 同樣地，Aspose.Slides 允許您以多種方式向簡報投影片新增圖像。

{{% alert  title="提示" color="primary" %}} 
Aspose 提供免費的轉換器 —[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt) —可讓您快速從圖像建立簡報。 
{{% /alert %}} 

{{% alert title="資訊" color="info" %}}
如果您想將圖像作為圖片框新增——特別是當您計畫調整大小、套用效果或使用其他標準格式設定時——請參閱 [Picture Frame](/slides/zh-hant/net/picture-frame/)。 
{{% /alert %}} 

{{% alert title="注意" color="warning" %}}
您可以將圖像從一種格式轉換為另一種格式。請參閱以下頁面：轉換 [影像轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/image-to-jpg/)、[JPG 轉影像](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-image/)、[JPG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-png/)、[PNG 轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-jpg/)、[PNG 轉 SVG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-svg/)、以及 [SVG 轉 PNG](https://products.aspose.com/slides/zh-hant/net/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides 支援 JPEG、PNG、BMP、GIF 等常見格式的圖像。 

## **將本機儲存的圖像新增至投影片**

您可以將電腦上儲存的一張或多張圖像新增至簡報投影片。以下 C# 範例程式碼示範如何將圖像新增至投影片：

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

## **從網路新增圖像至投影片**

如果您想新增至投影片的圖像未儲存在電腦上，您可以直接從網路新增。

以下 C# 範例程式碼示範如何從網路將圖像新增至投影片：

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

## **將圖像新增至投影片母片**

投影片母片儲存並控制使用該母片的投影片之主題與版面配置等資訊。當您將圖像新增至投影片母片時，該圖像會出現在所有基於該母片的投影片上。

以下 C# 範例程式碼示範如何將圖像新增至投影片母片：

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

## **將圖像設定為投影片背景**

您可以將圖片作為一或多張投影片的背景。詳情請參閱 *[Setting Images as Backgrounds for Slides](/slides/zh-hant/net/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 新增至簡報**

可使用 [SvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/svgimage/) 類別將 SVG 內容加入簡報。產生的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 物件隨後可加入簡報的圖像集合，並用於建立圖片框。

以下 C# 範例匯入一段自包含的 SVG 字串。此 SVG 內嵌了所有圖像、樣式與其他資源。

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

從設計工具、圖表編輯器、圖示系統與 Web 管線匯出的 SVG 檔案可能會參照儲存在 SVG 文件之外的資源。例如，SVG 可能包含 `images/photo.png` 的圖像連結、CSS `url(...)` 值或字型 URL。

要匯入此類 SVG 內容，請建立一個 [IExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/iexternalresourceresolver/) 實作，並將其與基礎 URI 一併傳遞給相應的 `SvgImage` 建構函式。基礎 URI 用於辨識 SVG 文件所在位置，並用於解析相對連結。

[ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 介面提供取得匯入 SVG 資訊的功能：

- `SvgContent` 以字串形式返回 SVG 標記。
- `SvgData` 以位元組陣列形式返回 SVG 內容。
- `BaseUri` 返回用於相對連結的基礎 URI。
- `ExternalResourceResolver` 返回指派給 SVG 圖像的解析器。

### **實作外部資源解析器**

解析器具備兩個方法：

- [ResolveUri](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) 結合基礎 URI 與相對資源連結，返回絕對 URI。若無法解析或不允許，返回 `null`。
- [GetEntity](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/iexternalresourceresolver/getentity/) 為絕對資源 URI 返回可讀取的串流。若資源缺失、被阻擋或無法取得，返回 `null`。必要時亦可返回備援串流。

以下解析器僅從允許的本機目錄載入已連結的資源。網路資源與目錄外的路徑皆會被阻擋。對於未解析的圖像連結，會回傳備援圖像。

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

        // 此解析器僅允許本機檔案。
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

        // 僅在圖像資源時使用備援。返回圖像串流
        // 對缺少的字型或樣式表返回圖像串流將不會有效。
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

### **在 SVG 匯入期間解析已連結的資源**

假設 `assets/diagram.svg` 內含如下相對參考：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 C# 範例將 SVG 檔案 URI 作為基礎 URI，並提供自訂解析器。解析器會將相對圖像連結轉換為絕對 URI，並在 Aspose.Slides 處理 SVG 時返回包含連結資源的串流。

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

// ISvgImage 會公開原始內容、二進位資料、基礎 URI 與解析器。
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

`SvgImage` 類別亦提供接受位元組陣列或串流的多載函式，搭配外部資源解析器與基礎 URI。

{{% alert title="重要" color="warning" %}}
資源解析器在 Aspose.Slides 處理與描繪 SVG 時會提供外部資源，但不會修改原始 SVG 標記，也不會自動將已解析的資源嵌入其中。

當 `ISvgImage` 被加入簡報的圖像集合時，PPTX 檔案可能同時包含原始 SVG 表示與點陣備援圖像。已連結的資源可能出現在產生的備援圖像中，而相對連結如 `images/photo.png` 仍保留在儲存的 SVG 中。若原始外部資源不可用，原生 SVG 呈現的應用程式可能會忽略該連結內容。
{{% /alert %}}

### **建立可攜式 SVG 圖片**

若要建立不依賴外部檔案的 SVG 圖片，請在建立 `SvgImage` 前先將 SVG 轉為自包含。可將連結的圖像 URL 替換為包含圖像資料的 `data:` URI，例如：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必要資源嵌入 SVG 內容後，建立 `SvgImage`、將其加入簡報圖像集合，並依先前範例將其插入圖片框中。

### **處理缺少或被阻擋的資源**

當資源 URI 無效、被禁止或無法解析時，`ResolveUri` 應返回 `null`。當資源無法讀取時，`GetEntity` 應返回 `null`。Aspose.Slides 會在可能的情況下繼續處理 SVG。

可以為缺少的資源返回備援串流，但其內容必須與請求的資源類型相容。例如，只對缺少的圖像返回圖像串流，不能對字型或樣式表返回圖像串流。

{{% alert title="安全" color="warning" %}}
切勿從不受信任的 SVG 檔案解析任意檔案路徑或不受限制的網路 URL。應限制允許的協定、目錄與主機。對於網路資源，亦需套用連線逾時、回應大小限制與內容驗證。
{{% /alert %}}

## **將 SVG 轉換為形狀集合**

此功能由 [AddGroupShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 方法的多載提供，該方法屬於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection) 介面，第一個參數接受 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage) 物件。

![PowerPoint 彈出功能表](img_01_01.png)

以下 C# 範例示範如何使用此方法將 SVG 檔案轉換為形狀集合：

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 原始 SVG 檔案名稱
string svgFileName = "sample.svg";

// 輸出簡報檔案名稱
string outPptxPath = "presentation.pptx";

// 建立新簡報
using (IPresentation presentation = new Presentation())
{
    // 讀取 SVG 檔案內容
    string svgContent = File.ReadAllText(svgFileName);

    // 建立 SvgImage 物件
    ISvgImage svgImage = new SvgImage(svgContent);

    // 取得投影片尺寸
    SizeF slideSize = presentation.SlideSize.Size;

    // 將 SVG 圖像轉換為形狀群組並依投影片尺寸縮放
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 以 PPTX 格式儲存簡報
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **將圖像作為 EMF 新增至投影片**

Aspose.Slides for .NET 可使用 Aspose.Cells 從 Excel 工作表產生 EMF 圖像，並將其新增至簡報投影片。

以下 C# 範例示範如何執行此操作：

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

    // 將活頁簿儲存至串流
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

## **取代圖像集合中的圖像**

Aspose.Slides 允許您取代簡報圖像集合中儲存的圖像，包括投影片形狀使用的圖像。本節說明更新集合中圖像的多種方式。您可以使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 實例，或已存在於集合中的另一張圖像來取代圖像。

請依下列步驟操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入包含圖像的簡報檔案。
2. 將新圖像從檔案載入至位元組陣列。
3. 使用位元組陣列將目標圖像取代為新圖像。
4. 在第二種方法中，將圖像載入 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件，並以該物件取代目標圖像。
5. 在第三種方法中，將目標圖像取代為已存在於簡報圖像集合中的圖像。
6. 將修改後的簡報寫入為 PPTX 檔案。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案的 Presentation 類別。
using Presentation presentation = new Presentation("sample.pptx");

// 第一種方式。
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 第二種方式。
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 第三種方式。
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// 將簡報儲存為檔案。
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="資訊" color="info" %}}
使用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字製作動畫並產生 GIF。
{{% /alert %}}

## **FAQ**

**插入後原始圖像的解析度是否保持不變？**  
是的。來源像素會被保留，但最終顯示效果取決於投影片上 [picture](/slides/zh-hant/net/picture-frame/) 的縮放方式以及儲存時的壓縮設定。

**一次取代數十張投影片中相同的徽標的最佳方法是什麼？**  
將徽標放在母片或版面配置上，並在簡報的圖像集合中取代該徽標——所有使用該資源的元素都會同步更新。

**插入的 SVG 能否轉換為可編輯的形狀？**  
可以。您可以將 SVG 轉換為一組形狀，之後即可使用標準形狀屬性編輯各個部件。

**如何一次將圖片設定為多張投影片的背景？**  
在母片或相關版面配置上 [將圖像指定為背景](/slides/zh-hant/net/presentation-background/)，使用該母片/版面的所有投影片都會繼承該背景。

**如何防止因大量圖片導致簡報檔案過大？**  
重複使用單一圖像資源而非多個副本，選擇適當的解析度，儲存時啟用壓縮，並在適當情況下將重複的圖形放在母片上。