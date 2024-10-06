---
title: Texte Animé
type: docs
weight: 60
url: /net/animated-text/
keywords: "Texte animé, Effets d'animation, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter du texte animé et des effets à une présentation PowerPoint en C# ou .NET"
---

## Ajout d'Effets d'Animation aux Paragraphes

Nous avons ajouté la méthode [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) aux classes [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) et [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Ce code d'exemple vous montre comment ajouter un effet d'animation à un seul paragraphe :

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // sélectionner le paragraphe pour ajouter l'effet
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // ajouter un effet d'animation de vol au paragraphe sélectionné
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```



## Obtention des Effets d'Animation dans les Paragraphes

Vous pourriez décider de découvrir les effets d'animation ajoutés à un paragraphe—par exemple, dans un scénario, vous souhaitez obtenir les effets d'animation dans un paragraphe car vous prévoyez d'appliquer ces effets à un autre paragraphe ou une autre forme.

Aspose.Slides pour .NET vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d'exemple vous montre comment obtenir les effets d'animation dans un paragraphe :

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Le paragraphe \"" + paragraph.Text + "\" a un effet de type " + effects[0].Type + ".");
	}
}
```