---
title: JavaでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPointをPDFに変換
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
description: "Aspose.Slides を使用して、Java で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

Java で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウトと書式設定の保持など、複数の利点があります。このガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、変換対象スライドの選択、そして出力ドキュメントにコンプライアンス標準を適用する方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスに渡し、その後 `save` メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを提供します。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する場合、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注**：この情報を出力ドキュメントから変更または削除するよう Aspose.Slides に指示することはできません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションとほぼ同一になるようにします。変換時に要素や属性が正確にレンダリングされ、以下を含みます：

* 画像
* テキスト ボックスとシェイプ
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準的な PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最適な設定と最高品質レベルで提供されたプレゼンテーションを PDF に変換しようとします。

このコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションを PDF として保存します。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint to PDF コンバータ**](https://products.aspose.app/slides/ja/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行すれば、本ガイドで説明した手順を実際に確認できます。

{{% /alert %}}

## **オプションを使用した PowerPoint から PDF への変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/) クラスのプロパティとしてカスタム オプションを提供し、生成される PDF のカスタマイズ、パスワードによるロック、変換プロセスの進行方法を指定できます。

### **カスタム オプションを使用した PowerPoint から PDF への変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI 設定などを指定できます。

以下のコード例は、複数のカスタム オプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

// PdfOptions クラスのインスタンスを作成します。
PdfOptions pdfOptions = new PdfOptions();

// JPG 画像の品質を設定します。
pdfOptions.setJpegQuality((byte)90);

// 画像の DPI を設定します。
pdfOptions.setSufficientResolution(300);

// メタファイルの動作を設定します。
pdfOptions.setSaveMetafilesAsPng(true);

// テキスト コンテンツの圧縮レベルを設定します。
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF コンプライアンス モードを定義します。
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

### **非表示スライドを含む PowerPoint から PDF への変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) メソッドを使用して、非表示スライドを生成された PDF のページとして含めることができます。

このコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

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

### **パスワード保護された PDF への PowerPoint 変換**

このコードは、[PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

このコードは、フォント置換を検出する方法を示しています。

```java
import com.aspose.slides.*;

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

{{%  alert color="info"  %}} 

レンダリングプロセス中のフォント置換に対するコールバック取得に関する詳細は、[フォント置換の警告コールバック取得](/slides/ja/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。フォント置換に関する詳細は、[フォント置換](/slides/ja/java/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **PowerPoint の選択スライドを PDF に変換**

このコードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

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

## **カスタム スライドサイズで PowerPoint を PDF に変換**

このコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

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

    // 新しいプレゼンテーションが作成された際の空のスライドを削除します。
    resizedPresentation.getSlides().removeAt(1);

    // リサイズされたプレゼンテーションを PDF として保存します。
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **ノート スライドビューで PowerPoint を PDF に変換**

このコードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています。

```java
import com.aspose.slides.*;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // ノート レイアウトで PDF オプションを設定します。
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

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。PowerPoint ドキュメントを PDF にエクスポートする際に、**PDF/A1a**、**PDF/A1b**、**PDF/UA** のいずれかのコンプライアンス標準を使用できます。

このコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルをさまざまな一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/ja/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-png/) 変換が可能です。その他の専門的な形式への変換—[PDF to SVG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/java/conversion/pdf-to-xml/)—もサポートされています。

{{% /alert %}}

> **注:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

### 複数の PowerPoint ファイルを一括で PDF に変換できますか？

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF に一括変換することをサポートしています。ファイルを順に処理し、プログラムから変換プロセスを適用できます。

### 変換された PDF をパスワードで保護できますか？

もちろんです。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/) クラスを使用してパスワードを設定し、アクセス許可を定義できます。

### PDF に非表示スライドを含めるにはどうすればよいですか？

`setShowHiddenSlides` メソッドを [PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/) クラスで使用して、非表示スライドを生成された PDF に含めます。

### Aspose.Slides は PDF で高画質の画像を維持できますか？

はい、[PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/) クラスの `setJpegQuality` や `setSufficientResolution` などのメソッドを使用して画像品質を制御し、PDF の画像を高品質に保つことができます。

### Aspose.Slides は PDF/A のコンプライアンス標準をサポートしていますか？

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA など、[さまざまな標準](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfcompliance/) に準拠した PDF のエクスポートを可能にし、文書がアクセシビリティとアーカイブ要件を満たすようにします。

## **追加リソース**

- [Aspose.Slides for Java ドキュメント](/slides/ja/java/)
- [Aspose.Slides for Java API リファレンス](https://reference.aspose.com/slides/ja/java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)