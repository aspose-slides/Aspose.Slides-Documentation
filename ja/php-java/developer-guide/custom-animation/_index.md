---
title: PHPでカスタム アニメーション 動作を作成および変更する
linktitle: カスタム アニメーション
type: docs
weight: 151
url: /ja/php-java/custom-animation/
keywords:
- カスタム アニメーション
- アニメーション 動作
- モーション パス
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint プレゼンテーション内のカスタム アニメーション 動作および編集可能なモーション パスを作成、検査、変更します。"
---
## **概要**

カスタム アニメーション 動作を使用すると、色の変更、形状の回転、編集可能なモーション パスに従うなど、アニメーション効果内の個々の操作を制御できます。このガイドでは、動作の作成と組み合わせ、タイミングの設定、既存のアニメーションの検査と変更、そしてプロパティがプレゼンテーションの保存と再読み込み後も保持されることを確認する方法を示します。

事前定義された効果やクリック トリガーについては、[シェイプ アニメーション](/slides/ja/php-java/shape-animation/) を参照してください。

## **アニメーション モデルの理解**

アニメーションは **Timeline → Sequence → Effect → Behaviors** の階層で構成されます。

- 各スライドには、メイン シーケンスとインタラクティブ シーケンスを含むタイムラインがあります。
- [Sequence](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/) は、異なる形状を対象にできる効果を保持します。
- [Effect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/) は、対象形状、プリセット、サブタイプ、効果のタイミングを識別します。
- [Effect::getBehaviors](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/getbehaviors/) が返すコレクションには、色の変更、移動、回転、プロパティ設定など、効果を実装する操作が含まれます。

## **個別の動作の作成**

[Sequence::addEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/sequence/addeffect/) を呼び出して効果を作成し、[getBehaviors](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/getbehaviors/) コレクションにアクセスします。プリセットを使用するとこのコレクションが自動的に構成されます。プリセットを拡張する場合はその操作を保持し、意図的に置き換える場合は [clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorcollection/clear/) を使用します。

[BehaviorFactory](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/) は、以下に示す 8 種類の動作を作成します。モーションに関しては [Build a Motion Path](#build-a-motion-path) を参照してください。各スニペットにはインポート文が含まれ、PHP/Java Bridge と Aspose.Slides PHP ライブラリがロードされていることを前提としています。後続の編集例では使用する出力ファイルを明記します。

### **回転**

[createRotationEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createrotationeffect/) で回転効果を作成します。[getBy](https://reference.aspose.com/slides/ja/php-java/aspose.slides/rotationeffect/getby/) で相対角度（度）を指定し、[getFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/rotationeffect/getfrom/) と [getTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/rotationeffect/getto/) で開始点と終了点を指定します。

この例は Spin 効果で開始し、プリセットの操作を 1 つの回転動作に置き換え、2 秒間の期間を設定します。90 度の相対角度は、形状の開始向きからの 1/4 回転を表すため、明示的な開始角度は不要です。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` には 1 つの形状と 1 つの回転動作が含まれます。以下のコレクション、タイミング、回転編集例はこのファイルを使用します。

### **拡大縮小**

[createScaleEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createscaleeffect/) を X/Y のパーセンテージで使用します。[getFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/scaleeffect/getfrom/) と [getTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/scaleeffect/getto/) が開始サイズと終了サイズを示し、[getBy](https://reference.aspose.com/slides/ja/php-java/aspose.slides/scaleeffect/getby/) が相対変化を示します。ここで 100 は元のサイズを意味します。

例では、2 秒間で両方の次元を 100% から 125% に拡大します。水平・垂直のパーセンテージを同じにすると形状の比率が保たれ、異なるパーセンテージにすると一方が伸びます。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **色**

[createColorEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createcoloreffect/) で塗りの色を青からオレンジに変更します。[getFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/coloreffect/getfrom/) と [getTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/coloreffect/getto/) が色、[getBy](https://reference.aspose.com/slides/ja/php-java/aspose.slides/coloreffect/getby/) が色オフセットです。動作の [BehaviorPropertyCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorpropertycollection/) がアニメーション対象の属性を識別します。

形状の単色塗りは青で初期化され、アニメーションの開始色と一致します。塗り色属性を選択することで、動作が変更すべき形状の部分が決まります。保存された効果は 2 秒間でオレンジへ遷移することを示しています。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **フィルター**

[createFilterEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createfiltereffect/) でワイプを選択します。[getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filtereffect/gettype/)、[getSubtype](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filtereffect/getsubtype/)、[getReveal](https://reference.aspose.com/slides/ja/php-java/aspose.slides/filtereffect/getreveal/) がフィルター、方向、表示/非表示を指定します。

この例は、右方向サブタイプで形状を表示する 2 秒間のワイプを構成します。フィルター設定は効果内部の動作に属するため、プリセットの元の操作を削除した後に設定します。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **プロパティ**

[createPropertyEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) で不透明度をアニメーション化します。[getFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/propertyeffect/getfrom/)、[getTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/propertyeffect/getto/)、[getBy](https://reference.aspose.com/slides/ja/php-java/aspose.slides/propertyeffect/getby/) は文字列で、[getValueType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/propertyeffect/getvaluetype/) と [getCalcMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/propertyeffect/getcalcmode/) によって解釈されます。3 つすべてを無差別に設定するのではなく、エンドポイントまたは相対オフセットを選択してください。

ここでは属性として不透明度を選び、数値文字列は 25% の不透明度からフル不透明度への変化を表します。線形補間により徐々に変化します。他の属性に適用する場合は、属性に適した値タイプとエンドポイント値を選びます。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **設定**

[createSetEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createseteffect/) を使用して、[getTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/seteffect/getto/) により可視性を割り当てます。設定動作はエンドポイント間を補間しません。

この例では可視性属性を選択し、動作実行時に文字列 `visible` を割り当てます。最小プレゼンテーションでは矩形は既に表示されているため、単体では目に見える変化は生じないことがあります。これは、形状の表示/非表示を制御する他の動作と組み合わせる際に有用です。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **コマンド**

[createCommandEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createcommandeffect/) を使用し、[getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/commandeffect/gettype/)、[getCommandString](https://reference.aspose.com/slides/ja/php-java/aspose.slides/commandeffect/getcommandstring/)、[getShapeTarget](https://reference.aspose.com/slides/ja/php-java/aspose.slides/commandeffect/getshapetarget/) を構成します。作業ディレクトリに `sample.wav` という WAV 録音ファイルを配置してください。この例では [addAudioFrameEmbedded](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addaudioframeembedded/) で埋め込み、再生コマンドを音声フレームに付加します。

音声フレームは効果の対象でもあり、コマンドの対象でもあります。これにより埋め込み録音への再生要求が結び付けられ、コマンド文字列単体ではどのメディアオブジェクトを制御するかは特定できません。効果はスライドショー中のクリックで開始するよう設定されています。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

保存後は `command.pptx` にコマンドが格納されますが、録音は再生されません。再生には、コマンドとそのメディア対象をサポートするスライドショー プレイヤーが必要です。

## **動作コレクションの管理**

[BehaviorCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorcollection/) は [add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorcollection/add/)、[insert](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorcollection/insert/)、[remove](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorcollection/remove/)、[removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorcollection/removeat/) をサポートします。この例では `rotation.pptx` を開き、拡大縮小を追加し、回転の前に挿入し、回転を削除します。同一オブジェクトの削除と再挿入はコピーを作成せずに位置を変更します。

編集シーケンスによりコレクションは「回転‑拡大縮小」→「拡大縮小‑回転」→「拡大縮小」の順に変化します。インデックスは現在のコレクションを基準とするため、再配置後の回転の新しいインデックスで削除が行われます。最終的な列挙で保存される動作が確認できます。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

出力は `ScaleEffect` だけで、拡大縮小のみが残ります。コレクションの順序だけで動作が順に実行されるわけではありません。すべての操作を置き換える場合にのみコレクションをクリアしてください。

## **動作タイミングの設定**

動作には [Timing](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/) があり、[Effect::getTiming](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/gettiming/) が返すタイミングとは独立しています。Effect のタイミングは効果全体をスケジュールし、動作のタイミングはその内部の操作を記述します。

### **期間、遅延、繰り返し、加速の設定**

`rotation.pptx` を開き、[getDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getduration/) で期間、[getTriggerDelayTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/gettriggerdelaytime/) でトリガー遅延（秒）を設定し、[setRepeatCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/setrepeatcount/) で繰り返し回数を構成します。[getAccelerate](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getaccelerate/) と [getDecelerate](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getdecelerate/) は期間の分数で、合計が 1 を超えないようにします。

入力ファイルは回転例で作成したものです。最初の動作が回転であることが分かっている前提で、ここではその動作のタイミングのみを変更し、90 度の角度はそのまま残します。角度とタイミングを分離して保持することで、アニメーションを再構築せずに速度調整が容易になります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この動作は 2 秒間の期間、0.5 秒の遅延、繰り返し回数 3 を使用し、期間の最初と最後の 20% が加速と減速に充てられます。

他の繰り返しポリシーとしては [getRepeatDuration](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getrepeatduration/)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getrepeatuntilendslide/)、[getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getrepeatuntilnextclick/) があります。すべてを同時に有効にせず、目的に応じて選択してください。[getAutoReverse](https://reference.aspose.com/slides/ja/php-java/aspose.slides/timing/getautoreverse/) は前方向の再生後に逆再生します。加速・減速は連続的な変化に適用され、離散的な代入やコマンドには適用されません。

## **モーション パスの作成**

[createMotionEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorfactory/createmotioneffect/) でモーションを作成します。[getFrom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioneffect/getfrom/)、[getTo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioneffect/getto/)、[getBy](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioneffect/getby/) はパーセンテージベースの座標またはオフセットを示します。編集可能なルートを作成するには [MotionPath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motionpath/) を作成し、[MotionEffect::setPath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioneffect/setpath/) で割り当てます。[MotionPath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motionpath/) はパスコマンドを格納します。

[MotionCommandPathType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioncommandpathtype/) で操作を選択します。

| コマンド | ポイント数 | 意味 |
| --- | --- | --- |
| MoveTo | 1 | 開始位置を設定します。 |
| LineTo | 1 | 直線セグメントの終点まで移動します。 |
| CurveTo | 3 | 2 つの制御点と終点で定義される三次ベジェ曲線に従います。 |
| CloseLoop | 0 | 開始位置に戻ります。 |
| End | 0 | パスを終了します。 |

[MotionPathPointsType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motionpathpointstype/) はコーナー点やスムーズ点など、点の編集特性を示します。コマンドタイプの代替にはなりません。下の曲線例では曲線点タイプ、直線セグメントではコーナー点タイプを使用してください。

パス座標はスライドのサイズに正規化されます。X の 0.25 はスライド幅の 1/4 を表し、0.25 ポイントではありません。Y は下方向が正です。絶対コマンドはパス座標系で位置を指定し、相対コマンドは現在位置からのオフセットを指定します。これは [getOrigin](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioneffect/getorigin/)（パスの参照フレーム）や [getPathEditMode](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioneffect/getpatheditmode/)（形状移動時のパスの動き）とは別です。

### **直線パスの作成**

開始点、1 本の直線セグメント、終了コマンドからなるモーション動作を作成します。[MotionPath::add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motionpath/add/) はコマンドタイプ、点の配列、点タイプ、相対座標フラグを受け取ります。

開始コマンドで (0, 0) を設定し、直線は (0.25, 0) で終了します。これによりスライド幅の 1/4 の水平変位が得られます。終了コマンドには座標点はありません。パスを割り当てたら、モーション動作を効果に追加して矩形に結び付けます。

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` には 3 つのパスコマンドを持つ 1 つのモーション動作が含まれます。以下のファイル編集例はこの構造を前提とします。

### **絶対座標と相対座標の比較**

この 2 つのパスオブジェクトは同じルートを表します。絶対コマンドは (0.3, 0.1) で終了し、相対コマンドは現在位置に (0.1, 0.1) を加算して (0.2, 0) にします。

両パスは同じ開始位置です。相対直線の場合は X と Y のオフセットを現在位置に加えて終点を求め、絶対直線の場合は終点を直接読み取ります。フラグだけを切り替えて座標変換を行わないと、異なるルートになります。

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

いずれかのパスをモーション動作に割り当ててプレゼンテーションで使用できます。最後のブール引数はそのコマンドが相対座標かどうかを選択します。

### **直線を曲線に置き換える**

`motion.pptx` を開き、直線コマンドを三次ベジェ曲線に置き換えます。最初に 2 つの制御点、その後に終点を指定します。

開始位置は前のコマンドで供給されます。最初の 2 点が曲線を形作り、3 番目が終点です。コマンドタイプ、点編集タイプ、点配列を同時に更新することで、セグメントが新しいジオメトリに一致します。

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`curve.pptx` のパスは依然として 3 つのコマンドを持ちますが、中央のコマンドが曲線になっています。

## **保存されたパスの検査と編集**

各 [MotionCmdPath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioncmdpath/) は [getPoints](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioncmdpath/getpoints/)、[getCommandType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioncmdpath/getcommandtype/)、[getPointsType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioncmdpath/getpointstype/)、[isRelative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motioncmdpath/isrelative/) を公開します。以下の例は `motion.pptx` の既知の 3 コマンドパスを使用します。任意の入力の場合は、対象効果を特定し、インデックスで編集する前にコマンドタイプと点数を確認してください。

### **コマンドと座標の読み取り**

パスを変更せずに読み取ります。終了および閉ループコマンドには点が不要なため、null の点配列を許容します。

出力は各数値コマンドタイプと相対座標フラグをペアで示し、その後に点を列挙します。これにより、パスを変更する前にエンドポイントとオフセットを区別できます。曲線は 3 点を列挙し、このファイルの直線は 1 点だけです。

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

一覧には開始点、(0.25, 0) で終了する絶対直線、そして終了コマンドが含まれます。

### **エンドポイントの変更**

`motion.pptx` を開き、直線の点配列を置き換えてエンドポイントを移動します。

入力ファイルではインデックス 0 が開始コマンド、インデックス 1 が直線です。直線の単一点を置き換えることで、コマンドタイプ、タイミング、コレクション内の位置は変わらずに目的地だけが変更されます。コマンドが絶対座標を使用しているため、新しいペアはオフセットではなく位置を指定します。

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion-endpoint.pptx` の直線は (0.4, 0.1) で終了し、元のファイルは変更されません。

### **セグメントの置き換え**

[insert](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motionpath/insert/) と [removeAt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/motionpath/removeat/) を使用して `motion.pptx` の直線を置き換えます。挿入により古い直線はインデックス 2 にシフトします。

これは既存座標を編集するのではなく、コマンドオブジェクト自体を置き換える例です。挿入後、コレクションは一時的に開始コマンド、新しい直線、古い直線、終了コマンドの順になります。インデックス 2 を削除すると古い直線が除去され、新しいルートが残ります。

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存されたパスは依然として 3 つのコマンドを持ち、新しい直線は (0.2, 0.1) で終了し、最後に終了コマンドがあります。

## **既存動作の変更と検証**

動作のインデックスが不明な場合はタイプで選択します。この例は `rotation.pptx` を開き、[RotationEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/rotationeffect/) を見つけて角度を変更し、再度開いたときに保存された値をチェックします。

タイプチェックにより、回転でない動作はループでスキップされます。2 回目のロードでは保存されたファイルを別のプレゼンテーションオブジェクトに読み込み、メモリ上の値ではなく永続化されたデータを比較します。この例は効果がメインシーケンスの最初にあることを前提としています。任意のプレゼンテーションで正しく動作させるには、タイプで動作を選択するパターンを他の動作にも適用してください。完全な保存チェックには、対象形状、効果、動作タイプと順序、タイミング、パスコマンドを比較します。浮動小数点値には数値許容誤差を使用してください。アニメーション構成が不明なプレゼンテーションについては、[シェイプ アニメーションの読み取り](/slides/ja/php-java/shape-animation/#read-shape-animations) を参照してメインおよびインタラクティブ シーケンスを走査してください。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

出力は `Rotation preserved: true` です。同様のタイプチェックパターンを他の動作にも適用してください。

## **動作の順序、プリセット、再生**

[BehaviorCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behaviorcollection/) の順序は効果の操作が保存される順序です。これは自動的に前の動作を待つプレイリストではありません。タイミングと囲む効果がスケジューリングを決定します。動作は重複可能で、同一プロパティへの操作は [additive](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behavioradditivetype/) や [accumulation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/behavioraccumulatetype/) 設定によって相互作用します。コレクションの並び替えだけで「移動 → 回転」をスケジュールしようとしないでください。明示的なタイミングまたは別々の効果を使用してください（[シェイプ アニメーション](/slides/ja/php-java/shape-animation/) 参照）。

効果の [getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/gettype/) と [getSubtype](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effect/getsubtype/) はプリセットを示しますが、編集された動作ツリー全体を表すわけではありません。動作をカスタマイズする前にプリセットとサブタイプを選択してください。プリセットを変更するとコレクションが再構築され、カスタム操作が失われる可能性があります。たとえば、カスタマイズした Spin 効果を Fade に変更すると、回転動作が設定やフィルター動作に置き換えられます。プリセットやサブタイプを変更した後は必ずコレクションを再確認してください。プリセットの動作をクリアすると、プリセットが必要とする可視化や初期化操作も削除されることがあります。例では意図的に可視形状を使用し、動作を置き換えているため、すべてのプリセット実装を再構築してはいません。

## **形式互換性**

保存された動作ツリーがすべてのビューアやエクスポートレンダラで同一の再生を保証するわけではありません。保存データとレンダリング結果を別々に確認してください。

| 形式または出力 | 確認項目 |
| --- | --- |
| PPTX | これらの例の主な形式として使用します。再読み込みして編集可能な動作ツリーを確認し、対象の PowerPoint バージョンで再生をチェックしてください。 |
| PPT | レガシー バイナリ形式は PPTX と異なる場合があります。別途保存‑再読み込みサイクルと再生をテストし、PPTX の成功だけですべてのカスタム組み合わせがサポートされていると判断しないでください。 |
| PDF、PNG、JPEG などの静的スライド画像 | 静的なスライド表現であり、再生可能な動作タイムラインや最終フレームの保証はありません。 |
| [HTML5](/slides/ja/php-java/export-to-html5/) | エクスポートオプションでシェイプ アニメーションを有効にすれば、サポートされたアニメーションを再生できます。ブラウザでカスタム組み合わせをテストしてください。 |
| [Animated GIF](/slides/ja/php-java/convert-powerpoint-to-animated-gif/) | レンダリングされたフレームを保存しますが、編集可能な動作やクリック トリガーは含まれません。実際の動きを確認してください。 |
| [Video](/slides/ja/php-java/convert-powerpoint-to-video/) | アニメーションフレームをレンダリングし、ビデオとしてエンコードします。サポートはレンダラの [supported animations and effects](/slides/ja/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) に限定され、コマンドやインタラクティブ イベントは編集可能なタイムラインにはなりません。 |

## **FAQ**

**なぜ効果に動作が何も追加していないのに含まれているのですか？**

事前定義された効果を作成すると、基礎となる操作が自動的に生成されることがあります。拡張するか置き換えるかを判断する前に、これらを検査してください。

**動作を先頭に移動すれば最初に再生されますか？**

必ずしもそうとは限りません。コレクションの順序はタイミングの代替になりません。遅延、期間、同一プロパティへの操作間の相互作用を確認してください。

**終了コマンドに点がないのはなぜですか？**

終了コマンドはパスの終端を示すだけで座標は不要です。ファイルからパスを読み取る際は、点配列が null であることを確認してください。

**ラウンドトリップが成功すれば再生も保証されますか？**

いいえ。再読み込みはプロパティの保存確認に過ぎません。スライドショー プレイヤーやアニメーション エクスポートで実際の再生を別途テストしてください。