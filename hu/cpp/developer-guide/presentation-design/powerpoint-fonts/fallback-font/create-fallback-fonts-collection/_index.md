---
title: Tartalék betűtípus-gyűjtemények konfigurálása C++-ban
linktitle: Tartalék betűtípus-gyűjtemény
type: docs
weight: 20
url: /hu/cpp/create-fallback-fonts-collection/
keywords:
- tartalék betűtípus
- tartalék szabály
- betűtípus-gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Állítson be egy tartalék betűtípus-gyűjteményt az Aspose.Slides C++-hoz, hogy a szöveg konzisztens és tiszta maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációhoz konfiguráljon egy tartalék betűkészlet szabályok gyűjteményét. Minden tartalék szabályt a `FontFallBackRule` osztály képviseli, és hozzáadható egy `FontFallBackRulesCollection`-hez, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után a prezentáció `FontsManager`-ének `set_FontFallBackRulesCollection` metódusával rendelheti hozzá. A `FontsManager` kezeli a betűkészleteket a prezentációban, és minden `Presentation` példány saját `FontsManager`-rel rendelkezik.

Miután a `FontsManager` inicializálva van a tartalék betűkészlet-gyűjteménnyel, a megadott tartalék betűkészletek a prezentáció renderelése során kerülnek alkalmazásra.

## **Tartalék szabályok alkalmazása**

Az [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztály példányai szervezhetők a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrulescollection/) gyűjteményébe, amely megvalósítja a [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrulescollection/) interfészt. Lehet szabályokat hozzáadni vagy eltávolítani a gyűjteményből.

Ezután ez a gyűjtemény átadható a [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metódusnak a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) osztályban. A FontsManager kezeli a betűkészleteket a prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) rendelkezik egy [get_FontsManager()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) metódussal, amely saját FontsManager példányt tartalmaz.

Az alábbi példa bemutatja, hogyan hozhat létre tartalék betűkészlet szabályok gyűjteményét, és hogyan rendelheti hozzá egy adott prezentáció FontsManager-éhez:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Miután a FontsManager inicializálva van a tartalék betűkészlet-gyűjteménnyel, a tartalék betűkészletek a prezentáció renderelése során kerülnek alkalmazásra.

{{% alert color="info" %}} 
Olvassa el részletesebben, hogyan lehet [Prezentáció renderelése tartalék betűtípussal](/slides/hu/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

### A tartalék szabályaim be lesznek ágyazva a PPTX fájlba, és láthatók lesznek a PowerPointban a mentés után?

Nem. A tartalék szabályok futásidejű renderelési beállítások; nem sorosítódnak a PPTX-be, és nem jelennek meg a PowerPoint felhasználói felületén.

### Alkalmazódik a tartalék betűkészlet a SmartArt, WordArt, diagramok és táblázatok szövegére?

Igen. Ugyanazzal a glifcsere‑mekánizmussal működik minden ilyen objektum szövegén.

### Az Aspose terjeszt betűkészleteket a könyvtárral együtt?

Nem. Ön adja hozzá és használja a betűkészleteket saját felelősségére.

### Használhatók együtt a hiányzó betűkészletek helyettesítése/cseréje és a hiányzó glifekre vonatkozó tartalék?

Igen. Ezek egymástól független lépései ugyanannak a betűkészlet‑felbontási folyamatnak: először a motor feloldja a betűkészlet elérhetőségét ([replacement](/slides/hu/cpp/font-replacement/)/[substitution](/slides/hu/cpp/font-substitution/)), majd a tartalék kitölti a hiányzó glifeket a rendelkezésre álló betűkészletekben.