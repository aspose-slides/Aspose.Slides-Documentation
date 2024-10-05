---
title: スライド遷移
type: docs
weight: 90
url: /python-net/slide-transition/
keywords: "スライド遷移の追加, PowerPointスライド遷移, モーフ遷移, 高度なスライド遷移, 遷移効果, Python, Aspose.Slides"
description: "PythonでPowerPointスライド遷移と遷移効果を追加する"
---

## **スライド遷移の追加**
理解を容易にするために、Aspose.Slides for Python via .NETを使用して簡単なスライド遷移を管理する方法を示しました。開発者はスライドに異なるスライド遷移効果を適用できるだけでなく、これらの遷移効果の動作をカスタマイズすることもできます。簡単なスライド遷移効果を作成するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. TransitionType列挙型を使用して、Aspose.Slides for Python via .NETが提供する遷移効果の1つからスライドにスライド遷移のタイプを適用します。
1. 修正されたプレゼンテーションファイルを書き込みます。

```py
import aspose.slides as slides

# ソースプレゼンテーションファイルを読み込むためにPresentationクラスのインスタンスを生成
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # スライド1に円形遷移を適用
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # スライド2にコンボタイプ遷移を適用
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # プレゼンテーションをディスクに書き込む
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **高度なスライド遷移の追加**
上のセクションでは、スライドに簡単な遷移効果を適用しました。今度は、その簡単な遷移効果をさらに向上させ、制御するために、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. Aspose.Slides for Python via .NETが提供する遷移効果の1つからスライドにスライド遷移のタイプを適用します。
1. 遷移を「クリックで進む」設定、特定の時間後、またはその両方に設定することもできます。
1. スライド遷移が「クリックで進む」に設定されている場合、マウスがクリックされたときのみ遷移が進みます。さらに、Advance After Timeプロパティが設定されている場合、指定された進む時間が経過した後に遷移が自動的に進みます。
1. 修正されたプレゼンテーションをプレゼンテーションファイルとして書き込みます。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # スライド1に円形遷移を適用
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE


    # 遷移時間を3秒に設定
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # スライド2にコンボタイプ遷移を適用
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB


    # 遷移時間を5秒に設定
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # スライド3にズームタイプ遷移を適用
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM


    # 遷移時間を7秒に設定
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # プレゼンテーションをディスクに書き込む
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **モーフ遷移**
Aspose.Slides for Python via .NETは現在、 [Morph Transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) をサポートしています。これはPowerPoint 2019で導入された新しいモーフ遷移を表します。モーフ遷移により、1つのスライドから次のスライドへのスムーズな動きをアニメーション化できます。この記事では、モーフ遷移の概念とその使用法について説明します。モーフ遷移を効果的に使用するには、少なくとも1つの共通のオブジェクトを持つ2つのスライドが必要です。最も簡単な方法は、スライドを複製し、次のスライドでオブジェクトを別の場所に移動することです。

次のコードスニペットは、プレゼンテーションにテキストを含むスライドのクローンを追加し、2番目のスライドに [morph type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) の遷移を設定する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "PowerPointプレゼンテーションでのモーフ遷移"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **モーフ遷移の種類**
新しい [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 列挙体が追加されました。これは、異なる種類のモーフスライド遷移を表します。

TransitionMorphType列挙体には3つのメンバーがあります：

- ByObject: モーフ遷移は、形状を不可分のオブジェクトとして考慮して実行されます。
- ByWord: モーフ遷移は、可能な場合に単語ごとにテキストを転送して実行されます。
- ByChar: モーフ遷移は、可能な場合に文字ごとにテキストを転送して実行されます。

次のコードスニペットは、スライドにモーフ遷移を設定し、モーフタイプを変更する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **遷移効果の設定**
Aspose.Slides for Python via .NETは、黒から、左から、右からなどの遷移効果の設定をサポートしています。遷移効果を設定するには、以下の手順に従ってください：

- [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- スライドの参照を取得します。
- 遷移効果を設定します。
- プレゼンテーションを [PPTX ](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

以下の例では、遷移効果を設定しました。

```py
import aspose.slides as slides

# Presentationクラスのインスタンスを生成
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # 効果を設定
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # プレゼンテーションをディスクに書き込む
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```