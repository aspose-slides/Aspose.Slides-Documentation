---
title: PHP を使用したプレゼンテーションへのシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/php-java/shape-animation/
keywords:
- シェイプ
- アニメーション
- 効果
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- 効果の追加
- 効果の取得
- 効果の抽出
- 効果サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、シェイプ アニメーション、タイミング、サウンド、アフターアニメーションの動作、アニメーション テキストの追加、検査、カスタマイズ方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、スライドアニメーションをスライドタイムライン上のエフェクトとして表現します。エフェクトには対象シェイプ、アニメーションの種類とサブタイプ、トリガー、タイミング設定、そしてサウンドやアフターアニメーション動作といったオプションプロパティがあります。

タイムラインには 2 種類のシーケンスがあります：

- **メインシーケンス** はスライドが進むと再生されます。
- **インタラクティブシーケンス** はトリガーシェイプがクリックされたときに開始します。

テキストボックス、画像、チャート、テーブル、その他のスライドオブジェクトはすべてシェイプであるため、ほとんどのスライドコンテンツには同じ[Sequence::addEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/addeffect/)メソッドを使用します。利用可能なエフェクトは[EffectType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effecttype/)クラスに一覧表示されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメインシーケンスを取得し、対象シェイプ、エフェクトタイプ、サブタイプ、トリガーを指定して[Sequence::addEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/addeffect/)を呼び出します。他のシェイプがクリックされたときに開始するエフェクトの場合、そのシェイプをトリガーとしたインタラクティブシーケンスを作成します。

以下の例は両方のタイプのアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

トリガーはエフェクトの開始時期を制御します：

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effecttriggertype/) はメインシーケンスでのクリック、またはインタラクティブシーケンスでトリガーシェイプのクリックを待ちます。
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effecttriggertype/) は前のエフェクトと同時に開始します。
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effecttriggertype/) は前のエフェクトが終了したときに開始します。

画像、チャート、その他のシェイプタイプをアニメーションさせるには、`$targetShape` の代わりにそのオブジェクトを[Sequence::addEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/addeffect/)に渡します。チャート固有のグループ化オプションについては[Animated Charts](/slides/ja/php-java/animated-charts/)をご覧ください。

## **シェイプ アニメーションの読み取り**

対象シェイプが分かっている場合は[Sequence::getEffectsByShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/geteffectsbyshape/)を使用します。すべてのエフェクトを確認するには、メインシーケンスとすべてのインタラクティブシーケンスを列挙します。列挙することでシーケンスがインデックス `0` にエフェクトを持つと仮定することを防げます。

以下の例はメインシーケンスとインタラクティブエフェクトを持つシェイプを作成し、シェイプを対象としたエフェクトを取得し、さらにスライド上のすべてのシーケンスを列挙します。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

1 つのシェイプに対するエフェクトだけが必要な場合は、まず名前、プレースホルダータイプ、または他の安定したプロパティでシェイプを特定し、次に[Sequence::getEffectsByShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/geteffectsbyshape/)を呼び出します。[ShapeCollection::get_Item](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/get_item/) のインデックス `0` が常に目的のオブジェクトであると仮定しないでください。

## **継承されたプレースホルダー エフェクトの操作**

通常のスライド上のプレースホルダーは、レイアウトスライドやマスタースライド上の対応するプレースホルダーからアニメーション動作を継承できます。[Shape::getBasePlaceholder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getbaseplaceholder/) はその親プレースホルダーを返し、親が存在しない場合は `null` を返します。

以下の例のプレゼンテーションでは、フッターは通常のスライドで**Random Bars**、レイアウトスライドで**Split**、マスタースライドで**Fly In** のアニメーションを持ちます。

![通常のスライド上のフッター アニメーション効果](slide-shape-animation.png)

![レイアウトスライド上のフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライド上のフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例は新しいプレゼンテーションからのプレースホルダー階層を使用します。マスタープレースホルダー、レイアウトプレースホルダー、および通常スライド上の対応するプレースホルダーにエフェクトを追加します。[Shape::getBasePlaceholder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getbaseplaceholder/) の呼び出しは、返されたシェイプが使用される前に必ずチェックされます。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **アニメーション タイミングの変更**

PowerPoint の**Timing** ダイアログは[Timing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/) のプロパティに対応しています。

![アニメーション効果の PowerPoint タイミング ダイアログ](shape-animation.png)

- **開始** は[Timing::getTriggerType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/gettriggertype/) に対応します。
- **期間** は[Timing::getDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getduration/) に対応し、秒単位です。
- **遅延** は[Timing::getTriggerDelayTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/gettriggerdelaytime/) に対応し、秒単位です。
- **繰り返し** は[Timing::getRepeatCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getrepeatuntilnextclick/), または[Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getrepeatuntilendslide/) に対応します。
- **再生完了後に巻き戻す** は[Timing::getRewind](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getrewind/) に対応します。

この独立した例はエフェクトを追加し、[Sequence::addEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/addeffect/) が返すオブジェクトを通じてそのタイミングを変更し、結果を保存します。返された[Effect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/) の参照を保持することで不要なコレクションインデックスを避けられます。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

意図的に 1 つのリピートモードのみを使用してください。リピート回数と「until」フラグを組み合わせると、ビューアーによって混乱する結果になることがあります。リピートモードを変更する際は、[Timing::setRepeatCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/setrepeatcount/) の前に[Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/setrepeatuntilnextclick/) と[Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/setrepeatuntilendslide/) を設定してください。これらのフラグの設定はアクティブなリピートモードも変更します。

## **アニメーションサウンドの追加と抽出**

アニメーションエフェクトは[Effect::getSound](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/getsound/) を使用して埋め込み音声を参照できます。[Effect::setStopPreviousSound](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/setstopprevioussound/) は、以前のエフェクトで開始された音声を停止するようエフェクトに指示します。

### **エフェクトにサウンドを追加**

以下の例は `animation-sound.wav` というローカル音声ファイルを前提とします。2 つのエフェクトを作成し、最初のエフェクトのサウンドとしてそのファイルを埋め込み、2 番目のエフェクトがサウンドを停止するよう構成します。[Sequence::addEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/addeffect/) が返すオブジェクトを使用するため、シーケンスインデックスは不要です。

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **埋め込みエフェクトサウンドの抽出**

以下の例は `presentation-with-animation-sounds.pptx` というローカルプレゼンテーションを前提とします。メインシーケンスとインタラクティブシーケンスの両方を走査し、埋め込まれたエフェクトサウンドをすべて `extracted-animation-sounds` ディレクトリに書き出します。拡張子は[Audio::getContentType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audio/getcontenttype/) が提供する音声 MIME タイプから選択されます。

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

大きな音声オブジェクトの場合は、[Audio::getStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/audio/getstream/) を使用し、全体をバイト配列に読み込むのではなくストリームをファイルにコピーしてください。

## **アフターアニメーション 動作の設定**

**After animation** オプションは、エフェクトが終了した後にシェイプに何が起こるかを制御します。

![After animation 設定を示す PowerPoint エフェクトオプション ダイアログ](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/afteranimationtype/) クラスは、シェイプを変更せずに保持する、色を変更する、アニメーション後に非表示にする、または次のクリックで非表示にする、という動作をサポートします。タイプが[AfterAnimationType::Color](https://reference.aspose.com/slides/ja/php-java/aspose.slides/afteranimationtype/) の場合は、[Effect::getAfterAnimationColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/getafteranimationcolor/) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクトオブジェクトを通じてアフターアニメーション動作を設定し、結果を保存します。

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[AfterAnimationType::Color](https://reference.aspose.com/slides/ja/php-java/aspose.slides/afteranimationtype/) 以外のタイプに変更すると、アフターアニメーションのカラー設定はクリアされます。

## **テキスト アニメーション**

テキストアニメーションには 2 つの関連する制御があります：

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textanimation/getbuildtype/) は段落がまとめて表示されるか段落レベルで表示されるかを制御します。
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/getanimatetexttype/) はテキストが一度に表示されるか、単語ごと、または文字ごとに表示されるかを制御します。[Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/getdelaybetweentextparts/) は単語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

以下の独立した例はテキストボックス内の単語をアニメーション化します。[BuildType::AsOneObject](https://reference.aspose.com/slides/ja/php-java/aspose.slides/buildtype/) は段落ごとのビルドを無効にし、単語設定がテキストフレーム全体に適用されるようにします。

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

段落単位でテキストボックスをビルドするには、[BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ja/php-java/aspose.slides/buildtype/)（または他の段落レベル）を設定します。単一の段落に固有のエフェクトを適用するには、[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) を受け取る[Sequence::addEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/addeffect/) のオーバーロードを使用してください。段落レベルの例については[Animated Text](/slides/ja/php-java/animated-text/)をご覧ください。

## **エクスポートと互換性に関する注意点**

- PPT または PPTX への保存はアニメーションモデルを保持しますが、最終的な再生はプレゼンテーションビューアーが制御します。
- PDF や静止画像はアニメーションを再生しません。出力に動きが必要な場合は[HTML5 export](/slides/ja/php-java/export-to-html5/)、アニメーション GIF、または[video conversion](/slides/ja/php-java/convert-powerpoint-to-video/) を使用してください。
- HTML5 用には[Html5Options::setAnimateShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/html5options/setanimateshapes/) を有効にし、必要に応じて[Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/html5options/setanimatetransitions/) を設定してください。
- ビデオレンダリングは多数の一般的な入場、強調、退出、モーションパスエフェクトをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の[supported animations and effects](/slides/ja/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、重要なプレゼンテーションを対象の Aspose.Slides バージョンでテストしてください。
- 高度なカスタムエフェクトや他のプレゼンテーション形式からインポートされたエフェクトはファイル内で保持される場合がありますが、PowerPoint、HTML5、またはビデオでのレンダリングが異なることがあります。エフェクト名のみで判断せず、エクスポート結果を検証してください。

## **よくある質問**

**なぜアニメーションは PowerPoint では表示されるが PDF では表示されないのですか？**

PDF は静的な形式であるため、アニメーションやスライド遷移は再生されません。動きを保持する必要がある場合は、HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**なぜエフェクトはビデオで異なる再生になるのですか？**

ビデオエクスポートはアニメーションをレンダリングし、元の PowerPoint の動作を保持しません。一部の高度なエフェクトはサポートされていないか、近似されています。サポートされているエフェクトの表を確認し、実際のプレゼンテーションを本番使用前にテストしてください。

**シェイプを前方または後方に移動するとアニメーションの順序が変わりますか？**

いいえ。シェイプの Z 順序は重なりを制御し、シーケンスの順序とトリガーがアニメーションの再生を制御します。再生順序を変更したい場合は、タイムラインを調整してください。