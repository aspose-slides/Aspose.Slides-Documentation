---
title: Android で PPT および PPTX を PDF に変換（高度な機能を含む）
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
- 添付ファイル
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換します。高速コード例と高度な変換オプションを提供します。"
---
## **概要**

Android で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、デバイス間の互換性が向上し、プレゼンテーションのレイアウトや書式を保持できます。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御する各種オプションの使用方法、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定スライドの選択変換、出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を **[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)** クラスの引数として渡し、**[save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)** メソッドで PDF として保存します。**[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)** クラスは、通常プレゼンテーションを PDF に変換するために使用される **[save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)** メソッドを公開しています。

{{% alert color="info" title="Note" %}}

Aspose.Slides for Android via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値が設定されます。**Note** この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドだけを PDF に変換

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

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルの最適な設定で提供されたプレゼンテーションを PDF に変換しようとします。

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

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン **[PowerPoint to PDF converter](https://products.aspose.app/slides/conversion/ppt-to-pdf)** を提供しています。このコンバータでテストを実行し、ここで説明した手順の実装を確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は **[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)** クラスのプロパティとしてカスタムオプションを提供し、結果の PDF をカスタマイズしたり、パスワードで保護したり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下の例は、PDF 1.5 にエクスポートし、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を適用します。

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

プレゼンテーションに埋め込まれた Excel ワークブックがある場合、PDF の受信者がスライドとともにワークブックのデータにアクセスできるようにしたいことがあります。`true` を指定して **[setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-)** を呼び出すと、埋め込み OLE ファイルを結果の PDF に添付ファイルとして保持できます。

デフォルトは `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページにレンダリングされますが、埋め込みファイルは添付されません。`true` に設定するとファイルデータも添付されます。プレビューは視覚的表現のままで、添付は受信者が埋め込みファイルを個別に開いたり保存したりできるようにします。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

以下の例は、既に埋め込まれた Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

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

1. 添付ファイルをサポートするビューア（例: Adobe Acrobat Reader）でエクスポートされた PDF を開きます。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探します。
3. 添付を保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付とは別です。

{{% alert color="info" title="Note" %}}

PDF/A 標準は添付ファイルに制限を課します。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付のみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。本例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。

{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、**[setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)** メソッドを **[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)** クラスで呼び出すことで、非表示スライドを PDF のページとして含めることができます。

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

### **パスワード保護された PDF に PowerPoint を変換**

以下の例は、パスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限は印刷（高品質印刷を含む）を許可します。

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

Aspose.Slides は **[setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-)** メソッドを **[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)** クラスで提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。利用できないフォントが置換されたときのみ警告が表示されます。

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

フォント置換の詳細については、[Font Substitution](/slides/ja/androidjava/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

### **専用の太字フォントがない場合の処理**

フォントに専用の太字体が存在しなくても、テキストに太字書式を適用できる場合があります。その場合、合成太字により通常のグリフが人工的に太くなりますが、PDF での表示が重すぎたり意図した外観と異なる場合は、**[PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-)** を `true` で呼び出してください。このオプションは、PDF エクスポート時に対象テキストをビットマップとしてレンダリングし、特定のフォントでの外観を改善できます。デフォルトは `false` です。

サンプルのプレゼンテーションには、同じフォントで通常テキストと太字書式が適用されたテキストボックスが 2 つ含まれています。以下の例はプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にして PDF にエクスポートします。

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

以下のプレビューは、オプション無効時と有効時の出力を示しています。この例では、オプションが無効のとき太字テキストの線が太くなります。オプションを有効にすると線が細くなり、通常テキストは変わりません。設定を選ぶ前に結果を比較してください。

| オプション無効 (`false`, デフォルト) | オプション有効 (`true`) |
|---|---|
| ![ラスタライズが無効のサポートされていないフォントスタイルの PDF](unsupported-bold-disabled.png) | ![ラスタライズが有効のサポートされていないフォントスタイルの PDF](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストのみがビットマップ化されます。OCR なしではテキストとして選択、コピー、検索できず、800% ズーム時にエッジが柔らかく表示されます。通常テキストは検索可能なままです。オプションが無効の場合、両方の文字列がテキストとして残ります。

このオプションは、専用の太字体がないフォントで太字書式が適用されたテキストをラスタライズします。**[Font substitution](/slides/ja/androidjava/font-substitution/)** は、元のフォントが利用できない場合に別のフォントを選択します。

## **プレゼンテーションから選択したスライドを PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を選択し、PDF にエクスポートします。配列内のスライド番号は 1 起算で、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

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

以下の例は、プレゼンテーションの最初のスライドを新しいプレゼンテーションにコピーし、スライドサイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライド内容を拡大縮小してフィットさせ、単一スライドを PDF にエクスポートします。

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

    // 新しいプレゼンテーションが作成されたときの空のスライドを削除します。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライド下部に配置します。スピーカーノートを含むプレゼンテーションで結果をご確認ください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下のコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示します。

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

Aspose.Slides は PDF 変換機能をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) などの特殊フォーマットへの変換もサポートしています。

{{% /alert %}}

> **Note:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複合グラフィックを単一の図形として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図形に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換できます。ファイルを列挙し、プログラムで変換プロセスを適用してください。

**変換後の PDF にパスワード保護を設定できますか？**

はい。**[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)** クラスを使用して、変換時にパスワードとアクセス権限を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

**[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)** クラスで **[setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-)** を `true` に設定すると、非表示スライドが結果の PDF に含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい。**[setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-)** や **[setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-)** などのメソッドを **[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)** で使用して、PDF の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は **[various standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/)** を含む PDF/A1a、PDF/A1b、PDF/UA へのエクスポートをサポートしており、ドキュメントがアクセシビリティおよびアーカイブ要件を満たすようにできます。

## **追加リソース**

- [Aspose.Slides for Android via Java Documentation](/slides/ja/androidjava/)
- [Aspose.Slides for Android via Java API Reference](https://reference.aspose.com/slides/androidjava/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)