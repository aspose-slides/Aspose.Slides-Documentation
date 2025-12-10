---
title: Animer le texte PowerPoint en C++
linktitle: Texte animé
type: docs
weight: 60
url: /fr/cpp/animated-text/
keywords:
- texte animé
- animation de texte
- paragraphe animé
- animation de paragraphe
- effet d'animation
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Créer du texte animé dynamique dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour C++, avec des exemples de code C++ optimisés et faciles à suivre."
---

## **Ajouter des effets d'animation aux paragraphes**

Nous avons ajouté la méthode [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) aux classes [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) et [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Le code d'exemple suivant montre comment ajouter un effet d'animation à un paragraphe unique :
``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// sélectionner le paragraphe pour ajouter l'effet
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// ajouter l'effet d'animation Fly au paragraphe sélectionné
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```



## **Obtenir les effets d'animation pour les paragraphes**

Vous pouvez décider de connaître les effets d'animation ajoutés à un paragraphe, par exemple, dans un scénario où vous souhaitez récupérer les effets d'animation d'un paragraphe afin de les appliquer à un autre paragraphe ou à une autre forme.

Aspose.Slides for C++ vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Le code d'exemple suivant montre comment récupérer les effets d'animation d'un paragraphe :
``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```


## **FAQ**

**En quoi les animations de texte diffèrent-elles des transitions de diapositive, et peut‑on les combiner ?**

Les animations de texte contrôlent le comportement d’un objet dans le temps sur une diapositive, tandis que les [transitions](/slides/fr/cpp/slide-transition/) contrôlent la façon dont les diapositives passent d’une à l’autre. Elles sont indépendantes et peuvent être utilisées ensemble ; l’ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont‑elles conservées lors de l’exportation vers PDF ou images ?**

Non. Les PDF et les images matricielles sont statiques, vous ne verrez donc qu’un état unique de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l’exportation [vidéo](/slides/fr/cpp/convert-powerpoint-to-video/) ou [HTML](/slides/fr/cpp/export-to-html5/).

**Les animations de texte fonctionnent‑elles dans les dispositions et le masque de diapositives ?**

Les effets appliqués aux objets de disposition/masque sont hérités par les diapositives, mais leur chronologie et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.