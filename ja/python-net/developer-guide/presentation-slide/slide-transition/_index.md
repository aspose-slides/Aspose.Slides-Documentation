---
title: Python を使用してプレゼンテーションのスライド遷移を管理する
linktitle: スライド遷移
type: docs
weight: 90
url: /ja/python-net/slide-transition/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してスライド遷移を適用し、自動スライド進行を構成し、Morph やその他の遷移効果をカスタマイズします。"
---
## **概要**

スライド遷移はスライドショー中のスライドの表示方法を制御します。Aspose.Slides for Python via .NET を使用すると、各スライドに遷移効果を選択し、マウスクリックまたはタイマーによる進行を設定し、効果固有のオプションを調整できます。この記事では、Python の例を使用して遷移を適用し、正確な遷移時間を設定し、スライドのタイミングを管理し、2 つのスライド間に Morph 遷移を作成します。例では設定を PPTX ファイルに保存する方法も示しています。

## **スライド遷移の追加**

遷移を適用するには、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスでプレゼンテーションをロードし、スライドの [slide_show_transition](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/slide_show_transition/) プロパティにアクセスします。その [type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/type/) を [TransitionType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の値に設定し、プレゼンテーションを保存します。

次の例は、最初のスライドに Circle 遷移を、2 番目のスライドに Comb 遷移を適用します。2 つ以上のスライドがある `input.pptx` ファイルを使用してください。

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

## **高度なスライド遷移の追加**

スライドが画面に表示される時間や、マウスクリックでスライドショーを進めるかどうかを構成できます。以下のプロパティがこの動作を制御します：

- [advance_on_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) ビューアがマウスクリックで進めることを許可します。
- [advance_after](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 自動的に進めることを可能にします。
- [advance_after_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) 自動的に進むまでの遅延時間（ミリ秒単位）を指定します。

クリックとタイマーの両方の進行を有効にすると、ビューアはクリックで進めるか、タイマー待ちで進めることができます。タイマーのみを使用する場合は、[advance_on_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) を `False` に設定します。遅延はスライドショーが進むタイミングを制御しますが、ビジュアル遷移効果の長さは設定しません。

この例では、最初の 3 枚のスライドに異なる効果を割り当て、3 秒、5 秒、7 秒後に自動的に進むように設定します。マウスクリックでもこれらのスライドを進めることができます。3 枚以上のスライドがある `input.pptx` ファイルを使用してください。

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

タイマー進行が有効かどうかを確認するには、[advance_after](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) を読み取ります。保存された遅延だけではタイマーがアクティブであることを示しません。

次の例では、上で保存したファイルを開き、各有効なタイマーを報告し、遅延が 2 秒を超えるスライドの自動進行を無効にします。そのスライドではマウスクリックを有効にし、更新された設定を保存します。

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

## **遷移タイミングを正確に制御する**

[duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/duration/) を使用して、遷移効果の正確な長さをミリ秒単位で指定します。スライドの [slide_show_transition](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/slide_show_transition/) プロパティは、これらの設定を [SlideShowTransition](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/) を通じて公開します：

| プロパティ | 目的 |
| --- | --- |
| [duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | 遷移効果自体の継続時間をミリ秒単位で設定します。 |
| [advance_after_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | スライドが自動的に進むまでの遅延をミリ秒単位で設定します。このタイマーを有効にするには [advance_after](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) を有効にします。 |
| [speed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitionspeed/) から事前定義された速度カテゴリ（SLOW、MEDIUM、FAST）を選択します。正確な継続時間が指定されていない場合に使用されます。 |

[duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/duration/) は遷移効果のみを制御し、スライドが表示され続ける時間は決定しません。自動進行の遅延は別途設定してください。明示的な duration が設定されていない場合、Aspose.Slides は遷移タイプと [speed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/speed/) の値から効果の継続時間を決定します。

### **すべてのスライドに同じ継続時間を適用する**

一定のペースを保つために、すべてのスライドに同じ効果と正確な継続時間を適用します。この例では `input.pptx` をロードし、[TransitionType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitiontype/) から Fade を選択し、各遷移に 750 ミリ秒の継続時間を設定します。また、5,000 ミリ秒後に自動進行を有効にし、マウスクリックによる進行を無効にして、結果を PPTX として保存します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # 効果の継続時間に依存せずに自動進行を設定します。
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **個々のスライドに異なる継続時間を設定する**

スライドごとに異なる効果の継続時間を使用できます。たとえば、タイトルスライドには短い遷移、セクション紹介には長い遷移を使用します。この例では、最初のスライドに 500 ミリ秒、2 番目のスライドに 1,200 ミリ秒を設定します。2 枚以上のスライドがある `input.pptx` ファイルを使用してください。

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

### **アニメーション出力と遷移を調整する**

[animated GIF](/slides/ja/python-net/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/ja/python-net/export-to-html5/)、または [video](/slides/ja/python-net/convert-powerpoint-to-video/) を作成する際は、エクスポート前に正確な遷移継続時間を設定して意図したペースに合わせます。例えば、シーン間に 600 ミリ秒のフェードを使用し、各スライドの進行遅延を個別に調整してナレーションやコンテンツの時間を確保します。

GIF およびビデオの場合、出力フレームレートを効果の継続時間と合わせます。600 ミリ秒は 30 fps の場合 18 フレームに相当します。HTML5 では、エクスポート設定でアニメーション遷移を有効にします。選択したエクスポート形式がサポートする効果やタイミングオプションを確認し、出力をプレビューして同期を確認してください。

### **既存の遷移継続時間を取得する**

遷移を変更する前に [duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/duration/) を読み取り、明示的な値が保存されているか確認します。`-1` の値は明示的な継続時間が設定されていないことを意味し、0 以上の値はミリ秒単位で保存された継続時間を示します。未設定の値は計算された再生時間ではありません。Aspose.Slides は遷移タイプと [speed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/speed/) を使用してその継続時間を決定します。遷移タイプを設定すると継続時間が初期化されることがあるため、最初に元の設定を確認してください。

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

## **Morph 遷移**

Morph 遷移は、連続するスライド間のオブジェクトの変化をアニメーション化します。シンプルな Morph 効果を作成するには、スライドを複製し、複製上のオブジェクトを移動またはサイズ変更し、2 枚目のスライドに Morph 遷移を適用します。これにより、遷移は元の状態と変更後の状態の間で対応するオブジェクトをアニメーションさせます。

以下の例では、テキスト矩形を含むスライドを作成し、スライドを複製して、複製上の矩形の位置とサイズを変更します。その後、2 枚目のスライドの [TransitionType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitiontype/) 列挙体から Morph を選択します。Morph をサポートするプレゼンテーションビューアで保存されたファイルを開くと、スライドショー中に効果を確認できます。

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

## **Morph 遷移タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、Morph がコンテンツをどのようにマッチングしアニメーション化するかを制御します：

- [BY_OBJECT](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitionmorphtype/) 各シェイプを個別のオブジェクトとして扱います。
- [BY_WORD](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitionmorphtype/) 可能な場合、単語単位でテキストをマッチングしてアニメーション化します。
- [BY_CHAR](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitionmorphtype/) 可能な場合、文字単位でテキストをマッチングしてアニメーション化します。

遷移の [type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/type/) を Morph に設定した後、[value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/value/) にアクセスします。これにより [MorphTransition](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/morphtransition/) オブジェクトが取得でき、[morph_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/morphtransition/morph_type/) プロパティでマッチングモードを選択します。

この例では、前のセクションで作成したプレゼンテーションを開き、2 枚目のスライドを単語ベースの Morph アニメーションになるよう設定します。

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

## **遷移効果の設定**

一部の遷移では、方向や効果がブラック画面から開始するかどうかなどの追加オプションが公開されています。利用可能なオプションは選択された遷移の [type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/type/) に依存します。まず type を設定し、その後 [value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/value/) から適切な遷移オブジェクトを使用します。

以下の例では、`input.pptx` の最初のスライドに Cut 遷移を適用します。[OptionalBlackTransition](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/optionalblacktransition/) の [from_black](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) を設定し、遷移がブラック画面から開始するようにします。

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

**スライド遷移の再生速度を制御できますか？**

はい。ミリ秒単位で正確な効果の継続時間が必要な場合は [duration](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/duration/) を優先してください。事前定義された [TransitionSpeed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitionspeed/) カテゴリ（SLOW、MEDIUM、FAST）が十分で、明示的な継続時間が設定されていない場合は [speed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/speed/) を使用します。これらの設定は自動進行遅延とは独立して遷移効果を制御します。

**遷移に音声を添付してループさせることはできますか？**

はい。[sound](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/sound/) に埋め込み音声を割り当て、[TransitionSoundMode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitionsoundmode/) 列挙体の START_SOUND を [sound_mode](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) に設定し、[sound_loop](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) を有効にします。音声はスライドショー内の次のサウンドイベントが発生するまでループします。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

プレゼンテーションの [slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slides/ja/) コレクションをループし、各スライドの遷移 [type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/type/) を同じ値に設定します。同じループ内でタイミングや効果オプションも設定すれば、スライド間で動作を一貫させることができます。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [slide_show_transition](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/slide_show_transition/) から [type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/slideshowtransition/type/) プロパティを読み取ります。これにより [TransitionType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の値が返されます。NONE は遷移効果が適用されていないことを意味します。