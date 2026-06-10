---
title: Tartalék betűtípusok megadása prezentációkhoz Androidon
linktitle: Tartalék betűtípus
type: docs
weight: 10
url: /hu/androidjava/create-fallback-font/
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
  - Android
  - Java
  - Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Android Java használatával, hogy tartalék betűtípusokat állítson be PPT, PPTX és ODP fájlokban, biztosítva a szöveg konzisztens megjelenítését minden eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi tartalék betűtípusok megadását a prezentáció megjelenítéséhez és exportálási műveletekhez. A tartalék betűtípusokat akkor használja a rendszer, ha az elsődleges betűtípus nem tartalmazza a bizonyos karakterekhez szükséges glifeket.

A tartalék betűtípusok viselkedése tartalék szabályokkal konfigurálható. Minden szabály egy Unicode‑tartományt rendel egy vagy több betűtípushoz, amelyek a szükséges glifeket tartalmazhatják. Meghatározhat szabályokat különböző karaktertartományokhoz, hozzáadhat vagy eltávolíthat tartalék betűtípusokat a meglévő szabályokból, és több szabályt rendezhet egy tartalék betűtípus szabálygyűjteményben.

A tartalék szabályok futásidejű megjelenítési beállítások. Nem módosítják magát a prezentációs fájlt, és nem tárolódnak a PPTX‑ben.

## **Tartalék szabályok**

Az Aspose.Slides támogatja az [IFontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IFontFallBackRule) interfészt és a [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) osztályt a tartalék betűtípusra vonatkozó szabályok megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) osztály az adott Unicode‑tartomány és a hiányzó glifek kereséséhez használható betűtípusok listája közötti kapcsolatot jelenti:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Többféle módon is hozzáadhat betűtípuslistát:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Az is lehetséges, hogy [remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) tartalék betűtípust vagy [addFallBackFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) hozzáadjon a meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) objektumba.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRulesCollection) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) objektumok listájának szervezésére, ha több Unicode‑tartományra kell tartalék betűtípus csere szabályokat megadni.

{{% alert color="primary" title="Lásd még" %}} 
- [Tartalék betűtípus-gyűjtemény létrehozása](/slides/hu/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a tartalék betűtípus, betűtípus helyettesítés és betűtípus beágyazás között?**

A tartalék betűtípust csak akkor használja a rendszer, ha a karakterek hiányoznak az elsődleges betűtípusból. [Font substitution](/slides/hu/androidjava/font-substitution/) helyettesíti a megadott betűtípust egy másikkal. [Font embedding](/slides/hu/androidjava/embedded-font/) a betűtípusokat a kimeneti fájlba csomagolja, így a címzettek a szöveget a tervezett módon láthatják.

**A tartalék betűtípusok alkalmazásra kerülnek exportáláskor, például PDF, PNG vagy SVG esetén, vagy csak a képernyőn megjelenítésnél?**

Igen. A tartalék betűtípus minden [rendering and export operations](/slides/hu/androidjava/convert-presentation/) (megjelenítési és exportálási művelet) esetén hat, ahol a karaktereket meg kell jeleníteni, de hiányoznak a forrás‑betűtípusból.

**A tartalék beállításának konfigurálása megváltoztatja-e magát a prezentációs fájlt, és a beállítás megmarad-e a későbbi megnyitásoknál?**

Nem. A tartalék szabályok futásidejű megjelenítési beállítások a kódban; nem tárolódnak a .pptx‑ben, és nem jelennek meg a PowerPointban.

**A operációs rendszer (Windows/Linux/macOS) és a betűtípus‑könyvtárak halmaza befolyásolja-e a tartalék kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [additional paths](/slides/hu/androidjava/custom-font/) (további útvonalak) alapján keresi a betűtípusokat. Ha egy betűtípus fizikailag nem érhető el, a rá hivatkozó szabály nem léphet életbe.

**A tartalék betűtípus működik-e a WordArt, SmartArt és diagramok esetén?**

Igen. Ha ezek az objektumok szöveget tartalmaznak, ugyanaz a glif‑helyettesítési mechanizmus alkalmazandó a hiányzó karakterek megjelenítésére.