---
title: Visszaeső betűtípusok megadása a prezentációkhoz JavaScriptben
linktitle: Visszaeső betűtípus
type: docs
weight: 10
url: /hu/nodejs-java/create-fallback-font/
keywords:
- visszaeső betűtípus
- visszaeső szabály
- betűtípus alkalmazása
- betűtípus cseréje
- Unicode tartomány
- hiányzó glif
- megfelelő glif
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Node.js könyvtárat, hogy JavaScriptben visszaeső betűtípusokat állíthasson be PPT, PPTX és ODP fájlokhoz, biztosítva a szöveg következetes megjelenítését minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy visszaeső betűtípusokat adjon meg a prezentációk megjelenítése és exportálása során. A visszaeső betűtípusokat akkor használják, ha az elsődleges betűtípus nem tartalmaz glifeket bizonyos karakterekhez.

A visszaeső viselkedés a visszaeső szabályok segítségével konfigurálható. Minden szabály egy Unicode-tartományt társít egy vagy több betűtípussal, amelyek tartalmazhatják a szükséges glifeket. Meghatározhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat visszaeső betűtípusokat a meglévő szabályokból, és több szabályt rendezhet egy visszaeső betűtípus szabálygyűjteményben.

A visszaeső szabályok futásidejű megjelenítési beállítások. Nem módosítják magát a prezentációs fájlt, és nem tárolódnak a PPTX fájlban.

## **Visszaeső betűtípus szabályok**

Az Aspose.Slides támogatja a [FontFallBackRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule) osztályt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule) osztályt a visszaeső betűtípus alkalmazásának szabályainak megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule) osztály a megadott Unicode-tartomány – amely a hiányzó glifek keresésére szolgál – és egy betűtípuslistát, amely megfelelő glifeket tartalmazhat, közötti kapcsolatot ábrázolja:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Többféle módon is hozzáadhat betűtípus-listát:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Lehetőség van a visszaeső betűtípus [eltávolítására](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) vagy a meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule) objektumba [addFallBackFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) hozzáadására.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRulesCollection) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule) objektumok listájának rendezésére, ha több Unicode-tartományhoz kell visszaeső betűtípus csereszabályokat megadni.

{{% alert color="primary" title="lásd még" %}} 
- [Visszaeső betűtípusok gyűjteményének létrehozása](/slides/hu/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a visszaeső betűtípus, a betűtípus-helyettesítés és a betűtípus-beágyazás között?**

A visszaeső betűtípus csak az elsődleges betűtípusban hiányzó karakterekhez használatos. A [Betűtípus-helyettesítés](/slides/hu/nodejs-java/font-substitution/) az egész megadott betűtípust egy másikra cseréli. A [Betűtípus-beágyazás](/slides/hu/nodejs-java/embedded-font/) a betűtípusokat az eredményfájlba csomagolja, így a címzettek a szöveget a tervezett módon láthatják.

**A visszaeső betűtípusok alkalmazásra kerülnek exportáláskor, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn történő megjelenítésnél?**

Igen. A visszaeső hatással van minden [megjelenítési és exportálási műveletekre](/slides/hu/nodejs-java/convert-presentation/), ahol a karaktereket kirajzolni kell, de a forrás betűtípusban hiányoznak.

**A visszaeső konfigurálása módosítja a prezentációs fájlt, és a beállítás megmarad a későbbi megnyitásoknál?**

Nem. A visszaeső szabályok futásidejű megjelenítési beállítások a kódban; nem tárolódnak a .pptx fájlban, ezért nem fognak megjelenni a PowerPointban.

**A operációs rendszer (Windows/Linux/macOS) és a betűtípus-könyvtárak halmaza befolyásolja a visszaeső kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [további útvonalak](/slides/hu/nodejs-java/custom-font/) közül keres betűtípusokat. Ha egy betűtípus nincs fizikailag elérhető, a rá hivatkozó szabály nem lép életbe.

**A visszaeső működik a WordArt, SmartArt és diagramok esetén?**

Igen. Amikor ezekben az objektumokban szöveg van, ugyanaz a glif-helyettesítési mechanizmus alkalmazásra kerül a hiányzó karakterek megjelenítéséhez.