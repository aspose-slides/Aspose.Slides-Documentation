---
title: JavaScriptでプレゼンテーションスライドを画像に変換する
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/nodejs-java/convert-slide/
keywords:
- スライド変換
- スライドエクスポート
- スライドを画像へ
- スライドを画像として保存
- スライドをPNGへ
- スライドをJPEGへ
- スライドをビットマップへ
- スライドをTIFFへ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、JavaScript で PPT、PPTX、ODP のスライドを画像に変換します — 高速で高品質なレンダリングと明確なコード例を提供します。"
---
## **はじめに**

Aspose.Slides for Node.js via Java を使用すると、PowerPoint および OpenDocument のプレゼンテーションスライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できます。

スライドを画像に変換するには、次の手順に従います。

1. 変換設定を定義し、エクスポートしたいスライドを次のいずれかを使用して選択します。
    - [TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) クラス、または
    - [RenderingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/renderingoptions/) クラス。
2. [getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getImage) メソッドを呼び出してスライド画像を生成します。

Aspose.Slides for Node.js via Java では、[IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) はピクセルデータで定義された画像を操作できるクラスです。このクラスを使用して、BMP、JPG、PNG など幅広い形式で画像を保存できます。

## **スライドをビットマップに変換し、PNG で画像を保存する**

スライドをビットマップオブジェクトに変換してアプリケーションで直接使用できます。または、スライドをビットマップに変換してから JPEG など任意の形式で画像を保存することも可能です。

この JavaScript コードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、PNG 形式で画像を保存する方法を示しています。

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // プレゼンテーションの最初のスライドをビットマップに変換します。
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // 画像を PNG 形式で保存します。
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **カスタムサイズでスライドを画像に変換する**

特定のサイズの画像が必要な場合があります。[getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getImage) のオーバーロードを使用して、幅と高さを指定した画像にスライドを変換できます。

このサンプルコードは、その手順を示しています。

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 指定されたサイズでプレゼンテーションの最初のスライドをビットマップに変換します。
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // 画像を JPEG 形式で保存します。
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **ノートとコメント付きスライドを画像に変換する**

スライドによってはノートやコメントが含まれていることがあります。

Aspose.Slides は、[TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) と [RenderingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/renderingoptions/) の 2 つのクラスを提供し、プレゼンテーションスライドを画像にレンダリングする際に制御できます。両クラスには `setSlidesLayoutOptions` メソッドが含まれており、スライドを画像に変換する際のノートとコメントのレンダリングを設定できます。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notescommentslayoutingoptions/) クラスを使用すると、生成された画像内でノートとコメントの位置を任意に指定できます。

この JavaScript コードは、ノートとコメント付きのスライドを変換する方法を示しています。

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // ノートの位置を設定します。
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // コメントの位置を設定します。
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // コメント領域の幅を設定します。
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // コメント領域の色を設定します。

    // レンダリングオプションを作成します。
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // プレゼンテーションの最初のスライドを画像に変換します。
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // 画像を GIF 形式で保存します。
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
スライドから画像への変換プロセスにおいて、[setNotesPosition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) メソッドは `BottomFull` を適用できません（ノートの位置を指定するため）。ノートの文字数が多すぎて、指定した画像サイズに収まらない可能性があるためです。
{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換する**

[TiffOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tiffoptions/) クラスは、サイズ、解像度、カラーパレットなどのパラメータを指定でき、生成される TIFF 画像をより細かく制御できます。

この JavaScript コードは、TIFF オプションを使用して解像度 300 DPI、サイズ 2160 × 2800 の白黒画像を出力する変換プロセスを示しています。

```js
// プレゼンテーションファイルを読み込みます。
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // プレゼンテーションから最初のスライドを取得します。
    let slide = presentation.getSlides().get_Item(0);

    // 出力 TIFF 画像の設定を構成します。
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // 画像サイズを設定します。
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // ピクセル形式を設定します（白黒）。
    tiffOptions.setDpiX(300);                                                          // 水平解像度を設定します。
    tiffOptions.setDpiY(300);                                                          // 垂直解像度を設定します。

    // 指定したオプションでスライドを画像に変換します。
    let image = slide.getImage(tiffOptions);
    try {
        // 画像を TIFF 形式で保存します。
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
JDK 9 未満のバージョンでは、TIFF のサポートは保証されていません。
{{% /alert %}} 

## **すべてのスライドを画像に変換する**

Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドを画像に変換でき、プレゼンテーション全体を一連の画像に変換することができます。

このサンプルコードは、JavaScript でプレゼンテーションのすべてのスライドを画像に変換する方法を示しています。

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // プレゼンテーションをスライドごとに画像としてレンダリングします。
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // 非表示スライドを制御します（非表示スライドはレンダリングしません）。
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // スライドを画像に変換します。
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // 画像を JPEG 形式で保存します。
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="warning" %}} 
プレゼンテーションスライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが、変換を実行するシステムにインストールされて利用可能である必要があります。例えば、プレゼンテーションが **Segoe UI Emoji** を使用していてこのフォントが欠如している場合、絵文字は出力画像でモノクロで表示される可能性があります。
{{% /alert %}} 

## **FAQ**

**Aspose.Slides はスライドのアニメーションのレンダリングをサポートしていますか？**

いいえ、`getImage` メソッドはスライドの静止画像のみを保存し、アニメーションは含まれません。

**非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**画像を影やエフェクト付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に影、透過、その他のグラフィックエフェクトのレンダリングをサポートしています。