---
title: "プレゼンテーションでスライド遷移をPythonで管理する"
linktitle: "スライド遷移"
type: docs
weight: 90
url: /ja/python-net/slide-transition/
keywords:
- スライド遷移
- スライド遷移の追加
- スライド遷移の適用
- 高度なスライド遷移
- モーフ遷移
- 遷移タイプ
- 遷移効果
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのスライド遷移をカスタマイズする方法をステップバイステップで解説します。"
---

## **概要**

Aspose.Slides for Python は、スライド遷移のタイプ選択からタイミングやトリガーの設定まで、完全な制御を提供します。スライドをクリック時または指定した遅延後に進めるように設定でき、黒からのカットや方向性のある入場効果などで視覚的な挙動を細かく調整できます。また、PowerPoint 2019 で導入されたモーフ遷移もサポートしており、オブジェクト、単語、文字単位でのモーフによりスライド間の滑らかで一体感のある動きを実現します。

## **スライド遷移の追加**

この例では、Aspose.Slides for Python を使用してシンプルなスライド遷移を管理する方法を示します。開発者はスライドにさまざまな遷移効果を適用し、その動作をカスタマイズできます。シンプルなスライド遷移を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の効果のいずれかを使用してスライド遷移を適用します。
3. 変更したプレゼンテーション ファイルを保存します。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    # スライド 1 にサークル遷移を適用します。
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # スライド 2 にコーム遷移を適用します。
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **高度なスライド遷移の追加**

このセクションでは、スライドにシンプルな遷移効果を適用しました。より制御された洗練された効果にするには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の効果のいずれかを使用してスライド遷移を適用します。
3. 遷移をクリック時に進めるか、特定の時間後に自動進行させるか、またはその両方を設定します。
4. 変更したプレゼンテーション ファイルを保存します。

**Advance On Click** が有効な場合、ユーザーがクリックしたときにのみスライドが進みます。**Advance After Time** プロパティが設定されている場合、指定された間隔の後に自動的にスライドが進みます。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # スライド 1 にサークル遷移を適用します。
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # クリックで進むように有効化し、3 秒の自動進行を設定します。
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # スライド 2 にコーム遷移を適用します。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # クリックで進むように有効化し、5 秒の自動進行を設定します。
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # スライド 3 にズーム遷移を適用します。
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # クリックで進むように有効化し、7 秒の自動進行を設定します。
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **モーフ遷移**

Aspose.Slides for Python は、[Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) をサポートしており、スライド間の滑らかな動きをアニメーション化します。このセクションでは、Morph 遷移の使用方法を説明します。効果的に使用するには、共通のオブジェクトを少なくとも1つ含む2つのスライドが必要です。最も簡単な方法は、スライドを複製し、2番目のスライドでオブジェクトの位置を変更することです。

以下のコードスニペットは、テキストを含むスライドをクローンし、2番目のスライドに Morph 遷移を適用する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Morph の連続性を保つために、同じシェイプを持つ第2スライドを作成するために最初のスライドをクローンします。
    slide1 = presentation.slides.add_clone(slide0)

    # 第2スライド上の同じ長方形を選択し、位置とサイズを変更します。
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # 第2スライドで Morph 遷移を有効にし、シェイプの変更をスムーズにアニメーションします。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **モーフ遷移タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、さまざまなモーフ スライド遷移タイプを表します。

以下のコードスニペットは、スライドにモーフ遷移を適用し、モーフタイプを変更する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **遷移効果の設定**

Aspose.Slides for Python では、**From Black**、**From Left**、**From Right** などの遷移効果を設定できます。遷移効果を構成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. 希望する遷移効果を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、いくつかの遷移効果を設定しています。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # カット遷移を適用し、From Black を有効にします。
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**スライド遷移の再生速度を制御できますか？**

はい。遷移の [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) を [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) 設定で設定します（例: slow/medium/fast）。

**遷移にオーディオを添付してループさせることはできますか？**

はい。遷移用にサウンドを埋め込み、サウンドモードやループ設定などで動作を制御できます（例: [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)、[sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)、[sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)、さらに [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) や [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/) などのメタデータも設定可能です）。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

各スライドの遷移設定で希望の遷移タイプを構成すればよいです。遷移はスライドごとに保存されるため、すべてのスライドに同じタイプを設定すれば一貫した結果が得られます。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) を調べ、その [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を確認します。その値が現在適用されている効果を正確に示します。