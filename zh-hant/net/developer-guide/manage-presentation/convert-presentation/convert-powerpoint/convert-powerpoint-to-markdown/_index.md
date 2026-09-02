---
title: 在 .NET 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/net/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報轉 MD
- 投影片轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 將投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- Markdown 圖像匯出
- CDN 圖像連結
- PowerPoint
- 簡報
- Markdown
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中將 PPT 與 PPTX 簡報轉換為 Markdown，並控制匯出之點陣圖、圖形檔案與 SVG 圖像的儲存位置與引用方式。"
---
## **概觀**

Aspose.Slides for .NET 可以將 PPT 與 PPTX 簡報轉換為 Markdown，以用於文件編寫、靜態網站、內容遷移和版本控制工作流程。您可以選擇 Markdown 風格、控制投影片內容的呈現方式，並決定匯出圖像的儲存位置以及產生的 Markdown 如何引用它們。

預設情況下，Markdown 匯出使用純文字輸出。若要匯出視覺內容，請將 [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/exporttype/) 屬性設定為 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownexporttype/) 列舉中的 `Sequential` 或 `Visual` 值。`Sequential` 會依序個別呈現投影片項目，而 `Visual` 則將分組項目保留在一起，以維持它們的視覺關係。`TextOnly` 值不會產生圖像資源，因此在此模式下不會觸發圖像儲存事件。

## **將簡報轉換為 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入來源檔案，然後以 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法，傳入 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 列舉中的 `Md` 值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **選取 Markdown 風格**

[MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/flavor/) 屬性控制輸出使用的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/flavor/) 列舉包括 CommonMark、GitHub Flavored Markdown 以及其他支援的變體。

下列範例將簡報匯出為 CommonMark：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **使用預設本機儲存行為匯出圖像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/) 類別提供兩個屬性，用於本機儲存圖像：

- [BasePath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/basepath/) 指定 Markdown 文件及其資源的基礎目錄。
- [ImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) 指定圖像子目錄。其預設值為 `Images`。

以下範例會渲染視覺內容、將圖像寫入 `output/assets`，並在 Markdown 文件中建立相對圖像引用：

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

此行為在自訂圖像儲存處理程序回傳 `false` 時亦作為備援。

## **自訂圖像儲存與 Markdown 連結**

使用 [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/imagesaving/) 事件處理在 Markdown 匯出期間產生的非 SVG 點陣圖與中繪圖資源。其 [MarkdownImageSavingHandler](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) 委派會收到 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件、其 [ImageFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/)，以及以 `ref string` 參數傳入的產生之 Markdown 連結。請使用提供的格式儲存或上傳圖像，並將 `link` 替換為必須寫入 Markdown 輸出的參照。

以 SVG 格式產生的資源則另行處理。訂閱 [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) 事件，其 [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) 委派會收到一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 物件與 `ref string link` 參數。SVG 沒有 `ImageFormat` 參數，請改從 [ISvgImage.SvgData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/svgdata/) 屬性寫入或上傳其 XML 資料。根據匯出模式與視覺分組，來源簡報中的 SVG 可能會被光柵化或與其他內容合併；此時產生的非 SVG 資源會傳遞給 `ImageSaving`。若每個匯出的視覺資源皆需要自訂處理，請同時訂閱兩個事件。

處理程序的回傳值決定誰負責圖像：

- 回傳 `true` 表示處理程序已儲存、上傳、轉換或以其他方式處理圖像，且已為 `link` 指派了有效值。Aspose.Slides 會將該值寫入 Markdown 文件，且不會執行預設本機儲存。
- 回傳 `false` 則讓 Aspose.Slides 依照 [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/basepath/) 與 [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) 將圖像儲存至本機並產生連結。

{{% alert color="warning" title="Important" %}}
回傳 `true` 的處理程序必須對圖像負全責。若回傳 `true` 但未指派有效且非空的連結，匯出將因 `InvalidOperationException` 失敗。
{{% /alert %}}

### **將圖像儲存至 CDN 原始目錄並使用外部 URL**

下列範例將 `cdn-origin/presentations/quarterly-report` 視為已掛載或同步的 CDN 原始目錄。每個處理程序會擷取產生的檔名，將圖像寫入該自訂目錄，並將產生的本機參照替換為公開的 CDN URL。此範例本身不會執行網路上傳：只有在目錄被掛載為 CDN 原始或檔案已發布至 CDN 後，URL 才會有效。若使用物件儲存，請改以儲存 SDK 的上傳操作取代檔案系統寫入，並在上傳成功後才指派 `link`。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

位圖處理程序會對小於 128 × 128 像素的圖像回傳 `false`，因此 Aspose.Slides 會使用預設行為將這些圖像儲存至 `output/fallback-images`。較大的位圖與中繪圖資源，以及 SVG 資源，則由自訂程式碼處理。例如，產生的本機參照 `fallback-images/image1.png` 會變為 `https://cdn.example.com/presentations/quarterly-report/image1.png`。處理程序僅在寫入檔案時使用作業系統路徑；寫入 Markdown 的連結使用正斜線與 URL 編碼的檔名。建立相對連結時亦同樣使用 `/`，而非平台特定的目錄分隔符。

## **常見問題**

**一個處理程序可以同時處理點陣圖與 SVG 圖像嗎？**

不能。請使用 [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/imagesaving/) 處理產生的點陣圖與中繪圖資源，使用 [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) 處理以 SVG 產生的資源。前者提供 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件與 [ImageFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/)，後者提供 [ISvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/) 物件，可從 [ISvgImage.SvgData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/svgdata/) 讀取 SVG 資料。若來源 SVG 在匯出過程中被光柵化，則會由 `ImageSaving` 處理。

**當圖像儲存處理程序回傳 `false` 時會發生什麼事？**

Aspose.Slides 會使用預設的本機儲存行為。圖像位置與產生的參照由 [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/basepath/) 與 [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) 控制。

**處理程序可以在不儲存圖像至本機的情況下提供 URL 嗎？**

可以。處理程序可將圖像上傳至物件儲存或傳給其他服務，然後將得到的 URL 指派給 `link`，最後回傳 `true`。此時處理程序必須自行完成所有處理，回傳 `true` 會阻止預設的本機儲存。

**為何 Markdown 匯出會因處理程序拋出 `InvalidOperationException`？**

當處理程序回傳 `true` 但未提供有效連結時，就會拋出此例外。請在回傳 `true` 之前，先將應寫入 Markdown 的相對路徑或外部 URL 指派給 `link`。

**圖像連結應使用哪種路徑分隔符？**

在 Markdown 連結與 URL 中使用正斜線 (`/`)。僅在檔案系統路徑上使用 `Path.Combine`，然後再另行建構或正規化 Markdown 參照。

**超連結在 Markdown 匯出時會被保留嗎？**

會。文字 [hyperlinks](/slides/zh-hant/net/manage-hyperlinks/) 會保留為標準 Markdown 連結。投影片的 [transitions](/slides/zh-hant/net/slide-transition/) 與 [animations](/slides/zh-hant/net/powerpoint-animation/) 則不會被轉換。

**可以平行轉換多個簡報為 Markdown 嗎？**

可以平行處理不同的簡報檔案，但請勿在執行緒間共用同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例。請遵循 [multithreading guidelines](/slides/zh-hant/net/multithreading/)，為每個檔案使用獨立的實例。