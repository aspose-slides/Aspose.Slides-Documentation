---
title: JavaScript でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
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
- ファイルへのプレゼンテーション変換
- ストリームへのプレゼンテーション変換
- 事前定義ビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進行状況
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して Java でプレゼンテーションを保存する方法を紹介します—レイアウト、フォント、エフェクトを保持したまま PowerPoint または OpenDocument にエクスポートできます。"
---
## **概要**

[Open Presentations in JavaScript](/slides/ja/nodejs-java/open-presentation/) では、プレゼンテーションを開くために [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスを使用する方法が説明されています。本稿では、プレゼンテーションの作成と保存方法を解説します。[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、作業が完了したら保存したくなります。Aspose.Slides for Node.js を使用すると、**ファイル** または **ストリーム** に保存できます。本稿では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルにプレゼンテーションを保存**

プレゼンテーションは、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスの `save` メソッドを呼び出すことでファイルに保存できます。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // ここで何らかの処理を行います...

    // プレゼンテーションをファイルに保存します。
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ストリームにプレゼンテーションを保存**

出力ストリームを [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスの `save` メソッドに渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存します。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // プレゼンテーションをストリームに保存します。
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides を使用すると、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを [ViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/) クラスで設定できます。[setLastView](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/#setLastView) メソッドに [ViewType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewtype/) 列挙体の値を渡して使用します。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides では、プレゼンテーションを Strict Office Open XML 形式で保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/) クラスを使用し、その conformance プロパティを設定します。[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存するものです。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    // プレゼンテーションを Strict Office Open XML 形式で保存します。
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Office Open XML 形式で Zip64 モードでプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブで、圧縮されていない任意のファイルのサイズ、圧縮後のサイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限があり、ファイル数は 65 535 (2^16‑1) に制限されます。ZIP64 形式拡張により、これらの制限が 2^64 まで緩和されます。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは以下のモードで使用できます:

- [IfNecessary](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。これはデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#Never) は、ZIP64 形式拡張を使用しません。
- [Always](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#Always) は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX ファイルとしてプレゼンテーションを保存する方法を示しています:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zip64mode/#Never) で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **Office Open XML 形式で圧縮レベルを指定してプレゼンテーションを保存**

大きなプレゼンテーションを扱う場合、圧縮レベルを調整してファイルサイズと処理時間のバランスを取ることができます。要件に応じて、処理速度を優先したり、出力ファイルを小さくしたりできます。

Aspose.Slides は、[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) メソッドを提供しており、Office Open XML 形式で保存する際に使用する圧縮レベルを指定できます。

利用可能な圧縮レベルは以下のとおりです:

- [**None**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#None): 圧縮は行われません。ファイルはそのまま保存されます。
- [**Level1**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level1): 圧縮率が最も低く、最速の圧縮です。
- [**Level2**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level2): **Level1** より若干高い圧縮率で、比較的高速に圧縮します。
- [**Level3**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level3): **Level2** より高い圧縮率で、処理時間への影響は中程度です。
- [**Level4**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level4): **Level3** より高い圧縮率です。
- [**Level5**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level5): **Level4** より高い圧縮率で、追加の処理時間がかかります。
- [**Level6**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level6): 標準的な圧縮で、処理速度とファイルサイズのバランスが良好です。*デフォルトの圧縮レベル* です。
- [**Level7**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level7): **Level6** より高い圧縮率ですが、処理は遅くなります。
- [**Level8**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level8): **Level7** より高い圧縮率です。
- [**Level9**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compressionlevel/#Level9): 最高の圧縮率で、最も小さいファイルサイズになりますが、処理時間が最も長くなります。

以下の例は、圧縮なしで PPTX ファイルとしてプレゼンテーションを保存する方法を示しています:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

この例は、最大圧縮で PPTX ファイルとしてプレゼンテーションを保存する方法を示しています:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドは、プレゼンテーションを PPTX に保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存時にサムネイルが更新されます。これはデフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードでは、サムネイルを更新せずに PPTX としてプレゼンテーションを保存しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
このオプションは、PPTX 形式でプレゼンテーションを保存するのにかかる時間を短縮するのに役立ちます。
{{% /alert %}}

## **保存進行状況をパーセンテージで更新**

保存進捗のレポートは、[SaveOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveoptions/) およびそのサブクラスの [setProgressCallback](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) メソッドで構成します。[IProgressCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iprogresscallback/) インターフェイスを実装した Java プロキシを提供します。エクスポート中にコールバックは定期的にパーセンテージの更新を受け取ります。

以下のコードスニペットは `IProgressCallback` の使用方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // ここで進捗のパーセンテージ値を使用します。
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose は、独自の API を使用した無料の PowerPoint Splitter アプリを開発しています。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**“高速保存”（インクリメンタル保存）は、変更部分だけが書き込まれるようにサポートされていますか？**

いいえ。保存は毎回完全なターゲット ファイルを作成します。インクリメンタルな「高速保存」はサポートされていません。

**複数スレッドから同じ Presentation インスタンスを保存することはスレッドセーフですか？**

いいえ。 [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスはスレッドセーフではありません。単一のスレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/nodejs-java/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例: 相対パスで参照される動画など）は自動的にコピーされません。参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントメタデータ（作者、タイトル、会社、日付）を設定/保存できますか？**

はい。標準の [document properties](/slides/ja/nodejs-java/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。