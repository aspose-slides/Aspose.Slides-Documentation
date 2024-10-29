---
title: PowerPointをJPGに変換
type: docs
weight: 60
url: /ja/java/convert-powerpoint-to-jpg/
keywords: "PowerPointをJPGに変換, PPTXをJPEGに, PPTをJPEGに"
description: "PowerPointをJPGに変換: PPTをJPGに, PPTXをJPGにJavaで"
---


## **PowerPointからJPGへの変換について**
[**Aspose.Slides API**](https://products.aspose.com/slides/java/)を使用すると、PowerPoint PPTまたはPPTXプレゼンテーションをJPG画像に変換できます。また、PPT/PPTXをJPEG、PNG、またはSVGに変換することも可能です。この機能を使用すると、自分自身のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりするのが簡単になります。この機能は、プレゼンテーションスライドを著作権から保護したり、プレゼンテーションを読み取り専用モードで表示したりする場合に役立ちます。Aspose.Slidesは、全体のプレゼンテーションまたは特定のスライドを画像フォーマットに変換できます。

{{% alert color="primary" %}} 

Aspose.SlidesがPowerPointをJPG画像に変換する方法を確認するには、これらの無料オンラインコンバータを試してみてください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTXをJPGに変換**
PPT/PPTXをJPGに変換する手順は以下の通りです:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)タイプのインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)コレクションから[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)タイプのスライドオブジェクトを取得します。
3. 各スライドのサムネイルを作成し、それをJPGに変換します。[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-)メソッドを使用してスライドのサムネイルを取得し、結果として[Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images)オブジェクトを返します。[getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-)メソッドは、必要な[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)タイプのスライドから呼び出し、結果のサムネイルのスケールをメソッドに渡します。
4. スライドのサムネイルを取得した後、サムネイルオブジェクトから[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))メソッドを呼び出します。結果のファイル名と画像フォーマットを渡します。 

{{% alert color="primary" %}}

**注意**: PPT/PPTXからJPGへの変換は、Aspose.Slides APIでの他のタイプへの変換とは異なります。他のタイプの場合、通常は[**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用しますが、ここでは[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))メソッドを使用する必要があります。

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // フルスケールの画像を作成
        IImage slideImage = sld.getImage(1f, 1f);

        // JPEG形式でディスクに画像を保存
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタマイズされた寸法でPowerPoint PPT/PPTXをJPGに変換**
結果のサムネイルやJPG画像の寸法を変更するには、[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-)メソッドに*ScaleX*と*ScaleY*の値を渡して設定できます:

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // 寸法を定義
    int desiredX = 1200;
    int desiredY = 800;
    // XとYのスケール値を取得
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // フルスケールの画像を作成
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // JPEG形式でディスクに画像を保存
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像への変換時にコメントをレンダリング**
Aspose.Slides for Javaは、プレゼンテーションのスライドを画像に変換する際にそのスライド内のコメントをレンダリングする機能を提供します。このJavaコードはその操作を示しています:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)またはPNGからPNG画像をマージし、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成することができます。 

この記事で説明されているのと同様の原則を使用して、画像を1つのフォーマットから別のフォーマットに変換できます。詳細については、これらのページをご覧ください: 画像を[JPGに変換](https://products.aspose.com/slides/java/conversion/image-to-jpg/); JPGを[画像に変換](https://products.aspose.com/slides/java/conversion/jpg-to-image/); JPGを[PNGに変換](https://products.aspose.com/slides/java/conversion/jpg-to-png/)、PNGを[JPGに変換](https://products.aspose.com/slides/java/conversion/png-to-jpg/); PNGを[SVGに変換](https://products.aspose.com/slides/java/conversion/png-to-svg/)、SVGを[PNGに変換](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

## **関連項目**

PPT/PPTXを画像に変換する他のオプションを参照してください:

- [PPT/PPTXをSVGに変換](/slides/ja/java/render-a-slide-as-an-svg-image/)。