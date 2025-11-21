---
title: "JavaScriptでプレゼンテーションを保存する"
linktitle: "プレゼンテーションの保存"
type: docs
weight: 80
url: /ja/nodejs-java/save-presentation/
keywords:
- "PowerPoint を保存"
- "OpenDocument を保存"
- "プレゼンテーションを保存"
- "スライドを保存"
- "PPT を保存"
- "PPTX を保存"
- "ODP を保存"
- "ファイルへのプレゼンテーション"
- "ストリームへのプレゼンテーション"
- "事前定義ビュータイプ"
- "Strict Office Open XML 形式"
- "Zip64 モード"
- "サムネイルの更新"
- "保存進行状況"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides を使用して JavaScript でプレゼンテーションを保存する方法を学びます。PowerPoint や OpenDocument へエクスポートし、レイアウト、フォント、エフェクトを保持します。"
---

## **Overview**

[JavaScript でプレゼンテーションを開く](/slides/ja/nodejs-java/open-presentation/) では、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法が説明されています。本記事では、プレゼンテーションの作成と保存の方法を解説します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のプレゼンテーションを修正する場合でも、作業が完了したら保存する必要があります。Aspose.Slides for Node.js では、**ファイル** または **ストリーム** に保存できます。本記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **Save Presentations to Files**

`save` メソッドを呼び出すことで、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスを使用してプレゼンテーションをファイルに保存できます。メソッドにファイル名と保存形式を渡してください。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。
```js
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


## **Save Presentations to Streams**

`save` メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリーム型に書き込むことができます。下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存しています。
```js
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // ストリームにプレゼンテーションを保存します。
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **Save Presentations with a Predefined View Type**

Aspose.Slides では、[ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/) クラスを介して生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを設定できます。[setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) メソッドに [ViewType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/) 列挙体の値を指定してください。
```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Save Presentations in the Strict Office Open XML Format**

Aspose.Slides では、プレゼンテーションを Strict Office Open XML 形式で保存できます。[PptxOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/) クラスを使用し、保存時に its conformance プロパティを設定してください。[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存する方法を示しています。
```js
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


## **Save Presentations in Office Open XML Format in Zip64 Mode**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの未圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限を課し、アーカイブ内のファイル数は 65 535 (2^16‑1) に制限されます。ZIP64 形式拡張により、これらの制限が 2^64 まで緩和されます。

[**PptxOptions.setZip64Mode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは次のモードで使用できます。

- [**IfNecessary**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。これがデフォルトモードです。
- [**Never**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) は、ZIP64 形式拡張を決して使用しません。
- [**Always**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Always) は、常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張が有効な状態で PPTX としてプレゼンテーションを保存する方法を示しています。
```js
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

[**Zip64Mode.Never**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [**PptxException**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **Save Presentations without Refreshing the Thumbnail**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドは、PPTX にプレゼンテーションを保存する際のサムネイル生成を制御します。

- `true` に設定すると、保存中にサムネイルが更新されます。既定値です。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードでは、サムネイルを更新せずに PPTX としてプレゼンテーションを保存しています。
```js
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

このオプションを使用すると、PPTX 形式でプレゼンテーションを保存するのにかかる時間を短縮できます。
{{% /alert %}}

## **Save Progress Updates in Percentage**

保存進行状況の報告は、[SaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) およびそのサブクラスの [setProgressCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) メソッドで構成します。Java プロキシで [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) インターフェイスを実装し、エクスポート中にコールバックが定期的にパーセンテージ更新を受け取ります。

以下のコードスニペットは、`IProgressCallback` の使用方法を示しています。
```javascript
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

Aspose は、独自の API を使用した無料の PowerPoint Splitter アプリをご提供しています。選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（インクリメンタル保存）はサポートされていますか？変更分だけを書き込むことは可能ですか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数スレッドから同時に保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) インスタンスはスレッドセーフではありません。単一スレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/nodejs-java/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例: 相対パスで参照される動画など）は自動的にコピーされません。参照先パスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（作者、タイトル、会社、日付など）を設定/保存できますか？**

はい。標準の[ドキュメントプロパティ](/slides/ja/nodejs-java/presentation-properties/) がサポートされており、保存時にファイルへ書き込まれます。