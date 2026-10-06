---
title: Spravovat poznámky k prezentaci v Pythonu přes Java
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/python-java/presentation-notes/
keywords:
- poznámky
- poznámkový snímek
- přidat poznámky
- odstranit poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přizpůsobte si poznámky k prezentaci pomocí Aspose.Slides pro Python přes Java. Bezproblémově pracujte s poznámkami v PowerPointu a OpenDocument, abyste zvýšili svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování snímků s poznámkami z prezentace. Toto téma představuje tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na snímky s poznámkami v prezentaci. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a použít formátování na existující poznámky. Vývojáři mohou odstranit poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

Pro čtení nebo změnu rozměrů stránky s poznámkami, přepnutí orientace a kontrolu chování exportu viz [Notes Page Size](/slides/cs/python-java/notes-size/).

## **Odstranit poznámky ze snímku**

Poznámky z konkrétního snímku lze odstranit, jak je uvedeno v níže uvedeném příkladu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("presWithNotes.pptx")
try:
    # Odstraňte poznámky z prvního snímku.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Uložte prezentaci na disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odstranit poznámky z prezentace**

Poznámky ze všech snímků v prezentaci lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("presWithNotes.pptx")
try:
    # Odstraňte poznámky ze všech snímků.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Uložte prezentaci na disk.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidat styl poznámek**

Metoda [getNotesStyle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslide/#getNotesStyle) třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslide/) poskytuje přístup ke stylu textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Vytvořte objekt Presentation, který představuje soubor prezentace.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Získejte styl textu hlavního snímku s poznámkami.
        notes_style = notes_master.getNotesStyle()

        # Nastavte symbolické odrážky pro odstavce první úrovně.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Která API entita poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné prostřednictvím správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notesslidemanager/) a metodu [getNotesSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notesslidemanager/#getNotesSlide), která vrací objekt poznámek, nebo `None`, pokud žádné poznámky neexistují.

**Existují rozdíly v podpoře poznámek napříč verzemi PowerPointu, se kterými knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97 a novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.