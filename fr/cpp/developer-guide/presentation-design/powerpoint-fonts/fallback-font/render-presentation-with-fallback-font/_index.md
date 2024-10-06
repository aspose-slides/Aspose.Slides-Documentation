---
title: Rendre une présentation avec une police de secours
type: docs
weight: 30
url: /cpp/render-presentation-with-fallback-font/
keywords: 
- police de secours
- rendre PowerPoint
- PowerPoint
- présentation
- C++
- Aspose.Slides pour C++
description: "Rendre PowerPoint avec une police de secours en C++"
---

L'exemple suivant inclut ces étapes :

1. Nous [créons une collection de règles de police de secours](/slides/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#aaf12e563d822f6e05e27732a837bcf33) une règle de police de secours et [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#a030268631ae616b775bdb6df8accf42c) à une autre règle.
1. Définir la collection de règles à [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) propriété.
1. Avec [Presentation::Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) méthode nous pouvons enregistrer la présentation dans le même format, ou l'enregistrer dans un autre. Après que la collection de règles de police de secours est définie pour FontsManager, ces règles sont appliquées lors de toutes les opérations sur la présentation : enregistrer, rendre, convertir, etc.

``` cpp
// Créer une nouvelle instance d'une collection de règles
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Créer un certain nombre de règles
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Essayer de retirer la police de secours "Tahoma" des règles chargées
	fallBackRule->Remove(u"Tahoma");

	// Et mettre à jour les règles pour la plage spécifiée
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Nous pouvons également retirer toutes les règles existantes de la liste
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Attribution d'une liste de règles préparées pour utilisation
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendu de la miniature en utilisant la collection de règles initialisée et sauvegarde en PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Lisez-en plus sur [Enregistrement et conversion dans la présentation](/slides/cpp/creating-saving-and-converting-a-presentation/).
{{% /alert %}}