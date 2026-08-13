---
title: Presentaties renderen met fallback-lettertypen in C++
linktitle: Presentaties renderen
type: docs
weight: 30
url: /nl/cpp/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- dia renderen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor C++ – houd tekst consistent over PPT, PPTX en ODP met stapsgewijze C++ codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentaties weer te geven met behulp van fallback-lettertype regels. Dit artikel laat zien hoe u een fallback-lettertype regels verzameling maakt, deze regels wijzigt door fallback-lettertypen te verwijderen of toe te voegen, en de verzameling toewijst met de `FontsManager::set_FontFallBackRulesCollection`‑methode.

Zodra de fallback-lettertype regelsverzameling is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld toont hoe de geconfigureerde regels te gebruiken bij het renderen van een miniatuur van een dia en het opslaan ervan als PNG‑afbeelding.

## **Een dia renderen met fallback-lettertype regels**

1. We [maken een verzameling fallback-lettertype regels](/slides/nl/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/remove/) een fallback-lettertype regel en [AddFallBackFonts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) aan een andere regel.
3. Geef de regelsverzameling door aan de [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) methode.
4. Met de [Presentation::Save()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de fallback-lettertype regelsverzameling is ingesteld op de FontsManager, worden deze regels toegepast tijdens elke bewerking op de presentatie: opslaan, renderen, converteren, enz.

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

// Maak een nieuwe instantie van een regelsverzameling
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Maak een aantal regels
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Proberen om fallback-lettertype "Tahoma" te verwijderen uit de geladen regels
	fallBackRule->Remove(u"Tahoma");

	// En de regels bijwerken voor het opgegeven bereik
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// We kunnen ook bestaande regels uit de lijst verwijderen
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// De voorbereide regelslijst toewijzen voor gebruik
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Miniatuur renderen met de geinitialiseerde regelsverzameling en opslaan als PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Lees meer over hoe u [PowerPoint-dia's naar PNG converteren in C++](/slides/nl/cpp/convert-powerpoint-to-png/).
{{% /alert %}}