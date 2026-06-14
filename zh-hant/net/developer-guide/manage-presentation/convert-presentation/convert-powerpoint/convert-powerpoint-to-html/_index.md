---
title: 在 .NET 中將 PowerPoint 簡報轉換為 HTML
linktitle: PowerPoint 轉 HTML
type: docs
weight: 30
url: /zh-hant/net/convert-powerpoint-to-html/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 HTML
- 簡報 轉 HTML
- 投影片 轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- 將 PowerPoint 保存為 HTML
- 將簡報保存為 HTML
- 將投影片保存為 HTML
- 將 PPT 保存為 HTML
- 將 PPTX 保存為 HTML
- 匯出 PPT 為 HTML
- 匯出 PPTX 為 HTML
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中將 PowerPoint 簡報轉換為 HTML。使用 Aspose.Slides 匯出 PPT 與 PPTX 檔案、選取的投影片、備註、字型、影像、SVG 與媒體。"
---
## **概觀**

Aspose.Slides for .NET 可以在不使用 Microsoft PowerPoint 的情況下將 PowerPoint 簡報另存為 HTML。基本的轉換只需要載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 並呼叫 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/)，使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/)。當您需要控制匯出版面、字型、圖片、備註、評論、SVG 輸出或連結資源時，請使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/)。

本指南著重於實用的 HTML 匯出情境：

- 匯出整份簡報或選取的投影片。  
- 產生固定版面、回應式或基於 SVG 的 HTML。  
- 包含講者備註與評論。  
- 控制圖像品質與裁切圖像資料。  
- 將字型內嵌或將字型檔案分別儲存。  
- 選擇外部資源與媒體檔案的寫入與參照方式。

預設情況下，HTML 匯出會產生自包含的 HTML 文件，將大多數資源內嵌。這對於共享單一檔案很方便，但會增加輸出大小。若要在網站上發布，請考慮使用外部資源、降低圖片 DPI，並僅內嵌在目標環境中不一定可用的字型。

## **將簡報轉換為 HTML**

若要將簡報匯出為 HTML，請使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 載入，並以 [SaveFormat.Html](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 儲存。

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

此範例會寫入一個 HTML 檔案。`using` 宣告會在匯出後釋放檔案句柄與渲染資源，進而處置簡報物件。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/) 是 HTML 匯出的主要設定類別。常見設定包括：

- `SlidesLayoutOptions`：加入備註、評論、講義或其他版面資訊。  
- `HtmlFormatter`：變更 HTML 文件結構或委託給控制器進行格式化。  
- `SlideImageFormat`：變更投影片的表示方式，例如作為 SVG。  
- `PicturesCompression`：控制圖片 DPI 與輸出大小。  
- `DeletePicturesCroppedAreas`：保留或移除裁切過的圖像資料。  
- `SvgResponsiveLayout`：讓匯出的 SVG 內容自適應其容器。  
- `ShowHiddenSlides`：在需要時包含隱藏投影片。

以下章節分別說明最常用的選項，您可以僅結合工作流程需要的部分。

## **將選取的投影片轉換為 HTML**

接受投影片編號的 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 多載使用 1 為基礎的投影片位置。下方迴圈會將每張投影片儲存為獨立的 HTML 檔案。

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

當網站或應用程式需要每張投影片都有一個 HTML 頁面時，請使用此模式。若每張投影片應使用相同版面，請建立單一 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/) 實例，並將其傳遞給每個 `Save` 呼叫。

## **建立回應式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/responsivehtmlcontroller/) 透過 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmlformatter/) 提供回應式 HTML 輸出。當匯出的頁面需更好地適應瀏覽器寬度時，請使用它。

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

若要使用基於 SVG 的回應式版面，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/) 上設定 `SvgResponsiveLayout`。這在投影片內容以可縮放 SVG 標記匯出時特別有用。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **包含講者備註與評論**

透過 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notescommentslayoutingoptions/) 以包含講者備註或評論。備註與評論預設為隱藏，除非您指定它們的位置。

假設來源簡報包含講者備註：

![PowerPoint 中含有講者備註的投影片](slide_with_notes.png)

以下程式碼會將投影片內容與投影片下方的講者備註一起匯出。

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

匯出的 HTML 會包含備註區域：

![HTML 輸出同時顯示投影片與講者備註](HTML_with_notes.png)

若要匯出評論，請設定 `CommentsPosition`（例如 `CommentsPositions.Right` 或 `CommentsPositions.Bottom`）。若只需要評論，請省略 `NotesPosition`。若同時需要備註與評論，則兩個屬性皆設定。

## **控制圖像品質與裁切區域**

HTML 匯出可以壓縮投影片圖片以減少輸出大小。當需要較高圖像品質時，請將 `PicturesCompression` 設為來自 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/picturescompression/) 的值。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

預設情況下，裁切過的圖像區域可能會從匯出結果中移除。僅在使用者必須能夠復原或檢視那些隱藏圖像部分時才保留裁切資料。保留它會增加 HTML 大小。

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **新增 CSS**

若只需簡單樣式，將 CSS 字串傳遞給 [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmlformatter/createdocumentformatter/)。這會變更周圍的 HTML 文件，同時 Aspose.Slides 繼續渲染投影片內容。

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

若要自訂文件標頭、連結的 CSS 檔案，或在投影片與圖形周圍加入自訂標記，請實作 [IHtmlFormattingController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ihtmlformattingcontroller/)，並使用 `CreateCustomFormatter` 將其傳遞給 [HtmlFormatter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmlformatter/)。

## **內嵌字型**

如果目標環境可能未安裝簡報所使用的字型，請使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/embedallfontshtmlcontroller/) 在 HTML 中內嵌字型。內嵌可以提升視覺相似度，但會增加輸出大小。

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

僅在確信目標瀏覽器或系統已提供字型時才排除內嵌。對於品牌字型或較不常見的字型，內嵌通常較安全。

## **連結字型檔案而非內嵌**

為了減少 HTML 檔案大小，您可以將字型資料寫入獨立的 WOFF 檔案，並在 HTML 中加入 `@font-face` 規則。下面的輔助程式延伸自 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/embedallfontshtmlcontroller/)，並覆寫 `WriteFont`。

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

在此範例中，字型檔案會儲存至 `html-output/fonts`，HTML 會以 `fonts/BrandFont-normal-400.woff` 之類的 URL 參照它們。若 HTML 檔案與字型部署於其他位置，請設定 `fontUrlPrefix` 以符合部署後的 URL 路徑。

## **外部儲存資源**

自包含的 HTML 易於搬移，但內嵌的 Base64 資源會使檔案變大。若您的應用程式需要外部圖片檔案，請實作 [ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/)，並將其傳遞給 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/htmloptions/) 建構子。

外部化資源時，請有意選擇兩條路徑：

- 檔案系統輸出路徑：應用程式寫入產生的圖片、字型、音訊或影片的目錄。  
- URL 路徑：瀏覽器在 HTML 文件中用來載入這些檔案的網址。

完整的圖片連結實作範例，請參閱 [Export Presentations to HTML with Externally Linked Images](/slides/zh-hant/net/exporting-presentations-to-html-with-externally-linked-images/)。

## **匯出媒體檔案**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/videoplayerhtmlcontroller/) 會匯出影片與音訊檔案，並產生可在瀏覽器播放的 HTML。其建構子接受以下參數：

- `path`：產生的媒體檔案寫入的目錄。  
- `fileName`：正在產生的 HTML 檔名。  
- `baseUri`：HTML 中指向媒體檔案的絕對 URI 前綴。

若 HTML 檔案為 `html-output/presentation.html`，而媒體檔案儲存在 `html-output/media`，則 `path` 應指向磁碟上的 media 目錄，同時 `baseUri` 應指向瀏覽器觀點下的相同目錄。對於本機預覽，您可以使用 `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` 產生 `file:///` URI；對於部署的應用程式，請使用已發布媒體目錄的絕對 URL。

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

在伺服器應用程式中，請為每次匯出作業使用唯一的輸出目錄。共用輸出路徑可能導致不同轉換的檔案互相覆寫。

## **效能與資源管理**

HTML 轉換屬於渲染操作，處理時間與記憶體使用量取決於投影片數量、圖片解析度、字型、特效、圖表與嵌入的媒體。較高的 `PicturesCompression` DPI、內嵌字型、SVG 輸出以及保留裁切圖像區域會提升忠實度，但通常會增加輸出大小。

批次轉換時：

- 及時處置每個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。  
- 為不同作業使用獨立的輸出目錄。  
- 除非忠實度有必須，否則避免內嵌常見字型。  
- 若 HTML 僅用於預覽或縮圖，請降低圖片 DPI。  
- 在部署路徑最終確定前，將來源簡報、產生的 HTML 與外部資源一起保留。

## **常見問題**

**HTML 輸出中會保留超連結嗎？**

會。簡報中的超連結會匯出為 HTML，且在目標 URL 有效時仍可點選。

**我可以平行轉換簡報為 HTML 嗎？**

可以，但請勿在多個執行緒間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。請使用不同的簡報實例、不同的資料流與不同的輸出目錄來處理不同檔案。請參閱 [multithreading guidance](/slides/zh-hant/net/multithreading/) 取得詳細資訊。

**Presentation 物件是執行緒安全的嗎？**

不是。單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例應在同一執行緒上完成載入、修改、儲存與處置。若要平行作業，請為每個執行緒或每個處理程序建立獨立的實例。

**為什麼產生的 HTML 檔案很大？**

預設匯出會將資源直接內嵌於 HTML。內嵌字型、高 DPI 圖片、媒體、SVG 內容以及保留的裁切圖像區域都會增加檔案大小。可改為使用外部資源、排除常見字型的內嵌，並在較不需要最高忠實度時降低 `PicturesCompression`。

**為什麼 PowerPoint 中 24 pt 的字型在 HTML 中顯示為 17.999819 pt？**

這是因為 PowerPoint 與 HTML 使用不同的 DPI 模型。PowerPoint 以 72 DPI 的排版點數儲存文字大小，而 HTML 版面基於 96 DPI 的 CSS 像素。Aspose.Slides 於匯出時會在兩者之間進行轉換，可能會產生微小的四捨五入差異。此差異不代表實際的視覺字型大小變化，只是數學上的換算結果。

**應該如何為媒體匯出選擇 baseUri？**

請從瀏覽器的觀點選擇 `baseUri`，並以絕對 URI 形式傳遞。對於本機預覽，可使用 `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` 產生 `file:///` URI；對於部署環境，請使用已發布媒體目錄的絕對 URL。檔案系統的 `path` 與瀏覽器的 `baseUri` 不必是相同的字串，但必須指向相同的資源位置。

**我可以包含隱藏投影片嗎？**

可以。當必須匯出隱藏投影片時，請在 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/) 上設定 `ShowHiddenSlides = true`。