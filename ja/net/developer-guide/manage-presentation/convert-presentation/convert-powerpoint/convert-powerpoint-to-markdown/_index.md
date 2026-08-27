---
title: .NET で PowerPoint プレゼンテーションを Markdown に変換
linktitle: PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を MD に変換
- プレゼンテーションを MD に変換
- スライドを MD に変換
- PPT を MD に変換
- PPTX を MD に変換
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- Markdown 画像エクスポート
- CDN 画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- .NET
- C#
- Aspose.Slides
description: ".NET で PPT および PPTX プレゼンテーションを Markdown に変換し、エクスポートされたビットマップ、メタファイル、SVG 画像の保存場所と参照先を制御します。"
---
## **概要**

Aspose.Slides for .NET は、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理のワークフロー向けに PPT および PPTX プレゼンテーションを Markdown に変換できます。Markdown のフレーバーを選択したり、スライド コンテンツのレンダリング方法を制御したり、エクスポートされた画像の保存先や生成された Markdown が画像を参照する方法を決めたりできます。

デフォルトでは、Markdown エクスポートはテキストのみの出力を使用します。ビジュアル コンテンツをエクスポートするには、[MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/exporttype/) プロパティを [MarkdownExportType](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownexporttype/) 列挙体の `Sequential` または `Visual` のいずれかに設定します。`Sequential` はスライド項目を個別かつ順番どおりにレンダリングし、`Visual` はグループ化された項目をまとめて視覚的な関係を保持します。`TextOnly` 値は画像リソースを出力しないため、そのモードでは画像保存イベントは呼び出されません。

## **プレゼンテーションを Markdown に変換する**

[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスでソース ファイルを読み込み、次に `Md` 値を持つ [SaveFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) 列挙体を使用して [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを呼び出します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Markdown フレーバーを選択する**

[MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/flavor/) プロパティは出力に使用する Markdown の仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/net/aspose.slides.export/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされているバリアントが含まれます。

次の例はプレゼンテーションを CommonMark としてエクスポートします。

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

## **既定のローカル保存動作で画像をエクスポートする**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/) クラスはローカルに保存される画像用に 2 つのプロパティを提供します。

- [BasePath](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/basepath/) は Markdown ドキュメントとそのリソースのベース ディレクトリを指定します。
- [ImagesSaveFolderName](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) は画像サブディレクトリを指定します。既定値は `Images` です。

次の例はビジュアル コンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown ドキュメントに相対画像参照を作成します。

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

この動作はカスタム画像保存ハンドラが `false` を返した場合のフォールバックとしても機能します。

## **画像保存と Markdown リンクをカスタマイズする**

Markdown エクスポート中に出力される非 SVG ビットマップおよびメタファイル リソースに対しては、[MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/imagesaving/) イベントを使用します。その [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) デリゲートは [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクト、[ImageFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/)、および `ref string` パラメータとして生成された Markdown リンクを受け取ります。提供されたフォーマットで画像を保存またはアップロードし、`link` を Markdown 出力に記述すべき参照に置き換えてください。

SVG 形式で出力されるリソースは別途処理されます。[MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) イベントに登録し、[MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) デリゲートが [ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/) オブジェクトと `ref string link` パラメータを受け取ります。SVG には `ImageFormat` 引数がないため、代わりに [ISvgImage.SvgData](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/svgdata/) プロパティから XML データを書き込むかアップロードしてください。エクスポート モードやビジュアル グルーピングに応じて、ソース プレゼンテーションの SVG がラスタライズされたり他のコンテンツと結合されたりすることがあり、その結果得られた非 SVG リソースは `ImageSaving` に渡されます。すべてのエクスポートされたビジュアル リソースがカスタム処理を必要とする場合は、両方のイベントに登録してください。

ハンドラの戻り値は画像の処理者を決定します。

- ハンドラが画像を保存、アップロード、変換、あるいはその他の処理を行い、`link` に有効な値を設定したら `true` を返します。Aspose.Slides はその値を Markdown 文書に書き込み、既定のローカル保存は行いません。
- `false` を返すと、Aspose.Slides が画像をローカルに保存し、[MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/basepath/) と [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) に従ってリンクを生成します。

{{% alert color="warning" title="Important" %}}
`true` を返すハンドラは画像に対する責任を負います。有効かつ空でないリンクを割り当てずに `true` を返すと、エクスポートは `InvalidOperationException` で失敗します。
{{% /alert %}}

### **画像を CDN のオリジン ディレクトリに保存し、外部 URL を使用する**

次の例は `cdn-origin/presentations/quarterly-report` をマウントまたは同期された CDN オリジン ディレクトリとして扱います。各ハンドラは生成されたファイル名を取得し、画像をそのカスタム ディレクトリに保存し、生成されたローカル参照をパブリック CDN URL に置き換えます。このサンプル自体はネットワークへのアップロードを行いません：ディレクトリが CDN オリジンとしてマウントされるか、ファイルが CDN に公開されたときにのみ URL が有効になります。オブジェクト ストレージを使用する場合は、ファイルシステムへの書き込みをストレージ SDK のアップロード操作に置き換え、アップロードが成功した後にのみ `link` を設定してください。

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

ビットマップ ハンドラは 128 × 128 ピクセル未満の画像に対して意図的に `false` を返すため、Aspose.Slides はそれらの画像を既定の動作で `output/fallback-images` に保存します。より大きなビットマップやメタファイル、SVG リソースはカスタム コードで処理されます。たとえば、生成されたローカル参照 `fallback-images/image1.png` は `https://cdn.example.com/presentations/quarterly-report/image1.png` に置き換えられます。ハンドラはファイルを書き込む際に OS 固有のパスを使用しますが、Markdown に書き込むリンクはスラッシュ (/) と URL エスケープされたファイル名を使用します。相対リンクを構築するときも同様に `/` を使用し、プラットフォーム固有のディレクトリ区切り文字は使用しないでください。

## **FAQ**

**1️⃣ ハンドラはラスタ画像と SVG 画像の両方を処理できますか？**

いいえ。ビットマップおよびメタファイル リソースには [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/imagesaving/) を、SVG として出力されるリソースには [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) を使用してください。前者は [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクトと [ImageFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/imageformat/) を提供し、後者は [ISvgImage](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/) オブジェクトとその SVG データを [ISvgImage.SvgData](https://reference.aspose.com/slides/ja/net/aspose.slides/isvgimage/svgdata/) から取得できます。エクスポート中にラスタライズされたソース SVG は `ImageSaving` で処理されます。

**2️⃣ 画像保存ハンドラが `false` を返した場合はどうなりますか？**

Aspose.Slides は既定のローカル保存動作を使用します。画像の保存場所と生成された参照は [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/basepath/) と [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ja/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) によって制御されます。

**3️⃣ ハンドラは画像をローカルに保存せずに URL を提供できますか？**

はい。ハンドラは画像をオブジェクト ストレージにアップロードするか別サービスへ渡し、生成された URL を `link` に割り当てて `true` を返すことができます。`true` を返すとデフォルトのローカル保存は行われません。

**4️⃣ ハンドラから `InvalidOperationException` がスローされるのはなぜですか？**

ハンドラが `true` を返したにもかかわらず有効なリンクを提供しなかった場合にこの例外が発生します。`true` を返す前に、Markdown に書き込むべき相対パスまたは外部 URL を `link` に設定してください。

**5️⃣ 画像リンクはどのパス区切り文字を使用すべきですか？**

Markdown リンクと URL ではスラッシュ (/) を使用します。ファイルシステム向けのパスを組み立てるときは `Path.Combine` を使用し、Markdown の参照は別途正規化してください。

**6️⃣ ハイパーリンクは Markdown エクスポート時に保持されますか？**

はい。テキストの [hyperlinks](/slides/ja/net/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/net/slide-transition/) や [animations](/slides/ja/net/powerpoint-animation/) は変換されません。

**7️⃣ プレゼンテーションを並列で Markdown に変換できますか？**

異なるプレゼンテーション ファイルを並列に処理できますが、同じ [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。[マルチスレッド ガイドライン](/slides/ja/net/multithreading/) に従い、ファイルごとに個別のインスタンスを使用してください。