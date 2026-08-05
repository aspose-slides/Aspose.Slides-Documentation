---
title: Rendera presentationer med fallback-teckensnitt i C++
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/cpp/render-presentation-with-fallback-font/
keywords:
- fallback-teckensnitt
- rendera PowerPoint
- rendera presentation
- rendera bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Rendera presentationer med fallback-teckensnitt i Aspose.Slides för C++ - håll texten konsekvent i PPT, PPTX och ODP med steg-för-steg C++-kodexempel."
---
## **Översikt**

Aspose.Slides gör det möjligt att rendera presentationer med fallback‑teckensnittregler. Denna artikel visar hur du skapar en samling av fallback‑teckensnittregler, ändrar dess regler genom att ta bort eller lägga till fallback‑teckensnitt och tilldelar samlingen med metoden `FontsManager::set_FontFallBackRulesCollection`.

När samlingen av fallback‑teckensnittregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som sparande, rendering och konvertering av presentationen. Exemplet demonstrerar hur de konfigurerade reglerna används vid rendering av en bildminiatyr och sparande som PNG‑bild.

## **Rendera en bild med fallback‑teckensnittregler**

Följande exempel innehåller dessa steg:

1. Vi [skapar en fallback‑teckensnittregelsamling](/slides/sv/cpp/create-fallback-fonts-collection/).
2. Vi [Remove()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/remove/) en fallback‑teckensnittregel och [AddFallBackFonts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) till en annan regel.
3. Skicka reglersamlingen till metoden [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Med [Presentation::Save()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/)‑metoden kan vi spara presentationen i samma format eller i ett annat. Efter att fallback‑teckensnittregelsamlingen har satts på FontsManager tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera etc.

``` cpp
// Skapa en ny instans av en regelsamling
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Skapa ett antal regler
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Försöker ta bort fallback‑teckensnittet "Tahoma" från laddade regler
	fallBackRule->Remove(u"Tahoma");

	// Och att uppdatera regler för angivet intervall
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Vi kan också ta bort befintliga regler från listan
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
Läs mer om hur du [konverterar PowerPoint‑bilder till PNG i C++](/slides/sv/cpp/convert-powerpoint-to-png/).
{{% /alert %}}