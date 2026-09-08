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
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションに動的なアニメーションテキストを作成し、分かりやすく最適化された Python コード例をご提供します。"
---
## **概要**

この記事では、Aspose.Slides でアニメーションテキストを扱う方法について、個々の段落にアニメーション効果を適用し、テキストフレーム内の段落に既に割り当てられている効果を取得する方法を説明します。プレゼンテーション内で段落レベルのアニメーションを追加し、既存の段落アニメーション効果を確認するために使用する API メソッドに焦点を当てています。

## **段落へのアニメーション効果の追加**

Sequence クラスの [addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) メソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # 効果を追加する段落を選択します。
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 選択した段落に Fly アニメーション効果を追加します。
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **段落のアニメーション効果の取得**

段落に追加されたアニメーション効果を確認したい場合があります。たとえば、あるシナリオでは、別の段落や図形に同じ効果を適用したいので、段落内のアニメーション効果を取得したいことがあります。

Aspose.Slides for Python via Java を使用すると、テキストフレーム（シェイプ）に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落内のアニメーション効果を取得する方法を示しています。

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

## **FAQ**

**テキストアニメーションはスライド遷移とどのように異なり、組み合わせることはできますか？**

テキストアニメーションはスライド上のオブジェクトの動作を時間軸で制御しますが、[transitions](/slides/ja/python-java/slide-transition/) はスライド間の切り替え方法を制御します。両者は独立しており、一緒に使用できます。再生順序はアニメーションのタイムラインと遷移設定によって決まります。

**テキストアニメーションは PDF や画像にエクスポートしたときに保存されますか？**

保存されません。PDF およびラスター画像は静的な形式なので、スライドの単一状態しか表示されません。動きを保持したい場合は、[video](/slides/ja/python-java/convert-powerpoint-to-video/) または [HTML](/slides/ja/python-java/export-to-html5/) へのエクスポートを使用してください。

**テキストアニメーションはレイアウトやスライドマスターで機能しますか？**

レイアウト・マスター オブジェクトに適用された効果はスライドに継承されますが、タイミングやスライドレベルのアニメーションとの相互作用は、最終的なスライド上のシーケンスに依存します。