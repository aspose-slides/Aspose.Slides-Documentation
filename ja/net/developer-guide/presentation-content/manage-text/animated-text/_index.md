---
title: PowerPoint テキストを .NET でアニメーション化
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
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument プレゼンテーション内に動的なアニメーションテキストを作成し、わかりやすく最適化された C# コード例を提供します。"
---

## **段落へのアニメーション効果の追加**

We added the [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) method to the [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) and [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) classes. This method allows you to add animation effects to a single paragraph. This sample code shows you how to add an animation effect to a single paragraph:
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // エフェクトを追加する段落を選択
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // 選択した段落に Fly アニメーションエフェクトを追加
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **段落のアニメーション効果の取得**

You may decide to find out the animation effects added to a paragraph—for example, in one scenario, you want to get the animation effects in a paragraph because you plan to apply those effects to another paragraph or shape.

Aspose.Slides for .NET allows you to get all the animation effects applied to paragraphs contained in a text frame (shape). This sample code shows you how to get the animation effects in a paragraph:
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

**テキストアニメーションはスライドトランジションとどのように異なり、組み合わせることはできますか？**

Text animations control object behavior over time on a slide, while [トランジション](/slides/ja/net/slide-transition/) control how slides change. They’re independent and can be used together; playback order is governed by the animation timeline and the transition settings.

**テキストアニメーションはPDFや画像にエクスポートしたときに保持されますか？**

No. PDF and raster images are static, so you’ll see a single state of the slide without motion. To keep movement, use [ビデオ](/slides/ja/net/convert-powerpoint-to-video/) or [HTML](/slides/ja/net/export-to-html5/) export.

**レイアウトやスライドマスターでもテキストアニメーションは機能しますか？**

Effects applied to layout/master objects are inherited by slides, but their timing and interaction with slide-level animations depend on the final sequence on the slide.