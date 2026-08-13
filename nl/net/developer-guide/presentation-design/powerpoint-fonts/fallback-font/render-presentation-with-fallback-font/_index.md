---
title: Render Presentaties met fallback-lettertypen in .NET
linktitle: Render Presentaties
type: docs
weight: 30
url: /nl/net/render-presentation-with-fallback-font/
keywords:
- fallback-lettertype
- PowerPoint renderen
- presentatie renderen
- dia renderen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor .NET – houd de tekst consistent over PPT, PPTX en ODP met stapsgewijze C# codevoorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat presentaties te renderen met behulp van fallback‑lettertype‑regels. Dit artikel laat zien hoe u een collectie fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst aan de eigenschap `FontsManager.FontFallBackRulesCollection`.

Zodra de collectie fallback‑lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld toont hoe de geconfigureerde regels te gebruiken bij het renderen van een dia‑miniatuur en het opslaan ervan als PNG‑afbeelding.

## **Een dia renderen met fallback‑lettertype‑regels**

Het volgende voorbeeld bevat de volgende stappen:

1. We [maak een collectie fallback‑lettertype‑regels](/slides/nl/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrule/methods/remove) een fallback‑lettertype‑regel en [AddFallBackFonts()](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) aan een andere regel.
1. Stel de regelscollectie in op de eigenschap [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Met de methode [Presentation.Save()](https://reference.aspose.com/slides/nl/net/aspose.slides.presentation/save/methods/4) kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de collectie fallback‑lettertype‑regels is toegewezen aan FontsManager, worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

```c#
using Aspose.Slides;

// Maak een nieuw exemplaar van een regelsverzameling
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// maak een aantal regels
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Proberen fallback-font "Tahoma" te verwijderen uit geladen regels
	fallBackRule.Remove("Tahoma");

	//En om de regels bij te werken voor het opgegeven bereik
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

//We kunnen ook alle bestaande regels uit de lijst verwijderen, maar minstens één regel behouden om mee te renderen
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Toewijzen van een voorbereide regelslijst voor gebruik
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderen van miniatuur met behulp van de geïnitialiseerde regelsverzameling en opslaan als PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Lees meer over [Opslaan en converteren in presentatie](/slides/nl/net/convert-powerpoint-to-png/).
{{% /alert %}}