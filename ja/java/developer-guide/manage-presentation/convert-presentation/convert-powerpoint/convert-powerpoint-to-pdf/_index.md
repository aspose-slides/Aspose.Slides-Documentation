---
title: JavaでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPointからPDFへ
type: docs
weight: 40
url: /ja/java/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointからPDFへ
- プレゼンテーションからPDFへ
- PPTからPDFへ
- PPTをPDFに変換
- PPTXからPDFへ
- PPTXをPDFに変換
- PowerPointをPDFとして保存
- PPTをPDFとして保存
- PPTXをPDFとして保存
- PPTをPDFにエクスポート
- PPTXをPDFにエクスポート
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java で PowerPoint PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---

## **概要**

Java で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウト・書式を保持できるといった利点があります。このガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF のパスワード保護、フォント置換の検出、変換対象スライドの選択、出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスに渡し、`save` メソッドで PDF として保存します。`save` メソッドは通常、プレゼンテーションを PDF に変換するために使用されます。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java は API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する場合、Application フィールドに「*Aspose.Slides*」、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」の形式の値が設定されます。**注**：Aspose.Slides にこの情報を変更または除去させることはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドだけを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションと非常に近い結果を得られます。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキストボックスとシェイプ
* テキスト書式
* 段落書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* テーブル

## **PowerPoint を PDF に変換する**

標準の PowerPoint から PDF への変換プロセスは既定のオプションを使用します。この場合、Aspose.Slides は最大品質レベルで最適な設定を用いてプレゼンテーションを PDF に変換しようとします。

以下のコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。
```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションを PDF として保存します。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン **PowerPoint to PDF converter**（https://products.aspose.app/slides/conversion/ppt-to-pdf）を提供しています。このコンバータでテストを実行し、ここで説明した手順の実装をライブで確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF のカスタマイズ、パスワードでのロック、変換プロセスの進行方法を指定できます。

### **カスタムオプションで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```java
// PdfOptions クラスのインスタンスを作成します。
PdfOptions pdfOptions = new PdfOptions();

// JPG 画像の品質を設定します。
pdfOptions.setJpegQuality((byte)90);

// 画像の DPI を設定します。
pdfOptions.setSufficientResolution(300);

// メタファイルの扱いを設定します。
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


### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) メソッドを使用して、非表示スライドを PDF のページとして含めることができます。

以下のコードは、非表示スライドを含めて PowerPoint を PDF に変換する方法を示しています。
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


### **パスワード保護された PDF に PowerPoint を変換する**

以下のコードは、[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護付き PDF に変換する方法を示しています。
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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下のコードは、フォント置換を検出する方法を示しています。
```java
public static void main(String[] args) {
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
    Presentation presentation = new Presentation("sample.pptx");

    // PDF オプションで警告コールバックを設定します。
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // プレゼンテーションを PDF として保存します。
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// 警告コールバックの実装。
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

レンダリングプロセス中のフォント置換に関するコールバック取得の詳細については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細情報は、[Font Substitution](/slides/ja/java/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **選択したスライドだけを PowerPoint から PDF に変換する**

以下のコードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。
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


## **カスタムスライドサイズで PowerPoint を PDF に変換する**

以下のコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
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

    // リサイズしたプレゼンテーションをノート付き PDF として保存します。
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **ノートスライドビューで PowerPoint を PDF に変換する**

以下のコードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています。
```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // ノートレイアウトで PDF オプションを構成します。
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


## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下のコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。
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

Aspose.Slides は PDF 変換操作もサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) などの特殊フォーマットへの変換もサポートされています。

{{% /alert %}}

## **よくある質問**

1. **複数の PowerPoint ファイルを一括で PDF に変換できますか？**

   はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換できます。ファイルを列挙し、プログラムで変換処理を適用してください。

2. **変換後の PDF にパスワードを設定できますか？**

   もちろんです。[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスを使用して、変換時にパスワードとアクセス権限を設定できます。

3. **PDF に非表示スライドを含めるにはどうすればよいですか？**

   [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスの `setShowHiddenSlides` メソッドを使用して、非表示スライドを生成される PDF に含めることができます。

4. **Aspose.Slides は PDF の画像品質を高く保てますか？**

   はい、`setJpegQuality` や `setSufficientResolution` などのメソッドを [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) クラスで使用し、PDF 内の画像を高品質に保つことができます。

5. **Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

   はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートをサポートし、アクセシビリティと長期保存の要件を満たします。

## **追加リソース**

- [Aspose.Slides for Java Documentation](/slides/ja/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)