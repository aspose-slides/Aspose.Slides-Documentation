---
title: PHP を使用したプレゼンテーションのスライド トランジションの管理
linktitle: スライド トランジション
type: docs
weight: 80
url: /ja/php-java/slide-transition/
keywords:
- スライド トランジション
- スライド トランジションの追加
- スライド トランジションの適用
- 高度なスライド トランジション
- Morph トランジション
- トランジション タイプ
- トランジション 効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、スライド トランジションを適用し、自動スライド進行を構成し、Morph およびその他のトランジション効果をカスタマイズします。"
---
## **概要**

スライド トランジションは、スライド ショー中にスライドが表示される方法を制御します。Aspose.Slides for PHP via Java を使用すると、各スライドにトランジション効果を選択し、マウスクリックまたはタイマーによる進行を構成し、効果固有のオプションを調整できます。この記事では、PHP の例を使ってトランジションを適用し、正確なトランジション時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph トランジションを作成する方法を示します。例では設定を PPTX ファイルに保存する方法も示しています。

## **スライド トランジションの追加**

トランジションを適用するには、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) を通じてスライドのトランジション設定にアクセスします。[setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) に [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列挙体から値を渡して設定し、プレゼンテーションを保存します。

次の例では、最初のスライドに Circle トランジション、2 番目のスライドに Comb トランジションを適用しています。`input.pptx` ファイルは少なくとも 2 枚のスライドが必要です。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Wheel トランジション**

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) メソッドは、目的のスライドを表示する放射状セクターの数を制御します。[setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) で [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) から Wheel を選択し、[getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) で [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) 設定にアクセスします。

この例では、同一のスライド ペアを 2 つ作成します。各ペアは黒いスライドで始まり、金色の矩形で覆われたスライドで終わります。スライド 2 は 1 本のスポーク、スライド 4 は 8 本のスポークを使用します。どちらのトランジションも、[setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) で同じスロー速度に設定し、[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) で 8,000 ミリ秒の明示的な期間を設定しています。

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存したプレゼンテーションを PowerPoint で開き、スライド ショーを開始します。スライド 1 からスライド 2 に進むと、時計回りに 1 本のセクターがスイープします。その後スライド 3 からスライド 4 に進むと、8 本の放射状セクターが同時に矩形を表示します。

## **高度なスライド トランジションの追加**

スライドが画面に表示される時間と、マウスクリックでスライド ショーを進めるかどうかを構成できます。次のメソッドがこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) は、マウスクリックで進めることを許可します。
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) は、自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) は、自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方の進行を有効にすると、クリックで進めるか、タイマーが切れるのを待つか選べます。タイマーのみを使用する場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) に `false` を渡します。遅延はスライド ショーの進行タイミングを制御しますが、視覚的なトランジション効果の長さを設定するものではありません。

この例では、最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定しています。マウスクリックでもこれらのスライドは進められます。`input.pptx` は少なくとも 3 枚のスライドが必要です。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

タイマー進行が有効か確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) を呼び出します。遅延が保存されているだけではタイマーが有効であることを意味しません。

次の例では、前述のファイルを開き、各スライドで有効なタイマーを報告し、2 秒以上の遅延が設定されたスライドの自動進行を無効にします。そのスライドはクリックで進められるようにし、更新された設定を保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **トランジション タイミングの正確な制御**

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) を使用して、トランジション効果の正確な長さ（ミリ秒）を指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) メソッドは、[SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) を通じてこれらの設定を公開します。

| メソッド | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | トランジション効果そのものの継続時間をミリ秒で設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | スライドが自動的に進むまでの遅延時間をミリ秒で設定します。タイマーを有効にするには、[setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) に `true` を渡します。 |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) 列挙体の事前定義された速度（Slow、Medium、Fast）を選択します。正確な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) はトランジション効果のみを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides はトランジションの種類と [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) の値から効果時間を算出します。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*この例は各スライドに 750ms の Fade トランジションを設定し、別途 5,000ms の自動進行を有効にしています。トランジション時間は効果そのものを制御し、進行時間はスライドを離れるタイミングを制御します。これらのバーは実測タイムラインではなく、設定値を示す概略です。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同じ期間を適用する**

一定のペースを保つため、すべてのスライドに同じ効果と正確な期間を適用します。この例では `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) から Fade を選択し、各トランジションに 750 ミリ秒の期間を設定します。自動進行は 5,000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして、結果を PPTX として保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // 効果の期間とは別に自動進行を設定します。
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **スライドごとに異なる期間を設定する**

スライドごとに異なる効果期間を設定できます。たとえば、タイトル スライドには短いトランジション、セクション紹介スライドには長めのトランジションを使用します。この例では、最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒の期間を設定します。`input.pptx` は少なくとも 2 枚のスライドが必要です。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **アニメーション出力との連携**

[animated GIF](/slides/ja/php-java/convert-powerpoint-to-animated-gif/) や [HTML5 presentation](/slides/ja/php-java/export-to-html5/)、[video](/slides/ja/php-java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確なトランジション期間を設定して意図したペースに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延も個別に調整してナレーションやコンテンツの時間を確保します。

GIF やビデオの場合は、出力フレームレートと効果期間を合わせます。600 ミリ秒は 30fps で 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション トランジションを有効にします。使用するエクスポート形式がサポートする効果とタイミング オプションを確認し、同期が取れているかプレビューで確認してください。

### **既存のトランジション期間を取得する**

トランジションを変更する前に [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) を呼び出して、明示的な値が保存されているか確認します。`-1` は明示的な期間が設定されていないことを示し、0 以上の値はミリ秒単位で保存された期間です。この未設定の値は再生時間ではありません。Aspose.Slides はトランジションの種類と [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) の値から再生時間を算出します。トランジションの種類を設定すると期間が初期化されることがあるため、まず元の設定を調べてください。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph トランジション**

Morph トランジションは、連続するスライド間でオブジェクトの変更をアニメーション化します。簡単な Morph 効果を作成するには、スライドを複製し、複製上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph トランジションを適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションします。

以下の例では、テキスト矩形を含むスライドを作成し、スライドを複製して複製上の矩形の位置とサイズを変更します。その後、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーション ビューアで保存したファイルを開くと、スライド ショー中に効果を確認できます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph トランジションの種類**

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチングしてアニメーション化するかを制御します。

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) は各シェイプ全体を 1 つのオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) は可能な場合に単語単位でテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) は可能な場合に文字単位でテキストをアニメーション化します。

[setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) で Morph を選択し、[getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) にアクセスします。取得した値は [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) オブジェクトを提供し、[setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) メソッドでマッチングモードを選択できます。

この例は前節で作成したプレゼンテーションを開き、2 番目のスライドに単語ベースの Morph アニメーションを設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **トランジション効果の設定**

一部のトランジションは、方向や黒画面から開始するかどうかなどの追加オプションを提供します。利用できるオプションは、[setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) で選択したトランジションに依存します。まずタイプを設定し、次に [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) で取得できる適切なトランジション オブジェクトを使用します。

以下の例は、`input.pptx` の最初のスライドに Cut トランジションを適用し、[OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) の [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) を呼び出して、黒画面から開始するように設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**スライド トランジションの再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果時間が必要な場合は、[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）カテゴリで十分で、明示的な期間を設定しない場合は、[setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) を使用します。これらの設定は自動進行遅延とは独立してトランジション効果を制御します。

**トランジションにオーディオを添付し、ループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) で埋め込みオーディオを割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) 列挙体の `StartSound` を [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) に渡し、[setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) を `true` に設定します。オーディオはスライド ショーの次のサウンド イベントが発生するまでループします。

**すべてのスライドに同じトランジションを適用する最速の方法は？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) コレクションをループし、各スライドのトランジションに対して同じ値で [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で一貫した動作が得られます。

**現在のスライドに設定されているトランジションを確認する方法は？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) の結果に対して [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) 列挙体の値で、`None` はトランジション効果が適用されていないことを示します。