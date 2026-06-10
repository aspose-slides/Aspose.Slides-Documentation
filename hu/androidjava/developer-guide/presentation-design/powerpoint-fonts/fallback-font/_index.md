---
title: Fallback betűtípusok kezelése Android prezentációkban
linktitle: Fallback betűtípus
type: docs
weight: 50
url: /hu/androidjava/fallback-font/
keywords:
- fallback betűtípus
- elérhető betűtípus
- glif helyettesítés
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tekintse meg, hogyan használja az Aspose.Slides for Android Java segítségével a fallback betűtípusokat a szöveg olvashatóságának biztosítására PowerPoint és OpenDocument prezentációkban, amikor az eredeti betűtípusok nem állnak rendelkezésre."
---
## **Bevezetés**

A fallback betűtípust akkor használjuk, amikor a szöveghez megadott betűtípus elérhető a rendszerben, de az nem tartalmaz egy szükséges glifet. Ilyenkor a megadott fallback betűtípusok egyikét lehet felhasználni a glif helyettesítésére.

## **Fallback betűtípus**

Az Aspose.Slides lehetővé teszi fallback betűtípusok létrehozását, azok hozzáadását a fallback betűtípusok gyűjteményéhez, egy adott bemutatóhoz fallback betűtípus-gyűjtemény beállítását, a fallback betűtípusok eltávolítását a bemutatóból, a fallback betűtípusok alkalmazásának szabályainak megadását és egyéb műveleteket.

Az alábbi linkekkel ismerkedhet meg ezekkel a funkciókkal:

- [Fallback betűtípus létrehozása](/slides/hu/androidjava/create-fallback-font)
- [Fallback betűtípus-gyűjtemény létrehozása](/slides/hu/androidjava/create-fallback-fonts-collection)
- [Bemutató renderelése fallback betűtípussal](/slides/hu/androidjava/render-presentation-with-fallback-font)

## **GYIK**

**Miben különbözik a fallback betűtípus a betűtípus-helyettesítéstől?**

A fallback egy karakterre vagy Unicode-tartományra vonatkozik, amikor az elsődleges betűtípus nem tartalmaz bizonyos glifeket; csak a hiányzó karaktereket pótolja. [Helyettesítés](/slides/hu/androidjava/font-substitution/) egy hiányzó vagy nem elérhető betűtípust egy teljes szövegrészt vagy szakaszt helyettesít egy másik betűtípussal. Kombinálhatók, de a hatókörük és a kiválasztási logikájuk eltérő.

**A fallback beállítások mentésre kerülnek a bemutató fájlon belül?**

Nem. A fallback konfiguráció a könyvtár feldolgozási/renderelési idejében él, és nem kerül sorosítva a PPTX-be. A bemutató nem tárolja a fallback szabályait.

**A fallback hatással van a PowerPoint objektumok által létrehozott elemekre (SmartArt, diagramok, WordArt)?**

Igen. A szöveg ezekben az objektumokban ugyanazon renderelési folyamaton megy keresztül, ezért ugyanazok a fallback szabályok alkalmazandók rá, mint a normál szövegre.