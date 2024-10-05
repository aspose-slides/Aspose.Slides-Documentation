---
title: スライドトランジション
type: docs
weight: 80
url: /php-java/slide-transition/
keywords: "PowerPointスライドトランジション, モーフトランジション"
description: "PowerPointスライドトランジション, PowerPointモーフトランジション"
---


## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Javaは、開発者がスライドのトランジション効果を管理またはカスタマイズすることを可能にします。このトピックでは、Aspose.Slides for PHP via Javaを使用して、スライドトランジションを簡単にコントロールする方法について説明します。

{{% /alert %}} 

理解しやすくするために、Aspose.Slides for PHP via Javaを使用してシンプルなスライドトランジションを管理する方法を示しています。開発者は、スライドに異なるスライドトランジション効果を適用するだけでなく、これらのトランジション効果の動作をカスタマイズすることもできます。

## **スライドトランジションの追加**
シンプルなスライドトランジション効果を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. TransitionType列挙型に基づいて、Aspose.Slides for PHP via Javaが提供するトランジション効果の1つをスライドに適用します。
1. 修正されたプレゼンテーションファイルを書き込みます。

```php
  # プレゼンテーションクラスのインスタンスを作成して、ソースプレゼンテーションファイルを読み込みます
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # スライド1に円形タイプのトランジションを適用します
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # スライド2にコンボタイプのトランジションを適用します
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # プレゼンテーションをディスクに書き込みます
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **高度なスライドトランジションの追加**
上記のセクションでは、スライドにシンプルなトランジション効果を適用しました。これをさらに良くし、コントロールできるようにするために、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. Aspose.Slides for PHP via Javaが提供するトランジション効果の1つをスライドに適用します。
1. トランジションをクリック時に進める、特定の時間経過後、またはその両方に設定することもできます。
1. スライドトランジションがクリック時に進むように設定されている場合、その進行はマウスをクリックしたときにのみ行われます。さらに、進む時間が設定されている場合、指定された経過時間が過ぎると自動的にトランジションが進行します。
1. 修正されたプレゼンテーションをプレゼンテーションファイルとして書き込みます。

```php
  # プレゼンテーションクラスのインスタンスを作成して、プレゼンテーションファイルを表します
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # スライド1に円形タイプのトランジションを適用します
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 3秒のトランジション時間を設定します
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # スライド2にコンボタイプのトランジションを適用します
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 5秒のトランジション時間を設定します
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # スライド3にズームタイプのトランジションを適用します
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 7秒のトランジション時間を設定します
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # プレゼンテーションをディスクに書き込みます
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **モーフトランジション**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Javaは現在、[モーフトランジション](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition)をサポートしています。PowerPoint 2019で導入された新しいモーフトランジションを表します。

{{% /alert %}} 

モーフトランジションを使用すると、1つのスライドから次のスライドにスムーズに移動するアニメーションを作成できます。この記事では、その概念とモーフトランジションの使用方法について説明します。モーフトランジションを効果的に使用するには、少なくとも1つの共通のオブジェクトを持つ2つのスライドが必要です。最も簡単な方法は、スライドを複製し、次に2つ目のスライドのオブジェクトを別の場所に移動することです。

以下のコードスニペットは、プレゼンテーションにテキストを含むスライドのクローンを追加し、2つ目のスライドに[morphタイプ](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType)のトランジションを設定する方法を示しています。

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("PowerPointプレゼンテーションにおけるモーフトランジション");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **モーフトランジションタイプ**
新しい[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType)列挙型が追加されました。これは、さまざまなタイプのモーフスライドトランジションを表します。

TransitionMorphType列挙型には3つのメンバーがあります。

- ByObject: モーフトランジションは、シェイプを分割不可能なオブジェクトとして考慮して実行されます。
- ByWord: モーフトランジションは、可能な限り単語ごとにテキストを転送する形で実行されます。
- ByChar: モーフトランジションは、可能な限り文字ごとにテキストを転送する形で実行されます。

以下のコードスニペットは、スライドにモーフトランジションを設定し、モーフタイプを変更する方法を示しています。

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **トランジションエフェクトの設定**
Aspose.Slides for PHP via Javaは、黒から、左から、右からなどのトランジションエフェクトを設定することをサポートしています。トランジションエフェクトを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- スライドの参照を取得します。
- トランジションエフェクトを設定します。
- プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

以下の例では、トランジションエフェクトを設定しています。

```php
  # プレゼンテーションクラスのインスタンスを作成します
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # エフェクトを設定します
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # プレゼンテーションをディスクに書き込みます
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```