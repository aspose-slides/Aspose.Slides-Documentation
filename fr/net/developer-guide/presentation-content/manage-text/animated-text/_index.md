---
title: Texte animé
type: docs
weight: 60
url: /fr/net/animated-text/
keywords: "Texte animé, Effets d'animation, Présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Ajouter du texte animé et des effets à une présentation PowerPoint en C# ou .NET"
---

## **Ajout d'effets d'animation aux paragraphes**

Nous avons ajouté la méthode [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) aux classes [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) et [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Cette méthode vous permet d’ajouter des effets d’animation à un seul paragraphe. Le code d’exemple suivant montre comment ajouter un effet d’animation à un seul paragraphe :
```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // sélectionner le paragraphe pour ajouter l'effet
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // ajouter l'effet d'animation Fly au paragraphe sélectionné
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```


## **Obtention des effets d'animation dans les paragraphes**

Vous pouvez souhaiter découvrir les effets d’animation ajoutés à un paragraphe — par exemple, dans un scénario où vous devez récupérer les effets d’animation d’un paragraphe pour les appliquer à un autre paragraphe ou à une forme.

Aspose.Slides for .NET vous permet d’obtenir tous les effets d’animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Le code d’exemple suivant montre comment récupérer les effets d’animation d’un paragraphe :
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


## **FAQ**

**Comment les animations de texte diffèrent‑elles des transitions de diapositive, et peuvent‑elles être combinées ?**

Les animations de texte contrôlent le comportement d’un objet dans le temps sur une diapositive, tandis que les [transitions](/slides/fr/net/slide-transition/) contrôlent la façon dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées ensemble ; l’ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont‑elles conservées lors de l’exportation en PDF ou en images ?**

Non. Les PDF et les images raster sont statiques, vous verrez donc un seul état de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l’exportation en [vidéo](/slides/fr/net/convert-powerpoint-to-video/) ou en [HTML](/slides/fr/net/export-to-html5/).

**Les animations de texte fonctionnent‑elles dans les dispositions et le masque des diapositives ?**

Les effets appliqués aux objets de disposition/masque sont hérités par les diapositives, mais leur minutage et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.