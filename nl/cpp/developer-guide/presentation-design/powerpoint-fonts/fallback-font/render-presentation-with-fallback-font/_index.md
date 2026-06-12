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
description: "Presentaties renderen met fallback-lettertypen in Aspose.Slides voor C++ – houd tekst consistent tussen PPT, PPTX en ODP met stap-voor-stap C++ code-voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentaties weer te geven met behulp van fallback‑lettertype‑regels. Dit artikel laat zien hoe u een verzameling fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de verzameling toewijst met behulp van de `FontsManager::set_FontFallBackRulesCollection`‑methode.

Zodra de verzameling fallback‑lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld laat zien hoe u de geconfigureerde regels gebruikt bij het renderen van een miniatuur van een dia en het opslaan daarvan als PNG‑afbeelding.

## **Een dia weergeven met fallback‑lettertype‑regels**

Het volgende voorbeeld omvat deze stappen:

1. We [create fallback font rules collection](/slides/nl/cpp/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/remove/) een fallback‑lettertype‑regel en [AddFallBackFonts()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) aan een andere regel.
1. Geef de verzameling regels door aan de [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)‑methode.
1. Met de [Presentation::Save()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de fallback‑lettertype‑regels zijn ingesteld op de FontsManager, worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

``` cpp
// Maak een nieuw exemplaar van een regelsverzameling
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Maak een aantal regels
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Probeert fallback-lettertype "Tahoma" uit geladen regels te verwijderen
	fallBackRule->Remove(u"Tahoma");

	// En om de regels voor het opgegeven bereik bij te werken
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
// Toewijzen van een voorbereide regelslijst voor gebruik
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Miniatuur renderen met behulp van de geïnitialiseerde regelsverzameling en opslaan als PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
Lees meer over hoe u PowerPoint‑dia's naar PNG kunt converteren in C++[/slides/nl/cpp/convert-powerpoint-to-png/).
{{% /alert %}}