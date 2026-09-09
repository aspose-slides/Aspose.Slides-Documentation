---
title: Python via Java で PowerPoint テキストをアニメーション化
linktitle: アニメーションテキスト
type: docs
weight: 60
url: /ja/python-java/animated-text/
keywords:
- アニメーションテキスト
- テキストアニメーション
- アニメーション段落
- 段落アニメーション
- アニメーション効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションに動的なアニメーションテキストを作成し、分かりやすく最適化された Python コード例で実装します。"
---
## **概要**

この記事では、Aspose.Slides で個々の段落にアニメーション効果を適用し、テキストフレーム内の段落に既に割り当てられている効果を取得する方法について説明します。プレゼンテーション内で段落レベルのアニメーションを追加し、既存の段落アニメーション効果を確認するために使用される API メソッドに焦点を当てています。

## **段落へのアニメーション効果の追加**

[Sequence](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/) クラスの [addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) メソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # エフェクトを追加する段落を選択します。
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 選択した段落に Fly アニメーション効果を追加します。
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **段落のアニメーション効果の取得**

段落に適用されたアニメーション効果を取得したい場合があります。たとえば、その効果を別の段落や図形に適用する場合です。

Aspose.Slides for Python via Java を使用すると、テキストフレーム (シェイプ) に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落に適用されたアニメーション効果を取得する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **よくある質問**

**テキストアニメーションはスライドトランジションとどのように異なり、組み合わせることはできますか？**

テキストアニメーションはスライド上のオブジェクトの時間的な動作を制御し、[transitions](/slides/ja/python-java/slide-transition/) はスライド間の切り替え方法を制御します。両者は独立しており、同時に使用できます。再生順序はアニメーションタイムラインとトランジション設定によって決まります。

**テキストアニメーションはPDFや画像にエクスポートしたときに保持されますか？**

保持されません。PDF とラスタ画像は静的であり、スライドの単一の状態しか表示されません。動きを保持したい場合は、[video](/slides/ja/python-java/convert-powerpoint-to-video/) または [HTML](/slides/ja/python-java/export-to-html5/) でエクスポートしてください。

**テキストアニメーションはレイアウトやスライドマスターで機能しますか？**

レイアウト/マスターオブジェクトに適用された効果はスライドに継承されますが、タイミングやスライドレベルのアニメーションとの相互作用は、スライド上の最終的なシーケンスに依存します。