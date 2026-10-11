---
title: Prezentációs megjegyzések kezelése .NET-ben
linktitle: Prezentációs megjegyzések
type: docs
weight: 110
url: /hu/net/presentation-notes/
keywords:
- megjegyzés
- megjegyzés dia
- megjegyzés hozzáadása
- megjegyzés eltávolítása
- megjegyzés stílusa
- mester megjegyzések
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Testreszabhatja a prezentációs megjegyzéseket az Aspose.Slides .NET számára. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument megjegyzésekkel a termelékenysége növelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides támogatja a megjegyzésoldalak eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a megjegyzések eltávolítását és a megjegyzésoldalak stílusának alkalmazását egy prezentációban. Az Aspose.Slides lehetővé teszi a megjegyzések eltávolítását bármely diáról, valamint a meglévő megjegyzések formázását. A fejlesztők a következő módokon távolíthatják el a megjegyzéseket:

- Megjegyzés eltávolítása a prezentáció egy adott diájáról.
- Megjegyzések eltávolítása a prezentáció összes diájáról.

A megjegyzésoldal méretének olvasásához vagy módosításához, az orientáció átkapcsolásához és az export viselkedésének ellenőrzéséhez lásd [Megjegyzésoldal mérete](/slides/hu/net/notes-size/).

## **Megjegyzés eltávolítása egy diáról**
Az egyes diák megjegyzései az alábbi példában látható módon eltávolíthatók:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation presentation = new Presentation("AccessSlides.pptx");

// Az első dia megjegyzéseinek eltávolítása
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// A prezentáció mentése lemezre
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Megjegyzés eltávolítása az összes diáról**
A prezentáció összes diájának megjegyzései az alábbi példában látható módon eltávolíthatók:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation presentation = new Presentation("AccessSlides.pptx");

// Az összes dia megjegyzéseinek eltávolítása
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// A prezentáció mentése lemezre
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Megjegyzésstílus hozzáadása**
A NotesStyle tulajdonság hozzá lett adva az [IMasterNotesSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasternotesslide) interfészhez és a [MasterNotesSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/masternotesslide) osztályhoz. Ez a tulajdonság meghatározza a megjegyzés szövegének stílusát. A megvalósítás az alábbi példában látható.

```c#
using Aspose.Slides;

// Példányosítja a Presentation osztályt, amely a prezentációs fájlt képviseli
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Lekérdezi a MasterNotesSlide szövegstílusát
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Állítsa be a szimbólum jelölőt az első szintű bekezdésekhez
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // A PPTX fájl mentése a lemezre
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **GYIK**

### Melyik API entitás biztosít hozzáférést egy adott dia megjegyzéseihez?
A megjegyzések a dia megjegyzéskezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/net/aspose.slides/notesslidemanager/) és egy [property](https://reference.aspose.com/slides/hu/net/aspose.slides/notesslidemanager/notesslide/) amely visszaadja a megjegyzés objektumát, vagy `null` értéket, ha nincs megjegyzés.

### Vannak-e különbségek a megjegyzések támogatásában a könyvtár által támogatott PowerPoint verziók között?
A könyvtár a Microsoft PowerPoint számos formátumát (97‑től napjainkig) és az ODP‑t célozza; a megjegyzések támogatottak ezekben a formátumokban anélkül, hogy a PowerPoint telepített példányára támaszkodna.