---
title: Alternatív betűtípusok megadása prezentációkhoz .NET-ben
linktitle: Alternatív betűtípus
type: docs
weight: 10
url: /hu/net/create-fallback-font/
keywords:
- alternatív betűtípus
- alternatív szabály
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
description: "Ismerje meg az Aspose.Slides for .NET-et, hogy beállítsa az alternatív betűtípusokat PPT, PPTX és ODP fájlokban, biztosítva a szöveg következetes megjelenítését minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy alternatív betűtípusokat adjon meg a prezentáció rendereléséhez és exportálási műveletekhez. Az alternatív betűtípusok akkor használatosak, amikor az elsődleges betűtípus nem tartalmaz megfelelő glifeket bizonyos karakterekhez.

Az alternatív viselkedést visszahívási szabályok segítségével konfiguráljuk. Minden szabály egy Unicode‑tartományt rendel hozzá egy vagy több betűtípushoz, amelyek tartalmazhatják a szükséges glifeket. Különböző karaktertartományokhoz definiálhat szabályokat, hozzáadhat vagy eltávolíthat alternatív betűtípusokat a meglévő szabályokból, valamint több szabályt rendezhet egy alternatív betűtípus szabálykészletben.

A visszahívási szabályok futásidejű renderelési beállítások. Nem módosítják magát a prezentációfájlt, és nem tárolódnak a PPTX fájlban.

## **Visszahívási szabályok**

Az Aspose.Slides támogatja a [IFontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/iFontFallBackRule) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) osztályt a visszahívási betűtípus alkalmazásának szabályainak megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) osztály egy összekapcsolást képvisel a megadott Unicode‑tartomány (amely a hiányzó glifyek keresésére szolgál) és a megfelelő glifyekkel rendelkező betűtípusok listája között:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Többféleképpen is hozzáadhat betűtípuslistát:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Az is lehetséges, hogy [Remove()](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontfallbackrule/methods/remove) segítségével eltávolítson egy visszahívási betűtípust, vagy [AddFallBackFonts()](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) segítségével hozzáadjon betűtípusokat egy meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) objektumba.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrulescollection) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) objektumok listájának rendszerezésére, ha több Unicode‑tartományhoz kell visszahívási betűtípus helyettesítési szabályokat megadni.

{{% alert color="info" title="Lásd még" %}} 
- [Alternatív betűtípusok gyűjteményének létrehozása](/slides/hu/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

### Mi a különbség az alternatív betűtípus, a betűtípus helyettesítés és a betűtípus beágyazás között?

Az alternatív betűtípus csak a primer betűtípusban hiányzó karakterekhez használatos. A [Betűtípus helyettesítés](/slides/hu/net/font-substitution/) az egész megadott betűtípust egy másikra cseréli. A [Betűtípus beágyazás](/slides/hu/net/embedded-font/) a betűtípusokat a kimeneti fájlba csomagolja, hogy a címzettek a szöveget a tervezett módon láthassák.

### Az alternatív betűtípusok alkalmazásra kerülnek exportáláskor, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn történő rendereléskor?

Igen. Az alternatív betűtípusok hatással vannak minden [renderelési és exportálási műveletre](/slides/hu/net/convert-presentation/), ahol a karaktereket meg kell rajzolni, de azok hiányoznak a forrás betűtípusból.

### A visszahívás beállítása módosítja-e a prezentációfájlt, és a beállítás megmarad-e a későbbi megnyitásokkor?

Nem. A visszahívási szabályok futásidejű renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

### Az operációs rendszer (Windows/Linux/macOS) és a betűtárak könyvtárai befolyásolják-e a visszahívási kiválasztást?

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [további útvonalakról](/slides/hu/net/custom-font/) oldja fel a betűtípusokat. Ha egy betűtípus nincs fizikailag elérhető, akkor a rá hivatkozó szabály nem léphet életbe.

### Az alternatív betűtípusok működnek a WordArt, SmartArt és diagramok esetében?

Igen. Amikor ezek az objektumok szöveget tartalmaznak, ugyanaz a glif‑helyettesítési mechanizmus alkalmazódik a hiányzó karakterek renderelésére.