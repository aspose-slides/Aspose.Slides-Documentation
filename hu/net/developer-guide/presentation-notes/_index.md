---
title: Prezentációs jegyzetek kezelése .NET-ben
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Aspose.Slides for .NET segítségével. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel a termelékenység növelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, köztük a jegyzetek eltávolítását és a jegyzetdiák stílusának alkalmazását egy prezentációban. Az Aspose.Slides lehetővé teszi, hogy bármely diáról eltávolítsa a jegyzeteket, valamint alkalmazzon stílusokat a meglévő jegyzetekre. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról egy prezentációban.
- Jegyzetek eltávolítása az összes diáról egy prezentációban.

## **Jegyzetek eltávolítása egy diáról**
Az egyes diák jegyzetei eltávolíthatók az alábbi példában megmutatott módon:

```c#
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt reprezentál 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Az első dia jegyzeteinek eltávolítása
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// A prezentáció mentése lemezre
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Jegyzetek eltávolítása az összes diáról**
Az összes diára vonatkozó jegyzetek eltávolíthatók az alábbi példában:

```c#
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Az összes dia jegyzeteinek eltávolítása
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// A prezentáció mentése lemezre
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Jegyzetstílus hozzáadása**
A NotesStyle tulajdonság hozzá lett adva az [IMasterNotesSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslide) interfészhez és a [MasterNotesSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslide) osztályhoz. Ez a tulajdonság a jegyzet szövegének stílusát határozza meg. Az implementáció az alábbi példában látható.

```c#
// Létrehozza a Presentation osztályt, amely a prezentációs fájlt képviseli
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Lekéri a MasterNotesSlide szövegstílusát
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set Szimbólum listaelemet állít be az első szintű bekezdésekhez
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Mentse a PPTX fájlt a lemezre
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **GYIK**

**Mely API entitás biztosít hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/net/aspose.slides/notesslidemanager/) és egy [property](https://reference.aspose.com/slides/hu/net/aspose.slides/notesslidemanager/notesslide/), amely a jegyzetobjektumot adja vissza, vagy `null`, ha nincs jegyzet.

**Vannak-e különbségek a jegyzetek támogatásában a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár a Microsoft PowerPoint számos formátumát (97–újabb) és az ODP-t célozza meg; a jegyzetek támogatottak ezekben a formátumokban, anélkül, hogy telepített PowerPoint példányra lenne szükség.