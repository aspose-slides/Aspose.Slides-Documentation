---
title: アニメーション
type: docs
weight: 100
url: /ja/python-net/examples/elements/animation/
keywords:
- アニメーション
- アニメーションの追加
- アニメーションへのアクセス
- アニメーションの削除
- アニメーションシーケンス
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で Aspose.Slides を使用してスライド アニメーションをマスターし、効果、タイミング、トリガーを追加、編集、削除して、PPT、PPTX、ODP で動的なプレゼンテーションを作成します。"
---
**Aspose.Slides for Python via .NET** を使用して、シンプルなアニメーションの作成とシーケンスの管理方法を示します。

## **アニメーションの追加**

矩形シェイプを作成し、クリックでトリガーされるフェード効果を適用します。

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # フェードイン効果を追加します。
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **アニメーションへのアクセス**

スライドのタイムラインから最初のアニメーション効果を取得します。

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # 最初のアニメーション効果にアクセスします。
        effect = slide.timeline.main_sequence[0]
```

## **アニメーションの削除**

シーケンスからアニメーション効果を削除します。

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # メインシーケンスに少なくとも1つのエフェクトが含まれていると仮定します。
        effect = slide.timeline.main_sequence[0]

        # エフェクトを削除します。
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **アニメーションのシーケンス**

複数の効果を追加し、アニメーションが実行される順序を示します。

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```