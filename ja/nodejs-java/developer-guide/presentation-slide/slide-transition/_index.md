---
title: JavaScript を使用したプレゼンテーションのスライド遷移の管理
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用してスライド遷移を適用し、自動スライド進行を構成し、Morph やその他の遷移効果をカスタマイズします。"
---
## **概要**

スライド遷移は、スライドショー中のスライドの表示方法を制御します。Aspose.Slides for Node.js via Java を使用すると、各スライドに遷移効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。本記事では、JavaScript の例を使用して遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph 遷移を作成する方法を示します。また、設定を PPTX ファイルに保存する方法も示しています。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) でスライドの遷移設定にアクセスします。[setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) に [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 列挙体の値を指定し、プレゼンテーションを保存してください。

次の例は、最初のスライドに Circle 遷移を、2 番目のスライドに Comb 遷移を適用します。少なくとも 2 枚のスライドがある `input.pptx` ファイルを使用してください。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **ホイール遷移**

[WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) の [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) メソッドは、目的スライドを表示する放射状セクターの数を制御します。まず [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) から Wheel を選択し、[setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) でスライドの遷移タイプを設定した後、[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) を [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) として取得します。

この例は、黒いスライドと金色の矩形が描かれたスライドの 2 組を作成します。目的スライドはそれぞれ 1 と 8 のスポーク数を使用し、[setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) で同じ速度を設定し、[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) で 8,000 ミリ秒の明示的な期間を設定して差違が観察しやすくしています。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint で出力プレゼンテーションを開き、スライドショーを実行します。スライド 1 から 2、次にスライド 3 から 4 に進めます。PowerPoint 再生では、スポーク数 1 の場合は時計回りに 1 回の掃き出しでスライドが表示され、スポーク数 8 の場合は 8 本の放射状セクターが同時に表示されます。目的スライドの内容と遷移タイミングは同一なので、違いは表示セクターの数だけです。

## **Reveal 遷移で黒を経由したフェード**

目的スライドの遷移タイプを Reveal に設定し、[setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) をその [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/) 設定に対して呼び出します。この例は、ティールの元スライドとコーラルの目的スライドを作成し、両方をクローンします。各ペアは同じ 2 秒の Reveal 遷移を使用し、2 番目のペアだけが黒を通すフェードになります。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存したプレゼンテーションを PowerPoint で開き、スライドショーを開始します。スライド 1 から 2 に進めると、ティールがコーラルに直接フェードします。続いてスライド 3 から 4 に進めると、画面が一瞬ほぼ黒くなってからコーラルスライドが表示されます。両スライドとも元の背景色は保持されます。

以下の行は PowerPoint のフレームを 0.5 秒間隔で示しています。各行の中央フレームを比較して効果を確認してください。

![黒を通すフェードが無効（上）および有効（下）になっている PowerPoint 再生。下の行だけがほぼ黒を通過します。](reveal-through-black.png)

## **高度なスライド遷移の追加**

スライドが画面に表示され続ける時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のメソッドがこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) は、ビューアがマウスクリックで進むことを許可します。
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) は自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) は自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方の進行を有効にすると、ビューアはクリックでもタイマーでも次へ進めます。タイマーだけを使用したい場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) に `false` を渡してください。遅延はスライドショーが進むタイミングを制御しますが、視覚的遷移効果の期間を設定するものではありません。

この例は最初の 3 スライドに異なる効果を割り当て、3、5、7 秒後に自動進行するように設定します。マウスクリックでもこれらのスライドは進められます。少なくとも 3 枚のスライドがある `input.pptx` ファイルを使用してください。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

タイマー進行が有効か確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) を呼び出します。保存された遅延だけではタイマーがアクティブかどうかは判断できません。

次の例は上記で保存したファイルを開き、各スライドのタイマーが有効かレポートし、遅延が 2 秒を超えるスライドの自動進行を無効にします。そのスライドのマウスクリックは有効にし、更新された設定を保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **遷移タイミングを正確に制御する**

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) を使用して、遷移効果自体の正確な長さ（ミリ秒）を指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) メソッドは、これらの設定を [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) を通じて公開します。

| メソッド | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | 遷移効果そのものの期間をミリ秒単位で設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | スライドが自動的に進むまでの遅延時間をミリ秒単位で設定します。タイマーを有効化するには [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) に `true` を渡します。 |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) 列挙体の Slow、Medium、Fast から事前定義された速度カテゴリを選択します。正確な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) は遷移効果そのもののみを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) の値から効果の期間を算出します。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*共有された例では、各スライドに 750 ミリ秒の Fade 遷移を与え、別途自動進行を 5,000 ミリ秒で有効にしています。遷移期間は効果を制御し、進行はスライドを離れるタイミングを制御します。これらのバーは測定されたタイムラインではなく、設定を示す模式図です。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同じ期間を適用する**

一貫したペースを保つため、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の期間を設定します。また、5,000 ミリ秒後に自動進行を有効にし、マウスクリックによる進行は無効にして、結果を PPTX として保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // 効果の期間とは独立して自動進行を構成します。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **個々のスライドに異なる期間を設定する**

スライドごとに異なる効果期間を使用できます。たとえば、タイトルスライドには短い遷移、セクションイントロには長い遷移を使用します。この例は最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒を設定します。少なくとも 2 枚のスライドがある `input.pptx` ファイルを使用してください。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **アニメーション出力と遷移を調整する**

[animated GIF](/slides/ja/nodejs-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/ja/nodejs-java/export-to-html5/)、または [video](/slides/ja/nodejs-java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確な遷移期間を設定して意図したタイミングに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延も個別に調整してナレーションやコンテンツの時間を確保します。

GIF と動画の場合、フレームレートと効果期間を合わせます。600 ミリ秒は 30 フレーム/秒で 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション遷移を有効にします。選択したエクスポート形式がサポートする効果とタイミングオプションを確認し、出力をプレビューして同期を確認してください。

### **既存の遷移期間を取得する**

遷移を変更する前に [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) を呼び出して、明示的な値が保存されているか確認します。`-1` は明示的な期間が設定されていないことを示し、0 以上の値はミリ秒単位で保存された期間を示します。未設定の値は再生時に計算された期間ではなく、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) の値から期間を算出します。遷移タイプを設定すると期間が初期化されることがあるため、まず元の設定を調査してください。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph 遷移**

Morph 遷移は、連続するスライド間のオブジェクトの変更をアニメーション化します。シンプルな Morph 効果を作成するには、スライドをクローンし、クローン上でオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph 遷移を適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションします。

以下の例はテキスト矩形を含むスライドを作成し、スライドをクローンして矩形の位置とサイズを変更します。次に、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存ファイルを開くと、スライドショー中に効果が確認できます。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph 遷移タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) 列挙体は、Morph がコンテンツを一致させてアニメーション化する方法を制御します。

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) は各シェイプ全体をオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) は可能な場合に単語単位でテキストを一致させてアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) は可能な場合に文字単位でテキストを一致させてアニメーション化します。

[setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) で Morph を選択し、[getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) を取得すると、[MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) オブジェクトが得られ、その [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) メソッドで一致モードを選択できます。

この例は前節で作成したプレゼンテーションを開き、2 番目のスライドに単語ベースの Morph アニメーションを設定します。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **遷移効果を設定する**

一部の遷移は、方向や黒画面から開始するかどうかなど、追加オプションを公開します。利用可能なオプションは [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) で選択した遷移に依存します。タイプを最初に設定し、次に [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) から適切な遷移オブジェクトを使用してください。

以下の例は `input.pptx` の最初のスライドに Cut 遷移を適用します。[OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) を介して [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) を呼び出し、遷移が黒画面から開始するようにします。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**スライド遷移の再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果期間が必要な場合は [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）のカテゴリで十分な場合は、明示的な期間が設定されていないときに [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) を使用します。これらの設定は、遷移効果を自動進行遅延とは独立して制御します。

**遷移にオーディオを添付してループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) で埋め込みオーディオを割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) 列挙体の StartSound を [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) に渡し、[setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) を `true` に設定します。オーディオはスライドショーの次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) コレクションをループし、各スライドの遷移に対して同じ値で [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で一貫した動作が保たれます。

**現在スライドに設定されている遷移を確認するにはどうすればよいですか？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 結果に対して [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 列挙体の値で、None の場合は遷移効果が適用されていないことを示します。