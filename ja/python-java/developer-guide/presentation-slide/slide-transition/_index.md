---
title: Python via Java を使用したプレゼンテーションのスライド遷移の管理
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
description: "Aspose.Slides for Python via Java を使用して、スライド遷移を適用し、自動スライド進行を構成し、Morph やその他の遷移効果をカスタマイズします。"
---
## **概要**

スライド遷移は、スライドショー中にスライドがどのように表示されるかを制御します。Aspose.Slides for Python via Java を使用すると、各スライドに遷移効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。本記事では Python のサンプルを用いて遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph 遷移を作成する方法を示します。サンプルは設定を PPTX ファイルに保存する方法も示しています。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) でスライドの遷移設定にアクセスします。[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) に [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列挙から値を指定し、最後にプレゼンテーションを保存します。

以下の例は、最初のスライドに Circle 遷移、2 番目のスライドに Comb 遷移を適用します。2 枚以上のスライドを含む `input.pptx` ファイルを使用してください。

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

## **Wheel 遷移**

[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) で [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) から Wheel を選択します。次に [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) で [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) 設定にアクセスし、[setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) メソッドで放射状セクタ数を制御します。

この例では同一のスライドペアを 2 つ作成します。各ペアは黒いスライドで始まり、全スライドに金色の矩形で終わります。両方の目的スライドは、[setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) で遅い速度を設定し、[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) で 8,000 ミリ秒の明示的な期間を設定しています。スポーク数だけが変わります。

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

`wheel-transitions.pptx` を PowerPoint で開き、スライドショーを開始します。スライド 1 から 2 に進むと、時計回りのスイープで金色の矩形が現れます。続いてスライド 3 から 4 に進むと、8 本の放射状セクタが同時に矩形を露出させます。

## **Reveal 遷移によるブラックフェード**

目的スライドの遷移タイプを Reveal に設定し、[setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) をその [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) 設定に対して呼び出します。例では、ティールの元スライドとコーラルの目的スライドを作成し、両方をクローンします。各ペアは 2 秒の Reveal 遷移を使用しますが、2 番目のペアだけがブラックフェードを伴います。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`reveal-transitions.pptx` を PowerPoint で開き、スライドショーを開始します。スライド 1 から 2 に進むと、ティールが直接コーラルにフェードします。スライド 3 から 4 に進むと、画面が一瞬ほぼ黒くなり、続いてコーラルスライドが表示されます。両スライドは元の背景色を保持します。

下の行は 0.5 秒間隔の PowerPoint のフレームを示しています。各行の中央フレームを比較して効果を確認してください。

![PowerPoint playback with fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **高度なスライド遷移の追加**

スライドが画面に表示される時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。次のメソッドでこの動作を制御します。

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) は、マウスクリックで進められるようにします。
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) は自動進行を有効にします。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) は自動進行までの遅延時間（ミリ秒）を指定します。

クリックとタイマーの両方を有効にすれば、クリックでもタイマー待ちでもスライドを進められます。タイマーのみ使用する場合は、[setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) に `False` を渡します。遅延はスライドショーが進むタイミングを決めるもので、ビジュアル遷移効果の長さを設定するものではありません。

この例は最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するよう設定します。マウスクリックでもこれらのスライドは進められます。`input.pptx` に最低 3 枚のスライドが必要です。

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

タイマー進行が有効か確認するには、[getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) を呼び出します。遅延が保存されているだけでは、タイマーがアクティブであることを示しません。

次の例は上記で保存したファイルを開き、各スライドのタイマーが有効かを報告し、2 秒を超える遅延があるスライドの自動進行を無効にします。これらのスライドはクリックで進められるようにし、更新された設定を保存します。

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

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) を使用して、遷移効果の正確な長さをミリ秒単位で指定します。スライドの [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) メソッドは、[SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) を介してこれらの設定を公開します。

| メソッド | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | 遷移効果自体の長さ（ミリ秒）を設定します。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | スライドが自動的に進むまでの遅延時間（ミリ秒）を設定します。自動タイマーを有効にするには [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) に `True` を渡します。 |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) 列挙から事前定義された速度（Slow、Medium、Fast）を選択します。明示的な期間が指定されていない場合に使用されます。 |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) は遷移効果のみを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定します。明示的な期間が設定されていない場合、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) の値から効果の長さを算出します。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*共有サンプルは各スライドに 750 ms の Fade 遷移を与え、別途 5,000 ms の自動進行を有効にしています。遷移期間は効果を制御し、進行はスライドを離れるタイミングを制御します。これらのバーは測定された合成タイムラインではなく、概念的な設定を示すものです。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同一期間を適用する**

一定のペースを保つため、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の期間を設定します。さらに自動進行を 5,000 ミリ秒後に有効にし、マウスクリックによる進行は無効にして、結果を PPTX として保存します。

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

        # エフェクトの期間とは別に自動進行を設定します。
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **スライドごとに異なる期間を設定する**

スライドごとに異なる効果期間を設定できます。たとえば、タイトルスライドは短い遷移にし、セクション紹介スライドは長めの遷移にします。この例は最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒の期間を設定します。`input.pptx` に少なくとも 2 枚のスライドが必要です。

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

### **アニメーション出力と遷移を連携させる**

[animated GIF](/slides/ja/python-java/convert-powerpoint-to-animated-gif/) や [HTML5 プレゼンテーション](/slides/ja/python-java/export-to-html5/)、[ビデオ](/slides/ja/python-java/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確な遷移期間を設定して意図したペースに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF とビデオの場合は、効果期間に合わせてフレームレートを調整します。600 ミリ秒は 30fps で 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション遷移を有効にします。選択したエクスポート形式がサポートする効果とタイミングオプションを確認し、プレビューで同期を確認してください。

### **既存の遷移期間を読む**

遷移を変更する前に [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) を呼び出して、明示的な値が保存されているか確認します。`-1` は明示的な期間が設定されていないことを示し、0 以上の値はミリ秒単位の保存期間を表します。未設定の値は再生時間の計算結果ではなく、Aspose.Slides は遷移タイプと [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) の値から期間を算出します。遷移タイプを設定すると期間が初期化されることがあるため、まず元の設定を確認してください。

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

Morph 遷移は連続するスライド間のオブジェクトの変更をアニメーション化します。シンプルな Morph 効果を作成するには、スライドをクローンし、クローン上でオブジェクトを移動またはサイズ変更し、2 番目のスライドに Morph 遷移を適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーションされます。

以下の例はテキスト矩形を含むスライドを作成し、スライドをクローンしてクローン上で矩形の位置とサイズを変更します。次に、2 番目のスライドの [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列挙から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存ファイルを開くと、スライドショー中に効果を確認できます。

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

## **Morph 遷移のタイプ**

[TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) 列挙は、Morph がコンテンツを一致させてアニメーション化する方法を制御します。

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) は各シェイプを全体として扱います。
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) は可能な限り単語単位でテキストをアニメーション化します。
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) は可能な限り文字単位でテキストをアニメーション化します。

[setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) で Morph を選択し、[getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) にアクセスします。取得した値は [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) クラスのインスタンスで、[setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) メソッドで一致モードを選択できます。

この例は前節で作成したプレゼンテーションを開き、2 番目のスライドに単語ベースの Morph アニメーションを設定します。

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

## **遷移効果を設定する**

一部の遷移は方向や黒画面から開始するかどうかなど、追加オプションを提供します。利用できるオプションは [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) で選択した遷移に依存します。まずタイプを設定し、次に [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) で取得した適切なクラスを使用します。

以下の例は `input.pptx` の最初のスライドに Cut 遷移を適用します。さらに [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) の [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) を呼び出し、遷移を黒画面から開始させます。

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

**スライド遷移の再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果時間が必要な場合は [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）で十分で、明示的な期間を設定しない場合は [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) を使用します。これらの設定は自動進行遅延とは独立して遷移効果を制御します。

**遷移に音声を添付し、ループさせることはできますか？**

はい。[setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) で埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) 列挙の `StartSound` を [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) に渡し、[setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) に `True` を指定します。音声は次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は？**

プレゼンテーションの [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) コレクションをループし、各スライドの遷移に対して同じ値で [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) を呼び出します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で動作を統一できます。

**現在のスライドに設定されている遷移を確認するには？**

スライドの [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) の結果に対して [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) を呼び出します。返されるのは [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 列挙の値で、`None_` は遷移効果が適用されていないことを示します。