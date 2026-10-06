---
title: Java でノートページのサイズと向きを変更する
linktitle: ノートページサイズ
type: docs
weight: 10
url: /ja/java/notes-size/
keywords:
- ノートページサイズ
- ノートの向き
- 横向きノート
- 縦向きノート
- 配布資料サイズ
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でノートページの寸法を読み取り・変更し、向きを切り替えて保存されたサイズを検証し、ノートまたは配布資料を PDF や画像にエクスポートします。"
---
## **概要**

プレゼンテーションのノートページ設定にアクセスするには、[Presentation.getNotesSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getNotesSize--) を使用します。このメソッドはページの寸法を設定する [setSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) メソッドを持つ [INotesSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/inotessize/) オブジェクトを返します。設定オブジェクト自体は置き換えられませんが、このメソッドを使用して新しい寸法を割り当てることができます。

幅と高さは **ポイント** 単位で指定され、1インチは72ポイントです。たとえば、900 × 600 ポイントは 12.5 × 8⅓ インチに相当します。これらの設定はプレゼンテーション全体に適用され、個々のスライドのノートには適用されません。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getNotesSize--) | ノートページの寸法と配布資料エクスポートに使用されるページ寸法を制御します。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlideSize--) | 通常のプレゼンテーションスライドの寸法を [ISlideSize](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidesize/) を介して制御します。 |

どちらかの設定を変更しても、もう一方が自動的に変更されることはありません。ノートページの向きを変更しても、通常のスライドは回転しません。通常のスライドのサイズ変更については、[スライドサイズ](/slides/ja/java/slide-size/) を参照してください。

以下の例は既存の `sample.pptx` を使用します。エクスポート例では、スピーカーノートを含むスライドが少なくとも1枚あるプレゼンテーションを使用してください。各例は個別に実行できます。

## **ノートページのサイズと向きの読み取り**

幅と高さを読み取り、比較して向きを判定します。幅が大きいページは横向き、高さが大きいページは縦向き、サイズが同じ場合は正方形になります。この例は標準用紙サイズを仮定せず、実際のポイント寸法を出力します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **用紙サイズを変更せずに横向きに切り替える**

向きだけを変更するには、既存の幅と高さを入れ替えます。これによりカスタム用紙サイズを含む両側の長さが保存されます。下記の条件は、すでに横向きのページが縦向きに戻されるのを防ぎ、正方形のページは変更しません。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

縦向きにしたい場合は、`size.getWidth() > size.getHeight()` のときに同様の代入を行います。用紙サイズも変更したい場合以外は、A4 や Letter の寸法を置き換えないでください。

## **カスタムノートページサイズの設定と検証**

両方の寸法をまとめて割り当て、次に [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) を使用してプレゼンテーションを書き出します。この例は 900 × 600 ポイントの横向きページを設定し、PPTX として保存し、保存したファイルを再度開いて永続化された値を確認します。比較では浮動小数点数の誤差として 0.01 ポイントの許容範囲を設けていますが、すべてのファイル形式での精度を保証するものではありません。

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

期待される結果は `900.0 x 600.0 points` と `Size preserved: true` です。新たに開いたプレゼンテーションを確認することで、メモリ上の設定だけでなく保存されたファイルも検証できます。

## **ノートと配布資料のエクスポート**

ページ寸法はノートや配布資料レイアウトで使用できる領域を定義しますが、これだけではレイアウトが有効になるわけではありません。エクスポートオプションも併せて設定してください。通常のスライドのエクスポートはスライド寸法を引き続き使用します。

### **ノートをPDFおよびPNGにエクスポート**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notescommentslayoutingoptions/) を [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) に割り当てて PDF にノートを含めます。この例はさらに、[Slide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) と [RenderingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングします。

[BottomTruncated](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notespositions/) モードはノートを1ページに収め、収まりきらないノートは切り捨てられます。PDF は 900 × 600 ポイントのページを使用します。以下で使用する 1 × 1 の画像スケールでは、PNG は 900 × 600 ピクセルになります。ポイントはページの幾何形状を表し、ピクセルはラスタ出力を表し、出力サイズはレンダリングスケールにも依存します。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

長いノートを含む PDF エクスポートの場合、[BottomFull](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notespositions/) を使用すると必要に応じて追加ページが生成されます。上記の単一スライド画像呼び出しではこのモードはサポートされていないため使用しないでください。サイズ変更後は、ノートが切り取られていないか、既存のノートマスタオブジェクトの配置を確認してください。ページ寸法だけを変更したからといって、すべてのコンテンツが収まる保証はありません。ノートのエクスポートに関する詳細は、[Convert PowerPoint to PDF with Notes](/slides/ja/java/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **配布資料をPDFにエクスポート**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handoutlayoutingoptions/) を使用して、1ページに複数のスライドサムネイルを配置します。以下の例は 900 × 600 ポイントのページを設定し、[HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handouttype/) を使用して最大4枚のスライドを横向きに配置します。横方向のプリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

ページサイズを変更すると、配布資料グリッドが使用できる領域が変わりますが、元スライドの寸法は変わりません。配布資料画像を取得する場合は、個々のスライドの画像メソッドではなく、配布資料レイアウトを指定して [Presentation.getImages](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) を使用してください。Aspose.Slides では、プレゼンテーションレベルの配布資料レンダリングがノートページ寸法を使用し、個別スライドの画像呼び出しは配布資料ページを生成しません。レイアウトオプションの詳細は、[Handout Mode](/slides/ja/java/convert-powerpoint-in-handout-mode/) を参照してください。

## **ビューア、エクスポート、印刷時のページサイズ**

保存されたプレゼンテーションサイズ、エクスポートされたページサイズ、印刷された用紙サイズを明確に区別してください。

- **Presentation viewers:** ビューアは独自のレイアウト規則でノートを表示または印刷できます。別のアプリケーションがファイルを保存した場合は再度開いて寸法を確認してください。そのアプリケーションの形式変換により寸法が正規化されることがあります。
- **Export formats:** 上記のノートおよび配布資料 PDF の例は設定されたページ寸法を使用します。ラスタ画像は整数ピクセル寸法とレンダリングスケールを使用するため、画像出力時に小数点以下のポイント値が丸められることがあります。通常スライドのエクスポートではノートページサイズは適用されません。
- **Printer drivers:** 用紙の選択、 自動回転、 ページに合わせる設定により、物理的な出力が変わりますが、プレゼンテーションや PDF に保存されている寸法は変わりません。特定の用紙サイズで印刷する場合は、プリンタ設定を合わせてプレビューを確認してください。

## **FAQ**

**スライド1枚だけのノートサイズを設定できますか？**  
ノートページサイズはプレゼンテーション全体の設定です。個々のスライドは別々のノート内容を持てますが、このプロパティではスライドごとに別のページサイズを指定することはできません。

**ノートページの向きを変更してもスライドが変わらなかったのはなぜですか？**  
ノートページと通常スライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常スライドサイズの設定を使用してください。

**保存したファイルや印刷した結果のサイズが異なるのはなぜですか？**  
まず、保存したプレゼンテーションを再度開いてノート寸法を比較してください。別のアプリケーションで保存または変換した際にページ設定が変わっている可能性があります。設定が変わっていない場合は、エクスポートのレイアウト、画像スケール、ビューアの設定、プリンタの用紙選択を確認してください。