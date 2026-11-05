---
title: Androidon a prezentációs jegyzetek kezelése
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/androidjava/presentation-notes/
keywords:
- jegyzetek
- jegyzet dia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzetstílus
- mester jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Androidra készült Aspose.Slides segítségével Java nyelven. Zökkenőmentesen dolgozhat a PowerPoint és OpenDocument jegyzetekkel, hogy növelje produktivitását."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdia eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolítását és a jegyzetdiákra való stílus alkalmazását egy prezentációban. Az Aspose.Slides lehetővé teszi, hogy bármely diáról eltávolítsa a jegyzeteket, és alkalmazzon stílust a meglévő jegyzetekre. A fejlesztők a következő módon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról egy prezentációban.
- Jegyzetek eltávolítása az összes diáról egy prezentációban.

A jegyzetoldal méretének olvasásához vagy módosításához, az orientáció váltásához és az export viselkedés ellenőrzéséhez lásd [Jegyzetoldal Mérete](/slides/hu/androidjava/notes-size/).

## **Jegyzetek eltávolítása egy diáról**
Egy adott diáról a jegyzetek eltávolíthatók, ahogyan az alábbi példában látható:

```java
import com.aspose.slides.*;

// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
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

## **Jegyzetek eltávolítása egy prezentációból**
Az összes diáról a jegyzetek eltávolíthatók, ahogyan az alábbi példában látható:

```java
import com.aspose.slides.*;

// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
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
[getNotesStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) metódust hozzáadták az [IMasterNotesSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IMasterNotesSlide) interfészhez és a [MasterNotesSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/MasterNotesSlide) osztályhoz. Ez a tulajdonság meghatározza a jegyzet szövegének stílusát. A megvalósítást az alábbi példában mutatjuk be.

```java
import com.aspose.slides.*;

// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // A MasterNotesSlide szövegstílusának lekérése
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Szimbólum felsorolást állít be az első szintű bekezdésekhez
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mely API entitás biztosítja a hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diának van egy [NotesSlideManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notesslidemanager/) és egy [method](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) amely visszaadja a jegyzet objektumot, vagy `null`, ha nincsenek jegyzetek.

**Vannak-e különbségek a jegyzetek támogatásában a különböző PowerPoint verziók között, amelyekkel a könyvtár működik?**

A könyvtár széles körű Microsoft PowerPoint formátumokat (97‑újabb) és ODP‑t céloz meg; a jegyzetek támogatottak ezekben a formátumokban, anélkül, hogy telepített PowerPoint példányra lenne szükség.