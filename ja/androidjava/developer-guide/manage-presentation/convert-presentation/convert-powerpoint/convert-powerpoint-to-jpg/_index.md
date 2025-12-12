---
title: Android で PPT および PPTX を JPG に変換
linktitle: PowerPoint を JPG に変換
type: docs
weight: 60
url: /ja/androidjava/convert-powerpoint-to-jpg/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、Java で PowerPoint（PPT、PPTX）スライドを高速かつ信頼性の高いコード例で高品質な JPG 画像に変換します。"
---

## **概要**

PowerPoint および OpenDocument のプレゼンテーションを JPG 画像に変換することで、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for Android via Java を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。本ガイドでは、さまざまな変換方法について説明します。

これらの機能を使用すると、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成することが簡単になります。スライドのコピーから保護したい場合や、読み取り専用モードでプレゼンテーションをデモする場合に便利です。Aspose.Slides は、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーションスライドを JPG 画像に変換する**

PPT、PPTX、または ODP ファイルを JPG に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) メソッドが返すコレクションから、タイプが [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) のスライド オブジェクトを取得します。
1. [ISlide.getImage(float, float)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) メソッドを使用してスライドの画像を作成します。
1. 画像オブジェクトで [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを呼び出します。出力ファイル名と画像フォーマットを引数として渡します。

{{% alert color="primary" %}} 
**Note:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides Android via Java API の他の形式への変換とは異なります。他の形式の場合、通常は [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用します。ただし、JPG 変換の場合は、[IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを使用する必要があります。
{{% /alert %}} 
```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 指定したスケールでスライド画像を作成します。
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // 画像を JPEG 形式でディスクに保存します。
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **カスタマイズされたサイズでスライドを JPG に変換する**

生成される JPG 画像のサイズを変更するには、[ISlide.getImage(Size)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値を持つ画像を生成でき、解像度やアスペクト比の要件を満たす出力が得られます。この柔軟性は、ウェブアプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に有用です。
```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 指定されたサイズでスライド画像を作成します。
        IImage slideImage = slide.getImage(imageSize);

        try {
            // 画像を JPEG 形式でディスクに保存します。
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **画像としてスライドを保存するときにコメントをレンダリングする**

Aspose.Slides for Android via Java は、スライドを JPG 画像に変換する際にプレゼンテーションのスライド上のコメントをレンダリングできる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保持するのに特に有用です。このオプションを有効にすると、生成された画像にコメントが表示されるため、元のプレゼンテーション ファイルを開かなくてもフィードバックの確認や共有が容易になります。

たとえば、コメントが含まれたスライドを持つプレゼンテーション ファイル "sample.pptx" があるとします:

![コメント付きスライド](slide_with_comments.png)

次の Java コードは、コメントを保持したままスライドを JPG 画像に変換します:
```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // 最初のスライドを画像に変換します。
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```


結果:

![コメント付き JPG 画像](image_with_comments.png)

## **関連項目**

PPT、PPTX、または ODP を画像に変換する他のオプションは次のとおりです:

- [PowerPoint を GIF に変換](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/androidjava/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides が PowerPoint プレゼンテーションを JPG 画像に変換する方法を確認するには、次の無料オンラインコンバータをお試しください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

![無料オンライン PPTX から JPG 変換ツール](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は [FREE Collage web app](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG 画像を結合したり、[photo grids](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

本記事で説明したのと同じ原理を使用して、画像を別の形式に変換できます。詳細については、次のページをご参照ください: 変換 [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/); 変換 [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/); 変換 [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

## **よくある質問**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は単一の操作で