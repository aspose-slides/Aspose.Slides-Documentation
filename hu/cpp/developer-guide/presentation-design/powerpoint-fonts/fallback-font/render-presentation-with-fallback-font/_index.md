---
title: Prezentációk renderelése tartalék betűtípusokkal C++-ban
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/cpp/render-presentation-with-fallback-font/
keywords:
- tartalék betűtípus
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Prezentációk renderelése tartalék betűtípusokkal az Aspose.Slides C++-hoz – biztosítja a szöveg következetességét a PPT, PPTX és ODP fájlok között lépésről lépésre bemutatott C++ kódmintákkal."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy prezentációkat rendereljen tartalék betűtípus szabályok használatával. Ez a cikk bemutatja, hogyan hozhat létre egy tartalék betűtípus szabálygyűjteményt, módosíthatja a szabályait tartalék betűtípusok eltávolításával vagy hozzáadásával, és hogyan rendeli hozzá a gyűjteményt a `FontsManager::set_FontFallBackRulesCollection` metódussal.

Miután a tartalék betűtípus szabálygyűjteményt hozzárendelték a prezentáció `FontsManager`-éhez, a szabályok alkalmazásra kerülnek a mentés, a renderelés és a prezentáció konvertálása során. A példa bemutatja, hogyan használhatók a beállított szabályok egy diakép bélyegkép renderelésekor és PNG képként való mentésekor.

## **Dia renderelése tartalék betűtípus szabályokkal**

A következő példa ezeket a lépéseket tartalmazza:

1. Létrehozzuk a [tartalék betűtípus szabálygyűjteményt](/slides/hu/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/remove/) egy tartalék betűtípus szabályt, illetve [AddFallBackFonts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) egy másik szabályhoz.
3. Adja át a szabálygyűjteményt a [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metódusnak.
4. A [Presentation::Save()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódussal menthetjük a prezentációt ugyanabban a formátumban, vagy másikban. Miután a tartalék betűtípus szabálygyűjtemény be lett állítva a FontsManager-ben, ezek a szabályok minden prezentációval végzett művelet során alkalmazásra kerülnek: mentés, renderelés, konvertálás stb.

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

// Új szabálygyűjtemény példány létrehozása
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// Szabályok létrehozása
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// Megpróbáljuk eltávolítani a "Tahoma" tartalék betűtípust a betöltött szabályokból
	fallBackRule->Remove(u"Tahoma");

	// És a megadott tartomány szabályainak frissítése
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
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
Olvasson tovább arról, hogyan [konvertálhat PowerPoint diákat PNG-re C++](/slides/hu/cpp/convert-powerpoint-to-png/).
{{% /alert %}}