---
title: Tartalék betűtípusok megadása Android prezentációkhoz
linktitle: Tartalék betűtípus
type: docs
weight: 10
url: /hu/androidjava/create-fallback-font/
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
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Android Java használatát a tartalék betűtípusok beállításához PPT, PPTX és ODP fájlokban, biztosítva a konzisztens szövegmegjelenítést minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalék betűtípusokat adj meg a prezentáció megjelenítéséhez és exportálási műveletekhez. A tartalék betűtípusok akkor kerülnek felhasználásra, ha az elsődleges betűtípus nem tartalmaz glifeket bizonyos karakterekhez.

A tartalék viselkedést a tartalék szabályok segítségével állítod be. Minden szabály egy Unicode‑tartományt kapcsol össze egy vagy több olyan betűtípussal, amely tartalmazhatja a szükséges glifeket. Meghatározhatsz szabályokat különböző karaktertartományokhoz, hozzáadhatsz vagy eltávolíthatsz tartalék betűtípusokat a meglévő szabályokból, és több szabályt szervezhetsz egy tartalék betűtípus szabálygyűjteménybe.

A tartalék szabályok futási időbeli megjelenítési beállítások. Nem módosítják magát a prezentációs fájlt, és nem tárolódnak a PPTX fájlban.

## **Tartalék Szabályok**

Az Aspose.Slides támogatja az [IFontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IFontFallBackRule) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) osztályt a tartalék betűtípus alkalmazásának szabályainak megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) osztály a megadott Unicode‑tartomány és a hiányzó glifek kereséséhez használható betűtípusok listája közötti összefüggést jelenti:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Lehetőség van a [remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) tartalék betűtípus eltávolítására vagy a [addFallBackFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) hozzáadására egy meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) objektumba.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRulesCollection) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) objektumok listájának szervezésére, amikor több Unicode‑tartományhoz kell tartalék betűtípus csereszabályokat megadni.

{{% alert color="info" title="Lásd még" %}} 
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

### Mi a különbség a tartalék betűtípus, betűtípus helyettesítés és betűtípus beágyazás között?

A tartalék betűtípus csak az elsődleges betűtípusban hiányzó karakterekhez használatos. A [Betűtípus helyettesítés](/slides/hu/androidjava/font-substitution/) az egész megadott betűtípust egy másikra cseréli. A [Betűtípus beágyazás](/slides/hu/androidjava/embedded-font/) a betűtípusokat az kimeneti fájlba csomagolja, hogy a címzettek a szöveget a tervezett módon láthassák.

### A tartalék betűtípusok alkalmazásra kerülnek az exportáláskor, mint a PDF, PNG vagy SVG, vagy csak képernyőn történő megjelenítéskor?

Igen. A tartalék hatással van minden [renderelési és exportálási műveletre](/slides/hu/androidjava/convert-presentation/), ahol a karaktereket meg kell jeleníteni, de hiányoznak a forrás betűtípusból.

### A tartalék beállítása módosítja-e magát a prezentációs fájlt, és a beállítás megmarad-e a későbbi megnyitások során?

Nem. A tartalék szabályok futási időbeli renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

### Befolyásolja-e az operációs rendszer (Windows/Linux/macOS) és a betűtípus könyvtárak halmaza a tartalék kiválasztását?

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és az Ön által megadott [további útvonalak](/slides/hu/androidjava/custom-font/) közül keres betűtípusokat. Ha egy betűtípus fizikailag nem elérhető, a rá hivatkozó szabály nem léphet életbe.

### Működik-e a tartalék betűtípus a WordArt, SmartArt és diagramok esetében?

Igen. Amikor ezek a objektumok szöveget tartalmaznak, ugyanaz a glifa helyettesítő mechanizmus alkalmazódik a hiányzó karakterek megjelenítésére.