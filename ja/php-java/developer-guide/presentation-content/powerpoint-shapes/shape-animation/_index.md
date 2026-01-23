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
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- エフェクトの追加
- エフェクトの取得
- エフェクトの抽出
- エフェクト サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションでシェイプ アニメーションを作成およびカスタマイズする方法を紹介します。目立ちましょう！"
---

アニメーションは、テキスト、画像、図形、または[charts](https://docs.aspose.com/slides/php-java/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

## **プレゼンテーションでアニメーションを使用する理由**

* 情報の流れを制御する  
* 重要なポイントを強調する  
* 聴衆の関心や参加意欲を高める  
* コンテンツを読みやすく、理解しやすく、処理しやすくする  
* 読者や視聴者の注意をプレゼンテーションの重要な部分へ導く  

PowerPoint は、**entrance**、**exit**、**emphasis**、**motion paths** の各カテゴリにわたるアニメーションとアニメーション効果のための多くのオプションとツールを提供します。

## **Aspose.Slides のアニメーション**

`Aspose.Slides.Animation` 名前空間の下で、アニメーションを扱うために必要なクラスと型を Aspose.Slides が提供します。

Aspose.Slides は、[EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype) 列挙体の下で **150** 以上のアニメーション効果を提供します。これらの効果は、実質的に PowerPoint で使用されるものと同じ（または同等）です。

## **テキストボックスへのアニメーション適用**

Aspose.Slides for PHP via Java を使用すると、図形内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライド参照を取得します。  
3. 矩形の [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。  
4. `AutoShape` の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) にテキストを追加します。  
5. メインのエフェクトシーケンスを取得します。  
6. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) にアニメーション効果を追加します。  
7. `TextAnimation.setBuildType` メソッドと `BuildType` 列挙体の値を使用します。  
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。  

この PHP コードは、`Fade` 効果を AutoShape に適用し、テキストアニメーションを *By 1st Level Paragraphs* に設定する方法を示しています:
```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # テキスト付きの新しい AutoShape を追加します
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # スライドのメイン シーケンスを取得します。
    $sequence = $sld->getTimeline()->getMainSequence();
    # シェイプに Fade アニメーション効果を追加します
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # シェイプのテキストを第1レベル段落単位でアニメーション化します
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
テキストへのアニメーション適用に加えて、単一の [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) にもアニメーションを適用できます。詳細は [**Animated Text**](/slides/ja/php-java/animated-text/) を参照してください。  
{{% /alert %}} 

## **PictureFrame へのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライド上に [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) を追加または取得します。  
4. メインのエフェクトシーケンスを取得します。  
5. [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe) にアニメーション効果を追加します。  
6. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。  

この PHP コードは、`Fly` 効果を画像フレームに適用する方法を示しています:
```php
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します。
  $pres = new Presentation();
  try {
    # プレゼンテーション の画像コレクションに追加する画像をロードします
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # スライドにピクチャーフレームを追加します
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # スライドのメインシーケンスを取得します。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # ピクチャーフレームに左から飛ぶアニメーション効果を追加します
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


## **シェイプへのアニメーション適用**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. 矩形の [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。  
4. ベベルの [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。  
5. ベベルシェイプに対してエフェクトシーケンスを作成します。  
6. カスタムの `UserPath` を作成します。  
7. `UserPath` への移動コマンドを追加します。  
8. プレゼンテーションを PPTX ファイルとしてディスクに書き込みます。  

この PHP コードは、`PathFootball`（パスフットボール）効果をシェイプに適用する方法を示しています:
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
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
    # このボタン用のエフェクトシーケンスを作成します。
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # カスタムのユーザーパスを作成します。オブジェクトはボタンがクリックされた後にのみ移動します。
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # 作成されたパスが空なので、移動コマンドを追加します。
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シェイプに適用されたアニメーション効果の取得**

以下の例では、[Sequence](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/) クラスの `getEffectsByShape` メソッドを使用して、シェイプに適用されたすべてのアニメーション効果を取得する方法を示します。

**例 1: 通常スライド上のシェイプに適用されたアニメーション効果の取得**

以前、PowerPoint プレゼンテーションのシェイプにアニメーション効果を追加する方法を学びました。以下のサンプルコードは、プレゼンテーション `AnimExample_out.pptx` の最初の通常スライド上の最初のシェイプに適用された効果を取得する方法を示します。
```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # スライドのメイン アニメーション シーケンスを取得します。
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # 最初のスライド上の最初のシェイプを取得します。
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

通常スライド上のシェイプに、レイアウトスライドやマスタースライド上にあるプレースホルダーがあり、これらのプレースホルダーにアニメーション効果が追加されている場合、スライドショー中にシェイプのすべての効果が再生されます。これにはプレースホルダーから継承された効果も含まれます。

PowerPoint プレゼンテーション ファイル `sample.pptx` があり、フッターシェイプにテキスト "Made with Aspose.Slides" が含まれ、**Random Bars** 効果がシェイプに適用されているとします。

![スライド シェイプ アニメーション効果](slide-shape-animation.png)

さらに、**layout** スライド上のフッタープレースホルダーに **Split** 効果が適用されているとします。

![レイアウト シェイプ アニメーション効果](layout-shape-animation.png)

最後に、**master** スライド上のフッタープレースホルダーに **Fly In** 効果が適用されているとします。

![マスタ シェイプ アニメーション効果](master-shape-animation.png)

以下のサンプルコードは、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスの `getBasePlaceholder` メソッドを使用してシェイプのプレースホルダーにアクセスし、レイアウトおよびマスタースライドにあるプレースホルダーから継承されたものを含む、フッターシェイプに適用されたアニメーション効果を取得する方法を示します。
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


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // フライ, 下
Type: 134, subtype: 45            // スプリット, 縦方向イン
Type: 126, subtype: 22            // ランダムバー, 水平
```


## **アニメーション効果のタイミング変更方法**

Aspose.Slides for PHP via Java を使用すると、アニメーション効果のタイミングプロパティを変更できます。

これは Microsoft PowerPoint のアニメーション タイミング ペインです:

![アニメーション タイミング ペイン](shape-animation.png)

以下は PowerPoint タイミングと [Effect Timing](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming) プロパティの対応関係です。

- PowerPoint のタイミング **Start** ドロップダウンリストは、[Timing::getTriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerType) メソッドに対応します。  
- PowerPoint のタイミング **Duration** は、[Timing::getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getDuration) メソッドに対応します。アニメーションの期間（秒）は、アニメーションが 1 サイクルを完了するのに要する合計時間です。  
- PowerPoint のタイミング **Delay** は、[Timing::getTriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/timing/#getTriggerDelayTime) メソッドに対応します。  

エフェクトのタイミングプロパティを変更する手順は次のとおりです。

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。  
2. [Effect::getTiming](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#getTiming) メソッドを使用して必要な新しい値を設定します。  
3. 変更された PPTX ファイルを保存します。  

この PHP コードは操作を示しています:
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # スライドのメイン シーケンスを取得します。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # メイン シーケンスの最初のエフェクトを取得します。
    $effect = $sequence->get_Item(0);
    # エフェクトの TriggerType をクリック開始に変更します。
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # エフェクトの Duration を変更します。
    $effect->getTiming()->setDuration(3.0);
    # エフェクトの TriggerDelayTime を変更します。
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # PPTX ファイルをディスクに保存します。
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **アニメーション効果のサウンド**

Aspose.Slides は、アニメーション効果のサウンドを操作するための以下のメソッドを提供します。

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **アニメーション効果サウンドの追加**

この PHP コードは、アニメーション効果サウンドを追加し、次の効果が開始するときに停止する方法を示しています:
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # プレゼンテーションのオーディオコレクションにオーディオを追加します
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
    # メインシーケンスの最初のエフェクトを取得します。
    $firstEffect = $sequence->get_Item(0);
    # エフェクトが「サウンドなし」かチェックします
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
3. メインのエフェクトシーケンスを取得します。  
4. 各アニメーション効果に埋め込まれた [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) を抽出します。  

この PHP コードは、アニメーション効果に埋め込まれたサウンドを抽出する方法を示しています:
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # スライドのメインシーケンスを取得します。
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # エフェクトのサウンドをバイト配列で抽出します。
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **アニメーション後**

Aspose.Slides for PHP via Java を使用すると、アニメーション効果の After animation プロパティを変更できます。

![アフターアニメーション ペイン](shape-after-animation.png)

PowerPoint のエフェクト **After animation** ドロップダウンリストは、以下のメソッドに対応します。

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationType) メソッドは、After animation のタイプを示します：
  * PowerPoint の **More Colors** は、[AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) タイプに対応します。  
  * PowerPoint の **Don't Dim** は、[AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim) タイプ（デフォルトの After animation タイプ）に対応します。  
  * PowerPoint の **Hide After Animation** は、[AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) タイプに対応します。  
  * PowerPoint の **Hide on Next Mouse Click** は、[AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) タイプに対応します。  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAfterAnimationColor) メソッドは、After animation のカラー形式を定義します。このメソッドは [AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color) タイプと連動して動作します。タイプを別のものに変更すると、After animation のカラーはクリアされます。

この PHP コードは、After animation 効果を変更する方法を示しています:
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # メインシーケンスの最初のエフェクトを取得します
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # After animation のタイプを Color に変更します
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # After animation の dim カラーを設定します
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

Aspose.Slides は、アニメーション効果の *Animate text* ブロックを操作するための以下のメソッドを提供します。

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) は、効果のテキストアニメーションタイプを示します。シェイプのテキストは次のようにアニメーション化できます：
  * 一括 ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce) タイプ)  
  * 単語単位 ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord) タイプ)  
  * 文字単位 ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter) タイプ)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts) は、アニメーション化されたテキストパーツ（単語または文字）間の遅延を設定します。正の値は効果期間のパーセンテージを、負の値は秒単位の遅延を示します。

エフェクトのテキストアニメーションプロパティを変更する手順は次のとおりです。

1. [Apply](#apply-animation-to-shape) またはアニメーション効果を取得します。  
2. [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/textanimation/#setBuildType) メソッドと [BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject) 値を使用して *By Paragraphs* アニメーションモードを無効にします。  
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setAnimateTextType) と [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setDelayBetweenTextParts) メソッドを使用して新しい値を設定します。  
4. 変更された PPTX ファイルを保存します。  

この PHP コードは操作を示しています:
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # メインシーケンスの最初のエフェクトを取得します
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # エフェクトのテキストアニメーションタイプを「As One Object」に変更します
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # エフェクトのアニメートテキストタイプを「By word」に変更します
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # 効果の期間の20%に相当する単語間の遅延を設定します
    $firstEffect->setDelayBetweenTextParts(20.0);
    # PPTX ファイルをディスクに書き込みます
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**プレゼンテーションをウェブに公開する際にアニメーションを保持するにはどうすればよいですか？**  
[Export to HTML5](/slides/ja/php-java/export-to-html5/) を使用し、[shape](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) と [transition](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/) アニメーションを担当する [options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) を有効にします。通常の HTML ではスライドアニメーションが再生されませんが、HTML5 では再生されます。

**シェイプの Z 順序（レイヤー順）を変更するとアニメーションにどのように影響しますか？**  
アニメーションと描画順序は独立しています。エフェクトは出現/消失のタイミングと種類を制御し、[z-order](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) はどのオブジェクトが他の上に重なるかを決定します。視覚的な結果は両者の組み合わせで決まります。（これは一般的な PowerPoint の動作であり、Aspose.Slides のエフェクトとシェイプのモデルも同じロジックに従います。）

**特定の効果をビデオに変換する際に制限はありますか？**  
一般的に、[animations are supported](/slides/ja/php-java/convert-powerpoint-to-video/) ですが、稀なケースや特定の効果は別の方式でレンダリングされる場合があります。使用する効果やライブラリのバージョンでテストすることを推奨します。