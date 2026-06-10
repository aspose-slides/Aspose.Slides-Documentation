---
title: Java-ban a bemutatók tartalék betűtípusainak kezelése
linktitle: Tartalék betűtípus
type: docs
weight: 50
url: /hu/java/fallback-font/
keywords:
- tartalék betűtípus
- elérhető betűtípus
- glyf helyettesítés
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Lásd, hogyan használja az Aspose.Slides for Java a tartalék betűtípusokat, hogy a szöveg olvasható maradjon PowerPoint és OpenDocument bemutatókban, ha az eredeti betűtípusok nem érhetők el."
---
## **Bevezetés**

A tartalék betűtípusok akkor kerülnek felhasználásra, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de nem tartalmaz egy szükséges glyfet. Ebben az esetben az Aspose.Slides a megadott tartalék betűtípusok egyikét használhatja a hiányzó glyf helyettesítésére.

## **Tartalék betűtípus**

Az Aspose.Slides lehetővé teszi tartalék betűtípusok létrehozását, azok hozzáadását a tartalék betűtípusok gyűjteményéhez, egy adott bemutató számára a tartalék betűtípus-gyűjtemény beállítását, a tartalék betűtípusok eltávolítását a bemutatóból, a tartalék betűtípusok alkalmazására vonatkozó szabályok meghatározását és egyebeket.

A funkciók megismeréséhez használja az alábbi hivatkozásokat:

- [Tartalék betűtípus létrehozása](/slides/hu/java/create-fallback-font)
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/java/create-fallback-fonts-collection)
- [Bemutató renderelése tartalék betűtípussal](/slides/hu/java/render-presentation-with-fallback-font)

## **GYIK**

**Miben különbözik a tartalék betűtípus a betűtípus helyettesítéstől?**

A tartalék betűtípus egy karakterre vagy Unicode tartományra alkalmazható, amikor az elsődleges betűtípus nem tartalmaz bizonyos glyfeket; csak a hiányzó karaktereket tölti ki. [Helyettesítés](/slides/hu/java/font-substitution/) egy hiányzó vagy nem elérhető betűtípust cserél ki egy teljes szövegrészre vagy szövektfajtára egy másik betűtípussal. Kombinálhatók, de a hatókörük és a kiválasztási logikájuk eltérő.

**A tartalék beállítások mentésre kerülnek a bemutató fájlban?**

Nem. A tartalék konfiguráció a könyvtár feldolgozás/renderelés időszakában él, és nem kerül sorosításra a PPTX-be. A bemutató nem tárolja a tartalék szabályait.

**A tartalék hatással van a PowerPoint objektumok (SmartArt, diagramok, WordArt) által létrehozott elemekre?**

Igen. Ezeken az objektumokon belüli szöveg ugyanazon a renderelési folyamaton megy keresztül, így ugyanazok a tartalék szabályok érvényesek rá, mint a normál szövegre.