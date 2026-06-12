---
title: Spravovat poznámky prezentace v .NET
linktitle: Poznámky prezentace
type: docs
weight: 110
url: /cs/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte poznámky prezentace pomocí Aspose.Slides pro .NET. Plynule pracujte s poznámkami PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámek ze snímků v prezentaci. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak aplikovat styl na poznámkové snímky v prezentaci. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstraňovat poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

## **Odstranit poznámky ze snímku**
Poznámky z určitého snímku lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```c#
// Vytvořte objekt Presentation, který představuje soubor prezentace 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Odstranění poznámek z prvního snímku
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Uložte prezentaci na disk
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Odstranit poznámky ze všech snímků**
Poznámky ze všech snímků prezentace lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```c#
// Vytvořte objekt Presentation, který představuje soubor prezentace 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Odstranění poznámek ze všech snímků
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
Vlastnost NotesStyle byla přidána do rozhraní [IMasterNotesSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasternotesslide) a třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslide). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

```c#
// Vytvořte třídu Presentation, která představuje soubor prezentace
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Získat styl textu MasterNotesSlide
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

**Která entita API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné prostřednictvím správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/net/aspose.slides/notesslidemanager/) a [vlastnost](https://reference.aspose.com/slides/cs/net/aspose.slides/notesslidemanager/notesslide/), která vrací objekt poznámek, nebo `null`, pokud neexistují žádné poznámky.

**Existují rozdíly v podpoře poznámek mezi verzemi PowerPointu, s nimiž knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97 a novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.