---
title: Java を使用したプレゼンテーションのスライド遷移の管理
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してスライド遷移を適用し、自動スライド進行を設定し、Morph やその他の遷移効果をカスタマイズします。"
---
## **概要**

スライド遷移は、スライドショー中にスライドがどのように表示されるかを制御します。Aspose.Slides for Java を使用すると、各スライドに遷移効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。本記事では、Java のサンプルを使って遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph 遷移を作成する方法を示します。サンプルは設定を PPTX ファイルに保存する方法も示しています。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスでプレゼンテーションをロードし、[getSlideShowTransition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) を介してスライドの遷移設定にアクセスします。[setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setType-int-) に [TransitionType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitiontype/) 列挙体の値を指定し、プレゼンテーションを保存します。

以下の例は、最初のスライドに Circle 遷移を、2 番目のスライドに Comb 遷移を適用します。スライドが最低 2 枚ある `input.pptx` ファイルを使用してください。

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

## **高度なスライド遷移の追加**

スライドが画面に留まる時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のメソッドでこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) は、マウスクリックで進めることを許可します。
- [setAdvanceAfter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) は、自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) は、自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方を有効にすれば、クリックでもタイマーでもスライドを進められます。タイマーのみ使用したい場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) に `false` を渡します。遅延はスライドショーが次に進むタイミングを制御しますが、視覚的な遷移効果の期間は設定しません。

この例は、最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもこれらのスライドは進められます。スライドが最低 3 枚ある `input.pptx` ファイルを使用してください。

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

タイマー進行が有効かどうかを確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) を呼び出します。遅延が保存されているだけでは、タイマーがアクティブであることを示しません。

次の例は、上記で保存したファイルを開き、各スライドのタイマーが有効かどうかを報告し、遅延が 2 秒を超えるスライドの自動進行を無効にします。そのスライドではマウスクリックを有効にし、設定を更新して保存します。

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

## **遷移タイミングを正確に制御する**

[setDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setDuration-int-) を使用して、遷移効果そのものの長さ（ミリ秒）を正確に指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) メソッドは、[ISlideShowTransition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/) を通じてこれらの設定を公開します。

| メソッド | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | 遷移効果自体の期間をミリ秒で設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | スライドが自動的に進むまでの遅延時間をミリ秒で設定します。[setAdvanceAfter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) に `true` を渡してタイマーを有効にします。 |
| [setSpeed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitionspeed/) 列挙体から Slow、Medium、Fast の事前定義された速度カテゴリを選択します。正確な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setDuration-int-) は遷移効果だけを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#getSpeed--) の値から効果期間を算出します。

### **すべてのスライドに同じ期間を適用する**

一定のペースを保つために、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` をロードし、[TransitionType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の期間を設定します。また、自動進行を 5,000 ミリ秒後に有効にし、マウスクリックによる進行を無効にして、結果を PPTX として保存します。

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

スライドごとに異なる効果期間を使用できます。たとえば、タイトルスライドには短い遷移を、セクションの導入スライドには長い遷移を設定します。この例は、最初のスライドを 500 ミリ秒、2 番目のスライドを 1,200 ミリ秒に設定します。スライドが最低 2 枚ある `input.pptx` ファイルを使用してください。

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

### **アニメーション出力と遷移を調整する**

[animated GIF](/slides/ja/java/convert-powerpoint-to-animated-gif/)、[HTML5 プレゼンテーション](/slides/ja/java/export-to-html5/)、または [video](/slides/ja/java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確な遷移期間を設定して目的のペースに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF と動画の場合、フレームレートと効果期間を合わせる必要があります。600 ミリ秒は 30 fps で 18 フレームに相当します。HTML5 では、エクスポート設定でアニメーション遷移を有効にします。選択したエクスポート形式がサポートする効果やタイミングオプションを確認し、プレビューで同期を確認してください。

### **既存の遷移期間を読む**

遷移を変更する前に [getDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#getDuration--) を呼び出して、明示的な値が保存されているか確認します。`-1` は明示的な期間が設定されていないことを示し、0 以上の値はミリ秒単位の保存された期間です。未設定の値は再生時の計算された期間ではありません。Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#getSpeed--) の値から期間を決定します。遷移タイプを設定すると期間が初期化されることがあるため、最初に元の設定を確認してください。

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

## **Morph 遷移**

Morph 遷移は、連続するスライド間でオブジェクトの変化をアニメーション化します。簡単な Morph 効果を作成するには、スライドをクローンし、クローン上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph 遷移を適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションします。

以下の例は、テキスト矩形を含むスライドを作成し、スライドをクローンしてクローン上の矩形の位置とサイズを変更します。2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitiontype/) 列挙体で Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存ファイルを開くと、スライドショー中に効果が確認できます。

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

## **Morph 遷移タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチングしアニメーション化するかを制御します。

- [ByObject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitionmorphtype/#ByObject) は各シェイプ全体をオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitionmorphtype/#ByWord) は可能な場合に単語単位でテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitionmorphtype/#ByChar) は可能な場合に文字単位でテキストをアニメーション化します。

[setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setType-int-) で Morph を選択した後、[getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#getValue--) を呼び出して取得できる [IMorphTransition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imorphtransition/) インターフェイスの [setMorphType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imorphtransition/#setMorphType-int-) メソッドでマッチングモードを選択します。

この例は前節で作成したプレゼンテーションを開き、2 番目のスライドで単語ベースの Morph アニメーションを設定します。

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

## **遷移効果の設定**

一部の遷移は方向や黒画面から開始するかどうかなど、追加オプションを公開します。利用できるオプションは [setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setType-int-) で選択した遷移に依存します。まずタイプを設定し、次に [getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#getValue--) から適切なインターフェイスを使用します。

以下の例は `input.pptx` の最初のスライドに Cut 遷移を適用します。[IOptionalBlackTransition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ioptionalblacktransition/) を介して [setFromBlack](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) を呼び出し、遷移が黒画面から開始するようにします。

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

**スライド遷移の再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果期間が必要な場合は [setDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setDuration-int-) を使用してください。事前定義されたカテゴリ（Slow、Medium、Fast）で十分で明示的な期間を設定しない場合は [setSpeed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) を使用します。これらの設定は自動進行遅延とは独立して遷移効果を制御します。

**遷移に音声を添付してループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) で埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitionsoundmode/) 列挙体の StartSound を [setSoundMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) に渡し、[setSoundLoop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) を `true` に設定します。音声はスライドショーの次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlides--) コレクションをループし、各スライドの遷移に対して同じ値で [setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#setType-int-) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド間で挙動を統一できます。

**スライドに現在設定されている遷移を確認するには？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 結果に対して [getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islideshowtransition/#getType--) を呼び出します。戻り値は [TransitionType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitiontype/) 列挙体の値で、None は遷移効果が適用されていないことを示します。