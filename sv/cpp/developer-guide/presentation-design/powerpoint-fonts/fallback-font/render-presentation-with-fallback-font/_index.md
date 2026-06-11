---
title: Rendera presentationer med reservtypsnitt i С++
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/cpp/render-presentation-with-fallback-font/
keywords:
- reservtypsnitt
- rendera PowerPoint
- rendera presentation
- rendera bild
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Rendera presentationer med reservtypsnitt i Aspose.Slides för С++ – behåll texten konsekvent i PPT, PPTX och ODP med steg‑för‑steg С++-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med reservtypsnittregler. Detta artikel visar hur du skapar en samling av reservtypsnittregler, ändrar dess regler genom att ta bort eller lägga till reservtypsnitt, och tilldelar samlingen med metoden `FontsManager::set_FontFallBackRulesCollection`.

När samlingen av reservtypsnittregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet demonstrerar hur man använder de konfigurerade reglerna vid rendering av en bildförhandsvisning av en bild och sparar den som en PNG‑bild.

## **Rendera en bild med reservtypsnittregler**

Följande exempel inkluderar dessa steg:

1. Vi [skapar en samling av reservtypsnittregler](/slides/sv/cpp/create-fallback-fonts-collection/).
2. Vi [Remove()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/remove/) ett reservtypsnittregel och [AddFallBackFonts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) till en annan regel.
3. Skicka samlingen av regler till metoden [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Med metoden [Presentation::Save()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) kan vi spara presentationen i samma format, eller i ett annat. Efter att samlingen av reservtypsnittregler har ställts in på FontsManager tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

``` cpp
// Skapa en ny instans av en regelsamling
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Skapa ett antal regler
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Försöker ta bort reservtypsnittet "Tahoma" från laddade regler
	fallBackRule->Remove(u"Tahoma");

	// Och uppdatera regler för angivet intervall
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
// Tilldelar en förberedd regellista för användning
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Renderar en miniatyrbild med den initierade regelsamlingen och sparar som PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Läs mer om hur du [konverterar PowerPoint‑bilder till PNG i C++](/slides/sv/cpp/convert-powerpoint-to-png/).
{{% /alert %}}