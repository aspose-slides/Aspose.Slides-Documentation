---
title: Android で PPT と PPTX を JPG に変換する
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
description: "Aspose.Slides for Android を使用し、Java で PowerPoint（PPT、PPTX）スライドを高品質な JPG 画像に変換する高速で信頼性のあるコード例"
---
## **はじめに**

PowerPoint および OpenDocument プレゼンテーションを JPG 画像に変換することで、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for Android via Java を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、さまざまな変換方法について説明します。

これらの機能により、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成するのが簡単になります。スライドのコピーから保護したり、読み取り専用モードでプレゼンテーションを示す場合に便利です。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換する**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlides--) メソッドが返すコレクションから、[ISlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) 型のスライドオブジェクトを取得します。
3. [ISlide.getImage(float, float)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getImage-float-float-) メソッドを使用してスライドの画像を作成します。
4. 画像オブジェクトに対して [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを呼び出します。出力ファイル名と画像形式を引数として渡します。

{{% alert color="info" %}} 
**注:** PPT、PPTX、ODP から JPG への変換は、Aspose.Slides Android via Java API の他形式への変換とは異なります。他の形式の場合、通常は [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用します。ただし、JPG 変換の場合は [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) メソッドを使用する必要があります。
{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 指定されたスケールでスライド画像を作成します。
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // JPEG 形式で画像をディスクに保存します。
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

結果の JPG 画像のサイズを変更するには、[ISlide.getImage(Size)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値で画像を生成でき、解像度やアスペクト比の要件を満たす出力が得られます。この柔軟性は、Web アプリケーション、レポート、ドキュメントなど、正確な画像サイズが必要なシナリオで特に有用です。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 指定されたサイズでスライド画像を作成します。
        IImage slideImage = slide.getImage(imageSize);

        try {
            // JPEG 形式で画像をディスクに保存します。
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

## **スライドを画像として保存する際にコメントを描画する**

Aspose.Slides for Android via Java は、スライドを JPG 画像に変換する際にプレゼンテーションのスライド上のコメントを描画できる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保存するのに特に便利です。このオプションを有効にすると、生成された画像内にコメントが表示され、元のプレゼンテーション ファイルを開かずにフィードバックの確認や共有が容易になります。

たとえば、コメントが含まれるスライドを持つプレゼンテーション ファイル "sample.pptx" があるとします:

![コメント付きスライド](slide_with_comments.png)

以下の Java コードは、コメントを保持したままスライドを JPG 画像に変換します。

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

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

## **参照**

PPT、PPTX、ODP を画像に変換する他のオプションを参照してください。例:

- [PowerPoint を GIF に変換](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/androidjava/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Aspose.Slides が PowerPoint プレゼンテーションを JPG 画像に変換する方法を確認するには、以下の無料オンラインコンバータを試してください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/ja/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/ja/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![無料オンライン PPTX から JPG へのコンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose は[無料の Collage Web アプリ](https://products.aspose.app/slides/ja/collage)を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/ja/collage/jpg)や PNG から PNG 画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/ja/collage/photo-grid)を作成したりできます。

この記事で説明したのと同じ原理を使って、画像をある形式から別の形式に変換できます。詳細は次のページをご覧ください: 変換 [image to JPG](https://products.aspose.com/slides/ja/java/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/ja/java/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/ja/java/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/ja/java/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/ja/java/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/ja/java/conversion/svg-to-png/)。
{{% /alert %}}

## **よくある質問**

### この方法はバッチ変換をサポートしていますか？

はい、Aspose.Slides は単一の操作で複数のスライドを JPG にバッチ変換できます。

### 変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツをレンダリングします。ただし、カスタムフォントや欠損フォントを使用した場合、PowerPoint と比較してレンダリング精度が若干異なることがあります。

### 処理できるスライド数に制限はありますか？

Aspose.Slides 自体は処理できるスライド数に厳密な制限を設けていません。ただし、大規模なプレゼンテーションや高解像度画像を扱う際にメモリ不足エラーが発生する可能性があります。