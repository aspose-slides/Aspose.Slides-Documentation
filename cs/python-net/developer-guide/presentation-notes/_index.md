---
title: Spravovat poznámky prezentace v Pythonu
linktitle: Poznámky prezentace
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
description: "Přizpůsobte poznámky k prezentaci pomocí Aspose.Slides pro Python přes .NET. Plynule pracujte s poznámkami v PowerPointu a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámkových snímků z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na poznámkové snímky v prezentaci. Aspose.Slides umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstranit poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

Podrobnosti o čtení nebo změně rozměrů stránky s poznámkami, změně orientace a chování exportu najdete v článku [Notes Page Size](/slides/cs/python-net/notes-size/).

## **Odstranění poznámek ze snímku**
Poznámky z konkrétního snímku lze odstranit, jak je ukázáno v následujícím příkladu:

```py
import aspose.slides as slides

# Vytvořit objekt Presentation, který představuje soubor prezentace
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Odstraňování poznámek z prvního snímku
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # uložit prezentaci na disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Odstranění poznámek ze všech snímků**
Poznámky ze všech snímků v prezentaci lze odstranit, jak je ukázáno v následujícím příkladu:

```py
import aspose.slides as slides

# Vytvořit objekt Presentation, který představuje soubor prezentace 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Odstraňování poznámek ze všech snímků
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # uložit prezentaci na disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití stylu pro poznámky**
Do třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslide/) byla přidána vlastnost [notes_style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslide/notes_style/). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

```py
import aspose.slides as slides

# Vytvořit třídu Presentation, která představuje soubor prezentace
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Získat textový styl MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Nastavit symbolové odrážky pro odstavce první úrovně
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # uložit soubor PPTX na disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Která entita API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné přes správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslidemanager/) a [vlastnost](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslidemanager/notes_slide/), která vrací objekt poznámek, nebo `None`, pokud poznámky neexistují.

**Existují rozdíly v podpoře poznámek mezi verzemi PowerPointu, se kterými knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97–novější) a ODP; poznámky jsou v těchto formátech podporovány bez ohledu na to, zda je nainstalována kopie PowerPointu.