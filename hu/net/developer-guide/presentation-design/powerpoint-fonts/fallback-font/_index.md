---
title: Fallback betűtípusok kezelése prezentációkban .NET-ben
linktitle: Fallback betűtípus
type: docs
weight: 50
url: /hu/net/fallback-font/
keywords:
- fallback betűtípus
- elérhető betűtípus
- glif helyettesítés
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Lásd, hogyan használja az Aspose.Slides for .NET a fallback betűtípusokat, hogy a szöveg olvasható maradjon a PowerPoint és OpenDocument prezentációkban, amikor az eredeti betűtípusok nem állnak rendelkezésre."
---
## **Bevezetés**

A tartalék betűtípusok akkor kerülnek felhasználásra, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de nem tartalmazza a szükséges glifet. Ebben az esetben az Aspose.Slides az egyik megadott tartalék betűtípust használhatja a hiányzó glif helyettesítésére.

## **Tartalék betűtípus**

Az Aspose.Slides lehetővé teszi tartalék betűtípusok létrehozását, azok hozzáadását a tartalék betűtípusok gyűjteményéhez, egy adott bemutatóhoz tartalék betűtípus-gyűjtemény beállítását, a tartalék betűtípusok eltávolítását a bemutatóból, a tartalék betűtípusok alkalmazásának szabályainak megadását és egyéb lehetőségeket.

A funkciók megismeréséhez használja az alábbi hivatkozásokat:

- [Tartalék betűtípus létrehozása](/slides/hu/net/create-fallback-font)
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/net/create-fallback-fonts-collection)
- [Bemutató renderelése tartalék betűtípussal](/slides/hu/net/render-presentation-with-fallback-font)

## **GYIK**

**Miben különbözik a tartalék betűtípus a betűtípus helyettesítéstől?**

A tartalék betűtípus karakterenként vagy Unicode-tartományonként alkalmazásra kerül, ha az elsődleges betűtípus nem tartalmaz bizonyos glifeket; csak a hiányzó karaktereket tölti ki. [Substitution](/slides/hu/net/font-substitution/) egy hiányzó vagy nem elérhető betűtípust cserél egy teljes futtatásra vagy szövegrészre egy másik betűtípusra. Kombinálhatók, de hatókörüket és a kiválasztási logikájukat tekintve különböznek.

**A tartalék beállítások mentésre kerülnek a bemutató fájlban?**

Nem. A tartalék konfiguráció a könyvtár feldolgozási/renderelési időszakában él, és nem kerül sor a PPTX-be való serializálásra. A bemutató nem tárolja a tartalék szabályait.

**A tartalék hatással van a PowerPoint objektumok (SmartArt, diagramok, WordArt) által létrehozott elemekre?**

Igen. Ezekben az objektumokban lévő szöveg ugyanazon renderelési csővezetéken megy keresztül, így ugyanazok a tartalék szabályok érvényesek rá, mint a normál szövegre.