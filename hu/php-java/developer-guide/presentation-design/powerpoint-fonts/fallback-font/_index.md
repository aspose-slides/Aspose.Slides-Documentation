---
title: PHP-ben a bemutatók helyettesítő betűtípusainak kezelése
linktitle: Helyettesítő betűtípus
type: docs
weight: 50
url: /hu/php-java/fallback-font/
keywords:
- helyettesítő betűtípus
- elérhető betűtípus
- glif helyettesítés
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Lásd, hogyan használja az Aspose.Slides for PHP a helyettesítő betűtípusokat, hogy a szöveg olvasható maradjon a PowerPoint és OpenDocument bemutatókban, ha az eredeti betűtípusok nem érhetők el."
---
## **Bevezetés**

A helyettesítő betűkészleteket akkor használják, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de nem tartalmaz egy szükséges glifet. Ebben az esetben az Aspose.Slides a megadott helyettesítő betűkészletek egyikét használhatja a hiányzó glif helyettesítésére.

## **Helyettesítő betűtípus**
A helyettesítő betűtípust akkor használják, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de ez a betűtípus nem tartalmaz egy szükséges glifet. Ebben az esetben lehetőség van a megadott helyettesítő betűkészletek egyikének használatára a glif cseréjéhez.

Az Aspose.Slides lehetővé teszi helyettesítő betűkészletek létrehozását, azok hozzáadását a helyettesítő betűkészletek gyűjteményéhez, a helyettesítő betűkészlet-gyűjtemény beállítását egy adott bemutatóhoz, a helyettesítő betűkészletek eltávolítását a bemutatóból, a helyettesítő betűkészletek alkalmazására vonatkozó szabályok megadását és egyéb műveleteket.

Ezekkel a funkciókkal való megismerkedéshez használja a következő hivatkozásokat:

- [Helyettesítő betűtípus létrehozása](/slides/hu/php-java/create-fallback-font)
- [Helyettesítő betűtípusok gyűjteményének létrehozása](/slides/hu/php-java/create-fallback-fonts-collection)
- [Bemutató renderelése helyettesítő betűtípussal](/slides/hu/php-java/render-presentation-with-fallback-font)

## **GYIK**

**Miben különbözik a helyettesítő betűkészlet a betűtípus‑helyettesítéstől?**

A helyettesítés karakterenként vagy Unicode‑tartományonként alkalmazandó, amikor az elsődleges betűtípus nem tartalmaz konkrét glifyeket; csak a hiányzó karaktereket tölti ki. [Helyettesítés](/slides/hu/php-java/font-substitution/) egy hiányzó vagy nem elérhető betűtípust cserél egy teljes futtatásra vagy szövegrészre egy másik betűtípusra. Kombinálhatók, de a hatókörük és a kiválasztási logikájuk különbözik.

**A helyettesítő beállítások el vannak mentve a bemutató fájlban?**

Nem. A helyettesítő konfiguráció a könyvtár feldolgozási/renderelési időben él, és nem kerül sorosításra a PPTX‑be. A bemutató nem tárolja a helyettesítő szabályait.

**A helyettesítés befolyásolja a PowerPoint objektumok által létrehozott elemeket (SmartArt, diagramok, WordArt)?**

Igen. Ezekben az objektumokban található szöveg ugyanazon a renderelési folyamaton megy keresztül, így ugyanazok a helyettesítő szabályok érvényesek rá, mint a normál szövegre.