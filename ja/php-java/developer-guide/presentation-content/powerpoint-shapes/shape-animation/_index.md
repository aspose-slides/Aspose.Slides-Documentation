---
title: シェイプアニメーション
type: docs
weight: 60
url: /ja/php-java/shape-animation/
keywords: "PowerPointアニメーション, アニメーション効果, アニメーションの適用, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointアニメーションの適用"
---

アニメーションは、テキスト、画像、シェイプ、または[チャート](https://docs.aspose.com/slides/php-java/animated-charts/)に適用できる視覚効果です。プレゼンテーションやその構成要素に命を吹き込みます。

### **プレゼンテーションでアニメーションを使用する理由は？**

アニメーションを使用することで、あなたは

* 情報の流れをコントロールする
* 重要なポイントを強調する
* 聴衆の関心や参加を高める
* コンテンツを読みやすく、理解しやすく、処理しやすくする
* プレゼンテーション内の重要な部分に読者や視聴者の注意を引き付ける

PowerPointは、**入場**、**退出**、**強調**、および**動きのパス**カテゴリ全体で、アニメーションおよびアニメーション効果のための多くのオプションとツールを提供しています。

### **Aspose.Slidesのアニメーション**

* Aspose.Slidesは、`Aspose.Slides.Animation`名前空間の下でアニメーションを操作するために必要なクラスとタイプを提供します。
* Aspose.Slidesは、[EffectType](https://reference.aspose.com/slides/php-java/aspose.slides/effecttype)列挙の下で150以上のアニメーション効果を提供します。これらの効果は基本的にPowerPointで使用されているものと同じ（または同等の）効果です。

## **テキストボックスにアニメーションを適用する**

Aspose.Slides for PHP via Javaを使用すると、シェイプ内のテキストにアニメーションを適用できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)を追加します。
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#addTextFrame-java.lang.String-)にテキストを追加します。
5. メインの効果シーケンスを取得します。
6. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)にアニメーション効果を追加します。
7. `TextAnimation.BuildType`プロパティを`BuildType`列挙の値に設定します。
8. プレゼンテーションをPPTXファイルとしてディスクに書き込みます。

このPHPコードは、`Fade`効果をAutoShapeに適用し、テキストアニメーションを*By 1st Level Paragraphs*値に設定する方法を示しています：

```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # テキスト付きの新しいAutoShapeを追加します
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("最初の段落 \n次の段落 \n 第三の段落");
    # スライドのメインシーケンスを取得します。
    $sequence = $sld->getTimeline()->getMainSequence();
    # 形状にFadeアニメーション効果を追加します
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # 1stレベル段落による形状テキストのアニメーション
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # PPTXファイルをディスクに保存します
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

テキストへのアニメーションの適用に加えて、単一の[段落](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph)へのアニメーションの適用もできます。 [**アニメーションテキスト**](/slides/ja/php-java/animated-text/)を参照してください。

{{% /alert %}} 

## **PictureFrameにアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. スライドに[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe)を追加または取得します。
4. メインの効果シーケンスを取得します。
5. [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe)にアニメーション効果を追加します。
6. プレゼンテーションをPPTXファイルとしてディスクに書き込みます。

このPHPコードは、ピクチャーフレームに`Fly`効果を適用する方法を示しています：

```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
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
    # スライドにピクチャーフレームを追加します
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # スライドのメインシーケンスを取得します。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # ピクチャーフレームに左からのFlyアニメーション効果を追加します
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # PPTXファイルをディスクに保存します
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **シェイプにアニメーションを適用する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)を追加します。
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape)を追加します（このオブジェクトがクリックされるとアニメーションが再生されます）。
5. ビベル形状上に効果のシーケンスを作成します。
6. カスタム`UserPath`を作成します。
7. `UserPath`までの移動コマンドを追加します。
8. プレゼンテーションをPPTXファイルとしてディスクに書き込みます。

このPHPコードは、シェイプに`PathFootball`（パスフットボール）効果を適用する方法を示しています：

```php
  # PPTXファイルを表すプレゼンテーションクラスをインスタンス化します。
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # 既存の形状に対してPathFootball効果をゼロから作成します。
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("アニメーションテキストボックス");
    # PathFootBallアニメーション効果を追加します
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 何らかの「ボタン」を作成します。
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # このボタンのための効果のシーケンスを作成します。
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # カスタムユーザーパスを作成します。このオブジェクトは、ボタンがクリックされた後のみ移動します。
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # 作成したパスが空なので移動するコマンドを追加します。
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # PPTXファイルをディスクに保存します
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **シェイプに適用されたアニメーション効果を取得する**

単一のシェイプに適用されたすべてのアニメーション効果を調べることを決定する場合があります。

このPHPコードは、特定のシェイプに適用されているすべての効果を取得する方法を示しています：

```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
  $pres = new Presentation("AnimExample_out.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # スライドのメインシーケンスを取得します。
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # スライドの最初の形状を取得します。
    $shape = $firstSlide->getShapes()->get_Item(0);
    # 形状に適用されたすべてのアニメーション効果を取得します。
    $shapeEffects = $sequence->getEffectsByShape($shape);
    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("形状 " . $shape->getName() . " には " . $Array->getLength($shapeEffects) . " のアニメーション効果があります。");
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **アニメーション効果のタイミングプロパティを変更する**

Aspose.Slides for PHP via Javaを使用すると、アニメーション効果のタイミングプロパティを変更できます。

これはMicrosoft PowerPointのアニメーションタイミングペインです：

![example1_image](shape-animation.png)

これらはPowerPointのタイミングと[Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--)プロパティとの対応関係です：

- PowerPointタイミングの**開始**ドロップダウンリストは、[Effect.Timing.TriggerType](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerType--)プロパティと一致します。
- PowerPointタイミングの**継続時間**は、[Effect.Timing.Duration](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getDuration--)プロパティと一致します。アニメーションの持続時間（秒単位）は、アニメーションが1サイクルを完了するのにかかる合計時間です。
- PowerPointタイミングの**遅延**は、[Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/php-java/aspose.slides/ITiming#getTriggerDelayTime--)プロパティと一致します。

これがEffect Timingプロパティを変更する方法です：

1. [アニメーションを適用](#apply-animation-to-shape)またはアニメーション効果を取得します。
2. 必要な[Effect.Timing](https://reference.aspose.com/slides/php-java/aspose.slides/IEffect#getTiming--)プロパティに新しい値を設定します。
3. 修正されたPPTXファイルを保存します。

このPHPコードは、操作を示しています：

```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # スライドのメインシーケンスを取得します。
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # メインシーケンスの最初の効果を取得します。
    $effect = $sequence->get_Item(0);
    # 効果のTriggerTypeをクリックで開始するように変更します
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # 効果の継続時間を変更します
    $effect->getTiming()->setDuration(3.0);
    # 効果のTriggerDelayTimeを変更します
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # PPTXファイルをディスクに保存します
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **アニメーション効果の音**

Aspose.Slidesは、アニメーション効果のサウンドを操作するために次のプロパティを提供します：

- [setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **アニメーション効果の音を追加する**

このPHPコードは、アニメーション効果の音を追加し、次の効果が開始するときにそれを停止する方法を示しています：

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # プレゼンテーションの音声コレクションに音声を追加します
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
    # メインシーケンスの最初の効果を取得します
    $firstEffect = $sequence->get_Item(0);
    # 効果が「サウンドなし」をチェックします
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # 最初の効果にサウンドを追加します
      $firstEffect->setSound($effectSound);
    }
    # スライドの最初のインタラクティブシーケンスを取得します。
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # 効果「前の音を停止する」フラグを設定します
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # PPTXファイルをディスクに保存します
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **アニメーション効果の音を抽出する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. メインの効果シーケンスを取得します。 
4. 各アニメーション効果に埋め込まれている[setSound(IAudio value)](https://reference.aspose.com/slides/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)を抽出します。

このPHPコードは、アニメーション効果に埋め込まれている音を抽出する方法を示しています：

```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # スライドのメインシーケンスを取得します。
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # 効果音のバイト配列を抽出します
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **アニメーション後**

Aspose.Slides for PHP via Javaを使用すると、アニメーション効果のアフターアニメーションプロパティを変更できます。

これはMicrosoft PowerPointのアニメーション効果ペインと拡張メニューです：

![example1_image](shape-after-animation.png)

PowerPointの効果**アフターアニメーション**ドロップダウンリストは次のプロパティに一致します：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationType-int-)プロパティは、アフターアニメーションタイプを説明します：
  * PowerPointの**その他の色**は、[AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color)タイプに一致します。
  * PowerPointの**暗くしない**リスト項目は、デフォルトのアフターアニメーションタイプである[AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#DoNotDim)に一致します。
  * PowerPointの**アニメーション後に非表示**項目は、[AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation)タイプに一致します。
  * PowerPointの**次のマウスクリックで非表示**項目は、[AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick)タイプに一致します。
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-)プロパティは、アフターアニメーションカラー形式を定義します。このプロパティは、[AfterAnimationType::Color](https://reference.aspose.com/slides/php-java/aspose.slides/afteranimationtype/#Color)タイプと連携して動作します。タイプを別のものに変更すると、アフターアニメーションカラーはクリアされます。

このPHPコードは、アフターアニメーション効果を変更する方法を示しています：

```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # メインシーケンスの最初の効果を取得します
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # アフターアニメーションタイプをColorに変更します
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # アフターアニメーションの明るさを設定します
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTXファイルをディスクに保存します
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストをアニメートする**

Aspose.Slidesは、アニメーション効果の*テキストのアニメーション*ブロックを操作するために次のプロパティを提供します：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-)は、効果のアニメートテキストタイプを説明します。シェイプテキストは次のようにアニメートできます：
  - 一度にすべて ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#AllAtOnce)タイプ)
  - 単語ごとに ([AnimateTextType::ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByWord)タイプ)
  - 文字ごとに ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/php-java/aspose.slides/animatetexttype/#ByLetter)タイプ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-)は、アニメートテキスト部分（単語または文字）の間の遅延を設定します。正の値は効果持続時間の割合を指定します。負の値は秒単位の遅延を指定します。

これがEffect Animate textプロパティを変更する方法です：

1. [アニメーションを適用](#apply-animation-to-shape)またはアニメーション効果を取得します。
2. [setBuildType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/itextanimation/#setBuildType-int-)プロパティを[BuildType::AsOneObject](https://reference.aspose.com/slides/php-java/aspose.slides/buildtype/#AsOneObject)値に設定して、*段落ごと*のアニメーションモードをオフにします。
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setAnimateTextType-int-)および[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/ieffect/#setDelayBetweenTextParts-float-)プロパティに新しい値を設定します。
4. 修正されたPPTXファイルを保存します。

このPHPコードは、操作を示しています：

```php
  # プレゼンテーションファイルを表すプレゼンテーションクラスをインスタンス化します。
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # メインシーケンスの最初の効果を取得します
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # 効果のテキストアニメーションタイプを「1つのオブジェクト」として変更します
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # 効果のアニメートテキストタイプを「単語ごと」に変更します
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # 単語の間の遅延を効果の持続時間の20%に設定します
    $firstEffect->setDelayBetweenTextParts(20.0);
    # PPTXファイルをディスクに保存します
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```