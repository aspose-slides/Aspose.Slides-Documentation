---
title: Python via Java を使用してプレゼンテーションのスライド トランジションを管理する
linktitle: スライド トランジション
type: docs
weight: 80
url: /ja/python-java/slide-transition/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してスライド トランジションを適用し、自動スライド進行を設定し、Morph などのトランジション効果をカスタマイズします。"
---
## **概要**

スライド トランジションは、スライドショー中にスライドがどのように表示されるかを制御します。Aspose.Slides for Python via Java を使用すると、各スライドにトランジション効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。この記事では、Python のサンプルを用いてトランジションの適用、正確なトランジション時間の設定、スライドタイミングの管理、2 枚のスライド間の Morph トランジションの作成方法を示します。また、設定を PPTX ファイルに保存する方法も紹介します。

## **スライド トランジションの追加**

トランジションを適用するには、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[getSlideShowTransition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getSlideShowTransition) でスライドのトランジション設定にアクセスします。[setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setType) に [TransitionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitiontype/) 列挙から値を指定し、プレゼンテーションを保存します。

次の例は、最初のスライドに Circle トランジション、2 番目のスライドに Comb トランジションを適用します。最低でも 2 枚のスライドがある `input.pptx` ファイルを使用してください。

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

## **高度なスライド トランジションの追加**

スライドが画面に表示され続ける時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のメソッドでこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) は、マウスクリックで進められるようにします。
- [setAdvanceAfter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) は、自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) は、自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方を有効にすれば、クリックでもタイマー待ちでも次へ進められます。タイマーのみ使用する場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) に `False` を渡してください。遅延はスライドショーの進行時期を決めるだけで、視覚的なトランジション効果の長さを設定するものではありません。

この例では、最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもこれらのスライドは進められます。最低でも 3 枚のスライドがある `input.pptx` を使用してください。

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

タイマー進行が有効かどうかを確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) を呼びます。遅延が保存されているだけでは、タイマーがアクティブかどうかは判断できません。

次の例は、上記で保存したファイルを開き、設定されたタイマーを各スライドで報告し、2 秒以上の遅延があるスライドの自動進行を無効にします。そのスライドはクリックで進められるようにし、設定を保存します。

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

## **トランジションのタイミングを正確に制御する**

[setDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setDuration) を使用して、トランジション効果そのものの長さをミリ秒単位で指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getSlideShowTransition) メソッドは、[SlideShowTransition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/) を通じてこれらの設定を公開します。

| メソッド | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setDuration) | トランジション効果そのものの継続時間（ミリ秒）を設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | スライドが自動的に進むまでの遅延時間（ミリ秒）を設定します。タイマーを有効にするには、[setAdvanceAfter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) に `True` を渡します。 |
| [setSpeed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitionspeed/) 列挙から Slow、Medium、Fast のいずれかを選択します。正確な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setDuration) はトランジション効果のみを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定してください。明示的な期間が設定されていない場合、Aspose.Slides はトランジションの種類と [getSpeed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#getSpeed) の値から効果の継続時間を算出します。

### **すべてのスライドに同一の期間を適用する**

一定のリズムを保つには、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitiontype/) から Fade を選択し、各トランジションを 750 ミリ秒に設定します。自動進行は 5,000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして、結果を PPTX として保存します。

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

        # 効果の継続時間とは別に自動進行を設定します。
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **スライドごとに異なる期間を設定する**

スライドごとに異なる効果期間を使用できます。たとえば、タイトルスライドは短いトランジション、セクション導入スライドは長いトランジションを設定します。この例では、最初のスライドを 500 ミリ秒、2 番目のスライドを 1,200 ミリ秒に設定します。最低でも 2 枚のスライドがある `input.pptx` を使用してください。

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

### **アニメーション出力とトランジションを連携させる**

[animated GIF](/slides/ja/python-java/convert-powerpoint-to-animated-gif/)、[HTML5 プレゼンテーション](/slides/ja/python-java/export-to-html5/)、または [動画](/slides/ja/python-java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確なトランジション期間を設定して意図したリズムに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF や動画の場合、出力フレームレートと効果期間を合わせます。600 ミリ秒は 30 fps の場合 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション トランジションを有効にします。選択したフォーマットがサポートする効果とタイミングオプションを確認し、プレビューで同期を確認してください。

### **既存のトランジション期間を取得する**

トランジションを変更する前に [getDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#getDuration) を呼び出して、明示的な値が保存されているか確認します。`-1` は明示的な期間が設定されていないことを示し、0 以上の値はミリ秒単位の保存された期間です。未設定の値は再生時間の計算結果ではなく、Aspose.Slides はトランジションの種類と [getSpeed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#getSpeed) の値から期間を算出します。トランジションの種類を設定すると期間が初期化されることがあるため、最初に元の設定を確認してください。

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

## **Morph トランジション**

Morph トランジションは、連続するスライド間でオブジェクトの変化をアニメーション化します。シンプルな Morph 効果を作成するには、スライドを複製し、複製したスライド上のオブジェクトを移動またはサイズ変更し、2 枚目のスライドに Morph トランジションを適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーション化されます。

以下の例は、テキスト矩形を持つスライドを作成し、スライドを複製して矩形の位置とサイズを変更します。2 枚目のスライドの [TransitionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitiontype/) 列挙から Morph を選択します。Morph をサポートするプレゼンテーション ビューアで保存ファイルを開くと、スライドショー中に効果が確認できます。

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

## **Morph トランジションの種類**

[TransitionMorphType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitionmorphtype/) 列挙は、Morph がコンテンツをマッチングおよびアニメーション化する方法を制御します。

- [ByObject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitionmorphtype/#ByObject) は、各シェイプ全体をオブジェクトとして扱います。
- [ByWord](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitionmorphtype/#ByWord) は、可能な限り単語単位でテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitionmorphtype/#ByChar) は、可能な限り文字単位でテキストをアニメーション化します。

[Morph] を選択するには、[setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setType) を呼び、続いて [getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#getValue) にアクセスします。取得した値は [MorphTransition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/morphtransition/) クラスのインスタンスであり、[setMorphType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/morphtransition/#setMorphType) メソッドでマッチングモードを選択します。

この例は前節で作成したプレゼンテーションを開き、2 枚目のスライドに単語ベースの Morph アニメーションを設定します。

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

## **トランジション効果の設定**

一部のトランジションは、方向や黒画面から開始するかどうかといった追加オプションを提供します。利用可能なオプションは、[setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setType) で選択したトランジションに依存します。まず種類を設定し、次に [getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#getValue) から適切なクラスを使用します。

以下の例は `input.pptx` の最初のスライドに Cut トランジションを適用します。[OptionalBlackTransition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/optionalblacktransition/) の [setFromBlack](https://reference.aspose.com/slides/ja/python-java/aspose.slides/optionalblacktransition/#setFromBlack) を呼び出し、黒画面から開始するようにします。

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

## **FAQ**

**スライド トランジションの再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果時間が必要な場合は [setDuration](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setDuration) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）のカテゴリで十分で、明示的な期間を設定しない場合は [setSpeed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setSpeed) を使用します。これらの設定は自動進行遅延とは独立してトランジション効果を制御します。

**トランジションに音声を添付してループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setSound) で埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitionsoundmode/) の `StartSound` を [setSoundMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setSoundMode) に渡し、[setSoundLoop](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setSoundLoop) に `True` を設定します。音声は次のサウンド イベントが発生するまでループします。

**すべてのスライドに同じトランジションを適用する最速の方法は？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) コレクションをループし、各スライドのトランジションに対して同じ値で [setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#setType) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で挙動を統一できます。

**スライドに現在設定されているトランジションを確認するには？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getSlideShowTransition) の結果に対して [getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideshowtransition/#getType) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/transitiontype/) 列挙からの値で、`None_` はトランジション効果が適用されていないことを示します。