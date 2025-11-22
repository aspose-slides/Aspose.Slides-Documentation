---
title: PythonでPowerPointテキストをアニメーション化
linktitle: アニメーションテキスト
type: docs
weight: 60
url: /ja/python-net/animated-text/
keywords:
- アニメーションテキスト
- テキストアニメーション
- アニメーション段落
- 段落アニメーション
- アニメーション効果
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を .NET 経由で使用し、PowerPoint および OpenDocument プレゼンテーションで動的なアニメーションテキストを作成します。わかりやすく最適化されたコード例を提供します。"
---

## **概要**

このドキュメントでは、Aspose.Slides for Python を使用して PowerPoint プレゼンテーション内のテキストにアニメーションを付ける方法を示します。段落ごとにエフェクトを追加したり、トリガーを調整したり、既存のアニメーション シーケンスを取得したりする手順を学びます。最後まで読むと、標準の PPTX にエクスポートでき、PowerPoint で正しく再生される再利用可能なテキスト アニメーション ワークフローを作成できるようになります。

## **段落アニメーション エフェクトの追加**

[add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) メソッド（[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) クラス）を使用すると、単一の段落にアニメーション エフェクトを適用できます。以下のサンプル コードが手順を示しています:
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # エフェクトを追加する段落を選択します。
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 選択した段落にフライ アニメーション エフェクトを追加します。
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```


## **段落アニメーション エフェクトの取得**

段落に適用されているアニメーション エフェクトを確認したい場合があります。たとえば、これらのエフェクトを別の段落やシェイプにコピーしたいときです。

Aspose.Slides for Python では、テキスト フレーム（シェイプ）内の段落に適用されたすべてのアニメーション エフェクトを取得できます。以下のサンプル コードは、段落のアニメーション エフェクトを取得する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```


## **FAQ**

**テキスト アニメーションはスライド トランジションとはどのように異なり、併用できますか？**

テキスト アニメーションはスライド上のオブジェクトの時間経過による動作を制御し、[transitions](/slides/ja/python-net/slide-transition/) はスライド同士の切り替え方法を制御します。これらは独立しており、同時に使用できます。再生順序はアニメーション タイムラインとトランジション設定によって決まります。

**テキスト アニメーションは PDF や画像にエクスポートしたときに保持されますか？**

保持されません。PDF やラスタ画像は静的であり、スライドの単一状態しか表示されません。動きを残したい場合は、[video](/slides/ja/python-net/convert-powerpoint-to-video/) や [HTML](/slides/ja/python-net/export-to-html5/) へのエクスポートを使用してください。

**テキスト アニメーションはレイアウトやスライド マスターでも機能しますか？**

レイアウト／マスター オブジェクトに適用されたエフェクトはスライドに継承されますが、タイミングやスライドレベルのアニメーションとの相互作用は、最終的なスライド上のシーケンスに依存します。