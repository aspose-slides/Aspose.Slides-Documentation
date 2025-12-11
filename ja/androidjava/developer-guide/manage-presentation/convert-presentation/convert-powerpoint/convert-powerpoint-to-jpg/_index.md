---
title: AndroidでPPTとPPTXをJPGに変換
linktitle: PowerPoint を JPG に変換
type: docs
weight: 60
url: /ja/androidjava/convert-powerpoint-to-jpg/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからJPGへ
- プレゼンテーションをJPGへ
- スライドをJPGへ
- PPTをJPGへ
- PPTXをJPGへ
- PowerPointをJPGとして保存
- プレゼンテーションをJPGとして保存
- スライドをJPGとして保存
- PPTをJPGとして保存
- PPTXをJPGとして保存
- PPTをJPGにエクスポート
- PPTXをJPGにエクスポート
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、JavaでPowerPoint（PPT、PPTX）スライドを高速かつ信頼性の高いコード例で高品質なJPG画像に変換します。"
---

## **概要**

PowerPoint および OpenDocument のプレゼンテーションを JPG 画像に変換することで、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for Android via Java を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、さまざまな変換方法について説明します。

これらの機能を使用すると、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成するのが簡単です。スライドのコピーを防止したり、読み取り専用モードでプレゼンテーションをデモンストレーションしたりする場合に便利です。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換**

PPT、PPTX、または ODP ファイルを JPG に変換する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) メソッドが返すコレクションから、[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) 型のスライドオブジェクトを取得します。
3. [ISlide.getImage(float, float)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) メソッドを使用してスライドの画像を作成します。
4. 画像オブジェクトで [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを呼び出します。出力ファイル名と画像形式を引数として渡します。

{{% alert color="primary" %}} 
**注:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides Android via Java API の他の形式への変換とは異なります。他の形式の場合、通常は [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用します。ただし、JPG 変換の場合は、[IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを使用する必要があります。
{{% /alert %}} 
```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 指定されたスケールでスライド画像を作成します。
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


## **カスタマイズされたサイズでスライドを JPG 画像に変換**

生成された JPG 画像のサイズを変更するには、[ISlide.getImage(Size)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値で画像を生成でき、出力が解像度やアスペクト比の要件を満たすようにできます。この柔軟性は、ウェブアプリケーション、レポート、ドキュメント用に画像を生成する際に、正確な画像サイズが必要な場合に特に有用です。
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


## **スライドを画像として保存する際にコメントを描画**

Aspose.Slides for Android via Java は、プレゼンテーションのスライドを JPG 画像に変換する際にコメントを描画できる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保持するのに特に役立ちます。このオプションを有効にすると、生成された画像にコメントが表示され、元のプレゼンテーションファイルを開かずにフィードバックの確認や共有が容易になります。

たとえば、コメントが含まれるスライドを持つプレゼンテーションファイル "sample.pptx" があるとします：

![コメント付きスライド](slide_with_comments.png)

以下の Java コードは、コメントを保持したままスライドを JPG 画像に変換します：

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


結果：

![コメント付きJPG画像](image_with_comments.png)

## **関連項目**

PPT、PPTX、または ODP を画像に変換する他のオプションをご覧ください。例：

- [PowerPoint を GIF に変換](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/androidjava/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides が PowerPoint プレゼンテーションを JPG 画像に変換する方法を確認するには、以下の無料オンラインコンバータをご利用ください：PowerPoint [PPTX を JPG に変換](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT を JPG に変換](https://products.aspose.app/slides/conversion/ppt-to-jpg) をお試しください。 
{{% /alert %}} 

![無料オンライン PPTX to JPG コンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は [無料 Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG 画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

この記事で説明した同じ原理を使用して、画像をある形式から別の形式に変換できます。詳細については、以下のページをご覧ください：画像を JPG に変換する [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)；JPG を画像に変換する [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/)；JPG を PNG に変換する [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)、PNG を JPG に変換する [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)；PNG を SVG に変換する [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)、SVG を PNG に変換する [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

## **よくある質問**

**この方法はバッチ変換をサポートしますか？**

はい、Aspose.Slides は、