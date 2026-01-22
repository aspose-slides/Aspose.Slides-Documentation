---
title: Android で PPT および PPTX を PDF に変換【高度な機能を含む】
linktitle: PowerPoint から PDF へ
type: docs
weight: 40
url: /ja/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint から PDF へ
- プレゼンテーションから PDF へ
- PPT から PDF へ
- PPT を PDF に変換
- PPTX から PDF へ
- PPTX を PDF に変換
- PowerPoint を PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で PowerPoint PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---

## **概要**

Android で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、デバイス間の互換性やプレゼンテーションのレイアウト・書式を保持できるなど、さまざまな利点があります。このガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定のスライドのみを変換する方法、そして出力ドキュメントに適用できるコンプライアンス基準について説明します。

## **PowerPointからPDFへの変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスに渡し、`save` メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換すると、Aspose.Slides は Application フィールドに "*Aspose.Slides*"、PDF Producer フィールドに "*Aspose.Slides v XX.XX*" 形式の値を設定します。**注意** この情報を出力ドキュメントから変更または削除することはできません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションにできるだけ忠実になるようにします。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキスト ボックスとシェイプ
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointからPDFへの変換**

標準の PowerPoint から PDF への変換プロセスは既定のオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を使用して提供されたプレゼンテーションを PDF に変換しようとします。

このコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています:
```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    //    プレゼンテーションを PDF として保存します。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン **PowerPointからPDFへのコンバータ** を提供しています。このコンバータでテストを実行し、ここで説明した手順をライブで確認できます。

{{% /alert %}}

## **PowerPointからPDFへの変換（オプションあり）**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、結果の PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプションでPowerPointからPDFへ変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを定義できます。

以下のコード例は、いくつかのカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```java
// PdfOptions クラスのインスタンスを作成します。
PdfOptions pdfOptions = new PdfOptions();

// JPG 画像の品質を設定します。
pdfOptions.setJpegQuality((byte)90);

// 画像の DPI を設定します。
pdfOptions.setSufficientResolution(300);

/// メタファイルの動作を設定します。
pdfOptions.setSaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定します。
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF の準拠モードを定義します。
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // プレゼンテーションを PDF ドキュメントとして保存します。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **非表示スライドを含むPowerPointからPDFへの変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) メソッドを使用して、非表示スライドを結果の PDF にページとして含めることができます。

このコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    PdfOptions pdfOptions = new PdfOptions();

    // 非表示スライドを含めます。
    pdfOptions.setShowHiddenSlides(true);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **パスワード保護されたPDFへのPowerPoint変換**

このコードは、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています:
```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    PdfOptions pdfOptions = new PdfOptions();

    // PDF のパスワードとアクセス権限を設定します。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

このコードは、フォント置換を検出する方法を示しています:
```java
public static void main(String[] args) {
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
    Presentation presentation = new Presentation("sample.pptx");

    // PDF オプションで警告コールバックを設定します。
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // プレゼンテーションを PDF として保存します。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// 警告コールバックの実装です。
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

フォント置換の詳細については、[フォント置換](/slides/ja/androidjava/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **PowerPointから選択したスライドをPDFへ変換**

このコードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています:
```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // スライド番号の配列を設定します。
    int[] slides = { 1, 3 };

    // プレゼンテーションを PDF として保存します。
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **カスタムスライドサイズでPowerPointをPDFに変換**

このコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
```java
float slideWidth = 612;
float slideHeight = 792;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");

// スライドサイズを調整した新しいプレゼンテーションを作成します。
Presentation resizedPresentation = new Presentation();

try {
    // カスタムスライドサイズを設定します。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // 元のプレゼンテーションから最初のスライドをクローンします。
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // リサイズしたプレゼンテーションをノート付きの PDF として保存します。
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **ノートスライドビューでPowerPointをPDFに変換**

このコードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています:
```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Notes レイアウトで PDF オプションを構成します。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // プレゼンテーションをノート付き PDF として保存します。
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **PDFのアクセシビリティと準拠基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できるようにします。次のコンプライアンス標準のいずれかを使用して PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、および **PDF/UA**。

このコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています:
```java
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルをさまざまな一般的な形式に変換できます。[PDF to HTML]、[PDF to image]、[PDF to JPG]、[PDF to PNG] 変換を実行できます。また、[PDF to SVG]、[PDF to TIFF]、[PDF to XML] といった専門的な形式への変換もサポートされています。

{{% /alert %}}

## **よくある質問**

**複数のPowerPointファイルを一括でPDFに変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを一括で PDF に変換することをサポートしています。ファイルを反復処理し、プログラムで変換プロセスを適用できます。

**変換されたPDFにパスワード保護を設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスを使用して、変換プロセス中にパスワードとアクセス許可を設定できます。

**PDFに非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの `setShowHiddenSlides` メソッドを使用して、結果の PDF に非表示スライドを含めることができます。

**Aspose.SlidesはPDFの画像品質を高く保つことができますか？**

はい、`setJpegQuality` や `setSufficientResolution` などのメソッドを使用して、PDF 内の画像品質を高く保つことができます。

**Aspose.SlidesはPDF/A準拠基準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな基準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for Android via Java ドキュメント](/slides/ja/androidjava/)
- [Aspose.Slides for Android via Java API リファレンス](https://reference.aspose.com/slides/androidjava/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)