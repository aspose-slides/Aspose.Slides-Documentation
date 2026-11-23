---
title: Java を使用したプレゼンテーションのスライドトランジションの管理
linktitle: スライドトランジション
type: docs
weight: 80
url: /ja/java/slide-transition/
keywords:
- スライドトランジション
- スライドトランジションの追加
- スライドトランジションの適用
- 高度なスライドトランジション
- モーフトランジション
- トランジションタイプ
- トランジション効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してスライドトランジションを適用し、自動スライド進行を設定し、Morph やその他のトランジション効果をカスタマイズします。"
---
## **概要**

スライドトランジションはスライドショー中にスライドがどのように表示されるかを制御します。Aspose.Slides for Java を使用すると、各スライドにトランジション効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果に固有のオプションを調整できます。本記事では、Java の例を使用してトランジションを適用し、正確なトランジション時間を設定し、スライドのタイミングを管理し、2 つのスライド間にモーフトランジションを作成します。また、設定を PPTX ファイルに保存する方法も示します。

## **スライドトランジションの追加**

トランジションを適用するには、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) メソッドでスライドのトランジション設定にアクセスします。[setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) に [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列挙から値を指定し、プレゼンテーションを保存します。

次の例は、最初のスライドに Circle トランジションを、2 番目のスライドに Comb トランジションを適用します。少なくとも 2 枚のスライドがある `input.pptx` ファイルを使用してください。

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

[IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) の [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) メソッドは、目的スライドを表示する放射状セクタの数を制御します。[TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) から Wheel を [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) で設定した後、[getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) を [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) として取得します。

この例では、黒いスライドの後に金色の長方形があるスライドという 2 つの同一ペアを作成します。目的スライドはそれぞれ 1 と 8 のスポーク数を使用し、[setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) で同じ速度を設定し、[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) で明示的に 8,000 ミリ秒の長さを設定して違いが分かりやすくしています。

```java
import java.awt.Color;
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
    Color gold = new Color(255, 215, 0);
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

PowerPoint で出力プレゼンテーションを開き、スライドショーを実行します。スライド 1 からスライド 2、続いてスライド 3 からスライド 4 に進みます。PowerPoint の再生では、スポーク数 1 の場合は時計回りに 1 回の掃き出しでスライドが表示され、スポーク数 8 の場合は同時に 8 部分に分かれて表示されます。目的コンテンツとトランジションのタイミングは同一なので、違いは表示セクタの数だけです。

## **Reveal トランジションによるブラックフェード**

目的スライドのトランジションタイプを Reveal に設定し、[IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) 設定で [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) を呼び出します。この例では、ティール色の元スライドとコーラル色の目的スライドを作成し、両方をクローンします。各ペアは同じ 2 秒の Reveal トランジションを使用し、2 番目のペアだけがブラックフェードを行います。

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
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

保存したプレゼンテーションを PowerPoint で開き、スライドショーを開始します。スライド 1 からスライド 2 に進むとティールが直接コーラルにフェードします。次にスライド 3 からスライド 4 に進むと、画面が一瞬ほぼ黒くなってからコーラルスライドが表示されます。両スライドとも元の背景色は保持されます。

以下の行は PowerPoint のフレームを 0.5 秒間隔で示しています。各行の中央フレームを比較して効果を確認してください。

![フェードスルーブラックが無効（上部）および有効（下部）になっている PowerPoint 再生。下部の行だけがほぼ黒にフェードします。](reveal-through-black.png)

## **高度なスライドトランジションの追加**

スライドが画面に留まる時間やマウスクリックでスライドショーを進めるかどうかを構成できます。以下のメソッドでこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) は、マウスクリックで進められるようにします。
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) は自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) は自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方の進行を有効にすると、クリックでもタイマーでもスライドを進められます。タイマーのみを使用する場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) に `false` を渡します。遅延はスライドショーが次のスライドに進むタイミングを決めるだけで、視覚的なトランジション効果の長さを設定するものではありません。

この例は最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもこれらのスライドは進められます。少なくとも 3 枚のスライドがある `input.pptx` ファイルを使用してください。

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

タイマー進行が有効かどうかを確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) を呼び出します。保存された遅延だけではタイマーがアクティブかどうかは判断できません。

次の例は、上記で保存したファイルを開き、各スライドのタイマーが有効かを報告し、2 秒以上の遅延が設定されたスライドの自動進行を無効にし、クリック進行を有効にして設定を保存します。

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

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) を使用して、トランジション効果そのものの長さをミリ秒単位で正確に指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) メソッドから [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) インターフェイスを取得し、以下の設定を行えます。

| メソッド | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | トランジション効果自体の継続時間（ミリ秒）を設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | スライドが自動的に進むまでの遅延時間（ミリ秒）を設定します。タイマーを有効にするには [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) に `true` を渡します。 |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 列挙（Slow、Medium、Fast）から事前定義された速度カテゴリを選択します。正確な継続時間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) はトランジション効果のみを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定します。明示的な継続時間が設定されていない場合、Aspose.Slides はトランジションタイプと [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) の値から効果時間を算出します。

<!-- visual-explanation:slide-transition:start -->
[![個別のバーが 750 ms のトランジション継続時間と 5 000 ms の自動進行設定を示しています。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*このサンプルは各スライドに 750 ms の Fade トランジションを設定し、同時に自動進行を 5 000 ms 後に有効にしています。トランジション継続時間は効果を制御し、進行はスライドを離れるタイミングを制御します。これらのバーは測定された合成タイムラインではなく、設定を示す概略です。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同一の継続時間を適用する**

一定のペースを保つには、すべてのスライドに同じ効果と正確な継続時間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) から Fade を選択し、各トランジションに 750 ミリ秒の継続時間を設定します。自動進行は 5 000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして PPTX として保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 効果の継続時間とは独立して自動進行を設定します。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **スライドごとに異なる継続時間を設定する**

スライドごとに別々の効果時間を使用できます。例として、タイトルスライドには短いトランジション、セクションイントロには長いトランジションを設定します。この例は最初のスライドに 500 ミリ秒、2 番目のスライドに 1 200 ミリ秒の継続時間を設定します。少なくとも 2 枚のスライドがある `input.pptx` を使用してください。

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

### **アニメーション出力とトランジションを連携させる**

[animated GIF](/slides/ja/java/convert-powerpoint-to-animated-gif/) や [HTML5 プレゼンテーション](/slides/ja/java/export-to-html5/)、[動画](/slides/ja/java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確なトランジション継続時間を設定して意図したペースに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF と動画の場合、フレームレートと効果時間を合わせます。600 ミリ秒は 30 fps の場合 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーショントランジションを有効にします。選択したエクスポート形式がサポートする効果とタイミングオプションを確認し、出力をプレビューして同期を確認してください。

### **既存のトランジション継続時間を取得する**

トランジションを変更する前に [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) を呼び出して、明示的な値が保存されているか確認します。`-1` は明示的な継続時間が設定されていないことを示し、非負の値はミリ秒単位で保存された継続時間を示します。未設定の値は再生時の計算された継続時間ではありません。Aspose.Slides はトランジションタイプと [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) の値から継続時間を算出します。トランジションタイプを設定すると継続時間が初期化されることがあるため、最初に元の設定を調べてください。

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

## **モーフ トランジション**

モーフトランジションは、連続するスライド間のオブジェクトの変更をアニメーション化します。シンプルなモーフ効果を作成するには、スライドをクローンし、クローン上のオブジェクトを移動またはサイズ変更し、2 番目のスライドにモーフトランジションを適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションします。

以下の例はテキスト長方形を含むスライドを作成し、スライドをクローンしてクローン上の長方形の位置とサイズを変更します。次に 2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列挙で Morph を選択します。モーフに対応したプレゼンテーションビューアで保存ファイルを開くと、スライドショー中に効果が確認できます。

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

## **モーフ トランジションの種類**

[TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) 列挙は、モーフがコンテンツをどのようにマッチングしてアニメーション化するかを制御します。

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) は各シェイプ全体をオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) は可能な限り単語単位でテキストをマッチングしてアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) は可能な限り文字単位でテキストをマッチングしてアニメーション化します。

[setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) で Morph を選択し、[getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) から取得した [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) インターフェイスの [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) メソッドでマッチングモードを選択します。

この例は前節で作成したプレゼンテーションを開き、2 番目のスライドを単語ベースのモーフアニメーションに設定します。

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

一部のトランジションは方向やブラックスクリーンから開始するかどうかなどの追加オプションを提供します。利用できるオプションは [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) で選択したトランジションに依存します。まずタイプを設定し、続いて [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) で取得した適切なインターフェイスを使用します。

以下の例は `input.pptx` の最初のスライドに Cut トランジションを適用し、[IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) を介して [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) を呼び出し、ブラックスクリーンから開始するように設定します。

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

## **FAQ**

**スライドトランジションの再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果時間が必要な場合は [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) カテゴリ（Slow、Medium、Fast）で十分な場合は、明示的な継続時間が設定されていないときに [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) を使用します。これらの設定は自動進行遅延とは独立してトランジション効果を制御します。

**トランジションに音声を添付してループ再生できますか？**

はい。[setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) で埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) 列挙の StartSound を [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) に渡し、[setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) を `true` に設定します。音声はスライドショーの次の音声イベントが発生するまでループ再生されます。

**すべてのスライドに同じトランジションを適用する最速の方法は？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) コレクションをループし、各スライドのトランジションに同じ値で [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で挙動を統一できます。

**スライドに現在設定されているトランジションを確認する方法は？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) の結果に対して [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 列挙の値で、None はトランジション効果が設定されていないことを意味します。