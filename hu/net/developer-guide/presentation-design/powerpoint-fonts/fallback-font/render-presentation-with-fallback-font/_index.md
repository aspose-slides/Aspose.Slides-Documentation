---
title: Prezentációk renderelése tartalék betűkészletekkel .NET-ben
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/net/render-presentation-with-fallback-font/
keywords:
- tartalék betűkészlet
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Prezentációk renderelése tartalék betűkészletekkel az Aspose.Slides for .NET-ben – biztosítsa a szöveg konzisztenciáját a PPT, PPTX és ODP formátumok között lépésről lépésre bemutatott C# kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a bemutatók megjelenítését tartalék betűkészlet szabályok használatával. Ez a cikk bemutatja, hogyan hozhatunk létre egy tartalék betűkészlet szabálygyűjteményt, hogyan módosíthatjuk szabályait eltávolítással vagy új tartalék betűkészletek hozzáadásával, és hogyan rendelhetjük a gyűjteményt a `FontsManager.FontFallBackRulesCollection` tulajdonsághoz.

Miután a tartalék betűkészlet szabálygyűjteményt a bemutató `FontsManager`-éhez rendeltük, a szabályok a mentés, megjelenítés és a bemutató konvertálása során kerülnek alkalmazásra. A példa azt mutatja be, hogyan használhatók a beállított szabályok egy dia bélyegképének megjelenítésekor és PNG képként való mentésekor.

## **Dia megjelenítése tartalék betűkészlet szabályokkal**

A következő példa ezeket a lépéseket tartalmazza:

1. [hozzunk létre tartalék betűkészlet szabálygyűjteményt](/slides/hu/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrule/methods/remove) egy tartalék betűkészlet szabályt és [AddFallBackFonts()](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) egy másik szabályhoz.
1. Állítsuk be a szabálygyűjteményt a [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) tulajdonságra.
1. A [Presentation.Save()](https://reference.aspose.com/slides/hu/net/aspose.slides.presentation/save/methods/4) metódussal ugyanabban a formátumban vagy egy másikban menthetjük a bemutatót. Miután a tartalék betűkészlet szabálygyűjtemény be lett állítva a FontsManagerben, ezek a szabályok minden művelet során érvényesülnek: mentés, megjelenítés, konvertálás stb.

```c#
using Aspose.Slides;

// Új szabálygyűjtemény példányának létrehozása
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// Hozzon létre több szabályt
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Megpróbáljuk eltávolítani a "Tahoma" tartalék betűkészletet a betöltött szabályokból
	fallBackRule.Remove("Tahoma");

	// És a megadott tartomány szabályainak frissítése
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Ezenkívül eltávolíthatunk bármely meglévő szabályt a listáról, ha biztosítunk legalább egy szabályt a rendereléshez
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Előkészített szabálygyűjtemény hozzárendelése a használathoz
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Bélyegkép renderelése a inicializált szabálygyűjtemény használatával és mentése PNG formátumba
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="info" %}} 
Olvasson többet a [Mentés és konvertálás a bemutatóban](/slides/hu/net/convert-powerpoint-to-png/).
{{% /alert %}}