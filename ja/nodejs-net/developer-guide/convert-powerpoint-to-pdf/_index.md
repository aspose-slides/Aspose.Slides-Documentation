---
title: Node.js via .NET で PowerPoint を PDF に変換
linktitle: PowerPoint を PDF に変換
type: docs
weight: 30
url: /ja/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を PDF に変換
- PowerPoint を PDF に変換
- PPTX を PDF に変換
- PPT を PDF に変換
- ODP を PDF に変換
- プレゼンテーションを PDF として保存
- PDF/A
- PdfOptions
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET を使用して JavaScript で PPTX、PPT、ODP プレゼンテーションを PDF に変換し、PdfOptions でアーカイブ用 PDF/A ファイルを作成します。"
---
## **概要**

Aspose.Slides for Node.js via .NET は、Microsoft PowerPoint を使用せずに PowerPoint および OpenDocument のプレゼンテーションを PDF に変換します。表示されている各スライドはスライドと同じサイズの PDF ページとなり、テキストは選択可能で検索可能です。この記事では、デフォルトの変換と [PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) を使用した PDF/A への変換を紹介します。

例では、[Installation](/slides/ja/nodejs-net/installation/) で設定したプロジェクトフォルダーに `sample.pptx` という名前のプレゼンテーションがあることを想定しています。任意の PowerPoint プレゼンテーションで構いません。各例をプロジェクトフォルダーに `.js` ファイルとして保存し、そのフォルダーで `node` コマンドを実行してください。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET には独自の API リファレンスがありません。camelCase の名前で Aspose.Slides for .NET API を鏡像化しているため、この記事の API リンクは [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ja/net/) の対応するクラスやメンバーへ導きます。
{{% /alert %}}

## **プレゼンテーションをPDFに変換**

プレゼンテーションを PDF に変換する手順は次のとおりです。

1. プレゼンテーションのパスを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/presentation/) コンストラクターに渡して開きます。このコードは PPTX、PPT、ODP ファイルすべてで動作します。
1. 出力パスと `SaveFormat.Pdf` を指定して [save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを呼び出します。
1. `finally` ブロック内で `dispose` を呼び出し、プレゼンテーションを支える .NET リソースを解放します。

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

スクリプトは `sample.pdf` をプロジェクトフォルダーに書き込みます。変換はデフォルト設定で実行され、非表示でないすべてのスライドがスライド順にページとなります。ライセンスがない場合、各ページに評価用の透かしが表示されます。詳細は [Licensing](/slides/ja/nodejs-net/licensing/) を参照してください。

## **プレゼンテーションをPDF/Aに変換**

出力を制御するには、`save` の第3引数に [PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) オブジェクトを渡します。以下の例では、[compliance](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/compliance/) プロパティを `PdfCompliance.PdfA2b` に設定し、PDF/A-2b ファイルを生成しています。PDF/A は長期保存用の ISO 標準で、ドキュメントで使用されるすべてのフォントをファイルに埋め込むことが求められます。

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

スクリプトはデフォルト変換と同じページ構成で `sample-pdfa.pdf` を書き込みます。ファイルが標準に準拠しているか確認するには、[veraPDF](https://verapdf.org/) などの PDF/A バリデータで検証してください。他の [PdfCompliance](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfcompliance/) 値を使用すると、`PdfA1b`、`PdfA2a`、アクセシビリティ向けの `PdfUa` など、別の標準を選択できます。

## **FAQ**

**PDF に非表示スライドを含めるにはどうすればよいですか？**

非表示スライドはデフォルトでスキップされます。`PdfOptions` の [showHiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを `true` に設定し、オプションを `save` に渡してください。

**PDF にパスワード保護を設定できますか？**

はい。`PdfOptions` の [password](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/password/) プロパティを `save` を呼び出す前に設定します。PDF リーダーはファイルを開く際にパスワードの入力を求めます。

**一部のスライドだけを変換できますか？**

はい。`save` の第4引数にスライド位置の配列を渡します。位置は 1 から始まり、オプションが不要な場合は第3引数に `null` を指定できます。例: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` は 1 枚目と 3 枚目のスライドだけを含む PDF を生成します。

**Linux で変換するとテキストの見た目が変わるのはなぜですか？**

Aspose.Slides は変換を実行するマシンにインストールされているフォントしか使用できません。プレゼンテーションで使用されているフォントが不足している場合（例: 一般的な Linux サーバーに Calibri がない場合）、代替フォントが使用され、テキストの外観や改行位置が変わります。Windows と同じ結果を得るには、使用しているフォントをサーバーにインストールしてください。

**PDF をファイルではなく Buffer として取得できますか？**

はい。`presentation.saveToBuffer(SaveFormat.Pdf)` は PDF を Node.js の `Buffer` として返します。HTTP 応答で結果を送信する際に便利です。また、第二引数に `PdfOptions` を渡すこともできます。