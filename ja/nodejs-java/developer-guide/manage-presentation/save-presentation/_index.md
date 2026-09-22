---
title: JavaScript でプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/nodejs-java/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- プレゼンテーションをファイルへ
- プレゼンテーションをストリームへ
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進捗
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して JavaScript で PowerPoint および OpenDocument のプレゼンテーションをファイルまたはストリームに保存し、PPTX の出力設定や進捗報告を構成します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/nodejs-java/open-presentation/)と、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) メソッドを使用して結果を書き込みます。Aspose.Slides for Node.js via Java は、PowerPoint、OpenDocument、PDF、その他の形式でプレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力で利用可能なオプションについて説明します。

## **ファイルにプレゼンテーションを保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) メソッドに渡します。format の値は、Aspose.Slides が作成するファイルの種類を決定します。

以下の例は、プレゼンテーションを作成し、PPTX ファイルとして保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // プレゼンテーションのコンテンツを追加または変更してください。

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **元の形式でプレゼンテーションを保存**

ファイルとストリームの検出例、新規作成されたプレゼンテーションの動作、ソース形式と出力形式の区別については、[元のプレゼンテーション形式の判定](/slides/ja/nodejs-java/detect-presentation-source-format/) を参照してください。

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルをロードした後、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSourceFormat) メソッドで元の形式を取得します。得られた [SourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sourceformat/) の値を [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/#toSaveFormat) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) の値を取得し、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) で変更されたプレゼンテーションを書き込みます。

以下の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新し、ロードされた形式のまま出力ディレクトリに保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/#toSaveFormat) は、PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれのプレゼンテーション保存形式にマッピングします。プレゼンテーションのソース形式のみをマッピングし、PDF、HTML、TIFF、画像などのエクスポート形式を選択する目的ではありません。サポートされていない、または無効な [SourceFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sourceformat/) の値を渡すとエラーが発生します。

レガシーな PPT、PPS、POT ファイルは同じバイナリコンテナを使用します。このようなプレゼンテーションを拡張子なしのストリームからロードすると、PPS や POT ファイルが PPT として識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名またはフォーマットメタデータを別途保持し、出力ファイル名と形式を選択する際に使用してください。

## **ストリームへのプレゼンテーション保存**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能なストリームと [SaveFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、メモリ内で処理する場合に便利です。

以下の例は、新しいプレゼンテーションをファイルストリームに保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **事前定義されたビュータイプでプレゼンテーションを保存**

保存されたプレゼンテーションを PowerPoint が最初に開くビューを指定できます。[ViewProperties.setLastView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#setLastView) メソッドに [ViewType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewtype/) の値を設定してから保存してください。

以下の例は、スライドマスタービューを初期ビューとして設定します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Strict プロファイルの Office Open XML に準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/) インスタンスを作成し、その [setConformance](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/#setConformance) メソッドに [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) を指定します。そのオプションを [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) メソッドに渡します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 モードで Office Open XML 形式でプレゼンテーションを保存**

標準的な ZIP アーカイブは、各エントリの圧縮・非圧縮サイズ、アーカイブ全体のサイズ、およびエントリ数に制限があります。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。ZIP64 拡張は、適用可能なサイズとエントリ数の制限を緩和します。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) メソッドを使用して、Aspose.Slides が ZIP64 拡張を書き込むかどうかを制御します：

- [IfNecessary](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが標準 ZIP 制限を超えた場合にのみ ZIP64 を使用します。これがデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#Never) は ZIP64 拡張を無効にします。
- [Always](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#Always) は常に ZIP64 拡張を書き込みます。

以下の例は、出力プレゼンテーションに対して常に ZIP64 拡張を有効にします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
If [Zip64Mode.Never](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#Never) が使用され、プレゼンテーションが標準 ZIP 制限内に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベル付きで Office Open XML 形式でプレゼンテーションを保存**

PPTX 出力では、[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) メソッドを使用して保存速度とファイルサイズのバランスを取ることができます。[CompressionLevel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/) クラスは以下の値を提供します：

- [None](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#None) は圧縮せずにデータを保存します。
- [Level1](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level1) は最速の圧縮を提供し、圧縮後の出力が最大になります。
- [Level2](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level2) から [Level5](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level5) は、保存速度よりも小さな出力を徐々に優先します。
- [Level6](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level6) は保存速度とファイルサイズのバランスを取ります。これがデフォルトレベルです。
- [Level7](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level7) と [Level8](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level8) は、さらに保存速度よりも小さな出力を優先します。
- [Level9](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level9) は最強の圧縮を提供し、最も多くの処理時間が必要です。

以下の例は、圧縮せずにプレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

以下の例は、最大の圧縮レベルを使用します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **サムネイルを更新せずにプレゼンテーションを保存**

PPTX としてプレゼンテーションを保存する際、[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドがドキュメントのサムネイルを制御します：

- `true` は保存時にサムネイルを再生成します。これがデフォルト値です。
- `false` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides は生成しません。

以下の例は、サムネイルを更新せずにプレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
サムネイルの更新を無効にすると、PPTX ファイルの保存に要する時間を短縮できます。
{{% /alert %}}

## **保存時の進捗をパーセンテージで取得**

保存操作を監視するには、Java プロキシで [IProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/) インターフェイスを実装し、その実装を [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) メソッドに渡します。Aspose.Slides はエクスポート中に進捗値を伴って [IProgressCallback.reporting](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/#reporting-double-) メソッドを呼び出します。

以下の例は、PDF エクスポートの進捗をコンソールに報告します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose は、Aspose.Slides API を使用して構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供します。これにより、プレゼンテーションから選択したスライドを個別の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides は増分保存または「高速保存」をサポートしていますか？**

いいえ。各保存操作は変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドが同じ Presentation インスタンスを保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスは [/slides/ja/nodejs-java/multithreading/](/slides/ja/nodejs-java/multithreading/) で説明されているようにスレッドセーフではありません。各インスタンスへのアクセスと保存は、同時に 1 スレッドからのみ行ってください。

**プレゼンテーションを保存すると、ハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/nodejs-java/manage-hyperlinks/) はプレゼンテーションに残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションはそれらの場所に引き続きアクセスできる必要があります。

**著者、タイトル、会社、作成日などのドキュメントメタデータを保存できますか？**

はい。保存前に適切な [ドキュメントプロパティ](/slides/ja/nodejs-java/presentation-properties/) を設定すれば、Aspose.Slides がそれらを出力ファイルに書き込みます。