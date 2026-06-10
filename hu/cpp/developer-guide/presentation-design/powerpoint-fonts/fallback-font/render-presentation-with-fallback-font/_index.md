---
title: Prezentációk renderelése fallback betűtípusokkal C++-ban
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/cpp/render-presentation-with-fallback-font/
keywords:
- fallback betűtípus
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Prezentációk renderelése fallback betűtípusokkal az Aspose.Slides C++-hoz – biztosítsa a szöveg konzisztenciáját a PPT, PPTX és ODP formátumok között lépésről lépésre C++ kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a prezentációkat fallback betűtípus szabályok segítségével rendereljük. Ez a cikk bemutatja, hogyan hozhatunk létre egy fallback betűtípus szabályok gyűjteményét, hogyan módosíthatjuk szabályait eltávolítással vagy új fallback betűtípusok hozzáadásával, valamint hogyan rendeljük hozzá a gyűjteményt a `FontsManager::set_FontFallBackRulesCollection` metódussal.

Miután a fallback betűtípus szabályok gyűjteménye hozzárendelésre került a prezentáció `FontsManager`-éhez, a szabályok a mentés, renderelés és konvertálás során alkalmazásra kerülnek. A példa bemutatja, hogyan használhatók a konfigurált szabályok egy diakép bélyegképének renderelésénél és PNG képként történő mentésénél.

## **Dia renderelése fallback betűtípus szabályokkal**

A következő példa ezeket a lépéseket tartalmazza:

1. [Létrehozzuk a fallback betűtípus szabályok gyűjteményét](/slides/hu/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/remove/) egy fallback betűtípus szabályt, és [AddFallBackFonts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) egy másik szabályhoz.
3. A szabályok gyűjteményét átadjuk a [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metódusnak.
4. A [Presentation::Save()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódussal menthetjük a prezentációt ugyanabban a formátumban, vagy egy másikban. Miután a fallback betűtípus szabályok gyűjteménye beállításra került a FontsManagerben, ezek a szabályok minden prezentációval végzett művelet során alkalmazásra kerülnek: mentés, renderelés, konvertálás stb.

``` cpp
// Új példány létrehozása egy szabálygyűjteményből
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Számos szabály létrehozása
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Megpróbáljuk eltávolítani a "Tahoma" fallback betűtípust a betöltött szabályokból
	fallBackRule->Remove(u"Tahoma");

	// És a szabályok frissítése a megadott tartományra
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Továbbá eltávolíthatunk bármely meglévő szabályt a listáról
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Előkészített szabálylistát rendelünk hozzárendeléshez
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Bélyegkép renderelése a inicializált szabálygyűjtemény használatával és mentése PNG-be
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Olvasson többet arról, hogyan [PowerPoint diák PNG-re konvertálása C++-ban](/slides/hu/cpp/convert-powerpoint-to-png/).
{{% /alert %}}