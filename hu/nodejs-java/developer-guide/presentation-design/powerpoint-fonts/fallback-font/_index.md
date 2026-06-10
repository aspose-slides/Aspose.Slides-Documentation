---
title: JavaScript-ben a prezentációk helyettesítő betűtípusainek kezelése
linktitle: Helyettesítő betűtípus
type: docs
weight: 50
url: /hu/nodejs-java/fallback-font/
keywords:
- helyettesítő betűtípus
- elérhető betűtípus
- glif helyettesítés
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Lásd, hogyan használja az Aspose.Slides a Node.js-hez helyettesítő betűtípusokat, hogy a szöveg olvasható maradjon PowerPoint és OpenDocument prezentációkban, amikor az eredeti betűtípusok nem érhetők el."
---
## **Bevezetés**

A helyettesítő betűtípusok akkor kerülnek felhasználásra, amikor a szöveghez megadott betűtípus elérhető a rendszeren, de nem tartalmazza a szükséges glifet. Ebben az esetben az Aspose.Slides a megadott helyettesítő betűtípusok egyikét használhatja a hiányzó glif helyettesítésére.

## **Helyettesítő betűtípus**

Az Aspose.Slides lehetővé teszi helyettesítő betűtípusok létrehozását, azok hozzáadását a helyettesítő betűtípusok gyűjteményéhez, egy adott prezentációhoz a helyettesítő betűtípus-gyűjtemény beállítását, a helyettesítő betűtípusok eltávolítását a prezentációból, a helyettesítő betűtípusok alkalmazási szabályainak meghatározását és egyebeket.

A funkciók megismeréséhez használja a következő hivatkozásokat:

- [Helyettesítő betűtípus létrehozása](/slides/hu/nodejs-java/create-fallback-font)
- [Helyettesítő betűtípusok gyűjteményének létrehozása](/slides/hu/nodejs-java/create-fallback-fonts-collection)
- [Prezentáció renderelése helyettesítő betűtípussal](/slides/hu/nodejs-java/render-presentation-with-fallback-font)

## **GYIK**

**Miben különbözik a helyettesítő betűtípus a betűtípushelyettesítéstől?**

A helyettesítő betűtípus a karakterek vagy Unicode-tartományok szerint kerül alkalmazásra, amikor az elsődleges betűtípus nem tartalmazza a szükséges glifeket; csak a hiányzó karaktereket tölti ki. [Helyettesítés](/slides/hu/nodejs-java/font-substitution/) egy hiányzó vagy nem elérhető betűtípust egy teljes szövegrészre vagy futtatásra egy másik betűtípussal helyettesíti. Együtt is használhatók, de hatókörük és kiválasztási logikájuk eltérő.

**A helyettesítő beállítások mentődnek-e a prezentáció fájlon belül?**

Nem. A helyettesítő konfiguráció a könyvtár feldolgozási/renderelési időben él, és nem kerül sorosítva a PPTX-be. A prezentáció nem tárolja a helyettesítő szabályait.

**A helyettesítő hatással van-e a PowerPoint objektumok (SmartArt, diagramok, WordArt) által létrehozott elemekre?**

Igen. Ezen objektumokban lévő szöveg ugyanazon a renderelési folyamaton megy keresztül, ezért ugyanazok a helyettesítő szabályok vonatkoznak rá, mint a normál szövegre.