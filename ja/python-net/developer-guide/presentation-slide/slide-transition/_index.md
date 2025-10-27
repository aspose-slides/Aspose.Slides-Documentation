---
title: Pythonを使用したプレゼンテーションのスライド遷移の管理
linktitle: スライド遷移
type: docs
weight: 90
url: /ja/python-net/slide-transition/
keywords:
- slide transition
- add slide transition
- apply slide transition
- advanced slide transition
- morph transition
- transition type
- transition effect
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で PowerPoint および OpenDocument プレゼンテーションのスライド遷移をカスタマイズする方法をステップバイステップで解説します。"
---

## **概要**

Aspose.Slides for Python は、遷移タイプの選択からタイミングやトリガーの設定まで、スライド遷移を完全に制御できます。スライドをクリック時または指定した遅延後に進めることができ、黒からのカットや方向性エントランスなどの効果で視覚的な振る舞いを細かく調整できます。また、PowerPoint 2019 で導入された Morph 遷移もサポートしており、オブジェクト、単語、文字単位でのモーフィングによりスムーズで統一感のあるスライド間アニメーションを実現します。

## **スライド遷移の追加**

この例では、Aspose.Slides for Python を使用してシンプルなスライド遷移を管理する方法を示します。開発者はスライドにさまざまな遷移効果を適用し、その動作をカスタマイズできます。シンプルなスライド遷移を作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の効果のいずれかを使用してスライド遷移を適用します。  
1. 変更したプレゼンテーションファイルを保存します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、プレゼンテーション ファイルをロードします。
with slides.Presentation("sample.pptx") as presentation:
    # スライド 1 にサークル遷移を適用します。
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # スライド 2 にコーム遷移を適用します。
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **高度なスライド遷移の追加**

前のセクションではシンプルな遷移効果をスライドに適用しました。ここでは、遷移をより細かく制御し、洗練された動作にする手順を示します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 列挙体の効果のいずれかを使用してスライド遷移を適用します。  
1. 遷移を「クリック時に進む」(Advance On Click)、「指定時間後に進む」(Advance After Time) のいずれか、または両方に設定します。  
1. 変更したプレゼンテーション ファイルを保存します。

**Advance On Click** が有効な場合、ユーザーがクリックしたときにのみスライドが進みます。**Advance After Time** プロパティが設定されている場合、指定した時間が経過すると自動的にスライドが進みます。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、プレゼンテーション ファイルを開きます。
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # スライド 1 にサークル遷移を適用します。
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # クリック時に進むことを有効にし、3 秒の自動進行を設定します。
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # スライド 2 にコーム遷移を適用します。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # クリック時に進むことを有効にし、5 秒の自動進行を設定します。
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # スライド 3 にズーム遷移を適用します。
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # クリック時に進むことを有効にし、7 秒の自動進行を設定します。
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 遷移**

Aspose.Slides for Python は、[Morph 遷移](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) をサポートしており、スライド間のスムーズな移動をアニメーション化します。このセクションでは Morph 遷移の使用方法を解説します。効果的に使用するには、少なくとも 1 つの共通オブジェクトを持つ 2 枚のスライドが必要です。最も簡単な方法は、スライドを複製し、2 枚目のスライドでオブジェクトの位置を変更することです。

以下のコードスニペットは、テキストを含むスライドを複製し、2 枚目のスライドに Morph 遷移を適用する例です。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # 最初のスライドをクローンして、同じシェイプを持つ 2 枚目のスライドを作成します。
    slide1 = presentation.slides.add_clone(slide0)

    # 2 枚目のスライドの同じ矩形を選択し、位置とサイズを変更します。
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # 2 枚目のスライドに Morph 遷移を有効にし、シェイプの変化をスムーズにアニメーション化します。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 遷移タイプ**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列挙体は、Morph スライド遷移のさまざまなタイプを表します。

以下のコードスニペットは、スライドに Morph 遷移を適用し、モーフ タイプを変更する例です。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **遷移効果の設定**

Aspose.Slides for Python では、**From Black**、**From Left**、**From Right** などの遷移効果を設定できます。遷移効果を構成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. スライドへの参照を取得します。  
1. 任意の遷移効果を設定します。  
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、いくつかの遷移効果を設定しています。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、プレゼンテーション ファイルを開きます。
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

はい。遷移の [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) を [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) 設定（例：slow/medium/fast）で指定できます。

**遷移にオーディオを付けてループさせることはできますか？**

はい。遷移用のサウンドを埋め込み、sound、sound_mode、sound_loop などの設定や、sound_is_built_in、sound_name といったメタデータで挙動を制御できます。

**すべてのスライドに同じ遷移を一括適用する最速の方法は？**

各スライドの遷移設定で目的の遷移タイプを構成します。遷移はスライド単位で保存されるため、すべてのスライドに同じタイプを設定すれば一貫した結果が得られます。

**現在のスライドに設定されている遷移を確認するには？**

スライドの [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) を調べ、[transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) を取得します。その値が適用されている遷移効果を示します。