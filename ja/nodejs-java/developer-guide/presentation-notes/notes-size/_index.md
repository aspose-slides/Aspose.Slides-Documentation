---
title: JavaScript でノートページのサイズと向きを変更する
linktitle: ノートページサイズ
type: docs
weight: 10
url: /ja/nodejs-java/notes-size/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を Java 経由で使用し、ノートページの寸法を読み取り・変更し、向きを切り替え、保存されたサイズを検証し、ノートや配布資料を PDF や画像にエクスポートします。"
---
## **概要**

Presentation.getNotesSize を使用して、プレゼンテーションのノートページ設定にアクセスします。  
このメソッドは、ページのサイズを設定する [setSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notessize/setsize/) メソッドを持つ [NotesSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notessize/) オブジェクトを返します。設定オブジェクト自体は置き換えることはできませんが、このメソッドを使用して新しい寸法を割り当てることができます。

幅と高さは **ポイント** で指定され、1 インチは 72 ポイントです。たとえば、900 × 600 ポイントは 12.5 × 8⅓ インチです。これらの設定はプレゼンテーション全体に適用され、個々のスライドのノートには適用されません。

| 設定 | 目的 |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getnotessize/) | ノートページのサイズと、ハンドアウトエクスポートに使用されるページサイズを制御します。 |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslidesize/) | SlideSize を使用して、通常のプレゼンテーションスライドのサイズを制御します。 |

いずれかの設定を変更しても、もう一方が自動的に変更されることはありません。ノートページの向きを変更しても、通常のスライドは回転しません。通常のスライドのサイズを変更するには、[Slide Size](/slides/ja/nodejs-java/slide-size/) を参照してください。

以下の例は既存の `sample.pptx` を使用します。エクスポートの例では、スピーカーノートを含むスライドが少なくとも 1 枚あるプレゼンテーションを使用してください。各例は個別に実行できます。

## **ノートページのサイズと向きの読み取り**

幅と高さを読み取り、比較して向きを判断します。幅が大きいページは横向き、高さが大きいページは縦向き、サイズが同じ場合は正方形です。この例は標準用紙サイズを想定せず、実際の寸法をポイントで出力します。

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **用紙サイズを変更せずに横向きに切り替える**

向きだけを変更するには、既存の幅と高さを入れ替えます。これにより、カスタム用紙サイズを含む両側の長さが保持されます。下記の条件は、すでに横向きのページが縦向きに戻されるのを防ぎ、正方形のページは変更しません。

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

縦向きの場合は、`size.getWidth() > size.getHeight()` のときに同じ代入を使用します。用紙サイズも変更したい場合以外は、A4 や Letter の寸法に置き換えないでください。

## **カスタムノートページサイズの設定と検証**

両方の寸法を一度に割り当て、次に [Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/save/) を使用してプレゼンテーションを書き込みます。この例は 900 × 600 ポイントの横向きページを設定し、PPTX として保存し、保存されたファイルを再度開いて永続化された値を確認します。比較では浮動小数点値に対して 0.01 ポイントの許容誤差を認めていますが、すべてのファイル形式での精度を保証するものではありません。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

期待される結果は `900 x 600 points` と `Size preserved: true` です。新しく開いたプレゼンテーションを確認することで、保存されたファイルが検証され、メモリ上の設定だけではないことが確認できます。

## **ノートとハンドアウトのエクスポート**

ページ寸法はノートやハンドアウトレイアウトの利用可能領域を定義しますが、これだけでレイアウトが有効になるわけではありません。エクスポートオプションも設定してください。通常のスライドのエクスポートは引き続きスライドの寸法を使用します。

### **ノートを PDF と PNG にエクスポート**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notescommentslayoutingoptions/) を [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) に割り当てて、PDF にノートを含めます。この例は、[Slide.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getImage) と [RenderingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/renderingoptions/) を使用して、ノート付きの最初のスライドを PNG にレンダリングします。

[BottomTruncated](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notespositions/) モードはノートを 1 ページに収めます。収まりきらないノートは切り捨てられます。PDF は 900 × 600 ポイントのページを使用します。以下で使用する 1 × 1 の画像スケールでは、PNG は 900 × 600 ピクセルになります。ポイントはページの幾何形状を表し、ピクセルはラスタ出力を表し、その寸法はレンダリングスケールにも依存します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

長いノートを含む PDF エクスポートでは、[BottomFull](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notespositions/) が必要に応じて追加ページを許可します。上記の単一スライド画像呼び出しではこのモードはサポートされていないため使用しないでください。サイズ変更後は、切り取られたノートや既存の notes‑master オブジェクトの配置を出力で確認してください。ページ寸法だけを変更しても、すべてのコンテンツが収まる保証にはなりません。ノートのエクスポートの詳細については、[Convert PowerPoint to PDF with Notes](/slides/ja/nodejs-java/convert-powerpoint-to-pdf-with-notes/) を参照してください。

### **ハンドアウトを PDF にエクスポート**

[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handoutlayoutingoptions/) を使用して、1 ページに複数のスライドサムネイルを配置します。以下の例は 900 × 600 ポイントのページを設定し、[HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/handouttype/) を使用して 1 ページに最大 4 枚のスライドを配置します。水平プリセットはスライドの順序を制御し、ページの向きは幅と高さから決まります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

ページサイズを変更すると、ハンドアウトグリッドの利用可能領域が変わりますが、元のスライドの寸法は変わりません。ハンドアウト画像を取得するには、個々のスライドの画像メソッドではなく、ハンドアウトレイアウトで [Presentation.getImages](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getimages/) を使用してください。Aspose.Slides では、プレゼンテーションレベルのハンドアウトレンダリングはノートページの寸法を使用し、個別スライドの画像呼び出しはハンドアウトページを生成しません。レイアウトオプションについては、[Handout Mode](/slides/ja/nodejs-java/convert-powerpoint-in-handout-mode/) を参照してください。

## **ビューア、エクスポート、印刷におけるページサイズ**

保存されたプレゼンテーションサイズ、エクスポートされたページサイズ、印刷された用紙サイズは別々に保ってください:

- **Presentation viewers:** ビューアは独自のレイアウト規則でノートを表示または印刷できます。他のアプリケーションがファイルを保存した場合は、再度開いて寸法を確認してください。そのアプリケーションの形式変換により寸法が正規化されることがあります。
- **Export formats:** 上記のノートおよびハンドアウト PDF の例は設定されたページ寸法を使用します。ラスター画像は整数ピクセル寸法とレンダリングスケールを使用するため、画像出力では小数点以下のポイント値が丸められることがあります。通常のスライドのエクスポートはノートページサイズを適用しません。
- **Printer drivers:** 用紙の選択、自動回転、ページに合わせて印刷などの設定は、プレゼンテーションや PDF に保存された寸法を変更せずに実際の出力を変えることがあります。特定の用紙サイズの場合は、プリンター設定を合わせ、印刷プレビューを確認してください。

## **FAQ**

**スライド1枚だけのノートサイズを設定できますか？**

ノートページサイズはプレゼンテーションレベルの設定です。個々のスライドは異なるノート内容を持つことができますが、このプロパティはスライドごとに別々のページサイズを提供しません。

**ノートの向きを変更してもスライドが変わらなかった理由は？**

ノートページと通常のスライドは独立した寸法を持っています。スライド自体のサイズを変更したい場合は、通常のスライドサイズ設定を使用してください。

**保存または印刷した結果のサイズが異なるのはなぜですか？**

まず、保存したプレゼンテーションを再度開き、ノートの寸法を比較してください。変更があれば、別のアプリケーションで保存または変換した際にページ設定が変わったか確認します。変わっていない場合は、エクスポートレイアウト、画像スケール、ビューア設定、プリンターの用紙選択を確認してください。