---
title: Java-ban a prezentációs jegyzetek kezelése
linktitle: Prezentációs jegyzetek
type: docs
weight: 110
url: /hu/java/presentation-notes/
keywords:
- jegyzetek
- jegyzetdia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzetstílus
- master jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Testreszabhatja a prezentációs jegyzeteket az Aspose.Slides for Java segítségével. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel, hogy növelje a termelékenységét."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy prezentációból. Ebben a témában bemutatjuk ezt a funkciót, beleértve, hogyan távolítható el a jegyzet, és hogyan alkalmazható stílus a jegyzetdiákra egy prezentációban. Az Aspose.Slides lehetővé teszi, hogy jegyzeteket távolítson el bármely diáról, valamint stílust alkalmazzon a meglévő jegyzetekre. A fejlesztők a jegyzeteket a következő módokon távolíthatják el:
- Jegyzetek eltávolítása egy adott diáról egy prezentációban.
- Jegyzetek eltávolítása az összes diáról egy prezentációban.

## **Jegyzetek eltávolítása egy diáról**

A konkrét dia jegyzetei eltávolíthatók, amint az alábbi példában látható:
```java
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

## **Jegyzetek eltávolítása egy prezentációból**

Egy prezentáció összes dia jegyzetei eltávolíthatók, ahogyan az alábbi példában látható:
```java
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

[getNotesStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) metódust hozzáadták a [IMasterNotesSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IMasterNotesSlide) interfészhez és a [MasterNotesSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/MasterNotesSlide) osztályhoz. Ez a tulajdonság a jegyzet szövegének stílusát adja meg. A megvalósítást az alábbi példában mutatjuk be.
```java
// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Lekéri a MasterNotesSlide szövegstílusát
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Beállítja a szimbólum jelölőt az első szintű bekezdésekhez
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Melyik API-entitás biztosít hozzáférést egy adott dia jegyzetéhez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notesslidemanager/) és egy [method](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) amely visszaadja a jegyzet objektumot, vagy `null`, ha nincs jegyzet.

**Vannak-e különbségek a jegyzetek támogatásában a PowerPoint verziók között, amelyeken a könyvtár működik?**

A könyvtár a Microsoft PowerPoint széles körű formátumait (97-újabb) és az ODP-t célozza; a jegyzetek támogatottak ezekben a formátumokban, függetlenül attól, hogy telepített PowerPoint példány áll-e rendelkezésre.