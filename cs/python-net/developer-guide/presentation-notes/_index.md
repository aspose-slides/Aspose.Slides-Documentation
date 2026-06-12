---
title: Spravovat poznámky k prezentaci v Pythonu
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/python-net/presentation-notes/
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
- Aspose.Slides
description: "Přizpůsobte poznámky k prezentaci pomocí Aspose.Slides pro Python přes .NET. Bezproblémově pracujte s poznámkami v PowerPointu a OpenDocumentu a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámkových snímků z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na poznámkové snímky v prezentaci. Aspose.Slides umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstranit poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

## **Odstranit poznámky ze snímku**
Poznámky konkrétního snímku lze odstranit, jak ukazuje následující příklad:

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Odstraňování poznámek z prvního snímku
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # uložit prezentaci na disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranit poznámky ze všech snímků**
Poznámky všech snímků v prezentaci lze odstranit, jak ukazuje následující příklad:

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Odstraňování poznámek ze všech snímků
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # uložit prezentaci na disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidat NotesStyle**
Vlastnost [notes_style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslide/notes_style/) byla přidána do třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslide/). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v ukázce níže.

```py
import aspose.slides as slides

# Vytvořte třídu Presentation, která představuje soubor prezentace
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Získat styl textu MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # Nastavit symbol bullet pro odstavce první úrovně
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # uložit soubor PPTX na disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Která entita API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné přes správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslidemanager/) a [property](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslidemanager/notes_slide/), která vrací objekt poznámek, nebo `None`, pokud nejsou žádné poznámky.

**Existují rozdíly v podpoře poznámek napříč verzemi PowerPointu, se kterými knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97–novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.