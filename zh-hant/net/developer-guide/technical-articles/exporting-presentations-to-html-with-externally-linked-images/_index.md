---
title: 將簡報匯出為包含外部連結影像的 HTML
type: docs
weight: 100
url: /zh-hant/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 匯出投影片
- 匯出 PPT
- 匯出 PPTX
- 匯出 ODP
- PowerPoint 轉 HTML
- OpenDocument 轉 HTML
- 簡報轉 HTML
- 投影片轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- ODP 轉 HTML
- 連結影像
- 外部連結影像
- 連結資源
- 外部資源
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，並將影像及其他資源儲存為外部連結檔案。"
---
## **概觀**

預設情況下，Aspose.Slides 會將簡報匯出為單一的 HTML 檔案。影像和其他資源會直接寫入 HTML，通常以 Base64 資料的形式。當您需要一個可攜帶的檔案時這很方便，但對於網站、CMS 或伺服器端的轉換管線而言，這並不總是最佳格式。

當您想要以下情況時，請使用外部連結的資源：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中分別快取影像、字型、音訊或視訊；
- 在匯出後檢查、取代、壓縮或後處理產生的資源；
- 使輸出結構更貼近 Web 應用程式的期待。

欲了解一般的 HTML 轉換工作流程，請參閱[Convert PowerPoint Presentations to HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)。本文聚焦於匯出的資源連結部分。

## **連結資源匯出運作方式**

[ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/) 讓您的應用程式可以逐一資源決定匯出程式是將資料嵌入 HTML，還是外部儲存並寫入連結。

此介面有三個方法：

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 決定資源應該被連結還是嵌入。
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/geturl/) 回傳將寫入產生的 HTML 或其他連結資源的 URL。
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) 將連結資源資料寫入磁碟或其他儲存目標。

檔案系統路徑與瀏覽器 URL 是分離的概念。例如，以下範例會將資源檔寫入磁碟上的 `html-output/assets`，而 HTML 中則包含像 `assets/resource-1.svg` 這樣的相對 URL。瀏覽器會以包含連結的檔案為基礎解析這些 URL。因此，`presentation.html` 連結到 SVG 檔案時使用 `assets/resource-1.svg`，而該 SVG 檔案若要連結同一 `assets` 資料夾中的圖片，則使用 `resource-4.jpg`。

## **匯出含連結資源的 HTML**

以下 C# 範例會建立輸出目錄，將 HTML 檔案儲存於其中，並在 `assets` 子目錄中存放連結資源。當 Aspose.Slides 提供或能推斷安全的檔案副檔名時，控制項會連結常見的影像、字型、音訊、視訊與 CSS 資源。未被識別的資源仍會保持嵌入。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

匯出後，輸出資料夾的結構如下：

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

實際產生的檔案取決於簡報內容與匯出選項。例如，點陣圖通常會匯出為 JPEG 或 PNG。Aspose.Slides 可能會選擇不同於來源簡報的影像編碼方式，以產生更小或更適合的檔案。具有透明度的影像會匯出為 PNG。

## **選擇部署用的 URL**

範例使用相對 URL 前綴：`assets/`。若從 `html-output/presentation.html` 開啟 `presentation.html`，瀏覽器會載入 `html-output/assets/resource-1.svg`。

當一個連結資源需要引用另一個連結資源時，範例會在 [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/geturl/) 中使用 `referrer` 參數，僅回傳檔名。例如，若 `resource-1.svg` 與 `resource-4.jpg` 均位於 `assets` 資料夾中，SVG 檔案應該引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

當檔案部署於其他位置時，請使用不同的 URL 前綴：

- 資產目錄與 HTML 檔案位於同一目錄時使用 `assets/`。
- 資產目錄位於 HTML 檔案上一層時使用 `../assets/`。
- 檔案上傳至 CDN 或靜態檔案伺服器時使用 `https://cdn.example.com/presentations/job-123/assets/`。

由 [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/geturl/) 回傳的 URL 必須與由 [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) 寫入的檔案最終部署位置相符。在伺服器應用程式中，請為每一次轉換作業使用唯一的輸出目錄或物件儲存前綴，以免覆寫其他匯出的資源。

## **何時改為嵌入**

當輸出必須為單一檔案（例如電子郵件附件、離線預覽，或需要在沒有支援資產資料夾的情況下搬移的文件）時，嵌入的 Base64 HTML 仍然有用。若 HTML 會由 Web 應用程式提供、存放於 CMS、經由建置管線優化，或需要瀏覽器獨立快取，則使用連結資源較為合適。

## **常見問題**

**我可以只將影像外部化，其他資源仍保持嵌入嗎？**

可以。在 [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 中，僅對想要另存為檔案的內容類型回傳 `LinkEmbedDecision.Link`，其餘回傳 `LinkEmbedDecision.Embed`。

**為什麼匯出的影像副檔名與來源簡報不同？**

Aspose.Slides 可能在 HTML 匯出過程中重新編碼點陣圖，以縮小檔案或提升瀏覽器相容性。例如，來源檔案中的影像可能會依照最終渲染結果寫入為 JPEG 或 PNG。

**移動 HTML 檔案後相對 URL 還能正常運作嗎？**

相對 URL 只能在保持相同相對資料夾結構時正常運作。若 HTML 參照 `assets/resource-1.png`，則 `assets` 資料夾必須仍與 HTML 檔案同層，除非您產生不同的 URL 前綴。

**伺服器應用程式是否可以重複使用相同的輸出資料夾？**

不行。每一次轉換作業請使用唯一的輸出目錄或儲存前綴，以避免檔名衝突並防止一個匯出覆寫另一個匯出的資源。