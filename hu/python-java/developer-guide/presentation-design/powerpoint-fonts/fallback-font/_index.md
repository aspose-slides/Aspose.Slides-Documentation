---
title: Pythonon keresztül Java használatával a prezentációk helyettesítő betűtípusainak kezelése
linktitle: Helyettesítő betűtípus
type: docs
weight: 50
url: /hu/python-java/fallback-font/
keywords:
- helyettesítő betűtípus
- elérhető betűtípus
- glif helyettesítése
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tekintse meg, hogyan használja az Aspose.Slides for Python via Java a helyettesítő betűtípusokat, hogy a szöveg olvasható maradjon PowerPoint és OpenDocument prezentációkban, ha az eredeti betűtípusok nem állnak rendelkezésre."
---
## **Bevezetés**

A helyettesítő betűtípusok akkor kerülnek felhasználásra, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de nem tartalmazza a szükséges glyf-et. Ilyen esetben az Aspose.Slides az egyik megadott helyettesítő betűtípust használhatja a hiányzó glyf helyettesítésére.

## **Helyettesítő betűtípus**

Az Aspose.Slides lehetővé teszi helyettesítő betűtípusok létrehozását, azok hozzáadását egy helyettesítő betűtípus-gyűjteményhez, a helyettesítő betűtípus-gyűjtemény beállítását egy adott bemutatóhoz, a helyettesítő betűtípusok eltávolítását a bemutatóból, a helyettesítő betűtípusok alkalmazására vonatkozó szabályok megadását, valamint egyéb kapcsolódó műveletek végrehajtását.

Az alábbi hivatkozások segítségével ismerheti meg ezeket a funkciókat:

- [Helyettesítő betűtípus létrehozása](/slides/hu/python-java/create-fallback-font/)
- [Helyettesítő betűtípus-gyűjtemény létrehozása](/slides/hu/python-java/create-fallback-fonts-collection/)
- [Bemutató renderelése helyettesítő betűtípussal](/slides/hu/python-java/render-presentation-with-fallback-font/)

## **GYIK**

**Miben különböznek a helyettesítő betűtípusok a betűtípus-helyettesítéstől?**

A helyettesítés karakterenként vagy Unicode-tartományonként történik, amikor az elsődleges betűtípus nem rendelkezik adott glifekkel; csak a hiányzó karaktereket tölti ki. [Substitution](/slides/hu/python-java/font-substitution/) egy hiányzó vagy nem elérhető betűtípust cserél le egy teljes szövegrészre vagy szövegrészletre egy másik betűtípussal. Kombinálhatóak, de hatókörük és a kiválasztásuk logikája eltér.

**A helyettesítő beállítások mentésre kerülnek a bemutató fájlon belül?**

Nem. A helyettesítő konfiguráció a könyvtár feldolgozási/renderelési időpontjában él, és nem kerül sorosítva a PPTX-be. A bemutató nem tárolja a helyettesítő szabályait.

**A helyettesítés hatással van-e a PowerPoint objektumok által létrehozott elemekre (SmartArt, diagramok, WordArt)?**

Igen. Ezekben az objektumokban található szöveg ugyanazon renderelési folyamaton megy keresztül, így ugyanazok a helyettesítő szabályok érvényesek rá, mint a normál szövegre.