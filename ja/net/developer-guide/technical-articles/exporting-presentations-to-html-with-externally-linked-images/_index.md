---
title: 外部リンク画像でプレゼンテーションをHTMLにエクスポート
type: docs
weight: 100
url: /ja/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- スライドをエクスポート
- PPT をエクスポート
- PPTX をエクスポート
- ODP をエクスポート
- PowerPoint を HTML に変換
- OpenDocument を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- ODP を HTML に変換
- リンク画像
- 外部リンク画像
- リンクリソース
- 外部リソース
- .NET
- C#
- Aspose.Slides
description: ".NET の Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションを HTML にエクスポートし、画像やその他のリソースを外部リンクファイルとして保存します。"
---
## **概要**

既定では、Aspose.Slides はプレゼンテーションを自己完結型の HTML ファイルにエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接書き込まれます。これは 1 つのポータブルファイルが必要なときに便利ですが、Web サイト、CMS、またはサーバーサイドの変換パイプラインにとって常に最適な形式とは限りません。

次の場合に外部リンクリソースを使用します。

- HTML 文書のサイズを削減したいとき
- ブラウザーや CDN で画像、フォント、音声、動画を個別にキャッシュしたいとき
- エクスポート後に生成されたリソースを検査、置換、圧縮、または後処理したいとき
- 出力構造を Web アプリケーションが期待する形に近づけたいとき

一般的な HTML 変換ワークフローについては、[Convert PowerPoint Presentations to HTML](/slides/ja/net/convert-powerpoint-to-html/) を参照してください。本記事はエクスポート時のリソースリンク処理に焦点を当てています。

## **リンクリソース エクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/) を使用すると、アプリケーション側でリソースごとに、エクスポート時にデータを HTML に埋め込むか外部に保存してリンクを書くかを決定できます。

インターフェイスには次の 3 つのメソッドがあります。

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) がリソースをリンクするか埋め込むかを判断します。
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/geturl/) が生成された HTML または別のリンクリソースに書き込まれる URL を返します。
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) がリンクリソースのデータをディスクまたは別の保存先に書き込みます。

ファイルシステム上のパスとブラウザーの URL は別々に考える必要があります。たとえば、以下のサンプルではリソースファイルを `html-output/assets` に書き出し、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルから相対的にこれらの URL を解決します。そのため、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` となり、同じ `assets` フォルダー内に保存された画像への参照は `resource-4.jpg` となります。

## **リンクリソース付き HTML のエクスポート**

次の C# サンプルは出力ディレクトリを作成し、HTML ファイルをその中に保存し、リンクリソースを `assets` サブディレクトリに格納します。コントローラーは Aspose.Slides が提供または安全と判断できるファイル拡張子を持つ画像、フォント、音声、動画、CSS リソースに対してリンクを作成します。認識できないリソースは埋め込まれたままです。

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

エクスポート後、出力フォルダーは以下の構成になります：

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

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。たとえば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、サイズが小さく、より適切なファイルになる場合に、元のプレゼンテーションで使用されていたものとは異なる画像コーデックを選択することがあります。透過情報を含む画像は PNG としてエクスポートされます。

## **デプロイ用 URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` が `html-output/presentation.html` から開かれると、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

1 つのリンクリソースが別のリンクリソースを参照する場合、サンプルは [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/geturl/) の `referrer` パラメーターを利用し、ファイル名だけを返します。たとえば、`resource-1.svg` と `resource-4.jpg` が同じ `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルを別の場所にデプロイする場合は、URL プレフィックスを変更してください。

- HTML ファイルと同じディレクトリにアセットディレクトリがある場合は `assets/` を使用。
- アセットディレクトリが HTML ファイルの 1 レベル上にある場合は `../assets/` を使用。
- CDN や静的ファイルサーバーにアップロードする場合は `https://cdn.example.com/presentations/job-123/assets/` を使用。

[ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/geturl/) が返す URL は、[ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) が書き込むファイルの最終的な配置先と一致する必要があります。サーバーアプリケーションでは、変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用し、別のエクスポートによる上書きを防止してください。

## **埋め込みにすべきケース**

単一ファイルが必要な場合（メール添付、オフラインプレビュー、アセットフォルダーなしで移動できるドキュメントなど）には、Base64 埋め込み HTML が依然として有用です。HTML が Web アプリケーションで配信される、CMS に保存される、ビルドパイプラインで最適化される、またはブラウザーが HTML とは別にキャッシュするようなシナリオでは、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込みのままにできますか？**

はい。 [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) で、別ファイルとして保存したいコンテンツタイプに対して `LinkEmbedDecision.Link` を返し、その他は `LinkEmbedDecision.Embed` を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は HTML エクスポート時にサイズ削減やブラウザー互換性向上のため、ラスタ画像を再エンコードすることがあります。たとえば、元ファイルの画像が JPEG または PNG のいずれかで書き出されます。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は同じ相対フォルダー構造が保持されている場合にのみ機能します。`assets/resource-1.png` を参照している HTML が別の場所に移動された場合、`assets` フォルダーも同じ位置に残すか、別の URL プレフィックスを生成する必要があります。

**サーバーアプリケーションで同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに一意の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名衝突を防ぎ、別のエクスポートが生成したリソース上書きを回避できます。