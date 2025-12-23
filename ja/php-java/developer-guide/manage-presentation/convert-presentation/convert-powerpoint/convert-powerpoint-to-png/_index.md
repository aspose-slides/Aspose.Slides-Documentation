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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **PowerPoint から PNG への変換について**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。

**使用例:** 複雑な画像でサイズが問題にならない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint to PNG コンバータ** をチェックしたいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは本ページで説明したプロセスの実装例です。 {{% /alert %}}

## **PowerPoint を PNG に変換する**

次の手順を実行してください:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスをインスタンス化します。
2. [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) インターフェイスの下にある [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) コレクションからスライドオブジェクトを取得します。
3. 各スライドのサムネイルを取得するために [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) メソッドを使用します。
4. スライドのサムネイルを PNG 形式で保存するために [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) メソッドを使用します。

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

特定のスケールで PNG ファイルを取得したい場合は、結果のサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。

このコードは上記の操作を示しています:
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

特定のサイズの PNG ファイルを取得したい場合は、`ImageSize` に対して希望の `width` と `height` を渡すことができます。

このコードは、画像のサイズを指定しながら PowerPoint を PNG に変換する方法を示しています:
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
Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/php-java/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバーでの並列変換はサポートされていますか？**  
はい、ただしスレッド間で単一のプレゼンテーション インスタンスを共有しないでください。[共有しない](/slides/ja/php-java/multithreading/)ことが必要です。スレッドまたはプロセスごとに別々のインスタンスを使用してください。

**PNG にエクスポートする際の評価版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/php-java/licensing/) が適用されます。