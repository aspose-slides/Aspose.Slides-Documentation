---
title: Java prezentációs jegyzetek kezelése
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/java/presentation-notes/
keywords:
- jegyzetek
- jegyzetdiák
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzet stílus
- mester jegyzetek
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Aspose.Slides for Java segítségével. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel, hogy növelje a hatékonyságát."
---
## **Áttekintés**

Aspose.Slides támogatja a jegyzetdiák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolítását és a jegyzetdiákra való stílus alkalmazását egy prezentációban. Az Aspose.Slides lehetővé teszi, hogy jegyzeteket távolítson el bármely diáról, valamint alkalmazzon formázást a meglévő jegyzetekre. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról a prezentációban.
- Jegyzetek eltávolítása az összes diáról a prezentációban.

A jegyzetoldal méreteinek olvasásához vagy módosításához, az orientáció váltásához és az export viselkedés ellenőrzéséhez lásd a [Jegyzetoldal mérete](/slides/hu/java/notes-size/).

## **Jegyzetek eltávolítása egy diáról**
Egy adott diáról a jegyzetek eltávolíthatók, ahogyan az alábbi példában látható:

```java
import com.aspose.slides.*;

// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Az első dia jegyzeteinek eltávolítása
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // A prezentáció mentése lemezre
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Jegyzetek eltávolítása egy előadáson belül**
Az összes diából származó jegyzetek eltávolíthatók, ahogyan az alábbi példában látható:

```java
import com.aspose.slides.*;

// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Az összes dia jegyzeteinek eltávolítása
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // A prezentáció mentése lemezre
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Jegyzetstílus hozzáadása**
A [getNotesStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) metódus hozzáadva lett az [IMasterNotesSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterNotesSlide) interfészhez és a [MasterNotesSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/MasterNotesSlide) osztályhoz. Ez a tulajdonság a jegyzet szövegének stílusát határozza meg. A megvalósítást az alábbi példában mutatjuk be.

```java
import com.aspose.slides.*;

// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Lekérdezi a MasterNotesSlide szövegstílusát
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Beállítja a szimbólum típusú felsorolást az első szintű bekezdésekhez
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gyakran Ismételt Kérdések**

**Melyik API entitás biztosítja a hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notesslidemanager/) és egy [metódus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) amely visszaadja a jegyzet objektumot, vagy `null`, ha nincsenek jegyzetek.

**Vannak-e különbségek a jegyzet támogatásban a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár széles körű Microsoft PowerPoint formátumot (97-tól napjainkig) és ODP-t céloz meg; a jegyzetek támogatottak ezekben a formátumokban anélkül, hogy a PowerPoint telepített példányára lenne szükség.