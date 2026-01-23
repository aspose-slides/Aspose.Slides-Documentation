---
title: PHPでPPTとPPTXをJPGに変換する
linktitle: PowerPointからJPGへ
type: docs
weight: 60
url: /ja/php-java/convert-powerpoint-to-jpg/
keywords: 
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからJPG
- プレゼンテーションからJPG
- スライドからJPG
- PPTからJPG
- PPTXからJPG
- PowerPointをJPGとして保存
- プレゼンテーションをJPGとして保存
- スライドをJPGとして保存
- PPTをJPGとして保存
- PPTXをJPGとして保存
- PPTをJPGにエクスポート
- PPTXをJPGにエクスポート
- PHP
- Aspose.Slides
description: "高速で信頼性の高いコード例を使用して、PHP用 Aspose.Slides で PowerPoint（PPT、PPTX）スライドを高品質な JPG 画像に変換します。"
---

## **PowerPoint to JPG 変換について**
[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) を使用すると、PowerPoint PPT または PPTX プレゼンテーションを JPG 画像に変換できます。PPT/PPTX を JPEG、PNG、SVG に変換することも可能です。この機能を利用すれば、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりできます。プレゼンテーションスライドをコピーライトから保護したり、読み取り専用モードでデモンストレーションしたりする場合にも便利です。Aspose.Slides は、プレゼンテーション全体または特定のスライドを画像形式に変換できます。  

{{% alert color="primary" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認したい場合は、次の無料オンライン変換ツールを試してください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX を JPG に変換する方法**
PPT/PPTX を JPG に変換する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 型のインスタンスを作成します。  
2. [Presentation::getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) コレクションから [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) 型のスライドオブジェクトを取得します。  
3. 各スライドのサムネイルを作成し、JPG に変換します。サムネイル取得には **[Slide::getImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)** メソッドを使用します。`getImage` メソッドは対象の [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) 型から呼び出し、結果のサムネイルのスケールを引数として渡します。  
4. スライドのサムネイルを取得したら、サムネイルオブジェクトから **[IImage::save(String formatName, int imageFormat)](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))** メソッドを呼び出します。ファイル名と画像形式を指定してください。  

{{% alert color="primary" %}}

**注意**: PPT/PPTX から JPG への変換は、Aspose.Slides API の他の形式への変換とは異なります。他の形式では通常 **[Presentation::Save(String fname, int format, SaveOptions options)](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)** メソッドを使用しますが、JPG 変換の場合は **[IImage::save(String formatName, int imageFormat)](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))** メソッドを使用する必要があります。

{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # フルスケール画像を作成
      $slideImage = $sld->getImage(1.0, 1.0);
      # 画像を JPEG 形式でディスクに保存
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


## **カスタマイズしたサイズで PowerPoint PPT/PPTX を JPG に変換する方法**
生成されるサムネイルおよび JPG 画像のサイズを変更するには、[**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) メソッドに *ScaleX* と *ScaleY* の値を渡します:
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # 次元を定義
    $desiredX = 1200;
    $desiredY = 800;
    # X と Y のスケール済み値を取得
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # フルスケール画像を作成
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # 画像を JPEG 形式でディスクに保存
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


## **スライドを画像として保存する際にコメントを描画する**
Aspose.Slides for PHP via Java は、スライドを画像に変換する際にプレゼンテーションのコメントを描画できる機能を提供します。以下の PHP コードがその操作例です:
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

Aspose は [FREE Collage web app](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使って、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG の画像を結合したり、[photo grids](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。  

本記事で説明した原理を利用すれば、画像形式間の変換も実行できます。詳細は次のページをご参照ください: 画像を [JPG に変換](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)、JPG を [画像に変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)、JPG を [PNG に変換](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)、PNG を [JPG に変換](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)、PNG を [SVG に変換](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)、SVG を [PNG に変換](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。

{{% /alert %}}

## **FAQ**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は複数スライドを一括で JPG に変換するバッチ変換をサポートしています。

**変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？**

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツをレンダリングします。ただし、カスタム フォントや欠落フォントを使用した場合、PowerPoint と比較して若干の精度差が生じることがあります。

**処理できるスライド数に制限はありますか？**

Aspose.Slides 自体に厳格なスライド数の上限はありませんが、大規模なプレゼンテーションや高解像度画像を扱う際にメモリ不足エラーが発生する可能性があります。

## **See Also**

PPT/PPTX を画像に変換する他のオプション:

- [PPT/PPTX to SVG conversion](/slides/ja/php-java/render-a-slide-as-an-svg-image/)