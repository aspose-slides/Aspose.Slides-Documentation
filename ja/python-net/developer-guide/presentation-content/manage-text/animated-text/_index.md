---
title: Python で PowerPoint テキストをアニメーション化する
linktitle: アニメーション テキスト
type: docs
weight: 60
url: /ja/python-net/animated-text/
keywords:
- アニメーション テキスト
- テキスト アニメーション
- アニメーション 段落
- 段落アニメーション
- アニメーション効果
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションに動的なアニメーション テキストを作成する方法を、わかりやすく最適化されたコード例とともに紹介します。"
---

## 段落にアニメーション効果を追加する

[**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) メソッドを [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) および [**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/) クラスに追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # 効果を追加する段落を選択
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # 選択した段落にフライアニメーション効果を追加
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## 段落のアニメーション効果を取得する

段落に追加されたアニメーション効果を調べることを決定する場合があります。たとえば、あるシナリオでは、他の段落や図形にそれらの効果を適用する予定があるため、段落のアニメーション効果を取得したいとします。

Aspose.Slides for Python via .NETを使用すると、テキストフレーム（図形）に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落のアニメーション効果を取得する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("段落 \"" + paragraph.text + "\" には " + str(effects[0].type) + " 効果があります。")
```