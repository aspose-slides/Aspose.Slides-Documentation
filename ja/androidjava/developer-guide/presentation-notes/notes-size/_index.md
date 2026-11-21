---
title: Android でノートページのサイズと向きを変更する
linktitle: ノートページサイズ
type: docs
weight: 10
url: /ja/androidjava/notes-size/
keywords:
- ノートページサイズ
- ノートの向き
- 横向きノート
- 縦向きノート
- 配付資料サイズ
- PowerPoint
- プレゼンテーション
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用してノートページの寸法を読み取り・変更し、向きを切り替えて保存サイズを検証し、ノートまたは配付資料を PDF や画像にエクスポートします。"
---
## **概要**

[Presentation.getNotesSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getNotesSize--) を使用して、プレゼンテーションのノートページ設定にアクセスします。これは、[setSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) メソッドでページ寸法を設定できる [INotesSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/inotessize/) オブジェクトを返します。設定オブジェクト自体は置き換えできませんが、このメソッドで新しい寸法を割り当てることができます。

幅と高さは **ポイント** 単位で指定され、1インチあたり 72 ポイントです。たとえば、900 × 600 ポイントは 12.5 × 8⅓ インチです。これらの設定は個々のスライドのノートではなく、プレゼンテーション全体に適用されます。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getNotesSize--) | ノートページのサイズと、配付資料のエクスポートに使用されるページサイズを制御します。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlideSize--) | [ISlideSize](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidesize/) を使用して、通常のプレゼンテーションスライドのサイズを制御します。 |

どちらか一方の設定を変更しても、もう一方は自動的に変更されません。ノートページの向きを変更しても、通常のスライドは回転しません。[Slide Size](/slides/ja/androidjava/slide-size/) を参照して、通常のスライドのサイズを変更してください。

以下の例は既存の `sample.pptx` を使用します。エクスポートの例では、スピーカーノートを含むスライドが少なくとも 1 枚あるプレゼンテーションを使用してください。各例は独立して実行できます。

## **ノートページのサイズと向きの読み取り**

幅と高さを取得し比較して、向きを判定します。幅が大きいページは横向き（ランドスケープ）、高さが大きいページは縦向き（ポートレート）、サイズが同じ場合は正方形です。この例は、標準用紙サイズを前提とせず、実際の寸法をポイント単位で出力します。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

向きだけを変更するには、既存の幅と高さを入れ替えます。これにより、カスタム用紙サイズを含む両側の長さが保持されます。以下の条件は、すでに横向きのページが縦向きに戻されることを防ぎ、正方形のページは変更しません。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ポートレート向きの場合は、`size.getWidth() > size.getHeight()` のときに同じ代入を使用してください。用紙サイズも変更したい場合以外は、A4 や Letter の寸法に置き換えないでください。

## **カスタムノートページサイズの設定と検証**

両方の寸法を同時に設定し、[Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) を使用してプレゼンテーションを書き込みます。この例では、900 × 600 ポイントの横向きページを設定し、PPTX として保存し、保存されたファイルを再度開いて保持された値を確認します。比較では浮動小数点値に対して 0.01 ポイントの許容差を認めていますが、すべてのファイル形式での精度を保証するものではありません。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

期待される結果は `900.0 x 600.0 points` と `Size preserved: true` です。新たに開いたプレゼンテーションを確認することで、保存されたファイルが正しいことを検証します。

## **ノートと配付資料のエクスポート**

ページ寸法はノートや配付資料のレイアウト領域を定義しますが、それだけではレイアウトは有効になりません。エクスポートオプションも設定してください。通常のスライドのエクスポートはスライドの寸法を使用し続けます。

### **ノートを PDF と PNG にエクスポート**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notescommentslayoutingoptions/) を [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) に割り当てて、PDF にノートを含めます。この例では、[Slide.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) と [RenderingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングします。

[BottomTruncated](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notespositions/) モードはノートを1ページに保ち、収まりきらないノートは切り捨てられます。PDF は 900 × 600 ポイントのページを使用します。下記で使用した 1 × 1 の画像スケールでは、PNG は 900 × 600 ピクセルになります。ポイントはページの幾何形状を表し、ピクセルはラスタ出力を表し、寸法はレンダリングスケールにも依存します。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

長いノートがある PDF エクスポートの場合、[BottomFull](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notespositions/) は必要に応じて追加ページを許可します。上記の単一スライド画像呼び出しではこのモードはサポートされていないので使用しないでください。サイズ変更後は、ノートが切り取られていないか、既存の notes‑master オブジェクトの配置を確認してください。ページ寸法だけを変更しても、すべてのコンテンツが収まる保証にはなりません。ノートエクスポートの詳細は [Convert PowerPoint to PDF with Notes](/slides/ja/androidjava/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **配付資料を PDF にエクスポート**

1ページに複数のスライドサムネイルを配置するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handoutlayoutingoptions/) を使用します。以下の例では、900 × 600 ポイントのページを設定し、[HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handouttype/) を使用して1ページに最大4枚のスライドを配置します。水平プリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

ページサイズを変更すると、配付資料のグリッドが利用できる領域が変わりますが、元のスライドの寸法は変わりません。配付資料の画像を取得するには、個々のスライドの画像メソッドではなく、配付レイアウトで [Presentation.getImages](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) を使用してください。Aspose.Slides では、プレゼンテーションレベルの配付資料レンダリングはノートページの寸法を使用し、個別スライドの画像呼び出しは配付ページを生成しません。レイアウトオプションについては [Handout Mode](/slides/ja/androidjava/convert-powerpoint-in-handout-mode/) を参照してください。

## **ビューア、エクスポート、印刷におけるページサイズ**

保存されたプレゼンテーションサイズ、エクスポートされたページサイズ、印刷時の紙サイズは別々に管理してください。

- **Presentation viewers:** ビューアは独自のレイアウト規則でノートを表示または印刷できます。他のアプリケーションがファイルを保存した場合は、再度開いて寸法を確認してください。そのアプリケーションのフォーマット変換により正規化されることがあります。
- **Export formats:** 上記のノートおよび配付資料の PDF 例は設定されたページ寸法を使用します。ラスタ画像は整数ピクセル寸法とレンダリングスケールを使用するため、ポイントの小数部分は画像出力時に丸められることがあります。通常のスライドのエクスポートはノートページサイズを適用しません。
- **Printer drivers:** 用紙選択、自動回転、ページに合わせる設定などにより、物理的な出力が変わることがありますが、プレゼンテーションや PDF に保存された寸法は変わりません。特定の用紙サイズの場合は、プリンタ設定と印刷プレビューを一致させて確認してください。

## **FAQ**

**ノートサイズをスライド単位で設定できますか？**

ノートページサイズはプレゼンテーション全体の設定です。個々のスライドは異なるノート内容を持てますが、このプロパティはスライドごとに別個のページサイズを提供しません。

**ノートの向きを変更してもスライドが変わらなかったのはなぜですか？**

ノートページと通常のスライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常のスライドサイズ設定を使用してください。

**保存または印刷した結果が異なるサイズになるのはなぜですか？**

まず保存したプレゼンテーションを再度開き、ノートの寸法を比較してください。変更されている場合は、別のアプリケーションで保存または変換した際にページ設定が変更されたか確認します。変更されていない場合は、エクスポートレイアウト、画像スケール、ビューア設定、プリンタの用紙選択を確認してください。