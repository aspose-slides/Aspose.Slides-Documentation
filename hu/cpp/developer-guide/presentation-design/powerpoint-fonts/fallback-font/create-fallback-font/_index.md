---
title: Tartalék betűtípusok meghatározása a prezentációkhoz C++-ban
linktitle: Tartalék betűtípus
type: docs
weight: 10
url: /hu/cpp/create-fallback-font/
keywords:
- tartalék betűtípus
- tartalék szabály
- betűtípus alkalmazása
- betűtípus cseréje
- Unicode-tartomány
- hiányzó glif
- megfelelő glif
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for C++ használatát a tartalék betűtípusok beállításához PPT, PPTX és ODP fájlokban, biztosítva a szöveg egységes megjelenítését minden eszközön és operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalék betűtípusokat adjon meg a prezentáció renderelése és exportálása során. A tartalék betűtípusokat akkor használja a rendszer, ha az elsődleges betűtípus nem tartalmaz glifeket bizonyos karakterekhez.

A tartalék viselkedés a tartalék szabályok segítségével konfigurálható. Minden szabály egy Unicode-tartományt kapcsol össze egy vagy több betűtípussal, amelyek a szükséges glifeket tartalmazhatják. Definiálhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat tartalék betűtípusokat a meglévő szabályokból, és több szabályt szervezhet egy tartalék betűtípus szabálygyűjteményben.

A tartalék szabályok futásidejű renderelési beállítások. Nem módosítják magát a prezentációfájlt, és nem tárolódnak a PPTX fájlban.

## **Tartalék szabályok**

Az Aspose.Slides támogatja az [IFontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztályt a tartalék betűtípus alkalmazásához szükséges szabályok megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztály a megadott Unicode-tartomány – amely a hiányzó glifek keresésére szolgál – és egy betűtípuslistának a megfelelő glifek tartalmazására való kapcsolását jelenti:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Több módon is hozzáadhat betűtípuslistát:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Az is lehetséges, hogy a [Remove()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/remove/) függvénnyel eltávolítsa a tartalék betűtípust, vagy a [AddFallBackFonts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) metódussal hozzáadja azt a meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) objektumhoz.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrulescollection/) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) objektumok listájának szervezésére, ha több Unicode-tartományhoz kell tartalék betűtípus helyettesítési szabályokat megadni.

{{% alert color="primary" title="Lásd még" %}} 
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a tartalék betűtípus, a betűtípus helyettesítés és a betűtípus beágyazása között?**

A tartalék betűtípust csak akkor használja a rendszer, ha a karakterek hiányoznak az elsődleges betűtípusból. A [betűtípus helyettesítés](/slides/hu/cpp/font-substitution/) az egész megadott betűtípust egy másikra cseréli. A [betűtípus beágyazása](/slides/hu/cpp/embedded-font/) a betűtípusokat az output fájlba csomagolja, így a fogadó fél a szöveget a tervezett módon láthatja.

**A tartalék betűtípusok alkalmazva vannak az exportálás során, például PDF, PNG vagy SVG, vagy csak a képernyőn történő renderelésnél?**

Igen. A tartalék hatással van minden [renderelési és exportálási műveletre](/slides/hu/cpp/convert-presentation/), ahol a karaktereket meg kell jeleníteni, de a forrás betűtípusban hiányoznak.

**A tartalék beállítása módosítja-e magát a prezentációfájlt, és a beállítás megmarad-e a későbbi megnyitások során?**

Nem. A tartalék szabályok futásidejű renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

**Hatással van-e a működési rendszer (Windows/Linux/macOS) és a betűtárkönyvtárak halmaza a tartalék kiválasztására?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [további útvonalak](/slides/hu/cpp/custom-font/) közül oldja fel a betűtípusokat. Ha egy betűtípus fizikailag nem érhető el, a rá hivatkozó szabály nem lép hatályba.

**A tartalék működik-e a WordArt, a SmartArt és a diagramok esetén?**

Igen. Amikor ezek az objektumok szöveget tartalmaznak, ugyanaz a glif-helyettesítési mechanizmus kerül alkalmazásra a hiányzó karakterek megjelenítéséhez.