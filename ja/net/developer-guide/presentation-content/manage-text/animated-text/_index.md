---
title: アニメーションテキスト
type: docs
weight: 60
url: /net/animated-text/
keywords: "アニメーションテキスト, アニメーション効果, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにアニメーションテキストと効果を追加する"
---

## 段落にアニメーション効果を追加する

[**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) メソッドを [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) と [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence) クラスに追加しました。このメソッドを使用すると、単一の段落にアニメーション効果を追加できます。このサンプルコードは、単一の段落にアニメーション効果を追加する方法を示しています：

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // 効果を追加する段落を選択
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // 選択した段落にフライアニメーション効果を追加
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```



## 段落内のアニメーション効果を取得する

段落に追加されたアニメーション効果を調べることを決定するかもしれません。例えば、あるシナリオでは、別の段落や図形にそれらの効果を適用する計画があるため、段落のアニメーション効果を取得したいと思います。

Aspose.Slides for .NETを使用すると、テキストフレーム（図形）に含まれる段落に適用されたすべてのアニメーション効果を取得できます。このサンプルコードは、段落のアニメーション効果を取得する方法を示しています：

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("段落 \"" + paragraph.Text + "\" には " + effects[0].Type + " 効果があります。");
	}
}
```