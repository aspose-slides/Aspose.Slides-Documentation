---
title: Python via Java を使用したプレゼンテーションでスライド遷移を管理する
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/python-java/slide-transition/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してスライド遷移を適用し、自動スライド進行を設定し、Morph やその他の遷移効果をカスタマイズします。"
---
## **概要**

スライド遷移はスライドショー中のスライドの表示方法を制御します。Aspose.Slides for Python via Java を使用すると、各スライドに遷移効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。本記事では、Python のサンプルを使用して遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph 遷移を作成する方法を示します。また、設定を PPTX ファイルに保存する方法も例示しています。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスでプレゼンテーションをロードし、[getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) を介してスライドの遷移設定にアクセスします。[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) を使用し、[TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列挙体の値を指定してから、プレゼンテーションを保存します。

以下の例は、最初のスライドに Circle 遷移、2 番目のスライドに Comb 遷移を適用します。`input.pptx` ファイルを使用し、スライドが少なくとも 2 枚あることを確認してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **ホイール遷移**

[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) を使用して、[TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) から Wheel を選択します。次に、[getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) を呼び出して [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) 設定にアクセスします。その [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) メソッドは、目的スライドを表示する放射状セクタの数を制御します。

この例では、同一のスライドペアを 2 組作成します。各ペアは黒色のスライドで開始し、スライド全体が金色の矩形で終了します。両方の目的スライドは、[setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) で設定した同じスロー速度と、[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) で設定した 8,000 ミリ秒の同一の明示的な期間を使用します。変更されるのはスポーク数だけです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint で `wheel-transitions.pptx` を開き、スライドショーを開始します。スライド 1 からスライド 2 に進むと、時計回りに 1 つのスイープで金色の矩形が表示されます。次にスライド 3 からスライド 4 に進むと、8 つの放射状セクタが同時に同じ矩形を表示します。

## **高度なスライド遷移の追加**

スライドが画面に表示される時間や、マウスクリックでスライドショーを進めるかどうかを設定できます。次のメソッドがこの動作を制御します：

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) は、閲覧者がマウスクリックで進められるようにします。
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) は、自動的に進むようにします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) は、自動進行までの遅延をミリ秒で指定します。

クリックとタイマーの両方の進行を有効にすると、閲覧者はクリックで進めるか、タイマー待ちで進めることができます。タイマーのみを使用する場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) に `False` を渡します。遅延はスライドショーが進むタイミングを制御しますが、視覚的遷移効果の期間は設定しません。

この例では、最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行を有効にします。マウスクリックでもこれらのスライドを進めることができます。`input.pptx` ファイルを使用し、スライドが少なくとも 3 枚あることを確認してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

タイマー進行が有効かどうかを確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) を呼び出します。保存された遅延だけでは、タイマーがアクティブであることを示すわけではありません。

次の例では、上記で保存したファイルを開き、各有効なタイマーを報告し、2 秒以上の遅延が設定されたスライドの自動進行を無効にします。そのスライドのマウスクリックを有効にし、更新された設定を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **遷移タイミングを正確に制御する**

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) を使用して、遷移効果の正確な長さ（ミリ秒）を指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) メソッドは、これらの設定を [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) を介して公開します。

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | 遷移効果自体の期間をミリ秒単位で設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | スライドが自動的に進むまでの遅延をミリ秒単位で設定します。`True` を [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) に渡すと、このタイマーが有効になります。 |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | 事前定義された速度カテゴリを [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) から選択します（Slow、Medium、Fast）。正確な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) は遷移効果のみを制御し、スライドが表示され続ける時間は決定しません。自動進行の遅延は別個に設定してください。明示的な期間が設定されていない場合、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) の値から効果期間を決定します。

<!-- visual-explanation:slide-transition:start -->
[![個別のバーが 750 ms の遷移期間と 5,000 ms の自動進行設定を示しています。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*この共有例は、各スライドに 750 ms の Fade 遷移を設定し、別々に 5,000 ms の自動進行を有効にします。遷移期間は効果を制御し、進行はスライドを離れるタイミングを制御します。これらのバーは概略設定であり、測定された総合タイムラインではありません。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同じ期間を適用する**

一貫したペースを保つために、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` をロードし、[TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の期間を設定します。また、5,000 ミリ秒後に自動進行を個別に有効にし、マウスクリックによる進行を無効にしてから、結果を PPTX として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # 効果の期間とは別に自動進行を設定します。
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **個々のスライドに異なる期間を設定する**

異なるスライドは異なる効果期間を使用できます。例えば、タイトルスライドには短い遷移、セクションの導入スライドには長い遷移を使用します。この例では、最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒を設定します。`input.pptx` ファイルを使用し、スライドが少なくとも 2 枚あることを確認してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **アニメーション出力と遷移を調整する**

アニメーション GIF [アニメーション GIF](/slides/ja/python-java/convert-powerpoint-to-animated-gif/)、HTML5 プレゼンテーション [HTML5 プレゼンテーション](/slides/ja/python-java/export-to-html5/)、またはビデオ [ビデオ](/slides/ja/python-java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確な遷移期間を設定し、意図したペースに合わせます。例えば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。GIF とビデオの場合、出力フレームレートを効果期間に合わせて調整します：600 ミリ秒は 30 fps で 18 フレームに相当します。HTML5 では、エクスポート設定でアニメーション遷移を有効にします。選択したエクスポート形式がサポートする効果とタイミングオプションを確認し、出力をプレビューして同期を確認してください。

### **既存の遷移期間を読み取る**

遷移を変更する前に [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) を呼び出して、明示的な値が保存されているかどうかを判断します。`-1` の値は明示的な期間が設定されていないことを意味し、0 以上の値はミリ秒単位で保存された期間を示します。未設定の値は計算された再生期間ではありません：Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) の値を使用してその期間を決定します。遷移タイプを設定すると期間が初期化されることがあるので、最初に元の設定を確認してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph 遷移**

Morph 遷移は連続するスライド間のオブジェクトの変化をアニメーション化します。シンプルな Morph 効果を作成するには、スライドを複製し、複製上のオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph 遷移を適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションします。

以下の例は、テキスト矩形を含むスライドを作成し、スライドを複製して、複製上の矩形の位置とサイズを変更します。その後、2 番目のスライドに対して [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存されたファイルを開き、スライドショー中の効果を確認してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph 遷移タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) 列挙体は、Morph がコンテンツを一致させてアニメーション化する方法を制御します：

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) は各シェイプを全体のオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) は可能な場合、単語を一致させてテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) は可能な場合、文字を一致させてテキストをアニメーション化します。

[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) を使用して [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) にアクセスする前に Morph を選択します。その結果は [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) クラスのインスタンスとなり、[setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) メソッドで一致モードを選択します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **遷移効果の設定**

一部の遷移は、方向や効果が黒画面から開始するかどうかなど追加オプションを提供します。利用可能なオプションは [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) で選択した遷移に依存します。まずタイプを設定し、次に [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) から適切なクラスを使用します。

以下の例は、`input.pptx` の最初のスライドに Cut 遷移を適用します。[OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) を介して [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) を呼び出し、遷移が黒画面から開始するようにします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **よくある質問**

**スライド遷移の再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果期間が必要な場合は、[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) を優先してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) カテゴリ（Slow、Medium、Fast）で十分で、明示的な期間が設定されていない場合は、[setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) を使用します。これらの設定は自動進行遅延とは独立して遷移効果を制御します。

**遷移に音声を添付してループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) で埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) 列挙体の StartSound を [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) に渡し、[setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) を `True` で有効にします。音声はスライドショー内の次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) コレクションをループし、各スライドの遷移に同じ値で [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) を呼び出します。同じループ内でタイミングや効果オプションを設定すれば、スライド間で動作を一貫させることができます。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 結果に対して [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) を呼び出します。これにより、[TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列挙体の値が返されます。None_ は遷移効果が適用されていないことを意味します。