---
title: Tartalék betűtípusok kezelése bemutatókhoz C++-ban
linktitle: Tartalék betűtípus
type: docs
weight: 50
url: /hu/cpp/fallback-font/
keywords:
- tartalék betűtípus
- elérhető betűtípus
- glyf helyettesítés
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Lásd, hogyan használja az Aspose.Slides C++-hoz a tartalék betűtípusokat, hogy a szöveg olvasható maradjon PowerPoint és OpenDocument bemutatókban, ha az eredeti betűtípusok nem érhetők el."
---
## **Bevezetés**

A tartalék betűtípusok akkor kerülnek használatra, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de nem tartalmaz egy szükséges glyfont. Ebben az esetben az Aspose.Slides az egyik megadott tartalék betűtípust használhatja a hiányzó glyf helyettesítésére.

## **Tartalék betűtípus**

A tartalék betűtípust akkor használják, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de ez a betűtípus nem tartalmaz egy szükséges glyfont. Ebben az esetben lehetőség van egy megadott tartalék betűtípus használatára a glyf helyettesítéséhez.

Az Aspose.Slides lehetővé teszi a tartalék betűtípusok létrehozását, hozzáadását a tartalék betűtípusok gyűjteményéhez, egy adott bemutatóhoz tartalék betűtípus-gyűjtemény beállítását, a tartalék betűtípusok eltávolítását a bemutatóból, a tartalék betűtípusok alkalmazásához szabályok meghatározását és egyebeket.

A funkciók megismeréséhez használja a következő hivatkozásokat:

- [Tartalék betűtípus létrehozása](/slides/hu/cpp/create-fallback-font)
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/cpp/create-fallback-fonts-collection)
- [Bemutató renderelése tartalék betűtípussal](/slides/hu/cpp/render-presentation-with-fallback-font)

## **GYIK**

**Miben különböznek a tartalék betűtípusok a betűtípus helyettesítéstől?**

A tartalék betűtípus egy karakter vagy Unicode‑tartomány szerint kerül alkalmazásra, amikor az elsődleges betűtípus nem tartalmaz bizonyos glyfeket; csak a hiányzó karaktereket tölti ki. [Helyettesítés](/slides/hu/cpp/font-substitution/) egy hiányzó vagy nem elérhető betűtípust egy teljes szakaszra vagy szövegrészre egy másik betűtípussal helyettesít. Kombinálhatók, de a hatókörük és a kiválasztási logikájuk különbözik.

**Mentésre kerülnek a tartalék beállítások a bemutató fájlon belül?**

Nem. A tartalék konfiguráció a feldolgozás/renderelés időpontjában él a könyvtárban, és nem kerül sorosításra a PPTX‑be. A bemutató nem tárolja a tartalék szabályait.

**A tartalék befolyásolja-e a PowerPoint objektumok által létrehozott elemeket (SmartArt, diagramok, WordArt)?**

Igen. Ezen objektumokban lévő szöveg ugyanazon a renderelési csővezetékön megy keresztül, ezért a ugyanazok a tartalék szabályok vonatkoznak rá, mint a normál szövegre.