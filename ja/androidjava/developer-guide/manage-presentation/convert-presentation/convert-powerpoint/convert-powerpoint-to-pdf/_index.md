---
title: Android で PPT と PPTX を PDF に変換（高度な機能を含む）
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
description: "Aspose.Slides for Android を使用し、Java で PowerPoint の PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

Android で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式を保持できるという利点があります。このガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプション、非表示スライドの含め方、PDF のパスワード保護、フォント置換の検出、変換対象スライドの選択、出力ドキュメントへのコンプライアンス基準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスの引数として渡し、`save` メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスは、プレゼンテーションを PDF に変換するためによく使用される `save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java は、API 情報とバージョン番号を出力ドキュメントに埋め込みます。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」という形式の値が設定されます。**注意**：この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides は次の変換をサポートします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションに極めて近い結果を生成します。変換時に正確に描画される要素と属性は次のとおりです。

* 画像
* テキストボックスと図形
* テキスト書式
* 段落書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最大品質レベルで最適な設定を用いてプレゼンテーションを PDF に変換しようとします。

以下のコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。

```java
// PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションをPDFとして保存します。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン **PowerPoint から PDF へのコンバータ**[https://products.aspose.app/slides/ja/conversion/ppt-to-pdf] を提供しています。このコンバータでテストを実行すると、ここで説明する手順のライブ実装を確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスのプロパティとして提供されるカスタムオプションを使用して、生成される PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの動作を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

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

// PDF コンプライアンスモードを定義します。
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

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

このコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    PdfOptions pdfOptions = new PdfOptions();

    // 非表示スライドを追加します。
    pdfOptions.setShowHiddenSlides(true);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **パスワード保護された PDF に PowerPoint を変換**

このコードは、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    PdfOptions pdfOptions = new PdfOptions();

    // PDF のパスワードとアクセス許可を設定します。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) メソッドを提供しており、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下のコードは、フォント置換を検出する方法を示しています。

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

フォント置換に関する詳細は、[フォント置換](/slides/ja/androidjava/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

## **選択したスライドだけを PowerPoint から PDF に変換**

このコードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。

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

## **カスタムスライドサイズで PowerPoint を PDF に変換**

このコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
float slideWidth = 612;
float slideHeight = 792;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");

// 調整されたスライドサイズで新しいプレゼンテーションを作成します。
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

## **ノート付きスライドビューで PowerPoint を PDF に変換**

このコードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています。

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // PDF オプションをノートレイアウトで設定します。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // プレゼンテーションをノート付きの PDF として保存します。
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF のアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下のコードは、異なるコンプライアンス基準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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

Aspose.Slides は PDF 変換操作もサポートしており、PDF を一般的なファイル形式に変換できます。たとえば、[PDF から HTML](https://products.aspose.com/slides/ja/java/conversion/pdf-to-html/)、[PDF から画像](https://products.aspose.com/slides/ja/java/conversion/pdf-to-image/)、[PDF から JPG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-jpg/)、[PDF から PNG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-png/) への変換が可能です。さらに、[PDF から SVG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-svg/)、[PDF から TIFF](https://products.aspose.com/slides/ja/java/conversion/pdf-to-tiff/)、[PDF から XML](https://products.aspose.com/slides/ja/java/conversion/pdf-to-xml/) への専門形式への変換もサポートされています。

{{% /alert %}}

> **注記**：PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図形に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF にすることをサポートしています。ファイルを列挙し、プログラムから変換処理を適用できます。

**変換後の PDF をパスワードで保護できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスを使用して、変換時にパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの `setShowHiddenSlides` メソッドを使用して、結果の PDF に非表示スライドを含めることができます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの `setJpegQuality` や `setSufficientResolution` などのメソッドを使用して、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートをサポートし、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for Android via Java ドキュメント](/slides/ja/androidjava/)
- [Aspose.Slides for Android via Java API リファレンス](https://reference.aspose.com/slides/ja/androidjava/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)