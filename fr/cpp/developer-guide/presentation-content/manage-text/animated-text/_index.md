---
title: Texte Animé
type: docs
weight: 60
url: /fr/cpp/animated-text/
keywords: "Texte animé dans PowerPoint"
description: "Texte animé dans la présentation PowerPoint avec Aspose.Slides"
---

## Ajouter des Effets d'Animation aux Paragraphes

Nous avons ajouté la méthode [**AddEffect()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) aux classes [**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) et [**ISequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.i_sequence). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Cet exemple de code vous montre comment ajouter un effet d'animation à un seul paragraphe :

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// sélectionner le paragraphe pour ajouter un effet
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// ajouter un effet d'animation de vol au paragraphe sélectionné
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```


## Obtenir les Effets d'Animation dans les Paragraphes

Vous pouvez décider de découvrir les effets d'animation ajoutés à un paragraphe, par exemple, dans un scénario, vous souhaitez obtenir les effets d'animation dans un paragraphe parce que vous prévoyez d'appliquer ces effets à un autre paragraphe ou forme.

Aspose.Slides pour C++ vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Cet exemple de code vous montre comment obtenir les effets d'animation dans un paragraphe :

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
		Console::WriteLine(String(u"Le paragraphe \"") + paragraph->get_Text() + u"\" a un effet de type " + ObjectExt::ToString(effects[0]->get_Type()) + u".");
	}
}
```