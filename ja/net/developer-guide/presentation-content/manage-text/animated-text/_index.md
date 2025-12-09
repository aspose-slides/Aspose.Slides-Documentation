---
title: PowerPoint テキストを .NET でアニメートする
linktitle: アニメーションテキスト
type: docs
weight: 60
url: /ja/net/animated-text/
keywords:
  - アニメーションテキスト
  - テキストアニメーション
  - アニメーション段落
  - 段落アニメーション
  - アニメーション効果
  - PowerPoint
  - プレゼンテーション
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションで動的なアニメーションテキストを作成し、分かりやすく最適化された C# コード例を提供します。"
---

## **段落へのアニメーション効果の追加**

Sequence クラスと ISequence クラスに [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) メソッドを追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // エフェクトを追加する段落を選択
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // 選択した段落に Fly アニメーション効果を追加
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **段落内のアニメーション効果の取得**

段落に追加されたアニメーション効果を確認したい場合があります。たとえば、あるシナリオでは、別の段落やシェイプにその効果を適用するために、段落内のアニメーション効果を取得したいことがあります。

Aspose.Slides for .NET を使用すると、テキスト フレーム（シェイプ）に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落内のアニメーション効果を取得する方法を示しています:
```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```


## **よくある質問**

**テキスト アニメーションはスライドトランジションとどのように異なり、組み合わせることはできますか？**

テキスト アニメーションはスライド上のオブジェクトの動作を時間的に制御し、[transitions](/slides/ja/net/slide-transition/) はスライドの切り替え方法を制御します。両者は独立しており、一緒に使用できます。再生順序はアニメーション タイムラインとトランジション設定によって決まります。

**テキスト アニメーションは PDF や画像にエクスポートすると保持されますか？**

いいえ。PDF とラスタ画像は静的であるため、スライドの動きのない単一の状態が表示されます。動きを保持したい場合は、[video](/slides/ja/net/convert-powerpoint-to-video/) または [HTML](/slides/ja/net/export-to-html5/) エクスポートを使用してください。

**テキスト アニメーションはレイアウトやスライド マスターでも機能しますか？**

レイアウト/マスター オブジェクトに適用された効果はスライドに継承されますが、タイミングやスライドレベルのアニメーションとの相互作用は、スライド上の最終シーケンスに依存します。