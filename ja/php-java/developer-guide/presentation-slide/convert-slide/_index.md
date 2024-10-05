---
title: スライドの変換
type: docs
weight: 35
url: /php-java/convert-slide/
keywords: 
- スライドを画像に変換
- スライドを画像としてエクスポート
- スライドを画像として保存
- スライドから画像へ
- スライドをPNGに
- スライドをJPEGに
- スライドをビットマップに
- PHP
- Aspose.Slides for PHP via Java
description: "PHPでPowerPointスライドを画像（ビットマップ、PNG、またはJPG）に変換"
---

Aspose.Slides for PHP via Javaを使用すると、スライド（プレゼンテーション内）を画像に変換できます。サポートされている画像フォーマットは次のとおりです：BMP、PNG、JPG（JPEG）、GIF、その他です。

スライドを画像に変換するには、以下の手順を実行します：

1. 最初に、変換パラメータと変換するスライドオブジェクトを設定します：
   * [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) インターフェースを使用するか
   * [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions) インターフェースを使用します。

2. 次に、[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用して、スライドを画像に変換します。

## **ビットマップおよびその他の画像フォーマットについて**

Javaでは、[Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images)は、ピクセルデータによって定義された画像を操作するためのオブジェクトです。このクラスのインスタンスを使用して、さまざまな形式（JPG、PNGなど）で画像を保存できます。

{{% alert title="情報" color="info" %}}

Asposeは最近、オンラインの[Text to GIF](https://products.aspose.app/slides/text-to-gif)コンバーターを開発しました。

{{% /alert %}}

## **スライドをビットマップとして変換し、PNG形式で画像を保存する**

以下のPHPコードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、その後PNG形式で画像を保存する方法を示しています：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # プレゼンテーションの最初のスライドをImagesオブジェクトに変換
    $slideImage = $pres->getSlides()->get_Item(0)->getImage();
    # PNG形式で画像を保存
    try {
      # ディスクに画像を保存します。
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

このサンプルコードは、[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用して、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換する方法を示しています：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # プレゼンテーションのスライドサイズを取得
    $slideSize = new Java("java.awt.Dimension", $slideSize->getWidth(), $slideSize->getHeight());
    # スライドサイズでImagesを作成
    $slideImage = $sld->getImage(new RenderingOptions(), $slideSize);
    try {
      # ディスクに画像を保存します。
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ヒント" color="primary" %}} 

スライドをImagesオブジェクトに変換し、そのオブジェクトを直接使用することができます。また、スライドをImagesに変換し、JPEGや他の好きな形式で画像を保存することも可能です。

{{% /alert %}}  

## **カスタムサイズの画像に変換するスライド**

特定のサイズの画像を取得する必要がある場合があります。[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) メソッドのオーバーロードを使用すると、特定の寸法（長さと幅）でスライドを画像に変換できます。

このサンプルコードは、[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用した提案された変換を示しています：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 指定されたサイズでプレゼンテーションの最初のスライドをビットマップに変換
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 1820, 1040));
    # JPEG形式で画像を保存
    try {
      # ディスクに画像を保存します。
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **メモとコメント付きスライドを画像に変換する**

いくつかのスライドにはメモやコメントが含まれています。

Aspose.Slidesは、プレゼンテーションスライドを画像にレンダリングするための制御を提供する2つのインターフェース、[ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) と [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions) を提供します。どちらのインターフェースにも、スライドを画像に変換するときにメモやコメントを追加することができる[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions)インターフェースがあります。

{{% alert title="情報" color="info" %}} 

[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) インターフェースを使用すると、生成された画像内のメモとコメントの位置を指定できます。

{{% /alert %}} 

このPHPコードは、メモとコメントを含むスライドの変換プロセスを示しています：

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # レンダリングオプションを作成
    $options = new RenderingOptions();
    # ページ上のメモの位置を設定
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # ページ上のコメントの位置を設定
    $options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);
    # コメントの出力エリアの幅を設定
    $options->getNotesCommentsLayouting()->setCommentsAreaWidth(500);
    # コメントエリアの色を設定
    $options->getNotesCommentsLayouting()->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);
    # プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, 2.0, 2.0);
    # GIF形式で画像を保存
    try {
      $slideImage->save("Slide_Notes_Comments_0.gif", ImageFormat::Gif);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

このPHPコードは、[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) メソッドを使用して、メモを含むスライドの変換プロセスを示しています：

```php
  $pres = new Presentation("PresentationNotes.pptx");
  try {
    # プレゼンテーションのメモサイズを取得
    $notesSize = $pres->getNotesSize()->getSize();
    # レンダリングオプションを作成
    $options = new RenderingOptions();
    # メモの位置を設定
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # メモのサイズでImagesを作成
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, $notesSize);
    # PNG形式で画像を保存
    try {
      # ディスクに画像を保存します。
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

スライドを画像に変換する過程において、[NotesPositions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) プロパティをBottomFullに設定することはできません（メモの位置を指定するため）。なぜなら、メモのテキストが大きい場合、指定された画像サイズに収まらない可能性があるためです。

{{% /alert %}} 

## **ITiffOptionsを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) インターフェースを使用すると、生成される画像に対するパラメータの制御が強化されます。このインターフェースを使用することで、生成される画像のサイズ、解像度、カラーパレット、およびその他のパラメータを指定できます。

このPHPコードは、ITiffOptionsを使用して300dpiの解像度と2160 × 2800のサイズを持つ白黒画像を出力する変換プロセスを示します：

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # インデックスでスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # TiffOptionsオブジェクトを作成
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));
    # ソースフォントが見つからない場合に使用するフォントを設定
    $options->setDefaultRegularFont("Arial Black");
    # ページ上のメモの位置を設定
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # ピクセルフォーマットを設定（白黒）
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);
    # 解像度を設定
    $options->setDpiX(300);
    $options->setDpiY(300);
    # スライドをビットマップオブジェクトに変換
    $slideImage = $slide->getImage($options);
    # TIFF形式で画像を保存
    try {
      $slideImage->save("PresentationNotesComments.tiff", ImageFormat::Tiff);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

JDK 9未満のバージョンでは、Tiffサポートは保証されていません。

{{% /alert %}} 

## **すべてのスライドを画像に変換する**

Aspose.Slidesを使用すると、単一のプレゼンテーションのすべてのスライドを画像に変換できます。基本的には、プレゼンテーション全体を画像に変換できます。

このサンプルコードは、プレゼンテーション内のすべてのスライドを画像に変換する方法を示しています：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # スライドごとに画像にプレゼンテーションをレンダリング
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      # 非表示スライドを制御（非表示スライドをレンダリングしない）
      if ($pres->getSlides()->get_Item($i)->getHidden()) {
        continue;
      }
      # スライドをビットマップオブジェクトに変換
      $slideImage = $pres->getSlides()->get_Item($i)->getImage(2.0, 2.0);
      # PNG形式で画像を保存
      try {
        $slideImage->save("Slide_" . $i . ".png", ImageFormat::Png);
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