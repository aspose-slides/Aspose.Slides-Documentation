---
title: Tartalékbetűtípusok kezelése prezentációkban C++-ban
linktitle: Tartalékbetűtípus
type: docs
weight: 50
url: /hu/cpp/fallback-font/
keywords:
- tartalékbetűtípus
- elérhető betűtípus
- glif helyettesítés
- betűtípus megadása
- szabály megadása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Lásd, hogyan használja az Aspose.Slides for C++ a tartalékbetűtípusokat a szöveg olvashatóságának biztosítására PowerPoint és OpenDocument prezentációkban, amikor az eredeti betűtípusok nem állnak rendelkezésre."
---
## **Bevezetés**

A tartalék betűtípusok akkor kerülnek használatra, ha a szöveghez megadott betűtípus elérhető a rendszerben, de nem tartalmazza a szükséges glifet. Ebben az esetben az Aspose.Slides a megadott tartalék betűtípusok egyikét használhatja a hiányzó glif helyettesítésére.

## **Tartalékbetűtípus**
A tartalékbetűtípust akkor használják, ha a szöveghez megadott betűtípus elérhető a rendszerben, de ez a betűtípus nem tartalmazza a szükséges glifet. Ebben az esetben a megadott tartalékbetűtípusok egyikét lehet használni a glif helyettesítésére.

Az Aspose.Slides lehetővé teszi tartalékbetűtípusok létrehozását, azok hozzáadását a tartalékbetűtípusok gyűjteményéhez, egy adott bemutatóhoz tartalékbetűtípus‑gyűjtemény beállítását, a tartalékbetűtípusok eltávolítását a bemutatóból, a tartalékbetűtípusok alkalmazására vonatkozó szabályok meghatározását és egyéb műveleteket.

A funkciók megismeréséhez használja az alábbi hivatkozásokat:

- [Tartalékbetűtípus létrehozása](/slides/hu/cpp/create-fallback-font)
- [Tartalékbetűtípus‑gyűjtemény létrehozása](/slides/hu/cpp/create-fallback-fonts-collection)
- [Bemutató renderelése tartalékbetűtípussal](/slides/hu/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Miben különböznek a tartalékbetűtípusok a betűtípushelyettesítéstől?**

A tartalékbetűtípusok karakterenként vagy Unicode‑tartományonként kerülnek alkalmazásra, amikor az elsődleges betűtípus nem tartalmaz bizonyos glifeket; csak a hiányzó karaktereket tölti ki. [Substitution](/slides/hu/cpp/font-substitution/) egy hiányzó vagy nem elérhető betűtípust cserél le egy teljes szakaszra vagy szövegrészre egy másik betűtípusra. Kombinálhatók, de a hatókörük és a kiválasztási logikájuk eltér.

**A tartalékbeállítások mentésre kerülnek a bemutató fájlban?**

Nem. A tartalékbeállítások a feldolgozás/renderelés során a könyvtárban élnek, és nem kerülnek sorosítva a PPTX‑be. A bemutató nem tárolja a tartalékszabályokat.

**A tartalékbetűtípusok hatással vannak a PowerPoint objektumok (SmartArt, diagramok, WordArt) által létrehozott elemekre?**

Igen. Ezekben az objektumokban lévő szöveg ugyanazon a renderelési csővezeten megy keresztül, ezért ugyanazok a tartalékbetűtípus‑szabályok vonatkoznak rá, mint a normál szövegre.