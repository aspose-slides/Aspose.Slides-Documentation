---
title: スライドトランジション
type: docs
weight: 110
url: /ja/python-net/examples/elements/slide-transition/
keywords:
- スライドトランジション
- スライドトランジションの追加
- スライドトランジションへのアクセス
- スライドトランジションの削除
- トランジション期間
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でスライドトランジションを制御します。タイプ、速度、サウンド、タイミングを選択して、PPT、PPTX、ODP のプレゼンテーションを磨き上げます。"
---
スライドのトランジション効果とタイミングを **Aspose.Slides for Python via .NET** で適用する方法を示します。

## **スライド トランジションの追加**

最初のスライドにフェードトランジション効果を適用します。

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # フェード トランジションを適用します。
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **スライド トランジションへのアクセス**

スライドに現在割り当てられているトランジションタイプを読み取ります。

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # トランジション タイプにアクセスします。
        transition_type = slide.slide_show_transition.type
```

## **スライド トランジションの削除**

タイプを `NONE` に設定して、すべてのトランジション効果をクリアします。

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # none に設定してトランジションを削除します。
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **トランジション期間の設定**

自動的に次のスライドへ進むまで、スライドが表示される時間を指定します。

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # ミリ秒単位です。

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```