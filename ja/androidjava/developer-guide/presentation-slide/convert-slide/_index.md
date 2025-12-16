---
title: Android でプレゼンテーション スライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/androidjava/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドから画像へ
- スライドを画像として保存
- スライドを PNG に変換
- スライドを JPEG に変換
- スライドをビットマップに変換
- スライドを TIFF に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PPT、PPTX、ODP のスライドを画像に変換します—高速で高品質なレンダリングと明確な Java コード例を提供。"
---

## **概要**

Aspose.Slides for Android via Java は、PowerPoint および OpenDocument のプレゼンテーションスライドを、BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できるようにします。

スライドを画像に変換するには、次の手順に従います。

1. 変換設定を定義し、エクスポートしたいスライドを選択します。使用できるのは：
    - [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) インターフェイス、または
    - [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/) インターフェイス。
2. [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) メソッドを呼び出してスライド画像を生成します。

Aspose.Slides for Android via Java では、[IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/) はピクセルデータで定義された画像を操作できるインターフェイスです。このインターフェイスを使用して、幅広い形式（BMP、JPG、PNG など）で画像を保存できます。

## **スライドをビットマップに変換し、PNG で画像を保存する**

スライドをビットマップオブジェクトに変換してアプリケーションで直接使用できます。または、スライドをビットマップに変換してから、JPEG や他の任意の形式で画像を保存することもできます。

このコードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、PNG 形式で画像を保存する方法を示しています:
```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションの最初のスライドをビットマップに変換します。
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // 画像を PNG 形式で保存します。
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **カスタムサイズでスライドを画像に変換する**

特定のサイズの画像が必要な場合があります。[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) のオーバーロードを使用すると、幅と高さを指定してスライドを画像に変換できます。

このサンプルコードは、その方法を示しています:
```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 指定したサイズでプレゼンテーションの最初のスライドをビットマップに変換します。
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // 画像を JPEG 形式で保存します。
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **ノートとコメント付きスライドを画像に変換する**

一部のスライドにはノートやコメントが含まれている場合があります。

Aspose.Slides は、[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) および [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/) の 2 つのインターフェイスを提供し、プレゼンテーションスライドを画像にレンダリングする際の制御が可能です。両インターフェイスには `setSlidesLayoutOptions` メソッドが含まれており、スライドを画像に変換する際にノートやコメントのレンダリングを設定できます。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) クラスを使用すると、結果画像内でノートとコメントの位置を好みで指定できます。

このコードは、ノートとコメント付きスライドを画像に変換する方法を示しています:
```java 
float scaleX = 2;
float scaleY = scaleX;

// プレゼンテーション ファイルを読み込みます。
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // ノートの位置を設定します。
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // コメントの位置を設定します。
    notesCommentsOptions.setCommentsAreaWidth(500);                         // コメント領域の幅を設定します。
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // コメント領域の色を設定します。

    // レンダリング オプションを作成します。
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // プレゼンテーションの最初のスライドを画像に変換します。
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // 画像を GIF 形式で保存します。
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

スライドから画像への変換プロセスでは、[setNotesPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) メソッドは `BottomFull`（ノートの位置を指定する）を適用できません。これは、ノートのテキストが大きすぎて、指定された画像サイズに収まらない可能性があるためです。

{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) インターフェイスは、サイズ、解像度、カラーパレットなどのパラメータを指定でき、生成される TIFF 画像をより細かく制御できます。

このコードは、TIFF オプションを使用して 300 DPI の解像度と 2160 × 2800 のサイズで白黒画像を出力する変換プロセスを示しています:
```java 
// プレゼンテーション ファイルを読み込みます。
Presentation presentation = new Presentation("sample.pptx");
try {
    // プレゼンテーションから最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 出力 TIFF 画像の設定を構成します。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // 画像サイズを設定します。
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // ピクセル形式を設定します（白黒）。
    tiffOptions.setDpiX(300);                                        // 水平解像度を設定します。
    tiffOptions.setDpiY(300);                                        // 垂直解像度を設定します。

    // 指定されたオプションでスライドを画像に変換します。
    IImage image = slide.getImage(tiffOptions);

    try {
        // TIFF 形式で画像を保存します。
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```


## **すべてのスライドを画像に変換する**

Aspose.Slides は、プレゼンテーション内のすべてのスライドを画像に変換でき、プレゼンテーション全体を一連の画像に変換することができます。

このサンプルコードは、Java でプレゼンテーション内のすべてのスライドを画像に変換する方法を示しています:
```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションをスライド単位で画像にレンダリングします。
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // 非表示スライドを制御します（非表示スライドはレンダリングしません）。
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // スライドを画像に変換します。
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // 画像を JPEG 形式で保存します。
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **よくある質問**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ、`getImage` メソッドはスライドの静止画のみを保存し、アニメーションは含まれません。

**非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**画像を影やエフェクト付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に、影、透明度、その他のグラフィック効果のレンダリングをサポートしています。