---
title: 外部リンク画像付きでプレゼンテーションを HTML にエクスポート
type: docs
weight: 100
url: /ja/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Java を介して Aspose.Slides for Node.js を使用し、画像やその他のリソースを外部リンクファイルとして保存しながら、PowerPoint および OpenDocument のプレゼンテーションを JavaScript で HTML にエクスポートします。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを単一の HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接書き込まれます。これは 1 つのポータブルファイルが必要なときに便利ですが、Web サイトや CMS、サーバー側の変換パイプラインに常に最適な形式というわけではありません。

外部リンクされたリソースを使用したい場合は、次のとおりです。

- HTML ドキュメントのサイズを削減する
- 画像、フォント、オーディオ、ビデオをブラウザーや CDN で個別にキャッシュする
- エクスポート後に生成されたリソースを検査、置換、圧縮、またはポストプロセスする
- 出力構造を Web アプリケーションが期待する形に近づける

一般的な HTML 変換ワークフローについては、[Convert PowerPoint Presentations to HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/) を参照してください。この記事はエクスポートのリソースリンク部分に焦点を当てています。

## **リンクリソースエクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) の Java プロキシにより、リソースごとにデータを HTML に埋め込むか外部に保存してリンクを書くかをアプリケーションが判断できます。

コントローラーには 3 つのメソッドがあります:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) はリソースをリンクするか埋め込むかを決定します。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は生成された HTML または別のリンクリソースに書き込まれる URL を返します。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) はリンクリソースのデータをディスクまたは別の保存先に書き込みます。

ファイルシステムのパスとブラウザー URL は別個の概念です。たとえば、以下のサンプルはリソースファイルをディスク上の `html-output/assets` に書き込み、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルから相対的にこれらの URL を解決します。したがって、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、その SVG ファイルが同じ `assets` フォルダーに保存された画像を参照するときは `resource-4.jpg` を使用します。

## **リンクリソース付き HTML のエクスポート**

以下の JavaScript 例は出力ディレクトリを作成し、HTML ファイルをそこに保存し、リンクリソースを `assets` サブディレクトリに格納します。コントローラーは Aspose.Slides が安全なファイル拡張子を提供または推測できる場合に、共通の画像、フォント、オーディオ、ビデオ、CSS リソースをリンクします。認識されないリソースは埋め込まれたままです。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

エクスポート後、出力フォルダーは次の構造になります:

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

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。たとえば、ラスタ画像は通常 JPEG または PNG としてエクスポートされます。Aspose.Slides は、元のプレゼンテーションで使用されたものと異なる画像コーデックを選択することがあり、サイズが小さくなるかより適切なファイルになる場合があります。透過が必要な画像は PNG としてエクスポートされます。

## **デプロイ時の URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

あるリンクリソースが別のリンクリソースを参照する場合、サンプルは [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) の `referrer` パラメーターを使用し、ファイル名だけを返します。たとえば、`resource-1.svg` と `resource-4.jpg` が両方とも `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルを別の場所にデプロイする場合は、異なる URL プレフィックスを使用します:

- アセットディレクトリが HTML ファイルの隣にある場合は `assets/` を使用します。
- アセットディレクトリが HTML ファイルの 1 レベル上にある場合は `../assets/` を使用します。
- ファイルが CDN や静的ファイルサーバーにアップロードされる場合は `https://cdn.example.com/presentations/job-123/assets/` を使用します。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) が返す URL は、[ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) が書き込むファイルの最終的な配置場所と一致する必要があります。サーバーアプリケーションでは、別のエクスポートがファイルを上書きしないように、各変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用してください。

## **埋め込みにすべき場合**

埋め込み Base64 HTML は、出力が単一ファイルである必要がある場合（メール添付、オフラインプレビュー、資産フォルダーなしで移動されるドキュメントなど）に依然として有用です。HTML が Web アプリケーションで配信されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザーが HTML とは別にキャッシュしたりする場合は、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。[ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) で、別ファイルとして保存したいコンテンツタイプに対してのみ `LinkEmbedDecision.Link` を返し、その他は `LinkEmbedDecision.Embed` を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は HTML エクスポート時にラスタ画像を再エンコードし、サイズやブラウザー互換性を向上させることがあります。たとえば、元ファイルの画像が JPEG または PNG のいずれかで書き込まれるかは、レンダリング結果に応じて決まります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は同じ相対フォルダー構造が維持されている場合にのみ機能します。`assets/resource-1.png` を参照している HTML がある場合、`assets` フォルダーは HTML ファイルの隣に残っている必要があります。別の URL プレフィックスを生成しない限りです。

**サーバーアプリケーションは同じ出力フォルダーを再利用すべきですか？**

いいえ。各変換ジョブごとに一意の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名の衝突を防ぎ、あるエクスポートが別のエクスポートで生成されたリソースを上書きすることを防げます。