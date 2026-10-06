---
title: "Prezentációs jegyzetek kezelése C++-ban"
linktitle: "Prezentációs jegyzetek"
type: docs
weight: 110
url: /hu/cpp/presentation-notes/
keywords:
- jegyzetek
- jegyzetdia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzetstílus
- mesterjegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Aspose.Slides C++-ra. Zökkenőmentesen dolgozhat a PowerPoint és OpenDocument jegyzetekkel, hogy növelje a termelékenységét."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolításának módját és a jegyzetdiákra való stílus alkalmazását a prezentációban. Az Aspose.Slides lehetővé teszi, hogy bármely diáról eltávolítsa a jegyzeteket, és meglévő jegyzetekre stílusokat alkalmazzon. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról a prezentációban.
- Jegyzetek eltávolítása az összes diáról a prezentációban.

A jegyzetoldal méretének olvasásához vagy módosításához, az orientáció átváltásához és az export viselkedésének ellenőrzéséhez lásd a [Jegyzetoldal mérete](/slides/hu/cpp/notes-size/).

## **Jegyzetek eltávolítása egy adott diáról**
A jegyzetek egy adott diáról a lenti példában mutatottak szerint távolíthatók el:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Jegyzetek eltávolítása az összes diáról**
A prezentáció összes diájáról a jegyzetek a lenti példában mutatottak szerint távolíthatók el:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Jegyzetstílus hozzáadása**
Az IMasterNotesSlide interfészhez és a MasterNotesSlide osztályhoz hozzá lett adva a NotesStyle tulajdonság. Ez a tulajdonság a jegyzet szövegének stílusát határozza meg. A megvalósítás a lenti példában látható.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### Melyik API-objektum biztosít hozzáférést egy adott dia jegyzeteihez?

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diának van egy [NotesSlideManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/notesslidemanager/) és egy [metódus](https://reference.aspose.com/slides/hu/cpp/aspose.slides/notesslidemanager/get_notesslide/), amely visszaadja a jegyzet objektumot, vagy `null`, ha nincsenek jegyzetek.

### Vannak-e különbségek a jegyzetek támogatásában a könyvtár által támogatott PowerPoint verziók között?

A könyvtár a Microsoft PowerPoint formátumait (97-tól újabb) és az ODP-t célozza; a jegyzetek ezekben a formátumokban támogatottak anélkül, hogy a PowerPoint egy telepített példányára lenne szükség.