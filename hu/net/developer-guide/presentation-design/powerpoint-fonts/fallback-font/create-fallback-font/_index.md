---
title: Tartalékbetűtípusok meghatározása a prezentációkhoz .NET-ben
linktitle: Tartalékbetűtípus
type: docs
weight: 10
url: /hu/net/create-fallback-font/
keywords:
- tartalékbetűtípus
- tartalék szabály
- betűtípus alkalmazása
- betűtípus cseréje
- Unicode-tartomány
- hiányzó glif
- megfelelő glif
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for .NET-et, hogy tartalékbetűtípusokat állítson be PPT, PPTX és ODP fájlokban, biztosítva a szöveg egységes megjelenését bármilyen eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalékbetűtípusokat adjon meg a prezentáció rendereléséhez és exportálási műveleteihez. A tartalékbetűtípusokat akkor használják, amikor az elsődleges betűtípust nem tartalmaz glifeket bizonyos karakterekhez.

A tartalékbetűtípus viselkedését tartalék szabályok segítségével konfigurálhatja. Minden szabály egy Unicode‑tartományt társít egy vagy több betűtípussal, amelyek a szükséges glifeket tartalmazhatják. Definiálhat szabályokat különböző karaktertartományokra, hozzáadhat vagy eltávolíthat tartalékbetűtípusokat a meglévő szabályokból, és több szabályt szervezhet egy tartalékbetűtípus‑szabályok gyűjteményében.

A tartalék szabályok futásidejű renderelési beállítások. Nem módosítják magát a prezentációs fájlt, és nem tárolódnak a PPTX fájlban.

## **Tartalék szabályok**

Az Aspose.Slides támogatja az [IFontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/iFontFallBackRule) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) osztályt a tartalékbetűtípus alkalmazásához szükséges szabályok megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) osztály egy kapcsolatot reprezentál a megadott Unicode‑tartomány és a hiányzó glifek keresésére használt lista, valamint azokkal a betűtípusokkal, amelyek a megfelelő glifeket tartalmazhatják:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Többféle módon is hozzáadhat betűtípusok listáját:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Lehetőség van a tartalékbetűtípus [Remove()](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontfallbackrule/methods/remove) eltávolítására vagy a meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) objektumba [AddFallBackFonts()](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) beszúrására.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrulescollection) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) objektumok listájának szervezésére, amikor több Unicode‑tartományra szükséges tartalékbetűtípus csere‑szabályokat meghatározni.

{{% alert color="primary" title="Lásd még" %}} 
- [Feltételes betűtípus‑gyűjtemény létrehozása](/slides/hu/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a tartalékbetűtípus, betűtípus helyettesítés és betűtípus beágyazás között?**

A tartalékbetűtípust csak akkor használják, amikor a karakterek hiányoznak az elsődleges betűtípusból. A [Betűtípus helyettesítés](/slides/hu/net/font-substitution/) az egész megadott betűtípust egy másikkal helyettesíti. A [Betűtípus beágyazás](/slides/hu/net/embedded-font/) a betűtípusokat a kimeneti fájlba csomagolja, hogy a címzettek a szöveget a tervezett módon láthassák.

**A tartalékbetűtípusok alkalmazva vannak az olyan exportoknál, mint a PDF, PNG vagy SVG, vagy csak a képernyőn történő renderelésnél?**

Igen. A tartalékbetűtípus hatással van minden [renderelési és exportálási műveletre](/slides/hu/net/convert-presentation/), ahol karaktereket kell megjeleníteni, de azok hiányoznak a forrásbetűtípusból.

**A tartalékbetűtípus beállítása módosítja a prezentációs fájlt, és a beállítás megmarad a jövőbeli megnyitások során?**

Nem. A tartalék szabályok futásidejű renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

**Az operációs rendszer (Windows/Linux/macOS) és a betűtárak könyvtárainak halmaza befolyásolja a tartalékbetűtípus kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [további útvonalak](/slides/hu/net/custom-font/) közül oldja fel a betűtípusokat. Ha egy betűtípus fizikailag nem elérhető, a rá hivatkozó szabály nem léphet életbe.

**A tartalékbetűtípus működik a WordArt, SmartArt és diagramok esetén?**

Igen. Amikor ezekben az objektumokban szöveg van, ugyanaz a glif‑helyettesítési mechanizmus kerül alkalmazásra a hiányzó karakterek megjelenítéséhez.