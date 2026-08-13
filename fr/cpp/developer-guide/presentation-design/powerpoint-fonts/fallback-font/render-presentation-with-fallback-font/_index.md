---
title: Rendu des présentations avec des polices de secours en C++
linktitle: Rendu des présentations
type: docs
weight: 30
url: /fr/cpp/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendre PowerPoint
- rendre présentation
- rendre diapositive
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Rendez les présentations avec des polices de secours dans Aspose.Slides pour C++ – maintenez le texte cohérent entre PPT, PPTX et ODP avec des exemples de code C++ étape par étape."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de rendre des présentations en utilisant des règles de police de secours. Cet article montre comment créer une collection de règles de police de secours, modifier ses règles en supprimant ou en ajoutant des polices de secours, et affecter la collection à l’aide de la méthode `FontsManager::set_FontFallBackRulesCollection`.

Une fois la collection de règles de police de secours assignée au `FontsManager` de la présentation, les règles sont appliquées lors d’opérations telles que l’enregistrement, le rendu et la conversion de la présentation. L’exemple montre comment utiliser les règles configurées lors du rendu d’une vignette de diapositive et de son enregistrement en tant qu’image PNG.

## **Rendre une diapositive en utilisant des règles de police de secours**

L’exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de police de secours](/slides/fr/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontfallbackrule/remove/) une règle de police de secours et [AddFallBackFonts()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) à une autre règle.
1. Passez la collection de règles à la méthode [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Avec la méthode [Presentation::Save()](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) nous pouvons enregistrer la présentation dans le même format ou dans un autre. Après que la collection de règles de police de secours a été définie sur le FontsManager, ces règles sont appliquées lors de toutes les opérations sur la présentation : enregistrement, rendu, conversion, etc.

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// Créer une nouvelle instance d'une collection de règles
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Créer un certain nombre de règles
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Tentative de suppression de la police de secours "Tahoma" des règles chargées
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
// Assignation d'une liste de règles préparée pour l'utilisation
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendu de la vignette en utilisant la collection de règles initialisée et enregistrement au format PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
En savoir plus sur la façon de [Convertir des diapositives PowerPoint en PNG en C++](/slides/fr/cpp/convert-powerpoint-to-png/).
{{% /alert %}}