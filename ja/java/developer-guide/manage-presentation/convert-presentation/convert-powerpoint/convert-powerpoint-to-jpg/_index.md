---
title: Java で PPT と PPTX を JPG に変換
linktitle: PowerPoint を JPG に変換
type: docs
weight: 60
url: /ja/java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を JPG に変換
- プレゼンテーションを JPG に変換
- スライドを JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- PowerPoint を JPG として保存
- プレゼンテーションを JPG として保存
- スライドを JPG として保存
- PPT を JPG として保存
- PPTX を JPG として保存
- PPT を JPG にエクスポート
- PPTX を JPG にエクスポート
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用し、速く信頼性の高いコード例で、Java で PowerPoint (PPT、PPTX) スライドを高品質な JPG 画像に変換します。"
---

## オンライン PPT から JPG への変換ツールをお探しですか？

Java コードに入る前に、**コード不要**で PowerPoint (PPT, PPTX) を JPG に変換できる **手軽なオンラインツール**が必要な場合は、以下のオンラインコンバータをご覧ください：  
[Aspose PPT to JPG Converter](https://products.aspose.app/slides/conversion/ppt-to-jpg)

**プログラム的な解決策を探している開発者**であれば、引き続き読んで **Aspose.Slides for Java** を使用して PowerPoint のスライドを JPG に変換する方法を学んでください。

## **PowerPoint から JPG の変換について**

[**Aspose.Slides API**](https://products.aspose.com/slides/java/) を使用すると、PowerPoint の PPT または PPTX プレゼンテーションを JPG 画像に変換できます。また、PPT/PPTX を JPEG、PNG、SVG に変換することも可能です。この機能により、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりするのが容易になります。プレゼンテーションスライドをコピー防止したり、読み取り専用モードでデモンストレーションしたりしたい場合に便利です。Aspose.Slides は、プレゼンテーション全体または特定のスライドを画像形式に変換できます。  

{{% alert color="primary" %}} 

Aspose.Slides が PowerPoint を JPG 画像に変換する様子を確認したい場合は、以下の無料オンラインコンバータをお試しください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) および [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。  

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX を JPG に変換する**

PPT/PPTX を JPG に変換する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 型のインスタンスを作成します。  
2. [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) コレクションから、[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 型のスライドオブジェクトを取得します。  
3. 各スライドのサムネイルを作成し、JPG に変換します。スライドのサムネイル取得には [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) メソッドを使用し、結果として [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) オブジェクトが返されます。必要なスライドの [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 型から [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) メソッドを呼び出し、生成されるサムネイルのスケールをメソッドに渡します。  
4. スライドのサムネイルを取得したら、サムネイルオブジェクトから [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを呼び出します。結果のファイル名と画像フォーマットを渡してください。  

{{% alert color="primary" %}}

**注意**: PPT/PPTX から JPG への変換は、Aspose.Slides API の他の形式への変換とは異なります。 他の形式の場合、通常は [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用しますが、ここでは [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドが必要です。  

{{% /alert %}} 
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // フルスケールの画像を作成
        IImage slideImage = sld.getImage(1f, 1f);

        // 画像を JPEG 形式でディスクに保存
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


## **カスタマイズされたサイズで PowerPoint PPT/PPTX を JPG に変換する**

生成されるサムネイルおよび JPG 画像のサイズを変更するには、[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) メソッドに *ScaleX* と *ScaleY* の値を渡すことで設定できます：  
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // 次元を定義
    int desiredX = 1200;
    int desiredY = 800;
    // X と Y のスケールされた値を取得
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // フルスケールの画像を作成
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // 画像を JPEG 形式でディスクに保存
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


## **画像としてプレゼンテーションを保存するときにコメントをレンダリングする**

Aspose.Slides for Java は、スライドを画像に変換する際にプレゼンテーション内のコメントをレンダリングできる機能を提供しています。以下の Java コードでその操作を示します：  
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


{{% alert title="Tip" color="primary" %}}

Aspose は、[無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使って、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG への画像結合、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) の作成などが可能です。  

この記事で説明した同じ原理を使って、画像を別の形式に変換できます。詳しくは以下のページをご参照ください: [image to JPG に変換](https://products.aspose.com/slides/java/conversion/image-to-jpg/)；[JPG から image に変換](https://products.aspose.com/slides/java/conversion/jpg-to-image/)；[JPG から PNG に変換](https://products.aspose.com/slides/java/conversion/jpg-to-png/) 、[PNG から JPG に変換](https://products.aspose.com/slides/java/conversion/png-to-jpg/)；[PNG から SVG に変換](https://products.aspose.com/slides/java/conversion/png-to-svg/) 、[SVG から PNG に変換](https://products.aspose.com/slides/java/conversion/svg-to-png/)。  

{{% /alert %}}

## よくある質問 (FAQ)

### PowerPoint (PPT, PPTX) を JPG に変換するには？

Aspose.Slides for Java を使用して PowerPoint スライドを JPG に変換できます。これにより、出力設定を完全に制御しながら高品質な画像変換が実現します。

### この方法でバッチ変換はサポートされていますか？

はい、Aspose.Slides は