---
title: Spravovat poznámky prezentace v .NET
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/net/presentation-notes/
keywords:
- poznámky
- snímek poznámek
- přidat poznámky
- odstranit poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte poznámky k prezentaci pomocí Aspose.Slides pro .NET. Plynule pracujte s poznámkami v PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámek ze snímků v prezentaci. V této kapitole představíme tuto funkci, včetně toho, jak odstraňovat poznámky a jak aplikovat styl na poznámky ve snímcích prezentace. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstraňovat poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

Pro čtení nebo změnu rozměrů stránky poznámek, změnu orientace a kontrolu chování exportu viz [Velikost stránky poznámek](/slides/cs/net/notes-size/).

## **Odstranit poznámky z snímku**
Poznámky konkrétního snímku lze odstranit, jak je ukázáno v příkladu níže:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation presentation = new Presentation("AccessSlides.pptx");

// Odstraňování poznámek z prvního snímku
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Uložte prezentaci na disk
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Odstranit poznámky ze všech snímků**
Poznámky ze všech snímků prezentace lze odstranit, jak je ukázáno v příkladu níže:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte objekt Presentation, který představuje soubor prezentace 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Odstraňování poznámek ze všech snímků
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Uložte prezentaci na disk
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Přidat styl poznámek**
Vlastnost NotesStyle byla přidána do rozhraní [IMasterNotesSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasternotesslide) a třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslide). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v příkladu níže.

```c#
using Aspose.Slides;

// Instancujte třídu Presentation, která představuje soubor prezentace
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Získejte styl textu MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Nastavit symbolovou odrážku pro odstavce první úrovně
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Uložte soubor PPTX na disk
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **Často kladené otázky**

### Která entita API poskytuje přístup k poznámkám konkrétního snímku?

K poznámkám se přistupuje prostřednictvím správy poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/net/aspose.slides/notesslidemanager/) a [vlastnost](https://reference.aspose.com/slides/cs/net/aspose.slides/notesslidemanager/notesslide/), která vrací objekt poznámek, nebo `null`, pokud žádné poznámky nejsou.

### Existují rozdíly v podpoře poznámek mezi verzemi PowerPointu, se kterými knihovna pracuje?

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97–newer) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.