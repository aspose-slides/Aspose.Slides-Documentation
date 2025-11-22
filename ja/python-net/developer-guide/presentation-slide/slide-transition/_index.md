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
- モーフ遷移
- 遷移タイプ
- 遷移効果
- Python
- Aspose.Slides
description: ".NET 経由で Aspose.Slides for Python のスライド遷移をカスタマイズする方法を、PowerPoint および OpenDocument プレゼンテーション向けのステップバイステップガイドとともに紹介します。"
---

## **概要**

Aspose.Slides for Python は、遷移タイプの選択からタイミングやトリガーの設定まで、スライド遷移をフルコントロールできる機能を提供します。クリック時や指定した遅延時間後にスライドを進める設定が可能で、黒からのカットや方向性のあるエントランスなどの効果で視覚的な挙動を細かく調整できます。また、本ライブラリは PowerPoint 2019 で導入された Morph 遷移もサポートし、オブジェクト、単語、文字単位でのモーフィングにより、スライド間の滑らかで一貫した動きを実現します。

## **スライド遷移の追加**

この例では、Aspose.Slides for Python を使用してシンプルなスライド遷移を管理する方法を示します。開発者はスライドにさまざまな遷移効果を適用し、その動作をカスタマイズできます。シンプルなスライド遷移を作成するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体のいずれかの効果を使用してスライド遷移を適用します。
1. 変更されたプレゼンテーション ファイルを保存します。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーションファイルを読み込みます。
with slides.Presentation("sample.pptx") as presentation:
    # スライド 1 に円形遷移を適用します。
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # スライド 2 にコーム遷移を適用します。
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **高度なスライド遷移の追加**

前節ではシンプルな遷移効果をスライドに適用しました。ここでは、その効果をより細かく制御し、洗練させる手順を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体のいずれかの効果を使用してスライド遷移を適用します。
1. 遷移を「クリック時に進む」「指定時間後に進む」またはその両方に設定します。
1. 変更されたプレゼンテーション ファイルを保存します。

**Advance On Click** が有効な場合、ユーザーがクリックしたときだけスライドが進みます。**Advance After Time** プロパティが設定されている場合、指定した間隔の後にスライドが自動的に進みます。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーションファイルを開きます。
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # スライド 1 に円形遷移を適用します。
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # クリックで進むように有効にし、3 秒の自動進行を設定します。
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # スライド 2 にコーム遷移を適用します。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # クリックで進むように有効にし、5 秒の自動進行を設定します。
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # スライド 3 にズーム遷移を適用します。
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # クリックで進むように有効にし、7 秒の自動進行を設定します。
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **モーフ遷移**

Aspose.Slides for Python は、スライド間のスムーズな動きを実現する [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) をサポートします。本節では Morph 遷移の使用方法を説明します。効果的に使用するには、少なくとも 1 つの共通オブジェクトを持つ 2 枚のスライドが必要です。最も簡単な方法は、スライドを複製して、2 枚目のスライドでオブジェクトの位置を変更することです。

次のコード スニペットは、テキストを含むスライドをクローンし、2 枚目のスライドに Morph 遷移を適用する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Morph の連続性を保つために、最初のスライドをクローンして同じシェイプを持つ2枚目のスライドを作成します。
    slide1 = presentation.slides.add_clone(slide0)

    # 2枚目のスライドで同じ長方形を選択し、位置とサイズを変更します。
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # 2枚目のスライドで Morph 遷移を有効にし、シェイプの変更をスムーズにアニメーションさせます。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **モーフ遷移の種類**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、Morph スライド遷移のさまざまなタイプを表します。

次のコード スニペットは、スライドに Morph 遷移を適用し、モーフ タイプを変更する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **遷移効果の設定**

Aspose.Slides for Python では、**From Black**、**From Left**、**From Right** などの遷移効果を設定できます。遷移効果を構成するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドへの参照を取得します。
1. 希望する遷移効果を設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、複数の遷移効果を設定しています。
```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成してプレゼンテーションファイルを開きます。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Cut 遷移を適用し、From Black を有効にします。
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **よくある質問**

**スライド遷移の再生速度を制御できますか？**

はい。遷移の [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) を [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) 設定（例: slow/medium/fast）で指定できます。

**遷移に音声を添付してループさせることはできますか？**

はい。遷移用のサウンドを埋め込み、サウンドモードやループなどの設定（[sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/)、[sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/)、[sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)）や、[sound_is_built_in](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) や [sound_name](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/) といったメタデータで制御できます。

**すべてのスライドに同じ遷移を最速で適用する方法は？**

各スライドの遷移設定で目的の遷移タイプを設定します。遷移はスライド単位で保存されるため、すべてのスライドに同じタイプを設定すれば一貫した結果が得られます。

**スライドに現在設定されている遷移を確認するには？**

スライドの [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) を調べ、[transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を取得します。その値が現在適用されている効果を示します。