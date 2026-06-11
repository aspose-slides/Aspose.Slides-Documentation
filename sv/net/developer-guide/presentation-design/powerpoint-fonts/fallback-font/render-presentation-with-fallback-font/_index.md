---
title: Rendera presentationer med reservteckensnitt i .NET
linktitle: Rendera presentationer
type: docs
weight: 30
url: /sv/net/render-presentation-with-fallback-font/
keywords:
- reservteckensnitt
- rendera PowerPoint
- rendera presentation
- rendera bildruta
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Rendera presentationer med reservteckensnitt i Aspose.Slides för .NET – behåll texten konsekvent i PPT, PPTX och ODP med steg-för-steg C#-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med hjälp av reservteckensnitt-regler. Den här artikeln visar hur du skapar en samling av reservteckensnitt-regler, ändrar dess regler genom att ta bort eller lägga till reservteckensnitt och tilldelar samlingen till egenskapen `FontsManager.FontFallBackRulesCollection`.

När samlingen av reservteckensnitt-regler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer som att spara, rendera och konvertera presentationen. Exemplet visar hur du använder de konfigurerade reglerna när du renderar en bild av en bildruta och sparar den som en PNG-bild.

## **Rendera en bildruta med reservteckensnitt-regler**

Följande exempel innehåller dessa steg:

1. Vi [skapar samling av reservteckensnitt-regler](/slides/sv/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrule/methods/remove) en reservteckensnitt-regel och [AddFallBackFonts()](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) till en annan regel.
1. Ställ in regelssamlingen på egenskapen [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Med metoden [Presentation.Save()](https://reference.aspose.com/slides/sv/net/aspose.slides.presentation/save/methods/4) kan vi spara presentationen i samma format eller i ett annat. Efter att reservteckensnitt-reglernas samling har tilldelats FontsManager tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```c#
// Skapa en ny instans av en regelkollektion
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// skapa ett antal regler
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Försöker ta bort reservteckensnittet "Tahoma" från laddade regler
	fallBackRule.Remove("Tahoma");

	// Och uppdatera reglerna för angivet intervall
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Vi kan också ta bort befintliga regler från listan
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Tilldelar den förberedda regellistan för användning
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderar en miniatyrbild med den initierade regelkollektionen och sparar som PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="primary" %}} 
Läs mer om [Spara och konvertering i presentation](/slides/sv/net/convert-powerpoint-to-png/).
{{% /alert %}}