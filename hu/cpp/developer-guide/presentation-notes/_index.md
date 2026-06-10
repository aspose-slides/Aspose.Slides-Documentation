---
title: Prezentációs jegyzetek kezelése C++-ban
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/cpp/presentation-notes/
keywords:
- jegyzetek
- jegyzet dia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzet stílus
- főjegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Aspose.Slides for C++ segítségével. Zökkenőmentesen dolgozhat a PowerPoint és az OpenDocument jegyzetekkel, hogy növelje a hatékonyságát."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy előadásból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolítását és a jegyzetdiák stílusának alkalmazását egy előadásban. Az Aspose.Slides lehetővé teszi, hogy jegyzeteket eltávolítson bármely diáról, valamint stílust alkalmazzon a meglévő jegyzetekre. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról a prezentációban.
- Jegyzetek eltávolítása az összes diáról a prezentációban.

## **Jegyzetek eltávolítása egy adott diáról**
Egy adott dia jegyzetei eltávolíthatók az alábbi példában bemutatott módon:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Jegyzetek eltávolítása az összes diáról**
A prezentáció összes diájának jegyzetei eltávolíthatók az alábbi példában bemutatott módon:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Jegyzetstílus hozzáadása**
A NotesStyle tulajdonság hozzá lett adva az IMasterNotesSlide felülethez és a MasterNotesSlide osztályhoz. Ez a tulajdonság a jegyzet szövegének stílusát határozza meg. A megvalósítást az alábbi példában mutatjuk be.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **GYIK**

**Melyik API entitás biztosít hozzáférést egy adott dia jegyzeteihez?**

Jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diának van egy [NotesSlideManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/notesslidemanager/) és egy [metódus](https://reference.aspose.com/slides/hu/cpp/aspose.slides/notesslidemanager/get_notesslide/) amely visszaadja a jegyzet objektumot, vagy `null`, ha nincs jegyzet.

**Vannak-e különbségek a jegyzetek támogatásában a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár a Microsoft PowerPoint széles skáláját (97‑újabb) és az ODP formátumot célozza; a jegyzetek ezekben a formátumokban támogatottak, anélkül hogy a PowerPoint telepített példányára lenne szükség.