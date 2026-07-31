---
title: Presentaties weergeven met fallback-lettertypen in C++
linktitle: Presentaties weergeven
type: docs
weight: 30
url: /nl/cpp/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint weergeven
- presentatie weergeven
- dia weergeven
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Presentaties weergeven met fallback-lettertypen in Aspose.Slides voor C++ - houd de tekst consistent over PPT, PPTX en ODP met stapsgewijze C++ codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties weer te geven met behulp van fallback‑lettertype‑regels. Dit artikel laat zien hoe u een collectie fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst met de methode `FontsManager::set_FontFallBackRulesCollection`.

Zodra de fallback‑lettertype‑regels‑collectie is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld toont hoe de geconfigureerde regels te gebruiken bij het renderen van een dia‑thumbnail en het opslaan ervan als PNG‑afbeelding.

## **Een dia weergeven met fallback‑lettertype‑regels**

Het volgende voorbeeld bevat deze stappen:

1. We [create fallback font rules collection](/slides/nl/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/remove/) een fallback‑lettertype‑regel en [AddFallBackFonts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) aan een andere regel.
1. Geef de regels‑collectie door aan de methode [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
1. Met de [Presentation::Save()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de fallback‑lettertype‑regels‑collectie is ingesteld op de FontsManager, worden deze regels toegepast tijdens elke bewerking op de presentatie: opslaan, renderen, converteren, enz.

``` cpp
// Maak een nieuw exemplaar van een regels-collectie
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Maak een aantal regels
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Probeer fallback-lettertype "Tahoma" te verwijderen uit geladen regels
	fallBackRule->Remove(u"Tahoma");

	// En om de regels bij te werken voor het opgegeven bereik
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
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Lees meer over hoe u [PowerPoint-dia's converteren naar PNG in C++](/slides/nl/cpp/convert-powerpoint-to-png/) kunt doen.
{{% /alert %}}