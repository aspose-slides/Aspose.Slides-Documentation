---
title: Bemutatók renderelése helyettesítő betűtípusokkal C++-ban
linktitle: Bemutatók renderelése
type: docs
weight: 30
url: /hu/cpp/render-presentation-with-fallback-font/
keywords:
- helyettesítő betűtípus
- PowerPoint renderelése
- bemutató renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Rendereljen bemutatókat helyettesítő betűtípusokkal az Aspose.Slides C++ verziójában – tartsa egységesen a szöveget PPT, PPTX és ODP között lépésről lépésre C++ kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a bemutatók megjelenítését helyettesítő betűtípus szabályok használatával. Ez a cikk bemutatja, hogyan hozhat létre egy helyettesítő betűtípus szabályok gyűjteményt, módosíthatja annak szabályait betűtípusok eltávolításával vagy hozzáadásával, és hogyan rendeli hozzá a gyűjteményt a `FontsManager::set_FontFallBackRulesCollection` metódussal.

Miután a helyettesítő betűtípus szabályok gyűjteménye hozzárendelésre került a bemutató `FontsManager`‑hez, a szabályok alkalmazásra kerülnek olyan műveletek során, mint a mentés, a megjelenítés és a bemutató átalakítása. A példa bemutatja, hogyan használhatók a beállított szabályok dia bélyegképének megjelenítésekor, és annak PNG képként való mentésekor.

## **Dia megjelenítése helyettesítő betűtípus szabályokkal**

1. [Létrehozzuk a helyettesítő betűtípus szabályok gyűjteményét](/slides/hu/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/remove/) egy helyettesítő betűtípus szabályt, és [AddFallBackFonts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) egy másik szabályhoz.
3. A szabályok gyűjteményét átadjuk a [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metódusnak.
4. [Presentation::Save()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódussal menthetjük a bemutatót ugyanabban a formátumban, vagy másik formátumban. Miután a helyettesítő betűtípus szabályok gyűjteményét beállítottuk a FontsManager‑ben, ezek a szabályok minden bemutatóval végzett művelet során alkalmazásra kerülnek: mentés, megjelenítés, átalakítás stb.

``` cpp
// Új példány létrehozása egy szabálygyűjteményből
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Szabályok létrehozása
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Megpróbáljuk eltávolítani a "Tahoma" helyettesítő betűtípust a betöltött szabályokból
	fallBackRule->Remove(u"Tahoma");

	// És a szabályok frissítése a megadott tartományra
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// Ezenkívül eltávolíthatunk bármely meglévő szabályt a listáról
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Felkészített szabálylistát rendelünk hozzárendeléshez
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Bélyegkép renderelése a inicializált szabálygyűjtemény használatával és mentése PNG-be
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
Olvasson tovább arról, hogyan [Konvertálja a PowerPoint diákat PNG-re C++-ban](/slides/hu/cpp/convert-powerpoint-to-png/).
{{% /alert %}}