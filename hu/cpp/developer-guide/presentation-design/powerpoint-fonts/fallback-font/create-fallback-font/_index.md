---
title: Tartalék betűtípusok megadása prezentációkhoz C++-ban
linktitle: Tartalék betűtípus
type: docs
weight: 10
url: /hu/cpp/create-fallback-font/
keywords:
- tartalék betűtípus
- tartalék szabály
- betűtípus alkalmazása
- betűtípus cseréje
- Unicode tartomány
- hiányzó glyph
- megfelelő glyph
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Magabiztosan használja az Aspose.Slides for C++-t a tartalék betűtípusok beállításához PPT, PPTX és ODP fájlokban, biztosítva a szöveg egységes megjelenését minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalék betűtípusokat állítson be a prezentáció renderelése és exportálása során. A tartalék betűtípusokat akkor használja, amikor az elsődleges betűtípus nem tartalmaz glyph-eket bizonyos karakterekhez.

A tartalék viselkedést tartalék szabályokkal konfigurálják. Minden szabály egy Unicode‑tartományt társít egy vagy több betűtípussal, amelyek tartalmazhatják a szükséges glyph-eket. Meghatározhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat tartalék betűtípusokat a meglévő szabályokból, és több szabályt rendezhet egy tartalék betűtípus szabálygyűjteményben.

A tartalék szabályok futásidejű renderelési beállítások. Nem módosítják magát a prezentációs fájlt, és nem tárolódnak a PPTX‑fájlban.

## **Tartalék Szabályok**

Az Aspose.Slides támogatja az [IFontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztályt a tartalék betűtípus alkalmazásának szabályainak megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztály egy kapcsolatot képvisel a megadott Unicode‑tartomány és egy betűtípuslista között, amely tartalmazhatja a megfelelő glyph‑eket:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Többféle módon is hozzáadhatsz betűtípuslistát:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Az is lehetséges, hogy [Remove()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/remove/) eltávolítson egy tartalék betűtípust, vagy [AddFallBackFonts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) hozzáadjon tartalék betűtípusokat egy meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) objektumba.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrulescollection/) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) objektumok listájának rendszerezésére, ha több Unicode‑tartományra vonatkozóan kell tartalék betűtípus csere szabályokat megadni.

{{% alert color="info" title="Lásd még" %}} 
- [Tartalék betűtípus‑gyűjtemény létrehozása](/slides/hu/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

### Mi a különbség a tartalék betűtípus, betűtípus helyettesítés és betűtípus beágyazás között?

A tartalék betűtípust csak az elsődleges betűtípusban hiányzó karakterekhez használják. A [Betűtípus helyettesítés](/slides/hu/cpp/font-substitution/) a megadott betűtípust teljes egészében egy másik betűtípusra cseréli. A [Betűtípus beágyazás](/slides/hu/cpp/embedded-font/) a betűtípusokat a kimeneti fájlba csomagolja, így a fogadók a szöveget a szándékolt módon láthatják.

### A tartalék betűtípusok alkalmazásra kerülnek exportáláskor, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn történő rendereléskor?

Igen. A tartalék minden [renderelési és export műveletnél](/slides/hu/cpp/convert-presentation/) hatással van, ahol a karaktereket meg kell rajzolni, de a forrásbetűtípusban hiányoznak.

### A tartalék beállítása megváltoztatja a prezentációs fájlt, és a beállítás megmarad‑e a későbbi megnyitások során?

Nem. A tartalék szabályok futásidejű renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

### Befolyásolja az operációs rendszer (Windows/Linux/macOS) és a betűtípus‑könyvtárak halmaza a tartalék kiválasztását?

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és az Ön által megadott [további útvonalak](/slides/hu/cpp/custom-font/) közül keresi a betűtípusokat. Ha egy betűtípus fizikailag nem érhető el, a rá hivatkozó szabály nem léphet érvénybe.

### Működik a tartalék betűtípus WordArt, SmartArt és diagramok esetén?

Igen. Amikor ezek az objektumok szöveget tartalmaznak, ugyanaz a glyph‑helyettesítési mechanizmus alkalmazódik a hiányzó karakterek renderelésére.