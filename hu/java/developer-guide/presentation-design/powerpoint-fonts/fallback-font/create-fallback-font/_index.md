---
title: "Tartalék betűtípusok megadása prezentációkhoz Java-ban"
linktitle: "Tartalék betűtípus"
type: docs
weight: 10
url: /hu/java/create-fallback-font/
keywords:
- "tartalék betűtípus"
- "tartalék szabály"
- "betűtípus alkalmazása"
- "betűtípus cseréje"
- "Unicode-tartomány"
- "hiányzó glyf"
- "megfelelő glyf"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java segítségével állíts be tartalék betűtípusokat PPT, PPTX és ODP fájlokban, biztosítva a szöveg egységes megjelenését minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalék betűtípusokat (fallback fonts) adjunk meg a prezentáció megjelenítése és exportálása során. A tartalék betűtípusokat akkor használja a rendszer, amikor az elsődleges betűtípus nem tartalmaz glyphákat a konkrét karakterekhez.

A tartalék viselkedés a fallback szabályokon keresztül konfigurálható. Minden szabály egy Unicode‑tartományt társít egy vagy több betűtípussal, amelyek tartalmazhatják a szükséges glyphákat. Különböző karaktertartományokhoz definiálhat szabályokat, hozzáadhat vagy eltávolíthat tartalék betűtípusokat a meglévő szabályokból, és több szabályt is rendezhet egy tartalék betűtípus szabálygyűjteményben.

A fallback szabályok futási időben alkalmazott megjelenítési beállítások. Nem módosítják a prezentáció fájlt, és nem tárolódnak a PPTX fájlban.

## **Fallback szabályok**

Az Aspose.Slides támogatja a [IFontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFontFallBackRule) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) osztályt a tartalék betűtípus szabályok megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) osztály egy kapcsolatot képvisel a megadott Unicode‑tartomány, a hiányzó glyphák kereséséhez használt tartomány, és egy betűtípuslistához, amely a megfelelő glyphákat tartalmazhatja:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Többféleképpen is hozzáadhat betűtípus-listát:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Lehetőség van a [remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) tartalék betűtípus eltávolítására vagy a [addFallBackFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) hozzáadására egy meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) objektumba.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRulesCollection) használható egy listában szereplő [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) objektumok rendezésére, amikor több Unicode‑tartományra vonatkozó tartalék betűtípus csere szabályokat kell megadni.

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/hu/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

### Mi a különbség a tartalék betűtípus, a betűtípus helyettesítés és a betűtípus beágyazás között?

A tartalék betűtípust csak azokhoz a karakterekhez használják, amelyek hiányoznak az elsődleges betűtípusból. A [Font substitution](/slides/hu/java/font-substitution/) az egész megadott betűtípust egy másikra cseréli. A [Font embedding](/slides/hu/java/embedded-font/) a betűtípusokat az eredményfájlba csomagolja, hogy a címzettek a szöveget a tervezett módon láthassák.

### A tartalék betűtípusok alkalmazva vannak-e az exportálás során, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn történő megjelenítésnél?

Igen. A fallback hatással van minden [rendering and export operations](/slides/hu/java/convert-presentation/) feladatra, ahol karaktereket kell megjeleníteni, de azok hiányoznak a forrás betűtípusból.

### A fallback beállítása módosítja-e magát a prezentáció fájlt, és a beállítás megmarad-e a későbbi megnyitások során?

Nem. A fallback szabályok futási időben alkalmazott megjelenítési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

### Befolyásolja-e a operációs rendszer (Windows/Linux/macOS) és a betűtárak könyvtárainak halmaza a fallback kiválasztását?

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [additional paths](/slides/hu/java/custom-font/) útvonalakból oldja fel a betűtípusokat. Ha egy betűtípus fizikailag nem érhető el, a rá hivatkozó szabály nem lép érvénybe.

### A fallback működik-e a WordArt, SmartArt és diagramok esetén?

Igen. Amikor ezek az objektumok szöveget tartalmaznak, ugyanaz a glyph‑helyettesítési mechanizmus alkalmazható a hiányzó karakterek megjelenítésére.