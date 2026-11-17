---
title: Python を使用したプレゼンテーションのスライド トランジションの管理
linktitle: スライド トランジション
type: docs
weight: 90
url: /ja/python-net/slide-transition/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してスライド トランジションを適用し、自動スライド進行を構成し、Morph などのトランジション効果をカスタマイズします。"
---
## **概要**

スライド トランジションは、スライドショー中にスライドがどのように表示されるかを制御します。Aspose.Slides for Python via .NET を使用すると、各スライドに対してトランジション効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。この記事では、Python のサンプルを使ってトランジションを適用し、正確なトランジション時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph トランジションを作成する方法を示します。また、設定を PPTX ファイルに保存する方法も示しています。

## **スライド トランジションの追加**

トランジションを適用するには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、スライドの [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) プロパティにアクセスします。[type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の値に設定し、その後プレゼンテーションを保存します。

以下の例は、最初のスライドに Circle トランジションを、2 番目のスライドに Comb トランジションを適用します。スライドが少なくとも 2 枚ある `input.pptx` ファイルを使用してください。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **ホイール トランジション**

[WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) の [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) プロパティは、目的スライドを表示する放射状セクタの数を制御します。スライドのトランジション [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) から WHEEL に設定し、[WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) として [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) にアクセスします。

この例は、黒いスライドと金色の矩形があるスライドの 2 組を作成します。目的スライドはそれぞれ 1 と 8 のスポーク数を使用し、同じ [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) と 8,000 ミリ秒の明示的な [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) を設定して、差分が分かりやすくしています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

出力されたプレゼンテーションを PowerPoint で開き、スライドショーを実行します。スライド 1 から 2、続いてスライド 3 から 4 に進みます。PowerPoint の再生では、スポーク数 1 の場合は時計回りに 1 回のスイープでスライドが表示され、スポーク数 8 の場合は 8 つの放射状セクタが同時に表示されます。目的コンテンツとトランジションのタイミングは同一なので、違いは表示セクタの数だけです。

## **高度なスライド トランジションの追加**

スライドが画面に表示され続ける時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のプロパティがこの動作を制御します。

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) は、ビューアがマウスクリックで進められるようにします。  
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) は自動進行を有効にします。  
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) は自動進行までの遅延時間をミリ秒単位で指定します。

クリックとタイマーの両方を有効にすると、クリックで進めるかタイマーで進むかを選択できます。タイマーのみを使用する場合は、[advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) を `False` に設定します。遅延はスライドショーが進むタイミングを制御しますが、ビジュアルなトランジション効果の継続時間を設定するものではありません。

この例は最初の 3 枚のスライドにそれぞれ異なる効果を割り当て、3 秒、5 秒、7 秒後に自動進行するように設定します。マウスクリックでもこれらのスライドは進められます。スライドが少なくとも 3 枚ある `input.pptx` ファイルを使用してください。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

タイマー進行が有効かどうかを確認するには、[advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) を読み取ります。遅延が保存されているだけでは、タイマーが実際に動作していることを意味しません。

次の例は、上記で保存したファイルを開き、各スライドのタイマーが有効かを報告し、2 秒以上の遅延が設定されているスライドの自動進行を無効にします。そのスライドではマウスクリックを有効にし、更新された設定を保存します。

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **トランジションのタイミングを正確に制御する**

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) を使用して、トランジション効果の正確な長さをミリ秒単位で指定します。スライドの [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) プロパティは、[SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) を通じてこれらの設定を公開します。

| プロパティ | 目的 |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | トランジション効果自体の継続時間をミリ秒で設定します。 |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | スライドが自動的に進むまでの遅延時間をミリ秒で設定します。[advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) を有効にするとこのタイマーが作動します。 |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) 列挙体の SLOW、MEDIUM、FAST のいずれかのカテゴリを選択します。正確な duration が指定されていない場合に使用されます。 |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) はトランジション効果だけを制御し、スライドが画面に残る時間は決定しません。自動進行の遅延は別途設定します。明示的な duration が設定されていない場合、Aspose.Slides はトランジションタイプと [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) の値から効果時間を算出します。

<!-- visual-explanation:slide-transition:start -->
[![個別のバーが 750 ms のトランジション継続時間と 5 000 ms の自動進行設定を示しています。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*共有された例では、各スライドに 750 ms の Fade トランジションを設定し、別途自動進行を 5 000 ms 後に有効にしています。トランジション継続時間は効果を制御し、進行はスライドから離れるタイミングを制御します。これらのバーは実測されたタイムラインではなく、設定を示す概略です。*
<!-- visual-explanation:slide-transition:end -->

### **すべてのスライドに同じ期間を適用する**

一定のペースを保つために、すべてのスライドに同じ効果と正確な期間を適用します。この例は `input.pptx` を読み込み、[TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) から Fade を選択し、各トランジションに 750 ミリ秒の duration を設定します。また、5 000 ミリ秒後に自動進行を有効にし、マウスクリックによる進行を無効にして結果を PPTX として保存します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # エフェクトの継続時間とは独立して自動進行を設定します。
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **個別スライドに異なる期間を設定する**

スライドごとに異なる効果期間を使用できます。たとえば、タイトルスライドには短いトランジション、セクション導入スライドには長めのトランジションを設定します。この例は最初のスライドに 500 ミリ秒、2 番目のスライドに 1 200 ミリ秒の duration を設定します。スライドが少なくとも 2 枚ある `input.pptx` ファイルを使用してください。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **アニメーション出力とトランジションを連携させる**

[animated GIF](/slides/ja/python-net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/ja/python-net/export-to-html5/)、または [video](/slides/ja/python-net/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確なトランジション期間を設定して意図したペースに合わせます。たとえば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF とビデオの場合、効果期間に合わせてフレームレートを調整します。600 ミリ秒は 30 fps で 18 フレームに相当します。HTML5 ではエクスポート設定でアニメーション トランジションを有効にします。選択したエクスポート形式がサポートする効果とタイミング オプションを確認し、出力をプレビューして同期を確認してください。

### **既存のトランジション期間を読み取る**

トランジションを変更する前に [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) を読み取り、明示的な値が保存されているか確認します。`-1` は明示的な期間が設定されていないことを意味し、0 以上の値はミリ秒単位で保存された期間を示します。未設定の値は再生時に計算された期間ではありません。Aspose.Slides はトランジションタイプと [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) を使用して期間を決定します。トランジションタイプを設定すると期間が初期化されることがあるため、まず元の設定を調べてください。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph トランジション**

Morph トランジションは、連続するスライド間でオブジェクトの変化をアニメーション化します。シンプルな Morph 効果を作成するには、スライドをクローンし、クローン上でオブジェクトを移動またはサイズ変更し、2 枚目のスライドに Morph トランジションを適用します。これにより、元の状態と変更後の状態の間で対応するオブジェクトがアニメーション化されます。

以下の例はテキスト矩形を含むスライドを作成し、スライドをクローンしてクローン上で矩形の位置とサイズを変更します。その後、2 枚目のスライドの [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存されたファイルを開くと、スライドショー中に効果が確認できます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph トランジションの種類**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチさせてアニメーション化するかを制御します。

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) は各シェイプを全体オブジェクトとして扱います。  
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) は可能な場合に単語単位でテキストをアニメーション化します。  
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) は可能な場合に文字単位でテキストをアニメーション化します。

[TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を Morph に設定し、[value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) にアクセスして取得した [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) オブジェクトの [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) プロパティでマッチングモードを選択します。

この例は前節で作成したプレゼンテーションを開き、2 枚目のスライドで単語ベースの Morph アニメーションを使用するように設定します。

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **トランジション効果を設定する**

一部のトランジションは方向や黒画面から開始するかどうかなど、追加オプションを提供します。利用可能なオプションは選択されたトランジションの [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) に依存します。まず type を設定し、次に [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) から取得できる適切なトランジション オブジェクトを使用します。

以下の例は `input.pptx` の最初のスライドに Cut トランジションを適用します。[OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) を通じて [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) を設定し、トランジションが黒画面から開始するようにします。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**スライド トランジションの再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果時間が必要な場合は [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) を使用してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) カテゴリ（SLOW、MEDIUM、FAST）で十分で明示的な duration を設定しない場合は [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) を使用します。これらの設定は自動進行遅延とは独立してトランジション効果を制御します。

**トランジションに音声を添付してループさせることはできますか？**

はい。埋め込み音声を [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) に割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) 列挙体の START_SOUND を [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) に設定し、[sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) を有効にします。音声はスライドショー内の次のサウンド イベントが発生するまでループします。

**すべてのスライドに同じトランジションを適用する最速の方法は何ですか？**

プレゼンテーションの [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) コレクションをループし、各スライドのトランジション [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を同じ値に設定します。同じループ内でタイミングや効果オプションも設定すれば、スライド全体で動作を統一できます。

**スライドに現在設定されているトランジションを確認する方法は？**

スライドの [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) から [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) プロパティを読み取ります。返される値は [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の一つで、NONE はトランジション効果が設定されていないことを示します。