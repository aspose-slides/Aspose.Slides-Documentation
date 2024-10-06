---
title: スライドの変換
type: docs
weight: 35
url: /ja/java/convert-slide/
keywords: 
- スライドを画像に変換
- スライドを画像としてエクスポート
- スライドを画像として保存
- スライドから画像へ
- スライドをPNGに
- スライドをJPEGに
- スライドをビットマップに
- Java
- Aspose.Slides for Java
description: "JavaでPowerPointのスライドを画像（ビットマップ、PNG、またはJPG）に変換する"
---

Aspose.Slides for Java を使用すると、（プレゼンテーション内の）スライドを画像に変換できます。サポートされている画像形式は次のとおりです：BMP、PNG、JPG（JPEG）、GIF、その他。

スライドを画像に変換するには、次の手順を行います：

1. まず、変換パラメーターと変換するスライドオブジェクトを設定します：
   * [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) インターフェースを使用するか
   * [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions) インターフェースを使用します。

2. 次に、[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用して、スライドを画像に変換します。

## **ビットマップと他の画像形式について**

Java における [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) は、ピクセルデータで定義された画像を操作するためのオブジェクトです。このクラスのインスタンスを使用して、幅広い形式（JPG、PNG など）で画像を保存できます。

{{% alert title="情報" color="info" %}}

Aspose は最近オンラインの [Text to GIF](https://products.aspose.app/slides/text-to-gif) 変換ツールを開発しました。

{{% /alert %}}

## **スライドをビットマップに変換してPNG形式で保存する**

このJavaコードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、その後PNG形式で画像を保存する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションの最初のスライドをImagesオブジェクトに変換
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// PNG形式で画像を保存
	try {
        // ディスクに画像を保存。
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

このサンプルコードは、[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用してプレゼンテーションの最初のスライドをビットマップオブジェクトに変換する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
	// プレゼンテーションのスライドサイズを取得
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// スライドサイズでImagesを作成
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // ディスクに画像を保存。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="ヒント" color="primary" %}} 

スライドをImagesオブジェクトに変換し、そのオブジェクトを直接どこかで使用できます。また、スライドをImagesに変換してJPEGや他の任意の形式で画像を保存することもできます。

{{% /alert %}}  

## **カスタムサイズの画像へのスライドの変換**

特定のサイズの画像を取得する必要がある場合があります。[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) メソッドのオーバーロードを使用すると、スライドを特定の寸法（長さと幅）の画像に変換できます。

このサンプルコードは、Javaの[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用した提案された変換を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションの最初のスライドを指定されたサイズのビットマップに変換
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// JPEG形式で画像を保存
	try {
         // ディスクに画像を保存。
          slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ノートとコメント付きのスライドを画像に変換する**

一部のスライドにはノートやコメントが含まれています。

Aspose.Slidesは、プレゼンテーションスライドを画像にレンダリングする際の制御を可能にする2つのインターフェース—[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) と [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions)—を提供しています。両方のインターフェースに、スライドを画像に変換する際にスライド上のノートやコメントを追加できる[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) インターフェースがあります。

{{% alert title="情報" color="info" %}} 

[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) インターフェースを使用すると、生成された画像内のノートとコメントの希望の位置を指定できます。

{{% /alert %}} 

このJavaコードは、ノートとコメントのあるスライドの変換プロセスを示しています：

```java
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // レンダリングオプションを作成
    IRenderingOptions options = new RenderingOptions();

    // ページ上のノートの位置を設定
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // ページ上のコメントの位置を設定 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // コメント出力エリアの幅を設定
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // コメントエリアの色を設定
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // GIF形式で画像を保存
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

このJavaコードは、[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用してノートのあるスライドの変換プロセスを示しています：

```java
Presentation pres = new Presentation("PresentationNotes.pptx");
try {
	// プレゼンテーションのノートサイズを取得
	Dimension2D notesSize = pres.getNotesSize().getSize();

	// レンダリングオプションを作成
	IRenderingOptions options = new RenderingOptions();

	// ノートの位置を設定
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// ノートのサイズでImagesを作成
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, notesSize);

	// PNG形式で画像を保存
    try {
         // ディスクに画像を保存。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

スライドから画像への変換プロセスでは、[NotesPositions](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) プロパティをBottomFullに設定することはできません（ノートの位置を指定するため）。ノートのテキストが大きい場合、指定された画像サイズに収まらない可能性があります。

{{% /alert %}} 

## **ITiffOptionsを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) インターフェースを使用すると、生成される画像に対してより多くの制御（パラメーターの観点から）が可能です。このインターフェースを使用すると、生成される画像のサイズ、解像度、カラー パレット、その他のパラメーターを指定できます。

このJavaコードは、ITiffOptionsを使用して300dpiの解像度で2160 × 2800サイズの白黒画像を出力する変換プロセスを示しています：

```java
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// インデックスでスライドを取得
	ISlide slide = pres.getSlides().get_Item(0);

	// TiffOptionsオブジェクトを作成
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// ソースフォントが見つからない場合に使用されるフォントを設定
	options.setDefaultRegularFont("Arial Black");

	// ページ上のノートの位置を設定
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// ピクセル形式を設定（白黒）
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// 解像度を設定
	options.setDpiX(300);
	options.setDpiY(300);

	// スライドをビットマップオブジェクトに変換
	IImage slideImage = slide.getImage(options);

	// TIFF形式で画像を保存
	try {
          slideImage.save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

Tiffサポートは、JDK 9以前のバージョンでは保証されていません。

{{% /alert %}} 

## **すべてのスライドを画像に変換する**

Aspose.Slidesを使用すると、単一のプレゼンテーション内のすべてのスライドを画像に変換できます。基本的に、プレゼンテーション全体を画像に変換できます。

このサンプルコードは、Javaでプレゼンテーション内のすべてのスライドを画像に変換する方法を示しています：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // スライドごとにプレゼンテーションを画像配列にレンダリング
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // 隠れたスライドを制御（隠れたスライドはレンダリングしない）
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // スライドをビットマップオブジェクトに変換
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // PNG形式で画像を保存
        try {
              slideImage.save("Slide_" + i + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
} 
```