---
title: PHP を使用したプレゼンテーションのスライド トランジションの管理
linktitle: スライド トランジション
type: docs
weight: 80
url: /ja/php-java/slide-transition/
keywords:
- スライドトランジション
- スライドトランジションの追加
- スライドトランジションの適用
- 高度なスライドトランジション
- モーフトランジション
- トランジションタイプ
- トランジション効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのスライド トランジションをカスタマイズする方法を、ステップバイステップで解説します。"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、開発者がスライドのトランジション効果を管理またはカスタマイズできるようにします。本トピックでは、Aspose.Slides for PHP via Java を使用してスライドトランジションを簡単に制御する方法について説明します。

{{% /alert %}} 

理解しやすくするために、Aspose.Slides for PHP via Java を使用してシンプルなスライドトランジションを管理する例を示しました。開発者はスライドにさまざまなトランジション効果を適用できるだけでなく、これらの効果の動作もカスタマイズできます。

## **スライドトランジションの追加**
シンプルなスライドトランジション効果を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. TransitionType 列挙体を使用して、Aspose.Slides for PHP via Java が提供するトランジション効果のいずれかをスライドに適用します。
3. 変更したプレゼンテーションをファイルに書き込みます。
```php
  # ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # スライド 1 にサークルタイプのトランジションを適用
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # スライド 2 にコンブタイプのトランジションを適用
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # プレゼンテーションをディスクに保存
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **高度なスライドトランジションの追加**
上記のセクションではシンプルなトランジション効果を適用しました。次に、同じトランジション効果をより細かく制御できるようにする手順です。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for PHP via Java が提供するトランジション効果の中からスライドにトランジションタイプを適用します。
3. トランジションを「クリックで進む」設定、特定の時間経過後に進む設定、またはその両方に設定できます。
4. 「クリックで進む」設定が有効な場合、マウスクリック時にのみトランジションが進みます。さらに、Advance After Time プロパティが設定されていると、指定された時間が経過した後に自動的にトランジションが進みます。
5. 変更したプレゼンテーションをファイルとして保存します。
```php
  # プレゼンテーションファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # スライド 1 にサークルタイプのトランジションを適用
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # 3 秒のトランジション時間を設定
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # スライド 2 にコンブタイプのトランジションを適用
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # 5 秒のトランジション時間を設定
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # スライド 3 にズームタイプのトランジションを適用
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # 7 秒のトランジション時間を設定
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # プレゼンテーションをディスクに保存
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **モーフトランジション**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は現在、[Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) をサポートしています。これは PowerPoint 2019 で導入された新しいモーフトランジションです。

{{% /alert %}} 

モーフトランジションを使用すると、スライド間のスムーズな移動をアニメーション化できます。本記事ではモーフトランジションの概念と使用方法を説明します。モーフトランジションを効果的に使用するには、少なくとも 1 つのオブジェクトが共通する 2 枚のスライドが必要です。最も簡単な方法は、スライドを複製し、2 枚目のスライドでオブジェクトを別の位置に移動することです。

以下のコードスニペットは、テキスト付きのスライドのコピーをプレゼンテーションに追加し、2 枚目のスライドに [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) のトランジションを設定する方法を示しています。
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


## **モーフトランジションの種類**
新しい [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType) 列挙体が追加されました。これはモーフスライドトランジションの種類を表します。

TransitionMorphType 列挙体には 3 つのメンバーがあります。

- ByObject: シェイプを不可分のオブジェクトとして扱い、モーフトランジションを実行します。
- ByWord: 可能な場合、テキストを単語単位で転送してモーフトランジションを実行します。
- ByChar: 可能な場合、テキストを文字単位で転送してモーフトランジションを実行します。

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


## **トランジション効果の設定**
Aspose.Slides for PHP via Java は、黒から、左から、右からなどのトランジション効果の設定をサポートしています。トランジション効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- トランジション効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。

以下の例では、トランジション効果を設定しています。
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


## **よくある質問**

**スライドトランジションの再生速度を制御できますか？**

はい。トランジションの [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) を [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 設定で指定できます（例: slow/medium/fast）。

**トランジションに音声を添付し、ループさせることはできますか？**

はい。トランジション用にサウンドを埋め込むことができ、サウンドモードやループ設定（例: [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/)）で動作を制御できます。さらに、[setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) や [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/) などのメタデータも設定可能です。

**すべてのスライドに同じトランジションを適用する最速の方法は？**

各スライドのトランジション設定で目的のトランジションタイプを構成します。トランジションはスライドごとに保存されるため、すべてのスライドに同じタイプを設定すれば一貫した結果が得られます。

**スライドに現在設定されているトランジションを確認するには？**

スライドの [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) を調べ、[transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/) を取得します。その値が適用されているエフェクトを正確に示します。