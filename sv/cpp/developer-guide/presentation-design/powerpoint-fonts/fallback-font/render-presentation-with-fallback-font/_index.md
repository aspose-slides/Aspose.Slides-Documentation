---
title: Rendera presentationer med reservteckensnitt i C++
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/cpp/render-presentation-with-fallback-font/
keywords:
- reservteckensnitt
- rendera PowerPoint
- rendera presentation
- rendera bildruta
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Rendera presentationer med reservteckensnitt i Aspose.Slides för C++ – håll texten konsekvent i PPT, PPTX och ODP med steg-för-steg C++-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med reservteckensnittregler. Den här artikeln visar hur du skapar en samling av reservteckensnittregler, ändrar dess regler genom att ta bort eller lägga till reservteckensnitt, och tilldelar samlingen med metoden `FontsManager::set_FontFallBackRulesCollection`.

När samlingen av reservteckensnittregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet visar hur man använder de konfigurerade reglerna när man renderar en bild på en bildruta och sparar den som en PNG-bild.

## **Rendera en bildruta med reservteckensnittregler**

Följande exempel innehåller dessa steg:

1. Vi [skapar en samling av reservteckensnittregler](/slides/sv/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/remove/) en reservteckensnittregel och [AddFallBackFonts()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) till en annan regel.
3. Skicka samlingen av regler till metoden [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. Med metoden [Presentation::Save()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) kan vi spara presentationen i samma format, eller spara den i ett annat. När samlingen av reservteckensnittregler har ställts in i FontsManager tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

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

// Skapa en ny instans av en regelkollektion
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Skapa ett antal regler
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Försöker att ta bort reservteckensnittet "Tahoma" från laddade regler
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
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Läs mer om hur du [konverterar PowerPoint-bilder till PNG i C++](/slides/sv/cpp/convert-powerpoint-to-png/).
{{% /alert %}}