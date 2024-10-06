---
title: PowerPointをJPGに変換
type: docs
weight: 60
url: /ja/php-java/convert-powerpoint-to-jpg/
keywords: "PowerPointをJPGに変換, PPTXをJPEGに, PPTをJPEGに"
description: "PowerPointをJPGに変換: PPTからJPG、PPTXからJPG"
---

## **PowerPointからJPGへの変換について**
[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)を使用すると、PowerPointのPPTまたはPPTXプレゼンテーションをJPG画像に変換できます。また、PPT/PPTXをJPEG、PNG、またはSVGに変換することも可能です。この機能を使うことで、自分専用のプレゼンテーションビューアを実装し、スライドごとにサムネイルを作成するのが簡単になります。これは、プレゼンテーションスライドを著作権から保護したい場合や、読み取り専用モードでプレゼンテーションを示したい場合に便利です。Aspose.Slidesでは、全体のプレゼンテーションまたは特定のスライドを画像形式に変換できます。

{{% alert color="primary" %}} 

Aspose.SlidesがPowerPointをJPG画像に変換する方法を確認するには、これらの無料オンラインコンバータを試してみると良いでしょう: PowerPoint [PPTXをJPGに変換](https://products.aspose.app/slides/conversion/pptx-to-jpg)および [PPTをJPGに変換](https://products.aspose.app/slides/conversion/ppt-to-jpg)。

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTXをJPGに変換する**
PPT/PPTXをJPGに変換する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)型のインスタンスを作成します。
2. [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)コレクションから[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)型のスライドオブジェクトを取得します。
3. 各スライドのサムネイルを作成し、それをJPGに変換します。[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-)メソッドを使用してスライドのサムネイルを取得し、[Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images)オブジェクトを結果として返します。[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-)メソッドは、必要な[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)型のスライドから呼び出され、結果のサムネイルのスケールがメソッドに渡されます。
4. スライドサムネイルを取得したら、サムネイルオブジェクトから[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))メソッドを呼び出します。結果のファイル名と画像形式を渡します。

{{% alert color="primary" %}}

**注意**: PPT/PPTXをJPGに変換する場合は、Aspose.Slides APIでの他のタイプへの変換とは異なります。他のタイプでは通常、[**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用しますが、ここでは[**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))メソッドを使用する必要があります。

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # フルスケールの画像を作成
      $slideImage = $sld->getImage(1.0, 1.0);
      # JPEG形式で画像をディスクに保存
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **カスタマイズされた寸法でPowerPoint PPT/PPTXをJPGに変換する**
結果のサムネイルおよびJPG画像の寸法を変更するには、*ScaleX*および*ScaleY*の値を設定して[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-)メソッドに渡すことができます：

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # 寸法を定義
    $desiredX = 1200;
    $desiredY = 800;
    # XとYのスケール値を取得
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # フルスケールの画像を作成
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # JPEG形式で画像をディスクに保存
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **プレゼンテーションを画像に保存する際にコメントをレンダリングする**
Aspose.Slides for PHP via Javaは、スライドを画像に変換する際にプレゼンテーションのスライドにコメントをレンダリングできる機能を提供しています。このPHPコードはその操作を示しています：

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用して、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)やPNGからPNGの画像を結合し、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成することができます。

この記事で説明したのと同じ原則を使用して、画像をある形式から別の形式に変換できます。詳細については、以下のページを参照してください: 画像を[JPGに変換](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); JPGを画像に変換する; [JPGをPNGに変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/); [PNGをJPGに変換](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); [PNGをSVGに変換](https://products.aspose.com/slides/php-java/conversion/png-to-svg/); [SVGをPNGに変換](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。

{{% /alert %}}

## **関連情報**

PPT/PPTXを画像に変換する他のオプションを参照してください:

- [PPT/PPTXをSVGに変換](/slides/ja/php-java/render-a-slide-as-an-svg-image/)。