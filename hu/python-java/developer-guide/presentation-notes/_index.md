---
title: "Bemutató megjegyzések kezelése Pythonban Java-n keresztül"
linktitle: "Bemutató megjegyzések"
type: docs
weight: 110
url: /hu/python-java/presentation-notes/
keywords:
- "megjegyzések"
- "megjegyzés dia"
- "megjegyzés hozzáadása"
- "megjegyzés eltávolítása"
- "megjegyzés stílus"
- "mester megjegyzések"
- "PowerPoint"
- "OpenDocument"
- "bemutató"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Testreszabhatja a bemutató megjegyzéseket az Aspose.Slides for Python via Java használatával. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument megjegyzésekkel a termelékenysége növelése érdekében."
---
## **Áttekintés**

Aspose.Slides támogatja a megjegyzés diáknak eltávolítását egy bemutatóból. Ez a téma bevezeti ezt a funkciót, beleértve a megjegyzések eltávolítását és a megjegyzés diák stílusának alkalmazását egy bemutatóban. Az Aspose.Slides lehetővé teszi a megjegyzések eltávolítását bármely diáról, valamint a meglévő megjegyzések stílusának alkalmazását. A fejlesztők a következő módokon távolíthatják el a megjegyzéseket:

- Megjegyzések eltávolítása egy adott diáról egy bemutatóban.
- Megjegyzések eltávolítása az összes diáról egy bemutatóban.

A megjegyzésoldal méreteinek olvasásához vagy módosításához, az orientáció átváltásához és az export viselkedés ellenőrzéséhez lásd a [Megjegyzésoldal mérete](/slides/hu/python-java/notes-size/).

## **Megjegyzések eltávolítása egy diáról**

Egy adott diáról a megjegyzések eltávolíthatók az alábbi példában:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Példányosít egy Presentation objektumot, amely egy bemutató fájlt képvisel.
presentation = Presentation("presWithNotes.pptx")
try:
    # Eltávolítja a megjegyzéseket az első diáról.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Mentse a bemutatót a lemezen.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megjegyzések eltávolítása egy bemutatóból**

Az összes diáról a megjegyzések eltávolíthatók az alábbi példában:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Példányosít egy Presentation objektumot, amely egy bemutató fájlt képvisel.
presentation = Presentation("presWithNotes.pptx")
try:
    # Eltávolítja a megjegyzéseket az összes diáról.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Mentse a bemutatót a lemezen.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megjegyzésstílus hozzáadása**

A [getNotesStyle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslide/#getNotesStyle) metódus a [MasterNotesSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslide/) osztályban hozzáférést biztosít a megjegyzés szövegének stílusához. A megvalósítást az alábbi példában mutatjuk be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Példányosít egy Presentation objektumot, amely egy bemutató fájlt képvisel.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Lekéri a mester megjegyzésdia szövegstílusát.
        notes_style = notes_master.getNotesStyle()

        # Beállítja a szimbólum bullet pontot az első szintű bekezdésekhez.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Melyik API entitás biztosít hozzáférést egy adott dia megjegyzéseihez?**

A megjegyzések a dia megjegyzéskezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslidemanager/) és egy [getNotesSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslidemanager/#getNotesSlide) metódus, amely visszaadja a megjegyzés objektumot, vagy `None`-t, ha nincsenek megjegyzések.

**Vannak-e különbségek a megjegyzések támogatásában a PowerPoint verziók között, amelyeket a könyvtár támogat?**

A könyvtár a Microsoft PowerPoint széles körű formátumait (97 és újabb) és az ODP-t célozza meg; a megjegyzések ezekben a formátumokban támogatottak anélkül, hogy a PowerPoint telepített példányára támaszkodnának.