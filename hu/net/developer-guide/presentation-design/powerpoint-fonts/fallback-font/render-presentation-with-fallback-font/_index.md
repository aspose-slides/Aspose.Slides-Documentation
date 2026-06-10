---
title: Prezentációk renderelése fallback betűkészletekkel .NET-ben
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/net/render-presentation-with-fallback-font/
keywords:
- fallback betűkészlet
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Prezentációk renderelése fallback betűkészletekkel az Aspose.Slides .NET verziójában - a szöveg egységességének biztosítása PPT, PPTX és ODP formátumok között lépésről-lépésre C# kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy előre definiált betűkészlet-szabályokkal renderelje a prezentációkat. Ez a cikk bemutatja, hogyan hozhat létre egy fallback betűkészlet-szabályok gyűjteményt, hogyan módosíthatja szabályait a fallback betűkészletek eltávolításával vagy hozzáadásával, és hogyan rendelheti a gyűjteményt a `FontsManager.FontFallBackRulesCollection` tulajdonsághoz.

Miután a fallback betűkészlet-szabályok gyűjteménye hozzá van rendelve a prezentáció `FontsManager`-éhez, a szabályok a mentés, a renderelés és a prezentáció konvertálása során kerülnek alkalmazásra. A példa bemutatja, hogyan használhatók a beállított szabályok egy diákkép bélyegképének renderelésekor és PNG képként való mentésekor.

## **Dia renderelése fallback betűkészlet-szabályok használatával**

A következő példa ezeket a lépéseket tartalmazza:

1. Létrehozzuk a [fallback betűkészlet-szabályok gyűjteményét](/slides/hu/net/create-fallback-fonts-collection/).
1. Eltávolítjuk ([Remove()](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrule/methods/remove)) a fallback betűkészlet-szabályt, és hozzáadjuk a [AddFallBackFonts()](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) egy másik szabályhoz.
1. A szabálygyűjteményt beállítjuk a [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) tulajdonsághoz.
1. A [Presentation.Save()](https://reference.aspose.com/slides/hu/net/aspose.slides.presentation/save/methods/4) metódussal menthetjük a prezentációt ugyanabban a formátumban, vagy egy másikban. Miután a fallback betűkészlet-szabályok gyűjteménye be van állítva a FontsManager‑ben, ezek a szabályok minden prezentáció‑művelet során alkalmazásra kerülnek: mentés, renderelés, konvertálás stb.

```c#
// Új szabálygyűjtemény példány létrehozása
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// néhány szabály létrehozása
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Megpróbáljuk eltávolítani a "Tahoma" fallback betűkészletet a betöltött szabályokból
	fallBackRule.Remove("Tahoma");

	//És a szabályok frissítése a megadott tartományhoz
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Ezenkívül eltávolíthatunk bármilyen meglévő szabályt a listáról
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Az előkészített szabálygyűjtemény hozzárendelése a használathoz
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Bélyegkép renderelése az előkészített szabálygyűjtemény használatával, majd mentés PNG formátumban
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
További információ a [Prezentáció mentéséről és konvertálásáról](/slides/hu/net/convert-powerpoint-to-png/).
{{% /alert %}}