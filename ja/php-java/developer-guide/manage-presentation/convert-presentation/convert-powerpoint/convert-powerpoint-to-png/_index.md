---
title: PHPでPowerPointスライドをPNGに変換
linktitle: PowerPointからPNGへ
type: docs
weight: 30
url: /ja/php-java/convert-powerpoint-to-png/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからPNGへ
- プレゼンテーションからPNGへ
- スライドからPNGへ
- PPTからPNGへ
- PPTXからPNGへ
- PPTをPNGとして保存
- PPTXをPNGとして保存
- PPTをPNGにエクスポート
- PPTXをPNGにエクスポート
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP（Java経由）を使用して、PowerPointプレゼンテーションを高品質なPNG画像に迅速に変換し、正確で自動化された結果を実現します。"
---

## **PowerPoint から PNG への変換について**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。  

**使用例:** 画像が複雑でサイズが問題とならない場合、PNG は JPEG よりも優れた画像形式です。  

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint から PNG へのコンバータ** をご確認ください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは本ページで説明したプロセスの実装例です。{{% /alert %}}

## **PowerPoint を PNG に変換する**

以下の手順を実行してください:

1. Presentation クラスのインスタンスを作成します。
2. Slide クラスの下にある Presentation.getSlides() コレクションからスライドオブジェクトを取得します。
3. Slide.getImage() メソッドを使用して各スライドのサムネイルを取得します。
4. IImage.save(String formatName, int imageFormat) メソッドを使用してスライドのサムネイルを PNG 形式で保存します。

この PHP コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **カスタム寸法で PowerPoint を PNG に変換する**

特定のスケールの PNG ファイルを取得したい場合は、結果のサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。  

このコードは上記の操作を実演しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **カスタムサイズで PowerPoint を PNG に変換する**

特定のサイズの PNG ファイルを取得したい場合は、`ImageSize` に希望の `width` と `height` 引数を渡すことができます。  

このコードは画像サイズを指定して PowerPoint を PNG に変換する方法を示しています: 
```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **FAQ**

**スライド全体ではなく、特定のシェイプ（例: チャートや画像）だけをエクスポートするにはどうすればよいですか？**  

Aspose.Slides は個々のシェイプのサムネイル生成をサポートしています。シェイプを PNG 画像としてレンダリングできます。  

**サーバーでの並列変換はサポートされていますか？**  

はい、可能ですが、スレッド間で単一の Presentation インスタンスを共有しないでください。スレッドまたはプロセスごとに別々のインスタンスを使用してください。  

**PNG へのエクスポート時の体験版の制限は何ですか？**  

評価モードでは出力画像に透かしが付加され、ライセンスが適用されるまで他の制限が適用されます。