---
title: JavaScript で PPT と PPTX を PDF に変換 [高度な機能を含む]
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint を PDF に変換
- プレゼンテーションを PDF に変換
- PPT を PDF に変換
- PPT を PDF に変換
- PPTX を PDF に変換
- PPTX を PDF に変換
- PowerPoint を PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---

## **概要**

JavaScript で PowerPoint および OpenDocument のプレゼンテーション (PPT、PPTX、ODP など) を PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式設定を保持できるという利点があります。このガイドでは、プレゼンテーションを PDF 文書に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、変換対象スライドの選択、出力文書へのコンプライアンス基準の適用方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスに渡し、`save` メソッドを使用して PDF として保存します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java は、API 情報とバージョン番号を出力文書に挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**Note** 出力文書からこの情報を変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では次のように変換できます。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い形になるよう保証します。変換時に正確にレンダリングされる要素と属性は以下のとおりです。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準の PowerPoint から PDF への変換プロセスはデフォルト オプションを使用します。この場合、Aspose.Slides は最高品質レベルの最適設定で提供されたプレゼンテーションを PDF に変換しようとします。

次のコードは、プレゼンテーション (PPT、PPTX、ODP など) を PDF に変換する方法を示しています:
```js
// PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションをPDFとして保存します。
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン **PowerPoint to PDF converter**(https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行すると、ここで説明した手順をライブで実装できます。

{{% /alert %}}

## **オプション付きでPowerPointをPDFに変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスのプロパティとしてカスタム オプションを提供し、生成される PDF のカスタマイズ、パスワードによるロック、変換プロセスの進行方法を指定できます。

### **カスタムオプションでPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを定義できます。

以下のコード例は、複数のカスタム オプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```js
// PdfOptions クラスのインスタンスを作成します。
let pdfOptions = new aspose.slides.PdfOptions();

// JPG 画像の品質を設定します。
pdfOptions.setJpegQuality(java.newByte(90));

// 画像の DPI を設定します。
pdfOptions.setSufficientResolution(300);

// メタファイルの動作を設定します。
pdfOptions.setSaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定します。
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// PDF コンプライアンスモードを定義します。
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


### **非表示スライドを含めてPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) メソッドを使用して、非表示スライドを生成される PDF のページとして含めることができます。

次の JavaScript コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
```js
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    let pdfOptions = new aspose.slides.PdfOptions();

    // 非表示スライドを追加します。
    pdfOptions.setShowHiddenSlides(true);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **パスワード保護PDFにPowerPointを変換**

次の JavaScript コードは、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護 PDF に変換する方法を示しています。
```js
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    let pdfOptions = new aspose.slides.PdfOptions();

    // PDF のパスワードとアクセス許可を設定します。
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

次の JavaScript コードは、フォント置換を検出する方法を示しています:
```js
// PDF オプションで警告コールバックを設定します。
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

フォント置換の詳細については、[Font Substitution](/slides/ja/nodejs-java/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

## **PowerPointの選択スライドをPDFに変換**

次の JavaScript コードは、PowerPoint プレゼンテーションの特定のスライドだけを PDF に変換する方法を示しています:
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


## **カスタムスライドサイズでPowerPointをPDFに変換**

次の JavaScript コードは、指定したスライド サイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
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

    // 元のプレゼンテーションから最初のスライドを複製します。
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ノート付きでリサイズされたプレゼンテーションを PDF に保存します。
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **ノートスライドビューでPowerPointをPDFに変換**

次の JavaScript コードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています:
```js
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // ノートレイアウトで PDF オプションを構成します。
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // プレゼンテーションをノート付きの PDF に保存します。
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **PDFのアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用することができます。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます: **PDF/A1a**、**PDF/A1b**、および **PDF/UA**。

次の JavaScript コードは、異なるコンプライアンス基準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています:
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

Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)、[PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) の変換が可能です。また、[PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) などの専門フォーマットへの変換もサポートされています。

{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF にすることをサポートしています。ファイルを順に処理し、プログラムから変換プロセスを適用できます。

**変換後の PDF にパスワードを設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスを使用して、変換プロセス中にパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスの `setShowHiddenSlides` メソッドを使用して、生成された PDF に非表示スライドを含めることができます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、`setJpegQuality` や `setSufficientResolution` などのメソッドを [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) クラスで使用することで、PDF の画像品質を高く保つことが可能です。

**Aspose.Slides は PDF/A コンプライアンス基準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな基準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for Node.js via Java ドキュメント](/slides/ja/nodejs-java/)
- [Aspose.Slides for Node.js via Java API リファレンス](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)