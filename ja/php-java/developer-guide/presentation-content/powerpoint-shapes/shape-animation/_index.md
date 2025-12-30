---
title: PHP を使用してプレゼンテーションにシェイプ アニメーションを適用する
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/php-java/shape-animation/
keywords:
  - シェイプ
  - アニメーション
  - エフェクト
  - アニメーション シェイプ
  - アニメーション テキスト
  - アニメーションを追加
  - アニメーションを取得
  - アニメーションを抽出
  - エフェクトを追加
  - エフェクトを取得
  - エフェクトを抽出
  - エフェクト サウンド
  - アニメーションを適用
  - PowerPoint
  - プレゼンテーション
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法をご紹介します。際立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[チャート](https://docs.aspose.com/slides/php-java/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

アニメーションを使用すると、

* 情報の流れを制御する
* 重要なポイントを強調する
* 聴衆の関心や参加を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* 読者や視聴者の注意をプレゼンテーションの重要な部分に引き付ける

PowerPoint は、**入口**、**退出**、**強調**、および**モーション パス**カテゴリにわたるアニメーションとアニメーション効果のための多くのオプションとツールを提供します。

## **Aspose.Slides のアニメーション**

* Aspose.Slides は、`Aspose.Slides.Animation` 名前空間でアニメーションを操作するために必要なクラスと型を提供します。
* Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype) 列挙体で **150 以上のアニメーション効果** を提供します。これらの効果は基本的に PowerPoint で使用されるものと同じ（または同等）です。

## **テキストボックスへのアニメーションの適用**

Aspose.Slides for PHP via Java を使用すると、図形内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-) にテキストを追加します。
5. 主シーケンスのエフェクトを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) にアニメーション効果を追加します。
7. `TextAnimation.BuildType` プロパティを `BuildType` 列挙体の値に設定します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この PHP コードは、AutoShape に `Fade` 効果を適用し、テキストアニメーションを *By 1st Level Paragraphs* に設定する方法を示しています：
```php
  # プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # テキスト付きの新しい AutoShape を追加します
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # スライドのメインシーケンスを取得します。
    $sequence = $sld->getTimeline()->getMainSequence();
    # シェイプにフェード アニメーション効果を追加します
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # シェイプのテキストを第1レベル段落ごとにアニメーションさせます
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # PPTX ファイルをディスクに保存します
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert color="primary"  %}} 
テキストへのアニメーション適用に加えて、単一の[段落](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph)にもアニメーションを適用できます。**アニメーション テキスト** を参照してください。
{{% /alert %}} 

## **PictureFrame へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) を追加または取得します。
4. 主シーケンスのエフェクトを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) にアニメーション効果を追加します。
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この PHP コードは、PictureFrame に `Fly` 効果を適用する方法を示しています：
```php
  # プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
  $pres = new Presentation();
  try {
    # プレゼンテーションの画像コレクションに追加する画像をロードします
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # スライドに画像フレームを追加します
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # スライドのメインシーケンスを取得します。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # 画像フレームに左からのフライ アニメーション効果を追加します
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # PPTX ファイルをディスクに保存します
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Shape へのアニメーションの適用**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライド参照を取得します。
3. `rectangle` の [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) を追加します。
4. `Bevel` の [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. ベベル形状上でエフェクトのシーケンスを作成します。
6. カスタム `UserPath` を作成します。
7. `UserPath` への移動コマンドを追加します。
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。

この PHP コードは、Shape に `PathFootball`（パスフットボール）効果を適用する方法を示しています：
```php
  # PPTX ファイルを表す Presentation クラスをインスタンス化します。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 既存のシェイプに対して PathFootball 効果を最初から作成します。
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # PathFootBall アニメーション効果を追加します
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 何らかの「ボタン」を作成します。
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # このボタン用のエフェクトシークエンスを作成します。
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # カスタムユーザーパスを作成します。ボタンがクリックされた後にのみオブジェクトが移動します。
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # 作成したパスが空なので、移動コマンドを追加します。
    $motionBvh = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBvh->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Shape に適用されたアニメーション効果の取得**

以下の例は、[Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) クラスの `getEffectsByShape` メソッドを使用して、Shape に適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常スライド上の Shape に適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションの Shape にアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初の Shape に適用された効果を取得する方法を示します。
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # スライドのメインアニメーションシーケンスを取得します。
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # 最初のスライドの最初のシェイプを取得します。
    $shape = $firstSlide->getShapes()->get_Item(0);

    # シェイプに適用されたアニメーション効果を取得します。
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


**例 2: プレースホルダーから継承されたものを含むすべてのアニメーション効果の取得**

通常スライド上の Shape がレイアウトスライドやマスタースライド上のプレースホルダーを持ち、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にプレースホルダーから継承された効果も含めてすべての効果が再生されます。

たとえば、`sample.pptx` という PowerPoint ファイルに、フッター Shape に「Made with Aspose.Slides」というテキストがあり、**Random Bars** 効果が適用されているとします。

![スライド形状アニメーション効果](slide-shape-animation.png)

さらに、**Split** 効果がレイアウトスライド上のフッタープレースホルダーに適用されているとします。

![レイアウト形状アニメーション効果](layout-shape-animation.png)

最後に、**Fly In** 効果がマスタースライド上のフッタープレースホルダーに適用されているとします。

![マスター形状アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスの `getBasePlaceholder` メソッドを使用して Shape のプレースホルダーにアクセスし、レイアウトやマスタースライド上のプレースホルダーから継承されたものを含めてフッター Shape に適用されたアニメーション効果を取得する方法を示します。
```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// 通常スライド上のシェイプのアニメーション効果を取得します。
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// レイアウトスライド上のプレースホルダーのアニメーション効果を取得します。
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// マスタースライド上のプレースホルダーのアニメーション効果を取得します。
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```

```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```


出力:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // フライ, 下
Type: 134, subtype: 45            // スプリット, 垂直イン
Type: 126, subtype: 22            // ランダムバー, 水平
```


## **アニメーション効果のタイミングプロパティの変更**

Aspose.Slides for PHP via Java を使用すると、アニメーション効果のタイミングプロパティを変更できます。

![アニメーションタイミング ペイン](shape-animation.png)

以下は PowerPoint のタイミングと [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) プロパティとの対応関係です。

- PowerPoint タイミング **Start** ドロップダウン リストは [Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--) プロパティに対応します。
- PowerPoint タイミング **Duration** は [Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--) プロパティに対応します。アニメーションの長さ（秒）は、アニメーションが 1 サイクルを完了するのに要する総時間です。
- PowerPoint タイミング **Delay** は [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--) プロパティに対応します。

タイミングプロパティを変更する手順:

1. [Apply](#apply-animation-to-shape) もしくはアニメーション効果を取得します。
2. 必要な [Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--) プロパティに新しい値を設定します。
3. 変更した PPTX ファイルを保存します。

この PHP コードは操作例を示します:
```php
  # プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します。
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # スライドのメインシーケンスを取得します。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # メインシーケンスの最初のエフェクトを取得します。
    $effect = $sequence->get_Item(0);
    # エフェクトの TriggerType をクリック時開始に変更します
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # エフェクトの Duration を変更します
    $effect->getTiming()->setDuration(3.0);
    # エフェクトの TriggerDelayTime を変更します
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # PPTX ファイルをディスクに保存します
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **アニメーション効果サウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するために次のプロパティを提供します。

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) — サウンドを設定します。
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-) — 前のサウンドを停止するかどうかを設定します。

### **アニメーション効果サウンドの追加**

この PHP コードは、アニメーション効果サウンドを追加し、次の効果が開始されるときに停止する方法を示します：
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # プレゼンテーションの音声コレクションにオーディオを追加します
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # スライドのメインシーケンスを取得します。
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # メインシーケンスの最初のエフェクトを取得します
    $firstEffect = $sequence->get_Item(0);
    # エフェクトがサウンドなしか確認します
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # 最初のエフェクトにサウンドを追加します
      $firstEffect->setSound($effectSound);
    }
    # スライドの最初のインタラクティブシーケンスを取得します。
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # エフェクトの「前のサウンドを停止」フラグを設定します
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **アニメーション効果サウンドの抽出**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 主シーケンスのエフェクトを取得します。
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。

この PHP コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示します：
```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # スライドのメインシーケンスを取得します。
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # エフェクトのサウンドをバイト配列として抽出します
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **アフターアニメーション**

Aspose.Slides for PHP via Java を使用すると、アニメーション効果の After animation プロパティを変更できます。

![アフターアニメーション ペイン](shape-after-animation.png)

PowerPoint の **After animation** ドロップダウン リストは以下のプロパティに対応します。

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-) プロパティは After animation のタイプを指定します:
  * PowerPoint の **More Colors** は [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) に対応します。
  * PowerPoint の **Don't Dim** はデフォルトの [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) に対応します。
  * PowerPoint の **Hide After Animation** は [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) に対応します。
  * PowerPoint の **Hide on Next Mouse Click** は [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) に対応します。
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) プロパティは After animation のカラー形式を定義します。このプロパティは [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) と併用されます。タイプを別のものに変更すると、After animation のカラーはクリアされます。

この PHP コードは After animation 効果を変更する方法を示します：
```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # メインシーケンスの最初のエフェクトを取得します
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # After animation のタイプを Color に変更します
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # After animation のカラーを設定します
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストのアニメーション**

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するために次のプロパティを提供します。

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-) — 効果のテキストアニメーションタイプを指定します。テキストは次のいずれかでアニメーション化できます:
  - All at once ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) タイプ)
  - By word ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) タイプ)
  - By letter ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) タイプ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-) — アニメーション化されたテキスト部分（単語または文字）間の遅延を設定します。正の値は効果の期間のパーセンテージを示し、負の値は秒単位の遅延を示します。

テキストアニメーションプロパティを変更する手順:

1. [Apply](#apply-animation-to-shape) もしくはアニメーション効果を取得します。
2. `setBuildType(int value)` プロパティを [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) に設定し、*By Paragraphs* モードをオフにします。
3. [setAnimateTextType(int value)] と [setDelayBetweenTextParts(float value)] の新しい値を設定します。
4. 変更した PPTX ファイルを保存します。

この PHP コードは操作例を示します：
```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスのインスタンスを作成します。
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # メインシーケンスの最初のエフェクトを取得します
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # エフェクトのテキストアニメーションタイプを「As One Object」に変更します
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # エフェクトのアニメートテキストタイプを「By word」に変更します
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # 単語間の遅延をエフェクト期間の20%に設定します
    $firstEffect->setDelayBetweenTextParts(20.0);
    # PPTXファイルをディスクに書き込みます
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**プレゼンテーションを Web に公開する際にアニメーションを保持するにはどうすればよいですか？**

[Export to HTML5](/slides/ja/php-java/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) と [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/) アニメーションを有効にするオプションを設定します。プレーンな HTML はスライドアニメーションを再生しませんが、HTML5 は再生します。

**形状の Z オーダー（レイヤー順）を変更するとアニメーションにどのような影響がありますか？**

アニメーションと描画順序は独立しています。エフェクトは出現/消失のタイミングとタイプを制御し、[z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) は何が何を覆うかを決定します。最終的な表示は両者の組み合わせで決まります。（これは PowerPoint の一般的な動作であり、Aspose.Slides のエフェクトと形状のモデルも同様です。）

**特定の効果をビデオに変換する際に制限はありますか？**

一般的に[アニメーションはサポートされています](/slides/ja/php-java/convert-powerpoint-to-video/)、ただしまれに特定の効果が異なる形でレンダリングされる場合があります。使用する効果とライブラリのバージョンでテストすることを推奨します。