---
title: Tartalék betűtípusok megadása prezentációkhoz Java-ban
linktitle: Tartalék betűtípus
type: docs
weight: 10
url: /hu/java/create-fallback-font/
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
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Java-t, hogy tartalék betűtípusokat állítson be PPT, PPTX és ODP fájlokban, és biztosítsa a szöveg következetes megjelenítését bármilyen eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalék betűtípusokat adjon meg a prezentáció rendereléséhez és exportálási műveletekhez. A tartalék betűtípusokat akkor használják, amikor az elsődleges betűtípus nem tartalmaz glifeket egyes karakterekhez.

A tartalék viselkedést tartalék szabályokkal konfigurálják. Minden szabály egy Unicode‑tartományt kapcsol össze egy vagy több betűtípussal, amelyek a szükséges glifeket tartalmazhatják. Definiálhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat tartalék betűtípusokat a meglévő szabályokból, és több szabályt rendezhet egy tartalék betűtípus szabályok gyűjteményében.

A tartalék szabályok futásidejű renderelési beállítások. Nem módosítják a prezentáció fájlt magát, és nem tárolódnak a PPTX fájlban.

## **Tartalék szabályok**

Az Aspose.Slides támogatja az [IFontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFontFallBackRule) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) osztályt a tartalék betűtípus alkalmazásának szabályainak megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) osztály egy társítást képvisel a megadott Unicode‑tartomány, amely a hiányzó glifek keresésére szolgál, és a megfelelő glifeket tartalmazó betűtípusok listája között:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Többféle módon adhat hozzá betűtípuslistát:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Azt is lehetséges, hogy [eltávolítsa](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) a tartalék betűtípust, vagy [addFallBackFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) hozzáadja egy meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) objektumba.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRulesCollection) felhasználható a [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) objektumok listájának rendszerezésére, ha több Unicode‑tartományhoz szükséges tartalék betűtípuscserélési szabályokat megadni.

{{% alert color="primary" title="Lásd még" %}} 
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a tartalék betűtípus, betűtípus helyettesítés és betűtípus beágyazás között?**

A tartalék betűtípus csak a hiányzó karakterekhez használható az elsődleges betűtípusban. A [Betűtípus helyettesítés](/slides/hu/java/font-substitution/) az egész megadott betűtípust egy másikkal helyettesíti. A [Betűtípus beágyazás](/slides/hu/java/embedded-font/) a betűtípusokat a kimeneti fájlba csomagolja, így a címzettek a szöveget a tervezett módon láthatják.

**A tartalék betűtípusok alkalmazásra kerülnek az exportálás során, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn történő rendereléskor?**

Igen. A tartalék hatással van minden [renderelési és exportálási műveletre](/slides/hu/java/convert-presentation/), ahol karaktereket kell megjeleníteni, de azok hiányoznak a forrás betűtípusban.

**A tartalék beállítása módosítja-e magát a prezentációfájlt, és a beállítás megmarad‑e a későbbi megnyitások során?**

Nem. A tartalék szabályok futásidejű renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem jelennek meg a PowerPointban.

**Az operációs rendszer (Windows/Linux/macOS) és a betűtípus‑könyvtárak halmaza befolyásolja‑e a tartalék kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [további útvonalak](/slides/hu/java/custom-font/) közül keresi a betűtípusokat. Ha egy betűtípus fizikailag nem érhető el, akkor a rá hivatkozó szabály nem lép hatályba.

**A tartalék működik WordArt, SmartArt és diagramok esetén?**

Igen. Amikor ezek az objektumok szöveget tartalmaznak, ugyanaz a glif‑helyettesítési mechanizmus alkalmazódik a hiányzó karakterek megjelenítésére.