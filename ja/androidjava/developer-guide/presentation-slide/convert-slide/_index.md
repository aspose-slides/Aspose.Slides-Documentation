---
title: スライドを変換
type: docs
weight: 35
url: /androidjava/convert-slide/
keywords: 
- スライドを画像に変換
- スライドを画像としてエクスポート
- スライドを画像として保存
- スライドを画像に
- スライドをPNGに
- スライドをJPEGに
- スライドをビットマップに
- Java
- Aspose.Slides for Android via Java
description: "JavaでPowerPointスライドを画像（ビットマップ、PNG、またはJPG）に変換"
---

Aspose.Slides for Android via Javaを使用すると、スライド（プレゼンテーション内の）を画像に変換できます。サポートされている画像形式は、BMP、PNG、JPG（JPEG）、GIFなどです。

スライドを画像に変換するには、次の手順を実行します：

1. まず、変換パラメーターと変換するスライドオブジェクトを設定します：
   * [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions)インターフェースを使用するか、
   * [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions)インターフェースを使用します。

2. 次に、[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--)メソッドを使用して、スライドを画像に変換します。

## **ビットマップおよびその他の画像形式について**

Javaにおける[Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images)は、ピクセルデータで定義された画像を操作するためのオブジェクトです。このクラスのインスタンスを使用して、幅広い形式（JPG、PNGなど）で画像を保存できます。

{{% alert title="情報" color="info" %}}

Asposeは最近、オンラインの[Text to GIF](https://products.aspose.app/slides/text-to-gif)変換ツールを開発しました。

{{% /alert %}}

## **スライドをビットマップに変換し、PNG形式で画像を保存する**

このJavaコードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、その後画像をPNG形式で保存する方法を示しています：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションの最初のスライドをImagesオブジェクトに変換
    IImage slideImage = pres.getSlides().get_Item(0).getImage();

	// 画像をPNG形式で保存
	try {
        // ディスクに画像を保存します。
         slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

このサンプルコードは、[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)メソッドを使用して、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換する方法を示しています：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
	// プレゼンテーションのスライドサイズを取得
	Dimension2D slideSize = new Dimension((int) slideSize.getWidth(), (int) slideSize.getHeight());

	// スライドサイズでImagesを作成
    IImage slideImage = sld.getImage(new RenderingOptions(), slideSize);
    try {
         // ディスクに画像を保存します。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="ヒント" color="primary" %}} 

スライドをImagesオブジェクトに変換し、そのオブジェクトをどこかに直接使用することができます。また、スライドをImagesに変換し、その後JPEGや他の形式で画像を保存することもできます。

{{% /alert %}}  

## **カスタムサイズの画像にスライドを変換する**

特定のサイズの画像を取得する必要があるかもしれません。[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-)メソッドのオーバーロードを使用することで、特定の寸法（長さと幅）を持つ画像にスライドを変換できます。

このサンプルコードは、Javaの[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)メソッドを使用して、提案された変換を示しています：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 指定されたサイズのビットマップにプレゼンテーションの最初のスライドを変換
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1820, 1040));
	
	// 画像をJPEG形式で保存
	try {
         // ディスクに画像を保存します。
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

Aspose.Slidesは、プレゼンテーションのスライドを画像にレンダリングする際に制御を可能にする二つのインターフェース—[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions)と[IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IRenderingOptions)—を提供します。両方のインターフェースには、スライドを画像に変換する際にノートやコメントを追加できる[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions)インターフェースがあります。

{{% alert title="情報" color="info" %}} 

[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions)インターフェースを使用すると、結果の画像におけるノートやコメントの好みの位置を指定できます。

{{% /alert %}} 

このJavaコードは、ノートとコメントを含むスライドの変換プロセスを示しています：

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // レンダリングオプションを作成
    IRenderingOptions options = new RenderingOptions();

    // ページ上でノートの位置を設定
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // ページ上でコメントの位置を設定 
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // コメント出力領域の幅を設定
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // コメントエリアの色を設定
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
    IImage slideImage = pres.getSlides().get_Item(0).getImage(options, 2f, 2f);

    // 画像をGIF形式で保存
    try {
          slideImage.save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

このJavaコードは、[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-java.awt.Dimension-)メソッドを使用してノート付きのスライドの変換プロセスを示しています：

``` java
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

	// 画像をPNG形式で保存
    try {
         // ディスクに画像を保存します。
          slideImage.save("Slide_0.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

スライドを画像に変換するプロセスにおいて、[NotesPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-)プロパティは、ノートの位置を指定するためにBottomFullに設定することはできません。なぜなら、ノートのテキストが大きい場合、指定された画像サイズに収まらない可能性があるからです。

{{% /alert %}} 

## **ITiffOptionsを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiffOptions)インターフェースは、生成される画像に対するパラメーターにより多くの制御を提供します。このインターフェースを使用すると、生成される画像のサイズ、解像度、カラーパレットなどのパラメーターを指定できます。

このJavaコードは、ITiffOptionsを使用して300dpiの解像度で2160×2800サイズの白黒画像を出力する変換プロセスを示しています：

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
	// インデックスでスライドを取得
	ISlide slide = pres.getSlides().get_Item(0);

	// TiffOptionsオブジェクトを作成
	TiffOptions options = new TiffOptions();
	options.setImageSize(new Dimension(2160, 2880));

	// ソースフォントが見つからない場合に使用されるフォントを設定
	options.setDefaultRegularFont("Arial Black");

	// ページ上でノートの位置を設定
	options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

	// ピクセル形式を設定（白黒）
	options.setPixelFormat(ImagePixelFormat.Format1bppIndexed);

	// 解像度を設定
	options.setDpiX(300);
	options.setDpiY(300);

	// スライドをビットマップオブジェクトに変換
	IImage slideImage = slide.getImage(options);

	// 画像をTIFF形式で保存
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

TiffサポートはJDK 9以前のバージョンでは保証されていません。

{{% /alert %}} 

## **すべてのスライドを画像に変換する**

Aspose.Slidesを使用すると、単一のプレゼンテーション内のすべてのスライドを画像に変換できます。実質的には、プレゼンテーション全体を画像に変換することができます。 

このサンプルコードは、プレゼンテーション内のすべてのスライドを画像に変換する方法を示しています：

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // スライドごとにプレゼンテーションを画像の配列にレンダリング
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // 非表示のスライドを制御（非表示のスライドはレンダリングしない）
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // スライドをビットマップオブジェクトに変換
        IImage slideImage = pres.getSlides().get_Item(i).getImage(2f, 2f);

        // 画像をPNG形式で保存
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