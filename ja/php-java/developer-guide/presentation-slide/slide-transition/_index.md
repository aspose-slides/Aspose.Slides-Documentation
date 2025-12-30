---
title: PHP でプレゼンテーションのスライド遷移を管理する
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/php-java/slide-transition/
keywords:
- スライド遷移
- スライド遷移の追加
- スライド遷移の適用
- 高度なスライド遷移
- モーフ遷移
- 遷移タイプ
- 遷移効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でスライド遷移をカスタマイズする方法を、PowerPoint と OpenDocument のプレゼンテーション向けにステップバイステップでご紹介します。"
---

## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java でも、開発者はスライドの遷移効果を管理・カスタマイズできます。このトピックでは、Aspose.Slides for PHP via Java を使用してスライド遷移を簡単に制御する方法について説明します。

{{% /alert %}} 

理解しやすくするために、Aspose.Slides for PHP via Java を使用したシンプルなスライド遷移の管理例を示します。開発者はスライドにさまざまな遷移効果を適用できるだけでなく、これらの遷移効果の動作をカスタマイズできます。

## **Add Slide Transition**
シンプルなスライド遷移効果を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. TransitionType 列挙体から、Aspose.Slides for PHP via Java が提供する遷移効果のいずれかを使用してスライドに遷移タイプを適用します。
1. 変更したプレゼンテーションファイルを書き出します。
```php
  # プレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # スライド1に円形遷移を適用
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # スライド2にコーム形遷移を適用
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # プレゼンテーションをディスクに保存
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Add Advanced Slide Transition**
前節ではシンプルな遷移効果のみを適用しました。ここでは、同じ遷移効果をさらに高度に制御できるようにする手順を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for PHP via Java が提供する遷移効果のいずれかを使用してスライドに遷移タイプを適用します。
1. 遷移を「クリックで進む」(Advance On Click)、「指定時間後に進む」(Advance After Time) またはその両方に設定できます。
1. スライド遷移が「クリックで進む」ように有効化されている場合、マウスクリック時にのみ遷移が進みます。さらに、Advance After Time プロパティが設定されていれば、指定した時間が経過した後に自動的に遷移が進みます。
1. 変更したプレゼンテーションをファイルとして書き出します。
```php
  # プレゼンテーションファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # スライド1にサークル型遷移を適用
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 遷移時間を 3 秒に設定
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # スライド2にコーム型遷移を適用
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 遷移時間を 5 秒に設定
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # スライド3にズーム型遷移を適用
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 遷移時間を 7 秒に設定
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # プレゼンテーションをディスクに保存
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Morph Transition**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は現在、[Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition) をサポートしています。これは PowerPoint 2019 で導入された新しいモーフ遷移です。

{{% /alert %}} 

Morph 遷移は、あるスライドから次のスライドへ滑らかな動きをアニメーション化します。本稿では概念と Morph 遷移の使用方法を説明します。Morph 遷移を効果的に使用するには、少なくとも 1 つの共通オブジェクトを持つ 2 枚のスライドが必要です。最も簡単な方法は、スライドを複製し、2 枚目のスライドでオブジェクトを別の位置に移動することです。

以下のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2 枚目のスライドに [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) の遷移を設定する方法を示しています。
```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
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


## **Morph Transition Types**
新しい [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) 列挙体が追加されました。これは Morph スライド遷移のさまざまなタイプを表します。

TransitionMorphType 列挙体には次の 3 つのメンバーがあります。

- ByObject: 形状を分割できないオブジェクトとして扱い、Morph 遷移を実行します。
- ByWord: 可能な限り単語単位でテキストを転送しながら Morph 遷移を実行します。
- ByChar: 可能な限り文字単位でテキストを転送しながら Morph 遷移を実行します。

以下のコードスニペットは、スライドに Morph 遷移を設定し、Morph タイプを変更する方法を示しています。
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


## **Set Transition Effects**
Aspose.Slides for PHP via Java は、黒から、左から、右から などの遷移効果の設定をサポートしています。遷移効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- 遷移効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。

以下の例では、遷移効果を設定しています。
```php
  # Presentation クラスのインスタンスを作成
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # エフェクトを設定
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # プレゼンテーションをディスクに保存
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Can I control the playback speed of a slide transition?**

はい。遷移の [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) を、[TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 設定（例: slow/medium/fast）で指定できます。

**Can I attach audio to a transition and make it loop?**

はい。遷移にサウンドを埋め込んで、サウンドモードやループ設定（例: [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/)、[setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/)、[setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/)）で動作を制御できます。また、[setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) や [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/) などのメタデータも設定可能です。

**What’s the fastest way to apply the same transition to every slide?**

各スライドの遷移設定で目的の遷移タイプを設定すれば、スライドごとに同じ遷移が適用され、一貫した結果が得られます。

**How can I check which transition is currently set on a slide?**

スライドの [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) を確認し、[transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/) を取得すれば、現在適用されている効果を正確に把握できます。