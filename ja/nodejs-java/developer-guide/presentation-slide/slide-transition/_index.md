---
title: JavaScript を使用したプレゼンテーションのスライド遷移管理
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
description: "Aspose.Slides for Node.js via Java を使用して、スライド遷移を適用し、自動スライド進行を設定し、Morph やその他の遷移効果をカスタマイズします。"
---
## **概要**

スライド遷移はスライドショー中のスライドの表示方法を制御します。Aspose.Slides for Node.js via Java を使用すると、各スライドに遷移効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。この記事では、JavaScript の例を用いて遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph 遷移を作成する方法を示します。例では設定を PPTX ファイルに保存する方法も示しています。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[getSlideShowTransition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) を介してスライドの遷移設定にアクセスします。[setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setType) に [TransitionType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitiontype/) 列挙体から値を指定し、プレゼンテーションを保存してください。

次の例は、最初のスライドに Circle 遷移、2 番目のスライドに Comb 遷移を適用します。スライドが少なくとも 2 枚ある `input.pptx` ファイルを使用してください。

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

## **高度なスライド遷移の追加**

スライドが画面に表示される時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のメソッドでこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) は、閲覧者がマウスクリックで進められるようにします。
- [setAdvanceAfter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) は自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) は、自動進行までの遅延時間をミリ秒で指定します。

クリックとタイマーの両方を有効にすると、閲覧者はクリックで進むか、タイマー待ちで進むことができます。タイマーのみを使用するには、[setAdvanceOnClick](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) に `false` を渡してください。遅延はスライドショーが進むタイミングを制御しますが、視覚的遷移効果の継続時間は設定しません。

この例は、最初の 3 スライドにそれぞれ異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもこれらのスライドは進められます。スライドが少なくとも 3 枚ある `input.pptx` ファイルを使用してください。

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

タイマー進行が有効かどうかを確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) を呼び出します。遅延が保存されているだけでは、タイマーがアクティブであることを意味しません。

次の例は、上記で保存したファイルを開き、各スライドのタイマーが有効か報告し、遅延が 2 秒を超えるスライドの自動進行を無効にします。そのスライドではクリックで進めるようにし、更新された設定を保存します。

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

## **遷移タイミングの正確な制御**

[setDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setDuration) を使用して、遷移効果の正確な長さをミリ秒単位で指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) メソッドは、これらの設定を [SlideShowTransition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/) 経由で公開します。

| メソッド | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | トランジション効果自体の継続時間をミリ秒単位で設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | スライドが自動的に進むまでの遅延時間をミリ秒単位で設定します。タイマーを有効にするには、[setAdvanceAfter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) に `true` を渡してください。 |
| [setSpeed](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitionspeed/) 列挙体から Slow、Medium、Fast のいずれかの事前定義された速度カテゴリを選択します。明示的な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setDuration) は遷移効果のみを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) の値から効果の期間を算出します。

### **すべてのスライドに同じ期間を適用する**

一定のテンポを保つために、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の期間を設定します。自動進行は 5,000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして、結果を PPTX として保存します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // 効果の期間とは別に自動進行を設定します。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **スライドごとに異なる期間を設定する**

スライドごとに異なる効果期間を使用できます。たとえば、タイトルスライドには短い遷移、セクション導入スライドには長めの遷移を設定します。この例は、最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒の期間を設定します。スライドが少なくとも 2 枚ある `input.pptx` ファイルを使用してください。

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

[animated GIF](/slides/ja/nodejs-java/convert-powerpoint-to-animated-gif/) や [HTML5 presentation](/slides/ja/nodejs-java/export-to-html5/)、[video](/slides/ja/nodejs-java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確な遷移期間を設定して意図したテンポに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF およびビデオの場合、フレームレートと効果期間を合わせます。600 ミリ秒は 30 fps の場合 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション遷移を有効にします。選択したエクスポート形式がサポートする効果とタイミングオプションを確認し、プレビューで同期を確認してください。

### **既存の遷移期間を取得する**

遷移を変更する前に [getDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#getDuration) を呼び出して、明示的な値が保存されているか確認します。`-1` は明示的な期間が設定されていないことを意味し、0 以上の値はミリ秒単位で保存された期間を示します。未設定の値は再生期間の計算結果ではなく、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) の値から期間を決定します。遷移タイプを設定すると期間が初期化されることがあるため、最初に元の設定を確認してください。

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

Morph 遷移は連続するスライド間のオブジェクトの変化をアニメーション化します。簡単な Morph 効果を作成するには、スライドをクローンし、クローン上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph 遷移を適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーション化されます。

次の例は、テキスト矩形を持つスライドを作成し、そのスライドをクローンし、クローン上で矩形の位置とサイズを変更します。次に、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存されたファイルを開くと、スライドショー中に効果が確認できます。

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

[TransitionMorphType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチングおよびアニメーション化するかを制御します。

- [ByObject](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) は、各シェイプを全体のオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) は、可能な場合に単語単位でテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) は、可能な場合に文字単位でテキストをアニメーション化します。

[setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setType) で Morph を選択し、[getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#getValue) にアクセスします。取得した値は [MorphTransition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/morphtransition/) オブジェクトを提供し、[setMorphType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/morphtransition/#setMorphType) メソッドでマッチングモードを選択します。

この例は前節で作成したプレゼンテーションを開き、2 番目のスライドで単語ベースの Morph アニメーションを使用するように構成します。

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

## **遷移効果の設定**

一部の遷移は方向や黒画面から開始するかなど、追加オプションを提供します。利用可能なオプションは [setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setType) で選択した遷移に依存します。まずタイプを設定し、次に [getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#getValue) から取得できる適切な遷移オブジェクトを使用します。

次の例は `input.pptx` の最初のスライドに Cut 遷移を適用します。[OptionalBlackTransition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/optionalblacktransition/) を通じて [setFromBlack](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) を呼び出し、遷移を黒画面から開始させます。

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

はい。ミリ秒単位で正確な効果時間が必要な場合は [setDuration](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setDuration) を使用してください。事前定義されたカテゴリ（Slow、Medium、Fast）で十分で明示的な期間を設定しない場合は [setSpeed](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) を使用します。これらの設定は自動進行遅延とは独立して遷移効果を制御します。

**遷移にオーディオを添付してループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setSound) で埋め込みオーディオを割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitionsoundmode/) 列挙体の StartSound を [setSoundMode](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) に渡し、[setSoundLoop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) を `true` に設定します。オーディオはスライドショーの次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getSlides) コレクションをループし、各スライドの遷移に対して同じ値で [setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#setType) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で動作が一貫します。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) の結果に対して [getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideshowtransition/#getType) を呼び出します。返される値は [TransitionType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/transitiontype/) 列挙体の一つで、None は遷移効果が適用されていないことを示します。