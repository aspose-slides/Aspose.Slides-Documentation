---
title: Vonal alakzatok hozzáadása prezentációkhoz C++-ban
linktitle: Vonal
type: docs
weight: 50
url: /hu/cpp/line/
keywords:
- vonal
- vonal létrehozása
- vonal hozzáadása
- egyszerű vonal
- vonal konfigurálása
- vonal testreszabása
- vonalstílus
- nyílhegy
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg a vonal formázás manipulálását PowerPoint prezentációkban az Aspose.Slides for C++ segítségével. Fedezze fel a tulajdonságokat, metódusokat és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan vonal alakzatokat adjunk hozzá a PowerPoint diákhoz. Ez a cikk bemutatja, hogyan hozhatunk létre egyszerű vonalat, és hogyan szabhatjuk testre a vonalat, hogy nyílnak látszódjon.

Megtanulja, hogyan adjon vonal alakzatot egy diára, hogyan állítsa be a megjelenését, és hogyan mentse el a frissített prezentációt. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, mint a stílus, szélesség, vonalmintázat, nyílhegy beállítások és a kitöltőszín.

## **Egyszerű vonal létrehozása**
Egy egyszerű, sima vonal hozzáadásához a prezentáció egy kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
- Szerezze meg a dia hivatkozását az Index használatával.
- Adjon hozzá egy Line típusú AutoShape-et a Shapes objektum által biztosított [AddAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addautoshape/) metódussal.
- Írja ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában hozzáadtunk egy vonalat a prezentáció első diájához.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Nyíl alakú vonal létrehozása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy néhány vonal tulajdonságot konfiguráljanak, hogy vonzóbbá tegyék azt. Próbáljunk meg néhány vonaltulajdonságot beállítani, hogy nyílnak tűnjön. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation class](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
- Szerezze meg a dia hivatkozását az Index használatával.
- Adjon hozzá egy Line típusú AutoShape-et a Shapes objektum által biztosított AddAutoShape metódussal.
- Állítsa be a Line Style-t az Aspose.Slides for C++ által kínált stílusok egyikére.
- Állítsa be a vonal szélességét.
- Állítsa be a vonal [Dash Style](https://reference.aspose.com/slides/hu/cpp/aspose.slides/linedashstyle/) értékét az Aspose.Slides for C++ által kínált stílusok egyikére.
- Állítsa be a vonal kezdőpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/cpp/aspose.slides/lineformat/) és hosszát.
- Állítsa be a vonal végpontjának nyílhegy stílusát és hosszát.
- Írja ki a módosított prezentációt PPTX fájlként.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Átalakíthatok egy normál vonalat csatlakozóvá, hogy "rátapadjon" az alakzatokra?**

Nem. Egy normál vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/autoshape/) típusú [Line](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapetype/)) nem válik automatikusan csatlakozóvá. Ahhoz, hogy rátapadjon az alakzatokra, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/cpp/aspose.slides/connector/) típust és a [corresponding APIs](/slides/hu/cpp/connector/) kapcsolatépítéshez.

**Mit tegyek, ha egy vonal tulajdonságai a témából öröklődnek, és nehéz meghatározni a végső értékeket?**

[Olvassa el a hatékony tulajdonságokat](/slides/hu/cpp/shape-effective-properties/) az [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilinefillformateffectivedata/) interfészeken keresztül — ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Zárolhatom a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objects](https://reference.aspose.com/slides/hu/cpp/aspose.slides/autoshape/get_autoshapelock/) biztosítanak, amelyekkel [tilthatja a szerkesztési műveleteket](/slides/hu/cpp/applying-protection-to-presentation/).