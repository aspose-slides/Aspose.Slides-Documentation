---
title: Animer le texte PowerPoint en .NET
linktitle: Texte animé
type: docs
weight: 60
url: /fr/net/animated-text/
keywords:
- texte animé
- animation de texte
- paragraphe animé
- animation de paragraphe
- effet d'animation
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créez du texte animé dynamique dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET, avec des exemples de code C# faciles à suivre et optimisés."
---

## **Ajout d'effets d'animation aux paragraphes**

Nous avons ajouté la méthode [**AddEffect()**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence/methods/addeffect/index) aux classes [**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) et [**ISequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Ce code d'exemple vous montre comment ajouter un effet d'animation à un seul paragraphe:
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

Vous pouvez décider de découvrir les effets d'animation ajoutés à un paragraphe — par exemple, dans un scénario, vous souhaitez obtenir les effets d'animation d'un paragraphe parce que vous prévoyez d'appliquer ces effets à un autre paragraphe ou forme.

Aspose.Slides for .NET vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d'exemple vous montre comment obtenir les effets d'animation dans un paragraphe :
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

**Comment les animations de texte diffèrent-elles des transitions de diapositive, et peuvent-elles être combinées ?**

Les animations de texte contrôlent le comportement d'un objet au fil du temps sur une diapositive, tandis que les [transitions](/slides/fr/net/slide-transition/) contrôlent la manière dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées conjointement; l'ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont-elles conservées lors de l'exportation vers PDF ou images ?**

Non. Les fichiers PDF et les images raster sont statiques, vous ne verrez donc qu'un état unique de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l'exportation en [video](/slides/fr/net/convert-powerpoint-to-video/) ou en [HTML](/slides/fr/net/export-to-html5/).

**Les animations de texte fonctionnent-elles dans les mises en page et le masque de diapositive ?**

Les effets appliqués aux objets de mise en page/masque sont hérités par les diapositives, mais leur chronologie et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.