---
title: JavaでPPTおよびPPTXをJPGに変換
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
description: "Aspose.Slides for Java を使用し、迅速で信頼性の高いコード例で、Java において PowerPoint (PPT, PPTX) スライドを高品質な JPG 画像に変換します。"
---
## **はじめに**

PowerPoint および OpenDocument プレゼンテーションを JPG 画像に変換することで、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。本ガイドでは、さまざまな変換方法を説明します。

これらの機能により、独自のプレゼンテーション ビューアを実装し、各スライドのサムネイルを作成することが簡単になります。スライドのコピーから保護したい場合や、読み取り専用モードでプレゼンテーションをデモする場合に便利です。Aspose.Slides は、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **PowerPoint PPT/PPTX を JPG に変換**

PPT/PPTX を JPG に変換する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) 型のインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getSlides--) コレクションから、[ISlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide) 型のスライド オブジェクトを取得します。
3. 各スライドのサムネイルを作成し、JPG に変換します。[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide#getImage-float-float-) メソッドはスライドのサムネイルを取得するために使用され、結果として [Images](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Images) オブジェクトを返します。[getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) メソッドは、必要な [ISlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide) 型のスライドから呼び出す必要があり、生成されるサムネイルのスケールはメソッドに渡されます。
4. スライドのサムネイルを取得したら、サムネイル オブジェクトから [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを呼び出します。生成されたファイル名と画像形式を渡します。

{{% alert color="info" %}}
**注**: PPT/PPTX から JPG への変換は、Aspose.Slides API の他の種類への変換とは異なります。他の種類の場合、通常は [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用しますが、ここでは [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドが必要です。
{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // フルスケールの画像を作成します
        IImage slideImage = sld.getImage(1f, 1f);

        // 画像を JPEG 形式でディスクに保存します
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

## **カスタマイズされたサイズで PowerPoint PPT/PPTX を JPG に変換**

生成されるサムネイルと JPG 画像のサイズを変更するには、[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide#getImage-float-float-) メソッドに *ScaleX* と *ScaleY* の値を渡すことで設定できます。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // 次元を定義します
    int desiredX = 1200;
    int desiredY = 800;
    // X と Y のスケール値を取得します
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // フルスケールの画像を作成します
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // 画像を JPEG 形式でディスクに保存します
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

## **スライドを画像として保存する際にコメントをレンダリング**

Aspose.Slides for Java は、スライドを画像に変換する際にプレゼンテーションのスライド内のコメントをレンダリングできる機能を提供します。この Java コードはその操作を示しています：

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

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

{{% alert title="Tip" color="info" %}}
Aspose は、[FREE Collage web app](https://products.aspose.app/slides/ja/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/ja/collage/jpg) や PNG から PNG への画像の結合、[photo grids](https://products.aspose.app/slides/ja/collage/photo-grid) の作成などができます。

本記事で説明した同じ原理を使用して、画像を別の形式に変換できます。詳細については、以下のページをご覧ください: 変換 [image to JPG](https://products.aspose.com/slides/ja/java/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/ja/java/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/ja/java/conversion/jpg-to-png/), 変換 [PNG to JPG](https://products.aspose.com/slides/ja/java/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/ja/java/conversion/png-to-svg/), 変換 [SVG to PNG](https://products.aspose.com/slides/ja/java/conversion/svg-to-png/)。
{{% /alert %}}

## **FAQ**

### この方法はバッチ変換をサポートしていますか？

はい、Aspose.Slides は、複数のスライドを単一の操作で JPG にバッチ変換できます。

### 変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツをレンダリングします。ただし、カスタムフォントや欠損フォントを使用する場合、PowerPoint と比較してレンダリング精度が若干異なることがあります。

### 処理できるスライド数に制限はありますか？

Aspose.Slides 自体には処理できるスライド数に厳格な制限はありません。ただし、大規模なプレゼンテーションや高解像度画像を扱う場合、メモリ不足エラーが発生する可能性があります。

## **関連項目**

PPT/PPTX を画像に変換する他のオプションをご覧ください:

- [PPT/PPTX を SVG に変換](/slides/ja/java/render-a-slide-as-an-svg-image/).