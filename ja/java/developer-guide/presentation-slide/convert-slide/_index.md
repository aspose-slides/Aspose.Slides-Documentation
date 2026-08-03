---
title: Java でプレゼンテーション スライドを画像に変換
linktitle: スライドから画像へ
type: docs
weight: 35
url: /ja/java/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像に
- スライドを画像として保存
- スライドを PNG に
- スライドを JPEG に
- スライドをビットマップに
- スライドを TIFF に
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java で PPT、PPTX、ODP のスライドを画像に変換します—高速で高品質なレンダリングと分かりやすいコード例を提供します。"
---
## **概要**

Aspose.Slides for Java を使用すると、PowerPoint および OpenDocument のプレゼンテーション スライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できます。

スライドを画像に変換するには、次の手順に従います。

1. 必要な変換設定を定義し、エクスポートするスライドを選択します。以下を使用します：
    - [ITiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiffoptions/) インターフェイス、または
    - [IRenderingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/irenderingoptions/) インターフェイス。
2. [getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) メソッドを呼び出してスライド画像を生成します。

Aspose.Slides for Java では、[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) はピクセルデータで定義された画像を操作できるインターフェイスです。このインターフェイスを使用して、BMP、JPG、PNG など、幅広い形式で画像を保存できます。

## **スライドをビットマップに変換し、PNG 形式で画像を保存**

スライドをビットマップ オブジェクトに変換してアプリケーションで直接使用できます。あるいは、スライドをビットマップに変換してから JPEG などの好みの形式で画像を保存することも可能です。

このコードは、プレゼンテーションの最初のスライドをビットマップ オブジェクトに変換し、PNG 形式で画像を保存する方法を示しています：

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

## **カスタムサイズでスライドを画像に変換**

特定のサイズの画像が必要な場合があります。[getImage] のオーバーロードを使用すると、スライドを指定した幅と高さの画像に変換できます。

このサンプルコードは、これを実現する方法を示しています：

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 指定されたサイズでプレゼンテーションの最初のスライドをビットマップに変換します。
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

## **ノートとコメント付きスライドを画像に変換**

一部のスライドにはノートやコメントが含まれていることがあります。

Aspose.Slides は、[ITiffOptions] と [IRenderingOptions] の 2 つのインターフェイスを提供し、プレゼンテーション スライドを画像へレンダリングする際の制御が可能です。両インターフェイスには `setSlidesLayoutOptions` メソッドがあり、スライドを画像に変換する際にノートやコメントのレンダリング設定を構成できます。

[NotesCommentsLayoutingOptions] クラスを使用すると、生成される画像内でノートやコメントの位置を好きな場所に指定できます。

このコードは、ノートとコメントを含むスライドを変換する方法を示しています：

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
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // コメント領域の色を設定します。

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
スライドから画像への変換プロセスにおいて、[setNotesPosition] メソッドは `BottomFull` を適用できません（ノートのテキストが大きすぎて、指定された画像サイズに収まらない可能性があるため）。
{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換**

[ITiffOptions] インターフェイスは、サイズ、解像度、カラーパレットなどのパラメータを指定でき、生成される TIFF 画像をより細かく制御できます。

このコードは、TIFF オプションを使用して 300 DPI の解像度で 2160 × 2800 のサイズの白黒画像を出力する変換プロセスを示しています：

```java 
// プレゼンテーション ファイルを読み込みます。
Presentation presentation = new Presentation("sample.pptx");
try {
    // プレゼンテーションから最初のスライドを取得します。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 出力 TIFF 画像の設定を構成します。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // 画像サイズを設定します。
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // ピクセル形式を設定します（白黒）。
    tiffOptions.setDpiX(300);                                        // 水平解像度を設定します。
    tiffOptions.setDpiY(300);                                        // 垂直解像度を設定します。

    // 指定されたオプションでスライドを画像に変換します。
    IImage image = slide.getImage(tiffOptions);

    try {
        // 画像を TIFF 形式で保存します。
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
JDK 9 未満のバージョンでは、Tiff のサポートが保証されていません。
{{% /alert %}} 

## **すべてのスライドを画像に変換**

Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドを画像に変換でき、事実上プレゼンテーション全体を画像の連続に変換できます。

このサンプルコードは、Java でプレゼンテーションのすべてのスライドを画像に変換する方法を示しています：

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションをスライドごとに画像へレンダリングします。
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

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="warning" %}} 
プレゼンテーションのスライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、プレゼンテーションで使用されている絵文字フォントが、変換を実行するシステムにインストールされて利用可能である必要があります。例えば、プレゼンテーションで **Segoe UI Emoji** が使用されているがそのフォントが存在しない場合、出力画像の絵文字はモノクロで表示される可能性があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ、`getImage` メソッドはスライドの静止画像のみを保存し、アニメーションは含まれません。

**非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**画像を影やエフェクト付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に、影や透明度、その他のグラフィック効果のレンダリングをサポートしています。