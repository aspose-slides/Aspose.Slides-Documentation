---
title: Rendre les présentations avec des polices de secours en C++
linktitle: Rendre les présentations
type: docs
weight: 30
url: /fr/cpp/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendre PowerPoint
- rendre la présentation
- rendre la diapositive
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Rendre les présentations avec des polices de secours dans Aspose.Slides pour C++ – garder le texte cohérent entre PPT, PPTX et ODP avec des exemples de code C++ étape par étape."
---

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de polices de secours](/slides/fr/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/remove/) une règle de police de secours et [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) à une autre règle.
1. Transmettez la collection de règles à la méthode [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Avec la méthode [Presentation::Save()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) nous pouvons enregistrer la présentation dans le même format, ou l'enregistrer dans un autre. Après que la collection de règles de polices de secours soit définie dans FontsManager, ces règles sont appliquées lors de toute opération sur la présentation : enregistrement, rendu, conversion, etc.
``` cpp
// Créer une nouvelle instance d'une collection de règles
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Créer un certain nombre de règles
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Tentative de suppression de la police FallBack "Tahoma" des règles chargées
	fallBackRule->Remove(u"Tahoma");

	// Et mise à jour des règles pour la plage spécifiée
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Nous pouvons également supprimer toutes les règles existantes de la liste
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assignation d'une liste de règles préparée pour utilisation
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendu de la miniature en utilisant la collection de règles initialisée et sauvegarde au format PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```



{{% alert color="primary" %}} 
En savoir plus sur la façon de [Convert PowerPoint Slides to PNG in C++](/slides/fr/cpp/convert-powerpoint-to-png/).
{{% /alert %}}