---
title: Tartalék betűtípusok megadása a bemutatókhoz C++-ban
linktitle: Tartalék betűtípus
type: docs
weight: 10
url: /hu/cpp/create-fallback-font/
keywords:
- tartalék betűtípus
- tartalék szabály
- betűtípus alkalmazása
- betűtípus helyettesítése
- Unicode tartomány
- hiányzó glif
- megfelelő glif
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ használatával állíthat be tartalék betűtípusokat PPT, PPTX és ODP fájlokban, biztosítva a szöveg egységes megjelenését minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalék betűtípusokat (fallback fonts) adjon meg a bemutató rendereléséhez és exportálási műveleteihez. A tartalék betűtípusokat akkor használja a rendszer, amikor az elsődleges betűtípus nem tartalmaz glyph-eket a konkrét karakterekhez.

A tartalék viselkedés a tartalék szabályok (fallback rules) segítségével konfigurálható. Minden szabály egy Unicode-tartományt rendel egy vagy több betűtípushoz, amely tartalmazhatja a szükséges glyph-eket. Definiálhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat tartalék betűtípusokat a meglévő szabályokból, illetve több szabályt szervezhet egy tartalék betűtípus szabályok gyűjteményébe.

A tartalék szabályok futás‑időbeli renderelési beállítások. Nem módosítják a bemutató fájlt, és nem tárolódnak a PPTX fájlban.

## **Tartalék szabályok**

Az Aspose.Slides támogatja a [IFontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztályt a tartalék betűtípus szabályok meghatározásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztály a megadott Unicode‑tartomány és egy lista a betűtípusokról közötti kapcsolatot reprezentálja, amely a hiányzó glyph‑ek keresésére szolgál, és megfelelő glyph‑eket tartalmazhat:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Többféleképpen hozzáadhat betűtípus-listát:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Lehetséges a tartalék betűtípus [Remove()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/remove/) metódusával eltávolítani vagy a [AddFallBackFonts()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) metódussal hozzáadni a meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) objektumhoz.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrulescollection/) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) objektumok listájának szervezésére, ha több Unicode‑tartományra szeretne tartalék betűtípus helyettesítési szabályokat meghatározni.

{{% alert color="primary" title="Lásd még" %}} 
- [Create Fallback Fonts Collection](/slides/hu/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a tartalék betűtípus, a betűtípus helyettesítés és a betűtípus beágyazás között?**

A tartalék betűtípust csak a fő betűtípusban hiányzó karakterekhez használja. A [betűtípus helyettesítés](/slides/hu/cpp/font-substitution/) az egész megadott betűtípust egy másikkal cseréli le. A [betűtípus beágyazás](/slides/hu/cpp/embedded-font/) a betűtípusokat a kimeneti fájlba csomagolja, így a címzettek a szöveget a tervezett módon láthatják.

**A tartalék betűtípusok alkalmazásra kerülnek exportáláskor, például PDF, PNG vagy SVG esetén, vagy csak képernyőn történő rendereléskor?**

Igen. A tartalék hat az összes [renderelési és exportálási műveletre](/slides/hu/cpp/convert-presentation/), ahol karaktereket kell megjeleníteni, de azok hiányoznak a forrás‑betűtípusból.

**A tartalék konfigurálása módosítja a bemutató fájlt, és a beállítás megmarad a jövőbeni megnyitásokkor?**

Nem. A tartalék szabályok futás‑időbeli renderelési beállítások a kódban; nem kerülnek tárolásra a .pptx fájlban, és nem jelennek meg a PowerPointban.

**Az operációs rendszer (Windows/Linux/macOS) és a betűtípus‑könyvtárak halmaza befolyásolja a tartalék kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [további útvonalak](/slides/hu/cpp/custom-font/) közül oldja fel a betűtípusokat. Ha egy betűtípus fizikailag nem áll rendelkezésre, a rá hivatkozó szabály nem lép hatályba.

**Működik a tartalék betűtípus WordArt, SmartArt és diagramok esetén is?**

Igen. Amikor ezek az objektumok szöveget tartalmaznak, ugyanaz a glyph‑helyettesítési mechanizmus alkalmazásra kerül a hiányzó karakterek rendereléséhez.