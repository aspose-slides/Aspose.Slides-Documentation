---
title: JavaScriptでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /ja/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointをPDFに変換
- プレゼンテーションをPDFに変換
- PPTをPDFに変換
- PPTをPDFに変換
- PPTXをPDFに変換
- PPTXをPDFに変換
- PowerPointをPDFとして保存
- PPTをPDFとして保存
- PPTXをPDFとして保存
- PPTをPDFにエクスポート
- PPTXをPDFにエクスポート
- 添付
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint の PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

JavaScript で PowerPoint および OpenDocument プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式を保持できるといった利点があります。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定スライドの選択変換、コンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスに渡し、[save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="注意" %}}

Aspose.Slides for Node.js via Java は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値が設定されます。**注意**：この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドだけを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションに極めて近い PDF を生成します。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint‑to‑PDF 変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を用いて提供されたプレゼンテーションを PDF に変換しようとします。

以下の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定で表示スライドすべてを PDF に保存します。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="注意" %}}

Aspose は、プレゼンテーション‑to‑PDF 変換プロセスを実演する無料のオンライン [**PowerPoint to PDF コンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行し、ここで説明する手順を実際に確認できます。

{{% /alert %}}

## **オプション付き PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF のカスタマイズ、パスワードによるロック、変換プロセスの挙動指定が可能です。

### **カスタムオプション付き PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下の例は、PDF 1.5 にエクスポートし、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG で保存し、Flate テキスト圧縮を適用します。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込み Excel ワークブックが含まれている場合、PDF の受信者がスライドと同時にワークブックのデータにもアクセスできるようにしたいことがあります。`true` を指定して [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) を呼び出すと、埋め込み OLE ファイルが生成された PDF の添付ファイルとして保持されます。

デフォルトは `false` で、OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに表示されますが、埋め込みファイルは添付されません。`true` に設定すると、ファイルデータも添付されます。プレビューは視覚的表現のままで、添付は受信者が埋め込みファイルを個別に開いたり保存したりできるようにします。OLE オブジェクト自体が PDF ページ上でインタラクティブな Excel ワークシートになるわけではありません。

以下の例は、既に埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

結果を確認する手順:

1. 添付ファイルに対応したビューア（例: Adobe Acrobat Reader）でエクスポートされた PDF を開く。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探す。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開く。PDF ページ上のプレビューは添付とは別物です。

{{% alert color="info" title="注意" %}}

PDF/A 標準は添付ファイルに制限を課します。PDF/A‑1 は埋め込みファイルを禁止し、PDF/A‑2 は PDF/A の添付ファイルのみを許可し、PDF/A‑3 は Excel ワークブックを含む他のファイルタイプも許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。

{{% /alert %}}

### **非表示スライドを含む PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) メソッドを使用して、非表示スライドを生成される PDF のページとして含めることができます。

以下の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **パスワード保護された PDF に PowerPoint を変換**

以下の例は、`password` というパスワードで開く必要がある PDF にプレゼンテーションをエクスポートします。アクセス権限では印刷（高品質印刷含む）が許可されています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラス配下の [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) メソッドを提供し、プレゼンテーション‑to‑PDF 変換プロセス中のフォント置換を検出できます。

以下の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。利用できないフォントが置換されたときだけ警告が出力されます。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="注意" %}}

フォント置換の詳細については、[Font Substitution](/slides/ja/nodejs-java/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

### **専用の Bold フォントがない場合の処理**

フォントに専用の Bold 体がなくても、プレゼンテーションはテキストに太字書式を適用できます。このテキストは合成太字（シンセティック・ボールド）として表示され、通常のグリフを人工的に太くします。PDF で見たときに太さが過剰または意図した外観と異なる場合は、`true` で [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) を呼び出してみてください。このオプションは、PDF 出力時に該当テキストをビットマップとして描画し、特定フォントでの外観を改善できる場合があります。デフォルトは `false` です。

サンプル プレゼンテーションには、同一フォントで通常テキストと Bold 書式のテキストボックスがそれぞれ 1 つずつ含まれています。そのフォントには専用の Bold 体がありません。以下の例はプレゼンテーションを読み込み、未対応フォントスタイルのラスター化を有効にして PDF にエクスポートします。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

次のプレビューは、オプション無効時と有効時の出力を示しています。この例では、オプション無効時の Bold テキストは線が太く、オプション有効時は線が細くなります。通常テキストは変わりません。設定を選択する前に結果を比較してください。

| オプション無効 (`false`、既定) | オプション有効 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると Bold テキストのみがビットマップ化されます。OCR なしでは選択・コピー・検索できず、800% ズーム時にエッジがやわらかく表示されます。通常テキストは検索可能なままです。オプション無効時は両方の文字列がテキストとして残ります。

このオプションは、フォントに専用の Bold 体がない場合に Bold 書式のテキストをビットマップ化します。代わりに [Font substitution](/slides/ja/nodejs-java/font-substitution/) は、元フォントが利用できないときに別のフォントを選択します。

## **選択スライドのみを PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を抽出し、PDF にエクスポートします。配列内のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 スライド以上含んでいる必要があります。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下の例は、最初のスライドを新しいプレゼンテーションにコピーし、スライドサイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライド内容を拡大縮小して収め、単一スライドを PDF にエクスポートします。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 新しいプレゼンテーションが作成されたときの空のスライドを削除します。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライド下部に配置します。ノートが含まれるプレゼンテーションで結果をご確認ください。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下のコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint‑to‑PDF 変換プロセスを示しています。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="注意" %}}

Aspose.Slides は PDF 変換機能をサポートしており、PDF ファイルを一般的なフォーマットに変換できます。[PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)、[PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) などの特殊フォーマットへの変換もサポートしています。

{{% /alert %}}

> **注意:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF にすることをサポートしています。ファイルを列挙し、プログラムで変換処理を適用できます。

**変換後の PDF にパスワードを設定できますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスを使用して、変換時にパスワードとアクセス権限を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) メソッドに `true` を渡すことで、生成される PDF に非表示スライドを含められます。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) クラスの [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) や [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) メソッドを使用して、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は [various standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) を含む PDF/A1a、PDF/A1b、PDF/UA へのエクスポートをサポートし、アクセシビリティとアーカイブ要件を満たすドキュメントを生成できます。

## **追加リソース**

- [Aspose.Slides for Node.js via Java Documentation](/slides/ja/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)