---
title: PHP でプレゼンテーションを効率的にマージ
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/php-java/merge-presentation/
keywords:
- PowerPoint のマージ
- プレゼンテーションのマージ
- スライドのマージ
- PPT のマージ
- PPTX のマージ
- ODP のマージ
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを手軽にマージし、ワークフローを効率化します。"
---

## **プレゼンテーションのマージ**

プレゼンテーションを別のプレゼンテーションにマージすると、スライドを単一のプレゼンテーションに結合して、1つのファイルにすることになります。

{{% alert title="情報" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPoint や OpenOffice）には、ユーザーがこのようにプレゼンテーションを結合できる機能がありません。

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/) は、さまざまな方法でプレゼンテーションをマージできるようにします。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を損失や品質低下を心配することなくマージできます。

**参照**

[Clone Slides](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **マージできるもの**

Aspose.Slides を使用すると、次のものをマージできます。

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます  
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます  
* 同一フォーマットのプレゼンテーション（PPT から PPT、PPTX から PPTX など）および異なるフォーマット（PPT から PPTX、PPTX から ODP など）を相互にマージできます。

{{% alert title="注" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は他のファイルのマージもサポートします。

* [画像](https://products.aspose.com/slides/php-java/merger/image-to-image/)、たとえば [JPG から JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)  
* ドキュメント、たとえば [PDF から PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)  
* 画像と PDF のように異なる種類のファイル（例: 画像から PDF、JPG から PDF、TIFF から PDF）

{{% /alert %}}

### **マージ オプション**

次のように、出力プレゼンテーションの各スライドが個別のスタイルを保持するか、すべてのスライドに同じスタイルを適用するかを決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか  
* 出力プレゼンテーションのすべてのスライドに特定のスタイルを使用するか  

プレゼンテーションをマージするには、Aspose.Slides は [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッド（[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) インターフェイス）を提供します。`AddClone` メソッドには、プレゼンテーション マージ プロセスのパラメーターを定義する複数の実装があります。すべての Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) コレクションを持っているため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。

`AddClone` メソッドは `ISlide` オブジェクトを返します。これはソース スライドのクローンです。出力プレゼンテーションのスライドは、単にソース スライドのコピーです。したがって、ソース プレゼンテーションに影響を与えることなく、結果のスライドに対して（たとえばスタイルや書式設定オプション、レイアウトを適用する）変更を行うことができます。

## **プレゼンテーションのマージ** 

Aspose.Slides は、スライドのレイアウトとスタイルを保持したままスライドを結合できる [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを提供します（デフォルト パラメーター）。

この PHP コードはプレゼンテーションのマージ方法を示しています:
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


## **スライド マスターを使用したプレゼンテーションのマージ** 

Aspose.Slides は、スライド マスター プレゼンテーション テンプレートを適用しながらスライドを結合できる [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを提供します。この方法では、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

このコードは上記の操作を示しています:
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


{{% alert title="注" color="warning" %}} 

スライド マスターのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブール パラメーターが true に設定されていれば、ソース スライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを使用したい場合は、マージ時に [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) メソッドを使用してください。

## **プレゼンテーションから特定のスライドをマージ** 

複数のプレゼンテーションから特定のスライドをマージすると、カスタム スライド デッキを作成できます。Aspose.Slides for PHP via Java は、必要なスライドだけを選択してインポートできるようにします。API は元のスライドの書式設定、レイアウト、デザインを保持します。

以下の PHP コードは新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトル スライドを追加して結果をファイルに保存します:
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


## **スライド レイアウトを使用したプレゼンテーションのマージ** 

この PHP コードは、プレゼンテーションからスライドを結合し、希望するスライド レイアウトを適用して 1 つの出力プレゼンテーションを作成する方法を示しています:
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


## **異なるスライド サイズのプレゼンテーションのマージ** 

{{% alert title="注" color="warning" %}} 

異なるスライド サイズのプレゼンテーションはマージできません。 

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションをマージするには、どちらかのプレゼンテーションのサイズを他方に合わせてリサイズする必要があります。

このサンプルコードは上記の操作を示しています:
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

この PHP コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示しています:
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

## **関連情報**


Aspose は [FREE Online Collage Maker](https://products.aspose.app/slides/collage) を提供しています。このオンライン サービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像をマージしたり、[フォト グリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

[Aspose FREE Online Merger](https://products.aspose.app/slides/merger) も確認してください。これは、同じ形式（例: PPT から PPT、PPTX から PPTX）または異なる形式（例: PPT から PPTX、PPTX から ODP）の PowerPoint プレゼンテーションをマージできます。

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **FAQ**

**プレゼンテーションをマージするときのスライド数に制限はありますか？**

厳密な制限はありません。Aspose.Slides は大容量ファイルを処理できますが、パフォーマンスはサイズやシステムリソースに依存します。非常に大きなプレゼンテーションの場合は、64 ビット JVM を使用し、十分なヒープ メモリを割り当てることを推奨します。

**埋め込み動画や音声があるプレゼンテーションをマージできますか？**

はい。Aspose.Slides はスライドに埋め込まれたマルチメディア コンテンツを保持しますが、最終的なプレゼンテーションは大幅にサイズが増加する可能性があります。

**フォントはマージ時に保持されますか？**

はい。ソース プレゼンテーションで使用されたフォントは、システムにインストールされているか [埋め込み](/slides/ja/php-java/embedded-font/) されている限り、出力ファイルに保持されます。