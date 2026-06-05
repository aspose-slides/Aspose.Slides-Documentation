---
title: 外部リンクされた画像でプレゼンテーションを HTML にエクスポート
type: docs
weight: 100
url: /ja/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint のエクスポート
- OpenDocument のエクスポート
- プレゼンテーションのエクスポート
- スライドのエクスポート
- PPT のエクスポート
- PPTX のエクスポート
- ODP のエクスポート
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
description: "Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーションを .NET で HTML にエクスポートし、画像やその他のリソースを外部リンクファイルとして保存します。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを単一の HTML ファイルとしてエクスポートします。画像やその他のリソースは HTML に直接埋め込まれ、通常は Base64 データとして記述されます。これは 1 つのポータブル ファイルが必要なときには便利ですが、Web サイト、CMS、またはサーバー側の変換パイプラインにとって常に最適な形式というわけではありません。

外部リンクされたリソースを使用したい場合は次のとおりです。

- HTML ドキュメントのサイズを削減したいとき
- ブラウザや CDN で画像、フォント、音声、動画を別々にキャッシュしたいとき
- エクスポート後に生成されたリソースを検査、置換、圧縮、または後処理したいとき
- 出力構造を Web アプリケーションが期待する形に近づけたいとき

一般的な HTML 変換ワークフローについては[PowerPoint プレゼンテーションを HTML に変換](/slides/ja/net/convert-powerpoint-to-html/)をご覧ください。本記事はエクスポート時のリソースリンク部分に焦点を当てています。

## **リンクされたリソースのエクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/) を使用すると、アプリケーションはリソースごとに、エクスポーターが HTML にデータを埋め込むか外部に保存してリンクを書くかを決定できます。

このインターフェイスには 3 つのメソッドがあります。

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) はリソースをリンクするか埋め込むかを決定します。
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/geturl/) は生成された HTML または別のリンクされたリソースに書き込まれる URL を返します。
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) はリンクされたリソースのデータをディスクまたは別の保存先に書き込みます。

ファイルシステム上のパスとブラウザ URL は別々に考える必要があります。たとえば、以下のサンプルはリソースファイルをディスク上の `html-output/assets` に書き込みますが、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザはリンクを含むファイルから相対的にこれらの URL を解決します。そのため、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、同じ `assets` フォルダーに保存された画像へのリンクは `resource-4.jpg` となります。

## **リンクされたリソースで HTML をエクスポート**

以下の C# サンプルは出力ディレクトリを作成し、HTML ファイルをそこに保存し、リンクされたリソースを `assets` サブディレクトリに格納します。コントローラは Aspose.Slides が提供または安全な拡張子を推測できる場合に、一般的な画像、フォント、音声、動画、CSS リソースをリンクします。認識できないリソースは埋め込まれたままです。

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

エクスポート後、出力フォルダーは次の構造になります。

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

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。たとえば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、サイズが小さくなる、またはより適切なファイルになる場合、元のプレゼンテーションで使用されたものとは異なる画像コーデックを選択することがあります。透明度を持つ画像は PNG としてエクスポートされます。

## **デプロイ時の URL 選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` が `html-output/presentation.html` から開かれる場合、ブラウザは `html-output/assets/resource-1.svg` を読み込みます。

1 つのリンクされたリソースが別のリンクされたリソースを参照する場合、サンプルは [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/geturl/) の `referrer` パラメーターを使用し、ファイル名だけを返します。たとえば、`resource-1.svg` と `resource-4.jpg` が同じ `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルが別の場所にデプロイされる場合は、異なる URL プレフィックスを使用してください。

- HTML ファイルと同じディレクトリにアセットディレクトリがある場合は `assets/` を使用
- HTML ファイルの 1 レベル上にアセットディレクトリがある場合は `../assets/` を使用
- ファイルが CDN や静的ファイルサーバーにアップロードされる場合は `https://cdn.example.com/presentations/job-123/assets/` を使用

[ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/geturl/) が返す URL は、[ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) が書き込むファイルの最終デプロイ先と一致しなければなりません。サーバー アプリケーションでは、変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用して、別のエクスポートがファイルを上書きしないようにしてください。

## **埋め込みにすべきケース**

埋め込み Base64 HTML は、出力が単一ファイルである必要がある場合（メール添付、オフラインプレビュー、資産フォルダーなしで移動されるドキュメントなど）に依然として有用です。リンクされたリソースは、HTML が Web アプリケーションで配信されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザが HTML とは別にキャッシュしたりするシナリオに適しています。

## **よくある質問**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。[ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ja/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) で、別ファイルとして保存したいコンテンツタイプに対してのみ `LinkEmbedDecision.Link` を返し、その他は `LinkEmbedDecision.Embed` を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は HTML エクスポート時にラスタ画像を再エンコードし、サイズやブラウザ互換性を向上させることがあります。たとえば、元ファイルの画像が JPEG または PNG として書き出されるかは、レンダリング結果に応じて決まります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は、同じ相対フォルダー構造が維持された場合にのみ機能します。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残っている必要があります。別の URL プレフィックスを生成しない限りは同様です。

**サーバー アプリケーションで同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに一意の出力ディレクトリまたは保存プレフィックスを使用してください。これによりファイル名の衝突を防ぎ、別のエクスポートが生成したリソースを上書きすることを防げます。