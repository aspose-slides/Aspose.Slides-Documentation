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
- rendera bild
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Rendera presentationer med reservteckensnitt i Aspose.Slides för .NET – håll texten konsekvent i PPT, PPTX och ODP med steg-för-steg C#-kodexempel."
---
## **Översikt**

Aspose.Slides låter dig rendera presentationer med hjälp av reservteckensnittregler. Denna artikel visar hur du skapar en samling av reservteckensnittregler, ändrar dess regler genom att ta bort eller lägga till reservteckensnitt, och tilldelar samlingen till egenskapen `FontsManager.FontFallBackRulesCollection`.

När samlingen av reservteckensnittregler har tilldelats presentationens `FontsManager` tillämpas reglerna under operationer såsom sparande, rendering och konvertering av presentationen. Exemplet demonstrerar hur de konfigurerade reglerna används när en bildminiatyr av en bild renderas och sparas som en PNG-bild.

## **Rendera en bild med reservteckensnittregler**

Följande exempel innehåller dessa steg:

1. Vi [skapar en samling av reservteckensnittregler](/slides/sv/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrule/methods/remove) en reservteckensnittregel och [AddFallBackFonts()](https://reference.aspose.com/slides/sv/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) till en annan regel.
1. Ställ in regelssamlingen på egenskapen [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Med metoden [Presentation.Save()](https://reference.aspose.com/slides/sv/net/aspose.slides.presentation/save/methods/4) kan vi spara presentationen i samma format eller i ett annat. Efter att samlingen av reservteckensnittregler har satts på FontsManager tillämpas dessa regler under alla operationer på presentationen: spara, rendera, konvertera osv.

```c#
using Aspose.Slides;

// Skapa en ny instans av en regelkollektion
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// skapa ett antal regler
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Försöker att ta bort reservteckensnittet "Tahoma" från laddade regler
	fallBackRule.Remove("Tahoma");

	//Och för att uppdatera regler för angivet intervall
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Vi kan också ta bort befintliga regler från listan, men behålla minst en regel att rendera med
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Tilldelar en förberedd regellista för användning
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Rendering av miniatyr med användning av initierad regelkollektion och sparande till PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Läs mer om [Spara och konvertering i presentation](/slides/sv/net/convert-powerpoint-to-png/).
{{% /alert %}}