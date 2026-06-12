---
title: Presentaties renderen met fallback-lettertypen in .NET
linktitle: Presentaties renderen
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
description: "Render presentaties met fallback-lettertypen in Aspose.Slides voor .NET – houd de tekst consistent in PPT, PPTX en ODP met stapsgewijze C#-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om presentaties te renderen met behulp van fallback-lettertype‑regels. Dit artikel laat zien hoe je een collectie van fallback‑lettertype‑regels maakt, de regels wijzigt door fallback‑lettertypen te verwijderen of toe te voegen, en de collectie toewijst aan de `FontsManager.FontFallBackRulesCollection` eigenschap.

Zodra de collectie van fallback‑lettertype‑regels is toegewezen aan de `FontsManager` van de presentatie, worden de regels toegepast tijdens bewerkingen zoals opslaan, renderen en converteren van de presentatie. Het voorbeeld toont hoe je de geconfigureerde regels gebruikt bij het renderen van een dia‑miniatuur en het opslaan daarvan als PNG‑afbeelding.

## **Een dia renderen met fallback‑lettertype‑regels**

1. We [maken een collectie van fallback‑lettertype‑regels](/slides/nl/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrule/methods/remove) een fallback‑lettertype‑regel en [AddFallBackFonts()](https://reference.aspose.com/slides/nl/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) aan een andere regel.
3. Stel de collectie regels in op de [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) eigenschap.
4. Met de [Presentation.Save()](https://reference.aspose.com/slides/nl/net/aspose.slides.presentation/save/methods/4) methode kunnen we de presentatie opslaan in hetzelfde formaat, of in een ander formaat. Nadat de collectie van fallback‑lettertype‑regels is ingesteld op de FontsManager, worden deze regels toegepast tijdens alle bewerkingen op de presentatie: opslaan, renderen, converteren, enz.

```c#
// Maak een nieuw exemplaar van een regelsverzameling
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Proberen om fallback-lettertype "Tahoma" te verwijderen uit geladen regels
	fallBackRule.Remove("Tahoma");

	// En om regels bij te werken voor gespecificeerd bereik
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Ook kunnen we bestaande regels uit de lijst verwijderen
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // De voorbereide regelslijst toewijzen voor gebruik
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Miniatuur renderen met behulp van de geïnitialiseerde regelscollectie en opslaan als PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}}
Lees meer over [Opslaan en conversie in presentatie](/slides/nl/net/convert-powerpoint-to-png/).
{{% /alert %}}