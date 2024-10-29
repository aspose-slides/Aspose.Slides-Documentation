---
title: プレゼンテーション内のスライドにアクセス
type: docs
weight: 20
url: /ja/php-java/access-slide-in-presentation/
keywords: "PowerPoint プレゼンテーションへのアクセス, スライドへのアクセス, スライドプロパティの編集, スライド位置の変更, スライド番号、インデックス、ID、位置の設定 Java, Aspose.Slides"
description: "インデックス、ID、または位置によって PowerPoint スライドにアクセスします。スライドプロパティを編集します。"
---

Aspose.Slidesを使用すると、インデックスまたはIDによってスライドにアクセスできます。

## **インデックスによるスライドへのアクセス**

プレゼンテーション内のすべてのスライドは、0から開始するスライド位置に基づいて番号付けされています。最初のスライドはインデックス0を介してアクセスでき、2つ目のスライドはインデックス1を介してアクセスできます。

Presentationクラスは、プレゼンテーションファイルを表し、すべてのスライドを[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/)コレクション（[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)オブジェクトのコレクション）として公開します。このPHPコードは、インデックスを介してスライドにアクセスする方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("demo.pptx");
  try {
    # スライドインデックスを使用してスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **IDによるスライドへのアクセス**

プレゼンテーション内の各スライドには、固有のIDが関連付けられています。[getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-)メソッド（[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスによって公開された）を使用して、そのIDをターゲットにすることができます。このPHPコードは、有効なスライドIDを提供し、[getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-)メソッドを介してそのスライドにアクセスする方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("demo.pptx");
  try {
    # スライドIDを取得
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # IDを介してスライドにアクセス
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **スライド位置の変更**

Aspose.Slidesを使用すると、スライドの位置を変更できます。たとえば、最初のスライドを2番目のスライドにするように指定できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを介して位置を変更したいスライドの参照を取得します。
1. [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-)プロパティを介してスライドの新しい位置を設定します。
1. 修正したプレゼンテーションを保存します。

このPHPコードは、位置1のスライドを位置2に移動する操作を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("Presentation.pptx");
  try {
    # 位置が変更されるスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # スライドの新しい位置を設定
    $sld->setSlideNumber(2);
    # 修正したプレゼンテーションを保存
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

最初のスライドは2番目になり、2番目のスライドは最初になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号の設定**

[setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-)プロパティ（[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスによって公開された）を使用すると、プレゼンテーション内の最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライド番号を取得します。
1. スライド番号を設定します。
1. 修正したプレゼンテーションを保存します。

このPHPコードは、最初のスライド番号を10に設定する操作を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # スライド番号を取得
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # スライド番号を設定
    $pres->setFirstSlideNumber(10);
    # 修正したプレゼンテーションを保存
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

最初のスライドをスキップしたい場合は、次の方法で2番目のスライドから番号付けを開始できます（最初のスライドの番号付けを非表示にする）：

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # 最初のプレゼンテーションスライドの番号を設定
    $presentation->setFirstSlideNumber(0);
    # すべてのスライドのスライド番号を表示
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # 最初のスライドのスライド番号を非表示にする
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # 修正したプレゼンテーションを保存
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```