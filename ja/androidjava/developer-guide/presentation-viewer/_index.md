---
title: プレゼンテーションビューア
type: docs
weight: 50
url: /androidjava/presentation-viewer/
keywords: "PowerPoint PPTビューワ"
description: "JavaでのPowerPoint PPTビューワ"
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Javaは、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションを開くことで表示できます。しかし、時には開発者はお気に入りの画像ビューアでスライドを画像として表示したり、自分自身のプレゼンテーションビューアを作成したりする必要がある場合があります。そのような場合に、Aspose.Slides for Android via Javaを使用すると、個々のスライドを画像にエクスポートすることができます。この記事では、その方法について説明します。

{{% /alert %}} 

## **ライブ例**
[**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/)の無料アプリを試して、Aspose.Slides APIで何を実装できるか確認できます：

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **スライドからSVG画像を生成する**
Aspose.Slides for Android via Javaを使用して、任意のスライドからSVG画像を生成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- IDまたはインデックスを使用して、希望するスライドの参照を取得します。
- メモリストリーム内にSVG画像を取得します。
- メモリストリームをファイルに保存します。

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // メモリストリームオブジェクトを作成します
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // スライドのSVG画像を生成し、メモリストリームに保存します
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **カスタム形状IDを使用してSVGを生成する**
Aspose.Slides for Android via Javaを使用して、カスタム形状IDを持つスライドから[SVG](https://docs.fileformat.com/page-description-language/svg/)を生成することができます。そのためには、生成されたSVG内の形状のカスタムIDを表す[ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgShape)のIDプロパティを使用します。CustomSvgShapeFormattingControllerを使用して形状IDを設定できます。

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

## **スライドのサムネイル画像を作成する**
Aspose.Slides for Android via Javaを使用すると、スライドのサムネイル画像を生成することができます。Aspose.Slides for Android via Javaを使用して、希望するスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、希望するスライドの参照を取得します。
1. 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の希望する画像形式でサムネイル画像を保存します。

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // フルスケール画像を作成します
    IImage slideImage = sld.getImage(1f, 1f);

    // 画像をJPEG形式でディスクに保存します
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **ユーザー定義の寸法でサムネイルを作成する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、希望するスライドの参照を取得します。
1. 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の希望する画像形式でサムネイル画像を保存します。

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // ユーザー定義の寸法
    int desiredX = 1200;
    int desiredY = 800;

    // XおよびYのスケーリング値を取得します
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // フルスケール画像を作成します
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // 画像をJPEG形式でディスクに保存します
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **ノートスライドビューでスライドからサムネイルを作成する**
Aspose.Slides for Android via Javaを使用して、ノートスライドビューで任意の希望するスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、希望するスライドの参照を取得します。
1. ノートスライドビューで指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の希望する画像形式でサムネイル画像を保存します。

以下のコードスニペットは、ノートスライドビューでプレゼンテーションの最初のスライドのサムネイルを生成します。

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // 最初のスライドにアクセスします
    ISlide sld = pres.getSlides().get_Item(0);

    // ユーザー定義の寸法
    int desiredX = 1200;
    int desiredY = 800;

    // XおよびYのスケーリング値を取得します
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // フルスケール画像を作成します
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // 画像をJPEG形式でディスクに保存します
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```