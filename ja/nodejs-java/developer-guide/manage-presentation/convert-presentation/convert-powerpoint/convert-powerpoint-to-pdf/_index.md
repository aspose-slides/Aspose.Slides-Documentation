---
title: "JavaScriptでPPTとPPTXをPDFに変換する [高度な機能を含む]"
linktitle: "PPTとPPTXをPDFに変換"
type: docs
weight: 40
url: /ja/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint を変換"
- "プレゼンテーションを変換"
- "PowerPoint を PDF に変換"
- "プレゼンテーションを PDF に変換"
- "PPT を PDF に変換"
- "PPT を PDF に変換"
- "PPTX を PDF に変換"
- "PPTX を PDF に変換"
- "ODP を PDF に変換"
- "ODP を PDF に変換"
- "PowerPoint を PDF として保存"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "JavaScript"
- "Node.js"
- "Aspose.Slides for Node.js via Java"
description: "Aspose.Slides を使用して、JavaScript で PPT、PPTX、ODP プレゼンテーションを PDF に変換する方法を学びます。パスワード保護やコンプライアンス基準、カスタムオプションなどの高度な機能を実装し、高品質でアクセシブルな PDF ドキュメントを作成します。"
---

## **概要**

PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP など）を JavaScript で PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式設定を保持できるといった利点があります。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF のパスワード保護、フォント置換の検出、変換対象スライドの選択、そして出力ドキュメントに適用できるコンプライアンス基準について説明します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスの引数として渡し、`save` メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに "*Aspose.Slides*" が、PDF Producer フィールドに "*Aspose.Slides v XX.XX*" 形式の値が設定されます。**注意:** この情報を出力ドキュメントから変更または除去することはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い状態になるようにします。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキストボックスとシェイプ
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換する**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を用いてプレゼンテーションを PDF に変換しようとします。

以下のコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。
```js
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションを PDF として保存します。
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン [**PowerPoint to PDF コンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行し、ここで説明した手順の実装例を確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF のカスタマイズ、パスワード保護、変換プロセスの制御が可能です。

### **カスタムオプションで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI 設定などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```js
// PdfOptions クラスのインスタンスを作成します。
let pdfOptions = new aspose.slides.PdfOptions();

// JPG 画像の品質を設定します。
pdfOptions.setJpegQuality(java.newByte(90));

// 画像の DPI を設定します。
pdfOptions.setSufficientResolution(300);

// メタファイルの処理方法を設定します。
pdfOptions.setSaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定します。
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// PDF の準拠モードを定義します。
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // プレゼンテーションを PDF ドキュメントとして保存します。
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) メソッドを使用して、非表示スライドを生成される PDF のページとして含めることができます。

以下の JavaScript コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```js
// PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptionsクラスのインスタンスを作成します。
    let pdfOptions = new aspose.slides.PdfOptions();

    // 非表示スライドを追加します。
    pdfOptions.setShowHiddenSlides(true);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **パスワード保護された PDF に PowerPoint を変換する**

以下の JavaScript コードは、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。
```js
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    let pdfOptions = new aspose.slides.PdfOptions();

    // PDF のパスワードとアクセス権限を設定します。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下の JavaScript コードは、フォント置換を検出する方法を示しています。
```js
// PDF オプションに警告コールバックを設定します。
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("sample.pptx");

// プレゼンテーションを PDF として保存します。
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```


{{%  alert color="primary"  %}} 

レンダリング中のフォント置換に対するコールバック取得に関する詳細は、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細は、[Font Substitution](/slides/ja/nodejs-java/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **選択したスライドだけを PowerPoint から PDF に変換する**

以下の JavaScript コードは、PowerPoint プレゼンテーションの特定スライドのみを PDF に変換する方法を示しています。
```js
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // スライド番号の配列を設定します。
    let slides = java.newArray("int", [1, 3]);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **カスタムスライドサイズで PowerPoint を PDF に変換する**

以下の JavaScript コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```js
const slideWidth = 612;
const slideHeight = 792;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// 調整されたスライドサイズで新しいプレゼンテーションを作成します。
let resizedPresentation = new aspose.slides.Presentation();

try {
    // カスタムスライドサイズを設定します。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // 元のプレゼンテーションから最初のスライドをクローンします。
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // リサイズされたプレゼンテーションをノート付きの PDF として保存します。
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **ノートスライドビューで PowerPoint を PDF に変換する**

以下の JavaScript コードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています。
```js
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // PDF オプションをノートレイアウトで構成します。
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // ノート付きの PDF としてプレゼンテーションを保存します。
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **PDF のアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス基準のいずれかで PowerPoint ドキュメントを PDF にエクスポートできます: **PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の JavaScript コードは、異なるコンプライアンス基準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスをデモンストレーションします。
```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides は PDF 変換機能もサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)、[PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) の変換が可能です。また、[PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) など、特殊フォーマットへの変換もサポートされています。

{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF にすることをサポートしています。ファイルを列挙し、プログラムで変換プロセスを適用できます。

**変換した PDF にパスワードを設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスを使用して、変換時にパスワードとアクセス権限を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスの `setShowHiddenSlides` メソッドを使用して、生成される PDF に非表示スライドを含められます。

**Aspose.Slides は PDF で高画像品質を維持できますか？**

はい、`setJpegQuality` や `setSufficientResolution` などのメソッドを [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスで使用することで、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス基準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな基準に準拠した PDF のエクスポートをサポートしており、アクセシビリティやアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for Node.js via Java ドキュメント](/slides/ja/nodejs-java/)
- [Aspose.Slides for Node.js via Java API リファレンス](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)