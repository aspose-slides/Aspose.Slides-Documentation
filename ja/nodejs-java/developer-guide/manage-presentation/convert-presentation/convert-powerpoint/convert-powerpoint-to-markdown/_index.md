---
title: JavaScriptでPowerPointプレゼンテーションをMarkdownに変換
linktitle: PowerPointからMarkdownへ
type: docs
weight: 140
url: /ja/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからMDへ
- プレゼンテーションからMDへ
- スライドからMDへ
- PPTからMDへ
- PPTXからMDへ
- PowerPointをMarkdownとして保存
- プレゼンテーションをMarkdownとして保存
- スライドをMarkdownとして保存
- PPTをMDとして保存
- PPTXをMDとして保存
- PPTをMDにエクスポート
- PPTXをMDにエクスポート
- Markdown画像エクスポート
- CDN画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScriptでPPTおよびPPTXプレゼンテーションをMarkdownに変換し、エクスポートされたビットマップ、メタファイル、SVG画像の保存場所と参照先を制御します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理のワークフロー向けに、PPT および PPTX プレゼンテーションを Markdown に変換できます。Markdown のフレーバーを選択したり、スライドコンテンツのレンダリング方法を制御したり、エクスポートされた画像の保存場所や生成された Markdown がそれらを参照する方法を決めることができます。

既定では、Markdown エクスポートはテキストのみの出力になります。ビジュアル コンテンツをエクスポートするには、[MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) メソッドでエクスポート タイプを [MarkdownExportType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownexporttype/) 列挙体の `Sequential` または `Visual` に設定します。`Sequential` はスライド アイテムを個別かつ順番通りにレンダリングし、`Visual` はグループ化されたアイテムを一緒に保持して視覚的な関係を保ちます。`TextOnly` 値は画像リソースを出力せず、このモードでは画像保存コールバックは呼び出されません。

## **プレゼンテーションを Markdown に変換**

[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスでソース ファイルを読み込み、次に [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) メソッドに [SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) 列挙体の `Md` 値を指定して呼び出します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown フレーバーの選択**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) メソッドは出力に使用する Markdown 仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされるバリアントが含まれます。

以下の例はプレゼンテーションを CommonMark としてエクスポートします:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **デフォルトのローカル保存動作で画像をエクスポート**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) クラスはローカルに保存される画像を構成するための 2 つのメソッドを提供します:

- [setBasePath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) は Markdown ドキュメントとそのリソースのベース ディレクトリを指定します。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) は画像のサブディレクトリを指定します。デフォルト値は `Images` です。

以下の例はビジュアル コンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown ドキュメントに相対画像参照を作成します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

この動作は、カスタム画像保存ハンドラーが `false` を返した場合のフォールバックとしても機能します。

## **画像保存と Markdown リンクのカスタマイズ**

Markdown エクスポート中に出力される非 SVG ビットマップおよびメタファイルリソース用のコールバックを登録するには、[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) メソッドを使用します。その `MarkdownImageSavingHandler` コールバックは、[IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) オブジェクト、[ImageFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imageformat/) 値、そして生成された Markdown リンクを要素が 1 つの文字列配列として受け取ります。指定されたフォーマットで画像を保存またはアップロードし、`link[0]` を Markdown 出力に表示すべき参照に置き換えます。

SVG 形式で出力されるリソースは別途処理されます。[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) メソッドでコールバックを登録します。その `MarkdownSvgImageSavingHandler` コールバックは `ISvgImage` オブジェクトと要素が 1 つの `link` 配列を受け取ります。SVG には `ImageFormat` 引数がないため、代わりに `ISvgImage.getSvgData` メソッドから XML データを書き込むかアップロードします。エクスポートモードや視覚的なグルーピングに応じて、元プレゼンテーションの SVG はラスタライズされたり他のコンテンツと結合されたりします。その結果得られた非 SVG リソースは画像保存コールバックに渡されます。すべてのエクスポートされたビジュアル リソースがカスタム処理を必要とする場合は、両方のコールバックを登録してください。

Node.js では、`java.newProxy` を使用してこれらのコールバック インターフェイスの実装を作成します。

ハンドラの戻り値により、画像を処理する側が決まります:

- `true` を返すと、ハンドラが画像を保存、アップロード、変換、またはその他の方法で処理し、`link[0]` に有効な値を割り当てたことを意味します。Aspose.Slides はその値を書き込み、デフォルトのローカル保存は行いません。
- `false` を返すと、Aspose.Slides が画像をローカルに保存し、[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) と [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) で設定された値に従ってリンクを生成します。

{{% alert color="warning" title="重要" %}}
`true` を返すハンドラは画像の責任を負います。`true` を返したが有効で空でないリンクを割り当てなかった場合、エクスポートは `InvalidOperationException` で失敗します。
{{% /alert %}}

### **画像を CDN オリジン ディレクトリに保存し外部 URL を使用**

以下の例では `cdn-origin/presentations/quarterly-report` をマウントまたは同期された CDN オリジン ディレクトリとして扱います。各ハンドラは生成されたファイル名を取得し、画像をそのカスタム ディレクトリに保存し、生成されたローカル参照をパブリック CDN URL に置き換えます。サンプル自体はネットワークアップロードを行わず、ディレクトリが CDN オリジンとしてマウントされるかファイルが CDN に公開された時点で URL が有効になります。オブジェクトストレージの場合は、ファイルシステムへの書き込みをストレージ SDK のアップロード操作に置き換え、アップロードが成功した後に `link[0]` を割り当てます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

ビットマップ ハンドラは 128 × 128 ピクセル未満の画像に対して意図的に `false` を返すため、Aspose.Slides はそれらの画像をデフォルト動作で `output/fallback-images` に保存します。より大きなビットマップやメタファイル、SVG リソースはカスタムコードで処理されます。例として、生成されたローカル参照 `fallback-images/image1.png` は `https://cdn.example.com/presentations/quarterly-report/image1.png` に変換されます。ハンドラはファイルを書き込む際に OS のパスを使用しますが、Markdown に書き込まれるリンクはスラッシュ (/) と URL エンコードされたファイル名を使用します。相対リンクを構築する場合も同様に `/` を使用し、プラットフォーム固有のディレクトリ区切り文字は使用しないでください。

## **FAQ**

**1つのハンドラでラスタ画像と SVG 画像の両方を処理できますか？**

いいえ。[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) を使用して出力されるビットマップおよびメタファイル リソースを処理し、[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) を使用して SVG として出力されるリソースを処理してください。前者は [IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) オブジェクトと [ImageFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imageformat/) 値を提供し、後者は `ISvgImage` オブジェクトを提供し、その SVG データは `ISvgImage.getSvgData` で取得できます。エクスポート時にラスタライズされた元の SVG は画像保存コールバックで処理されます。

**画像保存ハンドラが `false` を返した場合、どうなりますか？**

Aspose.Slides はデフォルトのローカル保存動作を使用します。画像の保存場所と生成された参照は、[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) と [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/markdownsaveoptions/) で設定された値によって制御されます。

**ハンドラは画像をローカルに保存せずに URL を提供できますか？**

はい。ハンドラは画像をオブジェクトストレージにアップロードするか別のサービスに渡し、生成された URL を `link[0]` に割り当てて `true` を返すことができます。ハンドラは処理を自己完結させる必要があり、`true` を返すことでデフォルトのローカル保存は行われません。

**なぜ Markdown エクスポートでハンドラから `InvalidOperationException` がスローされるのですか？**

この例外はハンドラが `true` を返したものの有効なリンクを提供しなかった場合に発生します。`true` を返す前に、Markdown に書き込むべき相対パスまたは外部 URL を割り当ててください。

**画像リンクではどのパス区切り文字を使用すべきですか？**

Markdown のリンクや URL ではスラッシュ (/) を使用してください。`path.join` はファイルシステムパスの構築にのみ使用し、Markdown の参照は別途作成または正規化してください。

**Markdown エクスポート時にハイパーリンクは保持されますか？**

はい。テキストの [ハイパーリンク](/slides/ja/nodejs-java/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [トランジション](/slides/ja/nodejs-java/slide-transition/) や [アニメーション](/slides/ja/nodejs-java/powerpoint-animation/) は変換されません。

**プレゼンテーションを並列で Markdown に変換できますか？**

異なるプレゼンテーション ファイルを並列に処理することは可能ですが、スレッド間で同じ [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを共有しないでください。[multithreading guidelines](/slides/ja/nodejs-java/multithreading/) に従い、ファイルごとに別々のインスタンスを使用してください。