---
title: JavaでPPTとPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPointからPDFへ
type: docs
weight: 40
url: /ja/java/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointからPDFへ
- プレゼンテーションをPDFへ
- PPTをPDFへ
- PPTをPDFに変換
- PPTXをPDFへ
- PPTXをPDFに変換
- PowerPointをPDFとして保存
- PPTをPDFとして保存
- PPTXをPDFとして保存
- PPTをPDFにエクスポート
- PPTXをPDFにエクスポート
- 添付ファイル
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、JavaでPowerPoint PPT/PPTXを高品質かつ検索可能なPDFに変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を Java で PDF 形式に変換すると、さまざまなデバイス間での互換性が向上し、プレゼンテーションのレイアウトや書式設定が保持されます。本ガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、変換対象スライドの選択、そして出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスに渡し、[save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドで PDF として保存します。 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) メソッドを公開しています。

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java は API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注意**：この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides は次の変換をサポートします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションに極めて近い PDF を生成します。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキスト ボックスと図形
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最大品質レベルで最適な設定を使用してプレゼンテーションを PDF に変換しようとします。

以下の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定で表示されているすべてのスライドを PDF に保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose は無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しており、プレゼンテーションから PDF への変換プロセスを実演しています。このコンバータでテストを実行し、ここで説明した手順を実際に確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、結果の PDF をカスタマイズしたり、PDF にパスワードを設定したり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下の例は、PDF 1.5 形式で JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を適用してプレゼンテーションをエクスポートします。

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込み Excel ワークブックが含まれている場合、PDF の受取人がワークブックのデータにアクセスできるようにしたいことがあります。`true` を指定して [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) を呼び出すと、埋め込み OLE ファイルが結果の PDF に添付ファイルとして保持されます。

デフォルトは `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付されません。`true` に設定すると、ファイルデータも添付されます。プレビューは視覚的な表現のままで、添付ファイルは受取人が別途開いたり保存したりできるようになります。OLE オブジェクト自体が PDF ページ上でインタラクティブな Excel ワークシートになるわけではありません。

以下の例は、既に埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

結果を確認する手順:

1. 添付ファイルに対応したビューア（例：Adobe Acrobat Reader）でエクスポートされた PDF を開く。  
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探す。  
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開く。PDF ページ上のプレビューは添付ファイルとは別物です。

{{% alert color="info" title="Note" %}}

PDF/A 標準は添付ファイルに制限を課します。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これは標準自体の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。

{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) メソッドを `true` に設定して、非表示スライドを PDF のページとして含めることができます。

以下の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **パスワード保護された PDF に変換**

以下の例は、開く際にパスワード `password` が必要な PDF をエクスポートします。アクセス許可では印刷（高品質印刷を含む）が許可されています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **フォント置換の検出**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) メソッドを提供し、プレゼンテーション → PDF 変換プロセス中のフォント置換を検出できます。

以下の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。利用できないフォントが置換されたときだけ警告が出力されます。

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

フォント置換の詳細については、[Font Substitution](/slides/ja/java/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

### **専用の Bold フォントがない場合の処理**

フォントに専用の Bold 書体が存在しない場合でも、テキストに太字書式を適用できることがあります。この場合、合成太字により文字が太く見えますが、PDF で意図した外観と異なる場合があります。そのようなときは、`true` を指定して [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) を呼び出します。このオプションは、PDF エクスポート時に対象テキストをビットマップとして描画し、特定フォントの外観を改善することがあります。デフォルトは `false` です。

サンプルのプレゼンテーションには、同じフォントで通常テキストと Bold 書式のテキストがそれぞれ 1 つずつ含まれています。このフォントには専用の Bold 書体がありません。以下の例はプレゼンテーションを読み込み、未対応フォントスタイルのラスタライズを有効にして PDF にエクスポートします。

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

以下のプレビューは、オプション無効時と有効時の出力を示しています。この例では、オプション無効時の太字テキストは線が太く、オプション有効時は線が細くなります。通常テキストは変わりません。設定を選択する前に結果を比較してください。

| オプション無効 (`false`、デフォルト) | オプション有効 (`true`) |
|---|---|
| ![PDF で未対応フォントスタイルのラスタライズが無効](unsupported-bold-disabled.png) | ![PDF で未対応フォントスタイルのラスタライズが有効](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストのみがビットマップ化され、OCR なしでは選択・コピー・検索できず、800% ズーム時にエッジが柔らかく表示されます。通常テキストは検索可能なままです。オプションを無効にした場合、両方の文字列がテキストとして残ります。

このオプションは、フォントに専用の Bold 書体がない場合に太字テキストをラスタライズします。[Font substitution](/slides/ja/java/font-substitution/) は、元フォントが利用できないときに別のフォントを選択します。

## **選択したスライドだけを PDF に変換**

以下の例は、プレゼンテーションのスライド 1 と 3 を PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは最低でも 3 枚のスライドを含んでいる必要があります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションの最初のスライドを新しいプレゼンテーションにコピーし、スライドサイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライド内容はフィットするようにスケーリングされ、単一スライドが PDF にエクスポートされます。

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 新しいプレゼンテーションが作成されたときに余分に入っている空のスライドを削除します。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **ノートスライド ビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライドの下に配置します。結果を確認するには、スピーカーノートを含むプレゼンテーションを使用してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PowerPoint 文書を PDF にエクスポートできます：**PDF/A-1a**、**PDF/A-1b**、**PDF/UA**。

以下のコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint → PDF 変換プロセスを示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides は PDF 変換機能をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) など、専門的な形式への変換もサポートされています。

{{% /alert %}}

> **Note:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックスを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換できます。ファイルを列挙してプログラムから変換処理を適用してください。

**変換された PDF にパスワードを設定できますか？**

はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスを使用してパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスで [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) を `true` に設定すると、結果の PDF に非表示スライドがページとして含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスの [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) や [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) メソッドを使用して、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は [様々な標準](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)（PDF/A-1a、PDF/A-1b、PDF/UA など）に準拠した PDF のエクスポートをサポートし、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for Java Documentation](/slides/ja/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)