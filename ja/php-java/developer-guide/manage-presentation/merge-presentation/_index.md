---
title: PHPでプレゼンテーションを効率的にマージ
linktitle: プレゼンテーションをマージ
type: docs
weight: 40
url: /ja/php-java/merge-presentation/
keywords:
- PowerPointをマージ
- プレゼンテーションをマージ
- スライドをマージ
- PPTをマージ
- PPTXをマージ
- ODPをマージ
- PowerPointを結合
- プレゼンテーションを結合
- スライドを結合
- PPTを結合
- PPTXを結合
- ODPを結合
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを手軽にマージし、ワークフローを効率化します。"
---

## **プレゼンテーションのマージ**

プレゼンテーションを別のプレゼンテーションにマージすると、スライドを単一のプレゼンテーションに結合し、1つのファイルにすることができます。

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーションソフト（PowerPoint または OpenOffice）には、ユーザーがこのようにプレゼンテーションを結合する機能がありません。

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/) は、さまざまな方法でプレゼンテーションをマージできるようにします。形状、スタイル、テキスト、書式設定、コメント、アニメーションなどを失うことなく、プレゼンテーション全体をマージできます。

**参照**  

[スライドの複製](/slides/ja/php-java/clone-slides/).

{{% /alert %}}

### **マージできるもの**

Aspose.Slides を使用すると、次のものをマージできます。

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます。  
* 特定のスライド。選択したスライドだけが 1 つのプレゼンテーションにまとめられます。  
* 同じ形式のプレゼンテーション（PPT → PPT、PPTX → PPTX など）や、異なる形式（PPT → PPTX、PPTX → ODP など）同士のマージ。

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は次のファイルのマージもサポートします。

* [画像](https://products.aspose.com/slides/php-java/merger/image-to-image/)（例: [JPG から JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)）  
* 文書（例: [PDF から PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)）  
* 異なる種類のファイルの組み合わせ（例: [画像から PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/)、[JPG から PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/)、[TIFF から PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/)）。

{{% /alert %}}

### **マージオプション**

次のようなオプションを指定できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか  
* 出力プレゼンテーションのすべてのスライドが同一のスタイルを使用するか  

プレゼンテーションをマージするには、Aspose.Slides は [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) メソッド（[SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) クラス）を提供します。`addClone` メソッドにはさまざまな実装があり、マージ処理のパラメータを指定できます。各 Presentation オブジェクトは [slide](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) コレクションを持つため、スライドをマージしたいプレゼンテーションから `addClone` メソッドを呼び出せます。

`addClone` メソッドは、ソーススライドのクローンとなる `Slide` オブジェクトを返します。出力プレゼンテーションのスライドは、ソースのスライドのコピーです。そのため、元のプレゼンテーションに影響を与えることなく、結果として得られたスライドにスタイルや書式設定、レイアウトなどの変更を加えることができます。

## **プレゼンテーションのマージ** 

Aspose.Slides は、スライドのレイアウトとスタイルを保持したままスライドを結合できる [addClone(Slide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) メソッドを提供します（デフォルト パラメータ）。

この PHP コードはプレゼンテーションのマージ方法を示しています。
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


## **スライドマスターを使用したプレゼンテーションのマージ** 

Aspose.Slides は、[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) メソッドを提供し、スライドマスターテンプレートを適用しながらスライドを結合できます。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

このコードは上記の操作を示しています。
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


{{% alert title="Note" color="warning" %}} 

スライドマスターのレイアウトは自動的に決定されます。適切なレイアウトが判断できない場合、`addClone` メソッドの `allowCloneMissingLayout` ブールパラメータが true に設定されていれば、ソーススライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを使用したい場合は、マージ時に [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) メソッドを使用してください。

## **プレゼンテーションから特定のスライドをマージ** 

複数のプレゼンテーションから特定のスライドをマージすると、カスタム スライド デックの作成に便利です。Aspose.Slides for PHP via Java を使用すると、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

次の PHP コードは新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトルスライドを追加して、結果をファイルに保存します。
```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```

```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```


## **スライドレイアウトを指定したプレゼンテーションのマージ** 

この PHP コードは、プレゼンテーションからスライドを結合し、希望するスライドレイアウトを適用して 1 つの出力プレゼンテーションを作成する方法を示しています。
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


## **異なるスライドサイズのプレゼンテーションのマージ** 

{{% alert title="Note" color="warning" %}} 

スライドサイズが異なるプレゼンテーションはマージできません。 

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションをマージするには、どちらかのプレゼンテーションのサイズをもう一方に合わせてリサイズする必要があります。

このサンプルコードは上記の操作を示しています。
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


## **スライドをプレゼンテーション セクションにマージ** 

この PHP コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示しています。
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


スライドはセクションの末尾に追加されます。

## **関連項目**


Aspose は、[FREE Online Collage Maker](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

[Aspose FREE Online Merger](https://products.aspose.app/slides/merger) をチェックしてください。同じ形式（例: PPT → PPT、PPTX → PPTX）または異なる形式（例: PPT → PPTX、PPTX → ODP）間で PowerPoint プレゼンテーションをマージできます。

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **FAQ**

**プレゼンテーションをマージする際のスライド数に制限はありますか？**

厳密な制限はありません。Aspose.Slides は大容量ファイルを処理できますが、パフォーマンスはファイルサイズとシステムリソースに依存します。非常に大きなプレゼンテーションの場合は、64 ビット JVM を使用し、十分なヒープメモリを割り当てることを推奨します。

**埋め込み動画や音声を含むプレゼンテーションをマージできますか？**

はい。Aspose.Slides はスライドに埋め込まれたマルチメディア コンテンツを保持しますが、最終的なプレゼンテーションは大幅にサイズが大きくなる可能性があります。

**フォントはマージ時に保持されますか？**

はい。ソースプレゼンテーションで使用されたフォントは、システムにインストールされているか[埋め込み](/slides/ja/php-java/embedded-font/)されていることを前提に、出力ファイルに保持されます。