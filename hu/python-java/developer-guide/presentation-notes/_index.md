---
title: "Prezentáció jegyzeteinek kezelése Pythonon keresztül Java-val"
linktitle: "Prezentáció jegyzetei"
type: docs
weight: 110
url: /hu/python-java/presentation-notes/
keywords:
  - "jegyzetek"
  - "jegyzet dia"
  - "jegyzetek hozzáadása"
  - "jegyzetek eltávolítása"
  - "jegyzet stílus"
  - "mester jegyzetek"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentáció"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Testreszabhatja a prezentáció jegyzeteit az Aspose.Slides for Python via Java használatával. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel, hogy növelje a hatékonyságát."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzet diák eltávolítását egy bemutatóból. Ez a téma bemutatja ezt a funkciót, beleértve a jegyzetek eltávolítását és a jegyzet diák stílusának alkalmazását egy bemutatóban. Az Aspose.Slides lehetővé teszi, hogy bármely diáról eltávolítsa a jegyzeteket, és stílust alkalmazzon a meglévő jegyzetekre. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról a bemutatóban.
- Jegyzetek eltávolítása az összes diáról a bemutatóban.

## **Jegyzetek eltávolítása egy diáról**

Egy adott diáról a jegyzetek eltávolíthatók az alábbi példában:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel.
presentation = Presentation("presWithNotes.pptx")
try:
    # Jegyzetek eltávolítása az első diáról.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # A prezentáció mentése lemezre.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Jegyzetek eltávolítása egy bemutatóból**

Az összes diáról a jegyzetek eltávolíthatók az alábbi példában:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel.
presentation = Presentation("presWithNotes.pptx")
try:
    # Jegyzetek eltávolítása az összes diáról.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # A prezentáció mentése lemezre.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Jegyzet stílus hozzáadása**

A [getNotesStyle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslide/#getNotesStyle) metódus a [MasterNotesSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/masternotesslide/) osztályban hozzáférést biztosít a jegyzet szöveg stílusához. A megvalósítást az alábbi példában mutatjuk be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Szerezze meg a mester jegyzetdia szövegstílusát.
        notes_style = notes_master.getNotesStyle()

        # Állítsa be a szimbólum pontokat az első szintű bekezdésekhez.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mely API entitás biztosít hozzáférést egy adott diának a jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslidemanager/) és egy [getNotesSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/notesslidemanager/#getNotesSlide) metódus, amely visszaadja a jegyzet objektumot, vagy `None`, ha nincs jegyzet.

**Vannak különbségek a jegyzetek támogatásában a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár a Microsoft PowerPoint széles körű formátumait (97 és későbbi) valamint az ODP-t támogatja; a jegyzetek ezekben a formátumokban támogatottak, anélkül, hogy a PowerPoint telepített példányára támaszkodnának.