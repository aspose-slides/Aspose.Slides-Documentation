---
title: Tartalék betűtípusok kezelése prezentációkhoz Pythonban
linktitle: Tartalék betűtípus
type: docs
weight: 50
url: /hu/python-net/fallback-font/
keywords:
- tartalék betűtípus
- elérhető betűtípus
- glyphe helyettesítése
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Lásd, hogyan használja a .NET-en keresztül elérhető Aspose.Slides for Python a tartalék betűtípusokat, hogy a szöveg olvasható maradjon a PowerPoint és OpenDocument prezentációkban, ha az eredeti betűtípusok nem érhetők el."
---
## **Bevezetés**

A tartalék betűtípusokat akkor használják, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de nem tartalmaz egy szükséges glyphet. Ebben az esetben az Aspose.Slides a megadott tartalék betűtípusok egyikét használhatja a hiányzó glyphe helyettesítésére.

## **Tartalék betűtípus**

Az Aspose.Slides lehetővé teszi tartalék betűtípusok létrehozását, azok hozzáadását a tartalék betűtípusok gyűjteményéhez, egy adott bemutatóhoz tartalék betűtípus-gyűjtemény beállítását, a tartalék betűtípusok eltávolítását a bemutatóból, a tartalék betűtípusok alkalmazásának szabályainak megadását és egyebeket.

A funkciók megismeréséhez használja a következő hivatkozásokat:

- [Tartalék betűtípus létrehozása](/slides/hu/python-net/create-fallback-font)
- [Tartalék betűtípusok gyűjteményének létrehozása](/slides/hu/python-net/create-fallback-fonts-collection)
- [Bemutató renderelése tartalék betűtípussal](/slides/hu/python-net/render-presentation-with-fallback-font)

## **GYIK**

**Miben különböznek a tartalék betűtípusok a betűtípus-helyettesítéstől?**

A tartalék betűtípus a karakter vagy Unicode-tartomány szerint kerül alkalmazásra, amikor az elsődleges betűtípus nem rendelkezik adott glyphekkel; csak a hiányzó karaktereket tölti ki. [Helyettesítés](/slides/hu/python-net/font-substitution/) egy hiányzó vagy nem elérhető betűtípust cserél le egy teljes szövegfolyamra vagy szövegrészre egy másik betűtípussal. Kombinálhatók, de a hatókörük és a kiválasztási logikájuk különbözik.

**A tartalék beállítások mentésre kerülnek a bemutató fájlon belül?**

Nem. A tartalék konfiguráció a könyvtárban a feldolgozás/renderelés időpontjában él, és nem sorosítódik a PPTX-be. A bemutató nem tárolja a tartalék szabályait.

**A tartalék hatással van a PowerPoint objektumok (SmartArt, diagramok, WordArt) által létrehozott elemekre?**

Igen. Az ezen objektumokban lévő szöveg ugyanazon renderelési folyamaton megy keresztül, ezért ugyanazok a tartalék szabályok érvényesek rá, mint a szokásos szövegre.