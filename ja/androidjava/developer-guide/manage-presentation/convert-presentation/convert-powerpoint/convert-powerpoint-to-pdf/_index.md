---
title: Android で PPT と PPTX を PDF に変換 [高度な機能を含む]
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で PowerPoint の PPT / PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

Android で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、デバイス間の互換性やプレゼンテーションのレイアウトと書式の保持など、さまざまな利点があります。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの包含、PDF のパスワード保護、フォント置換の検出、特定スライドの選択変換、および出力ドキュメントへの準拠基準の適用について説明します。

## **PowerPoint を PDF に変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスに渡し、`save` メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに "*Aspose.Slides*" を、PDF Producer フィールドに "*Aspose.Slides v XX.XX*" 形式の値を設定します。**注意**：出力ドキュメントからこの情報を変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、結果の PDF が元のプレゼンテーションとほぼ同一になるようにします。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキストボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最適な設定で最大品質レベルの PDF に変換しようとします。

以下のコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。

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

Aspose は無料のオンライン [**PowerPoint to PDF コンバータ**](https://products.aspose.app/slides/ja/conversion/ppt-to-pdf) を提供しており、プレゼンテーションから PDF への変換プロセスを実演しています。このコンバータでテストを実行し、ここで説明する手順をライブで確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの動作を指定したりできます。

### **カスタムオプション付きで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

// PdfOptions クラスのインスタンスを生成します。
PdfOptions pdfOptions = new PdfOptions();

// JPG 画像の品質を設定します。
pdfOptions.setJpegQuality((byte)90);

// 画像の DPI を設定します。
pdfOptions.setSufficientResolution(300);

/// メタファイルの動作を設定します。
pdfOptions.setSaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定します。
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF 準拠モードを定義します。
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // プレゼンテーションを PDF ドキュメントとして保存します。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) メソッドを使用して、非表示スライドを結果の PDF にページとして含めることができます。

以下のコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを生成します。
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

以下のコードは、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを生成します。
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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) メソッドを提供しており、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下のコードは、フォント置換を検出する方法を示しています。

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
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

{{%  alert color="info"  %}} 

フォント置換の詳細については、[Font Substitution](/slides/ja/androidjava/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

## **PowerPoint から PDF へ選択スライドだけを変換**

以下のコードは、PowerPoint プレゼンテーションから特定のスライドだけを抽出して PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
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

以下のコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
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

    // リサイズしたプレゼンテーションを PDF として保存します。
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下のコードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています。

```java
import com.aspose.slides.*;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Notes レイアウトで PDF オプションを設定します。
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

## **PDF のアクセシビリティと準拠基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次の準拠標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下のコードは、異なる準拠基準に基づく複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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

Aspose.Slides は PDF 変換機能をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/ja/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-png/) の変換が可能です。また、[PDF to SVG](https://products.aspose.com/slides/ja/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/java/conversion/pdf-to-xml/) といった特殊形式への変換もサポートしています。

{{% /alert %}}

> **注意:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図形に対してのみ提供されます。

## **FAQ**

### 複数の PowerPoint ファイルを一括で PDF に変換できますか？

はい、Aspose.Slides は複数の PPT または PPTX ファイルを一括で PDF に変換するバッチ機能をサポートしています。ファイルを順に処理し、プログラムから変換プロセスを適用できます。

### 変換後の PDF にパスワードを設定できますか？

もちろんです。[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスを使用して、変換時にパスワードとアクセス権限を設定できます。

### PDF に非表示スライドを含めるにはどうすればよいですか？

[PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスの `setShowHiddenSlides` メソッドを使用して、結果の PDF に非表示スライドを含めます。

### Aspose.Slides は PDF の画像品質を高く保てますか？

はい、`setJpegQuality` や `setSufficientResolution` などのメソッドを [PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/) クラスで使用することで、PDF 内の画像品質を高く保つことができます。

### Aspose.Slides は PDF/A 準拠基準をサポートしていますか？

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな準拠基準に従った PDF のエクスポートを可能にし、アクセシビリティと長期保存の要件を満たします。

## **追加リソース**

- [Aspose.Slides for Android via Java ドキュメント](/slides/ja/androidjava/)
- [Aspose.Slides for Android via Java API リファレンス](https://reference.aspose.com/slides/ja/androidjava/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)