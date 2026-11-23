---
title: Android でプレゼンテーションのスライド トランジションを管理する
linktitle: スライド トランジション
type: docs
weight: 80
url: /ja/androidjava/slide-transition/
keywords:
- スライド トランジション
- スライド トランジションの追加
- スライド トランジションの適用
- 高度なスライド トランジション
- モーフ トランジション
- トランジション タイプ
- トランジション 効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "スライド トランジションを適用し、自動スライド進行を構成し、Aspose.Slides for Android via Java でモーフやその他のトランジション効果をカスタマイズします。"
---
## **概要**

スライドトランジションは、スライドショー中にスライドが表示される方法を制御します。Aspose.Slides for Android via Java を使用すると、各スライドに対してトランジション効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。この記事では、Java のサンプルを使用してトランジションを適用し、正確なトランジション時間を設定し、スライドのタイミングを管理し、2 つのスライド間で Morph トランジションを作成する方法を示します。また、設定を PPTX ファイルに保存する方法も示しています。

## **スライド トランジションの追加**

トランジションを適用するには、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスでプレゼンテーションをロードし、[getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) を介してスライドのトランジション設定にアクセスします。[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) 列挙体の値を使用して [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) を呼び出し、最後にプレゼンテーションを保存します。

次の例は、最初のスライドに Circle トランジションを、2 番目のスライドに Comb トランジションを適用します。スライドが少なくとも 2 枚ある `input.pptx` ファイルを使用してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **ホイール トランジション**

[IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) の [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) メソッドは、対象スライドを表示する放射状セクタの数を制御します。[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) から Wheel を選択して [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) でスライドのトランジションタイプを設定し、[IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) として [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) にアクセスします。

この例では、黒いスライドと金色の長方形があるスライドの 2 つの同一ペアを作成します。対象スライドはスポーク数を 1 と 8 に設定し、[setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) で同じ速度を設定し、[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) で 8,000 ミリ秒の明示的な期間を設定して違いが分かりやすくしています。

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    int gold = Color.rgb(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint で出力プレゼンテーションを開き、スライドショーを実行します。スライド 1 からスライド 2、続いてスライド 3 からスライド 4 に進めます。PowerPoint の再生では、スポーク数が 1 の場合は時計回りに 1 回のスイープでスライドが表示され、8 の場合は 8 つの放射状セクタが同時に表示されます。対象コンテンツとトランジションのタイミングは同一なので、違いは表示セクタの数だけです。

## **リビール トランジションによる黒フェード**

対象スライドのトランジションタイプを Reveal に設定し、[IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/) の設定で [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) を呼び出します。この例では、ティール色の元スライドとコーラル色の対象スライドを作成し、両方をクローンします。各ペアは同じ 2 秒の Reveal トランジションを使用し、2 番目のペアだけが黒を通してフェードします。

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存したプレゼンテーションを PowerPoint で開き、スライドショーを開始します。スライド 1 からスライド 2 に進めると、ティールがコーラルに直接フェードするのが確認できます。その後、スライド 3 からスライド 4 に進めると、画面が一瞬ほぼ黒くなってからコーラルスライドが表示されます。どちらのスライドも元の背景色を保持しています。

以下の行は、PowerPoint のフレームを 0.5 秒間隔で示しています。各行の中央フレームを比較して効果を確認してください。

![別々のバーが 750 ミリ秒のトランジション期間と 5,000 ミリ秒の自動進行設定を示しています。](reveal-through-black.png)

*この共有例では、各スライドに 750 ミリ秒の Fade トランジションを設定し、別途 5,000 ミリ秒で自動進行を有効にしています。トランジション期間は効果を制御し、進行はスライドを離れるタイミングを制御します。これらのバーは概念的な設定であり、測定された統合タイムラインではありません。*

## **高度なスライドトランジションの追加**

スライドが画面に表示される時間や、マウスクリックでスライドショーを進めるかどうかを設定できます。以下のメソッドがこの動作を制御します：

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ビューアがマウスクリックで進めることを許可します。
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 自動的に進行できるようにします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) 自動進行までの遅延をミリ秒単位で指定します。

クリックとタイマーの両方の進行を有効にすると、ビューアはクリックで進めるか、タイマー待ちで進めることができます。タイマーのみ使用する場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) に `false` を渡します。遅延はスライドショーが進むタイミングを制御し、ビジュアルトランジション効果の期間は設定しません。

この例では、最初の 3 枚のスライドに異なる効果を割り当て、それぞれ 3 秒、5 秒、7 秒後に自動進行を有効にしています。マウスクリックでもこれらのスライドを進めることができます。スライドが少なくとも 3 枚ある `input.pptx` ファイルを使用してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

タイマー進行が有効か確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) を呼び出します。保存された遅延だけではタイマーがアクティブであることを示しません。

次の例では、上記で保存したファイルを開き、各有効なタイマーを報告し、遅延が 2 秒を超えるスライドの自動進行を無効にします。それらのスライドではマウスクリックを有効にし、更新された設定を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **トランジションタイミングの正確な制御**

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) を使用して、トランジション効果の正確な長さ（ミリ秒）を指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) メソッドは、[ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/) を通じてこれらの設定を公開します。

| メソッド | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | トランジション効果そのものの継続時間をミリ秒で設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | スライドが自動的に進むまでの遅延をミリ秒で設定します。`true` を [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) に渡すとこのタイマーが有効になります。 |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) から事前定義された速度カテゴリ（Slow、Medium、Fast）を選択します。正確な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) はトランジション効果のみを制御し、スライドが表示される時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides はトランジションタイプと [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) の値から効果の期間を決定します。

<!-- visual-explanation:slide-transition:start -->
[![別々のバーが 750 ミリ秒のトランジション期間と 5,000 ミリ秒の自動進行設定を示しています。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*この共有例では、各スライドに 750 ミリ秒の Fade トランジションを設定し、別途 5,000 ミリ秒で自動進行を有効にしています。トランジション期間は効果を制御し、進行はスライドを離れるタイミングを制御します。これらのバーは概念的な設定であり、測定された統合タイムラインではありません。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同じ期間を適用する**

一定のペースを保つため、すべてのスライドに同じ効果と正確な期間を適用します。この例では `input.pptx` をロードし、[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) から Fade を選択し、各トランジションに 750 ミリ秒の期間を設定します。また、5,000 ミリ秒後に自動進行を有効にし、マウスクリックでの進行を無効にして、結果を PPTX として保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 効果の期間とは別に自動進行を設定します。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **個々のスライドに異なる期間を設定する**

スライドごとに異なる効果期間を使用できます。例えば、タイトルスライドには短いトランジション、セクションの導入には長いトランジションを使用します。この例では、最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒を設定します。スライドが少なくとも 2 枚ある `input.pptx` ファイルを使用してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **アニメーション出力とトランジションを調整する**

アニメーションGIF([animated GIF](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/))、HTML5 プレゼンテーション([HTML5 presentation](/slides/ja/androidjava/export-to-html5/))、またはビデオ([video](/slides/ja/androidjava/convert-powerpoint-to-video/)) を作成する際は、エクスポート前に正確なトランジション期間を設定して意図したペースに合わせます。例えば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF とビデオの場合、出力フレームレートを効果期間と合わせます：600 ミリ秒は 30 フレーム/秒で 18 フレームに相当します。HTML5 では、エクスポート設定でアニメーション トランジションを有効にします。選択したエクスポート形式がサポートする効果やタイミングオプションを確認し、出力をプレビューして同期を確認してください。

### **既存のトランジション期間を読む**

トランジションを変更する前に [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) を呼び出し、明示的な値が保存されているか確認します。値が `-1` の場合は明示的な期間が設定されていないことを意味し、0 以上の値はミリ秒単位で保存された期間を示します。未設定の値は計算された再生期間ではありません。Aspose.Slides はトランジションタイプと [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) の値を使用して期間を決定します。トランジションタイプを設定すると期間が初期化されることがあるため、まず元の設定を確認してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph トランジション**

Morph トランジションは、連続するスライド間のオブジェクトの変化をアニメーション化します。シンプルな Morph 効果を作成するには、スライドをクローンし、クローン上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph トランジションを適用します。これにより、対応するオブジェクトが元の状態と変更後の状態の間でアニメーションします。

次の例では、テキスト長方形を含むスライドを作成し、スライドをクローンしてクローン上の長方形の位置とサイズを変更します。その後、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存されたファイルを開くと、スライドショー中に効果が確認できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph トランジションのタイプ**

[TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのように一致させてアニメーション化するかを制御します：

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) 各シェイプを全体オブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) 可能な場合、単語を一致させてテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) 可能な場合、文字を一致させてテキストをアニメーション化します。

[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) を使用して [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) にアクセスする前に Morph を選択します。その値は [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) インタフェースを提供し、[setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) メソッドでマッチングモードを選択します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **トランジション効果の設定**

いくつかのトランジションは、方向や効果が黒画面から開始するかどうかなど、追加オプションを提供します。利用可能なオプションは、[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) で選択したトランジションに依存します。まずタイプを設定し、次に [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) から適切なインタフェースを使用します。

次の例では、`input.pptx` の最初のスライドに Cut トランジションを適用します。[IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) を介して [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) を呼び出し、トランジションが黒画面から開始するようにします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**スライドトランジションの再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果期間が必要な場合は、[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) カテゴリ（Slow、Medium、Fast）で十分で明示的な期間を設定しない場合は、[setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) を使用します。これらの設定は自動進行遅延とは独立してトランジション効果を制御します。

**トランジションに音声を添付してループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) で埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) 列挙体から StartSound を [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) に渡し、[setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) を `true` に設定して有効化します。音声はスライドショー内の次のサウンドイベントが発生するまでループ再生されます。

**すべてのスライドに同じトランジションを適用する最速の方法は何ですか？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) コレクションをループし、各スライドのトランジションに同じ値で [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、すべてのスライドで動作が一貫します。

**スライドに現在設定されているトランジションを確認する方法は？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) の結果に対して [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) を呼び出します。これにより、[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) 列挙体の値が返ります。None はトランジション効果が適用されていないことを意味します。