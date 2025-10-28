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
- モーフ トランジション
- トランジション タイプ
- トランジション 効果
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で PowerPoint および OpenDocument プレゼンテーションのスライド トランジションをカスタマイズする方法を、ステップバイステップで解説します。"
---

## **概要**

Aspose.Slides for Python は、トランジション タイプの選択からタイミングやトリガーの設定まで、スライド トランジションを完全に制御できます。クリック時や指定した遅延時間後にスライドを進めることができ、黒からのカットや方向別のエントランスなどの効果で視覚的な挙動を細かく調整できます。また、PowerPoint 2019 で導入されたモーフ トランジションもサポートしており、オブジェクト、単語、文字単位でのモーフにより、スライド間の滑らかで一貫した動きを実現できます。

## **スライド トランジションの追加**

この例では、Aspose.Slides for Python を使用してシンプルなスライド トランジションを管理する方法を示します。開発者はスライドにさまざまなトランジション効果を適用し、その動作をカスタマイズできます。シンプルなスライド トランジションを作成する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体のいずれかの効果を使用してスライド トランジションを適用します。  
1. 変更したプレゼンテーション ファイルを保存します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーション ファイルを読み込みます。
with slides.Presentation("sample.pptx") as presentation:
    # スライド 1 にサークル トランジションを適用します。
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # スライド 2 にコーム トランジションを適用します。
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **高度なスライド トランジションの追加**

前節ではシンプルなトランジション効果をスライドに適用しました。ここでは、効果をより制御し洗練させる手順を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体のいずれかの効果を使用してスライド トランジションを適用します。  
1. 「クリックで進む」か「指定時間後に自動進む」か、または両方を設定します。  
1. 変更したプレゼンテーション ファイルを保存します。

**Advance On Click** が有効な場合、ユーザーがクリックしたときだけスライドが進みます。**Advance After Time** プロパティを設定すると、指定した間隔の後に自動でスライドが進みます。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーション ファイルを開きます。
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # スライド 1 にサークル トランジションを適用します。
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # クリックで進むようにし、3 秒後に自動進むよう設定します。
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # スライド 2 にコーム トランジションを適用します。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # クリックで進むようにし、5 秒後に自動進むよう設定します。
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # スライド 3 にズーム トランジションを適用します。
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # クリックで進むようにし、7 秒後に自動進むよう設定します。
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **モーフ トランジション**

Aspose.Slides for Python は、スライド間の滑らかな移動をアニメーション化する [Morph トランジション](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) をサポートしています。このセクションでは、モーフ トランジションの使用方法を説明します。効果的に利用するには、共通のオブジェクトが少なくとも 1 つある 2 枚のスライドが必要です。最も簡単な方法は、スライドを複製し、2 枚目のスライドでオブジェクトの位置を変更することです。

以下のコードスニペットは、テキストを含むスライドをクローンし、2 枚目のスライドにモーフ トランジションを適用する例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # 1 枚目のスライドを複製して、モーフ の連続性を保つ 2 枚目のスライドを作成します。
    slide1 = presentation.slides.add_clone(slide0)

    # 2 枚目のスライドで同じ長方形を選択し、位置とサイズを変更します。
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # 2 枚目のスライドにモーフ トランジションを有効にし、形状の変化を滑らかにアニメーション化します。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **モーフ トランジションの種類**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、モーフ スライド トランジションの種類を表します。

以下のコードスニペットは、スライドにモーフ トランジションを適用し、モーフ タイプを変更する例です。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **トランジション効果の設定**

Aspose.Slides for Python では、**From Black**、**From Left**、**From Right** などのトランジション効果を設定できます。トランジション効果を構成する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. スライドへの参照を取得します。  
1. 希望するトランジション効果を設定します。  
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、いくつかのトランジション効果を設定しています。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーション ファイルを開きます。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # カット トランジションを適用し、From Black を有効にします。
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**スライド トランジションの再生速度を制御できますか？**

はい。[TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) 設定を使用してトランジションの [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)（例：slow/medium/fast）を設定できます。

**トランジションに音声を添付し、ループさせることは可能ですか？**

はい。トランジション用にサウンドを埋め込み、sound、sound_mode、sound_loop などの設定で動作を制御できます（例：[sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)、[sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)、[sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)、さらに [sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) や [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/) などのメタデータも利用できます）。

**すべてのスライドに同じトランジションを適用する最速の方法は？**

各スライドのトランジション設定で希望のトランジション タイプを設定すれば、スライドごとに保存されるため、全スライドに同一のトランジションを適用できます。

**現在のスライドに設定されているトランジションを確認する方法は？**

スライドの [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) を調べ、その [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を取得すれば、どの効果が適用されているか正確に分かります。