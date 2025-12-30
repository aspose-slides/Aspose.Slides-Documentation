---
title: PHPでプレゼンテーションにフォントを埋め込む
linktitle: フォントの埋め込み
type: docs
weight: 40
url: /ja/php-java/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォント埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint と OpenDocument のプレゼンテーションに TrueType フォントを埋め込み、すべてのプラットフォームで正確に表示できるようにします。"
---

**PowerPoint の埋め込みフォント** は、プレゼンテーションを任意のシステムやデバイスで開いたときに正しく表示させたい場合に役立ちます。作業で創造的になり、サードパーティ製や非標準フォントを使用した場合、さらに埋め込みフォントにする理由が増えます。それ以外の場合（埋め込みフォントがないと）、スライド上のテキストや数字、レイアウト、スタイリングなどが変更されたり、意味不明な四角形に変わったりする可能性があります。

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) クラス、[FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) クラス、[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) クラス、およびそれらのインターフェイスには、PowerPoint プレゼンテーションで埋め込みフォントを操作するために必要なプロパティやメソッドがほぼすべて含まれています。

## **埋め込みフォントの取得と削除**

Aspose.Slides は、プレゼンテーションに埋め込まれているフォントを取得（または確認）できるように、[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) クラスで公開されている [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) メソッドを提供しています。フォントを削除するには、同じクラスで公開されている [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) メソッドを使用します。

この PHP コードは、プレゼンテーションから埋め込みフォントを取得および削除する方法を示しています:
```php
  # プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # 埋め込み "FunSized" を使用するテキストフレームを含むスライドをレンダリングします
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 画像を JPEG 形式でディスクに保存します
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # すべての埋め込みフォントを取得します
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # "Calibri" フォントを検索します
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # "Calibri" フォントを削除します
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # プレゼンテーションをレンダリングします。"Calibri" フォントは既存のフォントに置き換えられます
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # 画像を JPEG 形式でディスクに保存します
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 埋め込まれた "Calibri" フォントなしでプレゼンテーションをディスクに保存します
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **埋め込みフォントの追加**

[EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) 列挙体と、[addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) メソッドの 2 つのオーバーロードを使用すると、プレゼンテーションに埋め込むフォントのルールを選択できます。この PHP コードは、フォントを埋め込み追加する方法を示しています:
```php
  # プレゼンテーションを読み込みます
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # プレゼンテーションをディスクに保存します
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **埋め込みフォントの圧縮**

プレゼンテーションに埋め込まれたフォントを圧縮し、ファイル サイズを削減できるように、Aspose.Slides は [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) クラスで公開されている [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) メソッドを提供しています。

この PHP コードは、埋め込み PowerPoint フォントを圧縮する方法を示しています:
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**プレゼンテーション内の特定のフォントが埋め込みにもかかわらずレンダリング時に置き換えられるかどうかを確認する方法はありますか？**

フォントマネージャーの [置換情報](/slides/ja/php-java/font-substitution/) と [フォールバック/置換ルール](/slides/ja/php-java/fallback-font/) を確認してください。フォントが利用できない、または制限されている場合はフォールバックが使用されます。

**Arial や Calibri のような「システム」フォントを埋め込む価値はありますか？**

通常は不要です。これらのフォントはほぼ常に利用可能です。ただし、Docker やフォントが事前インストールされていない Linux サーバーなど「軽量」環境での完全なポータビリティが必要な場合、システムフォントを埋め込むことで予期しない置換リスクを排除できます。