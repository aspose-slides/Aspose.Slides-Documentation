---
title: PowerPointをJPGに変換
type: docs
weight: 60
url: /androidjava/convert-powerpoint-to-jpg/
keywords:
- PowerPointプレゼンテーションの変換
- JPG
- JPEG
- PowerPointからJPG
- PowerPointからJPEG
- PPTからJPG
- PPTXからJPG
- PPTからJPEG
- PPTXからJPEG
- Android
- Aspose.Slides
description: "PowerPointをJPGに変換: PPTからJPG、PPTXからJPGをJavaで"
---


## **PowerPointからJPGへの変換について**
[**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)を使用すると、PowerPointのPPTまたはPPTXプレゼンテーションをJPG画像に変換できます。また、PPT/PPTXをJPEG、PNG、またはSVGに変換することも可能です。この機能を使えば、自分のプレゼンテーションビューアを簡単に実装し、各スライドのサムネイルを作成できます。これは、プレゼンテーションスライドを著作権から保護したり、読み取り専用モードでプレゼンテーションを表示したりしたい場合に便利です。Aspose.Slidesは、全体のプレゼンテーションまたは特定のスライドを画像形式に変換することができます。 

{{% alert color="primary" %}} 

Aspose.SlidesがPowerPointをJPG画像に変換する方法を確認するには、これらの無料オンラインコンバータを試してみてください: PowerPoint [PPTXをJPGに変換](https://products.aspose.app/slides/conversion/pptx-to-jpg)および[PPTをJPGに変換](https://products.aspose.app/slides/conversion/ppt-to-jpg)。

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTXをJPGに変換する**
PPT/PPTXをJPGに変換する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)型のインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)コレクションから[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)型のスライドオブジェクトを取得します。
3. 各スライドのサムネイルを作成し、JPGに変換します。[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-)メソッドを使用して、スライドのサムネイルを取得します。それは[Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images)オブジェクトを返します。[getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-)メソッドは、必要なスライドの[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)型から呼び出され、結果として得られるサムネイルのスケールがメソッドに渡されます。
4. スライドのサムネイルを取得したら、サムネイルオブジェクトから[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat))メソッドを呼び出します。結果のファイル名と画像形式を引数として渡します。 

{{% alert color="primary" %}}

**注意**: PPT/PPTXからJPGへの変換は、Aspose.Slides APIの他の形式への変換とは異なります。他の形式の場合、通常は[**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用しますが、ここでは[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat))メソッドが必要です。

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // 全スケール画像を作成
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

## **カスタマイズされた寸法でPowerPoint PPT/PPTXをJPGに変換する**
結果のサムネイルとJPG画像の寸法を変更するには、[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-)メソッドを使って*ScaleX*と*ScaleY*の値を設定することができます：

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
        // 全スケール画像を作成
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

## **プレゼンテーションを画像に保存するときにコメントをレンダリングする**
Aspose.Slides for Android via Javaは、スライドを画像に変換する際にプレゼンテーションのスライドにコメントをレンダリングする機能を提供します。このJavaコードはその運用を示しています：

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

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPGをJPGに](https://products.aspose.app/slides/collage/jpg)またはPNGをPNGの画像にマージしたり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりできます。 

この記事で説明したのと同じ原則を使用して、画像をある形式から別の形式に変換できます。詳細については、次のページを参照してください: [画像をJPGに変換](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/)； [JPGを画像に変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/)； [JPGをPNGに変換](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/)； [PNGをSVGに変換](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/)。

{{% /alert %}}

## **関連情報**

PPT/PPTXを画像に変換する他のオプションについては、以下を参照してください：

- [PPT/PPTXをSVGに変換](/slides/androidjava/render-a-slide-as-an-svg-image/)。