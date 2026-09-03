---
title: PHP を使用したプレゼンテーションのスライド遷移の管理
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/php-java/slide-transition/
keywords:
- スライド遷移
- スライド遷移の追加
- スライド遷移の適用
- 高度なスライド遷移
- Morph 遷移
- 遷移タイプ
- 遷移効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: Aspose.Slides for PHP via Java を使用して、スライド遷移を適用し、自動スライド進行を設定し、Morph やその他の遷移効果をカスタマイズします。
---
## **概要**

スライド遷移は、スライドショー中のスライドの表示方法を制御します。Aspose.Slides for PHP via Java を使用すると、各スライドに遷移効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果に固有のオプションを調整できます。本記事では PHP のサンプルを使って遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph 遷移を作成する方法を示します。サンプルは設定を PPTX ファイルに保存する方法も示しています。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[getSlideShowTransition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#getSlideShowTransition) でスライドの遷移設定にアクセスします。[setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setType) に [TransitionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitiontype/) 列挙体の値を指定し、プレゼンテーションを保存します。

以下の例は、最初のスライドに Circle 遷移、2 番目のスライドに Comb 遷移を適用します。スライドが 2 枚以上含まれる `input.pptx` ファイルを使用してください。

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

## **高度なスライド遷移の追加**

スライドが画面に留まる時間と、マウスクリックでスライドショーが進むかどうかを構成できます。以下のメソッドでこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) はマウスクリックで進めるかを指定します。
- [setAdvanceAfter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) は自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) は自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方を有効にすれば、クリックでもタイマーでも次に進められます。タイマーのみを使用する場合は [setAdvanceOnClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) に `false` を渡します。遅延はスライドショーが次に進むタイミングを制御しますが、視覚的遷移効果の継続時間を設定するものではありません。

この例は最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもスライドは進みます。スライドが少なくとも 3 枚ある `input.pptx` ファイルをご使用ください。

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

タイマー進行が有効か確認するには [getAdvanceAfter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) を呼び出します。遅延が保存されていても、タイマーがアクティブであることを意味するわけではありません。

次の例は上記で保存したファイルを開き、タイマーが 2 秒を超えているスライドの自動進行を無効にし、代わりにマウスクリックで進めるように変更し、設定を保存します。

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

## **遷移タイミングを正確に制御する**

[setDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setDuration) を使用して、遷移効果そのものの長さ（ミリ秒）を正確に指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#getSlideShowTransition) メソッドはこれらの設定を [SlideShowTransition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/) を通じて公開します。

| メソッド | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setDuration) | 遷移効果自体の継続時間をミリ秒単位で設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | スライドが自動的に進むまでの遅延時間をミリ秒単位で設定します。タイマーを有効にするには [setAdvanceAfter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) に `true` を渡します。 |
| [setSpeed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitionspeed/) 列挙体の Slow、Medium、Fast のいずれかで事前定義された速度カテゴリを選択します。正確な継続時間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setDuration) は遷移効果のみを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#getSpeed) の値から効果の継続時間を算出します。

### **すべてのスライドに同じ期間を適用する**

一貫したペースにするため、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の期間を設定します。自動進行は 5,000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして PPTX として保存します。

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

スライドごとに異なる効果期間を使用できます。たとえば、タイトルスライドには短い遷移、セクション導入スライドには長い遷移を設定します。この例は最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒を設定します。スライドが 2 枚以上ある `input.pptx` ファイルをご使用ください。

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

### **アニメーション出力と遷移を調整する**

[animated GIF](/slides/ja/php-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/ja/php-java/export-to-html5/)、または [video](/slides/ja/php-java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確な遷移期間を設定して意図したペースに合わせます。たとえばシーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF やビデオの場合は、フレームレートと効果期間を合わせます。600 ミリ秒は 30 fps で 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション遷移を有効にします。選択したエクスポート形式のサポート対象効果とタイミングオプションを確認し、プレビューで同期を確かめてください。

### **既存の遷移期間を読み取る**

遷移を変更する前に [getDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#getDuration) を呼び出して、明示的に保存された値があるか確認します。`-1` は明示的な期間が設定されていないことを示し、0 以上の数値はミリ秒単位の保存期間です。未設定の値は再生時間の計算結果ではありません。Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#getSpeed) の値から期間を算出します。遷移タイプを設定すると期間が初期化されることがあるため、まず元の設定を確認してください。

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

## **Morph遷移**

Morph 遷移は連続するスライド間のオブジェクトの変更をアニメーション化します。シンプルな Morph 効果を作成するには、スライドを複製し、複製上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph 遷移を適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションされます。

以下の例はテキスト矩形を含むスライドを作成し、スライドを複製して複製上の矩形の位置とサイズを変更します。次に、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitiontype/) 列挙体から Morph を選択します。Morph に対応したプレゼンテーションビューアで保存ファイルを開くと、スライドショー中に効果を確認できます。

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

## **Morph遷移タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitionmorphtype/) 列挙体は Morph がコンテンツをどのようにマッチさせてアニメーション化するかを制御します。

- [ByObject](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitionmorphtype/#ByObject) は各シェイプ全体をオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitionmorphtype/#ByWord) は可能な場合に単語単位でテキストをマッチさせてアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitionmorphtype/#ByChar) は可能な場合に文字単位でテキストをマッチさせてアニメーション化します。

[Morph] を選択するには [setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setType) を呼び出し、次に [getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#getValue) で取得した値から [MorphTransition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/morphtransition/) オブジェクトを取得し、[setMorphType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/morphtransition/#setMorphType) メソッドでマッチングモードを選択します。

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

## **遷移効果の設定**

一部の遷移は方向や黒画面から開始するかどうかなどの追加オプションを提供します。利用可能なオプションは [setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setType) で選択した遷移に依存します。まずタイプを設定し、その後 [getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#getValue) から取得した適切な遷移オブジェクトを使用します。

以下の例は `input.pptx` の最初のスライドに Cut 遷移を適用し、[OptionalBlackTransition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/optionalblacktransition/) の [setFromBlack](https://reference.aspose.com/slides/ja/php-java/aspose.slides/optionalblacktransition/#setFromBlack) を呼び出して遷移を黒画面から開始させます。

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

**スライド遷移の再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果時間が必要な場合は [setDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setDuration) を使用してください。事前定義された速度カテゴリ（Slow、Medium、Fast）で十分な場合は、[TransitionSpeed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitionspeed/) 列挙体を使用する [setSpeed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setSpeed) を使用します。これらの設定は自動進行遅延とは独立して遷移効果を制御します。

**遷移に音声を添付してループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setSound) で埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitionsoundmode/) 列挙体の StartSound を [setSoundMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setSoundMode) に渡し、[setSoundLoop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setSoundLoop) を `true` に設定します。音声はスライドショー内の次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSlides) コレクションをループし、各スライドの遷移に対して同じ値で [setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#setType) を呼び出します。タイミングや効果オプションも同じループ内で設定すれば、スライド全体で一貫した動作になります。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#getSlideShowTransition) の結果に対して [getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideshowtransition/#getType) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/transitiontype/) 列挙体の値で、None は遷移効果が設定されていないことを意味します。