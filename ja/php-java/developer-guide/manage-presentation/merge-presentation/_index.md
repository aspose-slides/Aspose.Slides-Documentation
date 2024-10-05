---
title: 統合プレゼンテーション
type: docs
weight: 40
url: /php-java/merge-presentation/
keywords: "PowerPointを統合する, PPTX, PPT, PowerPointを結合する, プレゼンテーションを統合する, プレゼンテーションを結合する, Java"
description: "PowerPointプレゼンテーションを統合または結合します"
---

{{% alert  title="ヒント" color="primary" %}} 

**Asposeの無料オンライン** [Mergerアプリ](https://products.aspose.app/slides/merger)をチェックしてみてください。これを使用すると、同じ形式でPowerPointプレゼンテーションを統合したり（PPTからPPT、PPTXからPPTXなど）、異なる形式のプレゼンテーションを統合したり（PPTからPPTX、PPTXからODPなど）できます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 

## **プレゼンテーションの統合**

1つのプレゼンテーションを別のプレゼンテーションに統合すると、実質的にそれらのスライドが1つのプレゼンテーションにまとめられ、1ファイルを取得します。

{{% alert title="情報" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointやOpenOffice）には、ユーザーがそのようにプレゼンテーションを結合する機能が欠けています。

しかし、[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)は、さまざまな方法でプレゼンテーションを統合することを可能にします。すべての図形、スタイル、テキスト、書式設定、コメント、アニメーションなどを失うことなく、質やデータの損失を心配することなくプレゼンテーションを統合できます。

**関連情報**

[スライドを複製](https://docs.aspose.com/slides/php-java/clone-slides/)。

{{% /alert %}}

### **統合できるもの**

Aspose.Slidesを使用すると、次のものを統合できます。

* 完全なプレゼンテーション。プレゼンテーションのすべてのスライドが1つのプレゼンテーションに集約されます
* 特定のスライド。選択したスライドが1つのプレゼンテーションに集約されます
* 1つの形式のプレゼンテーション（PPTからPPT、PPTXからPPTXなど）と異なる形式（PPTからPPTX、PPTXからODPなど）を相互に統合できます。

{{% alert title="注意" color="warning" %}} 

プレゼンテーションの他に、Aspose.Slidesは他のファイルも統合できます：

* [画像](https://products.aspose.com/slides/php-java/merger/image-to-image/)、例えば、[JPGからJPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/)または[PNGからPNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* 文書、例えば、[PDFからPDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/)または[HTMLからHTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* そして、[画像からPDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/)や[JPGからPDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/)または[TIFFからPDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/)など、2つの異なるファイル。

{{% /alert %}}

### **統合オプション**

出力プレゼンテーション内の各スライドがユニークなスタイルを保持するか、すべてのスライドに特定のスタイルを使用するかを決定するオプションを適用できます。

プレゼンテーションを統合するために、Aspose.Slidesは[AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッド（[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)インターフェイスから）を提供します。プレゼンテーションの統合プロセスパラメータを定義する`AddClone`メソッドのいくつかの実装があります。各Presentationオブジェクトには[Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)コレクションがあるため、スライドを統合したいプレゼンテーションから`AddClone`メソッドを呼び出すことができます。

`AddClone`メソッドは、ソーススライドのクローンである`ISlide`オブジェクトを返します。出力プレゼンテーションのスライドは、ソースからのスライドの単なるコピーです。したがって、ソースのプレゼンテーションに影響を与えることを心配することなく、結果のスライド（たとえば、スタイルや書式設定オプションまたはレイアウトを適用）を変更できます。

## **プレゼンテーションを統合する**

Aspose.Slidesは、スライドがレイアウトやスタイルを保持したまま統合することを可能にする[**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを提供しています（デフォルトのパラメータ）。

このPHPコードは、プレゼンテーションを統合する方法を示しています：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **スライドマスターを使用したプレゼンテーションの統合**

Aspose.Slidesは、スライドマスタープレゼンテーションテンプレートを適用しながらスライドを統合することを可能にする[**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)メソッドを提供します。このようにして、必要に応じて出力プレゼンテーション内のスライドのスタイルを変更できます。

このコードは、説明された操作を示しています：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

スライドマスターのスライドレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone`メソッドの`allowCloneMissingLayout`ブールパラメータがtrueに設定されている場合、ソーススライドのレイアウトが使用されます。そうでない場合は、[PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException)がスローされます。

{{% /alert %}}

出力プレゼンテーション内のスライドに異なるスライドレイアウトを持たせたい場合は、統合の際に[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)メソッドを代わりに使用してください。

## **特定のスライドをプレゼンテーションから統合する**

このPHPコードは、異なるプレゼンテーションから特定のスライドを選択して結合し、1つの出力プレゼンテーションを取得する方法を示しています：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **スライドレイアウトを適用したプレゼンテーションの統合**

このPHPコードは、プレゼンテーションからスライドを結合し、好みのスライドレイアウトを適用して1つの出力プレゼンテーションを取得する方法を示しています：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **異なるスライドサイズを持つプレゼンテーションの統合**

{{% alert title="注意" color="warning" %}} 

異なるスライドサイズを持つプレゼンテーションを統合することはできません。 

{{% /alert %}}

異なるスライドサイズを持つ2つのプレゼンテーションを統合するには、1つのプレゼンテーションのサイズを他のプレゼンテーションのサイズと一致させるようにリサイズする必要があります。

このサンプルコードは、説明された操作を示しています：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **プレゼンテーションセクションへのスライドの統合**

このPHPコードは、特定のスライドをプレゼンテーションのセクションに統合する方法を示しています：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

スライドはセクションの最後に追加されます。

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュウェブアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを利用することで、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)またはPNGからPNG画像を統合し、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成することができます。

{{% /alert %}}