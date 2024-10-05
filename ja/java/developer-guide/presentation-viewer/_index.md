---
title: プレゼンテーションビューア
type: docs
weight: 50
url: /java/presentation-viewer/
keywords: "PowerPoint PPT ビューア"
description: "Java の PowerPoint PPT ビューア"
---

{{% alert color="primary" %}} 

Aspose.Slides for Java は、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPoint を使用してプレゼンテーションを開くことで表示できます。しかし、時には、開発者はお気に入りの画像ビューアでスライドを画像として表示したり、自分自身のプレゼンテーションビューアを作成したりする必要があります。そのような場合、Aspose.Slides for Java は、個々のスライドを画像としてエクスポートすることを可能にします。この記事では、その方法について説明します。

{{% /alert %}} 

## **ライブ例**
[**Aspose.Slides ビューア**](https://products.aspose.app/slides/viewer/) の無料アプリを試して、Aspose.Slides API を使用して何が実装できるかをご覧ください：

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **スライドから SVG 画像を生成**
Aspose.Slides for Java を使用して、任意のスライドから SVG 画像を生成するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- ID またはインデックスを使用して、目的のスライドの参照を取得します。
- メモリストリームで SVG 画像を取得します。
- メモリストリームをファイルに保存します。

```java
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化する
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // 最初のスライドにアクセスする
    ISlide sld = pres.getSlides().get_Item(0);

    // メモリストリームオブジェクトを作成する
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // スライドの SVG 画像を生成してメモリストリームに保存する
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **カスタム形状 ID で SVG を生成する**
Aspose.Slides for Java を使用して、カスタム形状 ID 付きのスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。そのためには、生成された SVG の形状のカスタム ID を表す [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgShape) から ID プロパティを使用します。CustomSvgShapeFormattingController を使用して形状 ID を設定できます。

```java
Presentation pres = new Presentation("pptxFileName.pptx");
try {
    FileOutputStream stream = new FileOutputStream("Aspose_out.svg");
    try {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

        pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    pres.dispose();
}
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }
    
    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **スライドのサムネイル画像を作成**
Aspose.Slides for Java は、スライドのサムネイル画像を生成するのに役立ちます。Aspose.Slides for Java を使用して、任意のスライドのサムネイルを生成するための手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して、目的のスライドの参照を取得します。
1. 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```java
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化する
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // 最初のスライドにアクセスする
    ISlide sld = pres.getSlides().get_Item(0);

    // フルスケール画像を作成する
    IImage slideImage = sld.getImage(1f, 1f);

    // JPEG 形式でディスクに画像を保存する
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **ユーザー定義の寸法でサムネイルを作成**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して、目的のスライドの参照を取得します。
1. 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```java
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化する
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // 最初のスライドにアクセスする
    ISlide sld = pres.getSlides().get_Item(0);

    // ユーザー定義の寸法
    int desiredX = 1200;
    int desiredY = 800;

    // X と Y のスケール値を取得する
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // フルスケール画像を作成する
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // JPEG 形式でディスクに画像を保存する
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **ノートスライドビューのスライドからサムネイルを作成**
Aspose.Slides for Java を使用して、ノートスライドビューで任意のスライドのサムネイルを生成する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. ID またはインデックスを使用して、目的のスライドの参照を取得します。
1. ノートスライドビューで指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

以下のコードスニペットは、ノートスライドビューでプレゼンテーションの最初のスライドのサムネイルを生成します。

```java
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化する
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // 最初のスライドにアクセスする
    ISlide sld = pres.getSlides().get_Item(0);

    // ユーザー定義の寸法
    int desiredX = 1200;
    int desiredY = 800;

    // X と Y のスケール値を取得する
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // フルスケール画像を作成する
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // JPEG 形式でディスクに画像を保存する
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```