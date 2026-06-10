---
title: Prezentációs jegyzetek kezelése Pythonban
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/python-net/presentation-notes/
keywords:
- jegyzetek
- jegyzet dia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzet stílus
- mester jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Aspose.Slides for Python via .NET használatával. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel, hogy növelje a produktivitását."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve, hogyan távolíthatók el a jegyzetek, és hogyan alkalmazhatók stílusok a jegyzetdiákra egy prezentációban. Az Aspose.Slides lehetővé teszi, hogy jegyzeteket távolítson el bármely diáról, és stílusokat alkalmazzon a meglévő jegyzetekre. A fejlesztők a következő módon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról a prezentációban.
- Jegyzetek eltávolítása az összes diáról a prezentációban.

## **Jegyzetek eltávolítása egy diáról**
Egy adott diáról a jegyzetek eltávolíthatók, ahogyan az alábbi példában látható:

```py
import aspose.slides as slides

# Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Az első dia jegyzeteinek eltávolítása
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # prezentáció mentése lemezre
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Jegyzetek eltávolítása az összes diáról**
A prezentáció összes diájáról a jegyzetek eltávolíthatók, ahogyan az alábbi példában látható:

```py
import aspose.slides as slides

# Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Az összes dia jegyzeteinek eltávolítása
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # prezentáció mentése lemezre
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **NotesStyle hozzáadása**
A [notes_style](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslide/notes_style/) tulajdonság hozzá lett adva a [MasterNotesSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslide/) osztályhoz. Ez a tulajdonság meghatározza a jegyzet szövegének stílusát. A megvalósítást az alábbi példában mutatjuk be.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely a prezentációs fájlt képviseli
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # A MasterNotesSlide szövegstílusának lekérése
        notesStyle = notesMaster.notes_style

        #Állítsa be a szimbolikus felsorolójelet az első szintű bekezdésekhez
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # mentse a PPTX fájlt a lemezre
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mely API entitás biztosítja a hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslidemanager/) és egy [property](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslidemanager/notes_slide/), amely visszaadja a jegyzetobjektumot, vagy `None`‑t, ha nincs jegyzet.

**Vannak-e különbségek a jegyzetek támogatásában a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár a Microsoft PowerPoint számos formátumát (97‑től napjainkig) és az ODP‑t célozza; a jegyzetek ezekben a formátumokban támogatottak, anélkül, hogy telepített PowerPoint példányra lenne szükség.