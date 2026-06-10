---
title: Tartalék betűtípusok megadása a bemutatókhoz PHP-ben
linktitle: Tartalék betűtípus
type: docs
weight: 10
url: /hu/php-java/create-fallback-font/
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
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg részletesen az Aspose.Slides for PHP-t Java-n keresztül, hogy tartalék betűtípusokat állítson be PPT, PPTX és ODP fájlokban, biztosítva a szöveg egységes megjelenését bármilyen eszközön vagy operációs rendszeren."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy tartalék betűtípusokat (fallback fonts) adjunk meg a bemutató renderelése és exportálási műveleteihez. A tartalék betűtípusok akkor kerülnek használatra, amikor az elsődleges betűtípus nem tartalmaz bizonyos karakterekhez megfelelő glifeket.

A tartalék betűtípusok viselkedését szabályokkal konfiguráljuk. Minden szabály egy Unicode-tartományt kapcsol össze egy vagy több betűtípussal, amelyek a szükséges glifeket tartalmazhatják. Definiálhat szabályokat különböző karaktertartományokra, hozzáadhat vagy eltávolíthat tartalék betűtípusokat a meglévő szabályokból, és több szabályt rendezhet egy tartalék betűtípus szabálygyűjteményben.

A tartalék szabályok futási időben történő renderelési beállítások. Nem módosítják magát a bemutató fájlt, és nem tárolódnak a PPTX fájlban.

## **Tartalék Szabályok**

Az Aspose.Slides támogatja a [FontFallBackRule](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRule) osztályt a tartalék betűtípus alkalmazásának szabályainak megadásához. A [FontFallBackRule](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRule) osztály egy kapcsolatot képvisel a megadott Unicode-tartomány, a hiányzó glifek keresésére használt tartomány, és egy betűtípus-lista között, amely megfelelő glifeket tartalmazhat:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Többféle módon is hozzáadhat betűtípuslistát:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Lehetőség van a [remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontfallbackrule/remove/) tartalék betűtípus eltávolítására vagy a [addFallBackFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) hozzáadására a meglévő [FontFallBackRule](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRule) objektumba.

A [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRulesCollection) használható a [FontFallBackRule](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRule) objektumok listájának rendezésére, ha szükség van több Unicode-tartományra vonatkozó tartalék betűtípus helyettesítési szabályok megadására.

{{% alert color="primary" title="Lásd még" %}} 
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a tartalék betűtípus, a betűtípus helyettesítés és a betűtípus beágyazás között?**

A tartalék betűtípus csak az elsődleges betűtípusban hiányzó karakterekhez használatos. A [Font substitution](/slides/hu/php-java/font-substitution/) a teljes megadott betűtípust egy másikra cseréli. A [Font embedding](/slides/hu/php-java/embedded-font/) a betűtípusokat a kimeneti fájlba csomagolja, így a címzettek a szöveget a tervezett módon láthatják.

**A tartalék betűtípusok csak képernyőn történő rendereléskor, vagy exportáláskor, például PDF, PNG vagy SVG esetén is alkalmazásra kerülnek?**

Igen. A tartalék betűtípusok minden [rendering and export operations](/slides/hu/php-java/convert-presentation/) műveletre hatással vannak, ahol a karaktereknek meg kell jelenniük, de hiányoznak a forrás betűtípusban.

**A tartalék betűtípusok konfigurálása módosítja-e a bemutató fájlt, és a beállítás megmarad-e a későbbi megnyitások során?**

Nem. A tartalék szabályok futási időben történő renderelési beállítások a kódban; nem tárolódnak a .pptx fájlban, és nem fognak megjelenni a PowerPointban.

**Az operációs rendszer (Windows/Linux/macOS) és a betűtárak könyvtárainak halmaza befolyásolja-e a tartalék betűtípusok kiválasztását?**

Igen. A motor a rendelkezésre álló rendszerkönyvtárakból és a megadott [additional paths](/slides/hu/php-java/custom-font/) útvonalakból oldja fel a betűtípusokat. Ha egy betűtípus nincs fizikailag elérhető, akkor a rá hivatkozó szabály nem léphet életbe.

**A tartalék betűtípusok működnek a WordArt, a SmartArt és a diagramok esetén?**

Igen. Amikor ezekben az objektumokban szöveg szerepel, ugyanaz a glifhelyettesítési mechanizmus alkalmazódik a hiányzó karakterek rendereléséhez.