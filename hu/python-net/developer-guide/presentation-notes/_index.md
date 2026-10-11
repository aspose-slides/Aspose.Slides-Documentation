---
title: Prezentációs megjegyzések kezelése Pythonban
linktitle: Prezentációs megjegyzések
type: docs
weight: 110
url: /hu/python-net/presentation-notes/
keywords:
- megjegyzések
- megjegyzésdia
- megjegyzések hozzáadása
- megjegyzések eltávolítása
- megjegyzés stílus
- master megjegyzések
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Testreszabhatja a prezentációs megjegyzéseket az Aspose.Slides for Python segítségével .NET-en keresztül. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument megjegyzésekkel, hogy növelje a termelékenységét."
---
## **Áttekintés**

Az Aspose.Slides támogatja a megjegyzéses diák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve, hogyan távolítható el a megjegyzés, és hogyan alkalmazható stílus a megjegyzéses diákra egy prezentációban. Az Aspose.Slides lehetővé teszi, hogy bármely diáról eltávolítsa a megjegyzéseket, és stílusokat alkalmazzon a meglévő megjegyzésekre. A fejlesztők a következő módokon távolíthatják el a megjegyzéseket:

- A megjegyzések eltávolítása egy adott diáról a prezentációban.  
- A megjegyzések eltávolítása az összes diáról a prezentációban.

A megjegyzésoldal méreteinek megtekintéséhez vagy módosításához, az orientáció megváltoztatásához és az export viselkedés ellenőrzéséhez lásd a [Notes Page Size](/slides/hu/python-net/notes-size/) oldalt.

## **Megjegyzés eltávolítása egy diáról**
Egy adott diáról a megjegyzéseket az alábbi példában mutatott módon lehet eltávolítani:

```py
import aspose.slides as slides

# Egy Presentation objektum példányosítása, amely egy bemutató fájlt képvisel 
# Az első dia megjegyzéseinek eltávolítása
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # A bemutató mentése lemezre
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjegyzés eltávolítása az összes diáról**
A prezentáció minden diájáról a megjegyzéseket az alábbi példában mutatott módon lehet eltávolítani:

```py
import aspose.slides as slides

# Egy Presentation objektum példányosítása, amely egy bemutató fájlt képvisel
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Az összes dia megjegyzéseinek eltávolítása
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # A bemutató mentése lemezre
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjegyzés stílus alkalmazása**
A [notes_style](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslide/notes_style/) tulajdonságot hozzáadták a [MasterNotesSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslide/) osztályhoz. Ez a tulajdonság a megjegyzés szövegének stílusát határozza meg. A megvalósítást az alábbi példában mutatjuk be.

```py
import aspose.slides as slides

# Presentation osztály példányosítása, amely a bemutató fájlt képviseli
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide szövegstílusának lekérése
        notesStyle = notesMaster.notes_style

        # Szimbólum típusú jelölő beállítása az első szintű bekezdésekhez
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # A PPTX fájl mentése a lemezre
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mely API entitás biztosít hozzáférést egy adott dia megjegyzéséhez?**

A megjegyzések a dia megjegyzéskezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslidemanager/) és egy [property](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslidemanager/notes_slide/), amely visszaadja a megjegyzés objektumot, vagy `None`, ha nincs megjegyzés.

**Vannak különbségek a megjegyzések támogatásában a különböző PowerPoint verziók között, amelyeket a könyvtár támogat?**

A könyvtár a Microsoft PowerPoint széles körű formátumaira (97‑től újakig) és ODP‑re céloz; a megjegyzések ezekben a formátumokban támogatottak anélkül, hogy a PowerPoint telepített példányára támaszkodnának.