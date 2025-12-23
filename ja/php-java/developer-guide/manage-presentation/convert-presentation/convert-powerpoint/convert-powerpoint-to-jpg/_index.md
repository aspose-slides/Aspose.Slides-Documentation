---
title: PHPでPPTとPPTXをJPGに変換
linktitle: PowerPointからJPGへ
type: docs
weight: 60
url: /ja/php-java/convert-powerpoint-to-jpg/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用し、迅速で信頼性の高いコード例で、PowerPoint（PPT、PPTX）スライドを高品質な JPG 画像に PHP で変換します。"
---

## **PowerPoint を JPG に変換する概要**
Aspose.Slides API を使用すると、PowerPoint の PPT または PPTX プレゼンテーションを JPG 画像に変換できます。PPT/PPTX を JPEG、PNG、SVG に変換することも可能です。この機能により、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりするのが簡単になります。プレゼンテーションスライドをコピーから保護したり、読み取り専用モードでデモンストレーションしたりしたい場合に便利です。Aspose.Slides は、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

{{% alert color="primary" %}} 
PowerPoint を JPG 画像に変換する Aspose.Slides の動作を確認するには、以下の無料オンラインコンバータを試してみてください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX を JPG に変換**
PPT/PPTX を JPG に変換する手順は以下の通りです:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 型のインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 型のスライドオブジェクトを、[Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) コレクションから取得します。
3. 各スライドのサムネイルを作成し、JPG に変換します。[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) メソッドはスライドのサムネイルを取得するために使用され、結果として [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) オブジェクトを返します。[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) メソッドは必要な [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 型のスライドから呼び出す必要があり、生成されるサムネイルのスケールがメソッドに渡されます。
4. スライドのサムネイルを取得したら、サムネイルオブジェクトから [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを呼び出します。結果のファイル名と画像形式を渡します。

{{% alert color="primary" %}}
**Note**: PPT/PPTX を JPG に変換する方法は、Aspose.Slides API の他の形式への変換と異なります。他の形式では通常、[**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用しますが、ここでは [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドが必要です。
{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # フルスケール画像を作成します
      $slideImage = $sld->getImage(1.0, 1.0);
      # 画像を JPEG 形式でディスクに保存します
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


## **カスタマイズしたサイズで PowerPoint PPT/PPTX を JPG に変換**
生成されるサムネイルおよび JPG 画像のサイズを変更するには、[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) メソッドに *ScaleX* と *ScaleY* の値を渡して設定します：
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # 次元を定義します
    $desiredX = 1200;
    $desiredY = 800;
    # X と Y のスケール値を取得
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # フルスケール画像を作成します
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # 画像を JPEG 形式でディスクに保存します
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


## **スライドを画像として保存する際にコメントを描画**
Aspose.Slides for PHP via Java は、スライドを画像に変換する際にプレゼンテーションのスライド上のコメントを描画できる機能を提供します。この PHP コードはその操作例を示しています：
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


{{% alert title="Tip" color="primary" %}}
Aspose は、[無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG 画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。  

本記事で説明した同じ原理を使用して、画像を別の形式に変換できます。詳細は以下のページをご参照ください: 画像を [JPG に変換](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)；[JPG を画像に変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)；[JPG を PNG に変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)；[PNG を JPG に変換](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)；[PNG を SVG に変換](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)；[SVG を PNG に変換](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。
{{% /alert %}}

## **よくある質問**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は単一の操作で